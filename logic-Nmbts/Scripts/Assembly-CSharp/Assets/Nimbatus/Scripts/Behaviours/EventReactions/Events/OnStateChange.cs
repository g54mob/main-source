using Assets.Nimbatus.Scripts.Behaviours.EventReactions.States;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnStateChange : NimbatusEvent
	{
		public bool AnyState;

		[HideIf("AnyState", true)]
		public EState NewState;

		protected override void Subscribe()
		{
			EventReaction.Behaviour.OnStateChange += Behaviour_OnStateChange;
		}

		private void Behaviour_OnStateChange(EState oldState, EState newState)
		{
			if (newState == NewState || AnyState)
			{
				RaiseEvent();
			}
		}

		protected override void Unsubscribe()
		{
			EventReaction.Behaviour.OnStateChange -= Behaviour_OnStateChange;
		}
	}
}
