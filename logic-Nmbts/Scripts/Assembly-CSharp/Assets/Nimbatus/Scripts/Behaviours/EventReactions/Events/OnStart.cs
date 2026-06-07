namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnStart : NimbatusEvent
	{
		protected override void Subscribe()
		{
			OwnWorldObject.OnStart += OwnWorldObject_OnUpdate;
		}

		private void OwnWorldObject_OnUpdate()
		{
			RaiseEvent();
		}

		protected override void Unsubscribe()
		{
			OwnWorldObject.OnStart -= OwnWorldObject_OnUpdate;
		}
	}
}
