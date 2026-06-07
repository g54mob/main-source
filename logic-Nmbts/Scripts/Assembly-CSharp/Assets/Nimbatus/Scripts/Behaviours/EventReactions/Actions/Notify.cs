using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class Notify : NimbatusAction
	{
		public ENotificationType Notification;

		public override void Execute()
		{
			OwnWorldObject.SendNotification(new NotificationData(OwnWorldObject, Notification));
		}
	}
}
