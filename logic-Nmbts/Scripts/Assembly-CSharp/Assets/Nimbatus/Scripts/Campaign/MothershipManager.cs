using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.MissionControl.Scripts;
using Assets.Nimbatus.GUI.TravelScene;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.TravelEvents;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Campaign
{
	public class MothershipManager : SerializableMonobehaviour<MothershipManager, MothershipSaveData>
	{
		protected List<MothershipUpgrade> UpgradePrefabs;

		public Texture2D HealthIcon;

		public Texture2D ThreatIcon;

		internal override string Filename
		{
			get
			{
				return "MothershipManager.xml";
			}
		}

		public int CurrentHealth { get; private set; }

		public int MaxHealth { get; private set; }

		public int Repairs { get; set; }

		public bool IsDead { get; private set; }

		public List<MothershipUpgradeData> Upgrades { get; private set; }

		public void ChangeHealth(int amount)
		{
			CurrentHealth += amount;
			CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
			if (RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat && CurrentHealth <= 0)
			{
				Die();
			}
		}

		private void Die()
		{
			IsDead = true;
			MissionControlNavigator.PageToLoad = EMissionControlPage.Main;
			TravelManager.ResetStaticFields();
			NimbatusSpeedAnimation.IsOverwritten = false;
			NimbatusSpeedAnimation.IsParticleOverwritten = false;
			SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ResetTravelEvent();
			if (RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				SaveManager.ResetAndDeleteCurrentSave();
			}
			NimbatusSceneManager.LoadScene("GameOverScene");
		}

		public void ChangeUpgradeLevel(EMothershipUpgradeType type, int lvl)
		{
			MothershipUpgrade upgradePrefab = GetUpgradePrefab(type);
			MothershipUpgradeData mothershipUpgradeData = Upgrades.FirstOrDefault((MothershipUpgradeData u) => u.Type == type);
			if (mothershipUpgradeData != null && upgradePrefab != null)
			{
				mothershipUpgradeData.CurrentLevel = Mathf.Clamp(lvl, upgradePrefab.MinLevel, upgradePrefab.MaxLevel);
			}
			else if (mothershipUpgradeData == null)
			{
				Upgrades.Add(new MothershipUpgradeData
				{
					Type = type,
					CurrentLevel = lvl
				});
			}
		}

		public int GetUpgradeLevel(EMothershipUpgradeType type)
		{
			if (Upgrades == null)
			{
				return 0;
			}
			MothershipUpgradeData mothershipUpgradeData = Upgrades.FirstOrDefault((MothershipUpgradeData u) => u.Type == type);
			if (mothershipUpgradeData == null)
			{
				return 0;
			}
			return mothershipUpgradeData.CurrentLevel;
		}

		public MothershipUpgrade GetUpgradePrefab(EMothershipUpgradeType type)
		{
			return UpgradePrefabs.FirstOrDefault((MothershipUpgrade u) => u.Type == type);
		}

		protected override void PreLoad()
		{
			base.PreLoad();
			CurrentHealth = Mathf.Max(1, RuntimeGlobals.GameModeSettings.MaxHealth - 1);
			MaxHealth = RuntimeGlobals.GameModeSettings.MaxHealth;
			Repairs = 0;
			UpgradePrefabs = Resources.LoadAll<MothershipUpgrade>("Upgrades").ToList();
			Upgrades = InitUpgrades();
		}

		private List<MothershipUpgradeData> InitUpgrades()
		{
			List<MothershipUpgradeData> list = new List<MothershipUpgradeData>();
			foreach (MothershipUpgrade upgradePrefab in UpgradePrefabs)
			{
				list.Add(new MothershipUpgradeData
				{
					Type = upgradePrefab.Type,
					CurrentLevel = upgradePrefab.MinLevel
				});
			}
			return list;
		}

		public void ChangeMaxHealth(int health)
		{
			MaxHealth = health;
			CurrentHealth = Mathf.Min(CurrentHealth, MaxHealth);
		}

		protected override void LoadFromFile(MothershipSaveData data)
		{
			CurrentHealth = data.Health;
			MaxHealth = data.MaxHealth;
			Repairs = data.Repairs;
			if (SaveManager.IsLoadedVersionEqualOrHigher("0.9.0"))
			{
				Upgrades = data.Upgrades;
			}
			else
			{
				Upgrades = InitUpgrades();
			}
		}

		protected override MothershipSaveData SaveToFile()
		{
			return new MothershipSaveData
			{
				Health = CurrentHealth,
				MaxHealth = MaxHealth,
				Repairs = Repairs,
				Upgrades = Upgrades
			};
		}
	}
}
