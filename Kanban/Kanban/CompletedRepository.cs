using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Kanban
{
    public class CompletedRepository
    {
        SQLiteConnection Completed_conn;

        public CompletedRepository(string path) 
        {
            Completed_conn = new SQLiteConnection(path);
            Completed_conn.CreateTable<Completed>();
        }

        public List<Completed> GetCompletedTasks()
        {
            return Completed_conn.Table<Completed>().ToList();
        }

        public Completed GetCompletedTask(int id) 
        {
            return Completed_conn.Get<Completed>(id);
        }

        public int SaveCompletedTasks(Completed completed)
        {
            return Completed_conn.Insert(completed);
        }

        public int DeleteCompletedTasks(int id)
        {
            return Completed_conn.Delete<Completed>(id);
        }

        public int UpdateCompletedTasks(Completed completed)
        {
            Completed_conn.Update(completed);
            return completed.ID;
        }
    }
}
