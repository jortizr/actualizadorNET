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
        public Configuracion Configuracion { get; private set; }
        public FormConfiguracion()
        {
            InitializeComponent();
            Configuracion = new Configuracion();

            //cargar las rutas en el dataGridView
            dgvRutas.DataSource = new BindingSource { DataSource = Configuracion.Rutas };
            txtIntervalo.Text = Configuracion.IntervaloVerificacion.ToString();
        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Configuracion.Rutas.Add(new RutaSincronizacion { ServidorPath = "", DestinoPath = "" });
            dgvRutas.DataSource = new BindingSource { DataSource = Configuracion.Rutas };
        }
    }
}
