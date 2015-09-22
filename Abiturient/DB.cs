using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Abiturient
{
    class DB
    {
        protected string connectionstring;

        protected string tableAbiturient = @"CREATE TABLE Abiturient(id INTEGER PRIMARY KEY, fio TEXT)";
        protected string tableSubject = @"CREATE TABLE Subject(id INTEGER PRIMARY KEY, name TEXT)";
        protected string tableSpecialty = @"CREATE TABLE Specialty(id INTEGER PRIMARY KEY, name TEXT, amount INTEGER)";
        protected string tableAbitSubj = @"CREATE TABLE AbitSubj(id INTEGER PRIMARY KEY, id_abit INTEGER, id_subj INTEGER,  FOREIGN KEY(id_abit) REFERENCES Abiturient(id), FOREIGN KEY(id_subj) REFERENCES Subject(id))";
        protected string tableAbitSpec = @"CREATE TABLE AbitSpec(id INTEGER PRIMARY KEY, id_abit INTEGER, id_spec INTEGER, prior INTEGER, scores INTEGER, FOREIGN KEY(id_abit) REFERENCES Abiturient(id), FOREIGN KEY(id_spec) REFERENCES Specialty(id))";
        protected string tableSpecSubj = @"CREATE TABLE SpecSubj(id INTEGER PRIMARY KEY, id_spec INTEGER, id_subj INTEGER,  FOREIGN KEY(id_subj) REFERENCES Subject(id), FOREIGN KEY(id_spec) REFERENCES Specialty(id))";        

        public DB(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }
        public void createTables()
        {
            SQLiteConnection sql = new SQLiteConnection(connectionstring);
            sql.Open();
            createQuery(sql, tableAbiturient);
            createQuery(sql, tableSubject);
            createQuery(sql, tableSpecialty);
            createQuery(sql, tableAbitSubj);
            createQuery(sql, tableAbitSpec);
            createQuery(sql, tableSpecSubj);
            sql.Close();
        }

        private void createQuery(SQLiteConnection sql, string strQuery)
        {
            SQLiteCommand sc = new SQLiteCommand(sql);
            sc.CommandText = strQuery;
            sc.ExecuteNonQuery();
        }
    }
}
