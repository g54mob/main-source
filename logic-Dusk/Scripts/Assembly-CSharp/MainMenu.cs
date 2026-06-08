using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class MainMenu : MenuScreenClass
{
	public enum ResetTypeEnum
	{
		NewRunReset = 0,
		FactoryReset = 1,
		SettingSafeReset = 2
	}

	public static MainMenu Instance;

	private static bool _loadedSavedGameFileAlready;

	private Rect _playGameRect;

	private Rect _playGameBeginnerRect;

	private Rect _playTutorialRect;

	private Rect _clearUserDataRect;

	private Rect _exitGameRext;

	private bool hasStaleData;

	private bool delayLoadMenu;

	private bool isHelpWindowShowing;

	private HelpManual helpManualWindow;

	private GUIStyle warningStyle;

	private BootScreen bootScreen;

	private DuskersMenuItem challengeMenuItem;

	public bool RelaunchChallengeMenu { get; set; }

	public bool RelaunchOptionsMenu { get; set; }

	public MainMenu()
	{
		Instance = this;
	}

	protected override void Initialize()
	{
		GlobalSettings.gameMode = GameModeEnum.Normal;
		GameSaveFile.ReInitSetting();
		GameSaveFile.Save("UNIVERSE_ID", "DEFAULT");
		UniverseSaveFile.ReInitSetting();
		GalaxySaveFile.ReInitSetting();
		LogManager.DeInitManager();
		GlobalSettings.IsContinuingWeeklyChallenge = false;
		EventManager.Initialize();
		float num = GameSaveFile.Get("GAME_VER", 0f);
		if (num > 0f && num < 0.2922f)
		{
			DialogUI.Instance.ShowDialog("EARLY ACCESS DATA LOSS WARNING!", "*** WARNING ***  *** WARNING ***  *** WARNING ***\n\nThis version is *incompatible* with runs started on older versions and your data must be cleared before continuing.\n\nIf you continue past this message, all of your run data will be lost.  However, we will attempt to keep your current stats, settings, etc.\n\nIf you wish to keep your current run, close the game *now* and revert to the previous version.\n\nIf you do, don't forget to come back to this version when you are ready to try the new objectives, additional changes, and bug fixes!", ModalWindowType.ContinueExit, delegate(ModalWindowResult result, string inputString)
			{
				if (result == ModalWindowResult.Continue)
				{
					ClearSavedGameData(ResetTypeEnum.SettingSafeReset);
					Initialize();
					delayLoadMenu = false;
					LoadMenu();
				}
				else
				{
					MenuExitGame();
				}
			}, 1);
			return;
		}
		Debug.Log(string.Format("======= {0} starting, v{1}, {2} =======", "Duskers", 1.041f, string.Empty));
		if (string.IsNullOrEmpty(GameSaveFile.Get("UNIVERSE_ID", string.Empty)))
		{
			GameSaveFile.Save("UNIVERSE_ID", "DEFAULT");
		}
		base.HideBackground = true;
		base.ActiveText = "Duskers Boot Utility";
		base.IgnoreCancel = true;
		base.postGUIDraw = DrawAdditional;
		MenuPanelUI.Instance.finalSetInactive = LaunchGameFinal;
		if (Camera.main.aspect >= 1.59f && Camera.main.aspect <= 1.69f)
		{
			SystemManager.AspectRatio = SystemManager.AspectRationEnum.ar16x10;
		}
		else if (Camera.main.aspect >= 1.776f && Camera.main.aspect <= 1.778f)
		{
			SystemManager.AspectRatio = SystemManager.AspectRationEnum.ar16x9OrUnknown;
		}
		else if (Camera.main.aspect >= 1.332f && Camera.main.aspect <= 1.334f)
		{
			SystemManager.AspectRatio = SystemManager.AspectRationEnum.ar4x3;
		}
		else if (Camera.main.aspect >= 1.49f && Camera.main.aspect <= 1.589f)
		{
			SystemManager.AspectRatio = SystemManager.AspectRationEnum.ar3x2;
		}
		else if (Camera.main.aspect >= 1.24f && Camera.main.aspect <= 1.36f)
		{
			SystemManager.AspectRatio = SystemManager.AspectRationEnum.ar5x4;
		}
		else if (Camera.main.aspect >= 2.32f && Camera.main.aspect <= 2.34f)
		{
			SystemManager.AspectRatio = SystemManager.AspectRationEnum.ar21x9;
		}
		else
		{
			Debug.LogWarning(string.Format("Unsupported Aspect Ration Provided (using 16:9): {0}", Camera.main.aspect));
			SystemManager.AspectRatio = SystemManager.AspectRationEnum.ar16x9OrUnknown;
		}
		if (FirstTimeDataSync())
		{
			SystemFileManager.SyncMapDataChanges();
		}
		else
		{
			bool newDataFound = false;
			bool oldDataDeleted = false;
			bool existingDataModified = false;
			if (!SystemFileManager.SyncMapDataChanges(true, out newDataFound, out oldDataDeleted, out existingDataModified))
			{
				if (newDataFound && !oldDataDeleted && !existingDataModified)
				{
					SystemFileManager.SyncMapDataChanges();
				}
				else if (!GameSaveFile.Get("WS_STALE", false))
				{
					MenuPanelUI.Instance.Disable();
					DialogUI.Instance.ShowDialog("Stale Galaxy Data Detected", "The galaxy source data is out of date.  In order to use the latest data, you must clear your user data and start over.\r\n\r\nYou can continue to play, but do so at your own risk!\r\n\r\nWould you like to clear your data (equivalent to selecting 'Clear User Data' from the main menu)?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
					{
						if (result == ModalWindowResult.Yes)
						{
							ClearSavedGameData(ResetTypeEnum.FactoryReset);
							SystemFileManager.SyncMapDataChanges();
							hasStaleData = false;
						}
						MenuPanelUI.Instance.Enable();
					}, 1);
					hasStaleData = true;
					GameSaveFile.Save("WS_STALE", true);
				}
				else
				{
					hasStaleData = true;
				}
			}
		}
		SystemFileManager.MapDataVerified = true;
		if (hasStaleData)
		{
			warningStyle = new GUIStyle();
			warningStyle.fontSize = 12;
			warningStyle.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
		}
		GlobalSettings.FirstTimeIn = false;
		string setting = ConfigFile.GetSetting("DiscoveredUpgradesOnly");
		if (!string.IsNullOrEmpty(setting))
		{
			if (setting.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
			{
				GlobalSettings.DiscoveredUpgradesOnly = true;
			}
			else if (setting.Equals("no", StringComparison.InvariantCultureIgnoreCase))
			{
				GlobalSettings.DiscoveredUpgradesOnly = false;
			}
		}
		if (!_loadedSavedGameFileAlready)
		{
			_loadedSavedGameFileAlready = true;
			List<DroneUpgradeType> discoveredUpgradesList = GameSaveFile.GetDiscoveredUpgradesList();
			if (discoveredUpgradesList.Count > 0)
			{
				GlobalSettings.DiscoveredUpgrades.Clear();
				GlobalSettings.DiscoveredUpgrades.AddRange(discoveredUpgradesList);
			}
			List<DroneUpgradeType> discoveredUpgradesExploringList = GameSaveFile.GetDiscoveredUpgradesExploringList();
			if (discoveredUpgradesExploringList.Count > 0)
			{
				GlobalSettings.DiscoveredUpgrades_Exploring.Clear();
				GlobalSettings.DiscoveredUpgrades_Exploring.AddRange(discoveredUpgradesExploringList);
			}
			GlobalSettings.LogFilesAlreadyViewed.Clear();
			GlobalSettings.LogFilesAlreadyViewed.AddRange(GameSaveFile.GetStoryFilesReadList());
			GlobalSettings.BestDaysSurvived = GameSaveFile.GetBestDaysSurvived();
			if (HelpManual.Instance != null && HelpManual.Instance.helper != null)
			{
				HelpManual.Instance.helper.RefreshDroneUpdadeMenu();
			}
		}
		string setting2 = ConfigFile.GetSetting("StartScene");
		if (!string.IsNullOrEmpty(setting2))
		{
			Debug.Log("Loading override scene: " + setting2);
			Application.LoadLevel(setting2);
		}
		GameplayManager.ResetGameState();
		if (HelpManual.Instance == null)
		{
			helpManualWindow = new HelpManual();
		}
		else
		{
			helpManualWindow = HelpManual.Instance;
		}
		int num2 = GameSaveFile.Get("Q_NOISE", 0);
		if (NoiseEffect.InstanceList != null)
		{
			int count = NoiseEffect.InstanceList.Count;
			for (int num3 = 0; num3 < count; num3++)
			{
				NoiseEffect noiseEffect = NoiseEffect.InstanceList[num3];
				if (!(noiseEffect != null))
				{
					continue;
				}
				if (num2 != 2)
				{
					noiseEffect.enabled = true;
					float grainIntensityMin;
					switch (num2)
					{
					case 0:
						grainIntensityMin = 0.1f;
						break;
					case 1:
						grainIntensityMin = 0.05f;
						break;
					default:
						grainIntensityMin = 0f;
						break;
					}
					noiseEffect.grainIntensityMin = grainIntensityMin;
					float grainIntensityMax;
					switch (num2)
					{
					case 0:
						grainIntensityMax = 0.2f;
						break;
					case 1:
						grainIntensityMax = 0.1f;
						break;
					default:
						grainIntensityMax = 0f;
						break;
					}
					noiseEffect.grainIntensityMax = grainIntensityMax;
				}
				else
				{
					noiseEffect.enabled = false;
				}
			}
		}
		if (GameSaveFile.Get("SKN", -1) == -1 || ((double)GameSaveFile.Get("GAME_VER", 0f) < 0.284 && !GameSaveFile.Get("TSTATE", "PRE29", false)))
		{
			GlobalSettings.GameState.CurrentSkin = SkinEnum.Default;
			if ((double)GameSaveFile.Get("GAME_VER", 0f) < 0.284)
			{
				GameSaveFile.Add("TSTATE", "PRE29", "true");
			}
			if (ProgressUI.Instance != null)
			{
				ProgressUI.Instance.skinObject.SetActive(false);
			}
		}
		if (num > 0f && num < 0.321f && !GameSaveFile.Get("TSTATE", "PRE321", false))
		{
			LogManager.InitManager();
			if (LogManager.LogDataFile.GroupExists("cosmic"))
			{
				LogManager.LogDataFile.SaveValue("cosmic", "stepA", 2);
			}
			if (LogManager.LogDataFile.GroupExists("superpredator") && LogManager.LogDataFile.GetValue("superpredator", "stepB", 0) > 0)
			{
				LogManager.LogDataFile.SaveValue("superpredator", "stepB", 2);
			}
			GameSaveFile.Add("TSTATE", "PRE321", "true");
		}
		if (num > 0f && num < 0.3211f && !GameSaveFile.Get("TSTATE", "PRE3211", false))
		{
			LogManager.InitManager();
			if (LogManager.LogDataFile.GroupExists("pandemic"))
			{
				if (LogManager.LogDataFile.GetValue("pandemic", "stepC", 0) > 0)
				{
					if (LogManager.LogDataFile.GetValue("pandemic", "stepD", 0) > 0)
					{
						if (LogManager.LogDataFile.GetValue("pandemic", "stepE", 0) > 0)
						{
							LogManager.LogDataFile.SaveValue("pandemic", "stepC", LogManager.LogDataFile.GetValue("pandemic", "stepD", 0));
							LogManager.LogDataFile.SaveValue("pandemic", "stepD", LogManager.LogDataFile.GetValue("pandemic", "stepE", 0));
							LogManager.LogDataFile.ClearValue("pandemic", "stepE");
						}
						else if (LogManager.LogDataFile.GetValue("pandemic", "stepD", 0) > 2)
						{
							LogManager.LogDataFile.SaveValue("pandemic", "stepC", 4);
							LogManager.LogDataFile.SaveValue("pandemic", "stepD", 2);
						}
						else
						{
							LogManager.LogDataFile.SaveValue("pandemic", "stepC", 2);
							LogManager.LogDataFile.ClearValue("pandemic", "stepD");
						}
					}
					else
					{
						LogManager.LogDataFile.SaveValue("pandemic", "stepC", 2);
					}
				}
				string value = LogManager.LogDataFile.GetGroup("OBJ_", "FILE", "Holmes_Results01_log");
				if (!string.IsNullOrEmpty(value))
				{
					LogManager.GetStoryLogText("Pandemic/Holmes_Results01_log", true);
				}
				value = LogManager.LogDataFile.GetGroup("OBJ_", "FILE", "Holmes_algorithm_log");
				if (!string.IsNullOrEmpty(value))
				{
					LogManager.GetStoryLogText("Pandemic/Holmes_algorithm_log", true);
				}
			}
			GameSaveFile.Add("TSTATE", "PRE3211", "true");
		}
		if (num > 0f && num < 0.331f && !GameSaveFile.Get("TSTATE", "PRE331", false))
		{
			GameSaveFile.Clear("OBSAMSTD");
			GameSaveFile.Clear("OBSAMFIRST");
			GameSaveFile.Clear("OBSAMNXT");
			GameSaveFile.Clear("OBSAMLSTENTRY");
			GameSaveFile.Clear("OBSAMCMPLTE");
			GameSaveFile.Add("TSTATE", "PRE331", "true");
		}
		ResourceManager.UnloadQueuedAssets();
		ValidateAndRepairUniverseData();
		base.Initialize();
	}

	public override void LoadMenu()
	{
		if (delayLoadMenu)
		{
			return;
		}
		int num = 0;
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[P]lay Game", KeyCode.P, MenuPlayGame, num++));
		if (SteamManager.Initialized && (SteamLeaderboard.HasDailyLeaderboard || SteamLeaderboard.HasWeeklyLeaderboard))
		{
			challengeMenuItem = new DuskersMenuItem("Ch[a]llenge", KeyCode.A, MenuPlayChallenge, num++);
			if (SteamLeaderboard.DailyLeaderboardScore < 0)
			{
				challengeMenuItem.SpecialHighlight = true;
			}
			else if (SteamLeaderboard.WeeklyLeaderboardScore < 0)
			{
				string a = GameSaveFile.Get("CH_WKLY_SEED", -1).ToString();
				string thisWeeksSeed = ChallengeMenu.GetThisWeeksSeed();
				if (string.Equals(a, thisWeeksSeed))
				{
					challengeMenuItem.SpecialHighlight = true;
				}
			}
			MenuPanelUI.Instance.AddMenuItem(challengeMenuItem);
			MenuPanelUI.Instance.AddMenuItem(null);
			num++;
		}
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[D]rone Operator Training", KeyCode.D, MenuPlayTutorial, num++));
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[O]ptions", KeyCode.O, MenuOptions, num++));
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[H]elp Manual", KeyCode.H, ShowHelp, num++));
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[S]tats", KeyCode.S, ShowStats, num++));
		MenuPanelUI.Instance.AddMenuItem(null);
		num++;
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[F]orums (Steam)", KeyCode.F, MenuForums, num++));
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[M]isfits Attic", KeyCode.M, MenuMisfitsAttic, num++));
		if (GameSaveFile.Get("SCAVENGER", false) && !GameSaveFile.Get("SCAVENGER_SUBMIT", false))
		{
			DuskersMenuItem duskersMenuItem = new DuskersMenuItem("S[u]bmit Scavenger Hunt Feedback", KeyCode.U, MenuSubmitWin, num++);
			duskersMenuItem.OverridenColor = Color.yellow;
			MenuPanelUI.Instance.AddMenuItem(duskersMenuItem);
		}
		MenuPanelUI.Instance.AddMenuItem(null);
		num++;
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("C[r]edits", KeyCode.R, MenuShowCredits, num++));
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[E]xit", KeyCode.E, MenuExitGame, num++));
		cheatMenuItems.Clear();
		cheatMenuItems.Add(new DuskersMenuItem("[R]eset Universe", KeyCode.R, MenuResetUniverse, num++));
		cheatMenuItems.Add(new DuskersMenuItem("[A]rchive Data", KeyCode.A, MenuPackageData, num++));
		ObjectiveManual.Reset();
		Application.runInBackground = GameSaveFile.Get("O_RIB", false);
		float num2 = GameSaveFile.Get("GAME_VER", 0f);
		if (num2 < 0.26f && !GameSaveFile.Get("VWS", "SHOWN_26", false) && UniverseSaveFile.Get("UNIVERSE_PLAYS", 0) > 0)
		{
			MenuPanelUI.Instance.Disable();
			DialogUI.Instance.ShowDialog("Early Access - Data Possibly Incompatible!", "Thanks for getting the latest version!  There are a lot of exciting updates, but...\r\n\r\nThis version changes some of the way the data is processed.  We recommend that you 'Reset' your run in the pause menu. If you are in the middle of a run that you want to continue, we suggest backing up the data before continuing!\r\n\r\n Would you like to visit the forum with more information on how to backup your data?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
			{
				if (result == ModalWindowResult.Yes)
				{
					Application.OpenURL("http://steamcommunity.com/app/254320/discussions/0/490121928339134137/");
					DialogUI.Instance.ShowDialog("Forum Opened", "The forum has been opened in your default browser.\r\n\r\nYou can also visit it directly by going to:\r\nhttp://steamcommunity.com/app/254320/discussions/", ModalWindowType.OK, null);
				}
				MenuPanelUI.Instance.Enable();
			});
			GameSaveFile.Save("VWS", "SHOWN_26", true);
		}
		base.LoadMenu();
		if (GlobalSettings.ShowDailyLeaderboard || GlobalSettings.ShowWeeklyLeaderboard || RelaunchChallengeMenu)
		{
			RelaunchChallengeMenu = false;
			MenuPlayChallenge();
		}
		else if (RelaunchOptionsMenu)
		{
			Instance.RelaunchOptionsMenu = false;
			MenuOptions();
		}
		else
		{
			GalaxyMapManager.ReleaseReferencesOnMainMenu();
		}
	}

	public override void Update()
	{
		if (SteamManager.Initialized && challengeMenuItem != null)
		{
			if (SteamLeaderboard.DailyLeaderboardScore < 0)
			{
				challengeMenuItem.SpecialHighlight = true;
			}
			else if (SteamLeaderboard.WeeklyLeaderboardScore < 0)
			{
				string a = GameSaveFile.Get("CH_WKLY_SEED", -1).ToString();
				string thisWeeksSeed = ChallengeMenu.GetThisWeeksSeed();
				if (!string.Equals(a, thisWeeksSeed))
				{
					challengeMenuItem.SpecialHighlight = true;
				}
				else
				{
					challengeMenuItem.SpecialHighlight = false;
				}
			}
		}
		base.Update();
	}

	public void DrawAdditional()
	{
		if (hasStaleData && !base.Inactive)
		{
			GUI.Label(new Rect(30f, Screen.height - 50, 30f, 200f), "Stale Galaxy Data - choose 'Clear User Data' from the menu to update", warningStyle);
		}
	}

	private void MenuShowCredits()
	{
		MenuPanelUI.Instance.gameObject.SetActive(false);
		CreditsScreen.Instance.Show();
		MenuPanelUI.Instance.Disable();
	}

	private void MenuExitGame()
	{
		Application.Quit();
		MenuPanelUI.Instance.Enable();
	}

	private void MenuForums()
	{
		Application.OpenURL("http://steamcommunity.com/app/254320/discussions/");
		DialogUI.Instance.ShowDialog("Forum Opened", "The forum has been opened in your default browser.\r\n\r\nYou can also visit it directly by going to:\r\nhttp://steamcommunity.com/app/254320/discussions/", ModalWindowType.OK, null);
	}

	private void MenuMisfitsAttic()
	{
		Application.OpenURL("http://misfitsattic.com");
		DialogUI.Instance.ShowDialog("Website Opened", "The website has been opened in your default browser.\r\n\r\nYou can also visit it directly by going to:\r\nhttp://misfitsattic.com", ModalWindowType.OK, null);
	}

	public void ResetStaleDataState()
	{
		hasStaleData = false;
	}

	private void MenuResetUniverse()
	{
		string message = "Really reset universe?\n\nYou will retain unlocks etc, but universe & logs will be reset";
		DialogUI.Instance.ShowDialog("Reset Universe", message, ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
		{
			if (result == ModalWindowResult.Yes)
			{
				Reset();
				SystemFileManager.SyncMapDataChanges();
				hasStaleData = false;
			}
		});
	}

	public static void Reset()
	{
		bool value = GameSaveFile.Get("NC", false);
		ClearSavedGameData(ResetTypeEnum.NewRunReset);
		DungeonConfigurationManager.DungeonHelper.DeInitalize();
		GameSaveFile.Save("NC", value);
		GameSaveFile.Save("URESET", value);
		if (GameSaveFile.Get("DIFF_GLXY", false))
		{
			UniverseSaveFile.Save("ESY_GLXY", true);
		}
	}

	public static void PlayerReset()
	{
		UniverseSaveFile.BeginBatch();
		GalaxyMapManager.PreserveData = false;
		List<string> allGroups = UniverseSaveFile.GetAllGroups("INVITMS", "P", "SHIP");
		if (allGroups != null)
		{
			foreach (string item in allGroups)
			{
				UniverseSaveFile.ClearGroup(item);
			}
		}
		UniverseSaveFile.ClearGroupAndChildren("PLAYER");
		UniverseSaveFile.ClearGroupAndChildren("DRONE_");
		UniverseSaveFile.EndBatch();
		StarField.ClearOnMapChange();
		GalaxyMapManager.hasBoardedDungeon = false;
	}

	private void MenuPlayChallenge()
	{
		MenuPlayChallenge(null);
	}

	private void MenuPlayChallenge(DuskersMenuItem item)
	{
		MenuPanelUI.Instance.Clear();
		ChallengeMenu challengeMenu = new ChallengeMenu();
	}

	private void MenuPlayTutorial()
	{
		MenuPanelUI.Instance.Disable();
		GlobalSettings.GameState = null;
		GlobalSettings.NumLogsAfterTutorial = 0;
		GameSaveFile.Save("VIEWED_TUT", true);
		GameSaveFile.Save("WS_FIRSTDUN_TUT", true);
		GameSaveFile.Save("PLAYS_SINCE_TUT", 0);
		GlobalSettings.IsTutorial = true;
		DungeonManager.DungeonFileAtNextInstatiate = "Data/Designed Ships/Tutorial";
		Application.LoadLevel("DungeonScene_Generated_Pro");
	}

	private void MenuPlayGame()
	{
		if (!GameSaveFile.Get("WS_NEVRVWD_TUT", false))
		{
			DialogUI.Instance.ShowDialog("Training Required?", "We strongly recommend that you take the Drone Operator Training if this is your first time piloting.\r\n\r\nWould you like to launch the training simulation?", ModalWindowType.YesNoCancel, PromptRunTutorialInsteadResult);
			return;
		}
		if (MainMenuBG.Instance != null)
		{
			MainMenuBG.Instance.gameObject.SetActive(true);
		}
		if (GameSaveFile.Get("RESETREQ", false))
		{
			GlobalSettings.IsGamePaused = false;
			GlobalSettings.RetrySameInitialState = false;
			GlobalSettings.GameIsOver = false;
			GlobalSettings.IsInResetState = true;
			GameSaveFile.Save("RESETS", GameSaveFile.Get("RESETS", 0) + 1);
			if (GalaxyProcessor.universeMapManager != null)
			{
				GalaxyProcessor.universeMapManager.Clear();
				GalaxyProcessor.universeMapManager = null;
			}
			NavigationHelper.Clear();
			PlayerReset();
			Reset();
			SystemFileManager.SyncMapDataChanges();
			GameSaveFile.Save("RESETREQ", false);
		}
		if (!GameSaveFile.Get("DIED", false))
		{
			GalaxyMapManager.PreserveData = true;
		}
		else
		{
			GalaxyMapManager.PreserveData = false;
			GameSaveFile.Save("DIED", false);
		}
		LaunchGame();
	}

	private void MenuSubmitWin()
	{
	}

	private void MenuPackageData()
	{
	}

	private void LaunchGame()
	{
		MenuPanelUI.Instance.Disable(true);
		base.InactiveText = "Generating Galaxy";
		base.InactiveTextAdditional = "=[ may take several seconds ]=";
	}

	public static void LaunchGameFinal()
	{
		GlobalSettings.IsTutorial = false;
		GlobalSettings.FirstTimeIn = true;
		int num = 0;
		if (!GalaxyMapManager.PreserveData)
		{
			num = 1;
		}
		GameSaveFile.Save("PLAYS", GameSaveFile.Get("PLAYS", 0) + num);
		UniverseSaveFile.Save("UNIVERSE_PLAYS", UniverseSaveFile.Get("UNIVERSE_PLAYS", 0) + num);
		if (GameSaveFile.Get("VIEWED_TUT", false))
		{
			GameSaveFile.Save("PLAYS_SINCE_TUT", GameSaveFile.Get("PLAYS_SINCE_TUT", 0) + 1);
		}
		MenuPanelUI.Instance.PopMenu(Instance);
		Resources.UnloadUnusedAssets();
		Application.LoadLevel("UniverseSceneProcessor");
	}

	private void ContinueFromSaveResult(ModalWindowResult result, string input)
	{
		switch (result)
		{
		case ModalWindowResult.No:
			GalaxyMapManager.PreserveData = false;
			break;
		case ModalWindowResult.Cancel:
			return;
		default:
			GalaxyMapManager.PreserveData = true;
			break;
		}
		LaunchGame();
	}

	private void PromptRunTutorialInsteadResult(ModalWindowResult result, string input)
	{
		switch (result)
		{
		case ModalWindowResult.Yes:
			MenuPlayTutorial();
			break;
		case ModalWindowResult.Cancel:
			break;
		default:
			GameSaveFile.Save("WS_NEVRVWD_TUT", true);
			LaunchGame();
			break;
		}
	}

	private void MenuOptions()
	{
		MenuPanelUI.Instance.Clear();
		OptionsMenu optionsMenu = new OptionsMenu();
	}

	public static void ClearSavedGameData(ResetTypeEnum resetType)
	{
		string value = string.Empty;
		string value2 = string.Empty;
		List<KeyValuePair<string, string>> groupDataItems = GameSaveFile.GetGroupDataItems("NOTIFICATION");
		bool value3 = false;
		bool value4 = false;
		bool value5 = false;
		bool value6 = false;
		bool value7 = false;
		bool value8 = false;
		bool value9 = false;
		bool value10 = false;
		bool value11 = false;
		bool value12 = false;
		SkinEnum value13 = SkinEnum.Default;
		Dictionary<string, KeyValuePair<Type, object>> dict = null;
		GalaxyProcessor.ClearUnloackedInfectionTypeList();
		if (resetType == ResetTypeEnum.FactoryReset || resetType == ResetTypeEnum.SettingSafeReset)
		{
			value = GameSaveFile.Get<string>("GALAXY_ID");
			if (false || GlobalSettings.cheatMode)
			{
				value2 = GameSaveFile.Get<string>("UNIVERSE_ID");
				value3 = GameSaveFile.Get("WS_NEVRVWD_TUT", false);
				value4 = GameSaveFile.Get("WS_FIRSTDUN_TUT", false);
				value5 = GameSaveFile.Get("WS_DIS_GEN", false);
				value6 = GameSaveFile.Get("WS_ALOCK", false);
				value9 = GameSaveFile.Get("VIEWED_LOGMSG", false);
				value10 = GameSaveFile.Get("FIRST_READY", false);
				value11 = GameSaveFile.Get("FIRST_BOARD", false);
				value12 = GameSaveFile.Get("FIRST_BOARD", false);
				value7 = GameSaveFile.Get("SCAVENGER", false);
				value8 = GameSaveFile.Get("SCAVENGER_SUBMIT", false);
			}
			else if (resetType == ResetTypeEnum.SettingSafeReset)
			{
				value3 = GameSaveFile.Get("WS_NEVRVWD_TUT", false);
				value4 = GameSaveFile.Get("WS_FIRSTDUN_TUT", false);
				value5 = GameSaveFile.Get("WS_DIS_GEN", false);
				value6 = GameSaveFile.Get("WS_ALOCK", false);
				value9 = GameSaveFile.Get("VIEWED_LOGMSG", false);
				value10 = GameSaveFile.Get("FIRST_READY", false);
				value11 = GameSaveFile.Get("FIRST_BOARD", false);
				value12 = GameSaveFile.Get("FIRST_BOARD", false);
				value7 = GameSaveFile.Get("SCAVENGER", false);
				value8 = GameSaveFile.Get("SCAVENGER_SUBMIT", false);
			}
			value13 = (SkinEnum)GameSaveFile.Get("SKN", 0);
			GlobalSettings.ResetDiscoveredUpgrades();
			GlobalSettings.ResetStoryLogHistory();
			GlobalSettings.InterfaceUsedOnce = false;
			StarField.ClearOnReset();
			GalaxySaveFile.DeleteAllClones();
			GalaxySaveFile.EraseFile();
		}
		else
		{
			if (GameSaveFile.Get("GAME_VER", 1.041f) <= 0.302f)
			{
				List<string> allGroups = UniverseSaveFile.GetAllGroups("EN_", "P", "GSTATE");
				foreach (string item in allGroups)
				{
					GameSaveFile.Save(item, "P", "GSTATE");
					GameSaveFile.Save(item, "STATE", 1);
				}
			}
			if (GameSaveFile.Get("D_ENMYRST", false))
			{
				List<string> allGroups2 = GameSaveFile.GetAllGroups("EN_", "P", "GSTATE");
				foreach (string item2 in allGroups2)
				{
					GameSaveFile.ClearGroup(item2);
				}
			}
			StarField.ClearOnReset();
		}
		SystemFileManager.ClearStarMapDataImages(true);
		if (resetType != ResetTypeEnum.NewRunReset)
		{
			if (resetType == ResetTypeEnum.SettingSafeReset)
			{
				dict = new Dictionary<string, KeyValuePair<Type, object>>();
				TempStoreSetting("WS_NEVRVWD_TUT", false, ref dict);
				TempStoreSetting("WS_NOMOUSE_REQ", false, ref dict);
				TempStoreSetting("WS_FIRSTDUN_TUT", false, ref dict);
				TempStoreSetting("WS_STALE", false, ref dict);
				TempStoreSetting("WS_DIS_GEN", false, ref dict);
				TempStoreSetting("WS_ALOCK", false, ref dict);
				TempStoreSetting("WS_LOAD_NOTFULL", false, ref dict);
				TempStoreSetting("WS_FUEL_RECHARGE", false, ref dict);
				TempStoreSetting("WS_FP_SCRAP", false, ref dict);
				TempStoreSetting("HNT_DISABLE", false, ref dict);
				TempStoreSetting("HNT_HERD", false, ref dict);
				TempStoreSetting("HNT_NAVIGATE", false, ref dict);
				TempStoreSetting("HNT_MOTION", false, ref dict);
				TempStoreSetting("HNT_GATALL", false, ref dict);
				TempStoreSetting("HNT_TRANSPOST", false, ref dict);
				TempStoreSetting("HNT_ALOCK_DOCK", false, ref dict);
				TempStoreSetting("HNT_ALOCK_CLOSE", false, ref dict);
				TempStoreSetting("HNT_EXIT", false, ref dict);
				TempStoreSetting("HNT_COMMANDEER", false, ref dict);
				TempStoreSetting("HNT_TOW", false, ref dict);
				TempStoreSetting("HNT_SHIPEXPLORED_TRY", 0, ref dict);
				TempStoreSetting("HNT_SHIPEXPLORED", false, ref dict);
				TempStoreSetting("HNT_NOUPGRADE", 0, ref dict);
				TempStoreSetting("HNT_SV_INPUT", false, ref dict);
				TempStoreSetting("HNT_TOGGLEDOOR", 0, ref dict);
				TempStoreSetting("HNT_SU_RMT", false, ref dict);
				TempStoreSetting("HNT_SU_RRT", false, ref dict);
				TempStoreSetting("HNT_SU_TPT", false, ref dict);
				TempStoreSetting("HNT_SU", false, ref dict);
				TempStoreSetting("HNT_VIEWS", false, ref dict);
				TempStoreSetting("HNT_NCOMPLETE", false, ref dict);
				TempStoreSetting("HNT_SHPTYP", false, ref dict);
				TempStoreSetting("VIEWED_TUT", false, ref dict);
				TempStoreSetting("VIEWED_LOGMSG", false, ref dict);
				TempStoreSetting("VIEWED_CONSTMSG", false, ref dict);
				TempStoreSetting("FIRST_BOARD", false, ref dict);
				TempStoreSetting("FIRST_READY", false, ref dict);
				TempStoreSetting("FIRST_OBJECTIVE", false, ref dict);
				TempStoreSetting("DIFF_SCRAP", 0, ref dict);
				TempStoreSetting("DIFF_UPG", 0, ref dict);
				TempStoreSetting("DIFF_GLXY", false, ref dict);
				TempStoreSetting("DIFF_W_AR", false, ref dict);
				TempStoreSetting("D_RAD", true, ref dict);
				TempStoreSetting("D_VENT", true, ref dict);
				TempStoreSetting("D_BLKDRONE", true, ref dict);
				TempStoreSetting("O_RIB", true, ref dict);
				TempStoreSetting("INSHIFTVIEW", false, ref dict);
				TempStoreSetting("Q_VSYNC", QualitySettings.vSyncCount, ref dict);
				TempStoreSetting("Q_STALE", true, ref dict);
				TempStoreSetting("Q_DIST", true, ref dict);
				TempStoreSetting("Q_NOISE", 0, ref dict);
				TempStoreSetting("P_FARVIEW", 0, ref dict);
				TempStoreSetting("P_QG", 0, ref dict);
				TempStoreSetting("P_QWO", 0, ref dict);
				TempStoreSetting("VOL_MASTER", 1f, ref dict);
				TempStoreSetting("VOL_ALERTS", GlobalSettings.SFXVolume, ref dict);
				TempStoreSetting("VOL_INTERFACE", GlobalSettings.SFXVolumeInterface, ref dict);
				TempStoreSetting("VOL_REMOTE", GlobalSettings.SFXVolumeRemote, ref dict);
				TempStoreSetting("VOL_SCHEMATIC", GlobalSettings.SFXVolumeSchematic, ref dict);
				TempStoreSetting("VOL_AMBIENCE", GlobalSettings.SFXVolumeRemoteAmbience, ref dict);
				TempStoreSetting("VOL_CALLSIGNAL", GlobalSettings.SFXDroneCallSignal, ref dict);
				TempStoreSetting("OBSAMSTD", false, ref dict);
				TempStoreSetting("OBSAMFIRST", false, ref dict);
				TempStoreSetting("OBSAMNXT", 0, ref dict);
				TempStoreSetting("OBSAMLSTENTRY", -1, ref dict);
				TempStoreSetting("OBSAMCMPLTE", false, ref dict);
				TempStoreSetting("ST_BST_DAYS", 0, ref dict);
				for (int i = 1; i < 5; i++)
				{
					TempStoreSetting(string.Format("{0}_{1}", "ST_CUR_ENKILL", (ShipInfestationType)i), 0, ref dict);
				}
				for (int j = 1; j < 6; j++)
				{
					TempStoreSetting(string.Format("{0}_{1}", "ST_BST_VISITED", (DungeonTypeEnum)j), 0, ref dict);
				}
				TempStoreSetting("ST_BST_SYS_VISITED", 0, ref dict);
				TempStoreSetting("ST_BST_GAL_VISITED", 0, ref dict);
				for (int k = 1; k < 22; k++)
				{
					TempStoreSetting(string.Format("{0}_{1}", "ST_BST_DUPG_USED", (DroneUpgradeType)k), 0, ref dict);
				}
				for (int l = 1; l < 12; l++)
				{
					TempStoreSetting(string.Format("{0}_{1}", "ST_BST_SUPG_USED", (ShipUpgradeType)l), 0, ref dict);
				}
				TempStoreSetting("ST_BST_SCRAP_COL", 0, ref dict);
				TempStoreSetting("ST_BST_JFUEL_COL", 0, ref dict);
				TempStoreSetting("ST_BST_PFUEL_COL", 0, ref dict);
				TempStoreSetting("ST_BST_DRN_DEAD", 0, ref dict);
				TempStoreSetting("ST_TTL_DAYS", 0, ref dict);
				for (int m = 1; m < 5; m++)
				{
					TempStoreSetting(string.Format("{0}_{1}", "ST_TTL_ENKILL", (ShipInfestationType)m), 0, ref dict);
				}
				for (int n = 1; n < 6; n++)
				{
					TempStoreSetting(string.Format("{0}_{1}", "ST_TTL_VISITED", (DungeonTypeEnum)n), 0, ref dict);
				}
				TempStoreSetting("ST_TTL_SYS_VISITED", 0, ref dict);
				TempStoreSetting("ST_TTL_UN_VISITED", 0, ref dict);
				TempStoreSetting("ST_TTL_GAL_VISITED", 0, ref dict);
				for (int num = 1; num < 22; num++)
				{
					TempStoreSetting(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", (DroneUpgradeType)num), 0, ref dict);
				}
				for (int num2 = 1; num2 < 12; num2++)
				{
					TempStoreSetting(string.Format("{0}_{1}", "ST_TTL_SUPG_USED", (ShipUpgradeType)num2), 0, ref dict);
				}
				TempStoreSetting("ST_TTL_SCRAP_COL", 0, ref dict);
				TempStoreSetting("ST_TTL_JFUEL_COL", 0, ref dict);
				TempStoreSetting("ST_TTL_PFUEL_COL", 0, ref dict);
				TempStoreSetting("ST_TTL_DRN_DEAD", 0, ref dict);
				TempStoreSetting("ST_TTL_PLAYER_DEATH", 0, ref dict);
			}
			GameSaveFile.EraseFile();
			if (resetType == ResetTypeEnum.SettingSafeReset)
			{
				TempRestoreSetting("WS_NEVRVWD_TUT", ref dict);
				TempRestoreSetting("WS_NOMOUSE_REQ", ref dict);
				TempRestoreSetting("WS_FIRSTDUN_TUT", ref dict);
				TempRestoreSetting("WS_STALE", ref dict);
				TempRestoreSetting("WS_DIS_GEN", ref dict);
				TempRestoreSetting("WS_ALOCK", ref dict);
				TempRestoreSetting("WS_LOAD_NOTFULL", ref dict);
				TempRestoreSetting("WS_FUEL_RECHARGE", ref dict);
				TempRestoreSetting("WS_FP_SCRAP", ref dict);
				TempRestoreSetting("HNT_DISABLE", ref dict);
				TempRestoreSetting("HNT_HERD", ref dict);
				TempRestoreSetting("HNT_NAVIGATE", ref dict);
				TempRestoreSetting("HNT_MOTION", ref dict);
				TempRestoreSetting("HNT_GATALL", ref dict);
				TempRestoreSetting("HNT_TRANSPOST", ref dict);
				TempRestoreSetting("HNT_ALOCK_DOCK", ref dict);
				TempRestoreSetting("HNT_ALOCK_CLOSE", ref dict);
				TempRestoreSetting("HNT_EXIT", ref dict);
				TempRestoreSetting("HNT_COMMANDEER", ref dict);
				TempRestoreSetting("HNT_TOW", ref dict);
				TempRestoreSetting("HNT_SHIPEXPLORED_TRY", ref dict);
				TempRestoreSetting("HNT_SHIPEXPLORED", ref dict);
				TempRestoreSetting("HNT_NOUPGRADE", ref dict);
				TempRestoreSetting("HNT_SV_INPUT", ref dict);
				TempRestoreSetting("HNT_TOGGLEDOOR", ref dict);
				TempRestoreSetting("HNT_SU_RMT", ref dict);
				TempRestoreSetting("HNT_SU_RRT", ref dict);
				TempRestoreSetting("HNT_SU_TPT", ref dict);
				TempRestoreSetting("WS_NEVRVWD_TUT", ref dict);
				TempRestoreSetting("HNT_SU", ref dict);
				TempRestoreSetting("HNT_VIEWS", ref dict);
				TempRestoreSetting("HNT_NCOMPLETE", ref dict);
				TempRestoreSetting("HNT_SHPTYP", ref dict);
				TempRestoreSetting("VIEWED_TUT", ref dict);
				TempRestoreSetting("VIEWED_LOGMSG", ref dict);
				TempRestoreSetting("VIEWED_CONSTMSG", ref dict);
				TempRestoreSetting("FIRST_BOARD", ref dict);
				TempRestoreSetting("FIRST_READY", ref dict);
				TempRestoreSetting("FIRST_OBJECTIVE", ref dict);
				TempRestoreSetting("DIFF_SCRAP", ref dict);
				TempRestoreSetting("DIFF_UPG", ref dict);
				TempRestoreSetting("DIFF_GLXY", ref dict);
				TempRestoreSetting("DIFF_W_AR", ref dict);
				TempRestoreSetting("D_RAD", ref dict);
				TempRestoreSetting("D_VENT", ref dict);
				TempRestoreSetting("D_BLKDRONE", ref dict);
				TempRestoreSetting("O_RIB", ref dict);
				TempRestoreSetting("INSHIFTVIEW", ref dict);
				TempRestoreSetting("Q_VSYNC", ref dict);
				TempRestoreSetting("Q_STALE", ref dict);
				TempRestoreSetting("Q_DIST", ref dict);
				TempRestoreSetting("Q_NOISE", ref dict);
				TempRestoreSetting("P_FARVIEW", ref dict);
				TempRestoreSetting("P_QG", ref dict);
				TempRestoreSetting("P_QWO", ref dict);
				TempRestoreSetting("VOL_MASTER", ref dict);
				TempRestoreSetting("VOL_ALERTS", ref dict);
				TempRestoreSetting("VOL_INTERFACE", ref dict);
				TempRestoreSetting("VOL_REMOTE", ref dict);
				TempRestoreSetting("VOL_SCHEMATIC", ref dict);
				TempRestoreSetting("VOL_AMBIENCE", ref dict);
				TempRestoreSetting("VOL_CALLSIGNAL", ref dict);
				TempRestoreSetting("OBSAMSTD", ref dict);
				TempRestoreSetting("OBSAMFIRST", ref dict);
				TempRestoreSetting("OBSAMNXT", ref dict);
				TempRestoreSetting("OBSAMLSTENTRY", ref dict);
				TempRestoreSetting("OBSAMCMPLTE", ref dict);
				TempRestoreSetting("ST_BST_DAYS", ref dict);
				for (int num3 = 1; num3 < 5; num3++)
				{
					TempRestoreSetting(string.Format("{0}_{1}", "ST_CUR_ENKILL", (ShipInfestationType)num3), ref dict);
				}
				for (int num4 = 1; num4 < 6; num4++)
				{
					TempRestoreSetting(string.Format("{0}_{1}", "ST_BST_VISITED", (DungeonTypeEnum)num4), ref dict);
				}
				TempRestoreSetting("ST_BST_SYS_VISITED", ref dict);
				TempRestoreSetting("ST_BST_GAL_VISITED", ref dict);
				for (int num5 = 1; num5 < 22; num5++)
				{
					TempRestoreSetting(string.Format("{0}_{1}", "ST_BST_DUPG_USED", (DroneUpgradeType)num5), ref dict);
				}
				for (int num6 = 1; num6 < 12; num6++)
				{
					TempRestoreSetting(string.Format("{0}_{1}", "ST_BST_SUPG_USED", (ShipUpgradeType)num6), ref dict);
				}
				TempRestoreSetting("ST_BST_SCRAP_COL", ref dict);
				TempRestoreSetting("ST_BST_JFUEL_COL", ref dict);
				TempRestoreSetting("ST_BST_PFUEL_COL", ref dict);
				TempRestoreSetting("ST_BST_DRN_DEAD", ref dict);
				TempRestoreSetting("ST_TTL_DAYS", ref dict);
				for (int num7 = 1; num7 < 5; num7++)
				{
					TempRestoreSetting(string.Format("{0}_{1}", "ST_TTL_ENKILL", (ShipInfestationType)num7), ref dict);
				}
				for (int num8 = 1; num8 < 6; num8++)
				{
					TempRestoreSetting(string.Format("{0}_{1}", "ST_TTL_VISITED", (DungeonTypeEnum)num8), ref dict);
				}
				TempRestoreSetting("ST_TTL_SYS_VISITED", ref dict);
				TempRestoreSetting("ST_TTL_UN_VISITED", ref dict);
				TempRestoreSetting("ST_TTL_GAL_VISITED", ref dict);
				for (int num9 = 1; num9 < 22; num9++)
				{
					TempRestoreSetting(string.Format("{0}_{1}", "ST_TTL_DUPG_USED", (DroneUpgradeType)num9), ref dict);
				}
				for (int num10 = 1; num10 < 12; num10++)
				{
					TempRestoreSetting(string.Format("{0}_{1}", "ST_TTL_SUPG_USED", (ShipUpgradeType)num10), ref dict);
				}
				TempRestoreSetting("ST_TTL_SCRAP_COL", ref dict);
				TempRestoreSetting("ST_TTL_JFUEL_COL", ref dict);
				TempRestoreSetting("ST_TTL_PFUEL_COL", ref dict);
				TempRestoreSetting("ST_TTL_DRN_DEAD", ref dict);
				TempRestoreSetting("ST_TTL_PLAYER_DEATH", ref dict);
			}
		}
		else
		{
			ArchiveRunStats();
			ArchiveCurrentStats();
			GameSaveFile.Clear("MISSIONS");
			if (!Convert.ToBoolean(GameSaveFile.Get("SP", "scn1", "false")) || !Convert.ToBoolean(GameSaveFile.Get("SP", "scn2", "false")) || !Convert.ToBoolean(GameSaveFile.Get("SP", "scn3", "false")))
			{
				GameSaveFile.ClearGroup("SP");
			}
		}
		UniverseSaveFile.EraseFile();
		UniverseSaveFile.DeleteAllSupportingDataFiles(true);
		UniverseMapManager.HasData = false;
		if (resetType == ResetTypeEnum.FactoryReset)
		{
			GameSaveFile.Save("GALAXY_ID", value);
			if (false || GlobalSettings.cheatMode)
			{
				GameSaveFile.Save("UNIVERSE_ID", value2);
				GameSaveFile.Save("WS_NEVRVWD_TUT", value3);
				GameSaveFile.Save("WS_FIRSTDUN_TUT", value4);
				GameSaveFile.Save("WS_DIS_GEN", value5);
				GameSaveFile.Save("WS_ALOCK", value6);
				GameSaveFile.Save("VIEWED_LOGMSG", value9);
				GameSaveFile.Save("VIEWED_CONSTMSG", value10);
				GameSaveFile.Save("FIRST_BOARD", value11);
				GameSaveFile.Save("FIRST_READY", value12);
				GameSaveFile.Save("SCAVENGER", value7);
				GameSaveFile.Save("SCAVENGER_SUBMIT", value8);
			}
			GameSaveFile.Save("SKN", (int)value13);
		}
		if (groupDataItems != null && groupDataItems.Count > 0)
		{
			foreach (KeyValuePair<string, string> item3 in groupDataItems)
			{
				GameSaveFile.Save("NOTIFICATION", item3.Key, item3.Value);
			}
		}
		string currentDataUniverseLocation = GameFileHelper.GetCurrentDataUniverseLocation();
		if (resetType == ResetTypeEnum.FactoryReset)
		{
			string[] files = Directory.GetFiles(currentDataUniverseLocation, "~obj*.txt", SearchOption.TopDirectoryOnly);
			string[] array = files;
			foreach (string path in array)
			{
				File.Delete(path);
			}
		}
		else
		{
			DataFile dataFile = new DataFile();
			dataFile.InitSettingInstance(currentDataUniverseLocation, "~objprogressive.txt");
			GalaxyProcessor.SetObjectiveProgressFile(dataFile);
			if (!GalaxyProcessor.ObjectiveProgressFile.GetValue("objA", "COMPLETED", false))
			{
				GalaxyProcessor.ObjectiveProgressFile.ClearGroupValues("objA");
			}
			if (!GalaxyProcessor.ObjectiveProgressFile.GetValue("objB", "COMPLETED", false))
			{
				GalaxyProcessor.ObjectiveProgressFile.ClearGroupValues("objB");
			}
		}
		DungeonManager.DisableTrackingCommandCounts = false;
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			string text = Path.Combine(currentDataUniverseLocation, "Logs");
			if (resetType == ResetTypeEnum.FactoryReset)
			{
				try
				{
					if (Directory.Exists(text))
					{
						Directory.Delete(text, true);
					}
				}
				catch (Exception ex)
				{
					Debug.LogError(string.Format("Couldn't delete the \\Logs\\ folder!\r\nException: {0}", ex.Message));
				}
			}
			else
			{
				LogManager.InitManager();
				List<string> groupsWithSettings = LogManager.LogDataFile.GetGroupsWithSettings("LOG_", "TEMP", true);
				foreach (string item4 in groupsWithSettings)
				{
					string setting = LogManager.LogDataFile.GetSetting(item4, "FILE", string.Empty);
					if (!(setting != string.Empty))
					{
						continue;
					}
					string text2 = Path.Combine(text, setting);
					try
					{
						if (File.Exists(text2 + ".txt"))
						{
							File.Delete(text2 + ".txt");
						}
					}
					catch (Exception ex2)
					{
						Debug.LogError("Couldn't delete log on reset.  Error: " + ex2);
					}
					try
					{
						if (File.Exists(text2 + ".bkd"))
						{
							File.Delete(text2 + ".bkd");
						}
					}
					catch (Exception ex3)
					{
						Debug.LogError("Couldn't delete log on reset.  Error: " + ex3);
					}
					LogManager.LogDataFile.RemoveGroupSettings(item4);
				}
				for (int num12 = 0; num12 < 2; num12++)
				{
					switch (num12)
					{
					case 0:
						groupsWithSettings = LogManager.LogDataFile.GetGroupsWithSettings("LOG_", "RFSH", true);
						break;
					case 1:
						groupsWithSettings = LogManager.LogDataFile.GetGroupsWithSettings("OBJ_", "RFSH", true);
						break;
					}
					foreach (string item5 in groupsWithSettings)
					{
						string setting2 = LogManager.LogDataFile.GetSetting(item5, "FILE", string.Empty);
						if (!(setting2 != string.Empty))
						{
							continue;
						}
						string text3 = Path.Combine(text, setting2);
						try
						{
							if (File.Exists(text3 + ".bkd"))
							{
								File.Delete(text3 + ".bkd");
							}
						}
						catch (Exception ex4)
						{
							Debug.LogError("Couldn't delete baked log on reset.  Error: " + ex4);
						}
					}
				}
			}
		}
		GameSaveFile.Save("GAME_VER", 1.041f);
		LogManager.DeInitManager();
		ResourceManager.UnloadAll(false);
	}

	public static void ArchiveRunStats()
	{
		bool flag = false;
		string text = "STAT_" + GameSaveFile.Get("PLAYS", 0);
		if (GameSaveFile.Get(text, "ST_CUR_DAYS", -1) != -1)
		{
			return;
		}
		List<string> allGroups = GameSaveFile.GetAllGroups("STAT_");
		SortedList<int, string> sortedList = new SortedList<int, string>();
		int count = allGroups.Count;
		for (int i = 0; i < count; i++)
		{
			int num = GameSaveFile.Get(allGroups[i], "ST_CUR_DAYS", -1);
			if (num <= -1)
			{
				continue;
			}
			if (sortedList.ContainsKey(num))
			{
				do
				{
					num++;
				}
				while (sortedList.ContainsKey(num));
			}
			sortedList.Add(num, allGroups[i]);
		}
		int num2 = GameSaveFile.Get("ST_CUR_DAYS", 0);
		if (sortedList.ContainsKey(num2))
		{
			do
			{
				num2++;
			}
			while (sortedList.ContainsKey(num2));
		}
		sortedList.Add(num2, text);
		IEnumerable<KeyValuePair<int, string>> source = sortedList.Reverse();
		List<KeyValuePair<int, string>> list = source.ToList();
		count = list.Count;
		if (count > 5)
		{
			for (int num3 = count - 1; num3 >= 5; num3--)
			{
				GameSaveFile.ClearGroup(list.ElementAt(num3).Value);
				list.RemoveAt(num3);
			}
		}
		count = list.Count;
		for (int j = 0; j < count; j++)
		{
			if (list.ElementAt(j).Key == num2)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			CopySettingToGroup("ST_CUR_DAYS", 0, text);
			for (int k = 1; k < 5; k++)
			{
				CopySettingToGroup(string.Format("{0}_{1}", "ST_CUR_ENKILL", (ShipInfestationType)k), 0, text);
			}
			for (int l = 1; l < 6; l++)
			{
				CopySettingToGroup(string.Format("{0}_{1}", "ST_CUR_VISITED", (DungeonTypeEnum)l), 0, text);
			}
			CopySettingToGroup("ST_CUR_SYS_VISITED", 0, text);
			CopySettingToGroup("ST_CUR_GAL_VISITED", 0, text);
			for (int m = 1; m < 22; m++)
			{
				CopySettingToGroup(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", (DroneUpgradeType)m), 0, text);
			}
			for (int n = 1; n < 12; n++)
			{
				CopySettingToGroup(string.Format("{0}_{1}", "ST_CUR_SUPG_USED", (ShipUpgradeType)n), 0, text);
			}
			CopySettingToGroup("ST_CUR_SCRAP_COL", 0, text);
			CopySettingToGroup("ST_CUR_JFUEL_COL", 0, text);
			CopySettingToGroup("ST_CUR_PFUEL_COL", 0, text);
			CopySettingToGroup("ST_CUR_DRN_DEAD", 0, text);
			for (int num4 = 1; num4 < 22; num4++)
			{
				CopySettingToGroup(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", (DroneUpgradeType)num4), 0, text);
			}
			for (int num5 = 1; num5 < 12; num5++)
			{
				CopySettingToGroup(string.Format("{0}_{1}", "ST_CUR_SUPG_USED", (ShipUpgradeType)num5), 0, text);
			}
			CopySettingToGroup("ST_CUR_SCRAP_COL", 0, text);
			CopySettingToGroup("ST_CUR_JFUEL_COL", 0, text);
			CopySettingToGroup("ST_CUR_PFUEL_COL", 0, text);
			CopySettingToGroup("ST_CUR_DRN_DEAD", 0, text);
			string groupKey = UniverseSaveFile.Get("PLAYER", "SHIP_ID", string.Empty);
			string value = UniverseSaveFile.Get(groupKey, "NAME", string.Empty);
			GameSaveFile.Save(text, "NAME", value);
		}
	}

	private static void ArchiveCurrentStats()
	{
		string text = "PREPLAY";
		GameSaveFile.ClearGroup(text);
		CopySettingToGroup("ST_BST_DAYS", 0, text);
		for (int i = 1; i < 5; i++)
		{
			CopySettingToGroup(string.Format("{0}_{1}", "ST_BST_ENKILL", (ShipInfestationType)i), 0, text);
		}
		for (int j = 1; j < 6; j++)
		{
			CopySettingToGroup(string.Format("{0}_{1}", "ST_BST_VISITED", (DungeonTypeEnum)j), 0, text);
		}
		CopySettingToGroup("ST_BST_SYS_VISITED", 0, text);
		CopySettingToGroup("ST_BST_GAL_VISITED", 0, text);
		for (int k = 1; k < 22; k++)
		{
			CopySettingToGroup(string.Format("{0}_{1}", "ST_BST_DUPG_USED", (DroneUpgradeType)k), 0, text);
		}
		for (int l = 1; l < 12; l++)
		{
			CopySettingToGroup(string.Format("{0}_{1}", "ST_BST_SUPG_USED", (ShipUpgradeType)l), 0, text);
		}
		CopySettingToGroup("ST_BST_SCRAP_COL", 0, text);
		CopySettingToGroup("ST_BST_JFUEL_COL", 0, text);
		CopySettingToGroup("ST_BST_PFUEL_COL", 0, text);
		CopySettingToGroup("ST_BST_DRN_DEAD", 0, text);
		for (int m = 1; m < 22; m++)
		{
			CopySettingToGroup(string.Format("{0}_{1}", "ST_BST_DUPG_USED", (DroneUpgradeType)m), 0, text);
		}
		for (int n = 1; n < 12; n++)
		{
			CopySettingToGroup(string.Format("{0}_{1}", "ST_BST_SUPG_USED", (ShipUpgradeType)n), 0, text);
		}
		CopySettingToGroup("ST_BST_SCRAP_COL", 0, text);
		CopySettingToGroup("ST_BST_JFUEL_COL", 0, text);
		CopySettingToGroup("ST_BST_PFUEL_COL", 0, text);
		CopySettingToGroup("ST_BST_DRN_DEAD", 0, text);
	}

	private static void TempStoreSetting<T>(string key, T defaultValue, ref Dictionary<string, KeyValuePair<Type, object>> dict)
	{
		if (dict == null)
		{
			dict = new Dictionary<string, KeyValuePair<Type, object>>();
		}
		if (!dict.ContainsKey(key) && !Convert.ChangeType(GameSaveFile.Get(key, defaultValue), defaultValue.GetType()).Equals(Convert.ChangeType(defaultValue, defaultValue.GetType())))
		{
			dict.Add(key, new KeyValuePair<Type, object>(typeof(T), GameSaveFile.Get(key, defaultValue)));
		}
	}

	private static void TempRestoreSetting(string key, ref Dictionary<string, KeyValuePair<Type, object>> dict)
	{
		if (dict.ContainsKey(key))
		{
			Type type = dict[key].Value.GetType();
			GameSaveFile.Save(key, Convert.ChangeType(dict[key].Value, dict[key].Value.GetType()));
		}
	}

	private static void CopySettingToGroup<T>(string key, T defaultValue, string newGroup)
	{
		if (!Convert.ChangeType(GameSaveFile.Get(key, defaultValue), defaultValue.GetType()).Equals(Convert.ChangeType(defaultValue, defaultValue.GetType())))
		{
			GameSaveFile.Save(newGroup, key, GameSaveFile.Get(key, defaultValue));
		}
	}

	private bool FirstTimeDataSync()
	{
		GameFileHelper.EnsureGameFileDirectoriesExist();
		string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
		return !File.Exists(Path.Combine(dataGalaxyLocation, "~inf.txt"));
	}

	private void ShowHelp()
	{
		isHelpWindowShowing = true;
		helpManualWindow.IsVisible = true;
		MenuPanelUI.Instance.Disable();
	}

	public void HideHelp()
	{
		isHelpWindowShowing = false;
		helpManualWindow.IsVisible = false;
		MenuPanelUI.Instance.Enable();
	}

	private void ShowStats()
	{
		StatUI.Instance.Show();
		MenuPanelUI.Instance.Disable();
	}

	public void HideStats()
	{
		StatUI.Instance.Hide();
		MenuPanelUI.Instance.Enable();
	}

	public static void ValidateAndRepairUniverseData()
	{
		int num = UniverseSaveFile.Get(GlobalSettings.GameState.ThePlayer.MyShip.GroupKey, "SLOTS", 2);
		if (num <= 0)
		{
			return;
		}
		List<string> allGroups = UniverseSaveFile.GetAllGroups("SLOT_", "P", GlobalSettings.GameState.ThePlayer.MyShip.GroupKey);
		int count = allGroups.Count;
		if (allGroups.Count < num)
		{
			List<string> allGroups2 = UniverseSaveFile.GetAllGroups("SLOT_");
			int count2 = allGroups2.Count;
			for (int num2 = count2 - 1; num2 >= 0; num2--)
			{
				for (int i = 0; i < count; i++)
				{
					if (allGroups[i] == allGroups2[num2])
					{
						allGroups2.RemoveAt(num2);
						break;
					}
				}
			}
			int num3 = num - count;
			int num4 = 0;
			for (int j = 0; j < num3; j++)
			{
				bool flag = true;
				do
				{
					flag = true;
					for (int k = 0; k < count; k++)
					{
						if (UniverseSaveFile.Get(allGroups[k], "SLOTNUM", -1) == num4)
						{
							num4++;
							flag = false;
							break;
						}
					}
				}
				while (!flag);
				if (j < allGroups2.Count)
				{
					UniverseSaveFile.Save(allGroups2[j], "P", GlobalSettings.GameState.ThePlayer.MyShip.GroupKey);
					UniverseSaveFile.Save(allGroups2[j], "SLOTNUM", num4);
				}
				else
				{
					int num5 = -1;
					int num6 = 0;
					do
					{
						num5 = UnityEngine.Random.Range(-2147483647, int.MaxValue);
						num6++;
					}
					while ((num5 == -1 || UniverseSaveFile.Get("SLOT_" + num5, "P", false)) && num6 < 100);
					string groupKey = "SLOT_" + num5;
					UniverseSaveFile.Save(groupKey, "P", GlobalSettings.GameState.ThePlayer.MyShip.GroupKey);
					UniverseSaveFile.Save(groupKey, "SLOTNUM", num4);
					UniverseSaveFile.Save(groupKey, "BREAK_PROB", 0);
					UniverseSaveFile.Save(groupKey, "MCOUNT", 0);
					UniverseSaveFile.Save(groupKey, "STATE", 1);
				}
				allGroups = UniverseSaveFile.GetAllGroups("SLOT_", "P", GlobalSettings.GameState.ThePlayer.MyShip.GroupKey);
				count = allGroups.Count;
			}
		}
		allGroups = UniverseSaveFile.GetAllGroups("SLOT_", "P", GlobalSettings.GameState.ThePlayer.MyShip.GroupKey);
		count = allGroups.Count;
		for (int l = 0; l < count; l++)
		{
			string text = UniverseSaveFile.Get(allGroups[l], "SLOT_INSTKEY", string.Empty);
			int num7 = UniverseSaveFile.Get(allGroups[l], "SLOTNUM", -1);
			if (!(text != string.Empty))
			{
				continue;
			}
			for (int m = 0; m < count; m++)
			{
				if (!(allGroups[l] != allGroups[m]))
				{
					continue;
				}
				string text2 = UniverseSaveFile.Get(allGroups[m], "SLOT_INSTKEY", string.Empty);
				if (text2 != string.Empty && text == text2)
				{
					int num8 = UniverseSaveFile.Get(allGroups[m], "SLOTNUM", -1);
					if (num8 > num7)
					{
						UniverseSaveFile.Clear(allGroups[m], "SLOT_INSTKEY");
					}
				}
			}
		}
		allGroups = UniverseSaveFile.GetAllGroups("SLOT_", "P", GlobalSettings.GameState.ThePlayer.MyShip.GroupKey);
		count = allGroups.Count;
		for (int n = 0; n < count; n++)
		{
			string groupKey2 = UniverseSaveFile.Get(allGroups[n], "SLOT_INSTKEY", string.Empty);
			string text3 = UniverseSaveFile.Get(groupKey2, "TYPE", string.Empty);
			int num9 = UniverseSaveFile.Get(allGroups[n], "SLOTNUM", -1);
			if (!(text3 != string.Empty))
			{
				continue;
			}
			for (int num10 = 0; num10 < count; num10++)
			{
				if (!(allGroups[n] != allGroups[num10]))
				{
					continue;
				}
				string groupKey3 = UniverseSaveFile.Get(allGroups[num10], "SLOT_INSTKEY", string.Empty);
				string text4 = UniverseSaveFile.Get(groupKey3, "TYPE", string.Empty);
				if (text4 != string.Empty && text3 == text4)
				{
					int num11 = UniverseSaveFile.Get(allGroups[num10], "SLOTNUM", -1);
					if (num11 > num9)
					{
						UniverseSaveFile.Clear(allGroups[num10], "SLOT_INSTKEY");
						UniverseSaveFile.Save(groupKey3, "P", "PLAYER");
					}
				}
			}
		}
		for (int num12 = 0; num12 < count; num12++)
		{
			string groupKey4 = UniverseSaveFile.Get(allGroups[num12], "SLOT_INSTKEY", string.Empty);
			string text5 = UniverseSaveFile.Get(groupKey4, "P", string.Empty);
			if (text5 == "PLAYER")
			{
				UniverseSaveFile.Clear(allGroups[num12], "SLOT_INSTKEY");
			}
		}
		for (int num13 = 0; num13 < count; num13++)
		{
			string groupKey5 = UniverseSaveFile.Get(allGroups[num13], "SLOT_INSTKEY", string.Empty);
			string text6 = UniverseSaveFile.Get(allGroups[num13], "P", string.Empty);
			string text7 = UniverseSaveFile.Get(groupKey5, "P", string.Empty);
			if (text7 != "PLAYER" && text7 != "SHIP" && text7 != string.Empty)
			{
				UniverseSaveFile.Clear(allGroups[num13], "SLOT_INSTKEY");
				UniverseSaveFile.Save(groupKey5, "P", "PLAYER");
			}
		}
		for (int num14 = 0; num14 < count; num14++)
		{
			string text8 = UniverseSaveFile.Get(allGroups[num14], "SLOT_INSTKEY", string.Empty);
			int num15 = UniverseSaveFile.Get(allGroups[num14], "SLOTNUM", -1);
			if (!(text8 != string.Empty))
			{
				continue;
			}
			for (int num16 = 0; num16 < count; num16++)
			{
				string text9 = UniverseSaveFile.Get(allGroups[num16], "SLOT_INSTKEY", string.Empty);
				if (text9 == string.Empty)
				{
					int num17 = UniverseSaveFile.Get(allGroups[num16], "SLOTNUM", -1);
					if (num17 < num15)
					{
						UniverseSaveFile.Clear(allGroups[num14], "SLOT_INSTKEY");
						UniverseSaveFile.Save(allGroups[num16], "SLOT_INSTKEY", text8);
						break;
					}
				}
			}
		}
	}
}
