using POS.Core.Entities;

namespace POS.Application.Services
{
    public interface ICalculator
    {
        double CalculateTotal(CartItem[] cartItems);       
    }
}
