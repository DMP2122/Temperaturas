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
        /// <para>calculamos la temperatura media total, dándo más peso al último día que al primero</para>
        /// </summary>
        /// <param name="observacionDia1">datos de orsevacion de dia 1</param>
        /// <param name="observacionDia2">datos de orsevacion de dia 2</param>
        /// <param name="observacionDia3">datos de orsevacion de dia 3</param>
        /// <exception cref="Exception">La lista no puede estar vacía</exception>
        /// <returns>devuelve la prevision basada en el metodo</returns>  

        public bool PredecirTemperatura(List<double> observacionDia1,
            List<double> observacionDia2, List<double> observacionDia3)
        {
            int i;
            double tempMedia1 = 0,
                   tempMedia2 = 0,
                   tempMedia3 = 0; // temperatura media de cada día

            if (observacionDia1.Count <= 0)
            {
                throw new Exception(NoListaVacia1);
                // Tenemos que tener al menos una observación
            }
            i = CalcularPrevision(observacionDia1, ref tempMedia1);

            tempMedia1 = tempMedia1 / observacionDia1.Count;



            if (observacionDia2.Count <= 0)
            {
                     throw new Exception(NoListaVacia2);
                // Tenemos que tener al menos una observación
            }

            i = CalcularPrevision(observacionDia2, ref tempMedia2);

            tempMedia2 = tempMedia2 / observacionDia2.Count;

            if (observacionDia3.Count <= 0)
            {
                    throw new Exception(NoListaVacia3);
                // Tenemos que tener al menos una observación
            }

            i = CalcularPrevision(observacionDia3, ref tempMedia3);

            tempMedia3 = tempMedia3 / observacionDia3.Count;

             TempCelsius = 0.2 * tempMedia1 + 0.35 * tempMedia2 + 0.45 * tempMedia3;
             TempFarenheit = (TempCelsius * 1.8) + 32;
            // calculamos también la temperatura en grados farenheit

            return true;
        }

        private int CalcularPrevision(List<double> observacionDia1, ref double tempMedia1)
        {
            int i;
            for (i = 0; i < observacionDia1.Count; i++)
            {
                tempMedia1 = tempMedia1 + observacionDia1[i];

                if (TempMin > observacionDia1[i])
                {
                    TempMin = observacionDia1[i];
                }

                if (TempMax < observacionDia1[i])
                {
                    TempMax = observacionDia1[i];
                }
            }
            return i;
        }
    }
}
