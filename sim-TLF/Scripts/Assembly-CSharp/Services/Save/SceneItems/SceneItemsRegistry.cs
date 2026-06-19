using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Services.Save.SceneItems
{
	public class SceneItemsRegistry : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private Dictionary<string, TransformData> _items = new Dictionary<string, TransformData>();

		public string SaveKey => "SceneItems";

		public int Priority => 5;

		internal event Action OnSaveStarted;

		internal event Action OnLoadCompleted;

		public SceneItemsRegistry(ISaveService saveService)
		{
			_saveService = saveService;
			_saveService.Register(this);
		}

		public void Save(string id, Vector3 position, Vector3 rotation)
		{
			_items[id] = new TransformData
			{
				Position = position,
				Rotation = rotation
			};
		}

		public bool TryGet(string id, out TransformData data)
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
			Debug.Log("[Registry] OnLoad called");
			if (_saveService.TryRead<Dictionary<string, TransformData>>(SaveKey, out var data))
			{
				Debug.Log($"[Registry] Read {data.Count} items from file");
				foreach (KeyValuePair<string, TransformData> item in data)
				{
					Debug.Log($"  {item.Key} → pos:{item.Value.Position}");
				}
				_items = data;
			}
			else
			{
				Debug.LogWarning("[Registry] TryRead returned false!");
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
