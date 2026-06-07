using System.Collections.Generic;
using NotificationService.Events;

namespace NotificationService.Persistence
{
	public class InMemoryNotificationEventPersistence : INotificationEventPersistence
	{
		private int _nextId;

		private readonly List<NotificationEvent> _events = new List<NotificationEvent>();

		private NotificationEvent? _latestEvent;

		public NotificationEvent? LatestEvent => _latestEvent;

		public List<NotificationEvent> Events => _events;

		public void AddEvent(NotificationEvent notificationEvent)
		{
			notificationEvent.Id = _nextId;
			_nextId++;
			_events.Add(notificationEvent);
			UpdateLatestEvent(notificationEvent);
		}

		public void RemoveEventWithId(int id)
		{
			_events.RemoveAt(IndexOf(id));
			ref NotificationEvent? latestEvent = ref _latestEvent;
			if (latestEvent.HasValue && latestEvent.GetValueOrDefault().Id == id)
			{
				if (_events.Count == 0)
				{
					_latestEvent = null;
				}
				else
				{
					_latestEvent = FindLatestEvent();
				}
			}
		}

		public void RemoveAll()
		{
			_events.Clear();
			_latestEvent = null;
			_nextId = 0;
		}

		public void UpdateEventWithId(int id, NotificationEvent updatedNotificationEvent)
		{
			updatedNotificationEvent.Id = id;
			_events[IndexOf(id)] = updatedNotificationEvent;
			UpdateLatestEvent(updatedNotificationEvent);
		}

		private int IndexOf(int id)
		{
			for (int i = 0; i < _events.Count; i++)
			{
				if (_events[i].Id == id)
				{
					return i;
				}
			}
			return -1;
		}

		private NotificationEvent FindLatestEvent()
		{
			NotificationEvent result = _events[0];
			for (int i = 1; i < _events.Count; i++)
			{
				NotificationEvent notificationEvent = _events[i];
				if (notificationEvent.OccuredAt > result.OccuredAt)
				{
					result = notificationEvent;
				}
			}
			return result;
		}

		private void UpdateLatestEvent(NotificationEvent newNotificationEvent)
		{
			if (!_latestEvent.HasValue)
			{
				_latestEvent = newNotificationEvent;
			}
			else if (newNotificationEvent.OccuredAt > _latestEvent.Value.OccuredAt)
			{
				_latestEvent = newNotificationEvent;
			}
		}
	}
}
