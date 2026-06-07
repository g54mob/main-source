using Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Controls;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main
{
	public class MissionControlUiManager : MonoBehaviour
	{
		public enum EMissonControlMode
		{
			Default = 0,
			Upgrades = 1,
			Options = 2
		}

		public NimbatusHealthDisplay HealthDisplay;

		public ThreatLevelDisplay ThreatDisplay;

		public GalaxyMapUiManager GalaxyMap;

		public LocationDetailDisplay LocationDisplay;

		public ManageSandboxSettings Settings;

		public UIGrid ButtonsGrid;

		public UIButtonOffset UpgradesButton;

		public UIButtonOffset HangarButton;

		public UIButtonOffset OptionsButton;

		public GameObject UpgradePanel;

		public GameObject OptionsPanel;

		public GameObject BackToDefaultButton;

		public GameObject BackToMenuButton;

		private EMissonControlMode _currentMode;

		private EMissonControlMode _previousMode;

		private LocationData _selectedLocation;

		public LocationData CurrentLocation
		{
			get
			{
				if (!(GalaxyMap.CurrentLocation != null))
				{
					return null;
				}
				return GalaxyMap.CurrentLocation.Location;
			}
		}

		public LocationData SelectedLocation
		{
			get
			{
				if (!(GalaxyMap.SelectedLocation != null))
				{
					return null;
				}
				return GalaxyMap.SelectedLocation.Location;
			}
		}

		public void Start()
		{
			UpdateUi();
			ThreatDisplay.Init(this);
			LocationDisplay.Init(this, SelectedLocation);
			Toggle(EMissonControlMode.Default);
		}

		public void Update()
		{
			if (SelectedLocation != _selectedLocation)
			{
				LocationDisplay.Init(this, SelectedLocation);
				_selectedLocation = SelectedLocation;
			}
			if (_currentMode == EMissonControlMode.Upgrades)
			{
				UpgradesButton.OverrideHover();
			}
			else if (_currentMode == EMissonControlMode.Options)
			{
				OptionsButton.OverrideHover();
			}
			if (_previousMode != _currentMode)
			{
				UpgradesButton.OnHover(_currentMode == EMissonControlMode.Upgrades);
				OptionsButton.OnHover(_currentMode == EMissonControlMode.Options);
				_previousMode = _currentMode;
			}
		}

		public void UpdateUi()
		{
			HealthDisplay.gameObject.SetActive(RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat);
			ThreatDisplay.gameObject.SetActive(RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat);
			if (RuntimeGlobals.GameModeSettings.InCampaignTutorial)
			{
				UpgradesButton.gameObject.SetActive(false);
				HangarButton.gameObject.SetActive(false);
			}
			ButtonsGrid.hideInactive = true;
			ButtonsGrid.enabled = true;
			ButtonsGrid.Reposition();
		}

		public void TravelToSelectedLocation()
		{
			GalaxyMap.TravelToSelectedLocation();
		}

		public void VisitCurrentLocation()
		{
			GalaxyMap.VisitCurrentLocation();
		}

		private void Toggle(EMissonControlMode mode)
		{
			_currentMode = mode;
			if (_previousMode == EMissonControlMode.Upgrades)
			{
				Settings.Close();
			}
			UpgradePanel.SetActive(_currentMode == EMissonControlMode.Upgrades);
			OptionsPanel.SetActive(_currentMode == EMissonControlMode.Options);
			LocationDisplay.gameObject.SetActive(_currentMode == EMissonControlMode.Default);
			BackToDefaultButton.SetActive(_currentMode != EMissonControlMode.Default);
			BackToMenuButton.SetActive(_currentMode == EMissonControlMode.Default);
			StarmapCamera.Instance.enabled = _currentMode == EMissonControlMode.Default;
			if (_previousMode == EMissonControlMode.Upgrades)
			{
				int upgradeLevel = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(EMothershipUpgradeType.Bridge);
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.ScanGalaxy(upgradeLevel);
				GalaxyMap.ReloadMap(RuntimeGlobals.GameModeSettings.FreeExploration);
			}
		}

		public void ToUpgrades()
		{
			Toggle((_currentMode != EMissonControlMode.Upgrades) ? EMissonControlMode.Upgrades : EMissonControlMode.Default);
		}

		public void ToOptions()
		{
			Toggle((_currentMode != EMissonControlMode.Options) ? EMissonControlMode.Options : EMissonControlMode.Default);
		}

		public void ToDefault()
		{
			Toggle(EMissonControlMode.Default);
		}
	}
}
