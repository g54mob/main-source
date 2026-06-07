using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSpawners_default", menuName = "Tower Factory/Spawners/LevelSpawners")]
public class LevelSpawners : ScriptableObject
{
	[Serializable]
	public class FAutoCycleConfig
	{
		public bool enabled = true;

		public int wavesAmount = 2;

		public RandomizableFloat waveMinStartTime = new RandomizableFloat(4f, Vector2.zero, EValueMode.Constant);

		public RandomizableFloat waveMaxStartTime = new RandomizableFloat(8f, Vector2.zero, EValueMode.Constant);

		public bool canModifyStartTimes = true;

		public bool useRoundWeightsInWave;

		public List<CycleSpawners.FAutoCycleSpawnerConfig> neutralSpawnersConfigs;

		public List<CycleSpawners.FAutoCycleWaveSpawnerConfig> waveSpawnersConfigs;

		public List<CycleSpawners.FAutoCycleBossSpawnerConfig> bossSpawnersConfigs;
	}

	[Serializable]
	public class FDifficultyCurveSettings
	{
		[SerializeField]
		private int startCycle;

		[SerializeField]
		private EDifficultyCurveType difficultyCurveType;

		[SerializeField]
		[Range(0f, 1f)]
		private float roundBias = 0.35f;

		[SerializeField]
		private float baseWaveValue = 10f;

		[SerializeField]
		private float progressionSpeedWaveValue = 1f;

		public int StartCycle
		{
			get
			{
				return startCycle;
			}
			set
			{
				startCycle = value;
			}
		}

		public EDifficultyCurveType DifficultyCurveType
		{
			get
			{
				return difficultyCurveType;
			}
			set
			{
				difficultyCurveType = value;
			}
		}

		public float RoundBias
		{
			get
			{
				return roundBias;
			}
			set
			{
				roundBias = value;
			}
		}

		public float BaseWaveValue
		{
			get
			{
				return baseWaveValue;
			}
			set
			{
				baseWaveValue = value;
			}
		}

		public float ProgressionSpeedWaveValue
		{
			get
			{
				return progressionSpeedWaveValue;
			}
			set
			{
				progressionSpeedWaveValue = value;
			}
		}
	}

	public enum EDifficultyCurveType
	{
		Exponential = 0,
		Geometric = 1
	}

	[Header("Editor balancing values")]
	[SerializeField]
	private List<FDifficultyCurveSettings> difficultyCurveSettings;

	[SerializeField]
	private float autoMaxSpawnRate = 1.3f;

	[SerializeField]
	private int autoStartEnemyEssence = 100;

	[SerializeField]
	private int autoEnemyEssencePerCycle = 75;

	[SerializeField]
	private int autoMaxEnemyEssence = 500;

	[SerializeField]
	[Range(0f, 1f)]
	private float autoEnemyEssenceSplitPercent = 0.65f;

	[SerializeField]
	private List<FAutoCycleConfig> autoCycleConfigs;

	[Header("Main")]
	[SerializeField]
	private List<CycleSpawners> cycleSpawners;

	public List<CycleSpawners> CycleSpawners => cycleSpawners;

	public List<FDifficultyCurveSettings> DifficultyCurveSettings
	{
		get
		{
			return difficultyCurveSettings;
		}
		set
		{
			difficultyCurveSettings = value;
		}
	}

	public List<FAutoCycleConfig> AutoCycleConfigs
	{
		get
		{
			return autoCycleConfigs;
		}
		set
		{
			autoCycleConfigs = value;
		}
	}

	private void UpdateCyclesBalancingValues()
	{
		foreach (CycleSpawners cycleSpawner in cycleSpawners)
		{
			cycleSpawner.ExpectedRoundTotalLifePerSecond = GetExpectedRoundTotalLifePerSecond(cycleSpawner.Cycle);
			cycleSpawner.ExpectedWaveLifePerSecond = GetExpectedWaveTotalLifePerSecond(cycleSpawner.Cycle);
		}
	}

	public bool AutoConfigureLevel(bool createAssets = false, float maxWaveLpSVariationPercentage = 0f)
	{
		int num = -1;
		if (DifficultyCurveSettings == null || DifficultyCurveSettings.Count == 0)
		{
			Debug.LogError("No se han encontrado difficultyCurveSettings para el LevelSpawner " + base.name);
			return false;
		}
		List<CycleSpawners> list = this.cycleSpawners;
		this.cycleSpawners = new List<CycleSpawners>();
		bool flag = true;
		foreach (FAutoCycleConfig autoCycleConfig in AutoCycleConfigs)
		{
			flag = true;
			num++;
			if (!autoCycleConfig.enabled && list != null && list.Count > num)
			{
				this.cycleSpawners.Add(list[num]);
				continue;
			}
			CycleSpawners cycleSpawners = ScriptableObject.CreateInstance<CycleSpawners>();
			float expectedRoundTotalLifePerSecond = GetExpectedRoundTotalLifePerSecond(num);
			float num2 = Mathf.Min(autoStartEnemyEssence + autoEnemyEssencePerCycle * num, autoMaxEnemyEssence);
			int totalRoundEnemyEssence = Mathf.RoundToInt(num2 * autoEnemyEssenceSplitPercent);
			int totalEnemyEssence = Mathf.RoundToInt(num2 * (1f - autoEnemyEssenceSplitPercent));
			float expectedWaveTotalLifePerSecond = GetExpectedWaveTotalLifePerSecond(num);
			cycleSpawners.AutoConfigureCycleRounds(autoCycleConfig.neutralSpawnersConfigs, expectedRoundTotalLifePerSecond, autoMaxSpawnRate, totalRoundEnemyEssence, num, createAssets);
			if (autoCycleConfig.useRoundWeightsInWave)
			{
				cycleSpawners.SetupWaveWeightsFromRoundSpawnRates(autoCycleConfig.waveSpawnersConfigs);
			}
			flag = cycleSpawners.AutoConfigureCycleWaves(autoCycleConfig.waveSpawnersConfigs, autoCycleConfig.bossSpawnersConfigs, expectedWaveTotalLifePerSecond, autoCycleConfig.wavesAmount, autoCycleConfig.waveMinStartTime, autoCycleConfig.waveMaxStartTime, totalEnemyEssence, autoCycleConfig.canModifyStartTimes, num, maxWaveLpSVariationPercentage, createAssets) && flag;
			this.cycleSpawners.Add(cycleSpawners);
			if (autoCycleConfig.useRoundWeightsInWave)
			{
				for (int i = 0; i < cycleSpawners.AutoWaveSpawnerConfigs.Count; i++)
				{
					autoCycleConfig.waveSpawnersConfigs[i].weight = cycleSpawners.AutoWaveSpawnerConfigs[i].weight;
				}
			}
		}
		list?.Clear();
		return flag;
	}

