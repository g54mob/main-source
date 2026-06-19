using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Services.Save.SceneItems
{
	public class SceneConsumablesRegistry : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private Dictionary<string, ConsumableData> _items = new Dictionary<string, ConsumableData>();

		public string SaveKey => "SceneConsumables";

		public int Priority => 5;

		internal event Action OnSaveStarted;

		internal event Action OnLoadCompleted;

		public SceneConsumablesRegistry(ISaveService saveService)
		{
			_saveService = saveService;
			_saveService.Register(this);
		}

		public void Save(string id, ConsumableData data)
		{
			_items[id] = data;
		}

		public bool TryGet(string id, out ConsumableData data)
		{
			return _items.TryGetValue(id, out data);
		}

		public void OnSave()
		{
			this.OnSaveStarted?.Invoke();
			_saveService.Write(SaveKey, _items);
		}

		public async UniTask OnLoad()
		{
			Debug.Log("[SceneConsumablesRegistry] OnLoad called");
			if (_saveService.TryRead<Dictionary<string, ConsumableData>>(SaveKey, out var data))
			{
				Debug.Log($"[SceneConsumablesRegistry] Read {data.Count} items from file");
				_items = data;
			}
			else
			{
				Debug.LogWarning("[SceneConsumablesRegistry] TryRead returned false — no saved data.");
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
