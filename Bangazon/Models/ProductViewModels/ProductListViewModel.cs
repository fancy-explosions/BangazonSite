using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Data;

namespace Bangazon.Models.ProductViewModels
{
  public class ProductListViewModel
  {
    public List<GroupedProducts> GroupedProducts { get; set; }

    public List<ProductType> ProductTypes { get; set; }
  }
}