using System.Collections.Generic;

namespace Notifications.Services
{
	public class NullSystemNotificationService : ISystemNotificationService
	{
		public int ApplicationBadge { get; set; }

		public List<SystemNotification> ScheduledNotifications { get; }

		public List<SystemNotification> DeliveredNotifications { get; }

		public AuthorizationStatus AuthorizationStatus => AuthorizationStatus.Unknown;

		public bool RequiresOptionsPanel => false;

		public bool IsAvailable => false;

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
		}

		public void ScheduleNotification(string identifier, SystemNotificationContent content, SystemNotificationTrigger trigger)
		{
		}

		public void RemoveScheduledNotification(string identifier)
		{
		}

		public void RemoveAllScheduledNotifications()
		{
		}

		public void RemoveAllDeliveredNotifications()
		{
		}

		public void RequestAuthorization(OnAuthorizationRequestComplete authorizationRequestComplete)
		{
		}
	}
}
