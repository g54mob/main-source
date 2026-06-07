using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CharMetaInst
{
	public CharType Type;

	public CharState CurState;

	public int WorkerBuildingId;

	public BuildingType WorkerBuildingType;

	public List<HarvestUpgradeInst> HarvestUpgrades;

	public int Lvl;

	public const int kMaxLvl = 99;

	public int CurXP;

	public int NumBattles;

	public int[] BonusStats;

	public bool IsUnlocked;

	[NonSerialized]
	public BallObj Obj;

	[NonSerialized]
	public BaseCharObj BaseObj;

	public int NumTimesRerolled;

	public CharMetaInst(CharType t)
	{
	}

	public CharInfo GetInfo()
	{
		return null;
	}

	public void ApplyIcon(Image img)
	{
	}

	public int GetSeed(int lvl)
	{
		return 0;
	}

	public List<StatType> GetLvlUpStats(int lvl)
	{
		return null;
	}

	public bool ShouldGainHarvestUpgrade(int lvl)
	{
		return false;
	}

	public bool ShouldGainHousingUpgrade(int lvl)
	{
		return false;
	}

	public bool HasHousingUpgrade()
	{
		return false;
	}

	public bool HasHousingUpgrade(int lvl)
	{
		return false;
	}

	public int GetTgtXP(int lvl = -1)
	{
		return 0;
	}

	public float GetXPPct()
	{
		return 0f;
	}

	public void AddLvl()
	{
	}

	public bool CanBeSentToBattle()
	{
		return false;
	}

	public bool CanBeSentToWork()
	{
		return false;
	}

	public void SetWorking(BuildingObj b)
	{
	}

	public BuildingInst GetWorkerBuilding()
	{
		return null;
	}

	public void RemoveFromWorkstation()
	{
	}

	public void SetState(CharState st)
	{
	}

	public Sprite GetStatusIcon()
	{
		return null;
	}

	public bool HasHarvestUpgrade(HarvestUpgradeType ht)
	{
		return false;
	}

	public HarvestUpgradeInst GetHarvestUpgrade(HarvestUpgradeType ht)
	{
		return null;
	}

	public int GetHarvestUpgradeLvl(HarvestUpgradeType ht)
	{
		return 0;
	}

	public void AddHarvestUpgrade(HarvestUpgradeType ht)
	{
	}

	public bool CanAddHarvestUpgrade(HarvestUpgradeType ht)
	{
		return false;
	}

	public int GetHarvestUpgradeBonusAmt(HarvestUpgradeType ht)
	{
		return 0;
	}

	public void AddSecs(int secs)
	{
	}

	public bool IsInBattle()
	{
		return false;
	}

	public Cost GetHarvestRerollCost()
	{
		return null;
	}

	public bool AreStatsCheated()
	{
		return false;
	}
}
