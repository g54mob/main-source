using Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles;
using Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap;
using Assets.Nimbatus.GUI.MissionControl.Scripts.Main;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts
{
	public class ManageSandboxSettings : MonoBehaviour
	{
		public GameObject SettingsPanel;

		public SaveFileGameSettingsPanel Settings;

		public MissionControlUiManager UiManager;

		public GalaxyMapUiManager GalaxyMap;

		private bool _hadFreeExploration;

		public void OnEnable()
		{
			SaveFileGameSettingsPanel.SettingsApplied += Settings_SettingsApplied;
		}

		public void OnDisable()
		{
			SaveFileGameSettingsPanel.SettingsApplied -= Settings_SettingsApplied;
		}

		public void Start()
		{
			SettingsPanel.SetActive(false);
			if (RuntimeGlobals.GameMode == EGameMode.Creative)
			{
				base.gameObject.SetActive(true);
			}
			else
			{
				base.gameObject.SetActive(false);
			}
		}

		public void Close()
		{
			Settings_SettingsApplied();
		}

		public void ToSettings()
		{
			_hadFreeExploration = RuntimeGlobals.GameModeSettings.FreeExploration;
			SettingsPanel.SetActive(true);
			Settings.gameObject.SetActive(true);
			Settings.Init(RuntimeGlobals.GameMode, RuntimeGlobals.GameModeSettings);
		}

		private void Settings_SettingsApplied()
		{
			SettingsPanel.SetActive(false);
			Settings.gameObject.SetActive(false);
			UiManager.UpdateUi();
			UiManager.LocationDisplay.Init(UiManager, SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation);
			bool freeExploration = RuntimeGlobals.GameModeSettings.FreeExploration;
			if (_hadFreeExploration == freeExploration)
			{
				return;
			}
			if (!freeExploration)
			{
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Sectors.ForEach(delegate(GalaxyMapSector s)
				{
					s.SetExplored(false);
				});
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.GetLocationById(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.StartLocationId).Sector.SetExplored(true);
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.Sector.SetExplored(true);
			}
			GalaxyMap.ReloadMap(freeExploration);
			_hadFreeExploration = freeExploration;
		}
	}
}
