using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seman3ejemplo1 { 

    internal class Program
    {
        static void Main(string[] args)
        {
            int dinero = 50;
            Granja granja = new Granja();

            // Lista de semillas disponibles
            List<Planta> semillasDisponibles = new List<Planta>()
            {
                new Planta("Tomate", 3, 5, 5, 3),
                new Planta("Papa", 4, 4, 6, 4),
                new Planta("Maíz", 5, 6, 8, 5)
            };

            while (true)
            {
                Console.WriteLine("--- JUEGO DE GRANJA ---");
                Console.WriteLine($"Dinero: {dinero}");
                Console.WriteLine("1. Comprar semilla y plantar");
                Console.WriteLine("2. Expandir granja");
                Console.WriteLine("3. Pasar turno");
                Console.WriteLine("4. Ver granja");
                Console.WriteLine("5. Cosechar plantas");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Semillas disponibles");
                        for (int i = 0; i < semillasDisponibles.Count; i++)
                        {
                            var s = semillasDisponibles[i];
                            Console.WriteLine($"{i + 1}.{s.Nombre}-Precio:{s.ValorSemilla}");
                        }
                        Console.Write("Elige una semilla:");
                        int eleccion;
                        if (int.TryParse(Console.ReadLine(), out eleccion) &&
                            eleccion > 0 && eleccion <= semillasDisponibles.Count)
                        {
                            var semilla = semillasDisponibles[eleccion - 1];
                            if (dinero >= semilla.ValorSemilla && granja.Plantas.Count < granja.Espacios)
                            {
                                dinero -= semilla.ValorSemilla;
                                granja.Plantas.Add(new Planta(semilla.Nombre, semilla.TiempoDeVida, semilla.Frutos, semilla.ValorSemilla, semilla.ValorProducto));
                                Console.WriteLine($"{semilla.Nombre} plantada!");
                            }
                            else
                            {
                                Console.WriteLine("No tienes dinero suficiente o no hay espacio.");
                            }
                        }
                        break;

                    case "2":
                        granja.Expandir(ref dinero);
                        break;

                    case "3":
                        foreach (var p in granja.Plantas)
                            p.PasarTurno();
                        Console.WriteLine("Ha pasado un turno.");
                        break;

                    case "4":
                        granja.MostrarPlantas();
                        break;

                    case "5":
                        {
                            for (int i = granja.Plantas.Count - 1; i >= 0; i--)
                            {
                                var p = granja.Plantas[i];
                                if (p.EstaLista())
                                {
                                    int ganancia = p.Frutos * p.ValorProducto;
                                    dinero += ganancia;
                                    Console.WriteLine($"Cosechaste {p.Frutos} {p.Nombre}(s) y ganaste {ganancia} monedas.");
                                    granja.Plantas.RemoveAt(i);
                                }
                            }
                            break;
                        }




                    case "0":

                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}



