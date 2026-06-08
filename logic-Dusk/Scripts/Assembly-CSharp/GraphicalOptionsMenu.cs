using System.Collections.Generic;
using UnityEngine;

public class GraphicalOptionsMenu : MenuScreenClass
{
	private List<string> galaxyMapList = new List<string>();

	private DuskersMenuItem vsyncMenuItem;

	private DuskersMenuItem staleDataMenuItem;

	private DuskersMenuItem distortionMenuItem;

	private DuskersMenuItem noiseMenuItem;

	private DuskersMenuItem staticHUDOnlyMenuItem;

	private DuskersMenuItem staticHUDMenuItem;

	private DuskersMenuItem colorBlindMenuItem;

	private DuskersMenuItem farViewMenuItem;

	private DuskersMenuItem qualityGraphicsMenuItem;

	private DuskersMenuItem qualityWOMenuItem;

	private DuskersMenuItem animateTravelMenuItem;

	private DuskersMenuItem fontMenuItem;

	private DuskersMenuItem mousePointerMenuItem;

	private DuskersMenuItem refreshScreenMenuItem;

	protected override void Initialize()
	{
		base.ActiveText = "Graphics Options";
		base.Initialize();
	}

	public override void LoadMenu()
	{
		int num = 0;
		int num2 = GameSaveFile.Get("Q_VSYNC", QualitySettings.vSyncCount);
		DuskersMenuItem duskersMenuItem = new DuskersMenuItem("[V]Sync\t\t", KeyCode.V, "Right", "Left", VSync, VSync, VSyncDec, num++);
		DuskersMenuItem duskersMenuItem2 = duskersMenuItem;
		object textValue;
		switch (num2)
		{
		case 0:
			textValue = "Don't Sync";
			break;
		case 1:
			textValue = "Every Frame";
			break;
		default:
			textValue = "Every Other Frame";
			break;
		}
		duskersMenuItem2.TextValue = (string)textValue;
		duskersMenuItem.Description = "Reduce frame syncing at risk of tearing (Sync = slower CPU, greater stability)";
		vsyncMenuItem = duskersMenuItem;
		MenuPanelUI.Instance.AddMenuItem(vsyncMenuItem);
		staleDataMenuItem = new DuskersMenuItem("[S]tale Data\t\t", KeyCode.S, "Right", "Left", StaleData, StaleData, StaleData, num++)
		{
			TextValue = ((!GameSaveFile.Get("Q_STALE", true)) ? "Disabled" : "Enabled"),
			Description = "When disabled, only data directly in-front of the drone will be visible (reduced CPU/GPU)"
		};
		MenuPanelUI.Instance.AddMenuItem(staleDataMenuItem);
		distortionMenuItem = new DuskersMenuItem("[D]istortion\t\t", KeyCode.D, "Right", "Left", DistortionOverlay, DistortionOverlay, DistortionOverlay, num++)
		{
			TextValue = ((!GameSaveFile.Get("Q_DIST", true)) ? "Disabled" : "Enabled"),
			Description = "Use to disable the screen waviness of drone view"
		};
		MenuPanelUI.Instance.AddMenuItem(distortionMenuItem);
		int num3 = GameSaveFile.Get("Q_NOISE", 0);
		duskersMenuItem = new DuskersMenuItem("[N]oise\t\t", KeyCode.N, "Right", "Left", NoiseOverlay, NoiseOverlay, NoiseOverlayDec, num++);
		DuskersMenuItem duskersMenuItem3 = duskersMenuItem;
		object textValue2;
		switch (num3)
		{
		case 0:
			textValue2 = "Normal";
			break;
		case 1:
			textValue2 = "Low";
			break;
		default:
			textValue2 = "Off";
			break;
		}
		duskersMenuItem3.TextValue = (string)textValue2;
		duskersMenuItem.Description = "Use to reduce/disable the visual monitor noise on the screen";
		noiseMenuItem = duskersMenuItem;
		MenuPanelUI.Instance.AddMenuItem(noiseMenuItem);
		colorBlindMenuItem = new DuskersMenuItem("Co[l]or Blind Mode\t\t", KeyCode.L, "Right", "Left", ColorBlindToggle, ColorBlindToggle, ColorBlindToggle, num++)
		{
			TextValue = ((!GameSaveFile.Get("O_CB", false)) ? "Disabled" : "Enabled"),
			Description = "Toggles some colors to more color-blind friendly colors"
		};
		MenuPanelUI.Instance.AddMenuItem(colorBlindMenuItem);
		staticHUDOnlyMenuItem = new DuskersMenuItem("[H]UD Static\t\t", KeyCode.H, "Right", "Left", HUDStaticOverlay, HUDStaticOverlay, HUDStaticOverlay, num++)
		{
			TextValue = ((!GameSaveFile.Get("Q_STATIC_HONLY", true)) ? "Disabled" : "Enabled"),
			Description = "Use to disable the static that affects only the HUD elements in DV (reduced GPU/CPU)"
		};
		MenuPanelUI.Instance.AddMenuItem(staticHUDOnlyMenuItem);
		staticHUDMenuItem = new DuskersMenuItem("Static [I]ndicator\t\t", KeyCode.I, "Right", "Left", DVStaticOverlay, DVStaticOverlay, DVStaticOverlay, num++)
		{
			TextValue = ((!GameSaveFile.Get("Q_STATIC_H", true)) ? "Disabled" : "Enabled"),
			Description = "Use to disable the visual static indicator that affects the entire DV (reduced GPU/CPU)"
		};
		MenuPanelUI.Instance.AddMenuItem(staticHUDMenuItem);
		MenuPanelUI.Instance.AddMenuItem(null);
		num++;
		int performanceFarView = GlobalSettings.PerformanceFarView;
		duskersMenuItem = new DuskersMenuItem("[F]ar View\t\t", KeyCode.F, "Right", "Left", FarView, FarView, FarViewDec, num++);
		DuskersMenuItem duskersMenuItem4 = duskersMenuItem;
		object textValue3;
		switch (performanceFarView)
		{
		case 0:
			textValue3 = "Full";
			break;
		case 1:
			textValue3 = "Simple";
			break;
		default:
			textValue3 = "None";
			break;
		}
		duskersMenuItem4.TextValue = (string)textValue3;
		duskersMenuItem.Description = "Setting to 'Simple' or 'None' will cause rooms to \"pop\" into view (reduced CPU)";
		farViewMenuItem = duskersMenuItem;
		MenuPanelUI.Instance.AddMenuItem(farViewMenuItem);
		DroneManager.QualityEnum qualityEnum = (DroneManager.QualityEnum)GameSaveFile.Get("P_QG", 0);
		duskersMenuItem = new DuskersMenuItem("[Q]uality\t\t", KeyCode.Q, "Right", "Left", QualityGraphics, QualityGraphics, QualityGraphicsDec, num++);
		DuskersMenuItem duskersMenuItem5 = duskersMenuItem;
		object textValue4;
		switch (qualityEnum)
		{
		case DroneManager.QualityEnum.HighOrDefault:
			textValue4 = "High";
			break;
		case DroneManager.QualityEnum.Medium:
			textValue4 = "Medium";
			break;
		default:
			textValue4 = "Low";
			break;
		}
		duskersMenuItem5.TextValue = (string)textValue4;
		duskersMenuItem.Description = "Quality of the Drone View look.  (High looks better, heavier GPU)";
		qualityGraphicsMenuItem = duskersMenuItem;
		MenuPanelUI.Instance.AddMenuItem(qualityGraphicsMenuItem);
		int num4 = GameSaveFile.Get("P_QWO", 0);
		duskersMenuItem = new DuskersMenuItem("[C]lutter\t\t", KeyCode.C, "Right", "Left", QualityWorldObjects, QualityWorldObjects, QualityWorldObjectsDec, num++);
		DuskersMenuItem duskersMenuItem6 = duskersMenuItem;
		object textValue5;
		switch (num4)
		{
		case 0:
			textValue5 = "Normal";
			break;
		case 1:
			textValue5 = "Medium";
			break;
		default:
			textValue5 = "Few";
			break;
		}
		duskersMenuItem6.TextValue = (string)textValue5;
		duskersMenuItem.Description = "Adjusts amount of clutter in rooms.  (Normal looks better, heavier CPU)";
		qualityWOMenuItem = duskersMenuItem;
		MenuPanelUI.Instance.AddMenuItem(qualityWOMenuItem);
		animateTravelMenuItem = new DuskersMenuItem("[A]nimate Ship Travel\t\t", KeyCode.A, "Right", "Left", AnimateShipTravel, AnimateShipTravel, AnimateShipTravel, num++)
		{
			TextValue = ((!GameSaveFile.Get("D_ANSHP", true)) ? "Disabled" : "Enabled"),
			Description = "Disabled = don't show player ship traveling between points on map"
		};
		MenuPanelUI.Instance.AddMenuItem(animateTravelMenuItem);
		if (SteamManager.Initialized)
		{
			refreshScreenMenuItem = new DuskersMenuItem("[R]efresh After Steam Overlay\t", KeyCode.R, "Right", "Left", RefreshFullScreen, RefreshFullScreen, RefreshFullScreen, num++)
			{
				TextValue = ((!GameSaveFile.Get("O_RFS", false)) ? "Disabled" : "Enabled"),
				Description = "Enabled = refresh after Steam overlay closed in FS (cleans artifacts left behind in FS, will cause screen flash)"
			};
			MenuPanelUI.Instance.AddMenuItem(refreshScreenMenuItem);
		}
		MenuPanelUI.Instance.AddMenuItem(null);
		num++;
		int result = 0;
		string setting = ConfigFile.GetSetting("ConsoleFontSize");
		if (!int.TryParse(setting, out result))
		{
			result = 14;
		}
		fontMenuItem = new DuskersMenuItem("C[o]nsole Font Size\t\t", KeyCode.O, "Right", "Left", FontSize, FontSizeInc, FontSizeDec, num++)
		{
			TextValue = result.ToString(),
			Description = "Adjusts the font-size of the in-game console"
		};
		MenuPanelUI.Instance.AddMenuItem(fontMenuItem);
		mousePointerMenuItem = new DuskersMenuItem("Auto-Hide [M]ouse Pointer\t\t", KeyCode.M, "Right", "Left", AutoHideMouse, AutoHideMouse, AutoHideMouse, num++)
		{
			TextValue = ((!GameSaveFile.Get("O_AHM", true)) ? "Disabled" : "Enabled"),
			Description = "Disabled = mouse always shows.  Enabled = mouse hides when not being used."
		};
		MenuPanelUI.Instance.AddMenuItem(mousePointerMenuItem);
		base.LoadMenu();
	}

