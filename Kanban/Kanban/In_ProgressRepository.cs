using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Kanban
{ 
    public class In_ProgressRepository
    {
        SQLiteConnection In_Progress_conn;

        public In_ProgressRepository(string path) 
        {
            In_Progress_conn = new SQLiteConnection(path);
            In_Progress_conn.CreateTable<In_Progress>();
        }

        public List<In_Progress> GetInProgressTasks()
        {
            return In_Progress_conn.Table<In_Progress>().ToList();
        }

        public In_Progress GetInProgressTask(int id) 
        {
            return In_Progress_conn.Get<In_Progress>(id);
        }

        public int SaveInProgressTasks(In_Progress inprogress)
        {
            return In_Progress_conn.Insert(inprogress);
        }

        public int DeleteInProgressTasks(int id)
        {
            return In_Progress_conn.Delete<In_Progress>(id);
        }

        public int UpdateInProgressTasks(In_Progress inprogress)
        {
            In_Progress_conn.Update(inprogress);
            return inprogress.ID;
        }
    }
}
