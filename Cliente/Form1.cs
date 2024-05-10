using Cliente.MiServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
                
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            var client = new MiServicio.WebService1SoapClient();
            // Obtener los valores de los TextBoxes
            string sandwichType = textBoxTipo.Text;
            int quantity = Convert.ToInt32(textBoxCantidad.Text);
            string address = textBoxDireccion.Text;

            // Crear una instancia del cliente del servicio web
            

            try
            {
                // Llamar al método CreateOrder del servicio web
                string result = client.CreateOrder(sandwichType, quantity, address);

                // Mostrar el resultado en un MessageBox
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al llamar al servicio web
                MessageBox.Show($"Error al crear la orden: {ex.Message}");
            }
        }
    }
}
