﻿namespace FrbaHotel.AbmUsuario
{
    partial class ListadoUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoUsuario));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hotelCombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rolCombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.limpiar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.nuevo = new System.Windows.Forms.Button();
            this.resultados = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hotelCombobox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rolCombobox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.usuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // hotelCombobox
            // 
            this.hotelCombobox.FormattingEnabled = true;
            this.hotelCombobox.Location = new System.Drawing.Point(103, 70);
            this.hotelCombobox.Name = "hotelCombobox";
            this.hotelCombobox.Size = new System.Drawing.Size(114, 21);
            this.hotelCombobox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hotel";
            // 
            // rolCombobox
            // 
            this.rolCombobox.FormattingEnabled = true;
            this.rolCombobox.Location = new System.Drawing.Point(103, 43);
            this.rolCombobox.Name = "rolCombobox";
            this.rolCombobox.Size = new System.Drawing.Size(114, 21);
            this.rolCombobox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Rol";
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(103, 19);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(114, 20);
            this.usuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(13, 120);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 1;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(161, 120);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 1;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // nuevo
            // 
            this.nuevo.Location = new System.Drawing.Point(184, 310);
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(75, 23);
            this.nuevo.TabIndex = 3;
            this.nuevo.Text = "Nuevo";
            this.nuevo.UseVisualStyleBackColor = true;
            this.nuevo.Click += new System.EventHandler(this.nuevo_Click);
            // 
            // resultados
            // 
            this.resultados.AllowUserToAddRows = false;
            this.resultados.AllowUserToDeleteRows = false;
            this.resultados.AllowUserToResizeRows = false;
            this.resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4});
            this.resultados.Location = new System.Drawing.Point(13, 154);
            this.resultados.MultiSelect = false;
            this.resultados.Name = "resultados";
            this.resultados.ReadOnly = true;
            this.resultados.Size = new System.Drawing.Size(246, 150);
            this.resultados.TabIndex = 8;
            this.resultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultados_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Usuario";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Text = "Seleccionar";
            // 
            // ListadoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 338);
            this.Controls.Add(this.resultados);
            this.Controls.Add(this.nuevo);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListadoUsuario";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Usuarios";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.ComboBox rolCombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox hotelCombobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button nuevo;
        private System.Windows.Forms.DataGridView resultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;


    }
}