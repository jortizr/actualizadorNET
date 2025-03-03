using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Timers;
using System.Net.NetworkInformation;
using System.Drawing.Text;
//importando la clase
using actualizadorNET.Models;
using System.Text.Json;



namespace actualizadorNET
{
    public partial class Form1 : Form
    {
        private Configuracion config;
        private FileSystemWatcher? watcher;
        private System.Timers.Timer? timer;
        private NotifyIcon notifyIcon;
        private List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();

        private bool serverOnline = true;
        public Form1()
        {
            CargarConfiguracion();
            notifyIcon = new NotifyIcon(); // Asegurar que se inicializa
            InitializeComponent();

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Opacity = 0;//transparente la ventana

            //verifica si hubo cambios en el servidor
            VerificarCambios();

            ConfigurarNotificacion();
            IniciarMonitoreo();

            //iniciar el temporizador para verificar la conexion
            timer = new System.Timers.Timer(30000);
            timer.Elapsed += VerificarConexionServidor;
            timer.Start();
        }

        private void CargarConfiguracion()
        {
            string configPath = "config.json";
         
            if (!File.Exists(configPath))
            {
                MostrarNotificacion("1.Archivo de configuracion no encontrado, crea uno nuevo...");
                config = new Configuracion
                {
                    nameServer = "",
                    IntervaloPing = 30000,
                    Rutas = new List<CarpetaConfig>()
                };
                File.WriteAllText(configPath, JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true }));

                MessageBox.Show("No existen rutas, por favor configura las rutas", 
                    "Configuracion requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //abrir formulario de configuracion
                FormConfiguracion formConfig = new FormConfiguracion();
                    if (formConfig.ShowDialog() == DialogResult.OK)
                    {
                        GuardarConfiguracion();
                    }
            }
            else
            {
                string json = File.ReadAllText(configPath);
                System.Diagnostics.Debug.WriteLine(json);
                config = JsonSerializer.Deserialize<Configuracion>(json) ?? new Configuracion();
            }

            //validar configuracion de las rutas si es valida
            ValidarConfiguracion();

            MostrarNotificacion("2.Configuracion cargada correctamente");
        }

