using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Almanac;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Dictionary;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.Stockpiles;
using NSMedieval.Types;

namespace NSMedieval.UI.Utils
{
	public static class AlmanacUtils
	{
		public static IEnumerable<AlmanacEntry> GetEntries()
		{
			List<AlmanacEntry> list = new List<AlmanacEntry>();
			list.AddRange(GetBuildables());
			list.AddRange(GetResources());
			list.AddRange(GetPlants());
			list.AddRange(GetAnimals());
			list.AddRange(GetRooms());
			list.AddRange(GetRoles());
			list.AddRange(GetPlayerTriggeredEvents());
			return list;
		}

		private static IEnumerable<AlmanacEntry> GetPlants()
		{
			List<AlmanacEntry> list = new List<AlmanacEntry>();
			foreach (PlantMapResource allItem in Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetAllItems())
			{
				AlmanacEntry newEntry = GetNewEntry(allItem.GetID(), "Plants", "Plants");
				newEntry.Tags.AddRange(allItem.AlmanacTags);
				List<string> infoLines = PlantUtils.GetInfoLines(allItem);
				string value = "<style=Desc>" + MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(allItem.LocKeys)) + "</style>\n\n" + string.Join("\n", infoLines);
				newEntry.Entries.Dictionary.Add("title", LocKeyUtils.GetName(allItem.LocKeys));
				newEntry.Entries.Dictionary.Add("video", "null");
				newEntry.Entries.Dictionary.Add("info", value);
				list.Add(newEntry);
			}
			return list;
		}

		private static IEnumerable<AlmanacEntry> GetRooms()
		{
			List<AlmanacEntry> list = new List<AlmanacEntry>();
			foreach (RoomType allItem in Repository<RoomTypeRepository, RoomType>.Instance.GetAllItems())
			{
				AlmanacEntry newEntry = GetNewEntry(allItem.GetID(), "Roomtypes", "almanac_default");
				newEntry.Entries.Dictionary.Add("title", LocKeyUtils.GetName(allItem.LocKeys));
				newEntry.Entries.Dictionary.Add("video", "null");
				newEntry.Entries.Dictionary.Add("info", RoomUtils.GetAlmanacInfo(allItem));
				list.Add(newEntry);
			}
			return list;
		}

		private static IEnumerable<AlmanacEntry> GetRoles()
		{
			List<AlmanacEntry> list = new List<AlmanacEntry>();
			foreach (Role allItem in Repository<RoleRepository, Role>.Instance.GetAllItems())
			{
				AlmanacEntry newEntry = GetNewEntry(allItem.GetID(), "Roletypes", allItem.IconPath);
				newEntry.Entries.Dictionary.Add("title", LocKeyUtils.GetName(allItem.LocKeys));
				newEntry.Entries.Dictionary.Add("video", "null");
				newEntry.Entries.Dictionary.Add("info", HumanoidRoleUtils.GetAlmanacInfo(allItem));
				list.Add(newEntry);
			}
			return list;
		}

		private static IEnumerable<AlmanacEntry> GetPlayerTriggeredEvents()
		{
			List<AlmanacEntry> list = new List<AlmanacEntry>();
			foreach (PlayerTriggeredEvent allItem in Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetAllItems())
			{
				_ = allItem.Dialogs.FirstOrDefault().ImagePath;
				AlmanacEntry newEntry = GetNewEntry(allItem.GetID(), "Eventypes", "almanac_default");
				newEntry.Entries.Dictionary.Add("title", LocKeyUtils.GetName(allItem.LocKeys));
				newEntry.Entries.Dictionary.Add("video", "null");
				newEntry.Entries.Dictionary.Add("info", PlayerTriggeredEventUtils.GetAlmanacEntries(allItem));
				list.Add(newEntry);
			}
			return list;
		}

		private static IEnumerable<AlmanacEntry> GetAnimals()
		{
			List<AlmanacEntry> list = new List<AlmanacEntry>();
			foreach (Animal allItem in Repository<AnimalBaseRepository, Animal>.Instance.GetAllItems())
			{
				AlmanacEntry newEntry = GetNewEntry(allItem.GetID(), "Animals", "Animals");
				newEntry.Tags.AddRange(allItem.AlmanacTags);
				List<string> infoLines = AnimalUtils.GetInfoLines(allItem);
				string value = "<style=Desc>" + AnimalUtils.GetLocalizedInfo(allItem) + "</style>\n\n" + string.Join("\n", infoLines);
				newEntry.Entries.Dictionary.Add("title", LocKeyUtils.GetName(allItem.LocKeys));
				newEntry.Entries.Dictionary.Add("video", "null");
				newEntry.Entries.Dictionary.Add("info", value);
				newEntry.SetIconId(allItem.IconPath);
				list.Add(newEntry);
			}
			return list;
		}

