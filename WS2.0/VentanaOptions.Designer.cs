namespace pgp
{
    partial class VentanaOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.ventanaOptionsBotonAceptar = new System.Windows.Forms.Button();
            this.ventanaOptionsBotonCancelar = new System.Windows.Forms.Button();
            this.ventanaOptionsTextBoxDirectory = new System.Windows.Forms.TextBox();
            this.ventanaOptionsBotonDirectory = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elija el directorio donde desea almacenar los archivos de datos.";
            // 
            // ventanaOptionsBotonAceptar
            // 
            this.ventanaOptionsBotonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ventanaOptionsBotonAceptar.Location = new System.Drawing.Point(162, 85);
            this.ventanaOptionsBotonAceptar.Name = "ventanaOptionsBotonAceptar";
            this.ventanaOptionsBotonAceptar.Size = new System.Drawing.Size(75, 23);
            this.ventanaOptionsBotonAceptar.TabIndex = 1;
            this.ventanaOptionsBotonAceptar.Text = "Aceptar";
            this.ventanaOptionsBotonAceptar.UseVisualStyleBackColor = true;
            // 
            // ventanaOptionsBotonCancelar
            // 
            this.ventanaOptionsBotonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ventanaOptionsBotonCancelar.Location = new System.Drawing.Point(243, 85);
            this.ventanaOptionsBotonCancelar.Name = "ventanaOptionsBotonCancelar";
            this.ventanaOptionsBotonCancelar.Size = new System.Drawing.Size(75, 23);
            this.ventanaOptionsBotonCancelar.TabIndex = 2;
            this.ventanaOptionsBotonCancelar.Text = "Cancelar";
            this.ventanaOptionsBotonCancelar.UseVisualStyleBackColor = true;
            // 
            // ventanaOptionsTextBoxDirectory
            // 
            this.ventanaOptionsTextBoxDirectory.Location = new System.Drawing.Point(15, 46);
            this.ventanaOptionsTextBoxDirectory.Name = "ventanaOptionsTextBoxDirectory";
            this.ventanaOptionsTextBoxDirectory.Size = new System.Drawing.Size(274, 20);
            this.ventanaOptionsTextBoxDirectory.TabIndex = 3;
            // 
            // ventanaOptionsBotonDirectory
            // 
            this.ventanaOptionsBotonDirectory.Location = new System.Drawing.Point(296, 46);
            this.ventanaOptionsBotonDirectory.Name = "ventanaOptionsBotonDirectory";
            this.ventanaOptionsBotonDirectory.Size = new System.Drawing.Size(32, 23);
            this.ventanaOptionsBotonDirectory.TabIndex = 4;
            this.ventanaOptionsBotonDirectory.Text = "...";
            this.ventanaOptionsBotonDirectory.UseVisualStyleBackColor = true;
            this.ventanaOptionsBotonDirectory.Click += new System.EventHandler(this.ventanaOptionsBotonDirectory_Click);
            // 
            // VentanaOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 123);
            this.Controls.Add(this.ventanaOptionsBotonDirectory);
            this.Controls.Add(this.ventanaOptionsTextBoxDirectory);
            this.Controls.Add(this.ventanaOptionsBotonCancelar);
            this.Controls.Add(this.ventanaOptionsBotonAceptar);
            this.Controls.Add(this.label1);
            this.Name = "VentanaOptions";
            this.Text = "VentanaOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ventanaOptionsBotonAceptar;
        private System.Windows.Forms.Button ventanaOptionsBotonCancelar;
        private System.Windows.Forms.Button ventanaOptionsBotonDirectory;
        public System.Windows.Forms.TextBox ventanaOptionsTextBoxDirectory;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}