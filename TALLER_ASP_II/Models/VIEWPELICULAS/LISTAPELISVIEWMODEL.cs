using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TALLER_ASP_II.Models.VIEWPELICULAS
{
    public class LISTAPELISVIEWMODEL
    {
        public int idPelicula { get; set; }
        public  string TituloPelicula { get; set; }
        public string Sinopsis { get; set; }
        public string Director { get; set; }
        public string Género { get; set; }
        public decimal Calificacion { get; set; }
        //que ondas con la imagen???? 
        //perdon
        ////public image Poster { get; set; }

    }
}