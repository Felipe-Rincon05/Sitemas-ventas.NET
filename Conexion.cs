using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PROYECTO_WEB
{
    public class Conexion
    {
        private static SqlConnection conexion;
        private static string Error;

        public static SqlConnection GetConexion()
        {
            if (conexion != null)
                return conexion;
            conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source=(LocalDB)" +
                "\\MSSQLLocalDB; AttachDbFilename =|DataDirectory|" +
                "\\bases_ventas.mdf; Integrated Security = True; Connect Timeout = 30";
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception e)
            {
                Error = e.Message;
                return null;
            }
        }
        public static void CerrarConexion()
        {
            if (conexion != null)
                conexion.Close();
        }
    }
}