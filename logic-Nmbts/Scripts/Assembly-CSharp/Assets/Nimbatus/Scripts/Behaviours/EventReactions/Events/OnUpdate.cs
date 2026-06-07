namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnUpdate : NimbatusEvent
	{
		protected override void Subscribe()
		{
			OwnWorldObject.OnUpdate += OwnWorldObject_OnUpdate;
		}

		private void OwnWorldObject_OnUpdate()
		{
			RaiseEvent();
		}

		protected override void Unsubscribe()
		{
			OwnWorldObject.OnUpdate -= OwnWorldObject_OnUpdate;
		}
	}
}
