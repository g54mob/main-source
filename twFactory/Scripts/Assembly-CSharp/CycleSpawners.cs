using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "CycleSpawner_default", menuName = "Tower Factory/Spawners/CycleSpawner")]
public class CycleSpawners : ScriptableObject
{
	[Serializable]
	public class FAutoCycleSpawnerConfig
	{
		public GameObject enemy;

		public SpawnerConfigAutoConfig spawnerConfigAutoConfig;

		[Tooltip("Tiempo extra entre un enemigo y otro, además del auto calculado")]
		public float extraInBetweenTime;

		public float startDelay;

		public float weight = 1f;

		[HideInInspector]
		public float weightPercent;
	}

	[Serializable]
	public class FAutoCycleWaveSpawnerConfig
	{
		public enum EQueue
		{
			Main = 0,
			Secondary = 1
		}

		public GameObject enemy;

		[Tooltip("Tiempo extra entre un enemigo y otro, además del auto calculado")]
		public float extraInBetweenTime;

		public EQueue queue;

		public float weight = 1f;

		[HideInInspector]
		public float weightPercent;
	}

	[Serializable]
	public class FAutoCycleBossSpawnerConfig
	{
		public GameObject enemy;

		public int wave = 1;
	}

	private const float MIN_WAVE_DURATION = 30f;

	[SerializeField]
	private int cycle;

	[SerializeField]
	private List<FAutoCycleSpawnerConfig> autoRoundSpawnerConfigs;

	[SerializeField]
	private float totalRoundLpS = 1f;

	[SerializeField]
	private float maxRoundSpawnRate = -1f;

	[SerializeField]
	private int totalRoundEnemyEssence;

	[Space]
	[SerializeField]
	private List<FAutoCycleWaveSpawnerConfig> autoWaveSpawnerConfigs;

	[SerializeField]
	private List<FAutoCycleBossSpawnerConfig> autoBossSpawnerConfigs;

	[SerializeField]
	private float totalWaveLpS = 1f;

	[SerializeField]
	private int wavesAmount;

	[SerializeField]
	private RandomizableFloat minWaveStartTime;

	[SerializeField]
	private RandomizableFloat maxWaveStartTime;

	[SerializeField]
	private bool canModifyStartTimes = true;

	[SerializeField]
	private int totalWaveEnemyEssence;

	[Space(10f)]
	[SerializeField]
	[FormerlySerializedAs("neutralSpawners")]
	private List<SpawnerConfig> roundSpawners;

	[SerializeField]
	[FormerlySerializedAs("newWaveSpawners")]
	private List<WaveSpawnerConfig> waveSpawners;

	private float expectedRoundTotalLifePerSecond;

	private float expectedWaveLifePerSecond;

	public List<SpawnerConfig> RoundSpawners
	{
		get
		{
			return roundSpawners;
		}
		set
		{
			roundSpawners = value;
		}
	}

	public List<WaveSpawnerConfig> WaveSpawners
	{
		get
		{
			return waveSpawners;
		}
		set
		{
			waveSpawners = value;
		}
	}

	public int Cycle => cycle;

	public float ExpectedRoundTotalLifePerSecond
	{
		get
		{
			return expectedRoundTotalLifePerSecond;
		}
		set
		{
			expectedRoundTotalLifePerSecond = FunctionLibrary.RoundToDecimals(value, 2);
		}
	}

	public float ExpectedWaveLifePerSecond
	{
		get
		{
			return expectedWaveLifePerSecond;
		}
		set
		{
			expectedWaveLifePerSecond = FunctionLibrary.RoundToDecimals(value, 2);
		}
	}

	public List<FAutoCycleWaveSpawnerConfig> AutoWaveSpawnerConfigs => autoWaveSpawnerConfigs;

