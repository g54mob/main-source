namespace VoxelBusters.EssentialKit.NotificationServicesCore
{
	internal sealed class NullNotificationCenterInterface : NativeNotificationCenterInterfaceBase
	{
		public NullNotificationCenterInterface()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public override void RequestPermission(NotificationPermissionOptions options, RequestPermissionInternalCallback callback)
		{
		}

		public override void GetSettings(GetSettingsInternalCallback callback)
		{
		}

		public override IMutableNotification CreateMutableNotification(string notificationId)
		{
			return null;
		}

		public override void ScheduleNotification(INotification notification, ScheduleNotificationInternalCallback callback)
		{
		}

		public override void GetScheduledNotifications(GetNotificationsInternalCallback callback)
		{
		}

		public override void CancelScheduledNotification(string notificationId)
		{
		}

		public override void CancelAllScheduledNotifications()
		{
		}

		public override void GetDeliveredNotifications(GetNotificationsInternalCallback callback)
		{
		}

		public override void RemoveAllDeliveredNotifications()
		{
		}

		public override void RegisterForPushNotifications(RegisterForPushNotificationsInternalCallback callback)
		{
		}

		public override void UnregisterForPushNotifications()
		{
		}

		public override bool IsRegisteredForPushNotifications()
		{
			return false;
		}

		public override void SetApplicationIconBadgeNumber(int count)
		{
		}
	}
}
