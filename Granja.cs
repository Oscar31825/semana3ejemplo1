using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seman3ejemplo1
{
   internal class Granja
    {
        public List<Planta> Plantas { get; set; } = new List<Planta>();
        public int Espacios { get; set; } = 2;
        public int CostoExpansion { get; set; } = 10;

        public void Expandir(ref int dinero)
        {
            if (dinero >= CostoExpansion)
            {
                dinero -= CostoExpansion;
                Espacios++;
                CostoExpansion += 10;
                Console.WriteLine("La granja se ha expandido. Espacios: " + Espacios);
            }
            else
            {
                Console.WriteLine("No tienes suficiente dinero.");
            }
        }

        public void MostrarPlantas()
        {
            if (Plantas.Count == 0)
            {
                Console.WriteLine("No hay plantas en la granja.");
                return;
            }

            for (int i = 0; i < Plantas.Count; i++)
            {
                var p = Plantas[i];
                Console.WriteLine($"{i + 1}. {p.Nombre} - Tiempo restante: {p.TiempoRestante} - Frutos: {p.Frutos}");
            }
        }
    }
}
