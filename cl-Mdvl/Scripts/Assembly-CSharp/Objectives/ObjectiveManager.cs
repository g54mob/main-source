using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Gameplay.Resource;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Objectives;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;

namespace Objectives
{
	public class ObjectiveManager : MonoSingleton<ObjectiveManager>
	{
		[NonSerialized]
		private ObjectiveInstance activeObjective;

		[NonSerialized]
		private VillageMap map;

		[NonSerialized]
		private HashSet<string> resourcesToTrack;

		[NonSerialized]
		private Dictionary<string, HashSet<string>> resourcesToTrackInRooms;

		[NonSerialized]
		private HashSet<string> roomsToTrack;

		[NonSerialized]
		private ObjectiveTaskRequirementType refreshType;

		[NonSerialized]
		private bool gameLoaded;

		public ObjectiveInstance ActiveObjective => activeObjective;

		public void Start()
		{
			resourcesToTrack = new HashSet<string>();
			roomsToTrack = new HashSet<string>();
			resourcesToTrackInRooms = new Dictionary<string, HashSet<string>>();
			map = VillageManager.ActiveVillage.Map;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingCompleted;
			SetActiveObjective(MonoSingleton<WorldMap>.Instance.Data.ActiveObjective);
		}

		public bool IsObjectiveEnabledInScenario(string objectiveId)
		{
			if (objectiveId == null)
			{
				return false;
			}
			return (GlobalSaveController.CurrentVillageData?.Scenario?.AllowedObjectives)?.Contains(objectiveId) ?? false;
		}

		public void SetActiveObjective(ObjectiveInstance objective)
		{
			activeObjective = objective;
			roomsToTrack.Clear();
			resourcesToTrackInRooms.Clear();
			resourcesToTrack.Clear();
			if (activeObjective == null)
			{
				return;
			}
			activeObjective.TurnFactionsIntoPermanentlyHostile();
			ObjectiveTask[] tasks = activeObjective.Blueprint.Tasks;
			foreach (ObjectiveTask objectiveTask in tasks)
			{
				if (objectiveTask.Requirements == null)
				{
					continue;
				}
				ObjectiveTaskRequirement[] requirements = objectiveTask.Requirements;
				foreach (ObjectiveTaskRequirement objectiveTaskRequirement in requirements)
				{
					if ((objectiveTaskRequirement.Type & (ObjectiveTaskRequirementType.HaveRoom | ObjectiveTaskRequirementType.HavePlantInRoom)) != ObjectiveTaskRequirementType.None && !string.IsNullOrEmpty(objectiveTaskRequirement.RoomType))
					{
						roomsToTrack.Add(objectiveTaskRequirement.RoomType);
					}
					if ((objectiveTaskRequirement.Type & ObjectiveTaskRequirementType.HaveResource) == 0 || string.IsNullOrEmpty(objectiveTaskRequirement.ModelId) || !(Repository<ResourceRepository, Resource>.Instance.GetByID(objectiveTaskRequirement.ModelId) != null))
					{
						continue;
					}
					if (!string.IsNullOrEmpty(objectiveTaskRequirement.RoomType))
					{
						if (!resourcesToTrackInRooms.ContainsKey(objectiveTaskRequirement.ModelId))
						{
							resourcesToTrackInRooms.Add(objectiveTaskRequirement.ModelId, new HashSet<string>());
						}
						resourcesToTrackInRooms[objectiveTaskRequirement.ModelId].Add(objectiveTaskRequirement.RoomType);
					}
					else
					{
						resourcesToTrack.Add(objectiveTaskRequirement.ModelId);
					}
				}
			}
		}

