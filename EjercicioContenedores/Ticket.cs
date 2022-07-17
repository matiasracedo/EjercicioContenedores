using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioContenedores
{
    class Ticket
    {
        private DateTime fecha;
        private bool multa = false;
        private double importe = 0;

        public Ticket (int dia, int mes, int anio, int hora, int min, int seg)
        {
            fecha = new DateTime(anio, mes, dia, hora, min, seg);
        }

        public DateTime Fecha
        {
            get { return fecha; }
        }

        public bool Multa
        {
            get { return multa; }
        }
        
        public double Importe
        {
            get { return importe; }
        }

        public void calcularImporte(bool domFeriado, int peso, bool tipo, int capacidad)
        {
            double resultado = 0;
            double subtotal = 0;
            // Calcular precio segun el tipo de envio (full o normal)
            if (tipo) subtotal += peso * 8.95;
            else subtotal += peso * 5.25;
            // Calcular recargo por peso
            if (peso <= capacidad - 100) resultado = subtotal + subtotal * 0.10;
            else if (peso > capacidad - 100 && peso <= capacidad - 10) resultado = subtotal + subtotal * 0.07;
            else if (peso > capacidad - 10 && peso <= capacidad + 5) resultado = subtotal - (subtotal * 0.05);
            else if (peso > capacidad + 5 && peso <= capacidad + 50) resultado = subtotal + subtotal * 0.18;
            else if (peso > capacidad + 50)
            {
                resultado = subtotal + subtotal * 0.8;
                multa = true;
            }
            // Calcular descuento/recargo por horario
            if (fecha.Hour >= 6 && fecha.Hour <= 20) resultado -= subtotal * 0.05;
            else resultado += subtotal * 0.04;

            // Agregar recargo si es domingo o feriado
            if (domFeriado) resultado += 1000;

            importe = resultado;
        }
    }
}
 