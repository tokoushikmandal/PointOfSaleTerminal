using System.ComponentModel.DataAnnotations;

namespace POS.Core.Entities
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        [Required]
        public string Code { get; set; }
        public double UnitPrice { get; set; }
        public int? DiscountVolume { get; set; }
        public double? VolumePrice { get; set; }
    }
}
