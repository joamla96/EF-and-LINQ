using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class OrderLine {
		public ProductType ProductType { get; set; }
		public Order Order;
		public int Quantity { get; set; }

		public OrderLine(Order Order, ProductType pT, int quantity) {
			this.Order = Order;
			this.ProductType = pT;
			Quantity = quantity;
		}
	}
}
