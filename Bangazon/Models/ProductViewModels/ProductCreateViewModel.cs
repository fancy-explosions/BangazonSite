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

        public List<SelectListItem> CategoryOptions
        {
            get
            {
                if(AvailableCategories == null)
                {
                    return null;
                }
                var ac = AvailableCategories?.Select(c => new SelectListItem(c.Label, c.ProductTypeId.ToString())).ToList();
                ac.Insert(0, new SelectListItem("Select a category", null));

                return ac;
            }
        }
        //public List<SelectListItem> CategoryOptions =>
            
        //    AvailableCategories?.Select(c => new SelectListItem(c.Label, c.ProductTypeId.ToString())).ToList();
            
    }
}
