namespace VoxelBusters.EssentialKit
{
	public class BillingServicesRestorePurchasesResult
	{
		public IBillingTransaction[] Transactions { get; private set; }

		internal BillingServicesRestorePurchasesResult(IBillingTransaction[] transactions)
		{
		}
	}
}
