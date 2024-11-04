using Refuerzo2024.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refuerzo2024.Model.DAO
{
    internal class DAOEstudiantes : DTOEstudiantes
    {
        //Variable con la conexión
        SqlConnection con = obtenerConexion();

        public DataSet ObtenerEspecialidades()
        {
            try
            {
                //Se crea la instrucción de lo que se quiere hacer
                string query = "SELECT * FROM Especialidades";
                //Se crea el comando de tipo Sql que recibe la instrucción y la conexión
                SqlCommand cmd = new SqlCommand(query, con);
                //ExecuteNonQuery se utiliza para acciones como INSERT, UPDATE, DELETE
                //ExecuteScalar se utiliza para acciones como SELECT
                cmd.ExecuteScalar();
                //Toma los valores y los pone en una tabla generica
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //Se crea el objeto según el tipo de dato a retornar
                DataSet ds = new DataSet();
                //Se rellena el objeto a retornar con los datos de la tabla generica
                adp.Fill(ds, "Especialidades");
                //Se retorna el objeto
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool RegistrarEstudiante()
        {
            try
            {
                string query = "INSERT INTO Estudiantes VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7)";
                SqlCommand cmdInsert = new SqlCommand(query, con);
                cmdInsert.Parameters.AddWithValue("param1", NombreEstudiante);
                cmdInsert.Parameters.AddWithValue("param2", ApellidoEstudiante);
                cmdInsert.Parameters.AddWithValue("param3", FechaNacimiento);
                cmdInsert.Parameters.AddWithValue("param4", Telefono);
                cmdInsert.Parameters.AddWithValue("param5", Correo);
                cmdInsert.Parameters.AddWithValue("param6", Dui);
                cmdInsert.Parameters.AddWithValue("param7", IdEspecialidad);
                cmdInsert.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet ObtenerEstudiantes()
        {
            try
            {
                string query = "SELECT * FROM ViewEstudiante";
                SqlCommand cmdObtener = new SqlCommand(query, con);
                cmdObtener.ExecuteScalar();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmdObtener);
                adp.Fill(ds, "ViewEstudiante");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ActualizarEstudiante()
        {
            try
            {
                //Crea la instrucción de lo que se quiere hacer
                string query = "UPDATE Estudiantes SET nombreEstudiante = @nombreEstudiante, apellidoEstudiante = @apellidoEstudiante, fechaNacimiento  = @fechaNacimiento, telefono = @telefono, correo = @correo, dui = @dui, idEspecialidad = @idEspecialidad WHERE idEstudiante = @idEstudiante";
                //Crea el comando con la instrucción y la conexión
                SqlCommand cmdUpdate = new SqlCommand(query, con);
                cmdUpdate.Parameters.AddWithValue("nombreEstudiante", NombreEstudiante);
                cmdUpdate.Parameters.AddWithValue("apellidoEstudiante", ApellidoEstudiante);
                cmdUpdate.Parameters.AddWithValue("fechaNacimiento", FechaNacimiento);
                cmdUpdate.Parameters.AddWithValue("telefono", Telefono);
                cmdUpdate.Parameters.AddWithValue("correo", Correo);
                cmdUpdate.Parameters.AddWithValue("dui", Dui);
                cmdUpdate.Parameters.AddWithValue("idEspecialidad", IdEspecialidad);
                cmdUpdate.Parameters.AddWithValue("idEstudiante", IdEstudiante);
                //Ejecuta la instrucciones
                cmdUpdate.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { con.Close(); }
        }

        public bool EliminarEstudiante()
        {
            try
            {
                string query = "DELETE FROM Estudiantes WHERE idEstudiante = @param1";
                SqlCommand cmdDelete = new SqlCommand (query, con);
                cmdDelete.Parameters.AddWithValue("param1", IdEstudiante);
                cmdDelete.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet BuscarEstudiante(string valor)
        {
            try
            {
                string query = "SELECT * FROM ViewEstudiante WHERE nombreEstudiante LIKE @param1 OR idEstudiante LIKE @param2 OR dui LIKE @param3";
                SqlCommand cmdObtener = new SqlCommand(query, con);
                cmdObtener.Parameters.AddWithValue("param1", "%" + valor + "%");
                cmdObtener.Parameters.AddWithValue("param2", "%" + valor + "%");
                cmdObtener.Parameters.AddWithValue("param3", "%" + valor + "%");
                cmdObtener.ExecuteScalar();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmdObtener);
                adp.Fill(ds, "ViewEstudiante");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
