namespace GestionVentas
{
    internal class RegistroVentas
    {
        static void Main(string[] args)
        {
            // Matriz de ventas: 5 productos (filas) y 4 vendedores (columnas)
            decimal[,] ventas = new decimal[5, 4];

            // Ingreso de datos de ventas por cada vendedor y producto
            while (true)
            {
                Console.WriteLine("Ingrese el número del vendedor (1-4, o 0 para terminar): ");
                int idVendedor = int.Parse(Console.ReadLine());

                // Si el número de vendedor es 0, se finaliza el ingreso de datos
                if (idVendedor == 0)
                    break;

                // Validar que el vendedor esté en el rango de 1 a 4
                if (idVendedor < 1 || idVendedor > 4)
                {
                    Console.WriteLine("Número de vendedor inválido. Intente nuevamente.");
                    continue;
                }

                Console.WriteLine("Ingrese el número del producto (1-5): ");
                int idProducto = int.Parse(Console.ReadLine());

                // Validar que el producto esté en el rango de 1 a 5
                if (idProducto < 1 || idProducto > 5)
                {
                    Console.WriteLine("Número de producto inválido. Intente nuevamente.");
                    continue;
                }

                Console.WriteLine("Ingrese el monto de la venta en dólares: ");
                decimal montoVenta = decimal.Parse(Console.ReadLine());

                // Acumular la venta en la matriz correspondiente (ajustando índices)
                ventas[idProducto - 1, idVendedor - 1] += montoVenta;
            }

            // Mostrar el resumen de ventas
            Console.WriteLine("\nReporte de ventas del mes:");
            Console.WriteLine("Producto\tVendedor 1\tVendedor 2\tVendedor 3\tVendedor 4\tTotal por producto");

            // Variables para totales por vendedor y producto
            decimal[] acumuladoPorVendedor = new decimal[4];
            decimal totalProducto;

            // Recorrer la matriz para mostrar los datos por producto y vendedor
            for (int producto = 0; producto < 5; producto++)
            {
                totalProducto = 0;
                Console.Write($"Producto {producto + 1}\t");

                // Recorrer cada vendedor para el producto actual
                for (int vendedor = 0; vendedor < 4; vendedor++)
                {
                    Console.Write($"{ventas[producto, vendedor]:C}\t\t"); // Imprimir ventas por vendedor
                    totalProducto += ventas[producto, vendedor]; // Acumular ventas por producto
                    acumuladoPorVendedor[vendedor] += ventas[producto, vendedor]; // Acumular por vendedor
                }

                // Imprimir el total por producto
                Console.WriteLine($"{totalProducto:C}");
            }

            // Mostrar el total por vendedor
            Console.Write("Total por vendedor\t");
            decimal totalGlobal = 0;
            for (int vendedor = 0; vendedor < 4; vendedor++)
            {
                Console.Write($"{acumuladoPorVendedor[vendedor]:C}\t");
                totalGlobal += acumuladoPorVendedor[vendedor]; // Acumular el total global
            }

            // Mostrar el total general
            Console.WriteLine($"\nTotal general de ventas: {totalGlobal:C}");
        }
    }
}