	public void AutoConfigureCycleRounds(List<FAutoCycleSpawnerConfig> roundSpawnerConfigs, float totalRoundLpS, float maxRoundSpawnRate, int totalRoundEnemyEssence, int cycleIdx, bool createAssets)
	{
		autoRoundSpawnerConfigs = roundSpawnerConfigs;
		this.totalRoundLpS = totalRoundLpS;
		this.maxRoundSpawnRate = maxRoundSpawnRate;
		this.totalRoundEnemyEssence = totalRoundEnemyEssence;
		cycle = cycleIdx;
		bool flag = false;
		List<float> list = new List<float>();
		if (!CheckRoundWeightsWithMaxSpawnRate(verbose: false))
		{
			flag = true;
			for (int i = 0; i < autoRoundSpawnerConfigs.Count; i++)
			{
				list.Add(autoRoundSpawnerConfigs[i].weight);
			}
			AdaptRoundWeightsToMaxSpawnRate();
		}
		float num = CalculateTotalRoundWeights();
		float num2 = 0f;
		int num3 = totalRoundEnemyEssence;
		roundSpawners = new List<SpawnerConfig>();
		foreach (FAutoCycleSpawnerConfig autoRoundSpawnerConfig in autoRoundSpawnerConfigs)
		{
			if ((bool)autoRoundSpawnerConfig.enemy && (bool)autoRoundSpawnerConfig.spawnerConfigAutoConfig && !(autoRoundSpawnerConfig.weight <= 0f))
			{
				SpawnerConfig spawnerConfig = ScriptableObject.CreateInstance<SpawnerConfig>();
				num2 = autoRoundSpawnerConfig.weight / num;
				float targetLpS = this.totalRoundLpS * num2;
				int num4 = Mathf.Min(Mathf.CeilToInt((float)totalRoundEnemyEssence * num2), num3);
				num3 -= num4;
				spawnerConfig.AutoConfigure(autoRoundSpawnerConfig.spawnerConfigAutoConfig.AutoConfigData, autoRoundSpawnerConfig.enemy, targetLpS, autoRoundSpawnerConfig.startDelay, autoRoundSpawnerConfig.extraInBetweenTime, num4, cycle);
				roundSpawners.Add(spawnerConfig);
			}
		}
		if (flag)
		{
			for (int j = 0; j < autoRoundSpawnerConfigs.Count; j++)
			{
				autoRoundSpawnerConfigs[j].weight = list[j];
			}
		}
	}

	public bool AutoConfigureCycleWaves(List<FAutoCycleWaveSpawnerConfig> autoWaveSpawnerConfigs, List<FAutoCycleBossSpawnerConfig> autoBossSpawnerConfigs, float totalWaveLpS, int wavesAmount, RandomizableFloat minStartTime, RandomizableFloat maxStartTime, int totalEnemyEssence, bool canModifyStartTimes, int cycleIdx, float maxLpSVariationPercentage, bool createAssets)
	{
		this.autoWaveSpawnerConfigs = autoWaveSpawnerConfigs;
		this.totalWaveLpS = totalWaveLpS;
		this.wavesAmount = wavesAmount;
		minWaveStartTime = minStartTime;
		maxWaveStartTime = maxStartTime;
		totalWaveEnemyEssence = totalEnemyEssence;
		int num = 200;
		int num2 = num * ((!canModifyStartTimes && !(maxLpSVariationPercentage > 0f)) ? 1 : 10);
		int num3 = 0;
		int num4 = 0;
		bool flag = false;
		float num5 = minStartTime.Value;
		float num6 = maxStartTime.Value;
		float num7 = 0f;
		while (num4 <= num2 && !flag)
		{
			if (num4 == num2)
			{
				if (canModifyStartTimes)
				{
					Debug.LogError("No se ha podido encontrar una configuración de WaveSpawnerConfigs válida para el cycle " + cycle.ToString("D2"));
				}
				break;
			}
			waveSpawners = InitializeWaveSpawnerConfigs(autoWaveSpawnerConfigs, wavesAmount, 0f);
			for (int i = 1; i < WaveSpawners.Count; i++)
			{
				WaveSpawners[i].MainWaveStartDelay = num6;
				WaveSpawners[i].SecondaryWaveStartDelay = num6;
			}
			num3 = 0;
			while (num3 <= num)
			{
				if (num3 == num)
				{
					if (canModifyStartTimes)
					{
						num5 = Mathf.Max(0f, num5 - 1f);
						num6 *= 1.1f;
						if (maxLpSVariationPercentage > 0f)
						{
							num7 = Mathf.Lerp(0f, maxLpSVariationPercentage, (float)num4 / (float)num2);
						}
					}
					break;
				}
				int totalWaveLife = GetTotalWaveLife();
				float totalDuration = GetTotalDuration(num6, num6);
				float totalDuration2 = GetTotalDuration(num5, num5);
				float num8 = (float)totalWaveLife / Mathf.Max(totalDuration, 30f);
				float num9 = (float)totalWaveLife / Mathf.Max(totalDuration2, 30f);
				float num10 = totalWaveLpS - totalWaveLpS * num7;
				if (totalWaveLpS + totalWaveLpS * num7 >= num8 && num10 <= num9)
				{
					float num11 = Mathf.Max((num8 * totalDuration / totalWaveLpS - GetTotalDuration(0f, 0f)) / (float)(WaveSpawners.Count - 1), 2f);
					for (int j = 1; j < WaveSpawners.Count; j++)
					{
						WaveSpawners[j].MainWaveStartDelay = num11;
						WaveSpawners[j].SecondaryWaveStartDelay = num11;
					}
					flag = true;
					break;
				}
				if (num9 < totalWaveLpS)
				{
					FAutoCycleWaveSpawnerConfig enemyWithLowerWeightDeviation = GetEnemyWithLowerWeightDeviation();
					int num12 = int.MaxValue;
					int index = 0;
					for (int num13 = WaveSpawners.Count - 1; num13 >= 0; num13--)
					{
						int num14 = WaveSpawners[num13].CalculateTotalEnemiesAmountByType(enemyWithLowerWeightDeviation.enemy);
						if (num14 < num12)
						{
							num12 = num14;
							index = num13;
						}
					}
					WaveSpawners[index].IncreaseEnemyAmountByType(enemyWithLowerWeightDeviation.enemy, 1);
				}
				else if (num8 > totalWaveLpS)
				{
					FAutoCycleWaveSpawnerConfig enemyWithHigherWeightDeviation = GetEnemyWithHigherWeightDeviation();
					int num15 = 0;
					int index2 = 0;
					for (int k = 0; k < WaveSpawners.Count; k++)
					{
						int num16 = WaveSpawners[k].CalculateTotalEnemiesAmountByType(enemyWithHigherWeightDeviation.enemy);
						if (num16 > num15)
						{
							num15 = num16;
							index2 = k;
						}
					}
					WaveSpawners[index2].IncreaseEnemyAmountByType(enemyWithHigherWeightDeviation.enemy, -1);
				}
				num3++;
				num4++;
			}
		}
		PurgeWaveSpawnersConfigs();
		DistributeWaveEnemyEssence();
		AutoConfigureCycleBoss(autoBossSpawnerConfigs, cycleIdx, createAssets);
		return flag;
	}

