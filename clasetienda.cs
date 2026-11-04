using System;
using System.Collections.Generic;

namespace GeekStoreApp
{
    public class Tienda
    {
        private List<ArticuloTienda> inventario;

        public double SaldoCaja { get; set; }

        public Tienda()
        {
            inventario = new List<ArticuloTienda>();
            SaldoCaja = 1000.0;
        }

        public void AgregarAlInventario(
            ArticuloTienda nuevoArticulo,
            int cantidadAComprar)
        {
            if (nuevoArticulo == null || cantidadAComprar <= 0)
            {
                Console.WriteLine("\nError: Datos inválidos.");
                return;
            }

            if (nuevoArticulo.PrecioCosto < 0 ||
                nuevoArticulo.PrecioVenta < 0)
            {
                Console.WriteLine("\nError: Precio inválido.");
                return;
            }

            double costoTotal =
                nuevoArticulo.PrecioCosto * cantidadAComprar;

            if (SaldoCaja < costoTotal)
            {
                Console.WriteLine("\nError: Saldo insuficiente en caja.");
                return;
            }

            foreach (ArticuloTienda articulo in inventario)
            {
                if (articulo.Id == nuevoArticulo.Id)
                {
                    Console.WriteLine("\nError: El ID ya existe.");
                    return;
                }
            }

            nuevoArticulo.Stock = cantidadAComprar;
            inventario.Add(nuevoArticulo);
            SaldoCaja -= costoTotal;

            Console.WriteLine("\nArtículo agregado exitosamente.");
        }

        public void MostrarInventario()
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("          INVENTARIO GEEK STORE");
            Console.WriteLine("========================================");

            if (inventario.Count == 0)
            {
                Console.WriteLine("El inventario está vacío.");
            }
            else
            {
                foreach (ArticuloTienda articulo in inventario)
                {
                    articulo.MostrarDetalles();
                }
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Saldo Actual en Caja: ${SaldoCaja:F2}");
            Console.WriteLine("========================================");
        }

        public void VenderArticulo(
            int idArticulo,
            int cantidadAVender)
        {
            if (cantidadAVender <= 0)
            {
                Console.WriteLine("\nError: Cantidad inválida.");
                return;
            }

            ArticuloTienda articuloEncontrado = null;

            foreach (ArticuloTienda articulo in inventario)
            {
                if (articulo.Id == idArticulo)
                {
                    articuloEncontrado = articulo;
                    break;
                }
            }

            if (articuloEncontrado == null)
            {
                Console.WriteLine("\nError: Artículo no encontrado.");
                return;
            }

            if (articuloEncontrado.Stock < cantidadAVender)
            {
                Console.WriteLine("\nError: Stock insuficiente.");
                return;
            }

            double totalVenta =
                articuloEncontrado.CalcularTotalVenta(cantidadAVender);

            articuloEncontrado.Stock -= cantidadAVender;
            SaldoCaja += totalVenta;

            Console.WriteLine("\n========== RECIBO DE VENTA ==========");
            Console.WriteLine($"Artículo: {articuloEncontrado.Nombre}");
            Console.WriteLine($"Cantidad vendida: {cantidadAVender}");
            Console.WriteLine($"Total cobrado: ${totalVenta:F2}");
            Console.WriteLine($"Nuevo saldo en caja: ${SaldoCaja:F2}");
            Console.WriteLine("=====================================");
        }
    }
}