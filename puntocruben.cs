using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Comic : ArticuloTienda
{
    public int Volumen { get; set; }
    public bool EsVariante { get; set; }

    public Comic(int id, string nombre, double precioCosto, double precioVenta, int stock, int volumen, bool esVariante)
        : base(id, nombre, precioCosto, precioVenta, stock)
    {
        Volumen = volumen;
        EsVariante = esVariante;
    }

    public override double CalcularTotalVenta(int cantidadComprada)
    {
        double subtotal = PrecioVenta * cantidadComprada;
        if (EsVariante)
        {
            subtotal *= 1.20; // Aumenta un 20% por ser de colección
        }
        return subtotal;
    }

    public override void MostrarDetalles()
    {
        Console.WriteLine($"[Cómic] ID: {Id} | Nombre: {Nombre} | Vol: {Volumen} | Variante: {EsVariante} | Costo: ${PrecioCosto} | Venta: ${PrecioVenta} | Stock: {Stock}");
    }
}

public class Merchandising : ArticuloTienda
{
    public string Tipo { get; set; } // Ej. "Polera", "Taza"
    public string Talla { get; set; } // Ej. "L", "N/A"

    public Merchandising(int id, string nombre, double precioCosto, double precioVenta, int stock, string tipo, string talla)
        : base(id, nombre, precioCosto, precioVenta, stock)
    {
        Tipo = tipo;
        Talla = talla;
    }

    public override double CalcularTotalVenta(int cantidadComprada)
    {
        return PrecioVenta * cantidadComprada; // Sin modificaciones
    }

    public override void MostrarDetalles()
    {
        Console.WriteLine($"[Merchandising] ID: {Id} | Nombre: {Nombre} | Tipo: {Tipo} | Talla: {Talla} | Costo: ${PrecioCosto} | Venta: ${PrecioVenta} | Stock: {Stock}");
    }
}