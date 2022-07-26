namespace DesafioEntregable
{
    class ProbarObjetos
    {
        static void Main(string[] args)
        {
        }
    }


    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string nombreUsuario;
        private string password;
        private string mail;
    }

    public class Producto
    {
        private int id;
        private string descripcion;
        private double costo;
        private double precioVenta;
        private int stock;
        private int idUsuario;

    }
    public class ProductoVendido
    {
        private int id;
        private string idProducto;
        private int stock;
        private int idVenta;

    }
    public class Venta
    {
        private int id;
        private string comentario;

    }


}