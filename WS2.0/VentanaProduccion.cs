using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Win32;
using System.Drawing.Printing;


namespace pgp
{
    public partial class VentanaProduccion : Form
    {
        //Delegates
        delegate void DelegateGraficarDatos(string[] text, tipoTrama tipoTramaRecibida);
        delegate void DelegatefinalizoHistoryTransmission();
        
        //Variables
        private TabPage previousTabSelected;
        private bool startOkReceived = false;
        private bool stopOkReceived = false;
        private Frame tramaRecibida = new Frame();
        private static string directoryPath;
        private static string nombreDistribucionGotas = "\\distribucionGotas.txt";
        private static string nombrePrecipitacionAcumuladaIntensidad = "\\precipitacionAcumuladaIntensidad.txt";
        private static string pathDistribucionGotas;
        private static string pathPrecipitacionAcumuladaIntensidad;
        DateTime fechaUltimaTramaRecibida = new DateTime();

        StreamReader srDistribucionGotas;
        StreamWriter swDistribucionGotas;
        StreamReader srPrecipitacionAcumuladaIntensidad;
        StreamWriter swPrecipitacionAcumuladaIntensidad;
        VentanaConfigDateTime ventanaConfigRTC;
        VentanaOptions ventanaOptions;
        private bool botonCustomTimeSettingsApretado = false;
        private bool botonLineStyleApretado = false;
        private int numberOfXDivisions = 24;
        private byte updateTime;
        RegistryKey regkey = Registry.CurrentUser.CreateSubKey("Software\\WeatherStation");


