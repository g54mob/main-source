namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public abstract class NimbatusEvent : EventReactionComponent
	{
		protected abstract void Subscribe();

		protected abstract void Unsubscribe();

		protected void RaiseEvent()
		{
			EventReaction.ExecuteEvent();
		}

		protected override void OnInit()
		{
			Subscribe();
		}

		protected override void OnRelease()
		{
			Unsubscribe();
		}
	}
}
