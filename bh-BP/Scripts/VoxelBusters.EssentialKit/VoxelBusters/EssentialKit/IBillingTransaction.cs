using System;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public interface IBillingTransaction
	{
		string Id { get; }

		[Obsolete("This property is deprecated. Use the properties available in IBillingPayment interface", false)]
		IBillingPayment Payment { get; }

		IBillingProduct Product { get; }

		int RequestedQuantity { get; }

		string Tag { get; }

		DateTime DateUTC { get; }

		DateTime Date { get; }

		BillingTransactionState TransactionState { get; }

		BillingReceiptVerificationState ReceiptVerificationState { get; set; }

		string Receipt { get; }

		BillingEnvironment Environment { get; }

		int PurchasedQuantity { get; }

		BillingProductRevocationInfo RevocationInfo { get; }

		BillingProductSubscriptionStatus SubscriptionStatus { get; }

		string RawData { get; }

		Error Error { get; }

		[Obsolete("This property is obsolete. Use data from RawData properties", true)]
		BillingTransactionAndroidProperties AndroidProperties { get; }
	}
}
