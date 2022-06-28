using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemperaturaNS;
using System.Collections.Generic;

namespace TemperaturaPrueba
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaDatosCorrectos() //Esta prueba pretende sacar un error si la temperatura máxima o mínima es mayor o menor de lo introducido en la clase
        {
            Prediccion miPrediccionPrueba = new Prediccion();
            List<double> dia1 = new List<double>(),
                         dia2 = new List<double>(),
                         dia3 = new List<double>();

            dia1.Add(12.5);
            dia1.Add(16.5);
            dia1.Add(21);
            dia1.Add(17);
            dia1.Add(15);
            dia2.Add(13);
            dia2.Add(15);
            dia2.Add(19.5);
            dia2.Add(16.5);
            dia2.Add(14);
            dia3.Add(14.5);
            dia3.Add(18.5);
            dia3.Add(23);
            dia3.Add(20);
            dia3.Add(17.5);

            double temperaturaMediaDia1 = 16.4;
            double temperaturaMediaDia2 = 15.6;
            double temperaturaMediaDia3 = 18.7;

            double celsuiusEsperados = 17.155;
            double farenheitEsperados = 62.879;
            double temperaturaMaxEsperada = 23;
            double temperaturaMinEsperada = 12.5;

            miPrediccionPrueba.PredecirTemperatura(dia1, dia2, dia3);

            Assert.AreEqual(celsuiusEsperados, miPrediccionPrueba.TempCelsius, 0.001, "Los valores no son correctos");
            Assert.AreEqual(farenheitEsperados, miPrediccionPrueba.TempFarenheit, 0.001, "Los valores no son correctos");
            Assert.AreEqual(temperaturaMaxEsperada, miPrediccionPrueba.TempMax,  "Los valores no son correctos");
            Assert.AreEqual(temperaturaMinEsperada, miPrediccionPrueba.TempMin, "Los valores no son correctos");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),Prediccion.NoListaVacia1)]
        public void PruebaDia1Vacio ()
        {
            Prediccion miPrediccionPrueba = new Prediccion();
            List<double> dia1 = new List<double>(),
                         dia2 = new List<double>(),
                         dia3 = new List<double>();

            dia2.Add(13); dia2.Add(15); dia2.Add(19.5); dia2.Add(16.5); dia2.Add(14);
            dia3.Add(14.5); dia3.Add(18.5); dia3.Add(23); dia3.Add(20); dia3.Add(17.5);
   
            miPrediccionPrueba.PredecirTemperatura(dia1, dia2, dia3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), Prediccion.NoListaVacia2)]
        public void PruebaDia2Vacio()
        {
            Prediccion miPrediccionPrueba = new Prediccion();

            List<double> dia1 = new List<double>(),
                         dia2 = new List<double>(),
                         dia3 = new List<double>();

            dia1.Add(12.5); dia1.Add(16.5); dia1.Add(21); dia1.Add(17); dia1.Add(15);
            dia3.Add(14.5); dia3.Add(18.5); dia3.Add(23); dia3.Add(20); dia3.Add(17.5);

            miPrediccionPrueba.PredecirTemperatura(dia1, dia2, dia3);
        }

        [TestMethod]

        public void PruebaDia3Vacio()
        {
            Prediccion miPrediccionPrueba = new Prediccion();

            List<double> dia1 = new List<double>(),
                         dia2 = new List<double>(),
                         dia3 = new List<double>();

            dia1.Add(12.5); dia1.Add(16.5); dia1.Add(21); dia1.Add(17); dia1.Add(15);
            dia2.Add(13); dia2.Add(15); dia2.Add(19.5); dia2.Add(16.5); dia2.Add(14);
            try
            {
                miPrediccionPrueba.PredecirTemperatura(dia1, dia2, dia3);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, Prediccion.NoListaVacia3);
                return;
            }
            Assert.Fail("Error");
        }
    }
}
