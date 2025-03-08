﻿namespace actualizadorNET
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
            dgvRutas.Location = new Point(14, 236);
            dgvRutas.Margin = new Padding(3, 4, 3, 4);
            dgvRutas.Name = "dgvRutas";
            dgvRutas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgvRutas.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvRutas.Size = new Size(488, 201);
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
            txtListaRutas.Location = new Point(137, 21);
            txtListaRutas.Name = "txtListaRutas";
            txtListaRutas.Size = new Size(251, 25);
            txtListaRutas.TabIndex = 1;
            txtListaRutas.Text = "Lista de rutas configuradas";
            // 
            // txtIntervalo
            // 
            txtIntervalo.Location = new Point(337, 196);
            txtIntervalo.Margin = new Padding(3, 4, 3, 4);
            txtIntervalo.Name = "txtIntervalo";
            txtIntervalo.PlaceholderText = "segundos";
            txtIntervalo.Size = new Size(84, 27);
            txtIntervalo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 196);
            label1.Name = "label1";
            label1.Size = new Size(319, 25);
            label1.TabIndex = 3;
            label1.Text = "Intervalo de verificacion host (seg)";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(411, 105);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 31);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(411, 153);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 31);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(166, 445);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(86, 31);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtServidor
            // 
            txtServidor.ForeColor = Color.Black;
            txtServidor.Location = new Point(154, 105);
            txtServidor.Margin = new Padding(3, 4, 3, 4);
            txtServidor.Name = "txtServidor";
            txtServidor.PlaceholderText = "\\\\SERVIDOR\\Compartida";
            txtServidor.Size = new Size(255, 27);
            txtServidor.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 105);
            label2.Name = "label2";
            label2.Size = new Size(138, 25);
            label2.TabIndex = 9;
            label2.Text = "Ruta servidor:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 153);
            label3.Name = "label3";
            label3.Size = new Size(129, 25);
            label3.TabIndex = 10;
            label3.Text = "Ruta destino:";
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(151, 154);
            txtDestino.Margin = new Padding(3, 4, 3, 4);
            txtDestino.Name = "txtDestino";
            txtDestino.PlaceholderText = "C:\\enviasql\\program";
            txtDestino.Size = new Size(255, 27);
            txtDestino.TabIndex = 11;
            txtDestino.TextChanged += txtDestino_TextChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(258, 445);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 31);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(14, 65);
            label4.Name = "label4";
            label4.Size = new Size(166, 25);
            label4.TabIndex = 12;
            label4.Text = "Nombre del host:";
            // 
            // txtHost
            // 
            txtHost.ForeColor = SystemColors.InfoText;
            txtHost.Location = new Point(180, 63);
            txtHost.Margin = new Padding(3, 4, 3, 4);
            txtHost.Name = "txtHost";
            txtHost.PlaceholderText = "0TEC0";
            txtHost.Size = new Size(227, 27);
            txtHost.TabIndex = 13;
            // 
            // FormConfiguracion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 488);
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
            Margin = new Padding(3, 4, 3, 4);
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
    }
}