	public void SetupWaveWeightsFromRoundSpawnRates(List<FAutoCycleWaveSpawnerConfig> autoWaveSpawnerConfigs)
	{
		this.autoWaveSpawnerConfigs = autoWaveSpawnerConfigs;
		float num = float.PositiveInfinity;
		float totalWeights = CalculateTotalRoundWeights();
		for (int i = 0; i < autoRoundSpawnerConfigs.Count; i++)
		{
			float num2 = CalculateRoundSpawnerSpawnRate(autoRoundSpawnerConfigs[i], totalRoundLpS, totalWeights);
			if (num2 < num)
			{
				num = num2;
			}
		}
		foreach (FAutoCycleWaveSpawnerConfig autoWaveSpawnerConfig in AutoWaveSpawnerConfigs)
		{
			float num2 = 0f;
			for (int j = 0; j < autoRoundSpawnerConfigs.Count; j++)
			{
				if (autoRoundSpawnerConfigs[j].enemy == autoWaveSpawnerConfig.enemy)
				{
					num2 = CalculateRoundSpawnerSpawnRate(autoRoundSpawnerConfigs[j], totalRoundLpS, totalWeights);
					break;
				}
			}
			autoWaveSpawnerConfig.weight = FunctionLibrary.RoundToDecimals(num2 / num, 2);
		}
	}

	public void AutoConfigureCycleBoss(List<FAutoCycleBossSpawnerConfig> autoBossSpawnerConfigs, int cycleIdx, bool createAssets)
	{
		if (autoBossSpawnerConfigs != null && autoBossSpawnerConfigs.Count != 0)
		{
			this.autoBossSpawnerConfigs = autoBossSpawnerConfigs;
			for (int i = 0; i < this.autoBossSpawnerConfigs.Count; i++)
			{
				FAutoCycleBossSpawnerConfig fAutoCycleBossSpawnerConfig = autoBossSpawnerConfigs[i];
				WaveEnemyData waveEnemyData = new WaveEnemyData();
				waveEnemyData.EnemyToSpawn = fAutoCycleBossSpawnerConfig.enemy;
				waveEnemyData.AmountToSpawn = 1;
				WaveSpawners[fAutoCycleBossSpawnerConfig.wave - 1].MainWaveEnemies.Add(waveEnemyData);
			}
		}
	}

