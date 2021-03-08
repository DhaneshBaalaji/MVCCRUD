using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAURANTCRUDAUTH.Data.Model
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Display(Name = "Type of Soru")]
        public CuisineType Cuisine { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [Phone]
        [MaxLength(10)]
        [MinLength(10)]
        [DataType(DataType.PhoneNumber)]

        public string Phone { get; set; }

        [Required]
        [MaxLength(32)]
        [DataType(DataType.PostalCode)]
        [Range(000000, 999999,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string Pin { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
