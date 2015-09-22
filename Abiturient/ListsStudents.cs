using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Abiturient
{
    class ListsStudents
    {
        protected string connectionstring;
        protected DB db;
        List<SpecialtyClass> listSpecWithAbit;
        List<ListAbiturienClass> listAbit;

        public ListsStudents(string connectionstring)
        {
            this.connectionstring = connectionstring;
            db = new DB(connectionstring);
            listSpecWithAbit = new List<SpecialtyClass>();
            
        }

        public List<SpecialtyClass> WriterLists()
        {
            createListsSpecWithAbit();
            sortLists();
            return listSpecWithAbit;
        }

        /// <summary>
        /// Создание списков абитуриентов по каждой специальности
        /// </summary>
        private void createListsSpecWithAbit()
        {
            DataTable dt_spec = db.readTableSpecialty();
            foreach(DataRow row_spec in dt_spec.Rows)
            {
                SpecialtyClass spec = new SpecialtyClass { ID = Convert.ToInt32(row_spec[0]), Specialty = row_spec[1].ToString(), Amount = Convert.ToInt32(row_spec[2]), listAbitur = createListAbit(Convert.ToInt32(row_spec[0]))};
                listSpecWithAbit.Add(spec);
            }
        }

        private List<ListAbiturienClass> createListAbit(int id_spec)
        {
            listAbit = new List<ListAbiturienClass>();
            DataTable dt_abit = db.selectAbitOnSpec(id_spec);
            foreach (DataRow row_abit in dt_abit.Rows)
            {
                ListAbiturienClass abit = new ListAbiturienClass { ID = Convert.ToInt32(row_abit[0]), FIO = row_abit[1].ToString(), Prior = Convert.ToInt32(row_abit[2]), Scores = Convert.ToInt32(row_abit[3]) };
                listAbit.Add(abit);
            }
            return listAbit;
        }

        /// <summary>
        /// Отсортировать списки абитуриентов
        /// </summary>
        private void sortLists()
        {
            foreach (var i in listSpecWithAbit)
            {
                i.listAbitur.Sort(delegate(ListAbiturienClass ab1, ListAbiturienClass ab2)
                { return ab1.Scores.CompareTo(ab2.Scores); });
                i.listAbitur.Reverse();
            }
        }
    }
}
