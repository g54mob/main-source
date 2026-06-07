using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.NotificationServicesCore;

namespace VoxelBusters.EssentialKit
{
	public static class NotificationServices
	{
		private static INativeNotificationCenterInterface s_nativeInterface;

		private static string s_deviceToken;

		public static NotificationServicesUnitySettings UnitySettings { get; private set; }

		internal static INativeNotificationCenterInterface NativeInterface => null;

		public static INotification[] ScheduledNotifications { get; private set; }

		public static NotificationSettings CachedSettings { get; private set; }

		public static event Callback<NotificationSettings> OnSettingsUpdate
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

		public static event Callback<NotificationServicesNotificationReceivedResult> OnNotificationReceived
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

		public static event EventCallback<NotificationServicesRegisterForPushNotificationsResult> OnRegisterForPushNotificationsComplete
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

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(NotificationServicesUnitySettings settings)
		{
		}

		public static void RequestPermission(NotificationPermissionOptions options, bool showPrepermissionDialog = true, EventCallback<NotificationServicesRequestPermissionResult> callback = null)
		{
		}

		public static void GetSettings(Callback<NotificationServicesGetSettingsResult> callback = null)
		{
		}

		public static NotificationBuilder CreateNotificationWithId(string notificationId)
		{
			return null;
		}

		public static void ScheduleNotification(INotification notification, CompletionCallback callback = null)
		{
		}

		public static void GetScheduledNotifications(EventCallback<NotificationServicesGetScheduledNotificationsResult> callback = null)
		{
		}

		public static void CancelScheduledNotification(string notificationId)
		{
		}

		public static void CancelScheduledNotification(INotification notification)
		{
		}

		public static void CancelAllScheduledNotifications()
		{
		}

		public static void GetDeliveredNotifications(EventCallback<NotificationServicesGetDeliveredNotificationsResult> callback = null)
		{
		}

		public static void RemoveAllDeliveredNotifications()
		{
		}

		public static void RegisterForPushNotifications(EventCallback<NotificationServicesRegisterForPushNotificationsResult> callback = null)
		{
		}

		public static void UnregisterForPushNotifications()
		{
		}

		public static bool IsRegisteredForPushNotifications()
		{
			return false;
		}

		public static void SetApplicationIconBadgeNumber(int count)
		{
		}

		public static bool IsAuthorizedPermissionStatus(NotificationPermissionStatus accessStatus)
		{
			return false;
		}

		public static bool? IsInitializedAndAuthorized()
		{
			return null;
		}

		public static bool IsAuthorized()
		{
			return false;
		}

		public static bool IsPermissionAvailable()
		{
			return false;
		}

		public static void TryRegisterForPushNotifications()
		{
		}

		private static void RegisterForEvents()
		{
		}

		private static void UnregisterFromEvents()
		{
		}

		private static void RequestPermissionInternal(NotificationPermissionOptions options, EventCallback<NotificationServicesRequestPermissionResult> callback = null)
		{
		}

		private static void SendRequestPermissionResult(EventCallback<NotificationServicesRequestPermissionResult> callback, NotificationPermissionStatus permissionStatus, Error error)
		{
		}

		private static void GetSettingsInternal(bool sendUpdateEvent, Callback<NotificationServicesGetSettingsResult> callback = null)
		{
		}

		private static void CopyPushNotificationPropertiesToCachedSettings(bool sendUpdateEvent = true)
		{
		}

		private static void HandleNotificationReceivedInternalCallback(INotification notification)
		{
		}
	}
}
