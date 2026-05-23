using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New ET Settings", menuName = "SimpleSiege/Super Wave Gen")]
public class SuperWaveGen : EternalWaveGenerator
{
	public enum EStartingGold
	{
		LowEcoStart = 0,
		MediumEcoStart = 1,
		HighEcoStart = 2,
		SuperHighEcoStart = 3,
		GigaHighEcoStart = 4
	}

	public enum EEnemyGoldDropRate
	{
		NoDropsExeptMinimum = 0,
		LowDroprate = 1,
		MediumDroprate = 2,
		HighDroprate = 3
	}

	public enum EMinimumGoldGainPerNight
	{
		MinGoldSmall = 0,
		MinGoldNormal = 1,
		MinGoldBigger = 2,
		MinGoldBiggest = 3,
		MinGoldMassive = 4
	}

	public enum EMaximumGoldGainPerNight
	{
		MaxGoldIsMinGold = 0,
		MaxGoldIsMinGoldx2 = 1,
		MaxGoldIsMinGoldx3 = 2,
		MaxGoldIsMinGoldx4 = 3,
		MaxGoldUnlimited = 4
	}

	public enum EEnemyPreselection
	{
		All_10 = 0,
		RemoveRandoms_10 = 1,
		NoFlying = 2,
		FlyingOnly = 3,
		MonstersOnly = 4,
		NoMonsters = 5,
		MeleeOnly = 6,
		RangedOnly = 7,
		NoSiege = 8,
		FastOnly = 9,
		NoFast = 10,
		VulnerableToSplashOnly = 11,
		NoVulnerableToSplash = 12
	}

	public enum EEnemyTypesMode
	{
		FixedMonobattle_1 = 0,
		VarietyMonobattle_4 = 1,
		FixedDuobattle_8 = 2,
		FixedTriobattle_10 = 3,
		VarietyDuobattle_12 = 4,
		VarietyTriobattle_10 = 5,
		VarietyGrowbattle_16 = 6,
		FixedGrowbattle_16 = 7
	}

	public enum ESpawnSelectMode
	{
		OneFixedRandom_1 = 0,
		TwoFixedRandom_2 = 1,
		ThreeFixedRandom_2 = 2,
		OneVarietyRandom_2 = 3,
		TwoVarietyRandom_3 = 4,
		ThreeVarietyRandom_3 = 5,
		OmegaRandomPerEnemy_3 = 6,
		FixedGrowspawns_2 = 7,
		VarietyGrowspawns_3 = 8,
		AllSpawns_1 = 9
	}

	public enum ESpawnInDuration
	{
		Immediate = 0,
		ShortFlow = 1,
		MediumFlow = 2,
		LongFlow = 3,
		RandomFlow = 4,
		GrowingFlow = 5
	}

	public enum EElitMode
	{
		OnlyToPreventOverpopulation_7 = 0,
		OneRandomEliteSpawn = 1,
		PartialConversionSmall = 2,
		PartialConversionMedium = 3,
		PartialConversionBig = 4,
		PartialConversionRandom = 5
	}

	public enum ESpawnInType
	{
		Normal = 0,
		TwoWaves = 1,
		ThreeWaves = 2,
		DynamicSmallGroups = 3,
		DynamicBigGroups = 4,
		RandomGroupsAndStreams = 5,
		OneSpawnAtATime = 6,
		OneSpawnAtATimeInWaves = 7
	}

	public enum EDistributeDifficulty
	{
		EvenDifficulty_3 = 0,
		EvenUnitCount = 1,
		EvenDifficultyAndUnitCountMixture_2 = 2,
		SlightlyRandom = 3,
		VeryRandom = 4
	}

	public enum EFinalWaveBonus
	{
		None = 0,
		AllSpawnsActive = 1,
		VeryLongWave = 2,
		VeryLongWaveWithAllSpawns = 3,
		AllSpawnsActivePlusNewEnemyType = 4,
		VeryLongWavePlusNewEnemyType = 5,
		VeryLongWaveWithAllSpawnsPlusNewEnemyType = 6
	}

	[SerializeField]
	private EternalTrialEnemySet enemySet;

	[SerializeField]
	private int maxAmountOfUnitsPerWave = 200;

	private List<EternalTrialEnemy> shuffledEnemies;

	private List<EnemySpawnLine> shuffledSpawns;

	[SerializeField]
	private bool randomizeEconomySettings;

	[SerializeField]
	private EStartingGold settingEStartingGold;

	[SerializeField]
	private EEnemyGoldDropRate settingEEnemyGoldDropRate;

	[SerializeField]
	private EMinimumGoldGainPerNight settingEMinimumGoldGainPerNight;

	[SerializeField]
	private EMaximumGoldGainPerNight settingEMaximumGoldGainPerNight;

	[SerializeField]
	private bool randomizeEnemiesAndSpanws;

	[SerializeField]
	private EEnemyPreselection settingEnemyPreselection;

	[SerializeField]
	private EEnemyTypesMode settingEnemiesToSpawn;

	[SerializeField]
	private ESpawnSelectMode settingSpawnToPick;

	[SerializeField]
	private ESpawnInDuration settingSpawnInDuration;

	[SerializeField]
	private EElitMode settingEliteMode;

	[SerializeField]
	private ESpawnInType settingESpawnInType;

	[SerializeField]
	private EDistributeDifficulty settingEDistributeDifficulty;

	[SerializeField]
	private EFinalWaveBonus settingEFinalWaveBonus;

	[SerializeField]
	private List<TagManager.ETag> counterableTags = new List<TagManager.ETag>();

	public float[] tagsCountered;

	public float[] targetDifficultyInNight;

	public List<string>[] difficultyContributionsInNight;

	public List<int> _OUTgoldSpentOnEconomyBeforeNigh = new List<int>();

	public List<int> _OUTgoldSpentOnDefenseBeforeNight = new List<int>();

	public List<int> _OUTNetworthBeforeNight = new List<int>();

	public List<int> _OUTgoldEarnedInNight = new List<int>();

	public List<int> _OUTgoldDroppedInNight = new List<int>();

	public List<string> _OUTBuildorder = new List<string>();

	public List<int> _OUTDefensePower = new List<int>();

	private List<EternalTrialEnemy> removedEnemies;

