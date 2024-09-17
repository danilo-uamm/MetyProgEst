namespace SistemaAsientos
{
    internal class GestionDeVuelos
    {
        // Método para mostrar el pase de abordaje
        static void MostrarPaseAbordaje(int numeroAsiento, int tipoSeccion)
        {
            if (tipoSeccion == 1)
                Console.WriteLine($"Su asiento es el #{numeroAsiento} en la sección de fumadores.");
            else
                Console.WriteLine($"Su asiento es el #{numeroAsiento} en la sección de no fumadores.");
        }

        // Método para asignar asiento en una determinada sección
        static int AsignarAsientoDisponible(int[] listaAsientos, int desde, int hasta)
        {
            for (int i = desde; i < hasta; i++)
            {
                if (listaAsientos[i] == 0) // Si el asiento está libre
                {
                    listaAsientos[i] = 1;   // Marcamos el asiento como ocupado
                    return i + 1;           // Retornamos el número del asiento asignado
                }
            }
            return -1; // No hay asientos disponibles en la sección
        }

        static void Main(string[] args)
        {
            int[] listaAsientos = new int[10];  // Arreglo que representa los asientos (0 libre, 1 ocupado)
            int eleccionUsuario, asientoReservado;

            while (true)
            {
                // Mostramos las opciones de secciones al pasajero
                Console.WriteLine("Seleccione 1 para la sección de 'fumadores'");
                Console.WriteLine("Seleccione 2 para la sección de 'no fumadores'");
                eleccionUsuario = int.Parse(Console.ReadLine());

                // Verificamos la elección del usuario
                if (eleccionUsuario == 1)
                {
                    // Intentamos asignar un asiento en la sección de fumadores (1 al 5)
                    asientoReservado = AsignarAsientoDisponible(listaAsientos, 0, 5);
                    if (asientoReservado != -1)
                    {
                        MostrarPaseAbordaje(asientoReservado, 1);
                    }
                    else
                    {
                        // Si la sección de fumadores está completa
                        Console.WriteLine("La sección de fumadores está llena. ¿Desea cambiar a la sección de no fumadores? (1 = sí, 0 = no): ");
                        int cambioSeccion = int.Parse(Console.ReadLine());
                        if (cambioSeccion == 1)
                        {
                            asientoReservado = AsignarAsientoDisponible(listaAsientos, 5, 10);
                            if (asientoReservado != -1)
                            {
                                MostrarPaseAbordaje(asientoReservado, 2);
                            }
                            else
                            {
                                Console.WriteLine("No hay asientos disponibles en ninguna sección. El próximo vuelo es en 3 horas.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El próximo vuelo es en 3 horas.");
                        }
                    }
                }
                else if (eleccionUsuario == 2)
                {
                    // Intentamos asignar un asiento en la sección de no fumadores (6 al 10)
                    asientoReservado = AsignarAsientoDisponible(listaAsientos, 5, 10);
                    if (asientoReservado != -1)
                    {
                        MostrarPaseAbordaje(asientoReservado, 2);
                    }
                    else
                    {
                        // Si la sección de no fumadores está completa
                        Console.WriteLine("La sección de no fumadores está llena. ¿Desea cambiar a la sección de fumadores? (1 = sí, 0 = no): ");
                        int cambioSeccion = int.Parse(Console.ReadLine());
                        if (cambioSeccion == 1)
                        {
                            asientoReservado = AsignarAsientoDisponible(listaAsientos, 0, 5);
                            if (asientoReservado != -1)
                            {
                                MostrarPaseAbordaje(asientoReservado, 1);
                            }
                            else
                            {
                                Console.WriteLine("No hay asientos disponibles en ninguna sección. El próximo vuelo es en 3 horas.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El próximo vuelo es en 3 horas.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Por favor, ingrese 1 o 2.");
                }

                // Verificamos si ya no quedan asientos disponibles
                bool todosAsientosOcupados = true;
                for (int i = 0; i < listaAsientos.Length; i++)
                {
                    if (listaAsientos[i] == 0)
                    {
                        todosAsientosOcupados = false;
                        break;
                    }
                }

                if (todosAsientosOcupados)
                {
                    Console.WriteLine("Todos los asientos están ocupados. El próximo vuelo es en 3 horas.");
                    break; // Salimos del ciclo ya que no quedan asientos disponibles
                }
            }
        }
    }
}
