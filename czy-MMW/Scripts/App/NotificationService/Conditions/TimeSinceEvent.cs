using System;
using System.Collections.Generic;
using NotificationService.Events;
using UnityEngine;

namespace NotificationService.Conditions
{
	[Serializable]
	public class TimeSinceEvent : INotificationCondition
	{
		[SerializeReference]
		public INotificationEventTypeQuery _notificationEventTypeQuery;

		public Comparator comparator;

		public int days = 1;

		public bool Evaluate(DateTime onDate, INotificationEventSystem notificationEventSystem)
		{
			List<NotificationEvent> list = new List<NotificationEvent>();
			foreach (NotificationEvent allEvent in notificationEventSystem.AllEvents)
			{
				if (_notificationEventTypeQuery.Matches(allEvent.EventType, onDate) && allEvent.OccuredAt <= onDate)
				{
					list.Add(allEvent);
				}
			}
			if (list.Count == 0)
			{
				return false;
			}
			NotificationEvent notificationEvent = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				NotificationEvent notificationEvent2 = list[i];
				if (notificationEvent2.OccuredAt > notificationEvent.OccuredAt)
				{
					notificationEvent = notificationEvent2;
				}
			}
			int num = (int)Math.Floor((onDate.Date - notificationEvent.OccuredAt.Date).TotalDays);
			switch (comparator)
			{
			case Comparator.Equals:
				return num == days;
			case Comparator.LessThan:
				return num < days;
			case Comparator.LessThanOrEqual:
				return num <= days;
			case Comparator.GreaterThan:
				return num > days;
			case Comparator.GreaterThanOrEqual:
				return num >= days;
			default:
				Diagnostics.FailAssert("Unknown comparator for notification condition `TimeSinceEvent`");
				return false;
			}
		}
	}
}
