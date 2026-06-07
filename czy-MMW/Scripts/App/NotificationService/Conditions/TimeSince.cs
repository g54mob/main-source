using System;
using Motorways;

namespace NotificationService.Conditions
{
	public class TimeSince : INotificationCondition
	{
		public enum OtherEvent
		{
			WeeklyChallengeStarted = 0
		}

		public OtherEvent otherEvent;

		public Comparator comparator;

		public int days = 1;

		public bool Evaluate(DateTime onDate, INotificationEventSystem notificationEventSystem)
		{
			if (otherEvent != OtherEvent.WeeklyChallengeStarted)
			{
				return false;
			}
			int num = (int)Math.Floor((onDate - ChallengeSystem.StartOfWeek(onDate)).TotalDays);
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
				Diagnostics.FailAssert("Unknown comparator for notification condition `TimeSince`");
				return false;
			}
		}
	}
}
