using System.Collections.Generic;
using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageColliders : MonoBehaviour
	{
		public FoliageCollisionSettings m_Settings;

		private Vector3 m_LastPosition;

		private GameObject m_ColliderHolder;

		private FoliageDataRuntime m_FoliageData;

		private Dictionary<int, FoliageType> m_FoliageTypes = new Dictionary<int, FoliageType>();

		private Dictionary<int, CollisionCache> m_Cache = new Dictionary<int, CollisionCache>();

		private int m_DataIssuedActiveColliders;

		private Vector3 m_CameraPosTemp;

		private FoliageCell currentCell;

		private int m_Layer;

		private void Start()
		{
			if (!m_Settings.m_WatchedTransform)
			{
				m_Settings.m_WatchedTransform = Camera.main.transform;
			}
			m_LastPosition = m_Settings.m_WatchedTransform.position;
			m_ColliderHolder = new GameObject("FoliageSystemColliderHolder");
		}

		public void InitCollider(FoliageDataRuntime dataToRender, List<FoliageType> foliageTypes)
		{
			m_FoliageData = dataToRender;
			m_FoliageTypes.Clear();
			foreach (FoliageType foliageType in foliageTypes)
			{
				m_FoliageTypes.Add(foliageType.m_Hash, foliageType);
			}
		}

		private void Update()
		{
			if (!m_Settings.m_WatchedTransform)
			{
				return;
			}
			m_CameraPosTemp = m_Settings.m_WatchedTransform.position;
			float num = m_CameraPosTemp.x - m_LastPosition.x;
			float num2 = m_CameraPosTemp.y - m_LastPosition.y;
			float num3 = m_CameraPosTemp.z - m_LastPosition.z;
			if (!(num * num + num2 * num2 + num3 * num3 > m_Settings.m_CollisionRefreshDistance * m_Settings.m_CollisionRefreshDistance))
			{
				return;
			}
			m_LastPosition = m_CameraPosTemp;
			m_Layer = LayerMask.NameToLayer(m_Settings.m_UsedLayer);
			m_DataIssuedActiveColliders = 0;
			foreach (CollisionCache value2 in m_Cache.Values)
			{
				value2?.Reset();
			}
			currentCell.Set(m_LastPosition);
			float collDistSqr = m_Settings.m_CollisionDistance * m_Settings.m_CollisionDistance;
			FoliageCell.IterateNeighboring(currentCell, 1, delegate(int hash)
			{
				if (m_FoliageData.m_FoliageData.TryGetValue(hash, out var value) && value.m_Bounds.SqrDistance(m_LastPosition) <= collDistSqr)
				{
					ProcessCell(value, collDistSqr);
				}
			});
		}

		private void ProcessCell(FoliageCellDataRuntime cell, float colliderDistSqr)
		{
			for (int i = 0; i < cell.m_TypeHashLocationsRuntime.Length; i++)
			{
				int key = cell.m_TypeHashLocationsRuntime[i].Key;
				FoliageType foliageType = m_FoliageTypes[key];
				if (!foliageType.m_EnableCollision)
				{
					continue;
				}
				FoliageInstance[] editTime = cell.m_TypeHashLocationsRuntime[i].Value.m_EditTime;
				int hash = foliageType.m_Hash;
				for (int j = 0; j < editTime.Length; j++)
				{
					Vector3 position = editTime[j].m_Position;
					float num = position.x - m_LastPosition.x;
					float num2 = position.y - m_LastPosition.y;
					float num3 = position.z - m_LastPosition.z;
					if (!(num * num + num2 * num2 + num3 * num3 <= colliderDistSqr))
					{
						continue;
					}
					GameObject colliderForPrototype = GetColliderForPrototype(hash);
					colliderForPrototype.layer = m_Layer;
					if (colliderForPrototype != null)
					{
						FoliageColliderData foliageColliderData = colliderForPrototype.GetComponent<FoliageColliderData>();
						if (foliageColliderData == null)
						{
							foliageColliderData = colliderForPrototype.AddComponent<FoliageColliderData>();
						}
						foliageColliderData.m_FoliageType = key;
						foliageColliderData.m_FoliageInstance = editTime[j];
						colliderForPrototype.transform.position = editTime[j].m_Position;
						colliderForPrototype.transform.rotation = editTime[j].m_Rotation;
						colliderForPrototype.transform.localScale = editTime[j].m_Scale;
						m_DataIssuedActiveColliders++;
					}
				}
			}
		}

		private GameObject GetColliderForPrototype(int hash)
		{
			FoliageType foliageType = m_FoliageTypes[hash];
			if (!foliageType.m_EnableCollision)
			{
				return null;
			}
			if (!m_Cache.ContainsKey(hash))
			{
				if (foliageType.m_Prefab.GetComponentInChildren<Collider>() == null)
				{
					m_Cache.Add(hash, null);
					return null;
				}
				GameObject gameObject = Object.Instantiate(foliageType.m_Prefab, m_ColliderHolder.transform);
				gameObject.name = "ColliderPrototype_" + foliageType.m_Prefab.name;
				LODGroup component = gameObject.GetComponent<LODGroup>();
				if ((bool)component)
				{
					Object.DestroyImmediate(component);
				}
				for (int num = gameObject.transform.childCount - 1; num >= 0; num--)
				{
					GameObject gameObject2 = gameObject.transform.GetChild(num).gameObject;
					if (gameObject2.GetComponent<Collider>() == null)
					{
						Object.DestroyImmediate(gameObject2);
					}
				}
				Component[] componentsInChildren = gameObject.GetComponentsInChildren<Component>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (!(componentsInChildren[i] is Collider) && !(componentsInChildren[i] is Transform))
					{
						Object.DestroyImmediate(componentsInChildren[i]);
					}
				}
				gameObject.SetActive(value: false);
				CollisionCache collisionCache = new CollisionCache(gameObject, m_ColliderHolder);
				m_Cache.Add(hash, collisionCache);
				return collisionCache.RetrieveInstance();
			}
			if (m_Cache[hash] != null)
			{
				return m_Cache[hash].RetrieveInstance();
			}
			return null;
		}
	}
}
