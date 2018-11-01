using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
     public class ProductRepository
    {
        //Energies sxetika me thn Cache Memory
        ObjectCache cache = MemoryCache.Default;

        List<Product> products;


        public ProductRepository()
        {
            products = cache["products"] as List<Product>;

            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
           {
           cache["products"] = products;

           }
        //Prosthiki neou product sth lista
        public void Insert(Product p)
        {
            products.Add(p);


        }
        //Update to idio uparxontos product
        public void Update(Product product)
        {
            //Vriskei to product me to id pou theloume
            Product productToUpdate = products.Find(p => p.Id == product.Id);

            if(productToUpdate != null)
            {
                //an to vrei kane update to uparxon me to neo
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public Product Find(string Id)
        {

            //Psaxnei to product me to id poy dinetai san argument
            Product product = products.Find(p => p.Id == Id);

            if (product != null)
            {
                //An to vrei to epistrefei
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id)
        {

            //Psaxnoume to product me to id poy dothike san argument
            Product productToDelete = products.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                //an to vroume to diagrafoyme apo ti lista products
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

    }



    
}
