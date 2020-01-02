using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            //BL.MapperProfile.Initialize();
            BL.Product product1 = new BL.Product();
            //product1.ID = 1;
            product1.Name = "Car";
            product1.Price = 20;
            BL.Provider provider1 = new BL.Provider();
            //provider1.ID = 2;
            provider1.Name = "Geely";

            product1.Provider = provider1;

            BL.Category cat1 = new BL.Category();
            //cat1.ID = 3;
            cat1.Name = "Cars";
            

            product1.Categories.Add(cat1);
            cat1.Products.Add(product1);

            BL.Category cat2 = new BL.Category();
            //cat2.ID = 4;
            cat2.Name = "Vehicles";

            product1.Categories.Add(cat2);
            cat2.Products.Add(product1);

            provider1.Products.Add(product1);

            BL.ProductService db = new BL.ProductService();

            //var db = ProductDb.Products;
            //foreach (Product prod in db)
            //{
            //    //База создалась только на этом моменте
            //    Console.WriteLine("{0} - {1}", prod.Name, prod.Price);
            //}


            db.AddProduct(product1);
            BL.Product pr = db.Get(1);
            db.Save();
            Console.WriteLine("{0}({2}) - {1}", pr.Name, pr.Price, pr.Provider.Name);

            Console.ReadLine();
        }


        //protected void Pending()
        //{
        //    Console.WriteLine("Awaiting for your commends...");
        //    Console.WriteLine(@"Type 'help' or command");
        //    string command = Console.ReadLine();
        //    switch (command)
        //    {
        //        case "help":
                    
        //                Console.WriteLine("");
        //                break;
                    
        //        case "AddProduct":
                   
        //            Console.WriteLine("");
        //            break;

        //        default:
        //            Console.WriteLine("Incorrect command, try again");
        //            Pending();
        //            break;

        //    }
                    



        //}
    }
}