	private void VSync()
	{
		VSync(null);
	}

	private void VSync(DuskersMenuItem item)
	{
		if (QualitySettings.vSyncCount < 2)
		{
			QualitySettings.vSyncCount++;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
		}
		vsyncMenuItem.TextValue = ((QualitySettings.vSyncCount == 0) ? "Don't Sync" : ((QualitySettings.vSyncCount != 1) ? "Every Other Frame" : "Every Frame"));
		GameSaveFile.Save("Q_VSYNC", QualitySettings.vSyncCount);
	}

	private void VSyncDec(DuskersMenuItem item)
	{
		if (QualitySettings.vSyncCount > 0)
		{
			QualitySettings.vSyncCount--;
		}
		else
		{
			QualitySettings.vSyncCount = 2;
		}
		vsyncMenuItem.TextValue = ((QualitySettings.vSyncCount == 0) ? "Don't Sync" : ((QualitySettings.vSyncCount != 1) ? "Every Other Frame" : "Every Frame"));
		GameSaveFile.Save("Q_VSYNC", QualitySettings.vSyncCount);
	}

	private void StaleData()
	{
		StaleData(null);
	}

	private void StaleData(DuskersMenuItem item)
	{
		GameSaveFile.Save("Q_STALE", !GameSaveFile.Get("Q_STALE", true));
		staleDataMenuItem.TextValue = ((!GameSaveFile.Get("Q_STALE", true)) ? "Disabled" : "Enabled");
		if (!(DroneManager.Instance != null))
		{
			return;
		}
		foreach (Drone drones in DroneManager.Instance.dronesList)
		{
			drones.DVP.RefreshPostSetting();
		}
		DroneManager.Instance.CurrentDrone.SetDroneNumber(DroneManager.Instance.CurrentDrone.DroneNumber);
	}

