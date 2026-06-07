namespace VoxelBusters.EssentialKit.BillingServicesCore
{
	internal class NullBillingServicesInterface : NativeBillingServicesInterfaceBase
	{
		public NullBillingServicesInterface()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public override bool CanMakePayments()
		{
			return false;
		}

		public override void RetrieveProducts(BillingProductDefinition[] productDefinitions)
		{
		}

		public override bool IsProductPurchased(IBillingProduct product)
		{
			return false;
		}

		public override void BuyProduct(string productId, string productPlatformId, BuyProductOptions options)
		{
		}

		public override IBillingTransaction[] GetTransactions()
		{
			return null;
		}

		public override void FinishTransactions(IBillingTransaction[] transactions)
		{
		}

		public override void RestorePurchases(bool forceRefresh, string tag)
		{
		}

		public override void TryClearingUnfinishedTransactions()
		{
		}
	}
}