	public int GetTotalCyclesAmount()
	{
		return cycleSpawners.Count;
	}

	public List<EnemyData> GetCycleEnemies(int cycle)
	{
		List<EnemyData> list = new List<EnemyData>();
		foreach (CycleSpawners cycleSpawner in cycleSpawners)
		{
			if (cycleSpawner.Cycle != cycle)
			{
				continue;
			}
			foreach (WaveSpawnerConfig waveSpawner in cycleSpawner.WaveSpawners)
			{
				foreach (WaveEnemyData mainWaveEnemy in waveSpawner.MainWaveEnemies)
				{
					list.AddUnique(mainWaveEnemy.EnemyToSpawn.GetComponent<Enemy>().Data);
				}
				foreach (WaveEnemyData secondaryWaveEnemy in waveSpawner.SecondaryWaveEnemies)
				{
					list.AddUnique(secondaryWaveEnemy.EnemyToSpawn.GetComponent<Enemy>().Data);
				}
			}
			break;
		}
		return list;
	}

	private FDifficultyCurveSettings GetDifficultyCurveSettingToUse(int cycle)
	{
		if (DifficultyCurveSettings == null || DifficultyCurveSettings.Count == 0)
		{
			return null;
		}
		if (DifficultyCurveSettings.Count <= 1)
		{
			return DifficultyCurveSettings[0];
		}
		int index = 0;
		for (int i = 1; i < DifficultyCurveSettings.Count && DifficultyCurveSettings[i].StartCycle <= cycle; i++)
		{
			index = i;
		}
		return DifficultyCurveSettings[index];
	}

	public float GetExpectedRoundTotalLifePerSecond(int cycle)
	{
		FDifficultyCurveSettings difficultyCurveSettingToUse = GetDifficultyCurveSettingToUse(cycle);
		if (difficultyCurveSettingToUse == null)
		{
			return 0f;
		}
		float num = ((cycle > 0) ? GetExpectedWaveTotalLifePerSecond(cycle - 1) : 0f);
		float expectedWaveTotalLifePerSecond = GetExpectedWaveTotalLifePerSecond(cycle);
		if (num + 1f >= expectedWaveTotalLifePerSecond)
		{
			int num2 = cycle - 2;
			while (num2 >= 0 && num + 1f >= expectedWaveTotalLifePerSecond)
			{
				num = GetExpectedWaveTotalLifePerSecond(num2);
				num2--;
			}
		}
		return Mathf.Lerp(num, expectedWaveTotalLifePerSecond, difficultyCurveSettingToUse.RoundBias);
	}

	public float GetExpectedWaveTotalLifePerSecond(int cycle)
	{
		FDifficultyCurveSettings difficultyCurveSettingToUse = GetDifficultyCurveSettingToUse(cycle);
		if (difficultyCurveSettingToUse == null)
		{
			return 0f;
		}
		if (difficultyCurveSettingToUse.DifficultyCurveType == EDifficultyCurveType.Exponential)
		{
			return Mathf.Pow((float)(cycle - difficultyCurveSettingToUse.StartCycle) * difficultyCurveSettingToUse.BaseWaveValue, difficultyCurveSettingToUse.ProgressionSpeedWaveValue) + difficultyCurveSettingToUse.BaseWaveValue;
		}
		return difficultyCurveSettingToUse.BaseWaveValue * Mathf.Pow(difficultyCurveSettingToUse.ProgressionSpeedWaveValue, cycle - difficultyCurveSettingToUse.StartCycle);
	}

	public List<EnemyData> GetLevelBosses()
	{
		List<EnemyData> list = new List<EnemyData>();
		CycleSpawners cycleSpawners = this.cycleSpawners[this.cycleSpawners.Count - 1];
		for (int i = 0; i < cycleSpawners.WaveSpawners.Count; i++)
		{
			for (int j = 0; j < cycleSpawners.WaveSpawners[i].MainWaveEnemies.Count; j++)
			{
				if (cycleSpawners.WaveSpawners[i].MainWaveEnemies[j].EnemyToSpawn.TryGetComponent<Enemy>(out var component) && component.Data.Boss)
				{
					list.Add(component.Data);
				}
			}
			for (int k = 0; k < cycleSpawners.WaveSpawners[i].SecondaryWaveEnemies.Count; k++)
			{
				if (cycleSpawners.WaveSpawners[i].SecondaryWaveEnemies[k].EnemyToSpawn.TryGetComponent<Enemy>(out var component2) && component2.Data.Boss)
				{
					list.Add(component2.Data);
				}
			}
		}
		return list;
	}
}
