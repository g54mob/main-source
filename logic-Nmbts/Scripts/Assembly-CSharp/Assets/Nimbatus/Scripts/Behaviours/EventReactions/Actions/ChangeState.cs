using Assets.Nimbatus.Scripts.Behaviours.EventReactions.States;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ChangeState : NimbatusAction
	{
		public EState State;

		public override void Execute()
		{
			Behaviour.ChangeState(State);
		}
	}
}
