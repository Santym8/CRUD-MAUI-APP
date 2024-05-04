using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Prices { get; set; }
        public double IVA { get; set; }
        public int categoryId { get; set; }
        public Category Category { get; set; }
    }
}
