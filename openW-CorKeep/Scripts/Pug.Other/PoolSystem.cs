using System;
using System.Collections;
using System.Collections.Generic;
using PimDeWitte.UnityMainThreadDispatcher;
using Unity.Profiling;
using UnityEngine;

public class PoolSystem : IPoolSystem
{
	private struct PooledObject
	{
		public GameObject GameObject;

		public Component Component;

		public IPoolable Callbacks;
	}

	private static readonly ProfilerMarker AllocateNewObjectMarker = new ProfilerMarker("PoolSystem.AllocateNewObject");

	private static readonly ProfilerMarker GetFreeMarker = new ProfilerMarker("PoolSystem.GetFree*");

	private static readonly ProfilerMarker FreeMarker = new ProfilerMarker("PoolSystem.Free");

	private readonly GameObject _prefab;

	private readonly Type _componentType;

	private readonly Stack<PooledObject> _freeObjects;

	private readonly Dictionary<int, PooledObject> _allocatedObjects;

	private int _currentSize;

	private readonly int _maxSize;

	private readonly int _initialSize;

	private readonly int _maxFreeSize;

	private int _forcedMinSize;

	private bool _reservingMoreObjects;

	private int _lastFrameGet = -1;

	private int _lastFrameFreed = -1;

	private readonly bool _autoEnable;

	private readonly Transform _autoParent;

	[HideInInspector]
	public int CurrentSize => _currentSize;

	public int InitialSize => _initialSize;

	public int FreeSize => _freeObjects.Count;

	public int PeakUse { get; private set; }

	public int AllocatedCount => _allocatedObjects.Count;

	public string Name { get; }

	public string PrefabName => _prefab.name;

	public int LastFrameGet => _lastFrameGet;

	public int LastFrameFreed => _lastFrameFreed;

	public int InUseCount => _allocatedObjects.Count;

	public uint TotalAllocations { get; private set; }

	public uint TotalDeallocations { get; private set; }

	public PoolSystem(GameObject prefab, Type componentType = null, Transform autoParent = null, bool autoEnable = false, int initialSize = 50, int maxSize = -1, int maxFreeSize = -1, string name = null)
	{
		Name = "Pool<" + (name ?? prefab.name) + ">";
		_prefab = prefab;
		_componentType = componentType;
		_freeObjects = new Stack<PooledObject>();
		_allocatedObjects = new Dictionary<int, PooledObject>();
		_autoParent = autoParent;
		_autoEnable = autoEnable;
		_initialSize = initialSize;
		if (maxSize < 0)
		{
			_maxSize = initialSize * 2;
		}
		else if (maxSize < initialSize)
		{
			Debug.LogWarning(Name + ": maxSize < initialSize. Overriding maxSize.");
			_maxSize = initialSize * 2;
		}
		else
		{
			_maxSize = maxSize;
		}
		_currentSize = 0;
		PoolSystemTracker.poolSystems.Add(this);
	}

	public void IncreasePoolCapacity()
	{
		for (int i = 0; i < _initialSize; i++)
		{
			PooledObject item = AllocateNewObject();
			item.GameObject.SetActive(value: false);
			_freeObjects.Push(item);
		}
	}

	public T GetFreeComponent<T>(bool deferOnOccupied = false, bool deferReparent = false) where T : Component
	{
		return (T)GetFreeComponent(deferOnOccupied, deferReparent);
	}

	public Component GetFreeComponent(bool deferOnOccupied = false, bool deferReparent = false)
	{
		return GetPoolObject(deferOnOccupied, deferReparent).Component;
	}

	public GameObject GetFreeObject(bool deferOnOccupied = false, bool deferReparent = false)
	{
		return GetPoolObject(deferOnOccupied, deferReparent).GameObject;
	}

	public bool IsFree(GameObject obj)
	{
		return !_allocatedObjects.ContainsKey(obj.GetInstanceID());
	}

	public void Free(Component component)
	{
		Free(component.gameObject);
	}

	public void Free(GameObject allocatedObject)
	{
		_lastFrameFreed = Time.frameCount;
		int instanceID = allocatedObject.GetInstanceID();
		if (!_allocatedObjects.TryGetValue(instanceID, out var value))
		{
			Debug.LogWarning($"{Name}: Trying to free an object that is not allocated (instanceID={instanceID}, name={allocatedObject.name})");
			return;
		}
		value.Callbacks?.OnFree();
		value.GameObject.SetActive(value: false);
		if (_autoParent != null && _autoParent.gameObject.activeInHierarchy)
		{
			value.GameObject.transform.SetParent(_autoParent);
		}
		_allocatedObjects.Remove(instanceID);
		FreeObject(in value);
	}

	public void FreeAll()
	{
		foreach (PooledObject value in _allocatedObjects.Values)
		{
			PooledObject pooledObject = value;
			if (pooledObject.GameObject == null)
			{
				Debug.LogWarning(Name + ": Encountered already destroyed object during FreeAll()");
				_currentSize--;
				continue;
			}
			try
			{
				pooledObject.Callbacks?.OnFree();
			}
			catch (Exception arg)
			{
				Debug.LogError($"{Name}: Exception during OnFree callback of object {pooledObject.GameObject.name}: {arg}");
			}
			pooledObject.GameObject.SetActive(value: false);
			if (_autoParent != null)
			{
				pooledObject.GameObject.transform.SetParent(_autoParent);
			}
			FreeObject(in pooledObject);
		}
		_allocatedObjects.Clear();
	}

