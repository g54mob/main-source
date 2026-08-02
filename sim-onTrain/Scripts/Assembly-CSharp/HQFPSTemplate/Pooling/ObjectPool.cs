using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate.Pooling
{
	public class ObjectPool
	{
		private GameObject m_Template;

		private Transform m_Parent;

		private string m_Id;

		private List<PoolableObject> m_AvailableObjects;

		private List<PoolableObject> m_InUseObjects;

		private int m_MinSize;

		private int m_MaxSize;

		private int m_CurrentSize;

		private bool m_Initialized;

		private float m_LastObjectGetTime;

		private bool m_AutoShrink;

		private float m_NextShrinkTime;

		private float m_AutoReleaseDelay;

		public string Id => m_Id;

		public ObjectPool(string id, GameObject template, int minSize, int maxSize, bool autoShrink, float autoReleaseDelay, Transform parent)
		{
			if (template == null)
			{
				Debug.LogError("You want to create an object pool for an object that is null!!");
				return;
			}
			m_Template = Object.Instantiate(template, parent);
			m_Template.SetActive(value: false);
			m_Parent = parent;
			m_Id = id;
			m_MinSize = minSize;
			m_MaxSize = Mathf.Clamp(maxSize, m_MinSize, int.MaxValue);
			m_CurrentSize = m_MinSize;
			m_AvailableObjects = new List<PoolableObject>(m_MaxSize);
			m_InUseObjects = new List<PoolableObject>(m_MaxSize);
			for (int i = 0; i < m_CurrentSize; i++)
			{
				PoolableObject poolableObject = CreateNewObject(m_Template, m_Parent, m_Id);
				poolableObject.gameObject.SetActive(value: false);
				m_AvailableObjects.Add(poolableObject);
			}
			m_AutoShrink = autoShrink;
			m_AutoReleaseDelay = autoReleaseDelay;
			m_Initialized = true;
		}

		public void Update()
		{
			if (m_AutoShrink && m_AvailableObjects.Count > m_MinSize && Time.time > m_LastObjectGetTime + 60f && Time.time > m_NextShrinkTime)
			{
				PoolableObject poolableObject = m_AvailableObjects[m_AvailableObjects.Count - 1];
				m_AvailableObjects.RemoveAt(m_AvailableObjects.Count - 1);
				Object.Destroy(poolableObject.gameObject);
				m_NextShrinkTime = Time.time + 0.5f;
				m_CurrentSize--;
			}
		}

		public PoolableObject GetObjectLocal()
		{
			if (!m_Initialized)
			{
				Debug.LogError("This pool can not be used, it's not initialized properly!");
				return null;
			}
			PoolableObject poolableObject = null;
			if (m_AvailableObjects.Count > 0)
			{
				poolableObject = m_AvailableObjects[m_AvailableObjects.Count - 1];
				m_AvailableObjects.RemoveAt(m_AvailableObjects.Count - 1);
				m_InUseObjects.Add(poolableObject);
			}
			else if (m_CurrentSize < m_MaxSize)
			{
				m_CurrentSize++;
				poolableObject = CreateNewObjectLocal(m_Template, m_Parent, m_Id);
				m_InUseObjects.Add(poolableObject);
			}
			else
			{
				poolableObject = m_InUseObjects[0];
				m_InUseObjects[0] = m_InUseObjects[m_InUseObjects.Count - 1];
				m_InUseObjects[m_InUseObjects.Count - 1] = poolableObject;
			}
			m_LastObjectGetTime = Time.time;
			poolableObject.gameObject.SetActive(value: true);
			poolableObject.OnUse();
			if (m_AutoReleaseDelay != float.PositiveInfinity)
			{
				Singleton<PoolingManager>.Instance.QueueObjectRelease(poolableObject, m_AutoReleaseDelay);
			}
			return poolableObject;
		}

		public PoolableObject GetObject()
		{
			if (!m_Initialized)
			{
				Debug.LogError("This pool can not be used, it's not initialized properly!");
				return null;
			}
			PoolableObject poolableObject = null;
			if (m_AvailableObjects.Count > 0)
			{
				poolableObject = m_AvailableObjects[m_AvailableObjects.Count - 1];
				m_AvailableObjects.RemoveAt(m_AvailableObjects.Count - 1);
				m_InUseObjects.Add(poolableObject);
			}
			else if (m_CurrentSize < m_MaxSize)
			{
				m_CurrentSize++;
				poolableObject = CreateNewObject(m_Template, m_Parent, m_Id);
				m_InUseObjects.Add(poolableObject);
			}
			else
			{
				poolableObject = m_InUseObjects[0];
				m_InUseObjects[0] = m_InUseObjects[m_InUseObjects.Count - 1];
				m_InUseObjects[m_InUseObjects.Count - 1] = poolableObject;
			}
			m_LastObjectGetTime = Time.time;
			poolableObject.gameObject.SetActive(value: true);
			poolableObject.OnUse();
			if (m_AutoReleaseDelay != float.PositiveInfinity)
			{
				Singleton<PoolingManager>.Instance.QueueObjectRelease(poolableObject, m_AutoReleaseDelay);
			}
			return poolableObject;
		}

		public bool TryPoolObject(PoolableObject obj)
		{
			if (!m_Initialized)
			{
				Debug.LogError("This pool can not be used, it's not initialized properly!");
				return false;
			}
			if (obj == null)
			{
				Debug.LogError("The object you want to pool is null!!");
				return false;
			}
			if (m_Id != obj.PoolId)
			{
				Debug.LogError("You want to put an object back in this pool, but it doesn't belong here!!");
				return false;
			}
			m_InUseObjects.Remove(obj);
			m_AvailableObjects.Add(obj);
			obj.OnReleased();
			obj.transform.SetParent(m_Parent);
			obj.gameObject.SetActive(value: false);
			return true;
		}

		private PoolableObject CreateNewObjectLocal(GameObject template, Transform parent, string poolId)
		{
			if (template == null)
			{
				return null;
			}
			GameObject gameObject = Object.Instantiate(template, parent);
			PoolableObject poolableObject = gameObject.GetComponent<PoolableObject>();
			if (poolableObject == null)
			{
				poolableObject = gameObject.AddComponent<PoolableObject>();
			}
			poolableObject.Init(poolId);
			return poolableObject;
		}

		private PoolableObject CreateNewObject(GameObject template, Transform parent, string poolId)
		{
			if (template == null)
			{
				return null;
			}
			GameObject gameObject = Object.Instantiate(template, parent);
			PoolableObject poolableObject = gameObject.GetComponent<PoolableObject>();
			if (poolableObject == null)
			{
				poolableObject = gameObject.AddComponent<PoolableObject>();
			}
			poolableObject.Init(poolId);
			return poolableObject;
		}
	}
}
