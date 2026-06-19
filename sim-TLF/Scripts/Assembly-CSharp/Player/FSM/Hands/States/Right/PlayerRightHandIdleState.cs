using Player.Animations;
using UnityHFSM;

namespace Player.FSM.Hands.States.Right
{
	internal class PlayerRightHandIdleState : StateBase
	{
		protected ArmsAnimator _armsAnimator;

		protected PlayerItemDropper _itemDropper;

		public PlayerRightHandIdleState(PlayerItemDropper itemDropper, ArmsAnimator armsAnimator, bool needsExitTime = false, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			name = "idle";
			_itemDropper = itemDropper;
			_armsAnimator = armsAnimator;
		}

		public override void OnEnter()
		{
			_itemDropper.enabled = true;
			_armsAnimator.StopDrinkingAnimation();
		}
	}
}
