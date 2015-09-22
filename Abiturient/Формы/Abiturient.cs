﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Abiturient
{
    public partial class Abiturient : Form
    {
        protected string connectionstring;
        private Generation_Class generation_class;

        public Abiturient(string connectionstring)
        {
            InitializeComponent();
            this.connectionstring = connectionstring;
            generation_class = new Generation_Class(this.connectionstring);
        }

        private void BTN_generation_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(TB_abit.Text);
            string nameTable = "Abiturient";
            string parametr = "fio";
            string name = "Абитуриент";
            generation_class.genAdd(n, nameTable, parametr, DGV_abiturient, name);
            generation_class.writerTableStaudent(nameTable, DGV_abiturient);
        }   

        private void Abiturient_Load(object sender, EventArgs e)
        {
            try
            {
                string nameTable = "Abiturient";
                generation_class.writerTableStaudent(nameTable, DGV_abiturient);
            }
            catch
            {
                MessageBox.Show("Таблица пуста! Заполните ее!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generation_class.delete("Abiturient");
            DGV_abiturient.Rows.Clear();

        }
    }
}
