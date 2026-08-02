using System.Collections.Generic;
using UnityEngine;

namespace CritiasFoliage
{
	public class CollisionCache
	{
		private GameObject m_CacheInstanceOwner;

		private GameObject m_CachePrototype;

		private List<GameObject> m_ActiveInstances = new List<GameObject>();

		private List<GameObject> m_InactiveInstances = new List<GameObject>();

		private int m_ExpansionSize;

		public CollisionCache(GameObject collisionPrototype, GameObject instanceOwner = null, int expansionSize = 3)
		{
			m_CacheInstanceOwner = instanceOwner;
			m_CachePrototype = collisionPrototype;
			m_ExpansionSize = expansionSize;
		}

		public GameObject RetrieveInstance()
		{
			if (m_InactiveInstances.Count == 0)
			{
				for (int i = 0; i < m_ExpansionSize; i++)
				{
					GameObject gameObject = Object.Instantiate(m_CachePrototype, m_CacheInstanceOwner.transform);
					gameObject.SetActive(value: false);
					m_InactiveInstances.Add(gameObject);
				}
			}
			GameObject gameObject2 = m_InactiveInstances[0];
			m_InactiveInstances.RemoveAt(0);
			m_ActiveInstances.Add(gameObject2);
			gameObject2.SetActive(value: true);
			return gameObject2;
		}

		public void RecycleInstance(GameObject instance)
		{
			if (m_ActiveInstances.Remove(instance))
			{
				instance.SetActive(value: false);
				m_InactiveInstances.Add(instance);
			}
		}

		public void Reset()
		{
			for (int i = 0; i < m_ActiveInstances.Count; i++)
			{
				GameObject gameObject = m_ActiveInstances[i];
				gameObject.SetActive(value: false);
				m_InactiveInstances.Add(gameObject);
			}
			m_ActiveInstances.Clear();
		}
	}
}
