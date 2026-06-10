using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.EventBase;
using NSMedieval.GameEventSystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.RoomDetection;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Stockpiles;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[FVSerializableKey("PlayerTriggeredEventInstance", "")]
	public class PlayerTriggeredEventInstance : EventInstanceBase
	{
		protected const float RandomAroundMeetingPoint = 3f;

		protected const string SkillBookGroupName = "skill_book";

		protected readonly HashSet<int> CheckedInIds = new HashSet<int>();

		private const string EventCooldown = "eventCooldown";

		private const string EventCompletion = "completion";

		private const string RoleQuality = "roleQuality";

		private const string ParticipantsQuality = "participants";

		private const string RoomQuality = "roomImpressiveness";

		private const string UniqueResourceCount = "uniqueResourceCount";

		private const string ResourceAmountQuality = "resourceAmount";

		private readonly HashSet<IEventParticipant> allParticipantsUnique = new HashSet<IEventParticipant>();

		private EventState previousState;

		private EventState currentState;

		private List<IHungerAgent> hungerAgentsCache;

		private bool fromSave;

		private Dictionary<IEventParticipant, Vec3Int> meetingPositions;

		protected Dictionary<IEventParticipant, Vec3Int> EventPositions;

		private List<Vec3Int> meetingPositionsCache;

		private float remainingGatherTime;

		private PlayerTriggeredEventInfo eventCooldownInfo;

		private Vec3Int furnitureCenter;

		protected bool NpcFriendlinessFired;

		public readonly Dictionary<string, Resource> UniqueResourceGroups = new Dictionary<string, Resource>();

		public bool IsInvalidEvent { get; private set; }

		public BaseBuildingInstance HostBuilding { get; private set; }

		public Dictionary<EventAttendeeType, HashSet<IEventParticipant>> AttendeesByType { get; private set; }

		public Dictionary<IEventParticipant, string> ParticipantGoalIds { get; protected set; }

		protected Dictionary<Resource, int> EventResources { get; private set; }

		protected Dictionary<string, int> EventQualityValues { get; private set; }

		public float RemainingTime { get; private set; }

		public List<Vec3Int> ReservedPositions { get; protected set; }

		public List<Vector3> AnimationPositions { get; protected set; }

		public PlayerTriggeredEvent Blueprint => (PlayerTriggeredEvent)base.BaseBlueprint;

		protected IReadOnlyCollection<IEventParticipant> AllParticipantsUnique
		{
			get
			{
				allParticipantsUnique.Clear();
				if (AttendeesByType == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(Blueprint.GetID());
						messageBuilder.AppendLiteral(" AttendeesByType is null.");
					}
					Log.Error(messageBuilder);
					return null;
				}
				if (AttendeesByType.TryGetValue(EventAttendeeType.Participant, out var value))
				{
					allParticipantsUnique.UnionWith(value);
				}
				if (AttendeesByType.TryGetValue(EventAttendeeType.RoleParticipant, out value))
				{
					allParticipantsUnique.UnionWith(value);
				}
				if (AttendeesByType.TryGetValue(EventAttendeeType.PrisonerParticipant, out value))
				{
					allParticipantsUnique.UnionWith(value);
				}
				if (AttendeesByType.TryGetValue(EventAttendeeType.MeleeParticipant, out value))
				{
					allParticipantsUnique.UnionWith(value);
				}
				if (AttendeesByType.TryGetValue(EventAttendeeType.RangedParticipant, out value))
				{
					allParticipantsUnique.UnionWith(value);
				}
				return allParticipantsUnique;
			}
		}

		public bool HasVisitorParticipant => AllParticipantsUnique.Any((IEventParticipant p) => p is HumanoidInstance humanoidInstance && !humanoidInstance.IsWorker());

		public int NpcParticipantsCount => AllParticipantsUnique.Count((IEventParticipant p) => p is HumanoidInstance humanoidInstance && humanoidInstance.IsNpc());

		public bool IsRoomRequired => Blueprint.RoomRequired;

		public event Action EventInventoryChangedAction;

		public event Action<EventState> StateChangedEvent;

		protected PlayerTriggeredEventInstance()
		{
		}

		public HashSet<IEventParticipant> GetParticipants()
		{
			HashSet<IEventParticipant> hashSet = new HashSet<IEventParticipant>();
			if (AttendeesByType.TryGetValue(EventAttendeeType.Participant, out var value))
			{
				hashSet.AddRange(value);
			}
			if (AttendeesByType.TryGetValue(EventAttendeeType.MeleeParticipant, out value))
			{
				hashSet.AddRange(value);
			}
			if (AttendeesByType.TryGetValue(EventAttendeeType.RangedParticipant, out value))
			{
				hashSet.AddRange(value);
			}
			return hashSet;
		}

		public bool IsAlreadyParticipating(IEventParticipant participant)
		{
			return AllParticipantsUnique.Contains(participant);
		}

		public bool NotStarted()
		{
			return currentState == EventState.NotStarted;
		}

		public bool Running()
		{
			if (currentState != EventState.Gathering)
			{
				return currentState == EventState.Started;
			}
			return true;
		}

		public bool Started()
		{
			return currentState == EventState.Started;
		}

		public bool Gathering()
		{
			return currentState == EventState.Gathering;
		}

		public bool Ended()
		{
			EventState eventState = currentState;
			return eventState == EventState.Ended || eventState == EventState.Disposed;
		}

		public bool Disposed()
		{
			return currentState == EventState.Disposed;
		}

		public bool Interrupted()
		{
			if (currentState == EventState.Ended)
			{
				return RemainingTime > 0f;
			}
			return false;
		}

		public bool Completed()
		{
			if (currentState == EventState.Ended)
			{
				return RemainingTime <= 0f;
			}
			return false;
		}

		public bool CanEndWithoutPenalty()
		{
			return currentState != EventState.Started;
		}

		public virtual IEnumerable<ResourceInstance> GetDisplayEventResources()
		{
			return HostBuilding.EventStorage.GetResources();
		}

		public virtual ResourceInstance GetRandomDisplayEventResources()
		{
			return GetDisplayEventResources().PickRandom();
		}

		public void AddRemoveUniqueResource(string groupId, Resource resource, bool add)
		{
			bool isEnabled;
			if (!add)
			{
				UniqueResourceGroups[groupId] = null;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removing item from ");
					messageBuilder.AppendFormatted(groupId);
				}
				Log.Debug(messageBuilder);
				this.EventInventoryChangedAction?.Invoke();
				return;
			}
			if (UniqueResourceGroups.TryAdd(groupId, resource))
			{
				FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("New item ");
					messageBuilder2.AppendFormatted(resource);
					messageBuilder2.AppendLiteral(" Added to ");
					messageBuilder2.AppendFormatted(groupId);
				}
				Log.Trace(messageBuilder2);
			}
			else
			{
				FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(27, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Replacing ");
					messageBuilder2.AppendFormatted(UniqueResourceGroups[groupId]);
					messageBuilder2.AppendLiteral(" with ");
					messageBuilder2.AppendFormatted(resource);
					messageBuilder2.AppendLiteral(" in  ");
					messageBuilder2.AppendFormatted(groupId);
					messageBuilder2.AppendLiteral(" group");
				}
				Log.Trace(messageBuilder2);
				UniqueResourceGroups[groupId] = resource;
			}
			this.EventInventoryChangedAction?.Invoke();
		}

		public int GetEventQualitySum()
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Attempting to get event quality, current state: ");
				messageBuilder.AppendFormatted(currentState);
			}
			Log.Debug(messageBuilder);
			EventState eventState = currentState;
			if (eventState == EventState.NotStarted || eventState == EventState.Gathering || eventState == EventState.Ended)
			{
				return EventQualityValues.Values.Sum();
			}
			float num = 1f - RemainingTime / (Blueprint.EventDurationHours * 60f);
			return Mathf.RoundToInt((float)EventQualityValues.Values.Sum() * num);
		}

		public void SetHostFurniture(BaseBuildingInstance targetBuilding)
		{
			HostBuilding = targetBuilding;
			if (HostBuilding == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Host furniture is null  for event ");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
			}
		}

		private void OnHostBuildingDisposed(IGameDisposable obj)
		{
			if (HostBuilding != null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(79, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Host building '");
					messageBuilder.AppendFormatted(HostBuilding);
					messageBuilder.AppendLiteral("' was disposed while PTE '");
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral("' was still running. Ending the event.");
				}
				Log.Info(messageBuilder);
				HostBuilding = null;
				ChangeStateEnd();
			}
		}

		public override bool IsCorrupted()
		{
			if (HostBuilding != null)
			{
				return HostBuilding?.Map?.BuildingsManagerMain?.GetBuilding(HostBuilding.GridDataPosition, (BaseBuildingInstance building) => building.BuildingType == HostBuilding.BuildingType) == null;
			}
			return false;
		}

		public bool FurnitureIsInRoom(BaseBuildingInstance furnitureInstance)
		{
			if (!IsRoomRequired)
			{
				return true;
			}
			if (HostBuilding?.GetRoom() == null || furnitureInstance.GetRoom() == null)
			{
				return false;
			}
			if (!IsInCorrectRoom(HostBuilding) || !IsInCorrectRoom(furnitureInstance))
			{
				return false;
			}
			return furnitureInstance.GetRoom() == HostBuilding.GetRoom();
		}

		private bool IsInCorrectRoom(BaseBuildingInstance furnitureInstance)
		{
			if (!Blueprint.RoomRequired)
			{
				return true;
			}
			Room room = furnitureInstance?.GetRoom();
			if (room != null)
			{
				return Blueprint.RoomTypeIds.Contains(room.RoomType.GetID());
			}
			return false;
		}

		private void RemoveFromAllButType(IEventParticipant eventParticipant, EventAttendeeType excludeType, out EventAttendeeType getType)
		{
			getType = EventAttendeeType.None;
			foreach (var (eventAttendeeType2, hashSet2) in AttendeesByType)
			{
				if (eventAttendeeType2 != excludeType && hashSet2.Contains(eventParticipant))
				{
					hashSet2.Remove(eventParticipant);
					getType = eventAttendeeType2;
					break;
				}
			}
		}

		public void AddRemoveAttendee(IEventParticipant eventParticipant, EventAttendeeType attendeeType, bool add)
		{
			if (eventParticipant == null)
			{
				Log.Debug("Participant is null.", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				return;
			}
			bool isEnabled;
			if (add)
			{
				if (AttendeesByType[attendeeType].Count >= GetLimitForAttendeeType(attendeeType))
				{
					IEventParticipant eventParticipant2 = AttendeesByType[attendeeType].First();
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(51, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Event ");
						messageBuilder.AppendFormatted(Blueprint.GetID());
						messageBuilder.AppendLiteral(" is full for ");
						messageBuilder.AppendFormatted(attendeeType);
						messageBuilder.AppendLiteral(". Removing first participant (");
						messageBuilder.AppendFormatted(eventParticipant2);
						messageBuilder.AppendLiteral(").");
					}
					Log.Debug(messageBuilder);
					AttendeesByType[attendeeType].Remove(eventParticipant2);
					if (ParticipantGoalIds.ContainsKey(eventParticipant2))
					{
						ParticipantGoalIds.Remove(eventParticipant2);
					}
				}
				FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(26, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Adding ");
					messageBuilder2.AppendFormatted(eventParticipant);
					messageBuilder2.AppendLiteral(" of type ");
					messageBuilder2.AppendFormatted(attendeeType);
					messageBuilder2.AppendLiteral(" to event ");
					messageBuilder2.AppendFormatted(Blueprint.GetID());
				}
				Log.Trace(messageBuilder2);
				AttendeesByType[attendeeType].Add(eventParticipant);
				RemoveFromAllButType(eventParticipant, attendeeType, out var _);
				ParticipantGoalIds[eventParticipant] = Blueprint.GetGoalIdByType(attendeeType);
			}
			else
			{
				ParticipantGoalIds.Remove(eventParticipant);
				AttendeesByType[attendeeType].Remove(eventParticipant);
				FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(30, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Removing ");
					messageBuilder2.AppendFormatted(eventParticipant);
					messageBuilder2.AppendLiteral(" of type ");
					messageBuilder2.AppendFormatted(attendeeType);
					messageBuilder2.AppendLiteral(" from event ");
					messageBuilder2.AppendFormatted(Blueprint.GetID());
				}
				Log.Trace(messageBuilder2);
			}
			CacheHungerAgents();
			this.EventInventoryChangedAction?.Invoke();
		}

		private int GetLimitForAttendeeType(EventAttendeeType attendeeType)
		{
			int num = 0;
			foreach (IEventParticipant item in AttendeesByType[EventAttendeeType.RoleParticipant])
			{
				if (item is HumanoidInstance { ActiveBehaviour: { } activeBehaviour })
				{
					IRoleOwner humanoidRoleOwner = activeBehaviour.HumanoidRoleOwner;
					if (humanoidRoleOwner != null && humanoidRoleOwner.RoleInstance.Level > num)
					{
						num = humanoidRoleOwner.RoleInstance.Level;
					}
				}
			}
			return Blueprint.GetLimitForAttendeeType(attendeeType, num);
		}

		public void AddRemoveParticipant(IEventParticipant eventParticipant, EventAttendeeType type, bool add)
		{
			AddRemoveAttendee(eventParticipant, type, add);
		}

		protected void AddRemoveParticipant(IEventParticipant eventParticipant, bool add)
		{
			AddRemoveAttendee(eventParticipant, EventAttendeeType.Participant, add);
		}

		private void AddRemoveRoleParticipant(IEventParticipant eventParticipant, bool add)
		{
			AddRemoveAttendee(eventParticipant, EventAttendeeType.RoleParticipant, add);
		}

		public void AddRemoveAnimal(IEventParticipant animalInstance, bool add)
		{
			AddRemoveAttendee(animalInstance, EventAttendeeType.AnimalParticipant, add);
		}

		protected void AddRemovePrisoner(IEventParticipant prisoner, bool add)
		{
			AddRemoveAttendee(prisoner, EventAttendeeType.PrisonerParticipant, add);
		}

		public void TryAddDefaultRole()
		{
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (key.WorkerBehaviour.HumanoidRoleOwner.HasRole(Blueprint.RoleId))
				{
					AddRemoveRoleParticipant(key, add: true);
				}
			}
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				if (!item.ActiveBehaviour.HumanoidRoleOwner.HasRole(Blueprint.RoleId) || item.HasDied || item.HasDisposed || item.IsLeaving)
				{
					continue;
				}
				bool flag = false;
				if (AttendeesByType[EventAttendeeType.RoleParticipant].Count == 0)
				{
					flag = true;
				}
				else
				{
					foreach (IEventParticipant item2 in AttendeesByType[EventAttendeeType.RoleParticipant])
					{
						if (!(item2 is IRoleOwner roleOwner) || roleOwner.RoleInstance.Level < item.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.Level)
						{
							flag = true;
						}
					}
				}
				if (!flag)
				{
					break;
				}
				AddRemoveRoleParticipant(item, add: true);
			}
		}

		public void RemoveAnimalFromEvent(IEventParticipant eventParticipant)
		{
			if (!Completed())
			{
				RemoveParticipantFromEvent(eventParticipant);
			}
		}

		public void RemoveParticipantFromEvent(IEventParticipant eventParticipant)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Removing ");
				messageBuilder.AppendFormatted(((CreatureBase)eventParticipant).GetFullName());
				messageBuilder.AppendLiteral(" from event ");
				messageBuilder.AppendFormatted(Blueprint.GetID());
			}
			Log.Debug(messageBuilder);
			RemoveFromAllButType(eventParticipant, EventAttendeeType.None, out var getType);
			if (eventParticipant is CreatureBase { HasDisposed: false, HasDied: false })
			{
				eventParticipant.GoapLeavePlayerTriggeredEvent(Blueprint.GetGoalIdByType(getType));
			}
		}

		public void OnAnimalCanNotAttend(AnimalInstance animalInstance)
		{
			if (!CanEndWithoutPenalty() && currentState != EventState.Ended)
			{
				AddRemoveAnimal(animalInstance, add: false);
				List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
				{
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_yes"), ChangeStateEnd),
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_no"), delegate
					{
					})
				};
				string promptText = MonoSingleton<LocalizationController>.Instance.GetText("animal_cant_attend_event_prompt").Replace("<event_name>", MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(Blueprint.LocKeys))).Replace("<animal_name>", AnimalUtils.GetAnimalName(animalInstance));
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(promptText, buttonActions), handleInput: false);
			}
		}

		public string GetEstimatedEventQuality()
		{
			return UiUtils.Localize.GetText(LocKeyUtils.GetName(GetOutcome().LocKeys)) ?? "";
		}

		public void AddToEventResource(Resource resource, int amountToAdd)
		{
			if (EventResources.TryAdd(resource, amountToAdd))
			{
				this.EventInventoryChangedAction?.Invoke();
			}
			else
			{
				SetEventResourceValue(resource, EventResources[resource] + amountToAdd);
			}
		}

		public void SetEventResourceValue(Resource resource, int value)
		{
			value = Mathf.Clamp(value, 0, MonoSingleton<ResourcePileTracker>.Instance.GetCount(resource).StockpileAllowedCount);
			if (EventResources.TryAdd(resource, value))
			{
				this.EventInventoryChangedAction?.Invoke();
				return;
			}
			EventResources[resource] = value;
			this.EventInventoryChangedAction?.Invoke();
		}

		public int GetEventResourceCount(Resource resource)
		{
			if (!EventResources.TryAdd(resource, 0))
			{
				return EventResources[resource];
			}
			return 0;
		}

		private void StoreResources()
		{
			if (fromSave)
			{
				return;
			}
			foreach (KeyValuePair<Resource, int> eventResource in EventResources)
			{
				if (eventResource.Value == 0)
				{
					continue;
				}
				int num = eventResource.Value;
				foreach (StockpileInstance stockpile in MonoSingleton<StockpileManager>.Instance.Stockpiles)
				{
					if (stockpile == null || stockpile.HasDisposed)
					{
						continue;
					}
					if (num == 0)
					{
						break;
					}
					foreach (ResourcePileInstance storedPile in stockpile.GetStoredPiles())
					{
						if (storedPile == null || storedPile.HasDisposed)
						{
							continue;
						}
						if (num == 0)
						{
							break;
						}
						if (storedPile.Blueprint != eventResource.Key)
						{
							continue;
						}
						Storage storage = storedPile.GetStorage();
						if (storage != null && !storage.HasDisposed)
						{
							ResourceInstance resourceInstance = storage.Take(eventResource.Key, num);
							if (resourceInstance != null)
							{
								num -= resourceInstance.Amount;
								HostBuilding.EventStorage.AddToStorage(resourceInstance);
							}
						}
					}
				}
				foreach (ShelfComponentInstance componentInstance in VillageManager.ActiveVillage.Map.ShelfComponentManager.ComponentInstances)
				{
					if (componentInstance == null || componentInstance.HasDisposed)
					{
						continue;
					}
					if (num == 0)
					{
						break;
					}
					foreach (ResourcePileInstance storedPile2 in componentInstance.GetStoredPiles())
					{
						if (storedPile2 == null || storedPile2.HasDisposed)
						{
							continue;
						}
						if (num == 0)
						{
							break;
						}
						if (storedPile2.Blueprint != eventResource.Key)
						{
							continue;
						}
						Storage storage2 = storedPile2.GetStorage();
						if (storage2 != null && !storage2.HasDisposed)
						{
							ResourceInstance resourceInstance2 = storage2.Take(eventResource.Key, num);
							if (resourceInstance2 != null)
							{
								num -= resourceInstance2.Amount;
								HostBuilding.EventStorage.AddToStorage(resourceInstance2);
							}
						}
					}
				}
			}
		}

		public EventOutcomeSetting GetOutcome()
		{
			int eventQualitySum = GetEventQualitySum();
			return Blueprint.GetOutcomeSettings(eventQualitySum);
		}

		private string GetValueString(int value)
		{
			if (value <= 0)
			{
				return $"{value}";
			}
			return $"+{value}";
		}

		private void TickResourceSpend()
		{
			foreach (KeyValuePair<Resource, int> eventResource in EventResources)
			{
				if (eventResource.Value == 0)
				{
					continue;
				}
				int num = Mathf.CeilToInt((float)eventResource.Value * GetEventCompletionPercentage());
				int resourceCount = HostBuilding.EventStorage.GetResourceCount(eventResource.Key);
				if (resourceCount == 0 || resourceCount <= num)
				{
					continue;
				}
				IGoapAgentOwner randomByConsumptionSpeedWeight = GetRandomByConsumptionSpeedWeight();
				Agent agent = randomByConsumptionSpeedWeight?.GetGoapAgent();
				if (agent == null)
				{
					continue;
				}
				int toTake = resourceCount - num;
				ResourceInstance resourceInstance = HostBuilding.EventStorage.TakeFromStorage(eventResource.Key, toTake);
				if (resourceInstance.Blueprint.Category.HasFlag(ResourceCategory.CtgEdible))
				{
					if (randomByConsumptionSpeedWeight is IHungerAgent hungerAgent)
					{
						StatInstance stat = hungerAgent.Stats.GetStat(StatType.Hunger);
						if (stat != null && stat.Current < 0f)
						{
							stat.AddCurrent(0f - stat.Current);
						}
						else
						{
							float value = resourceInstance.GetNutrition() * (float)resourceInstance.Amount;
							stat.AddCurrent(value);
						}
						hungerAgent.Stats.Update();
						MonoSingleton<ResourceCommonController>.Instance.OnAteResource(resourceInstance, agent);
					}
				}
				else if (resourceInstance.Blueprint.Category.HasFlag(ResourceCategory.CtgAlcohol))
				{
					MonoSingleton<ResourceCommonController>.Instance.OnDrankResource(resourceInstance, agent);
				}
			}
		}

		public IEnumerable<T> IterateAttendees<T>(EventAttendeeType eventAttendeeType, Predicate<T> filter = null)
		{
			foreach (IEventParticipant item in AttendeesByType[eventAttendeeType])
			{
				if (item is T val && (filter == null || filter(val)))
				{
					yield return val;
				}
			}
		}

		public IEnumerable<IEventParticipant> IterateAttendees(EventAttendeeType eventAttendeeType, Predicate<IEventParticipant> filter = null)
		{
			foreach (IEventParticipant item in AttendeesByType[eventAttendeeType])
			{
				if (filter == null || filter(item))
				{
					yield return item;
				}
			}
		}

		public T GetFirstAttendeeOfType<T>(EventAttendeeType attendeeType)
		{
			return IterateAttendees<T>(attendeeType).FirstOrDefault();
		}

		public bool HasAttendeeOfType<T>(EventAttendeeType attendeeType)
		{
			return GetFirstAttendeeOfType<T>(attendeeType) != null;
		}

		private void CacheHungerAgents()
		{
			hungerAgentsCache.Clear();
			foreach (IHungerAgent item in AllParticipantsUnique.OfType<IHungerAgent>())
			{
				if (item.Stats != null)
				{
					hungerAgentsCache.Add(item);
				}
			}
		}

		private IGoapAgentOwner GetRandomByConsumptionSpeedWeight()
		{
			foreach (IHungerAgent item in hungerAgentsCache)
			{
				if ((double)item.Stats.GetStat(StatType.Hunger).Current < 0.9)
				{
					return item as IGoapAgentOwner;
				}
			}
			return hungerAgentsCache.GetRandomByWeight((IHungerAgent agent) => agent.Stats.GetAttributeInstance(AttributeType.ConsumptionSpeed).Value) as IGoapAgentOwner;
		}

		protected void AssignChairs()
		{
			Room room = HostBuilding.GetRoom();
			if (room == null)
			{
				return;
			}
			foreach (WorldObject item in room.IterateRoomContent())
			{
				ChairComponentInstance componentInstance = item.Map.ChairComponentManager.GetComponentInstance(item);
				if (componentInstance != null && !componentInstance.HasDisposed)
				{
					IEventParticipant eventParticipant = GetParticipants().FirstOrDefault((IEventParticipant participant) => !EventPositions.ContainsKey(participant));
					if (eventParticipant == null)
					{
						break;
					}
					EventPositions.Add(eventParticipant, componentInstance.GridDataPosition);
				}
			}
		}

		public void AssignMeetingPositions()
		{
			meetingPositions = new Dictionary<IEventParticipant, Vec3Int>();
			foreach (IEventParticipant item in AllParticipantsUnique)
			{
				if (item is CreatureBase creatureBase)
				{
					if (HostBuilding == null)
					{
						meetingPositions.Add(item, creatureBase.GetGridPosition());
					}
					else
					{
						meetingPositions.Add(item, GetRandomMeetingPosition(item));
					}
				}
			}
		}

		public Vec3Int GetMeetingPosition(IEventParticipant participant)
		{
			if (meetingPositions.TryGetValue(participant, out var value))
			{
				return value;
			}
			if (participant is CreatureBase creatureBase)
			{
				return creatureBase.GetGridPosition();
			}
			return Vec3Int.zero;
		}

		public Vec3Int GetEventPosition(IEventParticipant participant)
		{
			if (EventPositions.TryGetValue(participant, out var value))
			{
				return value;
			}
			if (participant is CreatureBase creatureBase)
			{
				return creatureBase.GetGridPosition();
			}
			return Vec3Int.zero;
		}

		private bool EveryoneGathered()
		{
			int num = 0;
			foreach (IEventParticipant item in AllParticipantsUnique)
			{
				if (item is CreatureBase creatureBase && CheckedInIds.Contains(creatureBase.UniqueId))
				{
					num++;
				}
			}
			return num == AllParticipantsUnique.Count;
		}

		public Vec3Int GetFurnitureCenterPosition()
		{
			return furnitureCenter;
		}

		private void FindFurnitureCenterPosition()
		{
			if (HostBuilding.Positions == null || HostBuilding.Positions.Count < 3)
			{
				furnitureCenter = HostBuilding.GridDataPosition;
				return;
			}
			using PooledHashSet<int> pooledHashSet = HashSetPool<int>.GetJanitor();
			using PooledHashSet<int> pooledHashSet2 = HashSetPool<int>.GetJanitor();
			foreach (Vec3Int position in HostBuilding.Positions)
			{
				pooledHashSet.Add(position.x);
				pooledHashSet2.Add(position.z);
			}
			int num = pooledHashSet2.Count;
			int num2 = pooledHashSet.Count;
			if (num % 2 != 0)
			{
				num++;
			}
			if (num2 % 2 != 0)
			{
				num2++;
			}
			int index = Mathf.Clamp(num / 2 * (num2 / 2), 0, HostBuilding.Positions.Count - 1);
			furnitureCenter = HostBuilding.Positions[index];
		}

		private void FindEventPositionPoints()
		{
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			foreach (Vec3Int reachablePosition in HostBuilding.ReachablePositions)
			{
				Vec3Int pos = reachablePosition;
				if (ReservedPositions.Contains(pos))
				{
					continue;
				}
				if (!IsRoomRequired)
				{
					pooledList.Add(pos);
					continue;
				}
				if (HostBuilding.GetRoom() == null)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Something Went Wrong. ");
						messageBuilder.AppendFormatted(HostBuilding.Blueprint.GetID());
						messageBuilder.AppendLiteral(" should be in the room!");
					}
					Log.Info(messageBuilder);
					continue;
				}
				MapNode mapNode = HostBuilding.GetRoom().AllNodes.FirstOrDefault((MapNode n) => n.Position == pos);
				if (mapNode != null)
				{
					BuildingType furnitureType = BuildingType.Chair | BuildingType.Table | BuildingType.Bed | BuildingType.Decoration;
					if (!mapNode.WorldObjects.Any((WorldObject wo) => wo is BaseBuildingInstance baseBuildingInstance && furnitureType.HasFlag(baseBuildingInstance.BuildingType)))
					{
						pooledList.Add(pos);
					}
				}
			}
			pooledList.AddRange(meetingPositionsCache);
			foreach (IEventParticipant item in AllParticipantsUnique)
			{
				if (!EventPositions.ContainsKey(item))
				{
					if (pooledList.Count == 0)
					{
						EventPositions.Add(item, GetRandomMeetingPosition(item));
						continue;
					}
					Vec3Int vec3Int = pooledList.PickRandom();
					pooledList.Remove(vec3Int);
					EventPositions.Add(item, vec3Int);
				}
			}
		}

		private Vec3Int GetRandomMeetingPosition(IEventParticipant participant, FloatRange distanceRange = null)
		{
			if (CombatUtils.IsNullOrDisposed(participant as CreatureBase, HostBuilding))
			{
				return default(Vec3Int);
			}
			CreatureBase creatureBase = (CreatureBase)participant;
			Vec3Int position = creatureBase.GetNode().Position;
			VillageMap map = creatureBase.Map;
			MapNode node = creatureBase.GetNode();
			Vec3Int gridPosition = creatureBase.GetGridPosition();
			Room room = map.RoomDetection.GetRoom(gridPosition);
			Region region = map.GetNode(gridPosition).Region;
			Region region2 = HostBuilding.GetNode().Region;
			if (!PathfinderUtil.IsPathPossible(creatureBase.WalkableModel, node, HostBuilding.GetNode()))
			{
				return position;
			}
			if (!PathfinderUtil.IsRegionReachable(creatureBase.WalkableModel, region, region2))
			{
				return position;
			}
			if (room != null && room.IsFullyLocked())
			{
				return position;
			}
			position = meetingPositionsCache.PickRandom();
			if (position == creatureBase.GetGridPosition())
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Couldn't find no random position for ");
					messageBuilder.AppendFormatted(creatureBase.GetFullName());
					messageBuilder.AppendLiteral(".");
				}
				Log.Debug(messageBuilder);
			}
			return position;
		}

		private bool CacheMeetingPoints()
		{
			meetingPositionsCache.Clear();
			foreach (Vec3Int reachablePosition in HostBuilding.ReachablePositions)
			{
				meetingPositionsCache.AddUnique(reachablePosition);
			}
			PooledHashSet<MapNode> roomNodes = HashSetPool<MapNode>.GetJanitor();
			bool isInRoom;
			try
			{
				isInRoom = false;
				Room room = HostBuilding.GetRoom();
				if (room != null)
				{
					isInRoom = true;
					roomNodes.AddRange(room.AllNodes);
					foreach (MapNode item in roomNodes)
					{
						meetingPositionsCache.AddUnique(item.Position);
					}
				}
				AddNeighbours(meetingPositionsCache, includeHost: false);
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral(" Returning ");
					messageBuilder.AppendFormatted(meetingPositionsCache.Count);
					messageBuilder.AppendLiteral(" meeting positions.");
				}
				Log.Debug(messageBuilder);
				isEnabled = meetingPositionsCache.Count != 0;
				return isEnabled;
			}
			finally
			{
				((IDisposable)roomNodes/*cast due to .constrained prefix*/).Dispose();
			}
			void AddNeighbours(List<Vec3Int> hostPositions, bool includeHost)
			{
				using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
				pooledList.AddRange(hostPositions);
				if (!includeHost)
				{
					hostPositions.Clear();
				}
				foreach (Vec3Int item2 in pooledList)
				{
					foreach (MapNode neighbour in GlobalSaveController.CurrentVillageData.PlayerVillage.Map.GetNode(item2).Neighbours)
					{
						if (!ReservedPositions.Contains(neighbour.Position) && !hostPositions.Contains(neighbour.Position) && (!isInRoom || roomNodes.Contains(neighbour)) && neighbour.IsWalkable && !neighbour.IsWater)
						{
							bool flag = (neighbour.BuildingType & ~(BuildingType.Floor | BuildingType.Beam | BuildingType.Rug)) == 0 && (neighbour.BuildingType & (BuildingType.Floor | BuildingType.Rug)) != 0;
							if (neighbour.DataType == GridDataType.None || flag)
							{
								hostPositions.AddUnique(neighbour.Position);
							}
						}
					}
				}
			}
		}

		public virtual string[] GetParticipantEffectors()
		{
			return new List<string>(GetOutcome().ParticipantEffectors).ToArray();
		}

		protected virtual string[] GetParticipantEffectorParsed(EventAttendeeType eventAttendeeType)
		{
			List<string> list = new List<string>();
			if (!Blueprint.HasAttendeeType(eventAttendeeType))
			{
				return list.ToArray();
			}
			string[] participantEffectors = GetOutcome().ParticipantEffectors;
			foreach (string effector in participantEffectors)
			{
				list.Add(Blueprint.ParseEffector(eventAttendeeType, effector));
			}
			return list.ToArray();
		}

		public string[] GetParticipantEffectorParsed(IEventParticipant eventParticipant)
		{
			if (eventParticipant == null)
			{
				return GetParticipantEffectors();
			}
			foreach (KeyValuePair<EventAttendeeType, HashSet<IEventParticipant>> item in AttendeesByType)
			{
				if (item.Value.Contains(eventParticipant))
				{
					return GetParticipantEffectorParsed(item.Key);
				}
			}
			return GetParticipantEffectors();
		}

		public string[] GetNonParticipantEffectors()
		{
			return GetOutcome().NonParticipantEffectors;
		}

		public string[] GetNonFactionPrisonerEffectors()
		{
			return GetOutcome().NonFactionPrisonerEffectors;
		}

		public string[] GetFactionPrisonerEffectors()
		{
			return GetOutcome().FactionPrisonerEffectors;
		}

		public bool GetSpawnMapMarkerInfo(out SecondMapType mapType, out float chance)
		{
			EventOutcomeSetting outcome = GetOutcome();
			if (outcome.DiscoverMapMarkerFromForeigners == SecondMapType.None)
			{
				mapType = SecondMapType.None;
				chance = 0f;
				return false;
			}
			mapType = outcome.DiscoverMapMarkerFromForeigners;
			chance = outcome.DiscoverMapMarkerFromForeignersChance;
			return true;
		}

		protected virtual void StartGathering()
		{
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			FindFurnitureCenterPosition();
			if (!CacheMeetingPoints())
			{
				ChangeStateEnd();
				return;
			}
			AssignMeetingPositions();
			FindEventPositionPoints();
			ChangeState(EventState.Gathering);
			foreach (KeyValuePair<IEventParticipant, string> participantGoalId in ParticipantGoalIds)
			{
				participantGoalId.Key.GoapAttendPlayerTriggeredEvent(participantGoalId.Value);
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(32, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(((CreatureBase)participantGoalId.Key).GetFullName());
					messageBuilder.AppendLiteral(" is attending event ");
					messageBuilder.AppendFormatted(Blueprint.GetID());
					messageBuilder.AppendLiteral(" with ");
					messageBuilder.AppendFormatted(participantGoalId.Value);
					messageBuilder.AppendLiteral(" goal.");
				}
				Log.Debug(messageBuilder);
			}
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(UiUtils.Localize.GetText("player_triggered_event_start").Replace("<event_name>", UiUtils.Localize.GetText(LocKeyUtils.GetName(Blueprint.LocKeys))));
		}

		protected void ReserveRolePosition(HashSet<Vec3Int> workplacePositions)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Reserving role position: ");
				messageBuilder.AppendFormatted(workplacePositions.First());
			}
			Log.Trace(messageBuilder);
			if (workplacePositions == null || workplacePositions.Count <= 0)
			{
				Log.Error("No workplace positions assigned!", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				return;
			}
			ReservedPositions.AddRange(workplacePositions);
			if (!AttendeesByType.TryGetValue(EventAttendeeType.RoleParticipant, out var value) || value.Count <= 0)
			{
				Log.Debug("No Role Participants assigned!", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				return;
			}
			EventPositions.TryAdd(value.First(), workplacePositions.First());
			FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(16, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Role ");
				messageBuilder2.AppendFormatted(value.First());
				messageBuilder2.AppendLiteral(" position: ");
				messageBuilder2.AppendFormatted(workplacePositions.First());
			}
			Log.Debug(messageBuilder2);
		}

		public virtual void CheckIn(int uniqueId)
		{
			if (CheckedInIds.Contains(uniqueId))
			{
				return;
			}
			CheckedInIds.Add(uniqueId);
			if (!MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.DevTools)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Settler ");
					messageBuilder.AppendFormatted(uniqueId);
					messageBuilder.AppendLiteral(" arrived at ");
					messageBuilder.AppendFormatted(UiUtils.Localize.GetText(LocKeyUtils.GetName(Blueprint.LocKeys)));
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
			}
		}

		protected float GetEventCompletionPercentage()
		{
			if (currentState == EventState.Ended)
			{
				return 1f;
			}
			return Mathf.Clamp(RemainingTime / (Blueprint.EventDurationHours * 60f), 0f, 1f);
		}

		protected bool CanPathFind(IEventParticipant eventParticipant)
		{
			if (!(eventParticipant is CreatureBase creatureBase))
			{
				return false;
			}
			if (CombatUtils.IsNullOrDisposed(creatureBase))
			{
				return false;
			}
			if (creatureBase is HumanoidInstance humanoidInstance && humanoidInstance.IsCaptive())
			{
				return true;
			}
			VillageMap map = creatureBase.Map;
			MapNode node = creatureBase.GetNode();
			Vec3Int gridPosition = creatureBase.GetGridPosition();
			Room room = map.RoomDetection.GetRoom(gridPosition);
			Region region = creatureBase.Map.GetNode(creatureBase.GetGridPosition()).Region;
			Region region2 = HostBuilding.GetNode().Region;
			if (!PathfinderUtil.IsPathPossible(creatureBase.WalkableModel, node, HostBuilding.GetNode()))
			{
				return false;
			}
			if (!PathfinderUtil.IsRegionReachable(creatureBase.WalkableModel, region, region2))
			{
				return false;
			}
			Room room2 = HostBuilding.GetRoom();
			if (room != null && room2 != null && room != room2 && room.IsFullyLocked())
			{
				return false;
			}
			return true;
		}

		protected bool CanAnimalPathFind(IEventParticipant eventParticipant)
		{
			if (!(eventParticipant is AnimalInstance animalInstance))
			{
				return false;
			}
			if (CombatUtils.IsNullOrDisposed(animalInstance))
			{
				return false;
			}
			VillageMap map = animalInstance.Map;
			uint area = animalInstance.GetNode().Area;
			uint area2 = HostBuilding.GetNode().Area;
			if (PathfinderUtil.IsAreaReachable(Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID("animal_leave_map").GenerateTraversalProvider(), map, area2, area))
			{
				return true;
			}
			return false;
		}

		protected bool CanParticipate(HumanoidInstance humanoid)
		{
			if (humanoid.WorkerBehaviour != null)
			{
				if (!humanoid.WorkerBehaviour.IsBanished && !humanoid.HasFainted && !humanoid.WorkerBehaviour.IsCrazy && !humanoid.IsWounded && !humanoid.IsReceivingWoundTreatman)
				{
					return !humanoid.IsFormingCaravan();
				}
				return false;
			}
			if (!humanoid.HasDied && !humanoid.HasFainted && !humanoid.HasDisposed)
			{
				return !humanoid.IsLeaving;
			}
			return false;
		}

		protected bool CanParticipate(AnimalInstance animalInstance)
		{
			if (!animalInstance.HasDied && !animalInstance.HasFainted && !animalInstance.HasDisposed && !animalInstance.IsLeavingMap)
			{
				return !animalInstance.IsFormingCaravan();
			}
			return false;
		}

		public bool LockedInUI(IEventParticipant participant)
		{
			if (!(participant is HumanoidInstance humanoidInstance))
			{
				if (participant is AnimalInstance animalInstance)
				{
					return !CanAnimalPathFind(animalInstance) || animalInstance.HasFainted;
				}
				return false;
			}
			return !CanPathFind(participant) || humanoidInstance.HasFainted;
		}

		public bool HasParticipant(IEventParticipant eventParticipant)
		{
			return AllParticipantsUnique.Contains(eventParticipant);
		}

		public bool HasAnimal(IEventParticipant eventParticipant)
		{
			return AttendeesByType[EventAttendeeType.AnimalParticipant].Contains(eventParticipant);
		}

		public bool HasForeignNPC()
		{
			if (!GetParticipants().AnyNonAlloc((IEventParticipant participant) => participant is HumanoidInstance humanoidInstance && !humanoidInstance.IsWorker()))
			{
				return AttendeesByType[EventAttendeeType.RoleParticipant].AnyNonAlloc((IEventParticipant participant) => participant is HumanoidInstance humanoidInstance && !humanoidInstance.IsWorker());
			}
			return true;
		}

		public void ChangeStateEnd()
		{
			ChangeState(EventState.Ended);
		}

		protected virtual bool CanOverrideGatheringTimeout()
		{
			return true;
		}

		public override bool CanStart()
		{
			if (GetParticipants() == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(Blueprint.GetID());
					messageBuilder.AppendLiteral(" event instance:  Participants list is null");
				}
				Log.Error(messageBuilder);
				return false;
			}
			if (GetParticipants().Count < 1)
			{
				return false;
			}
			return base.CanStart();
		}

		public void InitializeFromSave()
		{
			base.Initialize();
			InitializeVariables();
			ChangeState(EventState.NotStarted);
			List<IEventParticipant> list = new List<IEventParticipant>();
			foreach (KeyValuePair<EventAttendeeType, HashSet<IEventParticipant>> item in AttendeesByType)
			{
				if (item.Value == null || item.Value.Count == 0)
				{
					continue;
				}
				list.Clear();
				list.AddRange(item.Value);
				item.Value.Clear();
				foreach (IEventParticipant item2 in list)
				{
					if (!(item2 is CreatureBase { HasView: false }))
					{
						AddRemoveAttendee(item2, item.Key, add: true);
					}
				}
			}
		}

		public override void Initialize()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(Blueprint.GetID());
				messageBuilder.AppendLiteral(" initialized");
			}
			Log.Trace(messageBuilder);
			base.Initialize();
			InitializeVariables();
			ChangeState(EventState.NotStarted);
			InitAttendees();
			TryAddDefaultRole();
			TryAddUniqueResources();
		}

		private void TryAddUniqueResources()
		{
			if (Blueprint.UniqueResourceSettings == null || Blueprint.UniqueResourceSettings.Length == 0)
			{
				return;
			}
			ResourceSetting[] uniqueResourceSettings = Blueprint.UniqueResourceSettings;
			foreach (ResourceSetting resourceSetting in uniqueResourceSettings)
			{
				foreach (Resource item in Repository<ResourceRepository, Resource>.Instance.GetAllResourcesByResourceCategory(resourceSetting.ResourceCategory))
				{
					if (PlayerTriggeredEventUtils.ShouldAddResource(resourceSetting, item))
					{
						AddRemoveUniqueResource(resourceSetting.GetID(), item, add: true);
						return;
					}
				}
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Creating empty group ");
					messageBuilder.AppendFormatted(resourceSetting.GetID());
				}
				Log.Debug(messageBuilder);
				AddRemoveUniqueResource(resourceSetting.GetID(), null, add: false);
			}
		}

		private void InitializeVariables()
		{
			if (!fromSave)
			{
				EventResources = new Dictionary<Resource, int>();
				EventQualityValues = new Dictionary<string, int>();
				RemainingTime = Blueprint.EventDurationHours * 60f;
				remainingGatherTime = Blueprint.GatheringTimeoutHours * 60f;
			}
			ParticipantGoalIds = new Dictionary<IEventParticipant, string>();
			EventPositions = new Dictionary<IEventParticipant, Vec3Int>();
			NpcFriendlinessFired = false;
			hungerAgentsCache = new List<IHungerAgent>();
			ReservedPositions = new List<Vec3Int>();
			AnimationPositions = new List<Vector3>();
			meetingPositionsCache = new List<Vec3Int>();
		}

		private void InitAttendees()
		{
			if (AttendeesByType == null)
			{
				Dictionary<EventAttendeeType, HashSet<IEventParticipant>> dictionary = (AttendeesByType = new Dictionary<EventAttendeeType, HashSet<IEventParticipant>>());
			}
			EventAttendeeType[] eventAttendeeTypes = EnumValues.EventAttendeeTypes;
			foreach (EventAttendeeType eventAttendeeType in eventAttendeeTypes)
			{
				if (eventAttendeeType != EventAttendeeType.None)
				{
					AttendeesByType.TryAdd(eventAttendeeType, new HashSet<IEventParticipant>());
				}
			}
		}

		public override void Start()
		{
			LogInfo();
			if (currentState == EventState.NotStarted)
			{
				Subscribe();
				StartGathering();
				StoreResources();
				return;
			}
			base.Start();
			if (fromSave)
			{
				CacheHungerAgents();
			}
			ChangeState(EventState.Started);
		}

		public override void End()
		{
			base.End();
			Unsubscribe();
			LogInfo();
			if (previousState != EventState.Started)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(UiUtils.Localize.GetText("player_triggered_event_cancelled").Replace("<event_name>", UiUtils.Localize.GetText(LocKeyUtils.GetName(Blueprint.LocKeys))));
				Dispose();
				return;
			}
			RemainingTime = 0f;
			MonoSingleton<NewsManager>.Instance.Publish(PlayerTriggeredEventUtils.GetEventEndNewsData(this));
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(UiUtils.Localize.GetText("player_triggered_event_ended").Replace("<event_name>", UiUtils.Localize.GetText(LocKeyUtils.GetName(Blueprint.LocKeys))).Replace("<quality_outcome>", GetEstimatedEventQuality()));
			FireEventSpecificEffectors();
			FireFactionFriendlinessEffectors();
			if (GetSpawnMapMarkerInfo(out var mapType, out var chance) && HasForeignNPC() && mapType == SecondMapType.LootStash)
			{
				MapPlaceGenerator.MaybeSpawnLootStash(chance);
			}
			Dispose();
		}

		protected virtual void Dispose()
		{
			using PooledHashSet<IEventParticipant> pooledHashSet = HashSetPool<IEventParticipant>.GetJanitor();
			foreach (KeyValuePair<EventAttendeeType, HashSet<IEventParticipant>> item in AttendeesByType)
			{
				item.Deconstruct(out var _, out var value);
				foreach (IEventParticipant item2 in value)
				{
					if (item2 is HumanoidInstance humanoidInstance && humanoidInstance.IsNpc() && (humanoidInstance.HasDied || humanoidInstance.HasDisposed))
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(44, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("The npc ");
							messageBuilder.AppendFormatted(humanoidInstance);
							messageBuilder.AppendLiteral(" is dead or disposed (left the map).");
						}
						Log.Error(messageBuilder);
					}
					else
					{
						pooledHashSet.Add(item2);
					}
				}
			}
			HostBuilding?.EventStorage.ClearEventStorage(HostBuilding.GridDataPosition);
			foreach (IEventParticipant item3 in pooledHashSet)
			{
				RemoveParticipantFromEvent(item3);
			}
			CheckedInIds.Clear();
			ChangeState(EventState.Disposed);
		}

		protected virtual void FireFactionFriendlinessEffectors()
		{
			if (NpcFriendlinessFired)
			{
				((AllParticipantsUnique.FirstOrDefault() is HumanoidInstance humanoidInstance) ? humanoidInstance.Faction : null)?.AddFriendliness(GetOutcome().Friendliness);
				NpcFriendlinessFired = true;
			}
		}

		protected virtual void FireEventSpecificEffectors()
		{
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (AllParticipantsUnique.Contains(key))
				{
					continue;
				}
				string[] nonParticipantEffectors = GetNonParticipantEffectors();
				foreach (string text in nonParticipantEffectors)
				{
					if (!string.IsNullOrEmpty(text))
					{
						key.Stats.StartEffector(text);
					}
				}
			}
		}

		private void ChangeState(EventState newState)
		{
			previousState = currentState;
			currentState = newState;
			this.StateChangedEvent?.Invoke(currentState);
		}

		private void Subscribe()
		{
			MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent += RemoveParticipantFromEvent;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += RemoveParticipantFromEvent;
			MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent += RemoveAnimalFromEvent;
			if (HostBuilding != null)
			{
				HostBuilding.OnDisposedEvent += OnHostBuildingDisposed;
			}
		}

		private void Unsubscribe()
		{
			MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent -= RemoveParticipantFromEvent;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= RemoveParticipantFromEvent;
			MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent -= RemoveAnimalFromEvent;
			if (HostBuilding != null)
			{
				HostBuilding.OnDisposedEvent -= OnHostBuildingDisposed;
			}
		}

		protected void OnTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("PlayerTriggeredEventInstance.Tick"))
			{
				switch (currentState)
				{
				case EventState.NotStarted:
				case EventState.Disposed:
					break;
				case EventState.Gathering:
					if (EveryoneGathered())
					{
						Start();
						break;
					}
					remainingGatherTime -= deltaTime;
					if (remainingGatherTime <= 0f)
					{
						if (CheckedInIds.Count > 0 && CanOverrideGatheringTimeout())
						{
							Start();
						}
						else
						{
							ChangeState(EventState.Ended);
						}
					}
					break;
				case EventState.Started:
					RemainingTime -= deltaTime;
					if (RemainingTime <= 0f || AllParticipantsUnique.Count == 0)
					{
						ChangeState(EventState.Ended);
					}
					else
					{
						TickResourceSpend();
					}
					break;
				case EventState.Ended:
					MonoSingleton<SceneController>.Instance.Tick -= OnTick;
					MonoSingleton<PlayerTriggeredEventManager>.Instance.EndEvent();
					End();
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public bool CanShowView()
		{
			if (HostBuilding == null)
			{
				return false;
			}
			if (!IsInCorrectRoom(HostBuilding))
			{
				return false;
			}
			if (currentState != EventState.NotStarted)
			{
				return false;
			}
			return true;
		}

		public virtual IEnumerable<PlayerTriggeredEventInfo> IterateEventQualityInfo()
		{
			yield return GetParticipantInfo();
			yield return GetRoleInfo();
			yield return GetRoomImpressivenessInfo();
			yield return GetCooldownInfo();
		}

		protected PlayerTriggeredEventInfo GetParticipantInfo()
		{
			return GetEventInfo(Blueprint.GetEventQualitySetting("participants"), AllParticipantsUnique.Count.ToString(), AllParticipantsUnique.Count);
		}

		protected PlayerTriggeredEventInfo GetRoleInfo()
		{
			int num = 0;
			int num2 = -1;
			EventQualitySetting eventQualitySetting = Blueprint.GetEventQualitySetting("roleQuality");
			foreach (IEventParticipant item in AttendeesByType[EventAttendeeType.RoleParticipant])
			{
				if (item is HumanoidInstance { ActiveBehaviour: { } activeBehaviour })
				{
					IRoleOwner humanoidRoleOwner = activeBehaviour.HumanoidRoleOwner;
					if (humanoidRoleOwner != null)
					{
						num2 = humanoidRoleOwner.RoleInstance.Level;
						num += Mathf.RoundToInt(eventQualitySetting.GetThresholdValue(num2 + 1));
					}
				}
			}
			EventQualityValues["roleQuality"] = num;
			string status = ((num2 == -1) ? "-" : HumanoidRoleUtils.GetLevelNumeral(num2));
			return new PlayerTriggeredEventInfo(GetLabelParsedRoleName(LocKeyUtils.GetName(eventQualitySetting.LocKeys)), status, GetValueString(num) ?? "");
		}

		protected PlayerTriggeredEventInfo GetRoomImpressivenessInfo()
		{
			if (HostBuilding == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(50, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("This event ");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral(" has no host furniture. Current state: ");
					messageBuilder.AppendFormatted(currentState);
				}
				Log.Error(messageBuilder);
			}
			Room room = HostBuilding?.GetRoom();
			if (room?.Impressiveness == null)
			{
				return GetEventInfo(Blueprint.GetEventQualitySetting("roomImpressiveness"), UiUtils.Localize.GetText("general_none"), 0f);
			}
			return GetEventInfo(Blueprint.GetEventQualitySetting("roomImpressiveness"), room.Impressiveness.NameLocalized, (float)room.Impressiveness.RoomImpressLevel);
		}

		protected PlayerTriggeredEventInfo GetUniqueResourceEventInfo(KeyValuePair<string, Resource> kvp)
		{
			float num = ((!(kvp.Value == null)) ? 1 : 0);
			EventQualitySetting eventQualitySetting = Blueprint.GetEventQualitySetting("uniqueResourceCount");
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(34, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("GetUniqueResourceEventInfo ");
				messageBuilder.AppendFormatted(eventQualitySetting);
				messageBuilder.AppendLiteral(", ");
				messageBuilder.AppendFormatted(LocKeyUtils.GetName(eventQualitySetting.LocKeys).ToLocalized());
				messageBuilder.AppendLiteral("_PH, ");
				messageBuilder.AppendFormatted(num);
			}
			Log.Trace(messageBuilder);
			return GetEventInfo(Blueprint.GetEventQualitySetting("uniqueResourceCount"), $"{num}", num);
		}

		protected PlayerTriggeredEventInfo ResourceAmountPerParticipant()
		{
			int num = 0;
			foreach (KeyValuePair<Resource, int> eventResource in EventResources)
			{
				if (eventResource.Value > 0)
				{
					num += eventResource.Value;
				}
			}
			float totalByParticipant = GetTotalByParticipant(num);
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(34, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("GetResourceAmountPerParticipant ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(": ");
				messageBuilder.AppendFormatted(totalByParticipant);
			}
			Log.Debug(messageBuilder);
			return GetEventInfo(Blueprint.GetEventQualitySetting("resourceAmount"), $"{totalByParticipant:F1}", totalByParticipant);
		}

		protected PlayerTriggeredEventInfo GetCooldownInfo()
		{
			if (currentState == EventState.NotStarted)
			{
				float num = GlobalSaveController.CurrentVillageData.PlayerTriggeredEventSaveData.HoursSinceLastEventEnd(Blueprint.GetID());
				if (HasVisitorParticipant)
				{
					num = float.MaxValue;
				}
				EventQualitySetting eventQualitySetting = Blueprint.GetEventQualitySetting("eventCooldown");
				float maxThreshold = eventQualitySetting.GetMaxThreshold();
				float totalHours = Mathf.Clamp(maxThreshold - num, 0f, maxThreshold);
				string status = ((Math.Abs(num - float.MaxValue) < 0.01f) ? "∞" : ("-" + UiUtils.GetTimeFormatByHours(totalHours, isDuration: true)));
				eventCooldownInfo = GetEventInfo(eventQualitySetting, status, num);
			}
			return eventCooldownInfo;
		}

		protected PlayerTriggeredEventInfo GetEventInfo(EventQualitySetting eventQualitySetting, string status, float points)
		{
			int value = Mathf.RoundToInt(eventQualitySetting.GetThresholdValue(points));
			EventQualityValues[eventQualitySetting.GetID()] = value;
			string text = ((eventQualitySetting.GetID().Equals("eventCooldown") && HasVisitorParticipant) ? "*" : "");
			return new PlayerTriggeredEventInfo(UiUtils.Localize.GetText(LocKeyUtils.GetName(eventQualitySetting.LocKeys)) + text, status, GetValueString(value) ?? "");
		}

		public override string GetEventInfo(GameEvent.DialogContent dialogContent)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(string.Format("{0} ({1:P0})", UiUtils.Localize.GetText("end_event_general"), Mathf.Clamp(GetEventCompletionPercentage(), 0f, 1f)));
			stringBuilder.AppendLine(UiUtils.Localize.GetText("end_event_quality").Replace("<quality_outcome>", GetEstimatedEventQuality()));
			stringBuilder.AppendLine(UiUtils.Localize.GetText("end_event_participants").Replace("<all_participants>", GetParticipantNames()));
			HashSet<IEventParticipant> hashSet = AttendeesByType[EventAttendeeType.RoleParticipant];
			if (hashSet != null && hashSet.Count > 0)
			{
				stringBuilder.AppendLine(UiUtils.Localize.GetText("end_event_role_" + Blueprint.GetShortId())).Replace("<all_roles>", GetParticipantWithRoleNames());
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(UiUtils.Localize.GetText("event_quality_points_breakdown"));
			foreach (PlayerTriggeredEventInfo item in IterateEventQualityInfo())
			{
				stringBuilder.AppendLine($"{item.Label}<indent={70}%>{item.Status}</indent><indent={90}%>{item.Points}</indent>");
			}
			stringBuilder.AppendLine(string.Format("<style=AltColor>{0}<indent={1}%>{2}</indent></style>", UiUtils.Localize.GetText("event_quality_points"), 90, GetEventQualitySum()));
			stringBuilder.AppendLine();
			return stringBuilder.ToString();
		}

		private string GetParticipantNames()
		{
			using PooledList<string> pooledList = ListPool<string>.GetJanitor();
			foreach (IEventParticipant participant in GetParticipants())
			{
				if (participant is CreatureBase creatureBase)
				{
					pooledList.Add(creatureBase.GetFullName());
				}
			}
			return string.Join(", ", pooledList);
		}

		private string GetParticipantWithRoleNames()
		{
			using PooledList<string> pooledList = ListPool<string>.GetJanitor();
			foreach (IEventParticipant item in AttendeesByType[EventAttendeeType.RoleParticipant])
			{
				if (item is HumanoidInstance humanoidInstance)
				{
					IRoleOwner humanoidRoleOwner = humanoidInstance.ActiveBehaviour.HumanoidRoleOwner;
					if (humanoidRoleOwner != null)
					{
						pooledList.Add(humanoidInstance.GetFullName() + " - " + HumanoidRoleUtils.GetRoleNameWithIconAndLevel(humanoidRoleOwner.RoleInstance));
					}
				}
			}
			return string.Join(", ", pooledList);
		}

		private string GetLabelParsedRoleName(string label)
		{
			if (string.IsNullOrEmpty(Blueprint.RoleId))
			{
				return label;
			}
			if (AttendeesByType[EventAttendeeType.RoleParticipant]?.FirstOrDefault() is HumanoidInstance roleOwner)
			{
				return UiUtils.Localize.GetText(label).Replace("<role_name>", HumanoidRoleUtils.GetRoleName(Blueprint.RoleId, roleOwner));
			}
			return UiUtils.Localize.GetText(label).Replace("<role_name>", HumanoidRoleUtils.GetRoleName(Blueprint.RoleId));
		}

		protected float GetTotalByParticipant(float value)
		{
			if (GetParticipantCount() == 0)
			{
				return 0f;
			}
			return value / (float)GetParticipantCount();
		}

		protected int GetParticipantCount()
		{
			return GetParticipants().Count;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("remainingGatherTime", remainingGatherTime);
			serializer.Write("remainingTime", RemainingTime);
			serializer.Write("hostFurniture", HostBuilding);
			serializer.Write("eventQualityValues", EventQualityValues);
			serializer.Write("playerTriggeredEvent", Blueprint.GetID());
			SerializeParticipants("attendees", AttendeesByType, serializer);
			SerializeEventResourcesDict("eventResources", EventResources, serializer);
		}

		private static void SerializeParticipants(string key, Dictionary<EventAttendeeType, HashSet<IEventParticipant>> dictionary, FVSerializer serializer)
		{
			using PooledList<int> pooledList = ListPool<int>.GetJanitor(dictionary.Keys.Select((EventAttendeeType k) => (int)k));
			using PooledList<List<CreatureBase>> pooledList2 = ListPool<List<CreatureBase>>.GetJanitor(dictionary.Values.Select((HashSet<IEventParticipant> list) => list.Cast<CreatureBase>().ToList()));
			serializer.Write(key + "_keys", pooledList);
			for (int num = 0; num < pooledList.Count; num++)
			{
				serializer.Write($"{key}_{pooledList[num]}_values", pooledList2[num]);
			}
		}

		private static void SerializeEventResourcesDict(string key, Dictionary<Resource, int> dictionary, FVSerializer serializer)
		{
			using PooledList<string> pooledList = ListPool<string>.GetJanitor(dictionary.Keys.Select((Resource resource) => resource.GetID()));
			using PooledList<int> pooledList2 = ListPool<int>.GetJanitor(dictionary.Values);
			serializer.Write(key + "_keys", pooledList);
			serializer.Write(key + "_values", pooledList2);
		}

		public PlayerTriggeredEventInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			remainingGatherTime = deserializer.ReadFloat("remainingGatherTime");
			RemainingTime = deserializer.ReadFloat("remainingTime");
			HostBuilding = deserializer.ReadObject<BaseBuildingInstance>("hostFurniture");
			EventQualityValues = deserializer.ReadStringIntDict("eventQualityValues");
			AttendeesByType = DeserializeAttendeesDict("attendees", deserializer);
			EventResources = DeserializeEventResourcesDict("eventResources", deserializer);
			base.SetBlueprint(Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetByID(deserializer.ReadString("playerTriggeredEvent")));
			OnAfterDeserialize();
		}

		private void OnAfterDeserialize()
		{
			fromSave = true;
			if (HostBuilding == null)
			{
				HostBuilding = null;
				IsInvalidEvent = true;
			}
			else
			{
				ChangeState(EventState.NotStarted);
			}
		}

		private static Dictionary<EventAttendeeType, HashSet<IEventParticipant>> DeserializeAttendeesDict(string key, FVDeserializer deserializer)
		{
			Dictionary<EventAttendeeType, HashSet<IEventParticipant>> dictionary = new Dictionary<EventAttendeeType, HashSet<IEventParticipant>>();
			foreach (int item in deserializer.ReadIntList(key + "_keys", new List<int>()))
			{
				dictionary[(EventAttendeeType)item] = DeserializeParticipants(key, item, deserializer);
			}
			if (dictionary.Count == 0)
			{
				return DeserializeOldParticipants(dictionary, deserializer);
			}
			return dictionary;
		}

		private static Dictionary<EventAttendeeType, HashSet<IEventParticipant>> DeserializeOldParticipants(Dictionary<EventAttendeeType, HashSet<IEventParticipant>> dictionary, FVDeserializer deserializer)
		{
			if (!dictionary.ContainsKey(EventAttendeeType.Participant))
			{
				List<CreatureBase> list = deserializer.ReadObjectList<CreatureBase>("participants");
				if (list != null)
				{
					dictionary[EventAttendeeType.Participant] = new HashSet<IEventParticipant>(list.Cast<IEventParticipant>());
					Log.Debug("Found old data for participants", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				}
			}
			if (!dictionary.ContainsKey(EventAttendeeType.RoleParticipant))
			{
				List<CreatureBase> list2 = deserializer.ReadObjectList<CreatureBase>("participantsWithRole");
				if (list2 != null)
				{
					dictionary[EventAttendeeType.RoleParticipant] = new HashSet<IEventParticipant>(list2.Cast<IEventParticipant>());
					Log.Debug("Found old data for participantsWithRole", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				}
			}
			if (!dictionary.ContainsKey(EventAttendeeType.AnimalParticipant))
			{
				List<CreatureBase> list3 = deserializer.ReadObjectList<CreatureBase>("eventAnimals");
				if (list3 != null)
				{
					dictionary[EventAttendeeType.AnimalParticipant] = new HashSet<IEventParticipant>(list3.Cast<IEventParticipant>());
					Log.Debug("Found old data for eventAnimals", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				}
			}
			return dictionary;
		}

		private static HashSet<IEventParticipant> DeserializeParticipants(string key, int index, FVDeserializer deserializer)
		{
			HashSet<IEventParticipant> hashSet = new HashSet<IEventParticipant>();
			List<CreatureBase> list = deserializer.ReadObjectList<CreatureBase>($"{key}_{index}_values");
			if (list == null)
			{
				return hashSet;
			}
			foreach (CreatureBase item2 in list)
			{
				if (!(item2 is IEventParticipant item))
				{
					throw new Exception("Corrupted save data, participant with id " + item2.GetFullName() + " is not IEventParticipant)");
				}
				hashSet.Add(item);
			}
			return hashSet;
		}

		private static Dictionary<Resource, int> DeserializeEventResourcesDict(string key, FVDeserializer deserializer)
		{
			List<string> list = deserializer.ReadStringList(key + "_keys", new List<string>());
			List<int> list2 = deserializer.ReadIntList(key + "_values", new List<int>());
			if (list.Count != list2.Count)
			{
				throw new Exception($"Corrupted save data, keys and values must be of same length (keys is {list.Count}, values is {list2.Count})");
			}
			Dictionary<Resource, int> dictionary = new Dictionary<Resource, int>();
			for (int i = 0; i < list.Count; i++)
			{
				Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(list[i]);
				if (!(byID == null))
				{
					dictionary[byID] = list2[i];
				}
			}
			return dictionary;
		}

		private void LogInfo()
		{
			if (Blueprint == null)
			{
				Log.Error("Blueprint is null", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				return;
			}
			if (AttendeesByType == null)
			{
				Log.Error("Participants list is null", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				return;
			}
			if (EventResources == null)
			{
				Log.Error("EventResources dictionary is null", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				return;
			}
			if (EventQualityValues == null)
			{
				Log.Error("EventQualityValues dictionary is null", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				return;
			}
			if (EventPositions == null)
			{
				Log.Error("EventPositions dictionary is null", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				return;
			}
			if (HostBuilding == null)
			{
				Log.Error("Host furniture is null", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				return;
			}
			if (hungerAgentsCache == null)
			{
				Log.Error("Hunger agents cache is null", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
				return;
			}
			string t = (IsRoomRequired ? $"in {HostBuilding.GetRoom()}" : "no room required");
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(61, 5, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(currentState);
				messageBuilder.AppendLiteral(" event ");
				messageBuilder.AppendFormatted(Blueprint.GetID());
				messageBuilder.AppendLiteral(" with ");
				messageBuilder.AppendFormatted(GetParticipants()?.Count);
				messageBuilder.AppendLiteral(" participants and ");
				messageBuilder.AppendFormatted(AttendeesByType[EventAttendeeType.AnimalParticipant]?.Count);
				messageBuilder.AppendLiteral(" animals. Role participants: ");
				messageBuilder.AppendFormatted(AttendeesByType[EventAttendeeType.RoleParticipant]?.Count);
				messageBuilder.AppendLiteral(".");
			}
			Log.Info(messageBuilder);
			messageBuilder = new FVLogInfoInterpolationHandler(22, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Host furniture: ");
				messageBuilder.AppendFormatted(HostBuilding.BlueprintId);
				messageBuilder.AppendLiteral(" at ");
				messageBuilder.AppendFormatted(HostBuilding.GetGridPosition());
				messageBuilder.AppendLiteral(", ");
				messageBuilder.AppendFormatted(t);
			}
			Log.Info(messageBuilder);
			messageBuilder = new FVLogInfoInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Stored resources: ");
				messageBuilder.AppendFormatted(string.Join(", ", from re in GetDisplayEventResources()
					select re.Info ?? ""));
			}
			Log.Info(messageBuilder);
		}
	}
}
