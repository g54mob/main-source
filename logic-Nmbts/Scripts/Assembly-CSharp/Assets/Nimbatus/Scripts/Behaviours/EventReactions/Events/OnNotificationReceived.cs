using Assets.Nimbatus.Scripts.WorldObjects;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnNotificationReceived : NimbatusEvent
	{
		protected override void Subscribe()
		{
			InteractiveWorldObject.OnNotify += InteractiveWorldObject_OnNotify;
		}

		private void InteractiveWorldObject_OnNotify(NotificationData data)
		{
			RaiseEvent();
		}

		protected override void Unsubscribe()
		{
			InteractiveWorldObject.OnNotify -= InteractiveWorldObject_OnNotify;
		}
	}
}
