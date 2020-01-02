using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DAL
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual List<Category> Categories { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        public Product()
        {
            Provider = new Provider();
            Categories = new List<Category> { };
        }
    }
}
