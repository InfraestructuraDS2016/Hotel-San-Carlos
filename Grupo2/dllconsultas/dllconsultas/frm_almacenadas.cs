﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dllconsultas
{
    public partial class frm_almacenadas : Form
    {
        string tabla;
        DataGridView dg;
        metodos ejecutar = new metodos();
        public frm_almacenadas(string tabla, DataGridView dg)
        {
            this.tabla = tabla;
            this.dg = dg;
            InitializeComponent();
        }

        private void frm_almacenadas_Load(object sender, EventArgs e)
        {
            String guardad = "select * from consultaguardada where idform = 1 and tabla='" + tabla + "';";
            ejecutar.actualizargrid(guardad, dataGridView1);
            nombrecolumna();
        }
        public void nombrecolumna()
        {
            try
            {
                //    creador:rodrigo
                this.dataGridView1.Columns[1].Visible = false;
                this.dataGridView1.Columns[0].HeaderText = "No";
                this.dataGridView1.Columns[2].HeaderText = "Nombre";
                this.dataGridView1.Columns[3].HeaderText = "Consulta";
                this.dataGridView1.Columns[3].HeaderText = "Tabla";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex);
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            String Squerys = ("Select * from consultaguardada where nombre like'" + textBox1.Text + "%'or descripcion like'" + textBox1.Text + "%';");
            ejecutar.buscarquery(Squerys);
            ejecutar.actualizargrid(Squerys, dataGridView1);
            nombrecolumna();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string queryss = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ejecutar.extraeryejecutar(queryss, dg);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex);
            }

        }
    }
}
