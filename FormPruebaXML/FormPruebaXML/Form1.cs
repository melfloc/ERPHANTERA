﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

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

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                clsxml obj = new clsxml();
                ruta = buscar.FileName;
                textBox1.Text = ruta;
                obj.get_datos(ruta);
                textBox2.Text = obj.comp_version;
                textBox3.Text = obj.rec_rfc;
                textBox4.Text = obj.rec_nombre;
                textBox6.Text = obj.tim_uuid;
                textBox7.Text = obj.comp_tipocomprobante;
                textBox8.Text = obj.comp_serie;
                textBox9.Text = obj.comp_folio;
            }
            buscar.Dispose();
        }
    }
}