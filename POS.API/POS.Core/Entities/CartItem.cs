
using System.ComponentModel.DataAnnotations;

namespace POS.Core.Entities
{
    /// <summary>
    /// Cart item
    /// </summary>
    public class CartItem
    {
        [Required]
        public string Code { get; set; }
        public int Quantity { get; set; }
    }
}
