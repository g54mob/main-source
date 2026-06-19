using System.Collections.Generic;
using Items;
using Player;
using Player.FSM;
using UnityEngine;
using Zenject;

namespace UI.Inventory
{
	public class InventoryUIItemEquiper : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _inventoryRaycaster;

		[Inject]
		private IPlayerInputService _playerInputService;

		[Inject]
		private IPlayerEquipService _playerEquipService;

		private readonly Dictionary<EquipSide, IEquipable> _equippedItems = new Dictionary<EquipSide, IEquipable>();

		private void OnEnable()
		{
			_playerInputService.OnInventoryUse += OnEquip;
		}

		private void OnDisable()
		{
			_playerInputService.OnInventoryUse -= OnEquip;
		}

		private void OnEquip(bool pressed)
		{
			if (pressed)
			{
				Transform transform = _inventoryRaycaster.Hit.transform;
				if (!(transform == null) && transform.TryGetComponent<IEquipable>(out var component))
				{
					_playerEquipService.TryEquip(component);
				}
			}
		}
	}
}
