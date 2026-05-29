using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core.Pooling
{
	public static class Pooler
	{
		private static readonly Dictionary<int, ComponentPool> ObjectPools = new Dictionary<int, ComponentPool>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void ClearStates()
		{
			ObjectPools.Clear();
		}

		public static void Create<TComponent>(TComponent prefab, int count, bool autoReturn = false) where TComponent : MonoBehaviour, IPoolable
		{
			int instanceID = prefab.GetInstanceID();
			ComponentPool orCreateObjectPool = GetOrCreateObjectPool(instanceID, prefab);
			orCreateObjectPool.autoReturn = autoReturn;
			count -= orCreateObjectPool.count;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					TComponent val = CTSFactory.Instantiate(prefab, orCreateObjectPool.Parent, instantiateInWorldSpace: false, false);
					string name = val.name + orCreateObjectPool.count;
					val.name = name;
					PooledObject pooledObject = val.gameObject.AddCTSComponent<PooledObject>();
					pooledObject.InPool = true;
					pooledObject.Setup(instanceID, val, orCreateObjectPool.autoReturn);
					orCreateObjectPool.Queue.Add(pooledObject);
					orCreateObjectPool.count++;
				}
			}
		}

		public static void Create(GameObject prefab, int count, bool autoReturn = false)
		{
			int instanceID = prefab.GetInstanceID();
			ComponentPool orCreateObjectPool = GetOrCreateObjectPool(instanceID, prefab);
			orCreateObjectPool.autoReturn = autoReturn;
			count -= orCreateObjectPool.count;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					GameObject gameObject = CTSFactory.Instantiate(prefab, orCreateObjectPool.Parent, instantiateInWorldSpace: false, false);
					gameObject.name += orCreateObjectPool.count;
					PooledObject pooledObject = gameObject.gameObject.AddCTSComponent<PooledObject>();
					pooledObject.InPool = true;
					pooledObject.Setup(instanceID, null, orCreateObjectPool.autoReturn);
					orCreateObjectPool.Queue.Add(pooledObject);
					orCreateObjectPool.count++;
				}
			}
		}

		public static void SetPoolAutoReturn<TComponent>(TComponent original, bool autoReturn) where TComponent : MonoBehaviour, IPoolable
		{
			GetOrCreateObjectPool(original.GetInstanceID(), original).autoReturn = autoReturn;
		}

		public static void SetPoolAutoReturn(GameObject original, bool autoReturn)
		{
			GetOrCreateObjectPool(original.GetInstanceID(), original).autoReturn = autoReturn;
		}

		public static void SetAutoReturn(PooledObject pooledObject, bool autoReturn)
		{
			pooledObject.SetAutoReturn(autoReturn);
		}

		public static void SetAutoReturn<TPoolable>(TPoolable poolable, bool autoReturn) where TPoolable : MonoBehaviour, IPoolable
		{
			SetAutoReturn(poolable.GetComponentInParent<PooledObject>(includeInactive: true), autoReturn);
		}

		public static TComponent Pull<TComponent>(TComponent prefab, Transform parent, bool active = false) where TComponent : MonoBehaviour, IPoolable
		{
			TComponent val = null;
			PooledObject pooledObject = null;
			int instanceID = prefab.GetInstanceID();
			ComponentPool orCreateObjectPool = GetOrCreateObjectPool(instanceID, prefab);
			while (!val)
			{
				if (ObjectPools[instanceID].Queue.Count > 0)
				{
					pooledObject = ObjectPools[instanceID].Dequeue();
					if (pooledObject == null || pooledObject.PoolComponent == null)
					{
						orCreateObjectPool.count = Math.Max(0, orCreateObjectPool.count - 1);
						continue;
					}
					val = (TComponent)pooledObject.PoolComponent;
					pooledObject.SetAutoReturn(orCreateObjectPool.autoReturn);
					pooledObject.InPool = false;
					val.transform.SetParent(parent ? parent : null);
				}
				else
				{
					val = CTSFactory.Instantiate(prefab, parent ? parent : null, instantiateInWorldSpace: false, false);
					string name = val.name + orCreateObjectPool.count;
					val.name = name;
					pooledObject = val.gameObject.AddCTSComponent<PooledObject>();
					pooledObject.Setup(instanceID, val, orCreateObjectPool.autoReturn);
					orCreateObjectPool.count++;
				}
			}
			val.gameObject.SetActive(active);
			pooledObject.Pulled();
			return val;
		}

		public static PooledRef<TComponent> PullSafe<TComponent>(TComponent prefab, Transform parent, bool active = false) where TComponent : MonoBehaviour, IPoolable
		{
			return new PooledRef<TComponent>(Pull(prefab, parent, active));
		}

		public static TComponent Pull<TComponent>(TComponent prefab, bool active = false) where TComponent : MonoBehaviour, IPoolable
		{
			return Pull(prefab, null, active);
		}

		public static PooledRef<TComponent> PullSafe<TComponent>(TComponent prefab, bool active = false) where TComponent : MonoBehaviour, IPoolable
		{
			return new PooledRef<TComponent>(Pull(prefab, null, active));
		}

		public static PooledObject Pull(GameObject prefab, bool active = false)
		{
			return Pull(prefab, null, active);
		}

		public static PooledRef<PooledObject> PullSafe(GameObject prefab, bool active = false)
		{
			return new PooledRef<PooledObject>(Pull(prefab, active).GetComponent<PooledObject>());
		}

		public static PooledObject Pull(GameObject obj, Transform parent, bool active = false)
		{
			PooledObject pooledObject = null;
			int instanceID = obj.GetInstanceID();
			ComponentPool orCreateObjectPool = GetOrCreateObjectPool(instanceID, obj);
			while (!pooledObject)
			{
				if (ObjectPools[instanceID].Queue.Count > 0)
				{
					pooledObject = ObjectPools[instanceID].Dequeue();
					if (pooledObject == null)
					{
						orCreateObjectPool.count = Math.Max(0, orCreateObjectPool.count - 1);
						continue;
					}
					pooledObject.SetAutoReturn(orCreateObjectPool.autoReturn);
					pooledObject.transform.SetParent(parent ? parent : null);
				}
				else
				{
					GameObject gameObject = CTSFactory.Instantiate(obj, parent ? parent : null, instantiateInWorldSpace: false, false);
					gameObject.name += orCreateObjectPool.count;
					pooledObject = gameObject.AddCTSComponent<PooledObject>();
					pooledObject.Setup(instanceID, null, orCreateObjectPool.autoReturn);
					orCreateObjectPool.count++;
				}
			}
			pooledObject.InPool = false;
			pooledObject.gameObject.SetActive(active);
			pooledObject.Pulled();
			return pooledObject;
		}

		public static PooledRef<PooledObject> PullSafe(GameObject prefab, Transform parent, bool active = false)
		{
			return new PooledRef<PooledObject>(Pull(prefab, parent, active).GetComponent<PooledObject>());
		}

		private static ComponentPool GetOrCreateObjectPool(int id, UnityEngine.Object prefab)
		{
			if (ObjectPools.TryGetValue(id, out var value))
			{
				return value;
			}
			ComponentPool value2 = new ComponentPool
			{
				Name = prefab.name
			};
			ObjectPools.Add(id, value2);
			return ObjectPools[id];
		}

		internal static void Clear(PooledObject pooledObject, int id)
		{
			pooledObject.InPool = false;
			if (!ObjectPools.TryGetValue(id, out var value))
			{
				return;
			}
			value.count--;
			int num = value.Queue.Count - 1;
			while (num >= 0)
			{
				PooledObject item = value.Queue[num];
				int count = value.Queue.Count;
				value.Queue.Remove(item);
				if (count == value.Queue.Count)
				{
					num--;
					continue;
				}
				break;
			}
		}

		internal static void Push(PooledObject pooledObject, Component obj, int id)
		{
			if (pooledObject.InPool || !pooledObject.gameObject.scene.isLoaded)
			{
				return;
			}
			if (ObjectPools.TryGetValue(id, out var value))
			{
				GameObject gameObject = obj.gameObject;
				if (gameObject.activeSelf)
				{
					gameObject.transform.SetParent(value.Parent);
					gameObject.SetActive(value: false);
				}
				value.Queue.Add(pooledObject);
				pooledObject.InPool = true;
			}
			else
			{
				Debug.LogWarning(obj.name + " isn't part of any instancing pool");
			}
		}

		public static void Push<T>(PooledRef<T> pooledRef) where T : MonoBehaviour, IPoolable
		{
			Push(pooledRef.Value);
		}

		public static void Push<T>(T poolable) where T : MonoBehaviour, IPoolable
		{
			PooledObject componentInParent = poolable.GetComponentInParent<PooledObject>(includeInactive: true);
			if ((bool)componentInParent)
			{
				componentInParent.PushToPool();
			}
		}
	}
}
