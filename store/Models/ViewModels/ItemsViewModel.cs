using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.ViewModels
{
    public class ItemsViewModel
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "The field Price must be greater than 0")]

        public int Price { get; set; }
        public List<ItemViewModel> Items {get; set;}
    }
}
