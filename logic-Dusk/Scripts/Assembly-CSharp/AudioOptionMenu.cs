using UnityEngine;

public class AudioOptionMenu : MenuScreenClass
{
	private DuskersMenuItem volumeAlertsMenu;

	private DuskersMenuItem volumeInterfaceMenu;

	private DuskersMenuItem volumeRemoteMenu;

	private DuskersMenuItem volumeSchematicMenu;

	private DuskersMenuItem volumeAmbienceMenu;

	private DuskersMenuItem volumeSignalMenu;

	protected override void Initialize()
	{
		base.ActiveText = "Audio Options";
		base.IgnoreCancel = false;
		base.Initialize();
	}

	public override void LoadMenu()
	{
		float num = GameSaveFile.Get("VOL_MASTER", 1f);
		int num2 = 0;
		MenuPanelUI.Instance.AddMenuItem(new DuskersMenuItem("[M]aster Volume\t\t", num, KeyCode.M, "Right", "Left", MasterVolumeIncrease, MasterVolumeDecrease, num2++)
		{
			Description = "Master volume adjusts all other volume levels"
		});
		volumeAlertsMenu = new DuskersMenuItem("[A]lerts\t\t", GameSaveFile.Get("VOL_ALERTS", GlobalSettings.SFXVolume), num, KeyCode.A, "Right", "Left", SFXVolumeIncrease, SFXVolumeDecrease, num2++)
		{
			Description = "Volume for general, system, and enemy alerts"
		};
		MenuPanelUI.Instance.AddMenuItem(volumeAlertsMenu);
		volumeInterfaceMenu = new DuskersMenuItem("[I]nterface\t\t", GameSaveFile.Get("VOL_INTERFACE", GlobalSettings.SFXVolumeInterface), num, KeyCode.I, "Right", "Left", SFXVolumeInterfaceIncrease, SFXVolumeInterfaceDecrease, num2++)
		{
			Description = "Volume for detecting and picking up objects"
		};
		MenuPanelUI.Instance.AddMenuItem(volumeInterfaceMenu);
		volumeRemoteMenu = new DuskersMenuItem("R[e]mote\t\t", GameSaveFile.Get("VOL_REMOTE", GlobalSettings.SFXVolumeRemote), num, KeyCode.E, "Right", "Left", SFXVolumeRemoteIncrease, SFXVolumeRemoteDecrease, num2++)
		{
			Description = "Volume for various remote (Drone View) sounds"
		};
		MenuPanelUI.Instance.AddMenuItem(volumeRemoteMenu);
		volumeSchematicMenu = new DuskersMenuItem("[S]chematic\t\t", GameSaveFile.Get("VOL_SCHEMATIC", GlobalSettings.SFXVolumeSchematic), num, KeyCode.S, "Right", "Left", SFXVolumeSchematicIncrease, SFXVolumeSchematicDecrease, num2++)
		{
			Description = "Volume for various Schematic View sounds"
		};
		MenuPanelUI.Instance.AddMenuItem(volumeSchematicMenu);
		volumeAmbienceMenu = new DuskersMenuItem("Ambien[c]e\t\t", GameSaveFile.Get("VOL_AMBIENCE", GlobalSettings.SFXVolumeRemoteAmbience), num, KeyCode.C, "Right", "Left", SFXVolumeAmbienceIncrease, SFXVolumeAmbienceDecrease, num2++)
		{
			Description = "Volume for ambient sounds"
		};
		MenuPanelUI.Instance.AddMenuItem(volumeAmbienceMenu);
		volumeSignalMenu = new DuskersMenuItem("Sig[n]al\t\t", GameSaveFile.Get("VOL_CALLSIGNAL", GlobalSettings.SFXDroneCallSignal), num, KeyCode.N, "Right", "Left", SFXVolumeCallSignalIncrease, SFXVolumeCallSignalIncrease, num2++)
		{
			Description = "Volume for drone call signals"
		};
		MenuPanelUI.Instance.AddMenuItem(volumeSignalMenu);
		base.LoadMenu();
	}

	private void MasterVolumeIncrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_MASTER", item.SliderValue);
		volumeAlertsMenu.SliderValueFactor = item.SliderValue;
		volumeInterfaceMenu.SliderValueFactor = item.SliderValue;
		volumeRemoteMenu.SliderValueFactor = item.SliderValue;
		volumeSchematicMenu.SliderValueFactor = item.SliderValue;
		volumeAmbienceMenu.SliderValueFactor = item.SliderValue;
		volumeSignalMenu.SliderValueFactor = item.SliderValue;
		MenuPanelUI.Instance.RefreshAllValues();
	}

	private void MasterVolumeDecrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_MASTER", item.SliderValue);
		volumeAlertsMenu.SliderValueFactor = item.SliderValue;
		volumeInterfaceMenu.SliderValueFactor = item.SliderValue;
		volumeRemoteMenu.SliderValueFactor = item.SliderValue;
		volumeSchematicMenu.SliderValueFactor = item.SliderValue;
		volumeAmbienceMenu.SliderValueFactor = item.SliderValue;
		volumeSignalMenu.SliderValueFactor = item.SliderValue;
		MenuPanelUI.Instance.RefreshAllValues();
	}

	private void SFXVolumeIncrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_ALERTS", item.SliderValue);
	}

	private void SFXVolumeDecrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_ALERTS", item.SliderValue);
	}

	private void SFXVolumeInterfaceIncrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_INTERFACE", item.SliderValue);
	}

	private void SFXVolumeInterfaceDecrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_INTERFACE", item.SliderValue);
	}

	private void SFXVolumeRemoteIncrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_REMOTE", item.SliderValue);
	}

	private void SFXVolumeRemoteDecrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_REMOTE", item.SliderValue);
	}

	private void SFXVolumeSchematicIncrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_SCHEMATIC", item.SliderValue);
	}

	private void SFXVolumeSchematicDecrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_SCHEMATIC", item.SliderValue);
	}

	private void SFXVolumeAmbienceIncrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_AMBIENCE", item.SliderValue);
	}

	private void SFXVolumeAmbienceDecrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_AMBIENCE", item.SliderValue);
	}

	private void SFXVolumeCallSignalIncrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_CALLSIGNAL", item.SliderValue);
	}

	private void SFXVolumeCallSignalDecrease(DuskersMenuItem item)
	{
		GameSaveFile.Save("VOL_CALLSIGNAL", item.SliderValue);
	}
}
