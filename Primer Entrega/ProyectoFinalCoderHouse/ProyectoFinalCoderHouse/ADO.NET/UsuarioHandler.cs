using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalCoderHouse
{
    public class UsuarioHandler : DBHandler
    {
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.id = Convert.ToInt32(dataReader["Id"]);
                                usuario.nombre = dataReader["Nombre"].ToString();
                                usuario.apellido = dataReader["Apellido"].ToString();
                                usuario.nombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.password = dataReader["Contraseña"].ToString();
                                usuario.mail = dataReader["Mail"].ToString();

                                usuarios.Add(usuario);
                            }
                        }

                    }
                    sqlConnection.Close();
                }
                return usuarios;
            }
        }
        public void GetUsuarioByPassword(string nombre, string contraseña)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection sqlConnection= new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();

                    sqlCommand.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @nombre AND Contraseña = @contraseña";
                    
                    sqlCommand.Parameters.AddWithValue("@nombre", nombre);
                    sqlCommand.Parameters.AddWithValue("@contraseña", contraseña);

                    SqlDataAdapter sqladapter = new SqlDataAdapter();
                    sqladapter.SelectCommand = sqlCommand;
                    
                }
            }
        }
        public void Delete(Usuario usuario)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM Usuario WHERE Id = @idUsuario";

                    SqlParameter parametro = new SqlParameter();
                    parametro.ParameterName = "idUsuario";
                    parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametro.Value = usuario.id;

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

        public void MostrarUsuarios()
        {
            Console.WriteLine("-------USUARIOS-------");

            foreach (Usuario usuario in GetUsuarios())
            {
                Console.WriteLine("ID = " + usuario.id);
                Console.WriteLine("NOMBRE= " + usuario.nombre);
                Console.WriteLine("APELLIDO = " + usuario.apellido);
                Console.WriteLine("NOMBRE USUARIO = " + usuario.nombreUsuario);
                Console.WriteLine("PASSWORD = " + usuario.password);
                Console.WriteLine("MAIL= " + usuario.mail);
            }
            Console.WriteLine("--------------------");
        }

    }
}
