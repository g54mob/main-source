using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerConfig_default", menuName = "GameKit/SpawnerConfig", order = 3)]
public class SpawnerConfig : ScriptableObject
{
	[SerializeField]
	private GameObject objectToSpawn;

	[SerializeField]
	private RandomizableInt totalObjectsToSpawn;

	[SerializeField]
	[Tooltip("Infinite if <= 0")]
	private float duration;

	[SerializeField]
	private bool autoDestroy = true;

	[SerializeField]
	private bool activateOnStart;

	[Header("Visuals")]
	[SerializeField]
	private GameObject spawnVFX;

	[SerializeField]
	[Tooltip("Tiene que tener en cuenta el delay de principio de ronda configurado en MatchSettings?")]
	private bool useRoundDelay = true;

	[SerializeField]
	private RandomizableFloat startDelay;

	[SerializeField]
	private RandomizableFloat spawnTime;

	[SerializeField]
	private RandomizableInt objectsPerSpawn;

	[SerializeField]
	private float inBetweenSpawnsTime = 1f;

	[SerializeField]
	private float extraInBetweenSpawnsTime;

	[SerializeField]
	private bool autoInBetweenSpawnsTime;

	[SerializeField]
	private bool ignoreFirstSpawnTime;

	[Space]
	[SerializeField]
	private int totalEnemyEssence;

	[Space]
	[SerializeField]
	private SpawnerConfigAutoConfig autoConfigAsset;

	[SerializeField]
	private FSpawnerConfigAutoConfigData autoConfigData;

	public GameObject ObjectToSpawn => objectToSpawn;

	public float Duration => duration;

	public bool AutoDestroy => autoDestroy;

	public bool ActivateOnStart => activateOnStart;

	public GameObject SpawnVFX => spawnVFX;

	public RandomizableInt TotalObjectsToSpawn
	{
		get
		{
			return totalObjectsToSpawn;
		}
		set
		{
			totalObjectsToSpawn = value;
		}
	}

	public RandomizableFloat SpawnTime
	{
		get
		{
			return spawnTime;
		}
		set
		{
			spawnTime = value;
		}
	}

	public RandomizableInt ObjectsPerSpawn
	{
		get
		{
			return objectsPerSpawn;
		}
		set
		{
			objectsPerSpawn = value;
		}
	}

	private EValueMode ObjectsPerSpawnMode => ObjectsPerSpawn.ValueMode;

	public float InBetweenSpawnsTime => inBetweenSpawnsTime;

	public bool IgnoreFirstSpawnTime => ignoreFirstSpawnTime;

	public int TotalEnemyEssence => totalEnemyEssence;

	public float StartDelay
	{
		get
		{
			float num = 0f;
			if (useRoundDelay && MatchInfo.instance?.CurrentMatchSettings != null)
			{
				CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
				num = (((object)cyclesManager == null || cyclesManager.CurrentCycle != 0) ? (MatchInfo.instance?.CurrentMatchSettings?.DefaultRoundDelay).GetValueOrDefault() : (MatchInfo.instance?.CurrentMatchSettings?.FirstRoundDelay).GetValueOrDefault());
			}
			return startDelay.Value + num;
		}
	}

	private void AutoConfigure()
	{
		AutoConfigure(null, null, 0f, -1f, -1f, -1);
	}

