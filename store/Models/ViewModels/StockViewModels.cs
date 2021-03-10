using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.ViewModels
{
    public class StockViewModels
    {
        [Required(ErrorMessage ="Make Sure you select an Item")]
        public int? Id { get; set; }
        [Required]
        [Range(1,double.MaxValue,ErrorMessage ="Stock field must be at least 1")]
        public int Stock { get; set; }
        public List<ItemViewModel> Ivm { get; set; }
    }
}
