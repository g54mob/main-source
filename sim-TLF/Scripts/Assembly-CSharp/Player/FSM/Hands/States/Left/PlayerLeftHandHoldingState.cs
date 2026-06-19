using JSAM;
using Player.Animations;
using UnityHFSM;

namespace Player.FSM.Hands.States.Left
{
	public class PlayerLeftHandHoldingState : StateBase<string>
	{
		protected ArmsAnimator _armsAnimator;

		protected PlayerItemPicker _itemPicker;

		protected InventoryUIItemMover _inventoryItemMover;

		public PlayerLeftHandHoldingState(PlayerItemPicker itemPicker, InventoryUIItemMover inventoryItemMover, ArmsAnimator armsAnimator, bool needsExitTime = false, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			name = "holding";
			_itemPicker = itemPicker;
			_inventoryItemMover = inventoryItemMover;
			_armsAnimator = armsAnimator;
		}

		public override void OnEnter()
		{
			_itemPicker.enabled = false;
			_inventoryItemMover.enabled = false;
			_armsAnimator.StartSmokingAnimation();
			AudioManager.PlaySound(PlayerLibrarySounds.LighterStart);
		}
	}
}
