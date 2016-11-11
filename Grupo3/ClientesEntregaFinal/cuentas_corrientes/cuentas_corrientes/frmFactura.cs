﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using System.Data.Odbc;
using seguridad;
using System.Diagnostics;

namespace cuentas_corrientes
{
    public partial class frmFactura : Form
    {
        public frmFactura()
        {
            InitializeComponent();
            llenar();
            btn_busfolio.Enabled = false;
            btn_busped.Enabled = false;
            btn_bproducto.Enabled = true;
            txt_cant.Enabled = true;

            


        }
        public int idFactAct;
        public frmFactura(int id, string emp, string serie, string nom,  string ape, string fec_emi,string fec_ven,string nom_emp,decimal tot,decimal imp, decimal subtot)
        {
            InitializeComponent();
            idFactAct = id;
            txt_nombre.Text = nom + " "+ape;
            cbo_empre.Enabled = false;
            cbo_empre.Text = emp;
            cbo_serie.Text = serie;
            cbo_serie.Enabled = false;
            dpic_fecemi.Text = fec_emi;
            dpic_fecven.Text = fec_ven;
            cbo_vendedor.Text = nom_emp;
            cbo_vendedor.Enabled = false;
            txt_subtot.Text = Convert.ToString(subtot);
            txt_tot.Text = Convert.ToString(tot);
            cbo_imp.Text = Convert.ToString(imp);
            txt_cant.Enabled = false;
            

            dgv_detallefact.DataSource = Cls_OpDevo.BuscarDet1(id);


            /*dgv_detallefact.Columns.RemoveAt(1);
            dgv_detallefact.Columns.RemoveAt(2);*/

        }
        

        public static int codigo;
        public static int codigoclte;
        public cls_cliente cte_fol;
        public static int dias_cte;
        public static int cantidad;

      

        public void llenar()
        {
            cbo_serie.Items.Add("A");
            cbo_serie.Items.Add("B");
            cbo_serie.Items.Add("C");
            //cbo_estado.Items.Add("Cancelado");
            //cbo_estado.Items.Add("Deuda");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txt_fecemi_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
           // cbo_empre.DropDownStyle = ComboBoxStyle.DropDownList;
            //cbo_serie.DropDownStyle = ComboBoxStyle.DropDownList;
            //cbo_vendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            //cbo_formpago.DropDownStyle = ComboBoxStyle.DropDownList;
            // button1.Enabled = false;
            //button2.Enabled = false;
            //button3.Enabled = false;

            //Codigo para llenar encabezado de factura
            //Olivia Vicente Tinoco 0901-13-194
            OdbcConnection conectar = seguridad.Conexion.ObtenerConexionODBC();
            string scad = "select * from forma_pago where estado='activo'";
            OdbcCommand mcd = new OdbcCommand(scad, conectar);
            OdbcDataReader mdr = mcd.ExecuteReader();
            while (mdr.Read())
            {
                cbo_formpago.Items.Add(mdr.GetString(1));
            }
            conectar.Close();

            OdbcConnection conectar2 = seguridad.Conexion.ObtenerConexionODBC();


            string scad1 = "select * from empresa";
            OdbcCommand mcd1 = new OdbcCommand(scad1, conectar2);
            OdbcDataReader mdr1 = mcd1.ExecuteReader();
            while (mdr1.Read())
            {
                cbo_empre.Items.Add(mdr1.GetString(1));
            }
            conectar2.Close();



            OdbcConnection conectar3 = seguridad.Conexion.ObtenerConexionODBC();


            string scad3 = "select * from impuesto where estado='activo'";
            OdbcCommand mcd3 = new OdbcCommand(scad3, conectar3);
            OdbcDataReader mdr3 = mcd3.ExecuteReader();
            while (mdr3.Read())
            {
                cbo_imp.Items.Add(mdr3.GetString(2));
            }
            conectar2.Close();





        }

        private void cbo_formpago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public cls_cliente cldes { get; set; }

        //public int codigo { get; set; }

        public void btn_Buscte_Click(object sender, EventArgs e)
        {
            //Codigo para buscar cliente y agregarlo a la factura
            //Olivia Aracely Vicente Tinoco
            try
            {
                frmbuscliente buscl = new frmbuscliente();
                buscl.ShowDialog();


                if (buscl.descl != null)
                {
                    cldes = buscl.descl;
                    codigoclte = buscl.descl.cod;
                    txt_nombre.Text = buscl.descl.nombre + " " + buscl.descl.apellido;

                    txt_nit.Text = buscl.descl.nit;
                    txt_dir.Text = buscl.descl.dire;
                    codigo = buscl.descl.codpre;
                    MessageBox.Show(Convert.ToString(codigo));
                    dias_cte = cldes.dias_cre;

                    int cod=buscl.descl.codven;

                    // cte_fol.dias_cre = dias_cte;

                    OdbcConnection conectar4 = seguridad.Conexion.ObtenerConexionODBC();

                    OdbcCommand _mcd2 = new OdbcCommand(String.Format("select nombre from empleado  where id_empleados_pk ='{0}'", cod), conectar4);

                    OdbcDataReader mdr2 = _mcd2.ExecuteReader();
                    while (mdr2.Read())
                    {
                        // cbo_vendedor.Items.Add(mdr2.GetString(1));
                        cbo_vendedor.Text = mdr2.GetString(0);
                       // MessageBox.Show(mdr2.GetString(1));

                    }
                    cbo_vendedor.Enabled = false;

                    conectar4.Close();

                }
                //MessageBox.Show(Convert.ToString(cldes.dias_cre));
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        
        
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            //button1.Enabled = true;
            //button2.Enabled = true;
            //button3.Enabled = true;
            
        }

        private void cbo_serie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void check_fol_CheckedChanged(object sender, EventArgs e)
        {
            //Codigo para validar facturación de folio
            //Olivia Vicente Tinoco 0901-13-194
            check_pre.Enabled = false;
            check_prod.Enabled = false;
            txt_prod.Enabled = false;
            txt_precio.Enabled = false;
            txt_cant.Enabled = false;
            btn_Buscte.Enabled = false;
            txt_dir.Enabled = false;
            txt_nombre.Enabled = false;
            txt_nit.Enabled = false;
            btn_busfolio.Enabled = true;
        }

        private void check_pre_CheckedChanged(object sender, EventArgs e)
        {
            //Codigo para valida facturación de pedido
            //Olivia Vicente Tinoco 0901-13-194
            check_fol.Enabled = false;
            check_prod.Enabled = false;
            txt_prod.Enabled = false;
            txt_precio.Enabled = false;
            txt_cant.Enabled = false;
            btn_Buscte.Enabled = false;
            txt_dir.Enabled = false;
            txt_nombre.Enabled = false;
            txt_nit.Enabled = false;
            btn_busped.Enabled = true;
        }



        private void cbo_vendedor_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Codigo para llenar combobox con el respectivo vendedor de la empresa a facturar
            //Olivia Vicente Tinoco 0901-13-194
            cbo_vendedor.Items.Clear();

            OdbcConnection conectar3 = seguridad.Conexion.ObtenerConexionODBC();
            clsComun emp = new clsComun();
            OdbcCommand _comando = new OdbcCommand(String.Format(
                 "SELECT id_empresa_pk FROM empresa where nombre ='{0}' ", cbo_empre.Text), conectar3);
            OdbcDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {

                emp.cod = _reader.GetInt16(0);
            }


            conectar3.Close();
            OdbcConnection conectar4 = seguridad.Conexion.ObtenerConexionODBC();

            OdbcCommand _mcd2 = new OdbcCommand(String.Format("select * from empleado  where cargo='vendedor' and id_empresa_pk ='{0}' ", emp.cod), conectar4);

            OdbcDataReader mdr2 = _mcd2.ExecuteReader();
            while (mdr2.Read())
            {
                cbo_vendedor.Items.Add(mdr2.GetString(1));
            }


            conectar4.Close();
        }

