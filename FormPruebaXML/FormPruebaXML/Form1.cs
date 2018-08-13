using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormPruebaXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ruta;
            OpenFileDialog buscar = new OpenFileDialog();
            buscar.Filter = "Archivos Xml (*.xml)|*.xml";
            buscar.Title = "archivos Xml";
            buscar.Multiselect = true;

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                foreach (string r in buscar.FileNames) //MULTISELECCION DE ARCHIVOS DE FACTURA XML
                {
                    clsxml obj = new clsxml();
                    ruta = r;
                    textBox1.Text += ruta + "; ";
                    obj.get_data(ruta);
                    textBox2.Text = obj.comp_version;
                    textBox3.Text = obj.rec_rfc;
                    textBox4.Text = obj.rec_nombre;
                    textBox6.Text = obj.tim_uuid;
                    textBox7.Text = obj.comp_tipocomprobante;
                    textBox8.Text = obj.comp_serie;
                    textBox9.Text = obj.comp_folio;
                    textBox12.Text = obj.con_descripcion;
                    textBox17.Text = obj.imp_ret_isr_importe;
                    textBox16.Text = obj.imp_ret_isr_impuesto;
                    textBox19.Text = obj.imp_ret_iva_importe;
                    textBox18.Text = obj.imp_ret_iva_impuesto;
                }
            }
                
            buscar.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Factura añadida a la base de datos;");
            Close();           
        }
    }
}
