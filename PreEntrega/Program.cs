using ProyectoFinalCoderHouse;

namespace ProyectoFinalCoderHouse
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {

            ///ProductoHandler productoHandler = new ProductoHandler();
            ///
            ///Console.WriteLine("-------INGRESE EL ID DEL PRODUCTO DE USUARIO A MOSTRAR--------");
            ///Console.WriteLine("---------------------------PRODUCTO---------------------------");
            ///
            ///productoHandler.MostrarProductos();
            ///
            ///UsuarioHandler usuarioHandler = new UsuarioHandler();
            ///
            ///Console.WriteLine("------------INGRESE EL NOMBRE DE USUARIO A MOSTRAR------------");
            ///Console.WriteLine("---------------------------USUARIO---------------------------");
            ///
            ///usuarioHandler.MostrarUsuarios();


            ProductosVendidosHandler productosVendidosHandler = new ProductosVendidosHandler();

            productosVendidosHandler.MostrarProductosVendidos();
            UsuarioHandler usuarioHandler = new UsuarioHandler();
            usuarioHandler.ShowUserWithPassword();


        }


    } 

    
}