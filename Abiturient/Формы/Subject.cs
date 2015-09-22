using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SQLite;

namespace Abiturient
{
    public partial class Subject : Form
    {
        protected string connectionstring;
        private Generation_Class generation_class;
        public Subject(string connectionstring)
        {
            InitializeComponent();
            this.connectionstring = connectionstring;
            generation_class = new Generation_Class(this.connectionstring);
        }

        private void BTN_generation_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(TB_abit.Text);
            string nameTable = "Subject";
            string parametr = "name";
            string name = "Предмет";
            generation_class.GenAdd(n, nameTable, parametr, DGV_subject, name);
            generation_class.WriterTableStaudent(nameTable, DGV_subject);
        }

        private void Subject_Load(object sender, EventArgs e)
        {
            try
            {
                string nameTable = "Subject";
                generation_class.WriterTableStaudent(nameTable, DGV_subject);
            }
            catch
            {
                MessageBox.Show("Таблица пуста! Заполните ее!");
            }
        }

    }
}
