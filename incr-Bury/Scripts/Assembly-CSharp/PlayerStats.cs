using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public static PlayerStats Singleton;

	public Action OnStarOrbsChanged_Action;

	[Header("Currencies")]
	public int money;

	public int money_Held;

	public int seeds;

	public int starOrbs;

	public int reimbursementStars;

	[Header("Dirt Patch")]
	public int dirtPatch_NumOfPurchased;

	public int dirtPatch_NumPlaced;

	[Header("Conveyor Belt")]
	public int conveyorBelt_NumOfPacksPurchased;

	public int conveyorBelt_NumOfBeltsPerPack;

	public int conveyorBelt_NumOfIndividualConveyorBeltsOwned;

	public int conveyorBelt_NumPlaced;

	[Header("Trampolines")]
	public bool trampoline_Unlocked;

	public int trampolines_NumOfPurchased;

	public int trampolines_NumPlaced;

	[Header("Blender")]
	public int blenders_NumOfPurchased;

	public int blenders_NumPlaced;

	[Header("Upgrades")]
	public float berryGrowthRate_Multiplier;

	public float berryCoinValue_Multiplier;

	[Header("Turtle")]
	public float turtleEatCooldown;

	public float turtleRotateSpeed;

	[Header("Piggy Bank")]
	public bool piggyBank_Unlocked;

	public int piggyBank_Limit;

	public int piggyBank_CurrentlyStored;

	[Header("Seed Spawning")]
	public float seedSpawnChance_Starting;

	public float seedSpawnChance_IncreasePerFail;

	public float seedSpawnChance_Current;

	public float seedSpawnChance_Max;

	public int seedSpawnGuaranteedIn;

	[Header("Trick Shots")]
	public float trickShot_bonusMultiplierPerUnitThrown;

	[Header("Golden Berry")]
	public float goldenBerryChance_Curr;

	public float goldenBerry_ValueMultiplier_Curr;

	[Header("Bonus Tiles")]
	public int bonusTile_XpMulti_Curr;

	[Header("Gold Rush")]
	public bool goldRush_Unlocked;

	public float goldRush_Duration_Max;

	public float goldRush_Cooldown_Max;

	public float goldRush_BonusGrowthRate;

	public bool hasUsedThisRound_GoldRush;

	[Header("Big Hole")]
	public bool bigHole_Unlocked;

	public float bigHole_Duration_Max;

	public float bigHole_Cooldown_Max;

	public float bigHole_Size;

	public bool hasUsedThisRound_BigHole;

	[Header("Blender")]
	public int blender_BerryToSmoothieAmt;

	public int blender_BerriesGrindedPerSeed;

	[Header("Hole Growth")]
	public int holeGrowth_Level;

	public int holeGrowthObjects_SpawnedCount;

	[Header("Vacuum")]
	public bool vacuum_Unlocked;

	public int vacuumCapacity;

	public float vacShootDowntime_Max;

	[Header("Broom")]
	public bool broom_Unlocked;

	[Header("Berry Flower")]
	public bool bushUpgrade_Unlocked;

	public bool treeUpgrade_Unlocked;

	[Header("Conveyor Belt Upgrade")]
	public bool conveyorBelt_Unlocked;

	[Header("Berry Totals")]
	public int berryTotal_Blueberry;

	public int berryTotal_Raspberry;

	public int berryTotal_Strawberry;

	public int berryTotal_Kiwi;

	public int berryTotal_Plum;

	public int berryTotal_Apple;

	public int berryTotal_Pear;

	public int berryTotal_Peach;

	public int berryTotal_Banana;

	public int berryTotal_Pineapple;

	public int berryTotal_Watermelon;

	public int berryTotal_Pumpkin;

	public long berryTotal_Total;

	[Header("Deposited Berry Total")]
	public int[] deposited_BerryTotals = new int[12];

	public int deposited_SmoothieTotal;

	[Header("Auto Coin Pick Up Sphere")]
	public bool autoCoinPickup_Unlocked;

	public int autoCoinPickUp_RadiusLevel;

	public float autoCoinPickUp_Radius_Current;

	public List<float> autoCoinPickUp_RadiusLevel_Values;

	[Header("Void Box Spawns")]
	public int numOfVoidBoxSpawnsTotal;

	public int numOfVoidBoxesDepositedInHole;

	public int bonusVoidBoxesFromFossilsSpawnedCurrently;

	[Header("Cultist Capacity")]
	public int cultistCapacity_Curr;

	[Header("Hole Move")]
	public bool holeMove_IsUnlocked;

	public int holeMoveJuiceCapacity_Curr;

	public float holeMoveSpeed_Curr;

	[Header("Cultists Combined Totals")]
	public List<int> cultistsCreated_TotalsByType;

	[Header("Blender Bot")]
	public bool blenderBot_Unlocked;

	[Header("Round Timer")]
	public float roundTimerLength;

	[Header("Star Orb Generator")]
	public bool starOrbGen_IsUnlocked;

	public int starOrbGen_SpawnsPerRound;

	public int starOrbGen_Rando_Level;

	public int starOrbGen_Rando_Limit_Max;

	public int starOrbGen_Rando_Limit_Min;

	public int starOrbGen_Rando_IncreasePerLevel;

	public int starOrbGen_Rando_Limit_Curr;

	public int starOrgGen_Rando_CurrentRoll_Floor;

	[Header("Void Box Carry Over POS")]
	public bool wasPreviousVoidBoxDugUp;

	public Vector3 voidBoxPositionThisRound;

	[Header("FailSafes")]
	public List<int> starOrbTypes_SpawnedButNotDeposited;

	[Header("Bubble Jetpack")]
	public bool bubbleJetpack_Unlocked;

	[Header("Pinata")]
	public bool pinata_Unlocked;

	public int pinata_ZoneSpawnTier;

	[Header("Auto-Pop Star Orbs")]
	public bool autoPopStarOrbs_Unlocked;

	[Header("StarWand")]
	public bool StarWand_Unlocked;

	[Header("Sledgehammer")]
	public bool SledgeHammer_Unlocked;

	public int SledgeHammer_Tier;

	[Header("Rewinds")]
	public int rewind_TimesUsed;

	[Header("Popgun")]
	public bool popgun_Unlocked;

	[Header("Star Key")]
	public bool starKey_Unlocked;

	[Header("Misc Stats")]
	public int highestBerryTierGrown;

	public int totalRounds;

	public long totalMoneyEarned;

	public long totalStarOrbsEarned;

	public long totalMoneySpent;

	public long totalStarOrbsSpent;

	public long totalMoney_Dropped;

	public bool fellInHoleThisRound;

	public float totalTimePlayed;

	public int wallsBroken;

	[Header("Radio")]
	public bool radio_IsUnlocked;

	public bool radio_IsTurnedOn;

	public int radio_ChannelIndex;

	[Header("Berry Picker")]
	public bool berryPicker_IsUnlocked;

	[Header("Juiced")]
	public float juiced_GrowthMultiplier;

	[Header("Tutorials")]
	public bool disableTutorials;

	[Header("Endings")]
	public bool ending_Happiness;

	public bool ending_Chainsaw;

	public bool ending_Gnome;

	public bool ending_BelladonnaBuddy;

	private int debugPuzzleSolveIndex;

	[Header("Confession Related")]
	public bool hasListenedToConfession;

	public bool hasOpenedTrash;

	[Header("Read/Unread Computer Messages")]
	public bool pc_HasRead_Website_BarryMissing;

	public bool pc_HasRead_Website_HallowayHeights;

	public bool pc_HasRead_Website_Arson;

	public bool pc_HasRead_Website_Dissappearances;

	public bool pc_HasRead_Email_SecurityCodes;

	public bool pc_HasRead_Email_ProductionConcerns;

	public bool pc_HasRead_Email_StudioDisregard;

	public bool pc_HasRead_Email_Meeting;

	public bool pc_HasRead_Email_PoliceRansom;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Singleton = this;
		InitializeCultistCreatedTypeList();
		InitializeStarOrbsSpawnedButNotDepositedList();
	}

	private void Start()
	{
		ResetSeedDropPsuedoRandom();
	}

	private void Update()
	{
		if (!Application.isEditor)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			IncreaseMoney_Banked(1000000);
			IncreaseStarOrbs(1000);
			IncreaseMoney_Held(100);
			berryTotal_Blueberry = 666;
			berryTotal_Raspberry = 666;
			berryTotal_Strawberry = 666;
			berryTotal_Kiwi = 666;
			berryTotal_Plum = 666;
			berryTotal_Apple = 666;
			berryTotal_Pear = 666;
			berryTotal_Peach = 666;
			berryTotal_Banana = 666;
			berryTotal_Pineapple = 666;
			berryTotal_Watermelon = 666;
			berryTotal_Pumpkin = 666;
			holeMove_IsUnlocked = true;
			holeMoveJuiceCapacity_Curr = 500;
			GameManager.Singleton.holeMoveJuice_Curr = holeMoveJuiceCapacity_Curr;
			GameManager.Singleton.roundTimer_Curr = 8000f;
			GameManager.Singleton.ResetAbilityCooldowns();
			GameManager.Singleton.DisableFirstRoundPlayerOnlyHoleCollider();
		}
		if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			try
			{
				PuzzleManager.Singleton.SetBlackStarOrbState_Collected(debugPuzzleSolveIndex);
				debugPuzzleSolveIndex++;
			}
			catch
			{
				Debug.Log("no more puzzles for debug solve!");
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			bubbleJetpack_Unlocked = true;
			GameManager.Singleton.Debug_SpawnHammer();
			GameManager.Singleton.Debug_SpawnStarKey();
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			GameManager.Singleton.roundTimer_Curr = 5f;
		}
	}

	public void SpendSeeds(int _amount)
	{
		seeds -= _amount;
		if (seeds < 0)
		{
			seeds = 0;
		}
	}

	public void IncreaseSeeds(int _amount)
	{
		seeds += _amount;
		HudManager.Singleton.PlayFeedback_SeedHeldPickUp();
	}

	public void IncreaseMoney_Banked(int _amount)
	{
		if ((long)money + (long)_amount > int.MaxValue)
		{
			money = int.MaxValue;
		}
		else
		{
			money += _amount;
		}
		HudManager.Singleton.PlayFeedback_MoneyBanked();
		totalMoneyEarned += _amount;
	}

	public void IncreaseMoney_Held(int _amount)
	{
		if ((long)money_Held + (long)_amount > int.MaxValue)
		{
			money_Held = int.MaxValue;
		}
		else
		{
			money_Held += _amount;
		}
		HudManager.Singleton.PlayFeedback_MoneyHeldPickUp();
	}

	public void SpendMoney(int _amount)
	{
		money -= _amount;
		if (money < 0)
		{
			money = 0;
		}
		totalMoneySpent += _amount;
	}

	public void IncreaseStarOrbs(int _amt)
	{
		starOrbs += _amt;
		HudManager.Singleton.PlayFeedback_SeedHeldPickUp();
		StartCoroutine(WaitAFewFrameThen_CallStarOrbsChangedAction());
		totalStarOrbsEarned += _amt;
	}

	public void SpendStarOrbs(int _amt)
	{
		starOrbs -= _amt;
		StartCoroutine(WaitAFewFrameThen_CallStarOrbsChangedAction());
		totalStarOrbsSpent += _amt;
	}

	private IEnumerator WaitAFewFrameThen_CallStarOrbsChangedAction()
	{
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		OnStarOrbsChanged_Action?.Invoke();
	}

	public void AddMoneyToPiggyBank(int _amount)
	{
		if ((long)piggyBank_CurrentlyStored + (long)_amount > int.MaxValue)
		{
			piggyBank_CurrentlyStored = int.MaxValue;
		}
		else
		{
			piggyBank_CurrentlyStored += _amount;
		}
		HudManager.Singleton.PlayFeedback_PiggyBankPickUp();
		if (piggyBank_Limit != -1 && piggyBank_CurrentlyStored > piggyBank_Limit)
		{
			piggyBank_CurrentlyStored = piggyBank_Limit;
		}
	}

	public bool RollForSeedDrop()
	{
		if (seedSpawnGuaranteedIn > 0)
		{
			seedSpawnGuaranteedIn--;
			if (seedSpawnGuaranteedIn == 0)
			{
				ResetSeedDropPsuedoRandom();
				return true;
			}
		}
		if (UnityEngine.Random.Range(0f, 100f) <= seedSpawnChance_Current)
		{
			ResetSeedDropPsuedoRandom();
			return true;
		}
		IncreaseSeedPsuedoRandomChance();
		return false;
	}

	private void IncreaseSeedPsuedoRandomChance()
	{
		seedSpawnChance_Current += seedSpawnChance_IncreasePerFail;
		if (seedSpawnChance_Current > seedSpawnChance_Max)
		{
			seedSpawnChance_Current = seedSpawnChance_Max;
		}
	}

	private void ResetSeedDropPsuedoRandom()
	{
		seedSpawnChance_Current = seedSpawnChance_Starting;
	}

	public void CalculateNumberOfIndividualConveyorBeltsOwned()
	{
		conveyorBelt_NumOfIndividualConveyorBeltsOwned = conveyorBelt_NumOfPacksPurchased * conveyorBelt_NumOfBeltsPerPack;
	}

	public void AddToCultistTotalCount(int _berryTier)
	{
		if (_berryTier != 12)
		{
			cultistsCreated_TotalsByType[_berryTier]++;
		}
	}

	public void AddSpawnedButNotDepositedStarOrb(int _orbEnumIndex)
	{
		starOrbTypes_SpawnedButNotDeposited[_orbEnumIndex]++;
	}

	public void RemoveOrbFromSpawnedButNotDeposited(int _orbEnumIndex)
	{
		if (starOrbTypes_SpawnedButNotDeposited[_orbEnumIndex] > 0)
		{
			starOrbTypes_SpawnedButNotDeposited[_orbEnumIndex]--;
		}
	}

	private void InitializeCultistCreatedTypeList()
	{
		cultistsCreated_TotalsByType = new List<int>();
		for (int i = 0; i < 12; i++)
		{
			cultistsCreated_TotalsByType.Add(0);
		}
	}

	private void InitializeStarOrbsSpawnedButNotDepositedList()
	{
		starOrbTypes_SpawnedButNotDeposited = new List<int>();
		for (int i = 0; i < Enum.GetValues(typeof(StarOrbsToSpawnWhenDeposited)).Length; i++)
		{
			starOrbTypes_SpawnedButNotDeposited.Add(0);
		}
	}

	public void UsedBerryBlitz_SetCooldownToMax()
	{
		GameManager.Singleton.goldRush_Cooldown_Curr = goldRush_Cooldown_Max;
	}

	public void UsedBigHole_SetCooldownToMax()
	{
		GameManager.Singleton.bigHole_Cooldown_Curr = bigHole_Cooldown_Max;
	}

	public void RoundStarted_TickAbilityCooldownsByOne()
	{
		hasUsedThisRound_BigHole = false;
		hasUsedThisRound_GoldRush = false;
		if (GameManager.Singleton.goldRush_Cooldown_Curr > goldRush_Cooldown_Max)
		{
			GameManager.Singleton.goldRush_Cooldown_Curr = goldRush_Cooldown_Max;
		}
		if (GameManager.Singleton.bigHole_Cooldown_Curr > bigHole_Cooldown_Max)
		{
			GameManager.Singleton.bigHole_Cooldown_Curr = bigHole_Cooldown_Max;
		}
	}

	public void IncreaseWallsBrokenStat()
	{
		wallsBroken++;
		if (wallsBroken > 0 && !AchievementHelper.IsAchievementUnlocked("ACH_BreakWalls_1"))
		{
			AchievementHelper.UnlockAchievement("ACH_BreakWalls_1");
		}
		if (wallsBroken >= 100 && !AchievementHelper.IsAchievementUnlocked("ACH_BreakWalls_100"))
		{
			AchievementHelper.UnlockAchievement("ACH_BreakWalls_100");
		}
	}
}
