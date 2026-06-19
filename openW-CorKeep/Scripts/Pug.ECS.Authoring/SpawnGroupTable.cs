using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class SpawnGroupTable : MonoBehaviour
{
	[Serializable]
	public class FactionSpawnGroups
	{
		public FactionID faction;

		public List<SpawnGroup> spawnGroups;
	}

	[Serializable]
	public class SpawnGroup
	{
		public string name;

		[Tooltip("Player needs to kill this before group can spawn")]
		public ObjectData killRequirement;

		[ArrayElementTitle("objectData.objectID")]
		public List<SpawnObject> objects;

		public int weight;
	}

	[Serializable]
	public struct SpawnObject
	{
		public ObjectData objectData;

		[MinMax(1f, 10f)]
		public Pug.UnityExtensions.RangeInt amountToSpawn;
	}

	[Serializable]
	public struct BiomeSpawn
	{
		public Biome biome;

		public List<FactionID> factions;
	}

	[ArrayElementTitle("faction")]
	public List<FactionSpawnGroups> factionSpawnGroups;
}
