using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Entities
{
    public class Product
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter at least few words")]
        public string Description { get; set; }
        public int Discount { get; set; }
        [Range(1,10000,ErrorMessage ="Set price")]
        public float Price { get; set; }
        [Required(ErrorMessage ="enter link to your img")]
        public string ImageLink { get; set; }

        public float CalculateDiscount()
        {
            if (Discount != 0) {
                return MathF.Round(this.Price / 100 * this.Discount);
            }
            else { return this.Price; } 
        }

    }
}