        public clsFolio FolAct { get; set; }
        public static decimal impu_fol { get; set; }
        public static decimal impu_ped { get; set; }
        public static decimal impu_prod { get; set; }


        public void calcular2()
        {
            ClsFactura factu2 = new ClsFactura();
            OdbcConnection conectar = seguridad.Conexion.ObtenerConexionODBC();
            clsComun emp2 = new clsComun();
            OdbcCommand _comando = new OdbcCommand(String.Format(
                 "SELECT id_empresa_pk FROM empresa where nombre ='{0}' ", cbo_empre.Text), conectar);
            OdbcDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {

                factu2.cod_emp = _reader.GetInt16(0); //Id empresa
            }
            conectar.Close();

            int filas = dgv_detallefact.RowCount;
            decimal sub = 0;
            for (int f = 0; f < filas; f++)
            {
                sub += Convert.ToDecimal(dgv_detallefact.Rows[f].Cells[5].Value);
            }


            txt_subtot.Text = Convert.ToString(sub);
            txt_tot.Text = Convert.ToString(sub);


            OdbcConnection conectar2 = seguridad.Conexion.ObtenerConexionODBC();
            clsComun imp2 = new clsComun();
            OdbcCommand _comando2 = new OdbcCommand(String.Format(
                 "SELECT SUM(impuesto.porcentaje) , parametros_fac.empresa FROM impuesto , parametros_fac where parametros_fac.empresa = '{0}' and parametros_fac.id_impuesto = impuesto.id_impuesto_pk ", factu2.cod_emp), conectar2);
            OdbcDataReader _reader2 = _comando2.ExecuteReader();
            while (_reader2.Read())
            {

                impu_ped = _reader2.GetDecimal(0); //Id impuestp
            }
            conectar2.Close();
            decimal subt = sub;

            decimal impue = subt * impu_ped;
           // MessageBox.Show(Convert.ToString(impue));

            cbo_imp.Text = Convert.ToString(impue);

            decimal total = subt + impue;
            txt_tot.Text = Convert.ToString(total);
        }


