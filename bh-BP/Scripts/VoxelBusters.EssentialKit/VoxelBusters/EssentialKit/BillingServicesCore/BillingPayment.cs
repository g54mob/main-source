namespace VoxelBusters.EssentialKit.BillingServicesCore
{
	public sealed class BillingPayment : IBillingPayment
	{
		public string ProductId { get; private set; }

		public string ProductPlatformId { get; private set; }

		public int Quantity { get; private set; }

		public string Tag { get; private set; }

		public BillingPayment(string productId, string productPlatformId, int quantity, string tag)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
