namespace VoxelBusters.EssentialKit
{
	public class BillingProductSubscriptionInfo
	{
		public string GroupId { get; private set; }

		public string LocalizedGroupTitle { get; private set; }

		public int Level { get; private set; }

		public BillingPeriod Period { get; private set; }

		public BillingProductSubscriptionInfo(string groupId, string localizedGroupTitle, int level, BillingPeriod period)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
