using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {

        //Energies sxetika me thn Cache Memory
        ObjectCache cache = MemoryCache.Default;

        List<ProductCategory> productCategories;


        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;

            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;

        }
        //Prosthiki neou product sth lista
        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);


        }
        //Update to idio uparxontos product
        public void Update(ProductCategory productCategory)
        {
            //Vriskei to product me to id pou theloume
            ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);

            if (productCategoryToUpdate != null)
            {
                //an to vrei kane update to uparxon me to neo
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public ProductCategory Find(string Id)
        {

            //Psaxnei to product me to id poy dinetai san argument
            ProductCategory productCategory = productCategories.Find(p => p.Id == Id);

            if (productCategory != null)
            {
                //An to vrei to epistrefei
                return productCategory;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {

            //Psaxnoume to product me to id poy dothike san argument
            ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);

            if (productCategoryToDelete != null)
            {
                //an to vroume to diagrafoyme apo ti lista products
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

    }

}

