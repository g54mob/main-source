using System;
using System.Collections.Generic;
using NotificationService.Events;

public interface INotificationEventSystem
{
	NotificationEvent? LatestEvent { get; }

	List<NotificationEvent> AllEvents { get; }

	void RecordEvent(INotificationEventType eventType, bool immediatelyRunScheduler = true);

	void RemoveEvent(int id);

	void RemoveAll();

	List<NotificationEvent> EventsOnDay(DateTime day);
}
