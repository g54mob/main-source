using System;
using System.Collections.Generic;

[Serializable]
internal class SubscriptionPurchase
{
	public string acknowledgementState;

	public CanceledStateContext? canceledStateContext;

	public ExternalAccountIdentifiers? externalAccountIdentifiers;

	public string kind;

	public string latestOrderId;

	public List<SubscriptionPurchaseLineItem> lineItems;

	public string? linkedPurchaseToken;

	public PausedStateContext? pausedStateContext;

	public string regionCode;

	public string startTime;

	public SubscribeWithGoogleInfo? subscribeWithGoogleInfo;

	public string subscriptionState;

	public TestPurchase? testPurchase;
}
