namespace AnalisisSalarios
{
    internal class EvaluaciónSalarios
    {
        static void Main(string[] args)
        {
            // Arreglo para contar los vendedores en diferentes rangos salariales
            int[] conteoRangos = new int[9];

            // Continuar capturando datos hasta que el usuario decida terminar
            while (true)
            {
                Console.WriteLine("Introduzca las ventas totales del vendedor (o -1 para terminar): ");
                decimal ventasTotales = decimal.Parse(Console.ReadLine());

                // Salir del bucle si se ingresa -1
                if (ventasTotales == -1)
                {
                    break;
                }

                // Calcular el salario: $200 más el 9% de las ventas totales
                decimal salarioCalculado = 200 + (ventasTotales * 0.09m);

                // Convertir el salario a entero
                int salarioFinal = (int)salarioCalculado;

                // Clasificar el salario en el rango correspondiente
                if (salarioFinal >= 200 && salarioFinal <= 299)
                    conteoRangos[0]++;
                else if (salarioFinal >= 300 && salarioFinal <= 399)
                    conteoRangos[1]++;
                else if (salarioFinal >= 400 && salarioFinal <= 499)
                    conteoRangos[2]++;
                else if (salarioFinal >= 500 && salarioFinal <= 599)
                    conteoRangos[3]++;
                else if (salarioFinal >= 600 && salarioFinal <= 699)
                    conteoRangos[4]++;
                else if (salarioFinal >= 700 && salarioFinal <= 799)
                    conteoRangos[5]++;
                else if (salarioFinal >= 800 && salarioFinal <= 899)
                    conteoRangos[6]++;
                else if (salarioFinal >= 900 && salarioFinal <= 999)
                    conteoRangos[7]++;
                else if (salarioFinal >= 1000)
                    conteoRangos[8]++;
            }

            // Mostrar los resultados
            Console.WriteLine("\nCantidad de vendedores en cada rango salarial:");
            Console.WriteLine($"$200 - $299: {conteoRangos[0]}");
            Console.WriteLine($"$300 - $399: {conteoRangos[1]}");
            Console.WriteLine($"$400 - $499: {conteoRangos[2]}");
            Console.WriteLine($"$500 - $599: {conteoRangos[3]}");
            Console.WriteLine($"$600 - $699: {conteoRangos[4]}");
            Console.WriteLine($"$700 - $799: {conteoRangos[5]}");
            Console.WriteLine($"$800 - $899: {conteoRangos[6]}");
            Console.WriteLine($"$900 - $999: {conteoRangos[7]}");
            Console.WriteLine($"$1000 o más: {conteoRangos[8]}");
        }
    }
}
