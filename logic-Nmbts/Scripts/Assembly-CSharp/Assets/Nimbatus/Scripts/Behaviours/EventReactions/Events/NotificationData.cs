using Assets.Nimbatus.Scripts.WorldObjects;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class NotificationData
	{
		public InteractiveWorldObject Sender;

		public ENotificationType Notification;

		public NotificationData(InteractiveWorldObject sender, ENotificationType notification)
		{
			Sender = sender;
			Notification = notification;
		}
	}
}
