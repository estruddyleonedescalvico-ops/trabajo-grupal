public abstract class ArticuloTienda : IComercializable
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public double PrecioCosto { get; set; }
    public double PrecioVenta { get; set; }
    public int Stock { get; set; }

    protected ArticuloTienda(int id, string nombre, double precioCosto, double precioVenta, int stock)
    {
        Id = id;
        Nombre = nombre;
        PrecioCosto = precioCosto;
        PrecioVenta = precioVenta;
        Stock = stock;
    }

    public abstract void MostrarDetalles();

    public abstract double CalcularTotalVenta(int cantidadComprada);
}