using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NotificationServicesCore
{
	public interface INativeNotificationCenterInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		event NotificationReceivedInternalCallback OnNotificationReceived;

		void RequestPermission(NotificationPermissionOptions options, RequestPermissionInternalCallback callback);

		void GetSettings(GetSettingsInternalCallback callback);

		IMutableNotification CreateMutableNotification(string notificationId);

		void ScheduleNotification(INotification notification, ScheduleNotificationInternalCallback callback);

		void GetScheduledNotifications(GetNotificationsInternalCallback callback);

		void CancelScheduledNotification(string notificationId);

		void CancelAllScheduledNotifications();

		void GetDeliveredNotifications(GetNotificationsInternalCallback callback);

		void RemoveAllDeliveredNotifications();

		void RegisterForPushNotifications(RegisterForPushNotificationsInternalCallback callback);

		void UnregisterForPushNotifications();

		bool IsRegisteredForPushNotifications();

		void SetApplicationIconBadgeNumber(int count);
	}
}