        private void ValidarConfiguracion()
        {
            if (config.Rutas == null || config.Rutas.Count == 0)
            {
                MessageBox.Show("Debe configurar al menos un par de ruta", "Advertencia configuracion vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //abre el formulario
                FormConfiguracion formConfig = new FormConfiguracion();
                formConfig.ShowDialog();
            }


        }

        private void GuardarConfiguracion()
        {
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("config.json", json);
            MostrarNotificacion("3.Configuracion guardada con exito");
        }
        private void ConfigurarNotificacion()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = new Icon(@"Resources/envia.ico"),
                Visible = true,
                Text = "Actualizador DTI en segundo plano"
            };

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Actualizar manualmente", null, (s, e) => ActualizarSoftware());
            menu.Items.Add("Salir", null, (s, e) => CerrarAplicacion());
            menu.Items.Add("Configuración", null, (s, e) => btnConfiguracion_Click(s, e));
            notifyIcon.ContextMenuStrip = menu;
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            FormConfiguracion formConfig = new FormConfiguracion();
            if (formConfig.ShowDialog() == DialogResult.OK)
            {
                GuardarConfiguracion();
            }
        }

        private void CerrarAplicacion()
        {
            watcher?.Dispose();
            watcher = null;
            timer?.Stop();
            timer = null;
            notifyIcon.Visible = false;
            Application.Exit();
        }

        private void MostrarNotificacion(string mensaje)
        {
            using (NotifyIcon notifyIcon = new NotifyIcon())
            {
                notifyIcon.Icon = SystemIcons.Information;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = "Actualizador DTI";
                notifyIcon.BalloonTipText = $"{mensaje}";
                // La notificación dura 3 segundos
                notifyIcon.ShowBalloonTip(3000);

                // Esperar un momento para asegurar que la notificación se muestra
                System.Threading.Thread.Sleep(4000);
                // Ocultar y eliminar el icono después de la notificación
                notifyIcon.Visible = false;
            }



        }

        private void IniciarMonitoreo()
        {
            try
            {
                bool algunServidorDisponible = false;
                //verificar si la carpeta del servidor esta disponible
                foreach (var ruta in config.Rutas)
                {
                    if (Directory.Exists(ruta.Servidor))
                    {
                        algunServidorDisponible = true;
                    }
                    else
                    {
                        MostrarNotificacion($"4. La ruta del Servidor no disponible: {ruta.Servidor}. " +
                            $"Verifica las credenciales del servidor...");
                    }
                }

                if (algunServidorDisponible)
                {
                    ConfigurarWatcher(); // Llamada sin parámetros
                    MostrarNotificacion("5. Monitoreo de actualizaciones iniciado");
                }

                serverOnline = algunServidorDisponible;
            }
            catch (Exception ex)
            {
                MostrarNotificacion($"6. Error en monitoreo: {ex.Message}");
            }
        }

        private void ConfigurarWatcher()
        {
            //primero, liberar los watchers anteriores
            foreach (var watcher in watchers)
            {
                watcher.Dispose();
            }
            watchers.Clear();

            foreach (var carpeta in config.Rutas)
            {
                if (!Directory.Exists(carpeta.Servidor))
                {
                    MostrarNotificacion($"7. La carpeta {carpeta.Servidor} no existe.");
                    continue;
                }

                FileSystemWatcher watcher = new FileSystemWatcher
                {
                    Path = carpeta.Servidor,
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                    Filter = "*.*",
                    IncludeSubdirectories = true,
                    EnableRaisingEvents = true
                };

                watcher.Changed += OnChanged;
                watcher.Renamed += OnRenamed;
                watchers.Add(watcher);
            }

        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            MostrarNotificacion($"8. Cambio detectado en {e.FullPath}, iniciando actualizacion...");
            ActualizarSoftware();
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            MostrarNotificacion($"9. Archivo renombrado de {e.OldFullPath} a {e.FullPath}, iniciando actualizacion...");
            ActualizarSoftware();
        }

        private void VerificarConexionServidor(object? sender, ElapsedEventArgs e)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply? reply = null;
                    try
                    {
                        reply = ping.Send(config.nameServer, 5000);
                    }
                    catch (PingException)
                    {
                        reply = null;
                    }


                    if (reply != null && reply.Status == IPStatus.Success)
                    {
                        if (!serverOnline)
                        {
                            MostrarNotificacion("10. Servidor en línea, reiniciando monitoreo...");
                            serverOnline = true;
                            VerificarCambios();
                            //reiniciar monitoreo
                            IniciarMonitoreo();
                        }
                    }
                    else
                    {
                        if (serverOnline)
                        {
                            MostrarNotificacion("11. Servidor fuera de línea, monitoreo detenido...");
                            DetenerMonitoreo();
                            serverOnline = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarNotificacion($"12. Error al verificar conexión: {ex.Message}");
            }
        }

        private void DetenerMonitoreo()
        {
            try
            {
                foreach (var watcher in watchers)
                {
                        //desactiva eventos
                        watcher.EnableRaisingEvents = false;
                        //libera recursos
                        watcher.Dispose();
                }
                watchers.Clear();
            }
            catch (Exception ex)
            {
                MostrarNotificacion($"13. Error al detener monitoreo: {ex.Message}");
            }
        }
        private void ActualizarSoftware()
        {
            try
            {
                //cierra el software si esta en ejecucion
                killprocess("envia.exe");
                //copiar todos los archivos y carpetas del servidor al destino
                foreach (var carpeta in config.Rutas)
                {
                    CopiarCarpetas(carpeta.Servidor, carpeta.Destino);
                }

                MostrarNotificacion("14. Actualización completada");
            }
            catch (Exception ex)
            {
                MostrarNotificacion($"15. Error en actualización: {ex.Message}");
            }
        }

        private void killprocess(string nombreSoft)
        {
            foreach (var process in Process.GetProcessesByName(nombreSoft))
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                }
                catch (Exception ex)
                {
                    MostrarNotificacion($"16. Error al cerrar {nombreSoft}: {ex.Message}");
                }
            }
        }

        private void CopiarCarpetas(string origen, string destino)
        {
            try
            {

                //crear la carpeta de destino si no existe
                if (!Directory.Exists(destino))
                {
                    Directory.CreateDirectory(destino);
                }
                //copiar todos los archivos de origen a destino
                foreach (string archivo in Directory.GetFiles(origen))
                {
                    string destinoArchivo = Path.Combine(destino, Path.GetFileName(archivo));
                    //comparar tamaño de archivo antes de copiar
                    if (!File.Exists(destinoArchivo) || new FileInfo(archivo).Length != new FileInfo(destinoArchivo).Length)
                    {
                        File.Copy(archivo, destinoArchivo, true);
                        MostrarNotificacion($"17. Archivo actualizado: {archivo}");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"18. Archivo sin cambios: {archivo}");

                    }
                }

                // Copiar todas las carpetas (recursivo)
                foreach (string subCarpeta in Directory.GetDirectories(origen))
                {
                    string destinoSubCarpeta = Path.Combine(destino, Path.GetFileName(subCarpeta));
                    CopiarCarpetas(subCarpeta, destinoSubCarpeta);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"19. Error al copiar archivos: {ex.Message}");
            }
        }

        private void VerificarCambios()
        {

            try
            {
                foreach (var carpeta in config.Rutas)
                {
                    if (!Directory.Exists(carpeta.Servidor)) continue;

                    foreach (string archivo in Directory.GetFiles(carpeta.Servidor))
                    {
                        string archivoDestino = Path.Combine(carpeta.Destino, Path.GetFileName(archivo));

                        if (!File.Exists(archivoDestino) || new FileInfo(archivo).Length != new FileInfo(archivoDestino).Length)
                        {
                            File.Copy(archivo, archivoDestino, true);
                            MostrarNotificacion($"20. Archivo actualizado: {archivo}");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MostrarNotificacion($"21. Error al verificar cambios: {ex.Message}");
            }
        }
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
