using System;
using System.Globalization;
using System.Threading;
using UnityEngine;

public class ChallengeMenu : MenuScreenClass
{
	public static ChallengeMenu Instance;

	private bool reloadOnReturn;

	private DuskersMenuItem dailyChallenge;

	private DuskersMenuItem weeklyChallenge;

	private bool hasShownWeeklyChallengeHint;

	public ChallengeMenu()
	{
		Instance = this;
	}

	protected override void Initialize()
	{
		base.ActiveText = "Challenge Launcher";
		base.IgnoreCancel = false;
		MenuPanelUI.Instance.finalSetInactive = LaunchGameFinal;
		base.Initialize();
	}

	public override void LoadMenu()
	{
		hasShownWeeklyChallengeHint = GameSaveFile.Get("FIRST_WKLY_CH", false);
		GameSaveFile.InitForWeeklyChallenge();
		GameSaveFile.Save("UNIVERSE_ID", "CHALLENGE_WKLY");
		GameSaveFile.InitForDailyChallenge();
		GameSaveFile.Save("UNIVERSE_ID", "CHALLENGE");
		GameSaveFile.InitForWeeklyChallenge();
		int num = 0;
		int num2 = GameSaveFile.Get("CH_WKLY_SEED", -1);
		bool flag = num2 != -1;
		string a = num2.ToString();
		string thisWeeksSeed = GetThisWeeksSeed();
		if (SteamLeaderboard.HasWeeklyLeaderboard)
		{
			if (SteamLeaderboard.WeeklyScoreStatus == SteamLeaderboard.ScoreStatusEnum.Final)
			{
				weeklyChallenge = new DuskersMenuItem(string.Format("Weekly Done! Score: {0}", SteamLeaderboard.WeeklyLeaderboardScore), KeyCode.W, ResumeExistingWeekly, num++)
				{
					Disabled = true
				};
				MenuPanelUI.Instance.AddMenuItem(weeklyChallenge);
			}
			else
			{
				if (string.Equals(a, thisWeeksSeed))
				{
					weeklyChallenge = new DuskersMenuItem("Continue [W]eekly Challenge", KeyCode.W, ResumeExistingWeekly, num++);
				}
				else
				{
					weeklyChallenge = new DuskersMenuItem("Start [W]eekly Challenge", KeyCode.W, LaunchExistingWeekly, num++)
					{
						SpecialHighlight = true
					};
				}
				MenuPanelUI.Instance.AddMenuItem(weeklyChallenge);
			}
		}
		GameSaveFile.InitForDailyChallenge();
		num2 = GameSaveFile.Get("CH_DLY_SEED", -1);
		flag = num2 != -1;
		if (SteamLeaderboard.HasDailyLeaderboard)
		{
			if (SteamLeaderboard.DailyLeaderboardScore >= 0)
			{
				dailyChallenge = new DuskersMenuItem(string.Format("Daily Done! Score: {0}", SteamLeaderboard.DailyLeaderboardScore), KeyCode.D, LaunchExistingDaily, num++)
				{
					Disabled = true
				};
			}
			else
			{
				dailyChallenge = new DuskersMenuItem("Start [D]aily Challenge", KeyCode.D, LaunchExistingDaily, num++)
				{
					SpecialHighlight = true
				};
			}
			MenuPanelUI.Instance.AddMenuItem(dailyChallenge);
		}
		MenuPanelUI.Instance.AddMenuItem(null);
		num++;
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("Open [L]eaderboards", KeyCode.L, ShowLeaderboard, num++));
		base.LoadMenu();
		if (GlobalSettings.ShowDailyLeaderboard || GlobalSettings.ShowWeeklyLeaderboard)
		{
			reloadOnReturn = true;
			ShowLeaderboardAuto();
		}
	}

	public override void CancelMenu()
	{
		GlobalSettings.gameMode = GameModeEnum.Normal;
		GameSaveFile.ReInitSetting();
		GameSaveFile.Save("UNIVERSE_ID", "DEFAULT");
		UniverseSaveFile.ReInitSetting();
		GalaxySaveFile.ReInitSetting();
		LogManager.DeInitManager();
		base.CancelMenu();
	}

	private void LaunchExistingWeekly()
	{
		LaunchExistingWeekly(null);
	}

	private void LaunchExistingWeekly(DuskersMenuItem item)
	{
		GameSaveFile.InitForWeeklyChallenge();
		GameSaveFile.Save("CH_WKLY_SEED", GetThisWeeksSeed());
		int seed = GameSaveFile.Get("CH_WKLY_SEED", -1);
		if (!hasShownWeeklyChallengeHint)
		{
			DialogUI.Instance.ShowDialog("Weekly Challenge Goal", "Complete the weekly challenge by reaching the galaxy's stargate", ModalWindowType.OK, delegate
			{
				GameSaveFile.InitForWeeklyChallenge();
				MenuPlayChallenge(false, GameModeEnum.WeeklyChallenge);
				GameSaveFile.Save("CH_WKLY_SEED", seed);
			});
		}
		else
		{
			MenuPlayChallenge(false, GameModeEnum.WeeklyChallenge);
			GameSaveFile.Save("CH_WKLY_SEED", seed);
		}
	}

	private void LaunchNewWeekly()
	{
		MenuPlayChallenge(false, GameModeEnum.WeeklyChallenge);
		GameSaveFile.Save("CH_WKLY_SEED", -1);
	}

	private void ResumeExistingWeekly()
	{
		ResumeExistingWeekly(null);
	}

	private void ResumeExistingWeekly(DuskersMenuItem item)
	{
		GlobalSettings.IsContinuingWeeklyChallenge = true;
		MenuPlayChallenge(true, GameModeEnum.WeeklyChallenge);
	}

	private void LaunchExistingDaily()
	{
		LaunchExistingDaily(null);
	}

	private void LaunchExistingDaily(DuskersMenuItem item)
	{
		GameSaveFile.InitForDailyChallenge();
		GameSaveFile.Save("CH_DLY_SEED", DateTime.UtcNow.ToString("yyyyMMdd"));
		int value = (UnityEngine.Random.seed = GameSaveFile.Get("CH_DLY_SEED", -1));
		do
		{
			UniverseProcessor.SeedDailyChallengeDungeon = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
		}
		while (UniverseProcessor.SeedDailyChallengeDungeon == -1);
		MenuPlayChallenge(false, GameModeEnum.DailyChallenge);
		GameSaveFile.Save("CH_DLY_SEED", value);
	}

	private void LaunchNewDaily()
	{
		MenuPlayChallenge(false, GameModeEnum.DailyChallenge);
		GameSaveFile.Save("CH_DLY_SEED", -1);
	}

	private void MenuPlayChallenge(bool skipClear, GameModeEnum gameMode)
	{
		if (GalaxyProcessor.universeMapManager != null)
		{
			GalaxyProcessor.universeMapManager.Clear();
			GalaxyProcessor.universeMapManager = null;
		}
		DroneNameGenerator.Reset();
		GameSaveFile.ReInitSetting();
		GameSaveFile.Save("UNIVERSE_ID", "DEFAULT");
		UniverseSaveFile.ReInitSetting();
		GalaxySaveFile.ReInitSetting();
		LogManager.DeInitManager();
		if (gameMode == GameModeEnum.WeeklyChallenge && !hasShownWeeklyChallengeHint)
		{
			GameSaveFile.Save("FIRST_WKLY_CH", true);
		}
		float value = GameSaveFile.Get("VOL_MASTER", 1f);
		float value2 = GameSaveFile.Get("VOL_ALERTS", GlobalSettings.SFXVolume);
		float value3 = GameSaveFile.Get("VOL_AMBIENCE", GlobalSettings.SFXVolumeRemoteAmbience);
		float value4 = GameSaveFile.Get("VOL_CALLSIGNAL", GlobalSettings.SFXDroneCallSignal);
		float value5 = GameSaveFile.Get("VOL_INTERFACE", GlobalSettings.SFXVolumeInterface);
		float value6 = GameSaveFile.Get("VOL_REMOTE", GlobalSettings.SFXVolumeRemote);
		float value7 = GameSaveFile.Get("VOL_SCHEMATIC", GlobalSettings.SFXVolumeSchematic);
		bool value8 = GameSaveFile.Get("INSHIFTVIEW", false);
		bool value9 = GameSaveFile.Get("O_RIB", false);
		GlobalSettings.gameMode = gameMode;
		switch (gameMode)
		{
		case GameModeEnum.WeeklyChallenge:
			GameSaveFile.InitForWeeklyChallenge();
			GameSaveFile.Save("UNIVERSE_ID", "CHALLENGE_WKLY");
			break;
		case GameModeEnum.DailyChallenge:
			GameSaveFile.InitForDailyChallenge();
			GameSaveFile.Save("UNIVERSE_ID", "CHALLENGE");
			break;
		}
		UniverseSaveFile.ReInitSetting();
		GalaxySaveFile.ReInitSetting();
		LogManager.DeInitManager();
		if (!skipClear)
		{
			MainMenu.ClearSavedGameData(MainMenu.ResetTypeEnum.FactoryReset);
			switch (gameMode)
			{
			case GameModeEnum.WeeklyChallenge:
				GameSaveFile.InitForWeeklyChallenge();
				GameSaveFile.Save("UNIVERSE_ID", "CHALLENGE_WKLY");
				break;
			case GameModeEnum.DailyChallenge:
				GameSaveFile.InitForDailyChallenge();
				GameSaveFile.Save("UNIVERSE_ID", "CHALLENGE");
				break;
			}
			UniverseSaveFile.ReInitSetting();
			GalaxySaveFile.ReInitSetting();
			LogManager.DeInitManager();
			GameSaveFile.Save("NC", true);
			GameSaveFile.Save("HNT_DISABLE", true);
			GameSaveFile.Save("D_RAD", true);
			GameSaveFile.Save("D_VENT", true);
			GameSaveFile.Save("D_BLKDRONE", true);
			GameSaveFile.Save("DIFF_GLXY", false);
			GameSaveFile.Save("DIFF_W_AR", false);
			GameSaveFile.Save("DIFF_SCRAP", 0);
			GameSaveFile.Save("DIFF_UPG", 0);
			int num = 5;
			for (int i = 1; i < num; i++)
			{
				GameSaveFile.Save(string.Format("EN_{0}", (ShipInfestationType)i), "P", "GSTATE");
				GameSaveFile.Save(string.Format("EN_{0}", (ShipInfestationType)i), "STATE", 1);
			}
		}
		GameSaveFile.Save("VOL_MASTER", value);
		GameSaveFile.Save("VOL_ALERTS", value2);
		GameSaveFile.Save("VOL_AMBIENCE", value3);
		GameSaveFile.Save("VOL_CALLSIGNAL", value4);
		GameSaveFile.Save("VOL_INTERFACE", value5);
		GameSaveFile.Save("VOL_REMOTE", value6);
		GameSaveFile.Save("VOL_SCHEMATIC", value7);
		GameSaveFile.Save("INSHIFTVIEW", value8);
		GameSaveFile.Save("O_RIB", value9);
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
			MainMenu.PlayerReset();
			MainMenu.Reset();
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

	private void LaunchGame()
	{
		MenuPanelUI.Instance.Disable(true);
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
		GameModeEnum gameMode = GlobalSettings.gameMode;
		MenuPanelUI.Instance.PopMenu(Instance);
		MenuPanelUI.Instance.PopMenu(MainMenu.Instance);
		GlobalSettings.gameMode = gameMode;
		switch (GlobalSettings.gameMode)
		{
		case GameModeEnum.WeeklyChallenge:
			GameSaveFile.InitForWeeklyChallenge();
			GameSaveFile.Save("UNIVERSE_ID", "CHALLENGE_WKLY");
			break;
		case GameModeEnum.DailyChallenge:
			GameSaveFile.InitForDailyChallenge();
			GameSaveFile.Save("UNIVERSE_ID", "CHALLENGE");
			break;
		}
		UniverseSaveFile.ReInitSetting();
		GalaxySaveFile.ReInitSetting();
		LogManager.DeInitManager();
		Application.LoadLevel("UniverseSceneProcessor");
	}

	public static string GetThisWeeksSeed()
	{
		CalendarWeekRule rule = CalendarWeekRule.FirstFullWeek;
		DayOfWeek firstDayOfWeek = DayOfWeek.Sunday;
		Calendar calendar = Thread.CurrentThread.CurrentCulture.Calendar;
		int weekOfYear = calendar.GetWeekOfYear(DateTime.UtcNow, rule, firstDayOfWeek);
		int num = DateTime.UtcNow.Year;
		if (weekOfYear == 52 && DateTime.UtcNow.Month == 1)
		{
			num--;
		}
		else if (weekOfYear == 1 && DateTime.UtcNow.Month == 12)
		{
			num++;
		}
		return string.Format("{0:0000}{1:00}", num, weekOfYear);
	}

	private void ShowLeaderboardAuto()
	{
		LeaderboardUI.Instance.ShowCurrent();
		MenuPanelUI.Instance.Disable();
	}

	private void ShowLeaderboard()
	{
		LeaderboardUI.Instance.Show();
		MenuPanelUI.Instance.Disable();
	}

	public void HideLeaderboard()
	{
		LeaderboardUI.Instance.Hide();
		MenuPanelUI.Instance.Enable();
		if (reloadOnReturn)
		{
			MainMenu.Instance.RelaunchChallengeMenu = true;
			MenuPanelUI.Instance.PopMenu(this);
		}
	}
}
