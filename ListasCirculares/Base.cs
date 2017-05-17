using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasCirculares
{
    class Base
    {
        public string nombre { get; set; }
        public int minutos { get; set; }
        public Base siguiente { get; set; }

        public override string ToString()
        {
            string cad = "Base: " + nombre + "\t" + minutos + "min. ";
            return cad;
        }

        public Base(string nombre, int minutos)
        {
            this.nombre = nombre;
            this.minutos = minutos;
        }

    }
}