		protected override void OnDestroy()
		{
			resourcesToTrack.Clear();
			roomsToTrack.Clear();
			resourcesToTrackInRooms.Clear();
			base.OnDestroy();
			map = null;
			if (MonoSingleton<FloraController>.IsInstantiated())
			{
				MonoSingleton<FloraController>.Instance.ChangeLifePhaseEvent -= OnChangeLifePhase;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingCompleted;
			}
			if (MonoSingleton<RoleManager>.IsInstantiated())
			{
				MonoSingleton<RoleManager>.Instance.RoleChangedEvent -= OnRoleChangedEvent;
			}
			if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventEndedEvent -= OnEventEnded;
			}
			if (MonoSingleton<RoomDetectionController>.IsInstantiated())
			{
				MonoSingleton<RoomDetectionController>.Instance.RoomTypeChangedEvent -= OnRoomTypeChanged;
				MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent -= OnRoomAdded;
				MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent -= OnRoomRemoved;
			}
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.DestroyPileEvent -= OnDestroyPile;
				MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent -= OnPileSpawn;
			}
			if (MonoSingleton<GameEventSystemController>.IsInstantiated())
			{
				MonoSingleton<GameEventSystemController>.Instance.NpcArrivedToEventEvent -= OnNpcArrivedToEvent;
				MonoSingleton<GameEventSystemController>.Instance.GameEventEnded -= OnGameEventEnded;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnAfterConstructionCompleted;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnDestroyBuilding;
			}
			if (VillageManager.ActiveVillage?.Map?.SecondMapLeaveManager != null)
			{
				VillageManager.ActiveVillage.Map.SecondMapLeaveManager.OnRaidWonEvent -= OnRaidWon;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (MonoSingleton<WorldMap>.IsInstantiated() && MonoSingleton<WorldMap>.Instance.MarkerManager != null)
			{
				MonoSingleton<WorldMap>.Instance.MarkerManager.MarkerDestroyedEvent -= OnMapMarkerDestroyed;
			}
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				MonoSingleton<CaravanController>.Instance.TradeDealMadeEvent -= OnTradeDealMade;
			}
			if (MonoSingleton<FactionsController>.IsInstantiated())
			{
				MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent -= OnFriendlinessChanged;
			}
		}

		private void Subscribe()
		{
			MonoSingleton<FloraController>.Instance.ChangeLifePhaseEvent += OnChangeLifePhase;
			MonoSingleton<PlayerTriggeredEventManager>.Instance.EventEndedEvent += OnEventEnded;
			MonoSingleton<RoleManager>.Instance.RoleChangedEvent += OnRoleChangedEvent;
			MonoSingleton<RoomDetectionController>.Instance.RoomTypeChangedEvent += OnRoomTypeChanged;
			MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent += OnRoomAdded;
			MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent += OnRoomRemoved;
			MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent += OnPileSpawn;
			MonoSingleton<ResourcePileController>.Instance.DestroyPileEvent += OnDestroyPile;
			VillageManager.ActiveVillage.Map.SecondMapLeaveManager.OnRaidWonEvent += OnRaidWon;
			MonoSingleton<GameEventSystemController>.Instance.NpcArrivedToEventEvent += OnNpcArrivedToEvent;
			MonoSingleton<GameEventSystemController>.Instance.GameEventEnded += OnGameEventEnded;
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnAfterConstructionCompleted;
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnDestroyBuilding;
			MonoSingleton<WorldMap>.Instance.MarkerManager.MarkerDestroyedEvent += OnMapMarkerDestroyed;
			MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent += OnFriendlinessChanged;
			MonoSingleton<CaravanController>.Instance.TradeDealMadeEvent += OnTradeDealMade;
		}

		private void OnFriendlinessChanged(FactionFriendliness friendliness, FactionInstance factionInstance)
		{
			if (friendliness != FactionFriendliness.Hostile && friendliness != FactionFriendliness.PermanentlyHostile)
			{
				return;
			}
			if (MonoSingleton<WorldMap>.Instance.Data.TradeDeals.Contains(factionInstance.BlueprintId))
			{
				MonoSingleton<WorldMap>.Instance.Data.RemoveTradeDeal(factionInstance);
				ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveTradeDeal);
			}
			using PooledList<WorldMapMarkerPlace> pooledList = MonoSingleton<WorldMap>.Instance.Data.Markers.WherePooled(delegate(WorldMapMarkerPlace marker)
			{
				IReadOnlyList<string> mandatoryResourceGroups = marker.MandatoryResourceGroups;
				return mandatoryResourceGroups != null && mandatoryResourceGroups.Count > 0 && marker.FactionInstance.BlueprintId == factionInstance.BlueprintId;
			});
			foreach (WorldMapMarkerPlace item in pooledList)
			{
				MonoSingleton<WorldMap>.Instance.MarkerManager.DestroyMarker(item);
			}
		}

		private void OnTradeDealMade(CaravanInstance caravanInstance, FactionInstance factionInstance)
		{
			ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveTradeDeal);
		}

		private void OnMapMarkerDestroyed(WorldMapMarkerPlace worldMapMarkerPlace)
		{
			if (ActiveObjective != null && !(worldMapMarkerPlace.LinkedObjective != ActiveObjective.BlueprintId))
			{
				TrySpawnBanditCampsForObjective(ActiveObjective);
			}
		}

		public void TrySpawnBanditCampsForObjective(ObjectiveInstance objectiveInstance)
		{
			if (objectiveInstance.Blueprint.BanditCamps == null || objectiveInstance.Blueprint.BanditCamps.Length == 0 || objectiveInstance.Blueprint.BanditCampsSpawnCount <= 0 || objectiveInstance.Blueprint.BanditCampsSpawnCount <= 0)
			{
				return;
			}
			int minutesInHour = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour;
			IntRange durationRangeMinutes = new IntRange(objectiveInstance.Blueprint.BanditCampDurationRangeHours.Min * minutesInHour, objectiveInstance.Blueprint.BanditCampDurationRangeHours.Max * minutesInHour);
			int num = MonoSingleton<WorldMap>.Instance.MarkerManager.AllMarkers.Count((WorldMapMarkerPlace marker) => marker.LinkedObjective == objectiveInstance.BlueprintId);
			int raidsWonForObjective = MonoSingleton<WorldMap>.Instance.Data.GetRaidsWonForObjective(objectiveInstance.BlueprintId);
			int num2 = objectiveInstance.Blueprint.BanditCampsSpawnCount - raidsWonForObjective - num;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(55, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Bandit camps for ");
				messageBuilder.AppendFormatted(objectiveInstance.BlueprintId);
				messageBuilder.AppendLiteral(" - on map: ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(", won: ");
				messageBuilder.AppendFormatted(raidsWonForObjective);
				messageBuilder.AppendLiteral(", need spawn count: ");
				messageBuilder.AppendFormatted(num2);
			}
			Log.Info(messageBuilder);
			using PooledList<string> pooledList = objectiveInstance.Blueprint.BanditCamps.ToPooledListJanitor();
			for (int num3 = 0; num3 < num2; num3++)
			{
				PooledList<string> mapIds = pooledList;
				string blueprintId = objectiveInstance.BlueprintId;
				MapPlaceGenerator.MaybeSpawnBanditCamp(1f, null, durationRangeMinutes, null, mapIds, checkCanSpawn: false, blueprintId, objectiveInstance.Blueprint.BanditCampPrefabAddress);
			}
		}

		private void OnRaidWon()
		{
			if (activeObjective != null && GlobalSaveController.CurrentVillageData.WorldMapPlace is WorldMapMarkerPlace worldMapMarkerPlace && !(worldMapMarkerPlace.LinkedObjective != activeObjective.BlueprintId))
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Won raid - for objective ");
					messageBuilder.AppendFormatted(activeObjective.BlueprintId);
				}
				Log.Info(messageBuilder);
				MonoSingleton<WorldMap>.Instance.Data.IncrementRaidsWonForObjective(activeObjective.BlueprintId);
			}
		}

		private void OnNpcArrivedToEvent(string eventId)
		{
			if (activeObjective != null)
			{
				ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveNpcByEvent);
			}
		}

		private void OnGameEventEnded(GameEventInstance obj)
		{
			if (activeObjective != null && !(obj?.Blueprint == null) && MonoSingleton<WorkerManager>.Instance.AnyWorker((HumanoidInstance worker) => !worker.HasDied && !worker.HasDisposed))
			{
				ScheduleCheckObjective(ObjectiveTaskRequirementType.FinishEvent);
			}
		}

		private void OnMapLoaded(bool wasLoadedFromSave)
		{
			Subscribe();
			if (activeObjective != null)
			{
				ObjectiveTaskRequirementType[] array = (ObjectiveTaskRequirementType[])Enum.GetValues(typeof(ObjectiveTaskRequirementType));
				foreach (ObjectiveTaskRequirementType requirementsToCheck in array)
				{
					ScheduleCheckObjective(requirementsToCheck);
				}
			}
		}

		private void OnLoadingCompleted()
		{
			MonoSingleton<TaskController>.Instance.WaitFor(1f).Then(delegate
			{
				gameLoaded = true;
			});
		}

		private void OnChangeLifePhase(PlantMapResourceInstance resource)
		{
			if (Repository<ObjectiveRepository, Objective>.Instance.ShouldCheckObjectiveOnPlantPhaseChange(resource.BlueprintId))
			{
				ScheduleCheckObjective(ObjectiveTaskRequirementType.HavePlantInRoom);
			}
		}

		private void OnDestroyBuilding(BaseBuildingInstance baseBuildingInstance)
		{
			if (activeObjective != null)
			{
				ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveBuilding);
			}
		}

		private void OnAfterConstructionCompleted(BaseBuildingInstance baseBuildingInstance)
		{
			if (activeObjective != null)
			{
				ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveBuilding);
			}
		}

		private void OnPileSpawn(ResourcePileInstance resource)
		{
			if (activeObjective != null)
			{
				string blueprintId = resource.BlueprintId;
				if (resourcesToTrack.Contains(blueprintId) || resourcesToTrackInRooms.ContainsKey(blueprintId))
				{
					ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveResource);
				}
			}
		}

		private void OnDestroyPile(ResourcePileInstance resource)
		{
			if (activeObjective != null)
			{
				string blueprintId = resource.BlueprintId;
				if (resourcesToTrack.Contains(blueprintId) || resourcesToTrackInRooms.ContainsKey(blueprintId))
				{
					ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveResource);
				}
			}
		}

		private void OnRoleChangedEvent(Role role, HumanoidInstance roleChangedHuman)
		{
			if (activeObjective != null)
			{
				ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveRole);
			}
		}

		private void OnRoomAdded(Room room, RoomType previousRoomType)
		{
			bool flag = roomsToTrack.Contains(room.RoomType.GetID());
			if ((flag || !(previousRoomType == null)) && (flag || roomsToTrack.Contains(previousRoomType.GetID())))
			{
				ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveRoom | ObjectiveTaskRequirementType.HaveResource | ObjectiveTaskRequirementType.HavePlantInRoom);
			}
		}

		private void OnRoomRemoved(Room room)
		{
			if (roomsToTrack.Contains(room.RoomType.GetID()))
			{
				ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveRoom | ObjectiveTaskRequirementType.HaveResource | ObjectiveTaskRequirementType.HavePlantInRoom);
			}
		}

		private void OnRoomTypeChanged(Room room, RoomType oldRoomType)
		{
			if (roomsToTrack.Contains(room.RoomType.GetID()) || roomsToTrack.Contains(oldRoomType.GetID()))
			{
				ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveRoom | ObjectiveTaskRequirementType.HaveResource | ObjectiveTaskRequirementType.HavePlantInRoom);
			}
		}

		private void OnEventEnded(PlayerTriggeredEventInstance eventInstance)
		{
			if (eventInstance.Completed())
			{
				MonoSingleton<WorldMap>.Instance.Data.IncrementPlayerTriggeredEventsEndedById(eventInstance.Blueprint.GetID());
				ScheduleCheckObjective(ObjectiveTaskRequirementType.HoldPlayerTriggeredEvent);
			}
		}

		public void ScheduleCheckObjective(ObjectiveTaskRequirementType requirementsToCheck)
		{
			refreshType |= requirementsToCheck;
		}

		private void Update()
		{
			if (activeObjective != null && gameLoaded && refreshType != ObjectiveTaskRequirementType.None)
			{
				CheckObjective(activeObjective, refreshType);
				refreshType = ObjectiveTaskRequirementType.None;
			}
		}

		private void CheckObjective(ObjectiveInstance objective, ObjectiveTaskRequirementType requirementsToCheck)
		{
			if (objective.Completed)
			{
				return;
			}
			ObjectiveTask[] tasks = objective.Blueprint.Tasks;
			foreach (ObjectiveTask objectiveTask in tasks)
			{
				if ((objectiveTask.RequirementTags & requirementsToCheck) != ObjectiveTaskRequirementType.None)
				{
					CheckTask(objective, objectiveTask, requirementsToCheck);
				}
			}
			bool flag = true;
			tasks = objective.Blueprint.Tasks;
			foreach (ObjectiveTask objectiveTask2 in tasks)
			{
				if (objectiveTask2.Requirements == null)
				{
					if (!objective.IsTaskCompleted(objectiveTask2.Id))
					{
						flag = false;
					}
					continue;
				}
				bool flag2 = true;
				ObjectiveTaskRequirement[] requirements = objectiveTask2.Requirements;
				foreach (ObjectiveTaskRequirement objectiveTaskRequirement in requirements)
				{
					if (!objective.IsRequirementCompleted(objectiveTask2.Id, objectiveTaskRequirement.Id))
					{
						flag2 = false;
						break;
					}
				}
				if (flag2 != objective.IsTaskCompleted(objectiveTask2.Id))
				{
					objective.SetTaskCompleted(objectiveTask2, flag2);
				}
				if (!objective.IsTaskCompleted(objectiveTask2.Id))
				{
					flag = false;
				}
			}
			if (objective.Completed != flag)
			{
				objective.SetCompleted(flag);
			}
		}

		private bool CheckTask(ObjectiveInstance objective, ObjectiveTask task, ObjectiveTaskRequirementType requirementsToCheck)
		{
			if (task.Requirements == null)
			{
				return false;
			}
			bool result = true;
			ObjectiveTaskRequirement[] requirements = task.Requirements;
			foreach (ObjectiveTaskRequirement objectiveTaskRequirement in requirements)
			{
				if ((objectiveTaskRequirement.Type & requirementsToCheck) != ObjectiveTaskRequirementType.None)
				{
					int currentCount;
					bool flag = CheckRequirement(objectiveTaskRequirement, out currentCount);
					objective.SetTaskRequirementCompleted(task, objectiveTaskRequirement, flag, currentCount);
					if (!flag)
					{
						result = false;
					}
				}
			}
			return result;
		}

		private bool CheckRequirement(ObjectiveTaskRequirement requirement, out int currentCount)
		{
			currentCount = 0;
			bool isEnabled;
			if (requirement.Type == ObjectiveTaskRequirementType.HaveRole)
			{
				string modelId = requirement.ModelId;
				int minLevel = requirement.MinLevel;
				currentCount = MonoSingleton<RoleManager>.Instance.CountWorkersWithRole(modelId, minLevel);
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(60, 6, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CheckRequirement ");
					messageBuilder.AppendFormatted(requirement.Type);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted((currentCount > requirement.MinCount) ? "success" : "fail");
					messageBuilder.AppendLiteral(": found ");
					messageBuilder.AppendFormatted(currentCount);
					messageBuilder.AppendLiteral(" of ");
					messageBuilder.AppendFormatted(requirement.MinCount);
					messageBuilder.AppendLiteral(" humans with min level ");
					messageBuilder.AppendFormatted(minLevel);
					messageBuilder.AppendLiteral(" role ");
					messageBuilder.AppendFormatted(requirement.ModelId);
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
				return currentCount >= requirement.MinCount;
			}
			if (requirement.Type == ObjectiveTaskRequirementType.HaveNpcByEvent)
			{
				currentCount = MonoSingleton<WorldMap>.Instance.Data.GetNpcsArrivedCountByEvent(requirement.ModelId);
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(55, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CheckRequirement ");
					messageBuilder.AppendFormatted(requirement.Type);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted((currentCount >= requirement.MinCount) ? "success" : "fail");
					messageBuilder.AppendLiteral(": found ");
					messageBuilder.AppendFormatted(currentCount);
					messageBuilder.AppendLiteral(" of ");
					messageBuilder.AppendFormatted(requirement.MinCount);
					messageBuilder.AppendLiteral(" NPCs arrived via event ");
					messageBuilder.AppendFormatted(requirement.ModelId);
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
				return currentCount >= requirement.MinCount;
			}
			if (requirement.Type == ObjectiveTaskRequirementType.HoldPlayerTriggeredEvent)
			{
				MonoSingleton<WorldMap>.Instance.Data.PlayerTriggeredEventsEndedById.TryGetValue(requirement.ModelId, out currentCount);
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(49, 6, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CheckRequirement ");
					messageBuilder.AppendFormatted(requirement.Type);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted((currentCount >= requirement.MinCount) ? "success" : "fail");
					messageBuilder.AppendLiteral(": ");
					messageBuilder.AppendFormatted(requirement.Type);
					messageBuilder.AppendLiteral(" found ");
					messageBuilder.AppendFormatted(currentCount);
					messageBuilder.AppendLiteral(" of ");
					messageBuilder.AppendFormatted(requirement.MinCount);
					messageBuilder.AppendLiteral(" events ");
					messageBuilder.AppendFormatted(requirement.ModelId);
					messageBuilder.AppendLiteral(" in total.");
				}
				Log.Info(messageBuilder);
				return currentCount >= requirement.MinCount;
			}
			if (requirement.Type == ObjectiveTaskRequirementType.HaveBuilding)
			{
				currentCount = map.BuildingsManagerMain.GetBuildingsCount(requirement.ModelId);
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(52, 6, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CheckRequirement ");
					messageBuilder.AppendFormatted(requirement.Type);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted((currentCount >= requirement.MinCount) ? "success" : "fail");
					messageBuilder.AppendLiteral(": ");
					messageBuilder.AppendFormatted(requirement.Type);
					messageBuilder.AppendLiteral(" found ");
					messageBuilder.AppendFormatted(currentCount);
					messageBuilder.AppendLiteral(" of ");
					messageBuilder.AppendFormatted(requirement.MinCount);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(requirement.ModelId);
					messageBuilder.AppendLiteral(" buildings in total.");
				}
				Log.Info(messageBuilder);
				return currentCount >= requirement.MinCount;
			}
			if (requirement.Type == ObjectiveTaskRequirementType.HaveRoom)
			{
				currentCount = 0;
				foreach (Room item in map.RoomDetection.IterateRoomsSafe())
				{
					if (!(item.RoomType.GetID() == requirement.RoomType))
					{
						continue;
					}
					currentCount++;
					if (currentCount >= requirement.MinCount)
					{
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(44, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("CheckRequirement ");
							messageBuilder.AppendFormatted(requirement.Type);
							messageBuilder.AppendLiteral(" success! Found >= ");
							messageBuilder.AppendFormatted(requirement.MinCount);
							messageBuilder.AppendLiteral(" ");
							messageBuilder.AppendFormatted(requirement.RoomType);
							messageBuilder.AppendLiteral(" rooms!");
						}
						Log.Info(messageBuilder);
						isEnabled = true;
						return isEnabled;
					}
				}
				return false;
			}
			if (requirement.Type == ObjectiveTaskRequirementType.HavePlantInRoom)
			{
				foreach (Room item2 in map.RoomDetection.IterateRoomsSafe())
				{
					if (!(item2.RoomType.GetID() == requirement.RoomType) || item2.GetResourceCount(requirement.ModelId) < requirement.MinCount)
					{
						continue;
					}
					if (requirement.PlantLifePhases != null)
					{
						foreach (PlantMapResourceInstance item3 in item2.PlantsInRoom[requirement.ModelId])
						{
							if (requirement.PlantLifePhases.Contains(item3.CurrentPhase))
							{
								isEnabled = true;
								return isEnabled;
							}
						}
						continue;
					}
					isEnabled = true;
					return isEnabled;
				}
				return false;
			}
			if (requirement.Type == ObjectiveTaskRequirementType.HavePlant)
			{
				MonoSingleton<FloraRegrowController>.Instance.PlantCountByType.TryGetValue(requirement.ModelId, out currentCount);
				return currentCount >= requirement.MinCount;
			}
			bool isEnabled2;
			if (requirement.Type == ObjectiveTaskRequirementType.DefeatObjectivesBanditCamps)
			{
				currentCount = MonoSingleton<WorldMap>.Instance.Data.GetRaidsWonForObjective(requirement.ModelId);
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(56, 4, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
				if (isEnabled2)
				{
					messageBuilder.AppendLiteral("CheckRequirement ");
					messageBuilder.AppendFormatted(requirement.Type);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted((currentCount >= requirement.MinCount) ? "success" : "fail");
					messageBuilder.AppendLiteral(": number of bandit camps defeated ");
					messageBuilder.AppendFormatted(currentCount);
					messageBuilder.AppendLiteral(" of ");
					messageBuilder.AppendFormatted(requirement.MinCount);
				}
				Log.Info(messageBuilder);
				return currentCount >= requirement.MinCount;
			}
			if (requirement.Type == ObjectiveTaskRequirementType.FinishEvent)
			{
				currentCount = MonoSingleton<WorldMap>.Instance.Data.GetEndedEventCount(requirement.ModelId);
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(50, 5, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
				if (isEnabled2)
				{
					messageBuilder.AppendLiteral("CheckRequirement ");
					messageBuilder.AppendFormatted(requirement.Type);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted((currentCount >= requirement.MinCount) ? "success" : "fail");
					messageBuilder.AppendLiteral(": number of ended '");
					messageBuilder.AppendFormatted(requirement.ModelId);
					messageBuilder.AppendLiteral("' events ");
					messageBuilder.AppendFormatted(currentCount);
					messageBuilder.AppendLiteral(" of ");
					messageBuilder.AppendFormatted(requirement.MinCount);
				}
				Log.Info(messageBuilder);
				return currentCount >= requirement.MinCount;
			}
			if (requirement.Type == ObjectiveTaskRequirementType.HaveResource)
			{
				currentCount = 0;
				Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(requirement.ModelId);
				if (byID == null)
				{
					return false;
				}
				if (byID.UniqueResource && requirement.RoomType == null && (currentCount = map.UniqueResourceTracker.GetUniqueResourceCount(requirement.ModelId)) >= requirement.MinCount && (map.UniqueResourceTracker.GetUniqueResourceOccurence(requirement.ModelId) & UniqueResourceTracker.Occurence.InPlayersPossession) != UniqueResourceTracker.Occurence.None)
				{
					return true;
				}
				ResourcePileCount count = MonoSingleton<ResourcePileTracker>.Instance.GetCount(byID);
				if (count == null)
				{
					return false;
				}
				if (count.TotalCount == 0)
				{
					return false;
				}
				if (string.IsNullOrEmpty(requirement.RoomType))
				{
					currentCount = count.TotalCount;
					if (count.TotalCount >= requirement.MinCount)
					{
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(48, 3, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
						if (isEnabled2)
						{
							messageBuilder.AppendLiteral("CheckRequirement ");
							messageBuilder.AppendFormatted(requirement.Type);
							messageBuilder.AppendLiteral(" success! Found >= ");
							messageBuilder.AppendFormatted(requirement.MinCount);
							messageBuilder.AppendLiteral(" ");
							messageBuilder.AppendFormatted(byID.GetID());
							messageBuilder.AppendLiteral(" resources!");
						}
						Log.Info(messageBuilder);
						return true;
					}
				}
				else
				{
					int num = 0;
					foreach (Room item4 in map.RoomDetection.IterateRoomsSafe())
					{
						if (!(item4.RoomType.GetID() == requirement.RoomType))
						{
							continue;
						}
						num = (currentCount = num + item4.GetResourceCount(byID.GetID()));
						if (num >= requirement.MinCount)
						{
							FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(57, 4, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Objectives\\ObjectiveManager.cs");
							if (isEnabled2)
							{
								messageBuilder.AppendLiteral("CheckRequirement ");
								messageBuilder.AppendFormatted(requirement.Type);
								messageBuilder.AppendLiteral(" success! Found >= ");
								messageBuilder.AppendFormatted(requirement.MinCount);
								messageBuilder.AppendLiteral(" ");
								messageBuilder.AppendFormatted(byID.GetID());
								messageBuilder.AppendLiteral(" resources in room ");
								messageBuilder.AppendFormatted(requirement.RoomType);
								messageBuilder.AppendLiteral("!");
							}
							Log.Info(messageBuilder);
							isEnabled = true;
							return isEnabled;
						}
					}
				}
			}
			if (requirement.Type == ObjectiveTaskRequirementType.HaveTradeDeal)
			{
				return MonoSingleton<WorldMap>.Instance.Data.TradeDeals.Count > 0;
			}
			return false;
		}
	}
}
