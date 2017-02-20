using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class ProductType {
		public string Description { get; set; }
		public double Price { get; set; }
		public int Amount { get; set; }

		public ProductType() {

		}
		public ProductType(string Desc, double Price, int Amount) {
			this.Description = Desc;
			this.Price = Price;
			this.Amount = Amount;
		}

		public void SetPrice(double newPrice) {
			this.Price = newPrice;
		}

		public void SetDescription(string newDesc) {
			this.Description = newDesc;
		}

		public void SetAmount(int newAmount) {
			this.Amount = newAmount;
		}

		public override string ToString() {
			StringBuilder SB = new StringBuilder();
			SB.AppendLine(this.Description);
			SB.AppendLine("Amount: " + this.Amount);
			SB.AppendLine("Price: " + this.Price);

			return SB.ToString();
		}
	}
}
