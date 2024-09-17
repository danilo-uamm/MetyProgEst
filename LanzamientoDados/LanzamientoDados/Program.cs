namespace LanzamientoDados
{
    internal class SimuladorDados
    {
        static void Main(string[] args)
        {
            // Creamos un generador de números aleatorios
            Random rng = new Random();

            // Arreglo para contar la frecuencia de cada suma (de 2 a 12)
            int[] contadorFrecuencias = new int[11];

            // Definimos el número total de lanzamientos de dados
            int numeroDeTiradas = 36000;

            for (int i = 0; i < numeroDeTiradas; i++)
            {
                // Simulamos los valores de dos dados
                int dado1 = rng.Next(1, 7); // Genera un número entre 1 y 6
                int dado2 = rng.Next(1, 7);

                // Calculamos la suma de los dos dados
                int resultado = dado1 + dado2;

                // Actualizamos el contador en la posición correspondiente a la suma
                contadorFrecuencias[resultado - 2]++;
            }

            // Mostramos los resultados en una tabla
            Console.WriteLine("Suma\tOcurrencias");
            for (int suma = 2; suma <= 12; suma++)
            {
                Console.WriteLine($"{suma}\t{contadorFrecuencias[suma - 2]}");
            }

            // Calculamos el porcentaje de veces que la suma fue 7
            double probabilidadSiete = (double)contadorFrecuencias[7 - 2] / numeroDeTiradas;
            Console.WriteLine($"\nEl {(probabilidadSiete * 100):F2}% de las veces la suma fue 7.");
        }
    }
}
