using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using WebService.datas;



namespace WebService.conexion
{
    public class Consultas
    {
        MySqlConnection conexion;
        MySqlDataAdapter adaptador = new MySqlDataAdapter();
        DataSet tablaS = new DataSet();
        DataTable tablaT = new DataTable();
        String cadena = "server=localhost;user id=root;persistsecurityinfo=True;database=alumnos; password=tesoem";

        public Consultas()
        {
            conexion = new MySqlConnection (cadena );
        }
        public DataSet TableS
        {
            get { return tablaS; }
        }
        public DataTable TablaT
        {
            get { return tablaT; }
        }
        public Boolean MostrarDataSet()
        {
            Boolean estado;
            try
            {
                conexion.Open();
                adaptador.SelectCommand = new MySqlCommand("select * from datos", conexion);
                adaptador.Fill(tablaS);
                estado = true;
            }
            catch ( MySqlException )
            {
                estado = false;
            }
            finally
            {
                conexion.Close();
            }
            return estado;
        }
        public Boolean MostrarDataTable()
        {
            Boolean estado;
            try
            {
                conexion.Open();
                adaptador.SelectCommand = new MySqlCommand("select * from datos", conexion);
                adaptador.Fill(tablaT);
                estado = true;
            }
            catch (MySqlException)
            {
                estado = false;
            }
            finally
            {
                conexion.Close();
            }
            return estado;
        }
        public Boolean InsertarDatos(Datos datos)
        {
            Boolean estado = true;
            try
            {
                adaptador.InsertCommand = new MySqlCommand("insert into datos values (@matricula, @nombre, @edad)", conexion);
                adaptador.InsertCommand.Parameters.Add("@matricula", MySqlDbType.Int32).Value = datos.Matricula;
                adaptador.InsertCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 100).Value = datos.Nombre;
                adaptador.InsertCommand.Parameters.Add("@edad", MySqlDbType.Int32).Value = datos.Edad;
                conexion.Open();
                adaptador.InsertCommand.Connection = conexion;
                adaptador.InsertCommand.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                estado = false;
            }
            finally
            {
                conexion.Close();
            }
            return estado;
        }
        public Boolean ActualizarDatos(Datos datos)
        {
            Boolean estado = true;
            try
            {
                adaptador.UpdateCommand = new MySqlCommand("update datos set nombre = @nombre, edad=@edad where matricula = @matricula", conexion);
                adaptador.UpdateCommand.Parameters.Add("@matricula", MySqlDbType.Int32).Value = datos.Matricula;
                adaptador.UpdateCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 100).Value = datos.Nombre;
                adaptador.UpdateCommand.Parameters.Add("@edad", MySqlDbType.Int32).Value = datos.Edad;
                conexion.Open();
                adaptador.UpdateCommand.Connection = conexion;
                adaptador.UpdateCommand.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                estado = false;
            }
            finally
            {
                conexion.Close();
            }
            return estado;
        }
        public Boolean EliminarDatos(int matricula)
        {
            Boolean estado = true;
            try
            {
                adaptador.DeleteCommand = new MySqlCommand("delete from datos where Matricula = @matricula", conexion);
                adaptador.DeleteCommand.Parameters.Add("@matricula", MySqlDbType.Int32).Value = matricula;
                conexion.Open();
                adaptador.DeleteCommand.Connection = conexion;
                adaptador.DeleteCommand.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                estado = false;
            }
            finally
            {
                conexion.Close();
            }
            return estado;
        }

    }
}