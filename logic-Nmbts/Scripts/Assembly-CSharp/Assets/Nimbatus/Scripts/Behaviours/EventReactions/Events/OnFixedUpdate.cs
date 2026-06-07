namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnFixedUpdate : NimbatusEvent
	{
		protected override void Subscribe()
		{
			OwnWorldObject.OnFixedUpdate += OwnWorldObject_OnFixedUpdate;
		}

		private void OwnWorldObject_OnFixedUpdate()
		{
			RaiseEvent();
		}

		protected override void Unsubscribe()
		{
			OwnWorldObject.OnFixedUpdate -= OwnWorldObject_OnFixedUpdate;
		}
	}
}
