using System;
using Assets.Nimbatus.GUI.SandboxSettings.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class SaveFileGameSettingsPanel : MonoBehaviour
	{
		private GameModeSettings _settings;

		private bool _inMenu;

		public SeedSettingsUi SeedInput;

		public SliderSettingsUi DroneHealthSlider;

		public SliderSettingsUi EnemyHealthSlider;

		public SliderSettingsUi EnemyDamageSlider;

		public CheckboxSettingsUi PartUnlockingToggle;

		public CheckboxSettingsUi HealthThreatToggle;

		public CheckboxSettingsUi DeployCostToggle;

		public SliderSettingsUi MaxHealthSlider;

		public SliderSettingsUi ThreatScaleSlider;

		public CheckboxSettingsUi CustomizablePlanets;

		public CheckboxSettingsUi FreeExplorationToggle;

		public CheckboxSettingsUi FreeWeaponUpgradesToggle;

		public CheckboxSettingsUi FreeNimbatusUpgradesToggle;

		public static event Action SettingsApplied;

		public void Update()
		{
			MaxHealthSlider.Activate(HealthThreatToggle.Value);
			ThreatScaleSlider.Activate(HealthThreatToggle.Value);
		}

		public void Init(EGameMode mode, GameModeSettings settings)
		{
			_inMenu = SaveManager.LoadedSave == null;
			SeedInput.Activate(_inMenu);
			PartUnlockingToggle.Activate(_inMenu);
			_settings = settings;
			SeedInput.Value = settings.Seed.ToString();
			DroneHealthSlider.Value = settings.DronePartHealth;
			EnemyHealthSlider.Value = settings.EnemyHealth;
			EnemyDamageSlider.Value = settings.EnemyDamage;
			PartUnlockingToggle.Value = settings.HasPartUnlocking;
			HealthThreatToggle.Value = settings.NimbatusHealthAndThreat;
			DeployCostToggle.Value = settings.DeployCost;
			MaxHealthSlider.Value = settings.MaxHealth;
			ThreatScaleSlider.Value = settings.ThreatIncrease;
			CustomizablePlanets.Value = settings.CustomizablePlanets;
			FreeExplorationToggle.Value = settings.FreeExploration;
			FreeWeaponUpgradesToggle.Value = settings.FreeTechnology;
			FreeNimbatusUpgradesToggle.Value = settings.FreeUpgrades;
		}

		public void ApplySettings()
		{
			if (_settings != null)
			{
				if (_inMenu)
				{
					base.gameObject.SetActive(false);
				}
				_settings.Seed = SeedInput.Value.GetHashCode();
				_settings.DronePartHealth = DroneHealthSlider.Value;
				_settings.EnemyHealth = EnemyHealthSlider.Value;
				_settings.EnemyDamage = EnemyDamageSlider.Value;
				_settings.HasPartUnlocking = PartUnlockingToggle.Value;
				_settings.SharedDroneList = !_settings.HasPartUnlocking;
				_settings.NimbatusHealthAndThreat = HealthThreatToggle.Value;
				_settings.DeployCost = DeployCostToggle.Value;
				_settings.MaxHealth = MaxHealthSlider.Value;
				SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.ChangeMaxHealth(_settings.MaxHealth);
				_settings.ThreatIncrease = ThreatScaleSlider.Value;
				_settings.CustomizablePlanets = CustomizablePlanets.Value;
				_settings.FreeExploration = FreeExplorationToggle.Value;
				_settings.FreeTechnology = FreeWeaponUpgradesToggle.Value;
				_settings.FreeUpgrades = FreeNimbatusUpgradesToggle.Value;
				Action settingsApplied = SaveFileGameSettingsPanel.SettingsApplied;
				if (settingsApplied != null)
				{
					settingsApplied();
				}
			}
		}
	}
}
