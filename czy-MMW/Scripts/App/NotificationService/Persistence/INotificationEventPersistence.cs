using System.Collections.Generic;
using NotificationService.Events;

namespace NotificationService.Persistence
{
	public interface INotificationEventPersistence
	{
		NotificationEvent? LatestEvent { get; }

		List<NotificationEvent> Events { get; }

		void AddEvent(NotificationEvent notificationEvent);

		void UpdateEventWithId(int id, NotificationEvent updatedNotificationEvent);

		void RemoveEventWithId(int id);

		void RemoveAll();
	}
}