	private void DistortionOverlay()
	{
		DistortionOverlay(null);
	}

	private void DistortionOverlay(DuskersMenuItem item)
	{
		GameSaveFile.Save("Q_DIST", !GameSaveFile.Get("Q_DIST", true));
		distortionMenuItem.TextValue = ((!GameSaveFile.Get("Q_DIST", true)) ? "Disabled" : "Enabled");
		if (!(DroneManager.Instance != null))
		{
			return;
		}
		foreach (Drone drones in DroneManager.Instance.dronesList)
		{
			drones.DVP.RefreshPostSetting();
		}
		DroneManager.Instance.CurrentDrone.SetDroneNumber(DroneManager.Instance.CurrentDrone.DroneNumber);
	}

	private void HUDStaticOverlay()
	{
		HUDStaticOverlay(null);
	}

	private void HUDStaticOverlay(DuskersMenuItem item)
	{
		GameSaveFile.Save("Q_STATIC_HONLY", !GameSaveFile.Get("Q_STATIC_HONLY", true));
		staticHUDOnlyMenuItem.TextValue = ((!GameSaveFile.Get("Q_STATIC_HONLY", true)) ? "Disabled" : "Enabled");
		if (DroneManager.Instance != null)
		{
			DroneManager.Instance.SetUseHUDOverlayCamera(GameSaveFile.Get("Q_STATIC_HONLY", true));
		}
	}

