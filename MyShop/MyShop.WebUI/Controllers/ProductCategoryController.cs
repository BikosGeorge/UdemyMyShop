﻿using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryController : Controller
    {
        //dimiourgoume instance ths class
        ProductCategoryRepository context;

        //o constrcutor ths parousas class
        public ProductCategoryController()
        {
            context = new ProductCategoryRepository();


        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        //Ftiaxnoume ta 2 Create Methods gia na dhmiourgoume Products.
        //To prwto kanei tis aparaithtes energeies eno to allo kalei http post request

        public ActionResult Create()
        {

            //Dhmiourgoume ena object tis klasis Product (Vasiko Model)
            ProductCategory productCategory = new ProductCategory();

            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);

            }
            else
            {
                context.Insert(productCategory);
                context.Commit();

                return RedirectToAction("Index");

            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productCategory);

            }

        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);
            if (productCategoryToEdit == null)
            {
                return HttpNotFound();

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }

                productCategoryToEdit.Category = productCategory.Category;
           


                context.Commit();

                return RedirectToAction("Index");
            }


        }
        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productCategoryToDelete);

            }


        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                context.Delete(Id);
                context.Commit();

                return RedirectToAction("Index");

            }

        }
    }
}