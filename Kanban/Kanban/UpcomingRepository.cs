using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SQLite;

namespace Kanban
{
    public class UpcomingRepository
    {
        SQLiteConnection Upcoming_conn;
        public UpcomingRepository(string path) 
        {
            Upcoming_conn = new SQLiteConnection(path);
            Upcoming_conn.CreateTable<Upcoming>();
        }

        public List<Upcoming> GetUpcomingTasks() 
        {
            return Upcoming_conn.Table<Upcoming>().ToList();
        }

        public Upcoming GetUpcomingTask(int id) 
        {
            return Upcoming_conn.Get<Upcoming>(id);
        }

        public int SaveUpcomingTasks(Upcoming upcoming) 
        {
            return Upcoming_conn.Insert(upcoming);
        }

        public int DeleteUpcomingTasks(int id) 
        {
            return Upcoming_conn.Delete<Upcoming>(id);
        }

        public int UpdateUpcomingTasks(Upcoming upcoming) 
        {
            Upcoming_conn.Update(upcoming);
            return upcoming.ID;
        }
    }
}
