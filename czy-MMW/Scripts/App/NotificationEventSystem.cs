using System;
using System.Collections.Generic;
using Factory;
using NotificationService.Events;
using NotificationService.Persistence;

public class NotificationEventSystem : INotificationEventSystem
{
	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("NotificationEventSystem");

	[Dependency]
	private INotificationEventPersistence _persistence;

	[Dependency]
	private NotificationScheduler _notificationScheduler;

	[Dependency]
	private IActivePlayer _activePlayer;

	public NotificationEvent? LatestEvent => _persistence.LatestEvent;

	public List<NotificationEvent> AllEvents => _persistence.Events;

	public void RecordEvent(INotificationEventType eventType, bool immediatelyRunScheduler = true)
	{
		if (!Diagnostics.Verify(_activePlayer.HasActivePlayer, "Cannot record events when we don't have a player! Tried to record {0}", eventType))
		{
			return;
		}
		NotificationEvent notificationEvent = new NotificationEvent(GameDateTime.UtcNow.Date, eventType);
		List<NotificationEvent> list = EventsOnDay(notificationEvent.OccuredAt);
		bool flag = false;
		foreach (NotificationEvent item in list)
		{
			if (item.EventType.Matches(eventType))
			{
				Log.Info("RecordEvent) UpdatingEventWithId - Id: {0}, {1}", item.Id, notificationEvent.EventType.GetType());
				_persistence.UpdateEventWithId(item.Id, notificationEvent);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			Log.Info("RecordEvent) AddEvent - {0}", notificationEvent.EventType.GetType());
			_persistence.AddEvent(notificationEvent);
		}
		if (immediatelyRunScheduler)
		{
			_notificationScheduler.ScheduleNotifications();
		}
	}

	public void RemoveEvent(int id)
	{
		_persistence.RemoveEventWithId(id);
		_notificationScheduler.ScheduleNotifications();
	}

	public void RemoveAll()
	{
		_persistence.RemoveAll();
		_notificationScheduler.ScheduleNotifications();
	}

	public List<NotificationEvent> EventsOnDay(DateTime day)
	{
		List<NotificationEvent> list = new List<NotificationEvent>();
		foreach (NotificationEvent allEvent in AllEvents)
		{
			if (allEvent.OccuredAt.Date == day.Date)
			{
				list.Add(allEvent);
			}
		}
		return list;
	}
}
