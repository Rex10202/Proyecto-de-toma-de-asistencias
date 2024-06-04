using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Asistencia.Logica;
using System.Windows.Forms;
using System.Data;

namespace Asistencia.Datos
{
    public class Dpersonal
    {
        public bool InsertarPersonal(Lpersonal parametros)
        {
			try
			{
				CONEXIONSQL.Abrir();
				SqlCommand cmd = new SqlCommand("InsertarPersonal",CONEXIONSQL.conectar);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
				cmd.Parameters.AddWithValue("@Identificacion", parametros.Identificacion);
				cmd.Parameters.AddWithValue("@Pais", parametros.Pais);
				cmd.Parameters.AddWithValue("@id_cargo", parametros.id_cargo);
				cmd.Parameters.AddWithValue("@SueldoPorHora", parametros.SueldoPorHora);
				cmd.ExecuteNonQuery();
				return true;
            }
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return false;
			}
			finally
			{
				CONEXIONSQL.Cerrar();
			}
        }

        public bool editarPersonal(Lpersonal parametros)
        {
            try
            {

                CONEXIONSQL.Abrir();
                SqlCommand cmd = new SqlCommand("editarPersonal", CONEXIONSQL.conectar);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_personal", parametros.Id_personal);
                cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                cmd.Parameters.AddWithValue("@Identificacion", parametros.Identificacion);
                cmd.Parameters.AddWithValue("@Pais", parametros.Pais);
                cmd.Parameters.AddWithValue("@id_cargo", parametros.id_cargo);
                cmd.Parameters.AddWithValue("@SueldoPorHora", parametros.SueldoPorHora);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CONEXIONSQL.Cerrar();
            }
        }

        public bool eliminarPersonal(Lpersonal parametros)
        {
            try
            {

                CONEXIONSQL.Abrir();
                SqlCommand cmd = new SqlCommand("eliminarPersonal", CONEXIONSQL.conectar);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_personal", parametros.Id_personal);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CONEXIONSQL.Cerrar();
            }
        }

        public void mostrarPersonal(ref DataTable dt, int desde,int hasta)
        {
            try
            {
                CONEXIONSQL.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarPersonal", CONEXIONSQL.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.Fill(dt);

            }
            catch (Exception e)
            {

                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                CONEXIONSQL.Cerrar();
            }
        }

        public void BuscarPersonal(ref DataTable dt, int desde, int hasta,string buscador)
        {
            try
            {
                CONEXIONSQL.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarPersonal", CONEXIONSQL.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                da.Fill(dt);

            }
            catch (Exception e)
            {

                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                CONEXIONSQL.Cerrar();
            }
        }

    }


}
