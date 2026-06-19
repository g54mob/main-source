using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Services.Save.Consumables;
using UnityEngine;
using Zenject;

namespace Services.Save.SpawnedItems
{
	public class SpawnedConsumablesRegistry : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private Dictionary<string, SpawnedConsumableData> _items = new Dictionary<string, SpawnedConsumableData>();

		public string SaveKey => "SpawnedConsumables";

		public int Priority => 0;

		internal event Action OnSaveStarted;

		internal event Action OnLoadCompleted;

		public SpawnedConsumablesRegistry(ISaveService saveService)
		{
			_saveService = saveService;
			_saveService.Register(this);
		}

		public void Save(string instanceId, SpawnedConsumableData data)
		{
			_items[instanceId] = data;
		}

		public void Remove(string instanceId)
		{
			_items.Remove(instanceId);
		}

		public bool TryGet(string instanceId, out SpawnedConsumableData data)
		{
			return _items.TryGetValue(instanceId, out data);
		}

		public void OnSave()
		{
			this.OnSaveStarted?.Invoke();
			_saveService.Write(SaveKey, _items);
		}

		public async UniTask OnLoad()
		{
			Debug.Log("[SpawnedConsumablesRegistry] OnLoad called");
			if (_saveService.TryRead<Dictionary<string, SpawnedConsumableData>>(SaveKey, out var data))
			{
				Debug.Log($"[SpawnedConsumablesRegistry] Read {data.Count} items from file");
				_items = data;
			}
			else
			{
				Debug.LogWarning("[SpawnedConsumablesRegistry] TryRead returned false — no saved data.");
			}
			this.OnLoadCompleted?.Invoke();
			await UniTask.CompletedTask;
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}
	}
}
