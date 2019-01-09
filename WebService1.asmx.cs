using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Services;
using WebService.conexion;
using WebService.datas;
using System.Data;

namespace WebService
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet MostrarDatos()
        {
            Consultas con = new Consultas();
            if (con.MostrarDataSet())
            {
                return con.TableS;
            }
            else
            {
                return null;
            }
        }
        [WebMethod]
        public Boolean InsertarDatos(int matricula, String nombre, int edad)
        {
            Consultas con = new Consultas();
            Datos dat = new Datos();
            dat.Matricula = matricula;
            dat.Nombre = nombre;
            dat.Edad = edad;

            if (con.InsertarDatos(dat))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        [WebMethod]
        public Boolean ActualizarDatos(int matricula, String nombre, int edad)
        {
            Consultas con = new Consultas();
            Datos dat = new Datos();
            dat.Matricula = matricula;
            dat.Nombre = nombre;
            dat.Edad = edad;

            if (con.ActualizarDatos(dat))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public Boolean EliminarDatos(int matricula)
        {
            Consultas con = new Consultas();
            Datos dat = new Datos();
            dat.Matricula = matricula;

            if (con.EliminarDatos(matricula))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
