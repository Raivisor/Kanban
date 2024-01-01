using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Kanban
{
    [Table("Upcoming")]
    public class Upcoming
    {
        [PrimaryKey, AutoIncrement,Column("ID")]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
