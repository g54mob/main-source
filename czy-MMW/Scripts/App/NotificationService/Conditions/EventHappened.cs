using System;
using NotificationService.Events;
using UnityEngine;

namespace NotificationService.Conditions
{
	[Serializable]
	public class EventHappened : INotificationCondition
	{
		[SerializeReference]
		public INotificationEventTypeQuery _notificationEventTypeQuery;

		public bool Evaluate(DateTime onDate, INotificationEventSystem notificationEventSystem)
		{
			foreach (NotificationEvent allEvent in notificationEventSystem.AllEvents)
			{
				if (_notificationEventTypeQuery.Matches(allEvent.EventType, onDate) && allEvent.OccuredAt.Date <= onDate.Date)
				{
					return true;
				}
			}
			return false;
		}
	}
}
