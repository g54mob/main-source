using Player.Animations;
using UnityHFSM;
using Zenject;

namespace Player.FSM.Hands.States.Left
{
	internal class PlayerLeftHandIdleState : StateBase<string>
	{
		protected ArmsAnimator _armsAnimator;

		protected PlayerItemPicker _itemPicker;

		protected InventoryUIItemMover _inventoryItemMover;

		[Inject]
		private IPlayerInputService _playerInputService;

		public PlayerLeftHandIdleState(PlayerItemPicker itemPicker, InventoryUIItemMover inventoryItemMover, ArmsAnimator armsAnimator, bool needsExitTime = false, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			name = "idle";
			_itemPicker = itemPicker;
			_inventoryItemMover = inventoryItemMover;
			_armsAnimator = armsAnimator;
		}

		public override void OnEnter()
		{
			_itemPicker.enabled = true;
			_inventoryItemMover.enabled = true;
			_armsAnimator.StopSmokingAnimation();
		}
	}
}
