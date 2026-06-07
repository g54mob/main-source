using System.Collections.Generic;
using UnityEngine;

public class ShopAndUpgradesManager : MonoBehaviour
{
	public static ShopAndUpgradesManager Singleton;

	public const int MAXBERRYTIER = 11;

	[Header("Berry Hole Growth")]
	public List<float> BerryHoleGrowthValueList;

	[Header("Price Lists")]
	public List<int> BerryUpgradesSeedPriceList;

	public List<int> BerryCoinValueList;

	public float sellMoneyBack_Percent;

	[Header("Soil Patches")]
	public int dirtPatch_BasePrice;

	public float dirtPatch_CostIncreaseMultiPer;

	[Header("Conveyor Belts")]
	public int conveyorBelt_BasePrice;

	public float conveyorBelt_CostIncreaseMultiPer;

	[Header("Trampolines")]
	public int trampolines_BasePrice;

	public float trampolines_CostIncreaseMultiPer;

	[Header("Blenders")]
	public int blenders_BasePrice;

	public float blenders_CostIncreaseMultiPer;

	[Header("Piggy Bank Upgrades")]
	public int piggyBank_Capacity_Level;

	public List<int> piggyBank_Capacity_Prices;

	public List<string> piggyBank_Capacity_UpgradeDescriptions;

	public List<int> piggyBank_Capacity_LevelValues;

	[Header("Turtle Upgrades")]
	public int turtleEatSpeed_Level;

	public List<int> turtleEatSpeed_Prices;

	public List<string> turtleEatSpeed_UpgradeDescriptions;

	public List<float> turtleEatSpeed_LevelValues;

	public int turtleEatSpeed_TurtleTurnSpeed_Base;

	public int turtleEatSpeed_TurtleTurnSpeed_IncreasePerLevel;

	[Header("Seed Drop Rate Upgrades")]
	public int seedDropRate_Level;

	public List<int> seedDropRate_Prices;

	public List<string> seedDropRate_UpgradeDescriptions;

	public List<float> seedDropRate_LevelValues;

	[Header("Turtle Bonus Coins Upgrades")]
	public int bonusCoinsUpgrade_Level;

	public List<int> bonusCoinsUpgrade_Prices;

	public List<string> bonusCoinsUpgrade_UpgradeDescriptions;

	public List<float> bonusCoinsUpgrade_LevelValues;

	[Header("Trick Shot Upgrades")]
	public int trickShotUpgrade_Level;

	public List<int> trickShotUpgrade_Level_Prices;

	public List<string> trickShotUpgrade_Level_UpgradeDescriptions;

	public List<float> trickShotUpgrade_Level_LevelValues;

	[Header("Growth Rate Upgrade")]
	public int growthRateUpgrade_Level;

	public List<int> growthRateUpgrade_Level_Prices;

	public List<string> growthRateUpgrade_Level_UpgradeDescriptions;

	public List<float> growthRateUpgrade_Level_LevelValues;

	[Header("Piggy Bank Can Suck Seeds")]
	public int piggyBank_CanPickUpSeeds_Level;

	public List<int> piggyBank_CanPickUpSeeds_Prices;

	public List<string> piggyBank_CanPickUpSeeds_UpgradeDescriptions;

	public bool piggyBank_CanSuckUpSeeds;

	[Header("Golden Berry Spawn Chance")]
	public int goldenBerrySpawnChance_Level;

	public List<int> goldenBerrySpawnChance_Level_Prices;

	public List<string> goldenBerrySpawnChance_Level_UpgradeDescriptions;

	public List<float> goldenBerrySpawnChance_Level_LevelValues;

	[Header("Golden Berry Multi")]
	public int goldenBerryMulti_Level;

	public List<int> goldenBerryMulti_Level_Prices;

	public List<string> goldenBerryMulti_Level_UpgradeDescriptions;

	public List<float> goldenBerryMulti_Level_LevelValues;

	[Header("Bonus Build Spot Multi")]
	public int bonusTile_Level;

	public List<int> bonusTile_Level_Prices;

	public List<string> bonusTile_Level_UpgradeDescriptions;

	public List<float> bonusTile_Level_LevelValues;

	[Header("Bonus Build Spot Multi")]
	public int bonusTileXpMulti_Level;

	public List<int> bonusTileXpMulti_Level_Prices;

	public List<string> bonusTileXpMulti_Level_UpgradeDescriptions;

	public List<int> bonusTileXpMulti_Level_LevelValues;

	[Header("Gold Rush Duration")]
	public int goldRushDuration_Level;

	public List<int> goldRushDuration_Level_Prices;

	public List<string> goldRushDuration_Level_UpgradeDescriptions;

	public List<int> goldRushDuration_Level_LevelValues;

	[Header("Gold Rush Cooldown")]
	public int goldRushCooldown_Level;

	public List<int> goldRushCooldown_Level_Prices;

