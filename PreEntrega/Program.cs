using ProyectoFinalCoderHouse;

namespace ProyectoFinalCoderHouse
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {

            UsuarioHandler usuarioHandler = new UsuarioHandler();

            usuarioHandler.GetUsuarios();
            usuarioHandler.MostrarUsuarios();
            
        }


    } 

    
}