	private List<WaveSpawnerConfig> InitializeWaveSpawnerConfigs(List<FAutoCycleWaveSpawnerConfig> autoConfigs, int wavesAmount, float startTime)
	{
		List<WaveSpawnerConfig> list = new List<WaveSpawnerConfig>();
		CalculateTotalWaveWeights();
		float minWaveWeight = GetMinWaveWeight();
		for (int i = 0; i < wavesAmount; i++)
		{
			WaveSpawnerConfig waveSpawnerConfig = ScriptableObject.CreateInstance<WaveSpawnerConfig>();
			waveSpawnerConfig.MainWaveEnemies = new List<WaveEnemyData>();
			waveSpawnerConfig.SecondaryWaveEnemies = new List<WaveEnemyData>();
			for (int j = 0; j < autoConfigs.Count; j++)
			{
				FAutoCycleWaveSpawnerConfig fAutoCycleWaveSpawnerConfig = autoConfigs[j];
				WaveEnemyData waveEnemyData = new WaveEnemyData();
				waveEnemyData.EnemyToSpawn = fAutoCycleWaveSpawnerConfig.enemy;
				waveEnemyData.AmountToSpawn = Mathf.RoundToInt(fAutoCycleWaveSpawnerConfig.weight / minWaveWeight);
				waveEnemyData.ExtraInBetweenSpawnsTime = fAutoCycleWaveSpawnerConfig.extraInBetweenTime;
				if (fAutoCycleWaveSpawnerConfig.queue == FAutoCycleWaveSpawnerConfig.EQueue.Main)
				{
					waveSpawnerConfig.MainWaveEnemies.Add(waveEnemyData);
				}
				else
				{
					waveSpawnerConfig.SecondaryWaveEnemies.Add(waveEnemyData);
				}
				waveSpawnerConfig.MainWaveStartDelay = startTime;
				waveSpawnerConfig.SecondaryWaveStartDelay = startTime;
			}
			list.Add(waveSpawnerConfig);
		}
		return list;
	}

	private void PurgeWaveSpawnersConfigs()
	{
		for (int num = WaveSpawners.Count - 1; num >= 0; num--)
		{
			WaveSpawnerConfig waveSpawnerConfig = WaveSpawners[num];
			for (int num2 = waveSpawnerConfig.MainWaveEnemies.Count - 1; num2 >= 0; num2--)
			{
				if (waveSpawnerConfig.MainWaveEnemies[num2].AmountToSpawn == 0)
				{
					waveSpawnerConfig.MainWaveEnemies.RemoveAt(num2);
				}
			}
			for (int num3 = waveSpawnerConfig.SecondaryWaveEnemies.Count - 1; num3 >= 0; num3--)
			{
				if (waveSpawnerConfig.SecondaryWaveEnemies[num3].AmountToSpawn == 0)
				{
					waveSpawnerConfig.SecondaryWaveEnemies.RemoveAt(num3);
				}
			}
			if (waveSpawnerConfig.MainWaveEnemies.Count == 0 && waveSpawnerConfig.SecondaryWaveEnemies.Count == 0)
			{
				WaveSpawners.RemoveAt(num);
			}
		}
	}

