namespace Notifications
{
	public class SystemNotification
	{
		public string Identifier { get; }

		public SystemNotificationContent Content { get; }

		public SystemNotificationTrigger Trigger { get; }

		public SystemNotification(string identifier, SystemNotificationContent content, SystemNotificationTrigger trigger)
		{
			Identifier = identifier;
			Content = content;
			Trigger = trigger;
		}
	}
}
