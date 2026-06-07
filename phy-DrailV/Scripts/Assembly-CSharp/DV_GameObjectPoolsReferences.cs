using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/ItemPool asset")]
public class DV_GameObjectPoolsReferences : ScriptableObject
{
	[Serializable]
	public struct DV_GameObjectPoolData
	{
		public DV_GameObjectPools.GameObjectCategory gameObjectCategory;

		public GameObject[] gameObjectPrefabs;

		public int poolSize;

		public bool disableCollisionsInPool;
	}

	[Header("GameObject pool specific data")]
	public List<DV_GameObjectPoolData> poolData = new List<DV_GameObjectPoolData>();
}
