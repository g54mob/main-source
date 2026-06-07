using System;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit.BillingServicesCore
{
	public sealed class BillingTransactionPlain : BillingTransactionBase
	{
		private readonly int m_requestedQuantity;

		private readonly string m_tag;

		private readonly BillingTransactionState m_transactionState;

		private BillingReceiptVerificationState m_verificationState;

		private readonly DateTime m_date;

		private readonly string m_receipt;

		private readonly BillingEnvironment m_environment;

		private readonly string m_applicationBundleIdentifier;

		private readonly int m_purchasedQuantity;

		private readonly BillingProductRevocationInfo m_revocationInfo;

		private readonly BillingProductSubscriptionStatus m_subscriptionStatus;

		private readonly string m_rawData;

		private readonly Error m_error;

		public BillingTransactionPlain(string transactionId, IBillingProduct product, int requestedQuantity, string tag, BillingTransactionState transactionState, BillingReceiptVerificationState verificationState, DateTime transactionDate, string receipt, BillingEnvironment environment, string applicationBundleIdentifier, int purchasedQuantity, BillingProductRevocationInfo revocationInfo, BillingProductSubscriptionStatus subscriptionStatus, string rawData, Error error)
			: base(null, null)
		{
		}

		~BillingTransactionPlain()
		{
		}

		protected override DateTime GetTransactionDateUTCInternal()
		{
			return default(DateTime);
		}

		protected override BillingTransactionState GetTransactionStateInternal()
		{
			return default(BillingTransactionState);
		}

		protected override BillingReceiptVerificationState GetReceiptVerificationStateInternal()
		{
			return default(BillingReceiptVerificationState);
		}

		protected override void SetReceiptVerificationStateInternal(BillingReceiptVerificationState value)
		{
		}

		protected override string GetReceiptInternal()
		{
			return null;
		}

		protected override Error GetErrorInternal()
		{
			return null;
		}

		protected override BillingEnvironment GetEnvironmentInternal()
		{
			return default(BillingEnvironment);
		}

		protected override string GetApplicationBundleIdentifierInternal()
		{
			return null;
		}

		protected override int GetPurchasedQuantityInternal()
		{
			return 0;
		}

		protected override BillingProductRevocationInfo GetRevocationInfoInternal()
		{
			return null;
		}

		protected override BillingProductSubscriptionStatus GetSubscriptionStatusInternal()
		{
			return null;
		}

		protected override string GetRawDataInternal()
		{
			return null;
		}

		protected override int GetRequestedQuantityInternal()
		{
			return 0;
		}

		protected override string GetTagInternal()
		{
			return null;
		}
	}
}
