using ProyectoFinalCoderHouse.MODELO;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinalCoderHouse
{
    public class ProductoHandler : DBHandler
    {
        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto WHERE ID= @idProducto", sqlConnection))
                {
                    int idProducto = 0;
                    idProducto = Convert.ToInt32(Console.ReadLine());

                    sqlConnection.Open();


                    SqlParameter parametro = new SqlParameter();

                    parametro.ParameterName = "idProducto";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = idProducto;

                    sqlCommand.Parameters.Add(parametro);


                    if (idProducto != 0)
                    {

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Producto producto = new Producto();

                                    producto.id = Convert.ToInt32(dataReader["Id"]);
                                    producto.descripcion = dataReader["Descripciones"].ToString();
                                    producto.stock = Convert.ToInt32(dataReader["Stock"]);
                                    producto.idUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                    producto.costo = Convert.ToInt32(dataReader["Costo"]);
                                    producto.precioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);

                                    productos.Add(producto);
                                }
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("EL PRODUCTO NO SE ENCUENTRA");
                        Console.WriteLine("REINCIE EL PROGRAMA");

                    }
                    sqlConnection.Close();
                }
                return productos;
            }
        }

        public void MostrarProductos()
        {

            foreach (Producto producto in GetProductos())
            {

                Console.WriteLine("ID = " + producto.id);
                Console.WriteLine("Descripcion= " + producto.descripcion);
                Console.WriteLine("Stock = " + producto.stock);
                Console.WriteLine("IDUsuario = " + producto.idUsuario);
                Console.WriteLine("Costo = " + producto.costo);
                Console.WriteLine("Precio De Venta = " + producto.precioVenta);


            }
            Console.WriteLine("--------------------------------------------------------------");
        }
    }
}



            ///public void GetProductosID()
            ///{
            ///    List<Producto> productos = new List<Producto>();
            ///    using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            ///    {
            ///        using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PRODUCTO WHERE Id = @idProducto", sqlConnection))
            ///        {
            ///            int idProducto = 3;
            ///            sqlConnection.Open();
            ///
            ///            SqlParameter parametro = new SqlParameter();
            ///
            ///            parametro.ParameterName = "idProducto";
            ///            parametro.SqlDbType = System.Data.SqlDbType.Int;
            ///            parametro.Value = idProducto;
            ///
            ///            sqlCommand.Parameters.Add(parametro);
            ///
            ///
            ///            sqlConnection.Close();
            ///
            ///
            ///        }
            ///    }
            ///}
//                    sqlCommand.Connection = sqlConnection;
//                    sqlCommand.CommandText = @"SELECT * FROM PRODUCTO WHERE Id = @idProducto", sqlConnection;
//
//                    sqlCommand.Parameters.AddWithValue("@id", id);
//
//
//                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
//
//
//
//
//                    dataAdapter.SelectCommand = sqlCommand;
//                    DataTable table = new DataTable();
//                    dataAdapter.Fill(table); // se ejecuta el select
//
//                    foreach (DataRow row in table.Rows)
//                    {
//                        Producto producto = new Producto();
//                        producto.id = Convert.ToInt32(row["Id"]);
//                        producto.descripcion = row["Descripciones"].ToString();
//                        producto.costo = Convert.ToDouble(row["Costo"]);
//                        producto.precioVenta = Convert.ToDouble(row["PrecioVenta"]);
//                        producto.stock = Convert.ToInt32(row["Stock"]);
//                        producto.idUsuario = Convert.ToInt32(row["IdUsuario"]);
//
//                        productos.Add(producto);
//                    }
//
//                }
//            }
//            return productos;
//        }
//    }
//
//}


 ///       public void MostrarProductos()
 ///       {
 ///           Console.WriteLine("-------PRODUCTOS-------");
 ///
 ///           foreach (Producto producto in GetProductosID())
 ///           {
 ///
 ///               Console.WriteLine("ID = " + producto.id);
 ///               Console.WriteLine("Descripcion= " + producto.descripcion);
 ///               Console.WriteLine("Stock = " + producto.stock);
 ///               Console.WriteLine("IDUsuario = " + producto.idUsuario);
 ///               Console.WriteLine("Costo = " + producto.costo);
 ///               Console.WriteLine("Precio De Venta = " + producto.precioVenta);
 ///
 ///
 ///           }
 ///           Console.WriteLine("--------------------");
 ///       }


///        public void Delete(Producto producto)
///        {
///            try
///            {
///                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
///                {
///                    string queryDelete = "DELETE FROM Producto WHERE Id = @id";
///
///                    SqlParameter parametro = new SqlParameter();
///                    parametro.ParameterName = "id";
///                    parametro.SqlDbType = System.Data.SqlDbType.BigInt;
///                    parametro.Value = producto.id;
///
///                    sqlConnection.Open();
///
///                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
///                    {
///                        sqlCommand.Parameters.Add(parametro);
///                        sqlCommand.ExecuteNonQuery(); /// se ejecuta el delete
///                    }
///
///                    sqlConnection.Close();
///                }
///            }
///            catch (Exception ex)
///            {
///                Console.WriteLine(ex.Message);
///            }
///        }




 ///       public List<Producto> GetProductos()
 ///       {
 ///           List<Producto> productos = new List<Producto>();
 ///           using (SqlConnection sqlConnection = new(ConnectionString))
 ///           {
 ///               using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlConnection))
 ///               {
 ///                   sqlConnection.Open();
 ///
 ///                   using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
 ///                   {
 ///                       if (dataReader.HasRows)
 ///                       {
 ///                           while (dataReader.Read())
 ///                           {
 ///                               Producto producto = new Producto();
 ///
 ///                               producto.id = Convert.ToInt32(dataReader["Id"]);
 ///                               producto.descripcion = dataReader["Descripciones"].ToString();
 ///                               producto.stock = Convert.ToInt32(dataReader["Stock"]);
 ///                               producto.idUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
 ///                               producto.costo = Convert.ToInt32(dataReader["Costo"]);
 ///                               producto.precioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
 ///
 ///                               productos.Add(producto);
 ///                           }
 ///                       }
 ///
 ///                   }
 ///                   sqlConnection.Close();
 ///               }
 ///               return productos;
 ///           }
 ///       }








///Console.WriteLine("--PRODUCTOS--");
///foreach (Producto producto in productos)
///{
///    Console.WriteLine("ID = " + producto.id);
///    Console.WriteLine("Descripciones = " + producto.descripcion);
///    Console.WriteLine("Stock = " + producto.stock);
///    Console.WriteLine("IDUsuario = " + producto.idUsuario);
///    Console.WriteLine("Costo = " + producto.costo);
///    Console.WriteLine("Precio De Venta = " + producto.precioVenta);
///}
///Console.WriteLine("---------");




///public void AbrirYCerrarConexion()
///{
///    using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
///    {
///        using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto Where Id = @idProducto", sqlConnection))
///        {
///            int IdProducto = 3;
///
///            sqlConnection.Open();
///
///            SqlParameter parametro = new SqlParameter();
///
///            parametro.ParameterName = "IdProducto";
///            parametro.SqlDbType = System.Data.SqlDbType.Int;
///            parametro.Value = IdProducto;
///
///            sqlCommand.Parameters.Add(parametro);
///
///
///            sqlConnection.Close();
///
///        }
///
///    }
///}
