using System.Collections.Generic;
using System.Linq;

namespace VoxelBusters.EssentialKit
{
	public class BillingProductOffer
	{
		public string Id { get; private set; }

		public BillingProductOfferCategory Category { get; private set; }

		public IOrderedEnumerable<BillingProductOfferPricingPhase> PricingPhases { get; private set; }

		public BillingProductOffer(string id, BillingProductOfferCategory category, List<BillingProductOfferPricingPhase> pricingPhases)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
