using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioContenedores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Creamos objeto Empresa
        Empresa miEmpresa = new Empresa();

        private void clearForm()
        {
            cBanio.ResetText();
            cBmes.ResetText();
            cBdia.ResetText();
            cBhora.ResetText();
            cBmin.ResetText();
            cBseg.ResetText();
            cBcapacidad.ResetText();
            tBid.ResetText();
            tBdespachante.ResetText();
            tBpaqA.ResetText();
            tBpaqB.ResetText();
            tBpaqC.ResetText();
            rBfull.Checked = false;
            rBnormal.Checked = false;
            rBsi.Checked = false;
            rBno.Checked = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Creamos ventana de dialogo
            TicketForm ticket = new TicketForm();

            //Instanciamos objeto Contenedor
            int cod = Convert.ToInt32(tBid.Text);
            string empresa = tBdespachante.Text;
            bool tipo = rBfull.Checked;
            int capacidad = Convert.ToInt32(cBcapacidad.SelectedItem.ToString());
            int paqA = Convert.ToInt32(tBpaqA.Text);
            int paqB = Convert.ToInt32(tBpaqB.Text);
            int paqC = Convert.ToInt32(tBpaqC.Text);
            int[] cantidad = new int[] { paqA, paqB, paqC };
            Contenedor container = new Contenedor(cod, empresa, tipo, capacidad, cantidad);

            //Llamamos metodo imprimirTicket()
            int dia = Convert.ToInt32(cBdia.SelectedItem.ToString());
            int mes = Convert.ToInt32(cBmes.SelectedItem.ToString());
            int anio = Convert.ToInt32(cBanio.SelectedItem.ToString());
            int hora = Convert.ToInt32(cBhora.SelectedItem.ToString());
            int min = Convert.ToInt32(cBmin.SelectedItem.ToString());
            int seg = Convert.ToInt32(cBseg.SelectedItem.ToString());
            bool domFeriado = rBsi.Checked;
            Ticket ticketObj = miEmpresa.imprimirTicket(dia, mes, anio, hora, min, seg, container, domFeriado);

            //Completamos el ticket: Columna 1
            ticket.lBticket.Items.Add("Fecha");
            ticket.lBticket.Items.Add("ID");
            ticket.lBticket.Items.Add("Despachante");
            ticket.lBticket.Items.Add("Tipo envio");
            ticket.lBticket.Items.Add("Capacidad");
            ticket.lBticket.Items.Add("Paquetes A");
            ticket.lBticket.Items.Add("Paquetes B");
            ticket.lBticket.Items.Add("Paquetes C");
            ticket.lBticket.Items.Add("Peso Total");
            ticket.lBticket.Items.Add("Multa");
            ticket.lBticket.Items.Add("----------------------------------------------");
            ticket.lBticket.Items.Add("Importe Total");
            //Completamos el ticket: Columna 2
            ticket.lBvalores.Items.Add(ticketObj.Fecha.ToString("G"));
            ticket.lBvalores.Items.Add(container.Id.ToString());
            ticket.lBvalores.Items.Add(container.Despachante.ToString());
            string type = "Normal";
            if (container.Tipo) type = "Full";
            ticket.lBvalores.Items.Add(type);
            ticket.lBvalores.Items.Add(capacidad.ToString()+" Kg");
            ticket.lBvalores.Items.Add(paqA.ToString());
            ticket.lBvalores.Items.Add(paqB.ToString());
            ticket.lBvalores.Items.Add(paqC.ToString());
            ticket.lBvalores.Items.Add(container.Peso.ToString()+ " Kg");
            string multa = "No";
            if (ticketObj.Multa) multa = "Si";
            ticket.lBvalores.Items.Add(multa);
            ticket.lBvalores.Items.Add("----------------------------------------------");
            ticket.lBvalores.Items.Add(ticketObj.Importe.ToString("C"));

            ticket.ShowDialog();
            ticket.Dispose();
            clearForm();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
    
            //Creamos ventana de dialogo
            TicketForm ticket = new TicketForm();

            //Completamos el informe X: Columna 1
            ticket.lBticket.Items.Add("Reporte X");
            ticket.lBticket.Items.Add("----------------------------------------------");
            ticket.lBticket.Items.Add("Sub-total cobrado");
            ticket.lBticket.Items.Add("Contenedores generados");
            ticket.lBticket.Items.Add("Peso promedio transportado");
            ticket.lBticket.Items.Add("Caja mas utilizada");

            //Completamos el informe X: Columna 2
            ticket.lBvalores.Items.Add(fecha.ToString("G"));
            ticket.lBvalores.Items.Add("----------------------------------------------");
            ticket.lBvalores.Items.Add(miEmpresa.Cobrado.ToString("C"));
            ticket.lBvalores.Items.Add(miEmpresa.Contendores.ToString());
            ticket.lBvalores.Items.Add(miEmpresa.pesoPromedio().ToString("0.00")+" Kg");
            ticket.lBvalores.Items.Add(miEmpresa.cajaMasUtilizada());

            ticket.ShowDialog();
            ticket.Dispose();
            clearForm();
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;

            //Creamos ventana de dialogo
            TicketForm ticket = new TicketForm();

            //Completamos el informe X: Columna 1
            ticket.lBticket.Items.Add("Reporte Z");
            ticket.lBticket.Items.Add("----------------------------------------------");
            ticket.lBticket.Items.Add("Contenedores con Multa");
            for (int i = 0; i < miEmpresa.Multas; i++)
            {
                ticket.lBticket.Items.Add("ID contenedor");
                ticket.lBticket.Items.Add("Empresa despachante");
                ticket.lBticket.Items.Add("Peso total");
                ticket.lBticket.Items.Add("----------------------------------------------");
            }

            //Completamos el informe X: Columna 2
            ticket.lBvalores.Items.Add(fecha.ToString("G"));
            ticket.lBvalores.Items.Add("----------------------------------------------");
            ticket.lBvalores.Items.Add("");
            for (int i = 0; i < miEmpresa.Multas; i++)
            {
                ticket.lBvalores.Items.Add(miEmpresa.Multa[i].Id.ToString());
                ticket.lBvalores.Items.Add(miEmpresa.Multa[i].Despachante.ToString());
                ticket.lBvalores.Items.Add(miEmpresa.Multa[i].Peso.ToString()+" Kg");
                ticket.lBvalores.Items.Add("----------------------------------------------");
            }

            ticket.ShowDialog();
            ticket.Dispose();
            Close();
        }
    }
}
