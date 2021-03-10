using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Range(0,double.MaxValue)]
        public int Price { get; set; }
        [Range(0, double.MaxValue)]
        public int Stock { get; set; }
    }
}