	private void DistributeWaveEnemyEssence()
	{
		Dictionary<GameObject, (int, int, int)> dictionary = new Dictionary<GameObject, (int, int, int)>();
		int totalEnemiesLife = 0;
		int num = totalWaveEnemyEssence;
		for (int i = 0; i < AutoWaveSpawnerConfigs.Count; i++)
		{
			int currentWaveTotalEnemiesAmountByType = GetCurrentWaveTotalEnemiesAmountByType(AutoWaveSpawnerConfigs[i].enemy);
			int item = (int)CalculateEnemyTotalLife(AutoWaveSpawnerConfigs[i].enemy) * currentWaveTotalEnemiesAmountByType;
			dictionary[AutoWaveSpawnerConfigs[i].enemy] = (0, currentWaveTotalEnemiesAmountByType, item);
		}
		dictionary.ToList().ForEach(delegate(KeyValuePair<GameObject, (int essencePerEnemy, int amount, int totalLife)> x)
		{
			totalEnemiesLife += x.Value.totalLife;
		});
		foreach (FAutoCycleWaveSpawnerConfig autoWaveSpawnerConfig in AutoWaveSpawnerConfigs)
		{
			if (dictionary.ContainsKey(autoWaveSpawnerConfig.enemy))
			{
				(int, int, int) value = dictionary[autoWaveSpawnerConfig.enemy];
				if (value.Item2 > 0)
				{
					value.Item1 = Mathf.RoundToInt((float)value.Item3 / (float)totalEnemiesLife * (float)totalWaveEnemyEssence / (float)value.Item2);
					dictionary[autoWaveSpawnerConfig.enemy] = value;
				}
			}
		}
		for (int num2 = 0; num2 < WaveSpawners.Count; num2++)
		{
			for (int num3 = 0; num3 < WaveSpawners[num2].MainWaveEnemies.Count; num3++)
			{
				WaveEnemyData waveEnemyData = WaveSpawners[num2].MainWaveEnemies[num3];
				waveEnemyData.EnemyEssence = Mathf.Min(dictionary[waveEnemyData.EnemyToSpawn].Item1 * waveEnemyData.AmountToSpawn, num);
				num -= waveEnemyData.EnemyEssence;
			}
			for (int num4 = 0; num4 < WaveSpawners[num2].SecondaryWaveEnemies.Count; num4++)
			{
				WaveEnemyData waveEnemyData = WaveSpawners[num2].SecondaryWaveEnemies[num4];
				waveEnemyData.EnemyEssence = Mathf.Min(dictionary[waveEnemyData.EnemyToSpawn].Item1 * waveEnemyData.AmountToSpawn, num);
				num -= waveEnemyData.EnemyEssence;
			}
		}
		if (num <= 0)
		{
			return;
		}
		List<WaveSpawnerConfig> list = WaveSpawners;
		if (list[list.Count - 1].MainWaveEnemies != null)
		{
			List<WaveSpawnerConfig> list2 = WaveSpawners;
			if (list2[list2.Count - 1].MainWaveEnemies.Count > 0)
			{
				List<WaveSpawnerConfig> list3 = WaveSpawners;
				List<WaveEnemyData> mainWaveEnemies = list3[list3.Count - 1].MainWaveEnemies;
				mainWaveEnemies[mainWaveEnemies.Count - 1].EnemyEssence += num;
				return;
			}
		}
		List<WaveSpawnerConfig> list4 = WaveSpawners;
		if (list4[list4.Count - 1].SecondaryWaveEnemies != null)
		{
			List<WaveSpawnerConfig> list5 = WaveSpawners;
			if (list5[list5.Count - 1].SecondaryWaveEnemies.Count > 0)
			{
				List<WaveSpawnerConfig> list6 = WaveSpawners;
				List<WaveEnemyData> secondaryWaveEnemies = list6[list6.Count - 1].SecondaryWaveEnemies;
				secondaryWaveEnemies[secondaryWaveEnemies.Count - 1].EnemyEssence += num;
			}
		}
	}

	[Tooltip("Modifica la configuración de pesos actual para que pueda cumplir el Max Spawn Rate")]
	private void AdaptRoundWeightsToMaxSpawnRate()
	{
		int num = 100;
		float num2 = 0.85f;
		CalculateTotalRoundSpawnRate();
		int num3 = 0;
		bool flag = false;
		while (!CheckRoundWeightsWithMaxSpawnRate(verbose: false) && num3 <= num)
		{
			if (num3 == num)
			{
				string text = ((cycle >= 0) ? (" (cycle " + cycle.ToString("D2") + ")") : "");
				Debug.LogError("No se ha podido encontrar una configuración de weights para " + base.name + " que cumpla con el maxRoundSpawnRate." + text);
				break;
			}
			flag = true;
			float num4 = 0f;
			int index = 0;
			for (int i = 0; i < autoRoundSpawnerConfigs.Count; i++)
			{
				float num5 = CalculateRoundSpawnerSpawnRate(autoRoundSpawnerConfigs[i], totalRoundLpS, CalculateTotalRoundWeights());
				if (num5 > num4)
				{
					num4 = num5;
					index = i;
				}
			}
			autoRoundSpawnerConfigs[index].weight *= num2;
			CalculateTotalRoundSpawnRate();
			num3++;
		}
		if (flag)
		{
			string text2 = ((cycle >= 0) ? (" (cycle " + cycle.ToString("D2") + ")") : "");
			Debug.LogWarning("Se han modificado los weights para cumplir con MaxSpawnRate." + text2);
		}
	}

