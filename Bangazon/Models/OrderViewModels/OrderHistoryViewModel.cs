using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Models.OrderViewModels
{
    public class OrderHistoryViewModel
    {
        public Order Order { get; set; }

        public List<Order> PreviousOrders { get; set; }

        
    }
}
