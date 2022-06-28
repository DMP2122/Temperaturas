using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturaNS
{
    public class Prediccion
    {
        public const string NoListaVacia1 = "Faltan datos en el día 1";
        public const string NoListaVacia2 = "Faltan datos en el día 2";
        public const string NoListaVacia3 = "Faltan datos en el día 3";

        private double tempCelsius; // temperatura en grados Celsius
        private double tempFarenheit; // temperatura en grados farenheit
        private double tempMax; // temperatura máxima
        private double tempMin; // temperatura mínima

        /// <summary>
        /// Getters y setters de las variables
        /// </summary>
        public double TempCelsius { get => tempCelsius; set => tempCelsius = value; }
        public double TempFarenheit { get => tempFarenheit; set => tempFarenheit = value; }
        public double TempMax { get => tempMax; set => tempMax = value; }
        public double TempMin { get => tempMin; set => tempMin = value; }

        /// <summary>
        /// Constuctor que inicializan las variables
        /// </summary>
        public Prediccion()
        {
            TempCelsius = 0;
            TempFarenheit = 0;
            TempMax = -1000;
            TempMin = 1000;
        }

        /// <summary>
        /// Funcion que predice la temperatura a raiz de tres dias de observacion
        /// <para>calculamos la temperatura media total de cada dia de observacion, dándo más peso al último día que al primero</para>
        /// <para>y obtenemos los grados en celsuis y farenheit</para>
        /// </summary>
        /// <remarks>El metodo calcula las temeperatura media del dia 1<paramref name="observacionDia1"/>
        /// la temperatura media del dia 2 <paramref name="observacionDia2"/>y la del dia 3 <paramref name="observacionDia3"/></remarks>
        /// <returns>devuelve la prevision basada en el metodo, con la temperatura máxima<see cref=">
        /// TempMax"/> y la mínima <see cref=">TempMin"/>al igual que los grados celsius <see cref=">TempCelsius"/>
        /// y los farengeit<see cref=">TempFarenheit"/></returns> 
        /// <exception cref="Exception">La lista no puede estar vacía</exception>

        public bool PredecirTemperatura(List<double> observacionDia1, List<double> observacionDia2, List<double> observacionDia3)
        {
            double tempMedia1 = CalcularPrevision(observacionDia1, NoListaVacia1);
            double tempMedia2 = CalcularPrevision(observacionDia2, NoListaVacia2);
            double tempMedia3 = CalcularPrevision(observacionDia3, NoListaVacia3);
            TempCelsius = 0.2 * tempMedia1 + 0.35 * tempMedia2 + 0.45 * tempMedia3;
            TempFarenheit = (TempCelsius * 1.8) + 32;
            // calculamos también la temperatura en grados farenheit

            return true;
        }

        private double CalcularPrevision(List<double> observacionDia, string excepcion)
        {
            double tempMedia = 0;
            if (observacionDia.Count <= 0)
            {
                throw new Exception(excepcion);
                // Tenemos que tener al menos una observación
            }
            for (int i = 0; i < observacionDia.Count; i++)
            {
                tempMedia = tempMedia + observacionDia[i];

                if (TempMin > observacionDia[i])
                {
                    TempMin = observacionDia[i];
                }

                if (TempMax < observacionDia[i])
                {
                    TempMax = observacionDia[i];
                }

            }
            return tempMedia / observacionDia.Count;
            
        }
    }
}
