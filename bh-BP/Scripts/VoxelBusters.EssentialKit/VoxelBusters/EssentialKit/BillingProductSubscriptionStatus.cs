using System;

namespace VoxelBusters.EssentialKit
{
	public class BillingProductSubscriptionStatus
	{
		public string GroupId { get; private set; }

		public BillingProductSubscriptionRenewalInfo RenewalInfo { get; private set; }

		private DateTime? ExpirationDate { get; set; }

		private bool IsUpgraded { get; set; }

		private string AppliedOfferId { get; set; }

		private BillingProductOfferCategory? AppliedOfferCategory { get; set; }

		internal BillingProductSubscriptionStatus(string groupId, BillingProductSubscriptionRenewalInfo renewalInfo = null, DateTime? expirationDate = null, bool isUpgraded = false, string appliedOfferIdentifier = null, BillingProductOfferCategory? appliedOfferCategory = null)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
