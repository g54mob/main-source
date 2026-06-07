using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MetaSaveData
{
	public static MetaSaveData I;

	public int VersionNum;

	public int[] NumResources;

	public int[] TotalResources;

	public int[] NumIdleResources;

	public int[] MarketResources;

	public CharType LastChar;

	public LevelType LastLevel;

	public int LastLevelNGPlus;

	public List<CharType> CharUnlockOrder;

	public List<CharType> CharWorkerOrder;

	public List<CharType> BonusChars;

	public List<int> BonusCharAmt;

	public bool[] IsGameTutSeen;

	public bool[] IsBaseTutSeen;

	public int CurDay;

	public List<BuildingInst> Buildings;

	public BaseChunkInst[][] BaseChunks;

	public int NumBuildingsBuilt;

	public bool DayJustPassed;

	public bool DidHarvestToday;

	public int LastHarvestWorldTime;

	public float LastHarvestX;

	public Vector2 LastHarvestAim;

	public CharMetaInst[] Chars;

	public BlueprintInst[] Blueprints;

	public int ElevatorLvl;

	public LevelType WarRoomLevel;

	public bool ShouldRecalculateLaunchers;

	public int NumMasseuseToday;

	public float EggDropRate;

	public int Seed;

	public int NumBattlesPlayed;

	public int[] NumPickupsGot;

	public LevelData[] LvlData;

	public List<LevelData[]> NGPlusLvlData;

	public HeroMetaStats[] HeroStats;

	public PassiveMetaStats[] PassiveStats;

	public int NumHarvests;

	public int NumBuildingsConstructed;

	public int NumResourcesConstructed;

	public int NumBuildingsUpgraded;

	public int NumResourcesUpgraded;

	public float PlayTime;

	public float ScaledPlayTime;

	public float BaseTime;

	public int WorldTime;

	public int NumBossWavesCompleted;

	public int NumKills;

	public int SecondsSince2040;

	public int NumBossBlueprintsDropped;

	public int GetMinCol()
	{
		return 0;
	}

	public int GetMaxCol()
	{
		return 0;
	}

	public int GetMinRow()
	{
		return 0;
	}

	public int GetMaxRow()
	{
		return 0;
	}

	public int GetNumPurchasedChunks()
	{
		return 0;
	}

	public bool IsPurchasedChunkAdjacent(int x, int y)
	{
		return false;
	}

	public int GetBaseCols()
	{
		return 0;
	}

	public int GetBaseRows()
	{
		return 0;
	}

	public float GetCenterCol()
	{
		return 0f;
	}

	public float GetCenterRow()
	{
		return 0f;
	}

	public BuildingInst GetHome()
	{
		return null;
	}

	public bool HasBuilding(BuildingType bt)
	{
		return false;
	}

	public bool HasResourceTile()
	{
		return false;
	}

	public bool HasAnythingToHarvest()
	{
		return false;
	}

	public bool IsWorkerAvailableToGather()
	{
		return false;
	}

	public int GetBaseSeed()
	{
		return 0;
	}

	public CharMetaInst GetLastCharInst()
	{
		return null;
	}

	public void RecalculateLaunchersIfNeeded()
	{
	}

	public List<CharType> GetUnlockedChars()
	{
		return null;
	}

	public int GetNumUnlockedChars()
	{
		return 0;
	}

	public WeightedEnumList<CharType> GetWeightedCharListForBonus()
	{
		return null;
	}

	public int GetNumLevelsComplete()
	{
		return 0;
	}

	public LevelData GetLvlData(LevelType t, int ngPlus)
	{
		return null;
	}

	public LevelType GetLatestUnlockedLevel()
	{
		return default(LevelType);
	}

	public int GetLatestNGPlusLevel()
	{
		return 0;
	}

	public LevelData GetLatestUnlockedLvlData()
	{
		return null;
	}

	public LevelData GetNextLockedLvlData()
	{
		return null;
	}

	public void MarkPlaythroughComplete(int ngPlus)
	{
	}
}
