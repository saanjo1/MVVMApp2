using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVM.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public string OrderCode { get; set; }

        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}
