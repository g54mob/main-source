using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	internal class PoolData
	{
		private const string CONTAINER_NAME = "{0} (pool)";

		[NonSerialized]
		private readonly int m_CollectionId;

		[NonSerialized]
		private readonly GameObject m_Prefab;

		[NonSerialized]
		private readonly Transform m_Container;

		[NonSerialized]
		private readonly List<PoolInstance> m_ReadyInstances;

		[NonSerialized]
		private readonly Dictionary<int, PoolInstance> m_RunningInstances;

		public int ReadyCount => m_ReadyInstances.Count;

		[field: NonSerialized]
		public GameObject LastGet { get; private set; }

		public PoolData(GameObject prefab, int count)
		{
			m_CollectionId = prefab.GetInstanceID();
			m_Prefab = prefab;
			m_Container = new GameObject($"{prefab.name} (pool)").transform;
			m_Container.SetParent(Singleton<PoolManager>.Instance.transform);
			m_Container.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			m_ReadyInstances = new List<PoolInstance>(count);
			m_RunningInstances = new Dictionary<int, PoolInstance>();
			Prewarm(count);
		}

		public PoolData(int collectionId, int count)
		{
			m_CollectionId = collectionId;
			m_Prefab = null;
			m_Container = new GameObject($"{collectionId} (pool)").transform;
			m_Container.SetParent(Singleton<PoolManager>.Instance.transform);
			m_Container.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			m_ReadyInstances = new List<PoolInstance>(count);
			m_RunningInstances = new Dictionary<int, PoolInstance>();
			Prewarm(collectionId, count);
		}

		public GameObject Get(Vector3 position, Quaternion rotation, float duration)
		{
			if (m_ReadyInstances.Count == 0)
			{
				Prewarm(1);
			}
			PoolInstance poolInstance = m_ReadyInstances[0];
			m_ReadyInstances.RemoveAt(0);
			int instanceID = poolInstance.GetInstanceID();
			m_RunningInstances[instanceID] = poolInstance;
			poolInstance.transform.SetPositionAndRotation(position, rotation);
			poolInstance.enabled = true;
			poolInstance.gameObject.SetActive(value: true);
			if (duration > 0f)
			{
				poolInstance.SetDuration(duration);
			}
			LastGet = poolInstance.gameObject;
			return LastGet;
		}

		public void Prewarm(int count)
		{
			Prewarm(m_CollectionId, count);
		}

		public void Dispose()
		{
			UnityEngine.Object.Destroy(m_Container);
		}

		public void SetDontDestroyOnLoad()
		{
			UnityEngine.Object.DontDestroyOnLoad(m_Container);
		}

		private PoolInstance CreateInstance()
		{
			GameObject gameObject = null;
			bool active = false;
			if (m_Prefab != null)
			{
				active = m_Prefab.activeSelf;
				m_Prefab.SetActive(value: false);
				gameObject = UnityEngine.Object.Instantiate(m_Prefab, m_Container);
			}
			else
			{
				gameObject = new GameObject("");
				gameObject.transform.SetParent(m_Container);
			}
			PoolInstance poolInstance = gameObject.GetComponent<PoolInstance>();
			if (poolInstance == null)
			{
				poolInstance = gameObject.AddComponent<PoolInstance>();
			}
			if (m_Prefab != null)
			{
				m_Prefab.gameObject.SetActive(active);
			}
			return poolInstance;
		}

		public void Prewarm(int collectionId, int count)
		{
			for (int i = 0; i < count; i++)
			{
				PoolInstance poolInstance = CreateInstance();
				poolInstance.OnCreate(collectionId);
				m_ReadyInstances.Add(poolInstance);
			}
		}

		internal void OnDisableInstance(PoolInstance instance)
		{
			int instanceID = instance.GetInstanceID();
			if (m_RunningInstances.Remove(instanceID))
			{
				m_ReadyInstances.Add(instance);
			}
		}

		internal void OnDestroyInstance(PoolInstance instance)
		{
			int instanceID = instance.GetInstanceID();
			m_RunningInstances.Remove(instanceID);
			m_ReadyInstances.Remove(instance);
		}
	}
}
