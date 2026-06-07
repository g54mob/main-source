using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	[DisallowMultipleComponent]
	public class PoolManager : Singleton<PoolManager>
	{
		[field: NonSerialized]
		private Dictionary<int, PoolData> Collection { get; set; }

		protected override void OnCreate()
		{
			base.OnCreate();
			Collection = new Dictionary<int, PoolData>();
		}

		public GameObject GetLastPicked(GameObject prefab)
		{
			if (prefab == null)
			{
				return null;
			}
			if (!Collection.TryGetValue(prefab.GetInstanceID(), out var value))
			{
				return null;
			}
			return value.LastGet;
		}

		public GameObject Pick(GameObject prefab, int count, float duration = -1f)
		{
			if (prefab == null)
			{
				return null;
			}
			int instanceID = prefab.GetInstanceID();
			if (!Collection.ContainsKey(instanceID))
			{
				CreatePool(prefab, count);
			}
			return Collection[instanceID].Get(Vector3.zero, Quaternion.identity, duration);
		}

		public GameObject Pick(GameObject prefab, Vector3 position, Quaternion rotation, int count, float duration = -1f)
		{
			if (prefab == null)
			{
				return null;
			}
			int instanceID = prefab.GetInstanceID();
			if (!Collection.ContainsKey(instanceID))
			{
				CreatePool(prefab, count);
			}
			return Collection[instanceID].Get(position, rotation, duration);
		}

		public GameObject Pick(int collectionId, Vector3 position, Quaternion rotation, int count, float duration = -1f)
		{
			if (!Collection.ContainsKey(collectionId))
			{
				CreatePool(collectionId, count);
			}
			return Collection[collectionId].Get(position, rotation, duration);
		}

		public void Prewarm(GameObject prefab, int count)
		{
			if (prefab == null)
			{
				return;
			}
			int instanceID = prefab.GetInstanceID();
			if (Collection.TryGetValue(instanceID, out var value))
			{
				int readyCount = value.ReadyCount;
				int num = count - readyCount;
				if (num > 0)
				{
					value.Prewarm(num);
				}
			}
			else
			{
				CreatePool(prefab, count);
			}
		}

		public void Dispose(GameObject prefab)
		{
			if (!(prefab == null))
			{
				int instanceID = prefab.GetInstanceID();
				if (Collection.TryGetValue(instanceID, out var value))
				{
					value.Dispose();
				}
			}
		}

		public void DontDestroyOnLoadPool(GameObject prefab)
		{
			if (!(prefab == null))
			{
				int instanceID = prefab.GetInstanceID();
				if (Collection.TryGetValue(instanceID, out var value))
				{
					value.SetDontDestroyOnLoad();
				}
			}
		}

		private void CreatePool(GameObject prefab, int count)
		{
			int instanceID = prefab.GetInstanceID();
			Collection.Add(instanceID, new PoolData(prefab, count));
		}

		private void CreatePool(int collectionId, int count)
		{
			Collection.Add(collectionId, new PoolData(collectionId, count));
		}

		internal void OnDisableInstance(int prefabId, PoolInstance instance)
		{
			if (Collection.TryGetValue(prefabId, out var value))
			{
				value.OnDisableInstance(instance);
			}
			else if (!(instance == null))
			{
				UnityEngine.Object.Destroy(instance.gameObject);
			}
		}

		internal void OnDestroyInstance(int prefabId, PoolInstance instance)
		{
			if (Collection.TryGetValue(prefabId, out var value))
			{
				value.OnDestroyInstance(instance);
			}
			else if (!(instance == null))
			{
				UnityEngine.Object.Destroy(instance.gameObject);
			}
		}
	}
}
