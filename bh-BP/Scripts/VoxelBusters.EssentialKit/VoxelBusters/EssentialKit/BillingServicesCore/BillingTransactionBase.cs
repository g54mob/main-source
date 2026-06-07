using System;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.BillingServicesCore
{
	public abstract class BillingTransactionBase : NativeObjectBase, IBillingTransaction
	{
		public string Id { get; private set; }

		public IBillingPayment Payment { get; private set; }

		public IBillingProduct Product { get; private set; }

		public int RequestedQuantity => 0;

		public string Tag => null;

		public DateTime DateUTC => default(DateTime);

		public DateTime Date => default(DateTime);

		public BillingTransactionState TransactionState => default(BillingTransactionState);

		public BillingReceiptVerificationState ReceiptVerificationState
		{
			get
			{
				return default(BillingReceiptVerificationState);
			}
			set
			{
			}
		}

		public string Receipt => null;

		public BillingEnvironment Environment => default(BillingEnvironment);

		public string ApplicationBundleIdentifier => null;

		public int PurchasedQuantity => 0;

		public BillingProductRevocationInfo RevocationInfo => null;

		public BillingProductSubscriptionStatus SubscriptionStatus => null;

		public Error Error => null;

		public BillingTransactionAndroidProperties AndroidProperties => null;

		public string RawData => null;

		protected BillingTransactionBase(string transactionId, IBillingProduct product)
		{
		}

		~BillingTransactionBase()
		{
		}

		protected abstract int GetRequestedQuantityInternal();

		protected abstract string GetTagInternal();

		protected abstract DateTime GetTransactionDateUTCInternal();

		protected abstract BillingTransactionState GetTransactionStateInternal();

		protected abstract BillingReceiptVerificationState GetReceiptVerificationStateInternal();

		protected abstract void SetReceiptVerificationStateInternal(BillingReceiptVerificationState value);

		protected abstract string GetReceiptInternal();

		protected abstract BillingEnvironment GetEnvironmentInternal();

		protected abstract string GetApplicationBundleIdentifierInternal();

		protected abstract int GetPurchasedQuantityInternal();

		protected abstract BillingProductRevocationInfo GetRevocationInfoInternal();

		protected abstract BillingProductSubscriptionStatus GetSubscriptionStatusInternal();

		protected abstract Error GetErrorInternal();

		protected abstract string GetRawDataInternal();

		public override string ToString()
		{
			return null;
		}
	}
}
