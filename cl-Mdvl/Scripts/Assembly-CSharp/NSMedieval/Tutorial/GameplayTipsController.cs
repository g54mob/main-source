using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.GlobalStats;
using NSMedieval.InfoMessages;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.Resources;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.View;
using NSMedieval.View.Animals;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class GameplayTipsController : MonoController<GameplayTipsController>
	{
		private const float GeneralDelay = 0.3f;

		private List<GameplayTipsSchedule> scheduleList;

		private void Start()
		{
			scheduleList = GlobalSaveController.CurrentVillageData.GameplayTipsSchedule;
			foreach (GameplayTipsSchedule schedule25 in scheduleList)
			{
				if (schedule25.SkipIfTutorialCompleted && MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TutorialComplete)
				{
					schedule25.SetTipShown();
				}
			}
			GameplayTipsSchedule schedule = GetSchedule("JobGameplayTips");
			if (schedule == null || schedule.IsShown)
			{
				GameplayTipsSchedule schedule2 = GetSchedule("ScheduleGameplayTips");
				if (schedule2 == null || schedule2.IsShown)
				{
					GameplayTipsSchedule schedule3 = GetSchedule("ResearchGameplayTips");
					if (schedule3 == null || schedule3.IsShown)
					{
						GameplayTipsSchedule schedule4 = GetSchedule("AnimalsTutorial");
						if (schedule4 == null || schedule4.IsShown)
						{
							GameplayTipsSchedule schedule5 = GetSchedule("RegionGameplayTips");
							if (schedule5 == null || schedule5.IsShown)
							{
								goto IL_00f1;
							}
						}
					}
				}
			}
			MonoSingleton<SceneUIManager>.Instance.OnPanelOpenEvent += OnPanelOpen;
			goto IL_00f1;
			IL_00f1:
			GameplayTipsSchedule schedule6 = GetSchedule("ProductionGameplayTips");
			if (schedule6 != null && !schedule6.IsShown)
			{
				MonoSingleton<SceneUIManager>.Instance.OnProductionPanelOpenEvent += OnProductionPanelOpen;
			}
			GameplayTipsSchedule schedule7 = GetSchedule("MoveStructuresGameplayTips");
			if (schedule7 == null || schedule7.IsShown)
			{
				GameplayTipsSchedule schedule8 = GetSchedule("AnimalsTameGameplayTips ");
				if (schedule8 == null || schedule8.IsShown)
				{
					GameplayTipsSchedule schedule9 = GetSchedule("AnimalsWildGameplayTips");
					if (schedule9 == null || schedule9.IsShown)
					{
						GameplayTipsSchedule schedule10 = GetSchedule("AnimalsDomesticGameplayTips");
						if (schedule10 == null || schedule10.IsShown)
						{
							GameplayTipsSchedule schedule11 = GetSchedule("AnimalsPetGameplayTips");
							if (schedule11 == null || schedule11.IsShown)
							{
								GameplayTipsSchedule schedule12 = GetSchedule("MeshVariationsGameplayTips");
								if (schedule12 == null || schedule12.IsShown)
								{
									goto IL_01cc;
								}
							}
						}
					}
				}
			}
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelect;
			goto IL_01cc;
			IL_027c:
			GameplayTipsSchedule schedule13 = GetSchedule("FriendlinessGameplayTips");
			if (schedule13 != null && !schedule13.IsShown)
			{
				MonoSingleton<FactionsController>.Instance.FriendlinessChangedByAmountEvent += OnFriendlinessChanged;
			}
			GameplayTipsSchedule schedule14 = GetSchedule("RoomTypeGameplayTips");
			if (schedule14 != null && !schedule14.IsShown)
			{
				MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent += OnRoomAdded;
			}
			GameplayTipsSchedule schedule15 = GetSchedule("PlayerTriggeredEventsGameplayTips");
			if (schedule15 != null && !schedule15.IsShown)
			{
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent += OnConstructionCompleted;
			}
			GameplayTipsSchedule schedule16 = GetSchedule("RolesGameplayTips");
			if (schedule16 != null && !schedule16.IsShown)
			{
				MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent += OnQuarterHourUpdate;
			}
			GameplayTipsSchedule schedule17 = GetSchedule("StabilityGameplayTips");
			if (schedule17 != null && !schedule17.IsShown)
			{
				MonoSingleton<BuildingPlacementManager>.Instance.StabilityBuildingRemovedEvent += OnStabilityBuildingRemoved;
			}
			GameplayTipsSchedule schedule18 = GetSchedule("TemperatureGameplayTips");
			if (schedule18 != null && !schedule18.IsShown)
			{
				MonoSingleton<WorldTimeManager>.Instance.SeasonUpdateEvent += OnSeasonChange;
			}
			GameplayTipsSchedule schedule19 = GetSchedule("RotGameplayTips");
			if (schedule19 != null && !schedule19.IsShown)
			{
				MonoSingleton<ResourcePileController>.Instance.PileRottenEvent += OnResourcePileRotten;
			}
			GameplayTipsSchedule schedule20 = GetSchedule("RenownGameplayTips");
			if (schedule20 != null && !schedule20.IsShown)
			{
				MonoSingleton<GlobalStatController>.Instance.GlobalStatTriggerActivatedEvent += OnGlobalObjectiveActivated;
			}
			return;
			IL_01cc:
			GameplayTipsSchedule schedule21 = GetSchedule("LayerControlGameplayTips");
			if (schedule21 != null && !schedule21.IsShown)
			{
				MonoSingleton<SelectionManager>.Instance.AssignOrderEvent += OnOrderAssigned;
			}
			GameplayTipsSchedule schedule22 = GetSchedule("FarmingGameplayTips");
			if (schedule22 != null && !schedule22.IsShown)
			{
				MonoSingleton<ResearchController>.Instance.ActivateResearchEvent += OnResearchUnlocked;
			}
			GameplayTipsSchedule schedule23 = GetSchedule("InitiateTradeGameplayTips");
			if (schedule23 == null || schedule23.IsShown)
			{
				GameplayTipsSchedule schedule24 = GetSchedule("TradeGameplayTips");
				if (schedule24 == null || schedule24.IsShown)
				{
					goto IL_027c;
				}
			}
			TraderEvent.EventStart = (Action)Delegate.Combine(TraderEvent.EventStart, new Action(OnTraderEventStart));
			goto IL_027c;
		}

		private void OnGlobalObjectiveActivated(GlobalStatInstance globalStatInstance, GlobalStatTrigger globalStatTrigger)
		{
			GameplayTipsSchedule schedule = GetSchedule("RenownGameplayTips");
			if (schedule != null && !schedule.IsShown)
			{
				ShowGameplayTipDelayed("RenownGameplayTips", 0.3f);
				MonoSingleton<GlobalStatController>.Instance.GlobalStatTriggerActivatedEvent -= OnGlobalObjectiveActivated;
			}
		}

		private void OnEnable()
		{
			MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent += OnTimeUpdate;
			if (GlobalSaveController.CurrentVillageData.Raids.Count == 0)
			{
				MonoSingleton<RaidController>.Instance.RaidSpawnedEvent += OnRaidStart;
			}
		}

		private void OnDisable()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent -= OnTimeUpdate;
			}
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.RaidSpawnedEvent -= OnRaidStart;
			}
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<SceneUIManager>.IsInstantiated())
			{
				MonoSingleton<SceneUIManager>.Instance.OnPanelOpenEvent -= OnPanelOpen;
				MonoSingleton<SceneUIManager>.Instance.OnProductionPanelOpenEvent -= OnProductionPanelOpen;
			}
			TraderEvent.EventStart = (Action)Delegate.Remove(TraderEvent.EventStart, new Action(OnTraderEventStart));
			if (MonoSingleton<ResearchController>.IsInstantiated())
			{
				MonoSingleton<ResearchController>.Instance.ActivateResearchEvent -= OnResearchUnlocked;
			}
			base.OnDestroy();
			scheduleList.Clear();
		}

		private void OnSelect(SelectableObject selectableObject)
		{
			if (!selectableObject)
			{
				return;
			}
			if (!(selectableObject is BaseBuildingViewComponent baseBuildingViewComponent))
			{
				if (selectableObject is AnimalView { AnimalInstance: var animalInstance })
				{
					if (animalInstance == null)
					{
						return;
					}
					switch (animalInstance.AnimalType)
					{
					case AnimalType.Domestic:
					case AnimalType.DomesticNpc:
					{
						GameplayTipsSchedule schedule3 = GetSchedule("AnimalsDomesticGameplayTips");
						if (schedule3 != null && !schedule3.IsShown)
						{
							ShowGameplayTipDelayed("AnimalsDomesticGameplayTips", 1f);
						}
						GameplayTipsSchedule schedule4 = GetSchedule("AnimalsPetGameplayTips");
						if (schedule4 != null && !schedule4.IsShown)
						{
							ShowGameplayTipDelayed("AnimalsPetGameplayTips", 3f);
						}
						break;
					}
					case AnimalType.Wild:
					case AnimalType.WildAggressive:
					{
						GameplayTipsSchedule schedule = GetSchedule("AnimalsWildGameplayTips");
						if (schedule != null && !schedule.IsShown)
						{
							ShowGameplayTipDelayed("AnimalsWildGameplayTips", 1f);
						}
						GameplayTipsSchedule schedule2 = GetSchedule("AnimalsTameGameplayTips");
						if (schedule2 != null && !schedule2.IsShown)
						{
							ShowGameplayTipDelayed("AnimalsTameGameplayTips", 3f);
						}
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
					case AnimalType.Pet:
						break;
					}
				}
			}
			else
			{
				if (baseBuildingViewComponent.BaseBuildingInstance.Blueprint.CanBeMoved)
				{
					GameplayTipsSchedule schedule5 = GetSchedule("MoveStructuresGameplayTips");
					if (schedule5 != null && !schedule5.IsShown)
					{
						ShowGameplayTipDelayed("MoveStructuresGameplayTips", 1f);
					}
				}
				if (baseBuildingViewComponent.BaseBuildingInstance.Blueprint.ShowVariations)
				{
					GameplayTipsSchedule schedule6 = GetSchedule("MeshVariationsGameplayTips");
					if (schedule6 != null && !schedule6.IsShown)
					{
						ShowGameplayTipDelayed("MeshVariationsGameplayTips", 1f);
					}
				}
			}
			GameplayTipsSchedule schedule7 = GetSchedule("MoveStructuresGameplayTips");
			if (schedule7 != null && !schedule7.IsShown)
			{
				return;
			}
			GameplayTipsSchedule schedule8 = GetSchedule("AnimalsTameGameplayTips");
			if (schedule8 != null && !schedule8.IsShown)
			{
				return;
			}
			GameplayTipsSchedule schedule9 = GetSchedule("AnimalsWildGameplayTips");
			if (schedule9 != null && !schedule9.IsShown)
			{
				return;
			}
			GameplayTipsSchedule schedule10 = GetSchedule("AnimalsDomesticGameplayTips");
			if (schedule10 == null || schedule10.IsShown)
			{
				GameplayTipsSchedule schedule11 = GetSchedule("AnimalsPetGameplayTips");
				if (schedule11 == null || schedule11.IsShown)
				{
					MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelect;
				}
			}
		}

		private void OnOrderAssigned(OrderType orderType, AreaType arg2)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Order assigned: ");
				messageBuilder.AppendFormatted(orderType);
			}
			Log.Debug(messageBuilder);
			if (orderType == OrderType.Digging)
			{
				MonoSingleton<SelectionManager>.Instance.AssignOrderEvent -= OnOrderAssigned;
				GameplayTipsSchedule schedule = GetSchedule("LayerControlGameplayTips");
				if (schedule != null && !schedule.IsShown)
				{
					ShowGameplayTipDelayed("LayerControlGameplayTips", 0.3f);
				}
			}
		}

		private void OnFriendlinessChanged(float amount, FactionInstance factionInstance)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Friendliness changed for ");
				messageBuilder.AppendFormatted(factionInstance);
				messageBuilder.AppendLiteral(" by ");
				messageBuilder.AppendFormatted(amount);
				messageBuilder.AppendLiteral(" ");
			}
			Log.Trace(messageBuilder);
			GameplayTipsSchedule schedule = GetSchedule("FriendlinessGameplayTips");
			if (schedule != null && !schedule.IsShown)
			{
				ShowGameplayTipDelayed("FriendlinessGameplayTips", 1f);
				MonoSingleton<FactionsController>.Instance.FriendlinessChangedByAmountEvent -= OnFriendlinessChanged;
			}
		}

		private void OnRoomAdded(Room room, RoomType roomType)
		{
			Log.Trace("Room created", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
			GameplayTipsSchedule schedule = GetSchedule("RoomTypeGameplayTips");
			if (schedule != null && !schedule.IsShown)
			{
				ShowGameplayTipDelayed("RoomTypeGameplayTips", 1f);
				MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent -= OnRoomAdded;
			}
		}

		private void OnConstructionCompleted(BaseBuildingInstance buildingInstance)
		{
			Log.Trace("Construction completed", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
			GameplayTipsSchedule schedule = GetSchedule("PlayerTriggeredEventsGameplayTips");
			if (schedule == null || schedule.IsShown)
			{
				return;
			}
			foreach (PlayerTriggeredEvent allItem in Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetAllItems())
			{
				if (allItem.BuildingIds.Contains(buildingInstance.Blueprint.GetID()))
				{
					ShowGameplayTipDelayed("PlayerTriggeredEventsGameplayTips", 1f);
					MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent -= OnConstructionCompleted;
				}
			}
		}

		private void OnQuarterHourUpdate()
		{
			GameplayTipsSchedule schedule = GetSchedule("RolesGameplayTips");
			if (schedule != null && !schedule.IsShown && MonoSingleton<GlobalSaveController>.IsInstantiated() && GlobalSaveController.CurrentVillageData != null)
			{
				if (!MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.Where((HumanoidInstance workerInstance) => Repository<RoleRepository, Role>.Instance.GetAllItems().Any(workerInstance.WorkerBehaviour.HumanoidRoleOwner.CanRoleBeLeveledUp)).Any())
				{
					Log.Trace("No ROLE assignable workers found", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
					return;
				}
				ShowGameplayTipDelayed("RolesGameplayTips", 0.3f);
				MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent -= OnQuarterHourUpdate;
			}
		}

		private void OnStabilityBuildingRemoved()
		{
			GameplayTipsSchedule schedule = GetSchedule("StabilityGameplayTips");
			if (schedule != null && !schedule.IsShown)
			{
				ShowGameplayTipDelayed("StabilityGameplayTips", 0.3f);
				MonoSingleton<BuildingPlacementManager>.Instance.StabilityBuildingRemovedEvent -= OnStabilityBuildingRemoved;
			}
		}

		private void OnSeasonChange()
		{
			GameplayTipsSchedule schedule = GetSchedule("TemperatureGameplayTips");
			if (schedule != null && !schedule.IsShown)
			{
				Season season = GlobalSaveController.CurrentVillageData.DateAndTime.Season;
				if (!(season.Name != "summer") || !(season.Name != "winter"))
				{
					ShowGameplayTipDelayed("TemperatureGameplayTips", 0.3f);
					MonoSingleton<WorldTimeManager>.Instance.SeasonUpdateEvent -= OnSeasonChange;
				}
			}
		}

		private void OnResourcePileRotten(ResourcePileInstance resourcePileInstance)
		{
			Debug.Log("OnResourcePileRotten " + resourcePileInstance.Blueprint.GetID());
			GameplayTipsSchedule schedule = GetSchedule("RotGameplayTips");
			if (schedule != null && !schedule.IsShown)
			{
				ShowGameplayTipDelayed("RotGameplayTips", 0.3f);
				MonoSingleton<ResourcePileController>.Instance.PileRottenEvent -= OnResourcePileRotten;
			}
		}

		private void OnRaidStart(ActiveRaidInfo info, List<HumanoidInstance> enemies)
		{
			GameplayTipsSchedule schedule = GetSchedule("DraftingCombatGameplayTips");
			if (schedule != null && !schedule.IsShown)
			{
				ShowGameplayTipDelayed("DraftingCombatGameplayTips", 1f);
			}
			GameplayTipsSchedule schedule2 = GetSchedule("MoveCombatGameplayTips");
			if (schedule2 != null && !schedule2.IsShown)
			{
				ShowGameplayTipDelayed("MoveCombatGameplayTips", 3f);
			}
			MonoSingleton<RaidController>.Instance.RaidSpawnedEvent -= OnRaidStart;
		}

		private void OnTraderEventStart()
		{
			GameplayTipsSchedule schedule = GetSchedule("InitiateTradeGameplayTips");
			if (schedule != null && !schedule.IsShown)
			{
				ShowGameplayTipDelayed("InitiateTradeGameplayTips", 0.3f);
			}
			GameplayTipsSchedule schedule2 = GetSchedule("TradeGameplayTips");
			if (schedule2 != null && !schedule2.IsShown)
			{
				ShowGameplayTipDelayed("TradeGameplayTips", 0.6f);
			}
			TraderEvent.EventStart = (Action)Delegate.Remove(TraderEvent.EventStart, new Action(OnTraderEventStart));
		}

		private void OnProductionPanelOpen()
		{
			GameplayTipsSchedule schedule = GetSchedule("ProductionGameplayTips");
			if (schedule != null && !schedule.IsShown)
			{
				ShowGameplayTipDelayed("ProductionGameplayTips", 0.3f);
				if (MonoSingleton<SceneUIManager>.IsInstantiated())
				{
					MonoSingleton<SceneUIManager>.Instance.OnProductionPanelOpenEvent -= OnProductionPanelOpen;
				}
			}
		}

		private void OnResearchUnlocked(ResearchNodeInstance node, bool afterLoading = false, bool forceUnlock = false)
		{
			if (node.Blueprint.GetID().Equals("agriculture_lvl1"))
			{
				ShowTutorialMessage("FarmingGameplayTips");
				MonoSingleton<ResearchController>.Instance.ActivateResearchEvent -= OnResearchUnlocked;
			}
		}

		private void OnTimeUpdate()
		{
			if (scheduleList == null || scheduleList.Count == 0)
			{
				return;
			}
			float num = 3f;
			foreach (GameplayTipsSchedule schedule in scheduleList)
			{
				if (!schedule.IsShown && schedule.DisplayHour > 0 && schedule.DisplayHour <= GlobalSaveController.CurrentVillageData.DateAndTime.HoursTotalZero + 1)
				{
					ShowGameplayTipDelayed(schedule.TipNotificationId, num);
					num += 1f;
				}
			}
		}

		private void OnPanelOpen(string panelName)
		{
			switch (panelName)
			{
			case "JobPanelManager":
			{
				GameplayTipsSchedule schedule5 = GetSchedule("JobGameplayTips");
				if (schedule5 != null && !schedule5.IsShown)
				{
					ShowGameplayTipDelayed("JobGameplayTips", 0.3f);
				}
				break;
			}
			case "SchedulePanelManager":
			{
				GameplayTipsSchedule schedule3 = GetSchedule("ScheduleGameplayTips");
				if (schedule3 != null && !schedule3.IsShown)
				{
					ShowGameplayTipDelayed("ScheduleGameplayTips", 0.3f);
				}
				break;
			}
			case "ResearchPanelManager":
			{
				GameplayTipsSchedule schedule6 = GetSchedule("ResearchGameplayTips");
				if (schedule6 != null && !schedule6.IsShown)
				{
					ShowGameplayTipDelayed("ResearchGameplayTips", 0.3f);
				}
				break;
			}
			case "ManagePanelManager":
			{
				GameplayTipsSchedule schedule2 = GetSchedule("ManageGameplayTips");
				if (schedule2 != null && !schedule2.IsShown)
				{
					ShowGameplayTipDelayed("ManageGameplayTips", 0.3f);
				}
				break;
			}
			case "AnimalPanelManager":
			{
				GameplayTipsSchedule schedule4 = GetSchedule("AnimalsTutorial");
				if (schedule4 != null && !schedule4.IsShown)
				{
					ShowGameplayTipDelayed("AnimalsTutorial", 0.3f);
				}
				break;
			}
			case "WorldMap":
			{
				GameplayTipsSchedule schedule = GetSchedule("RegionGameplayTips");
				if (schedule != null && !schedule.IsShown)
				{
					ShowGameplayTipDelayed("RegionGameplayTips", 0.3f);
				}
				break;
			}
			}
			GameplayTipsSchedule schedule7 = GetSchedule("JobGameplayTips");
			if (schedule7 != null && !schedule7.IsShown)
			{
				return;
			}
			GameplayTipsSchedule schedule8 = GetSchedule("ScheduleGameplayTips");
			if (schedule8 != null && !schedule8.IsShown)
			{
				return;
			}
			GameplayTipsSchedule schedule9 = GetSchedule("ResearchGameplayTips");
			if (schedule9 != null && !schedule9.IsShown)
			{
				return;
			}
			GameplayTipsSchedule schedule10 = GetSchedule("AnimalsTutorial");
			if (schedule10 == null || schedule10.IsShown)
			{
				GameplayTipsSchedule schedule11 = GetSchedule("RegionGameplayTips");
				if (schedule11 == null || schedule11.IsShown)
				{
					MonoSingleton<SceneUIManager>.Instance.OnPanelOpenEvent -= OnPanelOpen;
				}
			}
		}

		private void ShowGameplayTipDelayed(string tutorialNotificationId, float waitForSeconds = 0f)
		{
			if (TutorialManager.IsTutorialActive)
			{
				return;
			}
			if (waitForSeconds > 0f)
			{
				MonoSingleton<TaskController>.Instance.WaitForUnscaled(waitForSeconds).Then(delegate
				{
					ShowGameplayTipDelayed(tutorialNotificationId);
				});
			}
			else
			{
				if (MonoSingleton<UIController>.Instance.InGameMenu == null)
				{
					return;
				}
				if (MonoSingleton<UIController>.Instance.InGameMenu.MenuActive)
				{
					MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.2f).Then(delegate
					{
						ShowGameplayTipDelayed(tutorialNotificationId, waitForSeconds);
					});
					return;
				}
				GameplayTipsSchedule schedule = GetSchedule(tutorialNotificationId);
				if (schedule == null || schedule.IsShown)
				{
					return;
				}
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(60, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trying to show gameplay tip schedule: ");
					messageBuilder.AppendFormatted(schedule);
					messageBuilder.AppendLiteral(" with notification id:");
					messageBuilder.AppendFormatted(schedule.TipNotificationId);
				}
				Log.Debug(messageBuilder);
				switch (schedule.TipNotificationId)
				{
				case "StockpileGameplayTips":
					if (VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.Stockpile) > 0)
					{
						Log.Debug("Stockpile found! Skipping.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
						schedule.SetTipShown();
						return;
					}
					break;
				case "ForbidGameplayTips":
					foreach (ResourceInstance startingResource in MonoSingleton<ResourcePileManager>.Instance.StartingResources)
					{
						foreach (ResourcePileInstance spawnedPileInstance in MonoSingleton<ResourcePileManager>.Instance.SpawnedPileInstances)
						{
							if (!(spawnedPileInstance.Blueprint != startingResource.Blueprint) && !spawnedPileInstance.IsForbidden)
							{
								messageBuilder = new FVLogDebugInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Pile: ");
									messageBuilder.AppendFormatted(spawnedPileInstance.Blueprint.GetID());
									messageBuilder.AppendLiteral(" is allowed. Skipping.");
								}
								Log.Debug(messageBuilder);
								schedule.SetTipShown();
								return;
							}
						}
					}
					break;
				case "DefenceGameplayTips":
					foreach (WorldObject worldObject in VillageManager.ActiveVillage.Map.GetWorldObjects(GridDataType.AnyBuildPhase))
					{
						if (worldObject is BaseBuildingInstance baseBuildingInstance && BuildingType.DefensiveStructure.HasFlag(baseBuildingInstance.BuildingType))
						{
							FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
							if (isEnabled)
							{
								messageBuilder2.AppendLiteral("buildingInstance: ");
								messageBuilder2.AppendFormatted(baseBuildingInstance);
								messageBuilder2.AppendLiteral(" is built. Skipping.");
							}
							Log.Trace(messageBuilder2);
							schedule.SetTipShown();
							return;
						}
					}
					break;
				case "EquipmentGameplayTips":
					foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
					{
						if (!worker.HasDied && !worker.HasDisposed && worker.HasWeapon())
						{
							FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
							if (isEnabled)
							{
								messageBuilder2.AppendFormatted(worker);
								messageBuilder2.AppendLiteral(" has weapon. Skipping.");
							}
							Log.Trace(messageBuilder2);
							schedule.SetTipShown();
							return;
						}
					}
					break;
				}
				ShowTutorialMessage(schedule.TipNotificationId);
			}
		}

		private void ShowTutorialMessage(string tutorialNotificationId)
		{
			if (TutorialManager.IsTutorialActive || !MonoSingleton<GlobalSaveController>.IsInstantiated() || !MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.ShowTutorial)
			{
				return;
			}
			GameplayTipsSchedule schedule = GetSchedule(tutorialNotificationId);
			if (schedule != null)
			{
				schedule.SetTipShown();
				GlobalSaveController.CurrentVillageData.SetGameplayTipsSchedule(scheduleList);
				if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.ShowTutorial)
				{
					NotifyAll("OnShowMessage", schedule);
				}
			}
		}

		private GameplayTipsSchedule GetSchedule(string scheduleId)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(14, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("GetSchedule: ");
				messageBuilder.AppendFormatted(scheduleId);
				messageBuilder.AppendLiteral(".");
			}
			Log.Trace(messageBuilder);
			return scheduleList.FirstOrDefault((GameplayTipsSchedule item) => item.TipNotificationId == scheduleId);
		}
	}
}
