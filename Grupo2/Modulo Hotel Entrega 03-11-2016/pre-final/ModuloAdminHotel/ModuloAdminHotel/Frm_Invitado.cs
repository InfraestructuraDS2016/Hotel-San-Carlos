﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dllconsultas;
using FuncionesNavegador;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace ModuloAdminHotel
{
    public partial class Frm_Invitado : Form
    {

        Boolean editar;
        String atributo;
        String codigo;
        DataGridView datagridantes;

        conexionmanipulacion con = new conexionmanipulacion();

        public Frm_Invitado()
        {
            InitializeComponent();
        }

        public Frm_Invitado(DataGridView datagrid)
        {
            InitializeComponent();
            datagridantes = datagrid;
        }

        private void Frm_Invitado_Load(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.InhabilitarComponentes(this);


            DataSet ds = new DataSet();
            String Query = "select id_evento_pk, nombre from evento;";
            OdbcDataAdapter dad = new OdbcDataAdapter(Query, con.rutaconectada());
            dad.Fill(ds, "evento");

            cbo_evento.DataSource = ds.Tables[0].DefaultView;
            cbo_evento.ValueMember = ("id_evento_pk");
            cbo_evento.DisplayMember = ("nombre");


        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            editar = false;
            CapaNegocio fn = new CapaNegocio();
            fn.ActivarControles(this);
            fn.LimpiarComponentes(this);

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            txt_evento.Text = cbo_evento.SelectedItem.ToString();

            //try { 
            CapaNegocio fn = new CapaNegocio();
            TextBox[] textbox = { txt_nombre, txt_apellido,txt_dpi,txt_correo,txt_evento};
            DataTable datos = fn.construirDataTable(textbox);
            if (datos.Rows.Count == 0)
            {
                MessageBox.Show("Hay campos vacios");
            }
            else
            {
                string tabla = "invitado";
                if (editar)
                {
                    fn.modificar(datos, tabla, atributo, codigo);

                }
                else
                {
                    fn.insertar(datos, tabla);
                }
                fn.LimpiarComponentes(this);
                fn.ActualizarGrid(datagridantes, "select * from invitado", tabla);

            }
            //}
            //catch
            //{
            //    MessageBox.Show("Hubo un error durante el proceso");
            //}



        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                editar = true;
                atributo = "id_invitado_pk";
                //codigo = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                codigo = datagridantes.CurrentRow.Cells[0].Value.ToString();

                TextBox[] textbox = { txt_nombre, txt_apellido, txt_dpi, txt_correo, txt_evento };

                CapaNegocio fn = new CapaNegocio();
                fn.llenartextbox(textbox, datagridantes);


            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningun registro a editar");
            }


        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            try
            {
                //                String codigo2 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                String codigo2 = datagridantes.CurrentRow.Cells[0].Value.ToString();
                String atributo2 = "id_invitado_pk";
                var resultado = MessageBox.Show("Desea borrar el registro", "Confirme su accion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    CapaNegocio fn = new CapaNegocio();
                    string tabla = "invitado";
                    fn.eliminar(tabla, atributo2, codigo2);
                }
            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningun registro a editar");
            }


        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string tabla = "invitado";
            operaciones op = new operaciones();
            op.ejecutar(datagridantes, tabla);

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            editar = false;
            CapaNegocio fn = new CapaNegocio();
            fn.LimpiarComponentes(this);
            fn.InhabilitarComponentes(this);


        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

            CapaNegocio fn = new CapaNegocio();
            string tabla = "invitado";
            fn.ActualizarGrid(datagridantes, "select * from invitado", tabla);

        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Anterior(datagridantes);
            TextBox[] textbox = { txt_nombre, txt_apellido, txt_dpi, txt_correo, txt_evento };
            fn.llenartextbox(textbox, datagridantes);

        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {

            CapaNegocio fn = new CapaNegocio();
            fn.Siguiente(datagridantes);
            TextBox[] textbox = { txt_nombre, txt_apellido, txt_dpi, txt_correo, txt_evento };
            fn.llenartextbox(textbox, datagridantes);

        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Primero(datagridantes);
            TextBox[] textbox = { txt_nombre, txt_apellido, txt_dpi, txt_correo, txt_evento };
            fn.llenartextbox(textbox, datagridantes);

        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Ultimo(datagridantes);
            TextBox[] textbox = { txt_nombre, txt_apellido, txt_dpi, txt_correo, txt_evento };
            fn.llenartextbox(textbox, datagridantes);

        }
    }
}