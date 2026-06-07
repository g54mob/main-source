using System;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.BillingServicesCore
{
	public abstract class NativeBillingServicesInterfaceBase : NativeFeatureInterfaceBase, INativeBillingServicesInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public event RetrieveProductsInternalCallback OnRetrieveProductsComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event PaymentStateChangeInternalCallback OnTransactionStateChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event RestorePurchasesInternalCallback OnRestorePurchasesComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected NativeBillingServicesInterfaceBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public abstract void RetrieveProducts(BillingProductDefinition[] productDefinitions);

		public abstract bool IsProductPurchased(IBillingProduct product);

		public abstract bool CanMakePayments();

		public abstract void BuyProduct(string productId, string platformProductId, BuyProductOptions options);

		public abstract IBillingTransaction[] GetTransactions();

		public abstract void FinishTransactions(IBillingTransaction[] transactions);

		public abstract void RestorePurchases(bool forceRefresh, string tag);

		public abstract void TryClearingUnfinishedTransactions();

		protected void SendRetrieveProductsCompleteEvent(IBillingProduct[] products, string[] invalidProductIds, Error error)
		{
		}

		protected void SendPaymentStateChangeEvent(params IBillingTransaction[] transactions)
		{
		}

		protected void SendRestorePurchasesCompleteEvent(IBillingTransaction[] transactions, Error error)
		{
		}
	}
}
