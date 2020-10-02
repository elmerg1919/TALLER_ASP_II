using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TALLER_ASP_II.Models;
namespace TALLER_ASP_II.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Index() 
        {
            List<Peliculas> lst;
            using (CinePlusEntities DB=new CinePlusEntities())
            {
                lst = (from d in DB.Peliculas
                       select new Peliculas
                       {
                           idPelicula = d.idPelicula,
                           Director = d.Director,
                           Sinopsis = d.Sinopsis,
                           Género = d.Género,
                           TituloPelicula = d.TituloPelicula,
                           Calificacion = d.Calificacion,
                           Poster = d.Poster
                       }).ToList();
            }
                return View(lst);
        }
    }
}