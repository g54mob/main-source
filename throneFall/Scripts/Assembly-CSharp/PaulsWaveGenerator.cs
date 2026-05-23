using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ET Settings", menuName = "SimpleSiege/Pauls Legacy Wave Generator")]
public class PaulsWaveGenerator : EternalWaveGenerator
{
	[Serializable]
	public class EnemySpawnGroup
	{
		public EternalTrialEnemy enemy;

		public int count;

		public EnemySpawnGroup(EternalTrialEnemy enemy, int count)
		{
			this.enemy = enemy;
			this.count = count;
		}
	}

	public int startGold = 10;

	public int wavecount = 13;

	public int maxNumberOfGroupsToSpawnSimultaneously = 2;

	public float delayBetweenGroups = 5f;

	public float initialWaveStrength = 6f;

	public float targetWaveStrength = 300f;

	[Range(0f, 1f)]
	public float waveStrengthPerStageMultiplier = 0.15f;

	public AnimationCurve strengthProgression = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public int minGoldPerWave = 3;

	public int maxGoldPerWave = 20;

	public AnimationCurve goldProgression = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public int minEnemyTypeLimitPerWave = 2;

	public int maxEnemyTypeLimitPerWave = 5;

	public AnimationCurve enemyTypeLimitProgression = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public EternalTrialEnemySet enemySet;

	private List<Transform> flyingSpawns = new List<Transform>();

	private List<Transform> groundedSpawns = new List<Transform>();

	public float[] strengthPerWave = new float[0];

	public int[] goldPerWave = new int[0];

	public int[] enemyTypeLimitPerWave = new int[0];

	private void OnValidate()
	{
		RecalculateWaveParameters();
	}

	public void RecalculateWaveParameters()
	{
		RecalculateStrengthPerWave();
		RecalculateGoldPerWave();
		RecalculateEnemyTypeLimitPerWave();
	}

	private void RecalculateStrengthPerWave()
	{
		strengthPerWave = new float[wavecount];
		for (int i = 0; i < wavecount; i++)
		{
			strengthPerWave[i] = Mathf.Lerp(initialWaveStrength, targetWaveStrength, strengthProgression.Evaluate(Mathf.InverseLerp(0f, wavecount - 1, i)));
		}
	}

	private void RecalculateGoldPerWave()
	{
		goldPerWave = new int[wavecount];
		for (int i = 0; i < wavecount; i++)
		{
			goldPerWave[i] = Mathf.RoundToInt(Mathf.Lerp(minGoldPerWave, maxGoldPerWave, goldProgression.Evaluate(Mathf.InverseLerp(0f, wavecount - 1, i))));
		}
	}

	private void RecalculateEnemyTypeLimitPerWave()
	{
		enemyTypeLimitPerWave = new int[wavecount];
		for (int i = 0; i < wavecount; i++)
		{
			enemyTypeLimitPerWave[i] = Mathf.RoundToInt(Mathf.Lerp(minEnemyTypeLimitPerWave, maxEnemyTypeLimitPerWave, enemyTypeLimitProgression.Evaluate(Mathf.InverseLerp(0f, wavecount - 1, i))));
		}
	}

	public override List<Wave> GenerateWaves(EnemySpawnLine[] spawns, LevelInfo levelInfo, int stage, out int startingGold, int seed, int waveCountOverride = -1)
	{
		System.Random generator = new System.Random(seed);
		startingGold = startGold;
		flyingSpawns = new List<Transform>();
		groundedSpawns = new List<Transform>();
		foreach (EnemySpawnLine enemySpawnLine in spawns)
		{
			if (enemySpawnLine.canSpawnFlying)
			{
				flyingSpawns.Add(enemySpawnLine.SpawnLine);
			}
			if (enemySpawnLine.canSpawnSmallGround)
			{
				groundedSpawns.Add(enemySpawnLine.SpawnLine);
			}
		}
		RecalculateWaveParameters();
		List<Wave> list = new List<Wave>();
		List<EternalTrialEnemy> list2 = new List<EternalTrialEnemy>(enemySet.enemies);
		Dictionary<EternalTrialEnemy, int> openGroups = new Dictionary<EternalTrialEnemy, int>();
		List<EnemySpawnGroup> closedGroups = new List<EnemySpawnGroup>();
		List<EternalTrialEnemy> list3 = new List<EternalTrialEnemy>();
		float num = 1f + (float)EternalTrialsRunManager.CurrentRun.stage * waveStrengthPerStageMultiplier;
		float num2 = 0f;
		int num3 = 0;
		int num4 = 0;
		for (int j = 0; j < wavecount; j++)
		{
			list3.Clear();
			openGroups.Clear();
			closedGroups.Clear();
			num2 = strengthPerWave[j] * num;
			num3 = goldPerWave[j];
			num4 = enemyTypeLimitPerWave[j];
			int num5 = 0;
			while (num2 > 0f)
			{
				bool flag = false;
				if (num5 < num4)
				{
					list2.ETShuffle(generator);
					foreach (EternalTrialEnemy item in list2)
					{
						if (num2 >= item.difficultyValue)
						{
							num2 -= item.difficultyValue;
							TryAddEnemyToGroup(item, ref openGroups, ref closedGroups);
							flag = true;
							if (!list3.Contains(item))
							{
								num5++;
								list3.Add(item);
							}
							break;
						}
					}
				}
				else
				{
					list3.ETShuffle(generator);
					foreach (EternalTrialEnemy item2 in list3)
					{
						if (num2 >= item2.difficultyValue)
						{
							num2 -= item2.difficultyValue;
							TryAddEnemyToGroup(item2, ref openGroups, ref closedGroups);
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					break;
				}
			}
			foreach (KeyValuePair<EternalTrialEnemy, int> item3 in openGroups)
			{
				closedGroups.Add(new EnemySpawnGroup(item3.Key, item3.Value));
			}
			Wave wave = new Wave();
			int num6 = 0;
			float num7 = 0f;
			foreach (EnemySpawnGroup item4 in closedGroups)
			{
				num6++;
				if (num6 > maxNumberOfGroupsToSpawnSimultaneously)
				{
					num6 = 0;
					num7 += delayBetweenGroups;
				}
				Spawn spawn = new Spawn();
				if (num3 > 0)
				{
					num3 -= (spawn.goldCoins = UnityEngine.Random.Range(1, num3 + 1));
				}
				spawn.count = item4.count;
				spawn.interval = 0.15f;
				spawn.delay = num7;
				spawn.enemyPrefab = item4.enemy.enemyPrefab;
				if (item4.enemy.flying)
				{
					spawn.spawnLine = flyingSpawns[UnityEngine.Random.Range(0, flyingSpawns.Count)];
				}
				else
				{
					spawn.spawnLine = groundedSpawns[UnityEngine.Random.Range(0, groundedSpawns.Count)];
				}
				wave.spawns.Add(spawn);
			}
			if (num3 > 0)
			{
				wave.spawns[0].goldCoins += num3;
			}
			list.Add(wave);
		}
		return list;
	}

	private void TryAddEnemyToGroup(EternalTrialEnemy e, ref Dictionary<EternalTrialEnemy, int> openGroups, ref List<EnemySpawnGroup> closedGroups)
	{
		if (openGroups.ContainsKey(e))
		{
			openGroups[e]++;
			if (openGroups[e] + 1 > e.desiredGroupSize)
			{
				closedGroups.Add(new EnemySpawnGroup(e, openGroups[e]));
				openGroups.Remove(e);
			}
		}
		else
		{
			openGroups.Add(e, 1);
		}
	}
}
