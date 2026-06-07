using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
	[Serializable]
	public class SavedPlayerData
	{
		public int saved_Money;

		public int saved_StarOrbs;

		public int saved_ReimbursementStars;

		public int saved_HoleGrowthLevel;

		public int saved_VoidBoxesDepositedInHole;

		public bool saved_VoidBoxWasDugUpLastRound;

		public Vector3 saved_VoidBoxCarryOverPosition;

		public float saved_AbilityCD_BerryBlitz;

		public float saved_AbilityCD_BigHole;

		public List<BerryCultist_Info> saved_spawnedCultistsInfo = new List<BerryCultist_Info>();

		public List<int> saved_CultistsCreated_TotalsByType = new List<int>(12);

		public List<int> saved_BerryDepositedTotals = new List<int>(12);

		public List<bool> saved_UpgradeTreeUnlocks = new List<bool>();

		public List<int> saved_StarOrbsSpawnedButNotDeposited = new List<int>();

		public List<bool> saved_MilestoneObjectsList = new List<bool>();

		public List<bool> saved_WallsList = new List<bool>();

		public int saved_NumOfRewinds;

		public bool saved_RadioTurnedOn;

		public int saved_RadioChannel;

		public int saved_StarOrbGenLevel;

		public int saved_StarOrbGen_CurrRollFloor;

		public bool saved_idolCompleted_Blueberry;

		public bool saved_idolCompleted_Raspberry;

		public bool saved_idolCompleted_Strawberry;

		public bool saved_idolCompleted_Kiwi;

		public bool saved_idolCompleted_Plum;

		public bool saved_idolCompleted_Apple;

		public bool saved_idolCompleted_Pear;

		public bool saved_idolCompleted_Peach;

		public bool saved_idolCompleted_Banana;

		public bool saved_idolCompleted_Pineapple;

		public bool saved_idolCompleted_Watermelon;

		public bool saved_idolCompleted_Pumpkin;

		public int saved_HighestBerryTierGrown;

		public int saved_TotalRounds;

		public long saved_totalMoney_Earned;

		public long saved_totalStarOrbs_Earned;

		public long saved_totalMoney_Spent;

		public long saved_totalStarOrbs_Spent;

		public long saved_totalMoney_Dropped;

		public float saved_totalTimePlayed;

		public int saved_wallsBroken;

		public int saved_totalGrown_Blueberry;

		public int saved_totalGrown_Raspberry;

		public int saved_totalGrown_Strawberry;

		public int saved_totalGrown_Kiwi;

		public int saved_totalGrown_Plum;

		public int saved_totalGrown_Apple;

		public int saved_totalGrown_Pear;

		public int saved_totalGrown_Peach;

		public int saved_totalGrown_Banana;

		public int saved_totalGrown_Pineapple;

		public int saved_totalGrown_Watermelon;

		public int saved_totalGrown_Pumpkin;

		public long saved_TotalGrown_TotalBerries;

		public bool saved_DisableTutorials;

		public List<BlackStarOrbState> saved_BlackStarOrbStates = new List<BlackStarOrbState>();

		public bool saved_PcUnlocked;

		public int saved_BerryPickerState;

		public float saved_CurrentJuicedAmt;

		public bool saved_ending_Happiness;

		public bool saved_ending_Chainsaw;

		public bool saved_ending_Gnome;

		public bool saved_ending_BelladonnaBuddy;

		public bool saved_HasListenedToConfession;

		public bool saved_HasOpenedTrash;

		public bool saved_tapeCollected_1;

		public bool saved_tapeCollected_2;

		public bool saved_tapeCollected_3;

		public bool saved_tapeCollected_4;

		public bool saved_tapeCollected_5;

		public bool saved_tapeCollected_6;

		public bool saved_tapeCollected_7;

		public bool saved_tapeCollected_8;

		public bool saved_tapeCollected_9;

		public bool saved_tapeCollected_10;

		public bool saved_tapeCollected_11;

		public bool saved_tapeCollected_12;

		public bool saved_tapeCollected_13;

		public bool saved_pc_HasRead_Website_BarryMissing;

		public bool saved_pc_HasRead_Website_HallowayHeights;

		public bool saved_pc_HasRead_Website_Arson;

		public bool saved_pc_HasRead_Website_Dissappearances;

		public bool saved_pc_HasRead_Email_SecurityCodes;

		public bool saved_pc_HasRead_Email_ProductionConcerns;

		public bool saved_pc_HasRead_Email_StudioDisregard;

		public bool saved_pc_HasRead_Email_Meeting;

		public bool saved_pc_HasRead_Email_PoliceRansom;
	}

	[Serializable]
	public class SaveSlotInfo
	{
		public string lastPlayedDateTime;

		public string playtime;

		public int roundNumber;

		public int upgrades_Total;

		public int upgrades_Unlocked;

		public bool ending_Happiness;

		public bool ending_Chainsaw;

		public bool ending_Gnome;

		public bool ending_BelladonnaBuddy;

		public bool ngMod_NoWalls;

		public bool ngMod_GrowthBoost;

		public bool ngMod_InfiniteHoleMove;

		public bool ngMod_FastAbilityCooldowns;

		public bool ngMod_FromStartTrampoline;

		public bool ngMod_FromStartStarPopper;

		public bool ngMod_FromStartAbilities;

		public bool ngMod_FromStartAutoCoinPickUp;

		public bool ngMod_FromStartHammerAndChainsaw;

		public bool ngMod_InfiniteDaytime;

		public bool ngMod_CutSceneSkip;
	}

	[Serializable]
	public class GlobalSaveData
	{
		public bool ngPlusUnlocked;
	}

	[Serializable]
	public class SavedBuildTileInfo
	{
		public BuildableIdentity identity;

		public bool isBuiltOn;

		public bool isBonusSpot;

		public Vector3 tilePosition;

		public Vector3 tileRotation;

		public int dirtPatch_currentBerryTier;

		public int dirtPatch_berriesProduced;

		public int dirtPatch_xp;
	}

	private Coroutine startingNextRoundCoRoutine;

	public static SaveLoadManager Singleton;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(this);
		}
		else
		{
			Singleton = this;
		}
	}

	public SavedPlayerData CreateNewPlayerData()
	{
		SavedPlayerData savedPlayerData = new SavedPlayerData();
		savedPlayerData.saved_Money = PlayerStats.Singleton.money;
		savedPlayerData.saved_StarOrbs = PlayerStats.Singleton.starOrbs;
		savedPlayerData.saved_ReimbursementStars = PlayerStats.Singleton.reimbursementStars;
		savedPlayerData.saved_HoleGrowthLevel = PlayerStats.Singleton.holeGrowth_Level;
		savedPlayerData.saved_VoidBoxesDepositedInHole = PlayerStats.Singleton.numOfVoidBoxesDepositedInHole;
		savedPlayerData.saved_AbilityCD_BerryBlitz = GameManager.Singleton.goldRush_Cooldown_Curr;
		savedPlayerData.saved_AbilityCD_BigHole = GameManager.Singleton.bigHole_Cooldown_Curr;
		savedPlayerData.saved_VoidBoxWasDugUpLastRound = PlayerStats.Singleton.wasPreviousVoidBoxDugUp;
		savedPlayerData.saved_VoidBoxCarryOverPosition = PlayerStats.Singleton.voidBoxPositionThisRound;
		for (int i = 0; i < 12; i++)
		{
			savedPlayerData.saved_CultistsCreated_TotalsByType.Add(0);
			savedPlayerData.saved_BerryDepositedTotals.Add(0);
		}
		foreach (BerryCultist_AI spawnedCultist in GameManager.Singleton.spawnedCultists)
		{
			BerryCultist_Info berryCultist_Info = new BerryCultist_Info(spawnedCultist.GetBerryTier(), spawnedCultist.cultistsName);
			if (berryCultist_Info.tier == 12)
			{
				berryCultist_Info.tier = 11;
			}
			savedPlayerData.saved_spawnedCultistsInfo.Add(berryCultist_Info);
		}
		for (int j = 0; j < PlayerStats.Singleton.cultistsCreated_TotalsByType.Count; j++)
		{
			savedPlayerData.saved_CultistsCreated_TotalsByType[j] = PlayerStats.Singleton.cultistsCreated_TotalsByType[j];
		}
		for (int k = 0; k < PlayerStats.Singleton.deposited_BerryTotals.Length; k++)
		{
			savedPlayerData.saved_BerryDepositedTotals[k] = PlayerStats.Singleton.deposited_BerryTotals[k];
		}
		for (int l = 0; l < UpgradeTreeManager.Singleton.allUpgradeTreeButtons.Count; l++)
		{
			savedPlayerData.saved_UpgradeTreeUnlocks.Add(item: false);
		}
		for (int m = 0; m < UpgradeTreeManager.Singleton.allUpgradeTreeButtons.Count; m++)
		{
			savedPlayerData.saved_UpgradeTreeUnlocks[m] = UpgradeTreeManager.Singleton.allUpgradeTreeButtons[m].isUnlocked;
		}
		savedPlayerData.saved_StarOrbsSpawnedButNotDeposited = new List<int>(Enum.GetValues(typeof(StarOrbsToSpawnWhenDeposited)).Length);
		for (int n = 0; n < Enum.GetValues(typeof(StarOrbsToSpawnWhenDeposited)).Length; n++)
		{
			savedPlayerData.saved_StarOrbsSpawnedButNotDeposited.Add(0);
		}
		for (int num = 0; num < Enum.GetValues(typeof(StarOrbsToSpawnWhenDeposited)).Length; num++)
		{
			savedPlayerData.saved_StarOrbsSpawnedButNotDeposited[num] = PlayerStats.Singleton.starOrbTypes_SpawnedButNotDeposited[num];
		}
		for (int num2 = 0; num2 < GameManager.Singleton.milestoneObjects_MasterList.Count; num2++)
		{
			savedPlayerData.saved_MilestoneObjectsList.Add(GameManager.Singleton.milestoneObjects_MasterList_Bools[num2]);
		}
		for (int num3 = 0; num3 < GameManager.Singleton.walls_MasterList.Count; num3++)
		{
			savedPlayerData.saved_WallsList.Add(GameManager.Singleton.walls_MasterList_Bools[num3]);
		}
		foreach (BlackStarOrbState blackStarOrb_States in PuzzleManager.Singleton.blackStarOrb_StatesList)
		{
			savedPlayerData.saved_BlackStarOrbStates.Add(blackStarOrb_States);
		}
		savedPlayerData.saved_NumOfRewinds = PlayerStats.Singleton.rewind_TimesUsed;
		savedPlayerData.saved_RadioTurnedOn = PlayerStats.Singleton.radio_IsTurnedOn;
		savedPlayerData.saved_RadioChannel = PlayerStats.Singleton.radio_ChannelIndex;
		savedPlayerData.saved_CurrentJuicedAmt = GameManager.Singleton.juiced_Amount_Curr;
		savedPlayerData.saved_HighestBerryTierGrown = PlayerStats.Singleton.highestBerryTierGrown;
		savedPlayerData.saved_TotalRounds = PlayerStats.Singleton.totalRounds;
		savedPlayerData.saved_totalMoney_Earned = PlayerStats.Singleton.totalMoneyEarned;
		savedPlayerData.saved_totalStarOrbs_Earned = PlayerStats.Singleton.totalStarOrbsEarned;
		savedPlayerData.saved_totalMoney_Spent = PlayerStats.Singleton.totalMoneySpent;
		savedPlayerData.saved_totalStarOrbs_Spent = PlayerStats.Singleton.totalStarOrbsSpent;
		savedPlayerData.saved_totalMoney_Dropped = PlayerStats.Singleton.totalMoney_Dropped;
		savedPlayerData.saved_totalTimePlayed = PlayerStats.Singleton.totalTimePlayed;
		savedPlayerData.saved_wallsBroken = PlayerStats.Singleton.wallsBroken;
		savedPlayerData.saved_totalGrown_Blueberry = PlayerStats.Singleton.berryTotal_Blueberry;
		savedPlayerData.saved_totalGrown_Raspberry = PlayerStats.Singleton.berryTotal_Raspberry;
		savedPlayerData.saved_totalGrown_Strawberry = PlayerStats.Singleton.berryTotal_Strawberry;
		savedPlayerData.saved_totalGrown_Kiwi = PlayerStats.Singleton.berryTotal_Kiwi;
		savedPlayerData.saved_totalGrown_Plum = PlayerStats.Singleton.berryTotal_Plum;
		savedPlayerData.saved_totalGrown_Apple = PlayerStats.Singleton.berryTotal_Apple;
		savedPlayerData.saved_totalGrown_Pear = PlayerStats.Singleton.berryTotal_Pear;
		savedPlayerData.saved_totalGrown_Peach = PlayerStats.Singleton.berryTotal_Peach;
		savedPlayerData.saved_totalGrown_Banana = PlayerStats.Singleton.berryTotal_Banana;
		savedPlayerData.saved_totalGrown_Pineapple = PlayerStats.Singleton.berryTotal_Pineapple;
		savedPlayerData.saved_totalGrown_Watermelon = PlayerStats.Singleton.berryTotal_Watermelon;
		savedPlayerData.saved_totalGrown_Pumpkin = PlayerStats.Singleton.berryTotal_Pumpkin;
		savedPlayerData.saved_TotalGrown_TotalBerries = PlayerStats.Singleton.berryTotal_Total;
		savedPlayerData.saved_StarOrbGenLevel = PlayerStats.Singleton.starOrbGen_Rando_Level;
		savedPlayerData.saved_StarOrbGen_CurrRollFloor = PlayerStats.Singleton.starOrgGen_Rando_CurrentRoll_Floor;
		savedPlayerData.saved_DisableTutorials = PlayerStats.Singleton.disableTutorials;
		savedPlayerData.saved_ending_Happiness = PlayerStats.Singleton.ending_Happiness;
		savedPlayerData.saved_ending_Chainsaw = PlayerStats.Singleton.ending_Chainsaw;
		savedPlayerData.saved_ending_Gnome = PlayerStats.Singleton.ending_Gnome;
		savedPlayerData.saved_ending_BelladonnaBuddy = PlayerStats.Singleton.ending_BelladonnaBuddy;
		savedPlayerData.saved_HasListenedToConfession = PlayerStats.Singleton.hasListenedToConfession;
		savedPlayerData.saved_HasOpenedTrash = PlayerStats.Singleton.hasOpenedTrash;
		return savedPlayerData;
	}

	public SaveSlotInfo CreateNewSaveSlotInfo()
	{
		SaveSlotInfo obj = new SaveSlotInfo
		{
			lastPlayedDateTime = GetFriendlyDateTime(),
			playtime = FormatHelper.FormatTimeSmart(PlayerStats.Singleton.totalTimePlayed),
			roundNumber = PlayerStats.Singleton.totalRounds
		};
		Vector2 unlockedAndTotalUpgradeAmounts = UpgradeTreeManager.Singleton.GetUnlockedAndTotalUpgradeAmounts();
		obj.upgrades_Unlocked = Mathf.RoundToInt(unlockedAndTotalUpgradeAmounts.x);
		obj.upgrades_Total = Mathf.RoundToInt(unlockedAndTotalUpgradeAmounts.y);
		obj.ending_Happiness = PlayerStats.Singleton.ending_Happiness;
		obj.ending_Chainsaw = PlayerStats.Singleton.ending_Chainsaw;
		obj.ending_Gnome = PlayerStats.Singleton.ending_Gnome;
		obj.ending_BelladonnaBuddy = PlayerStats.Singleton.ending_BelladonnaBuddy;
		obj.ngMod_NoWalls = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_NoWalls;
		obj.ngMod_GrowthBoost = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_GrowthBoost;
		obj.ngMod_InfiniteHoleMove = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_InfiniteHoleMove;
		obj.ngMod_FastAbilityCooldowns = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FastAbilityCooldowns;
		obj.ngMod_FromStartTrampoline = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartTrampoline;
		obj.ngMod_FromStartStarPopper = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartStarPopper;
		obj.ngMod_FromStartAbilities = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartAbilities;
		obj.ngMod_FromStartAutoCoinPickUp = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartAutoCoinPickUp;
		obj.ngMod_FromStartHammerAndChainsaw = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartHammerAndChainsaw;
		obj.ngMod_InfiniteDaytime = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_InfiniteDaytime;
		obj.ngMod_CutSceneSkip = MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_CutSceneSkip;
		return obj;
	}

	private string GetFriendlyDateTime()
	{
		return DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
	}

	private void LoadSavedValuesIntoTheirRespectiveScripts(SavedPlayerData _loadedData)
	{
		PlayerStats.Singleton.money = _loadedData.saved_Money;
		PlayerStats.Singleton.starOrbs = _loadedData.saved_StarOrbs;
		if (_loadedData.saved_ReimbursementStars > 0)
		{
			PlayerStats.Singleton.starOrbs += _loadedData.saved_ReimbursementStars;
			_loadedData.saved_ReimbursementStars = 0;
			PlayerStats.Singleton.reimbursementStars = 0;
		}
		PlayerStats.Singleton.holeGrowth_Level = _loadedData.saved_HoleGrowthLevel;
		PlayerStats.Singleton.numOfVoidBoxesDepositedInHole = _loadedData.saved_VoidBoxesDepositedInHole;
		GameManager.Singleton.ResetRoundTimer();
		GameManager.Singleton.goldRush_Cooldown_Curr = _loadedData.saved_AbilityCD_BerryBlitz;
		GameManager.Singleton.bigHole_Cooldown_Curr = _loadedData.saved_AbilityCD_BigHole;
		PlayerStats.Singleton.wasPreviousVoidBoxDugUp = _loadedData.saved_VoidBoxWasDugUpLastRound;
		PlayerStats.Singleton.voidBoxPositionThisRound = _loadedData.saved_VoidBoxCarryOverPosition;
		if (GameManager.Singleton.spawnedCultists.Count > 0)
		{
			for (int num = GameManager.Singleton.spawnedCultists.Count - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(GameManager.Singleton.spawnedCultists[num]);
			}
			GameManager.Singleton.spawnedCultists.Clear();
		}
		foreach (BerryCultist_Info item in _loadedData.saved_spawnedCultistsInfo)
		{
			UpgradeTreeManager.Singleton.SpawnANewCultistFromUpgradeButtonClick(item.tier, _randomizeName: false).cultistsName = item.cultistName;
		}
		int num2 = 0;
		foreach (int item2 in _loadedData.saved_CultistsCreated_TotalsByType)
		{
			PlayerStats.Singleton.cultistsCreated_TotalsByType[num2] = item2;
			num2++;
		}
		int num3 = 0;
		foreach (int saved_BerryDepositedTotal in _loadedData.saved_BerryDepositedTotals)
		{
			PlayerStats.Singleton.deposited_BerryTotals[num3] = saved_BerryDepositedTotal;
			num3++;
		}
		for (int i = 0; i < UpgradeTreeManager.Singleton.allUpgradeTreeButtons.Count; i++)
		{
			UpgradeTreeManager.Singleton.allUpgradeTreeButtons[i].isUnlocked = _loadedData.saved_UpgradeTreeUnlocks[i];
		}
		foreach (UpgradeTreeButton allUpgradeTreeButton in UpgradeTreeManager.Singleton.allUpgradeTreeButtons)
		{
			if (allUpgradeTreeButton.isUnlocked)
			{
				UpgradeTreeManager.Singleton.UnlockUpgrade(allUpgradeTreeButton, _SetValuesAfter: false);
			}
		}
		PlayerStats.Singleton.starOrbTypes_SpawnedButNotDeposited = new List<int>(Enum.GetValues(typeof(StarOrbsToSpawnWhenDeposited)).Length);
		for (int j = 0; j < Enum.GetValues(typeof(StarOrbsToSpawnWhenDeposited)).Length; j++)
		{
			PlayerStats.Singleton.starOrbTypes_SpawnedButNotDeposited.Add(0);
			PlayerStats.Singleton.starOrbTypes_SpawnedButNotDeposited[j] = _loadedData.saved_StarOrbsSpawnedButNotDeposited[j];
		}
		AnomalousMaterial_Manager.Singleton.SetupStarOrbsQueueNotDepositedLastRound();
		for (int k = 0; k < _loadedData.saved_MilestoneObjectsList.Count; k++)
		{
			GameManager.Singleton.milestoneObjects_MasterList_Bools[k] = _loadedData.saved_MilestoneObjectsList[k];
		}
		for (int l = 0; l < _loadedData.saved_WallsList.Count; l++)
		{
			GameManager.Singleton.walls_MasterList_Bools[l] = _loadedData.saved_WallsList[l];
		}
		for (int m = 0; m < _loadedData.saved_BlackStarOrbStates.Count; m++)
		{
			PuzzleManager.Singleton.blackStarOrb_StatesList[m] = _loadedData.saved_BlackStarOrbStates[m];
		}
		PlayerStats.Singleton.rewind_TimesUsed = _loadedData.saved_NumOfRewinds;
		PlayerStats.Singleton.radio_IsTurnedOn = _loadedData.saved_RadioTurnedOn;
		PlayerStats.Singleton.radio_ChannelIndex = _loadedData.saved_RadioChannel;
		GameManager.Singleton.juiced_Amount_Curr = _loadedData.saved_CurrentJuicedAmt;
		PlayerStats.Singleton.starOrbGen_Rando_Level = _loadedData.saved_StarOrbGenLevel;
		PlayerStats.Singleton.starOrgGen_Rando_CurrentRoll_Floor = _loadedData.saved_StarOrbGen_CurrRollFloor;
		AnomalousMaterial_Manager.Singleton.CalculateRollTarget();
		PlayerStats.Singleton.highestBerryTierGrown = _loadedData.saved_HighestBerryTierGrown;
		PlayerStats.Singleton.totalRounds = _loadedData.saved_TotalRounds;
		PlayerStats.Singleton.totalMoneyEarned = _loadedData.saved_totalMoney_Earned;
		PlayerStats.Singleton.totalStarOrbsEarned = _loadedData.saved_totalStarOrbs_Earned;
		PlayerStats.Singleton.totalMoneySpent = _loadedData.saved_totalMoney_Spent;
		PlayerStats.Singleton.totalStarOrbsSpent = _loadedData.saved_totalStarOrbs_Spent;
		PlayerStats.Singleton.totalMoney_Dropped = _loadedData.saved_totalMoney_Dropped;
		PlayerStats.Singleton.totalTimePlayed = _loadedData.saved_totalTimePlayed;
		PlayerStats.Singleton.wallsBroken = _loadedData.saved_wallsBroken;
		PlayerStats.Singleton.berryTotal_Blueberry = _loadedData.saved_totalGrown_Blueberry;
		PlayerStats.Singleton.berryTotal_Raspberry = _loadedData.saved_totalGrown_Raspberry;
		PlayerStats.Singleton.berryTotal_Strawberry = _loadedData.saved_totalGrown_Strawberry;
		PlayerStats.Singleton.berryTotal_Kiwi = _loadedData.saved_totalGrown_Kiwi;
		PlayerStats.Singleton.berryTotal_Plum = _loadedData.saved_totalGrown_Plum;
		PlayerStats.Singleton.berryTotal_Apple = _loadedData.saved_totalGrown_Apple;
		PlayerStats.Singleton.berryTotal_Pear = _loadedData.saved_totalGrown_Pear;
		PlayerStats.Singleton.berryTotal_Peach = _loadedData.saved_totalGrown_Peach;
		PlayerStats.Singleton.berryTotal_Banana = _loadedData.saved_totalGrown_Banana;
		PlayerStats.Singleton.berryTotal_Pineapple = _loadedData.saved_totalGrown_Pineapple;
		PlayerStats.Singleton.berryTotal_Watermelon = _loadedData.saved_totalGrown_Watermelon;
		PlayerStats.Singleton.berryTotal_Pumpkin = _loadedData.saved_totalGrown_Pumpkin;
		PlayerStats.Singleton.berryTotal_Total = _loadedData.saved_TotalGrown_TotalBerries;
		PlayerStats.Singleton.disableTutorials = _loadedData.saved_DisableTutorials;
		PlayerStats.Singleton.ending_Happiness = _loadedData.saved_ending_Happiness;
		PlayerStats.Singleton.ending_Chainsaw = _loadedData.saved_ending_Chainsaw;
		PlayerStats.Singleton.ending_Gnome = _loadedData.saved_ending_Gnome;
		PlayerStats.Singleton.ending_BelladonnaBuddy = _loadedData.saved_ending_BelladonnaBuddy;
		PlayerStats.Singleton.hasListenedToConfession = _loadedData.saved_HasListenedToConfession;
		PlayerStats.Singleton.hasOpenedTrash = _loadedData.saved_HasOpenedTrash;
		try
		{
			CassettesManager.Singleton.tapeCollected_1 = _loadedData.saved_tapeCollected_1;
			CassettesManager.Singleton.tapeCollected_2 = _loadedData.saved_tapeCollected_2;
			CassettesManager.Singleton.tapeCollected_3 = _loadedData.saved_tapeCollected_3;
			CassettesManager.Singleton.tapeCollected_4 = _loadedData.saved_tapeCollected_4;
			CassettesManager.Singleton.tapeCollected_5 = _loadedData.saved_tapeCollected_5;
			CassettesManager.Singleton.tapeCollected_6 = _loadedData.saved_tapeCollected_6;
			CassettesManager.Singleton.tapeCollected_7 = _loadedData.saved_tapeCollected_7;
			CassettesManager.Singleton.tapeCollected_8 = _loadedData.saved_tapeCollected_8;
			CassettesManager.Singleton.tapeCollected_9 = _loadedData.saved_tapeCollected_9;
			CassettesManager.Singleton.tapeCollected_10 = _loadedData.saved_tapeCollected_10;
			CassettesManager.Singleton.tapeCollected_11 = _loadedData.saved_tapeCollected_11;
			CassettesManager.Singleton.tapeCollected_12 = _loadedData.saved_tapeCollected_12;
			CassettesManager.Singleton.tapeCollected_13 = _loadedData.saved_tapeCollected_13;
		}
		catch
		{
			Debug.Log("Cassette Data not found in save file. Ignoring!");
		}
		try
		{
			PlayerStats.Singleton.pc_HasRead_Website_BarryMissing = _loadedData.saved_pc_HasRead_Website_BarryMissing;
			PlayerStats.Singleton.pc_HasRead_Website_HallowayHeights = _loadedData.saved_pc_HasRead_Website_HallowayHeights;
			PlayerStats.Singleton.pc_HasRead_Website_Arson = _loadedData.saved_pc_HasRead_Website_Arson;
			PlayerStats.Singleton.pc_HasRead_Website_Dissappearances = _loadedData.saved_pc_HasRead_Website_Dissappearances;
			PlayerStats.Singleton.pc_HasRead_Email_SecurityCodes = _loadedData.saved_pc_HasRead_Email_SecurityCodes;
			PlayerStats.Singleton.pc_HasRead_Email_ProductionConcerns = _loadedData.saved_pc_HasRead_Email_ProductionConcerns;
			PlayerStats.Singleton.pc_HasRead_Email_StudioDisregard = _loadedData.saved_pc_HasRead_Email_StudioDisregard;
			PlayerStats.Singleton.pc_HasRead_Email_Meeting = _loadedData.saved_pc_HasRead_Email_Meeting;
			PlayerStats.Singleton.pc_HasRead_Email_PoliceRansom = _loadedData.saved_pc_HasRead_Email_PoliceRansom;
		}
		catch
		{
			Debug.Log("Failed to load read/unread PC messages. Ignoring!");
		}
		UpgradeTreeManager.Singleton.SetValuesFromUnlocks();
		GameManager.Singleton.ResetRoundStartValues();
	}

	public void SaveGame()
	{
		Debug.Log("saving!");
		string saveJson = JsonUtility.ToJson(CreateNewPlayerData());
		SaveToSlot(MenuToGameBridger.Singleton.activeSaveGameSlot, saveJson);
	}

	public void SaveToSlot(int _slot, string _saveJson)
	{
		if (string.IsNullOrEmpty(_saveJson))
		{
			Debug.LogError($"[Save] Refusing to save empty JSON for slot {_slot}");
			return;
		}
		string text = Path.Combine(Application.persistentDataPath, "Demo");
		Directory.CreateDirectory(text);
		string text2 = Path.Combine(text, $"slot_{_slot}.json");
		string text3 = text2 + ".tmp";
		string destinationBackupFileName = text2 + ".bak";
		try
		{
			using (FileStream fileStream = new FileStream(text3, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				using StreamWriter streamWriter = new StreamWriter(fileStream);
				streamWriter.Write(_saveJson);
				streamWriter.Flush();
				fileStream.Flush(flushToDisk: true);
			}
			if (!File.Exists(text3) || new FileInfo(text3).Length == 0L)
			{
				Debug.LogError($"[Save] Temp save file invalid for slot {_slot}");
				return;
			}
			if (File.Exists(text2))
			{
				File.Replace(text3, text2, destinationBackupFileName);
			}
			else
			{
				File.Move(text3, text2);
			}
			string slotInfo = JsonUtility.ToJson(CreateNewSaveSlotInfo());
			SaveSlotInfoToSlot(_slot, slotInfo);
		}
		catch (Exception)
		{
			Debug.LogError("FAILED TO SAVE GAME, Deleting temp, and ignoring for now. This is a rare occurrance!");
			try
			{
				if (File.Exists(text3))
				{
					File.Delete(text3);
				}
			}
			catch
			{
			}
		}
	}

	public void SaveSlotInfoToSlot(int _slot, string _slotInfo)
	{
		string path = Path.Combine(Application.persistentDataPath, "Demo", $"slot_{_slot}_Info.json");
		Directory.CreateDirectory(Path.GetDirectoryName(path));
		File.WriteAllText(path, _slotInfo);
	}

	public static void SaveGlobalSaveData(bool _ngPlusUnlocked)
	{
		string contents = JsonUtility.ToJson(new GlobalSaveData
		{
			ngPlusUnlocked = _ngPlusUnlocked
		});
		string path = Path.Combine(Application.persistentDataPath, "Demo", "GlobalSaveData.json");
		Directory.CreateDirectory(Path.GetDirectoryName(path));
		File.WriteAllText(path, contents);
	}

	public static void LoadGlobalSaveData()
	{
		string path = Path.Combine(Application.persistentDataPath, "Demo", "GlobalSaveData.json");
		if (!File.Exists(path))
		{
			if ((bool)MainMenuManager.Singleton)
			{
				MainMenuManager.Singleton.ngPlus_Unlocked = false;
			}
			else
			{
				Debug.Log("Must be on main menu to load global saved data!");
			}
			return;
		}
		string text = File.ReadAllText(path);
		if (text != null)
		{
			GlobalSaveData globalSaveData = JsonUtility.FromJson<GlobalSaveData>(text);
			if ((bool)MainMenuManager.Singleton)
			{
				MainMenuManager.Singleton.ngPlus_Unlocked = globalSaveData.ngPlusUnlocked;
			}
			else
			{
				Debug.Log("Must be on main menu to load global saved data!");
			}
		}
	}

	public void LoadSavedGame()
	{
		Debug.Log("loading!");
		string text = LoadFromSlot(MenuToGameBridger.Singleton.activeSaveGameSlot);
		if (text != null)
		{
			SavedPlayerData loadedData = JsonUtility.FromJson<SavedPlayerData>(text);
			LoadSavedValuesIntoTheirRespectiveScripts(loadedData);
			ShopAndUpgradesManager.Singleton.SetAllStatsFromLevels(_onGameStart: true);
		}
		GameManager.Singleton.ChangeGameState(GameManager.GameState.Intro);
	}

	public static string LoadFromSlot(int _slotIndex)
	{
		string path = Path.Combine(Application.persistentDataPath, "Demo", $"slot_{_slotIndex}.json");
		if (!File.Exists(path))
		{
			return null;
		}
		return File.ReadAllText(path);
	}

	private void Start()
	{
		if (MenuToGameBridger.Singleton.loadDataOnNextGameSceneLoad)
		{
			StartCoroutine(WaitASecThenLoadGame());
			MenuToGameBridger.Singleton.loadDataOnNextGameSceneLoad = false;
		}
		else
		{
			GameManager.Singleton.InitializeValuesForNewPlaythroughRoundStart();
			GameManager.Singleton.ChangeGameState(GameManager.GameState.Intro);
		}
	}

	private IEnumerator WaitASecThenLoadGame()
	{
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		LoadSavedGame();
	}

	private void Update()
	{
	}

	public void ReloadLevelAndLoadSavedData()
	{
		MenuToGameBridger.Singleton.loadDataOnNextGameSceneLoad = true;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void SaveDataAndStartNextRound()
	{
		if (startingNextRoundCoRoutine == null)
		{
			PlayerStats.Singleton.totalRounds++;
			CheckForEndOfRoundAchievements();
			startingNextRoundCoRoutine = StartCoroutine(SaveDataAndStartTheNextRound_Coroutine());
		}
		else
		{
			Debug.Log("We've already started resetting for the next round, ignoring!");
		}
	}

	private void CheckForEndOfRoundAchievements()
	{
		if (PlayerStats.Singleton.totalRounds > 0 && !AchievementHelper.IsAchievementUnlocked("ACH_Days1"))
		{
			AchievementHelper.UnlockAchievement("ACH_Days1");
		}
		if (PlayerStats.Singleton.totalRounds >= 10 && !AchievementHelper.IsAchievementUnlocked("ACH_Days10"))
		{
			AchievementHelper.UnlockAchievement("ACH_Days10");
		}
		if (PlayerStats.Singleton.totalRounds >= 100 && !AchievementHelper.IsAchievementUnlocked("ACH_Days100"))
		{
			AchievementHelper.UnlockAchievement("ACH_Days100");
		}
		CheckForAllUpgradesUnlocked_Achievement();
	}

	public void CheckForAllUpgradesUnlocked_Achievement()
	{
		Vector2 unlockedAndTotalUpgradeAmounts = UpgradeTreeManager.Singleton.GetUnlockedAndTotalUpgradeAmounts();
		if (unlockedAndTotalUpgradeAmounts.x == unlockedAndTotalUpgradeAmounts.y && !AchievementHelper.IsAchievementUnlocked("ACH_AllUpgrades"))
		{
			AchievementHelper.UnlockAchievement("ACH_AllUpgrades");
			MenuToGameBridger.Singleton.HundoPercentCompletionAchievementCheck();
		}
	}

	private IEnumerator SaveDataAndStartTheNextRound_Coroutine()
	{
		SaveGame();
		yield return new WaitForSeconds(1f);
		ReloadLevelAndLoadSavedData();
	}
}
