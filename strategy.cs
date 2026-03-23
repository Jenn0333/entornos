using System;

public interface ICosteEnvioStrategy
{
    double CalcularCoste(double precioProducto);
}

public class EnvioEstandarStrategy : ICosteEnvioStrategy
{
    public double CalcularCoste(double precioProducto) => 5.0;
}

public class EnvioExpressStrategy : ICosteEnvioStrategy
{
    public double CalcularCoste(double precioProducto) => 12.0;
}

public class EnvioInternacionalStrategy : ICosteEnvioStrategy
{
    public double CalcularCoste(double precioProducto) => precioProducto * 0.15;
}

public class RecogidaTiendaStrategy : ICosteEnvioStrategy
{
    public double CalcularCoste(double precioProducto) => 0.0;
}

public class Pedido
{
    public double PrecioProducto { get; set; }
    private ICosteEnvioStrategy _estrategia;

    public Pedido(double precio)
    {
        PrecioProducto = precio;
    }

    public void SetEstrategia(ICosteEnvioStrategy estrategia)
    {
        _estrategia = estrategia;
    }

    public void MostrarTotal()
    {
        if (_estrategia == null)
        {
            Console.WriteLine("Error: No se ha seleccionado un método de envío.");
            return;
        }

        double costeEnvio = _estrategia.CalcularCoste(PrecioProducto);
        double total = PrecioProducto + costeEnvio;

        Console.WriteLine($"Precio Producto: {PrecioProducto:C} | Coste Envío: {costeEnvio:C} | TOTAL: {total:C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pedido miPedido = new Pedido(100.0);

        Console.WriteLine("--- Sistema de Logística TransGlobal ---");

        miPedido.SetEstrategia(new EnvioEstandarStrategy());
        Console.Write("Envío Estándar: ");
        miPedido.MostrarTotal();

        miPedido.SetEstrategia(new EnvioInternacionalStrategy());
        Console.Write("Envío Internacional (15%): ");
        miPedido.MostrarTotal();

        miPedido.SetEstrategia(new RecogidaTiendaStrategy());
        Console.Write("Recogida en Tienda: ");
        miPedido.MostrarTotal();
        
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}