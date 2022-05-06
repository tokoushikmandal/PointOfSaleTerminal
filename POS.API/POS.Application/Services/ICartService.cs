using POS.Core.Entities;

namespace POS.Application.Services
{
    public interface ICartService
    {
        void AddCartItem(CartItem code);
        CartItem [] GetCartItems();
        void ClearCartItems();
    }
}
