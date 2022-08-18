using ProyectoFinalCoderHouse.MODELO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalCoderHouse
{
    public class ProductosVendidosHandler : DBHandler
    {
        public List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> productosvendidos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM ProductoVendido WHERE IdProducto = @idProducto ", sqlConnection))
                {
                    Console.WriteLine("POR FAVOR VUELVA A INGRESAR EL ID DEL PRODUCTO");  
                    
                    int idProducto = 0;
                    idProducto = Convert.ToInt32(Console.ReadLine());   
                    
                    sqlConnection.Open();

                    SqlParameter parametro = new SqlParameter();

                    parametro.ParameterName = "idProducto";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = idProducto;

                    sqlCommand.Parameters.Add(parametro);

                    if (idProducto != 0 )
                    {
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    ProductoVendido productovendido = new ProductoVendido();

                                    productovendido.id = Convert.ToInt32(dataReader["Id"]);
                                    productovendido.stock = Convert.ToInt32(dataReader["Stock"]);
                                    productovendido.idproducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    productovendido.idventa = Convert.ToInt32(dataReader["IdVenta"]);

                                    productosvendidos.Add(productovendido);
                                }
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("EL PRODUCTO NO SE ENCUENTRA");
                    }
                    sqlConnection.Close();
                }
                return productosvendidos;
            }
        }

        public void Delete(ProductoVendido productoVendido)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM ProdutoVendido WHERE Id = @idProducto";

                    SqlParameter parametro = new SqlParameter();
                    parametro.ParameterName = "idProducto";
                    parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametro.Value = productoVendido.idproducto;

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

        public void MostrarProductosVendidos()
        {

            foreach (ProductoVendido productovendido in GetProductosVendidos())
            {

                Console.WriteLine("ID = " + productovendido.id);
                Console.WriteLine("Descripcion= " + productovendido.stock);
                Console.WriteLine("Stock = " + productovendido.idproducto);
                Console.WriteLine("IDUsuario = " + productovendido.idventa);

            }
            Console.WriteLine("--------------------------------------------------------------");
        }



    }
}
