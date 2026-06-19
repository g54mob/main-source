using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Services.Save
{
	public class SaveService : ISaveService, IInitializable, IDisposable
	{
		private readonly List<ISaveable> _saveables = new List<ISaveable>();

		private readonly IJsonFileStorage _storage;

		public event Action OnSaveStarted;

		public event Action OnSaveCompleted;

		public event Action OnLoadStarted;

		public event Action OnLoadCompleted;

		public SaveService(IJsonFileStorage storage)
		{
			_storage = storage;
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void Register(ISaveable saveable)
		{
			if (!_saveables.Contains(saveable))
			{
				_saveables.Add(saveable);
			}
		}

		public void Unregister(ISaveable saveable)
		{
			_saveables.Remove(saveable);
		}

		public void SaveAll()
		{
			this.OnSaveStarted?.Invoke();
			foreach (ISaveable item in Sorted())
			{
				SaveOne(item);
			}
			this.OnSaveCompleted?.Invoke();
		}

		public void LoadAll()
		{
			this.OnLoadStarted?.Invoke();
			foreach (ISaveable item in Sorted())
			{
				LoadOne(item);
			}
			this.OnLoadCompleted?.Invoke();
		}

		public async UniTask LoadAllAsync()
		{
			this.OnLoadStarted?.Invoke();
			List<ISaveable> list = _saveables.OrderBy((ISaveable s) => s.Priority).ToList();
			foreach (ISaveable item in list)
			{
				await item.OnLoad();
			}
			this.OnLoadCompleted?.Invoke();
		}

		public void Save(string key)
		{
			ISaveable saveable = Find(key);
			if (saveable != null)
			{
				SaveOne(saveable);
			}
		}

		public void Load(string key)
		{
			ISaveable saveable = Find(key);
			if (saveable != null)
			{
				LoadOne(saveable);
			}
		}

		public void Write<T>(string key, T data)
		{
			_storage.Write(key, data);
		}

		public bool TryRead<T>(string key, out T data)
		{
			return _storage.TryRead<T>(key, out data);
		}

		public void DeleteKey(string key)
		{
			_storage.DeleteKey(key);
		}

		public void DeleteAll()
		{
			_storage.DeleteAll();
		}

		private void SaveOne(ISaveable s)
		{
			try
			{
				s.OnSave();
				Debug.Log("[SaveService] Saved  → " + s.SaveKey);
			}
			catch (Exception arg)
			{
				Debug.LogError($"[SaveService] Error saving {s.SaveKey}: {arg}");
			}
		}

		private void LoadOne(ISaveable s)
		{
			try
			{
				s.OnLoad();
				Debug.Log("[SaveService] Loaded → " + s.SaveKey);
			}
			catch (Exception arg)
			{
				Debug.LogError($"[SaveService] Error loading {s.SaveKey}: {arg}");
			}
		}

		private IEnumerable<ISaveable> Sorted()
		{
			return _saveables.OrderBy((ISaveable s) => s.Priority);
		}

		private ISaveable Find(string key)
		{
			ISaveable saveable = _saveables.FirstOrDefault((ISaveable x) => x.SaveKey == key);
			if (saveable == null)
			{
				Debug.LogWarning("[SaveService] Key not found: '" + key + "'");
			}
			return saveable;
		}
	}
}
