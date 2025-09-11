using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seman3ejemplo1
{
     internal class Planta
     {
        public string Nombre { get; set; }
        public int TiempoDeVida { get; set; }
        public int Frutos { get; set; }
        public int ValorSemilla { get; set; }
        public int ValorProducto { get; set; }
        public int TiempoRestante { get; set; }

        public Planta(string nombre, int vida, int frutos, int valorSemilla, int valorProducto)
        {
            Nombre = nombre;
            TiempoDeVida = vida;
            Frutos = frutos;
            ValorSemilla = valorSemilla;
            ValorProducto = valorProducto;
            TiempoRestante = vida;
        }

        public void PasarTurno()
        {
            if (TiempoRestante > 0)
                TiempoRestante--;
        }

        public bool EstaLista()
        {
            return TiempoRestante == 0;
        }
     }
}
