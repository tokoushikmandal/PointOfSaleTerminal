using POS.Core.Base;
using POS.Core.Entities;
using System.Collections.Generic;

namespace POS.Infrastructure.Base
{
    public class ProductRepository : IProductRepository
    {
        readonly Dictionary<string, Product> products = new Dictionary<string, Product>();

        /// <summary>
        /// constructor
        /// </summary>
        public ProductRepository()
        {            
            LoadProducts();            
        }

        /// <summary>
        /// initial load for products
        /// </summary>
        private void LoadProducts()
        {
            SetPrice("A", 1.25, 3, 3);
            SetPrice("B", 4.25);
            SetPrice("C", 1, 5, 6);
            SetPrice("D", 0.75);
        }

        /// <summary>
        /// Get Product by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Product GetProduct(string code)
        {
            if (products.TryGetValue(code, out var product))
            {
                return product;
            }
            return null;
        }
        /// <summary>
        /// Get products 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Product> GetProducts()
        {
            return products;
        }

        /// <summary>
        /// Set the price of a product
        /// </summary>
        /// <param name="code"></param>
        /// <param name="unitPrice"></param>
        /// <param name="volumePrice"></param>
        /// <param name="DiscountVolume"></param>
        public void SetPrice(string code, double unitPrice, double? volumePrice = null, int? discountVolume = null)
        {
            if (products.TryGetValue(code, out var product))
            {
                product.UnitPrice = unitPrice;
                product.VolumePrice = volumePrice;
                product.DiscountVolume = discountVolume;
            }
            else
            {
                product = new Product
                {
                    Code = code,
                    UnitPrice = unitPrice,
                    VolumePrice = volumePrice,
                    DiscountVolume = discountVolume
                };
                products.Add(code, product);
            }
        }
    }
}
