using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refuerzo2024.Model.Conexion
{
    internal class dbContext
    {
        /// <summary>
        /// 1. ** ENCAPSULAMIENTO
        /// public = puede ser utilizado desde cualquier parte del proyecto
        /// private = puede ser utilizado unicamente por la clase donde esta contenido
        /// protected = puede ser utilizado en la clase que lo contiene y sus clases hijas
        /// 
        /// 2. ** ESTATICO / NO ESTATICO
        /// static = utilizar la clase para invocar
        /// no static = utilizar un objeto para invocar
        /// 
        /// 3. ** RETORNO
        /// Que tipo de dato se espera que retorne el metodo
        /// /// ** VOID
        /// Se utiliza cuando el método no retornará algo
        /// 
        /// 4. ** NOMBRE DEL METODO
        /// </summary>
        /// <returns></returns>
        public static SqlConnection obtenerConexion()
        {
            //Valores que tendrá la conexión
            string server = "sql5111.site4now.net";
            string database = "db_aae962_devjosueguinea";
            string user = "db_aae962_devjosueguinea_admin";
            string password = "Josue12345";

            //Intentamos establecer una conexión con la base de datos
            try
            {
                //Se crea un objeto conexión con los valores definidos en las variables
                SqlConnection conn = new SqlConnection($"Server = {server}; Database = {database}; User Id = {user}; Password = {password}");
                //Se intenta abrir una conexión, si en caso los valores son correctos se abre la conexión, caso contrario algún valor esta erróneo devuelve nulo.
                conn.Open();
                //En caso establezca la conexión se retornará una conexión exitosa
                return conn;
            }
            catch (Exception)
            {
                //En caso no se establezca la conexión se retornará una conexión nula
                return null;
            }
        }
    }
}
