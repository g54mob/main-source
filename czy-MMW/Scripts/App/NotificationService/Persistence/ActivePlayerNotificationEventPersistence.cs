using System.Collections.Generic;
using Factory;
using Motorways;
using NotificationService.Events;

namespace NotificationService.Persistence
{
	public class ActivePlayerNotificationEventPersistence : INotificationEventPersistence
	{
		[Dependency]
		protected ActivePlayer _activePlayer;

		public NotificationEvent? LatestEvent => _activePlayer.LatestNotificationEvent;

		public List<NotificationEvent> Events => _activePlayer.NotificationEvents;

		public void AddEvent(NotificationEvent notificationEvent)
		{
			_activePlayer.AddGameNotificationEvent(notificationEvent);
		}

		public void UpdateEventWithId(int id, NotificationEvent updatedNotificationEvent)
		{
			_activePlayer.UpdateGameNotificationEventWithId(id, updatedNotificationEvent);
		}

		public void RemoveEventWithId(int id)
		{
			Diagnostics.FailAssert("UserProfileNotificationEventPersistence does not implement RemoveEvent");
		}

		public void RemoveAll()
		{
			_activePlayer.RemoveAllNotificationEvents();
		}
	}
}
