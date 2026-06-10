using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class EventScheduler : MonoSingleton<EventScheduler>
	{
		private const string RaidEventGroupName = "raid";

		private const string DefaultScheduleName = "default_1";

		private StartingEventSchedule startingEventSchedule;

		private List<EventGroupInstance> eventGroups = new List<EventGroupInstance>();

		private Dictionary<string, EventGroupInstance> eventGroupsByName = new Dictionary<string, EventGroupInstance>();

		private bool init;

		private uint daysTotal;

		public IWorkersCountProvider WorkersCountProvider { get; set; }

		public bool IsStarted { get; private set; }

		public uint DaysTotal => daysTotal;

		public List<EventGroupInstance> EventGroups
		{
			get
			{
				CheckInit();
				return eventGroups;
			}
		}

		private Dictionary<string, EventGroupInstance> EventGroupsByName
		{
			get
			{
				CheckInit();
				return eventGroupsByName;
			}
		}

		private Dictionary<string, long> ScheduledEvents => GlobalSaveController.CurrentVillageData.ScheduledGameEvents;

		public StartingEventSchedule EventSchedule
		{
			get
			{
				if (startingEventSchedule != null)
				{
					return startingEventSchedule;
				}
				string text = GlobalSaveController.CurrentVillageData.Scenario.StartingEventScheduleId;
				if (string.IsNullOrEmpty(text))
				{
					text = "default_1";
				}
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(0, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(text);
				}
				Log.Trace(messageBuilder);
				startingEventSchedule = Repository<StartingEventsRepository, StartingEventSchedule>.Instance.GetByID(text);
				return startingEventSchedule;
			}
		}

		public void CheckInit()
		{
			if (init)
			{
				return;
			}
			init = true;
			foreach (EventGroup allItem in Repository<EventGroupRepository, EventGroup>.Instance.GetAllItems())
			{
				EventGroupInstance eventGroupInstance = new EventGroupInstance(allItem);
				eventGroups.Add(eventGroupInstance);
				eventGroupsByName.Add(allItem.GetID(), eventGroupInstance);
			}
		}

		public bool ShouldOverrideCurrentEvent()
		{
			Log.Trace("Should override", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
			return daysTotal < EventSchedule.PredefinedEvents.Count;
		}

		public EventGroupInstance GetOverrideEvent()
		{
			if (daysTotal < EventSchedule.PredefinedEvents.Count)
			{
				string groupName = EventSchedule.PredefinedEvents[(int)daysTotal];
				return GetEventGroup(groupName);
			}
			return null;
		}

		public EventGroupInstance GetGroupToSchedule()
		{
			if (ShouldOverrideCurrentEvent())
			{
				return GetOverrideEvent();
			}
			if (GlobalSaveController.CurrentVillageData.SiegeComebackCount > 0 && GlobalSaveController.CurrentVillageData.SiegeComebackCount < 3)
			{
				Log.Info("Siege comeback because the previous was not successful", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
				return eventGroupsByName["raid"];
			}
			return GetRandomEventGroup();
		}

		public void IncDaysPast(int number = 1)
		{
			foreach (EventGroupInstance eventGroup in EventGroups)
			{
				eventGroup.DaysPast += number;
			}
		}

		public void OnDateUpdate()
		{
			Log.Trace("OnDateUpdate()", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
			IncDaysPast();
			daysTotal = GlobalSaveController.CurrentVillageData.DateAndTime.DaysTotal;
			if (MonoSingleton<GameEventSystem>.Instance.IsBlockingEventRunning())
			{
				Log.Debug("Skipping scheduling because a game event is running", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
			}
			else if (GlobalSaveController.CurrentVillageData.Raids.Any((ActiveRaidInfo raid) => !raid.HasEnded))
			{
				Log.Debug("Skipping scheduling because raid is running", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
			}
			else if (!GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				EventGroupInstance groupToSchedule = GetGroupToSchedule();
				if (groupToSchedule != null)
				{
					ScheduleEventGroup(groupToSchedule, GetRandomEventTime());
				}
			}
		}

		public float GetAllValues()
		{
			float num = 0f;
			int workersCount = GetWorkersCount();
			int count = MonoSingleton<CaptiveNpcManager>.Instance.PlayersCaptives.Count;
			foreach (EventGroupInstance eventGroup in EventGroups)
			{
				num += eventGroup.GetValue(workersCount, count);
			}
			return num;
		}

		public EventGroupInstance GetEventGroup(string groupName)
		{
			if (string.IsNullOrEmpty(groupName) || !EventGroupsByName.ContainsKey(groupName))
			{
				return null;
			}
			return EventGroupsByName[groupName];
		}

		public float GetValue(EventGroupInstance eventGroup)
		{
			return eventGroup.GetValue(GetWorkersCount(), MonoSingleton<CaptiveNpcManager>.Instance.PlayersCaptives.Count);
		}

		private EventGroupInstance GetRandomEventGroup()
		{
			int workersCount = GetWorkersCount();
			int count = MonoSingleton<CaptiveNpcManager>.Instance.PlayersCaptives.Count;
			float allValues = GetAllValues();
			float num = UnityEngine.Random.Range(0f, allValues);
			foreach (EventGroupInstance eventGroup in EventGroups)
			{
				if (!string.IsNullOrEmpty(eventGroup.Blueprint.DifficultyOptionId) && !IsEnabledInGameParameters(eventGroup.Blueprint.DifficultyOptionId))
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(50, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(eventGroup.Blueprint.GetID());
						messageBuilder.AppendLiteral(" skipped because od Difficulty Options setting: '");
						messageBuilder.AppendFormatted(eventGroup.Blueprint.DifficultyOptionId);
						messageBuilder.AppendLiteral("'");
					}
					Log.Info(messageBuilder);
					continue;
				}
				float value = eventGroup.GetValue(workersCount, count);
				if (!(value <= 0f))
				{
					if (num <= value)
					{
						return eventGroup;
					}
					num -= value;
				}
			}
			return null;
		}

		public void ScheduleEventGroup(EventGroupInstance e, long time)
		{
			bool isEnabled;
			if (IsGroupScheduled(e))
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Event group already scheduled: ");
					messageBuilder.AppendFormatted(e.Blueprint.GetID());
				}
				Log.Info(messageBuilder);
				return;
			}
			e.ResetDaysPastCounters();
			bool flag = false;
			using (IEnumerator<GameEvent> enumerator = e.Blueprint.GameEvents.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					flag = true;
				}
			}
			FVLogDebugInterpolationHandler messageBuilder2;
			if (!flag)
			{
				messageBuilder2 = new FVLogDebugInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("No GameEvents in Blueprint ");
					messageBuilder2.AppendFormatted(e.Blueprint.GetID());
				}
				Log.Debug(messageBuilder2);
				return;
			}
			messageBuilder2 = new FVLogDebugInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Scheduling event group: ");
				messageBuilder2.AppendFormatted(e.Blueprint.GetID());
				messageBuilder2.AppendLiteral(" at ");
				messageBuilder2.AppendFormatted(time);
				messageBuilder2.AppendLiteral(" ");
			}
			Log.Debug(messageBuilder2);
			if (!e.Blueprint.GetID().Equals("raid"))
			{
				GlobalSaveController.CurrentVillageData.SiegeComebackCount = 0;
				GlobalSaveController.CurrentVillageData.LastEventWasSiege = false;
			}
			AddToScheduledEvents(e, time);
		}

		private long GetRandomEventTime()
		{
			float num = UnityEngine.Random.Range(0f, 1f);
			return (long)((Mathf.Pow(num - 0.5f, 2f) * Mathf.Sign(num) * 2f + 0.5f) * (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInDay) + GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal;
		}

		private int GetWorkersCount()
		{
			return WorkersCountProvider.GetWorkersCount();
		}

		private void Start()
		{
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
			MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent += OnTimeUpdate;
			MonoSingleton<RaidController>.Instance.RaidEndedEvent += OnRaidEndedEvent;
			IsStarted = true;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateUpdate;
				MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent -= OnTimeUpdate;
			}
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.RaidEndedEvent -= OnRaidEndedEvent;
			}
		}

		private void OnRaidEndedEvent(ActiveRaidInfo info)
		{
			GlobalSaveController.CurrentVillageData.LastEventWasSiege = info.IsSiege;
			if (info.IsSiege)
			{
				GlobalSaveController.CurrentVillageData.LastSiegeSucceeded = !info.Won;
			}
			else
			{
				GlobalSaveController.CurrentVillageData.LastSiegeSucceeded = false;
			}
			if (GlobalSaveController.CurrentVillageData.LastEventWasSiege && !GlobalSaveController.CurrentVillageData.LastSiegeSucceeded)
			{
				GlobalSaveController.CurrentVillageData.SiegeComebackCount++;
			}
			else
			{
				GlobalSaveController.CurrentVillageData.SiegeComebackCount = 0;
			}
		}

		private void OnTimeUpdate()
		{
			if (!MonoSingleton<GameEventSystem>.IsInstantiated() || MonoSingleton<GameEventSystem>.Instance.IsBlockingEventRunning())
			{
				return;
			}
			foreach (EventGroupInstance eventGroup in EventGroups)
			{
				if (!ScheduledEvents.ContainsKey(eventGroup.Blueprint.GetID()) || GetScheduledEventRemainingTime(eventGroup) > 0)
				{
					continue;
				}
				RemoveFromScheduledEvents(eventGroup);
				GameEvent eventToStart = eventGroup.Blueprint.GetEventToStart();
				if (eventToStart == null)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\EventScheduler.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("No events chosen from group ");
						messageBuilder.AppendFormatted(eventGroup.Blueprint.GetID());
						messageBuilder.AppendLiteral(". Not spawning any events.");
					}
					Log.Info(messageBuilder);
				}
				else
				{
					MonoSingleton<GameEventSystem>.Instance.StartEvent(eventToStart.GetID());
				}
				break;
			}
		}

		private bool IsGroupScheduled(EventGroupInstance e)
		{
			return ScheduledEvents.ContainsKey(e.Blueprint.GetID());
		}

		private void AddToScheduledEvents(EventGroupInstance e, long scheduledTime)
		{
			if (!ScheduledEvents.ContainsKey(e.Blueprint.GetID()))
			{
				ScheduledEvents.Add(e.Blueprint.GetID(), scheduledTime);
			}
		}

		private void RemoveFromScheduledEvents(EventGroupInstance e)
		{
			if (ScheduledEvents.ContainsKey(e.Blueprint.GetID()))
			{
				ScheduledEvents.Remove(e.Blueprint.GetID());
			}
		}

		private int GetScheduledEventRemainingTime(EventGroupInstance e)
		{
			return (int)(ScheduledEvents[e.Blueprint.GetID()] - GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal);
		}

		private bool IsEnabledInGameParameters(string difficultyOptionId)
		{
			return GlobalSaveController.CurrentVillageData.GameParametersCurrent.GetById(difficultyOptionId) > 0.5f;
		}
	}
}
