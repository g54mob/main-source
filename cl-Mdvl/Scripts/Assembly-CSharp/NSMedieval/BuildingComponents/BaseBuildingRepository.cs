using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;

namespace NSMedieval.BuildingComponents
{
	public class BaseBuildingRepository : DynamicJsonRepository<BaseBuildingRepository, BaseBuildingBlueprint>
	{
		private readonly Dictionary<string, BaseBuildingBlueprint> allItemsDictionary = new Dictionary<string, BaseBuildingBlueprint>();

		private readonly List<BaseBuildingBlueprint> qualityItems = new List<BaseBuildingBlueprint>();

		private readonly Dictionary<BuildingType, List<BaseBuildingBlueprint>> buildings = new Dictionary<BuildingType, List<BaseBuildingBlueprint>>();

		private Dictionary<string, BaseBuildingBlueprint> regularAndQualityItemsByProtoId;

		private BaseBuildingBlueprint[] protoItems;

		private BaseBuildingBlueprint[] regularItems;

		private BaseBuildingBlueprint[] regularAndQualityItems;

		public BaseBuildingRepository(ResourceRepository resourceRepository, ConstructableQualitySettingsRepository constructableQualitySettingsRepository)
		{
			SplitProtoItems();
			CreateQualityItems();
			InitializeBuildingsAsResources();
		}

		public override BaseBuildingBlueprint GetByID(string id)
		{
			if (allItemsDictionary.TryGetValue(id, out var value))
			{
				return value;
			}
			BaseBuildingBlueprint[] array = protoItems;
			foreach (BaseBuildingBlueprint baseBuildingBlueprint in array)
			{
				if (baseBuildingBlueprint.ProtoId == id)
				{
					return baseBuildingBlueprint;
				}
			}
			return base.GetByID(id);
		}

		public bool TryGetDefaultByBuildingType(BuildingType buildingType, out BaseBuildingBlueprint defaultBlueprint)
		{
			defaultBlueprint = null;
			switch (buildingType)
			{
			case BuildingType.Wall:
				defaultBlueprint = GetByID("wood_wall_element");
				break;
			case BuildingType.Floor:
				defaultBlueprint = GetByID("wood_floor");
				break;
			case BuildingType.Beam:
				defaultBlueprint = GetByID("wood_beam");
				break;
			case BuildingType.Roof:
				defaultBlueprint = GetByID("hay_roof_whole");
				break;
			case BuildingType.Door:
				defaultBlueprint = GetByID("wood_door");
				break;
			case BuildingType.Window:
				defaultBlueprint = GetByID("wood_window");
				break;
			case BuildingType.Ladder:
				defaultBlueprint = GetByID("wood_ladder");
				break;
			default:
				return false;
			}
			return defaultBlueprint != null;
		}

		public bool TryGetDefaultById(string blueprintId, out BaseBuildingBlueprint defaultBlueprint)
		{
			defaultBlueprint = null;
			if (blueprintId.Contains("floor"))
			{
				defaultBlueprint = GetByID("wood_floor");
			}
			if (blueprintId.Contains("wall"))
			{
				defaultBlueprint = GetByID("wood_wall_element");
			}
			if (blueprintId.Contains("roof"))
			{
				defaultBlueprint = GetByID("hay_roof_whole");
			}
			if (blueprintId.Contains("beam"))
			{
				defaultBlueprint = GetByID("wood_beam");
			}
			if (blueprintId.Contains("door"))
			{
				defaultBlueprint = GetByID("wood_door");
			}
			if (blueprintId.Contains("window"))
			{
				defaultBlueprint = GetByID("wood_window");
			}
			if (blueprintId.Contains("ladder"))
			{
				defaultBlueprint = GetByID("wood_ladder");
			}
			return defaultBlueprint != null;
		}

		public override IEnumerable<BaseBuildingBlueprint> GetAllItems()
		{
			return regularAndQualityItems;
		}

		protected override string JsonFile()
		{
			return "Constructables/BaseBuildingRepository.json";
		}

		protected override void Refresh()
		{
			base.Refresh();
			SplitProtoItems();
			CreateQualityItems();
			InitializeBuildingsAsResources();
		}

		public List<BaseBuildingBlueprint> GetByBuildingType(BuildingType buildingType)
		{
			if (!buildings.ContainsKey(buildingType))
			{
				buildings.Add(buildingType, new List<BaseBuildingBlueprint>());
				foreach (BaseBuildingBlueprint allItem in base.AllItems)
				{
					if (allItem.BuildingType == buildingType)
					{
						buildings[buildingType].Add(allItem);
					}
				}
			}
			return buildings[buildingType];
		}

