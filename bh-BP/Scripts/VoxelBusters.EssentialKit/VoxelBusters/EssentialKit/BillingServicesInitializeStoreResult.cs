namespace VoxelBusters.EssentialKit
{
	public class BillingServicesInitializeStoreResult
	{
		public IBillingProduct[] Products { get; private set; }

		public string[] InvalidProductIds { get; private set; }

		internal BillingServicesInitializeStoreResult(IBillingProduct[] products, string[] invalidProductIds)
		{
		}
	}
}
