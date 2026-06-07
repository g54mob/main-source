using System;

namespace Jundroo.Services.Purchasing.Events
{
	public class ProductPurchaseCompletedEventArgs : EventArgs
	{
		public string FailureMessage { get; }

		public PurchaseFailureReason? FailureReason { get; }

		public Product Product { get; }

		public bool Success => FailureMessage == null;

		public ProductPurchaseCompletedEventArgs(Product product)
		{
			Product = product;
			FailureReason = null;
			FailureMessage = null;
		}

		public ProductPurchaseCompletedEventArgs(Product product, PurchaseFailureReason? failureReason, string failureMessage)
		{
			Product = product;
			FailureReason = failureReason;
			FailureMessage = failureMessage;
		}
	}
}
