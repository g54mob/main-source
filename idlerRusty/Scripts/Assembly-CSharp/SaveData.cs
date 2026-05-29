using System;
using System.Collections;
using System.IO;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
	public enum FarmType
	{
		GrassyPlains = 0,
		Swamp = 1,
		Desert = 2,
		BlossomForest = 3,
		DesertOasis = 4,
		WinterSnow = 5,
		Autumn = 6
	}

	public static SaveData ins;

	private ES3File savefile;

	private bool canClickSave = true;

	[Header("Save Data")]
	public bool verticalMode;

	public FarmType farmType;

	public CrossoverFarmType crossoverFarmType;

	[Header("Settings Data")]
	public LocalizationSystem.Language language;

	public bool overrideSteamLanguage;

	public bool alwaysOnTop;

	public bool focusMode;

	public bool nightMode;

	public bool blackScreenBug;

	public int taskbarHeight = 40;

	public int sidebarWidth = 40;

	public float soundFX = 8f;

	public float musicFX;

	public bool autoSave = true;

	public bool greenScreen;

	public bool vsync = true;

	public bool pixelfont = true;

	public int frameRate = 60;

	public int renderInterval;

	public int mapsUnlocked;

	private int maxMapUnlockedInSavefiles;

	public int waitForNextActionMS = 100;

	public int transparencyMode;

	[Header("Twitch Save Data")]
	public TwitchConnect twitchConnect;

	public TwitchIntegration twitchIntegration;

	public int inactivityTimer;

	public int availableSlots;

	public bool subsOnly;

	[Header("Settings References")]
	public ChangeLanguage languageDropdownScript;

	public Toggle alwaysOnTopToggle;

	public Toggle focusModeToggle;

	public Toggle nightModeToggle;

	public NightCycle nightCycleScript;

	public CameraZoomAndMove cameraZoomAndMove;

	public TMP_InputField taskbarInput;

	public TMP_InputField sidebarInput;

	public Slider soundFXSlider;

	public Slider musicFXSlider;

	public Toggle autoSaveToggle;

	public Toggle blackScreenToggle;

	public Toggle greenScreenToggle;

	public Toggle vsyncToggle;

	public Toggle pixelFontToggle;

	public TMP_Dropdown frameRateDropdown;

	public TMP_Dropdown renderIntervalDropdown;

	public TMP_Dropdown transparencyModeDropdown;

	public DisplayChanger transparentBackgroundScript;

	public GameObject blackScreenBugMessage;

	[Header("Achievements")]
	public int global_cogs_spins;

	public int global_spareparts_earned;

	public int global_biofuel_produced;

	public int global_watered_crops;

	public int global_harvested_crops;

	[Space]
	public StatsPanel statsPanel;

	public long total_spare_parts;

	public long total_biofuel;

	public long total_crops_watered;

	public long total_crops_harvested;

	public int total_animal_waste;

	public int total_fossils;

	[Header("Error Message")]
	[SerializeField]
	private GameObject savingScreen;

	[SerializeField]
	private AudioClip successAudio;

	[Header("Fonts")]
	[SerializeField]
	private TMP_FontAsset pixelFont;

	[SerializeField]
	private TMP_FontAsset cleanFont;

	private string achievementsFilePath = "Player-glob.txt";

	private ES3File achievementsfile;

	public CroppedWindowAsk croppedTransparencyWindow;

	private void Awake()
	{
		ins = this;
	}

	private void Start()
	{
		InvokeRepeating("AutoSave", 1f, 60f);
		InvokeRepeating("AutoBackup", 31f, 60f);
		LoadAchievementsFile();
	}

	public bool checkIfCrossover()
	{
		CrossoverFarmType crossover;
		return checkIfCrossover(out crossover);
	}

	public bool checkIfCrossover(out CrossoverFarmType crossover)
	{
		crossover = CrossoverFarmType.None;
		if (crossoverFarmType == CrossoverFarmType.None)
		{
			return false;
		}
		crossover = crossoverFarmType;
		return true;
	}

	private void AutoSave()
	{
		if (autoSave && canClickSave)
		{
			SaveGame();
			Debug.Log("Autosave");
		}
	}

	private void AutoBackup()
	{
		bool flag = false;
		bool flag2 = false;
		try
		{
			Debug.Log("Try to create a backup of savefile");
			ES3.KeyExists("griddata", PersistentFilePath.ins.currentFilePath);
		}
		catch (Exception)
		{
			Debug.Log("Failed to create a backup of savefile");
			flag = true;
		}
		if (!flag)
		{
			ES3.CreateBackup(PersistentFilePath.ins.currentFilePath);
			Debug.Log("Success. Created a backup of savefile");
		}
		try
		{
			Debug.Log("Try to create a backup of achievements");
			ES3.KeyExists("ttp", achievementsFilePath);
		}
		catch (Exception)
		{
			Debug.Log("Failed to create a backup of achievements");
			flag2 = true;
		}
		if (!flag2)
		{
			ES3.CreateBackup(achievementsFilePath);
			Debug.Log("Success. Created a backup of achievements");
		}
	}

	public void SaveGameData()
	{
		if (canClickSave)
		{
			SaveGame();
			StartCoroutine(TurnOffSaveScreen());
		}
	}

	public void SaveGameDataAndQuit()
	{
		if (canClickSave)
		{
			CancelInvoke("AutoSave");
			SaveGame();
			StartCoroutine(QuitApplication());
		}
	}

	public bool getCanSave()
	{
		return canClickSave;
	}

	private IEnumerator QuitApplication()
	{
		savingScreen.SetActive(value: true);
		canClickSave = false;
		AchievementManager.ins.AddUpdateTotalTimeStat(GameManager.ins.totalTimeElapsed);
		AchievementManager.ins.SaveStats();
		yield return new WaitForSecondsRealtime(0.5f);
		SaveSettings();
		SaveAchievementsFile();
		yield return new WaitForSecondsRealtime(0.5f);
		Application.Quit();
	}

	private void CacheSaveGame()
	{
		savingScreen.SetActive(value: true);
		canClickSave = false;
		try
		{
			Debug.Log("Try saving to " + PersistentFilePath.ins.currentFilePath);
			ES3Settings settings = new ES3Settings(PersistentFilePath.ins.currentFilePath, ES3.Location.Cache);
			GridSystem.ins.PrepareBuildingsAndCropsForSave();
			ES3.Save("griddata", GridSystem.ins.tile, settings);
			CacheSaveCropInventory(settings);
			CacheSaveGameManagerInfo(settings);
			CacheSaveBlockedLands(settings);
			CacheSavePriorityOrder(settings);
			CacheSaveCropGMO(settings);
			CacheSaveReaperShop(settings);
			CacheSaveFarmStatistics(settings);
			CacheSaveTwitchBonusMoney(settings);
			ES3.StoreCachedFile(PersistentFilePath.ins.currentFilePath);
			Debug.Log("Completed save to " + PersistentFilePath.ins.currentFilePath);
		}
		catch (Exception ex)
		{
			ErrorMessage.ins.ShowMessage("Failed to save " + PersistentFilePath.ins.currentFilePath);
			ErrorMessage.ins.ShowMessage(ex.Message);
		}
		savingScreen.SetActive(value: false);
		canClickSave = true;
	}

	private void CacheSaveCropInventory(ES3Settings settings)
	{
		for (int i = 0; i < GameManager.ins.cropManager.cropUnlocked.Length; i++)
		{
			string text = GameManager.ins.cropManager.cropCatalog[i].name;
			ES3.Save("crop" + text + "Unlocked", GameManager.ins.cropManager.cropUnlocked[i], settings);
			ES3.Save("crop" + text + "Harvested", GameManager.ins.cropManager.cropsHarvested[i], settings);
		}
		for (int j = 0; j < Inventory.ins.cropAndSeedInventory.Count; j++)
		{
			ES3.Save("cropInventory" + j, Inventory.ins.cropAndSeedInventory[j].cropAmount, settings);
		}
	}

	private void CacheSaveCropGMO(ES3Settings settings)
	{
		for (int i = 0; i < GameManager.ins.cropManager.cropGmoStats.Length; i++)
		{
			ES3.Save("crop" + i + "GMOtier", GameManager.ins.cropManager.cropGmoStats[i].tier, settings);
			ES3.Save("crop" + i + "GMOgrow", GameManager.ins.cropManager.cropGmoStats[i].grow, settings);
			ES3.Save("crop" + i + "GMOwater", GameManager.ins.cropManager.cropGmoStats[i].water, settings);
			ES3.Save("crop" + i + "GMObiofuel", GameManager.ins.cropManager.cropGmoStats[i].biofuel, settings);
			ES3.Save("crop" + i + "GMOharvest", GameManager.ins.cropManager.cropGmoStats[i].harvest, settings);
			ES3.Save("crop" + i + "GMOearnings", GameManager.ins.cropManager.cropGmoStats[i].earnings, settings);
		}
	}

	private void CacheSaveGameManagerInfo(ES3Settings settings)
	{
		ES3.Save("spareParts", Inventory.ins.spareParts, settings);
		ES3.Save("biofuel", Inventory.ins.biofuel, settings);
		ES3.Save("fossils", Inventory.ins.fossils, settings);
		ES3.Save("fertilizer", Inventory.ins.fertilizer, settings);
		ES3.Save("incrWaterBotSpeed", GameManager.ins.incrWaterBotSpeed, settings);
		ES3.Save("incrWaterBotCapacity", GameManager.ins.incrWaterBotCapacity, settings);
		ES3.Save("incrHarvestBotSpeed", GameManager.ins.incrHarvestBotSpeed, settings);
		ES3.Save("incrHarvestBotCapacity", GameManager.ins.incrHarvestBotCapacity, settings);
		ES3.Save("incrCarryBotSpeed", GameManager.ins.incrCarryBotSpeed, settings);
		ES3.Save("incrCarryBotCapacity", GameManager.ins.incrCarryBotCapacity, settings);
		ES3.Save("incrFeederBotSpeed", GameManager.ins.incrFeederBotSpeed, settings);
		ES3.Save("incrFeederBotCapacity", GameManager.ins.incrFeederBotCapacity, settings);
		ES3.Save("incrWasteBotSpeed", GameManager.ins.incrWasteBotSpeed, settings);
		ES3.Save("incrWasteBotCapacity", GameManager.ins.incrWasteBotCapacity, settings);
		ES3.Save("incrFertBotSpeed", GameManager.ins.incrFertBotSpeed, settings);
		ES3.Save("incrFertBotCapacity", GameManager.ins.incrFertBotCapacity, settings);
		ES3.Save("incrBerryBotSpeed", GameManager.ins.incrBerryBotSpeed, settings);
		ES3.Save("incrBerryBotCapacity", GameManager.ins.incrBerryBotCapacity, settings);
		ES3.Save("firstBuild", GameManager.ins.firstBuild, settings);
		ES3.Save("autoPlantSeeds", GameManager.ins.autoPlantSeeds, settings);
		ES3.Save("convertBiofuelTutorial", GameManager.ins.convertBiofuelTutorialPlayed, settings);
		ES3.Save("inGameTimer", GameManager.ins.timeElapsed, settings);
		ES3.Save("missingNo", GameManager.ins.missing404, settings);
	}

	private void CacheSaveBlockedLands(ES3Settings settings)
	{
		for (int i = 0; i < GameManager.ins.blockedLands.Length; i++)
		{
			ES3.Save("blockedLand" + i, (int)GameManager.ins.blockedLands[i], settings);
		}
	}

	private void CacheSavePriorityOrder(ES3Settings settings)
	{
		for (int i = 0; i < GameManager.ins.rustyPriority.priorities.Length; i++)
		{
			ES3.Save("rustyPriorityOrder" + i, GameManager.ins.rustyPriority.priorities[i].indexPosition, settings);
		}
		for (int j = 0; j < GameManager.ins.haikuPriority.priorities.Length; j++)
		{
			ES3.Save("haikuPriorityOrder" + j, GameManager.ins.haikuPriority.priorities[j].indexPosition, settings);
		}
	}

	private void CacheSaveReaperShop(ES3Settings settings)
	{
		ES3.Save("reaper_timer", GameManager.ins.reaperTimer, settings);
		for (int i = 0; i < GameManager.ins.reaperShopPanel.chipButtons.Length; i++)
		{
			ES3.Save("gmoChipIsLocked" + i, GameManager.ins.reaperShopPanel.chipButtons[i].locked, settings);
			ES3.Save("gmoChipIsHidden" + i, GameManager.ins.reaperShopPanel.chipButtons[i].hidden, settings);
			CacheSaveReaperShopChipButton(i, settings);
		}
	}

	private void CacheSaveReaperShopChipButton(int i, ES3Settings settings)
	{
		ES3.Save("gmoChip" + i + "tier", GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.tier, settings);
		ES3.Save("gmoChip" + i + "grow", GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.grow, settings);
		ES3.Save("gmoChip" + i + "water", GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.water, settings);
		ES3.Save("gmoChip" + i + "harvest", GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.harvest, settings);
		ES3.Save("gmoChip" + i + "biofuel", GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.biofuel, settings);
		ES3.Save("gmoChip" + i + "earnings", GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.earnings, settings);
		if (GameManager.ins.reaperShopPanel.chipButtons[i].currentCrop != null)
		{
			ES3.Save("gmoChip" + i + "cropI", GameManager.ins.reaperShopPanel.chipButtons[i].currentCrop.cropIndexInList, settings);
		}
		ES3.Save("gmoChip" + i + "price", GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOprice, settings);
		ES3.Save("gmoChip" + i + "stat1", GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstat1, settings);
		ES3.Save("gmoChip" + i + "stat2", GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstat2, settings);
	}

	private void CacheSaveFarmStatistics(ES3Settings settings)
	{
		ES3.Save("total_animal_waste", total_animal_waste, settings);
		ES3.Save("total_fossils", total_fossils, settings);
		ES3.Save("total_spare_parts", total_spare_parts, settings);
		ES3.Save("total_biofuel", total_biofuel, settings);
		ES3.Save("total_crops_watered", total_crops_watered, settings);
		ES3.Save("total_crops_harvested", total_crops_harvested, settings);
	}

	private void CacheSaveTwitchBonusMoney(ES3Settings settings)
	{
		ES3.Save("transferredStreamerBonusMoney", twitchIntegration.transferredStreamerBonusMoney, settings);
	}

	private void SaveGame()
	{
		CacheSaveGame();
	}

	private IEnumerator CreateBackupIfNotCorrupted()
	{
		yield return new WaitForSecondsRealtime(0.1f);
		Debug.Log("Trying to create backup");
		try
		{
			savefile = new ES3File(PersistentFilePath.ins.currentFilePath);
		}
		catch (FormatException)
		{
			yield break;
		}
		catch (IOException)
		{
			yield break;
		}
		catch (UnauthorizedAccessException)
		{
			yield break;
		}
		ES3.CreateBackup(PersistentFilePath.ins.currentFilePath);
		Debug.Log("Backup made");
	}

	private IEnumerator TurnOffSaveScreen()
	{
		savingScreen.SetActive(value: true);
		canClickSave = false;
		yield return new WaitForSecondsRealtime(0.5f);
		SaveAchievementsFile();
		savingScreen.SetActive(value: false);
		canClickSave = true;
	}

	private void SaveCropInventory()
	{
		for (int i = 0; i < GameManager.ins.cropManager.cropUnlocked.Length; i++)
		{
			string text = GameManager.ins.cropManager.cropCatalog[i].name;
			savefile.Save("crop" + text + "Unlocked", GameManager.ins.cropManager.cropUnlocked[i]);
			savefile.Save("crop" + text + "Harvested", GameManager.ins.cropManager.cropsHarvested[i]);
		}
		for (int j = 0; j < Inventory.ins.cropAndSeedInventory.Count; j++)
		{
			savefile.Save("cropInventory" + j, Inventory.ins.cropAndSeedInventory[j].cropAmount);
		}
	}

	private void SaveGameManagerInfo()
	{
		savefile.Save("spareParts", Inventory.ins.spareParts);
		savefile.Save("biofuel", Inventory.ins.biofuel);
		savefile.Save("fossils", Inventory.ins.fossils);
		savefile.Save("fertilizer", Inventory.ins.fertilizer);
		savefile.Save("incrWaterBotSpeed", GameManager.ins.incrWaterBotSpeed);
		savefile.Save("incrWaterBotCapacity", GameManager.ins.incrWaterBotCapacity);
		savefile.Save("incrHarvestBotSpeed", GameManager.ins.incrHarvestBotSpeed);
		savefile.Save("incrHarvestBotCapacity", GameManager.ins.incrHarvestBotCapacity);
		savefile.Save("incrCarryBotSpeed", GameManager.ins.incrCarryBotSpeed);
		savefile.Save("incrCarryBotCapacity", GameManager.ins.incrCarryBotCapacity);
		savefile.Save("incrFeederBotSpeed", GameManager.ins.incrFeederBotSpeed);
		savefile.Save("incrFeederBotCapacity", GameManager.ins.incrFeederBotCapacity);
		savefile.Save("incrWasteBotSpeed", GameManager.ins.incrWasteBotSpeed);
		savefile.Save("incrWasteBotCapacity", GameManager.ins.incrWasteBotCapacity);
		savefile.Save("incrFertBotSpeed", GameManager.ins.incrFertBotSpeed);
		savefile.Save("incrFertBotCapacity", GameManager.ins.incrFertBotCapacity);
		savefile.Save("incrBerryBotSpeed", GameManager.ins.incrBerryBotSpeed);
		savefile.Save("incrBerryBotCapacity", GameManager.ins.incrBerryBotCapacity);
		savefile.Save("firstBuild", GameManager.ins.firstBuild);
		savefile.Save("convertBiofuelTutorial", GameManager.ins.convertBiofuelTutorialPlayed);
		savefile.Save("inGameTimer", GameManager.ins.timeElapsed);
		savefile.Save("missingNo", GameManager.ins.missing404);
	}

	private void SaveBlockedLands()
	{
		for (int i = 0; i < GameManager.ins.blockedLands.Length; i++)
		{
			savefile.Save("blockedLand" + i, (int)GameManager.ins.blockedLands[i]);
		}
	}

	private void SavePriorityOrder()
	{
		for (int i = 0; i < GameManager.ins.rustyPriority.priorities.Length; i++)
		{
			savefile.Save("rustyPriorityOrder" + i, GameManager.ins.rustyPriority.priorities[i].indexPosition);
		}
		for (int j = 0; j < GameManager.ins.haikuPriority.priorities.Length; j++)
		{
			savefile.Save("haikuPriorityOrder" + j, GameManager.ins.haikuPriority.priorities[j].indexPosition);
		}
	}

	private void SaveFarmStatistics()
	{
		savefile.Save("total_animal_waste", total_animal_waste);
		savefile.Save("total_fossils", total_fossils);
		savefile.Save("total_spare_parts", total_spare_parts);
		savefile.Save("total_biofuel", total_biofuel);
		savefile.Save("total_crops_watered", total_crops_watered);
		savefile.Save("total_crops_harvested", total_crops_harvested);
	}

	private void SaveTwitchBonusMoney()
	{
		savefile.Save("transferredStreamerBonusMoney", twitchIntegration.transferredStreamerBonusMoney);
	}

	public void ClearSave()
	{
		savefile.Clear();
	}

	public void ClearPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
	}

	public bool checkIfSaveFileExists()
	{
		if (PersistentFilePath.ins.currentFilePath == "")
		{
			if (checkIfLatestSaveFileExists())
			{
				return true;
			}
			PersistentFilePath.ins.SetCurrentFilePathToNowUTC(vertical: false, 0, 0);
			return false;
		}
		return ES3.FileExists(PersistentFilePath.ins.currentFilePath);
	}

	private bool checkIfLatestSaveFileExists()
	{
		string latestSaveFile = getLatestSaveFile();
		if (latestSaveFile == null || latestSaveFile == "")
		{
			return false;
		}
		Debug.Log(latestSaveFile + " exists and is the latest save so let's load that one");
		PersistentFilePath.ins.currentFilePath = latestSaveFile;
		return true;
	}

	private string getLatestSaveFile()
	{
		string result = null;
		DateTime dateTime = new DateTime(0L);
		string[] files = ES3.GetFiles();
		foreach (string text in files)
		{
			if (!text.Contains(".txt") || text.Contains("tmp") || text.Contains(".bac") || text.Contains("Player-glob.txt") || (!text.StartsWith("V") && !text.StartsWith("H")))
			{
				continue;
			}
			int.TryParse(text.Substring(1, 1), out var result2);
			if (result2 > maxMapUnlockedInSavefiles)
			{
				maxMapUnlockedInSavefiles = result2;
			}
			try
			{
				ES3.CacheFile(text);
			}
			catch (Exception)
			{
				if (ES3.RestoreBackup(text))
				{
					Debug.Log("Backup restored.");
					try
					{
						ES3.CacheFile(text);
						goto end_IL_00aa;
					}
					catch (Exception)
					{
					}
				}
				continue;
				end_IL_00aa:;
			}
			DateTime timestamp = ES3.GetTimestamp(text);
			if (timestamp > dateTime)
			{
				result = text;
				dateTime = timestamp;
			}
		}
		return result;
	}

	public void CacheLoadGameData()
	{
		try
		{
			Debug.Log("Try loading from " + PersistentFilePath.ins.currentFilePath);
			ES3.CacheFile(PersistentFilePath.ins.currentFilePath);
			ES3Settings settings = new ES3Settings(PersistentFilePath.ins.currentFilePath, ES3.Location.Cache);
			GridSystem.ins.tile = ES3.Load<GridSystem.TileInfo[,]>("griddata", settings);
			CacheLoadCrops(settings);
			CacheLoadGameManagerInfo(settings);
			CacheLoadBlockedLands(settings);
			CacheLoadPriorityOrder(settings);
			CacheLoadCropGMO(settings);
			CacheLoadReaperShop(settings);
			CacheLoadFarmStatistics(settings);
			CacheLoadTwitchBonusMoney(settings);
			Debug.Log("Completed load from " + PersistentFilePath.ins.currentFilePath);
		}
		catch (Exception ex)
		{
			if (ES3.RestoreBackup(PersistentFilePath.ins.currentFilePath))
			{
				Debug.Log("Backup restored.");
				CacheLoadGameData();
			}
			else
			{
				Debug.Log("Backup could not be restored as no backup exists.");
				ErrorMessage.ins.ShowMessage("No backup exists. Failed to load " + PersistentFilePath.ins.currentFilePath);
				ErrorMessage.ins.ShowMessage(ex.Message);
			}
		}
	}

	private void CacheLoadCrops(ES3Settings settings)
	{
		for (int i = 0; i < GameManager.ins.cropManager.cropUnlocked.Length; i++)
		{
			string text = GameManager.ins.cropManager.cropCatalog[i].name;
			GameManager.ins.cropManager.cropUnlocked[i] = ES3.Load("crop" + text + "Unlocked", defaultValue: false, settings);
			GameManager.ins.cropManager.cropsHarvested[i] = ES3.Load("crop" + text + "Harvested", 0, settings);
		}
		for (int j = 0; j < Inventory.ins.cropAndSeedInventory.Count; j++)
		{
			Inventory.ins.cropAndSeedInventory[j].cropAmount = ES3.Load("cropInventory" + j, 0, settings);
		}
	}

	private void CacheLoadCropGMO(ES3Settings settings)
	{
		for (int i = 0; i < GameManager.ins.cropManager.cropGmoStats.Length; i++)
		{
			GameManager.ins.cropManager.cropGmoStats[i].tier = ES3.Load("crop" + i + "GMOtier", CropManager.GmoTier.None, settings);
			GameManager.ins.cropManager.cropGmoStats[i].grow = ES3.Load("crop" + i + "GMOgrow", 0f, settings);
			GameManager.ins.cropManager.cropGmoStats[i].water = ES3.Load("crop" + i + "GMOwater", 0, settings);
			GameManager.ins.cropManager.cropGmoStats[i].biofuel = ES3.Load("crop" + i + "GMObiofuel", 0, settings);
			GameManager.ins.cropManager.cropGmoStats[i].harvest = ES3.Load("crop" + i + "GMOharvest", 0, settings);
			GameManager.ins.cropManager.cropGmoStats[i].earnings = ES3.Load("crop" + i + "GMOearnings", 0, settings);
		}
	}

	private void CacheLoadGameManagerInfo(ES3Settings settings)
	{
		Inventory.ins.spareParts = ES3.Load("spareParts", 400, settings);
		Inventory.ins.biofuel = ES3.Load("biofuel", 8, settings);
		Inventory.ins.fossils = ES3.Load("fossils", 8, settings);
		Inventory.ins.fertilizer = ES3.Load("fertilizer", 0, settings);
		GameManager.ins.incrWaterBotSpeed = ES3.Load("incrWaterBotSpeed", 0, settings);
		GameManager.ins.incrWaterBotCapacity = ES3.Load("incrWaterBotCapacity", 0, settings);
		GameManager.ins.incrHarvestBotSpeed = ES3.Load("incrHarvestBotSpeed", 0, settings);
		GameManager.ins.incrHarvestBotCapacity = ES3.Load("incrHarvestBotCapacity", 0, settings);
		GameManager.ins.incrCarryBotSpeed = ES3.Load("incrCarryBotSpeed", 0, settings);
		GameManager.ins.incrCarryBotCapacity = ES3.Load("incrCarryBotCapacity", 0, settings);
		GameManager.ins.incrFeederBotSpeed = ES3.Load("incrFeederBotSpeed", 0, settings);
		GameManager.ins.incrFeederBotCapacity = ES3.Load("incrFeederBotCapacity", 0, settings);
		GameManager.ins.incrWasteBotSpeed = ES3.Load("incrWasteBotSpeed", 0, settings);
		GameManager.ins.incrWasteBotCapacity = ES3.Load("incrWasteBotCapacity", 0, settings);
		GameManager.ins.incrFertBotSpeed = ES3.Load("incrFertBotSpeed", 0, settings);
		GameManager.ins.incrFertBotCapacity = ES3.Load("incrFertBotCapacity", 0, settings);
		GameManager.ins.incrBerryBotSpeed = ES3.Load("incrBerryBotSpeed", 0, settings);
		GameManager.ins.incrBerryBotCapacity = ES3.Load("incrBerryBotCapacity", 0, settings);
		GameManager.ins.firstBuild = ES3.Load("firstBuild", defaultValue: false, settings);
		GameManager.ins.autoPlantSeeds = ES3.Load("autoPlantSeeds", defaultValue: true, settings);
		GameManager.ins.convertBiofuelTutorialPlayed = ES3.Load("convertBiofuelTutorial", defaultValue: false, settings);
		GameManager.ins.convertBiofuelTutorial.SetActive(!GameManager.ins.convertBiofuelTutorialPlayed);
		GameManager.ins.timeElapsed = ES3.Load("inGameTimer", 0f, settings);
		GameManager.ins.missing404 = ES3.Load<string>("missingNo", "x00 y00", settings);
	}

	private void CacheLoadBlockedLands(ES3Settings settings)
	{
		for (int i = 0; i < GameManager.ins.blockedLands.Length; i++)
		{
			GameManager.ins.blockedLands[i] = (BlockedLand.State)ES3.Load("blockedLand" + i, 0, settings);
		}
	}

	private void CacheLoadPriorityOrder(ES3Settings settings)
	{
		for (int i = 0; i < GameManager.ins.rustyPriority.priorities.Length; i++)
		{
			GameManager.ins.rustyPriority.priorities[i].indexPosition = ES3.Load("rustyPriorityOrder" + i, i, settings);
		}
		for (int j = 0; j < GameManager.ins.haikuPriority.priorities.Length; j++)
		{
			GameManager.ins.haikuPriority.priorities[j].indexPosition = ES3.Load("haikuPriorityOrder" + j, j, settings);
		}
		GameManager.ins.rustyPriority.UpdatePriorityListIn(GameManager.ins.rusty, smoothMove: false);
		GameManager.ins.haikuPriority.UpdatePriorityListIn(GameManager.ins.haiku, smoothMove: false);
	}

	private void CacheLoadReaperShop(ES3Settings settings)
	{
		GameManager.ins.reaperTimer = ES3.Load("reaper_timer", 300f, settings);
		for (int i = 0; i < GameManager.ins.reaperShopPanel.chipButtons.Length; i++)
		{
			GameManager.ins.reaperShopPanel.chipButtons[i].locked = ES3.Load("gmoChipIsLocked" + i, defaultValue: false, settings);
			GameManager.ins.reaperShopPanel.chipButtons[i].hidden = ES3.Load("gmoChipIsHidden" + i, defaultValue: false, settings);
			CacheLoadReaperShopChipButton(i, settings);
		}
	}

	private void CacheLoadReaperShopChipButton(int i, ES3Settings settings)
	{
		GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.tier = ES3.Load("gmoChip" + i + "tier", CropManager.GmoTier.None, settings);
		GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.grow = ES3.Load("gmoChip" + i + "grow", 0f, settings);
		GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.water = ES3.Load("gmoChip" + i + "water", 0, settings);
		GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.harvest = ES3.Load("gmoChip" + i + "harvest", 0, settings);
		GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.biofuel = ES3.Load("gmoChip" + i + "biofuel", 0, settings);
		GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.earnings = ES3.Load("gmoChip" + i + "earnings", 0, settings);
		if (GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstats.tier != CropManager.GmoTier.None)
		{
			CropSO currentCrop = GameManager.ins.cropManager.cropCatalog[ES3.Load("gmoChip" + i + "cropI", 0, settings)];
			GameManager.ins.reaperShopPanel.chipButtons[i].currentCrop = currentCrop;
			GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOprice = ES3.Load("gmoChip" + i + "price", 0, settings);
			GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstat1 = ES3.Load("gmoChip" + i + "stat1", ChipButton.Stat.None, settings);
			GameManager.ins.reaperShopPanel.chipButtons[i].currentGMOstat2 = ES3.Load("gmoChip" + i + "stat2", ChipButton.Stat.None, settings);
		}
	}

	private void CacheLoadFarmStatistics(ES3Settings settings)
	{
		total_animal_waste = ES3.Load("total_animal_waste", 0, settings);
		total_fossils = ES3.Load("total_fossils", 0, settings);
		total_spare_parts = ES3.Load("total_spare_parts", 0, settings);
		total_biofuel = ES3.Load("total_biofuel", 0, settings);
		total_crops_watered = ES3.Load("total_crops_watered", 0, settings);
		total_crops_harvested = ES3.Load("total_crops_harvested", 0, settings);
	}

	private void CacheLoadTwitchBonusMoney(ES3Settings settings)
	{
		twitchIntegration.transferredStreamerBonusMoney = ES3.Load("transferredStreamerBonusMoney", defaultValue: false, settings);
	}

	public void LoadGameData()
	{
		CacheLoadGameData();
	}

	private void LoadCrops()
	{
		for (int i = 0; i < GameManager.ins.cropManager.cropUnlocked.Length; i++)
		{
			string text = GameManager.ins.cropManager.cropCatalog[i].name;
			GameManager.ins.cropManager.cropUnlocked[i] = savefile.Load("crop" + text + "Unlocked", defaultValue: false);
			GameManager.ins.cropManager.cropsHarvested[i] = savefile.Load("crop" + text + "Harvested", 0);
		}
		for (int j = 0; j < Inventory.ins.cropAndSeedInventory.Count; j++)
		{
			Inventory.ins.cropAndSeedInventory[j].cropAmount = savefile.Load("cropInventory" + j, 0);
		}
	}

	private void LoadGameManagerInfo()
	{
		Inventory.ins.spareParts = savefile.Load("spareParts", 400);
		Inventory.ins.biofuel = savefile.Load("biofuel", 8);
		Inventory.ins.fossils = savefile.Load("fossils", 8);
		Inventory.ins.fertilizer = savefile.Load("fertilizer", 0);
		GameManager.ins.incrWaterBotSpeed = savefile.Load("incrWaterBotSpeed", 0);
		GameManager.ins.incrWaterBotCapacity = savefile.Load("incrWaterBotCapacity", 0);
		GameManager.ins.incrHarvestBotSpeed = savefile.Load("incrHarvestBotSpeed", 0);
		GameManager.ins.incrHarvestBotCapacity = savefile.Load("incrHarvestBotCapacity", 0);
		GameManager.ins.incrCarryBotSpeed = savefile.Load("incrCarryBotSpeed", 0);
		GameManager.ins.incrCarryBotCapacity = savefile.Load("incrCarryBotCapacity", 0);
		GameManager.ins.incrFeederBotSpeed = savefile.Load("incrFeederBotSpeed", 0);
		GameManager.ins.incrFeederBotCapacity = savefile.Load("incrFeederBotCapacity", 0);
		GameManager.ins.incrWasteBotSpeed = savefile.Load("incrWasteBotSpeed", 0);
		GameManager.ins.incrWasteBotCapacity = savefile.Load("incrWasteBotCapacity", 0);
		GameManager.ins.incrFertBotSpeed = savefile.Load("incrFertBotSpeed", 0);
		GameManager.ins.incrFertBotCapacity = savefile.Load("incrFertBotCapacity", 0);
		GameManager.ins.incrBerryBotSpeed = savefile.Load("incrBerryBotSpeed", 0);
		GameManager.ins.incrBerryBotCapacity = savefile.Load("incrBerryBotCapacity", 0);
		GameManager.ins.firstBuild = savefile.Load("firstBuild", defaultValue: false);
		GameManager.ins.convertBiofuelTutorialPlayed = savefile.Load("convertBiofuelTutorial", defaultValue: false);
		GameManager.ins.convertBiofuelTutorial.SetActive(!GameManager.ins.convertBiofuelTutorialPlayed);
		GameManager.ins.timeElapsed = savefile.Load("inGameTimer", 0f);
		GameManager.ins.missing404 = savefile.Load("missingNo", "x4 y04");
	}

	private void LoadBlockedLands()
	{
		for (int i = 0; i < GameManager.ins.blockedLands.Length; i++)
		{
			GameManager.ins.blockedLands[i] = (BlockedLand.State)savefile.Load("blockedLand" + i, 0);
		}
	}

	private void LoadPriorityOrder()
	{
		for (int i = 0; i < GameManager.ins.rustyPriority.priorities.Length; i++)
		{
			GameManager.ins.rustyPriority.priorities[i].indexPosition = savefile.Load("rustyPriorityOrder" + i, i);
		}
		for (int j = 0; j < GameManager.ins.haikuPriority.priorities.Length; j++)
		{
			GameManager.ins.haikuPriority.priorities[j].indexPosition = savefile.Load("haikuPriorityOrder" + j, j);
		}
		GameManager.ins.rustyPriority.UpdatePriorityListIn(GameManager.ins.rusty, smoothMove: false);
		GameManager.ins.haikuPriority.UpdatePriorityListIn(GameManager.ins.haiku, smoothMove: false);
	}

	private void LoadFarmStatistics()
	{
		total_animal_waste = savefile.Load("total_animal_waste", 0);
		total_fossils = savefile.Load("total_fossils", 0);
		total_spare_parts = savefile.Load("total_spare_parts", 0);
		total_biofuel = savefile.Load("total_biofuel", 0);
		total_crops_watered = savefile.Load("total_crops_watered", 0);
		total_crops_harvested = savefile.Load("total_crops_harvested", 0);
	}

	private void LoadTwitchBonusMoney()
	{
		twitchIntegration.transferredStreamerBonusMoney = savefile.Load("transferredStreamerBonusMoney", defaultValue: false);
	}

	public void CacheSaveAchievements()
	{
		try
		{
			Debug.Log("Try saving to " + achievementsFilePath);
			ES3Settings settings = new ES3Settings(achievementsFilePath, ES3.Location.Cache);
			ES3.Save("cs", global_cogs_spins, settings);
			ES3.Save("bp", global_biofuel_produced, settings);
			ES3.Save("se", global_spareparts_earned, settings);
			ES3.Save("gwc", global_watered_crops, settings);
			ES3.Save("ghc", global_harvested_crops, settings);
			ES3.Save("mu", mapsUnlocked, settings);
			ES3.Save("ttp", GameManager.ins.totalTimeElapsed, settings);
			ES3.StoreCachedFile(achievementsFilePath);
			Debug.Log("Completed save to " + achievementsFilePath);
		}
		catch (Exception ex)
		{
			ErrorMessage.ins.ShowMessage("Failed to save " + achievementsFilePath);
			ErrorMessage.ins.ShowMessage(ex.Message);
		}
	}

	public void CacheLoadAchievements()
	{
		try
		{
			Debug.Log("Try loading from " + achievementsFilePath);
			ES3.CacheFile(achievementsFilePath);
			ES3Settings settings = new ES3Settings(achievementsFilePath, ES3.Location.Cache);
			global_cogs_spins = ES3.Load("cs", 0, settings);
			global_biofuel_produced = ES3.Load("bp", 0, settings);
			global_spareparts_earned = ES3.Load("se", 0, settings);
			global_watered_crops = ES3.Load("gwc", 0, settings);
			global_harvested_crops = ES3.Load("ghc", 0, settings);
			mapsUnlocked = ES3.Load("mu", 0, settings);
			GameManager.ins.totalTimeElapsed = ES3.Load("ttp", 0f, settings);
			DoubleCheckMapsUnlocked();
			AchievementManager.ins.UnlockFarm(mapsUnlocked);
			Debug.Log("Completed load from " + achievementsFilePath);
		}
		catch (Exception ex)
		{
			if (ES3.RestoreBackup(achievementsFilePath))
			{
				Debug.Log("Backup restored.");
				CacheLoadAchievements();
			}
			else
			{
				Debug.Log("Backup could not be restored as no backup exists.");
				ErrorMessage.ins.ShowMessage("No backup exists. Failed to load achievements file: " + achievementsFilePath + "<br>");
				ErrorMessage.ins.ShowMessage(ex.Message);
			}
		}
	}

	private void DoubleCheckMapsUnlocked()
	{
		if (mapsUnlocked < (int)farmType)
		{
			mapsUnlocked = (int)farmType;
		}
		if (mapsUnlocked < maxMapUnlockedInSavefiles)
		{
			mapsUnlocked = maxMapUnlockedInSavefiles;
		}
		int num = AchievementManager.ins.CheckFarmUnlocks();
		if (mapsUnlocked < num)
		{
			mapsUnlocked = num;
		}
		if (mapsUnlocked >= 3)
		{
			mapsUnlocked = 100;
		}
	}

	public void SaveAchievementsFile()
	{
		CacheSaveAchievements();
	}

	public void LoadAchievementsFile()
	{
		CacheLoadAchievements();
	}

	public void SaveSettings()
	{
		Debug.Log("Saving settings to playerprefs");
		PlayerPrefs.SetInt("language", (int)language);
		PlayerPrefs.SetInt("taskbarHeight", taskbarHeight);
		PlayerPrefs.SetInt("sidebarWidth", sidebarWidth);
		PlayerPrefs.SetInt("frameRate", frameRate);
		PlayerPrefs.SetInt("transparencyMode", transparencyMode);
		PlayerPrefs.SetInt("renderInterval", renderInterval);
		PlayerPrefs.SetInt("overrideSteamLanguage", overrideSteamLanguage ? 1 : 0);
		PlayerPrefs.SetInt("alwaysOnTop", alwaysOnTop ? 1 : 0);
		PlayerPrefs.SetInt("autoSave", autoSave ? 1 : 0);
		PlayerPrefs.SetInt("greenScreen", greenScreen ? 1 : 0);
		PlayerPrefs.SetInt("vsync", vsync ? 1 : 0);
		PlayerPrefs.SetInt("pixelfont", pixelfont ? 1 : 0);
		PlayerPrefs.SetInt("focusMode", focusMode ? 1 : 0);
		PlayerPrefs.SetInt("nightMode", nightMode ? 1 : 0);
		PlayerPrefs.SetInt("blackScreenBug", blackScreenBug ? 1 : 0);
		PlayerPrefs.SetFloat("soundFX", soundFX);
		PlayerPrefs.SetFloat("musicFX", musicFX);
		PlayerPrefs.SetString("twitchUsername", twitchConnect.user);
		PlayerPrefs.SetString("twitchChannel", twitchConnect.channel);
		PlayerPrefs.SetString("twitchOAuth", twitchConnect.oAuth);
		PlayerPrefs.SetInt("twitchInactivityTimer", inactivityTimer);
		PlayerPrefs.SetInt("twitchAvailableSlots", availableSlots);
		PlayerPrefs.SetInt("twitchSubsOnly", subsOnly ? 1 : 0);
		PlayerPrefs.Save();
	}

	public void LoadSettings()
	{
		Debug.Log("Loading settings from playerprefs");
		language = (LocalizationSystem.Language)PlayerPrefs.GetInt("language", 0);
		taskbarHeight = PlayerPrefs.GetInt("taskbarHeight", 40);
		frameRate = PlayerPrefs.GetInt("frameRate", 6);
		sidebarWidth = PlayerPrefs.GetInt("sidebarWidth", 0);
		transparencyMode = PlayerPrefs.GetInt("transparencyMode", 0);
		renderInterval = PlayerPrefs.GetInt("renderInterval", 0);
		overrideSteamLanguage = PlayerPrefs.GetInt("overrideSteamLanguage", 0) == 1;
		alwaysOnTop = PlayerPrefs.GetInt("alwaysOnTop", 0) == 1;
		autoSave = PlayerPrefs.GetInt("autoSave", 1) == 1;
		greenScreen = PlayerPrefs.GetInt("greenScreen", 0) == 1;
		vsync = PlayerPrefs.GetInt("vsync", 1) == 1;
		pixelfont = PlayerPrefs.GetInt("pixelfont", 1) == 1;
		focusMode = PlayerPrefs.GetInt("focusMode", 0) == 1;
		nightMode = PlayerPrefs.GetInt("nightMode", 0) == 1;
		blackScreenBug = PlayerPrefs.GetInt("blackScreenBug", 0) == 1;
		soundFX = PlayerPrefs.GetFloat("soundFX", 5f);
		musicFX = PlayerPrefs.GetFloat("musicFX", 5f);
		twitchConnect.user = PlayerPrefs.GetString("twitchUsername", "MisterMorrisGames");
		twitchConnect.channel = PlayerPrefs.GetString("twitchChannel", "MisterMorrisGames");
		twitchConnect.oAuth = PlayerPrefs.GetString("twitchOAuth", "oauth:example");
		inactivityTimer = PlayerPrefs.GetInt("twitchInactivityTimer", 15);
		availableSlots = PlayerPrefs.GetInt("twitchAvailableSlots", 50);
		subsOnly = PlayerPrefs.GetInt("twitchSubsOnly", 1) == 1;
		twitchConnect.LoadSettings();
		twitchIntegration.LoadSettings();
	}

	public void ApplyAllSettings()
	{
		if (!overrideSteamLanguage)
		{
			CheckSteamLanguage();
		}
		else
		{
			SetLanguageTo(language);
		}
		SetAlwaysOnTopInUI(alwaysOnTop);
		SetFocusMode(focusMode);
		SetTaskbarHeightInUI(taskbarHeight);
		SetSidebarWidthInUI(sidebarWidth);
		SetSFXVolume();
		SetMFXVolume();
		SetAutoSave(autoSave);
		SetFrameRate(frameRate);
		SetTransparencyMode(transparencyMode);
		SetRenderInterval(renderInterval);
		TurnOnVsync(vsync);
		SetPixelFont(pixelfont);
		ShowBlackScreenBug();
		StartCoroutine(RefreshCameraPosition());
	}

	private IEnumerator RefreshCameraPosition()
	{
		yield return 0;
		cameraZoomAndMove.CalculateMove();
	}

	private void ShowBlackScreenBug()
	{
	}

	public void SetBlackScreenBugToTrue(bool value)
	{
		blackScreenBug = value;
	}

	public void SetPixelFont(bool value)
	{
		pixelfont = value;
		if (pixelfont)
		{
			GameManager.ins.fontAsset = pixelFont;
		}
		else
		{
			GameManager.ins.fontAsset = cleanFont;
		}
		pixelFontToggle.SetIsOnWithoutNotify(pixelfont);
	}

	public void SetAlwaysOnTopInUI(bool newAlwaysOnTop)
	{
		alwaysOnTop = newAlwaysOnTop;
		alwaysOnTopToggle.SetIsOnWithoutNotify(alwaysOnTop);
	}

	public void SetTaskbarHeightInUI(int newTaskbarHeight)
	{
		taskbarHeight = newTaskbarHeight;
		taskbarInput.text = taskbarHeight + "px";
	}

	public void SetSidebarWidthInUI(int newSidebarWidth)
	{
		sidebarWidth = newSidebarWidth;
		sidebarInput.text = sidebarWidth + "px";
	}

	public void SetSFXVolume()
	{
		SoundManager.ins.SetEffectsVolume(soundFX);
		soundFXSlider.value = soundFX;
	}

	public void SetMFXVolume()
	{
		SoundManager.ins.SetMusicVolume(musicFX);
		musicFXSlider.value = musicFX;
	}

	public void SetAutoSave(bool autoSaveValue)
	{
		autoSave = autoSaveValue;
		autoSaveToggle.SetIsOnWithoutNotify(autoSave);
	}

	public void ToggleBlackScreen()
	{
		blackScreenToggle.SetIsOnWithoutNotify(value: true);
		greenScreenToggle.SetIsOnWithoutNotify(value: false);
		if (greenScreen)
		{
			greenScreen = false;
			SetBlackGreenScreen();
		}
	}

	public void ToggleGreenScreen()
	{
		greenScreenToggle.SetIsOnWithoutNotify(value: true);
		blackScreenToggle.SetIsOnWithoutNotify(value: false);
		if (!greenScreen)
		{
			greenScreen = true;
			SetBlackGreenScreen();
		}
	}

	public void SetBlackGreenScreen()
	{
		transparentBackgroundScript.SetTransparentWindow(greenScreen);
		Debug.Log("Background set to green is " + greenScreen);
	}

	public void TurnOnVsync(bool value)
	{
		vsync = value;
		if (vsync)
		{
			QualitySettings.vSyncCount = 1;
			Application.targetFrameRate = 0;
			OnDemandRendering.renderFrameInterval = 0;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
			SetFrameRate(frameRate);
			SetRenderInterval(renderInterval);
		}
		if (vsync)
		{
			frameRateDropdown.interactable = false;
			renderIntervalDropdown.interactable = false;
		}
		else
		{
			frameRateDropdown.interactable = true;
			renderIntervalDropdown.interactable = true;
		}
		vsyncToggle.SetIsOnWithoutNotify(vsync);
	}

	public void SetFrameRate(int value)
	{
		frameRate = value;
		if (value == 0)
		{
			Application.targetFrameRate = 30;
		}
		if (value == 1)
		{
			Application.targetFrameRate = 40;
		}
		if (value == 2)
		{
			Application.targetFrameRate = 50;
		}
		if (value == 3)
		{
			Application.targetFrameRate = 60;
		}
		if (value == 4)
		{
			Application.targetFrameRate = 75;
		}
		if (value == 5)
		{
			Application.targetFrameRate = 90;
		}
		if (value == 6)
		{
			Application.targetFrameRate = 144;
		}
		frameRateDropdown.SetValueWithoutNotify(value);
	}

	public void SetTransparencyModeSwitch(int mode)
	{
		if ((mode == 3 && transparencyMode != 3) || (transparencyMode == 3 && mode != 3))
		{
			croppedTransparencyWindow.ActivateCroppedAsk(mode);
		}
		else
		{
			SetTransparencyMode(mode);
		}
	}

	public void SetTransparencyMode(int mode)
	{
		transparencyMode = mode;
		GameManager.ins.mainCam.GetComponent<TransparencySwitch>().SwitchTransparency(mode);
		if (mode == 0)
		{
			ToggleBlackScreen();
		}
		if (mode == 2)
		{
			ToggleGreenScreen();
		}
		transparencyModeDropdown.SetValueWithoutNotify(mode);
	}

	public void SetRenderInterval(int value)
	{
		renderInterval = value;
		if (value == 0)
		{
			OnDemandRendering.renderFrameInterval = 1;
		}
		if (value == 1)
		{
			OnDemandRendering.renderFrameInterval = 2;
		}
		if (value == 2)
		{
			OnDemandRendering.renderFrameInterval = 3;
		}
		renderIntervalDropdown.SetValueWithoutNotify(value);
	}

	public void LowPowerMode()
	{
		TurnOnVsync(value: false);
		SetFrameRate(1);
		SetRenderInterval(1);
	}

	public void SetToDefault()
	{
		TurnOnVsync(value: true);
		SetFrameRate(6);
		SetRenderInterval(0);
	}

	public void SetFocusMode(bool value)
	{
		focusMode = value;
		focusModeToggle.SetIsOnWithoutNotify(value);
	}

	public void SetNightMode(bool value)
	{
		nightMode = value;
		if (nightMode)
		{
			nightCycleScript.TurnOnNightCycle();
		}
		else
		{
			nightCycleScript.TurnOffNightCycle();
		}
		nightModeToggle.SetIsOnWithoutNotify(value);
	}

	private void CheckSteamLanguage()
	{
		if (SteamManager.Initialized)
		{
			string currentGameLanguage = SteamApps.GetCurrentGameLanguage();
			if (currentGameLanguage == "english")
			{
				language = LocalizationSystem.Language.EN;
			}
			if (currentGameLanguage == "french")
			{
				language = LocalizationSystem.Language.FR;
			}
			if (currentGameLanguage == "italian")
			{
				language = LocalizationSystem.Language.IT;
			}
			if (currentGameLanguage == "spanish")
			{
				language = LocalizationSystem.Language.ES;
			}
			if (currentGameLanguage == "latam")
			{
				language = LocalizationSystem.Language.ES;
			}
			if (currentGameLanguage == "portuguese")
			{
				language = LocalizationSystem.Language.PTBR;
			}
			if (currentGameLanguage == "brazilian")
			{
				language = LocalizationSystem.Language.PTBR;
			}
			if (currentGameLanguage == "german")
			{
				language = LocalizationSystem.Language.DE;
			}
			if (currentGameLanguage == "schinese")
			{
				language = LocalizationSystem.Language.SCH;
			}
			if (currentGameLanguage == "tchinese")
			{
				language = LocalizationSystem.Language.TCH;
			}
			if (currentGameLanguage == "japanese")
			{
				language = LocalizationSystem.Language.JA;
			}
			if (currentGameLanguage == "koreana")
			{
				language = LocalizationSystem.Language.KO;
			}
			SetLanguageTo(language);
		}
	}

	private void CheckSteamLanguageIndex()
	{
		int languageTo = 0;
		if (SteamManager.Initialized)
		{
			string currentGameLanguage = SteamApps.GetCurrentGameLanguage();
			if (currentGameLanguage == "english")
			{
				languageTo = 0;
			}
			if (currentGameLanguage == "french")
			{
				languageTo = 1;
			}
			if (currentGameLanguage == "italian")
			{
				languageTo = 2;
			}
			if (currentGameLanguage == "spanish")
			{
				languageTo = 4;
			}
			if (currentGameLanguage == "latam")
			{
				languageTo = 4;
			}
			if (currentGameLanguage == "portuguese")
			{
				languageTo = 9;
			}
			if (currentGameLanguage == "brazilian")
			{
				languageTo = 9;
			}
			if (currentGameLanguage == "german")
			{
				languageTo = 3;
			}
			if (currentGameLanguage == "schinese")
			{
				languageTo = 7;
			}
			if (currentGameLanguage == "tchinese")
			{
				languageTo = 8;
			}
			if (currentGameLanguage == "japanese")
			{
				languageTo = 5;
			}
			if (currentGameLanguage == "koreana")
			{
				languageTo = 6;
			}
			SetLanguageTo((LocalizationSystem.Language)languageTo);
		}
	}

	public void SetLanguageTo(LocalizationSystem.Language newLanguage)
	{
		language = newLanguage;
		languageDropdownScript.SetDropdownTo(newLanguage);
		LocalizationSystem.SetLanguage(newLanguage);
	}

	public void AddTotalSpareParts(int amount)
	{
		total_spare_parts += amount;
		if ((bool)statsPanel && statsPanel.gameObject.activeInHierarchy)
		{
			statsPanel.UpdateTotalSpareParts(total_spare_parts);
		}
	}

	public void AddTotalBiofuel(int amount)
	{
		total_biofuel += amount;
		if ((bool)statsPanel && statsPanel.gameObject.activeInHierarchy)
		{
			statsPanel.UpdateTotalBiofuel(total_biofuel);
		}
	}

	public void AddTotalCropsWatered(int amount)
	{
		total_crops_watered += amount;
		global_watered_crops += amount;
		if ((bool)statsPanel && statsPanel.gameObject.activeInHierarchy)
		{
			statsPanel.UpdateTotalCropsWatered(total_crops_watered);
		}
		AchievementManager.ins.Water1MillionCrops();
		AchievementManager.ins.AddWateredStat(amount);
	}

	public void AddTotalCropsHarvested(int amount)
	{
		total_crops_harvested += amount;
		global_harvested_crops += amount;
		if ((bool)statsPanel && statsPanel.gameObject.activeInHierarchy)
		{
			statsPanel.UpdateTotalCropsHarvested(total_crops_harvested);
		}
		AchievementManager.ins.Harvest1MillionCrops();
		AchievementManager.ins.AddHarvestStat(amount);
	}

	public void AddTotalWasteCollected(int amount)
	{
		total_animal_waste += amount;
		if ((bool)statsPanel && statsPanel.gameObject.activeInHierarchy)
		{
			statsPanel.UpdateTotalWaste(total_animal_waste);
		}
		AchievementManager.ins.CollectWaste(total_animal_waste);
		AchievementManager.ins.AddPoopStat(amount);
	}

	public void AddTotalFossils(int amount)
	{
		total_fossils += amount;
		if ((bool)statsPanel && statsPanel.gameObject.activeInHierarchy)
		{
			statsPanel.UpdateTotalFossils(total_fossils);
		}
	}

	public void UpdateTotalCropTiles()
	{
		if ((bool)statsPanel && statsPanel.gameObject.activeInHierarchy)
		{
			statsPanel.UpdateTotalCropTiles();
		}
	}

	public void UpdateTotalBees()
	{
		if ((bool)statsPanel && statsPanel.gameObject.activeInHierarchy)
		{
			statsPanel.UpdateTotalBees();
		}
	}

	public void UpdateTotalBots()
	{
		if ((bool)statsPanel && statsPanel.gameObject.activeInHierarchy)
		{
			statsPanel.UpdateTotalBots();
		}
	}
}
