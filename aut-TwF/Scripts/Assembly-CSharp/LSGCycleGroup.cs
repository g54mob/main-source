using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LSGCycleGroup_default", menuName = "Tower Factory/Spawners/Level Spawner Generator Cycle Group")]
public class LSGCycleGroup : ScriptableObject
{
	[Serializable]
	public class EnemyTemplate
	{
		public int enemyTierIndex;

		public SpawnerConfigAutoConfig spawnerConfigAutoConfig;

		public float roundStartDelay;

		public bool forceMainQueue;

		public float weight = 1f;

		[HideInInspector]
		public float weightPercent;
	}

	[Serializable]
	private class CycleTemplate
	{
		public int wavesAmount = 2;

		public RandomizableFloat waveMinStartTime = new RandomizableFloat(4f, Vector2.zero, EValueMode.Constant);

		public RandomizableFloat waveMaxStartTime = new RandomizableFloat(8f, Vector2.zero, EValueMode.Constant);

		public bool canModifyStartTimes = true;

		public List<EnemyTemplate> enemyTemplates;
	}

	[Header("Main")]
	[SerializeField]
	private bool usePreviousDifficultySettings;

	[SerializeField]
	private LevelSpawners.EDifficultyCurveType difficultyCurveType;

	[SerializeField]
	[Range(0f, 1f)]
	private float roundBias = 0.35f;

	[SerializeField]
	private float baseWaveValue = 10f;

	[SerializeField]
	private float progressionSpeedWaveValue = 1f;

	[Space]
	[SerializeField]
	private int bossWave = 1;

	[SerializeField]
	[Tooltip("Multiplicador que se aplica a los LpS del último cycle para determinar la vida del boss")]
	private float bossLifeMultiplier;

	[Header("Cycles config")]
	[SerializeField]
	private List<LevelSpawnersGenerator.EEnemyTier> enemyTiersToUse;

	[SerializeField]
	private List<CycleTemplate> cycleTemplates;

	public bool UsePreviousDifficultySettings => usePreviousDifficultySettings;

	public LevelSpawners.EDifficultyCurveType DifficultyCurveType => difficultyCurveType;

	public float RoundBias => roundBias;

	public float BaseWaveValue => baseWaveValue;

	public float ProgressionSpeedWaveValue => progressionSpeedWaveValue;

	public int BossWave => bossWave;

	public float BossLifeMultiplier => bossLifeMultiplier;

	public List<LevelSpawnersGenerator.EEnemyTier> EnemyTiersToUse => enemyTiersToUse;

	private List<CycleTemplate> CycleTemplates => cycleTemplates;