	public bool AutoConfigure(FSpawnerConfigAutoConfigData customConfigData, GameObject objectToSpawn, float targetLpS, float startDelay, float extraInBetweenTime, int enemyEssence, int cycle = -1)
	{
		int num = 200;
		int num2 = 1000;
		int num3 = 7;
		RandomizableFloat randomizableFloat = new RandomizableFloat(0f, Vector2.zero, EValueMode.Random);
		RandomizableInt randomizableInt = new RandomizableInt(0, Vector2Int.zero, EValueMode.Random);
		SetAutoConfigDefaultValues();
		FSpawnerConfigAutoConfigData fSpawnerConfigAutoConfigData = ((customConfigData != null) ? customConfigData : ((!(autoConfigAsset != null)) ? autoConfigData : autoConfigAsset.AutoConfigData));
		float num4 = ((targetLpS > 0f) ? targetLpS : fSpawnerConfigAutoConfigData.TargetLpS);
		if (num4 < 0.25f)
		{
			return false;
		}
		float num5 = Mathf.Max(fSpawnerConfigAutoConfigData.AutoConfigMinSpawnTime.Value, 0.5f);
		float num6 = Mathf.Max(fSpawnerConfigAutoConfigData.AutoConfigMaxSpawnTime.Value, 1f);
		float value = fSpawnerConfigAutoConfigData.AutoConfigSpawnTimeDeviation.Value;
		if ((bool)objectToSpawn)
		{
			this.objectToSpawn = objectToSpawn;
			autoInBetweenSpawnsTime = true;
			if (extraInBetweenSpawnsTime >= 0f)
			{
				extraInBetweenSpawnsTime = extraInBetweenTime;
			}
			AutoCalculateInBetweenTime();
		}
		if (startDelay >= 0f)
		{
			this.startDelay.ValueMode = EValueMode.Constant;
			this.startDelay.ConstantValue = startDelay;
		}
		if (enemyEssence >= 0)
		{
			totalEnemyEssence = enemyEssence;
		}
		randomizableInt.RandomRangeX = 1;
		randomizableInt.RandomRangeY = 1 + Random.Range(0, fSpawnerConfigAutoConfigData.AutoConfigMaxOpSDeviation + 1);
		StatsComponent component = this.objectToSpawn.GetComponent<StatsComponent>();
		float num7 = component.GetConfigStat(EStats.HealthMax) + component.GetConfigStat(EStats.ArmorMax) + component.GetConfigStat(EStats.ShieldMax);
		int num8 = 0;
		int num9 = 0;
		bool flag = false;
		int num10 = 0;
		while (num8 <= num && num9 <= num2)
		{
			if (num8 == num || num9 == num2)
			{
				string text = ((cycle >= 0) ? (" (cycle " + cycle.ToString("D2") + ")") : "");
				Debug.LogError("No se ha podido encontrar una configuración de SpawnerConfig válida para " + objectToSpawn.name + text);
				flag = true;
				break;
			}
			num9++;
			float num11 = num7 * GetEnemiesPerSecond(new RandomizableFloat(num5 + value / 2f, Vector2.zero, EValueMode.Constant), randomizableInt);
			float num12 = num7 * GetEnemiesPerSecond(new RandomizableFloat(num6 - value / 2f, Vector2.zero, EValueMode.Constant), randomizableInt);
			if (num4 >= num12 && num4 <= num11)
			{
				float num13 = (GetAverageAmountPerSpawn(randomizableInt) - 1f) * InBetweenSpawnsTime;
				float num14 = (num5 + value / 2f + num13) * num11 / num4;
				randomizableFloat.RandomRangeX = num14 - value / 2f - num13;
				randomizableFloat.RandomRangeY = num14 + value / 2f - num13;
				break;
			}
			if (num11 < num4 && num10 != -1 && randomizableInt.RandomRangeY < num3)
			{
				randomizableInt = AutoModifyOpS(randomizableInt, fSpawnerConfigAutoConfigData.AutoConfigMaxOpSDeviation, increase: true);
				num10 = 1;
				continue;
			}
			if (num12 > num4 && num10 != 1 && randomizableInt.RandomRangeY > 1)
			{
				randomizableInt = AutoModifyOpS(randomizableInt, fSpawnerConfigAutoConfigData.AutoConfigMaxOpSDeviation, increase: false);
				num10 = -1;
				continue;
			}
			randomizableInt.RandomRangeX = 1;
			randomizableInt.RandomRangeY = 1 + Random.Range(0, fSpawnerConfigAutoConfigData.AutoConfigMaxOpSDeviation + 1);
			num5 = Mathf.Max(num5 - 1f, 1.5f);
			num6 += 1f;
			num10 = 0;
			num8++;
		}
		SpawnTime = randomizableFloat;
		ObjectsPerSpawn = randomizableInt;
		if (flag)
		{
			return false;
		}
		return true;
	}

	private void SetAutoConfigDefaultValues()
	{
		totalObjectsToSpawn.ValueMode = EValueMode.Constant;
		totalObjectsToSpawn.ConstantValue = -1;
		duration = 0f;
		autoDestroy = false;
		activateOnStart = false;
		useRoundDelay = true;
		ignoreFirstSpawnTime = true;
		extraInBetweenSpawnsTime = 0f;
	}

