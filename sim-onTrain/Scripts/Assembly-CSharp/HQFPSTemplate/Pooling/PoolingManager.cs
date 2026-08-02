using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate.Pooling
{
	public class PoolingManager : Singleton<PoolingManager>
	{
		private Dictionary<string, ObjectPool> m_Pools = new Dictionary<string, ObjectPool>(50);

		private SortedList<float, PoolableObject> m_ObjectsToRelease = new SortedList<float, PoolableObject>();

		public ObjectPool CreatePool(GameObject template, int minSize, int maxSize, bool autoShrink, string poolId, float autoReleaseDelay = float.PositiveInfinity)
		{
			if (!m_Pools.TryGetValue(poolId, out var value))
			{
				value = new ObjectPool(poolId, template, minSize, maxSize, autoShrink, autoReleaseDelay, base.transform);
				m_Pools.Add(poolId, value);
			}
			return value;
		}

		public PoolableObject GetObjectLocal(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
		{
			PoolableObject poolableObject = null;
			if (prefab != null)
			{
				if (m_Pools.TryGetValue(prefab.GetInstanceID().ToString(), out var value))
				{
					poolableObject = value.GetObjectLocal();
				}
				else
				{
					value = CreatePool(prefab, 10, 30, autoShrink: true, prefab.GetInstanceID().ToString());
					poolableObject = value.GetObjectLocal();
				}
			}
			if (poolableObject != null)
			{
				poolableObject.transform.SetPositionAndRotation(position, rotation);
				poolableObject.transform.SetParent(parent);
			}
			return poolableObject;
		}

		public PoolableObject GetObjectLocal(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			PoolableObject poolableObject = null;
			if (prefab != null)
			{
				if (m_Pools.TryGetValue(prefab.GetInstanceID().ToString(), out var value))
				{
					poolableObject = value.GetObjectLocal();
				}
				else
				{
					value = CreatePool(prefab, 10, 30, autoShrink: true, prefab.GetInstanceID().ToString());
					poolableObject = value.GetObjectLocal();
				}
			}
			if (poolableObject != null)
			{
				poolableObject.transform.SetPositionAndRotation(position, rotation);
			}
			return poolableObject;
		}

		public PoolableObject GetObject(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
		{
			PoolableObject poolableObject = null;
			if (prefab != null)
			{
				if (m_Pools.TryGetValue(prefab.GetInstanceID().ToString(), out var value))
				{
					poolableObject = value.GetObject();
				}
				else
				{
					value = CreatePool(prefab, 10, 30, autoShrink: true, prefab.GetInstanceID().ToString());
					poolableObject = value.GetObject();
				}
			}
			if (poolableObject != null)
			{
				poolableObject.transform.SetPositionAndRotation(position, rotation);
				poolableObject.transform.SetParent(parent);
			}
			return poolableObject;
		}

		public PoolableObject GetObject(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			PoolableObject poolableObject = null;
			if (prefab != null)
			{
				if (m_Pools.TryGetValue(prefab.GetInstanceID().ToString(), out var value))
				{
					poolableObject = value.GetObject();
				}
				else
				{
					value = CreatePool(prefab, 10, 30, autoShrink: true, prefab.GetInstanceID().ToString());
					poolableObject = value.GetObject();
				}
			}
			if (poolableObject != null)
			{
				poolableObject.transform.SetPositionAndRotation(position, rotation);
			}
			return poolableObject;
		}

		public PoolableObject GetObject(string poolId, Vector3 position, Quaternion rotation, Transform parent)
		{
			PoolableObject poolableObject = GetObject(poolId);
			if (poolableObject != null)
			{
				poolableObject.transform.SetPositionAndRotation(position, rotation);
				poolableObject.transform.SetParent(parent);
			}
			return poolableObject;
		}

		public PoolableObject GetObject(string poolId, Vector3 position, Quaternion rotation)
		{
			PoolableObject poolableObject = GetObject(poolId);
			if (poolableObject != null)
			{
				poolableObject.transform.SetPositionAndRotation(position, rotation);
			}
			return poolableObject;
		}

		public PoolableObject GetObject(string poolId)
		{
			ObjectPool value = null;
			m_Pools.TryGetValue(poolId, out value);
			return value?.GetObject();
		}

		public bool ReleaseObject(PoolableObject obj)
		{
			if (obj == null)
			{
				return false;
			}
			ObjectPool value = null;
			if (!m_Pools.ContainsKey(obj.PoolId))
			{
				MonoBehaviour.print("key not found: " + obj.PoolId);
			}
			m_Pools.TryGetValue(obj.PoolId, out value);
			return value?.TryPoolObject(obj) ?? false;
		}

		public void QueueObjectRelease(PoolableObject obj, float delay)
		{
			float num = Time.time + delay;
			if (m_ObjectsToRelease.ContainsKey(num))
			{
				num += Random.Range(0.05f, 0.5f);
			}
			m_ObjectsToRelease.Add(num, obj);
		}

		private void Update()
		{
			if (m_ObjectsToRelease.Count > 0 && Time.time > m_ObjectsToRelease.Keys[0])
			{
				ReleaseObject(m_ObjectsToRelease.Values[0]);
				m_ObjectsToRelease.RemoveAt(0);
			}
		}
	}
}
