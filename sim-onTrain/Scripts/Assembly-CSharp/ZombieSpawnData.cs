using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieSpawnData", menuName = "TrainSurvival/Zombie Spawn Data")]
public class ZombieSpawnData : ScriptableObject
{
	[Serializable]
	public class ZombieSpawnInfo
	{
		public GameObject zombiePrefab;

		[Range(1f, 100f)]
		public int spawnWeight = 10;
	}

	[Header("Biome Info")]
	public string biomeName;

	[Header("Zombie Types")]
	public List<ZombieSpawnInfo> zombieTypes = new List<ZombieSpawnInfo>();

	public GameObject GetRandomZombie()
	{
		if (zombieTypes.Count == 0)
		{
			return null;
		}
		int num = 0;
		foreach (ZombieSpawnInfo zombieType in zombieTypes)
		{
			num += zombieType.spawnWeight;
		}
		int num2 = UnityEngine.Random.Range(0, num);
		int num3 = 0;
		foreach (ZombieSpawnInfo zombieType2 in zombieTypes)
		{
			num3 += zombieType2.spawnWeight;
			if (num2 < num3)
			{
				return zombieType2.zombiePrefab;
			}
		}
		return zombieTypes[0].zombiePrefab;
	}
}
