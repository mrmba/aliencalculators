using SSGeek.DAL;
using SSGeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Controllers
{
    public class StoreController : Controller
    {
        private IProductDAL _dal;
        public StoreController(IProductDAL dal)
        {
            _dal = dal;
        }

        public ActionResult Index()
        {
            IList<Product> products = _dal.GetProducts();
            return View(products);
        }

        public ActionResult ProductDetail(int id)
        {
            if (id.Equals(null))
            {
                return Index();
            }

            var product = _dal.GetProduct(id);
            return View("ProductDetail", product);
        }

        [HttpPost]
        public ActionResult ShoppingCart(int productId, int quantity)
        {
            /* Step 13 - Retrieve product and add to shopping cart */
            Product productToAdd = _dal.GetProduct(productId);

            ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(productToAdd,quantity);

            return RedirectToAction("ViewCart");
        }


        public ActionResult ViewCart()
        {
            ShoppingCart cart = GetActiveShoppingCart();
            return View(cart);
        }

        [HttpPost]
        public ActionResult ViewCart(int productId)
        {

            Product product = _dal.GetProduct(productId);

            ShoppingCart cart = GetActiveShoppingCart();

            return RedirectToAction("ViewCart");

        }

        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            //See if the user has a shopping cart already
            if (Session["ShoppingCart"] == null)
            {

                //If not, create one and save it.
                cart = new ShoppingCart();
                Session["ShoppingCart"] = cart; //  <-- Saves the shopping cart into the session
            }
            else
            {
                cart = Session["ShoppingCart"] as ShoppingCart;     //  <-- Gets the shopping cart out of the session
            }

            return cart;
        }

        public ActionResult CheckOut()
        {
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index","Planets");
        }

    }
}