	private void RandomizeAllMetaParameters(int _stage)
	{
		settingEStartingGold = GetRandomEnumValue<EStartingGold>();
		if (_stage >= 4 && settingEStartingGold == EStartingGold.LowEcoStart)
		{
			settingEStartingGold = EStartingGold.MediumEcoStart;
		}
		settingEEnemyGoldDropRate = GetRandomEnumValue<EEnemyGoldDropRate>();
		settingEMinimumGoldGainPerNight = GetRandomEnumValue<EMinimumGoldGainPerNight>();
		settingEMaximumGoldGainPerNight = GetRandomEnumValue<EMaximumGoldGainPerNight>();
		settingEnemyPreselection = GetRandomEnumValueWithDistribution<EEnemyPreselection>();
		settingEnemiesToSpawn = GetRandomEnumValueWithDistribution<EEnemyTypesMode>();
		settingSpawnToPick = GetRandomEnumValueWithDistribution<ESpawnSelectMode>();
		settingSpawnInDuration = GetRandomEnumValue<ESpawnInDuration>();
		settingESpawnInType = GetRandomEnumValue<ESpawnInType>();
		settingEliteMode = GetRandomEnumValueWithDistribution<EElitMode>();
		settingEFinalWaveBonus = GetRandomEnumValue<EFinalWaveBonus>();
		settingEDistributeDifficulty = GetRandomEnumValueWithDistribution<EDistributeDifficulty>();
		if (_stage <= 1)
		{
			settingEFinalWaveBonus = EFinalWaveBonus.None;
			if (settingSpawnInDuration == ESpawnInDuration.LongFlow)
			{
				settingSpawnInDuration = ESpawnInDuration.ShortFlow;
			}
			if (settingSpawnInDuration == ESpawnInDuration.RandomFlow)
			{
				settingSpawnInDuration = ESpawnInDuration.MediumFlow;
			}
		}
		if (_stage <= 2)
		{
			settingEliteMode = EElitMode.OnlyToPreventOverpopulation_7;
		}
		if (_stage >= 6)
		{
			if (settingEDistributeDifficulty == EDistributeDifficulty.VeryRandom)
			{
				settingEDistributeDifficulty = EDistributeDifficulty.SlightlyRandom;
			}
			if (settingSpawnToPick == ESpawnSelectMode.OneFixedRandom_1)
			{
				settingSpawnToPick = ESpawnSelectMode.OneVarietyRandom_2;
			}
			if (settingEnemiesToSpawn == EEnemyTypesMode.FixedMonobattle_1)
			{
				settingEnemiesToSpawn = EEnemyTypesMode.FixedDuobattle_8;
			}
			if (settingEnemiesToSpawn == EEnemyTypesMode.VarietyMonobattle_4)
			{
				settingEnemiesToSpawn = EEnemyTypesMode.VarietyDuobattle_12;
			}
		}
	}

	public override string ReturnDebugInfoAboutWave(int _wave)
	{
		if (_wave < 0 || _wave >= difficultyContributionsInNight.Length)
		{
			return "";
		}
		string text = "";
		foreach (string item in difficultyContributionsInNight[_wave])
		{
			text = text + item + "\n";
		}
		return text;
	}

	public override List<Wave> GenerateWaves(EnemySpawnLine[] _spawns, LevelInfo _levelInfo, int stage, out int startingGold, int seed, int waveCountOverride = -1)
	{
		System.Random random = new System.Random(seed);
		UnityEngine.Random.InitState(seed);
		RandomizeAllMetaParameters(stage);
		tagsCountered = new float[counterableTags.Count];
		foreach (EternalTrialEnemy enemy in enemySet.enemies)
		{
			enemy.DifficultyValueTemp = enemy.difficultyValue;
		}
		int num = 0;
		switch (stage)
		{
		case 0:
			num = 3;
			if (UnityEngine.Random.value <= 0.5f)
			{
				num++;
			}
			break;
		case 1:
			num = 5;
			if (UnityEngine.Random.value <= 0.5f)
			{
				num++;
			}
			break;
		case 2:
			num = 7;
			if (UnityEngine.Random.value <= 0.5f)
			{
				num++;
			}
			break;
		default:
			num = 6 + stage;
			break;
		}
		if (waveCountOverride > 0)
		{
			num = waveCountOverride;
		}
		startingGold = 0;
		switch (settingEStartingGold)
		{
		case EStartingGold.LowEcoStart:
			startingGold = 8;
			break;
		case EStartingGold.MediumEcoStart:
			startingGold = 13;
			break;
		case EStartingGold.HighEcoStart:
			startingGold = 18;
			break;
		case EStartingGold.SuperHighEcoStart:
			startingGold = 23;
			break;
		case EStartingGold.GigaHighEcoStart:
			startingGold = 28;
			break;
		}
		startingGold += UnityEngine.Random.Range(-2, 3);
		float goldDropRate = 0f;
		switch (settingEEnemyGoldDropRate)
		{
		case EEnemyGoldDropRate.NoDropsExeptMinimum:
			goldDropRate = 0f;
			break;
		case EEnemyGoldDropRate.LowDroprate:
			goldDropRate = 9f / 160f;
			break;
		case EEnemyGoldDropRate.MediumDroprate:
			goldDropRate = 0.1125f;
			break;
		case EEnemyGoldDropRate.HighDroprate:
			goldDropRate = 0.225f;
			break;
		}
		int num2 = 0;
		switch (settingEMinimumGoldGainPerNight)
		{
		case EMinimumGoldGainPerNight.MinGoldSmall:
			num2 = 2;
			break;
		case EMinimumGoldGainPerNight.MinGoldNormal:
			num2 = 4;
			break;
		case EMinimumGoldGainPerNight.MinGoldBigger:
			num2 = 6;
			break;
		case EMinimumGoldGainPerNight.MinGoldBiggest:
			num2 = 8;
			break;
		case EMinimumGoldGainPerNight.MinGoldMassive:
			num2 = 11;
			break;
		}
		if (UnityEngine.Random.value <= 0.5f)
		{
			num2++;
		}
		int maxGoldDrops = 10000000;
		switch (settingEMaximumGoldGainPerNight)
		{
		case EMaximumGoldGainPerNight.MaxGoldIsMinGold:
			maxGoldDrops = num2;
			break;
		case EMaximumGoldGainPerNight.MaxGoldIsMinGoldx2:
			maxGoldDrops = num2 * 2;
			break;
		case EMaximumGoldGainPerNight.MaxGoldIsMinGoldx3:
			maxGoldDrops = num2 * 3;
			break;
		case EMaximumGoldGainPerNight.MaxGoldIsMinGoldx4:
			maxGoldDrops = num2 * 4;
			break;
		case EMaximumGoldGainPerNight.MaxGoldUnlimited:
			maxGoldDrops = 10000000;
			break;
		}
		EconomySimulator.SimulateEconomy(out _OUTgoldSpentOnEconomyBeforeNigh, out _OUTgoldSpentOnDefenseBeforeNight, out _OUTNetworthBeforeNight, out _OUTgoldEarnedInNight, out _OUTgoldDroppedInNight, out _OUTBuildorder, out _OUTDefensePower, _levelInfo.virtualBuildings, startingGold, goldDropRate, num2, maxGoldDrops, num);
		num = _OUTgoldEarnedInNight.Count;
		targetDifficultyInNight = new float[num];
		difficultyContributionsInNight = new List<string>[num];
		for (int i = 0; i < difficultyContributionsInNight.Length; i++)
		{
			difficultyContributionsInNight[i] = new List<string>();
		}
		shuffledEnemies = new List<EternalTrialEnemy>(enemySet.enemies);
		RemoveInvalidEnemiesFromShuffeledEnemeisAndShuffle(out removedEnemies, random);
		shuffledSpawns = new List<EnemySpawnLine>(_spawns);
		shuffledSpawns.ETShuffle(random);
		List<Wave> list = new List<Wave>();
		for (int j = 0; j < num; j++)
		{
			list.Add(GenerateWave(j, list, stage, out var _success, j == num - 1, random));
			if (!_success && j > 1)
			{
				return GenerateWaves(_spawns, _levelInfo, stage, out startingGold, seed, j - 1);
			}
		}
		return list;
	}

