using System;

namespace NotificationService.Events
{
	public struct NotificationEvent
	{
		public const int InvalidId = -1;

		public int Id { get; set; }

		public DateTime OccuredAt { get; }

		public INotificationEventType EventType { get; }

		public NotificationEvent(DateTime occuredAt, INotificationEventType eventType)
		{
			OccuredAt = occuredAt;
			EventType = eventType;
			Id = -1;
		}
	}
}
