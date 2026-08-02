using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TrainSurvival/Animal Biome Data", fileName = "AnimalBiomeData")]
public class AnimalBiomeData : ScriptableObject
{
	[Header("Biome Info")]
	[Tooltip("Name of this biome")]
	public string biomeName = "Default Biome";

	[Header("Animal Spawn Settings")]
	[Tooltip("List of animals that can spawn in this biome with their destiny weights")]
	public List<AnimalSpawnEntry> animals = new List<AnimalSpawnEntry>();

	[Header("Spawn Point Settings")]
	[Tooltip("Area size for spawn point generation")]
	[Range(10f, 500f)]
	public float spawnAreaSize = 100f;

	[Tooltip("Distance between spawn points")]
	[Range(5f, 50f)]
	public float pointSpacing = 15f;

	[Tooltip("Number of raycast attempts per grid point")]
	[Range(1f, 5f)]
	public int raycastAttemptsPerPoint = 3;

	public int TotalDestinyWeight
	{
		get
		{
			int num = 0;
			foreach (AnimalSpawnEntry animal in animals)
			{
				num += animal.destiny;
			}
			return num;
		}
	}

	private void UpdateAllPrefabNames()
	{
		foreach (AnimalSpawnEntry animal in animals)
		{
			animal.UpdatePrefabName();
		}
	}

	public GameObject GetRandomAnimalPrefab()
	{
		if (animals == null || animals.Count == 0)
		{
			Debug.LogWarning("[AnimalBiomeData] " + biomeName + ": No animals configured!");
			return null;
		}
		int totalDestinyWeight = TotalDestinyWeight;
		if (totalDestinyWeight <= 0)
		{
			Debug.LogWarning("[AnimalBiomeData] " + biomeName + ": Total destiny weight is 0!");
			return null;
		}
		int num = Random.Range(0, totalDestinyWeight);
		int num2 = 0;
		foreach (AnimalSpawnEntry animal in animals)
		{
			num2 += animal.destiny;
			if (num < num2)
			{
				return animal.animalPrefab;
			}
		}
		return animals[0].animalPrefab;
	}

	private void OnValidate()
	{
		UpdateAllPrefabNames();
	}
}
