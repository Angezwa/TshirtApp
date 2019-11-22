using System;
using System.Collections.Generic;
using System.Text;


namespace TshirtWebApp.Models
{
    public class Tee
    {
        public int ID { get; internal set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
    }
}
