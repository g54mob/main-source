using System.Collections.Generic;
using NotificationService.Events;

namespace NotificationService.Persistence
{
	public class NullNotificationEventPersistence : INotificationEventPersistence
	{
		public NotificationEvent? LatestEvent => null;

		public List<NotificationEvent> Events => null;

		public void AddEvent(NotificationEvent notificationEvent)
		{
		}

		public void UpdateEventWithId(int id, NotificationEvent updatedNotificationEvent)
		{
		}

		public void RemoveEventWithId(int id)
		{
		}

		public void RemoveAll()
		{
		}
	}
}
