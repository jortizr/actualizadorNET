using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace actualizadorNET
{
    public partial class Form1 : Form
    {
        private FileSystemWatcher watcher;
        private string servidorPath = @"\\SERVIDOR\Usuario\Documents\GitHub\actualizadorNET\envia.exe";
        private string destinoPath = @"C:\enviasql\program\envia.exe";
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Opacity = 0;//transparente la ventana

            ConfigurarNotificacion();
            IniciarMonitoreo();
        }

        private void ConfigurarNotificacion()
        {
            NotifyIcon notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                Text = "Actualizador DTI en segundo plano"
            };

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Actualizar manualmente", null, (s,e) => ActualizarSoftware());
            menu.Items.Add("Salir", null, (s,e)=> Application.Exit());
            notifyIcon.ContextMenuStrip = menu;

        } 
    }
}
