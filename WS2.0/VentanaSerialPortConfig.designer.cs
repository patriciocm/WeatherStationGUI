namespace pgp
{
    partial class VentanaSerialPortConfig 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaSerialPortConfig));
            this.comLabel = new System.Windows.Forms.Label();
            this.comPortComboBox1 = new System.Windows.Forms.ComboBox();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comLabel
            // 
            this.comLabel.AutoSize = true;
            this.comLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comLabel.Location = new System.Drawing.Point(12, 50);
            this.comLabel.Name = "comLabel";
            this.comLabel.Size = new System.Drawing.Size(73, 17);
            this.comLabel.TabIndex = 0;
            this.comLabel.Text = "COM Port:";
            this.comLabel.Click += new System.EventHandler(this.comLabel_Click);
            // 
            // comPortComboBox1
            // 
            this.comPortComboBox1.FormattingEnabled = true;
            this.comPortComboBox1.Location = new System.Drawing.Point(91, 46);
            this.comPortComboBox1.Name = "comPortComboBox1";
            this.comPortComboBox1.Size = new System.Drawing.Size(64, 21);
            this.comPortComboBox1.TabIndex = 14;
            this.comPortComboBox1.SelectedIndexChanged += new System.EventHandler(this.comPortComboBox1_SelectedIndexChanged);
            // 
            // aceptarButton
            // 
            this.aceptarButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptarButton.Location = new System.Drawing.Point(117, 83);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(106, 21);
            this.aceptarButton.TabIndex = 2;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "Seleccione el puerto al cual se conecto el  modulo de transmision/recepcion.";
            // 
            // VentanaSerialPortConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 115);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comPortComboBox1);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.comLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VentanaSerialPortConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Port Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label comLabel;

        private System.Windows.Forms.ComboBox comPortComboBox1;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Label label1;

        public System.Windows.Forms.ComboBox ComPortComboBox1
        {
            get { return comPortComboBox1; }
            set { comPortComboBox1 = value; }
        }

    }
}