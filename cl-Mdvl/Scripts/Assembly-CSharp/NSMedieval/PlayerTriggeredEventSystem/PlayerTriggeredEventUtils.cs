using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Almanac;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Dialogs.Data;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.TimeHelpers;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	public static class PlayerTriggeredEventUtils
	{
		public static bool ShouldAddResource(ResourceSetting resourceSetting, Resource resource)
		{
			string[] allowedSortingGroups = resourceSetting.AllowedSortingGroups;
			if (allowedSortingGroups != null && allowedSortingGroups.Length > 0 && !resourceSetting.AllowedSortingGroups.Any((string sg) => sg.Equals(resource.SortingGroup)))
			{
				return false;
			}
			allowedSortingGroups = resourceSetting.AllowedResources;
			if (allowedSortingGroups != null && allowedSortingGroups.Length > 0 && !resourceSetting.AllowedResources.Any((string allowedId) => allowedId.Equals(resource.GetID())))
			{
				return false;
			}
			if (MonoSingleton<ResourcePileManager>.Instance.GetStoredBlueprintAmount(resource) <= 0)
			{
				return false;
			}
			return true;
		}

		public static bool GetEligibleUniqueResources(ResourceSetting resourceSetting, out List<Resource> eligibleResources)
		{
			eligibleResources = new List<Resource>();
			string[] allowedSortingGroups = resourceSetting.AllowedSortingGroups;
			if (allowedSortingGroups == null || allowedSortingGroups.Length <= 0)
			{
				return false;
			}
			List<Resource> list = new List<Resource>();
			allowedSortingGroups = resourceSetting.AllowedSortingGroups;
			foreach (string groupId in allowedSortingGroups)
			{
				list.AddRange(Repository<ResourceRepository, Resource>.Instance.GetAllResourcesBySortingGroup(groupId));
			}
			foreach (Resource item in list)
			{
				if (MonoSingleton<ResourcePileManager>.Instance.GetStoredBlueprintAmount(item) > 0)
				{
					eligibleResources.Add(item);
				}
			}
			return eligibleResources.Count > 0;
		}

		public static string GetUniqueResourceGroupTitleLocalized(PlayerTriggeredEventInstance eventInstance, string groupId)
		{
			ResourceSetting[] uniqueResourceSettings = eventInstance.Blueprint.UniqueResourceSettings;
			foreach (ResourceSetting resourceSetting in uniqueResourceSettings)
			{
				if (resourceSetting.GetID().Equals(groupId))
				{
					return LocKeyUtils.GetName(resourceSetting.LocKeys).ToLocalized();
				}
			}
			return string.Empty;
		}

		public static bool GetEligibleAttendees(PlayerTriggeredEventInstance eventInstance, EventAttendeeType type, out List<IEventParticipant> eligibleParticipants)
		{
			eligibleParticipants = new List<IEventParticipant>();
			switch (type)
			{
			case EventAttendeeType.Participant:
			case EventAttendeeType.MeleeParticipant:
			case EventAttendeeType.RangedParticipant:
				FillListParticipants(eligibleParticipants, eventInstance);
				break;
			case EventAttendeeType.AnimalParticipant:
				FillListAnimals(eligibleParticipants, eventInstance);
				break;
			case EventAttendeeType.RoleParticipant:
				FillListRoles(eligibleParticipants, eventInstance);
				break;
			case EventAttendeeType.PrisonerParticipant:
				FillListPrisoners(eligibleParticipants, eventInstance);
				break;
			}
			return eligibleParticipants.Count > 0;
		}

		private static void FillListPrisoners(List<IEventParticipant> eligibleParticipants, PlayerTriggeredEventInstance eventInstance)
		{
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				if (!item.HasDied && !item.HasDisposed && !item.IsLeaving && item.ActiveBehaviour is PrisonerBehaviour { IsPlayerVillagePrisoner: not false })
				{
					eligibleParticipants.Add(item);
				}
			}
		}

		private static void FillListAnimals(List<IEventParticipant> eligibleParticipants, PlayerTriggeredEventInstance eventInstance)
		{
			foreach (AnimalInstance key in MonoSingleton<AnimalManager>.Instance.Animals.Keys)
			{
				if (key.HasDied || key.HasDisposed)
				{
					continue;
				}
				AnimalSetting[] animalSettings = eventInstance.Blueprint.AnimalSettings;
				foreach (AnimalSetting animalSetting in animalSettings)
				{
					if (key.AnimalType == animalSetting.AnimalType)
					{
						eligibleParticipants.Add(key);
					}
				}
			}
		}

		private static void FillListRoles(List<IEventParticipant> eligibleParticipants, PlayerTriggeredEventInstance eventInstance)
		{
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (!key.HasDied && !key.HasDisposed && key.WorkerBehaviour.HumanoidRoleOwner.HasRole(eventInstance.Blueprint.RoleId))
				{
					eligibleParticipants.Add(key);
				}
			}
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				if (!item.HasDied && !item.HasDisposed && !item.IsLeaving && item.ActiveBehaviour.HumanoidRoleOwner.HasRole(eventInstance.Blueprint.RoleId))
				{
					eligibleParticipants.Add(item);
				}
			}
		}

		private static void FillListParticipants(List<IEventParticipant> eligibleParticipants, PlayerTriggeredEventInstance eventInstance)
		{
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (!key.HasDied && !key.HasDisposed && !eventInstance.IsAlreadyParticipating(key))
				{
					eligibleParticipants.Add(key);
				}
			}
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				if (item.HasDied || item.HasDisposed || item.IsLeaving || item.IsEnemy() || item.IsCaptive() || item.IsPrisoner() || item.ActiveBehaviour is BlankBehaviour || item.ActiveBehaviour is INegotiator || IsPrisonersTrader(item))
				{
					continue;
				}
				if (item.IsTraderBodyguard())
				{
					HumanoidInstance state = item.CombatAi.GetState<HumanoidInstance>(CombatAiState.FollowTarget);
					if (state != null && IsPrisonersTrader(state))
					{
						continue;
					}
				}
				if (!eventInstance.AttendeesByType[EventAttendeeType.RoleParticipant].Contains(item))
				{
					eligibleParticipants.Add(item);
				}
			}
			static bool IsPrisonersTrader(HumanoidInstance npcInstance)
			{
				if (npcInstance.ActiveBehaviour is TraderBehaviour traderBehaviour)
				{
					return traderBehaviour.TraderType.GetID() == "trader_prisoners";
				}
				return false;
			}
		}

		public static NewsData GetEventEndNewsData(PlayerTriggeredEventInstance eventInstance)
		{
			string message = UiUtils.Localize.GetText(LocKeyUtils.GetName(eventInstance.Blueprint.LocKeys)) + ": " + UiUtils.Localize.GetText(LocKeyUtils.GetName(eventInstance.GetOutcome().LocKeys));
			string imagePath = eventInstance.GetOutcome().ImagePath;
			string text = string.Empty;
			if (LocKeyUtils.GetTooltipLines(eventInstance.GetOutcome().LocKeys, out var lines))
			{
				text = lines.Aggregate(text, (string current, string line) => current + UiUtils.Localize.GetText(line) + "\n");
			}
			TimeInterval? activeTimeInterval = ((eventInstance.DefaultDurationHours == 0) ? ((TimeInterval?)null) : new TimeInterval?(TimeInterval.FromNowHours(eventInstance.DefaultDurationHours)));
			DialogContent dialogContent = BuildDialogContent(eventInstance);
			return new NewsData(message, imagePath, text, dialogContent, activeTimeInterval);
		}

		private static DialogContent BuildDialogContent(PlayerTriggeredEventInstance eventInstance, int dialogIndex = 0)
		{
			DialogContent dialogContent = new DialogContent();
			GameEvent.DialogContent dialogContent2 = eventInstance.GetDialogContent(dialogIndex);
			dialogContent.Options = new List<DialogOption>();
			int num = 0;
			foreach (string option in dialogContent2.Options)
			{
				DialogOption dialogOption = new DialogOption();
				int num2 = num;
				string text = MonoSingleton<LocalizationController>.Instance.GetText(option);
				text = TextFormatting.FormatText(text);
				dialogOption.Text = text;
				List<EventEffectsList> optionEffects = dialogContent2.OptionEffects;
				if (optionEffects != null && optionEffects.Count > num2)
				{
					dialogOption.Tooltips = BuildTooltips(eventInstance, dialogContent2.OptionEffects[num2]);
				}
				dialogContent.Options.Add(dialogOption);
				num++;
			}
			dialogContent.WindowTitle = eventInstance.GetEventTitle(dialogContent2);
			dialogContent.ContentBodyImagePath = eventInstance.GetEventImagePath(dialogContent2);
			dialogContent.ContentTitle = eventInstance.GetEventName(dialogContent2);
			dialogContent.ContentBodyText = eventInstance.GetEventInfo(dialogContent2);
			dialogContent.ShowCloseButton = dialogContent2.ShowCloseButton;
			return dialogContent;
		}

		private static List<TooltipData> BuildTooltips(PlayerTriggeredEventInstance eventInstance, EventEffectsList effects)
		{
			List<TooltipData> list = new List<TooltipData>();
			foreach (GameEventOptionEffect item in effects.Items)
			{
				if (item != GameEventOptionEffect.None)
				{
					TooltipData tooltipData = new TooltipData();
					tooltipData.Key = item.ToString();
					tooltipData.Args = new List<string>();
					list.Add(tooltipData);
				}
			}
			return list;
		}

		public static string GetAttendeeGroupTitle(EventAttendeeType type)
		{
			return type switch
			{
				EventAttendeeType.Participant => UiUtils.Localize.GetText("event_quality_participants_name"), 
				EventAttendeeType.RoleParticipant => GetEventRoleName(), 
				EventAttendeeType.AnimalParticipant => UiUtils.Localize.GetText("menu_animals"), 
				EventAttendeeType.PrisonerParticipant => UiUtils.Localize.GetText("general_prisoner"), 
				EventAttendeeType.MeleeParticipant => UiUtils.Localize.GetText("event_quality_melee_name"), 
				EventAttendeeType.RangedParticipant => UiUtils.Localize.GetText("event_quality_ranged_name"), 
				_ => string.Empty, 
			};
		}

		public static string GetAddAttendeeTooltipTitle(EventAttendeeType type)
		{
			return type switch
			{
				EventAttendeeType.Participant => UiUtils.Localize.GetText("event_quality_participants_name"), 
				EventAttendeeType.RoleParticipant => MonoSingleton<LocalizationController>.Instance.GetText("general_add") + " " + GetEventRoleName(), 
				EventAttendeeType.AnimalParticipant => MonoSingleton<LocalizationController>.Instance.GetText("general_add") + " " + MonoSingleton<LocalizationController>.Instance.GetText("menu_animals"), 
				_ => string.Empty, 
			};
		}

		private static string GetEventRoleName()
		{
			if (!MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				return string.Empty;
			}
			return HumanoidRoleUtils.GetRoleName(MonoSingleton<PlayerTriggeredEventManager>.Instance.EventToStart.Blueprint.RoleId);
		}

		public static string GetLocalizedName(PlayerTriggeredEvent pte)
		{
			return LocKeyUtils.GetName(pte.LocKeys).ToLocalized();
		}

		public static string GetLocalizedInfo(PlayerTriggeredEvent pte)
		{
			return LocKeyUtils.GetInfo(pte.LocKeys).ToLocalized().FormatVillage();
		}

		public static string GetAlmanacEntries(PlayerTriggeredEvent pte)
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<string> list = new List<string>();
			stringBuilder.AppendLine(GetLocalizedInfo(pte).ToStyled(TooltipStyles.TooltipDescriptionLine));
			stringBuilder.AppendLine();
			string arg = "player_triggered_event_duration".ToLocalized();
			stringBuilder.AppendLine(string.Format("{0}: {1} {2}", arg, pte.EventDurationHours, "general_hour_short".ToLocalized()).ToStyled(TooltipStyles.TooltipAttribute));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(LocKeyUtils.GetDescription(pte.LocKeys).ToLocalized().ToStyled(TooltipStyles.TooltipAttribute) ?? "");
			string[] buildingIds = pte.BuildingIds;
			bool isEnabled;
			foreach (string text in buildingIds)
			{
				BaseBuildingBlueprint byID = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(text);
				if (byID == null)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventUtils.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Building ");
						messageBuilder.AppendFormatted(text);
						messageBuilder.AppendLiteral(" not found");
					}
					Log.Error(messageBuilder);
				}
				else
				{
					list.Add(LocKeyUtils.GetName(byID.LocKeys));
				}
			}
			stringBuilder.AppendLine();
			string text2 = "pte_host_buildings".ToLocalized();
			stringBuilder.AppendLine((text2 + ": " + UiUtils.GetLocalizedAlmanacLinks(list)).ToStyled(TooltipStyles.TooltipAttribute));
			if (pte.RoomRequired)
			{
				list.Clear();
				buildingIds = pte.RoomTypeIds;
				foreach (string text3 in buildingIds)
				{
					RoomType byID2 = Repository<RoomTypeRepository, RoomType>.Instance.GetByID(text3);
					if (byID2 == null)
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventUtils.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Room ");
							messageBuilder.AppendFormatted(text3);
							messageBuilder.AppendLiteral(" not found");
						}
						Log.Error(messageBuilder);
					}
					else
					{
						list.Add(LocKeyUtils.GetName(byID2.LocKeys));
					}
				}
				stringBuilder.AppendLine();
				string text4 = "pte_needs_rooms".ToLocalized();
				stringBuilder.AppendLine((text4 + ": " + UiUtils.GetLocalizedAlmanacLinks(list)).ToStyled(TooltipStyles.TooltipAttribute));
			}
			if (!string.IsNullOrEmpty(pte.RoleId))
			{
				foreach (Role allItem in Repository<RoleRepository, Role>.Instance.GetAllItems())
				{
					if (!(allItem.GetID() != pte.RoleId))
					{
						stringBuilder.AppendLine();
						string text5 = "can_have_role".ToLocalized();
						stringBuilder.AppendLine((text5 + ": " + UiUtils.GetLocalizedAlmanacLink(LocKeyUtils.GetName(allItem.LocKeys))).ToStyled(TooltipStyles.TooltipAttribute));
						break;
					}
				}
			}
			ResourceSetting[] resourceSettings = pte.ResourceSettings;
			if (resourceSettings != null && resourceSettings.Length > 0)
			{
				stringBuilder.AppendLine();
				resourceSettings = pte.ResourceSettings;
				foreach (ResourceSetting resourceSetting in resourceSettings)
				{
					list.Clear();
					string text6 = LocKeyUtils.GetName(resourceSetting.LocKeys).ToLocalized();
					buildingIds = resourceSetting.AllowedResources;
					if (buildingIds != null && buildingIds.Length > 0)
					{
						buildingIds = resourceSetting.AllowedResources;
						foreach (string text7 in buildingIds)
						{
							Resource byID3 = Repository<ResourceRepository, Resource>.Instance.GetByID(text7);
							if (byID3 == null)
							{
								FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventUtils.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Resource ");
									messageBuilder.AppendFormatted(text7);
									messageBuilder.AppendLiteral(" not found");
								}
								Log.Error(messageBuilder);
							}
							else
							{
								list.Add(LocKeyUtils.GetName(byID3.LocKeys));
							}
						}
						stringBuilder.AppendLine((text6 + ": " + UiUtils.GetLocalizedAlmanacLinks(list)).ToStyled(TooltipStyles.TooltipAttribute));
					}
					else if (resourceSetting.ResourceCategory != ResourceCategory.None)
					{
						stringBuilder.AppendLine((text6 + ": " + $"resource_category_name_{resourceSetting.ResourceCategory}".ToLocalized(TooltipStyles.TooltipAttribute)).ToStyled(TooltipStyles.TooltipAttribute));
					}
				}
			}
			resourceSettings = pte.UniqueResourceSettings;
			if (resourceSettings != null && resourceSettings.Length > 0)
			{
				list.Clear();
				stringBuilder.AppendLine();
				resourceSettings = pte.UniqueResourceSettings;
				foreach (ResourceSetting obj in resourceSettings)
				{
					string text8 = LocKeyUtils.GetName(obj.LocKeys).ToLocalized();
					buildingIds = obj.AllowedSortingGroups;
					foreach (string text9 in buildingIds)
					{
						Links byID4 = Repository<LinkRepository, Links>.Instance.GetByID(text9);
						if (byID4 == null)
						{
							FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventUtils.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("Group ");
								messageBuilder.AppendFormatted(text9);
								messageBuilder.AppendLiteral(" not found");
							}
							Log.Error(messageBuilder);
						}
						else
						{
							list.Add(byID4.LinkKeys.FirstOrDefault());
						}
					}
					stringBuilder.AppendLine((text8 + ": " + UiUtils.GetLocalizedAlmanacLinks(list)).ToStyled(TooltipStyles.TooltipAttribute));
				}
			}
			return stringBuilder.ToString();
		}
	}
}
