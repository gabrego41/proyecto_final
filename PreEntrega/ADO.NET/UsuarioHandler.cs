using ProyectoFinalCoderHouse.MODELO;
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
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario", sqlConnection))
                {
                    string nombreUsuario = null;
                    nombreUsuario=Console.ReadLine();

                    sqlConnection.Open();

                    SqlParameter parametro = new SqlParameter();

                    parametro.ParameterName = "nombreUsuario";
                    parametro.Value = nombreUsuario;

                    sqlCommand.Parameters.Add(parametro);

                    if (parametro.Value != null)
                    {
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
                            
                    }
                    else
                    {
                        Console.WriteLine("USUARIO NO ENCONTRADO");
                        Console.WriteLine("PROGRAMA TERMINADO");
                    }

                    sqlConnection.Close();
                }
                return usuarios;
            }
        }
        public List<Usuario> GetUserWithPassword()
        {
            List<Usuario> usuariosPasswords = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña", sqlConnection))
                {
                    string nombreUsuario = null;
                    string contraseña = null;

                    Console.WriteLine("Ingrese el Usuario");

                    nombreUsuario = Console.ReadLine();

                    Console.WriteLine("Ingrese la contraseña");

                    contraseña = Console.ReadLine();

                    sqlConnection.Open();

                    SqlParameter parametro = new SqlParameter();
                    SqlParameter password = new SqlParameter();

                    parametro.ParameterName = "nombreUsuario";
                    parametro.Value = nombreUsuario;
                    sqlCommand.Parameters.Add(parametro);

                    password.ParameterName = "contraseña";
                    password.Value = contraseña;
                    sqlCommand.Parameters.Add(password);

                    if (parametro.Value != null)
                    {
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Usuario usuarioPassword = new Usuario();

                                    usuarioPassword.id = Convert.ToInt32(dataReader["Id"]);
                                    usuarioPassword.nombre = dataReader["Nombre"].ToString();
                                    usuarioPassword.apellido = dataReader["Apellido"].ToString();
                                    usuarioPassword.nombreUsuario = dataReader["NombreUsuario"].ToString();
                                    usuarioPassword.password = dataReader["Contraseña"].ToString();
                                    usuarioPassword.mail = dataReader["Mail"].ToString();

                                    usuariosPasswords.Add(usuarioPassword);

                                    if ( usuarioPassword.password == contraseña)
                                    {
                                        Console.WriteLine("--------------------BIENVENIDO AL SISTEMA---------------------");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("---------------USUARIO O CONTRASEÑA INCORRECTOS---------------");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("---------------USUARIO O CONTRASEÑA INCORRECTOS---------------");
                    }

                    sqlConnection.Close();
                }
                return usuariosPasswords;
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
            foreach (Usuario usuario in GetUsuarios())
            {
                Console.WriteLine("ID = " + usuario.id);
                Console.WriteLine("NOMBRE= " + usuario.nombre);
                Console.WriteLine("APELLIDO = " + usuario.apellido);
                Console.WriteLine("NOMBRE USUARIO = " + usuario.nombreUsuario);
                Console.WriteLine("PASSWORD = " + usuario.password);
                Console.WriteLine("MAIL= " + usuario.mail);
            }
            Console.WriteLine("--------------------------------------------------------------");
        }

        public void ShowUserWithPassword()
        {
            Console.WriteLine("---------------INGRESE USUARIO Y LA CONTRASEÑA---------------");
            foreach (Usuario usuarioPassword in GetUserWithPassword())
            {
                Console.WriteLine("ID = " + usuarioPassword.id);
                Console.WriteLine("NOMBRE= " + usuarioPassword.nombre);
                Console.WriteLine("APELLIDO = " + usuarioPassword.apellido);
                Console.WriteLine("NOMBRE USUARIO = " + usuarioPassword.nombreUsuario);
                Console.WriteLine("MAIL= " + usuarioPassword.mail);
            }
            Console.WriteLine("--------------------------------------------------------------");
        }
    }
}
