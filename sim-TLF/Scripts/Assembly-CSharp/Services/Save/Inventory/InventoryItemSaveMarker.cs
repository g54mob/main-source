using System;
using System.Linq;
using AssembleSystem;
using Data.Save;
using Services.Save.SceneItems;
using Services.Save.SpawnedItems;
using UnityEngine;
using Zenject;

namespace Services.Save.Inventory
{
	public class InventoryItemSaveMarker : MonoBehaviour, IInventorySaveable
	{
		[SerializeField]
		private bool _isSceneItem;

		private string _instanceId;

		private string _addressableKey;

		[Inject]
		private InventorySaveService _inventorySaveService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private SpawnedItemsRegistry _spawnedItemsRegistry;

		public string InstanceId => _instanceId;

		public string AddressableKey => _addressableKey;

		public bool IsSceneItem => _isSceneItem;

		private void Awake()
		{
			if (_isSceneItem)
			{
				Init(isSceneItem: true);
			}
		}

		public void Init(bool isSceneItem)
		{
			_isSceneItem = isSceneItem;
			SpawnedItemSaveHandler component2;
			if (_isSceneItem)
			{
				if (TryGetComponent<SceneItemSaveHandler>(out var component))
				{
					_instanceId = component.SaveKey;
				}
				_inventorySaveService.RegisterSceneItem(_instanceId, base.gameObject);
			}
			else if (TryGetComponent<SpawnedItemSaveHandler>(out component2))
			{
				_instanceId = component2.InstanceId;
				_addressableKey = component2.AddressableKey;
			}
			InventorySaveService inventorySaveService = _inventorySaveService;
			inventorySaveService.OnLoadComplete = (Action)Delegate.Combine(inventorySaveService.OnLoadComplete, new Action(OnLoad));
			IInventoryService inventoryService = _inventoryService;
			inventoryService.OnItemPicked = (Action<IInventoryManagable>)Delegate.Combine(inventoryService.OnItemPicked, new Action<IInventoryManagable>(OnItemPicked));
			IInventoryService inventoryService2 = _inventoryService;
			inventoryService2.OnItemDropped = (Action<IInventoryManagable>)Delegate.Combine(inventoryService2.OnItemDropped, new Action<IInventoryManagable>(OnItemDropped));
		}

		private void OnLoad()
		{
			if (_inventorySaveService.SaveData.Items != null && _inventorySaveService.SaveData.Items.Any((InventoryItemSaveData x) => x.InstanceId == _instanceId))
			{
				_inventoryService.AddItem(GetComponent<IInventoryManagable>());
			}
		}

		private void OnDestroy()
		{
			if (_isSceneItem)
			{
				_inventorySaveService.UnregisterSceneItem(_instanceId);
			}
			InventorySaveService inventorySaveService = _inventorySaveService;
			inventorySaveService.OnLoadComplete = (Action)Delegate.Remove(inventorySaveService.OnLoadComplete, new Action(OnLoad));
			IInventoryService inventoryService = _inventoryService;
			inventoryService.OnItemPicked = (Action<IInventoryManagable>)Delegate.Remove(inventoryService.OnItemPicked, new Action<IInventoryManagable>(OnItemPicked));
			IInventoryService inventoryService2 = _inventoryService;
			inventoryService2.OnItemDropped = (Action<IInventoryManagable>)Delegate.Remove(inventoryService2.OnItemDropped, new Action<IInventoryManagable>(OnItemDropped));
		}

		private void OnItemPicked(IInventoryManagable item)
		{
			if (item == GetComponent<IInventoryManagable>())
			{
				_inventorySaveService.TrackItem(this);
			}
		}

		private void OnItemDropped(IInventoryManagable item)
		{
			if (item == GetComponent<IInventoryManagable>())
			{
				_inventorySaveService.UntrackItem(this);
			}
		}
	}
}
