using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class Order {
		public DateTime OrderDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public Customer Customer { get; set; }
		public List<OrderLine> OrderLines { get; set; }

		public Order(int id, DateTime orderDate, DateTime deliveryDate, Customer customer) {
			this.OrderDate = orderDate;
			this.DeliveryDate = deliveryDate;
			this.Customer = customer;
		}

		public void AddOrderLine(OrderLine orderLine) {
			OrderLines.Add(orderLine);
		}
	}
}
