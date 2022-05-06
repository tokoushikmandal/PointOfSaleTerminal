using POS.Core.Entities;
using System.Collections.Generic;

namespace POS.Core.Base
{
    public interface IProductRepository
    {
        void SetPrice(string code, double unitPrice, double? volumePrice = null, int? discountVolume = null);
        Product GetProduct(string code);
        Dictionary<string, Product> GetProducts();
    }
}
