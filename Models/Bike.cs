using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicycles.WebAPI.Models
{
    public class Bike
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
    }
}
