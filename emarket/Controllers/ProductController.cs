using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emarket.Context;
using emarket.Models;
using emarket.ViewModels;

namespace emarket.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        //LINQ statment
        private ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            return RedirectToAction("AllProducts");
        }
        public ActionResult AllProducts(string search)
        {
            var products = db.Product.ToList();
            var carts = db.Cart.ToList();
            var cateogries = db.Category.ToList();
            if (!string.IsNullOrEmpty(search)) 
            {
                Category category = db.Category.Where(m => m.name == search).FirstOrDefault<Category>();
                if (category != null)
                {
                    products = db.Product.Where(m => m.category_id == category.id).ToList();
                }
                if (category == null)
                {
                    products = null;
                }

            }
            ProductCartModel productCartModel = new ProductCartModel
            {
                Cart = carts,
                Product = products
            };

            
            return View(productCartModel);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var Category = db.Category.ToList();
            ProductCategoryModel productCategoryModel = new ProductCategoryModel
            {
                category = Category
            };
            return View(productCategoryModel);
        }

        [HttpPost]
        public ActionResult Add(ProductCategoryModel productCategoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(productCategoryModel.product);
                db.SaveChanges();
                return Json(new { restult = 1});
            }

            return Json(new { restult = 0 });
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var Category = db.Category.ToList();
            var Product = db.Product.SingleOrDefault(m => m.id == id);
            ProductCategoryModel productCategoryModel = new ProductCategoryModel
            {
                category = Category,
                product = Product
            };
            return View(productCategoryModel);
        }
        [HttpPost]
        public ActionResult Update(ProductCategoryModel productCategoryModel)
        {
            if (ModelState.IsValid) { 
            
                var Category = db.Category.ToList();
                var ProductOld = db.Product.SingleOrDefault(m => m.id == productCategoryModel.product.id);
                ProductOld.name = productCategoryModel.product.name;
                ProductOld.image = productCategoryModel.product.image;
                ProductOld.price = productCategoryModel.product.price;
                ProductOld.description = productCategoryModel.product.description;
                ProductOld.category_id = productCategoryModel.product.category_id;
                db.SaveChanges();
                return RedirectToAction("AllProducts");
            }

            return View(productCategoryModel);
        }
        [HttpGet]
        public ActionResult AddToCart(int id)
        {

            var cart = db.Product.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            Cart CartItem = new Cart
            {
                product_id = id,
                added_at= DateTime.Now
            };
            //check if cart has the same product inside 
            var check = db.Cart.Find(id);

            if(check == null)
            {
                db.Cart.Add(CartItem);
                db.SaveChanges();
                return Json(new { restult = 1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { restult = 0 }, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult Details(int id)
        {
            var product = db.Product.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult DeleteFormCart(int id)
        {

            var Cart = db.Cart.FirstOrDefault(m => m.product_id == id );
            db.Cart.Remove(Cart);
            db.SaveChanges();
            return RedirectToAction("AllProducts");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Cart = db.Cart.FirstOrDefault(m => m.product_id == id);
            if(Cart != null)
            {
                db.Cart.Remove(Cart);
                db.SaveChanges();
            }
            var product = db.Product.FirstOrDefault(m => m.id == id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("AllProducts");
        }
    }
}