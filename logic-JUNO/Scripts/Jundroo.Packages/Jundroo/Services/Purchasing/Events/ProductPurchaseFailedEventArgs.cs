using System;

namespace Jundroo.Services.Purchasing.Events
{
	public class ProductPurchaseFailedEventArgs : EventArgs
	{
		public PurchaseFailureReason FailureReason { get; }

		public string Message { get; }

		public Product Product { get; }

		public ProductPurchaseFailedEventArgs(Product product, PurchaseFailureReason failureReason, string message)
		{
			Product = product;
			FailureReason = failureReason;
			Message = message;
		}
	}
}
