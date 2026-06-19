using AssembleSystem;
using AssembleSystem.FSM.Parts;
using Cysharp.Threading.Tasks;
using Items;
using UI.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityHFSM;

namespace Player.FSM.States
{
	internal class PlayerInventoryItemPacingState : StateBase<StateIdentifier>
	{
		private readonly IInventoryUIService _inventoryUIService;

		private readonly IInventoryService _inventoryService;

		private readonly RaycasterInfo _playerRaycasterInfo;

		private readonly IPlayerInputService _playerInputService;

		private readonly IPlayerStateMachineParametersManipulator _playerStateMachineParametersManipulator;

		private readonly Vector3 _moveOffset;

		private readonly PlayerItemHolder _itemHolder;

		private readonly PlayerItemPicker _itemPicker;

		private readonly Transform _inventoryItemsSpawnPoint;

		private IMoveable _currentMovingWorldItem;

		public PlayerInventoryItemPacingState(IPlayerInputService playerInputService, RaycasterInfo playerRaycasterInfo, IInventoryUIService inventoryUIService, IPlayerStateMachineParametersManipulator playerStateMachineParametersManipulator, IInventoryService inventoryService, Vector3 moveOffset, PlayerItemHolder itemHolder, Transform inventoryItemsSpawnPoint, PlayerItemPicker itemPicker, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_inventoryUIService = inventoryUIService;
			_playerRaycasterInfo = playerRaycasterInfo;
			_playerInputService = playerInputService;
			_playerStateMachineParametersManipulator = playerStateMachineParametersManipulator;
			_inventoryService = inventoryService;
			_moveOffset = moveOffset;
			_itemHolder = itemHolder;
			_inventoryItemsSpawnPoint = inventoryItemsSpawnPoint;
			_itemPicker = itemPicker;
		}

		public override void OnEnter()
		{
			_itemPicker.enabled = false;
			_playerInputService.OnInteract += ExitToDefaultState;
			IInventoryManagable inventoryManagable = _inventoryUIService.MovingItem as IInventoryManagable;
			_currentMovingWorldItem = inventoryManagable as IMoveable;
			Rigidbody component = (inventoryManagable as MonoBehaviour).GetComponent<Rigidbody>();
			if (component != null)
			{
				MeshRenderer component2 = component.GetComponent<MeshRenderer>();
				if (component2 != null)
				{
					Vector3 vector = component2.bounds.center - component.transform.position;
					component.transform.position = _inventoryItemsSpawnPoint.position - vector;
				}
				else
				{
					component.transform.position = _inventoryItemsSpawnPoint.position;
				}
				GrabAfterOneFrame(component).Forget();
			}
		}

		private async UniTaskVoid GrabAfterOneFrame(Rigidbody itemRb)
		{
			await UniTask.WaitForEndOfFrame();
			await UniTask.WaitForEndOfFrame();
			itemRb.isKinematic = false;
			_itemHolder.Grab(itemRb);
		}

		public override void OnExit()
		{
			_inventoryService.RemoveItem(_currentMovingWorldItem as IInventoryManagable);
			_inventoryUIService.RemoveItem(_currentMovingWorldItem as IInventoryManagable);
			_inventoryUIService.SetMovingItem(null);
			if (_currentMovingWorldItem is IEquipable equipable)
			{
				equipable.Unequip();
			}
			else if (_currentMovingWorldItem is PartObject partObject)
			{
				partObject.GetComponent<PartObjectStateMachine>().InInventoryParentPlaced = false;
			}
			_playerInputService.OnInteract -= ExitToDefaultState;
		}

		private void ExitToDefaultState(InputAction.CallbackContext context)
		{
			if (context.canceled)
			{
				_playerStateMachineParametersManipulator.SetPlacingItemFromInventory(inPlace: false);
				_itemPicker.enabled = true;
			}
		}
	}
}
