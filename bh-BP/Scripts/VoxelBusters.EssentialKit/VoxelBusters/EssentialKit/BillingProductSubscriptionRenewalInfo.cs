using System;

namespace VoxelBusters.EssentialKit
{
	public class BillingProductSubscriptionRenewalInfo
	{
		public BillingProductSubscriptionRenewalState State { get; private set; }

		private string ApplicableOfferIdentifier { get; set; }

		private BillingProductOfferCategory? ApplicableOfferCategory { get; set; }

		private DateTime? LastRenewedDate { get; set; }

		private string LastRenewalId { get; set; }

		public bool IsAutoRenewEnabled { get; private set; }

		public BillingProductSubscriptionExpirationReason? ExpirationReason { get; private set; }

		public DateTime? RenewalDate { get; private set; }

		public DateTime? GracePeriodExpirationDate { get; private set; }

		private BillingProductSubscriptionPriceIncreaseStatus PriceIncreaseStatus { get; set; }

		internal BillingProductSubscriptionRenewalInfo(BillingProductSubscriptionRenewalState state, string applicableOfferIdentifier, BillingProductOfferCategory? applicableOfferCategory, DateTime? lastRenewedDate, string lastRenewalId, bool isAutoRenewEnabled, BillingProductSubscriptionExpirationReason? expirationReason, DateTime? renewalDate = null, DateTime? gracePeriodExpirationDate = null, BillingProductSubscriptionPriceIncreaseStatus priceIncreaseStatus = BillingProductSubscriptionPriceIncreaseStatus.NoIncreasePending)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
