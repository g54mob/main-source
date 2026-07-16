using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class LootUtils
{
	public static Enhancement GetRandomLoot(LootType lootType, Rarity? rarity = null, List<Enhancement> blacklist = null)
	{
		blacklist = ((blacklist != null) ? new List<Enhancement>(blacklist) : new List<Enhancement>());
		blacklist.AddRange(from Enhancement e in UpgradeManager.Instance.UpgradesInInventory
			where e != null
			select e);
		blacklist.AddRange(from Enhancement e in UpgradeManager.Instance.ModulesInInventory
			where e != null
			select e);
		blacklist.AddRange(from Enhancement e in UpgradeManager.Instance.RelicsInInventory
			where e != null
			select e);
		blacklist.AddRange(from Enhancement e in UpgradeManager.Instance.UpgradesGraveyard
			where e != null
			select e);
		Enhancement[] allE = UpgradeManager.Instance.Enhancements.ToArray();
		new HashSet<Enhancement>();
		IEnumerable<Enhancement> enumerable = lootType switch
		{
			LootType.Module => GetFilteredE<EnhancementModule>((EnhancementModule m) => IsValidModule(m)), 
			LootType.Upgrade => GetFilteredE<EnhancementUpgrade>((EnhancementUpgrade u) => IsValidUpgrade(u) && !u.IsRelic && !u.StatsObjectsToUpgrade.Contains(UpgradeManager.Instance.CannonStatsSO)), 
			LootType.CannonUpgrade => GetFilteredE<EnhancementUpgrade>((EnhancementUpgrade u) => IsValidUpgrade(u) && !u.IsRelic && u.StatsObjectsToUpgrade.Contains(UpgradeManager.Instance.CannonStatsSO)), 
			LootType.Relic => GetFilteredE<EnhancementUpgrade>((EnhancementUpgrade u) => IsValidUpgrade(u) && u.IsRelic), 
			_ => Enumerable.Empty<Enhancement>(), 
		};
		if (enumerable == null)
		{
			if (rarity == Rarity.Legendary || !rarity.HasValue)
			{
				return null;
			}
			Rarity valueOrDefault = rarity.GetValueOrDefault();
			rarity = LevelManager.Instance.CurrentLevel.Difficulty.IncreaseRarity(valueOrDefault);
			return GetRandomLoot(lootType, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), blacklist);
		}
		Enhancement enhancement = enumerable.OrderByDescending((Enhancement e) => (int)e.Rarity).ThenBy((Enhancement _) => DRNG.Instance.NextFloat01()).FirstOrDefault();
		if (enhancement == null)
		{
			if (rarity == Rarity.Legendary || !rarity.HasValue)
			{
				return null;
			}
			Rarity valueOrDefault2 = rarity.GetValueOrDefault();
			valueOrDefault2 = LevelManager.Instance.CurrentLevel.Difficulty.IncreaseRarity(valueOrDefault2);
			return GetRandomLoot(lootType, valueOrDefault2, blacklist);
		}
		return enhancement;
		IEnumerable<Enhancement> GetFilteredE<T>(Func<T, bool> predicate = null) where T : Enhancement
		{
			IEnumerable<T> enumerable2 = allE.OfType<T>();
			if (rarity.HasValue)
			{
				enumerable2 = enumerable2.Where((T e) => e.Rarity <= rarity.Value);
			}
			if (predicate != null)
			{
				enumerable2 = enumerable2.Where(predicate);
			}
			if (blacklist != null)
			{
				enumerable2 = enumerable2.Where((T e) => !blacklist.Contains(e));
			}
			return enumerable2;
		}
		static bool IsValidModule(EnhancementModule m, ModuleCombatTypes? moduleType = null)
		{
			if ((!moduleType.HasValue || m.ModuleCombatType == moduleType.Value) && Train.Instance.GetFirstEmptyModuleSlot() != null && !m.Locked && m.Zone <= ZoneManager.Instance.CurrentZoneIndex)
			{
				return !UpgradeManager.Instance.ModulesInInventory.Contains(m);
			}
			return false;
		}
		bool IsValidUpgrade(EnhancementUpgrade u, ModuleCombatTypes? moduleType = null)
		{
			if (u.IgnoreChecks)
			{
				if (u.Locked)
				{
					return false;
				}
				return true;
			}
			List<EnhancementUpgrade> list = new List<EnhancementUpgrade>();
			foreach (Enhancement item2 in blacklist)
			{
				if (item2 is EnhancementUpgrade item)
				{
					list.Add(item);
				}
			}
			if (UpgradeHasInstance(u) && UpgradePrerequisitesMet(u) && UpgradeRequiredModulesMet(u) && !IsUpgradeInGraveyard(u) && !UpgradeExclusiveMet(u) && list != null && !UpgradeExclusiveFoundInBlacklist(u, list) && !u.Locked && u.Zone <= ZoneManager.Instance.CurrentZoneIndex)
			{
				if (moduleType.HasValue)
				{
					return u.StatsObjectsToUpgrade.Any((Stats statsSO) => statsSO.ModuleType == moduleType.Value);
				}
				return true;
			}
			return false;
		}
	}

	public static EnhancementModule GetTutorialLoot(LootType lootType)
	{
		return lootType switch
		{
			LootType.Lever => UpgradeManager.Instance.StartingModules.FirstOrDefault((EnhancementModule m) => m.Name == "Track Lever"), 
			LootType.Claw => UpgradeManager.Instance.StartingModules.FirstOrDefault((EnhancementModule m) => m.Name == "Claw"), 
			LootType.Cannon => UpgradeManager.Instance.StartingModules.FirstOrDefault((EnhancementModule m) => m.Name == "Cannon"), 
			_ => null, 
		};
	}

	public static EnhancementWagon GetRandomWagon()
	{
		List<EnhancementWagon> wagons = UpgradeManager.Instance.Wagons;
		int weightedIndex = GetWeightedIndex(LootManager.Instance.WagonWeights);
		return wagons[weightedIndex];
	}

	public static EnhancementWagon GetWagonBySize(int size)
	{
		return UpgradeManager.Instance.Wagons.FirstOrDefault((EnhancementWagon w) => w.ModuleSlotCount == size);
	}

	public static bool UpgradeHasInstance(EnhancementUpgrade upgrade)
	{
		if (upgrade.StatsObjectsToUpgrade != null && upgrade.StatsObjectsToUpgrade.Length != 0)
		{
			return upgrade.StatsObjectsToUpgrade.Any((Stats stats) => stats.instances > 0);
		}
		return true;
	}

	public static bool UpgradeRequiredModulesMet(EnhancementUpgrade upgrade)
	{
		if (upgrade.RequiredModules == null || upgrade.RequiredModules.Length == 0)
		{
			return true;
		}
		return upgrade.RequiredModules.All((EnhancementModule module) => UpgradeManager.Instance.ModulesInInventory.Contains(module));
	}

	public static bool UpgradePrerequisitesMet(EnhancementUpgrade upgrade)
	{
		EnhancementUpgrade[] prerequisiteUpgrades = upgrade.PrerequisiteUpgrades;
		foreach (EnhancementUpgrade item in prerequisiteUpgrades)
		{
			if (!UpgradeManager.Instance.UpgradesInInventory.Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsUpgradeInGraveyard(EnhancementUpgrade upgrade)
	{
		return UpgradeManager.Instance.UpgradesGraveyard.Contains(upgrade);
	}

	public static bool UpgradeExclusiveMet(EnhancementUpgrade upgrade)
	{
		if (upgrade.IsRelic)
		{
			EnhancementUpgrade[] upgradesExclusiveTo = upgrade.UpgradesExclusiveTo;
			foreach (EnhancementUpgrade value in upgradesExclusiveTo)
			{
				if (UpgradeManager.Instance.RelicsInInventory.Contains(value))
				{
					return true;
				}
			}
		}
		else
		{
			EnhancementUpgrade[] upgradesExclusiveTo = upgrade.UpgradesExclusiveTo;
			foreach (EnhancementUpgrade item in upgradesExclusiveTo)
			{
				if (UpgradeManager.Instance.UpgradesInInventory.Contains(item))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool UpgradeExclusiveFoundInBlacklist(EnhancementUpgrade upgrade, List<EnhancementUpgrade> blacklist = null)
	{
		EnhancementUpgrade[] upgradesExclusiveTo = upgrade.UpgradesExclusiveTo;
		foreach (EnhancementUpgrade item in upgradesExclusiveTo)
		{
			if (blacklist.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	public static LootType GetWeightedLootType(ZoneDefinition def, int column)
	{
		float mapProgressNorm = Mathf.Clamp01((float)column / (float)def.MapSize.x);
		List<WorldLoots> levelLoots = LootManager.Instance.LevelLoots;
		float[] weights = levelLoots[ZoneManager.Instance.CurrentZoneIndex].Loots.Select((LevelLoot loot) => loot.WeightCurve.Evaluate(mapProgressNorm)).ToArray();
		return levelLoots[ZoneManager.Instance.CurrentZoneIndex].Loots[GetWeightedIndex(weights)].LootType;
	}

	public static LootType GetWeightedLootType(int zoneIndex, int mapX, int column)
	{
		float mapProgressNorm = Mathf.Clamp01((float)column / (float)mapX);
		List<WorldLoots> levelLoots = LootManager.Instance.LevelLoots;
		float[] weights = levelLoots[zoneIndex].Loots.Select((LevelLoot loot) => loot.WeightCurve.Evaluate(mapProgressNorm)).ToArray();
		return levelLoots[zoneIndex].Loots[Mathf.Clamp(GetWeightedIndex(weights), 0, levelLoots[zoneIndex].Loots.Count - 1)].LootType;
	}

	public static int GetWeightedIndex(float[] weights)
	{
		float num = weights.Sum();
		float num2 = DRNG.Instance.NextFloat01() * num;
		float num3 = 0f;
		for (int i = 0; i < weights.Length; i++)
		{
			num3 += weights[i];
			if (num3 >= num2)
			{
				return i;
			}
		}
		return -1;
	}

	public static Rarity GetRandomWeightedRarity(float chanceForCommon, float chanceForRare, float chanceForEpic, float chanceForLegendary)
	{
		float maxInclusive = chanceForCommon + chanceForRare + chanceForEpic + chanceForLegendary;
		float num = UnityEngine.Random.Range(0f, maxInclusive);
		float num2 = 0f;
		Dictionary<Rarity, float> dictionary = new Dictionary<Rarity, float>();
		dictionary.Add(Rarity.Common, chanceForCommon);
		dictionary.Add(Rarity.Rare, chanceForRare);
		dictionary.Add(Rarity.Epic, chanceForEpic);
		dictionary.Add(Rarity.Legendary, chanceForLegendary);
		foreach (Rarity key in dictionary.Keys)
		{
			num2 += dictionary[key];
			if (num <= num2)
			{
				return key;
			}
		}
		return Rarity.Legendary;
	}

	public static List<EnhancementUpgrade> ViableUpgrades(Rarity rarity, Module module = null, List<EnhancementUpgrade> blacklist = null)
	{
		return (from u in UpgradeManager.Instance.Upgrades
			where (bool)u && UpgradeHasInstance(u) && UpgradePrerequisitesMet(u) && UpgradeRequiredModulesMet(u) && !IsUpgradeInGraveyard(u) && !UpgradeExclusiveMet(u) && (blacklist == null || (!blacklist.Contains(u) && !UpgradeExclusiveFoundInBlacklist(u, blacklist))) && !UpgradeManager.Instance.UpgradesInInventory.Contains(u) && (module == null || u.StatsObjectsToUpgrade.Contains(module.StatsSO)) && u.Rarity == rarity
			orderby u.name
			select u).ToList();
	}

	public static List<EnhancementUpgrade> ViableUpgrades(Module module = null, List<EnhancementUpgrade> blacklist = null)
	{
		return (from u in UpgradeManager.Instance.Upgrades
			where (bool)u && UpgradeHasInstance(u) && UpgradePrerequisitesMet(u) && UpgradeRequiredModulesMet(u) && !IsUpgradeInGraveyard(u) && !UpgradeExclusiveMet(u) && (blacklist == null || (!blacklist.Contains(u) && !UpgradeExclusiveFoundInBlacklist(u, blacklist))) && !UpgradeManager.Instance.UpgradesInInventory.Contains(u) && (module == null || u.StatsObjectsToUpgrade.Contains(module.StatsSO))
			orderby u.name
			select u).ToList();
	}

	public static List<EnhancementUpgrade> ViableModuleUpgrades(List<EnhancementUpgrade> blacklist = null)
	{
		return (from u in UpgradeManager.Instance.Upgrades
			where (bool)u && UpgradeHasInstance(u) && UpgradePrerequisitesMet(u) && UpgradeRequiredModulesMet(u) && !IsUpgradeInGraveyard(u) && !UpgradeExclusiveMet(u) && (blacklist == null || (!blacklist.Contains(u) && !UpgradeExclusiveFoundInBlacklist(u, blacklist))) && !UpgradeManager.Instance.UpgradesInInventory.Contains(u) && u.ModulesTag != "Player"
			orderby u.name
			select u).ToList();
	}

	public static EnhancementUpgrade GetRandomUpgrade(Rarity rarity, Module module = null, bool autoAdd = true, List<EnhancementUpgrade> blacklist = null)
	{
		List<EnhancementUpgrade> list = ViableUpgrades(rarity, module, blacklist);
		if (list.Count == 0)
		{
			list = FindUpgradeOfAvailableRarity(rarity, module, blacklist);
		}
		if (list == null)
		{
			return null;
		}
		int index = DRNG.Instance.NextInt(0, list.Count);
		if (autoAdd)
		{
			UpgradeManager.Instance.AddUpgrade(list[index]);
		}
		return list[index];
	}

	public static EnhancementUpgrade GetRandomUpgrade(Module module = null, bool autoAdd = true, List<EnhancementUpgrade> blacklist = null)
	{
		List<EnhancementUpgrade> list = ViableUpgrades(module, blacklist);
		if (list.Count == 0)
		{
			return null;
		}
		int index = DRNG.Instance.NextInt(0, list.Count);
		if (autoAdd)
		{
			UpgradeManager.Instance.AddUpgrade(list[index]);
		}
		return list[index];
	}

	public static List<EnhancementUpgrade> FindUpgradeOfAvailableRarity(Rarity startingRarity, Module module = null, List<EnhancementUpgrade> blacklist = null)
	{
		Array values = Enum.GetValues(typeof(Rarity));
		for (int num = (int)(startingRarity - 1); num >= 0; num--)
		{
			List<EnhancementUpgrade> list = ViableUpgrades((Rarity)values.GetValue(num), module, blacklist);
			if (list.Count > 0)
			{
				return list;
			}
		}
		for (int i = (int)(startingRarity + 1); i < values.Length; i++)
		{
			List<EnhancementUpgrade> list2 = ViableUpgrades((Rarity)values.GetValue(i), module, blacklist);
			if (list2.Count > 0)
			{
				return list2;
			}
		}
		return null;
	}
}
