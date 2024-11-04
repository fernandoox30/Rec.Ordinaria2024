using Refuerzo2024.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Refuerzo2024.Model.DAO
{
    internal class DAOAsignatura : DTOAsignatura
    {
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


        public bool RegistrarAsignatura()
        {
            try
            {
                string query = "INSERT INTO Asignaturas VALUES (@param1, @param2, @param3, @param4)";
                SqlCommand cmdInsert = new SqlCommand(query, con);
                cmdInsert.Parameters.AddWithValue("param1", NombreAsignaturas);
                cmdInsert.Parameters.AddWithValue("param2", CodigoAsignatura);
                cmdInsert.Parameters.AddWithValue("param3", Facultad1);
                cmdInsert.Parameters.AddWithValue("param4", IdEspecilidad);
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


        public DataSet ObtenerAsignatura()
        {
            try
            {
                string query = "SELECT * FROM Asignaturas";
                SqlCommand cmdObtener = new SqlCommand(query, con);
                cmdObtener.ExecuteScalar();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmdObtener);
                adp.Fill(ds, "ViewAsignatura");
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


        public bool ActualizarAsignatura()
        {
            try
            {
                //Crea la instrucción de lo que se quiere hacer
                string query = "UPDATE Asignaturas SET NombreAsignaturas = @nombreAsignaturas, CodigoAsignatura = @CodigoAsignatura, Facultad1  = @Facultad1,idEspecialidad = @idEspecialidad WHERE idEstudiante = @idEstudiante";
                //Crea el comando con la instrucción y la conexión
                SqlCommand cmdUpdate = new SqlCommand(query, con);
                cmdUpdate.Parameters.AddWithValue("nombreEstudiante", NombreAsignaturas);
                cmdUpdate.Parameters.AddWithValue("apellidoEstudiante",CodigoAsignatura);
                cmdUpdate.Parameters.AddWithValue("fechaNacimiento", Facultad1);
                cmdUpdate.Parameters.AddWithValue("idEspecialidad", IdEspecilidad);

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


        public bool EliminarAsignatura()
        {
            try
            {
                string query = "DELETE FROM Asignaturas WHERE idAsignatura = @param1";
                SqlCommand cmdDelete = new SqlCommand(query, con);
                cmdDelete.Parameters.AddWithValue("param1", IdAsignaturas);
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



        public DataSet BuscarAsignatura(string valor)
        {
            try
            {
                string query = "SELECT * FROM ViewAsignatura WHERE nombreAsignatura LIKE @param1 OR idAsignatura LIKE @param2 OR CodigoAsignatura LIKE @param3";
                SqlCommand cmdObtener = new SqlCommand(query, con);
                cmdObtener.Parameters.AddWithValue("param1", "%" + valor + "%");
                cmdObtener.Parameters.AddWithValue("param2", "%" + valor + "%");
                cmdObtener.Parameters.AddWithValue("param3", "%" + valor + "%");
                cmdObtener.ExecuteScalar();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmdObtener);
                adp.Fill(ds, "ViewAsignatura");
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
