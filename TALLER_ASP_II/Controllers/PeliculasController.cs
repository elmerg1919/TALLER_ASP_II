using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TALLER_ASP_II.Models;
using TALLER_ASP_II.Models.VIEWPELICULAS;

namespace TALLER_ASP_II.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Index() 
        {
            List<LISTAPELISVIEWMODEL> lst;
            using (CinePlusEntities DB=new CinePlusEntities())
            {
                 lst = (from d in DB.Peliculas
                           select new LISTAPELISVIEWMODEL
                           {
                               idPelicula = d.idPelicula,
                               Director = d.Director,
                               Sinopsis = d.Sinopsis,
                               Género = d.Género,
                               TituloPelicula = d.TituloPelicula,

                               /////???????
                               //Calificacion=d.Calificacion,



                               //////////////////
                               ///POSTER???///////
                               ///
                           }).ToList();
            }
                return View(lst);
        }
    }
}