using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveData
{
	[HideInInspector]
	public int Index;

	[SerializeField]
	[Header("$GetWaveDifficultyInfo")]
	private float difficultyMultiplier;

	[SerializeField]
	private List<MonsterSpawnData> list_SpawnData;

	public float DifficultyMultiplier => 0f;

	public List<MonsterSpawnData> List_SpawnData => null;

	public WaveData()
	{
	}

	public WaveData(float difficultyMultiplier, List<MonsterSpawnData> list_SpawnData)
	{
	}

	public WaveData CloneData()
	{
		return null;
	}

	public void OverrideDifficultyMultiplier(float value)
	{
	}

	private float CalculateInterval(MonsterSpawnData spawnData, MonsterSettingData monsterData)
	{
		return 0f;
	}

	public void AddSpawnData(MonsterSpawnData spawnData)
	{
	}

	public int GetTotalMonsterCount()
	{
		return 0;
	}
}
