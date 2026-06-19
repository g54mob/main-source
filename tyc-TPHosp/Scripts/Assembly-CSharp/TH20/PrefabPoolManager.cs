#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class PrefabPoolManager : MustCallDestroy
	{
		public class PooledObject
		{
			public GameObject _objectToPool;

			public string _name;

			public int _initialPoolSize;

			[Tooltip("Determines if when an object is returned to the pool it is forced to be re-parented")]
			public bool _reparentByDefault;

			[NonSerialized]
			[HideInInspector]
			public int _poolID;
		}

		public class Config
		{
			public PooledObject[] _pooledObjects;
		}

		private static PrefabPoolManager _instance;

		private readonly Config _config;

		private List<PooledObject> _AllPooledObjects;

		private Dictionary<int, int> _instanceToPoolMapping;

		private readonly Dictionary<int, PrefabPool> _prefabPools;

		private GameObject _root;

		public static PrefabPoolManager GetInstance()
		{
			return _instance;
		}

		public PrefabPoolManager(Config config)
		{
			_config = config;
			_AllPooledObjects = new List<PooledObject>();
			_instanceToPoolMapping = new Dictionary<int, int>(1024);
			_instance = this;
			_root = null;
			_prefabPools = new Dictionary<int, PrefabPool>(_config._pooledObjects.Length);
			for (int i = 0; i < _config._pooledObjects.Length; i++)
			{
				if (!CreateAPool(_config._pooledObjects[i], i))
				{
					Logging.Error("Didn't create duplicate pool for " + _config._pooledObjects[i]._objectToPool.name + ". Remove the duplicate from the scriptable");
				}
			}
		}

		public bool CreateAPool(GameObject gameObject, int poolSize, bool reparentByDefault = true)
		{
			PooledObject pooledObject = new PooledObject
			{
				_objectToPool = gameObject,
				_name = gameObject.name,
				_initialPoolSize = poolSize,
				_reparentByDefault = reparentByDefault
			};
			return CreateAPool(pooledObject, _prefabPools.Count);
		}

		private bool CreateAPool(PooledObject pooledObject, int poolIndex)
		{
			foreach (PrefabPool value in _prefabPools.Values)
			{
				if (value.Prefab == pooledObject._objectToPool)
				{
					return false;
				}
			}
			_AllPooledObjects.Add(pooledObject);
			pooledObject._poolID = poolIndex;
			Transform unusedInstancesContainer = null;
			PrefabPool prefabPool = new PrefabPool(pooledObject._objectToPool, pooledObject._initialPoolSize, pooledObject._reparentByDefault, unusedInstancesContainer);
			_prefabPools.Add(poolIndex, prefabPool);
			prefabPool.GatherInstanceIDs(ref _instanceToPoolMapping, poolIndex, GetObjectID);
			return true;
		}

		public override void Destroy()
		{
			foreach (KeyValuePair<int, PrefabPool> prefabPool in _prefabPools)
			{
				prefabPool.Value.Destroy();
			}
			_AllPooledObjects.Clear();
			base.Destroy();
		}

		public GameObject GetInstance(GameObject source, Transform parent = null, bool worldPositionsStay = true, bool isActive = true, bool mustBeLastInList = false)
		{
			foreach (PooledObject allPooledObject in _AllPooledObjects)
			{
				if (allPooledObject._objectToPool == source)
				{
					bool wasJustInstantiated;
					GameObject instance = _prefabPools[allPooledObject._poolID].GetInstance(parent, out wasJustInstantiated, worldPositionsStay, isActive);
					int objectID = GetObjectID(source);
					if (wasJustInstantiated && !_instanceToPoolMapping.ContainsKey(objectID))
					{
						_instanceToPoolMapping.Add(objectID, allPooledObject._poolID);
					}
					if (mustBeLastInList)
					{
						instance.transform.SetAsLastSibling();
					}
					return instance;
				}
			}
			string name = source.name;
			foreach (PooledObject allPooledObject2 in _AllPooledObjects)
			{
				if (allPooledObject2._name == name)
				{
					Logging.Error("Could not find an object to pool which matches " + name + " yet an object with the same name was found. Ensure the asset is bundled or in a bundled folder.");
				}
			}
			return null;
		}

		public T GetInstance<T>(GameObject source, Transform parent = null, bool worldPositionsStay = true) where T : MonoBehaviour
		{
			foreach (PooledObject allPooledObject in _AllPooledObjects)
			{
				if (allPooledObject._objectToPool == source)
				{
					bool wasJustInstantiated;
					T instance = _prefabPools[allPooledObject._poolID].GetInstance<T>(parent, out wasJustInstantiated, worldPositionsStay, source.activeSelf);
					int objectID = GetObjectID(source);
					if (wasJustInstantiated && !_instanceToPoolMapping.ContainsKey(objectID))
					{
						_instanceToPoolMapping.Add(objectID, allPooledObject._poolID);
					}
					return instance;
				}
			}
			return null;
		}

		public void ReturnInstance(GameObject obj, bool reparent = false)
		{
			if (!TryReturnInstance(obj, reparent))
			{
				UnityEngine.Object.Destroy(obj);
			}
		}

		private bool TryReturnInstance(GameObject obj, bool reparent = false)
		{
			if (_instanceToPoolMapping.TryGetValue(GetObjectID(obj), out var value))
			{
				_prefabPools[value].ReturnInstance(obj, reparent);
				return true;
			}
			return false;
		}

		private int GetObjectID(GameObject obj)
		{
			return obj.name.GetHashCode();
		}
	}
}
