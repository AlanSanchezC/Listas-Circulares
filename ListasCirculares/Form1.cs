using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListasCirculares
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ruta1 = new Ruta();
        }

        Ruta ruta1;

        private void limpiarCajas()
        {
            txtNombre.Text = "";
            txtMinutos.Text = "";
            txtNombre.Focus();
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            Base b = new Base(txtNombre.Text, int.Parse(txtMinutos.Text));
            ruta1.agregar(b);

            limpiarCajas();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtCaja.Text = ruta1.reporte();
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            Base b = new Base(txtNombre.Text, int.Parse(txtMinutos.Text));
            ruta1.agregarInicio(b);

            limpiarCajas();
        }

        private void btnElimPrimero_Click(object sender, EventArgs e)
        {
            ruta1.eliminarPrimera();
        }

        private void btnElimUltimo_Click(object sender, EventArgs e)
        {
            ruta1.eliminarUltima();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Base busqueda = ruta1.buscar(txtNombre.Text);
            if (busqueda != null)
            {
                txtMinutos.Text = busqueda.minutos.ToString();
            }
            else
            {
                limpiarCajas();
                MessageBox.Show("No existe.");
            }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            ruta1.eliminar(txtNombre.Text);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Base b = new Base(txtNombre.Text, int.Parse(txtMinutos.Text));

            ruta1.insertar(txtInsertar.Text, b);

            txtInsertar.Text = "";
            limpiarCajas();
        }

        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            txtRecorrido.Text = ruta1.recorrido(txtNombreRecorrido.Text, dtHoraInicio.Value, dtHoraFin.Value);
        }
    }
}
