using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioContenedores
{
    class Contenedor
    {
        private bool tipo;
        private int capacidad;
        private int[] paquetes;
        private int id;
        private int peso;
        private string despachante;

        public Contenedor (int cod, string empresa, bool type, int capacity, int[] cantidad)
        {
            id = cod;
            despachante = empresa;
            tipo = type;
            capacidad = capacity;
            paquetes = cantidad;
            peso = paquetes[0] * 5 + paquetes[1] * 15 + paquetes[2] * 25;
        }

        public int Id
        {
            get { return id;  }
        }

        public int Peso
        {
            get { return peso;  }
        }

        public string Despachante
        {
            get { return despachante;  }
        }

        public bool Tipo
        {
            get { return tipo; }
        }

        public int Capacidad
        {
            get { return capacidad; }
        }

        public int[] Paquetes
        {
            get { return paquetes; }
        }
    }
}