	[Tooltip("Comprueba si la configuración actual de weights cumple con el maxRoundSpawnRate")]
	private bool CheckRoundWeightsWithMaxSpawnRate(bool verbose)
	{
		return CalculateTotalRoundSpawnRate() <= maxRoundSpawnRate;
	}

	[Tooltip("Calcula los weights de la wave a partir de los de la round")]
	private void CalculateWaveWeightsFromRoundWeights()
	{
		SetupWaveWeightsFromRoundSpawnRates(AutoWaveSpawnerConfigs);
	}

	private float CalculateTotalRoundWeights()
	{
		float num = 0f;
		for (int i = 0; i < autoRoundSpawnerConfigs.Count; i++)
		{
			if ((bool)autoRoundSpawnerConfigs[i].enemy && (bool)autoRoundSpawnerConfigs[i].spawnerConfigAutoConfig && autoRoundSpawnerConfigs[i].weight > 0f)
			{
				num += autoRoundSpawnerConfigs[i].weight;
			}
		}
		return num;
	}

	private float CalculateTotalWaveWeights()
	{
		float num = 0f;
		for (int i = 0; i < AutoWaveSpawnerConfigs.Count; i++)
		{
			if ((bool)AutoWaveSpawnerConfigs[i].enemy && AutoWaveSpawnerConfigs[i].weight > 0f)
			{
				num += AutoWaveSpawnerConfigs[i].weight;
			}
		}
		return num;
	}

	private float GetMinWaveWeight()
	{
		float num = float.PositiveInfinity;
		for (int i = 0; i < AutoWaveSpawnerConfigs.Count; i++)
		{
			if (AutoWaveSpawnerConfigs[i].weight < num)
			{
				num = AutoWaveSpawnerConfigs[i].weight;
			}
		}
		return num;
	}

	private FAutoCycleWaveSpawnerConfig GetEnemyWithLowerWeightDeviation()
	{
		FAutoCycleWaveSpawnerConfig fAutoCycleWaveSpawnerConfig = null;
		int currentWaveTotalEnemiesAmount = GetCurrentWaveTotalEnemiesAmount();
		float num = float.PositiveInfinity;
		for (int i = 0; i < AutoWaveSpawnerConfigs.Count; i++)
		{
			float waveWeightDeviation = GetWaveWeightDeviation(AutoWaveSpawnerConfigs[i], currentWaveTotalEnemiesAmount);
			if (waveWeightDeviation < num)
			{
				num = waveWeightDeviation;
				fAutoCycleWaveSpawnerConfig = AutoWaveSpawnerConfigs[i];
			}
			else if (waveWeightDeviation == num && CalculateEnemyTotalLife(AutoWaveSpawnerConfigs[i].enemy) < CalculateEnemyTotalLife(fAutoCycleWaveSpawnerConfig.enemy))
			{
				fAutoCycleWaveSpawnerConfig = AutoWaveSpawnerConfigs[i];
			}
		}
		return fAutoCycleWaveSpawnerConfig;
	}

	private FAutoCycleWaveSpawnerConfig GetEnemyWithHigherWeightDeviation()
	{
		FAutoCycleWaveSpawnerConfig fAutoCycleWaveSpawnerConfig = null;
		int currentWaveTotalEnemiesAmount = GetCurrentWaveTotalEnemiesAmount();
		float num = float.NegativeInfinity;
		for (int i = 0; i < AutoWaveSpawnerConfigs.Count; i++)
		{
			float waveWeightDeviation = GetWaveWeightDeviation(AutoWaveSpawnerConfigs[i], currentWaveTotalEnemiesAmount);
			if (waveWeightDeviation > num)
			{
				num = waveWeightDeviation;
				fAutoCycleWaveSpawnerConfig = AutoWaveSpawnerConfigs[i];
			}
			else if (waveWeightDeviation == num && CalculateEnemyTotalLife(AutoWaveSpawnerConfigs[i].enemy) < CalculateEnemyTotalLife(fAutoCycleWaveSpawnerConfig.enemy))
			{
				fAutoCycleWaveSpawnerConfig = AutoWaveSpawnerConfigs[i];
			}
		}
		return fAutoCycleWaveSpawnerConfig;
	}

