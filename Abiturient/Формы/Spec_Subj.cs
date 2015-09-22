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
    public partial class Spec_Subj : Form
    {
        protected string connectionstring;
        private Generation_Class generation_class;

        public Spec_Subj(string connectionstring)
        {
            InitializeComponent();
            this.connectionstring = connectionstring;
            generation_class = new Generation_Class(this.connectionstring);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteDataReader read_sub = generation_class.writerTable("Subject");
            SQLiteDataReader read_spec = generation_class.writerTable("Specialty");

            int count_mas = 5;
            int max = 0;
            int min = 0;
            int[] mas_id_sub = new int[count_mas];           
            int i = 0;
            while (read_sub.Read())
            {
                mas_id_sub[i] = Convert.ToInt32(read_sub.GetValue(0).ToString());
                i++;
            }
            min = mas_id_sub[0];
            max = mas_id_sub[0];
            for (int j = 0; j < mas_id_sub.Length-1; j++)
            {
               
                for (int k = j + 1; k < mas_id_sub.Length; k++)
                {
                    if (mas_id_sub[k] < min)
                        min = mas_id_sub[k];
                    if (mas_id_sub[k] > max)
                        max = mas_id_sub[k];
                }
            }
         Random rn = new Random();
            int[] mas_sub_3 = new int[3];
         /*   while (read_spec.Read())
            {
       
                for(int j = 0; j<3; j++)
                {
                    mas_sub_3[j] = rn.Next(min, max);
                    if(j>0)
                    {
                        int temp = mas_sub_3[j];
                        for (int jj = j-1; jj >=0; jj--)
                        {
                            if (temp == mas_sub_3[jj])
                            {
                                j-- ;
                            }
                        }
                    }
                }
                for (int j = 0; j < mas_sub_3.Length; j++)
                {
                    generation_class.Spec_Sub("Spec_subj", "ID_specialty", "ID_subject", Convert.ToInt32(read_spec.GetValue(0).ToString()), mas_sub_3[j]);
                }
                
            }
            */
            while (read_spec.Read())
            {
                    mas_sub_3[0] = min;
                    mas_sub_3[1] = min + 1;
                    mas_sub_3[2] = rn.Next(min + 2, max);
                    for (int j = 0; j < mas_sub_3.Length; j++)
                    {
                        generation_class.Spec_Sub("SpecSubj", "id_spec", "id_subj", Convert.ToInt32(read_spec.GetValue(0).ToString()), mas_sub_3[j]);
                    }
            }
            generation_class.writerTableStaudent1("Specsubj", DGC_specsubj);
        }

        private void Spec_Subj_Load(object sender, EventArgs e)
        {
            generation_class.writerTableStaudent1("Specsubj", DGC_specsubj);
       
        }
    }
}
