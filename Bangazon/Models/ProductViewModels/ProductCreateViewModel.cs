using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Models.ProductViewModels
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; }
        public List<ProductType> AvailableCategories { get; set; }

        public List<SelectListItem> CategoryOptions =>
            AvailableCategories?.Select(c => new SelectListItem(c.Label, c.ProductTypeId.ToString())).ToList();
    }
}
