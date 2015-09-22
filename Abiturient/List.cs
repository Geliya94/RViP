using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Abiturient
{
    public class List
    {
        public int ID_student { get; set; }
        public int ID_specialty { get; set; }
        public int Prio { get; set; }
        public int Sum { get; set; }
    }

    public class ListSpec
    {
        public int ID { get; set; }
        public string Specialty { get; set; }
        public int Amount { get; set; }
    }
}