	private RandomizableInt AutoModifyOpS(RandomizableInt currentOpS, int maxDeviation, bool increase)
	{
		if (increase)
		{
			if (maxDeviation <= 0)
			{
				currentOpS.RandomRangeX++;
				currentOpS.RandomRangeY++;
			}
			else if (currentOpS.RandomRangeY - currentOpS.RandomRangeX >= maxDeviation)
			{
				currentOpS.RandomRangeX++;
			}
			else if (currentOpS.RandomRangeY - currentOpS.RandomRangeX == 0)
			{
				currentOpS.RandomRangeY++;
			}
			else if (Random.value > 0.5f)
			{
				currentOpS.RandomRangeX++;
			}
			else
			{
				currentOpS.RandomRangeY++;
			}
		}
		else
		{
			if (maxDeviation <= 0)
			{
				currentOpS.RandomRangeX--;
				currentOpS.RandomRangeY--;
			}
			else if (currentOpS.RandomRangeY - currentOpS.RandomRangeX >= maxDeviation)
			{
				currentOpS.RandomRangeY--;
			}
			else if (currentOpS.RandomRangeY - currentOpS.RandomRangeX == 0)
			{
				currentOpS.RandomRangeX--;
			}
			else if (currentOpS.RandomRangeX > 1 && Random.value > 0.5f)
			{
				currentOpS.RandomRangeX--;
			}
			else
			{
				currentOpS.RandomRangeY--;
			}
			currentOpS.RandomRangeX = Mathf.Max(currentOpS.RandomRangeX, 1);
			currentOpS.RandomRangeY = Mathf.Max(currentOpS.RandomRangeY, 1);
		}
		return currentOpS;
	}

	private void OnValidate()
	{
		AutoCalculateInBetweenTime();
	}

	public float GetAverageTotalObjectsToSpawn()
	{
		if (TotalObjectsToSpawn.ValueMode == EValueMode.Constant)
		{
			return TotalObjectsToSpawn.ConstantValue;
		}
		return (float)(TotalObjectsToSpawn.RandomRange.x + TotalObjectsToSpawn.RandomRange.y) / 2f;
	}

	public float GetAverageStartDelay()
	{
		float num = 0f;
		if (MatchInfo.instance?.CurrentMatchSettings != null)
		{
			CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
			num = (((object)cyclesManager == null || cyclesManager.CurrentCycle != 0) ? (MatchInfo.instance?.CurrentMatchSettings?.DefaultRoundDelay).GetValueOrDefault() : (MatchInfo.instance?.CurrentMatchSettings?.FirstRoundDelay).GetValueOrDefault());
		}
		if (startDelay.ValueMode == EValueMode.Constant)
		{
			return startDelay.ConstantValue + ((Application.isPlaying && useRoundDelay) ? num : 0f);
		}
		return (startDelay.RandomRange.x + startDelay.RandomRange.y) / 2f + ((Application.isPlaying && useRoundDelay) ? num : 0f);
	}

	public float GetAverageSpawnTime(RandomizableFloat spawnTime)
	{
		if (spawnTime.ValueMode == EValueMode.Constant)
		{
			return spawnTime.ConstantValue;
		}
		return (spawnTime.RandomRange.x + spawnTime.RandomRange.y) / 2f;
	}

	public float GetAverageAmountPerSpawn(RandomizableInt objectsPerSpawn)
	{
		if (objectsPerSpawn.ValueMode == EValueMode.Constant)
		{
			return objectsPerSpawn.ConstantValue;
		}
		return (float)(objectsPerSpawn.RandomRangeX + objectsPerSpawn.RandomRangeY) / 2f;
	}

	public float GetEnemiesPerSecond()
	{
		if (TotalObjectsToSpawn.Value < 0)
		{
			return GetEnemiesPerSecond(SpawnTime, ObjectsPerSpawn);
		}
		float b = 300f;
		if ((bool)LTFunctionLibrary.GetCyclesManager())
		{
			b = LTFunctionLibrary.GetCyclesManager().RoundTime;
		}
		float num = Mathf.Max(0f, b);
		return GetAverageTotalObjectsToSpawn() / num;
	}

