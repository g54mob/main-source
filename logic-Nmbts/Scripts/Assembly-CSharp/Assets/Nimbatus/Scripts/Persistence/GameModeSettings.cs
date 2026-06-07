using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.Persistence
{
	[Serializable]
	public class GameModeSettings
	{
		public EGameModeDifficulty Difficulty;

		public int Seed { get; set; }

		public string DronePerkId { get; set; }

		public bool ViewCampaignTutorial { get; set; }

		public bool InCampaignTutorial { get; set; }

		public bool HasPartUnlocking { get; set; }

		public bool SharedDroneList { get; set; }

		public bool GenerateGalaxy { get; set; }

		public bool ShowAllDroneParts { get; set; }

		public bool HasShops
		{
			get
			{
				return HasPartUnlocking;
			}
		}

		public bool HasWeaponCasino
		{
			get
			{
				return HasPartUnlocking;
			}
		}

		public bool HasGarages
		{
			get
			{
				if (!NimbatusHealthAndThreat)
				{
					return !FreeUpgrades;
				}
				return true;
			}
		}

		public bool ImportDrones
		{
			get
			{
				return SharedDroneList;
			}
		}

		public int EnemyHealth { get; set; }

		public int EnemyDamage { get; set; }

		public int DronePartHealth { get; set; }

		public int ThreatIncrease { get; set; }

		public int CommonOreRewardScale { get; set; }

		public int MaxHealth { get; set; }

		public int MaxRepairs { get; set; }

		public bool MultipleTestDriveModes { get; set; }

		public bool AllTechnologyUnlocked { get; set; }

		public bool FreeTechnology { get; set; }

		public bool FreeUpgrades { get; set; }

		public bool FreeExploration { get; set; }

		public bool CustomizablePlanets { get; set; }

		public bool NimbatusHealthAndThreat { get; set; }

		public bool DeployCost { get; set; }

		public bool HasTemplates { get; set; }

		public string GetSandboxDetails()
		{
			string text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/GalaxySeed") + ": " + LabelHelper.Orange + Seed + LabelHelper.NewLine;
			text = text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/DronePartHealth") + ": " + LabelHelper.Orange + DronePartHealth + "%" + LabelHelper.NewLine;
			text = text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/EnemyHealth") + ": " + LabelHelper.Orange + EnemyHealth + "%" + LabelHelper.NewLine;
			text = text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/EnemyDamage") + ": " + LabelHelper.Orange + EnemyDamage + "%" + LabelHelper.NewLine;
			text = text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/CustomizablePlanets") + ": " + LabelHelper.Orange + LocalizationManager.GetTermTranslation("MainMenu/" + (CustomizablePlanets ? "Yes" : "No")) + LabelHelper.NewLine;
			text = text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/PartUnlocking") + ": " + LabelHelper.Orange + LocalizationManager.GetTermTranslation("MainMenu/" + (HasPartUnlocking ? "Yes" : "No")) + LabelHelper.NewLine;
			text = text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/HealthThreat") + ": " + LabelHelper.Orange + LocalizationManager.GetTermTranslation("MainMenu/" + (NimbatusHealthAndThreat ? "Yes" : "No")) + LabelHelper.NewLine;
			return text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/DeployCost") + ": " + LabelHelper.Orange + LocalizationManager.GetTermTranslation("MainMenu/" + (DeployCost ? "Yes" : "No"));
		}

		public string GetSurvivalDetails()
		{
			string text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/EnemyHealth") + ": " + LabelHelper.Orange + EnemyHealth + "%" + LabelHelper.NewLine;
			text = text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/EnemyDamage") + ": " + LabelHelper.Orange + EnemyDamage + "%" + LabelHelper.NewLine;
			text = text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/ThreatIncrease") + ": " + LabelHelper.Orange + ThreatIncrease + "%" + LabelHelper.NewLine;
			return text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("CreativeMode/MaxHealth") + ": " + LabelHelper.Orange + MaxHealth;
		}

		public static string GetDifficultyDetails(EGameModeDifficulty difficulty)
		{
			GameModeSettings gameModeSettings = new GameModeSettings();
			gameModeSettings.Init(EGameMode.Campaign, difficulty);
			return gameModeSettings.GetSurvivalDetails();
		}

		public void Init(EGameMode mode, EGameModeDifficulty difficulty)
		{
			Seed = Guid.NewGuid().ToString().GetHashCode();
			Difficulty = difficulty;
			HasPartUnlocking = mode == EGameMode.Campaign;
			SharedDroneList = !HasPartUnlocking && mode != EGameMode.Tutorial;
			GenerateGalaxy = mode == EGameMode.Creative || mode == EGameMode.Campaign;
			NimbatusHealthAndThreat = mode == EGameMode.Campaign;
			DeployCost = mode == EGameMode.Campaign;
			MultipleTestDriveModes = mode == EGameMode.Competitive;
			ShowAllDroneParts = mode == EGameMode.Tutorial || mode == EGameMode.Campaign || mode == EGameMode.Demo;
			AllTechnologyUnlocked = mode == EGameMode.Competitive || mode == EGameMode.Demo;
			FreeTechnology = mode == EGameMode.Creative;
			FreeUpgrades = mode == EGameMode.Creative;
			FreeExploration = mode == EGameMode.Creative;
			CustomizablePlanets = mode == EGameMode.Creative;
			HasTemplates = mode == EGameMode.Creative || mode == EGameMode.Campaign || mode == EGameMode.Demo || mode == EGameMode.Competitive;
			DronePerkId = "";
			InitDifficulty();
		}

		public void ValidateSettingsAfterLoad(EGameMode mode)
		{
			if (!SaveManager.IsLoadedVersionEqualOrHigher("1.1.0"))
			{
				HasTemplates = mode == EGameMode.Creative || mode == EGameMode.Campaign || mode == EGameMode.Demo || mode == EGameMode.Competitive;
			}
			if (mode != EGameMode.Campaign)
			{
				MaxRepairs = 10;
			}
			else
			{
				InitDifficulty();
			}
		}

		private void InitDifficulty()
		{
			switch (Difficulty)
			{
			case EGameModeDifficulty.Easy:
				EnemyHealth = 50;
				DronePartHealth = 100;
				EnemyDamage = 50;
				MaxHealth = 5;
				ThreatIncrease = 75;
				CommonOreRewardScale = 125;
				MaxRepairs = 10;
				break;
			case EGameModeDifficulty.Hard:
				EnemyHealth = 125;
				DronePartHealth = 100;
				EnemyDamage = 150;
				MaxHealth = 3;
				ThreatIncrease = 125;
				CommonOreRewardScale = 75;
				MaxRepairs = 4;
				break;
			default:
				EnemyHealth = 100;
				DronePartHealth = 100;
				EnemyDamage = 100;
				ThreatIncrease = 100;
				MaxHealth = 4;
				CommonOreRewardScale = 100;
				MaxRepairs = 5;
				break;
			}
		}
	}
}