        public VentanaProduccion()
        {
            InitializeComponent();

            //Inicializar Resgistro
            if (regkey.GetValue("DirectoryPath") == null)
            {   regkey.SetValue("DirectoryPath", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
                directoryPath = regkey.GetValue("DirectoryPath").ToString();

            if (regkey.GetValue("UpdateTime") == null)
            {   regkey.SetValue("UpdateTime", "10");
                updateTime = 10;
            }
            else
                updateTime = Convert.ToByte(regkey.GetValue("UpdateTime").ToString());

            if (regkey.GetValue("DropDistro") != null)
                comboBoxGraficoSeleccionado.Items.Add("Distribucion Gotas");


            //Inicializar los Graficos
            InicializarDistribucionGotas();
            InicializarVolumenAcumulado();
            InicializarIntensidad();


            //Seleccionar Tab Volumen Acumulado como Default
            wizardPagesGraficos.TabPages.Remove(tabDistribucionGotas);
            wizardPagesGraficos.TabPages.Remove(tabIntensidad);
            previousTabSelected = tabVolumenAcumulado;
            comboBoxGraficoSeleccionado.SelectedIndex = 0;
            comboBoxUpdateTime.SelectedItem = updateTime.ToString();
            

            //Inicializar Streams
            pathDistribucionGotas = directoryPath + nombreDistribucionGotas;
            pathPrecipitacionAcumuladaIntensidad = directoryPath + nombrePrecipitacionAcumuladaIntensidad;
            FileStream fileReadDistribucionGotas = new FileStream(pathDistribucionGotas, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            FileStream fileWriteDistribucionGotas = new FileStream(pathDistribucionGotas, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            srDistribucionGotas = new StreamReader(fileReadDistribucionGotas);
            swDistribucionGotas = new StreamWriter(fileWriteDistribucionGotas);
            FileStream fileReadPrecipitacionAcumuladaIntensidad = new FileStream(pathPrecipitacionAcumuladaIntensidad, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            FileStream fileWritePrecipitacionAcumuladaIntensidad = new FileStream(pathPrecipitacionAcumuladaIntensidad, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            srPrecipitacionAcumuladaIntensidad = new StreamReader(fileReadPrecipitacionAcumuladaIntensidad);
            swPrecipitacionAcumuladaIntensidad = new StreamWriter(fileWritePrecipitacionAcumuladaIntensidad);


            try
            {
                //Cargar Datos Iniciales en Graficos
                char c;
                string lineOfText;
                String[] StringValuesSplit;
                while ((lineOfText = srPrecipitacionAcumuladaIntensidad.ReadLine()) != null)
                {
                    if (!lineOfText.Equals(""))
                    {
                        c = lineOfText[0];
                        if (c != '\n' && c != '\t' && c != '\r' && c != '#' && c != '/')
                        {
                            StringValuesSplit = lineOfText.Split(' ', '#',',');
                            DateTime dateTime = Convert.ToDateTime(StringValuesSplit[2] + "-" + StringValuesSplit[1] + "-" + StringValuesSplit[0] + " " + StringValuesSplit[3] + ":" + StringValuesSplit[4] + ":" + StringValuesSplit[5]);
                            chartVolumenAcumulado.Series["Volumen Acumulado"].Points.AddXY(dateTime, Convert.ToDouble(StringValuesSplit[6]));
                            chartIntensidad.Series["Intensidad"].Points.AddXY(dateTime, Convert.ToDouble(StringValuesSplit[7]));
                        }
                    }
                }
                while ((lineOfText = srDistribucionGotas.ReadLine()) != null)
                {
                    if (!lineOfText.Equals(""))
                    {
                        c = lineOfText[0];
                        if (c != '\n' && c != '\t' && c != '\r' && c != '#' && c != '/')
                        {
                            StringValuesSplit = lineOfText.Split(' ', '#', ',');
                            DateTime dateTime = Convert.ToDateTime(StringValuesSplit[2] + "-" + StringValuesSplit[1] + "-" + StringValuesSplit[0] + " " + StringValuesSplit[3] + ":" + StringValuesSplit[4] + ":" + StringValuesSplit[5]);
                            chartDistribucion.Series["Distribucion Gotas"].Points.AddXY(dateTime, Convert.ToDouble(StringValuesSplit[6]));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("{0} Exception caught.", exception.ToString(),
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Posicionar Writers al final del archivo
            swDistribucionGotas.BaseStream.Position = swDistribucionGotas.BaseStream.Length;
            swPrecipitacionAcumuladaIntensidad.BaseStream.Position = swPrecipitacionAcumuladaIntensidad.BaseStream.Length;

            //Actualizar Estadisticas
            actualizarEstadisticas();
        }


        public void InicializarDistribucionGotas()
        {
            //GENERAL
            chartDistribucion.Series["Distribucion Gotas"].Color = Color.Green;
            chartDistribucion.Series["Distribucion Gotas"].BorderWidth = 3;
            chartDistribucion.ChartAreas[0].AxisY.Title = "Tamanio Gota (mm)";
            chartDistribucion.Legends["Legend1"].DockedToChartArea = "ChartArea1";
            chartDistribucion.Legends["Legend1"].IsDockedInsideChartArea = true;

            //X AXIS
            DateTime tiempoInicio = DateTime.Now.Subtract(TimeSpan.FromHours(5));
            chartDistribucion.ChartAreas[0].AxisX.Minimum = tiempoInicio.ToOADate();
            chartDistribucion.ChartAreas[0].AxisX.Maximum = tiempoInicio.AddDays(1).ToOADate();
            chartDistribucion.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Hours;
            TimeSpan anchoEjeX = tiempoInicio.AddDays(1) - tiempoInicio;
            chartDistribucion.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours/numberOfXDivisions;
            chartDistribucion.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm \n dd-MM-yyyy";
            chartDistribucion.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            //Y AXIS
            chartDistribucion.ChartAreas[0].AxisY.Minimum = 0;
            chartDistribucion.ChartAreas[0].AxisY.Maximum = 3;
            chartDistribucion.ChartAreas[0].AxisY.MajorGrid.IntervalType = DateTimeIntervalType.Number;
            chartDistribucion.ChartAreas[0].AxisY.MajorGrid.Interval = 0.25;
            
            //AGREGAR PUNTOS
            chartDistribucion.Series["Distribucion Gotas"].Points.AddXY(Convert.ToDateTime("01/01/1900"), 0);
            chartDistribucion.Series["Distribucion Gotas"].Points[0].IsEmpty = true;
        }


        public void InicializarVolumenAcumulado()
        {
            //GENERAL
            chartVolumenAcumulado.Series["Volumen Acumulado"].Color = Color.Red;
            chartVolumenAcumulado.Series["Volumen Acumulado"].BorderWidth = 3;
            chartVolumenAcumulado.ChartAreas[0].AxisY.Title = "Volumen (mm)";
            chartVolumenAcumulado.Legends["Legend1"].DockedToChartArea = "ChartArea1";
            chartVolumenAcumulado.Legends["Legend1"].IsDockedInsideChartArea = true;

            //X AXIS
            DateTime tiempoInicio = DateTime.Now.Subtract(TimeSpan.FromHours(5));
            chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum = tiempoInicio.ToOADate();
            chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum = tiempoInicio.AddDays(1).ToOADate();
            chartVolumenAcumulado.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Hours;
            TimeSpan anchoEjeX = tiempoInicio.AddDays(1) - tiempoInicio;
            chartVolumenAcumulado.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours/numberOfXDivisions;
            chartVolumenAcumulado.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm \n dd-MM-yyyy";
            chartVolumenAcumulado.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            //Y AXIS
            chartVolumenAcumulado.ChartAreas[0].AxisY.Minimum = 0;
            //chartVolumenAcumulado.ChartAreas[0].AxisY.Maximum = 3;
            chartVolumenAcumulado.ChartAreas[0].AxisY.MajorGrid.IntervalType = DateTimeIntervalType.Number;
            //chartVolumenAcumulado.ChartAreas[0].AxisY.MajorGrid.Interval = 0.25;
            
            //AGREGAR PUNTOS
            chartVolumenAcumulado.Series["Volumen Acumulado"].Points.AddXY(Convert.ToDateTime("01/01/1900"),0);
            chartVolumenAcumulado.Series["Volumen Acumulado"].Points[0].IsEmpty = true;

        }


        public void InicializarIntensidad()
        {
            //GENERAL
            chartIntensidad.Series["Intensidad"].Color = Color.Blue;
            chartIntensidad.Series["Intensidad"].BorderWidth = 3;
            chartIntensidad.ChartAreas[0].AxisY.Title = "Intensidad (mm / h)";
            chartIntensidad.Legends["Legend1"].DockedToChartArea = "ChartArea1";
            chartIntensidad.Legends["Legend1"].IsDockedInsideChartArea = true;

            //X AXIS
            DateTime tiempoInicio = DateTime.Now.Subtract(TimeSpan.FromHours(5));
            chartIntensidad.ChartAreas[0].AxisX.Minimum = tiempoInicio.ToOADate();
            chartIntensidad.ChartAreas[0].AxisX.Maximum = tiempoInicio.AddDays(1).ToOADate();
            chartIntensidad.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Hours;
            TimeSpan anchoEjeX = tiempoInicio.AddDays(1) - tiempoInicio;
            chartIntensidad.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;
            chartIntensidad.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm \n dd-MM-yyyy";
            chartIntensidad.ChartAreas[0].AxisX.LabelStyle.Angle = -90;

            //Y AXIS
            chartIntensidad.ChartAreas[0].AxisY.Minimum = 0;
            //chartIntensidad.ChartAreas[0].AxisY.Maximum = 3;
            chartIntensidad.ChartAreas[0].AxisY.MajorGrid.IntervalType = DateTimeIntervalType.Number;
            //chartIntensidad.ChartAreas[0].AxisY.MajorGrid.Interval = 0.25;

            //AGREGAR PUNTOS
            chartIntensidad.Series["Intensidad"].Points.AddXY(Convert.ToDateTime("01/01/1900"), 0);
            chartIntensidad.Series["Intensidad"].Points[0].IsEmpty = true;
        }


        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                VentanaSerialPortConfig serialPortConfigWindow = new VentanaSerialPortConfig();

                //Obtener puertos disponibles y cargarlos en Form1.
                string[] ports = SerialPort.GetPortNames();

                foreach (string port in ports)
                {
                    serialPortConfigWindow.ComPortComboBox1.Items.Add(port);
                }

                DialogResult dr = serialPortConfigWindow.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // Allow the user to set the appropriate properties
                    serialPort.PortName = serialPortConfigWindow.ComPortComboBox1.SelectedItem.ToString();
                    serialPort.BaudRate = Convert.ToInt32("250000");
                    serialPort.DataBits = Convert.ToInt32("8");
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;

                    serialPort.ReadBufferSize = 1000000;

                    serialPort.Open();

                    DateTime present = DateTime.Now;
                    DateTime addXSeconds = DateTime.Now.AddSeconds(2);

                    Frame.EnviarStart(serialPort);
                    while (!startOkReceived && present < addXSeconds) //agregar control de tiempo 5seg
                        present = DateTime.Now;

                    if(startOkReceived)
                    {
                        startOkReceived = false;
                        labelEstado.Text = "SINCRONIZANDO.....";
                        progressBarHistorySincro.Visible = true;
                        chartDistribucion.Visible = false;
                        chartVolumenAcumulado.Visible = false;
                        chartIntensidad.Visible = false;
                        timer1.Enabled = true;
                        pictureBoxEstado.Image = Image.FromFile("../../Resources/sincro-history-icon.png");
                    }
                    else
                    {
                        serialPort.Close();
                        MessageBox.Show("No se pudo establecer la conexión. Es posible que la estación meteorológica se encuentre apagada.", "Error de Conexión",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Te falto el puerto papi.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Elegí otro puerto maestro, este ya esta en uso.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception exception)
            {
                MessageBox.Show("{0} Exception caught.", exception.ToString(),
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Eof)
                    return;

                int numberOfBytesToRead;
                numberOfBytesToRead = serialPort.BytesToRead;
                Byte[] newReceivedData = new Byte[1];

                for (int i = 0; i < numberOfBytesToRead; i++)
                {
                    serialPort.Read(newReceivedData, 0, 1);
                    tramaRecibida.CargarBytes(newReceivedData);

                    if (tramaRecibida.EstadoActual == estado.Ready)
                    {
                        tipoTrama tipoTramaRecibida = tramaRecibida.ChequearTrama();

                        if (tipoTramaRecibida == tipoTrama.StartOk)
                        {
                            startOkReceived = true;
                        }
                        else if (tipoTramaRecibida == tipoTrama.FinishHistoryTransmission)
                        {
                            finalizoHistoryTransmission();
                        }
                        else if (tipoTramaRecibida == tipoTrama.GotaDetectada)
                        {
                            String[] tramaRecibidaParseada = tramaRecibida.ParsearTramaRecibidaGota();
                            grabarEnArchivo(swDistribucionGotas, tramaRecibidaParseada);
                            graficarDatos(tramaRecibidaParseada, tipoTrama.GotaDetectada);
                        }
                        else if (tipoTramaRecibida == tipoTrama.ActualizarVolumen)
                        {
                            String[] tramaRecibidaParseada = tramaRecibida.ParsearTramaRecibidaVolumen();
                            grabarEnArchivo(swPrecipitacionAcumuladaIntensidad, tramaRecibidaParseada);
                            graficarDatos(tramaRecibidaParseada, tipoTrama.ActualizarVolumen);
                            fechaUltimaTramaRecibida = DateTime.Now;
                        }
                        else if (tipoTramaRecibida == tipoTrama.TransmitHistoryGotaDetectada)
                        {
                            String[] tramaRecibidaParseada = tramaRecibida.ParsearTramaRecibidaGota();
                            grabarEnArchivo(swDistribucionGotas, tramaRecibidaParseada);
                            graficarDatos(tramaRecibidaParseada, tipoTrama.TransmitHistoryGotaDetectada);
                                
                        }
                        else if (tipoTramaRecibida == tipoTrama.TransmitHistoryVolumenIntesidad)
                        {
                            String[] tramaRecibidaParseada = tramaRecibida.ParsearTramaRecibidaVolumen();
                            grabarEnArchivo(swPrecipitacionAcumuladaIntensidad, tramaRecibidaParseada);
                            graficarDatos(tramaRecibidaParseada, tipoTrama.TransmitHistoryVolumenIntesidad);
                                
                        }
                        else if (tipoTramaRecibida == tipoTrama.RemoteATResponse)
                        {
                            String valorRecibidoComandoAT = tramaRecibida.ParsearTramaRecibidaRemoteATResponse();
                            //ActualizarLabelValorComandoRemoto(valorRecibidoComandoAT);
                        }
                        else if (tipoTramaRecibida == tipoTrama.ATResponse)
                        {
                            String valorRecibidoComandoAT = tramaRecibida.ParsearTramaRecibidaATResponse();
                            //ActualizarLabelValorComandoLocal(valorRecibidoComandoAT);
                        }
                        else if (tipoTramaRecibida == tipoTrama.RTCReadResponse)
                        {
                            DateTime dateTimeRececived = tramaRecibida.ParsearTramaRecibidaRTCReadResponse();
                            ventanaConfigRTC.ActualizarLabelConsulta(dateTimeRececived);
                        }
                        else if (tipoTramaRecibida == tipoTrama.StopOk)
                        {
                            stopOkReceived = true;
                        }

                        tramaRecibida.BorrarTrama();
                    }
                }
            }
            catch (TimeoutException timeOutException)
            {
                MessageBox.Show(timeOutException.ToString(), "Exception caught in serialPort_DataReceived.",
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "{0} Exception caught in serialPort_DataReceived.",
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        public void finalizoHistoryTransmission()
        {
            if (progressBarHistorySincro.InvokeRequired)
            {
                DelegatefinalizoHistoryTransmission d = new DelegatefinalizoHistoryTransmission(finalizoHistoryTransmission);
                this.Invoke(d, new object[] { });
            }
            else
            {
                try
                {
                    progressBarHistorySincro.Visible = false;
                    timer1.Enabled = false;
                    //timerConectado.Enabled = true;
                    labelEstado.Text = "CONECTADO";
                    pictureBoxEstado.Image = Image.FromFile("../../Resources/green-ok-icon.png");
                    chartDistribucion.Visible = true;
                    chartVolumenAcumulado.Visible = true;
                    chartIntensidad.Visible = true;
                    groupBoxUpdateTime.Enabled = true;
                    Frame.EnviarRefreshTiempoMediciones(serialPort, updateTime);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "{0} Exception caught in ActualizarLabelConsulta.",
                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        private void grabarEnArchivo(TextWriter tw, String[] datos)
        {
            string auxiliarElemento;

            foreach (string elemento in datos)
            {
                auxiliarElemento = elemento.Trim();
                tw.Write("{0} ", auxiliarElemento);
            }
            tw.Write("\n");
            tw.Flush();
        }


        private void graficarDatos(string[] datosRecibidos, tipoTrama tipoTramaRecibida)
        {
            if (chartVolumenAcumulado.InvokeRequired)
            {
                DelegateGraficarDatos d = new DelegateGraficarDatos(graficarDatos);
                this.Invoke(d, new object[] { datosRecibidos, tipoTramaRecibida });
            }
            else
            {
                try
                {
                    if (tipoTramaRecibida == tipoTrama.GotaDetectada || tipoTramaRecibida == tipoTrama.TransmitHistoryGotaDetectada)
                    {
                        DateTime dateTime = Convert.ToDateTime(datosRecibidos[2] + "-" + datosRecibidos[1] + "-" + datosRecibidos[0] + " " + datosRecibidos[3] + ":" + datosRecibidos[4] + ":" + datosRecibidos[5]);
                        chartDistribucion.Series["Distribucion Gotas"].Points.AddXY(dateTime, Convert.ToDouble(datosRecibidos[6]));
                    }
                    else if (tipoTramaRecibida == tipoTrama.ActualizarVolumen || tipoTramaRecibida == tipoTrama.TransmitHistoryVolumenIntesidad)
                    {
                        DateTime dateTime = Convert.ToDateTime(datosRecibidos[2] + "-" + datosRecibidos[1] + "-" + datosRecibidos[0] + " " + datosRecibidos[3] + ":" + datosRecibidos[4] + ":" + datosRecibidos[5]);
                        chartVolumenAcumulado.Series["Volumen Acumulado"].Points.AddXY(dateTime, Convert.ToDouble(datosRecibidos[6]));
                        chartIntensidad.Series["Intensidad"].Points.AddXY(dateTime, Convert.ToDouble(datosRecibidos[7]));
                    }

                }
                catch (IndexOutOfRangeException indexOutOfRangeException)
                {
                    //MessageBox.Show(indexOutOfRangeException.ToString(), "{0} Exception caught in MostrarDatosParseados.",
                      //                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception exception)
                {
                    //MessageBox.Show(exception.ToString(), "{0} Exception caught in MostrarDatosParseados.",
                      //                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        private void comboBoxGraficoSeleccionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxGraficoSeleccionado.SelectedIndex)
            {             
                case 0:
                    if (previousTabSelected != tabVolumenAcumulado)
                    {
                        wizardPagesGraficos.TabPages.Remove(previousTabSelected);
                        wizardPagesGraficos.TabPages.Insert(0, tabVolumenAcumulado);
                        previousTabSelected = tabVolumenAcumulado;
                    }
                    break;
                case 1:
                    wizardPagesGraficos.TabPages.Remove(previousTabSelected);
                    wizardPagesGraficos.TabPages.Insert(0, tabIntensidad);
                    previousTabSelected = tabIntensidad;
                    break;
                case 2:
                    wizardPagesGraficos.TabPages.Remove(previousTabSelected);
                    wizardPagesGraficos.TabPages.Insert(0, tabDistribucionGotas);
                    previousTabSelected = tabDistribucionGotas;
                    break;
                default:
                    break;
            }

            actualizarEstadisticas();
        }


        private void comboBoxUpdateTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newUpdateTime = comboBoxUpdateTime.SelectedItem.ToString();

            Frame.EnviarRefreshTiempoMediciones(serialPort, Convert.ToByte(newUpdateTime));
            regkey.SetValue("UpdateTime", newUpdateTime);

            groupBoxUpdateTime.Focus();
        }
        

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (labelEstado.Text.Equals("CONECTADO"))
            {
                DateTime present = DateTime.Now;
                DateTime addXSeconds = DateTime.Now.AddSeconds(2);

                Frame.EnviarStop(serialPort);
                while (!stopOkReceived && present < addXSeconds) //agregar control de tiempo 5seg
                    present = DateTime.Now;

                if (!stopOkReceived)
                {
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("No se pudo establecer conexion con la estacion. Desconectar de todos modos?", "Error de Conexión",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dr != DialogResult.OK)
                        return;
                }

                stopOkReceived = false;
                serialPort.Close();
                labelEstado.Text = "DESCONECTADO";
                pictureBoxEstado.Image = Image.FromFile("../../Resources/red-notok-icon.png");
                groupBoxUpdateTime.Enabled = false;
                timerConectado.Enabled = false;
            }
            
        }
       
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();                 
        }


        private void configStationDateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelEstado.Text.Equals("CONECTADO"))
                {
                    ventanaConfigRTC = new VentanaConfigDateTime(serialPort);
                    ventanaConfigRTC.Show();
                }
                else
                    MessageBox.Show("Necesita estar online para acceder a esta funcionalidad.", "Offline",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Exception caught.",
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBarHistorySincro.Value == 100)
                progressBarHistorySincro.Value = 0;

            progressBarHistorySincro.PerformStep();
            pictureBoxEstado.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBoxEstado.Refresh();
            
        }

       
        private void VentanaProduccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (labelEstado.Text.Equals("CONECTADO"))
            {
                DateTime present = DateTime.Now;
                DateTime addXSeconds = DateTime.Now.AddSeconds(2);

                Frame.EnviarStop(serialPort);
                while (!stopOkReceived && present < addXSeconds) //agregar control de tiempo 5seg
                    present = DateTime.Now;

                if (!stopOkReceived)
                {
                    DialogResult dr = MessageBox.Show("No se pudo establecer conexion con la estacion. Desea cerrar la aplicacion de todos modos?", "Error de Conexión",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dr != DialogResult.OK)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            Application.Exit();
        }


        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VentanaAbout ventanaCreditos = new VentanaAbout();
            ventanaCreditos.ShowDialog();      
        }


        //Boton GoBack
        private void buttonGoBack_MouseHover(object sender, EventArgs e)
        {
            if(comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonGoBackDG.FlatStyle = FlatStyle.Standard;
            else if(comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonGoBackVA.FlatStyle = FlatStyle.Standard;
            else if(comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonGoBackI.FlatStyle = FlatStyle.Standard;
        }

        private void buttonGoBack_MouseLeave(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonGoBackDG.FlatStyle = FlatStyle.Flat;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonGoBackVA.FlatStyle = FlatStyle.Flat;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonGoBackI.FlatStyle = FlatStyle.Flat;
            
        }

        private void buttonGoBack_MouseClick(object sender, MouseEventArgs e)
        {
            double Xmin = chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum;
            double Xmax = chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum;

            chartDistribucion.ChartAreas[0].AxisX.Minimum = Xmin - (Xmax - Xmin) / 10;
            chartDistribucion.ChartAreas[0].AxisX.Maximum = Xmax - (Xmax - Xmin) / 10;
            chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum = Xmin - (Xmax - Xmin) / 10;
            chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum = Xmax - (Xmax - Xmin) / 10;
            chartIntensidad.ChartAreas[0].AxisX.Minimum = Xmin - (Xmax - Xmin) / 10;
            chartIntensidad.ChartAreas[0].AxisX.Maximum = Xmax - (Xmax - Xmin) / 10;
            actualizarEstadisticas();
        }


        //Boton GoForward
        private void buttonGoForward_MouseHover(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonGoForwardDG.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonGoForwardVA.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonGoForwardI.FlatStyle = FlatStyle.Standard;
            
        }
        
        private void buttonGoForward_MouseLeave(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonGoForwardDG.FlatStyle = FlatStyle.Flat;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonGoForwardVA.FlatStyle = FlatStyle.Flat;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonGoForwardI.FlatStyle = FlatStyle.Flat;
            
        }
        
        private void buttonGoForward_MouseClick(object sender, MouseEventArgs e)
        {
            double Xmin = chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum;
            double Xmax = chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum;

            chartDistribucion.ChartAreas[0].AxisX.Minimum = Xmin + (Xmax - Xmin) / 10;
            chartDistribucion.ChartAreas[0].AxisX.Maximum = Xmax + (Xmax - Xmin) / 10;
            chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum = Xmin + (Xmax - Xmin) / 10;
            chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum = Xmax + (Xmax - Xmin) / 10;
            chartIntensidad.ChartAreas[0].AxisX.Minimum = Xmin + (Xmax - Xmin) / 10;
            chartIntensidad.ChartAreas[0].AxisX.Maximum = Xmax + (Xmax - Xmin) / 10;
            actualizarEstadisticas();
        }


        //Boton ZoomIn
        private void buttonZoomIn_MouseHover(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonZoomInDG.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonZoomInVA.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonZoomInI.FlatStyle = FlatStyle.Standard;
            
        }

        private void buttonZoomIn_MouseLeave(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonZoomInDG.FlatStyle = FlatStyle.Flat;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonZoomInVA.FlatStyle = FlatStyle.Flat;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonZoomInI.FlatStyle = FlatStyle.Flat;
            
        }

        private void buttonZoomIn_MouseClick(object sender, EventArgs e)
        {
            double Xmin = chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum;
            double Xmax = chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum;

            chartDistribucion.ChartAreas[0].AxisX.Minimum = Xmin + (Xmax - Xmin) / 4;
            chartDistribucion.ChartAreas[0].AxisX.Maximum = Xmax - (Xmax - Xmin) / 4;
            chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum = Xmin + (Xmax - Xmin) / 4;
            chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum = Xmax - (Xmax - Xmin) / 4;
            chartIntensidad.ChartAreas[0].AxisX.Minimum = Xmin + (Xmax - Xmin) / 4;
            chartIntensidad.ChartAreas[0].AxisX.Maximum = Xmax - (Xmax - Xmin) / 4;

            Xmin = chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum;
            Xmax = chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum;
            TimeSpan anchoEjeX = DateTime.FromOADate(Xmax) - DateTime.FromOADate(Xmin);
            chartDistribucion.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;
            chartVolumenAcumulado.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;
            chartIntensidad.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;

            actualizarEstadisticas();
        }


        //Boton ZoomOut
        private void buttonZoomOut_MouseHover(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonZoomOutDG.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonZoomOutVA.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonZoomOutI.FlatStyle = FlatStyle.Standard;
            
        }
               
        private void buttonZoomOut_MouseLeave(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonZoomOutDG.FlatStyle = FlatStyle.Flat;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonZoomOutVA.FlatStyle = FlatStyle.Flat;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonZoomOutI.FlatStyle = FlatStyle.Flat;
            
        }
        
        private void buttonZoomOut_MouseClick(object sender, EventArgs e)
        {
            double Xmin = chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum;
            double Xmax = chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum;

            chartDistribucion.ChartAreas[0].AxisX.Minimum = Xmin - (Xmax-Xmin)/2;
            chartDistribucion.ChartAreas[0].AxisX.Maximum = Xmax + (Xmax-Xmin)/2;
            chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum = Xmin - (Xmax-Xmin)/2;
            chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum = Xmax + (Xmax-Xmin)/2;
            chartIntensidad.ChartAreas[0].AxisX.Minimum = Xmin - (Xmax-Xmin)/2;
            chartIntensidad.ChartAreas[0].AxisX.Maximum = Xmax + (Xmax-Xmin)/2;

            Xmin = chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum;
            Xmax = chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum;
            TimeSpan anchoEjeX = DateTime.FromOADate(Xmax) - DateTime.FromOADate(Xmin);
            chartDistribucion.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;
            chartVolumenAcumulado.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;
            chartIntensidad.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;

            actualizarEstadisticas();
        }


        //Boton LineStyle
        private void buttonLineStyle_MouseHover(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonLineStyleDG.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonLineStyleVA.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonLineStyleI.FlatStyle = FlatStyle.Standard;
        }
                       
        private void buttonLineStyle_MouseLeave(object sender, EventArgs e)
        {
            if (!botonLineStyleApretado)
            {
                if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                    buttonLineStyleDG.FlatStyle = FlatStyle.Flat;
                else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                    buttonLineStyleVA.FlatStyle = FlatStyle.Flat;
                else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                    buttonLineStyleI.FlatStyle = FlatStyle.Flat;
            }
        }
        
        private void buttonLineStyle_MouseClick(object sender, MouseEventArgs e)
        {
            if (botonLineStyleApretado)
            {
                chartDistribucion.Series["Distribucion Gotas"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chartVolumenAcumulado.Series["Volumen Acumulado"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chartIntensidad.Series["Intensidad"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                botonLineStyleApretado = false;

                buttonLineStyleDG.FlatStyle = FlatStyle.Flat;
                buttonLineStyleVA.FlatStyle = FlatStyle.Flat;
                buttonLineStyleI.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                chartDistribucion.Series["Distribucion Gotas"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chartVolumenAcumulado.Series["Volumen Acumulado"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chartIntensidad.Series["Intensidad"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                botonLineStyleApretado = true;

                buttonLineStyleDG.FlatStyle = FlatStyle.Standard;
                buttonLineStyleVA.FlatStyle = FlatStyle.Standard;
                buttonLineStyleI.FlatStyle = FlatStyle.Standard;             
            }
        }


        //Boton DefaultTimeSettings
        private void buttonDefaultTimeSettings_MouseHover(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonDefaultTimeSettingsDG.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonDefaultTimeSettingsVA.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonDefaultTimeSettingsI.FlatStyle = FlatStyle.Standard;
        }
                        
        private void buttonDefaultTimeSettings_MouseLeave(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonDefaultTimeSettingsDG.FlatStyle = FlatStyle.Flat;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonDefaultTimeSettingsVA.FlatStyle = FlatStyle.Flat;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonDefaultTimeSettingsI.FlatStyle = FlatStyle.Flat;
            
        }
                
        private void buttonDefaultTimeSettings_MouseClick(object sender, MouseEventArgs e)
        {
            buttonCustomTimeSettingsDG.FlatStyle = FlatStyle.Flat;
            buttonCustomTimeSettingsVA.FlatStyle = FlatStyle.Flat;
            buttonCustomTimeSettingsI.FlatStyle = FlatStyle.Flat;
            
            botonCustomTimeSettingsApretado = false;
            groupBoxTimeSpan.Enabled = false;
            DateTime tiempoInicio = DateTime.Now.Subtract(TimeSpan.FromHours(5));
            chartDistribucion.ChartAreas[0].AxisX.Minimum = tiempoInicio.ToOADate();
            chartDistribucion.ChartAreas[0].AxisX.Maximum = tiempoInicio.AddDays(1).ToOADate();
            chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum = tiempoInicio.ToOADate();
            chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum = tiempoInicio.AddDays(1).ToOADate();
            chartIntensidad.ChartAreas[0].AxisX.Minimum = tiempoInicio.ToOADate();
            chartIntensidad.ChartAreas[0].AxisX.Maximum = tiempoInicio.AddDays(1).ToOADate();

            TimeSpan anchoEjeX = tiempoInicio.AddDays(1) - tiempoInicio;
            chartDistribucion.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;
            chartVolumenAcumulado.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;
            chartIntensidad.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;

            actualizarEstadisticas();
        }


        //Boton CustomTimeSettings
        private void buttonCustomTimeSettings_MouseHover(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonCustomTimeSettingsDG.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonCustomTimeSettingsVA.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonCustomTimeSettingsI.FlatStyle = FlatStyle.Standard;
        }
                
        private void buttonCustomTimeSettings_MouseLeave(object sender, EventArgs e)
        {
            if (!botonCustomTimeSettingsApretado)
            {
                if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                    buttonCustomTimeSettingsDG.FlatStyle = FlatStyle.Flat;
                else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                    buttonCustomTimeSettingsVA.FlatStyle = FlatStyle.Flat;
                else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                    buttonCustomTimeSettingsI.FlatStyle = FlatStyle.Flat;
            }
        }

        private void buttonCustomTimeSettings_MouseClick(object sender, MouseEventArgs e)
        {
            buttonCustomTimeSettingsDG.FlatStyle = FlatStyle.Standard;
            buttonCustomTimeSettingsVA.FlatStyle = FlatStyle.Standard;
            buttonCustomTimeSettingsI.FlatStyle = FlatStyle.Standard;
    
            groupBoxTimeSpan.Enabled = true;
            botonCustomTimeSettingsApretado = true;
        }


        //Boton RefreshCustomTimeSettings
        private void buttonRefreshCustomTimeSettings_MouseHover(object sender, EventArgs e)
        {

            buttonRefreshCustomTimeSettings.FlatStyle = FlatStyle.Standard;
        }
                
        private void buttonRefreshCustomTimeSettings_MouseLeave(object sender, EventArgs e)
        {
            buttonRefreshCustomTimeSettings.FlatStyle = FlatStyle.Flat;
        }
        
        private void buttonRefreshCustomTimeSettings_MouseClick(object sender, MouseEventArgs e)
        {
            DateTime fromDateTime = new DateTime(datePickerFrom.Value.Year, datePickerFrom.Value.Month, datePickerFrom.Value.Day, timePickerFrom.Value.Hour, timePickerFrom.Value.Minute, timePickerFrom.Value.Second);
            DateTime toDateTime = new DateTime(datePickerTo.Value.Year, datePickerTo.Value.Month, datePickerTo.Value.Day, timePickerTo.Value.Hour, timePickerTo.Value.Minute, timePickerTo.Value.Second);
            if (fromDateTime > toDateTime)
            {
                MessageBox.Show("La fecha de incio es posterior a la fecha de fin.", "Error de Parametrizacion",
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            chartDistribucion.ChartAreas[0].AxisX.Minimum = fromDateTime.ToOADate();
            chartDistribucion.ChartAreas[0].AxisX.Maximum = toDateTime.ToOADate();
            chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum = fromDateTime.ToOADate();
            chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum = toDateTime.ToOADate();
            chartIntensidad.ChartAreas[0].AxisX.Minimum = fromDateTime.ToOADate();
            chartIntensidad.ChartAreas[0].AxisX.Maximum = toDateTime.ToOADate();

            TimeSpan anchoEjeX = toDateTime - fromDateTime;
            chartDistribucion.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;
            chartVolumenAcumulado.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;
            chartIntensidad.ChartAreas[0].AxisX.MajorGrid.Interval = anchoEjeX.TotalHours / numberOfXDivisions;

            
            actualizarEstadisticas();
        }


        //Boton/Menu Imprimir 
        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);

            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog();
        }

        private void printSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);

            PrintDialog printWindow = new PrintDialog();
            printWindow.Document = pd;

            DialogResult result = printWindow.ShowDialog();
            if (result == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Fuente Utilizada para los textos
            Font printFont = new Font("Arial", 16, FontStyle.Bold | FontStyle.Underline);
            
            //Utilizado para centrar objetos en el documento
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Rectangle rect1 = new Rectangle(50, 50, 750, 0);

            float xPos = 50;
            float yPos = 50;

            //Titulo Principal
            string text = "Weather Station Report\n\n";
            e.Graphics.DrawString(text, printFont, Brushes.Black, rect1, sf);
            yPos += printFont.GetHeight(e.Graphics);

            //Fecha Inicio - Fecha Fin
            printFont = new Font("Arial", 11, FontStyle.Regular);
            text = "Fecha Inicio: " + labelFechaInicio.Text + "\n";
            text += "Fecha Fin: " + labelFechaFin.Text;
            e.Graphics.DrawString(text, printFont, Brushes.Black, xPos, yPos);
            yPos += 3 * printFont.GetHeight(e.Graphics);

            //Titulo Grafico Volumen Acumulado
            text = "Volumen Acumulado";
            printFont = new Font("Arial", 13, FontStyle.Underline);
            e.Graphics.DrawString(text, printFont, Brushes.Black, xPos, yPos);
            yPos += 2*printFont.GetHeight(e.Graphics);

            //Estadisticas Volumen Acumulado
            actualizarEstadisticasVolumenAcumulado();
            text = "Minimo: " + labelPrimerParametroValue.Text + "\t\t";
            text += "Maximo: " + labelSegundoParametroValue.Text;
            printFont = new Font("Arial", 10, FontStyle.Regular);
            e.Graphics.DrawString(text, printFont, Brushes.Black, xPos, yPos);
            yPos += printFont.GetHeight(e.Graphics);
         
            //Chart Volumen Acumulado
            int alturaChart = 400;
            int anchoChart = 650;
            if (e.Graphics.PageUnit != GraphicsUnit.Pixel)
            {
                e.Graphics.PageUnit = GraphicsUnit.Pixel;
                rect1.X = (int)(xPos * (e.Graphics.DpiX / 100f));
                rect1.Y = (int)(yPos * (e.Graphics.DpiY / 100f));
                rect1.Width = (int)(anchoChart * (e.Graphics.DpiX / 100f));
                rect1.Height = (int)(alturaChart * (e.Graphics.DpiY / 100f));
            }
            chartVolumenAcumulado.Printing.PrintPaint(e.Graphics, rect1);
            e.Graphics.PageUnit = GraphicsUnit.Display;
            yPos += alturaChart + 2 * printFont.GetHeight(e.Graphics);

          
            //Titulo Intensidad de Precipitacion
            text = "Intensidad de Precipitacion";
            printFont = new Font("Arial", 13, FontStyle.Underline);
            e.Graphics.DrawString(text, printFont, Brushes.Black, xPos, yPos);
            yPos += 2*printFont.GetHeight(e.Graphics);

            //Estadisticas Intensidad Precipitacion
            actualizarEstadisticasIntensidad();
            text = "Minimo: " + labelPrimerParametroValue.Text + "\t\t";
            text += "Maximo: " + labelSegundoParametroValue.Text + "\t\t";
            text += "Promedio: " + labelTercerParametroValue.Text;
            printFont = new Font("Arial", 10, FontStyle.Regular);
            e.Graphics.DrawString(text, printFont, Brushes.Black, xPos, yPos);
            yPos += printFont.GetHeight(e.Graphics);

            //Chart Intensidad de Precipitacion
            if (e.Graphics.PageUnit != GraphicsUnit.Pixel)
            {
                e.Graphics.PageUnit = GraphicsUnit.Pixel;
                rect1.X = (int)(xPos * (e.Graphics.DpiX / 100f));
                rect1.Y = (int)(yPos * (e.Graphics.DpiY / 100f));
            }
            chartIntensidad.Series["Intensidad"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartIntensidad.Printing.PrintPaint(e.Graphics, rect1);
            chartIntensidad.Series["Intensidad"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            e.Graphics.PageUnit = GraphicsUnit.Display;
            yPos += alturaChart;

            actualizarEstadisticas();
        }

        private void buttonImprimir_MouseHover(object sender, EventArgs e)
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                buttonImprimirVA.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                buttonImprimirVA.FlatStyle = FlatStyle.Standard;
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                buttonImprimirI.FlatStyle = FlatStyle.Standard;
        }

        private void buttonImprimir_MouseLeave(object sender, EventArgs e)
        {
            if (!botonCustomTimeSettingsApretado)
            {
                if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                    buttonImprimirVA.FlatStyle = FlatStyle.Flat;
                else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                    buttonImprimirVA.FlatStyle = FlatStyle.Flat;
                else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                    buttonImprimirI.FlatStyle = FlatStyle.Flat;
            }
        }



        private void resetVolumenAcumuladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelEstado.Text.Equals("CONECTADO"))
                {
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("Desea setear en cero el volumen acumulado en la estacion meteorologica?", "Reset Volumen Acumulado",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        Frame.ResetMediciones(serialPort);
                        return;
                    }
                }
                else
                    MessageBox.Show("Necesita estar online para acceder a esta funcionalidad.", "Offline",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Exception caught.",
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
                   

        private void actualizarEstadisticas()
        {
            if (comboBoxGraficoSeleccionado.Text.Equals("Distribucion Gotas"))
                actualizarEstadisticasDistribucionGotas();
            else if (comboBoxGraficoSeleccionado.Text.Equals("Volumen Acumulado"))
                actualizarEstadisticasVolumenAcumulado();
            else if (comboBoxGraficoSeleccionado.Text.Equals("Intensidad"))
                actualizarEstadisticasIntensidad();

        }


        private void actualizarEstadisticasDistribucionGotas()
        {
            //Configuracion Lables
            labelPrimerParametro.Text = "Cantidad Gotas: ";
            labelPrimerParametroValue.Location = new Point(101, labelPrimerParametroValue.Location.Y);
            labelSegundoParametro.Text = "Minimo Ø: ";
            labelSegundoParametroValue.Location = new Point(101, labelSegundoParametroValue.Location.Y);
            labelTercerParametro.Visible = true;
            labelTercerParametroValue.Visible = true;
            labelTercerParametro.Text = "Maximo Ø: ";
            labelTercerParametroValue.Location = new Point(101, labelTercerParametroValue.Location.Y);

            //Fecha De Inicio y Fin
            labelFechaInicio.Text = DateTime.FromOADate(chartDistribucion.ChartAreas[0].AxisX.Minimum).ToString("dd/MM/yyyy  HH:mm:ss");
            labelFechaFin.Text = DateTime.FromOADate(chartDistribucion.ChartAreas[0].AxisX.Maximum).ToString("dd/MM/yyyy  HH:mm:ss");

            //Maximo, Minimo y Promedio
            chartDistribucion.Series["Distribucion Gotas"].Sort(PointSortOrder.Ascending, "X");

            double Xmin = chartDistribucion.ChartAreas[0].AxisX.Minimum;
            double Xmax = chartDistribucion.ChartAreas[0].AxisX.Maximum;

            int cantidadPuntos = chartDistribucion.Series["Distribucion Gotas"].Points.Count;
            int indiceInicial = 0;
            DataPoint d = new DataPoint();

            while (indiceInicial < cantidadPuntos)
            {
                d = chartDistribucion.Series["Distribucion Gotas"].Points[indiceInicial];
                if(d.XValue > Xmin)
                    break;
                else
                    indiceInicial++;
            }

            if (indiceInicial == cantidadPuntos || d.XValue > Xmax)
            {    //No se encontraron puntos en el rango seleccionado 
                labelPrimerParametroValue.Text = "No hay datos";
                labelSegundoParametroValue.Text = "No hay datos";
                labelTercerParametroValue.Text = "No hay datos";
            }
            else
            {
                double Ymin = d.YValues[0];
                double Ymax = d.YValues[0];
                int Cantidad = 1;

                int indiceFinal = indiceInicial;

                while (indiceFinal+1 < cantidadPuntos)
                {
                    indiceFinal++;
                    d = chartDistribucion.Series["Distribucion Gotas"].Points[indiceFinal];

                    if (d.XValue < Xmax)
                    {
                        if (d.YValues[0] < Ymin)
                            Ymin = d.YValues[0];

                        if (d.YValues[0] > Ymax)
                            Ymax = d.YValues[0];

                        Cantidad++;
                    }
                    else
                        break;                    
                }

                labelPrimerParametroValue.Text = Cantidad.ToString();
                labelSegundoParametroValue.Text = Ymin.ToString() + " mm";
                labelTercerParametroValue.Text = Ymax.ToString() + " mm"; 
            }
        }


        private void actualizarEstadisticasVolumenAcumulado()
        {
            //Configuracion Lables
            labelPrimerParametro.Text = "Minimo: ";
            labelPrimerParametroValue.Location = new Point(72, labelPrimerParametroValue.Location.Y);
            labelSegundoParametro.Text = "Maximo: ";
            labelSegundoParametroValue.Location = new Point(72, labelSegundoParametroValue.Location.Y);
            labelTercerParametro.Visible = false;
            labelTercerParametroValue.Visible = false;

            //Fecha De Inicio y Fin
            labelFechaInicio.Text = DateTime.FromOADate(chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum).ToString("dd/MM/yyyy  HH:mm:ss");
            labelFechaFin.Text = DateTime.FromOADate(chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum).ToString("dd/MM/yyyy  HH:mm:ss");

            //Maximo, Minimo y Promedio
            chartVolumenAcumulado.Series["Volumen Acumulado"].Sort(PointSortOrder.Ascending, "X");

            double Xmin = chartVolumenAcumulado.ChartAreas[0].AxisX.Minimum;
            double Xmax = chartVolumenAcumulado.ChartAreas[0].AxisX.Maximum;
            
            int cantidadPuntos = chartVolumenAcumulado.Series["Volumen Acumulado"].Points.Count;
            int indiceInicial = 0;
            DataPoint d = new DataPoint();

            while (indiceInicial < cantidadPuntos)
            {   
                 d = chartVolumenAcumulado.Series["Volumen Acumulado"].Points[indiceInicial];
                 if(d.XValue > Xmin)
                    break;
                 else
                    indiceInicial++;
            }

            if (indiceInicial == cantidadPuntos || d.XValue > Xmax)
            {    //No se encontraron puntos en el rango seleccionado 
                labelPrimerParametroValue.Text = "No hay datos";
                labelSegundoParametroValue.Text = "No hay datos";
                labelTercerParametroValue.Text = "No hay datos";
            }
            else
            {
                double Ymin = d.YValues[0];
                double Ymax = d.YValues[0];

                int indiceFinal = indiceInicial;

                while (indiceFinal + 1 < cantidadPuntos)
                {
                    indiceFinal++;
                    d = chartVolumenAcumulado.Series["Volumen Acumulado"].Points[indiceFinal];

                    if (d.XValue < Xmax)
                    {
                        if (d.YValues[0] < Ymin)
                            Ymin = d.YValues[0];

                        if (d.YValues[0] > Ymax)
                            Ymax = d.YValues[0];
                    }
                    else
                        break;                    
                }

                labelPrimerParametroValue.Text = Ymin.ToString() + " mm";
                labelSegundoParametroValue.Text = Ymax.ToString() + " mm";
            }
        }


        private void actualizarEstadisticasIntensidad()
        {
            //Configuracion Lables
            labelPrimerParametro.Text = "Minimo: ";
            labelPrimerParametroValue.Location = new Point(72, labelPrimerParametroValue.Location.Y);
            labelSegundoParametro.Text = "Maximo: ";
            labelSegundoParametroValue.Location = new Point(72, labelSegundoParametroValue.Location.Y);
            labelTercerParametro.Visible = true;
            labelTercerParametroValue.Visible = true;
            labelTercerParametro.Text = "Promedio: ";
            labelTercerParametroValue.Location = new Point(72, labelTercerParametroValue.Location.Y);

            //Fecha De Inicio y Fin
            labelFechaInicio.Text = DateTime.FromOADate(chartIntensidad.ChartAreas[0].AxisX.Minimum).ToString("dd/MM/yyyy  HH:mm:ss");
            labelFechaFin.Text = DateTime.FromOADate(chartIntensidad.ChartAreas[0].AxisX.Maximum).ToString("dd/MM/yyyy  HH:mm:ss");

            //Maximo, Minimo y Promedio
            chartIntensidad.Series["Intensidad"].Sort(PointSortOrder.Ascending, "X");

            double Xmin = chartIntensidad.ChartAreas[0].AxisX.Minimum;
            double Xmax = chartIntensidad.ChartAreas[0].AxisX.Maximum;

            int cantidadPuntos = chartIntensidad.Series["Intensidad"].Points.Count;
            int indiceInicial = 0;
            DataPoint d = new DataPoint();

            while (indiceInicial < cantidadPuntos)
            {
                d = chartIntensidad.Series["Intensidad"].Points[indiceInicial];
                if (d.XValue > Xmin)
                    break;
                else
                    indiceInicial++;
            }

            if (indiceInicial == cantidadPuntos || d.XValue > Xmax)
            {    //No se encontraron puntos en el rango seleccionado 
                labelPrimerParametroValue.Text = "No hay datos";
                labelSegundoParametroValue.Text = "No hay datos";
                labelTercerParametroValue.Text = "No hay datos";
            }
            else
            {
                double Ymin = d.YValues[0];
                double Ymax = d.YValues[0];
                double Ypromedio = 0;
                double lastXValue = d.XValue;
                double lastYValue = d.YValues[0];

                int indiceFinal = indiceInicial;

                while (indiceFinal + 1 < cantidadPuntos)
                {
                    indiceFinal++;
                    d = chartIntensidad.Series["Intensidad"].Points[indiceFinal];

                    if (d.XValue < Xmax)
                    {
                        if (d.YValues[0] < Ymin)
                            Ymin = d.YValues[0];

                        if (d.YValues[0] > Ymax)
                            Ymax = d.YValues[0];

                        Ypromedio += lastYValue * (d.XValue - lastXValue) / (Xmax - Xmin);
                        lastXValue = d.XValue;
                        lastYValue = d.YValues[0];
                    }
                    else
                        break;
                }

                labelPrimerParametroValue.Text = Ymin.ToString() + " mm/h";
                labelSegundoParametroValue.Text = Ymax.ToString() + " mm/h";
                labelTercerParametroValue.Text = Ypromedio.ToString("0.00") + " mm/h";
            }
        }


        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelEstado.Text.Equals("DESCONECTADO"))
                {
                    ventanaOptions = new VentanaOptions();
                    ventanaOptions.ventanaOptionsTextBoxDirectory.Text = directoryPath;
                    DialogResult dr = ventanaOptions.ShowDialog();
                    if (dr == DialogResult.OK && !directoryPath.Equals(ventanaOptions.ventanaOptionsTextBoxDirectory.Text))
                    {
                        //Modificar Directorio de Archivos de Texto
                        modificarDirectorioArchivos(ventanaOptions.ventanaOptionsTextBoxDirectory.Text);
                    }
                }
                else
                    MessageBox.Show("Necesita estar offline para acceder a esta funcionalidad.", "Online",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Exception caught.",
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
		}
        

        private void modificarDirectorioArchivos(string newDirectory)
        {
            //Cerrar StreamsViejos
            srDistribucionGotas.Close();
            swDistribucionGotas.Close();
            srPrecipitacionAcumuladaIntensidad.Close();
            swPrecipitacionAcumuladaIntensidad.Close();

            //Mover los archivos al nuevo directorio
            File.Move(pathDistribucionGotas, newDirectory + nombreDistribucionGotas);
            File.Move(pathPrecipitacionAcumuladaIntensidad, newDirectory + nombrePrecipitacionAcumuladaIntensidad);
            pathDistribucionGotas = newDirectory + nombreDistribucionGotas;
            pathPrecipitacionAcumuladaIntensidad = newDirectory + nombrePrecipitacionAcumuladaIntensidad;

            //Inicializar Streams
            FileStream fileReadDistribucionGotas = new FileStream(pathDistribucionGotas, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            FileStream fileWriteDistribucionGotas = new FileStream(pathDistribucionGotas, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            srDistribucionGotas = new StreamReader(fileReadDistribucionGotas);
            swDistribucionGotas = new StreamWriter(fileWriteDistribucionGotas);
            FileStream fileReadPrecipitacionAcumuladaIntensidad = new FileStream(pathPrecipitacionAcumuladaIntensidad, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            FileStream fileWritePrecipitacionAcumuladaIntensidad = new FileStream(pathPrecipitacionAcumuladaIntensidad, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            srPrecipitacionAcumuladaIntensidad = new StreamReader(fileReadPrecipitacionAcumuladaIntensidad);
            swPrecipitacionAcumuladaIntensidad = new StreamWriter(fileWritePrecipitacionAcumuladaIntensidad);

            //Posicionar Writers al final del archivo
            swDistribucionGotas.BaseStream.Position = swDistribucionGotas.BaseStream.Length;
            swPrecipitacionAcumuladaIntensidad.BaseStream.Position = swPrecipitacionAcumuladaIntensidad.BaseStream.Length;

            directoryPath = newDirectory;
            regkey.SetValue("DirectoryPath", newDirectory);
        }


        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string linesFromFile = string.Empty;

            try
            {
                // Export a csv archivo de Precipitacion Acumulada
                srPrecipitacionAcumuladaIntensidad.BaseStream.Position = 0; 
                linesFromFile = srPrecipitacionAcumuladaIntensidad.ReadToEnd();
                linesFromFile = linesFromFile.Replace(" ", ",");
                using (StreamWriter sw = new StreamWriter(directoryPath + "\\precipitacionAcumulada.csv"))
                {
                    sw.WriteLine(linesFromFile);
                }

                // Export a csv archivo de Distribucion de Gotas
                srDistribucionGotas.BaseStream.Position = 0;
                linesFromFile = srDistribucionGotas.ReadToEnd();
                linesFromFile = linesFromFile.Replace(" ", ",");

                using (StreamWriter sw = new StreamWriter(directoryPath + "\\distribucionGotas.csv"))
                {
                    sw.WriteLine(linesFromFile);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("{0} Exception caught.", exception.ToString(),
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void timerConectado_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now > fechaUltimaTramaRecibida.AddMinutes(10))
            {
                MessageBox.Show("Ha habido problemas en la comunicacion con la estacion, y se pasara al modo DESCONECTADO", "Error de Comunicacion",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                stopOkReceived = false;
                serialPort.Close();
                labelEstado.Text = "DESCONECTADO";
                pictureBoxEstado.Image = Image.FromFile("../../Resources/red-notok-icon.png");
                groupBoxUpdateTime.Enabled = false;
                timerConectado.Enabled = false;
            }

        }     

    }
}

