using POS.Core.Base;
using POS.Core.Entities;

namespace POS.Application.Services
{
    public class Calculator : ICalculator
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository"></param>
        public Calculator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Calculate total
        /// </summary>
        /// <param name="cartItems"></param>
        /// <returns></returns>
        public double CalculateTotal(CartItem [] cartItems)
        {
            double total = 0;
            var products = _productRepository.GetProducts();

            if (products is null || cartItems is null)
            {
                return 0;
            }

            foreach (var item in cartItems)
            {                
                if (products.TryGetValue(item.Code, out var product))
                {
                    if (product.DiscountVolume is null || product.DiscountVolume.Equals(0))
                    {
                        total += product.UnitPrice * item.Quantity;
                    }
                    else
                    {
                        total += GetVolumePrice(product, item.Quantity);
                    }
                }
            }
            return total;
        }

        /// <summary>
        /// Get Volume price
        /// </summary>
        /// <param name="product"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        private static double GetVolumePrice(Product product, int Quantity)
        {
            return (double)product.VolumePrice * (Quantity / (int)product.DiscountVolume) + Quantity % (int)product.DiscountVolume * product.UnitPrice;
        }
    }
}
