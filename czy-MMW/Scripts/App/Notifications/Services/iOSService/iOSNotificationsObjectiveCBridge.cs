using System;

namespace Notifications.Services.iOSService
{
	public static class iOSNotificationsObjectiveCBridge
	{
		internal delegate void AuthorizationRequestComplete(bool authorizationGranted);

		internal delegate void NotificationReceivedCallback(string identifier);

		internal static void _ScheduleLocalCalendarNotification(IntPtr notificationContent, IntPtr calendarTrigger)
		{
		}

		internal static void _ScheduleLocalTimeIntervalNotification(IntPtr notificationContent, IntPtr timeIntervalTrigger)
		{
		}

		internal static void _RequestAuthorization()
		{
		}

		internal static void _SetAuthorizationRequestCompleteDelegate(AuthorizationRequestComplete callback)
		{
		}

		internal static AuthorizationStatus _GetAuthorizationStatus()
		{
			return AuthorizationStatus.Unknown;
		}

		internal static void _RemoveScheduledNotification(string identifier)
		{
		}

		internal static void _RemoveAllScheduledNotifications()
		{
		}

		internal static void _RemoveDeliveredNotification(string identifier)
		{
		}

		internal static void _RemoveAllDeliveredNotifications()
		{
		}

		internal static void _SetNotificationReceivedDelegate(NotificationReceivedCallback callback)
		{
		}

		internal static void _OpenApplicationSettings()
		{
		}

		internal static void _SetApplicationBadgeNumber(int number)
		{
		}

		internal static int _GetApplicationBadgeNumber()
		{
			return 0;
		}

		public static void _Log(string text)
		{
		}
	}
}
