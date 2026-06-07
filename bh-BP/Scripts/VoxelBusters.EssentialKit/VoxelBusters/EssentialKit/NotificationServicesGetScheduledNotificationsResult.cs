namespace VoxelBusters.EssentialKit
{
	public class NotificationServicesGetScheduledNotificationsResult
	{
		public INotification[] Notifications { get; private set; }

		internal NotificationServicesGetScheduledNotificationsResult(INotification[] notifications)
		{
		}
	}
}
