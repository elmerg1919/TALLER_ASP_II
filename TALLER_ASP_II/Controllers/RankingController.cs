using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TALLER_ASP_II.Models;
using System.Data;

namespace TALLER_ASP_II.Controllers
{
    public class RankingController : Controller
    {
        // GET: Ranking
        public ActionResult Ranking()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ranking(DataTable ranks)
        {
            using (var l = new CinePlusEntities()) {
                var result = l.Peliculas.SqlQuery("SELECT TituloPelicula, Calificacion FROM Peliculas");

                foreach (Peliculas p in result)
                {
                    ranks.Rows.Add(p.TituloPelicula, p.Calificacion);
                }
            }
            return View();
        }

        public string ObtenerDatos(DataTable ranks) {
            using (var l = new CinePlusEntities())
            {
                var result = l.Peliculas.SqlQuery("SELECT TituloPelicula, Calificacion FROM Peliculas");

                foreach (Peliculas p in result)
                {
                    ranks.Rows.Add(p.TituloPelicula, p.Calificacion);
                }
            }
            string strDatos;
            strDatos = "[['Peliculas', 'Calificacion'],";
            foreach (DataRow dr in ranks.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";
            return strDatos;
        }
    }
}