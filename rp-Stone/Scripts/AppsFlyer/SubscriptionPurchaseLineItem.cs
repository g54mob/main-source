using System;

[Serializable]
internal class SubscriptionPurchaseLineItem
{
	public AutoRenewingPlan? autoRenewingPlan;

	public DeferredItemReplacement? deferredItemReplacement;

	public string expiryTime;

	public OfferDetails? offerDetails;

	public PrepaidPlan? prepaidPlan;

	public string productId;
}
