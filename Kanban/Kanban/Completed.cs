using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban
{
    [Table("Completed")]
    public class Completed
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
