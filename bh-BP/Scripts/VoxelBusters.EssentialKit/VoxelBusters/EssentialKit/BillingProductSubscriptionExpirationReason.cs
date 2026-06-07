namespace VoxelBusters.EssentialKit
{
	public enum BillingProductSubscriptionExpirationReason
	{
		None = 0,
		Unknown = 1,
		AutoRenewDisabled = 2,
		BillingError = 3,
		DidNotConsentToPriceIncrease = 4,
		ProductUnavailable = 5
	}
}
