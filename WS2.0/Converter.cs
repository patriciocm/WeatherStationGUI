using System;
using System.Collections.Generic;
using System.Text;

namespace pgp
{
    class Converter
    {
        static public Int32 DWordToDecimal(byte[] ptrDWord, int indexInicial)
        {
            Int32 tramaAuxiliar = ptrDWord[indexInicial] << 24 | ptrDWord[indexInicial + 1] << 16 | ptrDWord[indexInicial + 2] << 8 | ptrDWord[indexInicial + 3];
            return tramaAuxiliar;
        }

        static public Int32 WordToDecimal(byte[] ptrDWord, int indexInicial)
        {
            Int32 tramaAuxiliar = ptrDWord[indexInicial] << 8 | ptrDWord[indexInicial + 1];
            return tramaAuxiliar;
        }

        static public double AsciiToDecimal(byte[] ptrDWord, int indexInicial)
        {
            char[] valorVolumenChar = new char[5];

            //Pasar de byte[] a string
            for (int i = indexInicial; i < indexInicial + 5; i++ )
                valorVolumenChar[i - indexInicial] = Convert.ToChar(ptrDWord[i]);

            string valorVolumenString = new string(valorVolumenChar, 0, 5);
            double valorVolumenFloat = Convert.ToDouble(valorVolumenString);
            return valorVolumenFloat;
        }
    }
}
