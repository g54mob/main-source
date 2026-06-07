using System;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NotificationServicesCore
{
	public abstract class NativeNotificationCenterInterfaceBase : NativeFeatureInterfaceBase, INativeNotificationCenterInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public event NotificationReceivedInternalCallback OnNotificationReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected NativeNotificationCenterInterfaceBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public abstract void RequestPermission(NotificationPermissionOptions options, RequestPermissionInternalCallback callback);

		public abstract void GetSettings(GetSettingsInternalCallback callback);

		public abstract IMutableNotification CreateMutableNotification(string notificationId);

		public abstract void ScheduleNotification(INotification notification, ScheduleNotificationInternalCallback callback);

		public abstract void GetScheduledNotifications(GetNotificationsInternalCallback callback);

		public abstract void CancelScheduledNotification(string notificationId);

		public abstract void CancelAllScheduledNotifications();

		public abstract void GetDeliveredNotifications(GetNotificationsInternalCallback callback);

		public abstract void RemoveAllDeliveredNotifications();

		public abstract void RegisterForPushNotifications(RegisterForPushNotificationsInternalCallback callback);

		public abstract void UnregisterForPushNotifications();

		public abstract bool IsRegisteredForPushNotifications();

		public abstract void SetApplicationIconBadgeNumber(int count);

		protected void SendNotificationReceivedEvent(INotification notification)
		{
		}
	}
}
