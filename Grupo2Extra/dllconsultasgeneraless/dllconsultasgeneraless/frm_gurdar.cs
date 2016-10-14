﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dllconsultasgeneraless
{
    public partial class frm_gurdar : Form
    {
        metodos ejecutar = new metodos();
        string consulta;
        public frm_gurdar(string query)
        {
            this.consulta =query;
            InitializeComponent();
        }

        private void frm_gurdar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ya a la funcion insertar 
            insert();
        }
        private void insert()
        {
           //ingresa la consulta a la base de datos
            if (txt_Nombre.Text == "")
            {
                MessageBox.Show("Llene los campos por favor");
                MessageBox.Show(consulta);
            }
            else
            {

                try
                {
                    string traduccion = consulta.Replace("'", "$");
                    String Squery = "insert into  consultaguardada (idform,nombre,descripcion,tabla) values( 'C','" + txt_Nombre.Text + "', '" + traduccion + "','Joins');";
                    ejecutar.EjecutarQuery(Squery);
                    this.Close();
                    //this.Hide();
                    //Form1 r = new Form1();
                    //r.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.TargetSite);
                    MessageBox.Show("Error al Guardar");
                }
            }
        }

        private void btn_cancelarGuardar_Click(object sender, EventArgs e)
        {
            txt_Nombre.Text = "";
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
