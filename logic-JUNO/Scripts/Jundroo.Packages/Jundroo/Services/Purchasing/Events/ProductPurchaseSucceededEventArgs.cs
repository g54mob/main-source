using System;

namespace Jundroo.Services.Purchasing.Events
{
	public class ProductPurchaseSucceededEventArgs : EventArgs
	{
		public Product Product { get; }

		public ProductPurchaseSucceededEventArgs(Product product)
		{
			Product = product;
		}
	}
}
