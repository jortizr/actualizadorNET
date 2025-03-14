using actualizadorNET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace actualizadorNET
{
    public partial class FormConfiguracion : Form
    {
        private Configuracion config;
        private string configPath = "config.json";

        public FormConfiguracion()
        {
            InitializeComponent();
            CargarConfiguracion();
        }

        private void CargarConfiguracion()
        {
            if (System.IO.File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                config = JsonSerializer.Deserialize<Configuracion>(json) ?? new Configuracion();
            }
            else
            {
                config = new Configuracion();
            }
            ActualizarLista();
            txtIntervalo.Text = config.IntervaloPing.ToString();
            txtHost.Text = config.nameServer;
            txtIP.Text = config.IPServer;
            txtUsername.Text = config.Username;
            txtPassword.Text = config.Password;
        }

        private void ActualizarLista()
        {
            dgvRutas.DataSource = null;
            dgvRutas.DataSource = config.Rutas;
            if (!string.IsNullOrEmpty(config.nameServer) && !string.IsNullOrEmpty(config.IPServer))
            {
                txtHost.Text = config.nameServer;
                txtIP.Text = config.IPServer;
            }

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string servidor = txtServidor.Text.Trim();
            string destino = txtDestino.Text.Trim();

            if (string.IsNullOrEmpty(servidor) || string.IsNullOrEmpty(destino))
            {
                MessageBox.Show("Debe ingresar ambas rutas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            config.Rutas.Add(new CarpetaConfig { Servidor = servidor, Destino = destino });
            ActualizarLista();
            txtServidor.Text = string.Empty;
            txtDestino.Text = string.Empty;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRutas.SelectedCells[0].RowIndex;
                //verificar el indice seleccionado
                if (rowIndex >= 0 && rowIndex < config.Rutas.Count)
                {
                    config.Rutas.RemoveAt(rowIndex);
                    ActualizarLista();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIntervalo.Text, out int intervalo))
            {
                config.IntervaloPing = intervalo;
            }
            else
            {
                MessageBox.Show("El intervalo debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtHost.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del servidor", "Campo del servidor vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            config.nameServer = txtHost.Text.Trim();
            File.WriteAllText(configPath, JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true }));
            MessageBox.Show("Configuración guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {

        }

    }
}
