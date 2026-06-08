using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class EventController : MonoBehaviour
{
	[Serializable]
	public class EventData
	{
		public string id;

		public string name;

		public string description;

		public string iconPath;

		public string rewardsPath;

		public bool showPreCountdown = true;

		public bool showTimeRemaining = true;

		public string unlockEpicQuest;

		public string[] preEventInfo;

		public string[] info;

		public string music;

		public string uniqueLocation;

		public float uniqueCoeficient;

		public bool qualityOverQuantity;

		public bool rewindProtection;

		public EventData Copy()
		{
			return new EventData
			{
				id = id,
				name = name,
				description = description,
				iconPath = iconPath,
				rewardsPath = rewardsPath,
				showPreCountdown = showPreCountdown,
				showTimeRemaining = showTimeRemaining,
				unlockEpicQuest = unlockEpicQuest,
				preEventInfo = preEventInfo,
				info = info,
				music = music,
				uniqueLocation = uniqueLocation,
				uniqueCoeficient = uniqueCoeficient,
				qualityOverQuantity = qualityOverQuantity,
				rewindProtection = rewindProtection
			};
		}

		public bool IsProtectingFromRewind()
		{
			if (rewindProtection)
			{
				return HeroSettings.lastSaveTime - DateTime.Now > ONE_DAY;
			}
			return false;
		}

		public static EventData FromString(string sjson)
		{
			EventData eventData = new EventData();
			eventData.id = SlimJson.Parse(sjson, "id");
			eventData.name = SlimJson.Parse(sjson, "na", "");
			eventData.description = SlimJson.Parse(sjson, "de", "");
			eventData.iconPath = SlimJson.Parse(sjson, "ic", "");
			eventData.rewardsPath = SlimJson.Parse(sjson, "re", "");
			eventData.showPreCountdown = SlimJson.ParseBool(sjson, "sPC", defaultValue: true);
			eventData.showTimeRemaining = SlimJson.ParseBool(sjson, "sTR", defaultValue: true);
			eventData.unlockEpicQuest = SlimJson.Parse(sjson, "uEQ", "");
			eventData.music = SlimJson.Parse(sjson, "mu", "");
			eventData.uniqueLocation = SlimJson.Parse(sjson, "uL", "");
			eventData.uniqueCoeficient = SlimJson.ParseFloat(sjson, "uC");
			eventData.qualityOverQuantity = SlimJson.ParseBool(sjson, "qOQ");
			eventData.rewindProtection = SlimJson.ParseBool(sjson, "rP");
			eventData.preEventInfo = SlimJson.ParseArray(sjson, "preI");
			if (eventData.preEventInfo == null)
			{
				eventData.preEventInfo = new string[0];
			}
			eventData.info = SlimJson.ParseArray(sjson, "info");
			if (eventData.info == null)
			{
				eventData.info = new string[0];
			}
			return eventData;
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			if (!string.IsNullOrEmpty(name))
			{
				SlimJson.AddProperty("na", name);
			}
			if (!string.IsNullOrEmpty(description))
			{
				SlimJson.AddProperty("de", description);
			}
			if (!string.IsNullOrEmpty(iconPath))
			{
				SlimJson.AddProperty("ic", iconPath);
			}
			if (!string.IsNullOrEmpty(rewardsPath))
			{
				SlimJson.AddProperty("re", rewardsPath);
			}
			if (!showPreCountdown)
			{
				SlimJson.AddProperty("sPC", showPreCountdown);
			}
			if (!showTimeRemaining)
			{
				SlimJson.AddProperty("sTR", showTimeRemaining);
			}
			if (!string.IsNullOrEmpty(unlockEpicQuest))
			{
				SlimJson.AddProperty("uEQ", unlockEpicQuest);
			}
			if (!string.IsNullOrEmpty(music))
			{
				SlimJson.AddProperty("mu", music);
			}
			if (!string.IsNullOrEmpty(uniqueLocation))
			{
				SlimJson.AddProperty("uL", uniqueLocation);
			}
			if (uniqueCoeficient != 0f)
			{
				SlimJson.AddProperty("uC", uniqueCoeficient);
			}
			if (qualityOverQuantity)
			{
				SlimJson.AddProperty("qOQ", qualityOverQuantity);
			}
			if (rewindProtection)
			{
				SlimJson.AddProperty("rP", rewindProtection);
			}
			SlimJson.AddProperty("preI", preEventInfo);
			SlimJson.AddProperty("info", info);
			return SlimJson.EndSerialization();
		}
	}

	private const int DEBUG_FORCE_PART_NUMBER = -1;

	private readonly int TICKET_COST_NUM = 30;

	public static SafeInt TICKET_COST;

	private static TimeSpan ONE_DAY = new TimeSpan(24, 0, 0);

	public EventData[] events;

	private Dictionary<string, EventData> dataDict = new Dictionary<string, EventData>();

	private Dictionary<string, EventData> preEventDict = new Dictionary<string, EventData>();

	private List<BaseEventController2> activeControllers = new List<BaseEventController2>();

	private HashSet<string> yearsCompleted = new HashSet<string>();

	private List<EventData> lastEventList;

	private float lastEventListRealTime = -99f;

	private EventData lastCurrentEvent;

	private float lastCurrentEventRealTime = -99f;

	private bool _progressLoaded;

	public static EventController singleton { get; private set; }

	public BaseEventController2 GetEventController(string eventId)
	{
		BaseEventController2 baseEventController = null;
		switch (eventId)
		{
		case "winter":
			baseEventController = WinterEventController.singleton;
			break;
		case "hoh":
			baseEventController = HeadOverHeelsEventController.singleton;
			break;
		case "nagaraja_2x":
			baseEventController = Nagaraja2xEventController.singleton;
			break;
		case "towering":
			baseEventController = ToweringEventController.singleton;
			break;
		case "spring":
			baseEventController = SpringEventController.singleton;
			break;
		case "aether_talisman":
			baseEventController = AetherTalismanEventController.singleton;
			break;
		}
		if (baseEventController == null)
		{
			Utils.LogWarningIfEditor("Could not find controller for event: " + eventId);
		}
		else if (!activeControllers.Contains(baseEventController))
		{
			activeControllers.Add(baseEventController);
		}
		return baseEventController;
	}

	public List<EventData> GetEventList(int maxEvents)
	{
		if ((bool)RemoteVersionCheckController.singleton && RemoteVersionCheckController.singleton.newVersionAvailable)
		{
			EventData eventData = FindEventById("new_version");
			if (eventData != null)
			{
				string text = eventData.info[5];
				string newValue = RemoteVersionCheckController.singleton.newVersionValue.ToString();
				text = text.Replace("1.2.3", newValue);
				eventData.info[5] = text;
				return new List<EventData> { eventData };
			}
			Utils.LogErrorIfEditor("Couldn't find event data 'new_version'.");
		}
		if (lastEventList == null || lastEventListRealTime + 1f < Time.realtimeSinceStartup)
		{
			lastEventListRealTime = Time.realtimeSinceStartup;
			List<EventData> list = (lastEventList = new List<EventData>());
			if (CanPlayerSeeEvents())
			{
				foreach (string @event in EventSchedules.singleton.GetEventList(maxEvents))
				{
					if (@event == null)
					{
						continue;
					}
					EventData eventData2 = FindEventById(@event);
					if (eventData2 != null)
					{
						list.Add(eventData2);
						continue;
					}
					string eventId = @event.Substring(0, @event.Length - 1);
					eventData2 = FindEventById(eventId);
					if (eventData2 != null)
					{
						eventData2 = AddDuplicateEventData(eventData2, @event);
						list.Add(eventData2);
					}
					else
					{
						Utils.LogErrorIfEditor("Event " + @event + " is active, but there's no event data.");
					}
				}
				for (int i = 0; i < list.Count; i++)
				{
					GetEventController(list[i].id);
				}
				return list;
			}
		}
		return lastEventList;
	}

	public EventData GetCurrentEvent()
	{
		if ((bool)RemoteVersionCheckController.singleton && RemoteVersionCheckController.singleton.newVersionAvailable)
		{
			EventData eventData = FindEventById("new_version");
			if (eventData != null)
			{
				string text = eventData.info[5];
				string newValue = RemoteVersionCheckController.singleton.newVersionValue.ToString();
				text = text.Replace("1.2.3", newValue);
				eventData.info[5] = text;
				return eventData;
			}
			Utils.LogErrorIfEditor("Couldn't find event data 'new_version'.");
		}
		if (lastCurrentEventRealTime + 1f < Time.realtimeSinceStartup)
		{
			lastCurrentEventRealTime = Time.realtimeSinceStartup;
			lastCurrentEvent = null;
			if (CanPlayerSeeEvents())
			{
				string currentEvent = EventSchedules.singleton.GetCurrentEvent();
				if (currentEvent != null)
				{
					EventData eventData2 = FindEventById(currentEvent);
					if (eventData2 != null)
					{
						lastCurrentEvent = eventData2;
						return eventData2;
					}
					string eventId = currentEvent.Substring(0, currentEvent.Length - 1);
					eventData2 = FindEventById(eventId);
					if (eventData2 != null)
					{
						return lastCurrentEvent = AddDuplicateEventData(eventData2, currentEvent);
					}
					Utils.LogErrorIfEditor("Event " + currentEvent + " is active, but there's no event data.");
				}
				return null;
			}
		}
		return lastCurrentEvent;
	}

	public EventData GetActiveAndStartedEvent()
	{
		BaseEventController2 activeEventController = GetActiveEventController();
		if (activeEventController != null && activeEventController.HasEventStarted() && !activeEventController.HasEventEnded())
		{
			return FindEventById(activeEventController.GetEventId());
		}
		return null;
	}

	public bool IsEventActiveAndStarted(string eventId)
	{
		if (IsEventActive(eventId))
		{
			BaseEventController2 eventController = singleton.GetEventController(eventId);
			if (eventController == null || (eventController.HasEventStarted() && !eventController.HasEventEnded()))
			{
				return true;
			}
		}
		return false;
	}

	public EventData FindEventById(string eventId)
	{
		if (dataDict.ContainsKey(eventId))
		{
			EventData eventData = dataDict[eventId];
			if (!eventData.IsProtectingFromRewind())
			{
				return eventData;
			}
		}
		if (preEventDict.ContainsKey(eventId))
		{
			EventData eventData2 = preEventDict[eventId];
			if (!eventData2.IsProtectingFromRewind())
			{
				return eventData2;
			}
		}
		return null;
	}

	public void FindEventAsync(string eventId, Action<EventData> callback)
	{
		EventData eventData = FindEventById(eventId);
		if (eventData != null)
		{
			callback(eventData);
		}
		else if (RemoteEventDataController.singleton != null && RemoteEventDataController.singleton.isLoading)
		{
			RemoteEventDataController.singleton.OnLoadingComplete += delegate
			{
				EventData eventData2 = FindEventById(eventId);
				if (eventData2 != null)
				{
					callback(eventData2);
				}
				else
				{
					Debug.LogError("FindEventAsync[1]: Failed to locate event data for " + eventId);
				}
			};
		}
		else
		{
			Debug.LogError("FindEventAsync[2]: Failed to locate event data for " + eventId);
		}
	}

	public bool IsObjectiveActive(string objectiveId)
	{
		BaseEventController2 activeEventController = GetActiveEventController();
		if (activeEventController != null && activeEventController.HasEventStarted() && !activeEventController.HasEventEnded())
		{
			return activeEventController.objectives.IsObjectiveActive(objectiveId);
		}
		return false;
	}

	public bool IsPreventingLocationStatsUpdate()
	{
		BaseEventController2 activeEventController = GetActiveEventController();
		if (activeEventController != null && activeEventController.HasEventStarted() && !activeEventController.HasEventEnded())
		{
			return activeEventController.objectives.IsPreventingLocationStatsUpdate();
		}
		return false;
	}

	private EventData AddDuplicateEventData(EventData originalData, string newId)
	{
		EventData eventData = originalData.Copy();
		eventData.id = newId;
		if (newId.StartsWith("pre_"))
		{
			preEventDict.Add(newId, eventData);
		}
		else
		{
			dataDict.Add(newId, eventData);
		}
		return eventData;
	}

	public bool IsEventActive(string eventId)
	{
		if (EventSchedules.singleton.IsEventActive(eventId))
		{
			if (dataDict.ContainsKey(eventId))
			{
				EventData eventData = dataDict[eventId];
				if (eventData != null && eventData.IsProtectingFromRewind())
				{
					return false;
				}
			}
			return true;
		}
		int duplicateIdCount = EventSchedules.singleton.GetDuplicateIdCount(eventId);
		for (int i = 1; i < duplicateIdCount; i++)
		{
			if (IsEventActive(eventId + i))
			{
				return true;
			}
		}
		return false;
	}

	public bool CanPlayerSeeEvents()
	{
		List<SaveFiles.SaveFileMeta> directory = SaveFiles.singleton.GetDirectory();
		for (int i = 0; i < directory.Count; i++)
		{
			if (directory[i].bigHead || directory[i].hasQuestStone || directory[i].totalStars >= 19)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsProgressLoaded()
	{
		return _progressLoaded;
	}

	public int GetProgress(string key, int defaultValue)
	{
		return defaultValue;
	}

	public void SetProgress(string key, int value)
	{
	}

	public void SetReward(string key)
	{
	}

	public bool HasReceivedReward(string eventId)
	{
		return true;
	}

	public bool HasCompletedYear(string eventId, int year)
	{
		string item = eventId + year;
		return yearsCompleted.Contains(item);
	}

	public void SetCompletedYear(string eventId, int year)
	{
		string item = eventId + year;
		if (!yearsCompleted.Contains(item))
		{
			yearsCompleted.Add(item);
		}
	}

	public BaseEventController2 GetPendingRewardsEventController()
	{
		for (int i = 0; i < activeControllers.Count; i++)
		{
			BaseEventController2 baseEventController = activeControllers[i];
			if (baseEventController.CanBeCollected())
			{
				return baseEventController;
			}
		}
		return null;
	}

	public BaseEventController2 GetActiveEventController()
	{
		for (int i = 0; i < activeControllers.Count; i++)
		{
			BaseEventController2 baseEventController = activeControllers[i];
			if (EventSchedules.singleton.IsEventActive(baseEventController.GetEventId()))
			{
				return baseEventController;
			}
		}
		return null;
	}

	public int GetCurrentEventRewardBonus()
	{
		return GetActiveEventController()?.rewardBonus ?? 0;
	}

	public int GetCurrentEventRewardLevel()
	{
		return GetActiveEventController()?.rewardLevel ?? 0;
	}

	public int GetEventRarityBonus(string eventId)
	{
		return GetEventController(eventId)?.rewardBonus ?? 0;
	}

	public int GetEventRewardLevel(string eventId)
	{
		return GetEventController(eventId)?.rewardLevel ?? 0;
	}

	public int GetEventPart(string eventId)
	{
		return GetEventController(eventId)?.part ?? 0;
	}

	public void UnlockEpicQuestIfNeeded()
	{
		EventData currentEvent = GetCurrentEvent();
		if (currentEvent == null)
		{
			return;
		}
		string epicQuestId = currentEvent.unlockEpicQuest;
		if (string.IsNullOrEmpty(epicQuestId))
		{
			return;
		}
		CustomQuestsController customQuestsController = CustomQuestsController.Singleton;
		if (customQuestsController.ftueStep >= CustomQuestsController.FTUEStep.CompleteFirstBasicQuest)
		{
			Data.CustomQuest customQuest = customQuestsController.QuestDefinitions.Find((Data.CustomQuest qd) => qd.id == epicQuestId);
			if (customQuest != null)
			{
				customQuestsController.UnlockQuest(customQuest);
			}
			else
			{
				Debug.LogError("Could not unlock epic quest " + epicQuestId + " for event");
			}
		}
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		List<string> list = new List<string>();
		for (int i = 0; i < activeControllers.Count; i++)
		{
			BaseEventController2 baseEventController = activeControllers[i];
			if (baseEventController.HasEventStarted())
			{
				list.Add(baseEventController.GetEventId());
				SlimJson.AddProperty(baseEventController.GetEventId(), baseEventController.Serialize());
			}
		}
		SlimJson.AddProperty("sIds", list.ToArray());
		if (yearsCompleted.Count > 0)
		{
			string[] array = new string[yearsCompleted.Count];
			yearsCompleted.CopyTo(array);
			SlimJson.AddProperty("years", array);
		}
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson != null)
		{
			string[] array = SlimJson.ParseArray(sjson, "sIds");
			if (array != null)
			{
				foreach (string text in array)
				{
					BaseEventController2 eventController = GetEventController(text);
					string sjson2 = SlimJson.Parse(sjson, text);
					eventController.Parse(sjson2);
				}
			}
			string[] array2 = SlimJson.ParseArray(sjson, "years");
			if (array2 != null)
			{
				yearsCompleted = new HashSet<string>(array2);
			}
		}
		_progressLoaded = true;
	}

	public void ClearProgress()
	{
		for (int i = 0; i < activeControllers.Count; i++)
		{
			activeControllers[i].ClearProgress();
		}
		yearsCompleted.Clear();
		_progressLoaded = false;
	}

	private void Initialize()
	{
		RemoteEventDataController remoteEventDataController = RemoteEventDataController.singleton;
		if (remoteEventDataController != null && remoteEventDataController.remoteData != null && remoteEventDataController.remoteData.events != null)
		{
			events = remoteEventDataController.remoteData.events;
		}
		for (int i = 0; i < events.Length; i++)
		{
			EventData eventData = events[i];
			if (dataDict.ContainsKey(eventData.id))
			{
				Utils.LogWarningIfEditor("Duplicate event data for [" + i + "] " + eventData.id);
				continue;
			}
			dataDict.Add(eventData.id, eventData);
			if (eventData.preEventInfo != null && eventData.preEventInfo.Length != 0)
			{
				EventData eventData2 = new EventData();
				eventData2.id = "pre_" + eventData.id;
				eventData2.showTimeRemaining = eventData.showPreCountdown;
				eventData2.info = eventData.preEventInfo;
				eventData2.rewindProtection = eventData.rewindProtection;
				preEventDict.Add(eventData2.id, eventData2);
			}
		}
	}

	private void Awake()
	{
		singleton = this;
		TICKET_COST = new SafeInt(TICKET_COST_NUM);
		if (RemoteEventDataController.singleton != null && RemoteEventDataController.singleton.isLoading)
		{
			RemoteEventDataController.singleton.OnLoadingComplete += delegate
			{
				Initialize();
			};
		}
		else
		{
			Initialize();
		}
	}

	public string DiagnosticsString()
	{
		DateTime now = DateTime.Now;
		int day = now.Day;
		int month = now.Month;
		int year = now.Year;
		string text = year + "/" + month + "/" + day;
		EventData activeAndStartedEvent = GetActiveAndStartedEvent();
		if (activeAndStartedEvent != null)
		{
			DateTime dateTimeEnd = EventSchedules.singleton.GetDateTimeEnd(activeAndStartedEvent.id);
			text = text + ", " + Math.Floor((dateTimeEnd - DateTime.Now).TotalSeconds);
		}
		return text;
	}
}
