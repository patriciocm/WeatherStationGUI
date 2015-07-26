using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace pgp
{
    public partial class VentanaConfigDateTime : Form
    {
        delegate void DelegateActualizarLabelConsulta(DateTime dateTime);

        private SerialPort mySerialPort;

        public VentanaConfigDateTime(SerialPort serialPortToBeUsed)
        {
            InitializeComponent();
            mySerialPort = serialPortToBeUsed;
        }

        private void buttonActualizarConsultarRTC_Click(object sender, EventArgs e)
        {
            Frame.EnviarRTCReadRequest(mySerialPort);
        }

        public void ActualizarLabelConsulta(DateTime dateTime)
        {
            if (textBoxConsultarRTC.InvokeRequired)
            {
                DelegateActualizarLabelConsulta d = new DelegateActualizarLabelConsulta(ActualizarLabelConsulta);
                this.Invoke(d, new object[] { dateTime });
            }
            else
            {
                try
                {
                    textBoxConsultarRTC.Text = dateTime.Day + "/" + dateTime.Month + "/" + dateTime.Year + "     " + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "{0} Exception caught in MostrarDatosParseados.",
                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }   
        }

        private void buttonActualizarSetearRTC_Click(object sender, EventArgs e)
        {
            int dia = datePickerSetearRTC.Value.Day;
            int mes = datePickerSetearRTC.Value.Month;
            int anio = datePickerSetearRTC.Value.Year;

            int hora = timePickerSetearRTC.Value.Hour;
            int minuto = timePickerSetearRTC.Value.Minute;
            int segundo = timePickerSetearRTC.Value.Second;

            Frame.EnviarRTCSet(mySerialPort, dia, mes, anio, hora, minuto, segundo);
        }
    }
}
