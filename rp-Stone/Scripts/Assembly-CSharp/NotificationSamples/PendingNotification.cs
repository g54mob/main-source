using System;

namespace NotificationSamples
{
	public class PendingNotification
	{
		public bool Reschedule;

		public readonly IGameNotification Notification;

		public PendingNotification(IGameNotification notification)
		{
			Notification = notification ?? throw new ArgumentNullException("notification");
		}
	}
}
