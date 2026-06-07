namespace VoxelBusters.EssentialKit
{
	public sealed class BillingTransactionAndroidProperties
	{
		public string PurchaseData { get; private set; }

		public string Signature { get; private set; }

		public BillingTransactionAndroidProperties(string purchaseData, string signature)
		{
		}
	}
}
