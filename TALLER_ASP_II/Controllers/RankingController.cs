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
            using (var db = new CinePlusEntities())
            {
                var data = db.Database.SqlQuery<Ranking_Result>("EXECUTE Ranking").ToList();
               ViewBag.BestPeli= data[0].TituloPelicula.ToString();
            }

            return View();
        }

        public ActionResult getImage()
        {
            using (var db = new CinePlusEntities())
            {
                var data = db.Database.SqlQuery<Ranking_Result>("EXECUTE Ranking").ToList();
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

    }
}