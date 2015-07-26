using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pgp
{
    public partial class VentanaOptions : Form
    {
        public VentanaOptions()
        {
            InitializeComponent();
        }


        private void ventanaOptionsBotonDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                ventanaOptionsTextBoxDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
