using System;
using System.Collections.Generic;
using UnityEngine;

public static class DatabaseConversionUtility
{
	public struct PrefabData : IComparable<PrefabData>
	{
		public ObjectInfo ObjectInfo;

		public int CompareTo(PrefabData other)
		{
			if (ObjectInfo.objectID != other.ObjectInfo.objectID)
			{
				int objectID = (int)ObjectInfo.objectID;
				return objectID.CompareTo((int)other.ObjectInfo.objectID);
			}
			return ObjectInfo.variation.CompareTo(other.ObjectInfo.variation);
		}
	}

	public static List<PrefabData> GetPrefabList(PugDatabaseAuthoring authoring)
	{
		List<MonoBehaviour> list = new List<MonoBehaviour>();
		if (Application.isPlaying)
		{
			list.AddRange(Manager.mod.ExtraAuthoring);
		}
		list.AddRange(authoring.prefabList);
		HashSet<ObjectDataCD> hashSet = new HashSet<ObjectDataCD>();
		List<PrefabData> list2 = new List<PrefabData>();
		for (int i = 0; i < list.Count; i++)
		{
			MonoBehaviour monoBehaviour = list[i];
			if (monoBehaviour == null)
			{
				Debug.LogError($"Null prefab at position {i} PugDatabase");
			}
			else if (!(monoBehaviour is IEntityMonoBehaviourData { ObjectInfo: var objectInfo }))
			{
				Debug.Log(monoBehaviour.name + " doesn't implement IEntityMonoBehaviourData");
			}
			else if (!objectInfo.isCustomScenePrefab)
			{
				ObjectDataCD item = new ObjectDataCD
				{
					objectID = objectInfo.objectID,
					variation = objectInfo.variation
				};
				if (!hashSet.Contains(item))
				{
					hashSet.Add(item);
					list2.Add(new PrefabData
					{
						ObjectInfo = objectInfo
					});
				}
			}
		}
		list2.Sort();
		return list2;
	}
}
