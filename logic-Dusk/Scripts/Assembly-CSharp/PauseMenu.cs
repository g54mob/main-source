using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MenuScreenClass
{
	public static PauseMenu Instance;

	public Action cancelSelected;

	public MenuItemValidate restartVerify;

	public MenuItemValidate restartSoftVerify;

	public Action restartSelected;

	public Action fullRestartSelected;

	public MenuItemValidate exitVerify;

	public Action exitSelected;

	public MenuItemValidate mainMenuVerify;

	public Action mainMenuSelected;

	public Action softResetSelected;

	private HelpManual helpManualWindow;

	public PauseMenu(bool includeHelpMenu, bool excludeCancel)
		: base(includeHelpMenu)
	{
		MenuPanelUI.Instance.IgnoreCancel = excludeCancel;
		if (excludeCancel)
		{
			MenuPanelUI.Instance.RemoveCancelMenu();
		}
	}

	protected override void Initialize()
	{
		base.ActiveText = "Pause";
		base.Initialize();
	}

	public override void LoadMenu()
	{
		Instance = this;
		MenuPanelUI.Instance.Clear();
		int num = 0;
		if (GlobalSettings.GameIsOver)
		{
			MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[R]eset", KeyCode.R, MenuReset, num++));
		}
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[O]ptions", KeyCode.O, MenuOptions, num++));
		if (Convert.ToBoolean(base.MenuData))
		{
			helpManualWindow = new HelpManual();
			MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[H]elp Manual", KeyCode.H, ShowHelp, num++)
			{
				Description = "Open the DUSKERS Help Manual..."
			});
		}
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[S]tats", KeyCode.S, ShowStats, num++));
		MenuPanelUI.Instance.AddMenuItem(null);
		num++;
		if (GlobalSettings.gameMode == GameModeEnum.Normal && !GlobalSettings.GameIsOver)
		{
			if (!GlobalSettings.IsTutorial)
			{
				MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[R]eset", KeyCode.R, MenuReset, num++));
				if (!GlobalSettings.IsTutorial && GlobalSettings.gameMode == GameModeEnum.Normal && DungeonManager.Instance != null && !GlobalSettings.GameIsOver && GameSaveFile.Get("D_SFTRST", false))
				{
					MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("So[f]t Reset", KeyCode.F, SoftMenuReset, num++));
				}
			}
			else
			{
				MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[R]estart", KeyCode.R, MenuRestart, num++));
			}
		}
		string text = "[M]ain Menu";
		if (!GlobalSettings.IsTutorial)
		{
			text += " (saves)";
		}
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem(text, KeyCode.M, MenuMainMenu, num++));
		if (!GlobalSettings.IsTutorial)
		{
			MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[E]xit (saves)", KeyCode.E, SaveAndExit, num++));
			cheatMenuItems = new List<DuskersMenuItem>();
			cheatMenuItems.Add(new DuskersMenuItem("[R]estart", KeyCode.R, MenuRestart, num++));
		}
		GlobalSettings.IsGamePaused = true;
		base.LoadMenu();
	}

	private void SFXVolumeIncrease(DuskersMenuItem item)
	{
		GlobalSettings.SFXVolume = item.SliderValue;
	}

	private void SFXVolumeDecrease(DuskersMenuItem item)
	{
		GlobalSettings.SFXVolume = item.SliderValue;
	}

	private void SFXVolumeInterfaceIncrease(DuskersMenuItem item)
	{
		GlobalSettings.SFXVolumeInterface = item.SliderValue;
	}

	private void SFXVolumeInterfaceDecrease(DuskersMenuItem item)
	{
		GlobalSettings.SFXVolumeInterface = item.SliderValue;
	}

	private void SFXVolumeRemoteIncrease(DuskersMenuItem item)
	{
		GlobalSettings.SFXVolumeRemote = item.SliderValue;
	}

	private void SFXVolumeRemoteDecrease(DuskersMenuItem item)
	{
		GlobalSettings.SFXVolumeRemote = item.SliderValue;
	}

	private void SFXVolumeSchematicIncrease(DuskersMenuItem item)
	{
		GlobalSettings.SFXVolumeSchematic = item.SliderValue;
	}

	private void SFXVolumeSchematicDecrease(DuskersMenuItem item)
	{
		GlobalSettings.SFXVolumeSchematic = item.SliderValue;
	}

	private void SFXVolumeAmbienceIncrease(DuskersMenuItem item)
	{
		GlobalSettings.SFXVolumeRemoteAmbience = item.SliderValue;
	}

	private void SFXVolumeAmbienceDecrease(DuskersMenuItem item)
	{
		GlobalSettings.SFXVolumeRemoteAmbience = item.SliderValue;
	}

	public override void CancelMenu()
	{
		GlobalSettings.IsGamePaused = false;
		base.CancelMenu();
		if (cancelSelected != null)
		{
			cancelSelected();
		}
		Instance = null;
	}

	private void MenuReset()
	{
		bool flag = false;
		if (restartVerify == null || restartVerify())
		{
			PerformFullReset();
		}
		else
		{
			Instance = null;
		}
	}

	private void SoftMenuReset()
	{
		bool flag = false;
		flag = restartSoftVerify == null || restartSoftVerify();
		if (flag && softResetSelected != null)
		{
			softResetSelected();
		}
		else
		{
			Instance = null;
		}
	}

	public void PerformFullReset()
	{
		Instance = null;
		if (GlobalSettings.IsTutorial)
		{
			DungeonManager.DungeonFileAtNextInstatiate = "Data/Designed Ships/Tutorial";
		}
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
		DroneNameGenerator.Reset();
		SystemFileManager.SyncMapDataChanges();
		GalaxyMapManager.hasBoardedDungeon = false;
		MainMenu.LaunchGameFinal();
		GameSaveFile.Save("DIED", false);
	}

	private void MenuRestart()
	{
		bool flag = false;
		if (restartVerify == null || restartVerify())
		{
			if (GlobalSettings.IsTutorial)
			{
				DungeonManager.DungeonFileAtNextInstatiate = "Data/Designed Ships/Tutorial";
			}
			GlobalSettings.IsGamePaused = false;
			if (restartSelected != null)
			{
				restartSelected();
			}
			Instance = null;
		}
	}

	private void MenuFullRestart()
	{
		GlobalSettings.IsGamePaused = false;
		if (fullRestartSelected != null)
		{
			fullRestartSelected();
		}
		Instance = null;
	}

	private void SaveAndExit()
	{
		bool flag = false;
		if (exitVerify == null || exitVerify())
		{
			GlobalSettings.IsGamePaused = false;
			if (exitSelected != null)
			{
				exitSelected();
			}
			GlobalSettings.IsExitingApplication = true;
			Application.Quit();
		}
		Instance = null;
	}

	public void SaveAndExitFromExternal()
	{
		GlobalSettings.IsGamePaused = false;
		if (exitSelected != null)
		{
			exitSelected();
		}
		GlobalSettings.IsExitingApplication = true;
		Application.Quit();
		Instance = null;
	}

	private void MenuMainMenu()
	{
		bool flag = false;
		if (mainMenuVerify == null || mainMenuVerify())
		{
			GlobalSettings.IsGamePaused = false;
			if (mainMenuSelected != null)
			{
				mainMenuSelected();
			}
		}
		Instance = null;
	}

	private void ShowHelp()
	{
		helpManualWindow.IsVisible = true;
		MenuPanelUI.Instance.Disable();
	}

	public void HideHelp()
	{
		if (helpManualWindow != null)
		{
			helpManualWindow.IsVisible = false;
		}
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

	private void MenuOptions()
	{
		MenuPanelUI.Instance.Clear();
		OptionsMenu optionsMenu = new OptionsMenu();
	}
}