	public List<string> goldRushCooldown_Level_UpgradeDescriptions;

	public List<int> goldRushCooldown_Level_LevelValues;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Singleton = this;
		CalculateBerryCoinValuesAndPopulateList();
	}

	private void Start()
	{
		SetAllStatsFromLevels(_onGameStart: true);
	}

	private void Update()
	{
	}

	public void UpgradeBerryButtonClicked()
	{
		UpgradePlantBedsBerryTier(HudManager.Singleton.selectedPlantBed, HudManager.Singleton.selectedPlantBed.currentBerryTier + 1, BerryUpgradesSeedPriceList[HudManager.Singleton.selectedPlantBed.currentBerryTier + 1]);
		HudManager.Singleton.ShowUIGroup_SubGroup_PlantBedInfo();
	}

	public void UpgradePlantBedsBerryTier(PlantBed _plantBed, int _tier, int _seedCost)
	{
		if (_tier <= 11)
		{
			_plantBed.currentBerryTier++;
			_plantBed.ChangeBerryProfile(GameManager.Singleton.prefabBank.berryProfiles[_plantBed.currentBerryTier]);
			PlayerStats.Singleton.SpendSeeds(_seedCost);
			_plantBed.OnUpgraded();
		}
	}

	public void SetAllStatsFromLevels(bool _onGameStart = false)
	{
	}

	public void SetLevelValues_PiggyBankCapacity()
	{
		PlayerStats.Singleton.piggyBank_Limit = piggyBank_Capacity_LevelValues[piggyBank_Capacity_Level];
		if (piggyBank_Capacity_Level > 0)
		{
			GameManager.Singleton.prefabBank.piggyBankInScene.SetActive(value: true);
		}
		else
		{
			GameManager.Singleton.prefabBank.piggyBankInScene.SetActive(value: false);
		}
	}

	public void SetLevelValus_PiggyBankSeedVacuum()
	{
		piggyBank_CanSuckUpSeeds = piggyBank_CanPickUpSeeds_Level > 0;
	}

	public void SetLevelValues_TurtleEatSpeed()
	{
		PlayerStats.Singleton.turtleEatCooldown = turtleEatSpeed_LevelValues[turtleEatSpeed_Level];
		PlayerStats.Singleton.turtleRotateSpeed = turtleEatSpeed_TurtleTurnSpeed_Base + turtleEatSpeed_TurtleTurnSpeed_IncreasePerLevel * turtleEatSpeed_Level;
	}

	public void SetLevelValues_SeedDropRate()
	{
		PlayerStats.Singleton.seedSpawnChance_IncreasePerFail = seedDropRate_LevelValues[seedDropRate_Level];
	}

	public void SetLevelValues_BonusCoinsUpgrade()
	{
		PlayerStats.Singleton.berryCoinValue_Multiplier = 1f + bonusCoinsUpgrade_LevelValues[bonusCoinsUpgrade_Level];
	}

	public void SetLevelValues_TrickShotUpgrade()
	{
		PlayerStats.Singleton.trickShot_bonusMultiplierPerUnitThrown = trickShotUpgrade_Level_LevelValues[trickShotUpgrade_Level];
	}

	public void SetLevelValues_GrowthRateUpgrade()
	{
		PlayerStats.Singleton.berryGrowthRate_Multiplier = 1f + growthRateUpgrade_Level_LevelValues[growthRateUpgrade_Level];
	}

	public void SetLevelValues_GoldenBerrySpawnRate()
	{
		PlayerStats.Singleton.goldenBerryChance_Curr = goldenBerrySpawnChance_Level_LevelValues[goldenBerrySpawnChance_Level];
	}

	public void SetLevelValues_GoldenBerryMulti()
	{
		PlayerStats.Singleton.goldenBerry_ValueMultiplier_Curr = goldenBerryMulti_Level_LevelValues[goldenBerryMulti_Level];
	}

	public void SetLevelValues_BonusTile()
	{
	}

	public void SetLevelValues_BonusTileXpMulti()
	{
		PlayerStats.Singleton.bonusTile_XpMulti_Curr = bonusTileXpMulti_Level_LevelValues[bonusTileXpMulti_Level];
	}

	public void SetLevelValues_GoldRushDuration()
	{
	}

	public void SetLevelValues_GoldRushCooldown(bool _onGameStart = false)
	{
	}

	public void CalculateBerryCoinValuesAndPopulateList()
	{
		BerryCoinValueList[0] = 1;
		float num = 0.2f;
		for (int i = 1; i < BerryCoinValueList.Count; i++)
		{
			int num2 = BerryCoinValueList[i - 1] * 2;
			int num3 = Mathf.CeilToInt((float)num2 * num);
			num2 += num3;
			BerryCoinValueList[i] = num2;
		}
		BerryCoinValueList[12] = -666;
	}
}
