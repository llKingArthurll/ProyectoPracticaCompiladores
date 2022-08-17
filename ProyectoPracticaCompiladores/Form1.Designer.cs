namespace ProyectoPracticaCompiladores
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.lblSalida = new System.Windows.Forms.Label();
            this.lblReservada = new System.Windows.Forms.Label();
            this.txtReservadas = new System.Windows.Forms.TextBox();
            this.lblNoReservadas = new System.Windows.Forms.Label();
            this.txtNoReservadas = new System.Windows.Forms.TextBox();
            this.txtOperadores = new System.Windows.Forms.TextBox();
            this.lblOperadores = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(35, 51);
            this.txtEntrada.Multiline = true;
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(405, 105);
            this.txtEntrada.TabIndex = 0;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(476, 60);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 23);
            this.btnEjecutar.TabIndex = 1;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(476, 90);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(476, 120);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(32, 35);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(47, 13);
            this.lblEntrada.TabIndex = 4;
            this.lblEntrada.Text = "Entrada:";
            // 
            // lblSalida
            // 
            this.lblSalida.AutoSize = true;
            this.lblSalida.Location = new System.Drawing.Point(32, 196);
            this.lblSalida.Name = "lblSalida";
            this.lblSalida.Size = new System.Drawing.Size(39, 13);
            this.lblSalida.TabIndex = 5;
            this.lblSalida.Text = "Salida:";
            // 
            // lblReservada
            // 
            this.lblReservada.AutoSize = true;
            this.lblReservada.Location = new System.Drawing.Point(32, 218);
            this.lblReservada.Name = "lblReservada";
            this.lblReservada.Size = new System.Drawing.Size(67, 13);
            this.lblReservada.TabIndex = 6;
            this.lblReservada.Text = "Reservadas:";
            // 
            // txtReservadas
            // 
            this.txtReservadas.Enabled = false;
            this.txtReservadas.Location = new System.Drawing.Point(35, 234);
            this.txtReservadas.Multiline = true;
            this.txtReservadas.Name = "txtReservadas";
            this.txtReservadas.Size = new System.Drawing.Size(144, 119);
            this.txtReservadas.TabIndex = 7;
            // 
            // lblNoReservadas
            // 
            this.lblNoReservadas.AutoSize = true;
            this.lblNoReservadas.Location = new System.Drawing.Point(182, 218);
            this.lblNoReservadas.Name = "lblNoReservadas";
            this.lblNoReservadas.Size = new System.Drawing.Size(84, 13);
            this.lblNoReservadas.TabIndex = 8;
            this.lblNoReservadas.Text = "No Reservadas:";
            // 
            // txtNoReservadas
            // 
            this.txtNoReservadas.Enabled = false;
            this.txtNoReservadas.Location = new System.Drawing.Point(185, 234);
            this.txtNoReservadas.Multiline = true;
            this.txtNoReservadas.Name = "txtNoReservadas";
            this.txtNoReservadas.Size = new System.Drawing.Size(144, 119);
            this.txtNoReservadas.TabIndex = 9;
            // 
            // txtOperadores
            // 
            this.txtOperadores.Enabled = false;
            this.txtOperadores.Location = new System.Drawing.Point(335, 234);
            this.txtOperadores.Multiline = true;
            this.txtOperadores.Name = "txtOperadores";
            this.txtOperadores.Size = new System.Drawing.Size(144, 119);
            this.txtOperadores.TabIndex = 10;
            // 
            // lblOperadores
            // 
            this.lblOperadores.AutoSize = true;
            this.lblOperadores.Location = new System.Drawing.Point(332, 218);
            this.lblOperadores.Name = "lblOperadores";
            this.lblOperadores.Size = new System.Drawing.Size(65, 13);
            this.lblOperadores.TabIndex = 11;
            this.lblOperadores.Text = "Operadores:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 450);
            this.Controls.Add(this.lblOperadores);
            this.Controls.Add(this.txtOperadores);
            this.Controls.Add(this.txtNoReservadas);
            this.Controls.Add(this.lblNoReservadas);
            this.Controls.Add(this.txtReservadas);
            this.Controls.Add(this.lblReservada);
            this.Controls.Add(this.lblSalida);
            this.Controls.Add(this.lblEntrada);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.txtEntrada);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Label lblSalida;
        private System.Windows.Forms.Label lblReservada;
        private System.Windows.Forms.TextBox txtReservadas;
        private System.Windows.Forms.Label lblNoReservadas;
        private System.Windows.Forms.TextBox txtNoReservadas;
        private System.Windows.Forms.TextBox txtOperadores;
        private System.Windows.Forms.Label lblOperadores;
    }
}

