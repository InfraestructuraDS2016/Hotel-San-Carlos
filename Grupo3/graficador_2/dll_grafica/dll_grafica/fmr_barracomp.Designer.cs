﻿namespace dll_grafica
{
    partial class fmr_barracomp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmr_barracomp));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_x = new System.Windows.Forms.Button();
            this.btn_y = new System.Windows.Forms.Button();
            this.dgv_datos = new System.Windows.Forms.DataGridView();
            this.btn_acpt = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgv_datos2 = new System.Windows.Forms.DataGridView();
            this.btn_acpt2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btn_grafigen = new System.Windows.Forms.Button();
            this.btn_cambiar = new System.Windows.Forms.Button();
            this.btn_validar = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.cbo_msem = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbo_mmes2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbo_mmes = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ames = new System.Windows.Forms.TextBox();
            this.cbo_ssem = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_asem = new System.Windows.Forms.TextBox();
            this.btn_historico = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Titulo del Grafico";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 12;
            // 
            // btn_x
            // 
            this.btn_x.Location = new System.Drawing.Point(874, 352);
            this.btn_x.Name = "btn_x";
            this.btn_x.Size = new System.Drawing.Size(75, 23);
            this.btn_x.TabIndex = 7;
            this.btn_x.Text = "X";
            this.btn_x.UseVisualStyleBackColor = true;
            this.btn_x.Click += new System.EventHandler(this.btn_x_Click);
            // 
            // btn_y
            // 
            this.btn_y.Location = new System.Drawing.Point(609, 352);
            this.btn_y.Name = "btn_y";
            this.btn_y.Size = new System.Drawing.Size(75, 23);
            this.btn_y.TabIndex = 6;
            this.btn_y.Text = "Y";
            this.btn_y.UseVisualStyleBackColor = true;
            this.btn_y.Click += new System.EventHandler(this.btn_y_Click);
            // 
            // dgv_datos
            // 
            this.dgv_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datos.Location = new System.Drawing.Point(12, 159);
            this.dgv_datos.Name = "dgv_datos";
            this.dgv_datos.Size = new System.Drawing.Size(491, 184);
            this.dgv_datos.TabIndex = 4;
            // 
            // btn_acpt
            // 
            this.btn_acpt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_acpt.BackgroundImage")));
            this.btn_acpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_acpt.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_acpt.Location = new System.Drawing.Point(315, 95);
            this.btn_acpt.Name = "btn_acpt";
            this.btn_acpt.Size = new System.Drawing.Size(60, 60);
            this.btn_acpt.TabIndex = 1;
            this.btn_acpt.UseVisualStyleBackColor = true;
            this.btn_acpt.Click += new System.EventHandler(this.btn_acpt_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(172, 118);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgv_datos2
            // 
            this.dgv_datos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datos2.Location = new System.Drawing.Point(521, 159);
            this.dgv_datos2.Name = "dgv_datos2";
            this.dgv_datos2.Size = new System.Drawing.Size(491, 184);
            this.dgv_datos2.TabIndex = 5;
            // 
            // btn_acpt2
            // 
            this.btn_acpt2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_acpt2.BackgroundImage")));
            this.btn_acpt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_acpt2.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_acpt2.Location = new System.Drawing.Point(761, 93);
            this.btn_acpt2.Name = "btn_acpt2";
            this.btn_acpt2.Size = new System.Drawing.Size(60, 60);
            this.btn_acpt2.TabIndex = 3;
            this.btn_acpt2.UseVisualStyleBackColor = true;
            this.btn_acpt2.Click += new System.EventHandler(this.btn_acpt2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(618, 116);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // btn_grafigen
            // 
            this.btn_grafigen.Location = new System.Drawing.Point(472, 396);
            this.btn_grafigen.Name = "btn_grafigen";
            this.btn_grafigen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_grafigen.Size = new System.Drawing.Size(100, 30);
            this.btn_grafigen.TabIndex = 11;
            this.btn_grafigen.Text = "Genera grafica";
            this.btn_grafigen.UseVisualStyleBackColor = true;
            this.btn_grafigen.Click += new System.EventHandler(this.btn_grafigen_Click);
            // 
            // btn_cambiar
            // 
            this.btn_cambiar.Location = new System.Drawing.Point(597, 398);
            this.btn_cambiar.Name = "btn_cambiar";
            this.btn_cambiar.Size = new System.Drawing.Size(100, 30);
            this.btn_cambiar.TabIndex = 8;
            this.btn_cambiar.Text = "Cambiar Eje";
            this.btn_cambiar.UseVisualStyleBackColor = true;
            this.btn_cambiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_validar
            // 
            this.btn_validar.Enabled = false;
            this.btn_validar.Location = new System.Drawing.Point(863, 398);
            this.btn_validar.Name = "btn_validar";
            this.btn_validar.Size = new System.Drawing.Size(100, 30);
            this.btn_validar.TabIndex = 9;
            this.btn_validar.Text = "Validar Eje";
            this.btn_validar.UseVisualStyleBackColor = true;
            this.btn_validar.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "X",
            "Y"});
            this.comboBox3.Location = new System.Drawing.Point(720, 404);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 10;
            // 
            // cbo_msem
            // 
            this.cbo_msem.FormattingEnabled = true;
            this.cbo_msem.Location = new System.Drawing.Point(203, 376);
            this.cbo_msem.Name = "cbo_msem";
            this.cbo_msem.Size = new System.Drawing.Size(47, 21);
            this.cbo_msem.TabIndex = 41;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(175, 431);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "-";
            // 
            // cbo_mmes2
            // 
            this.cbo_mmes2.FormattingEnabled = true;
            this.cbo_mmes2.Location = new System.Drawing.Point(203, 428);
            this.cbo_mmes2.Name = "cbo_mmes2";
            this.cbo_mmes2.Size = new System.Drawing.Size(47, 21);
            this.cbo_mmes2.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(199, 408);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 20);
            this.label11.TabIndex = 53;
            this.label11.Text = "Mes";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(199, 356);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 20);
            this.label12.TabIndex = 52;
            this.label12.Text = "Mes";
            // 
            // cbo_mmes
            // 
            this.cbo_mmes.FormattingEnabled = true;
            this.cbo_mmes.Location = new System.Drawing.Point(127, 428);
            this.cbo_mmes.Name = "cbo_mmes";
            this.cbo_mmes.Size = new System.Drawing.Size(47, 21);
            this.cbo_mmes.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(124, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 20);
            this.label8.TabIndex = 51;
            this.label8.Text = "Mes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(275, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "Año";
            // 
            // txt_ames
            // 
            this.txt_ames.Location = new System.Drawing.Point(278, 428);
            this.txt_ames.Name = "txt_ames";
            this.txt_ames.Size = new System.Drawing.Size(47, 20);
            this.txt_ames.TabIndex = 45;
            // 
            // cbo_ssem
            // 
            this.cbo_ssem.FormattingEnabled = true;
            this.cbo_ssem.Location = new System.Drawing.Point(127, 376);
            this.cbo_ssem.Name = "cbo_ssem";
            this.cbo_ssem.Size = new System.Drawing.Size(47, 21);
            this.cbo_ssem.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(275, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 49;
            this.label6.Text = "Año";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(124, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "Semana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 47;
            this.label3.Text = "Mensual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Semanal";
            // 
            // txt_asem
            // 
            this.txt_asem.Location = new System.Drawing.Point(278, 377);
            this.txt_asem.Name = "txt_asem";
            this.txt_asem.Size = new System.Drawing.Size(47, 20);
            this.txt_asem.TabIndex = 42;
            // 
            // btn_historico
            // 
            this.btn_historico.Location = new System.Drawing.Point(345, 397);
            this.btn_historico.Name = "btn_historico";
            this.btn_historico.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_historico.Size = new System.Drawing.Size(100, 30);
            this.btn_historico.TabIndex = 55;
            this.btn_historico.Text = "Crear Historico";
            this.btn_historico.UseVisualStyleBackColor = true;
            this.btn_historico.Click += new System.EventHandler(this.btn_historico_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(284, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(455, 32);
            this.label4.TabIndex = 62;
            this.label4.Text = "GRAFICA COMPUESTA DE BARRAS";
            // 
            // fmr_barracomp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1024, 461);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_historico);
            this.Controls.Add(this.cbo_msem);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbo_mmes2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbo_mmes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_ames);
            this.Controls.Add(this.cbo_ssem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_asem);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.btn_validar);
            this.Controls.Add(this.btn_cambiar);
            this.Controls.Add(this.btn_grafigen);
            this.Controls.Add(this.btn_acpt2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.dgv_datos2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_x);
            this.Controls.Add(this.btn_y);
            this.Controls.Add(this.dgv_datos);
            this.Controls.Add(this.btn_acpt);
            this.Controls.Add(this.comboBox1);
            this.Name = "fmr_barracomp";
            this.Text = "fmr_barracomp";
            this.Load += new System.EventHandler(this.fmr_barracomp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_x;
        private System.Windows.Forms.Button btn_y;
        private System.Windows.Forms.DataGridView dgv_datos;
        private System.Windows.Forms.Button btn_acpt;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgv_datos2;
        private System.Windows.Forms.Button btn_acpt2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btn_grafigen;
        private System.Windows.Forms.Button btn_cambiar;
        private System.Windows.Forms.Button btn_validar;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox cbo_msem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbo_mmes2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbo_mmes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_ames;
        private System.Windows.Forms.ComboBox cbo_ssem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_asem;
        private System.Windows.Forms.Button btn_historico;
        private System.Windows.Forms.Label label4;
    }
}