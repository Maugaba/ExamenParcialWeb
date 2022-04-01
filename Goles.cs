using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenParcialWeb
{
    public class Goles
    {
        public string identificacion { get; set; }
        public DateTime fecha { get; set; }
        public string Nombre_equipo_que_anoto { get; set; }
        public int Goles_anotados { get; set; }
    }
}