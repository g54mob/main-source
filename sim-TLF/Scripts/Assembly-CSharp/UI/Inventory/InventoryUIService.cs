using System;
using System.Collections.Generic;
using AssembleSystem;
using JSAM;
using Player;
using Player.FSM;
using UnityEngine;
using Zenject;

namespace UI.Inventory
{
	public class InventoryUIService : MonoBehaviour, IInventoryUIService, IInitializable
	{
		[SerializeField]
		private Transform _spawnPoint;

		[SerializeField]
		private InventoryUIItemRaycaster _inventoryRaycaster;

		[SerializeField]
		private InventoryUIItemMover _inventoryItemMover;

		[SerializeField]
		private InventoryUIItemEquiper _inventoryItemEquiper;

		[SerializeField]
		private InventoryUIItemUser _inventoryItemUser;

		[SerializeField]
		private InventoryUIItemDescriber _inventoryItemDescriber;

		[SerializeField]
		private InventoryUIItemOutliner _inventoryItemOutliner;

		[SerializeField]
		private InventoryUIItemDropper _inventoryItemDropper;

		private IMoveable _moveable;

		private bool _inventoryOpened;

		private List<IInventoryManagable> _partsInInventory = new List<IInventoryManagable>();

		[Inject]
		private IPlayerInputService _playerInputService;

		[Inject]
		private IPlayerEquipService _playerEquipToolService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private IAssembleSystemService _assembleSystemService;

		[Inject]
		private ICraftUIService _craftUIService;

		[Inject]
		private IPlayerStateMachineParametersManipulator _playerStateMachineParametersManipulator;

		[Inject]
		private DiContainer _diContainer;

		Action IInventoryUIService.OnItemOfTheInventoryView { get; set; }

		Action<IInventoryManagable> IInventoryUIService.OnItemAdded { get; set; }

		Action<IInventoryManagable> IInventoryUIService.OnItemRemoved { get; set; }

		Action<bool> IInventoryUIService.OnInventoryOpened { get; set; }

		bool IInventoryUIService.InventoryOpened => _inventoryOpened;

		IMoveable IInventoryUIService.MovingItem => _moveable;

		private void Awake()
		{
			_inventoryItemMover.enabled = true;
		}

		void IInventoryUIService.AddItem(IInventoryManagable part)
		{
			if (!_partsInInventory.Contains(part))
			{
				MonoBehaviour monoBehaviour = (MonoBehaviour)part;
				MeshRenderer component = monoBehaviour.GetComponent<MeshRenderer>();
				Vector3 vector = Vector3.zero;
				if (component != null)
				{
					vector = component.bounds.center - monoBehaviour.transform.position;
				}
				monoBehaviour.transform.position = _spawnPoint.position - vector;
				_partsInInventory.Add(part);
				((IInventoryUIService)this).OnItemAdded?.Invoke(part);
			}
		}

		void IInventoryUIService.RemoveItem(IInventoryManagable part)
		{
			_partsInInventory.Remove(part);
			((IInventoryUIService)this).OnItemRemoved?.Invoke(part);
		}

		void IInventoryUIService.OpenInventory()
		{
			AudioManager.PlaySound(UILibrarySounds.UIInventoryOpen);
			_inventoryRaycaster.enabled = true;
			_inventoryItemMover.enabled = true;
			_inventoryItemEquiper.enabled = true;
			_inventoryItemUser.enabled = true;
			_inventoryItemDescriber.enabled = true;
			_inventoryItemOutliner.enabled = true;
			_inventoryItemDropper.enabled = true;
			_inventoryOpened = true;
			_playerInputService.DisableLookAction();
			_playerInputService.DisablePlayerUseAction();
			_playerInputService.DisableInteractAction();
			Debug.Log("Inventory Opened");
			((IInventoryUIService)this).OnInventoryOpened?.Invoke(obj: true);
		}

		void IInventoryUIService.CloseInventory()
		{
			AudioManager.PlaySound(UILibrarySounds.UIInventoryClose);
			((IInventoryUIService)this).OnInventoryOpened?.Invoke(obj: false);
			_inventoryRaycaster.enabled = false;
			_inventoryItemMover.enabled = false;
			_inventoryItemEquiper.enabled = false;
			_inventoryItemUser.enabled = false;
			_inventoryItemDescriber.enabled = false;
			_inventoryItemOutliner.enabled = false;
			_inventoryItemDropper.enabled = false;
			_inventoryOpened = false;
			_playerInputService.EnableLookAction();
			_playerInputService.EnablePlayerUseAction();
			_playerInputService.EnableInteractAction();
			Debug.Log("Inventory Closed");
		}

		void IInventoryUIService.SetMovingItem(IMoveable moveable)
		{
			if (moveable != null)
			{
				Collider component = (moveable as MonoBehaviour).GetComponent<Collider>();
				if (component != null)
				{
					_inventoryItemOutliner.SetOutlinedObject(component);
				}
			}
			else
			{
				_inventoryItemOutliner.ClearOutlinedObject();
			}
			_moveable = moveable;
		}

		public void Initialize()
		{
			Debug.Log((_playerInputService == null) ? " input is null" : "input is not null");
			_inventoryItemMover.Init(_playerInputService, this, _inventoryService, _assembleSystemService, _craftUIService, _playerEquipToolService, _playerStateMachineParametersManipulator);
		}

		InventoryUIItemMover IInventoryUIService.GetItemMover()
		{
			return _inventoryItemMover;
		}
	}
}
