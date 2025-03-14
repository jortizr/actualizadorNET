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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfiguracion));
            dgvRutas = new DataGridView();
            servidorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            destinoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            carpetaConfigBindingSource = new BindingSource(components);
            txtListaRutas = new Label();
            txtIntervalo = new TextBox();
            label1 = new Label();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            txtServidor = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtDestino = new TextBox();
            btnCancelar = new Button();
            label4 = new Label();
            txtHost = new TextBox();
            label5 = new Label();
            txtIP = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvRutas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)carpetaConfigBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvRutas
            // 
            dgvRutas.AllowUserToAddRows = false;
            dgvRutas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvRutas.AutoGenerateColumns = false;
            dgvRutas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvRutas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutas.Columns.AddRange(new DataGridViewColumn[] { servidorDataGridViewTextBoxColumn, destinoDataGridViewTextBoxColumn });
            dgvRutas.DataSource = carpetaConfigBindingSource;
            dgvRutas.EnableHeadersVisualStyles = false;
            dgvRutas.Location = new Point(12, 211);
            dgvRutas.Name = "dgvRutas";
            dgvRutas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgvRutas.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvRutas.Size = new Size(427, 151);
            dgvRutas.TabIndex = 0;
            // 
            // servidorDataGridViewTextBoxColumn
            // 
            servidorDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            servidorDataGridViewTextBoxColumn.DataPropertyName = "Servidor";
            servidorDataGridViewTextBoxColumn.HeaderText = "Servidor";
            servidorDataGridViewTextBoxColumn.MinimumWidth = 6;
            servidorDataGridViewTextBoxColumn.Name = "servidorDataGridViewTextBoxColumn";
            // 
            // destinoDataGridViewTextBoxColumn
            // 
            destinoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            destinoDataGridViewTextBoxColumn.DataPropertyName = "Destino";
            destinoDataGridViewTextBoxColumn.HeaderText = "Destino";
            destinoDataGridViewTextBoxColumn.MinimumWidth = 6;
            destinoDataGridViewTextBoxColumn.Name = "destinoDataGridViewTextBoxColumn";
            // 
            // carpetaConfigBindingSource
            // 
            carpetaConfigBindingSource.DataSource = typeof(Models.CarpetaConfig);
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
            txtIntervalo.Location = new Point(270, 181);
            txtIntervalo.Name = "txtIntervalo";
            txtIntervalo.PlaceholderText = "segundos";
            txtIntervalo.Size = new Size(89, 23);
            txtIntervalo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 181);
            label1.Name = "label1";
            label1.Size = new Size(253, 20);
            label1.TabIndex = 3;
            label1.Text = "Intervalo de verificacion host (seg)";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(360, 113);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(360, 149);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(145, 368);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtServidor
            // 
            txtServidor.ForeColor = Color.Black;
            txtServidor.Location = new Point(135, 113);
            txtServidor.Name = "txtServidor";
            txtServidor.PlaceholderText = "\\\\SERVIDOR\\Compartida";
            txtServidor.Size = new Size(224, 23);
            txtServidor.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 113);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 9;
            label2.Text = "Ruta servidor:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 149);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 10;
            label3.Text = "Ruta destino:";
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(132, 150);
            txtDestino.Name = "txtDestino";
            txtDestino.PlaceholderText = "C:\\enviasql\\program";
            txtDestino.Size = new Size(224, 23);
            txtDestino.TabIndex = 11;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(226, 368);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 49);
            label4.Name = "label4";
            label4.Size = new Size(131, 20);
            label4.TabIndex = 12;
            label4.Text = "Nombre del host:";
            // 
            // txtHost
            // 
            txtHost.ForeColor = SystemColors.InfoText;
            txtHost.Location = new Point(149, 50);
            txtHost.Name = "txtHost";
            txtHost.PlaceholderText = "08TEC01";
            txtHost.Size = new Size(105, 23);
            txtHost.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(267, 49);
            label5.Name = "label5";
            label5.Size = new Size(27, 20);
            label5.TabIndex = 14;
            label5.Text = "IP:";
            // 
            // txtIP
            // 
            txtIP.ForeColor = SystemColors.InfoText;
            txtIP.Location = new Point(295, 50);
            txtIP.Name = "txtIP";
            txtIP.PlaceholderText = "ip del servidor";
            txtIP.Size = new Size(140, 23);
            txtIP.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 81);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 16;
            label6.Text = "Usuario host:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(250, 81);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 17;
            label7.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(132, 82);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "digita12";
            txtUsername.Size = new Size(112, 23);
            txtUsername.TabIndex = 18;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(336, 83);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "contraseña";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 19;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // FormConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 402);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtIP);
            Controls.Add(label5);
            Controls.Add(txtHost);
            Controls.Add(label4);
            Controls.Add(txtDestino);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtServidor);
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
            ((System.ComponentModel.ISupportInitialize)carpetaConfigBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRutas;
        private Label txtListaRutas;
        private TextBox txtIntervalo;
        private Label label1;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnGuardar;
        private TextBox txtServidor;
        private Label label2;
        private Label label3;
        private TextBox txtDestino;
        private Button btnCancelar;
        private BindingSource carpetaConfigBindingSource;
        private DataGridViewTextBoxColumn servidorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn destinoDataGridViewTextBoxColumn;
        private Label label4;
        private TextBox txtHost;
        private Label label5;
        private TextBox txtIP;
        private Label label6;
        private Label label7;
        private TextBox txtUsername;
        private TextBox txtPassword;
    }
}