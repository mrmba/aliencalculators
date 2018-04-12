using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();

        public void AddToCart(Product p, int quantity)
        {
            //Add new item, if it doesn't exist; otherwise increase quantity by input quantity
            bool itemFound = false;
            foreach (ShoppingCartItem item in Items)
            {
                if (item.Product.ProductId == p.ProductId)
                {
                    item.Quantity += quantity;
                    item.TotalCostPerProduct += quantity * item.Product.Price;
                    itemFound = true;
                }
            }

            if (!itemFound)
            {
                Items.Add(new ShoppingCartItem() { Product = p, Quantity = quantity, TotalCostPerProduct = quantity * p.Price });
            }
        }

        public decimal GetTotalCost()
        {

            decimal totalCost = 0m;

            foreach (ShoppingCartItem item in Items)
            {
                totalCost += item.Quantity * item.Product.Price;
            }

            return totalCost;
        }
    }
}