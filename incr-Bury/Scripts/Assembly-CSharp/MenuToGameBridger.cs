using UnityEngine;

public class MenuToGameBridger : MonoBehaviour
{
	public static MenuToGameBridger Singleton;

	public bool loadDataOnNextGameSceneLoad;

	public SaveLoadManager.SavedPlayerData duplicated_PlayerData_ForEndResultScreen;

	public string endingCompletedString = "X";

	public bool comingBackToMainMenuFromTrueEnding;

	public bool comingBackToMainMenuFromBelladonnaEnding;

	public bool comingBackToMainMenuFromGnomeEnding;

	public bool comingBackToMainMenuFromPigEnding;

	public bool enteredCreditsFromMainMenu;

	public int activeSaveGameSlot;

	public NGPlusModifiers activeSaveGame_NGPlusModifiers;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(this);
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
			Object.DontDestroyOnLoad(this);
		}
	}

	private void Start()
	{
		ResetNgPlusMods();
	}

	private void Update()
	{
	}

	public void GrabAndStoreSavedPlayerData()
	{
		if ((bool)SaveLoadManager.Singleton)
		{
			duplicated_PlayerData_ForEndResultScreen = SaveLoadManager.Singleton.CreateNewPlayerData();
		}
	}

	public void HundoPercentCompletionAchievementCheck()
	{
		if (AchievementHelper.IsAchievementUnlocked("ACH_Ending_Key") && AchievementHelper.IsAchievementUnlocked("ACH_Ending_True") && AchievementHelper.IsAchievementUnlocked("ACH_Ending_Belladonna") && AchievementHelper.IsAchievementUnlocked("ACH_Ending_Gnome") && AchievementHelper.IsAchievementUnlocked("ACH_AllUpgrades") && AchievementHelper.IsAchievementUnlocked("ACH_Cassettes_All") && AchievementHelper.IsAchievementUnlocked("ACH_DepositProps_All") && AchievementHelper.IsAchievementUnlocked("ACH_MaxHoleSize") && !AchievementHelper.IsAchievementUnlocked("ACH_100Percent"))
		{
			AchievementHelper.UnlockAchievement("ACH_100Percent");
		}
	}

	public void ResetNgPlusMods()
	{
		activeSaveGame_NGPlusModifiers.ngMod_CutSceneSkip = false;
		activeSaveGame_NGPlusModifiers.ngMod_FastAbilityCooldowns = false;
		activeSaveGame_NGPlusModifiers.ngMod_FromStartAbilities = false;
		activeSaveGame_NGPlusModifiers.ngMod_FromStartAutoCoinPickUp = false;
		activeSaveGame_NGPlusModifiers.ngMod_FromStartHammerAndChainsaw = false;
		activeSaveGame_NGPlusModifiers.ngMod_FromStartStarPopper = false;
		activeSaveGame_NGPlusModifiers.ngMod_FromStartTrampoline = false;
		activeSaveGame_NGPlusModifiers.ngMod_GrowthBoost = false;
		activeSaveGame_NGPlusModifiers.ngMod_InfiniteDaytime = false;
		activeSaveGame_NGPlusModifiers.ngMod_InfiniteHoleMove = false;
		activeSaveGame_NGPlusModifiers.ngMod_NoWalls = false;
	}

	public void SetNGPlusModsFromData(SaveSlotUI _slot)
	{
		Debug.Log("LOADING MODS WEE WOO");
		activeSaveGame_NGPlusModifiers.ngMod_CutSceneSkip = _slot.ngMod_CutSceneSkip;
		activeSaveGame_NGPlusModifiers.ngMod_FastAbilityCooldowns = _slot.ngMod_FastAbilityCooldowns;
		activeSaveGame_NGPlusModifiers.ngMod_FromStartAbilities = _slot.ngMod_FromStartAbilities;
		activeSaveGame_NGPlusModifiers.ngMod_FromStartAutoCoinPickUp = _slot.ngMod_FromStartAutoCoinPickUp;
		activeSaveGame_NGPlusModifiers.ngMod_FromStartHammerAndChainsaw = _slot.ngMod_FromStartHammerAndChainsaw;
		activeSaveGame_NGPlusModifiers.ngMod_FromStartStarPopper = _slot.ngMod_FromStartStarPopper;
		activeSaveGame_NGPlusModifiers.ngMod_FromStartTrampoline = _slot.ngMod_FromStartTrampoline;
		activeSaveGame_NGPlusModifiers.ngMod_GrowthBoost = _slot.ngMod_GrowthBoost;
		activeSaveGame_NGPlusModifiers.ngMod_InfiniteDaytime = _slot.ngMod_InfiniteDaytime;
		activeSaveGame_NGPlusModifiers.ngMod_InfiniteHoleMove = _slot.ngMod_InfiniteHoleMove;
		activeSaveGame_NGPlusModifiers.ngMod_NoWalls = _slot.ngMod_NoWalls;
	}

	public bool HasNGPlusModsOn()
	{
		if (activeSaveGame_NGPlusModifiers.ngMod_CutSceneSkip || activeSaveGame_NGPlusModifiers.ngMod_FastAbilityCooldowns || activeSaveGame_NGPlusModifiers.ngMod_FromStartAbilities || activeSaveGame_NGPlusModifiers.ngMod_FromStartAutoCoinPickUp || activeSaveGame_NGPlusModifiers.ngMod_FromStartHammerAndChainsaw || activeSaveGame_NGPlusModifiers.ngMod_FromStartStarPopper || activeSaveGame_NGPlusModifiers.ngMod_FromStartTrampoline || activeSaveGame_NGPlusModifiers.ngMod_GrowthBoost || activeSaveGame_NGPlusModifiers.ngMod_InfiniteDaytime || activeSaveGame_NGPlusModifiers.ngMod_InfiniteHoleMove || activeSaveGame_NGPlusModifiers.ngMod_NoWalls)
		{
			return true;
		}
		return false;
	}
}
