using actualizadorNET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace actualizadorNET
{
    public partial class FormConfiguracion : Form
    {
        public Configuracion configuracion { get; private set; }
        public FormConfiguracion()
        {
            InitializeComponent();
            Configuracion = new Configuracion();

            //cargar las rutas en el dataGridView
            dgvRutas.DataSource = new BindingSource { DataSource = Configuracion.Rutas };
            txtIntervalo.Text = Configuracion.IntervaloPing.ToString();
        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            Configuracion = new Configuracion();

            //cargar las rutas en el dataGridView
            dgvRutas.DataSource = new BindingSource { DataSource = Configuracion.Rutas };
            txtIntervalo.Text = Configuracion.IntervaloPing.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Configuracion.Rutas.Add(new RutaSincronizacion { ServidorPath = "", DestinoPath = "" });
            dgvRutas.DataSource = new BindingSource { DataSource = Configuracion.Rutas };
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
            {
                var ruta = dgvRutas.SelectedRows[0].DataBoundItem as RutaSincronizacion;
                Configuracion.Rutas.Remove(ruta);
                dgvRutas.DataSource = new BindingSource { DataSource = Configuracion.Rutas };
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIntervalo.Text, out int intervalo))
            {
                Configuracion.IntervaloPing = intervalo;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