		private static IEnumerable<AlmanacEntry> GetResources()
		{
			List<AlmanacEntry> list = new List<AlmanacEntry>();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (!string.IsNullOrEmpty(allItem.BuildingBlueprintID))
				{
					continue;
				}
				if (allItem.HasQuality)
				{
					if (!hashSet.Contains(allItem.ProtoId))
					{
						list.Add(GetEquipmentEntry(allItem));
						hashSet.Add(allItem.ProtoId);
					}
				}
				else
				{
					list.Add(GetResourceEntry(allItem));
				}
			}
			return list;
		}

		private static AlmanacEntry GetEquipmentEntry(Resource item)
		{
			string groupId = GetGroupId(item);
			if (item.Category.HasFlag(ResourceCategory.CtgItem))
			{
				if (item.SortingGroup == "MeleeOnehanded" || item.SortingGroup == "MeleeTwohanded")
				{
					groupId = "Melee";
				}
				else if (item.SortingGroup == "WeaponRanged")
				{
					groupId = "Ranged";
				}
				else if (item.SortingGroup == "ArmorBody" || item.SortingGroup == "ArmorHead")
				{
					groupId = "Armor";
				}
				else if (item.SortingGroup == "WarfareShield")
				{
					groupId = "Shields";
				}
			}
			AlmanacEntry newEntry = GetNewEntry(item.ProtoId, groupId, item.IconPath, item.IconColorOverlay);
			newEntry.Tags.AddRange(item.AlmanacTags);
			List<string> generalInfoLines = ResourceUtils.GetGeneralInfoLines(item);
			List<string> infoLines = EquipmentUtils.GetInfoLines(item);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<style=Desc>" + UiUtils.Localize.GetText(LocKeyUtils.GetInfo(item.LocKeys)) + "</style>");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(string.Join("\n", generalInfoLines) ?? "");
			stringBuilder.AppendLine(string.Join("\n", infoLines) ?? "");
			newEntry.Entries.Dictionary.Add("title", LocKeyUtils.GetName(item.LocKeys));
			newEntry.Entries.Dictionary.Add("video", "null");
			newEntry.Entries.Dictionary.Add("info", stringBuilder.ToString());
			foreach (KeyValuePair<string, List<string>> materialQualityInfoLine in EquipmentUtils.GetMaterialQualityInfoLines(item))
			{
				newEntry.MaterialQualityEntries.Dictionary.Add(materialQualityInfoLine.Key, string.Join("\n", materialQualityInfoLine.Value));
			}
			newEntry.SetIconId(item.IconPath);
			return newEntry;
		}

		private static AlmanacEntry GetResourceEntry(Resource item)
		{
			string groupId = GetGroupId(item);
			string sortingGroup = item.SortingGroup;
			if (sortingGroup == "CarcassHuman" || sortingGroup == "CarcassAnimal")
			{
				groupId = "Carcases";
			}
			AlmanacEntry newEntry = GetNewEntry(item.GetID(), groupId, item.IconPath, item.IconColorOverlay);
			newEntry.Tags.AddRange(item.AlmanacTags);
			string value = string.Concat(str3: string.Join("\n", ResourceUtils.GetInfoLines(item)), str0: "<style=Desc>", str1: UiUtils.Localize.GetText(LocKeyUtils.GetInfo(item.LocKeys)), str2: "</style>\n\n");
			newEntry.Entries.Dictionary.Add("title", LocKeyUtils.GetName(item.LocKeys));
			newEntry.Entries.Dictionary.Add("video", "null");
			newEntry.Entries.Dictionary.Add("info", value);
			newEntry.SetIconId(item.IconPath);
			return newEntry;
		}

		private static string GetGroupId(Resource item)
		{
			string[] array = item.SortingGroup.SplitAtFirstUppercase();
			string result = array[0];
			if (!(array[1] == string.Empty))
			{
				return array[1];
			}
			return result;
		}

		private static IEnumerable<AlmanacEntry> GetBuildables()
		{
			List<AlmanacEntry> list = new List<AlmanacEntry>();
			foreach (BaseBuildingBlueprint allItem in Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetAllItems())
			{
				AlmanacEntry buildableEntry = GetBuildableEntry(allItem);
				if ((object)buildableEntry != null)
				{
					list.Add(buildableEntry);
				}
			}
			Stockpile stockpile = Repository<StockpileRepository, Stockpile>.Instance.GetAllItems().FirstOrDefault();
			string iconColorOverlay = (string.IsNullOrEmpty(stockpile?.IconColorOverlay) ? string.Empty : stockpile?.IconColorOverlay);
			AlmanacEntry newEntry = GetNewEntry("stockpile", "Zone", stockpile?.IconPath, iconColorOverlay);
			newEntry.Entries.Dictionary.Add("title", "ctrl_stockpile");
			newEntry.Entries.Dictionary.Add("video", "null");
			newEntry.SetIconId("default_stockpile");
			string value = "<style=Desc>" + UiUtils.Localize.GetText("building_info_default_stockpile") + "</style>\n" + UiUtils.GetLocalizedAlmanacLink("tutorial_stockpile");
			newEntry.Entries.Dictionary.Add("info", value);
			list.Add(newEntry);
			Cropfield cropfield = Repository<CropfieldRepository, Cropfield>.Instance.GetAllItems().FirstOrDefault();
			string iconColorOverlay2 = (string.IsNullOrEmpty(cropfield?.IconColorOverlay) ? string.Empty : cropfield?.IconColorOverlay);
			AlmanacEntry newEntry2 = GetNewEntry("cropfield", "Zone", cropfield?.IconPath, iconColorOverlay2);
			newEntry2.Entries.Dictionary.Add("title", "zone_name_cropfield");
			newEntry2.Entries.Dictionary.Add("video", "null");
			newEntry2.SetIconId("barley_cropfield");
			value = "<style=Desc>" + UiUtils.Localize.GetText("zone_info_cropfield") + "</style>\n";
			newEntry2.Entries.Dictionary.Add("info", value);
			list.Add(newEntry2);
			return list;
		}

		private static AlmanacEntry GetBuildableEntry(BaseBuildingBlueprint item)
		{
			if (item.BuildingType.HasFlag(BuildingType.Ground))
			{
				return null;
			}
			string groupId = item.BuildingCategoryUI.ToString();
			string text = item.GetID();
			if (item.BuildingCategoryUI == BuildingCategoryUI.None && item.CanBeMoved && !string.IsNullOrEmpty(item.ProtoId))
			{
				groupId = "Produceable";
				text = item.ProtoId;
			}
			AlmanacEntry newEntry = GetNewEntry(text, groupId, BuildingUtils.GetIconPath(text), BuildingUtils.GetIconColor(text));
			newEntry.Tags.AddRange(BuildingUtils.GetAlmanacTags(text));
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<style=Desc>" + BuildingUtils.GetLocalizedInfo(text) + "</style>");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			stringBuilder.AppendJoin("\n", BuildingUtils.GetInfoLines(text, Vec3Int.zero));
			if (item.HasQuality)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendJoin("\n", BuildingUtils.GetProtoQualitySpecificInfos(item));
			}
			newEntry.Entries.Dictionary.Add("title", LocKeyUtils.GetName(item.LocKeys));
			newEntry.Entries.Dictionary.Add("video", "null");
			newEntry.Entries.Dictionary.Add("info", stringBuilder.ToString());
			newEntry.SetIconId(item.IconPath);
			return newEntry;
		}

		private static AlmanacEntry GetNewEntry(string itemId, string groupId, string iconPath, string iconColorOverlay = "")
		{
			string text = string.Empty;
			bool isEnabled;
			if (Repository<AlmanacRepository, NSMedieval.Almanac.Almanac>.Instance.TryGetValue(groupId, out var model))
			{
				text = model.Path;
			}
			else
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(39, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\AlmanacUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(itemId);
					messageBuilder.AppendLiteral(": ");
					messageBuilder.AppendFormatted(groupId);
					messageBuilder.AppendLiteral(" group does not exist in Almanac.json");
				}
				Log.Warning(messageBuilder);
			}
			string text2 = itemId.ToCamelCase().ToLower().CapitalizeFirst();
			AlmanacEntry almanacEntry = new AlmanacEntry(itemId, text2, groupId, text + text2, iconPath, new StringStringDictionary(), new StringStringDictionary(), new List<string>());
			if (!string.IsNullOrEmpty(iconColorOverlay))
			{
				almanacEntry.SetIconColorOverlayId(iconColorOverlay);
			}
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(51, 7, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\AlmanacUtils.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("ID:");
				messageBuilder2.AppendFormatted(itemId);
				messageBuilder2.AppendLiteral(" | Name:");
				messageBuilder2.AppendFormatted(text2);
				messageBuilder2.AppendLiteral(" | GroupID:");
				messageBuilder2.AppendFormatted(groupId);
				messageBuilder2.AppendLiteral(" | Path:");
				messageBuilder2.AppendFormatted(text);
				messageBuilder2.AppendFormatted(text2);
				messageBuilder2.AppendLiteral(" | Icon:");
				messageBuilder2.AppendFormatted(iconPath);
				messageBuilder2.AppendLiteral(" | IconColor:");
				messageBuilder2.AppendFormatted(iconColorOverlay);
			}
			Log.Trace(messageBuilder2);
			return almanacEntry;
		}
	}
}