		private void CreateQualityItems()
		{
			qualityItems.Clear();
			BaseBuildingBlueprint[] array = protoItems;
			foreach (BaseBuildingBlueprint baseBuildingBlueprint in array)
			{
				if (!baseBuildingBlueprint.HasQuality)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingRepository.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("No quality item found for ");
						messageBuilder.AppendFormatted(baseBuildingBlueprint);
					}
					Log.Error(messageBuilder);
					continue;
				}
				foreach (ConstructableQuality allItem in Repository<ConstructableQualitySettingsRepository, ConstructableQuality>.Instance.GetAllItems())
				{
					float wealthPoints = baseBuildingBlueprint.WealthPoints * allItem.WealthPointsMultiplier;
					float beautyInput = baseBuildingBlueprint.BeautyInput + allItem.BeautyPointsAdd;
					Stat healthStat = GetHealthStat(baseBuildingBlueprint.GetStat(StatType.Health), allItem.HitpointsMultiplier);
					BaseBuildingBlueprint qualityClone = baseBuildingBlueprint.GetQualityClone(allItem.Quality, wealthPoints, beautyInput, healthStat);
					qualityItems.Add(qualityClone);
					allItemsDictionary.TryAdd(qualityClone.GetID(), qualityClone);
				}
			}
			regularAndQualityItems = regularItems.Union(qualityItems).ToArray();
			if (regularAndQualityItemsByProtoId == null)
			{
				regularAndQualityItemsByProtoId = new Dictionary<string, BaseBuildingBlueprint>();
			}
			else
			{
				regularAndQualityItemsByProtoId.Clear();
			}
			array = regularAndQualityItems;
			foreach (BaseBuildingBlueprint baseBuildingBlueprint2 in array)
			{
				if (!string.IsNullOrEmpty(baseBuildingBlueprint2.ProtoId))
				{
					regularAndQualityItemsByProtoId.TryAdd(baseBuildingBlueprint2.ProtoId, baseBuildingBlueprint2);
				}
			}
		}

		private Stat GetHealthStat(Stat protoHealth, float hpMultiplier)
		{
			float num = protoHealth.InitialValue * hpMultiplier;
			float baseValue = num;
			List<StatAttributeElement> max = protoHealth.Max;
			if (max.Count > 0)
			{
				baseValue = max[0].BaseValue * hpMultiplier;
			}
			StatAttributeModifiers attributes = new StatAttributeModifiers(new List<StatAttributeElement>(), new List<StatAttributeElement>
			{
				new StatAttributeElement(baseValue)
			}, new List<StatAttributeElement>(), new List<StatAttributeElement>());
			return new Stat(protoHealth.Type, num, attributes);
		}

		private void SplitProtoItems()
		{
			protoItems = base.AllItems.Where((BaseBuildingBlueprint r) => r.HasQuality).ToArray();
			regularItems = base.AllItems.Where((BaseBuildingBlueprint r) => !r.HasQuality).ToArray();
			allItemsDictionary.Clear();
			BaseBuildingBlueprint[] array = regularItems;
			foreach (BaseBuildingBlueprint baseBuildingBlueprint in array)
			{
				if (!allItemsDictionary.TryAdd(baseBuildingBlueprint.GetID(), baseBuildingBlueprint))
				{
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingRepository.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't add ");
						messageBuilder.AppendFormatted(baseBuildingBlueprint.GetID());
						messageBuilder.AppendLiteral(" to BaseBuildingRepository. Key already exists.");
					}
					Log.Warning(messageBuilder);
				}
			}
		}

		private void InitializeBuildingsAsResources()
		{
			List<Resource> list = new List<Resource>();
			foreach (BaseBuildingBlueprint allItem in GetAllItems())
			{
				if (allItem.CanBeMoved)
				{
					list.Add(GetNewBuildableResourceBlueprint(allItem));
				}
			}
			Repository<ResourceRepository, Resource>.Instance.CacheStructurePiles(list);
		}

		private Resource GetNewBuildableResourceBlueprint(BaseBuildingBlueprint building)
		{
			ProductQualityBase productQualityBase = null;
			if (building.Quality != ProductQuality.None)
			{
				productQualityBase = Repository<ConstructableQualitySettingsRepository, ConstructableQuality>.Instance.GetAllItems().FirstOrDefault((ConstructableQuality cq) => cq.Quality == building.Quality);
			}
			Resource resource = new Resource();
			resource.SetupNewBuildingResource(building.GetID(), ResourceCategory.CtgStructure, building.GetStat(StatType.Health).InitialValue, building.PilePrefabID, building.PileVariationLists, building.TransformSettingsArray, building.IconPath, building.WealthPoints, new List<string>(), building.DecomposeModifiersId, building.Weight, building.GetID(), building.SortingGroup, building.GroupIdentifier, building.ProtoId, building.HasQuality, building.Quality, productQualityBase, building.LocKeys, building.IsArt);
			return resource;
		}

		public BaseBuildingBlueprint GetByProtoId(string itemId)
		{
			return regularAndQualityItemsByProtoId.GetValueOrDefault(itemId);
		}
	}
}