	public float GetEnemiesPerSecond(RandomizableFloat customSpawnTime, RandomizableInt customObjectsPerSpawn)
	{
		return GetAverageAmountPerSpawn(customObjectsPerSpawn) / (GetAverageSpawnTime(customSpawnTime) + (GetAverageAmountPerSpawn(customObjectsPerSpawn) - 1f) * InBetweenSpawnsTime);
	}

	private string CalculateTotalLifeText()
	{
		int num = (int)CalculateTotalStat(EStats.HealthMax);
		int num2 = (int)CalculateTotalStat(EStats.ArmorMax);
		int num3 = (int)CalculateTotalStat(EStats.ShieldMax);
		float configStat = objectToSpawn.GetComponent<StatsComponent>().GetConfigStat(EStats.HealthMax);
		float configStat2 = objectToSpawn.GetComponent<StatsComponent>().GetConfigStat(EStats.ArmorMax);
		float configStat3 = objectToSpawn.GetComponent<StatsComponent>().GetConfigStat(EStats.ShieldMax);
		string text = "Total life: " + (num + num2 + num3);
		text = text + " (" + FunctionLibrary.RoundToDecimals((configStat + configStat2 + configStat3) * GetEnemiesPerSecond(), 2) + "/s)";
		text = text + "\nHealth: " + num;
		text = text + " (" + FunctionLibrary.RoundToDecimals(configStat * GetEnemiesPerSecond(), 2) + "/s)";
		if (num2 > 0)
		{
			text = text + "\nArmor: " + num2;
			text = text + " (" + FunctionLibrary.RoundToDecimals(configStat2 * GetEnemiesPerSecond(), 2) + "/s)";
		}
		if (num3 > 0)
		{
			text = text + "\nShield: " + num3;
			text = text + " (" + FunctionLibrary.RoundToDecimals(configStat3 * GetEnemiesPerSecond(), 2) + "/s)";
		}
		return text + "\nSpawn rate: " + FunctionLibrary.RoundToDecimals(GetEnemiesPerSecond(), 2) + "/s";
	}

	public float CalculateTotalStat(EStats stat)
	{
		if (GetAverageTotalObjectsToSpawn() > 0f)
		{
			return objectToSpawn.GetComponent<StatsComponent>().GetConfigStat(stat) * GetAverageTotalObjectsToSpawn();
		}
		float num = 300f;
		if ((bool)LTFunctionLibrary.GetCyclesManager())
		{
			num = LTFunctionLibrary.GetCyclesManager().RoundTime;
		}
		float num2 = Mathf.Max(0f, num - GetAverageStartDelay()) * GetEnemiesPerSecond();
		return objectToSpawn.GetComponent<StatsComponent>().GetConfigStat(stat) * num2;
	}

	public float CalculateEnemyEssencePerEnemy()
	{
		if (GetAverageTotalObjectsToSpawn() > 0f)
		{
			return (float)TotalEnemyEssence / GetAverageTotalObjectsToSpawn();
		}
		float num = 300f;
		if ((bool)LTFunctionLibrary.GetCyclesManager())
		{
			num = LTFunctionLibrary.GetCyclesManager().RoundTime;
		}
		float num2 = Mathf.Max(0f, num - GetAverageStartDelay()) * GetEnemiesPerSecond();
		return (float)TotalEnemyEssence / num2;
	}

	private string CalculateEnemyEssencePerEnemyText()
	{
		return "Essence per enemy: " + FunctionLibrary.RoundToDecimals(CalculateEnemyEssencePerEnemy(), 3);
	}

	private void AutoCalculateInBetweenTime()
	{
		if (autoInBetweenSpawnsTime)
		{
			float num = FunctionLibrary.GetObjectRadius(objectToSpawn) * 2f;
			float configStat = objectToSpawn.GetComponent<StatsComponent>().GetConfigStat(EStats.MovementSpeed);
			inBetweenSpawnsTime = num / configStat + extraInBetweenSpawnsTime + 0.05f;
		}
		else
		{
			extraInBetweenSpawnsTime = 0f;
		}
	}

	public float GetLifePerSecond()
	{
		StatsComponent component = objectToSpawn.GetComponent<StatsComponent>();
		return (component.GetConfigStat(EStats.HealthMax) + component.GetConfigStat(EStats.ArmorMax) + component.GetConfigStat(EStats.ShieldMax)) * GetEnemiesPerSecond();
	}
}
