namespace VoxelBusters.EssentialKit
{
	public class NotificationServicesNotificationReceivedResult
	{
		public INotification Notification { get; private set; }

		internal NotificationServicesNotificationReceivedResult(INotification notification)
		{
		}
	}
}
