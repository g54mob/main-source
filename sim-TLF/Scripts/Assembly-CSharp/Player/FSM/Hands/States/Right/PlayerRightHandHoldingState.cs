using Player.Animations;
using UnityHFSM;

namespace Player.FSM.Hands.States.Right
{
	internal class PlayerRightHandHoldingState : StateBase
	{
		protected ArmsAnimator _armsAnimator;

		protected PlayerItemDropper _itemDropper;

		public PlayerRightHandHoldingState(PlayerItemDropper itemDropper, ArmsAnimator armsAnimator, bool needsExitTime = false, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			name = "holding";
			_itemDropper = itemDropper;
			_armsAnimator = armsAnimator;
		}

		public override void OnEnter()
		{
			_armsAnimator.StartDrinkingAnimation();
		}
	}
}
