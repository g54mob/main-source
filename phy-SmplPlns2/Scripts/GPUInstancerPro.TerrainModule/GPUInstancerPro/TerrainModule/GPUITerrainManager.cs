using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPUInstancerPro.TerrainModule
{
	public abstract class GPUITerrainManager<T> : GPUIManagerWithPrototypeData<T> where T : GPUIPrototypeData, new()
	{
		[SerializeField]
		private List<GPUITerrain> _gpuiTerrains;

		[SerializeField]
		protected bool _isAutoAddPrototypesBasedOnTerrains = true;

		[SerializeField]
		protected bool _isAutoAddActiveTerrainsOnInitialization;

		[NonSerialized]
		private Dictionary<int, GPUITerrain> _activeTerrains;

		[NonSerialized]
		protected bool _isTerrainsModified;

		[NonSerialized]
		private HashSet<int> _toRemoveActiveTerrains;

		[NonSerialized]
		private Dictionary<int, GPUITerrain> _gpuiTerrainsDict;

		private const int ERROR_CODE_ADDITION = 300;

		private Predicate<GPUITerrain> _isNullTerrainPredicate;

		protected override void Awake()
		{
			base.Awake();
			if (_gpuiTerrains == null)
			{
				_gpuiTerrains = new List<GPUITerrain>();
			}
			_isNullTerrainPredicate = IsNullTerrain;
		}

		protected override void LateUpdate()
		{
			base.LateUpdate();
			if (!base.IsInitialized)
			{
				return;
			}
			if (_isTerrainsModified)
			{
				ApplyTerrainModifications();
			}
			foreach (GPUITerrain activeTerrainValue in GetActiveTerrainValues())
			{
				if (activeTerrainValue != null && activeTerrainValue.IsInitialized)
				{
					activeTerrainValue.NotifyTransformChanges();
				}
			}
		}

		public override bool IsValid(bool logError = true)
		{
			if (!base.IsValid(logError))
			{
				return false;
			}
			if (GetTerrainCount() == 0)
			{
				errorCode = -301;
				return false;
			}
			return true;
		}

		public override void Initialize()
		{
			base.Initialize();
			_isNullTerrainPredicate = IsNullTerrain;
			_toRemoveActiveTerrains = new HashSet<int>();
			_gpuiTerrainsDict = new Dictionary<int, GPUITerrain>();
			_activeTerrains = new Dictionary<int, GPUITerrain>();
			if (_gpuiTerrains == null)
			{
				_gpuiTerrains = new List<GPUITerrain>();
			}
			DeterminePrototypeIndexes();
			if (_isAutoAddActiveTerrainsOnInitialization)
			{
				AddActiveTerrains();
				SceneManager.sceneLoaded += AddActiveTerrains;
			}
			UpdateActiveTerrains();
		}

		public override void Dispose()
		{
			SceneManager.sceneLoaded -= AddActiveTerrains;
			if (isEnableDefaultRenderingWhenDisabled && _activeTerrains != null)
			{
				foreach (GPUITerrain value in _activeTerrains.Values)
				{
					if (value != null)
					{
						RemoveGPUITerrainManager(value);
					}
				}
			}
			base.Dispose();
			if (base.IsInitialized)
			{
				_activeTerrains = null;
				_toRemoveActiveTerrains = null;
				_gpuiTerrainsDict = null;
			}
		}

		public void OnTerrainsModified()
		{
			_isTerrainsModified = true;
		}

		private void ApplyTerrainModifications()
		{
			IsValid(Application.isPlaying);
			if (_isAutoAddPrototypesBasedOnTerrains)
			{
				AddMissingPrototypes();
			}
			UpdateActiveTerrains();
			_isTerrainsModified = false;
		}

		private void UpdateActiveTerrains()
		{
			if (!base.IsInitialized)
			{
				return;
			}
			_gpuiTerrainsDict.Clear();
			foreach (GPUITerrain gpuiTerrain in _gpuiTerrains)
			{
				if (gpuiTerrain != null)
				{
					_gpuiTerrainsDict[gpuiTerrain.GetInstanceID()] = gpuiTerrain;
				}
			}
			bool flag = false;
			foreach (KeyValuePair<int, GPUITerrain> activeTerrain in _activeTerrains)
			{
				if (!_toRemoveActiveTerrains.Contains(activeTerrain.Key))
				{
					if (activeTerrain.Value == null)
					{
						_toRemoveActiveTerrains.Add(activeTerrain.Key);
					}
					else if (!_gpuiTerrainsDict.ContainsKey(activeTerrain.Key))
					{
						_toRemoveActiveTerrains.Add(activeTerrain.Key);
						RemoveGPUITerrainManager(activeTerrain.Value);
					}
				}
			}
			foreach (int toRemoveActiveTerrain in _toRemoveActiveTerrains)
			{
				if (_activeTerrains.ContainsKey(toRemoveActiveTerrain))
				{
					_activeTerrains.Remove(toRemoveActiveTerrain);
					flag = true;
				}
			}
			_toRemoveActiveTerrains.Clear();
			foreach (KeyValuePair<int, GPUITerrain> item in _gpuiTerrainsDict)
			{
				if (!_activeTerrains.ContainsKey(item.Key))
				{
					_activeTerrains.Add(item.Key, item.Value);
					SetGPUITerrainManager(item.Value);
					flag = true;
				}
			}
			if (flag)
			{
				RequireUpdate();
			}
		}

		public void RemoveNullTerrains()
		{
			if (_isNullTerrainPredicate == null)
			{
				_isNullTerrainPredicate = IsNullTerrain;
			}
			_gpuiTerrains.RemoveAll(_isNullTerrainPredicate);
			OnTerrainsModified();
		}

		public void AddTerrains(IEnumerable<Terrain> terrains)
		{
			if (terrains == null)
			{
				return;
			}
			foreach (Terrain terrain in terrains)
			{
				AddTerrain(terrain);
			}
		}

		public void AddTerrains(IEnumerable<GPUITerrain> terrains)
		{
			if (terrains == null)
			{
				return;
			}
			foreach (GPUITerrain terrain in terrains)
			{
				AddTerrain(terrain);
			}
		}

		public bool AddTerrain(Terrain terrain)
		{
			if (terrain == null)
			{
				return false;
			}
			if (_gpuiTerrains.Count == 0)
			{
				OnFirstTerrainAdded(terrain);
			}
			return AddTerrain(terrain.AddOrGetComponent<GPUITerrainBuiltin>());
		}

		public bool AddTerrain(GPUITerrain terrain)
		{
			if (terrain == null)
			{
				return false;
			}
			if (_gpuiTerrains.Contains(terrain))
			{
				return false;
			}
			_gpuiTerrains.Add(terrain);
			OnTerrainsModified();
			return true;
		}

		private void AddActiveTerrains(Scene arg0, LoadSceneMode arg1)
		{
			AddActiveTerrains();
		}

		public void AddActiveTerrains()
		{
			AddTerrains(Terrain.activeTerrains);
		}

		public bool RemoveTerrain(Terrain terrain)
		{
			if (terrain.TryGetComponent<GPUITerrainBuiltin>(out var component))
			{
				return RemoveTerrain(component);
			}
			return false;
		}

		public bool RemoveTerrain(GPUITerrain gpuiTerrain)
		{
			if (base.IsInitialized)
			{
				_toRemoveActiveTerrains.Add(gpuiTerrain.GetInstanceID());
			}
			int num = _gpuiTerrains.IndexOf(gpuiTerrain);
			if (num >= 0)
			{
				return Internal_RemoveTerrainAtIndex(num);
			}
			return false;
		}

		public bool RemoveTerrainAtIndex(int index)
		{
			if (index >= 0 && _gpuiTerrains.Count > index)
			{
				return Internal_RemoveTerrainAtIndex(index);
			}
			return false;
		}

		private bool Internal_RemoveTerrainAtIndex(int index)
		{
			_gpuiTerrains.RemoveAt(index);
			OnTerrainsModified();
			return true;
		}

		public bool ContainsTerrains(IEnumerable<Terrain> terrains)
		{
			if (terrains == null)
			{
				return true;
			}
			foreach (Terrain terrain in terrains)
			{
				if (!ContainsTerrain(terrain))
				{
					return false;
				}
			}
			return true;
		}

		public bool ContainsTerrains(IEnumerable<GPUITerrain> gpuiTerrains)
		{
			if (gpuiTerrains == null)
			{
				return true;
			}
			foreach (GPUITerrain gpuiTerrain in gpuiTerrains)
			{
				if (!ContainsTerrain(gpuiTerrain))
				{
					return false;
				}
			}
			return true;
		}

		public bool ContainsTerrain(Terrain terrain)
		{
			if (terrain == null)
			{
				return true;
			}
			foreach (GPUITerrain gpuiTerrain in _gpuiTerrains)
			{
				if (gpuiTerrain != null && gpuiTerrain is GPUITerrainBuiltin gPUITerrainBuiltin && gPUITerrainBuiltin.GetTerrain() == terrain)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsTerrain(GPUITerrain gpuiTerrain)
		{
			if (gpuiTerrain == null || _gpuiTerrains.Contains(gpuiTerrain))
			{
				return true;
			}
			return false;
		}

		protected virtual void OnFirstTerrainAdded(Terrain terrain)
		{
		}

		public void ResetPrototypesFromTerrains()
		{
			if (GetTerrainCount() != 0)
			{
				bool isInitialized = base.IsInitialized;
				Dispose();
				DeterminePrototypeIndexes();
				RemoveUnusedPrototypes();
				AddMissingPrototypes();
				if (isInitialized)
				{
					Initialize();
				}
			}
		}

		private bool RemoveUnusedPrototypes()
		{
			int num = GetPrototypeCount();
			bool flag = false;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					if (!PrototypeHasMatchOnTerrains(i))
					{
						RemovePrototypeAtIndex(i);
						i--;
						num--;
						flag = true;
					}
				}
			}
			if (flag)
			{
				DeterminePrototypeIndexes();
			}
			return flag;
		}

		private bool AddMissingPrototypes()
		{
			bool flag = false;
			int terrainCount = GetTerrainCount();
			for (int i = 0; i < terrainCount; i++)
			{
				GPUITerrain terrain = GetTerrain(i);
				if (!(terrain == null))
				{
					flag |= AddMissingPrototypesFromTerrain(terrain);
				}
			}
			if (flag)
			{
				DeterminePrototypeIndexes();
			}
			return flag;
		}

		protected abstract bool AddMissingPrototypesFromTerrain(GPUITerrain gpuiTerrain);

		private bool PrototypeHasMatchOnTerrains(int prototypeIndex)
		{
			int terrainCount = GetTerrainCount();
			for (int i = 0; i < terrainCount; i++)
			{
				GPUITerrain terrain = GetTerrain(i);
				if (!(terrain == null) && GetTerrainPrototypeIndex(terrain, prototypeIndex) >= 0)
				{
					return true;
				}
			}
			return false;
		}

		private void DeterminePrototypeIndexes()
		{
			BeginDeterminePrototypeIndexes();
			int terrainCount = GetTerrainCount();
			for (int i = 0; i < terrainCount; i++)
			{
				GPUITerrain terrain = GetTerrain(i);
				if (!(terrain == null))
				{
					DeterminePrototypeIndexes(terrain);
				}
			}
		}

		protected virtual void BeginDeterminePrototypeIndexes()
		{
		}

		protected abstract void DeterminePrototypeIndexes(GPUITerrain gpuiTerrain);

		protected abstract void SetGPUITerrainManager(GPUITerrain gpuiTerrain);

		protected abstract void RemoveGPUITerrainManager(GPUITerrain gpuiTerrain);

		protected abstract int[] GetTerrainPrototypeIndexes(GPUITerrain gpuiTerrain);

		protected int GetTerrainPrototypeIndex(GPUITerrain gpuiTerrain, int managerPrototypeIndex)
		{
			int[] terrainPrototypeIndexes = GetTerrainPrototypeIndexes(gpuiTerrain);
			if (terrainPrototypeIndexes == null)
			{
				return -1;
			}
			for (int i = 0; i < terrainPrototypeIndexes.Length; i++)
			{
				if (terrainPrototypeIndexes[i] == managerPrototypeIndex)
				{
					return i;
				}
			}
			return -1;
		}

		public override void OnPrototypeEnabledStatusChanged(int prototypeIndex, bool isEnabled)
		{
			base.OnPrototypeEnabledStatusChanged(prototypeIndex, isEnabled);
			RequireUpdate();
		}

		public override void RemovePrototypeAtIndex(int index)
		{
			base.RemovePrototypeAtIndex(index);
			DeterminePrototypeIndexes();
		}

		public abstract void RequireUpdate();

		public int GetTerrainCount()
		{
			return _gpuiTerrains.Count;
		}

		public void ReloadTerrains()
		{
			foreach (GPUITerrain gpuiTerrain in _gpuiTerrains)
			{
				if (!(gpuiTerrain == null))
				{
					gpuiTerrain.LoadTerrainData();
				}
			}
		}

		public int GetActiveTerrainCount()
		{
			return _activeTerrains.Count;
		}

		public GPUITerrain GetTerrain(int terrainIndex)
		{
			if (terrainIndex < _gpuiTerrains.Count)
			{
				return _gpuiTerrains[terrainIndex];
			}
			return null;
		}

		public Dictionary<int, GPUITerrain>.ValueCollection GetActiveTerrainValues()
		{
			return _activeTerrains.Values;
		}

		private bool IsNullTerrain(GPUITerrain t)
		{
			return t == null;
		}

		public IEnumerable<TerrainLayer> GetAllTerrainLayers()
		{
			if (_gpuiTerrains == null || _gpuiTerrains.Count == 0)
			{
				return null;
			}
			List<TerrainLayer> list = new List<TerrainLayer>();
			foreach (GPUITerrain gpuiTerrain in _gpuiTerrains)
			{
				if (gpuiTerrain == null)
				{
					continue;
				}
				TerrainLayer[] terrainLayers = gpuiTerrain.GetTerrainLayers();
				if (terrainLayers == null || terrainLayers.Length == 0)
				{
					continue;
				}
				TerrainLayer[] array = terrainLayers;
				foreach (TerrainLayer item in array)
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
	}
}
