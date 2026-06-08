using System;

[Serializable]
internal class AutoRenewingPlan
{
	public string? autoRenewEnabled;

	public SubscriptionItemPriceChangeDetails? priceChangeDetails;
}
