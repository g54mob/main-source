namespace VoxelBusters.EssentialKit
{
	public class NotificationServicesRegisterForPushNotificationsResult
	{
		public string DeviceToken { get; private set; }

		internal NotificationServicesRegisterForPushNotificationsResult(string deviceToken)
		{
		}
	}
}
