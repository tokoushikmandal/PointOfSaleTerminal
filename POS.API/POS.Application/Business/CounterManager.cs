
using POS.Application.Services;
using POS.Core.Base;
using POS.Core.Entities;

namespace POS.Application.Business
{
    public class CounterManager : ICounterManager
    {        
        private readonly ICartService _cartService;
        private readonly ICalculator _calculator;
        private readonly IProductRepository _productRepository;
        
        /// <summary>
        /// controller
        /// </summary>
        /// <param name="cartService"></param>
        /// <param name="calculator"></param>
        /// <param name="productRepository"></param>
        public CounterManager(ICartService cartService, ICalculator calculator, IProductRepository productRepository)
        {            
            _cartService = cartService;
            _calculator = calculator;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Scan the codes and calculate total
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public double ProcessAndCalculateTotal(string codes)
        {
            // Scan items
            ScanItems(codes);
            //calculate total
            double total = _calculator.CalculateTotal(_cartService.GetCartItems());

            //clear the cart
            _cartService.ClearCartItems();
            return total;
        }

        /// <summary>
        /// Validate codes
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool Validate(string codes)
        {
            foreach(var code in codes)
            {
                if (_productRepository.GetProduct(code.ToString()) is null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// scan codes
        /// </summary>
        /// <param name="codes"></param>
        private void ScanItems(string codes)
        {
            foreach (var code in codes)
            {
                _cartService.AddCartItem(new CartItem { Code = code.ToString(), Quantity = 1});
            }
        }
    }
}
