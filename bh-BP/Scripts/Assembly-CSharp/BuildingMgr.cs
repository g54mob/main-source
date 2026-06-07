using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BuildingMgr : SerializedMonoBehaviour
{
	public static BuildingMgr I;

	public const bool kUseAutomation = true;

	[Header("Misc Refs")]
	public Sprite RendScaffold2x2;

	public Sprite RendScaffold1x1;

	public Sprite RendScaffoldUpgrade2x2;

	public Sprite RendScaffoldUpgrade1x1;

	public Sprite RendScaffold6x6;

	[Header("Building bonuses")]
	public int[] BonusStats;

	public List<BuildingInst>[] BuildingsByType;

	[NamedArray(typeof(StatType))]
	public StatScaling[] BonusStatScaling;

	public float BonusXP;

	public float BonusGold;

	public int NumKillsPerBonusGold;

	public int MarketLvl;

	public int MasseuseLvl;

	public int BonusStarterLvl;

	public int NumRevives;

	public float ReviveHealthPct;

	public float HarvestLength;

	public float WorkerMoveSpeedMult;

	public float WorkerMoveSpeed;

	public float BonusPickupRange;

	public int MinFuserUpgrades;

	public int NumFreeRerolls;

	public const int kBaseRerollCost = 5;

	public float RerollCostMult;

	public float SecondUpgradeChance;

	public int BallStarterLevel;

	public int PassiveStarterLevel;

	public int PetUpgradeStarterLevel;

	public int NumLvlUpChoices;

	public int NumBanishes;

	public bool EndlessModeUnlocked;

	public int BonusDeathGold;

	public int BonusCompletionGold;

	public int NumBallSlots;

	public int NumPassiveSlots;

	public int BonusBallChoiceLvl;

	public int BonusPassiveChoiceLvl;

	public int MatchMakerSecondBallLvl;

	public const int kMaxHatcherySlots = 4;

	public int NumHatcherySlots;

	public const int kMaxPetSlots = 3;

	public int NumPetSlots;

	public int MaxPetUpgrades;

	public const int kMaxPetLabSlots = 3;

	public int NumPetLabSlots;

	public Dictionary<int, BuildingInst> BuildingsById;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public bool IsBuildingBuilt(BuildingType bt)
	{
		return false;
	}

	public void CalculateBonuses()
	{
	}

	public int GetBonusStat(StatType st)
	{
		return 0;
	}

	public StatScaling GetScaling(StatType pt)
	{
		return default(StatScaling);
	}

	public float GetScalingMult(StatType pt)
	{
		return 0f;
	}

	public void PassDay()
	{
	}

	public List<BuildingInfo> GetAvailBlueprintsForLevel(LevelType lt)
	{
		return null;
	}

	public List<BuildingInfo> GetAvailBossBlueprints()
	{
		return null;
	}

	public int GetNumBossBlueprintsAvailable()
	{
		return 0;
	}

	public List<BuildingInfo> GetAvailFuserBlueprints(out int numBlueprintsGot)
	{
		numBlueprintsGot = default(int);
		return null;
	}

	private void AddBlueprintIfFullyUpgraded(BuildingType statue, BuildingType dep1, BuildingType dep2, List<BuildingInfo> outList)
	{
	}

	public BuildingInst GetBuildingOfType(BuildingType bt)
	{
		return null;
	}

	public int GetNumFuserBlueprintsAvailable()
	{
		return 0;
	}

	public void RegisterBuildingToChunk(BuildingInst b, bool add)
	{
	}

	public BaseTileType GetTile(float x, float y)
	{
		return default(BaseTileType);
	}

	public void SetTile(float x, float y, BaseTileType type)
	{
	}

	private void OnSaveLoaded()
	{
	}

	public BuildingInst GetBuildingById(int id)
	{
		return null;
	}

	public int GetMasseuseCost()
	{
		return 0;
	}

	public float GetLevelCompletionBonusAmt(BuildingType bt, bool isPreview = false)
	{
		return 0f;
	}

	public bool IsBuildingAvailableToHarvest()
	{
		return false;
	}

	public int GetHarvestRefreshLen()
	{
		return 0;
	}

	public float GetHarvestRefreshProgress()
	{
		return 0f;
	}

	public bool HasBuilding(BuildingType bt)
	{
		return false;
	}

	public void RefreshStatusIcons(BuildingType bt)
	{
	}

	public void PrintBaseExport()
	{
	}

	private string GetBaseExportStr()
	{
		return null;
	}

	public void ImportBase(string str, bool ignoreReq)
	{
	}

	private int GetFirstIdxOfBld(List<BuildingInst> list, BuildingType t)
	{
		return 0;
	}
}