	private void FreeObject(in PooledObject pooledObject)
	{
		_freeObjects.Push(pooledObject);
	}

	private PooledObject GetPoolObject(bool deferOnOccupied = false, bool deferReparent = false)
	{
		_lastFrameGet = Time.frameCount;
		bool flag = _freeObjects.Count == 0;
		if (flag && CheckAdditionalAllocationSize(1) == 0)
		{
			return default(PooledObject);
		}
		PooledObject pooledObject = (flag ? AllocateNewObject() : _freeObjects.Pop());
		if (pooledObject.GameObject == null)
		{
			if (flag)
			{
				Debug.LogError(Name + ": Failed to allocate new object.");
			}
			else
			{
				Debug.LogError($"{Name}: Pooled object {pooledObject.GameObject} got destroyed.");
			}
			_currentSize--;
			return default(PooledObject);
		}
		_allocatedObjects[pooledObject.GameObject.GetInstanceID()] = pooledObject;
		PeakUse = Math.Max(PeakUse, _allocatedObjects.Count);
		if (!deferReparent)
		{
			pooledObject.GameObject.transform.SetParent(Manager.camera.VolatileRenderAnchor);
		}
		if (!deferOnOccupied)
		{
			pooledObject.Callbacks?.OnOccupied();
		}
		pooledObject.GameObject.SetActive(_autoEnable);
		return pooledObject;
	}

	private int CheckAdditionalAllocationSize(int numNewElements)
	{
		int num = _maxSize - _currentSize;
		if (num == 0)
		{
			Debug.LogWarning($"{Name}: Couldn't allocate {numNewElements} objects because " + $"max capacity ({_maxSize}) exceeded! Consider increasing max size " + $"to {_maxSize + numNewElements} or more.");
			return 0;
		}
		if (numNewElements > num)
		{
			Debug.LogWarning($"{Name}: Too many new objects requested ({numNewElements}), " + $"capping to {num} (current size: {_currentSize}, max: {_maxSize})");
			return num;
		}
		return numNewElements;
	}

	private PooledObject AllocateNewObject()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(_prefab, _autoParent, worldPositionStays: true);
		Component component = ((_componentType == null) ? null : gameObject.GetComponent(_componentType));
		IPoolable poolable = component as IPoolable;
		poolable?.OnAllocation(this);
		_currentSize++;
		uint totalAllocations = TotalAllocations + 1;
		TotalAllocations = totalAllocations;
		return new PooledObject
		{
			GameObject = gameObject,
			Component = component,
			Callbacks = poolable
		};
	}

	private void DiscardObject(in PooledObject pooledObject)
	{
		UnityEngine.Object.Destroy(pooledObject.GameObject);
		_currentSize--;
		TotalDeallocations++;
	}

	public int DiscardFreeObjects(int count)
	{
		for (int i = 0; i < count; i++)
		{
			if (_freeObjects.Count <= _forcedMinSize)
			{
				return i;
			}
			DiscardObject(_freeObjects.Pop());
		}
		return count;
	}

	public int DiscardFreeObjectsToSize(int size)
	{
		int num = 0;
		while (_freeObjects.Count > size)
		{
			if (_freeObjects.Count <= _forcedMinSize)
			{
				return num;
			}
			DiscardObject(_freeObjects.Pop());
			num++;
		}
		return num;
	}

	public void ReserveObjects(int count)
	{
		UnityMainThreadDispatcher.Instance().StartCoroutine(ReserveSeveralObjectsBySeveralFrames(count));
	}

	private IEnumerator ReserveSeveralObjectsBySeveralFrames(int count)
	{
		_forcedMinSize = count;
		_reservingMoreObjects = true;
		int maxAllocateAmount = CheckAdditionalAllocationSize(count - _freeObjects.Count);
		Debug.Log(string.Format("{0}.{1}: Original amount: {2}, new amount: {3}, already free objects: {4}", "PoolSystem", "ReserveSeveralObjectsBySeveralFrames", count, maxAllocateAmount, _freeObjects.Count));
		int i = 0;
		while (i < maxAllocateAmount)
		{
			yield return null;
			if (CheckAdditionalAllocationSize(1) == 0)
			{
				Debug.LogWarning("PoolSystem.ReserveSeveralObjectsBySeveralFrames: Max allocations reached prematurely.");
				break;
			}
			if (!_reservingMoreObjects)
			{
				Debug.LogWarning("PoolSystem.ReserveSeveralObjectsBySeveralFrames: Commanded to stop instantiating mid instantiation. Stop instantiating.");
				break;
			}
			PooledObject item = AllocateNewObject();
			item.GameObject.SetActive(value: false);
			_freeObjects.Push(item);
			Debug.Log("PoolSystem.ReserveSeveralObjectsBySeveralFrames: Adding new object to pool");
			int num = i + 1;
			i = num;
		}
		_reservingMoreObjects = false;
	}

	public void UnreserveObjects()
	{
		_reservingMoreObjects = false;
		_forcedMinSize = _initialSize;
	}
}
