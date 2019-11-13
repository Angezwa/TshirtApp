using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TShirtOderingApp
{
   public class Tees
    {
        [PrimaryKey, AutoIncrement] //to add multiple detailes for different people, and show below info on the table (sqlite)[using sqlite]
        public int ID { get; internal set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public  string Color { get; set; }
        public string Address { get; set; }
    }
}