	private void DVStaticOverlay()
	{
		DVStaticOverlay(null);
	}

	private void DVStaticOverlay(DuskersMenuItem item)
	{
		GameSaveFile.Save("Q_STATIC_H", !GameSaveFile.Get("Q_STATIC_H", true));
		staticHUDMenuItem.TextValue = ((!GameSaveFile.Get("Q_STATIC_H", true)) ? "Disabled" : "Enabled");
		if (DroneManager.Instance != null)
		{
			DroneManager.Instance.SetUseGlobalGlitchEffects(GameSaveFile.Get("Q_STATIC_H", true));
		}
	}

	private void ColorBlindToggle()
	{
		ColorBlindToggle(null);
	}

	private void ColorBlindToggle(DuskersMenuItem item)
	{
		GameSaveFile.Save("O_CB", !GameSaveFile.Get("O_CB", false));
		colorBlindMenuItem.TextValue = ((!GameSaveFile.Get("O_CB", false)) ? "Disabled" : "Enabled");
		if (DroneManager.Instance != null)
		{
			DroneManager.Instance.SetUseGlobalGlitchEffects(GameSaveFile.Get("O_CB", false));
		}
	}

	private void NoiseOverlay()
	{
		NoiseOverlay(null);
	}

	private void NoiseOverlay(DuskersMenuItem item)
	{
		int num = GameSaveFile.Get("Q_NOISE", 0);
		num++;
		if (num > 2)
		{
			num = 0;
		}
		GameSaveFile.Save("Q_NOISE", num);
		DuskersMenuItem duskersMenuItem = noiseMenuItem;
		object textValue;
		switch (num)
		{
		case 0:
			textValue = "Normal";
			break;
		case 1:
			textValue = "Low";
			break;
		default:
			textValue = "Off";
			break;
		}
		duskersMenuItem.TextValue = (string)textValue;
		if (NoiseEffect.InstanceList == null)
		{
			return;
		}
		int count = NoiseEffect.InstanceList.Count;
		for (int i = 0; i < count; i++)
		{
			NoiseEffect noiseEffect = NoiseEffect.InstanceList[i];
			if (!(noiseEffect != null))
			{
				continue;
			}
			if (num != 2)
			{
				noiseEffect.enabled = true;
				float grainIntensityMin;
				switch (num)
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
				switch (num)
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

	private void NoiseOverlayDec(DuskersMenuItem item)
	{
		int num = GameSaveFile.Get("Q_NOISE", 0);
		num--;
		if (num < 0)
		{
			num = 2;
		}
		GameSaveFile.Save("Q_NOISE", num);
		DuskersMenuItem duskersMenuItem = noiseMenuItem;
		object textValue;
		switch (num)
		{
		case 0:
			textValue = "Normal";
			break;
		case 1:
			textValue = "Low";
			break;
		default:
			textValue = "Off";
			break;
		}
		duskersMenuItem.TextValue = (string)textValue;
		if (NoiseEffect.InstanceList == null)
		{
			return;
		}
		int count = NoiseEffect.InstanceList.Count;
		for (int i = 0; i < count; i++)
		{
			NoiseEffect noiseEffect = NoiseEffect.InstanceList[i];
			if (!(noiseEffect != null))
			{
				continue;
			}
			if (num != 2)
			{
				noiseEffect.enabled = true;
				float grainIntensityMin;
				switch (num)
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
				switch (num)
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

	private void FontSize()
	{
		FontSizeInc(null);
	}

	private void FontSizeInc(DuskersMenuItem item)
	{
		int result = 0;
		string setting = ConfigFile.GetSetting("ConsoleFontSize");
		if (!int.TryParse(setting, out result))
		{
			result = 14;
		}
		result++;
		if (result > 24)
		{
			result = 8;
		}
		ConfigFile.SaveSetting("ConsoleFontSize", result.ToString());
		fontMenuItem.TextValue = result.ToString();
		if (ConsoleWindow3.Instance != null)
		{
			ConsoleWindow3.Instance.SetFontSize(result);
		}
	}

	private void FontSizeDec(DuskersMenuItem item)
	{
		int result = 0;
		string setting = ConfigFile.GetSetting("ConsoleFontSize");
		if (!int.TryParse(setting, out result))
		{
			result = 14;
		}
		result--;
		if (result < 8)
		{
			result = 24;
		}
		ConfigFile.SaveSetting("ConsoleFontSize", result.ToString());
		fontMenuItem.TextValue = result.ToString();
		if (ConsoleWindow3.Instance != null)
		{
			ConsoleWindow3.Instance.SetFontSize(result);
		}
	}

	private void FarView()
	{
		FarView(null);
	}

	private void FarView(DuskersMenuItem item)
	{
		int num = GameSaveFile.Get("P_FARVIEW", 0);
		num++;
		if (num > 2)
		{
			num = 0;
		}
		GameSaveFile.Save("P_FARVIEW", num);
		DuskersMenuItem duskersMenuItem = farViewMenuItem;
		object textValue;
		switch (num)
		{
		case 0:
			textValue = "Full";
			break;
		case 1:
			textValue = "Simple";
			break;
		default:
			textValue = "None";
			break;
		}
		duskersMenuItem.TextValue = (string)textValue;
		GlobalSettings.PerformanceFarView = num;
	}

	private void FarViewDec(DuskersMenuItem item)
	{
		int num = GameSaveFile.Get("P_FARVIEW", 0);
		num--;
		if (num < 0)
		{
			num = 2;
		}
		GameSaveFile.Save("P_FARVIEW", num);
		DuskersMenuItem duskersMenuItem = farViewMenuItem;
		object textValue;
		switch (num)
		{
		case 0:
			textValue = "Full";
			break;
		case 1:
			textValue = "Simple";
			break;
		default:
			textValue = "None";
			break;
		}
		duskersMenuItem.TextValue = (string)textValue;
		GlobalSettings.PerformanceFarView = num;
	}

	private void QualityGraphics()
	{
		QualityGraphics(null);
	}

	private void QualityGraphics(DuskersMenuItem item)
	{
		DroneManager.QualityEnum qualityEnum = (DroneManager.QualityEnum)GameSaveFile.Get("P_QG", 0);
		int num = (int)qualityEnum;
		num++;
		if (num > 2)
		{
			num = 0;
		}
		qualityEnum = (DroneManager.QualityEnum)num;
		GameSaveFile.Save("P_QG", (int)qualityEnum);
		DuskersMenuItem duskersMenuItem = qualityGraphicsMenuItem;
		object textValue;
		switch (qualityEnum)
		{
		case DroneManager.QualityEnum.HighOrDefault:
			textValue = "High";
			break;
		case DroneManager.QualityEnum.Medium:
			textValue = "Medium";
			break;
		default:
			textValue = "Low";
			break;
		}
		duskersMenuItem.TextValue = (string)textValue;
		if (DroneManager.Instance != null)
		{
			DroneManager.Instance.SetQuality(qualityEnum);
		}
	}

	private void QualityGraphicsDec(DuskersMenuItem item)
	{
		DroneManager.QualityEnum qualityEnum = (DroneManager.QualityEnum)GameSaveFile.Get("P_QG", 0);
		int num = (int)qualityEnum;
		num--;
		if (num < 0)
		{
			num = 2;
		}
		qualityEnum = (DroneManager.QualityEnum)num;
		GameSaveFile.Save("P_QG", (int)qualityEnum);
		DuskersMenuItem duskersMenuItem = qualityGraphicsMenuItem;
		object textValue;
		switch (qualityEnum)
		{
		case DroneManager.QualityEnum.HighOrDefault:
			textValue = "High";
			break;
		case DroneManager.QualityEnum.Medium:
			textValue = "Medium";
			break;
		default:
			textValue = "Low";
			break;
		}
		duskersMenuItem.TextValue = (string)textValue;
		if (DroneManager.Instance != null)
		{
			DroneManager.Instance.SetQuality(qualityEnum);
		}
	}

	private void QualityWorldObjects()
	{
		QualityWorldObjects(null);
	}

	private void QualityWorldObjects(DuskersMenuItem item)
	{
		int num = GameSaveFile.Get("P_QWO", 0);
		num++;
		if (num > 2)
		{
			num = 0;
		}
		GameSaveFile.Save("P_QWO", num);
		DuskersMenuItem duskersMenuItem = qualityWOMenuItem;
		object textValue;
		switch (num)
		{
		case 0:
			textValue = "Normal";
			break;
		case 1:
			textValue = "Medium";
			break;
		default:
			textValue = "Few";
			break;
		}
		duskersMenuItem.TextValue = (string)textValue;
	}

	private void QualityWorldObjectsDec(DuskersMenuItem item)
	{
		int num = GameSaveFile.Get("P_QWO", 0);
		num--;
		if (num < 0)
		{
			num = 2;
		}
		GameSaveFile.Save("P_QWO", num);
		DuskersMenuItem duskersMenuItem = qualityWOMenuItem;
		object textValue;
		switch (num)
		{
		case 0:
			textValue = "Normal";
			break;
		case 1:
			textValue = "Medium";
			break;
		default:
			textValue = "Few";
			break;
		}
		duskersMenuItem.TextValue = (string)textValue;
	}

	private void AnimateShipTravel()
	{
		AnimateShipTravel(null);
	}

	private void AnimateShipTravel(DuskersMenuItem item)
	{
		GameSaveFile.Save("D_ANSHP", !GameSaveFile.Get("D_ANSHP", true));
		animateTravelMenuItem.TextValue = ((!GameSaveFile.Get("D_ANSHP", true)) ? "Disabled" : "Enabled");
	}

	private void RefreshFullScreen()
	{
		RefreshFullScreen(null);
	}

	private void RefreshFullScreen(DuskersMenuItem item)
	{
		GameSaveFile.Save("O_RFS", !GameSaveFile.Get("O_RFS", false));
		refreshScreenMenuItem.TextValue = ((!GameSaveFile.Get("O_RFS", false)) ? "Disabled" : "Enabled");
	}

	private void AutoHideMouse()
	{
		AutoHideMouse(null);
	}

	private void AutoHideMouse(DuskersMenuItem item)
	{
		GameSaveFile.Save("O_AHM", !GameSaveFile.Get("O_AHM", true));
		mousePointerMenuItem.TextValue = ((!GameSaveFile.Get("O_AHM", true)) ? "Disabled" : "Enabled");
		if (SceneLevelInput.Instance != null)
		{
			SceneLevelInput.Instance.RefreshAutoHideState();
		}
	}
}
