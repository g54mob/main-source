using System;
using System.Collections.Generic;
using System.Linq;
using NSMedieval.Serialization;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[FVSerializableKey("PlayerTriggeredEventSaveData", "")]
	public class PlayerTriggeredEventSaveData : IFVSerializable
	{
		private readonly List<PlayerTriggeredEventInstance> previousPlayerTriggeredEvents;

		private PlayerTriggeredEventInstance runningPlayerTriggeredEvent;

		private uint timeOfLastEventEnd;

		private Dictionary<string, float> eventEndTimes;

		private readonly HashSet<string> shownEventIds = new HashSet<string>();

		public PlayerTriggeredEventSaveData()
		{
			previousPlayerTriggeredEvents = new List<PlayerTriggeredEventInstance>();
			eventEndTimes = new Dictionary<string, float>();
		}

		public void AddRunningEvent(PlayerTriggeredEventInstance eventInstance)
		{
			runningPlayerTriggeredEvent = eventInstance;
		}

		public void RemoveRunningEvent(PlayerTriggeredEventInstance eventInstance, uint hoursTotalOverride = uint.MaxValue)
		{
			previousPlayerTriggeredEvents.Add(eventInstance);
			runningPlayerTriggeredEvent = null;
			timeOfLastEventEnd = ((hoursTotalOverride == uint.MaxValue) ? GlobalSaveController.CurrentVillageData.DateAndTime.HoursTotal : hoursTotalOverride);
			if (!eventEndTimes.TryAdd(eventInstance.Blueprint.GetID(), timeOfLastEventEnd))
			{
				eventEndTimes[eventInstance.Blueprint.GetID()] = timeOfLastEventEnd;
			}
		}

		public bool GetRunningEvent(out PlayerTriggeredEventInstance playerTriggeredEventInstance)
		{
			playerTriggeredEventInstance = runningPlayerTriggeredEvent;
			return playerTriggeredEventInstance != null;
		}

		public float HoursSinceLastEventEnd(string eventBlueprintId)
		{
			eventEndTimes.TryAdd(eventBlueprintId, 0f);
			if (eventEndTimes[eventBlueprintId] == 0f)
			{
				return float.MaxValue;
			}
			return (float)GlobalSaveController.CurrentVillageData.DateAndTime.HoursTotal - eventEndTimes[eventBlueprintId];
		}

		public float HoursSinceLastEventEndGlobal()
		{
			if (timeOfLastEventEnd == 0)
			{
				return float.MaxValue;
			}
			return GlobalSaveController.CurrentVillageData.DateAndTime.HoursTotal - timeOfLastEventEnd;
		}

		public void TrySetViewShown(string eventId)
		{
			if (!IsEventViewShown(eventId))
			{
				shownEventIds.Add(eventId);
			}
		}

		public bool IsEventViewShown(string eventId)
		{
			return shownEventIds.Contains(eventId);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("runningPlayerTriggeredEvent", runningPlayerTriggeredEvent);
			serializer.Write("timeOfLastEventEnd", timeOfLastEventEnd);
			serializer.Write("previousPlayerTriggeredEvents", previousPlayerTriggeredEvents);
			serializer.Write("shownEventIds", shownEventIds);
			SerializeEndTimesDictionary("eventEndTimes", eventEndTimes, serializer);
		}

		private static void SerializeEndTimesDictionary(string key, Dictionary<string, float> dictionary, FVSerializer serializer)
		{
			List<string> value = dictionary.Select((KeyValuePair<string, float> pair) => pair.Key).ToList();
			List<float> value2 = dictionary.Select((KeyValuePair<string, float> pair) => pair.Value).ToList();
			serializer.Write(key + "_keys", value);
			serializer.Write(key + "_values", value2);
		}

		public PlayerTriggeredEventSaveData(FVDeserializer deserializer)
		{
			runningPlayerTriggeredEvent = deserializer.ReadObject<PlayerTriggeredEventInstance>("runningPlayerTriggeredEvent");
			timeOfLastEventEnd = deserializer.ReadUInt("timeOfLastEventEnd");
			previousPlayerTriggeredEvents = deserializer.ReadObjectList("previousPlayerTriggeredEvents", new List<PlayerTriggeredEventInstance>());
			shownEventIds = deserializer.ReadStringHashSet("shownEventIds", new HashSet<string>());
			eventEndTimes = DeserializeEndTimeDictionary("eventEndTimes", deserializer);
			OnAfterDeserialize();
		}

		private void OnAfterDeserialize()
		{
			if (runningPlayerTriggeredEvent != null && runningPlayerTriggeredEvent.IsInvalidEvent)
			{
				runningPlayerTriggeredEvent = null;
			}
		}

		private static Dictionary<string, float> DeserializeEndTimeDictionary(string key, FVDeserializer deserializer)
		{
			List<string> list = deserializer.ReadStringList(key + "_keys", new List<string>());
			List<float> list2 = deserializer.ReadFloatList(key + "_values", new List<float>());
			if (list.Count != list2.Count)
			{
				throw new Exception($"Corrupted save data, keys and values must be of same length (keys is {list.Count}, values is {list2.Count})");
			}
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			for (int i = 0; i < list.Count; i++)
			{
				dictionary[list[i]] = list2[i];
			}
			return dictionary;
		}
	}
}
