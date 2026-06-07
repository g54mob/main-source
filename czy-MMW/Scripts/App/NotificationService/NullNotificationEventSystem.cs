using System;
using System.Collections.Generic;
using NotificationService.Events;

namespace NotificationService
{
	public class NullNotificationEventSystem : INotificationEventSystem
	{
		public NotificationEvent? LatestEvent => null;

		public List<NotificationEvent> AllEvents => null;

		public void RecordEvent(INotificationEventType eventType, bool immediatelyRunScheduler = true)
		{
		}

		public void RemoveEvent(int id)
		{
		}

		public void RemoveAll()
		{
		}

		public List<NotificationEvent> EventsOnDay(DateTime day)
		{
			return null;
		}
	}
}
