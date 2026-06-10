using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Model;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.Tools;

namespace NSMedieval.UI.Utils
{
	public static class RoomUtils
	{
		public const string PteRequired = "room_pte_requirement";

		public const string RoleRequired = "room_role_requirement";

		public static string GetLocalizedName(string roomTypeId)
		{
			RoomType byID = Repository<RoomTypeRepository, RoomType>.Instance.GetByID(roomTypeId);
			if (byID == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\RoomUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Room type ");
					messageBuilder.AppendFormatted(roomTypeId);
					messageBuilder.AppendLiteral(" could not be found.");
				}
				Log.Error(messageBuilder);
				return string.Empty;
			}
			return LocKeyUtils.GetName(byID.LocKeys).ToLocalized();
		}

		public static string GetLocalizedContentsList(List<string> roomContents, string lastEntrySeparator, string separator = ", ")
		{
			if (roomContents.Count == 1)
			{
				return GetItemNameLocalized(roomContents[0]);
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			int num = 0;
			foreach (string roomContent in roomContents)
			{
				string itemNameLocalized = GetItemNameLocalized(roomContent);
				if (roomContent.Equals(roomContents.Last()))
				{
					stringBuilder.Append(lastEntrySeparator ?? "");
				}
				stringBuilder.Append(itemNameLocalized);
				if (num < roomContents.Count - 2)
				{
					stringBuilder.Append(separator);
				}
				num++;
			}
			return stringBuilder.ToString();
		}

		public static string GetAlmanacInfo(RoomType roomType)
		{
			string value = "room_must_have".ToLocalized().ToStyled(TooltipStyles.DefaultGreen);
			string value2 = "room_cannot_have".ToLocalized().ToStyled(TooltipStyles.DefaultRed);
			string lastEntrySeparator = " " + "list_or".ToLocalized() + " ";
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(("room_info_" + roomType.GetID()).ToLocalized().ToStyled(TooltipStyles.TooltipDescriptionLine));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(("room_effect_" + roomType.GetID()).ToLocalized());
			if (roomType.MustHave.Count > 0)
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				foreach (RoomTypeMustHave item in roomType.MustHave)
				{
					string text = GetLocalizedContentsLinks(item.Content, lastEntrySeparator);
					if (item.TextKeys != null && item.TextKeys.Any())
					{
						List<string> list = new List<string>(item.TextKeys);
						for (int i = 0; i < list.Count; i++)
						{
							list[i] = list[i].ToLocalized();
						}
						text = GetLocalizedContentsList(list, lastEntrySeparator) + " (" + text + ")";
					}
					if (item != roomType.MustHave.First())
					{
						stringBuilder2.AppendLine();
					}
					if (item.MaxCount == item.MinCount)
					{
						stringBuilder2.Append("list_exactly".ToLocalized() + " " + TextFormatting.GetFormatedItemCount(item.MinCount, text));
					}
					else if (item.MaxCount <= 0)
					{
						stringBuilder2.Append("list_at_least".ToLocalized() + " " + TextFormatting.GetFormatedItemCount(item.MinCount, text));
					}
					else
					{
						stringBuilder2.Append(TextFormatting.GetFormatedItemCount($"{item.MinCount} - {item.MaxCount}", text));
					}
					if (item != roomType.MustHave.Last())
					{
						stringBuilder2.Append(", ");
					}
				}
				stringBuilder.AppendLine();
				stringBuilder.AppendLine(value);
				stringBuilder.AppendLine(stringBuilder2.ToString().ToStyled(TooltipStyles.TooltipAttribute));
			}
			if (roomType.CantHave.Count > 0)
			{
				StringBuilder stringBuilder3 = new StringBuilder();
				string text2 = GetLocalizedContentsLinks(roomType.CantHave, lastEntrySeparator);
				if (roomType.TextKeyCantHaveBuildings != null && roomType.TextKeyCantHaveBuildings.Any())
				{
					List<string> list2 = new List<string>(roomType.TextKeyCantHaveBuildings);
					for (int j = 0; j < list2.Count; j++)
					{
						list2[j] = list2[j].ToLocalized();
					}
					text2 = GetLocalizedContentsList(list2, lastEntrySeparator) + " (" + text2 + ")";
				}
				stringBuilder3.AppendLine(text2);
				if (roomType.CantHaveOtherProductionBuildings)
				{
					stringBuilder3.AppendLine("room_cant_have_other_prod_buildings".ToLocalized() ?? "");
				}
				stringBuilder.AppendLine();
				stringBuilder.AppendLine(value2);
				stringBuilder.AppendLine(stringBuilder3.ToString().ToStyled(TooltipStyles.TooltipAttribute));
			}
			if (roomType.MinimumArea > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine(string.Format("{0} {1}", "room_minimum_area".ToLocalized(), roomType.MinimumArea).ToStyled(TooltipStyles.TooltipAttribute));
			}
			if (GetPlayerTriggeredEventsInfo(roomType, out var line))
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine(line);
			}
			if (GetRoleInfo(roomType, out var line2))
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine(line2);
			}
			return stringBuilder.ToString();
		}

		public static bool GetPlayerTriggeredEventsInfo(RoomType roomType, out string line)
		{
			line = string.Empty;
			foreach (PlayerTriggeredEvent allItem in Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetAllItems())
			{
				if (allItem.RoomTypeIds != null && allItem.RoomTypeIds.Contains(roomType.GetID()))
				{
					line = "room_pte_requirement".ToLocalized() + ": " + UiUtils.GetLocalizedAlmanacLink(LocKeyUtils.GetName(allItem.LocKeys));
					break;
				}
			}
			return !string.IsNullOrEmpty(line);
		}

		public static bool GetRoleInfo(RoomType roomType, out string line)
		{
			line = string.Empty;
			foreach (Role allItem in Repository<RoleRepository, Role>.Instance.GetAllItems())
			{
				if (allItem.GetAllRoleRooms(out var roomIds) && roomIds.Contains(roomType.GetID()))
				{
					line = "room_role_requirement".ToLocalized() + ": " + UiUtils.GetLocalizedAlmanacLink(LocKeyUtils.GetName(allItem.LocKeys));
					break;
				}
			}
			return !string.IsNullOrEmpty(line);
		}

		public static string GetLocalizedContentsLinks(List<string> roomContents, string lastEntrySeparator, string separator = ", ")
		{
			if (roomContents.Count == 1)
			{
				return UiUtils.GetLocalizedAlmanacLink(GetItemLocName(roomContents[0]));
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			int num = 0;
			foreach (string roomContent in roomContents)
			{
				string localizedAlmanacLink = UiUtils.GetLocalizedAlmanacLink(GetItemLocName(roomContent));
				if (roomContent.Equals(roomContents.Last()))
				{
					stringBuilder.Append(lastEntrySeparator ?? "");
				}
				stringBuilder.Append(localizedAlmanacLink);
				if (num < roomContents.Count - 2)
				{
					stringBuilder.Append(separator);
				}
				num++;
			}
			return stringBuilder.ToString();
		}

		private static string GetItemNameLocalized(string itemBlueprintId)
		{
			BaseBuildingBlueprint baseBlueprint = BuildingUtils.GetBaseBlueprint(itemBlueprintId);
			if (baseBlueprint != null)
			{
				return BuildingUtils.GetLocalizedName(baseBlueprint);
			}
			if (Repository<ResourceRepository, Resource>.Instance.GetByID(itemBlueprintId) != null)
			{
				return ResourceUtils.GetLocalizedResourceName(itemBlueprintId);
			}
			return itemBlueprintId;
		}

		public static string GetItemLocName(string itemBlueprintId)
		{
			BaseBuildingBlueprint baseBlueprint = BuildingUtils.GetBaseBlueprint(itemBlueprintId);
			if (baseBlueprint != null)
			{
				return LocKeyUtils.GetName(baseBlueprint.LocKeys);
			}
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(itemBlueprintId);
			if (byID != null)
			{
				return LocKeyUtils.GetName(byID.LocKeys);
			}
			PlantMapResource byID2 = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(itemBlueprintId);
			if (byID2 != null)
			{
				return LocKeyUtils.GetName(byID2.LocKeys);
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\RoomUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Item ");
				messageBuilder.AppendFormatted(itemBlueprintId);
				messageBuilder.AppendLiteral(" not found");
			}
			Log.Error(messageBuilder);
			return itemBlueprintId;
		}
	}
}
