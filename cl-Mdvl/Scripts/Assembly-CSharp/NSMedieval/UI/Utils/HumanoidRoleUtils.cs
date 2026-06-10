using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Extensions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class HumanoidRoleUtils
	{
		public static string GetRoleName(string roleId, HumanoidInstance roleOwner = null)
		{
			Role byID = Repository<RoleRepository, Role>.Instance.GetByID(roleId);
			if (byID == null)
			{
				return string.Empty;
			}
			return GetRoleName(byID, roleOwner);
		}

		public static string GetRoleName(Role role, HumanoidInstance roleOwner)
		{
			if (roleOwner != null)
			{
				return UiUtils.Localize.GetText(LocKeyUtils.GetName(role.LocKeys), roleOwner.GetInfo().BodyType) ?? "";
			}
			return UiUtils.Localize.GetText(LocKeyUtils.GetName(role.LocKeys)) ?? "";
		}

		public static string GetRoleNameWithIconAndLevel(RoleInstance roleInstance)
		{
			if (roleInstance == null)
			{
				return string.Empty;
			}
			return GetRoleNameWithIconAndLevel(roleInstance.Blueprint, roleInstance.Level, roleInstance.RoleOwner);
		}

		public static string GetRoleNameWithIconAndLevel(Role role, HumanoidInstance humanoidInstance, bool nextLevel = false)
		{
			HumanoidBehaviour activeBehaviour = humanoidInstance.ActiveBehaviour;
			if (activeBehaviour != null)
			{
				IRoleOwner humanoidRoleOwner = activeBehaviour.HumanoidRoleOwner;
				if (humanoidRoleOwner != null && humanoidRoleOwner.RoleInstance != null)
				{
					int level = (nextLevel ? (humanoidRoleOwner.RoleInstance.Level + 1) : humanoidRoleOwner.RoleInstance.Level);
					return role.GetSpriteAsset() + " " + GetRoleName(role, humanoidInstance) + GetLevelNumeral(level);
				}
			}
			string text = (nextLevel ? GetLevelNumeral(0) : string.Empty);
			return role.GetSpriteAsset() + " " + GetRoleName(role, humanoidInstance) + text;
		}

		public static string GetRoleNameWithIconAndLevel(Role role, int level, HumanoidInstance roleOwner = null)
		{
			return role.GetSpriteAsset() + " " + GetRoleName(role, roleOwner) + GetLevelNumeral(level);
		}

		public static string GetLevelNumeral(int level)
		{
			return level switch
			{
				0 => " I", 
				1 => " II", 
				2 => " III", 
				_ => "III", 
			};
		}

		public static string GetRoleNameWithIcon(Role role, HumanoidInstance roleOwner)
		{
			return role.GetSpriteAsset() + " " + GetRoleName(role, roleOwner);
		}

		public static string GetRoleDescription(Role role, HumanoidInstance humanoidInstance, bool nextLevel = false)
		{
			return ParseRoleText(UiUtils.Localize.GetText(LocKeyUtils.GetDescription(role.LocKeys), humanoidInstance), humanoidInstance, role, nextLevel);
		}

		public static string GetRoleInfo(Role role, HumanoidInstance humanoidInstance)
		{
			return ParseRoleText(UiUtils.Localize.GetText(LocKeyUtils.GetInfo(role.LocKeys), humanoidInstance), humanoidInstance, role);
		}

		public static string ParseRoleText(string text, HumanoidInstance roleOwner, RoleInstance roleInstance)
		{
			return text.Replace("<role>", GetRoleNameWithIconAndLevel(roleInstance)).Replace("<role_jobs>", GetRoleRelatedGoalPreferences(roleOwner, roleInstance.Blueprint)).Replace("<list_of_requirements>", GetMissingRequirements(roleOwner, roleInstance.Blueprint));
		}

		public static string ParseRoleText(string text, HumanoidInstance roleOwner, Role role, bool nextLevel = false)
		{
			return text.Replace("<role>", GetRoleNameWithIconAndLevel(role, roleOwner, nextLevel)).Replace("<role_jobs>", GetRoleRelatedGoalPreferences(roleOwner, role, nextLevel)).Replace("<event_name>", GetRoleDefaultEvent(roleOwner, role))
				.Replace("<list_of_requirements>", GetMissingRequirements(roleOwner, role));
		}

		private static string GetMissingRequirements(HumanoidInstance humanoidInstance, Role role)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine();
			int num = ((humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleLevel >= 0) ? humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleLevel : 0);
			string religiousRequirement = role.RoleLevels[num].ReligiousRequirement;
			string thresholdName = humanoidInstance.HumanoidBelief.GetThresholdName(humanoidInstance.Stats.GetStat(StatType.ReligiousAlignment).Current);
			if (!string.IsNullOrEmpty(religiousRequirement) && !religiousRequirement.Equals(thresholdName))
			{
				stringBuilder.AppendLine("menu_ReligiousAlignment".ToLocalized() + ": " + religiousRequirement.ToLocalized() + " (" + thresholdName.ToLocalized() + ")");
			}
			List<Room> rooms;
			bool allRoomsOfType = VillageManager.ActiveVillage.Map.RoomDetection.GetAllRoomsOfType(role.RoleLevels[num].RoomRequirement, out rooms);
			string[] roomRequirement = role.RoleLevels[num].RoomRequirement;
			if (roomRequirement != null && roomRequirement.Length > 0)
			{
				List<string> list = new List<string>();
				string[] array = roomRequirement;
				foreach (string id in array)
				{
					list.Add(Repository<RoomTypeRepository, RoomType>.Instance.GetByID(id).LocKeys.GetNameLocalized() ?? "");
				}
				stringBuilder.AppendLine(list.ToPrettyStringNoBrackets(", ", " " + "list_or".ToLocalized() + " ") ?? "");
				if (allRoomsOfType)
				{
					List<RoomTypeMustHave> roomRequiredFurniture = role.RoleLevels[num].RoomRequiredFurniture;
					if (roomRequiredFurniture != null && roomRequiredFurniture.Count > 0)
					{
						foreach (RoomTypeMustHave item in role.RoleLevels[num].RoomRequiredFurniture)
						{
							int num2 = 0;
							foreach (string furnitureId in item.Content)
							{
								num2 += rooms.Sum((Room room) => room.IterateRoomFurniture().Count((BaseBuildingInstance buildableObject) => buildableObject.Blueprint.ProtoId.Equals(furnitureId) || buildableObject.Blueprint.GetID().Equals(furnitureId)));
							}
							if (num2 < item.MinCount && item.MinCount >= 1)
							{
								IEnumerable<string> source = item.TextKeys.Select((string textKey) => textKey.ToLocalized());
								stringBuilder.AppendLine($"<indent=10%>{item.MinCount}x ({num2})</indent> <indent=20%>{source.ToList().ToPrettyStringNoBrackets()}</indent>");
							}
						}
					}
				}
			}
			Room singleOwnerRoom = VillageManager.ActiveVillage.Map.RoomDetection.GetSingleOwnerRoom(humanoidInstance);
			if (role.RoleLevels[num].OwnRoomRequirement && singleOwnerRoom == null)
			{
				stringBuilder.AppendLine(UiUtils.Localize.GetText("role_own_room", humanoidInstance) ?? "");
			}
			if (singleOwnerRoom != null)
			{
				List<RoomTypeMustHave> roomRequiredFurniture = role.RoleLevels[num].OwnRoomRequiredFurniture;
				if (roomRequiredFurniture != null && roomRequiredFurniture.Count > 0)
				{
					foreach (RoomTypeMustHave item2 in role.RoleLevels[num].OwnRoomRequiredFurniture)
					{
						int num3 = 0;
						foreach (string furnitureId2 in item2.Content)
						{
							num3 += singleOwnerRoom.IterateRoomFurniture().Count((BaseBuildingInstance baseBuildableObject) => baseBuildableObject.Blueprint.ProtoId.Equals(furnitureId2) || baseBuildableObject.Blueprint.GetID().Equals(furnitureId2));
						}
						if (num3 < item2.MinCount && item2.MinCount >= 1)
						{
							IEnumerable<string> source2 = item2.TextKeys.Select((string textKey) => textKey.ToLocalized());
							stringBuilder.AppendLine($"<indent=10%>{item2.MinCount}x ({num3})</indent> <indent=20%>{source2.ToList().ToPrettyStringNoBrackets()}</indent>");
						}
					}
				}
			}
			List<StringIntPair> globalRequiredStoredResources = role.RoleLevels[num].GlobalRequiredStoredResources;
			if (globalRequiredStoredResources != null && globalRequiredStoredResources.Count > 0)
			{
				List<string> list2 = new List<string>();
				foreach (StringIntPair item3 in globalRequiredStoredResources)
				{
					int totalCount = MonoSingleton<ResourcePileTracker>.Instance.GetCount(item3.Key).TotalCount;
					if (item3.Value < totalCount)
					{
						list2.Add($"{ResourceUtils.GetLocalizedNameWithSprite(item3.Key)}: {item3.Value} ({totalCount})");
					}
				}
				if (list2.Count > 0)
				{
					stringBuilder.AppendLine("role_global_resources".ToLocalized() + ": " + list2.ToPrettyStringNoBrackets());
				}
			}
			return stringBuilder.ToString();
		}

		public static string GetRoleRelatedGoalPreferences(HumanoidInstance roleOwner, Role role, bool nextLevel = false)
		{
			if (roleOwner.ActiveBehaviour == null)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			if (MonoSingleton<WorkerManager>.Instance.IsRoleTaken(role, out var humanoidInstance) && humanoidInstance == roleOwner)
			{
				num = (nextLevel ? Mathf.Clamp(roleOwner.WorkerBehaviour.HumanoidRoleOwner.RoleLevel + 1, 0, role.RoleLevels.Length - 1) : roleOwner.WorkerBehaviour.HumanoidRoleOwner.RoleLevel);
			}
			foreach (StringIntPair goalPreference in role.RoleLevels[num].GoalPreferences)
			{
				GoalPreference byID = Repository<GoalPreferenceRepository, GoalPreference>.Instance.GetByID(goalPreference.Key);
				if (byID == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidRoleUtils.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("GoalPreference: ");
						messageBuilder.AppendFormatted(goalPreference.Key);
						messageBuilder.AppendLiteral(" not found");
					}
					Log.Error(messageBuilder);
					continue;
				}
				GoalPreferenceLevel value = (GoalPreferenceLevel)goalPreference.Value;
				if (value != GoalPreferenceLevel.None)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append("\n");
					}
					stringBuilder.Append(AssetUtils.GetSpriteAsset(value.ToString().ToLower()) + " " + UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys)));
				}
			}
			return stringBuilder.ToString().Trim(',').Trim(' ');
		}

		public static List<string> GetRoleLevelUpTooltipLines(HumanoidInstance humanoidInstance, Role role)
		{
			List<string> list = new List<string>();
			if (humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.AssignedRole && !humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.HasRole(role))
			{
				list.Add(UiUtils.Localize.GetText("role_already_assigned") + ": " + UiUtils.Localize.GetText(LocKeyUtils.GetName(humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.Blueprint.LocKeys), humanoidInstance));
				return list;
			}
			if (humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.HasRole(role) && humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleLevel == role.RoleLevels.Length - 1)
			{
				list.Add(UiUtils.Localize.GetText("role_max") ?? "");
				return list;
			}
			FillNextLevelLines(list, humanoidInstance, role);
			return list;
		}

		public static List<string> GetPossibleRoleLevelUpTooltipLines(HumanoidInstance humanoidInstance)
		{
			List<string> list = new List<string>();
			if (humanoidInstance?.ActiveBehaviour == null || humanoidInstance.HasDisposed)
			{
				return list;
			}
			Role role = humanoidInstance.ActiveBehaviour.HumanoidRoleOwner?.RoleInstance?.Blueprint;
			if (role == null)
			{
				foreach (Role allItem in Repository<RoleRepository, Role>.Instance.GetAllItems())
				{
					if (humanoidInstance.ActiveBehaviour.HumanoidRoleOwner != null && humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.CanRoleBeLeveledUp(allItem))
					{
						list.Add(GetRoleNameWithIconAndLevel(allItem, humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleLevel + 1, humanoidInstance));
					}
				}
				if (list.Count > 0)
				{
					string text = list.ToPrettyStringNoBrackets(", ", "", newLineSeparator: true, 10);
					list.Clear();
					list.Add("eligible_for_roles".ToLocalized(humanoidInstance.GetInfo().BodyType) + ": \n " + text);
				}
				else
				{
					list.Add("not_eligible_for_roles_info".ToLocalized(humanoidInstance.GetInfo().BodyType).ToStyled(TooltipStyles.DefaultRed));
				}
				return list;
			}
			if (humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.HasRole(role) && humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleLevel == role.RoleLevels.Length - 1)
			{
				list.Add(UiUtils.Localize.GetText("role_max") ?? "");
				return list;
			}
			FillNextLevelLines(list, humanoidInstance, role);
			return list;
		}

		private static void FillNextLevelLines(List<string> lines, HumanoidInstance humanoidInstance, Role role)
		{
			lines.Add(TooltipStyles.ApplyStyle(UiUtils.Localize.GetText("role_requirements"), TooltipStyles.TooltipTitle));
			if (humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.InsInCooldown(out var hoursLeft))
			{
				lines.Add("role_cooldown".ToLocalized() + ": " + UiUtils.GetTimeFormatByHours(hoursLeft, isDuration: true));
			}
			int num = humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleLevel + 1;
			if (num > 0)
			{
				int hoursRequirement = role.RoleLevels[num].HoursRequirement;
				int hoursInRole = humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.GetHoursInRole(role);
				lines.Add(FormatTooltipLine(UiUtils.Localize.GetText("hours_spent_in_role") + ": " + UiUtils.GetTimeFormatByHours(hoursRequirement) + " (" + UiUtils.GetTimeFormatByHours(hoursInRole, isDuration: true) + ")", hoursInRole >= hoursRequirement));
			}
			foreach (SkillLevelPair skillRequirement in role.RoleLevels[num].SkillRequirements)
			{
				WorkerSkill skill = humanoidInstance.Skills.GetSkill(skillRequirement.Key);
				if (skill != null)
				{
					lines.Add(FormatTooltipLine($"{UiUtils.Localize.GetText(skill.GetSkillTextKey())}: {skillRequirement.Value} ({skill.Level})", skill.Level >= skillRequirement.Value));
				}
			}
			string religiousRequirement = role.RoleLevels[num].ReligiousRequirement;
			if (!string.IsNullOrEmpty(religiousRequirement))
			{
				string thresholdName = humanoidInstance.HumanoidBelief.GetThresholdName(humanoidInstance.Stats.GetStat(StatType.ReligiousAlignment).Current);
				lines.Add(FormatTooltipLine(UiUtils.Localize.GetText("menu_ReligiousAlignment") + ": " + UiUtils.Localize.GetText(religiousRequirement) + " (" + UiUtils.Localize.GetText(thresholdName) + ")", religiousRequirement.Equals(thresholdName)));
			}
			string[] roomRequirement = role.RoleLevels[num].RoomRequirement;
			if (roomRequirement != null && roomRequirement.Length > 0)
			{
				List<string> list = new List<string>();
				List<Room> rooms;
				bool allRoomsOfType = VillageManager.ActiveVillage.Map.RoomDetection.GetAllRoomsOfType(role.RoleLevels[num].RoomRequirement, out rooms);
				string[] array = roomRequirement;
				foreach (string id in array)
				{
					list.Add(UiUtils.Localize.GetText(LocKeyUtils.GetName(Repository<RoomTypeRepository, RoomType>.Instance.GetByID(id).LocKeys)) ?? "");
				}
				lines.Add(FormatTooltipLine(list.ToPrettyStringNoBrackets(", ", " " + "list_or".ToLocalized() + " "), allRoomsOfType) ?? "");
				List<RoomTypeMustHave> roomRequiredFurniture = role.RoleLevels[num].RoomRequiredFurniture;
				if (roomRequiredFurniture != null && roomRequiredFurniture.Count > 0)
				{
					foreach (RoomTypeMustHave item in role.RoleLevels[num].RoomRequiredFurniture)
					{
						int num2 = 0;
						foreach (string furnitureId in item.Content)
						{
							num2 += rooms.Sum((Room room) => room.IterateRoomFurniture().Count((BaseBuildingInstance buildableObject) => buildableObject.Blueprint.ProtoId.Equals(furnitureId) || buildableObject.Blueprint.GetID().Equals(furnitureId)));
						}
						bool anyRoomHasFurniture = num2 >= item.MinCount;
						string countText = string.Empty;
						if (item.MinCount > 1)
						{
							countText = $"{item.MinCount}x ({num2}) ";
						}
						lines.AddRange(item.TextKeys.Select((string textKey) => "  - " + FormatTooltipLine(countText + UiUtils.Localize.GetText(UiUtils.Localize.GetText(textKey)), anyRoomHasFurniture)));
					}
				}
			}
			if (role.RoleLevels[num].OwnRoomRequirement)
			{
				Room singleOwnerRoom = VillageManager.ActiveVillage.Map.RoomDetection.GetSingleOwnerRoom(humanoidInstance);
				lines.Add(FormatTooltipLine(UiUtils.Localize.GetText("role_own_room", humanoidInstance) ?? "", singleOwnerRoom != null));
				if (singleOwnerRoom != null)
				{
					List<RoomTypeMustHave> roomRequiredFurniture = role.RoleLevels[num].OwnRoomRequiredFurniture;
					if (roomRequiredFurniture != null && roomRequiredFurniture.Count > 0)
					{
						foreach (RoomTypeMustHave item2 in role.RoleLevels[num].OwnRoomRequiredFurniture)
						{
							int num3 = 0;
							foreach (string furnitureId2 in item2.Content)
							{
								num3 += singleOwnerRoom.IterateRoomFurniture().Count((BaseBuildingInstance baseBuildableObject) => baseBuildableObject.Blueprint.ProtoId.Equals(furnitureId2) || baseBuildableObject.Blueprint.GetID().Equals(furnitureId2));
							}
							bool anyRoomHasFurniture2 = num3 >= item2.MinCount;
							lines.AddRange(item2.TextKeys.Select((string textKey) => "  - " + FormatTooltipLine(UiUtils.Localize.GetText(UiUtils.Localize.GetText(textKey)), anyRoomHasFurniture2)));
						}
					}
				}
			}
			List<StringIntPair> globalRequiredStoredResources = role.RoleLevels[num].GlobalRequiredStoredResources;
			if (globalRequiredStoredResources == null || globalRequiredStoredResources.Count <= 0)
			{
				return;
			}
			List<string> list2 = new List<string>();
			foreach (StringIntPair item3 in globalRequiredStoredResources)
			{
				int totalCount = MonoSingleton<ResourcePileTracker>.Instance.GetCount(item3.Key).TotalCount;
				list2.Add(FormatTooltipLine($"{ResourceUtils.GetLocalizedNameWithSprite(item3.Key)}: {item3.Value} ({totalCount})", totalCount >= item3.Value));
			}
			if (list2.Count > 0)
			{
				lines.Add("role_global_resources".ToLocalized() + ": \n " + list2.ToPrettyStringNoBrackets(", ", "", newLineSeparator: true, 10));
			}
		}

		private static string FormatTooltipLine(string line, bool isPossible)
		{
			string spriteId = (isPossible ? "checkmark_yes" : "checkmark_no");
			string text = (isPossible ? "<style=Normal>" : "<style=DefaultRed>");
			return AssetUtils.GetSpriteAsset(spriteId) + text + line + "</style>";
		}

		private static string GetRoleDefaultEvent(HumanoidInstance roleOwner, Role role)
		{
			foreach (PlayerTriggeredEvent allItem in Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetAllItems())
			{
				if (!string.IsNullOrEmpty(allItem.RoleId) && allItem.RoleId.Equals(role.GetID()))
				{
					return UiUtils.GetLocalizedAlmanacLink(LocKeyUtils.GetName(allItem.LocKeys));
				}
			}
			return string.Empty;
		}

		public static string GetAlmanacInfo(Role role)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(UiUtils.Localize.GetText(LocKeyUtils.GetDescription(role.LocKeys), BodyType.Female));
			foreach (PlayerTriggeredEvent allItem in Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetAllItems())
			{
				if (!string.IsNullOrEmpty(allItem.RoleId) && allItem.RoleId.Equals(role.GetID()))
				{
					stringBuilder.AppendLine();
					string text = "role_active_in_pte".ToLocalized();
					stringBuilder.AppendLine(text + ": " + UiUtils.GetLocalizedAlmanacLink(LocKeyUtils.GetName(allItem.LocKeys)));
					break;
				}
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("role_requirements".ToLocalized().ToStyled(TooltipStyles.TooltipSubtitleLineStyle));
			StringBuilder stringBuilder2 = new StringBuilder();
			List<string> list = new List<string>();
			int num = 0;
			RoleLevel[] roleLevels = role.RoleLevels;
			foreach (RoleLevel roleLevel in roleLevels)
			{
				num++;
				string arg = "general_level".ToLocalized();
				stringBuilder.AppendLine();
				stringBuilder.AppendLine(string.Format("<indent={0}>{1}: {2}</indent>", "3%", arg, num).ToStyled(TooltipStyles.TooltipAttribute));
				if (roleLevel.SkillRequirements.Count > 0)
				{
					stringBuilder.AppendLine(("<indent=6%>" + "general_skill_requirements".ToLocalized() + "</indent>").ToStyled(TooltipStyles.TooltipAttribute));
					foreach (SkillLevelPair skillRequirement in roleLevel.SkillRequirements)
					{
						string text2 = ("skill_name_" + skillRequirement.Key).ToLocalized();
						stringBuilder.AppendLine(string.Format("<indent={0}>{1} {2} {3}</indent>", "9%", AssetUtils.GetSpriteAsset(skillRequirement.Key.ToString().ToLower()), text2, skillRequirement.Value));
					}
				}
				string[] roomRequirement = roleLevel.RoomRequirement;
				bool isEnabled;
				if (roomRequirement != null && roomRequirement.Length > 0)
				{
					list.Clear();
					string text3 = "general_room_requirements".ToLocalized().ToStyled(TooltipStyles.TooltipAttribute);
					roomRequirement = roleLevel.RoomRequirement;
					foreach (string text4 in roomRequirement)
					{
						RoomType byID = Repository<RoomTypeRepository, RoomType>.Instance.GetByID(text4);
						if (byID == null)
						{
							FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidRoleUtils.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("There is no Room: ");
								messageBuilder.AppendFormatted(text4);
							}
							Log.Error(messageBuilder);
						}
						else
						{
							list.Add(LocKeyUtils.GetName(byID.LocKeys));
						}
					}
					stringBuilder.AppendLine("<indent=6%>" + text3 + ": " + UiUtils.GetLocalizedAlmanacLinks(list) + "</indent>");
				}
				List<RoomTypeMustHave> roomRequiredFurniture = roleLevel.RoomRequiredFurniture;
				if (roomRequiredFurniture != null && roomRequiredFurniture.Count > 0)
				{
					list.Clear();
					string text5 = "general_room_furniture_requirements".ToLocalized().ToStyled(TooltipStyles.TooltipAttribute);
					foreach (RoomTypeMustHave item in roleLevel.RoomRequiredFurniture)
					{
						foreach (string building in item.Buildings)
						{
							BaseBuildingBlueprint byID2 = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(building);
							if (byID2 == null)
							{
								FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidRoleUtils.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("There is no Building: ");
									messageBuilder.AppendFormatted(building);
								}
								Log.Error(messageBuilder);
							}
							else
							{
								list.Add(LocKeyUtils.GetName(byID2.LocKeys));
							}
						}
					}
					stringBuilder.AppendLine("<indent=6%>" + text5 + ": " + UiUtils.GetLocalizedAlmanacLinks(list) + "</indent>");
				}
				if (roleLevel.OwnRoomRequirement)
				{
					string text6 = "general_own_room_requirement".ToLocalized().ToStyled(TooltipStyles.TooltipAttribute);
					stringBuilder.AppendLine("<indent=6%>" + text6 + "</indent>");
				}
				roomRequiredFurniture = roleLevel.OwnRoomRequiredFurniture;
				if (roomRequiredFurniture != null && roomRequiredFurniture.Count > 0)
				{
					stringBuilder2.Clear();
					foreach (RoomTypeMustHave item2 in roleLevel.OwnRoomRequiredFurniture)
					{
						StringBuilder stringBuilder3 = new StringBuilder();
						foreach (string item3 in item2.Content)
						{
							stringBuilder3.AppendJoin(",", UiUtils.GetLocalizedAlmanacLink(RoomUtils.GetItemLocName(item3)));
						}
						stringBuilder2.AppendJoin(",", TextFormatting.GetFormatedItemCount(item2.MinCount, stringBuilder3.ToString()));
					}
					string text7 = "general_room_furniture_requirements".ToLocalized().ToStyled(TooltipStyles.TooltipAttribute);
					stringBuilder.AppendLine("<indent=6%>" + text7 + "</indent>");
					stringBuilder.AppendLine(string.Format("<indent={0}>{1}</indent>", "9%", stringBuilder2));
				}
				List<StringIntPair> globalRequiredStoredResources = roleLevel.GlobalRequiredStoredResources;
				if (globalRequiredStoredResources != null && globalRequiredStoredResources.Count > 0)
				{
					stringBuilder2.Clear();
					foreach (StringIntPair globalRequiredStoredResource in roleLevel.GlobalRequiredStoredResources)
					{
						Resource byID3 = Repository<ResourceRepository, Resource>.Instance.GetByID(globalRequiredStoredResource.Key);
						if (byID3 == null)
						{
							FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidRoleUtils.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("There is no Resource: ");
								messageBuilder.AppendFormatted(globalRequiredStoredResource.Key);
							}
							Log.Error(messageBuilder);
						}
						else
						{
							stringBuilder2.AppendJoin(",", TextFormatting.GetFormatedItemCount(globalRequiredStoredResource.Value, UiUtils.GetLocalizedAlmanacLink(LocKeyUtils.GetName(byID3.LocKeys))));
						}
					}
					string text8 = "role_global_resources".ToLocalized().ToStyled(TooltipStyles.TooltipAttribute);
					stringBuilder.AppendLine("<indent=6%>" + text8 + "</indent>");
					stringBuilder.AppendLine(string.Format("<indent={0}>{1}</indent>", "9%", stringBuilder2));
				}
				string text9 = "job_preferences".ToLocalized().ToStyled(TooltipStyles.TooltipAttribute);
				stringBuilder.AppendLine("<indent=6%>" + text9 + "</indent>");
				foreach (KeyValuePair<GoalPreferenceLevel, string> item4 in GetPrefLevelNamesLocalized(roleLevel.GoalPreferences))
				{
					if (item4.Key != GoalPreferenceLevel.None && item4.Key != GoalPreferenceLevel.Indifferent)
					{
						stringBuilder.AppendLine("<indent=9%>" + AssetUtils.GetSpriteAsset(item4.Key.ToString().ToLower()) + " " + item4.Value + "</indent>");
					}
				}
			}
			return stringBuilder.ToString();
		}

		public static Dictionary<GoalPreferenceLevel, string> GetPrefLevelNamesLocalized(List<StringIntPair> goalPreferences)
		{
			Dictionary<GoalPreferenceLevel, string> dictionary = new Dictionary<GoalPreferenceLevel, string>();
			foreach (StringIntPair goalPreference in goalPreferences)
			{
				GoalPreference byID = Repository<GoalPreferenceRepository, GoalPreference>.Instance.GetByID(goalPreference.Key);
				GoalPreferenceLevel value = (GoalPreferenceLevel)goalPreference.Value;
				if (value != GoalPreferenceLevel.None && !dictionary.TryAdd(value, GetJobsPerPreferenceLevel(byID)))
				{
					dictionary[value] = dictionary[value] + ", " + GetJobsPerPreferenceLevel(byID);
				}
			}
			return dictionary;
			static string GetJobsPerPreferenceLevel(GoalPreference goalPreference)
			{
				return UiUtils.Localize.GetText(LocKeyUtils.GetName(goalPreference.LocKeys)) ?? "";
			}
		}
	}
}
