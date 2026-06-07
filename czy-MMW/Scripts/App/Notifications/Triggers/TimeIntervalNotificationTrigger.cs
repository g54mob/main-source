using System;

namespace Notifications.Triggers
{
	public class TimeIntervalNotificationTrigger : SystemNotificationTrigger
	{
		public TimeSpan TimeInterval;

		public bool Repeats { get; set; }
	}
}
