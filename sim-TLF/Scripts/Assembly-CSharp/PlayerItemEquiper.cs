using AssembleSystem;
using Items;
using Player;
using UI.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerItemEquiper : MonoBehaviour
{
	[SerializeField]
	private RaycasterInfo _playerRaycasterInfo;

	[Inject]
	private IInventoryUIService _inventoryUIService;

	[Inject]
	private IInventoryService _inventoryService;

	[Inject]
	private IPlayerInputService _playerInputService;

	[Inject]
	private IPlayerEquipService _playerEquipService;

	private void Awake()
	{
		_playerEquipService.EquippedItems.Clear();
	}

	private void OnEnable()
	{
		_playerInputService.OnPlayerUse += OnEquip;
	}

	private void OnDisable()
	{
		_playerInputService.OnPlayerUse -= OnEquip;
	}

	private void OnEquip(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			Transform transform = _playerRaycasterInfo.Hit.transform;
			if (!(transform == null) && transform.TryGetComponent<IEquipable>(out var component))
			{
				_inventoryService.AddItem(component as IInventoryManagable);
				_inventoryUIService.AddItem(component as IInventoryManagable);
				_playerEquipService.TryEquip(component);
			}
		}
	}
}
