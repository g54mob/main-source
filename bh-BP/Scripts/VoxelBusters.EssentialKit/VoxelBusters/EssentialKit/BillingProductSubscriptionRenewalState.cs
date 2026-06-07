namespace VoxelBusters.EssentialKit
{
	public enum BillingProductSubscriptionRenewalState
	{
		Unknown = 0,
		Subscribed = 1,
		Expired = 2,
		InBillingRetryPeriod = 3,
		InGracePeriod = 4,
		Revoked = 5
	}
}
