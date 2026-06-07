using System;
using UnityEngine;

[Serializable]
public class MonsterSpawnData
{
	[SerializeField]
	private eMonsterType type;

	[SerializeField]
	private int spawnNodeIndex;

	[SerializeField]
	private float startTime;

	[SerializeField]
	private float spawnIntervalMultiplier;

	[SerializeField]
	private int waveCount;

	[SerializeField]
	private int countForEachSpawn;

	[HideInInspector]
	public bool isSubstituted;

	public eMonsterType MonsterType => default(eMonsterType);

	public int SpawnNodeIndex => 0;

	public float StartTime => 0f;

	public float SpawnIntervalMultiplier => 0f;

	public int WaveCount => 0;

	public int CountForEachSpawn => 0;

	public MonsterSpawnData()
	{
	}

	public MonsterSpawnData(eMonsterType type, int spawnNodeIndex, float startTime, float intervalMultiplier, int waveCount, int countForEachSpawn)
	{
	}

	public MonsterSpawnData CloneData()
	{
		return null;
	}

	public void OverrideMonsterType(eMonsterType type)
	{
	}

	public void OverrideCountForEachSpawn(int count)
	{
	}

	public void OverrideWaveCount(int count)
	{
	}

	public int GetTotalMonsterCountInWave()
	{
		return 0;
	}
}
