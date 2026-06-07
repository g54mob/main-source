namespace Data.Notifications
{
	public class RankNotificationData : AbstractNotificationData
	{
		public RankConfig RankConfig;

		public RankNotificationData(RankConfig rankConfig)
		{
			RankConfig = rankConfig;
		}
	}
}
