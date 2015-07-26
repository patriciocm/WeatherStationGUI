namespace pgp
{
    partial class VentanaConfigDateTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaConfigDateTime));
            this.tabConfigRTC = new System.Windows.Forms.TabControl();
            this.tabConsultarRTC = new System.Windows.Forms.TabPage();
            this.textBoxConsultarRTC = new System.Windows.Forms.TextBox();
            this.buttonActualizarConsultarRTC = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabSetearRTC = new System.Windows.Forms.TabPage();
            this.buttonActualizarSetearRTC = new System.Windows.Forms.Button();
            this.timePickerSetearRTC = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.datePickerSetearRTC = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabConfigRTC.SuspendLayout();
            this.tabConsultarRTC.SuspendLayout();
            this.tabSetearRTC.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabConfigRTC
            // 
            this.tabConfigRTC.Controls.Add(this.tabConsultarRTC);
            this.tabConfigRTC.Controls.Add(this.tabSetearRTC);
            this.tabConfigRTC.Location = new System.Drawing.Point(0, -1);
            this.tabConfigRTC.Name = "tabConfigRTC";
            this.tabConfigRTC.SelectedIndex = 0;
            this.tabConfigRTC.Size = new System.Drawing.Size(324, 194);
            this.tabConfigRTC.TabIndex = 6;
            // 
            // tabConsultarRTC
            // 
            this.tabConsultarRTC.Controls.Add(this.textBoxConsultarRTC);
            this.tabConsultarRTC.Controls.Add(this.buttonActualizarConsultarRTC);
            this.tabConsultarRTC.Controls.Add(this.label2);
            this.tabConsultarRTC.Controls.Add(this.label6);
            this.tabConsultarRTC.Location = new System.Drawing.Point(4, 22);
            this.tabConsultarRTC.Name = "tabConsultarRTC";
            this.tabConsultarRTC.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsultarRTC.Size = new System.Drawing.Size(316, 168);
            this.tabConsultarRTC.TabIndex = 0;
            this.tabConsultarRTC.Text = "Consultar";
            this.tabConsultarRTC.UseVisualStyleBackColor = true;
            // 
            // textBoxConsultarRTC
            // 
            this.textBoxConsultarRTC.Location = new System.Drawing.Point(92, 73);
            this.textBoxConsultarRTC.Name = "textBoxConsultarRTC";
            this.textBoxConsultarRTC.Size = new System.Drawing.Size(213, 20);
            this.textBoxConsultarRTC.TabIndex = 16;
            // 
            // buttonActualizarConsultarRTC
            // 
            this.buttonActualizarConsultarRTC.Location = new System.Drawing.Point(110, 122);
            this.buttonActualizarConsultarRTC.Name = "buttonActualizarConsultarRTC";
            this.buttonActualizarConsultarRTC.Size = new System.Drawing.Size(75, 23);
            this.buttonActualizarConsultarRTC.TabIndex = 15;
            this.buttonActualizarConsultarRTC.Text = "Actualizar";
            this.buttonActualizarConsultarRTC.UseVisualStyleBackColor = true;
            this.buttonActualizarConsultarRTC.Click += new System.EventHandler(this.buttonActualizarConsultarRTC_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Fecha/Hora :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 41);
            this.label6.TabIndex = 10;
            this.label6.Text = "Presione el boton Actualizar para leer los valores de fecha y tiempo configurados" +
                " en la estacion meteorologica.";
            // 
            // tabSetearRTC
            // 
            this.tabSetearRTC.Controls.Add(this.buttonActualizarSetearRTC);
            this.tabSetearRTC.Controls.Add(this.timePickerSetearRTC);
            this.tabSetearRTC.Controls.Add(this.label3);
            this.tabSetearRTC.Controls.Add(this.label4);
            this.tabSetearRTC.Controls.Add(this.datePickerSetearRTC);
            this.tabSetearRTC.Controls.Add(this.label1);
            this.tabSetearRTC.Location = new System.Drawing.Point(4, 22);
            this.tabSetearRTC.Name = "tabSetearRTC";
            this.tabSetearRTC.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetearRTC.Size = new System.Drawing.Size(316, 168);
            this.tabSetearRTC.TabIndex = 1;
            this.tabSetearRTC.Text = "Configurar";
            this.tabSetearRTC.UseVisualStyleBackColor = true;
            // 
            // buttonActualizarSetearRTC
            // 
            this.buttonActualizarSetearRTC.Location = new System.Drawing.Point(108, 131);
            this.buttonActualizarSetearRTC.Name = "buttonActualizarSetearRTC";
            this.buttonActualizarSetearRTC.Size = new System.Drawing.Size(75, 23);
            this.buttonActualizarSetearRTC.TabIndex = 9;
            this.buttonActualizarSetearRTC.Text = "Actualizar";
            this.buttonActualizarSetearRTC.UseVisualStyleBackColor = true;
            this.buttonActualizarSetearRTC.Click += new System.EventHandler(this.buttonActualizarSetearRTC_Click);
            // 
            // timePickerSetearRTC
            // 
            this.timePickerSetearRTC.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerSetearRTC.Location = new System.Drawing.Point(76, 90);
            this.timePickerSetearRTC.Name = "timePickerSetearRTC";
            this.timePickerSetearRTC.ShowUpDown = true;
            this.timePickerSetearRTC.Size = new System.Drawing.Size(107, 20);
            this.timePickerSetearRTC.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tiempo:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha:";
            // 
            // datePickerSetearRTC
            // 
            this.datePickerSetearRTC.Location = new System.Drawing.Point(76, 53);
            this.datePickerSetearRTC.Name = "datePickerSetearRTC";
            this.datePickerSetearRTC.Size = new System.Drawing.Size(197, 20);
            this.datePickerSetearRTC.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "Elija la fecha y hora que desea configurar en la estacion meteorologica y luego p" +
                "resione el boton Actualizar.";
            // 
            // VentanaConfigDateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 190);
            this.Controls.Add(this.tabConfigRTC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VentanaConfigDateTime";
            this.Text = "ConfigDateTime";
            this.tabConfigRTC.ResumeLayout(false);
            this.tabConsultarRTC.ResumeLayout(false);
            this.tabConsultarRTC.PerformLayout();
            this.tabSetearRTC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabConfigRTC;
        private System.Windows.Forms.TabPage tabConsultarRTC;
        private System.Windows.Forms.TabPage tabSetearRTC;
        private System.Windows.Forms.Button buttonActualizarSetearRTC;
        private System.Windows.Forms.DateTimePicker timePickerSetearRTC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker datePickerSetearRTC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonActualizarConsultarRTC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxConsultarRTC;
    }
}