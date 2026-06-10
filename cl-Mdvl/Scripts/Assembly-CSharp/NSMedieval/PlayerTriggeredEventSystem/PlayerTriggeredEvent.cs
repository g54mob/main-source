using System;
using System.Collections.Generic;
using System.Linq;
using NSMedieval.EventBase;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[Serializable]
	public class PlayerTriggeredEvent : EventBaseModel
	{
		[NonSerialized]
		private string shortId;

		[SerializeField]
		private string[] buildingIds;

		[SerializeField]
		private string[] roomTypeIds;

		[SerializeField]
		private EventAttendeeTypeSetting[] eventAttendeeTypeSettings;

		[FormerlySerializedAs("roleIds")]
		[SerializeField]
		private string roleId;

		[SerializeField]
		private ResourceSetting[] resourceSettings;

		[SerializeField]
		private AnimalSetting[] animalSettings;

		[SerializeField]
		private EventQualitySetting[] eventQualitySettings;

		[SerializeField]
		private EventOutcomeSetting[] eventOutcomeSettings;

		[SerializeField]
		private ResourceSetting[] uniqueResourceSettings;

		private Dictionary<string, EventQualitySetting> eventQualitySettingsCache;

		public string[] BuildingIds => buildingIds;

		public string[] RoomTypeIds => roomTypeIds;

		public string RoleId => roleId;

		public ResourceSetting[] ResourceSettings => resourceSettings;

		public AnimalSetting[] AnimalSettings => animalSettings;

		public bool RoomRequired
		{
			get
			{
				string[] array = roomTypeIds;
				if (array != null)
				{
					return array.Length > 0;
				}
				return false;
			}
		}

		public ResourceSetting[] UniqueResourceSettings => uniqueResourceSettings;

		public EventQualitySetting GetEventQualitySetting(string settingId)
		{
			if (eventQualitySettingsCache == null)
			{
				eventQualitySettingsCache = new Dictionary<string, EventQualitySetting>();
				EventQualitySetting[] array = eventQualitySettings;
				foreach (EventQualitySetting eventQualitySetting in array)
				{
					eventQualitySettingsCache.Add(eventQualitySetting.GetID(), eventQualitySetting);
				}
			}
			return eventQualitySettingsCache[settingId];
		}

		public EventOutcomeSetting GetOutcomeSettings(float threshold)
		{
			EventOutcomeSetting[] array = eventOutcomeSettings;
			foreach (EventOutcomeSetting eventOutcomeSetting in array)
			{
				if (threshold <= eventOutcomeSetting.OutcomeValue)
				{
					return eventOutcomeSetting;
				}
			}
			return eventOutcomeSettings.LastOrDefault();
		}

		public int GetLimitForAttendeeType(EventAttendeeType attendeeType, int roleLevel = 0)
		{
			EventAttendeeTypeSetting[] array = eventAttendeeTypeSettings;
			foreach (EventAttendeeTypeSetting eventAttendeeTypeSetting in array)
			{
				if (eventAttendeeTypeSetting.AttendeeType == attendeeType)
				{
					return eventAttendeeTypeSetting.GetLimit(roleLevel);
				}
			}
			return 0;
		}

		public bool HasAttendeeType(EventAttendeeType attendeeType)
		{
			EventAttendeeTypeSetting[] array = eventAttendeeTypeSettings;
			foreach (EventAttendeeTypeSetting eventAttendeeTypeSetting in array)
			{
				if (eventAttendeeTypeSetting.AttendeeType == attendeeType && eventAttendeeTypeSetting.GetLimit() > 0)
				{
					return true;
				}
			}
			return false;
		}

		public string GetGoalIdByType(EventAttendeeType attendeeType)
		{
			EventAttendeeTypeSetting[] array = eventAttendeeTypeSettings;
			foreach (EventAttendeeTypeSetting eventAttendeeTypeSetting in array)
			{
				if (eventAttendeeTypeSetting.AttendeeType == attendeeType && eventAttendeeTypeSetting.GetLimit() > 0)
				{
					return eventAttendeeTypeSetting.GoalId;
				}
			}
			return string.Empty;
		}

		public string ParseEffector(EventAttendeeType eventAttendeeType, string effector)
		{
			EventAttendeeTypeSetting[] array = eventAttendeeTypeSettings;
			foreach (EventAttendeeTypeSetting eventAttendeeTypeSetting in array)
			{
				if (eventAttendeeTypeSetting.AttendeeType == eventAttendeeType)
				{
					return eventAttendeeTypeSetting.GetEffectorIdParsed(effector);
				}
			}
			return string.Empty;
		}

		public ResourceSetting GetUniqueResourceSetting(string settingId)
		{
			if (uniqueResourceSettings == null || uniqueResourceSettings.Length == 0)
			{
				return null;
			}
			return uniqueResourceSettings.First((ResourceSetting rs) => rs.GetID() == settingId);
		}

		public string GetShortId()
		{
			if (shortId == null)
			{
				shortId = id.Split('_')[3];
			}
			return shortId;
		}
	}
}
