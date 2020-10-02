using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TALLER_ASP_II.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string sUsuario, string sContra)
        {
            ViewBag.Message = "Debe iniciar sesión para realizar esta acción.";
            string usuario = "admin" ;
            string contra="12345";
            if (sUsuario == usuario && sContra == contra)
            {
                return Redirect("/Peliculas1/Index");
            }
            else
            {
                // Si el numero de pin o de tarjeta no corresponde, entonces se
                // procede a mostrar un mensaje de error
                ViewBag.Error = "Error en nombre de usuario o contraseña. Verifique";
                return View();
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}