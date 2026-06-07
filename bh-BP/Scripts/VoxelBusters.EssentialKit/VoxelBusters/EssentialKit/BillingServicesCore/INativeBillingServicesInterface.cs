using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.BillingServicesCore
{
	public interface INativeBillingServicesInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		event RetrieveProductsInternalCallback OnRetrieveProductsComplete;

		event PaymentStateChangeInternalCallback OnTransactionStateChange;

		event RestorePurchasesInternalCallback OnRestorePurchasesComplete;

		bool CanMakePayments();

		void RetrieveProducts(BillingProductDefinition[] productDefinitions);

		bool IsProductPurchased(IBillingProduct product);

		void BuyProduct(string productId, string platformProductId, BuyProductOptions options);

		IBillingTransaction[] GetTransactions();

		void FinishTransactions(IBillingTransaction[] transactions);

		void RestorePurchases(bool forceRefresh, string tag);

		void TryClearingUnfinishedTransactions();
	}
}
