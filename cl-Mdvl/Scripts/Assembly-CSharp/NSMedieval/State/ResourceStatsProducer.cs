using System;
using System.Collections.Generic;
using System.Threading;
using FoxyVoxel.Logging;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.State
{
	public static class ResourceStatsProducer
	{
		private static Stat sunlightBlueprint;

		private static Thread mainThread;

		private static readonly Dictionary<int, Stat> FreshnessBlueprints = new Dictionary<int, Stat>();

		private static readonly Dictionary<int, Stat> DurabilityBlueprints = new Dictionary<int, Stat>();

		private static readonly Dictionary<int, Stat> PlantBlueprints = new Dictionary<int, Stat>();

		private static readonly Dictionary<int, Stat> FermentationBlueprints = new Dictionary<int, Stat>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			mainThread = Thread.CurrentThread;
			sunlightBlueprint = null;
			FreshnessBlueprints.Clear();
			DurabilityBlueprints.Clear();
			PlantBlueprints.Clear();
			FermentationBlueprints.Clear();
		}

		public static StatsInstance ProduceEquipmentStats(EquipmentInstance owner, Equipment blueprint, StatsInstance stats = null)
		{
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(blueprint.GetID());
			Stat stat = GenerateDurabilityBlueprint(byID.Hitpoints);
			if (stats != null)
			{
				StatInstance stat2 = stats.GetStat(stat.Type);
				if (stat2 == null)
				{
					Log.Error("Equipment stats producer did not found proper stat!", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourceStatsProducer.cs");
					return stats;
				}
				stat2.SetBlueprint(stat);
				if (stats.GetModifierInstanceStack(ModifierType.CustomAttribute)?.GetByTag("equipment_decompose") == null)
				{
					stats.AddAttributeModifier(new CustomAttributeModifierInstance(AttributeType.DecomposeSpeed, blueprint.DecompositionCoefficient, "equipment_decompose"));
				}
				stats.Initialize();
				return stats;
			}
			CustomStatsInstance customStatsInstance = new CustomStatsInstance(owner);
			List<StatInstance> list = new List<StatInstance>();
			StatInstance statInstance = new StatInstance(stat, customStatsInstance);
			list.Add(statInstance);
			if (Mathf.Approximately(statInstance.Current, 0f))
			{
				statInstance.ForceCurrentValue(byID.Hitpoints);
			}
			List<AttributeInstance> list2 = new List<AttributeInstance>();
			list2.Add(new AttributeInstance(AttributeType.DecomposeSpeed, customStatsInstance));
			customStatsInstance.SetCustomStats(list);
			customStatsInstance.SetCustomAttributes(list2);
			customStatsInstance.Initialize();
			customStatsInstance.AddAttributeModifier(new CustomAttributeModifierInstance(AttributeType.DecomposeSpeed, blueprint.DecompositionCoefficient, "equipment_decompose"));
			return customStatsInstance;
		}

		public static StatsInstance ProduceResourceStats(ResourceInstance owner, Resource blueprint, StatsInstance stats = null)
		{
			CustomStatsInstance customStatsInstance = ((stats == null) ? new CustomStatsInstance(owner) : null);
			List<StatInstance> list = new List<StatInstance>();
			bool flag = false;
			if (stats == null)
			{
				flag = true;
				List<AttributeInstance> list2 = new List<AttributeInstance>();
				if (blueprint.DecomposeModifiers != null)
				{
					list2.Add(new AttributeInstance(AttributeType.DecomposeSpeed, customStatsInstance));
				}
				if (blueprint.RottingModifiers != null)
				{
					list2.Add(new AttributeInstance(AttributeType.RottingSpeed, customStatsInstance));
				}
				if (blueprint.FermentingModifiers != null)
				{
					list2.Add(new AttributeInstance(AttributeType.FermentingSpeed, customStatsInstance));
				}
				customStatsInstance.SetCustomAttributes(list2);
			}
			if (stats == null || stats.GetStat(StatType.Health) == null)
			{
				StatInstance statInstance = new StatInstance(GenerateDurabilityBlueprint(blueprint.Hitpoints), customStatsInstance);
				statInstance.ForceCurrentValue(blueprint.Hitpoints);
				list.Add(statInstance);
			}
			else
			{
				stats.GetStat(StatType.Health).SetBlueprint(GenerateDurabilityBlueprint(blueprint.Hitpoints));
			}
			if (!flag)
			{
				if (blueprint.DecomposeModifiers != null && !stats.Attributes.ContainsKey(AttributeType.DecomposeSpeed))
				{
					stats.Attributes.Add(AttributeType.DecomposeSpeed, new AttributeInstance(AttributeType.DecomposeSpeed, stats));
				}
				if (blueprint.RottingModifiers != null && !stats.Attributes.ContainsKey(AttributeType.RottingSpeed))
				{
					stats.Attributes.Add(AttributeType.RottingSpeed, new AttributeInstance(AttributeType.RottingSpeed, stats));
				}
				if (blueprint.FermentingModifiers != null && !stats.Attributes.ContainsKey(AttributeType.FermentingSpeed))
				{
					stats.Attributes.Add(AttributeType.FermentingSpeed, new AttributeInstance(AttributeType.FermentingSpeed, stats));
				}
			}
			if (blueprint.RottingModifiers == null)
			{
				if (stats == null || stats.GetStat(StatType.Freshness) == null)
				{
					list.Add(new StatInstance(GenerateFreshnessBlueprint(0f), customStatsInstance));
				}
				else
				{
					stats.GetStat(StatType.Freshness).SetBlueprint(GenerateFreshnessBlueprint(0f));
				}
			}
			else if (stats == null || stats.GetStat(StatType.Freshness) == null)
			{
				StatInstance statInstance2 = new StatInstance(GenerateFreshnessBlueprint(100f), customStatsInstance);
				statInstance2.ForceCurrentValue(100f);
				list.Add(statInstance2);
			}
			else
			{
				stats.GetStat(StatType.Freshness).SetBlueprint(GenerateFreshnessBlueprint(100f));
			}
			if (blueprint.FermentingModifiers == null)
			{
				if (stats == null || stats.GetStat(StatType.Fermentation) == null)
				{
					list.Add(new StatInstance(GenerateFermentationBlueprint(0f), customStatsInstance));
				}
				else
				{
					stats.GetStat(StatType.Fermentation).SetBlueprint(GenerateFermentationBlueprint(0f));
				}
			}
			else if (stats == null || stats.GetStat(StatType.Fermentation) == null)
			{
				StatInstance statInstance3 = new StatInstance(GenerateFermentationBlueprint(100f), customStatsInstance);
				statInstance3.ForceCurrentValue(100f);
				list.Add(statInstance3);
			}
			else
			{
				stats.GetStat(StatType.Fermentation).SetBlueprint(GenerateFermentationBlueprint(100f));
			}
			if (stats != null)
			{
				return stats;
			}
			customStatsInstance.SetCustomStats(list);
			customStatsInstance.Initialize(forceReInit: true);
			return customStatsInstance;
		}

		public static Stat GetDurabilityBlueprintMapResource(MapResourceInstance owner, float durability)
		{
			if (owner is PlantMapResourceInstance)
			{
				return GeneratePlantDurabilityBlueprint(durability);
			}
			return GenerateDurabilityBlueprint(durability);
		}

		private static Stat GetSunlightBlueprint(MapResourceInstance owner)
		{
			if (sunlightBlueprint != null)
			{
				return sunlightBlueprint;
			}
			int num = 100;
			List<StatAttributeElement> list = new List<StatAttributeElement>();
			list.Add(new StatAttributeElement(0f));
			List<StatAttributeElement> list2 = new List<StatAttributeElement>();
			list2.Add(new StatAttributeElement(num));
			List<StatAttributeElement> list3 = new List<StatAttributeElement>();
			list3.Add(new StatAttributeElement(-1f, new AttributeType[1] { AttributeType.SunlightLoss }));
			List<StatAttributeElement> list4 = new List<StatAttributeElement>();
			list4.Add(new StatAttributeElement(1f));
			sunlightBlueprint = new Stat(StatType.SunLight, 0f, new StatAttributeModifiers(list, list2, list3, list4));
			return sunlightBlueprint;
		}

		private static StatInstance CreateSunlightStat(MapResourceInstance owner)
		{
			Stat blueprint = GetSunlightBlueprint(owner);
			CustomStatsInstance statsInstance = new CustomStatsInstance(owner);
			StatInstance statInstance = new StatInstance(blueprint, statsInstance);
			statInstance.SetBlueprint(blueprint);
			statInstance.ForceCurrentValue(20f);
			return statInstance;
		}

		public static StatsInstance ProduceMapResourceStats(MapResourceInstance owner, float durability, StatsInstance stats = null)
		{
			Stat durabilityBlueprintMapResource = GetDurabilityBlueprintMapResource(owner, durability);
			PlantMapResourceInstance plantMapResourceInstance = owner as PlantMapResourceInstance;
			if (stats != null)
			{
				stats.SetOwner(owner);
				stats.GetStat(durabilityBlueprintMapResource.Type).SetBlueprint(durabilityBlueprintMapResource);
				if (plantMapResourceInstance != null)
				{
					if (plantMapResourceInstance.Blueprint != null && plantMapResourceInstance.Blueprint.UseSunlight)
					{
						StatInstance stat = stats.GetStat(StatType.SunLight);
						if (stat == null)
						{
							stat = CreateSunlightStat(owner);
							stats.AddStatInstance(stat);
						}
						else
						{
							stat.SetBlueprint(GetSunlightBlueprint(owner));
						}
						if (stats.GetAttributeInstance(AttributeType.SunlightLoss) == null)
						{
							stats.Attributes.Add(AttributeType.SunlightLoss, new AttributeInstance(AttributeType.SunlightLoss, stats));
						}
						SunlightModifierInstance modifier = new SunlightModifierInstance(AttributeType.SunlightLoss, 1f, null);
						stats.AddAttributeModifier(modifier);
					}
					if (stats.GetAttributeInstance(AttributeType.HealthRecovery) == null)
					{
						stats.Attributes.Add(AttributeType.HealthRecovery, new AttributeInstance(AttributeType.HealthRecovery, stats));
					}
					PlantHpModifierInstance modifier2 = new PlantHpModifierInstance(AttributeType.HealthRecovery, 1f, null);
					stats.AddAttributeModifier(modifier2);
					stats.Initialize(forceReInit: true);
				}
				return stats;
			}
			CustomStatsInstance customStatsInstance = new CustomStatsInstance(owner);
			List<StatInstance> list = new List<StatInstance>();
			StatInstance statInstance = new StatInstance(durabilityBlueprintMapResource, customStatsInstance);
			statInstance.ForceCurrentValue(durability);
			list.Add(statInstance);
			List<AttributeInstance> list2 = new List<AttributeInstance>();
			if (plantMapResourceInstance != null)
			{
				if (plantMapResourceInstance.Blueprint.UseSunlight)
				{
					StatInstance item = CreateSunlightStat(owner);
					list.Add(item);
					list2.Add(new AttributeInstance(AttributeType.SunlightLoss, customStatsInstance));
				}
				list2.Add(new AttributeInstance(AttributeType.HealthRecovery, customStatsInstance));
			}
			customStatsInstance.SetCustomStats(list);
			customStatsInstance.SetCustomAttributes(list2);
			if (plantMapResourceInstance != null)
			{
				PlantHpModifierInstance modifier3 = new PlantHpModifierInstance(AttributeType.HealthRecovery, 1f, null);
				customStatsInstance.AddAttributeModifier(modifier3);
				if (plantMapResourceInstance.Blueprint.UseSunlight)
				{
					SunlightModifierInstance modifier4 = new SunlightModifierInstance(AttributeType.SunlightLoss, 1f, null);
					customStatsInstance.AddAttributeModifier(modifier4);
				}
			}
			customStatsInstance.Initialize();
			return customStatsInstance;
		}

		private static Stat GeneratePlantDurabilityBlueprint(float max)
		{
			int key = Mathf.RoundToInt(max);
			if (PlantBlueprints.ContainsKey(key))
			{
				return PlantBlueprints[key];
			}
			List<StatAttributeElement> list = new List<StatAttributeElement>();
			list.Add(new StatAttributeElement(0f));
			List<StatAttributeElement> list2 = new List<StatAttributeElement>();
			list2.Add(new StatAttributeElement(max));
			List<StatAttributeElement> list3 = new List<StatAttributeElement>();
			list3.Add(new StatAttributeElement(1f, new AttributeType[1] { AttributeType.HealthRecovery }));
			List<StatAttributeElement> list4 = new List<StatAttributeElement>();
			list4.Add(new StatAttributeElement(1f));
			Stat stat = new Stat(StatType.Health, 0f, new StatAttributeModifiers(list, list2, list3, list4));
			PlantBlueprints.Add(key, stat);
			return stat;
		}

		private static Stat GenerateDurabilityBlueprint(float max)
		{
			if (mainThread != Thread.CurrentThread)
			{
				throw new Exception("Tried to generate stat blueprint from non-main thread.");
			}
			int key = Mathf.RoundToInt(max);
			if (DurabilityBlueprints.ContainsKey(key))
			{
				return DurabilityBlueprints[key];
			}
			List<StatAttributeElement> list = new List<StatAttributeElement>();
			list.Add(new StatAttributeElement(0f));
			List<StatAttributeElement> list2 = new List<StatAttributeElement>();
			list2.Add(new StatAttributeElement(max));
			List<StatAttributeElement> list3 = new List<StatAttributeElement>();
			list3.Add(new StatAttributeElement(1f, new AttributeType[1] { AttributeType.DecomposeSpeed }));
			List<StatAttributeElement> list4 = new List<StatAttributeElement>();
			list4.Add(new StatAttributeElement(1f));
			Stat stat = new Stat(StatType.Health, 0f, new StatAttributeModifiers(list, list2, list3, list4));
			DurabilityBlueprints.Add(key, stat);
			return stat;
		}

		private static Stat GenerateFreshnessBlueprint(float max)
		{
			int key = Mathf.RoundToInt(max);
			if (FreshnessBlueprints.ContainsKey(key))
			{
				return FreshnessBlueprints[key];
			}
			List<StatAttributeElement> list = new List<StatAttributeElement>();
			list.Add(new StatAttributeElement(0f));
			List<StatAttributeElement> list2 = new List<StatAttributeElement>();
			list2.Add(new StatAttributeElement(max));
			List<StatAttributeElement> list3 = new List<StatAttributeElement>();
			list3.Add(new StatAttributeElement(1f, new AttributeType[1] { AttributeType.RottingSpeed }));
			List<StatAttributeElement> list4 = new List<StatAttributeElement>();
			list4.Add(new StatAttributeElement(1f));
			Stat stat = new Stat(StatType.Freshness, max, new StatAttributeModifiers(list, list2, list3, list4));
			FreshnessBlueprints.Add(key, stat);
			return stat;
		}

		private static Stat GenerateFermentationBlueprint(float max)
		{
			int key = Mathf.RoundToInt(max);
			if (FermentationBlueprints.ContainsKey(key))
			{
				return FermentationBlueprints[key];
			}
			List<StatAttributeElement> list = new List<StatAttributeElement>();
			list.Add(new StatAttributeElement(0f));
			List<StatAttributeElement> list2 = new List<StatAttributeElement>();
			list2.Add(new StatAttributeElement(max));
			List<StatAttributeElement> list3 = new List<StatAttributeElement>();
			list3.Add(new StatAttributeElement(1f, new AttributeType[1] { AttributeType.FermentingSpeed }));
			List<StatAttributeElement> list4 = new List<StatAttributeElement>();
			list4.Add(new StatAttributeElement(1f));
			Stat stat = new Stat(StatType.Fermentation, max, new StatAttributeModifiers(list, list2, list3, list4));
			FermentationBlueprints.Add(key, stat);
			return stat;
		}
	}
}
