using Assets.Nimbatus.Scripts.Behaviours.EventReactions.States;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnStateEnter : NimbatusEvent
	{
		protected override void Subscribe()
		{
			EventReaction.Behaviour.OnStateChange += Behaviour_OnStateChange;
		}

		private void Behaviour_OnStateChange(EState oldState, EState newState)
		{
			RaiseEvent();
		}

		protected override void Unsubscribe()
		{
			EventReaction.Behaviour.OnStateChange -= Behaviour_OnStateChange;
		}
	}
}
