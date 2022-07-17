using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioContenedores
{
    class Empresa
    {
        private int pesoTotal = 0;
        private int[] cajasUtilizadas = new int[3];
        private int multas = 0;
        private Contenedor[] multa = new Contenedor[20];
        private double cobrado = 0;
        private int contenedores = 0;

        public Contenedor[] Multa
        {
            get { return multa; }
        } 

        public double Cobrado
        {
            get { return cobrado; }
        }

        public double Multas
        {
            get { return multas; }
        }

        public int Contendores
        {
            get { return contenedores; }
        }

        public double pesoPromedio()
        {
            double promedio;
            if (contenedores == 0) promedio = 0;
            else promedio = pesoTotal / contenedores;
            return promedio;
        }

        public string cajaMasUtilizada()
        {
            string result;
            if (cajasUtilizadas[0] > cajasUtilizadas[1])
            {
                if (cajasUtilizadas[0] > cajasUtilizadas[2]) result = "A";
                else result = "C";
            }
            else
            {
                if (cajasUtilizadas[1] > cajasUtilizadas[2]) result = "B";
                else result = "C";
            }
            return result;
        }

        public Ticket imprimirTicket (int dia, int mes, int anio, int hora, int min, int seg, Contenedor contenedor, bool domFeriado)
        {
            Ticket ticket = new Ticket(dia, mes, anio, hora, min, seg);
            ticket.calcularImporte(domFeriado, contenedor.Peso, contenedor.Tipo, contenedor.Capacidad);
            if (ticket.Multa && multas < 20)
            {
                multa[multas] = contenedor;
                multas++;
            }
            pesoTotal += contenedor.Peso;
            cajasUtilizadas[0] += contenedor.Paquetes[0];
            cajasUtilizadas[1] += contenedor.Paquetes[1];
            cajasUtilizadas[2] += contenedor.Paquetes[2];
            cobrado += ticket.Importe;
            contenedores++;

            return ticket;
        }

    }
}
