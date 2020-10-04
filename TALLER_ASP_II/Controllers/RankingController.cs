using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TALLER_ASP_II.Models;
using System.Data;
using System.Web.Helpers;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace TALLER_ASP_II.Controllers
{
    public class RankingController : Controller
    {
        // GET: Ranking
        public ActionResult Ranking()
        {
            DataTable ranks = new DataTable();
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
            ViewBag.r = ranks;
            return View();
        }

        public ActionResult getImage()
        {
            using (var db = new CinePlusEntities())
            {
                var data = db.Database.SqlQuery<Ranking>("EXECUTE Ranking").ToList();
                var myChart = new Chart(width: 600, height: 400)
               .AddTitle("Mejores peliculas")
               .DataBindTable(dataSource: data, xField: "TituloPelicula")
               .Write();
                byte[] byteImage = myChart.GetBytes();
                MemoryStream memo = new MemoryStream(byteImage);
                Image image = Image.FromStream(memo);


                memo = new MemoryStream();
                image.Save(memo, ImageFormat.Jpeg);
                memo.Position = 0;
                return File(memo, "image/jpg");
            }
        }

        /*  public ActionResult ObtenerDatos(DataTable ranks) {
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
              ViewBag.strDatos="[";
              foreach (DataRow dr in ranks.Rows)
              {
                  strDatos = strDatos + "[";
                  strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                  strDatos = strDatos + "],";
              }
              strDatos = strDatos + "]";
              return View();
          }*/
    }
}