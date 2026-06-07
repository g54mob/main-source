namespace Jundroo.Services.Purchasing
{
	public class PurchaseProductResult
	{
		public string FailureMessage { get; }

		public PurchaseFailureReason? FailureReason { get; }

		public Product Product { get; }

		public bool Success => FailureMessage == null;

		public PurchaseProductResult(Product product)
		{
			Product = product;
			FailureReason = null;
			FailureMessage = null;
		}

		public PurchaseProductResult(Product product, PurchaseFailureReason? failureReason, string failureMessage)
		{
			Product = product;
			FailureReason = failureReason;
			FailureMessage = failureMessage;
		}
	}
}
