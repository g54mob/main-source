namespace VoxelBusters.EssentialKit
{
	public class BillingServicesTransactionStateChangeResult
	{
		public IBillingTransaction[] Transactions { get; private set; }

		internal BillingServicesTransactionStateChangeResult(IBillingTransaction[] transactions)
		{
		}
	}
}
