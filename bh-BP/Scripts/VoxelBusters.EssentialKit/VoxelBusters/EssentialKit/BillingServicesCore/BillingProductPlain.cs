using System;
using System.Collections.Generic;

namespace VoxelBusters.EssentialKit.BillingServicesCore
{
	[Serializable]
	public sealed class BillingProductPlain : BillingProductBase
	{
		private string m_localizedTitle;

		private string m_localizedDescription;

		private BillingPrice m_price;

		private BillingProductSubscriptionInfo m_subscriptionInfo;

		private IEnumerable<BillingProductOffer> m_offers;

		private IEnumerable<BillingProductPayoutDefinition> m_payouts;

		public BillingProductPlain(string id, string platformId, BillingProductType type, string localizedTitle, string localizedDescription, BillingPrice price, BillingProductSubscriptionInfo subscriptionInfo, IEnumerable<BillingProductOffer> offers, IEnumerable<BillingProductPayoutDefinition> payouts)
			: base(null, null, default(BillingProductType), null, isAvailable: false)
		{
		}

		~BillingProductPlain()
		{
		}

		protected override string GetLocalizedTitleInternal()
		{
			return null;
		}

		protected override string GetLocalizedDescriptionInternal()
		{
			return null;
		}

		protected override BillingPrice GetPriceInternal()
		{
			return null;
		}

		protected override BillingProductSubscriptionInfo GetSubscriptionInfoInternal()
		{
			return null;
		}

		protected override IEnumerable<BillingProductOffer> GetOffersInternal()
		{
			return null;
		}
	}
}
