using POS.Core.Entities;
using System.Collections.Generic;

namespace POS.Application.Services
{
    public class CartService : ICartService
    {
        readonly List<CartItem> cartItems = new List<CartItem>();
        
        /// <summary>
        /// Add item into cart
        /// </summary>
        /// <param name="code"></param>
        public void AddCartItem(CartItem item)
        {            
            if (cartItems.Exists(w => w.Code.Equals(item.Code)))
            {
                cartItems.Find(w => w.Code.Equals(item.Code)).Quantity++;
            }
            else
            {
                cartItems.Add(item);
            }
        }

        /// <summary>
        /// Clear cart items post calculation
        /// </summary>
        public void ClearCartItems()
        {
            cartItems.Clear();
        }

        /// <summary>
        /// Get cart items
        /// </summary>
        /// <returns></returns>
        public CartItem[] GetCartItems()
        {
            return cartItems.ToArray();
        }
    }
}
