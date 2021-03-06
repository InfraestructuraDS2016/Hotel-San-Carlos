﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Data.Odbc;
using dllconsultas;
using FuncionesNavegador;
using seguridad;
namespace ModuloAdminHotel
{
    // PROGRAMADOR:RODRIGO JOSE SIFONTES RODRIGUEZ
    //AREA:RESERVACION DE HABITACION
    //FECHA DE INICIO: 15 /10/2016
    //FECHA DE FINALIZACION : 07/11/2016
    public partial class Frm_ReservacionHotel : Form
    {
        FuncionesNavegador.CapaNegocio fn = new FuncionesNavegador.CapaNegocio();
   
        String atributo;
        String codigo;
        Boolean editar, inactivo;
        DateTime fechaHoy = DateTime.Now;
        seguridad.bitacora bita = new seguridad.bitacora();

        DataGridView datagridantes;
        public List<String> cuartosseleccionados = new List<string>();
        int contador = 0;
        conexionmanipulacion conexion = new conexionmanipulacion();
        private const string ayudacinetopiaadministrativa = "ayuda_reservacion.chm";
        public Frm_ReservacionHotel(DataGridView datagrid)
        {
            InitializeComponent();
            bloquer();
            limpiar();
            datagridantes = datagrid;
            fn.InhabilitarComponentes(gpb_reservacion);
            fn.InhabilitarComponentes(gpb_cliente);


        }
        public Frm_ReservacionHotel()
        {
            InitializeComponent();
            bloquer();
            limpiar();
            fn.InhabilitarComponentes(gpb_reservacion);
            fn.InhabilitarComponentes(gpb_cliente);

        }
        private void Frm_ReservacionHotel_Load(object sender, EventArgs e)
        {
             llenarcolumnas();
            DataTable seg = seguridad.ObtenerPermisos.Permisos(seguridad.Conexion.User, "15111");
            if (seg.Rows.Count > 0)
            {
                fn.desactivarPermiso(seg, btn_guardar, btn_eliminar, btn_editar, btn_nuevo, btn_cancelar, btn_actualizar, btn_buscar, btn_anterior, btn_siguiente, btn_primero, btn_ultimo);
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        { 

        }

        private void lbl_tipo1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_tipo2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_tipo3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_tipo4_Click(object sender, EventArgs e)
        {

        }

        private void lbl_tipo5_Click(object sender, EventArgs e)
        {

        }


        private void gpb_reservacion_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gpb_cliente_Enter(object sender, EventArgs e)
        {

        }
        private void cbo_tipo1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // SE LLENA LOS COMOBOX CADA VEZ QUE CAMBIA
            cargar1();
            // SE CAMBIA EL FORMATO DE LAS FECHAS PARA QUE SE PUEDAN VER DE UNA MEJOR MANERA
            fechaentrada.Format = DateTimePickerFormat.Custom;
            fechaentrada.CustomFormat = "yyyy-MM-dd";
            string rs = fechaentrada.Text;
            fechaentrada.Format = DateTimePickerFormat.Custom;
            fechaentrada.CustomFormat = "dd-MM-yyyy";
         
            fechasalida.Format = DateTimePickerFormat.Custom;
            fechasalida.CustomFormat = "yyyy-MM-dd";
            string rf= fechasalida.Text;
            fechasalida.Format = DateTimePickerFormat.Custom;
            fechasalida.CustomFormat = "dd-MM-yyyy";
            // BORRA LOS ITEMS DEL CHECKLIST
            ckl_reservacion.Items.Clear();
            llenarcheck(cbo_tipo1, rs, rf);
            // SI NO HAY ELEMENTOS EN EL CHECKLIST SE MANTIENE BLOQUEADO
            if (txt_cant1.Text !="" && Convert.ToInt32(txt_cant1.Text)>0)
            {
                ckl_reservacion.Enabled = true;
            }
            else
            {
                ckl_reservacion.Enabled = false;
                txt_cant1.Enabled = true;
            }
           
           ;
        }
        private void lbl_capacidad3_Click(object sender, EventArgs e)
        {

        }

        private void txt_adultos3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txt_niño3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_descripcion3_Click(object sender, EventArgs e)
        {

        }

        private void txt_descp3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_cantidad3_Click(object sender, EventArgs e)
        {

        }

        private void txt_cant3_TextChanged(object sender, EventArgs e)
        {

        }
        private void cbo_codigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcomboboxcodigo();
        }
        private void cbo_nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcomboboxnombre();
        }
        private void cbo_dpi_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcomboboxdpi();
        }

        private void cbo_nit_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcomboboxnit();
        }
        //funciones
        //bloquea los botones, texto
        public void bloquer()
        {
            txt_niño1.ReadOnly = true;
         txt_adultos1.ReadOnly = true;
            txt_cant1.Enabled = false;
            fechasalida.Enabled = false;
            btn_buscar.Enabled = false;
         
        }
        //permite llemnar el combobox nombre con la concatenacion del nombre y el apellido
        public void llenarcbonombre(String Query)
        {

            OdbcCommand cm = new OdbcCommand(Query, conexion.rutaconectada());
           OdbcDataReader adaptador = cm.ExecuteReader();
            while (adaptador.Read())
            {
                cbo_nombre.Items.Add(adaptador["nombre"].ToString() + " " + adaptador["apellido"].ToString());

            }
            adaptador.Close();

        }
        public void llenartipo()
        {
           OdbcCommand cm = new OdbcCommand("SELECT  nivel_tipo FROM  tipo_habitacion where estado='activo';", conexion.rutaconectada());
            OdbcDataReader adaptador = cm.ExecuteReader();
            while (adaptador.Read())
            {
                cbo_tipo1.Items.Add(adaptador["nivel_tipo"].ToString());

            }
            adaptador.Close();
        }
        //llena los combobox del form
        public void llenarcolumnas()
        {
            try
            {
  
                llenartipo();
                // LLENA LOS COMBOBOX CON EL ID DEL CLIENTE, NIT , DPI,Y NOMBRE (EL NOMBRE ES UNA FUNCION APARTE YA QUE DEBE JUNTAR EL NOMBRE Y EL APELLIDO)
                conexion.getColumnas(cbo_codigo, "cliente", "id_cliente_pk");
                conexion.getColumnas(cbo_nit, "cliente", "nit");
                conexion.getColumnas(cbo_dpi, "cliente", "dpi");
                llenarcbonombre("SELECT * from cliente;");

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex);

            }
        }
        //carga los textbox de acuerdo al combobx tipo1 en el area de reservacion
        public void cargar1()
        {
            //CADA VEZ QUE CAMBIA EL COMBO BOX DE TIPO CAMBIA LOS TEXTBOX DE LA CAPACIDAD DE NIÑOS , CAPACIDAD DE ADULTOS Y LA DESCRIPCION
            String r1 = "SELECT ninio_tipo,adulto_tipo,especificaciones_tipo from tipo_habitacion WHERE nivel_tipo = '" + cbo_tipo1.Text + "';";
            if (cbo_tipo1.Text != "")
            {
                // LLENA LOS TEXTBOX
                conexion.llenartext(txt_niño1, r1, "ninio_tipo");
                conexion.llenartext(txt_adultos1, r1, "adulto_tipo");
                conexion.llenartext(txt_descp1, r1, "especificaciones_tipo");
                txt_niño1.ReadOnly = true;
                txt_adultos1.ReadOnly = true;
                txt_descp1.ReadOnly = true;
            }
     

        }
        // LLENA LOS COMBOBOX CUANDO EL CODIGO DEL CLIENTE CAMBIA
        public void llenarcomboboxcodigo()
        {
            try
            {
                if (cbo_codigo.Text != "")
                {
                    int s = cbo_codigo.SelectedIndex;
                    cbo_nombre.SelectedIndex = s;
                    cbo_dpi.SelectedIndex = s;
                    cbo_nit.SelectedIndex = s;
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex);
            }
        }
        //permite cambiar los combobox del cliente de acuerdo al combobox nombre
        public void llenarcomboboxnombre()
        {
            try
            {
                if (cbo_nombre.Text != "")
                {

                    int f = cbo_nombre.SelectedIndex;
                    cbo_codigo.SelectedIndex = f;
                    cbo_dpi.SelectedIndex = f;
                    cbo_nit.SelectedIndex = f;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex);
            }
        }
        //permite cambiar los combobox del cliente de acuerdo al combobox dpi

        public void llenarcomboboxdpi()
        {
            try
            {
                if (cbo_dpi.Text != "")
                {

                    int s = cbo_dpi.SelectedIndex;
                    cbo_codigo.SelectedIndex = s;
                    cbo_nombre.SelectedIndex = s;
                    cbo_nit.SelectedIndex = s;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex);
            }
        }
        //permite cambiar los combobox del cliente de acuerdo al combobox nit
        public void llenarcomboboxnit()
        {
            try
            {
                if (cbo_nit.Text != "")
                {
                    int s = cbo_nit.SelectedIndex;
                    cbo_codigo.SelectedIndex = s;
                    cbo_dpi.SelectedIndex = s;
                    cbo_nombre.SelectedIndex = s;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex);
            }
        }

        private void txt_acompañantes_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }
        private void txt_acompañantes_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_descp2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_descp1_TextChanged(object sender, EventArgs e)
        {

        }
        // solo permite ingresar numeros
        private void txt_acompañantes_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo debe llevar numero", "validacion de letras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo debe llevar numero", "validacion de letras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dtp_entrada_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        { 
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        //validacion de fechas que no puedan ingresar menos que la del sistema
        private void fechaentrada_ValueChanged(object sender, EventArgs e)
        {
            fechasalida.Enabled = true;
            //VALIDA QUE LA FECHA DE SALIDA NO PUEDE SER MENOR QUE LA DE ENTRADA
            fechasalida.MinDate = fechaentrada.Value;
            if (cbo_tipo1.Text!="")
            {
                fechaentrada.Format = DateTimePickerFormat.Custom;
                fechaentrada.CustomFormat = "yyyy-MM-dd";
                string rs = fechaentrada.Text;
                fechaentrada.Format = DateTimePickerFormat.Custom;
                fechaentrada.CustomFormat = "dd-MM-yyyy";

                //  //CONVIERTE LAS FECHAS A OTRO DTIPO DE FORMATO
                fechasalida.Format = DateTimePickerFormat.Custom;
                fechasalida.CustomFormat = "yyyy-MM-dd";
                string rf = fechasalida.Text;
                fechasalida.Format = DateTimePickerFormat.Custom;
                fechasalida.CustomFormat = "dd-MM-yyyy";

                ckl_reservacion.Items.Clear();
                llenarcheck(cbo_tipo1, rs, rf);

            }
        }
        //la fecha cambia de acuerdo a la de entrada
        private void fechasalida_ValueChanged(object sender, EventArgs e)
        {   //vALIDA QUE LA FECHA DE ENTRADA SOLO PUEDE SER LA ACTUAL DEL SISTEMA
            fechaentrada.MinDate = DateTime.Today;
            if (cbo_tipo1.Text != "")
            {
                fechaentrada.Format = DateTimePickerFormat.Custom;
                fechaentrada.CustomFormat = "yyyy-MM-dd";
                string rs = fechaentrada.Text;
                fechaentrada.Format = DateTimePickerFormat.Custom;
                fechaentrada.CustomFormat = "dd-MM-yyyy";

                fechasalida.Format = DateTimePickerFormat.Custom;
                fechasalida.CustomFormat = "yyyy-MM-dd";
                string rf = fechasalida.Text;
                fechasalida.Format = DateTimePickerFormat.Custom;
                fechasalida.CustomFormat = "dd-MM-yyyy";

                ckl_reservacion.Items.Clear();
                llenarcheck(cbo_tipo1, rs, rf);

            }
        }

        private void txt_adultos2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_adultos1_TextChanged(object sender, EventArgs e)
        {

        }
        //solo permite ingresar numeros en los textbox
        private void txt_cant1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo debe llevar numero", "validacion de letras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_cant2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo debe llevar numero", "validacion de letras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void txt_cant3_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
               
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Este campo solo debe llevar numero", "validacion de letras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //VALIDA QUE LA CANTIDAD DE HABTACIONES DISPONBLES SEA IGUAL O MAYOR A LA CANTIDAD QUE PIDE EL CLIENTE
        private void txt_cant1_TextChanged(object sender, EventArgs e)
        {
            if (txt_cant1.Text == ""|| txt_cant1.Text == "0")
            {
                ckl_reservacion.Enabled = false;
            }
            else
            {
                 
                int s = Convert.ToInt32(txt_cant1.Text);
                int f = Convert.ToInt32(ckl_reservacion.Items.Count.ToString());
                if (f < s)
                {
                    MessageBox.Show("No hay habitaciones suficientes");
                    ckl_reservacion.Enabled = false;
                }
                else
                {
                        ckl_reservacion.Enabled = true;
                }
            }
        }


        private void ckl_reservacion_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void ckl_reservacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          
 
        }

        private void lbl_cantidad1_Click(object sender, EventArgs e)
        {

        }

        //hace el filtro para verificar si una habitacione sta disponible

        public void llenarcheck(ComboBox cb, string entrada, String salida)
        {// selecciona todas las habitaciones
            String query1 = "select count(*) from habitacion;";
            int validacion1 = Convert.ToInt32(conexion.verificacionhabitaicon(query1));
            for (int a=1; a<=validacion1; a++)
            {// selecciona las que sean del tipo
                String query2 = "Select count(*) from habitacion a, tipo_habitacion b where a.id_habitacion_pk=" + a + " and b.nivel_tipo='" + cb.Text + "'and a.id_tipo_Pk = b.id_tipo_pk and a.estado!='INACTIVO';";
                int validacion2 = Convert.ToInt32(conexion.verificacionhabitaicon(query2));
                if(validacion2>0)
                {// validacion de fechas
                    String query3 = "SELECT count(*) from reservacion_habitacion where id_habitacion_pk =" + a + " and fecha_entreda >= '" + entrada + "'and fecha_entreda < '" + salida + "' and estado='reservado' or  id_habitacion_pk =" + a + " and fecha_entreda >= '" + entrada + "'and fecha_entreda < '" + salida + "' and estado='ocupado' or id_habitacion_pk =" + a + " and fecha_entreda <'" + entrada + "' and fecha_salida>'" + entrada + "' and estado='reservado' or id_habitacion_pk =" + a + " and fecha_entreda <'" + entrada + "' and fecha_salida>'" + entrada + "' and estado='ocupado' or id_habitacion_pk =" + a + " and  fecha_entreda<'" + entrada + "' and fecha_salida > '" + salida + "' and estado ='reservado'or id_habitacion_pk =" + a + " and  fecha_entreda<'" + entrada + "' and fecha_salida > '" + salida + "' and estado ='ocupado' or id_habitacion_pk =" + a + " and fecha_entreda = '" + entrada + "'and fecha_salida= '" + salida + "' and estado='reservado' or  id_habitacion_pk =" + a + " and fecha_entreda = '" + entrada + "'and fecha_salida ='" + salida + "' and estado='ocupado';";
                    int validacion3 = Convert.ToInt32(conexion.verificacionhabitaicon(query3));
                    if (validacion3==0)
                    {//inserta al checklistbox
                        String query4 = "Select nombre from habitacion where id_habitacion_pk=" + a + ";";
                        ckl_reservacion.Items.Add(conexion.verificacionhabitaicon(query4));
                    }
                    
                }
              
            }
        }
        // VALIDA CUANDO LA RESERVACION ESTA INACTIVA
        public void llenarcheckinactivo(ComboBox cb, string entrada, String salida)
        {// selecciona todas las habitaciones
            contador = 0;
            String query1 = "select count(*) from habitacion;";
            int validacion1 = Convert.ToInt32(conexion.verificacionhabitaicon(query1));
            for (int a = 1; a <= validacion1; a++)
            {// selecciona las que sean del tipo
                String query2 = "Select count(*) from habitacion a, tipo_habitacion b where a.id_habitacion_pk=" + a + " and b.nivel_tipo='" + cb.Text + "'and a.id_tipo_Pk = b.id_tipo_pk and a.estado!='INACTIVO';";
                int validacion2 = Convert.ToInt32(conexion.verificacionhabitaicon(query2));
                if (validacion2 > 0)
                {// validacion de fechas
                    String query3 = "SELECT count(*) from reservacion_habitacion where id_habitacion_pk =" + a + " and fecha_entreda >= '" + entrada + "'and fecha_entreda < '" + salida + "' and estado='reservado' or  id_habitacion_pk =" + a + " and fecha_entreda >= '" + entrada + "'and fecha_entreda < '" + salida + "' and estado='ocupado' or id_habitacion_pk =" + a + " and fecha_entreda <'" + entrada + "' and fecha_salida>'" + entrada + "' and estado='reservado' or id_habitacion_pk =" + a + " and fecha_entreda <'" + entrada + "' and fecha_salida>'" + entrada + "' and estado='ocupado' or id_habitacion_pk =" + a + " and  fecha_entreda<'" + entrada + "' and fecha_salida > '" + salida + "' and estado ='reservado'or id_habitacion_pk =" + a + " and  fecha_entreda<'" + entrada + "' and fecha_salida > '" + salida + "' and estado ='ocupado' or id_habitacion_pk =" + a + " and fecha_entreda = '" + entrada + "'and fecha_salida= '" + salida + "' and estado='reservado' or  id_habitacion_pk =" + a + " and fecha_entreda = '" + entrada + "'and fecha_salida ='" + salida + "' and estado='ocupado';";
                    int validacion3 = Convert.ToInt32(conexion.verificacionhabitaicon(query3));
                    if (validacion3 == 0)
                    {
                        //inserta al checklistbox
                        String query4 = "Select nombre from habitacion where id_habitacion_pk=" + a + ";";
                        ckl_reservacion.Items.Add(conexion.verificacionhabitaicon(query4));
                     
                        int habitacion= Convert.ToInt32(datagridantes.CurrentRow.Cells[2].Value.ToString());
                      
                        if (a==habitacion)
                        {
                         
                            ckl_reservacion.SetItemChecked(contador, true);
                            contador = 0;
                            
                        }
                        else
                        {
                            contador = contador + 1;
                        }
                    }

                }

            }
            contador =0;
        }



        private void btn_guardar_Click(object sender, EventArgs e)
        {
           
            if (txt_cant1.Text != "" && txt_acompañantes.Text != "" && txt_niñosacompañantes.Text != "" && cbo_codigo.Text != "")
            {
                int total_adultos = Convert.ToInt32(txt_adultos1.Text) * Convert.ToInt32(txt_cant1.Text);
                int total_niños = Convert.ToInt32(txt_niño1.Text) * Convert.ToInt32(txt_cant1.Text);
                int niños_habitacion = Convert.ToInt32(txt_niñosacompañantes.Text);
                int adultos_habitacion = Convert.ToInt32(txt_acompañantes.Text);
                if (total_adultos >= adultos_habitacion && total_niños >= niños_habitacion)
                {
                    int s = Convert.ToInt32(txt_cant1.Text);
                    if (ckl_reservacion.CheckedItems.Count != 0 && ckl_reservacion.CheckedItems.Count == s)
                    {
                      
                        //RECORRE LOS ITEMS SELECCIONADOS DEL CHECKLIST
                        for (int x = 0; x <= ckl_reservacion.CheckedItems.Count - 1; x++)
                        {
                            cuartosseleccionados.Add(ckl_reservacion.CheckedItems[x].ToString());
                            contador = contador + 1;

                        }
                        //HACE UN CICLO DE LOS ITEMS SELECCIONADOS PARA PODER INSERTAR
                        for (int x = 0; x < contador; x++)
                        {
                            String query = "select id_habitacion_pk from habitacion where nombre='" + cuartosseleccionados[x] + "';";
                            txt_codigocliente.Text = cbo_codigo.SelectedItem.ToString();
                            fechaentrada.Format = DateTimePickerFormat.Custom;
                            fechaentrada.CustomFormat = "yyyy-MM-dd";
                            string rs = fechaentrada.Text;
                            fechaentrada.Format = DateTimePickerFormat.Custom;
                            fechaentrada.CustomFormat = "dd-MM-yyyy";
                            txt_fechaentrada.Text = rs;
                            fechasalida.Format = DateTimePickerFormat.Custom;
                            fechasalida.CustomFormat = "yyyy-MM-dd";
                            string rf = fechasalida.Text;
                            fechasalida.Format = DateTimePickerFormat.Custom;
                            fechasalida.CustomFormat = "dd-MM-yyyy";
                            txt_fechasalida.Text = rf;
                            txt_idhabitacion.Text = conexion.verificacionhabitaicon(query);
                            txt_estadoreservacion.Text = "Reservado";
                            txt_fechasistema.Text = fechaHoy.ToString("yyyy-MM-dd");
                            TextBox[] textbox = { txt_codigocliente, txt_idhabitacion, txt_fechaentrada, txt_fechasalida, txt_fechasistema, txt_estadoreservacion };
                            DataTable datos = fn.construirDataTable(textbox);
                            if (datos.Rows.Count == 0)
                            {
                                MessageBox.Show("Hay campos vacios");
                            }
                            else
                            {
                                string tabla = "reservacion_habitacion";

                                if (editar)
                                {
                                  
                                    fn.modificar(datos, tabla, atributo, codigo);
                                    bita.Modificar("modifico una reservacion", "reservacion_habitacion");
                                }
                                else
                                {
                                    fn.insertar(datos, tabla);
                                    bita.Insertar("insercion de nueva reservacion", "reservacion_habitacion");
                                }

                            }

                        }

                        fn.ActualizarGrid(datagridantes, "select * from reservacion_habitacion ", "reservacion_habitacion");
                        contador = 0;
                        cuartosseleccionados.Clear();
                        limpiar();

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar la cantidad de habitaciones seleccionadas ");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar mas habitaciones , el numero de acompañantes es mayor a la capacidad de la habitacion");
                }
            }
            else
            {
                MessageBox.Show("debe llenar todos los campos");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_idhabitacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_fechasistema_TextChanged(object sender, EventArgs e)
        {

        }
        
        public void limpiar()
        {
            cbo_codigo.Text = null;
            cbo_dpi.Text = null;
            cbo_nombre.Text = null;
            cbo_nit.Text = null;
            cbo_tipo1.Text = null;
            txt_adultos1.Text = "";
            txt_cant1.Text = "";
            txt_niño1.Text = "";
            txt_descp1.Text = "";
            txt_acompañantes.Text = "";
            txt_niñosacompañantes.Text = "";
            fechaentrada.Value = DateTime.Now;
            fechasalida.Value = DateTime.Now;
         
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            editar = false;

            fn.ActivarControles(gpb_cliente);
            fn.ActivarControles(gpb_reservacion);
            limpiar();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            //llena todos los campos de form con forme a la celda seleccionada
            try
            {
                limpiar();
                editar = true;
                atributo = "id_reserhabit_pk";
                //codigo = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                codigo = datagridantes.CurrentRow.Cells[0].Value.ToString();

                if (datagridantes.CurrentRow.Cells[5].Value.ToString() == "INACTIVO")
                {
                    //SI EL ESTADO DE LA RESERVACION ES INACTIVO
                    inactivo = true;
                }

                TextBox[] textbox = { txt_codigocliente, txt_idhabitacion, txt_fechaentrada, txt_fechasalida, txt_fechasistema, txt_estadoreservacion };
                fn.llenartextbox(textbox, datagridantes);
                fechaentrada.Value = Convert.ToDateTime(txt_fechaentrada.Text);
                fechasalida.Value = Convert.ToDateTime(txt_fechasalida.Text);
                cbo_codigo.Text = txt_codigocliente.Text;
                int a = Convert.ToInt32(txt_idhabitacion.Text);
                string query1 = "select id_tipo_pk from habitacion  where id_habitacion_pk =" + a + ";";
                int consulta1 = Convert.ToInt32(conexion.verificacionhabitaicon(query1));
                string query = "select nivel_tipo from tipo_habitacion where id_tipo_pk=" + consulta1 + ";";
                cbo_tipo1.Text = conexion.verificacionhabitaicon(query);
                txt_acompañantes.Text = txt_adultos1.Text;
                txt_niñosacompañantes.Text = txt_niño1.Text;
                String query4 = "select nombre from habitacion where id_habitacion_pk =" + a + ";";
                ckl_reservacion.Items.Add(conexion.verificacionhabitaicon(query4));
                txt_cant1.Text = "1";
                if (inactivo)
                {
                    // SI EL ESTADO DE LA RESERVACION ES INACTIVO LO LLENA CON LA FUNCION LLENARCHECKINACTIVO()
                    ckl_reservacion.Items.Clear();
                    fechaentrada.Format = DateTimePickerFormat.Custom;
                    fechaentrada.CustomFormat = "yyyy-MM-dd";
                    string rs = fechaentrada.Text;
                    fechaentrada.Format = DateTimePickerFormat.Custom;
                    fechaentrada.CustomFormat = "dd-MM-yyyy";

                    fechasalida.Format = DateTimePickerFormat.Custom;
                    fechasalida.CustomFormat = "yyyy-MM-dd";
                    string rf = fechasalida.Text;
                    fechasalida.Format = DateTimePickerFormat.Custom;
                    fechasalida.CustomFormat = "dd-MM-yyyy";

                    llenarcheckinactivo(cbo_tipo1, rs, rf);
                    inactivo = false;
                }
                else
                {
                    int lista = ckl_reservacion.Items.Count - 1;
                    ckl_reservacion.SetItemChecked(lista, true);
                }
            }
            catch
            {
                
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //                String codigo2 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                String codigo2 = datagridantes.CurrentRow.Cells[0].Value.ToString();
                String atributo2 = "id_reserhabit_pk";
                var resultado = MessageBox.Show("Desea borrar el registro", "Confirme su accion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                
                    string tabla = "reservacion_habitacion";
                    fn.eliminar(tabla, atributo2, codigo2);
                    bita.Eliminar("elimino reservacion", "reservacion_habitacion");
                    fn.ActualizarGrid(datagridantes, "select * from reservacion_habitacion ", "reservacion_habitacion");
                    limpiar();
                }
            }
            catch
            {
               
            }
          
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                editar = false;
              
                fn.LimpiarComponentes(gpb_cliente);
                fn.InhabilitarComponentes(gpb_cliente);
                limpiar();
                fn.InhabilitarComponentes(gpb_reservacion);
                fn.InhabilitarComponentes(gpb_reservacionhab);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        private void txt_adultos1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            try
            {

                limpiar();
                fn.Siguiente(datagridantes);
                TextBox[] textbox = { txt_codigocliente, txt_idhabitacion, txt_fechaentrada, txt_fechasalida, txt_fechasistema, txt_estadoreservacion };
                fn.llenartextbox(textbox, datagridantes);
                fechaentrada.Value = Convert.ToDateTime(txt_fechaentrada.Text);
                fechasalida.Value = Convert.ToDateTime(txt_fechasalida.Text);
                cbo_codigo.Text = txt_codigocliente.Text;
                int a = Convert.ToInt32(txt_idhabitacion.Text);
                string query1 = "select id_tipo_pk from habitacion  where id_habitacion_pk =" + a + ";";
                int consulta1 = Convert.ToInt32(conexion.verificacionhabitaicon(query1));
                string query = "select nivel_tipo from tipo_habitacion where id_tipo_pk=" + consulta1 + ";";
                cbo_tipo1.Text = conexion.verificacionhabitaicon(query);
                txt_acompañantes.Text = txt_adultos1.Text;
                txt_niñosacompañantes.Text = txt_niño1.Text;
                String query4 = "select nombre from habitacion where id_habitacion_pk =" + a + ";";
                ckl_reservacion.Items.Add(conexion.verificacionhabitaicon(query4));
                txt_cant1.Text = "1";
                if (datagridantes.CurrentRow.Cells[5].Value.ToString() == "INACTIVO")//vERIFICAICA SI ES INACTIVO Y LLENA CON LA FUNCION LLENAR CHECKINACTIVO
                {
                    inactivo = true;
                }
                if (inactivo)
                {

                    ckl_reservacion.Items.Clear();
                    fechaentrada.Format = DateTimePickerFormat.Custom;
                    fechaentrada.CustomFormat = "yyyy-MM-dd";
                    string rs = fechaentrada.Text;
                    fechaentrada.Format = DateTimePickerFormat.Custom;
                    fechaentrada.CustomFormat = "dd-MM-yyyy";

                    fechasalida.Format = DateTimePickerFormat.Custom;
                    fechasalida.CustomFormat = "yyyy-MM-dd";
                    string rf = fechasalida.Text;
                    fechasalida.Format = DateTimePickerFormat.Custom;
                    fechasalida.CustomFormat = "dd-MM-yyyy";

                    llenarcheckinactivo(cbo_tipo1, rs, rf);
                    inactivo = false;
                }
                else
                {
                    int lista = ckl_reservacion.Items.Count - 1;
                    ckl_reservacion.SetItemChecked(lista, true);
                }
                
            }
            catch
            {
               
            }
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                fn.Anterior(datagridantes);
                TextBox[] textbox = { txt_codigocliente, txt_idhabitacion, txt_fechaentrada, txt_fechasalida, txt_fechasistema, txt_estadoreservacion };
                fn.llenartextbox(textbox, datagridantes);
                fechaentrada.Value = Convert.ToDateTime(txt_fechaentrada.Text);
                fechasalida.Value = Convert.ToDateTime(txt_fechasalida.Text);
                cbo_codigo.Text = txt_codigocliente.Text;
                int a = Convert.ToInt32(txt_idhabitacion.Text);
                string query1 = "select id_tipo_pk from habitacion  where id_habitacion_pk =" + a + ";";
                int consulta1 = Convert.ToInt32(conexion.verificacionhabitaicon(query1));
                string query = "select nivel_tipo from tipo_habitacion where id_tipo_pk=" + consulta1 + ";";
                cbo_tipo1.Text = conexion.verificacionhabitaicon(query);
                txt_acompañantes.Text = txt_adultos1.Text;
                txt_niñosacompañantes.Text = txt_niño1.Text;
                String query4 = "select nombre from habitacion where id_habitacion_pk =" + a + ";";
                ckl_reservacion.Items.Add(conexion.verificacionhabitaicon(query4));
                txt_cant1.Text = "1";
                if (datagridantes.CurrentRow.Cells[5].Value.ToString() == "INACTIVO")
                {
                    inactivo = true;
                }
                if (inactivo)
                {

                    ckl_reservacion.Items.Clear();
                    fechaentrada.Format = DateTimePickerFormat.Custom;
                    fechaentrada.CustomFormat = "yyyy-MM-dd";
                    string rs = fechaentrada.Text;
                    fechaentrada.Format = DateTimePickerFormat.Custom;
                    fechaentrada.CustomFormat = "dd-MM-yyyy";

                    fechasalida.Format = DateTimePickerFormat.Custom;
                    fechasalida.CustomFormat = "yyyy-MM-dd";
                    string rf = fechasalida.Text;
                    fechasalida.Format = DateTimePickerFormat.Custom;
                    fechasalida.CustomFormat = "dd-MM-yyyy";

                    llenarcheckinactivo(cbo_tipo1, rs, rf);
                    inactivo = false;
                }
                else
                {
                    int lista = ckl_reservacion.Items.Count - 1;
                    ckl_reservacion.SetItemChecked(lista, true);
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
      
                fn.Ultimo(datagridantes);
                TextBox[] textbox = { txt_codigocliente, txt_idhabitacion, txt_fechaentrada, txt_fechasalida, txt_fechasistema, txt_estadoreservacion };
                fn.llenartextbox(textbox, datagridantes);
                fechaentrada.Value = Convert.ToDateTime(txt_fechaentrada.Text);
                fechasalida.Value = Convert.ToDateTime(txt_fechasalida.Text);
                cbo_codigo.Text = txt_codigocliente.Text;
                int a = Convert.ToInt32(txt_idhabitacion.Text);
                string query1 = "select id_tipo_pk from habitacion  where id_habitacion_pk =" + a + ";";
                int consulta1 = Convert.ToInt32(conexion.verificacionhabitaicon(query1));
                string query = "select nivel_tipo from tipo_habitacion where id_tipo_pk=" + consulta1 + ";";
                cbo_tipo1.Text = conexion.verificacionhabitaicon(query);
                txt_acompañantes.Text = txt_adultos1.Text;
                txt_niñosacompañantes.Text = txt_niño1.Text;
                String query4 = "select nombre from habitacion where id_habitacion_pk =" + a + ";";
                ckl_reservacion.Items.Add(conexion.verificacionhabitaicon(query4));
                txt_cant1.Text = "1";
                if (datagridantes.CurrentRow.Cells[5].Value.ToString() == "INACTIVO")
                {
                    inactivo = true;
                }
                if (inactivo)
                {

                    ckl_reservacion.Items.Clear();
                    fechaentrada.Format = DateTimePickerFormat.Custom;
                    fechaentrada.CustomFormat = "yyyy-MM-dd";
                    string rs = fechaentrada.Text;
                    fechaentrada.Format = DateTimePickerFormat.Custom;
                    fechaentrada.CustomFormat = "dd-MM-yyyy";

                    fechasalida.Format = DateTimePickerFormat.Custom;
                    fechasalida.CustomFormat = "yyyy-MM-dd";
                    string rf = fechasalida.Text;
                    fechasalida.Format = DateTimePickerFormat.Custom;
                    fechasalida.CustomFormat = "dd-MM-yyyy";

                    llenarcheckinactivo(cbo_tipo1, rs, rf);
                    inactivo = false;
                }
                else
                {
                    int lista = ckl_reservacion.Items.Count - 1;
                    ckl_reservacion.SetItemChecked(lista, true);
                }
            }
            catch
            {
               
            }
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
            
                fn.Primero(datagridantes);
                TextBox[] textbox = { txt_codigocliente, txt_idhabitacion, txt_fechaentrada, txt_fechasalida, txt_fechasistema, txt_estadoreservacion };
                fn.llenartextbox(textbox, datagridantes);
                fechaentrada.Value = Convert.ToDateTime(txt_fechaentrada.Text);
                fechasalida.Value = Convert.ToDateTime(txt_fechasalida.Text);
                cbo_codigo.Text = txt_codigocliente.Text;
                int a = Convert.ToInt32(txt_idhabitacion.Text);
                string query1 = "select id_tipo_pk from habitacion  where id_habitacion_pk =" + a + ";";
                int consulta1 = Convert.ToInt32(conexion.verificacionhabitaicon(query1));
                string query = "select nivel_tipo from tipo_habitacion where id_tipo_pk=" + consulta1 + ";";
                cbo_tipo1.Text = conexion.verificacionhabitaicon(query);
                txt_acompañantes.Text = txt_adultos1.Text;
                txt_niñosacompañantes.Text = txt_niño1.Text;
                String query4 = "select nombre from habitacion where id_habitacion_pk =" + a + ";";
                ckl_reservacion.Items.Add(conexion.verificacionhabitaicon(query4));
                txt_cant1.Text = "1";
                if (datagridantes.CurrentRow.Cells[5].Value.ToString() == "INACTIVO")
                {
                    inactivo = true;
                }
                if (inactivo)
                {

                    ckl_reservacion.Items.Clear();
                    fechaentrada.Format = DateTimePickerFormat.Custom;
                    fechaentrada.CustomFormat = "yyyy-MM-dd";
                    string rs = fechaentrada.Text;
                    fechaentrada.Format = DateTimePickerFormat.Custom;
                    fechaentrada.CustomFormat = "dd-MM-yyyy";

                    fechasalida.Format = DateTimePickerFormat.Custom;
                    fechasalida.CustomFormat = "yyyy-MM-dd";
                    string rf = fechasalida.Text;
                    fechasalida.Format = DateTimePickerFormat.Custom;
                    fechasalida.CustomFormat = "dd-MM-yyyy";

                    llenarcheckinactivo(cbo_tipo1, rs, rf);
                    inactivo = false;
                }
                else
                {
                    int lista = ckl_reservacion.Items.Count - 1;
                    ckl_reservacion.SetItemChecked(lista, true);
                }
            }
            catch
            {
          
            
            }
        }

        private void fechaentrada_ValueChanged_1(object sender, EventArgs e)
        { 
            fechasalida.MinDate = fechaentrada.Value;
            if (cbo_tipo1.Text != "")
            {
                fechaentrada.Format = DateTimePickerFormat.Custom;
                fechaentrada.CustomFormat = "yyyy-MM-dd";
                string rs = fechaentrada.Text;
                fechaentrada.Format = DateTimePickerFormat.Custom;
                fechaentrada.CustomFormat = "dd-MM-yyyy";

                //
                fechasalida.Format = DateTimePickerFormat.Custom;
                fechasalida.CustomFormat = "yyyy-MM-dd";
                string rf = fechasalida.Text;
                fechasalida.Format = DateTimePickerFormat.Custom;
                fechasalida.CustomFormat = "dd-MM-yyyy";

                ckl_reservacion.Items.Clear();
                llenarcheck(cbo_tipo1, rs, rf);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(this,Application.StartupPath + @"/"+ayudacinetopiaadministrativa);
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            llenarcolumnas();
        }

        private void lbl_adultos_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