	private float GetWaveWeightDeviation(FAutoCycleWaveSpawnerConfig autoCycleWSC, int totalEnemiesAmount)
	{
		float num = (float)GetCurrentWaveTotalEnemiesAmountByType(autoCycleWSC.enemy) / (float)totalEnemiesAmount;
		float num2 = autoCycleWSC.weight / CalculateTotalWaveWeights();
		return num - num2;
	}

	private float CalculateEnemyTotalLife(GameObject enemy)
	{
		return 0f + enemy.GetComponent<StatsComponent>().GetConfigStat(EStats.HealthMax) + enemy.GetComponent<StatsComponent>().GetConfigStat(EStats.ArmorMax) + enemy.GetComponent<StatsComponent>().GetConfigStat(EStats.ShieldMax);
	}

	private int GetCurrentWaveTotalEnemiesAmount()
	{
		int num = 0;
		for (int i = 0; i < WaveSpawners.Count; i++)
		{
			num += WaveSpawners[i].CalculateTotalEnemiesAmount();
		}
		return num;
	}

	private int GetCurrentWaveTotalEnemiesAmountByType(GameObject type)
	{
		int num = 0;
		for (int i = 0; i < WaveSpawners.Count; i++)
		{
			num += WaveSpawners[i].CalculateTotalEnemiesAmountByType(type);
		}
		return num;
	}

	private float CalculateTotalRoundSpawnRate()
	{
		float num = 0f;
		float totalWeights = CalculateTotalRoundWeights();
		for (int i = 0; i < autoRoundSpawnerConfigs.Count; i++)
		{
			num += CalculateRoundSpawnerSpawnRate(autoRoundSpawnerConfigs[i], totalRoundLpS, totalWeights);
		}
		return num;
	}

	private float CalculateRoundSpawnerSpawnRate(FAutoCycleSpawnerConfig roundSpawnerConfig, float totalRoundLpS, float totalWeights)
	{
		StatsComponent component = roundSpawnerConfig.enemy.GetComponent<StatsComponent>();
		float num = component.GetConfigStat(EStats.HealthMax) + component.GetConfigStat(EStats.ArmorMax) + component.GetConfigStat(EStats.ShieldMax);
		return totalRoundLpS * (roundSpawnerConfig.weight / totalWeights) / num;
	}

	private int GetTotalWaveLife()
	{
		int num = 0;
		foreach (WaveSpawnerConfig waveSpawner in WaveSpawners)
		{
			num += waveSpawner.CalculateTotalStat(EStats.HealthMax);
			num += waveSpawner.CalculateTotalStat(EStats.ArmorMax);
			num += waveSpawner.CalculateTotalStat(EStats.ShieldMax);
		}
		return num;
	}

