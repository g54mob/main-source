using AssembleSystem;
using JSAM;
using Player;
using Player.FSM;
using UI.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIItemMover : MonoBehaviour
{
	[SerializeField]
	private InventoryUIItemOutliner _inventoryItemOutliner;

	[SerializeField]
	private RaycasterInfo _inventoryItemRaycaster;

	[SerializeField]
	private RaycasterInfo _inventoryMoveRaycaster;

	[SerializeField]
	private RaycasterInfo _playerMoveRaycaster;

	[SerializeField]
	private Vector3 _moveOffset;

	private IPlayerInputService _playerInputService;

	private IPlayerEquipService _playerEquipToolService;

	private IInventoryUIService _inventoryUIService;

	private IInventoryService _inventoryService;

	private IAssembleSystemService _assembleSystemService;

	private ICraftUIService _craftUIService;

	private IPlayerStateMachineParametersManipulator _playerStateMachineParametersManipulator;

	public void Init(IPlayerInputService inputService, IInventoryUIService inventoryUIService, IInventoryService inventoryService, IAssembleSystemService assembleSystemService, ICraftUIService craftUIService, IPlayerEquipService playerEquipToolService, IPlayerStateMachineParametersManipulator playerStateMachineParametersManipulator)
	{
		_playerInputService = inputService;
		_inventoryUIService = inventoryUIService;
		_inventoryService = inventoryService;
		_assembleSystemService = assembleSystemService;
		_craftUIService = craftUIService;
		_playerEquipToolService = playerEquipToolService;
		_playerStateMachineParametersManipulator = playerStateMachineParametersManipulator;
		_playerInputService.OnInventoryInteract += TryPickupObject;
	}

	private void OnEnable()
	{
		if (_playerInputService != null)
		{
			_playerInputService.OnInventoryInteract += TryPickupObject;
		}
	}

	private void OnDisable()
	{
		_playerInputService.OnInventoryInteract -= TryPickupObject;
	}

	private void Update()
	{
		MovePickedObject();
	}

	private void MovePickedObject()
	{
		if (_inventoryUIService.MovingItem != null && _inventoryMoveRaycaster.Hit.transform != null)
		{
			_inventoryUIService.MovingItem.Move(_inventoryMoveRaycaster.Hit.point + _moveOffset);
		}
	}

	private void TryPickupObject(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			IMoveable component = null;
			if (_inventoryItemRaycaster.Hit.transform != null)
			{
				_inventoryItemRaycaster.Hit.transform.TryGetComponent<IMoveable>(out component);
			}
			if (component != null)
			{
				(component as MonoBehaviour).GetComponent<Rigidbody>().isKinematic = true;
				_inventoryUIService.SetMovingItem(component);
				AudioManager.PlaySound(UILibrarySounds.UIInventoryItemPick);
			}
		}
		if (context.canceled && _inventoryUIService.MovingItem != null)
		{
			(_inventoryUIService.MovingItem as MonoBehaviour).GetComponent<Rigidbody>().isKinematic = false;
			_inventoryUIService.SetMovingItem(null);
			AudioManager.PlaySound(UILibrarySounds.UIInventoryItemDrop);
		}
	}
}
