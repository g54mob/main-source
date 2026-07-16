using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour, ISaveable
{
	public static UpgradeManager Instance;

	private List<Enhancement> enhancements;

	private EnhancementUpgrade[] AllUpgrades;

	[SerializeField]
	private RadarUpgrade[] radarUpgradeSaves;

	private bool upgradesLoaded;

	public List<Enhancement> Enhancements
	{
		get
		{
			return enhancements;
		}
		private set
		{
			enhancements = value;
		}
	}

	public EnhancementUpgrade[] Upgrades { get; set; }

	public List<EnhancementUpgrade> Relics { get; set; }

	[field: SerializeField]
	public List<EnhancementModule> Modules { get; private set; }

	[field: SerializeField]
	public List<EnhancementModule> StartingModules { get; set; }

	[field: SerializeField]
	public List<EnhancementWagon> Wagons { get; private set; }

	[field: SerializeField]
	public List<EnhancementUpgrade> UpgradesInInventory { get; private set; }

	[field: SerializeField]
	public List<EnhancementUpgrade> UpgradesGraveyard { get; private set; }

	[field: SerializeField]
	public EnhancementUpgrade[] RelicsInInventory { get; private set; } = new EnhancementUpgrade[3];

	[field: SerializeField]
	public List<EnhancementModule> ModulesInInventory { get; internal set; }

	[field: SerializeField]
	public List<EnhancementWagon> WagonsInInventory { get; private set; }

	[field: SerializeField]
	public List<Sprite> ModuleSlotSprites { get; private set; }

	[field: SerializeField]
	public Stats[] AllStatsSOs { get; private set; }

	[field: SerializeField]
	public Stats CannonStatsSO { get; private set; }

	[field: SerializeField]
	public EnhancementRadar[] RadarUpgrades { get; set; }

	public RadarUpgrade[] RadarUpgradeSaves
	{
		get
		{
			return Instance.radarUpgradeSaves;
		}
		private set
		{
			Instance.radarUpgradeSaves = value;
		}
	}

	public event Action OnAddRelic;

	public event Action<EnhancementModule> OnAddEnhancementModule;

	public event Action<Module> OnAddModule;

	private void Awake()
	{
		Instance = this;
		radarUpgradeSaves = new RadarUpgrade[RadarUpgrades.Length];
		EnhancementRadar[] radarUpgrades = RadarUpgrades;
		foreach (EnhancementRadar enhancementRadar in radarUpgrades)
		{
			if (!(enhancementRadar == null))
			{
				radarUpgradeSaves[enhancementRadar.ID] = new RadarUpgrade(enhancementRadar);
			}
		}
	}

	private void Start()
	{
		AllUpgrades = Resources.LoadAll<EnhancementUpgrade>("Upgrades");
		Upgrades = AllUpgrades.Where((EnhancementUpgrade upgrade) => !upgrade.IsRelic).ToArray();
		Relics = AllUpgrades.Where((EnhancementUpgrade u) => u.IsRelic).ToList();
		if (Upgrades == null || Upgrades.Length == 0)
		{
			Debug.LogWarning("No upgrades were loaded from Resources.");
		}
		ResetAllUpgrades();
		enhancements = new List<Enhancement>();
		enhancements.AddRange(Upgrades);
		enhancements.AddRange(Modules);
		enhancements.AddRange(Wagons);
		enhancements.AddRange(Relics);
	}

	private void Update()
	{
		for (int i = 0; i < UpgradesInInventory.Count; i++)
		{
			UpgradesInInventory[i].UpdateUpgrade();
		}
		for (int j = 0; j < RelicsInInventory.Length; j++)
		{
			if (RelicsInInventory[j] != null)
			{
				RelicsInInventory[j].UpdateUpgrade();
			}
		}
	}

	public bool AddRelic(EnhancementUpgrade newRelic)
	{
		if (newRelic == null)
		{
			Debug.LogWarning("Tried to add null relic");
			return false;
		}
		for (int i = 0; i < RelicsInInventory.Count(); i++)
		{
			if (!(RelicsInInventory[i] != null))
			{
				GameManager.Instance.TotalEnhancementsCollected += 1f;
				RelicsInInventory[i] = newRelic;
				newRelic.ApplyUpgrade();
				this.OnAddRelic?.Invoke();
				return true;
			}
		}
		return false;
	}

	public void SetRelic(int newRelicIndex, EnhancementUpgrade newRelic)
	{
		if (newRelic.IsRelic)
		{
			EnhancementUpgrade enhancementUpgrade = RelicsInInventory[newRelicIndex];
			if (enhancementUpgrade != null)
			{
				enhancementUpgrade.OnRemove();
				RelicsInInventory[newRelicIndex] = null;
			}
			UpgradesGraveyard.Add(enhancementUpgrade);
			RelicsInInventory[newRelicIndex] = newRelic;
			newRelic.ApplyUpgrade();
		}
	}

	public void ReturnRelicToPool(EnhancementUpgrade relic)
	{
		if (!relic.IsRelic || !relic)
		{
			return;
		}
		for (int i = 0; i < RelicsInInventory.Count(); i++)
		{
			if (!(RelicsInInventory[i] == null) && RelicsInInventory[i] == relic)
			{
				relic.OnRemove();
				RelicsInInventory[i] = null;
				break;
			}
		}
	}

	public void AddUpgrade(EnhancementUpgrade upgrade)
	{
		if (upgrade == null)
		{
			Debug.LogWarning("Tried to add null upgrade");
			return;
		}
		GameManager.Instance.TotalEnhancementsCollected += 1f;
		if (upgrade.ShouldRemovePrerequisites)
		{
			RemovePrerequisites(upgrade);
		}
		UpgradesInInventory.Add(upgrade);
		Stats[] statsObjectsToUpgrade = upgrade.StatsObjectsToUpgrade;
		for (int i = 0; i < statsObjectsToUpgrade.Length; i++)
		{
			statsObjectsToUpgrade[i].AddUpgrade(upgrade);
		}
		upgrade.ApplyUpgrade();
	}

	public void RemovePrerequisites(EnhancementUpgrade upgrade)
	{
		EnhancementUpgrade[] prerequisiteUpgrades = upgrade.PrerequisiteUpgrades;
		foreach (EnhancementUpgrade enhancementUpgrade in prerequisiteUpgrades)
		{
			Stats[] statsObjectsToUpgrade = enhancementUpgrade.StatsObjectsToUpgrade;
			for (int j = 0; j < statsObjectsToUpgrade.Length; j++)
			{
				statsObjectsToUpgrade[j].RemoveUpgrade(enhancementUpgrade);
			}
			RemoveUpgrade(enhancementUpgrade);
		}
	}

	public void RemoveUpgrade(EnhancementUpgrade upg)
	{
		upg.OnRemove();
		UpgradesInInventory.Remove(upg);
		UpgradesGraveyard.Add(upg);
	}

	public void ReturnUpgradeToPool(EnhancementUpgrade upg)
	{
		Stats[] statsObjectsToUpgrade = upg.StatsObjectsToUpgrade;
		for (int i = 0; i < statsObjectsToUpgrade.Length; i++)
		{
			statsObjectsToUpgrade[i].RemoveUpgrade(upg);
		}
		upg.OnRemove();
		UpgradesInInventory.Remove(upg);
	}

	public bool AddModule(EnhancementModule md, ModuleSlot predeterminedSlot = null)
	{
		ModuleSlot moduleSlot = null;
		moduleSlot = (predeterminedSlot ? predeterminedSlot : ((md.Name == "Track Lever" && Train.Instance.Wagons[1].ModuleSlots.Length == 4) ? Train.Instance.GetLeverModuleSlot() : ((md.Name == "Claw" && Train.Instance.Wagons[1].ModuleSlots.Length == 4) ? ((ZoneManager.Instance.CurrentZoneIndex == 0) ? Train.Instance.GetClawModuleSlot() : ((Train.Instance.currentTrain.trainType != TrainType.Cannon) ? Train.Instance.Wagons[1].ModuleSlots[3] : Train.Instance.Wagons[1].ModuleSlots[1])) : ((!(md.Name == "Cannon") || Train.Instance.Wagons[1].ModuleSlots.Length != 4 || ZoneManager.Instance.CurrentZoneIndex != 0) ? Train.Instance.GetFirstEmptyModuleSlot() : Train.Instance.GetCannonModuleSlot()))));
		if (moduleSlot == null)
		{
			return false;
		}
		GameManager.Instance.TotalEnhancementsCollected += 1f;
		moduleSlot.SetModule(md);
		ModulesInInventory.Add(md);
		this.OnAddEnhancementModule?.Invoke(md);
		this.OnAddModule?.Invoke(moduleSlot.Module);
		if (md.Name == "Track Lever")
		{
			Train.Instance.SetDirectionLever();
		}
		else if (md.Name == "Claw")
		{
			moduleSlot = Train.Instance.GetClawModuleSlot();
		}
		else if (md.Name == "Cannon")
		{
			moduleSlot = Train.Instance.GetCannonModuleSlot();
		}
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.interactor.RefreshInteractablesArray();
		}
		return true;
	}

	public void ReturnModuleToPool(EnhancementModule md)
	{
		ModuleSlot moduleSlot = null;
		foreach (Module module in Train.Instance.Modules)
		{
			if (module.GetEnhancementModule() == md)
			{
				moduleSlot = module.ModuleSlot;
			}
		}
		if (moduleSlot == null)
		{
			return;
		}
		moduleSlot.RemoveModule();
		ModulesInInventory.Remove(md);
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.interactor.RefreshInteractablesArray();
		}
	}

	public bool AddEnhancement(Enhancement enhancement)
	{
		if (!(enhancement is EnhancementUpgrade enhancementUpgrade))
		{
			if (enhancement is EnhancementModule md)
			{
				AddModule(md);
				return true;
			}
			return false;
		}
		if (enhancementUpgrade.IsRelic)
		{
			if (AddRelic(enhancementUpgrade))
			{
				return true;
			}
			return false;
		}
		AddUpgrade(enhancementUpgrade);
		return true;
	}

	public void AddWagon(EnhancementWagon wagon)
	{
		GameObject wagonPrefab = wagon.WagonPrefab;
		Train.Instance.AddWagon(wagonPrefab);
	}

	public void ResetAllUpgrades()
	{
		EnhancementUpgrade[] upgrades = Upgrades;
		foreach (EnhancementUpgrade enhancementUpgrade in upgrades)
		{
			if (!(enhancementUpgrade == null))
			{
				enhancementUpgrade.ResetUpgrade();
			}
		}
		Stats[] allStatsSOs = AllStatsSOs;
		foreach (Stats stats in allStatsSOs)
		{
			if ((bool)stats)
			{
				stats.ResetUpgrades();
			}
		}
		ModulesInInventory.Clear();
		UpgradesInInventory.Clear();
		ModulesInInventory.AddRange(StartingModules);
	}

	public void Save(SaveDataContext context = null)
	{
		if (context == null)
		{
			context = SaveManager.Instance.SaveDataContext;
		}
		MetaSavefile metaSave = context.MetaSave;
		metaSave.radarUpgradesBought.Clear();
		metaSave.radarUpgradesToggledOff.Clear();
		if (Instance.RadarUpgradeSaves == null)
		{
			Debug.LogError("Error saving radar upgrades, null value");
			return;
		}
		for (int i = 0; i < RadarUpgradeSaves.Length; i++)
		{
			RadarUpgrade radarUpgrade = RadarUpgradeSaves[i];
			if (radarUpgrade != null && radarUpgrade.isBought)
			{
				metaSave.radarUpgradesBought.Add(radarUpgrade.upgrade.ID);
				if (!radarUpgrade.IsApplied)
				{
					metaSave.radarUpgradesToggledOff.Add(radarUpgrade.upgrade.ID);
				}
			}
		}
		Debug.Log("Saved Radar Upgrades");
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		if (upgradesLoaded)
		{
			return;
		}
		upgradesLoaded = true;
		MetaSavefile metaSave = context.MetaSave;
		if (RadarUpgrades == null || RadarUpgradeSaves == null)
		{
			Debug.Log("Failed Loading Radar Upgrades");
			return;
		}
		foreach (int item in metaSave.radarUpgradesBought)
		{
			if (RadarUpgrades[item] != null && RadarUpgradeSaves[item] != null)
			{
				RadarUpgradeSaves[item].isBought = true;
				if (metaSave.radarUpgradesToggledOff.Contains(item))
				{
					RadarUpgradeSaves[item].IsApplied = false;
				}
				else
				{
					RadarUpgradeSaves[item].IsApplied = true;
				}
			}
		}
		Debug.Log("Loaded Radar Upgrades");
	}
}