	private float GetTotalDuration(float customMainStartDelay = -1f, float customSecondaryStartDelay = -1f)
	{
		if (WaveSpawners == null)
		{
			return 0f;
		}
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < WaveSpawners.Count; i++)
		{
			if (i > 0 && WaveSpawners[i] == WaveSpawners[i - 1])
			{
				num += num2;
				continue;
			}
			num2 = ((i != 0) ? Mathf.Max(WaveSpawners[i].CalculateMainWaveDuration(customMainStartDelay), WaveSpawners[i].CalculateSecondaryWaveDuration(customSecondaryStartDelay)) : Mathf.Max(WaveSpawners[i].CalculateMainWaveDuration(0f), WaveSpawners[i].CalculateSecondaryWaveDuration(0f)));
			num += num2;
		}
		return num;
	}

	private string GetTotalRoundEssenceText()
	{
		int roundSpawnersEssence = 0;
		int waveSpawnersEssence = 0;
		roundSpawners?.ForEach(delegate(SpawnerConfig x)
		{
			roundSpawnersEssence += x.TotalEnemyEssence;
		});
		WaveSpawners?.ForEach(delegate(WaveSpawnerConfig x)
		{
			waveSpawnersEssence += x.CalculateTotalEnemyEssence();
		});
		return "Total cycle essence: " + (roundSpawnersEssence + waveSpawnersEssence) + " (N: " + roundSpawnersEssence + " W: " + waveSpawnersEssence + ")";
	}

	private string GetTotalRoundLifeText()
	{
		float num = 0f;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		foreach (SpawnerConfig roundSpawner in RoundSpawners)
		{
			num += roundSpawner.GetEnemiesPerSecond();
			num2 += (int)roundSpawner.CalculateTotalStat(EStats.HealthMax);
			num3 += (int)roundSpawner.CalculateTotalStat(EStats.ArmorMax);
			num4 += (int)roundSpawner.CalculateTotalStat(EStats.ShieldMax);
			num5 += FunctionLibrary.RoundToDecimals(roundSpawner.ObjectToSpawn.GetComponent<StatsComponent>().GetConfigStat(EStats.HealthMax) * roundSpawner.GetEnemiesPerSecond(), 2);
			num6 += FunctionLibrary.RoundToDecimals(roundSpawner.ObjectToSpawn.GetComponent<StatsComponent>().GetConfigStat(EStats.ArmorMax) * roundSpawner.GetEnemiesPerSecond(), 2);
			num7 += FunctionLibrary.RoundToDecimals(roundSpawner.ObjectToSpawn.GetComponent<StatsComponent>().GetConfigStat(EStats.ShieldMax) * roundSpawner.GetEnemiesPerSecond(), 2);
		}
		num8 = num2 + num3 + num4;
		string text = "Round total life: " + num8 + " (" + (num5 + num6 + num7) + "/s)   (Expected: " + expectedRoundTotalLifePerSecond + "/s)";
		text = text + "\nHealth: " + num2 + " (" + num5 + "/s) (" + FunctionLibrary.RoundToDecimals((float)num2 / num8 * 100f, 2) + "%)";
		if (num3 > 0)
		{
			text = text + "\nArmor: " + num3 + " (" + num6 + "/s) (" + FunctionLibrary.RoundToDecimals((float)num3 / num8 * 100f, 2) + "%)";
		}
		if (num4 > 0)
		{
			text = text + "\nShield: " + num4 + " (" + num7 + "/s) (" + FunctionLibrary.RoundToDecimals((float)num4 / num8 * 100f, 2) + "%)";
		}
		return text + "\nSpawn rate: " + FunctionLibrary.RoundToDecimals(num, 2) + "/s";
	}

	private string GetTotalWaveLifeText()
	{
		if (WaveSpawners == null)
		{
			return "0";
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		int num9 = 0;
		float totalDuration = GetTotalDuration();
		float num10 = Mathf.Max(30f, totalDuration);
		foreach (WaveSpawnerConfig waveSpawner in WaveSpawners)
		{
			num += waveSpawner.CalculateTotalStat(EStats.HealthMax);
			num2 += waveSpawner.CalculateTotalStat(EStats.ArmorMax);
			num3 += waveSpawner.CalculateTotalStat(EStats.ShieldMax);
			num9 += waveSpawner.CalculateTotalEnemiesAmount();
		}
		num4 = num + num2 + num3;
		num5 = FunctionLibrary.RoundToDecimals((float)(num + num2 + num3) / num10, 2);
		num6 = FunctionLibrary.RoundToDecimals((float)num / num10, 2);
		num7 = FunctionLibrary.RoundToDecimals((float)num2 / num10, 2);
		num8 = FunctionLibrary.RoundToDecimals((float)num3 / num10, 2);
		string text = "Wave total life: " + (num + num2 + num3) + " (" + num5 + "/s)   (Expected: " + expectedWaveLifePerSecond + "/s)";
		text = text + "\nHealth: " + num + " (" + num6 + "/s) (" + FunctionLibrary.RoundToDecimals((float)num / num4 * 100f, 2) + "%)";
		if (num2 > 0)
		{
			text = text + "\nArmor: " + num2 + " (" + num7 + "/s) (" + FunctionLibrary.RoundToDecimals((float)num2 / num4 * 100f, 2) + "%)";
		}
		if (num3 > 0)
		{
			text = text + "\nShield: " + num3 + " (" + num8 + "/s) (" + FunctionLibrary.RoundToDecimals((float)num3 / num4 * 100f, 2) + "%)";
		}
		text = text + "\nTotal wave duration: " + totalDuration + "s";
		if (num10 > totalDuration)
		{
			text = text + " (using " + 30f + "s for calculations)";
		}
		text = text + "\nTotal enemies: " + num9;
		return text + "\nSpawn rate: " + FunctionLibrary.RoundToDecimals((float)num9 / totalDuration, 2) + "/s";
	}
}
