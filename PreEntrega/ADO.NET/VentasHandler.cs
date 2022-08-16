using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalCoderHouse
{
    public class VentasHandler : DBHandler
    {
        public List<Venta> GetVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM VENTA", sqlConnection))
                {   
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.id = Convert.ToInt32(dataReader["Id"]);
                                venta.comentario = dataReader["Comentarios"].ToString();

                                ventas.Add(venta);
                            }
                        }

                    }
                    sqlConnection.Close();
                }
                return ventas;
            }
        }

        public void Delete(Venta venta)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM Venta WHERE Id = @id";

                    SqlParameter parametro = new SqlParameter();
                    parametro.ParameterName = "id";
                    parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametro.Value = venta.id;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametro);
                        sqlCommand.ExecuteNonQuery(); /// se ejecuta el delete
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MostrarVentas()
        {
            Console.WriteLine("-------VENTAS-------");


            foreach (Venta venta in GetVentas())
            {
                Console.WriteLine("ID = " + venta.id);
                Console.WriteLine("COMENTARIO= " + venta.comentario);

            }
            Console.WriteLine("--------------------");
        }

    }
}
