using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MenuScreenClass
{
	private List<string> galaxyMapList = new List<string>();

	private int galaxyMapIdx;

	private DuskersMenuItem hintMenu;

	private DuskersMenuItem runInBackgroundMenu;

	private DuskersMenuItem inputShiftMenu;

	private DuskersMenuItem clearBestPlaysMenu;

	private DuskersMenuItem cheatDifficulty;

	private DuskersMenuItem skinMenu;

	private DuskersMenuItem debugMessagesMenu;

	private DuskersMenuItem volumeMasterMenu;

	private bool hintVisibilityChanged;

	~OptionsMenu()
	{
		if (hintVisibilityChanged)
		{
			if (GameSaveFile.Get("HNT_DISABLE", false))
			{
				HintManager.CancelAllHints();
			}
			DroneUIObject.DisableHelpText = GameSaveFile.Get("HNT_DISABLE", false);
		}
	}

	protected override void Initialize()
	{
		base.ActiveText = "Options";
		base.IgnoreCancel = false;
		base.Initialize();
	}

	public override void LoadMenu()
	{
		float sliderValue = GameSaveFile.Get("VOL_MASTER", 1f);
		int num = 0;
		volumeMasterMenu = new DuskersMenuItem("[M]aster Volume\t\t", sliderValue, KeyCode.M, "Right", "Left", MasterVolumeIncrease, MasterVolumeDecrease, num++)
		{
			Description = "Adjusts all volume levels (use [A]udio to adjust individual audio channels)"
		};
		MenuPanelUI.Instance.AddMenuItem(volumeMasterMenu);
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[A]udio...", KeyCode.A, MenuAudioOptions, num++)
		{
			Description = "Set individual audio channels..."
		});
		MenuPanelUI.Instance.AddMenuItem(null);
		num++;
		hintMenu = new DuskersMenuItem("[H]ints and Help\t", KeyCode.H, "Right", "Left", MenuHints, MenuHints, MenuHints, num++)
		{
			TextValue = ((!GameSaveFile.Get("HNT_DISABLE", false)) ? "Enabled" : "Disabled"),
			Description = "Disable hints and help messages (will not disable access to the Help Manual)",
			Disabled = (GlobalSettings.gameMode != GameModeEnum.Normal)
		};
		MenuPanelUI.Instance.AddMenuItem(hintMenu);
		runInBackgroundMenu = new DuskersMenuItem("[R]un in Background\t", KeyCode.R, "Right", "Left", MenuRunInBackground, MenuRunInBackground, MenuRunInBackground, num++)
		{
			TextValue = ((!GameSaveFile.Get("O_RIB", false)) ? "Disabled" : "Enabled"),
			Description = "Enable to keep the game running in the background"
		};
		MenuPanelUI.Instance.AddMenuItem(runInBackgroundMenu);
		GlobalSettings.EnableShiftButtonForChangeView = GameSaveFile.Get("INSHIFTVIEW", false);
		inputShiftMenu = new DuskersMenuItem("[T]oggle View w/SHIFT\t", KeyCode.T, "Right", "Left", ToggleViewWithShift, ToggleViewWithShift, ToggleViewWithShift, num++)
		{
			TextValue = ((!GlobalSettings.EnableShiftButtonForChangeView) ? "Disabled" : "Enabled"),
			Description = "Enable SHIFT button (in addition to SPACE) as a toggle between Drone and Schematic views"
		};
		MenuPanelUI.Instance.AddMenuItem(inputShiftMenu);
		debugMessagesMenu = new DuskersMenuItem("Show D[e]bug Messages\t", KeyCode.E, "Right", "Left", DebugMessages, DebugMessages, DebugMessages, num++)
		{
			TextValue = ((!GameSaveFile.Get("O_DBG", false)) ? "Disabled" : "Enabled"),
			Description = "Help the programmers by being notified when particularly difficult to resove bugs happen"
		};
		MenuPanelUI.Instance.AddMenuItem(debugMessagesMenu);
		MenuPanelUI.Instance.AddMenuItem(null);
		num++;
		skinMenu = new DuskersMenuItem("[S]kin...", KeyCode.S, "Right", "Left", SkinChange, SkinIncrease, SkinDecrease, num++, GameplayManager.Instance != null)
		{
			TextValue = GlobalSettings.GameState.CurrentSkin.ToString(),
			Description = "Change game's theme (eg: Halloween)..."
		};
		MenuPanelUI.Instance.AddMenuItem(skinMenu);
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[G]raphical...", KeyCode.G, MenuGraphicalOptions, num++)
		{
			Description = "Tweak the graphic options for a better playing experience..."
		});
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[D]ifficulty...", KeyCode.D, MenuDifficultyOptions, num++, !(DungeonManager.Instance == null))
		{
			Description = "Adjustments vairous difficulty settings..."
		});
		MenuPanelUI.Instance.AddMenuItem(null);
		num++;
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[C]lear User Data", KeyCode.C, MenuClearUserData, num++)
		{
			Disabled = ((GalaxyMapManager.Instance != null || GameplayManager.Instance != null) ? true : false),
			Description = ((!(GalaxyMapManager.Instance != null) && !(GameplayManager.Instance != null)) ? "Delete all saved data" : "Go to Options from the Main Menu to clear the user data")
		});
		base.LoadMenu();
	}

	public void MenuClearUserData()
	{
		string text = "Are you sure?\r\n\r\nClearing user data will remove all saved settings, story progress, unlocked upgrades, reset introductory hints, etc.\r\n\r\nThis is only recommended for a brand new player.";
		if (GlobalSettings.cheatMode)
		{
			text += "\r\n\r\nGlobalSettings.Constants.GameConstants.CLEAR_AS_NEW_INSTALL will be overriden";
		}
		DialogUI.Instance.ShowDialog("Clear User Data", text, ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
		{
			if (result == ModalWindowResult.Yes)
			{
				MainMenu.ClearSavedGameData(MainMenu.ResetTypeEnum.FactoryReset);
				if (HelpManualScript.Instance.IsInitialized && HelpManual.Instance.helper != null)
				{
					HelpManual.Instance.helper.RefreshDroneUpdadeMenu();
				}
				SystemFileManager.SyncMapDataChanges();
				if (GalaxyProcessor.universeMapManager != null)
				{
					GalaxyProcessor.universeMapManager.Clear();
					GalaxyProcessor.universeMapManager = null;
				}
				MainMenu.Instance.ResetStaleDataState();
				MainMenu.Instance.RelaunchOptionsMenu = true;
				MenuPanelUI.Instance.PopMenu(this);
			}
		}, 1);
	}

	private void MasterVolumeIncrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_MASTER", item.SliderValue);
	}

	private void MasterVolumeDecrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_MASTER", item.SliderValue);
	}

	private void SkinChange()
	{
		SkinIncrease(null);
	}

	private void SkinIncrease(DuskersMenuItem item)
	{
		int currentSkin = (int)GlobalSettings.GameState.CurrentSkin;
		currentSkin++;
		if (currentSkin >= 2)
		{
			currentSkin = 0;
		}
		GlobalSettings.GameState.CurrentSkin = (SkinEnum)currentSkin;
		skinMenu.TextValue = GlobalSettings.GameState.CurrentSkin.ToString();
		if (ProgressUI.Instance != null)
		{
			if (GlobalSettings.GameState.CurrentSkin != SkinEnum.Default)
			{
				ProgressUI.Instance.skinObject.SetActive(true);
			}
			else
			{
				ProgressUI.Instance.skinObject.SetActive(false);
			}
		}
	}

	private void SkinDecrease(DuskersMenuItem item)
	{
		int currentSkin = (int)GlobalSettings.GameState.CurrentSkin;
		currentSkin--;
		if (currentSkin < 0)
		{
			currentSkin = 1;
		}
		GlobalSettings.GameState.CurrentSkin = (SkinEnum)currentSkin;
		skinMenu.TextValue = GlobalSettings.GameState.CurrentSkin.ToString();
		if (ProgressUI.Instance != null)
		{
			if (GlobalSettings.GameState.CurrentSkin != SkinEnum.Default)
			{
				ProgressUI.Instance.skinObject.SetActive(true);
			}
			else
			{
				ProgressUI.Instance.skinObject.SetActive(false);
			}
		}
	}

	private void MenuAudioOptions()
	{
		MenuPanelUI.Instance.Clear();
		AudioOptionMenu audioOptionMenu = new AudioOptionMenu();
	}

	private void MenuGraphicalOptions()
	{
		MenuPanelUI.Instance.Clear();
		GraphicalOptionsMenu graphicalOptionsMenu = new GraphicalOptionsMenu();
	}

	private void MenuDifficultyOptions()
	{
		MenuPanelUI.Instance.Clear();
		DifficultyOptionsMenu difficultyOptionsMenu = new DifficultyOptionsMenu();
	}

	private void MenuHints()
	{
		MenuHints(null);
	}

	private void MenuHints(DuskersMenuItem item)
	{
		bool value = !GameSaveFile.Get("HNT_DISABLE", false);
		GameSaveFile.Save("HNT_DISABLE", value);
		hintMenu.TextValue = ((!GameSaveFile.Get("HNT_DISABLE", false)) ? "Enabled" : "Disabled");
		hintVisibilityChanged = true;
	}

	private void MenuRunInBackground()
	{
		MenuRunInBackground(null);
	}

	private void MenuRunInBackground(DuskersMenuItem item)
	{
		bool flag = !GameSaveFile.Get("O_RIB", false);
		GameSaveFile.Save("O_RIB", flag);
		runInBackgroundMenu.TextValue = ((!GameSaveFile.Get("O_RIB", false)) ? "Disabled" : "Enabled");
		Application.runInBackground = flag;
	}

	private void ToggleViewWithShift()
	{
		ToggleViewWithShift(null);
	}

	private void ToggleViewWithShift(DuskersMenuItem item)
	{
		bool flag = !GameSaveFile.Get("INSHIFTVIEW", false);
		GameSaveFile.Save("INSHIFTVIEW", flag);
		inputShiftMenu.TextValue = ((!GameSaveFile.Get("INSHIFTVIEW", false)) ? "Disabled" : "Enabled");
		GlobalSettings.EnableShiftButtonForChangeView = flag;
	}

	private void DebugMessages()
	{
		DebugMessages(null);
	}

	private void DebugMessages(DuskersMenuItem item)
	{
		bool value = !GameSaveFile.Get("O_DBG", false);
		GameSaveFile.Save("O_DBG", value);
		debugMessagesMenu.TextValue = ((!GameSaveFile.Get("O_DBG", false)) ? "Disabled" : "Enabled");
	}

	private void ClearBestPlays()
	{
		ClearBestPlays(null);
	}

	private void ClearBestPlays(DuskersMenuItem item)
	{
		DialogUI.Instance.ShowDialog("Are you sure?", "Your best plays will be reset to 0.\r\n\r\nNote: this will NOT affect your current game!\r\n\r\nAre you sure you want to do this?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
		{
			if (result == ModalWindowResult.Yes)
			{
				GameSaveFile.Save("BestDaysSurvived", 0);
				clearBestPlaysMenu.TextValue = GameSaveFile.Get("BestDaysSurvived", 0).ToString();
			}
		}, 1);
	}

	private void DifficultyMenu()
	{
		DifficultyMenu(cheatDifficulty);
	}

	private void DifficultyMenu(DuskersMenuItem item)
	{
		GameSaveFile.Save("HARD", !GameSaveFile.Get("HARD", false));
		item.TextValue = ((!GameSaveFile.Get("HARD", false)) ? "Normal" : "Hard");
	}

	private void GalaxyMap()
	{
	}

	private void GalaxyMapIncrease(DuskersMenuItem item)
	{
		galaxyMapIdx++;
		if (galaxyMapIdx >= galaxyMapList.Count)
		{
			galaxyMapIdx = 0;
		}
		item.TextValue = galaxyMapList[galaxyMapIdx];
		GameSaveFile.Save("GALAXY_ID", item.TextValue);
		StarField.ClearOnMapChange();
		GalaxySaveFile.Reset();
	}

	private void GalaxyMapDecrease(DuskersMenuItem item)
	{
		galaxyMapIdx--;
		if (galaxyMapIdx < 0)
		{
			galaxyMapIdx = galaxyMapList.Count - 1;
		}
		item.TextValue = galaxyMapList[galaxyMapIdx];
		GameSaveFile.Save("GALAXY_ID", item.TextValue);
		StarField.ClearOnMapChange();
		GalaxySaveFile.Reset();
	}
}
