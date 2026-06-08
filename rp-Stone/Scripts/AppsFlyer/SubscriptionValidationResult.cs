using System;

[Serializable]
internal class SubscriptionValidationResult
{
	public bool success;

	public SubscriptionPurchase? subscriptionPurchase;

	public ValidationFailureData? failureData;

	public string token;
}
