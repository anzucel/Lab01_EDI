﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab01_EDI.Models;

namespace Lab01_EDI.ListaDobleArtesanal
{
    public class ListaDoble <T> : IEnumerable <T>
    {
        public Nodo<T> inicio = new Nodo<T>();
        private Nodo<T> fin = new Nodo<T>();
        public int contador;
        public bool Editar;
        public int PosEditar;

        public ListaDoble()
        {
            inicio = null;
            fin = null;
            contador = 0;
        }

        ~ListaDoble() { }

        public bool ListaVacia()
        {
            return contador == 0;
        }

        public void InsertarInicio(T NuevoValor)
        {
            Nodo<T> nuevoNodo = new Nodo<T>();
            nuevoNodo.Valor = NuevoValor;

            if (ListaVacia())
            {
                inicio = nuevoNodo;
                fin = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = inicio;
                inicio.Anterior = nuevoNodo;
                inicio = nuevoNodo;
            }
            contador++;
            return;
        }

        public Nodo<T> ExtraerInicio()
        {
            Nodo<T> temporal = inicio;

            if (!ListaVacia())
            {
                inicio = inicio.Siguiente;
                if(inicio != null)
                    inicio.Anterior = null;
                if (contador == 1)
                {
                    fin = inicio;
                }
                contador--;
            }
            return temporal;
        }

        public Nodo<T> ExtraerFinal()
        {
            Nodo<T> temporal = fin;

            if (!ListaVacia())
            {
                if (contador == 1)
                {
                    fin = fin.Siguiente;
                    inicio = fin;
                }
                else
                {
                    fin = fin.Anterior;
                    fin.Siguiente = null;
                }
                contador--;
            }
            return temporal;
        }

        public Nodo<T> ExtraerEnPosicion(int posicion)
        {
            Nodo<T> temporal = inicio;

            if (!ListaVacia())
            {
                if ((contador == 1) || (posicion == 0))
                {
                    return ExtraerInicio();
                }
                else
                {
                    if (posicion == contador-1)
                    {
                        return ExtraerFinal();
                    }
                    else
                    {
                        Nodo<T> auxiliar = inicio;
                        int pos = 0;

                        while ((pos < posicion))
                        {
                            auxiliar = auxiliar.Siguiente;
                            pos++;
                        }
                        auxiliar.Anterior.Siguiente = auxiliar.Siguiente;
                        auxiliar.Siguiente.Anterior = auxiliar.Anterior;
                        contador--;
                    }
                }
            }
            return temporal;
        }

        public void CambiarEnPosicion(int posicion, T NuevoValor)
        {
            if (!ListaVacia())
            {
                if ((contador == 1) || (posicion == 0))
                {
                    inicio.Valor = NuevoValor;
                }
                else
                {
                    if (posicion == contador - 1)
                    {
                        fin.Valor = NuevoValor;
                    }
                    else
                    {
                        Nodo<T> auxiliar = inicio;
                        int pos = 0;

                        while ((pos < posicion))
                        {
                            auxiliar = auxiliar.Siguiente;
                            pos++;
                        }
                        auxiliar.Valor = NuevoValor;
                    }
                }
            }
        }
        public T ObtenerValor(int posicion)
        {
            if (posicion >= 0 && posicion < contador)
            {

                Nodo<T> temporal = inicio;
                int ubicacion = 0;

                while (ubicacion < posicion)
                {
                    temporal = temporal.Siguiente;
                    ubicacion++;
                }
                return temporal.Valor;
            }
            return default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T> nodo = inicio;
            while (nodo != null)
            {
                yield return nodo.Valor;
                nodo = nodo.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
      
    }
}

