namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnCollected : NimbatusEvent
	{
		protected override void Subscribe()
		{
			OwnWorldObject.OnCollected += _collected;
		}

		protected override void Unsubscribe()
		{
			OwnWorldObject.OnCollected -= _collected;
		}

		private void _collected()
		{
			RaiseEvent();
		}
	}
}
