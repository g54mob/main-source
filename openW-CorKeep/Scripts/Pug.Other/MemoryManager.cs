using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using PugMod;
using Unity.Collections;
using Unity.Entities;
using Unity.Profiling;
using UnityEngine;

public class MemoryManager : ManagerBase
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PoolObjectInfo
	{
		public int ActiveCount;

		public int InactiveCount;

		public int PeakSize;

		public uint TotalAllocationActivity;

		public FixedString32Bytes PrefabName;

		public int TotalCount => ActiveCount + InactiveCount;

		public PoolObjectInfo(string prefabName, int activeCount, int inactiveCount, int peakSize, uint allocations, uint deallocations)
		{
			PrefabName = new FixedString32Bytes(prefabName);
			ActiveCount = activeCount;
			InactiveCount = inactiveCount;
			PeakSize = peakSize;
			TotalAllocationActivity = allocations + deallocations;
		}

		public override string ToString()
		{
			return string.Format("[{0}] - active: {1}, free: {2}, total: {3}, peak: {4}, allocation activity: {5}", (!PrefabName.IsEmpty) ? PrefabName : ((FixedString32Bytes)"None"), ActiveCount, InactiveCount, TotalCount, PeakSize, TotalAllocationActivity);
		}
	}

	public List<PoolablePrefabBank> poolablePrefabBanks;

	private readonly Dictionary<int, PoolSystem> _pools = new Dictionary<int, PoolSystem>();

	private readonly Dictionary<Type, int> _poolFromComponentType = new Dictionary<Type, int>();

	public readonly StringBuilder preallocatedStringBuilder = new StringBuilder();

	public readonly Collider[] preallocatedColliderArray = new Collider[64];

	public Dictionary<Entity, EntityMonoBehaviour> entityMonoLookUp = new Dictionary<Entity, EntityMonoBehaviour>();

	private const int ONEFRAMEINSTANTIATEAMOUNT = int.MaxValue;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("MemoryManager.Init");

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			if (poolablePrefabBanks == null || poolablePrefabBanks.Count == 0)
			{
				return true;
			}
			Manager.RunAfterInitComplete(CreatePools());
			Manager.RunAfterInitComplete(PopulatePools());
			Manager.RunAfterInitComplete(PoolModdedPrefabs());
			return true;
		}
	}

	private IEnumerator CreatePools()
	{
		StringBuilder builder = new StringBuilder();
		string prefix = "Pool ";
		foreach (PoolablePrefabBank poolablePrefabBank in poolablePrefabBanks)
		{
			PoolablePrefabBank.PlatformObjectPoolScaling poolScaling = null;
			bool flag = poolablePrefabBank.TryGetCurrentPlatformPoolScaling(out poolScaling);
			int prefabsAdded = 0;
			foreach (PoolablePrefabBank.PoolablePrefab item in poolablePrefabBank)
			{
				if (item.prefab == null)
				{
					Debug.LogError("You haven't set the poolable prefab or it has been removed");
					continue;
				}
				if (_pools.ContainsKey(item.prefab.GetInstanceID()))
				{
					Debug.LogError($"Pool for prefab {item.prefab} already exists. Did you add it to multiple PoolablePrefabBanks?");
					continue;
				}
				Component component = item.prefab.GetComponent<IPoolable>() as Component;
				if (component == null)
				{
					Debug.LogError($"Prefab {item.prefab} does not have a suitable IPoolable component");
					continue;
				}
				Type type = item.prefab.GetComponent(typeof(IPoolable))?.GetType();
				builder.Clear();
				builder.Append(prefix);
				builder.Append(component.name);
				GameObject gameObject = new GameObject(builder.ToString());
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				int initialSize = (flag ? poolScaling.GetScaledInitialAmount(item) : item.initialSize);
				int maxSize = (flag ? poolScaling.GetScaledMaxAmount(item) : item.maxSize);
				int maxFreeSize = (flag ? poolScaling.GetScaledMaxAmount(item) : item.maxFreeSize);
				PoolSystem value = new PoolSystem(item.prefab, type, gameObject.transform, autoEnable: true, initialSize, maxSize, maxFreeSize);
				_pools.Add(item.prefab.GetInstanceID(), value);
				if (type != null)
				{
					_poolFromComponentType.TryAdd(type, item.prefab.GetInstanceID());
				}
				prefabsAdded++;
			}
			yield return null;
			Debug.Log($"Added memory pools for {prefabsAdded} prefabs from {poolablePrefabBank.name}");
		}
	}

	private IEnumerator PoolModdedPrefabs()
	{
		yield return null;
		IEnumerable<LoadedMod> loadedMods = Loader.Instance.LoadedMods;
		int num = 0;
		foreach (LoadedMod item in loadedMods)
		{
			PooledModGraphicalObjectBank pooledModGraphicalObjectBank = null;
			foreach (UnityEngine.Object asset in item.Assets)
			{
				if (asset is PooledModGraphicalObjectBank pooledModGraphicalObjectBank2)
				{
					pooledModGraphicalObjectBank = pooledModGraphicalObjectBank2;
					break;
				}
			}
			if (pooledModGraphicalObjectBank != null)
			{
				foreach (PoolablePrefabBank.PoolablePrefab item2 in pooledModGraphicalObjectBank)
				{
					if (TryCreateModdedPrefabPool(item, item2))
					{
						num++;
					}
				}
				continue;
			}
			foreach (UnityEngine.Object asset2 in item.Assets)
			{
				if (asset2 is GameObject prefab && TryCreateModdedPrefabPool(item, prefab))
				{
					num++;
				}
			}
		}
		Debug.Log($"pooled {num} modded prefabs");
	}

	private bool TryCreateModdedPrefabPool(LoadedMod loadedMod, PoolablePrefabBank.PoolablePrefab pool)
	{
		if (pool.prefab == null)
		{
			Debug.LogWarning("skipping pooled mod prefab from: " + loadedMod.Metadata.name + ".");
			return false;
		}
		if (!pool.prefab.TryGetComponent<IPoolable>(out var _))
		{
			Debug.LogWarning("won't pool mod prefab: " + pool.prefab.name + ", it doesn't contain an IPoolable component.");
			return false;
		}
		CreateModdedPrefabPool(pool.prefab, pool.initialSize, pool.maxSize, pool.maxFreeSize);
		return true;
	}

	private bool TryCreateModdedPrefabPool(LoadedMod loadedMod, GameObject prefab)
	{
		if (!prefab.TryGetComponent<IPoolable>(out var _))
		{
			Debug.LogWarning("won't pool mod prefab: " + prefab.name + ", it doesn't contain an IPoolable component.");
			return false;
		}
		CreateModdedPrefabPool(prefab);
		return true;
	}

	public void CreateModdedPrefabPool(GameObject prefab, int initialSize = 16, int maxSize = 1024, int maxFreeSize = 1024)
	{
		Component component = prefab.GetComponent<IPoolable>() as Component;
		if (!(component == null))
		{
			Type type = prefab.GetComponent(typeof(IPoolable)).GetType();
			GameObject gameObject = new GameObject("pool " + component.name);
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			PoolSystem value = new PoolSystem(prefab, type, gameObject.transform, autoEnable: true, initialSize, maxSize, maxFreeSize);
			_pools.Add(prefab.GetInstanceID(), value);
			if (type != null)
			{
				_poolFromComponentType.TryAdd(type, prefab.GetInstanceID());
			}
		}
	}

	private IEnumerator PopulatePools()
	{
		int instantiatedObjectAmount = 0;
		Debug.Log("Populating pools...");
		foreach (PoolSystem pool in _pools.Values)
		{
			if (instantiatedObjectAmount > int.MaxValue)
			{
				instantiatedObjectAmount = 0;
				yield return null;
			}
			pool.IncreasePoolCapacity();
			instantiatedObjectAmount += pool.CurrentSize;
		}
	}

	public override void Deinit()
	{
		foreach (PoolSystem value in _pools.Values)
		{
			value.FreeAll();
		}
		base.Deinit();
	}

	public T GetFreeComponent<T>(bool deferOnOccupied = false, bool deferReparent = false) where T : Component
	{
		return GetPrefabPool(typeof(T)).GetFreeComponent<T>(deferOnOccupied, deferReparent);
	}

	public Component GetFreeComponent(Type componentType, bool deferOnOccupied = false, bool deferReparent = false)
	{
		return GetPrefabPool(componentType).GetFreeComponent(deferOnOccupied, deferReparent);
	}

	public GameObject GetFreeObject(GameObject prefab, bool deferOnOccupied = false, bool deferReparent = false)
	{
		return _pools[prefab.GetInstanceID()].GetFreeObject(deferOnOccupied, deferReparent);
	}

	private PoolSystem GetPrefabPool(Type componentType)
	{
		return _pools[_poolFromComponentType[componentType]];
	}

	public EntityMonoBehaviour GetEntityMono(Entity entity)
	{
		if (!entityMonoLookUp.TryGetValue(entity, out var value))
		{
			return null;
		}
		return value;
	}

	public bool TryGetEntityMono(Entity entity, out EntityMonoBehaviour mono)
	{
		return entityMonoLookUp.TryGetValue(entity, out mono);
	}

	public bool TryGetEntityMono<T>(Entity entity, out T monoT) where T : EntityMonoBehaviour
	{
		if (TryGetEntityMono(entity, out var mono))
		{
			monoT = mono as T;
			return true;
		}
		monoT = null;
		return false;
	}

	public void AddEntityMonoToLookUp(Entity entity, EntityMonoBehaviour entityMono)
	{
		if (!(entity == Entity.Null) && !entityMonoLookUp.TryAdd(entity, entityMono))
		{
			Debug.LogError($"Trying to add Entity {entity} to EntityMono look-up, but it already exists in the look-up.");
		}
	}

	public void RemoveEntityMonoFromLookUp(Entity entity)
	{
		if (entityMonoLookUp.ContainsKey(entity))
		{
			entityMonoLookUp.Remove(entity);
		}
	}

	public void OnSceneUnload()
	{
		foreach (PoolSystem value in _pools.Values)
		{
			value.FreeAll();
		}
		entityMonoLookUp.Clear();
	}

	private void ExecuteIEnumeratorInstantly(IEnumerator enumerator)
	{
		while (enumerator.MoveNext())
		{
		}
	}

	public void ReserveObjects(Type componentType, int amount)
	{
		PoolSystem prefabPool = GetPrefabPool(componentType);
		ReserveObjects(prefabPool, amount);
	}

	public void ReserveObjects(ObjectID objectID, int amount)
	{
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectID);
		if (objectInfo == null)
		{
			Debug.LogError($"Could not find ObjectInfo for ObjectID {objectID}");
		}
		else
		{
			ReserveObjects(objectInfo.prefabInfos[objectInfo.variation].prefab.gameObject, amount);
		}
	}

	public void ReserveObjects(GameObject prefab, int amount)
	{
		if (!_pools.TryGetValue(prefab.GetInstanceID(), out var value))
		{
			Debug.LogError($"No pool found for prefab {prefab}.");
		}
		else
		{
			ReserveObjects(value, amount);
		}
	}

	private void ReserveObjects(PoolSystem poolSystem, int amount)
	{
		poolSystem.ReserveObjects(amount);
	}

	public void UnreserveObjects(Type componentType)
	{
		PoolSystem prefabPool = GetPrefabPool(componentType);
		UnreserveObjects(prefabPool);
	}

	public void UnreserveObjects(ObjectID objectID)
	{
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectID);
		UnreserveObjects(objectInfo.prefabInfos[objectInfo.variation].prefab.gameObject);
	}

	public void UnreserveObjects(GameObject prefab)
	{
		PoolSystem poolSystem = _pools[prefab.GetInstanceID()];
		UnreserveObjects(poolSystem);
	}

	private void UnreserveObjects(PoolSystem poolSystem)
	{
		poolSystem.UnreserveObjects();
	}

	public List<PoolObjectInfo> GeneratePoolObjectInfo(out uint totalAllocationsForAllPools, out uint totalDeallocationsForAllPools)
	{
		List<PoolObjectInfo> list = new List<PoolObjectInfo>(_pools.Count);
		totalAllocationsForAllPools = 0u;
		totalDeallocationsForAllPools = 0u;
		foreach (KeyValuePair<int, PoolSystem> pool in _pools)
		{
			list.Add(new PoolObjectInfo(pool.Value.PrefabName, pool.Value.InUseCount, pool.Value.FreeSize, pool.Value.PeakUse, pool.Value.TotalAllocations, pool.Value.TotalDeallocations));
			totalAllocationsForAllPools += pool.Value.TotalAllocations;
			totalDeallocationsForAllPools += pool.Value.TotalDeallocations;
		}
		return list;
	}
}
