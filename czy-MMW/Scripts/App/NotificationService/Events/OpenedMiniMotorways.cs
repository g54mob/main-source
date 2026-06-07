using System;
using Factory;

namespace NotificationService.Events
{
	[Factory.Serializable(1)]
	public class OpenedMiniMotorways : INotificationEventType, INotificationEventTypeQuery
	{
		public string QueryName => "OpenedMiniMotorways";

		public bool Matches(INotificationEventType eventType, DateTime onDate)
		{
			return GetType() == eventType.GetType();
		}
	}
}
