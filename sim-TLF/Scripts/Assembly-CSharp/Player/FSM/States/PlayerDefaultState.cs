using UnityHFSM;

namespace Player.FSM.States
{
	public class PlayerDefaultState : StateBase<StateIdentifier>
	{
		public PlayerDefaultState(bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
		}

		public override void OnEnter()
		{
			base.OnEnter();
		}

		public override void OnExit()
		{
			base.OnExit();
		}

		public override void OnLogic()
		{
			base.OnLogic();
		}
	}
}
