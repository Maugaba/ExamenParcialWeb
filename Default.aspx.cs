using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenParcialWeb
{
    public partial class _Default : Page
    {
        List<Jugadores> jugadores = new List<Jugadores>();
        List<Goles> goles = new List<Goles>();
        protected void Page_Load(object sender, EventArgs e)
        {
            LeerJugadores();
            LeerGoles();
            foreach (var a in jugadores)
            {
                ListBoxjuga.Items.Add(a.Nombre);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (var a in jugadores)
            {
                if (a.Nombre == ListBoxjuga.Text)
                {
                    Goles gol = new Goles();
                    gol.identificacion = a.Identificacion;
                    gol.fecha = Calendar1.SelectedDate;
                    gol.Nombre_equipo_que_anoto = TextBoxnombreequipo.Text;
                    gol.Goles_anotados = Convert.ToInt32(TextBoxgolesanotados.Text);
                    goles.Add(gol);
                }
            }
            Guardar(Server.MapPath("~/Goles.txt"));
            TextBoxnombreequipo.Text = "";
            TextBoxgolesanotados.Text = "";

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
        void Guardar(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var a in goles)
            {
                writer.WriteLine(a.identificacion);
                writer.WriteLine(a.fecha);
                writer.WriteLine(a.Nombre_equipo_que_anoto);
                writer.WriteLine(a.Goles_anotados);
            }

            writer.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}