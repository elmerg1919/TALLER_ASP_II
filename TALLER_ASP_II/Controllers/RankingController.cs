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
                List<Ranking> result = l.Database.SqlQuery<Ranking>("EXECUTE Ranking").ToList();
                ranks.Columns.Add(new DataColumn("Películas", typeof(string)));
                ranks.Columns.Add(new DataColumn("Califación", typeof(int)));
                foreach (var item in result)
                {
                    ranks.Rows.Add(item.TituloPelicula, item.Calificacion);
                }
            }
            return View();
        }

        public ActionResult ObtenerDatos(DataTable ranks) {
            using (var l = new CinePlusEntities())
            {
                List<Ranking> result = l.Database.SqlQuery<Ranking>("EXECUTE Ranking").ToList();

                ranks.Columns.Add(new DataColumn("Películas", typeof(string)));
                ranks.Columns.Add(new DataColumn("Califación", typeof(int)));
                foreach (var item in result)
                {
                    ranks.Rows.Add(item.TituloPelicula, item.Calificacion);
                }
            }
            string strDatos;
            strDatos = "[";
            foreach (DataRow dr in ranks.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";
            return View(strDatos);
        }
    }
}