	private Wave GenerateWave(int _waveNr, List<Wave> _outPutWavesLookup, int _stage, out bool _success, bool _finalWave, System.Random randomGenerator)
	{
		Wave wave = new Wave();
		int num = _OUTgoldDroppedInNight[_waveNr];
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (_finalWave)
		{
			switch (settingEFinalWaveBonus)
			{
			case EFinalWaveBonus.AllSpawnsActive:
				flag = true;
				break;
			case EFinalWaveBonus.AllSpawnsActivePlusNewEnemyType:
				flag = true;
				flag3 = true;
				break;
			case EFinalWaveBonus.VeryLongWave:
				flag2 = true;
				break;
			case EFinalWaveBonus.VeryLongWavePlusNewEnemyType:
				flag2 = true;
				flag3 = true;
				break;
			case EFinalWaveBonus.VeryLongWaveWithAllSpawns:
				flag2 = true;
				flag = true;
				break;
			case EFinalWaveBonus.VeryLongWaveWithAllSpawnsPlusNewEnemyType:
				flag2 = true;
				flag = true;
				flag3 = true;
				break;
			}
		}
		List<EternalTrialEnemy> list = new List<EternalTrialEnemy>();
		int _foundIndex;
		switch (settingEnemiesToSpawn)
		{
		case EEnemyTypesMode.FixedMonobattle_1:
			list.Add(FirstPossibleEnemyForWave(_waveNr, 0, out _foundIndex));
			break;
		case EEnemyTypesMode.FixedDuobattle_8:
			list.Add(FirstPossibleEnemyForWave(_waveNr, 0, out _foundIndex));
			list.Add(FirstPossibleEnemyForWave(_waveNr, _foundIndex + 1, out _foundIndex));
			break;
		case EEnemyTypesMode.FixedTriobattle_10:
			list.Add(FirstPossibleEnemyForWave(_waveNr, 0, out _foundIndex));
			list.Add(FirstPossibleEnemyForWave(_waveNr, _foundIndex + 1, out _foundIndex));
			list.Add(FirstPossibleEnemyForWave(_waveNr, _foundIndex + 1, out _foundIndex));
			break;
		case EEnemyTypesMode.VarietyMonobattle_4:
			shuffledEnemies.ETShuffle(randomGenerator);
			list.Add(FirstPossibleEnemyForWave(_waveNr, 0, out _foundIndex));
			break;
		case EEnemyTypesMode.VarietyDuobattle_12:
			shuffledEnemies.ETShuffle(randomGenerator);
			list.Add(FirstPossibleEnemyForWave(_waveNr, 0, out _foundIndex));
			list.Add(FirstPossibleEnemyForWave(_waveNr, _foundIndex + 1, out _foundIndex));
			break;
		case EEnemyTypesMode.VarietyTriobattle_10:
			shuffledEnemies.ETShuffle(randomGenerator);
			list.Add(FirstPossibleEnemyForWave(_waveNr, 0, out _foundIndex));
			list.Add(FirstPossibleEnemyForWave(_waveNr, _foundIndex + 1, out _foundIndex));
			list.Add(FirstPossibleEnemyForWave(_waveNr, _foundIndex + 1, out _foundIndex));
			break;
		case EEnemyTypesMode.FixedGrowbattle_16:
		{
			int num2 = Mathf.Clamp(_waveNr, 1, 7);
			list.Add(FirstPossibleEnemyForWave(_waveNr, 0, out _foundIndex));
			for (int j = 0; j < num2; j++)
			{
				list.Add(FirstPossibleEnemyForWave(_waveNr, _foundIndex + 1, out _foundIndex));
			}
			break;
		}
		case EEnemyTypesMode.VarietyGrowbattle_16:
		{
			shuffledEnemies.ETShuffle(randomGenerator);
			int num2 = Mathf.Clamp(_waveNr, 1, 7);
			list.Add(FirstPossibleEnemyForWave(_waveNr, 0, out _foundIndex));
			for (int i = 0; i < num2; i++)
			{
				list.Add(FirstPossibleEnemyForWave(_waveNr, _foundIndex + 1, out _foundIndex));
			}
			break;
		}
		}
		if (flag3)
		{
			shuffledEnemies.AddRange(removedEnemies);
			shuffledEnemies.ETShuffle(randomGenerator);
			foreach (EternalTrialEnemy shuffledEnemy in shuffledEnemies)
			{
				if (!list.Contains(shuffledEnemy))
				{
					list.Add(shuffledEnemy);
					break;
				}
			}
		}
		list = list.Distinct().ToList();
		if (list.Count <= 0)
		{
			list.Add(enemySet.enemies[0]);
		}
		bool flag4 = true;
		foreach (EternalTrialEnemy item2 in list)
		{
			if (!item2.enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.Flying))
			{
				flag4 = false;
				break;
			}
		}
		if (flag4)
		{
			Debug.Log("Adding a ground enemy YO!");
			foreach (EternalTrialEnemy shuffledEnemy2 in shuffledEnemies)
			{
				if (!shuffledEnemy2.enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.Flying))
				{
					Debug.Log("Adding a ground enemy YO!");
					list.Add(shuffledEnemy2);
					break;
				}
			}
		}
		foreach (EternalTrialEnemy item3 in list)
		{
			item3.TempSpawnLineList.Clear();
			item3.TempSpawnLineTargetDifficulty.Clear();
			item3.TempSpawnAmount.Clear();
			item3.TempDropGold.Clear();
		}
		switch (settingSpawnToPick)
		{
		case ESpawnSelectMode.OneFixedRandom_1:
			foreach (EternalTrialEnemy item4 in list)
			{
				item4.TempSpawnLineList.Add(FirstPossibleSpawnFor(item4, 0, out _foundIndex));
			}
			break;
		case ESpawnSelectMode.TwoFixedRandom_2:
			foreach (EternalTrialEnemy item5 in list)
			{
				item5.TempSpawnLineList.Add(FirstPossibleSpawnFor(item5, 0, out _foundIndex));
				item5.TempSpawnLineList.Add(FirstPossibleSpawnFor(item5, _foundIndex + 1, out _foundIndex));
			}
			break;
		case ESpawnSelectMode.ThreeFixedRandom_2:
			foreach (EternalTrialEnemy item6 in list)
			{
				item6.TempSpawnLineList.Add(FirstPossibleSpawnFor(item6, 0, out _foundIndex));
				item6.TempSpawnLineList.Add(FirstPossibleSpawnFor(item6, _foundIndex + 1, out _foundIndex));
				item6.TempSpawnLineList.Add(FirstPossibleSpawnFor(item6, _foundIndex + 1, out _foundIndex));
			}
			break;
		case ESpawnSelectMode.OneVarietyRandom_2:
			shuffledSpawns.ETShuffle(randomGenerator);
			foreach (EternalTrialEnemy item7 in list)
			{
				item7.TempSpawnLineList.Add(FirstPossibleSpawnFor(item7, 0, out _foundIndex));
			}
			break;
		case ESpawnSelectMode.TwoVarietyRandom_3:
			shuffledSpawns.ETShuffle(randomGenerator);
			foreach (EternalTrialEnemy item8 in list)
			{
				item8.TempSpawnLineList.Add(FirstPossibleSpawnFor(item8, 0, out _foundIndex));
				item8.TempSpawnLineList.Add(FirstPossibleSpawnFor(item8, _foundIndex + 1, out _foundIndex));
			}
			break;
		case ESpawnSelectMode.ThreeVarietyRandom_3:
			shuffledSpawns.ETShuffle(randomGenerator);
			foreach (EternalTrialEnemy item9 in list)
			{
				item9.TempSpawnLineList.Add(FirstPossibleSpawnFor(item9, 0, out _foundIndex));
				item9.TempSpawnLineList.Add(FirstPossibleSpawnFor(item9, _foundIndex + 1, out _foundIndex));
				item9.TempSpawnLineList.Add(FirstPossibleSpawnFor(item9, _foundIndex + 1, out _foundIndex));
			}
			break;
		case ESpawnSelectMode.OmegaRandomPerEnemy_3:
			shuffledSpawns.ETShuffle(randomGenerator);
			foreach (EternalTrialEnemy item10 in list)
			{
				foreach (EnemySpawnLine shuffledSpawn in shuffledSpawns)
				{
					if (IsPossibleSpawnLineFor(item10, shuffledSpawn))
					{
						item10.TempSpawnLineList.Add(shuffledSpawn);
					}
				}
				List<EnemySpawnLine> list2 = item10.TempSpawnLineList;
				RemoveRandomInstances(ref list2, randomGenerator);
			}
			break;
		case ESpawnSelectMode.VarietyGrowspawns_3:
		{
			int num3 = Mathf.Max(1, _waveNr);
			shuffledSpawns.ETShuffle(randomGenerator);
			foreach (EternalTrialEnemy item11 in list)
			{
				foreach (EnemySpawnLine shuffledSpawn2 in shuffledSpawns)
				{
					if (IsPossibleSpawnLineFor(item11, shuffledSpawn2))
					{
						item11.TempSpawnLineList.Add(shuffledSpawn2);
					}
				}
				List<EnemySpawnLine> tempSpawnLineList2 = item11.TempSpawnLineList;
				while (tempSpawnLineList2.Count > num3)
				{
					tempSpawnLineList2.RemoveAt(tempSpawnLineList2.Count - 1);
				}
			}
			break;
		}
		case ESpawnSelectMode.FixedGrowspawns_2:
		{
			int num3 = Mathf.Max(1, _waveNr);
			foreach (EternalTrialEnemy item12 in list)
			{
				foreach (EnemySpawnLine shuffledSpawn3 in shuffledSpawns)
				{
					if (IsPossibleSpawnLineFor(item12, shuffledSpawn3))
					{
						item12.TempSpawnLineList.Add(shuffledSpawn3);
					}
				}
				List<EnemySpawnLine> tempSpawnLineList = item12.TempSpawnLineList;
				while (tempSpawnLineList.Count > num3)
				{
					tempSpawnLineList.RemoveAt(tempSpawnLineList.Count - 1);
				}
			}
			break;
		}
		case ESpawnSelectMode.AllSpawns_1:
			foreach (EternalTrialEnemy item13 in list)
			{
				foreach (EnemySpawnLine shuffledSpawn4 in shuffledSpawns)
				{
					if (IsPossibleSpawnLineFor(item13, shuffledSpawn4))
					{
						item13.TempSpawnLineList.Add(shuffledSpawn4);
					}
				}
			}
			break;
		}
		if (flag)
		{
			shuffledSpawns.ETShuffle(randomGenerator);
			foreach (EternalTrialEnemy item14 in list)
			{
				item14.TempSpawnLineList.Clear();
				foreach (EnemySpawnLine shuffledSpawn5 in shuffledSpawns)
				{
					if (IsPossibleSpawnLineFor(item14, shuffledSpawn5))
					{
						item14.TempSpawnLineList.Add(shuffledSpawn5);
					}
				}
				List<EnemySpawnLine> list3 = item14.TempSpawnLineList;
				RemoveRandomInstances(ref list3, randomGenerator);
			}
		}
		float num4 = (float)_OUTDefensePower[_waveNr] * 2f + 11f;
		difficultyContributionsInNight[_waveNr].Add(num4 + $" Base Difficulty from Expected Defense Gold Spent ({_OUTDefensePower[_waveNr]} Defense Power)");
		float num5 = 1f;
		float num6 = 1f;
		switch (settingSpawnInDuration)
		{
		case ESpawnInDuration.Immediate:
			num5 = 1f;
			break;
		case ESpawnInDuration.ShortFlow:
			num5 = 5.5f + 4f * UnityEngine.Random.value;
			break;
		case ESpawnInDuration.MediumFlow:
			num5 = 11.5f + 7f * UnityEngine.Random.value;
			break;
		case ESpawnInDuration.LongFlow:
			num5 = 25f + 7f * UnityEngine.Random.value;
			break;
		case ESpawnInDuration.RandomFlow:
			num5 = 1f + 30f * UnityEngine.Random.value;
			if (UnityEngine.Random.value < 0.2f)
			{
				num5 = 2f;
			}
			break;
		case ESpawnInDuration.GrowingFlow:
			num5 = (float)_waveNr * 3f;
			break;
		}
		if (flag2)
		{
			num5 = 40f + 140f * UnityEngine.Random.value;
		}
		num6 = 1f + num5 / 60f;
		difficultyContributionsInNight[_waveNr].Add(num6 + "x From spawn duration (" + num5 + " sec)");
		num4 *= num6;
		List<EnemySpawnLine> list4 = new List<EnemySpawnLine>();
		foreach (EternalTrialEnemy item15 in list)
		{
			foreach (EnemySpawnLine tempSpawnLine in item15.TempSpawnLineList)
			{
				if (!list4.Contains(tempSpawnLine))
				{
					list4.Add(tempSpawnLine);
				}
			}
		}
		float num7 = 0f;
		int num8 = 0;
		for (int k = 0; k < list4.Count; k++)
		{
			for (int l = k + 1; l < list4.Count; l++)
			{
				num8++;
				EnemySpawnLine enemySpawnLine = list4[k];
				EnemySpawnLine enemySpawnLine2 = list4[l];
				num7 = ((!enemySpawnLine.mostlySharedAttackpaths.Contains(enemySpawnLine2) && !enemySpawnLine2.mostlySharedAttackpaths.Contains(enemySpawnLine)) ? ((!enemySpawnLine.mostlySeperatedAttackPaths.Contains(enemySpawnLine2) && !enemySpawnLine2.mostlySeperatedAttackPaths.Contains(enemySpawnLine)) ? (num7 + 0.9f) : (num7 + 0.8f)) : (num7 + 1f));
			}
		}
		float num9 = ((num8 > 0) ? (num7 / (float)num8) : 1f);
		float num10 = Mathf.Pow(0.98f, list4.Count - 2) * num9;
		difficultyContributionsInNight[_waveNr].Add(num10 + "x From count (" + list4.Count + " spawns and average relationship strength of " + num9 + ")");
		num4 *= num10;
		float num11 = 0f;
		foreach (EnemySpawnLine item16 in list4)
		{
			num11 += item16.DifficultyBudgetMultiplyer;
		}
		num11 /= (float)list4.Count;
		difficultyContributionsInNight[_waveNr].Add(num11 + "x From spawn difficulty (e.g. proximity to base).");
		num4 *= num11;
		if (_waveNr == _outPutWavesLookup.Count - 1)
		{
			float num12 = 1.05f;
			difficultyContributionsInNight[_waveNr].Add(num12 + "x From final night difficulty bonus.");
			num4 *= num12;
		}
		int num13 = Mathf.Clamp(_stage, 0, 5);
		int num14 = _stage - num13;
		float num15 = Mathf.Pow(1.2f, num13 - 2) + (float)num14 * 0.3f;
		difficultyContributionsInNight[_waveNr].Add(num15 + "x From current stage (stage " + _stage + ").");
		num4 *= num15;
		targetDifficultyInNight[_waveNr] = num4;
		float num16 = 0f;
		float num17 = 0f;
		int num18 = 0;
		int num19 = 0;
		list.ETShuffle(randomGenerator);
		float num20 = 0f;
		foreach (EternalTrialEnemy item17 in list)
		{
			num20 += item17.difficultyValue;
		}
		float num21 = 1f;
		for (int m = 0; m < list.Count; m++)
		{
			EternalTrialEnemy eternalTrialEnemy = list[m];
			bool flag5 = m == list.Count - 1;
			EDistributeDifficulty eDistributeDifficulty = settingEDistributeDifficulty;
			if (_finalWave)
			{
				eDistributeDifficulty = EDistributeDifficulty.EvenDifficulty_3;
			}
			switch (eDistributeDifficulty)
			{
			case EDistributeDifficulty.EvenDifficulty_3:
				eternalTrialEnemy.TempTargetDifficulty = num4 / (float)list.Count;
				break;
			case EDistributeDifficulty.EvenUnitCount:
			{
				float num22 = eternalTrialEnemy.difficultyValue / num20;
				eternalTrialEnemy.TempTargetDifficulty = num4 * num22;
				break;
			}
			case EDistributeDifficulty.EvenDifficultyAndUnitCountMixture_2:
			{
				float num22 = eternalTrialEnemy.difficultyValue / num20;
				eternalTrialEnemy.TempTargetDifficulty = num4 * num22 * 0.5f + num4 / (float)list.Count * 0.5f;
				break;
			}
			case EDistributeDifficulty.VeryRandom:
			{
				float num22 = UnityEngine.Random.value * num21;
				if (flag5)
				{
					num22 = num21;
				}
				num21 -= num22;
				eternalTrialEnemy.TempTargetDifficulty = num4 * num22;
				break;
			}
			case EDistributeDifficulty.SlightlyRandom:
			{
				float num22 = UnityEngine.Random.value * num21;
				if (flag5)
				{
					num22 = num21;
				}
				num21 -= num22;
				eternalTrialEnemy.TempTargetDifficulty = num4 * num22 * 0.5f + num4 / (float)list.Count * 0.5f;
				break;
			}
			}
			float num23 = 0f;
			foreach (EnemySpawnLine tempSpawnLine2 in eternalTrialEnemy.TempSpawnLineList)
			{
				_ = tempSpawnLine2;
				float num24 = eternalTrialEnemy.TempTargetDifficulty / (float)eternalTrialEnemy.TempSpawnLineList.Count;
				eternalTrialEnemy.TempSpawnLineTargetDifficulty.Add(num24);
				int num25 = Mathf.Max(1, Mathf.RoundToInt(num24 / eternalTrialEnemy.DifficultyValueTemp));
				num19 += num25;
				eternalTrialEnemy.TempSpawnAmount.Add(num25);
				float num26 = (float)num25 * eternalTrialEnemy.DifficultyValueTemp;
				eternalTrialEnemy.TempSpawnLineActualDifficulty.Add(num26);
				num23 += num26;
				num17 += (float)num * (num24 / num4);
				int num27 = Mathf.RoundToInt(num17);
				num18 += num27;
				num17 -= (float)num27;
				eternalTrialEnemy.TempDropGold.Add(num27);
			}
			eternalTrialEnemy.TempActualDifficulty = num23;
			num16 += num23;
		}
		foreach (EternalTrialEnemy item18 in list)
		{
			for (int n = 0; n < item18.TempSpawnLineList.Count; n++)
			{
				float num28 = item18.TempSpawnLineActualDifficulty[n];
				float num29 = item18.TempSpawnLineTargetDifficulty[n];
				num29 += num4 - num16;
				if (num16 == num28 && num16 > num28)
				{
					continue;
				}
				int num30 = item18.TempSpawnAmount[n];
				Tuple<float, int> tuple = AdjustSpawnDifficulty(item18, num29, num28);
				int num31 = tuple.Item2 - num30;
				if (num19 + num31 > 0)
				{
					num19 += num31;
					item18.TempSpawnAmount[n] = tuple.Item2;
					item18.TempSpawnLineActualDifficulty[n] = tuple.Item1;
					item18.TempActualDifficulty = CalculateActualDifficulty(item18);
					num16 = list.Sum((EternalTrialEnemy et) => et.TempActualDifficulty);
				}
			}
			AdjustGoldAllocation(item18, list);
		}
		List<TagManager.ETag> list5 = new List<TagManager.ETag>();
		foreach (EternalTrialEnemy item19 in list)
		{
			foreach (TagManager.ETag tag in item19.enemyPrefab.GetComponentInChildren<TaggedObject>().Tags)
			{
				if (!list5.Contains(tag) && counterableTags.Contains(tag))
				{
					list5.Add(tag);
				}
			}
		}
		float num32 = _OUTDefensePower[_waveNr];
		if (_waveNr > 0)
		{
			num32 = _OUTDefensePower[_waveNr] - _OUTDefensePower[_waveNr - 1];
		}
		float num33 = num32 / (float)list5.Count;
		for (int num34 = 0; num34 < counterableTags.Count; num34++)
		{
			if (list5.Contains(counterableTags[num34]))
			{
				tagsCountered[num34] += num33;
			}
		}
		difficultyContributionsInNight[_waveNr].Add("---------------");
		foreach (EternalTrialEnemy enemy in enemySet.enemies)
		{
			int num35 = 0;
			foreach (TagManager.ETag tag2 in enemy.enemyPrefab.GetComponentInChildren<TaggedObject>().Tags)
			{
				int num36 = counterableTags.IndexOf(tag2);
				if (num36 != -1)
				{
					num35 += (int)tagsCountered[num36];
				}
			}
			float difficultyValue = enemy.difficultyValue;
			enemy.DifficultyValueTemp = enemy.difficultyValue * Mathf.Clamp(Mathf.Pow(0.996f, num35), 0.4f, 1f);
			difficultyContributionsInNight[_waveNr].Add(enemy.enemyPrefab.name + " difficulty reduced from " + difficultyValue + " to " + enemy.DifficultyValueTemp);
		}
		int num37 = 0;
		foreach (EternalTrialEnemy item20 in list)
		{
			for (int num38 = 0; num38 < item20.TempSpawnLineList.Count; num38++)
			{
				if (item20.TempSpawnAmount[num38] > 0)
				{
					wave.spawns.Add(new Spawn(item20.enemyPrefab, item20.TempSpawnLineList[num38].SpawnLine, item20.TempSpawnAmount[num38], 0.2f, item20.TempDropGold[num38]));
					num37 += item20.TempSpawnAmount[num38];
				}
			}
		}
		float num39 = 0f;
		switch (settingEliteMode)
		{
		case EElitMode.OneRandomEliteSpawn:
		{
			List<Spawn> list6 = wave.spawns.Where((Spawn spawn5) => spawn5.count >= 10 && !spawn5.eliteEnemies).ToList();
			if (list6.Any())
			{
				Spawn spawn = list6[UnityEngine.Random.Range(0, list6.Count)];
				spawn.count = Mathf.RoundToInt((float)spawn.count / 6f);
				spawn.interval *= 6f;
				spawn.eliteEnemies = true;
			}
			break;
		}
		case EElitMode.PartialConversionSmall:
			num39 = 0.2f;
			break;
		case EElitMode.PartialConversionMedium:
			num39 = 0.4f;
			break;
		case EElitMode.PartialConversionBig:
			num39 = 0.6f;
			break;
		case EElitMode.PartialConversionRandom:
			num39 = UnityEngine.Random.value * ((UnityEngine.Random.value < 0.25f) ? 0f : 1f);
			break;
		}
		if (num39 > 0f)
		{
			for (int num40 = 0; num40 < wave.spawns.Count; num40++)
			{
				Spawn spawn2 = wave.spawns[num40];
				if (!spawn2.eliteEnemies)
				{
					int num41 = Mathf.FloorToInt((float)spawn2.count * num39 / 6f) * 6;
					int num42 = Mathf.FloorToInt((float)spawn2.goldCoins * num39);
					if (num41 > 0)
					{
						spawn2.goldCoins -= num42;
						spawn2.count -= num41;
						Spawn item = new Spawn(spawn2.enemyPrefab, spawn2.spawnLine, num41 / 6, spawn2.interval * 6f, num42, spawn2.delay, _eliteEnemies: true);
						wave.spawns.Add(item);
					}
				}
			}
		}
		bool flag6 = false;
		while (num37 > maxAmountOfUnitsPerWave)
		{
			Spawn spawn3 = null;
			int index = -1;
			for (int num43 = 0; num43 < wave.spawns.Count; num43++)
			{
				if ((spawn3 == null || wave.spawns[num43].count > spawn3.count) && !wave.spawns[num43].eliteEnemies)
				{
					spawn3 = wave.spawns[num43];
					index = num43;
				}
			}
			if (spawn3 == null || spawn3.count == 1)
			{
				flag6 = true;
				break;
			}
			int num44 = Mathf.Max(1, spawn3.count / 6);
			num37 -= spawn3.count;
			num37 += num44;
			spawn3.interval *= 6f;
			spawn3.count = num44;
			spawn3.eliteEnemies = true;
			wave.spawns[index] = spawn3;
		}
		float lowestDelay = float.MaxValue;
		int count = wave.spawns.Count;
		float num45 = UnityEngine.Random.Range(0.05f, 0.45f);
		float num46 = num5 / (float)count;
		wave.spawns.ETShuffle(randomGenerator);
		for (int num47 = 0; num47 < count; num47++)
		{
			Spawn spawn4 = wave.spawns[num47];
			ESpawnInType eSpawnInType = settingESpawnInType;
			if (num5 >= 45f)
			{
				if (UnityEngine.Random.value < 0.5f)
				{
					eSpawnInType = ESpawnInType.Normal;
				}
				else if (UnityEngine.Random.value < 0.5f)
				{
					eSpawnInType = ESpawnInType.DynamicSmallGroups;
				}
				else if (UnityEngine.Random.value < 0.5f)
				{
					eSpawnInType = ESpawnInType.OneSpawnAtATime;
				}
			}
			switch (eSpawnInType)
			{
			case ESpawnInType.Normal:
				CalculateSpawnParameters(spawn4.count, num5, ref lowestDelay, out spawn4.interval, out spawn4.delay);
				break;
			case ESpawnInType.TwoWaves:
				SplitSpawns(wave.spawns, spawn4, 2, num5 * 0.1f, ref lowestDelay, num5);
				break;
			case ESpawnInType.ThreeWaves:
				SplitSpawns(wave.spawns, spawn4, 3, num5 * 0.1f, ref lowestDelay, num5);
				break;
			case ESpawnInType.DynamicSmallGroups:
			{
				int num48 = 4 + UnityEngine.Random.Range(0, 3);
				int targetSubSpawnCount = Mathf.Max(1, Mathf.RoundToInt(spawn4.count / num48));
				float subSpawnDuration = num5 * num45 / (float)targetSubSpawnCount;
				SplitSpawns(wave.spawns, spawn4, targetSubSpawnCount, subSpawnDuration, ref lowestDelay, num5);
				break;
			}
			case ESpawnInType.DynamicBigGroups:
			{
				int num48 = 8 + UnityEngine.Random.Range(0, 10);
				int targetSubSpawnCount = Mathf.Max(1, Mathf.RoundToInt(spawn4.count / num48));
				float subSpawnDuration = num5 * num45 / (float)targetSubSpawnCount;
				SplitSpawns(wave.spawns, spawn4, targetSubSpawnCount, subSpawnDuration, ref lowestDelay, num5);
				break;
			}
			case ESpawnInType.RandomGroupsAndStreams:
			{
				int targetSubSpawnCount = UnityEngine.Random.Range(1, 6);
				float subSpawnDuration = num5 * num45 / (float)targetSubSpawnCount;
				SplitSpawns(wave.spawns, spawn4, targetSubSpawnCount, subSpawnDuration, ref lowestDelay, num5);
				break;
			}
			case ESpawnInType.OneSpawnAtATime:
				CalculateSpawnParameters(spawn4.count, num46, ref lowestDelay, out spawn4.interval, out spawn4.delay);
				spawn4.delay += num46 * (float)num47;
				break;
			case ESpawnInType.OneSpawnAtATimeInWaves:
			{
				int targetSubSpawnCount = UnityEngine.Random.Range(2, 4);
				SplitSpawns(wave.spawns, spawn4, targetSubSpawnCount, num46 * 0.1f, ref lowestDelay, num46, num46 * (float)num47);
				break;
			}
			}
		}
		foreach (Spawn spawn5 in wave.spawns)
		{
			spawn5.delay -= lowestDelay;
		}
		if (num17 > 0.01f)
		{
			Debug.LogError("We did not drop all the gold. Thats bad. Leftover: " + num17);
		}
		if (num18 != num)
		{
			Debug.LogError("Dropped gold and gold to drop do not match: " + num18 + " - " + num);
		}
		int num49 = 0;
		foreach (EternalTrialEnemy item21 in list)
		{
			num49 += CalculateTotalGoldDropped(item21);
		}
		if (num49 != num)
		{
			Debug.LogError("Gold check and gold to drop do not match: " + num49 + " - " + num);
		}
		_success = !flag6;
		return wave;
	}

	private EternalTrialEnemy FirstPossibleEnemyForWave(int _waveNr, int _startIndex, out int _foundIndex)
	{
		_foundIndex = _startIndex % shuffledEnemies.Count;
		int num = _foundIndex;
		do
		{
			if (shuffledEnemies[_foundIndex].minDefenseInvestment <= (float)_OUTDefensePower[_waveNr])
			{
				return shuffledEnemies[_foundIndex];
			}
			_foundIndex = (_foundIndex + 1) % shuffledEnemies.Count;
		}
		while (_foundIndex != num);
		return shuffledEnemies[num];
	}

	private EnemySpawnLine FirstPossibleSpawnFor(EternalTrialEnemy _enemy, int _startIndex, out int _foundIndex)
	{
		bool flying = _enemy.flying;
		bool bigGround = _enemy.bigGround;
		bool smallGround = _enemy.smallGround;
		_foundIndex = _startIndex % shuffledSpawns.Count;
		int num = _foundIndex;
		do
		{
			if ((shuffledSpawns[_foundIndex].canSpawnBigGround || !bigGround) && (shuffledSpawns[_foundIndex].canSpawnFlying || !flying) && (shuffledSpawns[_foundIndex].canSpawnSmallGround || !smallGround))
			{
				return shuffledSpawns[_foundIndex];
			}
			_foundIndex = (_foundIndex + 1) % shuffledSpawns.Count;
		}
		while (_foundIndex != num);
		return shuffledSpawns[num];
	}

	private bool IsPossibleSpawnLineFor(EternalTrialEnemy _enemy, EnemySpawnLine _line)
	{
		if ((_line.canSpawnBigGround || !_enemy.bigGround) && (_line.canSpawnFlying || !_enemy.flying) && (_line.canSpawnSmallGround || !_enemy.smallGround))
		{
			return true;
		}
		return false;
	}

	private Tuple<float, int> AdjustSpawnDifficulty(EternalTrialEnemy et, float targetDiff, float currentDiff)
	{
		int num = Mathf.Max(0, Mathf.RoundToInt(targetDiff / et.DifficultyValueTemp));
		float num2 = (float)num * et.DifficultyValueTemp;
		if (Mathf.Abs(targetDiff - num2) < Mathf.Abs(targetDiff - currentDiff))
		{
			return new Tuple<float, int>(num2, num);
		}
		return new Tuple<float, int>(currentDiff, Mathf.RoundToInt(currentDiff / et.DifficultyValueTemp));
	}

	private void AdjustGoldAllocation(EternalTrialEnemy et, List<EternalTrialEnemy> enemyList)
	{
		if (et.TempSpawnAmount.All((int amount) => amount == 0))
		{
			int num = et.TempDropGold.Sum();
			foreach (EternalTrialEnemy enemy in enemyList)
			{
				if (enemy == et || !enemy.TempSpawnAmount.Any((int amount) => amount > 0))
				{
					continue;
				}
				for (int num2 = 0; num2 < enemy.TempSpawnAmount.Count; num2++)
				{
					if (num <= 0)
					{
						break;
					}
					if (enemy.TempSpawnAmount[num2] > 0)
					{
						enemy.TempDropGold[num2] += num;
						num = 0;
					}
				}
			}
			for (int num3 = 0; num3 < et.TempDropGold.Count; num3++)
			{
				et.TempDropGold[num3] = 0;
			}
			return;
		}
		for (int num4 = 0; num4 < et.TempSpawnAmount.Count; num4++)
		{
			if (et.TempSpawnAmount[num4] != 0)
			{
				continue;
			}
			int num5 = et.TempDropGold[num4];
			et.TempDropGold[num4] = 0;
			for (int num6 = 0; num6 < et.TempSpawnAmount.Count; num6++)
			{
				if (num5 <= 0)
				{
					break;
				}
				if (et.TempSpawnAmount[num6] > 0)
				{
					et.TempDropGold[num6] += num5;
					num5 = 0;
				}
			}
		}
	}

	private float CalculateActualDifficulty(EternalTrialEnemy et)
	{
		float num = 0f;
		for (int i = 0; i < et.TempSpawnAmount.Count; i++)
		{
			num += (float)et.TempSpawnAmount[i] * et.DifficultyValueTemp;
		}
		return num;
	}

	private int CalculateTotalGoldDropped(EternalTrialEnemy et)
	{
		int num = 0;
		for (int i = 0; i < et.TempSpawnAmount.Count; i++)
		{
			num += et.TempDropGold[i];
		}
		return num;
	}

	private static void RemoveRandomInstances<T>(ref List<T> list, System.Random rng)
	{
		int num = rng.Next(0, list.Count);
		for (int i = 0; i < num; i++)
		{
			if (list.Count <= 1)
			{
				break;
			}
			int index = rng.Next(0, list.Count);
			list.RemoveAt(index);
		}
	}

	private void RemoveInvalidEnemiesFromShuffeledEnemeisAndShuffle(out List<EternalTrialEnemy> removedEnemies, System.Random randomGenerator)
	{
		shuffledEnemies.ETShuffle(randomGenerator);
		removedEnemies = new List<EternalTrialEnemy>();
		switch (settingEnemyPreselection)
		{
		case EEnemyPreselection.MonstersOnly:
		{
			for (int num6 = shuffledEnemies.Count - 1; num6 >= 0; num6--)
			{
				if (!shuffledEnemies[num6].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.Monster))
				{
					removedEnemies.Add(shuffledEnemies[num6]);
					shuffledEnemies.RemoveAt(num6);
				}
			}
			break;
		}
		case EEnemyPreselection.NoMonsters:
		{
			for (int num10 = shuffledEnemies.Count - 1; num10 >= 0; num10--)
			{
				if (shuffledEnemies[num10].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.Monster))
				{
					removedEnemies.Add(shuffledEnemies[num10]);
					shuffledEnemies.RemoveAt(num10);
				}
			}
			break;
		}
		case EEnemyPreselection.FastOnly:
		{
			for (int num2 = shuffledEnemies.Count - 1; num2 >= 0; num2--)
			{
				if (!shuffledEnemies[num2].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.FastMoving))
				{
					removedEnemies.Add(shuffledEnemies[num2]);
					shuffledEnemies.RemoveAt(num2);
				}
			}
			break;
		}
		case EEnemyPreselection.NoFast:
		{
			for (int num8 = shuffledEnemies.Count - 1; num8 >= 0; num8--)
			{
				if (shuffledEnemies[num8].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.FastMoving))
				{
					removedEnemies.Add(shuffledEnemies[num8]);
					shuffledEnemies.RemoveAt(num8);
				}
			}
			break;
		}
		case EEnemyPreselection.MeleeOnly:
		{
			for (int num4 = shuffledEnemies.Count - 1; num4 >= 0; num4--)
			{
				if (!shuffledEnemies[num4].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.MeeleFighter))
				{
					removedEnemies.Add(shuffledEnemies[num4]);
					shuffledEnemies.RemoveAt(num4);
				}
			}
			break;
		}
		case EEnemyPreselection.RangedOnly:
		{
			for (int num11 = shuffledEnemies.Count - 1; num11 >= 0; num11--)
			{
				if (!shuffledEnemies[num11].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.RangedFighter))
				{
					removedEnemies.Add(shuffledEnemies[num11]);
					shuffledEnemies.RemoveAt(num11);
				}
			}
			break;
		}
		case EEnemyPreselection.NoFlying:
		{
			for (int num9 = shuffledEnemies.Count - 1; num9 >= 0; num9--)
			{
				if (shuffledEnemies[num9].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.Flying))
				{
					removedEnemies.Add(shuffledEnemies[num9]);
					shuffledEnemies.RemoveAt(num9);
				}
			}
			break;
		}
		case EEnemyPreselection.FlyingOnly:
		{
			for (int num7 = shuffledEnemies.Count - 1; num7 >= 0; num7--)
			{
				if (!shuffledEnemies[num7].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.Flying))
				{
					removedEnemies.Add(shuffledEnemies[num7]);
					shuffledEnemies.RemoveAt(num7);
				}
			}
			break;
		}
		case EEnemyPreselection.NoSiege:
		{
			for (int num5 = shuffledEnemies.Count - 1; num5 >= 0; num5--)
			{
				if (shuffledEnemies[num5].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.SiegeWeapon))
				{
					removedEnemies.Add(shuffledEnemies[num5]);
					shuffledEnemies.RemoveAt(num5);
				}
			}
			break;
		}
		case EEnemyPreselection.VulnerableToSplashOnly:
		{
			for (int num3 = shuffledEnemies.Count - 1; num3 >= 0; num3--)
			{
				if (!shuffledEnemies[num3].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.NaturallyVulnerableToSplash))
				{
					removedEnemies.Add(shuffledEnemies[num3]);
					shuffledEnemies.RemoveAt(num3);
				}
			}
			break;
		}
		case EEnemyPreselection.NoVulnerableToSplash:
		{
			for (int num = shuffledEnemies.Count - 1; num >= 0; num--)
			{
				if (shuffledEnemies[num].enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.NaturallyVulnerableToSplash))
				{
					removedEnemies.Add(shuffledEnemies[num]);
					shuffledEnemies.RemoveAt(num);
				}
			}
			break;
		}
		case EEnemyPreselection.RemoveRandoms_10:
			RemoveRandomInstances(ref shuffledEnemies, randomGenerator);
			break;
		}
		bool flag = true;
		foreach (EternalTrialEnemy shuffledEnemy in shuffledEnemies)
		{
			if (!shuffledEnemy.enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.Flying))
			{
				flag = false;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		foreach (EternalTrialEnemy removedEnemy in removedEnemies)
		{
			if (!removedEnemy.enemyPrefab.GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.Flying))
			{
				shuffledEnemies.Add(removedEnemy);
				shuffledEnemies.ETShuffle(randomGenerator);
				break;
			}
		}
	}

	private void CalculateSpawnParameters(int enemyCount, float spawnDuration, ref float lowestDelay, out float interval, out float delay)
	{
		interval = 0.02f;
		delay = 0f;
		if (enemyCount > 1)
		{
			interval = spawnDuration / (float)(enemyCount - 1);
		}
		else
		{
			delay = UnityEngine.Random.value * spawnDuration;
		}
		lowestDelay = Mathf.Min(lowestDelay, delay);
	}

	private int[] DistributeEvenly(int total, int divisions)
	{
		int[] array = new int[divisions];
		int num = total / divisions;
		int num2 = total % divisions;
		for (int i = 0; i < divisions; i++)
		{
			array[i] = num + ((i < num2) ? 1 : 0);
		}
		return array;
	}

	private int SplitSpawns(List<Spawn> listToAddTo, Spawn spawnToSplit, int targetSubSpawnCount, float subSpawnDuration, ref float lowestDelay, float totalSpawnDuration, float addedDelay = 0f)
	{
		if (spawnToSplit.count <= 1)
		{
			CalculateSpawnParameters(spawnToSplit.count, totalSpawnDuration, ref lowestDelay, out spawnToSplit.interval, out spawnToSplit.delay);
			spawnToSplit.delay += addedDelay;
			return 0;
		}
		if (targetSubSpawnCount <= 1)
		{
			CalculateSpawnParameters(spawnToSplit.count, totalSpawnDuration, ref lowestDelay, out spawnToSplit.interval, out spawnToSplit.delay);
			spawnToSplit.delay += addedDelay;
			return 0;
		}
		if (targetSubSpawnCount > spawnToSplit.count)
		{
			targetSubSpawnCount = spawnToSplit.count;
		}
		int num = 0;
		int[] array = DistributeEvenly(spawnToSplit.count, targetSubSpawnCount);
		int[] array2 = DistributeEvenly(spawnToSplit.goldCoins, targetSubSpawnCount);
		float num2 = (totalSpawnDuration - subSpawnDuration) / (float)(targetSubSpawnCount - 1);
		CalculateSpawnParameters(array[0], subSpawnDuration, ref lowestDelay, out spawnToSplit.interval, out spawnToSplit.delay);
		spawnToSplit.delay += addedDelay;
		spawnToSplit.count = array[0];
		spawnToSplit.goldCoins = array2[0];
		for (int i = 1; i < targetSubSpawnCount; i++)
		{
			float num3 = num2 * (float)i;
			CalculateSpawnParameters(array[i], subSpawnDuration, ref lowestDelay, out var interval, out var delay);
			Spawn item = new Spawn(spawnToSplit.enemyPrefab, spawnToSplit.spawnLine, array[i], interval, array2[i], num3 + delay + addedDelay, spawnToSplit.eliteEnemies);
			listToAddTo.Add(item);
			num++;
		}
		return num;
	}

	public static T GetRandomEnumValue<T>() where T : Enum
	{
		Array values = Enum.GetValues(typeof(T));
		return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
	}

	public static T GetRandomEnumValueWithDistribution<T>() where T : Enum
	{
		Array values = Enum.GetValues(typeof(T));
		List<T> list = new List<T>();
		foreach (object item in values)
		{
			string text = item.ToString();
			int num = text.LastIndexOf('_');
			if (num > 0 && int.TryParse(text.Substring(num + 1), out var result))
			{
				for (int i = 0; i < result; i++)
				{
					list.Add((T)item);
				}
			}
			else
			{
				list.Add((T)item);
			}
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}
}