	public List<LevelSpawners.FAutoCycleConfig> GenerateAutoCycleConfigs(List<LevelSpawnersGenerator.FEnemyInfo> availableEnemies, LevelSpawnersGenerator.FBossGroup bossGroup)
	{
		List<LevelSpawners.FAutoCycleConfig> list = new List<LevelSpawners.FAutoCycleConfig>();
		List<GameObject> enemiesToUse = GetEnemiesToUse(availableEnemies);
		foreach (CycleTemplate cycleTemplate in cycleTemplates)
		{
			LevelSpawners.FAutoCycleConfig fAutoCycleConfig = new LevelSpawners.FAutoCycleConfig();
			fAutoCycleConfig.wavesAmount = cycleTemplate.wavesAmount;
			fAutoCycleConfig.waveMinStartTime = cycleTemplate.waveMinStartTime;
			fAutoCycleConfig.waveMaxStartTime = cycleTemplate.waveMaxStartTime;
			fAutoCycleConfig.canModifyStartTimes = cycleTemplate.canModifyStartTimes;
			fAutoCycleConfig.useRoundWeightsInWave = true;
			fAutoCycleConfig.neutralSpawnersConfigs = new List<CycleSpawners.FAutoCycleSpawnerConfig>();
			foreach (EnemyTemplate enemyTemplate in cycleTemplate.enemyTemplates)
			{
				if (enemiesToUse.Count > enemyTemplate.enemyTierIndex)
				{
					CycleSpawners.FAutoCycleSpawnerConfig fAutoCycleSpawnerConfig = new CycleSpawners.FAutoCycleSpawnerConfig();
					fAutoCycleSpawnerConfig.enemy = enemiesToUse[enemyTemplate.enemyTierIndex];
					fAutoCycleSpawnerConfig.spawnerConfigAutoConfig = enemyTemplate.spawnerConfigAutoConfig;
					fAutoCycleSpawnerConfig.startDelay = enemyTemplate.roundStartDelay;
					fAutoCycleSpawnerConfig.weight = enemyTemplate.weight;
					fAutoCycleConfig.neutralSpawnersConfigs.Add(fAutoCycleSpawnerConfig);
				}
			}
			fAutoCycleConfig.waveSpawnersConfigs = new List<CycleSpawners.FAutoCycleWaveSpawnerConfig>();
			bool flag = false;
			foreach (EnemyTemplate enemyTemplate2 in cycleTemplate.enemyTemplates)
			{
				if (enemiesToUse.Count > enemyTemplate2.enemyTierIndex)
				{
					CycleSpawners.FAutoCycleWaveSpawnerConfig fAutoCycleWaveSpawnerConfig = new CycleSpawners.FAutoCycleWaveSpawnerConfig();
					fAutoCycleWaveSpawnerConfig.enemy = enemiesToUse[enemyTemplate2.enemyTierIndex];
					if (fAutoCycleWaveSpawnerConfig.enemy.TryGetComponent<Enemy>(out var component))
					{
						flag = component.EnemyType == Enemy.EEnemyType.Flying || component.GetComponent<StatsComponent>().GetConfigStat(EStats.MovementSpeed) > 1.5f;
					}
					fAutoCycleWaveSpawnerConfig.queue = ((flag && !enemyTemplate2.forceMainQueue) ? CycleSpawners.FAutoCycleWaveSpawnerConfig.EQueue.Secondary : CycleSpawners.FAutoCycleWaveSpawnerConfig.EQueue.Main);
					fAutoCycleConfig.waveSpawnersConfigs.Add(fAutoCycleWaveSpawnerConfig);
				}
			}
			list.Add(fAutoCycleConfig);
		}
		list[list.Count - 1].bossSpawnersConfigs = new List<CycleSpawners.FAutoCycleBossSpawnerConfig>();
		foreach (GameObject enemy in bossGroup.enemies)
		{
			CycleSpawners.FAutoCycleBossSpawnerConfig fAutoCycleBossSpawnerConfig = new CycleSpawners.FAutoCycleBossSpawnerConfig();
			fAutoCycleBossSpawnerConfig.enemy = enemy;
			fAutoCycleBossSpawnerConfig.wave = bossWave;
			list[list.Count - 1].bossSpawnersConfigs.Add(fAutoCycleBossSpawnerConfig);
		}
		return list;
	}

	public float CalculateEnemyLifeMultiplier()
	{
		if (DifficultyCurveType == LevelSpawners.EDifficultyCurveType.Exponential)
		{
			return 1f;
		}
		return BaseWaveValue * Mathf.Pow(ProgressionSpeedWaveValue, cycleTemplates.Count) / BaseWaveValue;
	}

	private List<GameObject> GetEnemiesToUse(List<LevelSpawnersGenerator.FEnemyInfo> availableEnemies)
	{
		List<GameObject> list = new List<GameObject>();
		List<LevelSpawnersGenerator.FEnemyInfo> list2 = new List<LevelSpawnersGenerator.FEnemyInfo>();
		for (int i = 0; i < availableEnemies.Count; i++)
		{
			list2.Add(availableEnemies[i]);
		}
		int index = 0;
		for (int j = 0; j < enemyTiersToUse.Count; j++)
		{
			bool flag = false;
			int num = 0;
			while (!flag && num < 10)
			{
				for (int k = 0; k < list2.Count; k++)
				{
					if (list2[k].tier == (LevelSpawnersGenerator.EEnemyTier)Mathf.Max((int)(enemyTiersToUse[j] + num), 0))
					{
						index = k;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					for (int l = 0; l < list2.Count; l++)
					{
						if (list2[l].tier == (LevelSpawnersGenerator.EEnemyTier)Mathf.Max((int)(enemyTiersToUse[j] - num), 0))
						{
							index = l;
							flag = true;
							break;
						}
					}
				}
				num++;
			}
			list.Add(list2[index].enemy);
			list2.RemoveAt(index);
		}
		return list;
	}
}
