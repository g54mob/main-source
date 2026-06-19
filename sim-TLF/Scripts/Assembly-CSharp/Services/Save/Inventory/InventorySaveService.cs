using System;
using System.Collections.Generic;
using System.Linq;
using AssembleSystem;
using Cysharp.Threading.Tasks;
using Data.Save;
using UI.Inventory;
using UnityEngine;
using Zenject;

namespace Services.Save.Inventory
{
	public class InventorySaveService : ISaveable, ILateDisposable
	{
		public Action OnLoadComplete;

		private InventorySaveData _saveData;

		private readonly List<IInventorySaveable> _registeredItems = new List<IInventorySaveable>();

		private readonly ISaveService _saveService;

		private readonly IInventoryService _inventoryService;

		private readonly IInventoryUIService _inventoryUIService;

		private readonly DiContainer _diContainer;

		private readonly Transform _playerTransform;

		private readonly Dictionary<string, GameObject> _sceneItemsMap = new Dictionary<string, GameObject>();

		public string SaveKey => "Inventory";

		public int Priority => 20;

		public InventorySaveData SaveData => _saveData;

		public InventorySaveService(ISaveService saveService, IInventoryService inventoryService, IInventoryUIService inventoryUIService, DiContainer diContainer, Transform playerTransform)
		{
			_saveService = saveService;
			_inventoryService = inventoryService;
			_inventoryUIService = inventoryUIService;
			_diContainer = diContainer;
			_playerTransform = playerTransform;
			_saveService.Register(this);
		}

		public void TrackItem(IInventorySaveable item)
		{
			if (!_registeredItems.Contains(item))
			{
				_registeredItems.Add(item);
			}
		}

		public void UntrackItem(IInventorySaveable item)
		{
			_registeredItems.Remove(item);
		}

		public void RegisterSceneItem(string instanceId, GameObject go)
		{
			_sceneItemsMap[instanceId] = go;
		}

		public void UnregisterSceneItem(string instanceId)
		{
			_sceneItemsMap.Remove(instanceId);
		}

		public void OnSave()
		{
			List<InventoryItemSaveData> items = _registeredItems.Select((IInventorySaveable item) => new InventoryItemSaveData
			{
				InstanceId = item.InstanceId,
				AddressableKey = item.AddressableKey,
				IsSceneItem = item.IsSceneItem
			}).ToList();
			_saveService.Write(SaveKey, new InventorySaveData
			{
				Items = items
			});
		}

		public async UniTask OnLoad()
		{
			if (_saveService.TryRead<InventorySaveData>(SaveKey, out _saveData) && _saveData.Items != null)
			{
				OnLoadComplete?.Invoke();
			}
		}

		private async UniTask RestoreInventoryAsync(List<InventoryItemSaveData> items)
		{
			foreach (InventoryItemSaveData item in items)
			{
				if (item.IsSceneItem)
				{
					RestoreSceneItem(item);
				}
				else
				{
					await RestoreSpawnedItemAsync(item);
				}
			}
		}

		private void RestoreSceneItem(InventoryItemSaveData data)
		{
			if (!_sceneItemsMap.TryGetValue(data.InstanceId, out var value))
			{
				Debug.LogWarning("[InventorySaveService] Scene item not found: " + data.InstanceId);
				return;
			}
			value.SetActive(value: true);
			if (value.TryGetComponent<IInventoryManagable>(out var component))
			{
				_inventoryService.AddItem(component);
			}
		}

		private async UniTask RestoreSpawnedItemAsync(InventoryItemSaveData data)
		{
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}
	}
}
