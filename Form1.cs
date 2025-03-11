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
        private const int INTERVALO_MAXIMO = 600000; //10 minutos

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
            IniciarTemporizador(config.IntervaloPing);
        }

        /// <summary>
        /// Inicia un temporizador para verificar la conexión con el servidor.
        /// </summary>
        /// <param name="intervalo"></param>

        private void IniciarTemporizador(int intervalo)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }

            timer = new System.Timers.Timer(intervalo);
            timer.Elapsed += VerificarConexionServidor;
            timer.Start();
        }

        /// <summary>
        /// Carga la configuración del archivo config.json
        /// </summary>
        private void CargarConfiguracion()
        {
            string configPath = "config.json";
         
            if (!File.Exists(configPath))
            {
                MostrarNotificacion("configuracion no encontrada, crea uno nuevo...");
                config = new Configuracion
                {
                    IPServer = "",
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
                config = JsonSerializer.Deserialize<Configuracion>(json) ?? new Configuracion();
            }

            //validar configuracion de las rutas si es valida
            ValidarConfiguracion();

            MostrarNotificacion("Configuracion cargada correctamente");
        }

        /// <summary>
        /// Valida que la configuración tenga al menos una ruta configurada.
        /// </summary>
        private void ValidarConfiguracion()
        {
            if (config.Rutas == null || config.Rutas.Count == 0 || 
                config.IPServer == null || config.nameServer == null)
            {
                MessageBox.Show("Debe configurar al menos un par de ruta", "Advertencia configuracion vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //abre el formulario
                FormConfiguracion formConfig = new FormConfiguracion();
                formConfig.ShowDialog();
            }


        }

        /// <summary>
        /// Guarda la configuración en el archivo config.json
        /// </summary>
        private void GuardarConfiguracion()
        {
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("config.json", json);
            MostrarNotificacion("Configuracion guardada con exito");
        }


        /// <summary>
        /// Configura la notificación en la barra de tareas.
        /// </summary>
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

        /// <summary>
        /// Abre el formulario de configuración al dar clic en el menú de la barra de tareas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            FormConfiguracion formConfig = new FormConfiguracion();
            if (formConfig.ShowDialog() == DialogResult.OK)
            {
                GuardarConfiguracion();
            }
        }


        /// <summary>
        /// Muestra una notificación en la barra de tareas.
        /// </summary>
        /// <param name="mensaje"></param>
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
        /// <summary>
        /// Inicia el monitoreo de actualizaciones en las rutas configuradas.
        /// </summary>
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
                    //MostrarNotificacion("5. Monitoreo de actualizaciones iniciado");
                }

                serverOnline = algunServidorDisponible;
            }
            catch (Exception ex)
            {
                MostrarNotificacion($"6. Error en monitoreo: {ex.Message}");
            }
        }
        /// <summary>
        /// Configura los watchers para monitorear los cambios en las rutas configuradas del servidor.
        /// </summary>
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
        /// <summary>
        /// Evento que se dispara cuando se detecta un cambio en el servidor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            //MostrarNotificacion($"8. Cambio detectado en {e.FullPath}, iniciando actualizacion...");
            ActualizarSoftware();
        }

        /// <summary>
        /// Evento que se dispara cuando se renombra un archivo en el servidor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            //MostrarNotificacion($"9. Archivo renombrado de {e.OldFullPath} a {e.FullPath}, iniciando actualizacion...");
            ActualizarSoftware();
        }

        /// <summary>
        /// Verifica la conexión con el servidor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void VerificarConexionServidor(object? sender, ElapsedEventArgs e)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply? reply = ping.Send(config.nameServer, 5000);

                    if (reply.Status == IPStatus.Success)
                    {
                        //si el servidor esta en linea, se restablece el intervalo
                        if (config.IntervaloPing != 30000)
                        {
                            config.IntervaloPing = 30000;
                            //reiniciamos el temporizador
                            IniciarTemporizador(config.IntervaloPing);
                        }
                        MostrarNotificacion("Servidor en linea");
                        serverOnline = true;
                        VerificarCambios();
                        //reiniciar monitoreo
                        IniciarMonitoreo();
                    }
                    else
                    {
                        AjustarIntervalo();
                    }

                }
            }
            catch (Exception ex)
            {
                AjustarIntervalo();
            }
        }

        /// <summary>
        /// Aumenta progresivamente el intervalo de verificación si el servidor está caído.
        /// </summary>
        private void AjustarIntervalo()
        {
            if (config.IntervaloPing < INTERVALO_MAXIMO)
            {
                config.IntervaloPing *= 2; // Duplicar el tiempo
                if (config.IntervaloPing > INTERVALO_MAXIMO)
                    config.IntervaloPing = INTERVALO_MAXIMO;
            }

            IniciarTemporizador(config.IntervaloPing);
        }

        /// <summary>
        /// Detiene el monitoreo de actualizaciones
        /// </summary>
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

        /// <summary>
        /// Actualiza el software en el cliente con los archivos del servidor.
        /// </summary>
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

        /// <summary>
        /// Cierra un proceso en ejecución.
        /// </summary>
        /// <param name="nombreSoft"></param>
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
        /// <summary>
        /// Copia los archivos y carpetas de origen a destino.
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
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
                    System.Diagnostics.Debug.WriteLine($"contenido del foreach al copiar archivos: {archivo}");

                    string destinoArchivo = Path.Combine(destino, Path.GetFileName(archivo));
                    //comparar tamaño de archivo antes de copiar
                    if (!File.Exists(destinoArchivo) || new FileInfo(archivo).Length != new FileInfo(destinoArchivo).Length)
                    {
                        File.Copy(archivo, destinoArchivo, true);
                        //MostrarNotificacion($"17. Archivo actualizado: {archivo}");
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
        /// <summary>
        /// verifica los cambios en el servidor y actualiza los archivos en el cliente.
        /// </summary>
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

                        FileInfo infoServidor = new FileInfo(archivo);
                        FileInfo infoDestino = new FileInfo(archivoDestino);


                        if (!File.Exists(archivoDestino) || infoServidor.Length != infoDestino.Length 
                            || infoServidor.LastWriteTimeUtc > infoDestino.LastWriteTimeUtc)
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

        /// <summary>
        /// Evento que se dispara cuando se detecta un cambio en el archivo de configuración.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cierra la aplicación y libera los recursos.
        /// </summary>
        private void CerrarAplicacion()
        {
            watcher?.Dispose();
            watcher = null;
            timer?.Stop();
            timer = null;
            notifyIcon.Visible = false;
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
