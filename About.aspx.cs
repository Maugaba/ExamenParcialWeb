using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenParcialWeb
{
    public partial class About : Page
    {
        List<Jugadores> jugadores = new List<Jugadores>();
        List<Goles> goles = new List<Goles>();
        List<Estadisiticas> estadisticas = new List<Estadisiticas>();
        List<Estadisiticas> estadisticasorden = new List<Estadisiticas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            LeerJugadores();
            LeerGoles();
            foreach (var a in jugadores)
            {
                foreach (var b in goles)
                {
                    if (b.identificacion == a.Identificacion)
                    {
                        Estadisiticas jug = new Estadisiticas();
                        jug.Nombre = a.Nombre;
                        jug.Goles = b.Goles_anotados;
                        estadisticas.Add(jug);
                    }
                }
            }
            GridView1.DataSource = estadisticas;
            GridView1.DataBind();
        }
        void LeerJugadores()
        {
            FileStream stream = new FileStream(Server.MapPath("~/Jugadores.txt"), FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Jugadores jug = new Jugadores();
                jug.Identificacion = reader.ReadLine();
                jug.Nombre = reader.ReadLine();
                jug.Equipo_al_que_pertenece = reader.ReadLine();
                jugadores.Add(jug);
            }

            reader.Close();
        }
        void LeerGoles()
        {
            FileStream stream = new FileStream(Server.MapPath("~/Goles.txt"), FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Goles g = new Goles();
                g.identificacion = reader.ReadLine();
                g.fecha = Convert.ToDateTime(reader.ReadLine());
                g.Nombre_equipo_que_anoto = reader.ReadLine();
                g.Goles_anotados = Convert.ToInt32(reader.ReadLine());
                goles.Add(g);
            }

            reader.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            estadisticasorden = estadisticas.OrderByDescending(p => p.Goles).ToList();
            GridView1.DataSource = estadisticasorden;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = estadisticas;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int b;
            int c = 0;
            int cont = 0;
            foreach (var a in estadisticas)
            {
                b = a.Goles;
                c = c + b;
                cont++;
            }

            decimal promedio = Convert.ToDecimal(c / cont);
            Label1.Text = "Promedio de goles:" + promedio;
        }
    }
}