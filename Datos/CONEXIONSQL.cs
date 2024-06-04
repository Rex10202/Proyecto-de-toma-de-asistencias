using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Datos
{
    public class CONEXIONSQL
    {
        public static string conexion = @"Data source = DESKTOP-MFQC9Q3\SQLEXPRESS; initial Catalog=Asistencias365; Integrated Security = false";
        public static SqlConnection conectar = new SqlConnection(conexion);
        public static void Abrir()
        {
            if(conectar.State == System.Data.ConnectionState.Closed)
            {
                conectar.Open();
            }
        }
        public static void Cerrar()
        {
            if (conectar.State == System.Data.ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
