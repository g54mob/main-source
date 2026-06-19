using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Services.Save.SpawnedItems
{
	public class SpawnedItemsRegistry : ISaveable, ILateDisposable, IInitializable
	{
		[Serializable]
		public struct SpawnedItemData
		{
			public string AddressableKey;

			public Vector3 Position;

			public Vector3 Rotation;
		}

		private readonly ISaveService _saveService;

		private readonly DiContainer _diContainer;

		private Dictionary<string, SpawnedItemData> _items = new Dictionary<string, SpawnedItemData>();

		private Transform _parent;

		public string SaveKey => "SpawnedItems";

		public int Priority => 0;

		public Dictionary<string, SpawnedItemData> Items => _items;

		internal event Action OnSaveStarted;

		public event Action OnLoadComplete;

		public SpawnedItemsRegistry(ISaveService saveService, DiContainer diContainer)
		{
			_saveService = saveService;
			_diContainer = diContainer;
			Debug.Log("[SpawnedItemsRegistry] Initialized");
			_saveService.Register(this);
		}

		public void Initialize()
		{
			_parent = UnityEngine.Object.FindAnyObjectByType<SceneGameLoader>().transform;
		}

		public void Track(string instanceId, string addressableKey, Vector3 pos, Vector3 rot)
		{
			Debug.Log($"[SpawnedItemsRegistry] Track -> ID: {instanceId}, Key: {addressableKey}, Pos: {pos}");
			_items[instanceId] = new SpawnedItemData
			{
				AddressableKey = addressableKey,
				Position = pos,
				Rotation = rot
			};
		}

		public void Untrack(string instanceId)
		{
			Debug.Log("[SpawnedItemsRegistry] Untrack -> ID: " + instanceId);
			_items.Remove(instanceId);
		}

		public bool TryGet(string instanceId, out SpawnedItemData data)
		{
			bool flag = _items.TryGetValue(instanceId, out data);
			Debug.Log($"[SpawnedItemsRegistry] TryGet -> ID: {instanceId}, Found: {flag}");
			return flag;
		}

		public void OnSave()
		{
			Debug.Log($"[SpawnedItemsRegistry] SAVE STARTED. Items count: {_items.Count}");
			this.OnSaveStarted?.Invoke();
			foreach (var (arg, spawnedItemData2) in _items)
			{
				Debug.Log($"[SpawnedItemsRegistry] Saving -> ID: {arg}, Key: {spawnedItemData2.AddressableKey}, Pos: {spawnedItemData2.Position}");
			}
			_saveService.Write(SaveKey, _items);
			Debug.Log("[SpawnedItemsRegistry] SAVE COMPLETE");
		}

		public async UniTask OnLoad()
		{
			Debug.Log("[SpawnedItemsRegistry] LOAD STARTED");
			if (!_saveService.TryRead<Dictionary<string, SpawnedItemData>>(SaveKey, out var data))
			{
				Debug.LogWarning("[SpawnedItemsRegistry] No saved data found");
				return;
			}
			_items = data;
			Debug.Log($"[SpawnedItemsRegistry] Loaded {_items.Count} items from save");
			await RestoreAllAsync();
			Debug.Log("[SpawnedItemsRegistry] LOAD COMPLETE");
		}

		private async UniTask RestoreAllAsync()
		{
			Debug.Log("[SpawnedItemsRegistry] RestoreAllAsync START");
			List<UniTask> list = new List<UniTask>();
			foreach (var (text2, data) in _items)
			{
				if (string.IsNullOrEmpty(data.AddressableKey))
				{
					Debug.Log("[SpawnedItemsRegistry] Skip re-spawn (structure-spawned) -> ID: " + text2);
					continue;
				}
				Debug.Log("[SpawnedItemsRegistry] Queue spawn -> ID: " + text2 + ", Key: " + data.AddressableKey);
				list.Add(SpawnOneAsync(text2, data));
			}
			await UniTask.WhenAll(list);
			Debug.Log("[SpawnedItemsRegistry] All items spawned");
			this.OnLoadComplete?.Invoke();
		}

		private async UniTask SpawnOneAsync(string instanceId, SpawnedItemData data)
		{
			Debug.Log("[SpawnedItemsRegistry] Spawn START -> ID: " + instanceId + ", Key: " + data.AddressableKey);
			try
			{
				GameObject prefab = await Addressables.LoadAssetAsync<GameObject>(data.AddressableKey);
				Debug.Log("[SpawnedItemsRegistry] Prefab loaded -> " + data.AddressableKey);
				GameObject gameObject = _diContainer.InstantiatePrefab(prefab, _parent);
				gameObject.transform.SetPositionAndRotation(data.Position, Quaternion.Euler(data.Rotation));
				Debug.Log("[SpawnedItemsRegistry] Instantiated -> " + gameObject.name + " (ID: " + instanceId + ")");
				SpawnedItemSaveInitializer.Init(gameObject, instanceId, data.AddressableKey, _diContainer);
				Debug.Log("[SpawnedItemsRegistry] Initialized save component -> " + instanceId);
				Debug.Log("[SpawnedItemsRegistry] Released prefab -> " + data.AddressableKey);
			}
			catch (Exception arg)
			{
				Debug.LogError($"[SpawnedItemsRegistry] FAILED -> ID: {instanceId}, Key: {data.AddressableKey}\n{arg}");
			}
		}

		public void LateDispose()
		{
			Debug.Log("[SpawnedItemsRegistry] Disposed");
			_saveService.Unregister(this);
		}
	}
}
