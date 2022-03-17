using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.APIHelper;
using Test.Logs;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        string USUARIO_PARAMETRIZADO = "admin";
        string PASS_PARAMETRIZADO = "123";
        public ActionResult Login()
        {
            LogsHelper logHelper = new LogsHelper();
            return View();
        }
        [HttpPost]
        public ActionResult Loguearse(string txtUsuario, string txtPass)
        {
            LogsHelper logHelper = new LogsHelper();
            if (txtUsuario.Equals(USUARIO_PARAMETRIZADO) && txtPass.Equals(PASS_PARAMETRIZADO))
            {
                ViewBag.Usuario = txtUsuario;
                logHelper.EscribirEnLog("Login exitoso.");
            return View("Index");
            }
            logHelper.EscribirEnLog("Login incorrecto-> Usuario: " + txtUsuario + ", Pass: " + txtPass);
            ViewBag.Message = "Alguno de los datos ingresados es incorrecto.";
            return View("Login");
        }
        [HttpPost]
        public ActionResult Provincias(string provincia)
        {
            LogsHelper logHelper = new LogsHelper();
            ViewBag.Usuario = USUARIO_PARAMETRIZADO;
            ViewBag.Provincia = provincia;
            ApiHelper api = new ApiHelper();
            Root listaProvincia = new Root();
            logHelper.EscribirEnLog("Buscando provincia " + provincia);
            try
            {
                listaProvincia = api.CallAuth(provincia);
                logHelper.EscribirEnLog("Cantidad de resultados: " + listaProvincia.cantidad);
            }
            catch (Exception ex)
            {
                logHelper.EscribirEnLog(DateTime.Now.ToString() + " - ERROR: " + ex.Message);
                throw new Exception(ex.Message);
            }

            ViewBag.Lat = listaProvincia.provincias[0].centroide.lat;
            ViewBag.Lon = listaProvincia.provincias[0].centroide.lon;

            return View("Index");
        }
    }
}