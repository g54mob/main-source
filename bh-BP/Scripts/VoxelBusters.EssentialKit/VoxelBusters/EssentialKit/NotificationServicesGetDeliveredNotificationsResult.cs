namespace VoxelBusters.EssentialKit
{
	public class NotificationServicesGetDeliveredNotificationsResult
	{
		public INotification[] Notifications { get; private set; }

		internal NotificationServicesGetDeliveredNotificationsResult(INotification[] notifications)
		{
		}
	}
}
