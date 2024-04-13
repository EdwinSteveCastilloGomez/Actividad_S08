using PlayerBlazorApp.Models;

namespace PlayerBlazorApp.Services
{
    public class DoubleLinkedList
    {
        public Nodo?  PrimerNodo { get; set; }
        public Nodo?  UltimoNodo { get; set; }

        public Nodo? NodoActual  { get; set; }
        public DoubleLinkedList()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            NodoActual = null;
        }

        public bool IsEmpty => PrimerNodo == null;


        //Insercion de nodos

        public string AgregarNodoAlInicio(Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaSiguiente = PrimerNodo;

                PrimerNodo.LigaAnterior = nuevoNodo;

                PrimerNodo = nuevoNodo;
            }

            NodoActual = nuevoNodo;

            return "Nodo agregado al inicio...";
        }

        public string AgregarNodoAlFinal(Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.LigaSiguiente = nuevoNodo;

                nuevoNodo.LigaAnterior = UltimoNodo;

                UltimoNodo = nuevoNodo;
            }

            NodoActual = nuevoNodo;

            return "Nodo agregado al final...";
        }
        
        public string AgregarNodoEnPosicion(int posicion, Nodo nuevoNodo)
        {
            if (posicion < 0)
            {
                return "La posición no puede ser negativa.";
            }
            if (posicion == 0)
            {
                return AgregarNodoAlInicio(nuevoNodo);
            }

            int indice = 0;
            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null && indice < posicion - 1)
            {
                nodoActual = nodoActual.LigaSiguiente;
                indice++;
            }

            if (nodoActual == null)
            {
                return $"La lista tiene menos de {posicion} elementos.";
            }

            nuevoNodo.LigaSiguiente = nodoActual.LigaSiguiente;
            nuevoNodo.LigaAnterior = nodoActual;

            nodoActual.LigaSiguiente = nuevoNodo;

            if (nodoActual == UltimoNodo)
            {
                UltimoNodo = nuevoNodo;
            }

            return $"Se ha agregado el nodo en la posición {posicion}.";
        }

        public string EliminarNodoEnPosicion(int posicion)
        {
            if (posicion < 0)
            {
                return "La posición no puede ser negativa.";
            }
            if (posicion == 0)
            {
                return QuitarNodoAlInicio();
            }

            int indice = 0;
            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null && indice < posicion - 1)
            {
                nodoActual = nodoActual.LigaSiguiente;
                indice++;
            }

            if (nodoActual == null || nodoActual.LigaSiguiente == null)
            {
                return $"La lista tiene menos de {posicion} elementos.";
            }

            Nodo nodoAEliminar = nodoActual.LigaSiguiente;
            nodoActual.LigaSiguiente = nodoAEliminar.LigaSiguiente;

            if (nodoAEliminar == UltimoNodo)
            {
                UltimoNodo = nodoActual;
            }
            else
            {
                nodoAEliminar.LigaSiguiente.LigaAnterior = nodoActual;
            }

            return $"Se ha eliminado el nodo en la posición {posicion}.";
        }


        //Eliminacion de nodos

        public string QuitarNodoAlInicio()
        {
            if (IsEmpty)
            {
                return "La lista ya esta vacia...";
            }
            else if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo? nodoEliminar;

                nodoEliminar = PrimerNodo;
                PrimerNodo = PrimerNodo.LigaSiguiente;
                PrimerNodo.LigaAnterior = null;

                nodoEliminar = null;
            }

            return "primer nodo eliminado";

        }

        public string QuitarNodoAlFinal()
        {
            if (IsEmpty)
            {
                return "La lista ya esta vacia...";
            }
            else if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo? nodoEliminar;

                nodoEliminar= UltimoNodo;
                UltimoNodo = UltimoNodo.LigaAnterior;
                UltimoNodo.LigaSiguiente = null;

                nodoEliminar = null;
            }

            return "Ultimo nodo eliminado";

        }


        public Nodo Siguiente()
        {
            NodoActual = NodoActual.LigaSiguiente ?? UltimoNodo;
            return NodoActual;
        }

        public Nodo Anterior()
        {
            NodoActual = NodoActual.LigaAnterior ?? PrimerNodo;
            return NodoActual;
        }


    }
}
