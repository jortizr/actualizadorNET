namespace actualizadorNET
{
    partial class FormConfiguracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfiguracion));
            dgvRutas = new DataGridView();
            Servidor = new DataGridViewTextBoxColumn();
            Destino = new DataGridViewTextBoxColumn();
            txtListaRutas = new Label();
            txtIntervalo = new TextBox();
            label1 = new Label();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRutas).BeginInit();
            SuspendLayout();
            // 
            // dgvRutas
            // 
            dgvRutas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutas.Columns.AddRange(new DataGridViewColumn[] { Servidor, Destino });
            dgvRutas.Location = new Point(12, 39);
            dgvRutas.Name = "dgvRutas";
            dgvRutas.Size = new Size(455, 275);
            dgvRutas.TabIndex = 0;
            // 
            // Servidor
            // 
            Servidor.HeaderText = "Servidor";
            Servidor.Name = "Servidor";
            // 
            // Destino
            // 
            Destino.HeaderText = "Destino";
            Destino.Name = "Destino";
            // 
            // txtListaRutas
            // 
            txtListaRutas.AutoSize = true;
            txtListaRutas.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtListaRutas.Location = new Point(120, 16);
            txtListaRutas.Name = "txtListaRutas";
            txtListaRutas.Size = new Size(198, 20);
            txtListaRutas.TabIndex = 1;
            txtListaRutas.Text = "Lista de rutas configuradas";
            // 
            // txtIntervalo
            // 
            txtIntervalo.Location = new Point(236, 326);
            txtIntervalo.Name = "txtIntervalo";
            txtIntervalo.Size = new Size(92, 23);
            txtIntervalo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 329);
            label1.Name = "label1";
            label1.Size = new Size(218, 20);
            label1.TabIndex = 3;
            label1.Text = "Intervalo de verificacion (seg)";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(473, 39);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(473, 68);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(473, 97);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(473, 126);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(txtIntervalo);
            Controls.Add(txtListaRutas);
            Controls.Add(dgvRutas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormConfiguracion";
            Text = "Formulario de Configuracion";
            Load += FormConfiguracion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRutas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRutas;
        private DataGridViewTextBoxColumn Servidor;
        private DataGridViewTextBoxColumn Destino;
        private Label txtListaRutas;
        private TextBox txtIntervalo;
        private Label label1;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}