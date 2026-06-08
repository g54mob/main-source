using System;

[Serializable]
internal class SubscriptionItemPriceChangeDetails
{
	public string expectedNewPriceChargeTime;

	public Money? newPrice;

	public string priceChangeMode;

	public string priceChangeState;
}
