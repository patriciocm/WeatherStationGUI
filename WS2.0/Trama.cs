using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace pgp
{
    enum estado { Waiting_Delimiter, Waiting_MSB, Waiting_LSB, Waiting_Data, Waiting_Checksum, Ready };
    public enum tipoTrama
    {
        NonValid, Start = 0x10, StartOk = 0x11, Stop = 0x90, StopOk = 0x91, TransmitData, TransmitStatus, ATResponse, RemoteATResponse,
        GotaDetectada = 0x12, ActualizarVolumen = 0x13, ResetMedicionesLluvia = 0x14, UpdateRefreshTime = 0x15,
        TransmitHistoryGotaDetectada = 0x16, TransmitHistoryVolumenIntesidad = 0x17, FinishHistoryTransmission = 0x18,
        RTCReadRequest = 0x20, RTCReadResponse = 0x21, RTCSet = 0x22
    };

    public class Frame
    {
        private List<byte> trama;
        private ushort frameLength;
        private byte MSB;
        private byte LSB;
        private byte datosLength;
        private estado estadoActual;


        public List<byte> Trama
        {
            get { return trama; }
            set { trama = value; }
        }

        internal estado EstadoActual
        {
            get { return estadoActual; }
            set { estadoActual = value; }
        }


        //Constructor
        public Frame()
        {
            trama = new List<byte>();
            estadoActual = estado.Waiting_Delimiter;
            frameLength = 0;
            datosLength = 0;

        }


        //Metodo que recibe datos y arma toda la trama[]
        public static void ArmarTrama(byte[] datos, ref Frame tramaParaArmar)
        {
            tramaParaArmar.trama[0] = 0x7E;

            ushort count = 0;
            byte checksum = 0;

            foreach (byte dato in datos)
            {
                tramaParaArmar.trama[3 + count] = dato;
                checksum = (byte)(checksum + dato);
                count++;
            }

            tramaParaArmar.trama[1] = (byte)(count >> 8);
            tramaParaArmar.trama[2] = (byte)count;
            tramaParaArmar.trama[count + 3] = checksum;
        }


        //Metodo que recibe bytes y los agrega a trama[]
        public void CargarBytes(byte[] frame_bytes)
        {
            bool ready = false;

            foreach (byte dato in frame_bytes)
            {
                switch (EstadoActual)
                {
                    case estado.Waiting_Delimiter:
                        if (frame_bytes[0] == 0x7E)
                        {
                            trama.Add(dato);
                            estadoActual = estado.Waiting_MSB;
                        }
                        break;

                    case estado.Waiting_MSB:
                        trama.Add(dato);
                        estadoActual = estado.Waiting_LSB;
                        break;

                    case estado.Waiting_LSB:
                        trama.Add(dato);
                        LSB = dato;
                        estadoActual = estado.Waiting_Data;
                        frameLength = (ushort)(MSB << 8);
                        frameLength = LSB;
                        break;

                    case estado.Waiting_Data:
                        trama.Add(dato);
                        datosLength += 1;
                        if (frameLength == datosLength)
                            estadoActual = estado.Waiting_Checksum;
                        break;

                    case estado.Waiting_Checksum:
                        trama.Add(dato);
                        estadoActual = estado.Ready;
                        ready = true;
                        break;
                }

                if (ready)
                    break;
            }
        }


        //Metodo para borra contenido de trama[];
        public void BorrarTrama()
        {
            trama.Clear();
            estadoActual = estado.Waiting_Delimiter;
            frameLength = 0;
            MSB = 0;
            LSB = 0;
            datosLength = 0;
        }


        //Metodo para chequear si la trama recibida es correcta (estructura y checksum)
        //Devuelve el tipo de trama recibida
        public tipoTrama ChequearTrama()
        {
            //Chequeo de Frame Delimiter
            if (this.Trama[0] != 0x7E)
                return tipoTrama.NonValid;

            //Chequeo Basico de Tamanio
            if (this.Trama.Count < 5)
                return tipoTrama.NonValid;

            ushort largoTramaRecibida = this.Trama[1];
            largoTramaRecibida = (ushort)(largoTramaRecibida << 8);
            largoTramaRecibida += this.Trama[2];

            //Chequeo de Tamanio con MSB y LSB
            if ((this.Trama.Count - 4) != largoTramaRecibida)
                return tipoTrama.NonValid;

            byte checksum = 0;

            //Chequeo de Checksum y carga del campo datos en byte[] datos
            for (int x = 0; x < largoTramaRecibida; x++)
            {
                checksum = (byte)(checksum + this.Trama[3 + x]);
            }
            checksum = (byte)(checksum + this.Trama[3 + largoTramaRecibida]);
            if (checksum != 0xFF)
                return tipoTrama.NonValid;


            switch (this.Trama[3])
            {
                //Transmit Request Packet
                case 0x01:
                    break;

                //Receive Packet
                case 0x81:
                    break;

                //AT Command Response
                case 0x88:
                    return tipoTrama.ATResponse;

                //Transmit Status
                case 0x89:
                    return tipoTrama.TransmitStatus;

                //Remote AT Command Response
                case 0x97:
                    return tipoTrama.RemoteATResponse;

                default:
                    return tipoTrama.NonValid;
            }

            switch (this.Trama[8])
            {
                //Receive Start Packet
                case 0x10:
                    return tipoTrama.Start;

                //Receive StartOk Packet
                case 0x11:
                    return tipoTrama.StartOk;

                //Receive Stop Packet
                case 0x90:
                    return tipoTrama.Stop;

                //Receive StopOk Packet
                case 0x91:
                    return tipoTrama.StopOk;

                //Receive Data Packet (Mediciones de Gotas)
                case 0x12:
                    return tipoTrama.GotaDetectada;

                //Receive Data Packet (Volumen de Agua)
                case 0x13:
                    return tipoTrama.ActualizarVolumen;

                //Receive Reset Mediciones
                case 0x14:
                    return tipoTrama.ResetMedicionesLluvia;

                //Receive Update Transmition Time
                case 0x15:
                    return tipoTrama.UpdateRefreshTime;

                //Receive Transmision Historia Gotas Detectadas
                case 0x16:
                    return tipoTrama.TransmitHistoryGotaDetectada;

                //Receive Transmision Historia Volumen/Intensidad Acumulados
                case 0x17:
                    return tipoTrama.TransmitHistoryVolumenIntesidad;

                //Receive Finish History Transmission
                case 0x18:
                    return tipoTrama.FinishHistoryTransmission;

                //Receive Leer RTC Response
                case 0x21:
                    return tipoTrama.RTCReadResponse;

                default:
                    return tipoTrama.NonValid;
            }
        }


        //Metodo para chequear si la trama recibida es correcta (estructura y checksum)
        //Devuelve el tipo de trama recibida
        //En caso de recibir trama correcta se guarda en datos[] el campo datos de la trama
        public tipoTrama ChequearTrama(ref byte[] datos)
        {
            //Chequeo de Frame Delimiter
            if (this.Trama[0] != 0x7E)
                return tipoTrama.NonValid;

            //Chequeo Basico de Tamanio
            if (this.Trama.Count < 5)
                return tipoTrama.NonValid;

            ushort largoTramaRecibida = this.Trama[1];
            largoTramaRecibida = (ushort)(largoTramaRecibida << 8);
            largoTramaRecibida += this.Trama[2];

            //Chequeo de Tamanio con MSB y LSB
            if ((this.Trama.Count - 4) != largoTramaRecibida)
                return tipoTrama.NonValid;

            byte checksum = 0;
            datos = new byte[largoTramaRecibida];

            //Chequeo de Checksum y carga del campo datos en byte[] datos
            for (int x = 0; x < largoTramaRecibida; x++)
            {
                datos[x] = this.Trama[3 + x];
                checksum = (byte)(checksum + this.Trama[3 + x]);
            }
            checksum = (byte)(checksum + this.Trama[3 + largoTramaRecibida]);
            if (checksum != 0xFF)
                return tipoTrama.NonValid;


            switch (this.Trama[3])
            {
                //Receive Packet
                case 0x81:
                    break;

                //AT Command Response
                case 0x88:
                    return tipoTrama.ATResponse;

                //Transmit Status
                case 0x89:
                    return tipoTrama.TransmitStatus;

                //Remote AT Command Response
                case 0x97:
                    return tipoTrama.RemoteATResponse;

                default:
                    return tipoTrama.NonValid;
            }

            switch (this.Trama[8])
            {
                //Receive Start Packet
                case 0x10:
                    return tipoTrama.Start;

                //Receive Stop Packet
                case 0x90:
                    return tipoTrama.Stop;

                //Receive Data Packet (Mediciones de Gotas)
                case 0x12:
                    return tipoTrama.GotaDetectada;

                //Receive Data Packet (Volumen de Agua)
                case 0x13:
                    return tipoTrama.ActualizarVolumen;

                //Receive History Request
                case 0x14:
                    return tipoTrama.ResetMedicionesLluvia;

                //Receive Update Transmition Time
                case 0x15:
                    return tipoTrama.UpdateRefreshTime;

                //Receive History Request
                case 0x16:
                    return tipoTrama.TransmitHistoryGotaDetectada;

                //Receive History Request
                case 0x17:
                    return tipoTrama.TransmitHistoryVolumenIntesidad;

                default:
                    return tipoTrama.NonValid;
            }
        }


        public static void EnviarStart(SerialPort puertoserial)
        {
            byte[] array = new byte[10];

            array[0] = 0x7E;
            array[1] = 0x00;
            array[2] = 0x06;
            array[3] = 0x01;
            array[4] = 0x01;
            array[5] = 0x00;
            array[6] = 0x02;
            array[7] = 0x00;
            array[8] = 0x10;
            array[9] = 0xEB;

            try
            {
                puertoserial.Write(array, 0, array.Length);
            }
            catch { }
        }

        public static void EnviarStop(SerialPort puertoserial)
        {
            byte[] array = new byte[10];

            array[0] = 0x7E;
            array[1] = 0x00;
            array[2] = 0x06;
            array[3] = 0x01;
            array[4] = 0x01;
            array[5] = 0x00;
            array[6] = 0x02;
            array[7] = 0x00;
            array[8] = 0x90;
            array[9] = 0x6B;

            try
            {
                puertoserial.Write(array, 0, array.Length);
            }
            catch { }
        }

        public static void ResetMediciones(SerialPort puertoserial)
        {
            byte[] array = new byte[10];

            array[0] = 0x7E;
            array[1] = 0x00;
            array[2] = 0x06;
            array[3] = 0x01;
            array[4] = 0x01;
            array[5] = 0x00;
            array[6] = 0x02;    //Direccion
            array[7] = 0x00;
            array[8] = 0x14;
            array[9] = (byte)(0xFF - 0x18);

            try
            {
                puertoserial.Write(array, 0, array.Length);
            }
            catch { }
        }

        public static void EnviarRefreshTiempoMediciones(SerialPort puertoserial, byte refreshRate)
        {
            byte[] array = new byte[11];

            array[0] = 0x7E;
            array[1] = 0x00;
            array[2] = 0x07;
            array[3] = 0x01;
            array[4] = 0x01;
            array[5] = 0x00;
            array[6] = 0x02;    //Direccion
            array[7] = 0x00;
            array[8] = 0x15;
            array[9] = refreshRate;
            array[10] = (byte)(0xFF - (0x19 + refreshRate));

            try
            {
                puertoserial.Write(array, 0, array.Length);
            }
            catch { }
        }

        public static void EnviarRTCReadRequest(SerialPort puertoserial)
        {
            byte[] array = new byte[10];

            array[0] = 0x7E;
            array[1] = 0x00;
            array[2] = 0x06;
            array[3] = 0x01;
            array[4] = 0x01;
            array[5] = 0x00;
            array[6] = 0x02;    //Direccion
            array[7] = 0x00;
            array[8] = 0x20;
            array[9] = (byte)(0xFF - 0x24);

            try
            {
                puertoserial.Write(array, 0, array.Length);
            }
            catch { }
        }

        public static void EnviarRTCSet(SerialPort puertoserial, int dia, int mes, int anio, int hora, int minuto, int segundo)
        {
            byte[] array = new byte[17];
            byte checksumAux = 0;

            array[0] = 0x7E;
            array[1] = 0x00;
            array[2] = 0x0D;
            array[3] = 0x01;
            array[4] = 0x01;
            array[5] = 0x00;
            array[6] = 0x02;    
            array[7] = 0x00;
            array[8] = 0x22;
            array[9] = (byte)dia;
            array[10] = (byte)mes;
            array[11] = (byte)(anio >> 8 );
            array[12] = (byte)anio;
            array[13] = (byte)hora;
            array[14] = (byte)minuto;
            array[15] = (byte)segundo;

            for (int i = 0; i < array[2]; i++)
            {
                checksumAux += array[i + 3];
            }

            array[16] = (byte)(0xFF - checksumAux);

            try
            {
                puertoserial.Write(array, 0, array.Length);
            }
            catch { }
        }

        public static void EnviarLocalAT(SerialPort puertoserial, String comandoAT)
        {
            byte[] array = new byte[8];
            byte checksumAux = 0;

            try
            {
                array[0] = 0x7E;
                array[1] = 0x00;
                array[2] = 0x04;
                array[3] = 0x08;  //Tipo de Trama
                array[4] = 0x01;  //FrameID
                array[5] = (byte)comandoAT[0];   //B
                array[6] = (byte)comandoAT[1];   //D

                for (int i = 0; i < array[2]; i++)
                {
                    checksumAux += array[i + 3];
                }

                array[7] = (byte)(0xFF - checksumAux);

                puertoserial.Write(array, 0, array.Length);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Exception caught.",
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public static void EnviarLocalAT(SerialPort puertoserial, String comandoAT, Byte[] valorComando)
        {
            byte[] array = new byte[12];
            byte checksumAux = 0;

            try
            {
                array[0] = 0x7E;
                array[1] = 0x00;
                array[2] = 0x08;
                array[3] = 0x08;  //Tipo de Trama
                array[4] = 0x01;  //FrameID
                array[5] = (byte)comandoAT[0];   //B
                array[6] = (byte)comandoAT[1];   //D
                array[7] = valorComando[0];
                array[8] = valorComando[1];
                array[9] = valorComando[2];
                array[10] = valorComando[3];

                for (int i = 0; i < array[2]; i++)
                {
                    checksumAux += array[i + 3];
                }

                array[11] = (byte)(0xFF - checksumAux);

                puertoserial.Write(array, 0, array.Length);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Exception caught.",
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public String ParsearTramaRecibidaATResponse()
        {
            String respuesta = "";
            Int32 respuestaInt = 0;
            byte[] datosRecibidos = this.trama.ToArray();
            byte[] valorComandoAT = new byte[this.datosLength - 5];

            for (int i = 0; i < valorComandoAT.Length; i++)
            {
                valorComandoAT[i] = datosRecibidos[i + 8];
            }

            if (valorComandoAT.Length == 1)
                respuestaInt = valorComandoAT[0];
            else if (valorComandoAT.Length == 2)
                respuestaInt = Converter.WordToDecimal(valorComandoAT, 0);
            else if (valorComandoAT.Length == 4)
                respuestaInt = Converter.DWordToDecimal(valorComandoAT, 0);

            respuesta = respuestaInt.ToString();
            return respuesta;

        }

        public static void EnviarRemoteAT(SerialPort puertoserial, String comandoAT)
        {            
            byte[] array = new byte[19];
            byte checksumAux = 0;

            try
            {
                array[0] = 0x7E;
                array[1] = 0x00;
                array[2] = 0x0F;
                array[3] = 0x17;  //Tipo de Trama
                array[4] = 0x01;  //FrameID
                array[5] = 0x00;
                array[6] = 0x00;
                array[7] = 0x00;
                array[8] = 0x00;
                array[9] = 0x00;
                array[10] = 0x00;
                array[11] = 0x00;
                array[12] = 0x00;
                array[13] = 0x00;   //Destination High
                array[14] = 0x02;   //Destination Low
                array[15] = 0x00;   //Apply Changes
                array[16] = (byte) comandoAT[0];   //B
                array[17] = (byte) comandoAT[1];   //D

                for (int i = 0; i < array[2]; i++)
                {
                    checksumAux += array[i + 3];
                }

                array[18] = (byte)(0xFF - checksumAux);

                puertoserial.Write(array, 0, array.Length);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Exception caught.", 
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void EnviarRemoteAT(SerialPort puertoserial, String comandoAT, Byte[] valorComando)
        {
            byte[] array = new byte[23];
            byte checksumAux = 0;

            try
            {
                array[0] = 0x7E;
                array[1] = 0x00;
                array[2] = 0x13;
                array[3] = 0x17;  //Tipo de Trama
                array[4] = 0x01;  //FrameID
                array[5] = 0x00;
                array[6] = 0x00;
                array[7] = 0x00;
                array[8] = 0x00;
                array[9] = 0x00;
                array[10] = 0x00;
                array[11] = 0x00;
                array[12] = 0x00;
                array[13] = 0x00;   //Destination High
                array[14] = 0x02;   //Destination Low
                array[15] = 0x00;   //Apply Changes
                array[16] = (byte)comandoAT[0];   //B
                array[17] = (byte)comandoAT[1];   //D
                array[18] = valorComando[0];
                array[19] = valorComando[1];
                array[20] = valorComando[2];
                array[21] = valorComando[3];


                for (int i = 0; i < array[2]; i++)
                {
                    checksumAux += array[i + 3];
                }

                array[22] = (byte)(0xFF - checksumAux);

                puertoserial.Write(array, 0, array.Length);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Exception caught.",
                                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public String ParsearTramaRecibidaRemoteATResponse()
        {
            String respuesta = "";
            Int32 respuestaInt = 0;
            byte[] datosRecibidos = this.trama.ToArray();
            byte[] valorComandoAT = new byte[this.datosLength - 15];

            for (int i = 0; i < valorComandoAT.Length; i++)
            {
                valorComandoAT[i] = datosRecibidos[i + 18];
            }

            if (valorComandoAT.Length == 1)
                respuestaInt = valorComandoAT[0];
            else if (valorComandoAT.Length == 2)
                respuestaInt = Converter.WordToDecimal(valorComandoAT, 0);
            else if (valorComandoAT.Length == 4)
                respuestaInt = Converter.DWordToDecimal(valorComandoAT, 0);

            respuesta = respuestaInt.ToString();
            return respuesta;

        }

        public String[] ParsearTramaRecibidaGota()
        {
            byte[] datosRecibidos = this.trama.ToArray();
            char[] charArray = Encoding.ASCII.GetString(datosRecibidos).ToCharArray();
            string valorVolumenString = new string(charArray, 9, this.datosLength - 6);

            String[] StringValuesSplit;
            StringValuesSplit = valorVolumenString.Split('#');

            //Calcular volumen y diametro de la gota
            double tensionGota = Convert.ToDouble(StringValuesSplit[6]);   //en V
            double volumenGota = 0.6 * 1.963 * 0.0125 * Math.Pow(tensionGota, 0.4);  //en cm3
            double tamanioGota = Math.Pow(volumenGota * 3 / (4 * Math.PI), 1 / 3.0) * 20; //en mm

            Array.Resize(ref StringValuesSplit, StringValuesSplit.Length + 2);
            volumenGota = Math.Truncate(volumenGota * 100000) / 100000;
            tamanioGota = Math.Truncate(tamanioGota * 100) / 100;
            StringValuesSplit[7] = volumenGota.ToString();
            StringValuesSplit[8] = tamanioGota.ToString();

            return StringValuesSplit;

        }

        public String[] ParsearTramaRecibidaVolumen()
        {

            byte[] datosRecibidos = this.trama.ToArray();
            char[] charArray = Encoding.ASCII.GetString(datosRecibidos).ToCharArray();
            string valorVolumenString = new string(charArray, 9, this.datosLength - 6);

            String[] StringValuesSplit;
            return StringValuesSplit = valorVolumenString.Split('#');

            /*
            Int16 i = 0;

            FloatValuesSplit = valorVolumenString.Split('#');
            Double[] floatValues = new Double[FloatValuesSplit.Length];

            foreach (string elemento in FloatValuesSplit)
                floatValues[i++] = Convert.ToDouble(elemento);

            return floatValues;*/
        }

        public DateTime ParsearTramaRecibidaRTCReadResponse()
        {
            byte[] datosRecibidos = this.trama.ToArray();
            char[] charArray = Encoding.ASCII.GetString(datosRecibidos).ToCharArray();
            string valorVolumenString = new string(charArray, 9, this.datosLength - 6);

            String[] StringValuesSplit = valorVolumenString.Split('#');
            DateTime dateTime = Convert.ToDateTime(StringValuesSplit[2] + "-" + StringValuesSplit[1] + "-" + StringValuesSplit[0] + " " + StringValuesSplit[3] + ":" + StringValuesSplit[4] + ":" + StringValuesSplit[5]);

            return dateTime;
        }
       
    }
}
