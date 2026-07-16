using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JourneySavefile : Savefile
{
	public bool CanLoadJourney;

	public bool SavedOnLevelStart;

	public int Seed;

	public int NextIntIndex;

	public int NextFloatIndex;

	public int NextBoolIndex;

	public float Hull;

	public float Ammo;

	public float Scrap;

	public float Rerols;

	public float BossDmgMp;

	public bool Coop;

	public ControllerType P1Controller;

	public ControllerType P2Controller;

	public int WorldIndex;

	public List<int> LevelHistory;

	public List<int> TotalLevelHistory;

	public List<LevelSaveData> Levels;

	public List<TrainWagonLayout> WagonsLayout;

	public List<EnhancementUpgrade> Upgrades;

	public List<EnhancementUpgrade> Relics;

	public List<string> singleRunMilestoneNames;

	public List<float> singleRunMilestoneProgress;

	public List<bool> singleRunMilestoneCompleted;

	public float PlayTime;

	public float TotalDamageDealt;

	public float TotalDamageMitigated;

	public float TotalDamageTaken;

	public float TotalDamageRepaired;

	public int TotalEnemiesKilled;

	public int TotalModulesActivated;

	public int TotalEnhancementsCollected;

	public int CannonHits;

	public int CannonFires;

	public float TotalDistanceTravelled;

	public float LocationsVisited;

	public bool CollectedLevelReward;

	public List<Enhancement> LevelRewards;

	public List<ShopCard> PurchasedItems;

	public List<ShopCard> AllShopItems;

	public List<int> PurchasedWagonIndexes;

	public List<ShopWagon> ShopWagons;

	public List<Encounter> Encounter;

	public int coresCostModifier;

	public JourneySavefile()
	{
		version = GameManager.Instance.Version;
	}

	public void ResetJourney()
	{
		version = GameManager.Instance.Version;
		DRNG.Instance?.ResetWithSeed(Random.Range(0, 1000000));
		SaveManager.Instance.ShouldSaveJourney = false;
		SaveJourney();
	}

	public void HandleBossBeaten(bool isEnd)
	{
		WorldIndex = ZoneManager.Instance.CurrentZoneIndex + 1;
		if (LevelHistory == null)
		{
			LevelHistory = new List<int> { 0 };
		}
		else
		{
			LevelHistory.Add(0);
		}
		if (TotalLevelHistory == null)
		{
			TotalLevelHistory = new List<int> { 0 };
		}
		else
		{
			TotalLevelHistory.Add(0);
		}
		SaveTrainStats();
		SaveJourneyStats();
		SaveCoop();
		CanLoadJourney = !isEnd;
	}

	public void SaveJourney()
	{
		version = GameManager.Instance.Version;
		CanLoadJourney = SaveManager.Instance.ShouldSaveJourney;
		SavedOnLevelStart = SaveManager.Instance.JourneySavedOnLevelStart;
		Seed = DRNG.Instance.Seed;
		SaveTrainStats();
		SaveCoop();
		SaveProgress();
		SaveJourneyStats();
	}

	public void SaveTrainStats()
	{
		Hull = Train.Instance.HealthComponent.HealthCurrent;
		Ammo = ResourceManager.Instance.Ammo.Value;
		Scrap = ResourceManager.Instance.Scrap.Value;
		Rerols = ResourceManager.Instance.Rerolls.Value;
		BossDmgMp = EnemyManager.Instance.BossDmgMult;
		WagonsLayout = new List<TrainWagonLayout>();
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			TrainWagonLayout trainWagonLayout = new TrainWagonLayout();
			trainWagonLayout.wagonSize = wagon.ModuleSlots.Length;
			trainWagonLayout.modules = new List<ModuleTypes>();
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			foreach (ModuleSlot moduleSlot in moduleSlots)
			{
				if ((bool)moduleSlot.Module)
				{
					trainWagonLayout.modules.Add(moduleSlot.Module.ModuleType);
				}
				else
				{
					trainWagonLayout.modules.Add(ModuleTypes.None);
				}
			}
			WagonsLayout.Add(trainWagonLayout);
		}
		Upgrades = new List<EnhancementUpgrade>(UpgradeManager.Instance.UpgradesInInventory);
		Relics = new List<EnhancementUpgrade>(UpgradeManager.Instance.RelicsInInventory.Where((EnhancementUpgrade r) => r != null));
		coresCostModifier = ShopWindow.Instance.coresCostModifier;
	}

	public void SaveCoop()
	{
		Coop = PlayerManager.Instance.IsCoop;
		if (Coop)
		{
			P1Controller = PlayerManager.Instance.Players[0].InputHandler.controllerType;
			P2Controller = PlayerManager.Instance.Players[1].InputHandler.controllerType;
		}
	}

	public void SaveProgress()
	{
		if (ZoneManager.Instance.CurrentZoneIndex >= 0)
		{
			WorldIndex = ZoneManager.Instance.CurrentZoneIndex;
		}
		if (LevelManager.Instance.LevelHistory != null)
		{
			LevelHistory = new List<int>(LevelManager.Instance.LevelHistory);
		}
		if (LevelManager.Instance.TotalLevelHistory != null)
		{
			TotalLevelHistory = new List<int>(LevelManager.Instance.TotalLevelHistory);
		}
	}

	public void SaveJourneyStats()
	{
		List<Milestone> source = MilestoneManager.Instance.milestones.Where((Milestone m) => m.SingleRun).ToList();
		singleRunMilestoneNames = new List<string>(source.Select((Milestone m) => m.Name));
		singleRunMilestoneProgress = new List<float>(source.Select((Milestone m) => m.Progress));
		singleRunMilestoneCompleted = new List<bool>(source.Select((Milestone m) => m.Completed));
		PlayTime = GameManager.Instance.playtimeInRun;
		TotalDamageDealt = GameManager.Instance.TotalDamageInRun;
		TotalDamageMitigated = GameManager.Instance.TotalDamageMitigatedInRun;
		TotalDamageTaken = GameManager.Instance.TotalDamageTakenInRun;
		TotalDamageRepaired = GameManager.Instance.TotalDamageRepairedInRun;
		TotalEnemiesKilled = (int)GameManager.Instance.TotalKillsInRun;
		TotalModulesActivated = (int)GameManager.Instance.TotalModulesActivated;
		TotalEnhancementsCollected = (int)GameManager.Instance.TotalEnhancementsCollected;
		CannonHits = GameManager.Instance.cannonHitsInRun;
		CannonFires = GameManager.Instance.cannonFiresInRun;
		TotalDistanceTravelled = Train.Instance.GlobalDistance;
		LocationsVisited = GameManager.Instance.locationsVisitedInRun;
	}

	public void SaveLevels()
	{
		Levels = new List<LevelSaveData>();
		foreach (Level level in LevelManager.Instance.Levels)
		{
			Levels.Add(new LevelSaveData(level));
		}
	}

	public void ClearRewards()
	{
		LevelRewards = new List<Enhancement>();
	}

	public void AddReward(Enhancement reward)
	{
		if (LevelRewards == null)
		{
			LevelRewards = new List<Enhancement>();
		}
		LevelRewards.Add(reward);
	}

	public void ClearEncounter()
	{
		Encounter = new List<Encounter>();
	}

	public void SetEncounter(Encounter encounter)
	{
		Encounter = new List<Encounter> { encounter };
	}

	public void LoadJourney()
	{
		if (!CanLoadJourney)
		{
			return;
		}
		SaveManager.Instance.ShouldSaveJourney = true;
		SaveManager.Instance.JourneySavedOnLevelStart = SavedOnLevelStart;
		DRNG.Instance.InitWithSeedAndNextCounts(Seed, NextIntIndex, NextFloatIndex, NextBoolIndex);
		ZoneManager.Instance.SetZoneAtIndex(WorldIndex);
		if (LevelHistory != null)
		{
			LevelManager.Instance.LoadLevelHistory(LevelHistory);
		}
		if (TotalLevelHistory != null)
		{
			LevelManager.Instance.LoadTotalLevelHistory(TotalLevelHistory);
		}
		if (WagonsLayout != null)
		{
			Train.Instance.SetWagonsLayout(WagonsLayout.ToArray());
		}
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((bool)moduleByType)
		{
			moduleByType.cannon.ReloadBlocked = true;
		}
		Train.Instance.SetMaxHullBasedOnModules();
		if (Upgrades != null)
		{
			foreach (EnhancementUpgrade upgrade in Upgrades)
			{
				UpgradeManager.Instance.AddUpgrade(upgrade);
			}
		}
		if (Relics != null)
		{
			foreach (EnhancementUpgrade relic in Relics)
			{
				UpgradeManager.Instance.AddRelic(relic);
			}
		}
		Train.Instance.HealthComponent.SetHealth(Hull);
		ResourceManager.Instance.Ammo.SetValue(Ammo);
		ResourceManager.Instance.Scrap.SetValue(Scrap);
		ResourceManager.Instance.Rerolls.SetValue(Rerols);
		EnemyManager.Instance.BossDmgMult = BossDmgMp;
		ShopWindow.Instance.coresCostModifier = coresCostModifier;
		if ((bool)moduleByType)
		{
			moduleByType.cannon.ReloadBlocked = false;
		}
		if (Coop && !PlayerManager.Instance.TryLoadCoop(P1Controller, P2Controller))
		{
			Debug.LogWarning("Could not load Coop from previous journey. Switching to single player.");
			if (PlayerManager.Instance.IsCoop)
			{
				PlayerManager.Instance.TryEndCoop();
			}
		}
		int i;
		for (i = 0; i < singleRunMilestoneCompleted.Count; i++)
		{
			Milestone milestone = MilestoneManager.Instance.milestones.FirstOrDefault((Milestone m) => m.name == singleRunMilestoneNames[i]);
			if ((object)milestone != null)
			{
				milestone.Progress = singleRunMilestoneProgress[i];
				milestone.Completed = singleRunMilestoneCompleted[i];
			}
		}
		GameManager.Instance.playtimeInRun = PlayTime;
		GameManager.Instance.TotalDamageInRun = TotalDamageDealt;
		GameManager.Instance.TotalDamageMitigatedInRun = TotalDamageMitigated;
		GameManager.Instance.TotalDamageTakenInRun = TotalDamageTaken;
		GameManager.Instance.TotalDamageRepairedInRun = TotalDamageRepaired;
		GameManager.Instance.TotalKillsInRun = TotalEnemiesKilled;
		GameManager.Instance.TotalModulesActivated = TotalModulesActivated;
		GameManager.Instance.TotalEnhancementsCollected = TotalEnhancementsCollected;
		GameManager.Instance.cannonHitsInRun = CannonHits;
		GameManager.Instance.cannonFiresInRun = CannonFires;
		Train.Instance.GlobalDistance = TotalDistanceTravelled;
		GameManager.Instance.locationsVisitedInRun = LocationsVisited;
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			if (player != null && player.InputHandler != null)
			{
				player.interactor.RefreshInteractablesArray();
			}
		}
	}
}
