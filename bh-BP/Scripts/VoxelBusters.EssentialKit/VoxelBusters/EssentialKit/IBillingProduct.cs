using System;
using System.Collections.Generic;

namespace VoxelBusters.EssentialKit
{
	public interface IBillingProduct
	{
		string Id { get; }

		string PlatformId { get; }

		string LocalizedTitle { get; }

		string LocalizedDescription { get; }

		BillingProductType Type { get; }

		BillingPrice Price { get; }

		bool IsAvailable { get; }

		BillingProductSubscriptionInfo SubscriptionInfo { get; }

		IEnumerable<BillingProductOffer> Offers { get; }

		IEnumerable<BillingProductPayoutDefinition> Payouts { get; }

		[Obsolete("Use LocalizedText property of Price(BillingPrice) property")]
		string LocalizedPrice { get; }

		[Obsolete("Use Code property of Price(BillingPrice) property")]
		string PriceCurrencyCode { get; }

		[Obsolete("Use Symbol property of Price(BillingPrice) property")]
		string PriceCurrencySymbol { get; }

		[Obsolete("This property is deprecated. Use Payout instead.", false)]
		object Tag { get; }
	}
}
