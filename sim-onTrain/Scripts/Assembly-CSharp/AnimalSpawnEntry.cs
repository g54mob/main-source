using System;
using UnityEngine;

[Serializable]
public class AnimalSpawnEntry
{
	[Tooltip("Animal prefab to spawn")]
	public GameObject animalPrefab;

	[Tooltip("Destiny weight for spawn probability (higher = more common)")]
	[Range(1f, 100f)]
	public int destiny = 10;

	[Tooltip("Prefab name for display")]
	public string prefabName;

	public void UpdatePrefabName()
	{
		if (animalPrefab != null)
		{
			prefabName = animalPrefab.name;
		}
	}
}
