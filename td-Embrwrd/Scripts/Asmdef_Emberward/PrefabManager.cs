using System;
using UnityEngine;

public class PrefabManager : Singleton<PrefabManager>
{
	[Serializable]
	public class StringPrefabDictionary : SerializableDictionary<string, GameObject>
	{
	}

	[SerializeField]
	private StringPrefabDictionary dic_Prefabs;

	private void OnDestroy()
	{
	}

	private GameObject GetPrefab(string name)
	{
		return null;
	}

	public GameObject InstantiatePrefab(string name, Vector3 position, Quaternion rotation, Transform parent = null)
	{
		return null;
	}

	public GameObject InstantiatePrefab(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
	{
		return null;
	}

	public void DespawnPrefab(GameObject obj, float delay = 0f)
	{
	}
}
