using Player.Animations;
using UnityHFSM;

namespace Player.FSM
{
	public class PlayerPushState : StateBase<StateIdentifier>
	{
		private readonly BasicRigidBodyPush _push;

		private readonly ArmsAnimator _armsAnimator;

		public PlayerPushState(ArmsAnimator armsAnimator, BasicRigidBodyPush push, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_push = push;
			_armsAnimator = armsAnimator;
		}

		public override void OnEnter()
		{
			_push.canPush = true;
			_armsAnimator.EnablePushing();
		}

		public override void OnExit()
		{
			_push.canPush = false;
			_armsAnimator.DisablePushing();
		}
	}
}
