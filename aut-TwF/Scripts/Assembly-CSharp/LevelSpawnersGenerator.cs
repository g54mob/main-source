using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnersGenerator : MonoBehaviour, ISavable
{
	public enum EEnemyTier
	{
		T1 = 0,
		T2 = 1,
		T3 = 2,
		T4 = 3,
		T5 = 4,
		Boss = 100
	}

	[Serializable]
	public struct FEnemyInfo
	{
		public GameObject enemy;

		public EEnemyTier tier;

		public LevelData levelToUnlock;
	}

	[Serializable]
	public struct FBossGroup
	{
		public List<GameObject> enemies;

		public LevelData unlockedBy;
	}

	[Serializable]
	public struct UnlockableCycleGroup
	{
		public LSGCycleGroup cycleGroup;

		public LevelData unlockedBy;

		public LevelData lockedBy;

		public bool IsUnlocked()
		{
			if (unlockedBy == null || LTFunctionLibrary.GetLevelsProgressionManager().IsLevelComplete(unlockedBy.Id))
			{
				if (!(lockedBy == null))
				{
					return !LTFunctionLibrary.GetLevelsProgressionManager().IsLevelComplete(lockedBy.Id);
				}
				return true;
			}
			return false;
		}
	}

	[Serializable]
	public class UnlockableCycleGroupList
	{
		public List<UnlockableCycleGroup> unlockableCycleGroups;

		public LSGCycleGroup GetRandomCycleGroup()
		{
			List<LSGCycleGroup> list = new List<LSGCycleGroup>();
			for (int i = 0; i < unlockableCycleGroups.Count; i++)
			{
				if (unlockableCycleGroups[i].IsUnlocked())
				{
					list.Add(unlockableCycleGroups[i].cycleGroup);
				}
			}
			if (list.Count > 0)
			{
				return list[UnityEngine.Random.Range(0, list.Count)];
			}
			return null;
		}
	}

	[Header("Main")]
	[SerializeField]
	private LevelSpawners levelSpawnersAsset;

	[SerializeField]
	private int customSeed = -1;

	[Savable("seed", true, false)]
	private int seed = -1;

	[SerializeField]
	private int cyclesToGenerate = 10;

	[SerializeField]
	private float maxWaveLpSVariationPercentage;

	[Header("Available enemies")]
	[SerializeField]
	private List<FEnemyInfo> availableEnemies;

	[SerializeField]
	private List<FBossGroup> availableBossGroups;

	[Header("Cycle groups")]
	[SerializeField]
	private List<UnlockableCycleGroupList> availableCycleGroups;

	private void SetupSeed()
	{
		if (customSeed < 0)
		{
			seed = DateTime.Now.Millisecond;
		}
		else
		{
			seed = customSeed;
		}
		UnityEngine.Random.InitState(seed);
	}

	public LevelSpawners GenerateLevelSpawners()
	{
		SetupSeed();
		LevelSpawners levelSpawners = ScriptableObject.CreateInstance<LevelSpawners>();
		levelSpawnersAsset.DifficultyCurveSettings = new List<LevelSpawners.FDifficultyCurveSettings>();
		levelSpawnersAsset.AutoCycleConfigs.Clear();
		levelSpawnersAsset.CycleSpawners.Clear();
		bool flag = false;
		int num = 0;
		int num2 = ((!Application.isPlaying) ? 1 : 10);
		List<LSGCycleGroup> randomCycleGroups = GetRandomCycleGroups();
		if (randomCycleGroups == null || randomCycleGroups.Count == 0)
		{
			Debug.LogError("No se encontraron Cycle Groups para ser usados");
			return null;
		}
		List<FEnemyInfo> unlockedEnemies = GetUnlockedEnemies();
		List<FBossGroup> unlockedBosses = GetUnlockedBosses();
		unlockedBosses.Shuffle();
		while (!flag && num < num2)
		{
			num++;
			int num3 = 0;
			int num4 = 0;
			bool flag2 = false;
			levelSpawners.AutoCycleConfigs = new List<LevelSpawners.FAutoCycleConfig>();
			levelSpawners.DifficultyCurveSettings = new List<LevelSpawners.FDifficultyCurveSettings>();
			while (levelSpawners.AutoCycleConfigs.Count < cyclesToGenerate)
			{
				LSGCycleGroup lSGCycleGroup = randomCycleGroups[num3];
				if (lSGCycleGroup.UsePreviousDifficultySettings)
				{
					List<LevelSpawners.FDifficultyCurveSettings> difficultyCurveSettings = levelSpawners.DifficultyCurveSettings;
					List<LevelSpawners.FDifficultyCurveSettings> difficultyCurveSettings2 = levelSpawners.DifficultyCurveSettings;
					difficultyCurveSettings.Add(difficultyCurveSettings2[difficultyCurveSettings2.Count - 1]);
				}
				else
				{
					levelSpawners.DifficultyCurveSettings.Add(GenerateDifficultyCurveSettings(lSGCycleGroup, levelSpawners.AutoCycleConfigs.Count));
				}
				unlockedEnemies.Shuffle();
				levelSpawners.AutoCycleConfigs.AddRange(GenerateAutoCycleConfigs(lSGCycleGroup, unlockedEnemies, unlockedBosses[num4 % unlockedBosses.Count]));
				num4++;
				if (Application.isPlaying && MatchInfo.instance.CurrentMatchMode == EMatchMode.Endless)
				{
					LTGameManager_Endless lTGameManager_Endless = LTFunctionLibrary.GetLTGameManager() as LTGameManager_Endless;
					if (!flag2 && num3 >= randomCycleGroups.Count - 1)
					{
						lTGameManager_Endless.FirstRepetitionCycle = levelSpawners.AutoCycleConfigs.Count;
						lTGameManager_Endless.BaseEnemyLifeMultiplier = lSGCycleGroup.CalculateEnemyLifeMultiplier();
						flag2 = true;
					}
					float expectedWaveTotalLifePerSecond = levelSpawners.GetExpectedWaveTotalLifePerSecond(levelSpawners.AutoCycleConfigs.Count - 1);
					lTGameManager_Endless.BossLivesPerCycle.Add((levelSpawners.AutoCycleConfigs.Count - 1, expectedWaveTotalLifePerSecond * lSGCycleGroup.BossLifeMultiplier));
				}
				if (num3 < randomCycleGroups.Count - 1)
				{
					num3++;
				}
			}
			flag = levelSpawners.AutoConfigureLevel(createAssets: false, maxWaveLpSVariationPercentage);
		}
		levelSpawnersAsset.AutoCycleConfigs = levelSpawners.AutoCycleConfigs;
		levelSpawnersAsset.DifficultyCurveSettings = levelSpawners.DifficultyCurveSettings;
		levelSpawnersAsset.CycleSpawners.AddRange(levelSpawners.CycleSpawners);
		UnityEngine.Object.DestroyImmediate(levelSpawners);
		return levelSpawnersAsset;
	}

	private List<LSGCycleGroup> GetRandomCycleGroups()
	{
		List<LSGCycleGroup> list = new List<LSGCycleGroup>();
		for (int i = 0; i < availableCycleGroups.Count; i++)
		{
			LSGCycleGroup randomCycleGroup = availableCycleGroups[i].GetRandomCycleGroup();
			if (!(randomCycleGroup != null))
			{
				break;
			}
			list.Add(randomCycleGroup);
		}
		return list;
	}

	private LevelSpawners.FDifficultyCurveSettings GenerateDifficultyCurveSettings(LSGCycleGroup cycleGroup, int startCycle)
	{
		return new LevelSpawners.FDifficultyCurveSettings
		{
			StartCycle = startCycle,
			DifficultyCurveType = cycleGroup.DifficultyCurveType,
			RoundBias = cycleGroup.RoundBias,
			BaseWaveValue = cycleGroup.BaseWaveValue,
			ProgressionSpeedWaveValue = cycleGroup.ProgressionSpeedWaveValue
		};
	}

	private List<LevelSpawners.FAutoCycleConfig> GenerateAutoCycleConfigs(LSGCycleGroup cycleGroupToUse, List<FEnemyInfo> unlockedEnemies, FBossGroup bossGroup)
	{
		return cycleGroupToUse.GenerateAutoCycleConfigs(unlockedEnemies, bossGroup);
	}

	private List<FEnemyInfo> GetUnlockedEnemies()
	{
		List<FEnemyInfo> list = new List<FEnemyInfo>();
		foreach (FEnemyInfo availableEnemy in availableEnemies)
		{
			if (LTFunctionLibrary.GetLevelsProgressionManager().IsLevelComplete(availableEnemy.levelToUnlock.Id))
			{
				list.Add(availableEnemy);
			}
		}
		return list;
	}

	private List<FBossGroup> GetUnlockedBosses()
	{
		List<FBossGroup> list = new List<FBossGroup>();
		foreach (FBossGroup availableBossGroup in availableBossGroups)
		{
			if (LTFunctionLibrary.GetLevelsProgressionManager().IsLevelComplete(availableBossGroup.unlockedBy.Id))
			{
				list.Add(availableBossGroup);
			}
		}
		return list;
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (seed >= 0)
		{
			customSeed = seed;
		}
	}
}
