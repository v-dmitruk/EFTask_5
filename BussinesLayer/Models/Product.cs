using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual List<Category> Categories { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }


        public Product()
        {
            Categories = new List<Category> { };
            Provider = new Provider();
        }
    }
}
