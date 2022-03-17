using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.APIHelper;
using Test.Logs;
using System.IO;

namespace Test.Tests.Tests
{
    [TestClass()]
    public class TestsGeneralesTests
    {
        [TestMethod()]
        public void GetProvincia()
        {
            ApiHelper api = new ApiHelper();
            Root listaProvincia = new Root();

            try
            {
                listaProvincia = api.CallAuth("Buenos");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            Assert.IsTrue(listaProvincia.cantidad == 2, "No se encontraron resultados");
        }
        [TestMethod()]
        public void GetLatitud()
        {
            ApiHelper api = new ApiHelper();
            Root listaProvincia = new Root();

            try
            {
                listaProvincia = api.CallAuth("La Pampa");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            double lat = listaProvincia.provincias[0].centroide.lat;

            Assert.IsTrue(lat == -37.1315537735949, "No se encontraron resultados");
        }
        [TestMethod()]
        public void ExisteArchivo()
        {
            string file_name = @"D:\Log-Test-Tecnico.txt";
            LogsHelper logHelper = new LogsHelper();
            Assert.IsTrue(File.Exists(file_name), "Archivo no encontrado");
        }
    }
}