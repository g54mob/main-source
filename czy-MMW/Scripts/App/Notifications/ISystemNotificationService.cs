using System.Collections.Generic;

namespace Notifications
{
	public interface ISystemNotificationService
	{
		int ApplicationBadge { get; set; }

		List<SystemNotification> ScheduledNotifications { get; }

		List<SystemNotification> DeliveredNotifications { get; }

		bool IsAvailable { get; }

		AuthorizationStatus AuthorizationStatus { get; }

		bool RequiresOptionsPanel { get; }

		event NotificationReceived OnNotificationReceived;

		void Setup();

		void ScheduleNotification(string identifier, SystemNotificationContent content, SystemNotificationTrigger trigger);

		void RemoveScheduledNotification(string identifier);

		void RemoveAllScheduledNotifications();

		void RemoveAllDeliveredNotifications();

		void RequestAuthorization(OnAuthorizationRequestComplete authorizationRequestComplete = null);
	}
}
