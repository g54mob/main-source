using System;
using System.Collections.Generic;
using AOT;
using JetBrains.Annotations;
using Notifications.Services.iOSService;
using Notifications.Triggers;

namespace Notifications.Services
{
	public class iOSSystemNotificationService : ISystemNotificationService
	{
		[CanBeNull]
		private static OnAuthorizationRequestComplete _authorizationRequestComplete;

		public int ApplicationBadge
		{
			get
			{
				return iOSNotificationsObjectiveCBridge._GetApplicationBadgeNumber();
			}
			set
			{
				iOSNotificationsObjectiveCBridge._SetApplicationBadgeNumber(value);
			}
		}

		public List<SystemNotification> ScheduledNotifications { get; }

		public List<SystemNotification> DeliveredNotifications { get; }

		public bool IsAvailable => true;

		public bool RequiresOptionsPanel => true;

		public AuthorizationStatus AuthorizationStatus => iOSNotificationsObjectiveCBridge._GetAuthorizationStatus();

		public event NotificationReceived OnNotificationReceived
		{
			add
			{
			}
			remove
			{
			}
		}

		public void Setup()
		{
			iOSNotificationsObjectiveCBridge._SetNotificationReceivedDelegate(NotificationReceived);
			iOSNotificationsObjectiveCBridge._SetAuthorizationRequestCompleteDelegate(OnAuthorizationRequestComplete);
		}

		public void RemoveAllDeliveredNotifications()
		{
			iOSNotificationsObjectiveCBridge._RemoveAllDeliveredNotifications();
		}

		public void RequestAuthorization(OnAuthorizationRequestComplete authorizationRequestComplete = null)
		{
			if (_authorizationRequestComplete != null)
			{
				Diagnostics.FailAssert("Cannot handle multiple notification authorization requests.");
				return;
			}
			iOSNotificationsObjectiveCBridge._Log("RequestAuthorization called");
			_authorizationRequestComplete = authorizationRequestComplete;
			iOSNotificationsObjectiveCBridge._RequestAuthorization();
		}

		[MonoPInvokeCallback(typeof(iOSNotificationsObjectiveCBridge.AuthorizationRequestComplete))]
		public static void OnAuthorizationRequestComplete(bool authorizationGranted)
		{
			iOSNotificationsObjectiveCBridge._Log($"Authorization Request Complete! Granted: {authorizationGranted}");
			_authorizationRequestComplete?.Invoke(authorizationGranted);
			_authorizationRequestComplete = null;
		}

		[MonoPInvokeCallback(typeof(iOSNotificationsObjectiveCBridge.NotificationReceivedCallback))]
		public static void NotificationReceived(string identifier)
		{
			iOSNotificationsObjectiveCBridge._Log("Notification Received! " + identifier);
			Diagnostics.Log.Info("iOSNotificationBackend", "Notification Received! {0}", identifier);
		}

		public void ScheduleNotification(string identifier, SystemNotificationContent content, SystemNotificationTrigger trigger)
		{
			IntPtr notificationContent = iOSContentData.ToIntPtr(iOSContentData.ToContentData(identifier, content));
			if (!(trigger is CalendarNotificationTrigger calendarNotificationTrigger))
			{
				if (trigger is TimeIntervalNotificationTrigger calendarNotificationTrigger2)
				{
					IntPtr timeIntervalTrigger = iOSContentData.ToIntPtr(iOSContentData.ToContentData(calendarNotificationTrigger2));
					iOSNotificationsObjectiveCBridge._ScheduleLocalTimeIntervalNotification(notificationContent, timeIntervalTrigger);
				}
				else
				{
					Diagnostics.FailAssert("No implementation available for {0} in iOSNotificationBackend", trigger.GetType().ToString());
				}
			}
			else
			{
				IntPtr calendarTrigger = iOSContentData.ToIntPtr(iOSContentData.ToContentData(calendarNotificationTrigger));
				iOSNotificationsObjectiveCBridge._ScheduleLocalCalendarNotification(notificationContent, calendarTrigger);
				iOSNotificationsObjectiveCBridge._Log($"Scheduling calendar notification {identifier} for {calendarNotificationTrigger}");
			}
		}

		public void RemoveScheduledNotification(string identifier)
		{
			iOSNotificationsObjectiveCBridge._Log("Removing scheduled notification " + identifier);
			iOSNotificationsObjectiveCBridge._RemoveScheduledNotification(identifier);
		}

		public void RemoveAllScheduledNotifications()
		{
			iOSNotificationsObjectiveCBridge._RemoveAllScheduledNotifications();
		}

		public void OpenApplicationSettings()
		{
			iOSNotificationsObjectiveCBridge._OpenApplicationSettings();
		}
	}
}
