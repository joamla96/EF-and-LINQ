using System.Collections.Generic;
using System.IO;

namespace Core {
	public class Customer {
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public List<Order> Orders;

		public Customer(string name, string address, string email) {
			this.Name = name;
			this.Address = address;
			this.Email = email;
		}

		public override string ToString() {
			string Addr = this.Address;

			StringWriter Output = new StringWriter();

			Output.WriteLine("Name: " + this.Name);
			Output.WriteLine("Email: " + this.Email);
			Output.WriteLine("String: " + this.Address);

			return Output.ToString();
		}
	}
}