        private void btn_busfolio_Click(object sender, EventArgs e)
        {
            //Codigo para buscar folio, extraer los datos y llenar factura con los mismos
            //Olivia Vicente Tinoco 0901-13-194
            try
            {
                frm_BusFol temp = new frm_BusFol();
                temp.ShowDialog();
                if (temp.FolSelec != null)
                {
                    FolAct = temp.FolSelec;
                    //MessageBox.Show(Convert.ToString(FolAct.cod));
                    //MessageBox.Show(Convert.ToString(FolAct.estado));
                    //MessageBox.Show(FolAct.fec_pago);
                    dgv_detallefact.DataSource = ClsOpFolio.BuscardetalleFol(FolAct.cod);


                    OdbcConnection conectar3 = seguridad.Conexion.ObtenerConexionODBC();
                    cls_cliente cte = new cls_cliente();
                    OdbcCommand _comando3 = new OdbcCommand(String.Format(
                         "SELECT nombre, apellido, direccion, nit, id_empleado_pk, dias_cred FROM cliente where id_cliente_pk ='{0}' ", FolAct.codcte), conectar3);
                    OdbcDataReader _reader3 = _comando3.ExecuteReader();
                    while (_reader3.Read())
                    {
                        cte.nombre = _reader3.GetString(0);
                        cte.apellido = _reader3.GetString(1);
                        cte.dire = _reader3.GetString(2);
                        cte.nit = _reader3.GetString(3);
                        cte.codven = _reader3.GetInt16(4);
                        cte.dias_cre = _reader3.GetInt16(5);
                    }
                    cte_fol = cte;
                    txt_nombre.Text = cte.nombre + " " + cte.apellido;
                    txt_nit.Text = cte.nit;
                    txt_dir.Text = cte.dire;
                    


                 //   MessageBox.Show(Convert.ToString(cte.dias_cre));

                    OdbcConnection conectar4 = seguridad.Conexion.ObtenerConexionODBC();

                    OdbcCommand _mcd2 = new OdbcCommand(String.Format("select * from empleado  where id_empleados_pk ='{0}'", cte.codven), conectar4);

                    OdbcDataReader mdr2 = _mcd2.ExecuteReader();
                    while (mdr2.Read())
                    {
                       // cbo_vendedor.Items.Add(mdr2.GetString(1));
                      cbo_vendedor.Text= mdr2.GetString(1);

                    }
                    cbo_vendedor.Enabled = false;

                    conectar4.Close();
                   

                }



                int filas = dgv_detallefact.RowCount;
                for (int f = 0; f < filas; f++)
                {

                    dgv_detallefact.Rows[f].Cells[1].Value = 1;

                }

                for (int f = 0; f < filas; f++)
                {
                    int cant, cost, sub;

                    //dgv_detallefact.Rows[f].Cells[1].Value = 1;
                    cant = Convert.ToInt16(dgv_detallefact.Rows[f].Cells[1].Value);
                    cost = Convert.ToInt16(dgv_detallefact.Rows[f].Cells[3].Value);
                    sub = cant * cost;
                    dgv_detallefact.Rows[f].Cells[4].Value = Convert.ToString(sub);
                }

                txt_subtot.Text = Convert.ToString(FolAct.costo);
                ClsFactura factu1 = new ClsFactura();
                OdbcConnection conectar = seguridad.Conexion.ObtenerConexionODBC();
                clsComun emp = new clsComun();
                OdbcCommand _comando = new OdbcCommand(String.Format(
                     "SELECT id_empresa_pk FROM empresa where nombre ='{0}' ", cbo_empre.Text), conectar);
                OdbcDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {

                    factu1.cod_emp = _reader.GetInt16(0); //Id empresa
                }
                conectar.Close();


                OdbcConnection conectar2 = seguridad.Conexion.ObtenerConexionODBC();
                clsComun imp = new clsComun();
                OdbcCommand _comando2 = new OdbcCommand(String.Format(
                     "SELECT SUM(impuesto.porcentaje) , parametros_fac.empresa FROM impuesto , parametros_fac where parametros_fac.empresa = '{0}' and parametros_fac.id_impuesto = impuesto.id_impuesto_pk ", factu1.cod_emp), conectar2);
                OdbcDataReader _reader2 = _comando2.ExecuteReader();
                while (_reader2.Read())
                {
                    impu_fol = _reader2.GetDecimal(0); //Id impuestp
                }
                conectar2.Close();
                decimal subt = Convert.ToDecimal(txt_subtot.Text);

                decimal impue = subt * impu_fol;
                MessageBox.Show(Convert.ToString(impue));
               
              cbo_imp.Text = Convert.ToString(impue);

                decimal total = subt + impue;
               txt_tot.Text = Convert.ToString(total);

               // calcular2();



                // txt_tot.Text = Convert.ToString(FolAct.costo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public string tipo_fact;

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            try
            {


                if (check_fol.Enabled == true)
                {
                    tipo_fact = "folio";
                }

                if (check_pre.Enabled == true)
                {
                    tipo_fact = "pedido";
                }
                if (check_prod.Enabled == true)
                {
                    tipo_fact = "prod";
                }
                //MessageBox.Show(tipo_fact);



                /* if (tipo_fact == "folio")
                 {
                     MessageBox.Show("FOLIO");
                 }

                 if (tipo_fact == "pedido")
                 {
                     MessageBox.Show("PEDIDO");
                 }

                 if (tipo_fact == "prod")
                 {
                     MessageBox.Show("PRODUCTO");
                 }*/




                //Codigo para facturar folio
                //Olivia Vicente Tinoco 0901-13-194
                if (tipo_fact == "folio")
                {
                    if (string.IsNullOrWhiteSpace(cbo_empre.Text) || string.IsNullOrWhiteSpace(cbo_serie.Text) || string.IsNullOrWhiteSpace(cbo_vendedor.Text))
                        MessageBox.Show("Campo obligatorio vacío", "Campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {

                        ClsFactura fact = new ClsFactura();

                        //Obteniendo Id de empresa
                        OdbcConnection conectar = seguridad.Conexion.ObtenerConexionODBC();
                        clsComun emp = new clsComun();
                        OdbcCommand _comando = new OdbcCommand(String.Format(
                             "SELECT id_empresa_pk FROM empresa where nombre ='{0}' ", cbo_empre.Text), conectar);
                        OdbcDataReader _reader = _comando.ExecuteReader();
                        while (_reader.Read())
                        {

                            fact.cod_emp = _reader.GetInt16(0); //Id empresa
                        }
                        conectar.Close();

                        fact.serie = cbo_serie.Text; //Serie

                        //Obteniendo Id de vendedor
                        OdbcConnection conectar1 = seguridad.Conexion.ObtenerConexionODBC();
                        clsComun vend = new clsComun();
                        OdbcCommand _comando1 = new OdbcCommand(String.Format(
                             "SELECT id_empleados_pk FROM empleado where nombre ='{0}' ", cbo_vendedor.Text), conectar1);
                        OdbcDataReader _reader1 = _comando1.ExecuteReader();
                        while (_reader1.Read())
                        {

                            fact.cod_vendedor = _reader1.GetInt16(0); //Id vendedor
                        }
                        conectar1.Close();

                        fact.fec_ven = dpic_fecven.Text; //Fecha vencimiento;
                      //  MessageBox.Show(Convert.ToString(dpic_fecemi));
                        fact.fec_emision = dpic_fecemi.Text; //Fecha de emision 
                       // fact.estado_fact = cbo_estado.Text; //Estado de factura
                        fact.subtotal = Convert.ToDecimal(txt_subtot.Text); //Subtotal
                        fact.total = Convert.ToDecimal(txt_tot.Text); //Total
                        fact.cod_cte = FolAct.codcte; //Id del cliente



                        //CALCULADO IMPUESTO SOBRE EL SUBTOTAL
                        /*OdbcConnection conectar2 = seguridad.Conexion.ObtenerConexionODBC();
                        clsComun imp = new clsComun();
                        OdbcCommand _comando2 = new OdbcCommand(String.Format(
                             "SELECT id_impuesto_pk FROM impuesto where nombre ='{0}' ", cbo_imp.Text), conectar2);
                        OdbcDataReader _reader2 = _comando2.ExecuteReader();
                        while (_reader2.Read())
                        {

                            fact.cod_imp = _reader2.GetInt16(0); //Id impuestp
                        }
                        conectar2.Close();
                        */
                        /*

                                                OdbcConnection conectar2 = seguridad.Conexion.ObtenerConexionODBC();
                                                clsComun imp = new clsComun();
                                                OdbcCommand _comando2 = new OdbcCommand(String.Format(
                                                     "SELECT SUM(impuesto.porcentaje) , parametros_fac.empresa FROM impuesto , parametros_fac where parametros_fac.empresa = '{0}' and parametros_fac.id_impuesto = impuesto.id_impuesto_pk ", fact.cod_emp), conectar2);
                                                OdbcDataReader _reader2 = _comando2.ExecuteReader();
                                                while (_reader2.Read())
                                                {

                                                    fact.cod_imp = _reader2.GetInt16(0); //Id impuestp
                                                }
                                                conectar2.Close();
                                                decimal subt = Convert.ToDecimal(txt_subtot.Text);
                                                decimal impu = subt * (fact.cod_imp / 100);
                                                cbo_imp.Text = Convert.ToString(impu);

                                                decimal total = subt + impu;
                                                txt_tot.Text = Convert.ToString(total);


                                            */
                        fact.cod_imp = Convert.ToDecimal(cbo_imp.Text);
                        int iresultado = ClsOpFact.AgregarFact(fact); //Enviando a facturar encabezado
                        if (iresultado > 0)
                        {
                            //MessageBox.Show("Encabezado de factura guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Insertando en detalle de factura 
                            int filas = dgv_detallefact.RowCount;


                            //Obteniendo el ultimo Id de insertar, para insertar detalle_Fact
                            OdbcConnection conectar3 = seguridad.Conexion.ObtenerConexionODBC();
                            clsComun imp3 = new clsComun();
                            OdbcCommand _comando3 = new OdbcCommand(String.Format(
                                 "SELECT MAX(id_fac_empresa_pk) from factura "), conectar3);
                            OdbcDataReader _reader3 = _comando3.ExecuteReader();
                            while (_reader3.Read())
                            {

                                imp3.cod = _reader3.GetInt16(0); //Id impuestp
                            }
                            conectar3.Close();

                            //Codigo para recorrer grid e insertar a detalle factura

                            for (int f = 0; f < filas; f++)
                            {


                                ClsDetalleFact defact = new ClsDetalleFact();
                                defact.cod_fact = imp3.cod;
                                defact.cod_emp = fact.cod_emp;
                                defact.serie = fact.serie;
                                defact.cod_bien = Convert.ToInt16(dgv_detallefact.Rows[f].Cells[0].Value);
                                defact.cantidad = Convert.ToInt16(dgv_detallefact.Rows[f].Cells[1].Value);
                                //MessageBox.Show(Convert.ToString(defact.cantidad));
                                defact.descripcion = Convert.ToString(dgv_detallefact.Rows[f].Cells[2].Value);
                                defact.prec = Convert.ToInt16(dgv_detallefact.Rows[f].Cells[3].Value);
                                defact.subtotal = Convert.ToInt16(dgv_detallefact.Rows[f].Cells[4].Value);

                                int iresultado1 = ClsOpFact.AgregarDetFact(defact);
                                if (iresultado1 > 0)
                                {
                                    //MessageBox.Show("Detalle insertado correctamente");



                                }
                                else
                                {
                                    MessageBox.Show("No se inserto detalle");
                                }




                            }
                            //Actualizando folio
                            clsFolio folio = new clsFolio();
                            folio.estado = "Cancelado";
                            folio.fec_pago = dpic_fecemi.Text;
                            folio.cod = FolAct.cod;
                            //MessageBox.Show(Convert.ToString(folio.cod));
                            ClsOpFolio.ActualizarFolio(folio);


                            //Insertando en tabla folio-factura
                            ClsFactura factu = new ClsFactura();
                            factu.cod_fact = imp3.cod;
                            MessageBox.Show(Convert.ToString(factu.cod_fact));
                            factu.cod_emp = fact.cod_emp;
                            factu.serie = cbo_serie.Text;
                            ClsOpFact.AgregarDetFactFol(factu, folio);

                            //Insertando en tabla de deuda
                            cls_deuda deuda = new cls_deuda();
                            deuda.monto = txt_tot.Text;
                            deuda.saldo = txt_tot.Text;
                            deuda.codclte = fact.cod_cte;
                            deuda.codfac = imp3.cod;
                            deuda.codemp = fact.cod_emp;
                            deuda.serie = cbo_serie.Text;
                            clsOdeuda.Agregar(deuda);


                            //Limpiando Textbox.. 
                            cbo_empre.Text = "";
                            cbo_serie.Text="";
                            cbo_vendedor.Text = "";
                            txt_nombre.Clear();
                            txt_nit.Clear();
                            txt_dir.Clear();
                            dpic_fecemi.Text = "";
                            dpic_fecven.Text = "";
                            cbo_formpago.Text = "";
                            txt_prod.Clear();
                            txt_cant.Clear();
                            txt_precio.Clear();
                            cbo_imp.Text = "";
                            txt_subtot.Clear();
                            txt_tot.Clear();
                            //dgv_detallefact.Rows.Clear();
                            //dgv_detallefact.Refresh();


                        }

                        else
                        {
                            MessageBox.Show("No se pudo guardar el encabezado de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        cbo_empre.Text = "";
                        cbo_serie.Text = "";
                        cbo_vendedor.Text = "";
                        txt_nombre.Clear();
                        txt_nit.Clear();
                        txt_dir.Clear();
                        dpic_fecemi.Text = "";
                        dpic_fecven.Text = "";
                        cbo_formpago.Text = "";
                        txt_prod.Clear();
                        txt_cant.Clear();
                        txt_precio.Clear();
                        cbo_imp.Text = "";
                        txt_subtot.Clear();
                        txt_tot.Clear();
                        dgv_detallefact.Rows.Clear();
                        dgv_detallefact.Refresh();

                    }
                }
                else//cerraando if folio,..abriendo else if pedido
                {
                    //Codigo para facturar pedido
                    //Olivia Vicente Tinoco 0901-13-194
                    if (tipo_fact == "pedido")
                    {
                       // MessageBox.Show("PEDIDOOOO");
                        if (string.IsNullOrWhiteSpace(cbo_empre.Text) || string.IsNullOrWhiteSpace(cbo_serie.Text) || string.IsNullOrWhiteSpace(cbo_vendedor.Text))
                            MessageBox.Show("Campo obligatorio vacío", "Campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                        {

                            ClsFactura fact = new ClsFactura();

                            //Obteniendo Id de empresa
                            OdbcConnection conectar = seguridad.Conexion.ObtenerConexionODBC();
                            clsComun emp = new clsComun();
                            OdbcCommand _comando = new OdbcCommand(String.Format(
                                 "SELECT id_empresa_pk FROM empresa where nombre ='{0}' ", cbo_empre.Text), conectar);
                            OdbcDataReader _reader = _comando.ExecuteReader();
                            while (_reader.Read())
                            {

                                fact.cod_emp = _reader.GetInt16(0); //Id empresa
                            }
                            conectar.Close();

                            fact.serie = cbo_serie.Text; //Serie

                            //Obteniendo Id de vendedor
                            OdbcConnection conectar1 = seguridad.Conexion.ObtenerConexionODBC();
                            clsComun vend = new clsComun();
                            OdbcCommand _comando1 = new OdbcCommand(String.Format(
                                 "SELECT id_empleados_pk FROM empleado where nombre ='{0}' ", cbo_vendedor.Text), conectar1);
                            OdbcDataReader _reader1 = _comando1.ExecuteReader();
                            while (_reader1.Read())
                            {

                                fact.cod_vendedor = _reader1.GetInt16(0); //Id vendedor
                            }
                            conectar1.Close();

                            

                            fact.fec_ven = dpic_fecven.Text; //Fecha vencimiento;
                            fact.fec_emision = dpic_fecemi.Text; //Fecha de emision 
                           // fact.estado_fact = cbo_estado.Text; //Estado de factura
                            fact.subtotal = Convert.ToDecimal(txt_subtot.Text); //Subtotal
                            fact.total = Convert.ToDecimal(txt_tot.Text); //Total
                            fact.cod_cte = PedAct.codcte; //Id del cliente



                            //Obteniendo Id de impuesto
                           /* OdbcConnection conectar2 = seguridad.Conexion.ObtenerConexionODBC();
                            clsComun imp = new clsComun();
                            OdbcCommand _comando2 = new OdbcCommand(String.Format(
                                 "SELECT id_impuesto_pk FROM impuesto where nombre ='{0}' ", cbo_imp.Text), conectar2);
                            OdbcDataReader _reader2 = _comando2.ExecuteReader();
                            while (_reader2.Read())
                            {

                                fact.cod_imp = _reader2.GetInt16(0); //Id impuestp
                            }
                            conectar2.Close();
                            */
                            fact.cod_imp = Convert.ToDecimal(cbo_imp.Text);

                            int iresultado = ClsOpFact.AgregarFact(fact);
                            if (iresultado > 0)
                            {
                                MessageBox.Show("Encabezado de factura guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Insertando en detalle de factura 
                                int filas = dgv_detallefact.RowCount;


                                //Obteniendo el ultimo Id para insertar detalle_Fact
                                OdbcConnection conectar3 = seguridad.Conexion.ObtenerConexionODBC();
                                clsComun imp3 = new clsComun();
                                OdbcCommand _comando3 = new OdbcCommand(String.Format(
                                     "SELECT MAX(id_fac_empresa_pk) from factura "), conectar3);
                                OdbcDataReader _reader3 = _comando3.ExecuteReader();
                                while (_reader3.Read())
                                {

                                    imp3.cod = _reader3.GetInt16(0); //Id impuestp
                                }
                                conectar3.Close();

                                //Recorriendo Grid para insertar en detalle_fact
                                for (int f = 0; f < filas; f++)
                                {
                                    ClsDetalleFact defact = new ClsDetalleFact();
                                    defact.cod_fact = imp3.cod;
                                    defact.cod_emp = fact.cod_emp;
                                    defact.serie = fact.serie;
                                    defact.cod_bien = Convert.ToInt16(dgv_detallefact.Rows[f].Cells[0].Value);
                                    defact.cantidad = Convert.ToInt16(dgv_detallefact.Rows[f].Cells[1].Value);
                                    //MessageBox.Show(Convert.ToString(defact.cantidad));
                                    defact.descripcion = Convert.ToString(dgv_detallefact.Rows[f].Cells[2].Value);
                                    defact.prec = Convert.ToInt16(dgv_detallefact.Rows[f].Cells[3].Value);
                                    defact.subtotal = Convert.ToInt16(dgv_detallefact.Rows[f].Cells[4].Value);

                                    int iresultado1 = ClsOpFact.AgregarDetFact(defact);
                                    if (iresultado1 > 0)
                                    {
                                        //MessageBox.Show("Detalle insertado correctamente");



                                    }
                                    else
                                    {
                                        //MessageBox.Show("No se inserto detalle");
                                    }
                                }

                                //Actualizando pedido
                                ClsPedido pedido = new ClsPedido();
                                pedido.estado = "Cancelado";

                                pedido.codped = PedAct.codped;
                                //MessageBox.Show(Convert.ToString(folio.cod));
                                ClsOpPedido.ActualizarPedido(pedido);


                                //Insertando en tabla pedido-factura
                                ClsFactura factu = new ClsFactura();
                                factu.cod_fact = imp3.cod;
                              //  MessageBox.Show(Convert.ToString(factu.cod_fact));
                                factu.cod_emp = fact.cod_emp;
                                factu.serie = cbo_serie.Text;
                                ClsOpFact.AgregarDetFactPed(factu, pedido);


                                //Insertando en tabla de deuda
                                cls_deuda deuda = new cls_deuda();
                                deuda.monto = txt_tot.Text;
                                deuda.saldo = txt_tot.Text;
                                deuda.codclte = fact.cod_cte;
                                deuda.codfac = imp3.cod;
                                deuda.codemp = fact.cod_emp;
                                deuda.serie = cbo_serie.Text;
                                clsOdeuda.Agregar(deuda);
                                cbo_empre.Text = "";
                                cbo_serie.Text = "";
                                cbo_vendedor.Text = "";
                                txt_nombre.Clear();
                                txt_nit.Clear();
                                txt_dir.Clear();
                                dpic_fecemi.Text = "";
                                dpic_fecven.Text = "";
                                cbo_formpago.Text = "";
                                txt_prod.Clear();
                                txt_cant.Clear();
                                txt_precio.Clear();
                                cbo_imp.Text = "";
                                txt_subtot.Clear();
                                txt_tot.Clear();
                             //   dgv_detallefact.Rows.Clear();
                               // dgv_detallefact.Refresh();

                            }
                            else
                            {
                                MessageBox.Show("No se pudo guardar el encabezado de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cbo_empre.Text = "";
                                cbo_serie.Text = "";
                                cbo_vendedor.Text = "";
                                txt_nombre.Clear();
                                txt_nit.Clear();
                                txt_dir.Clear();
                                dpic_fecemi.Text = "";
                                dpic_fecven.Text = "";
                                cbo_formpago.Text = "";
                                txt_prod.Clear();
                                txt_cant.Clear();
                                txt_precio.Clear();
                                cbo_imp.Text = "";
                                txt_subtot.Clear();
                                txt_tot.Clear();
                               // dgv_detallefact.Rows.Clear();
                                //dgv_detallefact.Refresh();

                            }



                        } //CIERRA IF PEDIDO ..abrir else if producto
                    }
                    else

                    //Sammy Salazar
                    //FACTURAR PRODUCTOS


                        if (tipo_fact == "prod") 
                    {
                        btn_bproducto.Enabled = true;
                        if (string.IsNullOrWhiteSpace(cbo_empre.Text) || string.IsNullOrWhiteSpace(cbo_serie.Text) || string.IsNullOrWhiteSpace(cbo_vendedor.Text))
                            MessageBox.Show("Campo obligatorio vacío", "Campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                        {
                            ClsFactura fact = new ClsFactura();

                            //Obteniendo Id de empresa
                            OdbcConnection conectar = seguridad.Conexion.ObtenerConexionODBC();
                            clsComun emp = new clsComun();
                            OdbcCommand _comando = new OdbcCommand(String.Format(
                                 "SELECT id_empresa_pk FROM empresa where nombre ='{0}' ", cbo_empre.Text), conectar);
                            OdbcDataReader _reader = _comando.ExecuteReader();
                            while (_reader.Read())
                            {
                                fact.cod_emp = _reader.GetInt16(0); //Id empresa
                            }
                            conectar.Close();

                            fact.serie = cbo_serie.Text; //Serie

                            //Obteniendo Id de vendedor
                            OdbcConnection conectar1 = seguridad.Conexion.ObtenerConexionODBC();
                            clsComun vend = new clsComun();
                            OdbcCommand _comando1 = new OdbcCommand(String.Format(
                                 "SELECT id_empleados_pk FROM empleado where nombre ='{0}' ", cbo_vendedor.Text), conectar1);
                            OdbcDataReader _reader1 = _comando1.ExecuteReader();
                            while (_reader1.Read())
                            {

                                fact.cod_vendedor = _reader1.GetInt16(0); //Id vendedor
                            }
                            conectar1.Close();

                            fact.fec_ven = dpic_fecven.Text; //Fecha vencimiento;
                            fact.fec_emision = dpic_fecemi.Text; //Fecha de emision 
                          //  fact.estado_fact = cbo_estado.Text; //Estado de factura
                            fact.subtotal = Convert.ToDecimal(txt_subtot.Text); //Subtotal
                            fact.total = Convert.ToDecimal(txt_tot.Text); //Total
                            fact.cod_cte = codigoclte; //Id del cliente
                            

                            //Obteniendo Id de impuesto
                            OdbcConnection conectar2 = seguridad.Conexion.ObtenerConexionODBC();
                            clsComun imp = new clsComun();
                            OdbcCommand _comando2 = new OdbcCommand(String.Format(
                                 "SELECT id_impuesto_pk FROM impuesto where nombre ='{0}' ", cbo_imp.Text), conectar2);
                            OdbcDataReader _reader2 = _comando2.ExecuteReader();
                            while (_reader2.Read())
                            {

                                fact.cod_imp = _reader2.GetInt16(0); //Id impuestp
                            }
                            conectar2.Close();

                            int iresultado = ClsOpFact.AgregarFact(fact);
                            if (iresultado > 0)
                            {
                                //MessageBox.Show("Encabezado de factura guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Insertando en detalle de factura 
                                int filas = dgv_detallefact.RowCount;

                                //Obteniendo el ultimo Id para insertar detalle_Fact
                                OdbcConnection conectar3 = seguridad.Conexion.ObtenerConexionODBC();
                                clsComun imp3 = new clsComun();
                                OdbcCommand _comando3 = new OdbcCommand(String.Format(
                                     "SELECT MAX(id_fac_empresa_pk) from factura "), conectar3);
                                OdbcDataReader _reader3 = _comando3.ExecuteReader();
                                while (_reader3.Read())
                                {

                                    imp3.cod = _reader3.GetInt16(0); //Id impuestp
                                }
                                conectar3.Close();

                                for (int f = 0; f < filas; f++)
                                {
                                    ClsDetalleFact defact = new ClsDetalleFact();
                                    defact.cod_fact = imp3.cod;
                                    defact.cod_emp = fact.cod_emp;
                                    defact.serie = fact.serie;
                                    defact.cod_bien = Convert.ToInt32(dgv_detallefact.Rows[f].Cells[0].Value);
                                    defact.descripcion = Convert.ToString(dgv_detallefact.Rows[f].Cells[1].Value);
                                    defact.prec = Convert.ToInt32(Convert.ToDecimal(dgv_detallefact.Rows[f].Cells[3].Value));
                                    defact.cantidad = Convert.ToInt32(dgv_detallefact.Rows[f].Cells[4].Value);
                                    defact.subtotal = Convert.ToInt32(dgv_detallefact.Rows[f].Cells[5].Value);

                                    int iresultado1 = ClsOpFact.AgregarDetFact(defact);
                                    if (iresultado1 > 0)
                                    {
                                        //MessageBox.Show("Detalle insertado correctamente");
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se inserto detalle");
                                    }

                                }
                                //Insertando en tabla de deuda
                                cls_deuda deuda = new cls_deuda();
                                deuda.monto = txt_tot.Text;
                                deuda.saldo = txt_tot.Text;
                                deuda.codclte = fact.cod_cte;
                                deuda.codfac = imp3.cod;
                                deuda.codemp = fact.cod_emp;
                                deuda.serie = cbo_serie.Text;
                                clsOdeuda.Agregar(deuda);

                                cbo_empre.Text = "";
                                cbo_serie.Text = "";
                                cbo_vendedor.Text = "";
                                txt_nombre.Clear();
                                txt_nit.Clear();
                                txt_dir.Clear();
                                dpic_fecemi.Text = "";
                                dpic_fecven.Text = "";
                                cbo_formpago.Text = "";
                                txt_prod.Clear();
                                txt_cant.Clear();
                                txt_precio.Clear();
                                cbo_imp.Text = "";
                                txt_subtot.Clear();
                                txt_tot.Clear();
                              //  dgv_detallefact.Rows.Clear();
                                //dgv_detallefact.Refresh();


                            }


                            else
                            {
                                MessageBox.Show("No se pudo guardar el encabezado de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cbo_empre.Text = "";
                                cbo_serie.Text = "";
                                cbo_vendedor.Text = "";
                                txt_nombre.Clear();
                                txt_nit.Clear();
                                txt_dir.Clear();
                                dpic_fecemi.Text = "";
                                dpic_fecven.Text = "";
                                cbo_formpago.Text = "";
                                txt_prod.Clear();
                                txt_cant.Clear();
                                txt_precio.Clear();
                                cbo_imp.Text = "";
                                txt_subtot.Clear();
                                txt_tot.Clear();
                                //dgv_detallefact.Rows.Clear();
                               // dgv_detallefact.Refresh();


                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void check_prod_CheckedChanged(object sender, EventArgs e)
        {
            check_pre.Enabled = false;
            check_fol.Enabled = false;
            llenar_encabezado();
        }

        public ClsPedido PedAct { get; set; }
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            //Codigo para buscar pedido, extrar datos e ingresarlos a factura
            //Olivia Vicente Tinoco 0901-13-194
            try
            {
                BuscPedido temp = new BuscPedido();
                temp.ShowDialog();
                if (temp.PedSelec != null)
                {
                    PedAct = temp.PedSelec;

                    dgv_detallefact.DataSource = ClsOpPedido.BuscardetallePed(PedAct.codemp, PedAct.codped);


                    OdbcConnection conectar = seguridad.Conexion.ObtenerConexionODBC();
                    cls_cliente cte = new cls_cliente();
                    OdbcCommand _comando = new OdbcCommand(String.Format(
                    "SELECT nombre, apellido, direccion, nit, id_empleado_pk, dias_cred FROM cliente where id_cliente_pk ='{0}' ", PedAct.codcte), conectar);
                    OdbcDataReader _reader = _comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        cte.nombre = _reader.GetString(0);
                        cte.apellido = _reader.GetString(1);
                        cte.dire = _reader.GetString(2);
                        cte.nit = _reader.GetString(3);
                        cte.codven = _reader.GetInt16(4);
                        cte.dias_cre = _reader.GetInt16(5);
                    }
                    txt_nombre.Text = cte.nombre + " " + cte.apellido;
                    txt_nit.Text = cte.nit;
                    txt_dir.Text = cte.dire;
                    cte_fol = cte;


                    OdbcConnection conectar3 = seguridad.Conexion.ObtenerConexionODBC();
                    clsComun emp1 = new clsComun();
                    OdbcCommand _comando1 = new OdbcCommand(String.Format(
                         "SELECT nombre FROM empresa where id_empresa_pk ='{0}' ", PedAct.codemp), conectar3);
                    OdbcDataReader _reader1 = _comando1.ExecuteReader();
                    while (_reader1.Read())
                    {

                        emp1.nombre = _reader1.GetString(0);
                    }

                    cbo_empre.Text = emp1.nombre;
                    cbo_empre.Enabled = false;
                    conectar3.Close();

                    OdbcConnection conectar4 = seguridad.Conexion.ObtenerConexionODBC();

                    OdbcCommand _mcd2 = new OdbcCommand(String.Format("select * from empleado  where id_empleados_pk ='{0}'", cte.codven), conectar4);

                    OdbcDataReader mdr2 = _mcd2.ExecuteReader();
                    while (mdr2.Read())
                    {
                        // cbo_vendedor.Items.Add(mdr2.GetString(1));
                        cbo_vendedor.Text = mdr2.GetString(1);

                    }
                    cbo_vendedor.Enabled = false;

                    conectar4.Close();


                }



                int filas = dgv_detallefact.RowCount;
                decimal sub = 0;
                for (int f = 0; f < filas; f++)
                {
                    sub += Convert.ToDecimal(dgv_detallefact.Rows[f].Cells[4].Value);

                }


                txt_subtot.Text = Convert.ToString(sub);
                txt_tot.Text = Convert.ToString(sub);

                ClsFactura factu1 = new ClsFactura();
                OdbcConnection conectar7 = seguridad.Conexion.ObtenerConexionODBC();
                clsComun emp = new clsComun();
                OdbcCommand _comando7 = new OdbcCommand(String.Format(
                     "SELECT id_empresa_pk FROM empresa where nombre ='{0}' ", cbo_empre.Text), conectar7);
                OdbcDataReader _reader7 = _comando7.ExecuteReader();
                while (_reader7.Read())
                {

                    factu1.cod_emp = _reader7.GetInt16(0); //Id empresa
                }
                conectar7.Close();


                OdbcConnection conectar2 = seguridad.Conexion.ObtenerConexionODBC();
                clsComun imp = new clsComun();
                OdbcCommand _comando2 = new OdbcCommand(String.Format(
                     "SELECT SUM(impuesto.porcentaje) , parametros_fac.empresa FROM impuesto , parametros_fac where parametros_fac.empresa = '{0}' and parametros_fac.id_impuesto = impuesto.id_impuesto_pk ", factu1.cod_emp), conectar2);
                OdbcDataReader _reader2 = _comando2.ExecuteReader();
                while (_reader2.Read())
                {
                    impu_prod = _reader2.GetInt32(0); //Id impuestp
                }
                conectar2.Close();
                decimal subt = Convert.ToDecimal(txt_subtot.Text);

                decimal impue = subt * impu_prod;
               // MessageBox.Show(Convert.ToString(impue));

                cbo_imp.Text = Convert.ToString(impue);

                decimal total = subt + impue;
                txt_tot.Text = Convert.ToString(total);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void llenar_encabezado()
        {
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "Codigo";
            c1.Width = 100;
            c1.ReadOnly = true;

            dgv_detallefact.Columns.Add(c1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "Nombre";
            c2.Width = 50;
            c2.ReadOnly = true;

            dgv_detallefact.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "Costo";
            c3.Width = 50;
            c3.ReadOnly = true;

            dgv_detallefact.Columns.Add(c3);

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.HeaderText = "Precio";
            c4.Width = 50;
            c4.ReadOnly = true;

            dgv_detallefact.Columns.Add(c4);

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.HeaderText = "Cantidad";
            c5.Width = 50;
            c5.ReadOnly = true;

            dgv_detallefact.Columns.Add(c5);

            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.HeaderText = "Subtotal";
            c6.Width = 50;
            c6.ReadOnly = true;

            dgv_detallefact.Columns.Add(c6);

            DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            c6.HeaderText = "Cod.Bodega";
            c6.Width = 50;
            c6.ReadOnly = true;

            dgv_detallefact.Columns.Add(c7);
        }


        public ClsListadoPrecio pre { get; set; }
        public static String codigos;
        public static String costos;
        public void btn_bproducto_Click(object sender, EventArgs e)
        {
            try
            {
               
                frmbusclistaprecio buscl = new frmbusclistaprecio(codigo);
                buscl.ShowDialog();

                
               if (buscl.listpr != null)
                {
                    pre = buscl.listpr;
                   // MessageBox.Show(buscl.listpr.descripcion);
                    txt_prod.Text = buscl.listpr.descripcion;
                    txt_precio.Text = Convert.ToString(buscl.listpr.precio);
                    //double prec = Convert.ToDouble(txt_precio.Text);

                    costos = Convert.ToString(buscl.listpr.costo);
                    codigos = Convert.ToString(buscl.listpr.codbien);
                    /*double prec2 = Convert.ToDouble(Convert.ToString(txt_cant));
                    double subtotal = prec * prec2;*/


                   

                    //dgv_detallefact.Rows.Add(buscl.listpr.codbien, buscl.listpr.descripcion, buscl.listpr.costo, buscl.listpr.precio);//, txt_cant.Text, subtotal);
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_nuevo_Click_1(object sender, EventArgs e)
        {
            cbo_empre.Text = "";
            cbo_serie.Text = "";
            cbo_vendedor.Text = "";
            txt_nombre.Clear();
            txt_nit.Clear();
            txt_dir.Clear();
            dpic_fecemi.Text = "";
            dpic_fecven.Text = "";
            cbo_formpago.Text = "";
            txt_prod.Clear();
            txt_cant.Clear();
            txt_precio.Clear();
            cbo_imp.Text = "";
            txt_subtot.Clear();
            txt_tot.Clear();
            // dgv_detallefact.Rows.Clear();
            //dgv_detallefact.Refresh();
            btn_bproducto.Enabled = false;
            btn_Buscte.Enabled = true;
            btn_busfolio.Enabled = false;
            btn_busped.Enabled = false;
            cbo_vendedor.Enabled = false;
            txt_nombre.Enabled = false;
            txt_nit.Enabled = false;
            txt_dir.Enabled = false;
            

        }





        public void calcular()
        {
            ClsFactura factu1 = new ClsFactura();
            OdbcConnection conectar = seguridad.Conexion.ObtenerConexionODBC();
            clsComun emp = new clsComun();
            OdbcCommand _comando = new OdbcCommand(String.Format(
                 "SELECT id_empresa_pk FROM empresa where nombre ='{0}' ", cbo_empre.Text), conectar);
            OdbcDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {

                factu1.cod_emp = _reader.GetInt16(0); //Id empresa
            }
            conectar.Close();

            int filas = dgv_detallefact.RowCount;
            decimal sub = 0;
            for (int f = 0; f < filas; f++)
            {
                sub += Convert.ToDecimal(dgv_detallefact.Rows[f].Cells[5].Value);

            }


            txt_subtot.Text = Convert.ToString(sub);
            txt_tot.Text = Convert.ToString(sub);


            OdbcConnection conectar2 = seguridad.Conexion.ObtenerConexionODBC();
            clsComun imp = new clsComun();
            OdbcCommand _comando2 = new OdbcCommand(String.Format(
                 "SELECT SUM(impuesto.porcentaje) , parametros_fac.empresa FROM impuesto , parametros_fac where parametros_fac.empresa = '{0}' and parametros_fac.id_impuesto = impuesto.id_impuesto_pk ", factu1.cod_emp), conectar2);
            OdbcDataReader _reader2 = _comando2.ExecuteReader();
            while (_reader2.Read())
            {

                impu_fol = _reader2.GetDecimal(0); //Id impuestp
            }
            conectar2.Close();
            decimal subt = sub;

            decimal impue = subt * impu_fol;
            MessageBox.Show(Convert.ToString(impue));

            cbo_imp.Text = Convert.ToString(impue);

            decimal total = subt + impue;
            txt_tot.Text = Convert.ToString(total);
        }

        public void btn_agrega_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_prod.Text) || string.IsNullOrWhiteSpace(txt_cant.Text) || string.IsNullOrWhiteSpace(txt_precio.Text))
                MessageBox.Show("Campo obligatorio vacío", "Campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                frmDescontando des = new frmDescontando(Convert.ToInt32(codigos), Convert.ToInt32(txt_cant.Text));
                des.ShowDialog();

                //MessageBox.Show(Convert.ToString(frmDescontando.idbod));


                if (des != null)
                {
                    double prec = Convert.ToDouble(txt_precio.Text);
                    double prec2 = Convert.ToDouble(Convert.ToString(txt_cant.Text));
                    double subtotal = prec * prec2;
                    dgv_detallefact.Rows.Add(codigos, txt_prod.Text, costos, txt_precio.Text, txt_cant.Text, subtotal, frmDescontando.idbod);
                    cantidad = Convert.ToInt32(txt_cant.Text);
                    calcular();
                }
                //else MessageBox.Show("vacio");
            }
        }

        private void dpic_fecemi_ValueChanged(object sender, EventArgs e)
        {
            //Sumando dias de credito a fecha de factura, para calcular fecha de vencimiento
            if (cte_fol != null)
            {
                int dias = cte_fol.dias_cre;
                DateTime fec = Convert.ToDateTime(dpic_fecemi.Text);
                MessageBox.Show(Convert.ToString(cte_fol.dias_cre));

                DateTime fec_venci;
                fec_venci = fec.AddDays(cte_fol.dias_cre);

                //MessageBox.Show(Convert.ToString(fec_venci));
                dpic_fecven.Text = Convert.ToString(fec_venci);
                dpic_fecven.Enabled = false;
            }
            else
            {
                if(dias_cte != 0)
                {
                    int dias = dias_cte; ;
                    DateTime fec = Convert.ToDateTime(dpic_fecemi.Text);
                    //MessageBox.Show(Convert.ToString(fec));

                    DateTime fec_venci;
                    fec_venci = fec.AddDays(dias);

                    //MessageBox.Show(Convert.ToString(fec_venci));
                    dpic_fecven.Text = Convert.ToString(fec_venci);
                    dpic_fecven.Enabled = false;
                }
            }
        }

        private void dgv_detallefact_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        
      
        //Sammy Salazar
        //Eliminar registro en datagrid actualizado
        private void dgv_detallefact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 08)
            {
                 
                int fil = dgv_detallefact.CurrentRow.Index;
                //MessageBox.Show(Convert.ToString(ult));
                
                dgv_detallefact.Rows.RemoveAt(fil);

                dgv_detallefact.ClearSelection();

                int ult = dgv_detallefact.RowCount - 2;

                //dgv_detallefact.Rows.Remove(dgv_detallefact.Rows[ult]);
                calcular();

            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_nombre.Text))
                    MessageBox.Show("Campo obligatorio vacío", "Campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {




                    int iresultado = ClsOpFact.EliminarEncabeDevo(idFactAct);
                    int re = ClsOpFact.EliminarDetalleDevo(idFactAct);
                    if (iresultado > 0)
                    {
                        MessageBox.Show("Factura Anulada Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo anular la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ayuda_Click(object sender, EventArgs e)
        {
            string ruta = "Manual_Facturacion.pdf";
            ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.FileName = "AcroRd32.exe";
            startinfo.Arguments = ruta;
            Process.Start(startinfo);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txt_tot_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

