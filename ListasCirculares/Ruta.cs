using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasCirculares
{
    class Ruta
    {
        Base inicio, ultima;

        public void agregar(Base nueva)
        {
            if (inicio == null)
            {
                inicio = nueva;
                inicio.siguiente = nueva;
            }
            else
            {
                nueva.siguiente = inicio;
                ultima.siguiente = nueva;
            }
            ultima = nueva;
        }

        public string reporte()
        {
            string cadena = "";
            Base bs = inicio;

            if (inicio == null)
                cadena = "Vacío";
            else if (inicio == ultima)
                cadena = bs.ToString();
            else
                do {
                    cadena += bs.ToString() + Environment.NewLine;
                    bs = bs.siguiente;
                } while (bs != inicio);

            return cadena;
        }

        public void agregarInicio(Base nueva)
        {
            if (inicio == null)
            {
                inicio = nueva;
                inicio.siguiente = nueva;
                ultima = nueva;
            }
            else
            {
                nueva.siguiente = inicio;
                ultima.siguiente = nueva;
                inicio = nueva;
            }
        }

        public void eliminarPrimera()
        {
            if (inicio == ultima)
            {
                inicio = null;
                ultima = null;
            }
            else
            {
                ultima.siguiente = inicio.siguiente;
                inicio = inicio.siguiente;
            }
        }

        public void eliminarUltima()
        {
            if (inicio == ultima)
            {
                inicio = null;
                ultima = null;
            }
            else
            {
                Base bs = inicio;
                while (bs.siguiente != ultima)
                    bs = bs.siguiente;

                bs.siguiente = inicio;
                ultima = bs;

            }
        }

        public Base buscar(string nombre)
        {
            bool encontrado = false;
            Base bs = inicio;
            Base basePedida = null;

            do
            {
                if (bs.nombre == nombre)
                {
                    encontrado = true;
                    basePedida = bs;
                }
                else
                {
                    bs = bs.siguiente;
                }            
            } while (!encontrado && bs != inicio);

            return basePedida;
        }

        public void eliminar(string nombre)
        {
            if (inicio.nombre == nombre)
                eliminarPrimera();
            else if (ultima.nombre == nombre)
                eliminarUltima();
            else
            {
                Base bs = inicio;
                bool encontrado = false;
                do
                { 
                    if (bs.siguiente.nombre == nombre)
                    {
                        encontrado = true;
                        bs.siguiente = bs.siguiente.siguiente;
                    }
                    else
                    {
                        bs = bs.siguiente;
                    }
                } while (!encontrado && bs != ultima) ;
            }
        }

        public void insertar(string nombre, Base nueva)
        {
            Base bs = buscar(nombre);
            if (bs == ultima)
            {
                agregar(nueva);
            }
            else
            {
                nueva.siguiente = bs.siguiente;
                bs.siguiente = nueva;
            } 
        }

        public string recorrido(string nombre, DateTime horaInicio, DateTime horaFin)
        {
            string cad = "";
            Base baseRuta = buscar(nombre);
            
            while(horaInicio <= horaFin)
            {
                cad += baseRuta.nombre + "  " + horaInicio.ToShortTimeString() + Environment.NewLine;
                horaInicio = horaInicio.AddMinutes(baseRuta.siguiente.minutos);

                baseRuta = baseRuta.siguiente;
            }
            return cad;
        }
    }
}
