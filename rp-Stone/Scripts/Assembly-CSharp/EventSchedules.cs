using System;
using System.Collections.Generic;
using UnityEngine;

public class EventSchedules : MonoBehaviour
{
	[Serializable]
	public class ScheduleGenerator
	{
		public enum Frequency
		{
			Weekly = 0,
			Quarterly = 1
		}

		public string id;

		public int priority;

		public Frequency frequency;

		[Tooltip("Day of the week the event will start on.")]
		public DayOfWeek startDay;

		[Tooltip("How many days the event will last.")]
		public int duration;

		[Tooltip("Whether or not it can occur at the same time as other events.")]
		public bool canCoincide;

		[Header("Quarterly Specific")]
		[Range(0f, 91f)]
		[Tooltip("Amount of days from the start of quarter that the search targets.")]
		public int searchOffset;

		[Range(0f, 13f)]
		[Tooltip("Maximum amount of weeks the event can differ from the searchOffset day.")]
		public int searchDistance;

		public static ScheduleGenerator FromString(string sjson)
		{
			return new ScheduleGenerator
			{
				id = SlimJson.Parse(sjson, "id"),
				priority = SlimJson.ParseInt(sjson, "pR"),
				startDay = (DayOfWeek)SlimJson.ParseInt(sjson, "dW"),
				duration = SlimJson.ParseInt(sjson, "du"),
				canCoincide = SlimJson.ParseBool(sjson, "cC"),
				searchOffset = SlimJson.ParseInt(sjson, "sO"),
				searchDistance = SlimJson.ParseInt(sjson, "sD")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			if (priority > 0)
			{
				SlimJson.AddProperty("pR", priority);
			}
			SlimJson.AddProperty("dW", (int)startDay);
			SlimJson.AddProperty("du", duration);
			if (canCoincide)
			{
				SlimJson.AddProperty("cC", canCoincide);
			}
			if (searchOffset > 0)
			{
				SlimJson.AddProperty("sO", searchOffset);
			}
			if (searchDistance > 0)
			{
				SlimJson.AddProperty("sD", searchDistance);
			}
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class Schedule
	{
		public string id;

		public int startDay;

		public int startMonth;

		public int endDay;

		public int endMonth;

		public int specificYear;

		public int priority;

		public bool autoAdjust;

		public DayOfWeek autoAdjustDayOfWeek;

		public int autoAdjustDuration;

		private long dateTimeHash;

		private DateTime dateTimeStart;

		private DateTime dateTimeEnd;

		private long HashScheduleDate()
		{
			return (((((long)startDay << 4) + startMonth << 5) + endDay << 4) + endMonth << 11) + specificYear;
		}

		private void ComputeDates()
		{
			long num = HashScheduleDate();
			if (num == dateTimeHash)
			{
				return;
			}
			dateTimeHash = num;
			if (specificYear < 2019)
			{
				DateTime now = DateTime.Now;
				DateTime dateTime = new DateTime(now.Year, startMonth, startDay);
				DateTime dateTime2 = new DateTime(now.Year, endMonth, endDay) + ONE_DAY;
				if (dateTime2 < dateTime)
				{
					dateTime2 = new DateTime(dateTime2.Year + 1, endMonth, endDay) + ONE_DAY;
				}
				if (dateTime2 < now)
				{
					dateTime = new DateTime(dateTime.Year + 1, startMonth, startDay);
					dateTime2 = new DateTime(dateTime2.Year + 1, endMonth, endDay) + ONE_DAY;
				}
				dateTimeStart = dateTime;
				dateTimeEnd = dateTime2;
			}
			else
			{
				dateTimeStart = new DateTime(specificYear, startMonth, startDay);
				dateTimeEnd = new DateTime(specificYear, endMonth, endDay) + ONE_DAY;
				if (dateTimeEnd < dateTimeStart)
				{
					dateTimeEnd = new DateTime(dateTimeEnd.Year + 1, endMonth, endDay) + ONE_DAY;
				}
			}
		}

		public DateTime GetDateTimeStart()
		{
			ComputeDates();
			return dateTimeStart;
		}

		public DateTime GetDateTimeEnd()
		{
			ComputeDates();
			return dateTimeEnd;
		}

		public static Schedule FromString(string sjson)
		{
			return new Schedule
			{
				id = SlimJson.Parse(sjson, "id"),
				startDay = SlimJson.ParseInt(sjson, "sD"),
				startMonth = SlimJson.ParseInt(sjson, "sM"),
				endDay = SlimJson.ParseInt(sjson, "eD"),
				endMonth = SlimJson.ParseInt(sjson, "eM"),
				specificYear = SlimJson.ParseInt(sjson, "sY"),
				priority = SlimJson.ParseInt(sjson, "pR"),
				autoAdjust = SlimJson.ParseBool(sjson, "aA"),
				autoAdjustDayOfWeek = (DayOfWeek)SlimJson.ParseInt(sjson, "aW"),
				autoAdjustDuration = SlimJson.ParseInt(sjson, "aD")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			if (startDay > 0)
			{
				SlimJson.AddProperty("sD", startDay);
			}
			if (startMonth > 0)
			{
				SlimJson.AddProperty("sM", startMonth);
			}
			if (endDay > 0)
			{
				SlimJson.AddProperty("eD", endDay);
			}
			if (endMonth > 0)
			{
				SlimJson.AddProperty("eM", endMonth);
			}
			if (specificYear > 0)
			{
				SlimJson.AddProperty("sY", specificYear);
			}
			if (priority > 0)
			{
				SlimJson.AddProperty("pR", priority);
			}
			if (autoAdjust)
			{
				SlimJson.AddProperty("aA", autoAdjust);
			}
			if (autoAdjustDayOfWeek > DayOfWeek.Sunday)
			{
				SlimJson.AddProperty("aW", (int)autoAdjustDayOfWeek);
			}
			if (autoAdjustDuration > 0)
			{
				SlimJson.AddProperty("aD", autoAdjustDuration);
			}
			return SlimJson.EndSerialization();
		}
	}

	public const int GAME_START_YEAR = 2019;

	private static TimeSpan ONE_DAY = new TimeSpan(1, 0, 0, 0);

	public int searchPeriod;

	public int communityFirstSearchPeriod;

	public ScheduleGenerator[] scheduleGenerators;

	private Schedule[] schedules = new Schedule[0];

	public Schedule[] baseSchedules;

	private List<Schedule> preEventSchedules = new List<Schedule>();

	private Dictionary<string, Schedule> scheduleDict = new Dictionary<string, Schedule>();

	private Dictionary<string, int> duplicateIdCount = new Dictionary<string, int>();

	public static EventSchedules singleton { get; private set; }

	public Schedule GetSchedule(string eventId)
	{
		if (scheduleDict.ContainsKey(eventId))
		{
			return scheduleDict[eventId];
		}
		return null;
	}

	public List<string> GetEventList(int maxEvents)
	{
		List<Schedule> list = new List<Schedule>();
		List<Schedule> list2 = new List<Schedule>();
		Schedule[] array = schedules;
		foreach (Schedule schedule in array)
		{
			if (IsEventActive(schedule.id))
			{
				list.Add(schedule);
			}
		}
		foreach (Schedule preEventSchedule in preEventSchedules)
		{
			if (IsEventVisible(preEventSchedule.id, searchPeriod))
			{
				list2.Add(preEventSchedule);
			}
		}
		list.Sort((Schedule a, Schedule b) => a.GetDateTimeEnd().CompareTo(b.GetDateTimeEnd()));
		list2.Sort(delegate(Schedule a, Schedule b)
		{
			DateTime dateTime = a.GetDateTimeStart() - new TimeSpan(a.priority, 0, 0, 0, 0);
			DateTime value = b.GetDateTimeStart() - new TimeSpan(b.priority, 0, 0, 0, 0);
			return dateTime.CompareTo(value);
		});
		List<string> list3 = new List<string>();
		foreach (Schedule item in list)
		{
			list3.Add(item.id);
		}
		foreach (Schedule item2 in list2)
		{
			list3.Add(item2.id);
		}
		HashSet<string> hashSet = new HashSet<string>();
		List<string> list4 = new List<string>();
		for (int num = 0; num < list3.Count; num++)
		{
			string text = list3[num];
			if (text.StartsWith("pre_"))
			{
				text = text.Substring(4);
			}
			text = text.TrimEnd('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
			if (!hashSet.Contains(text))
			{
				hashSet.Add(text);
				list4.Add(list3[num]);
			}
		}
		list3 = list4;
		if (!HasConnectedToCommunity())
		{
			if (list3.Count == 0)
			{
				list3.Add("community");
			}
			else
			{
				list3 = list3.GetRange(0, Math.Min(list3.Count - 1, maxEvents - 1));
				if (IsEventActive(list3[0]) || IsEventVisible(list3[0], communityFirstSearchPeriod))
				{
					list3.Add("community");
				}
				else
				{
					list3.Insert(0, "community");
				}
			}
		}
		else
		{
			list3 = list3.GetRange(0, Math.Min(list3.Count, maxEvents));
		}
		return list3;
	}

	private bool HasConnectedToCommunity()
	{
		return false;
	}

	public string GetCurrentEvent()
	{
		for (int num = schedules.Length - 1; num >= 0; num--)
		{
			Schedule schedule = schedules[num];
			if (IsEventActive(schedule.id))
			{
				return schedule.id;
			}
		}
		DateTime dateTime = default(DateTime);
		string text = null;
		foreach (Schedule preEventSchedule in preEventSchedules)
		{
			if (IsEventActive(preEventSchedule.id))
			{
				DateTime dateTimeEnd = preEventSchedule.GetDateTimeEnd();
				if (text == null || dateTimeEnd < dateTime)
				{
					text = preEventSchedule.id;
					dateTime = dateTimeEnd;
				}
			}
		}
		return text;
	}

	public bool IsEventVisible(string eventId, int searchPeriod)
	{
		if (!scheduleDict.ContainsKey(eventId))
		{
			return false;
		}
		Schedule schedule = scheduleDict[eventId];
		DateTime now = DateTime.Now;
		DateTime dateTime = DateTime.Now.AddDays(searchPeriod);
		DateTime dateTimeStart = schedule.GetDateTimeStart();
		if (schedule.GetDateTimeEnd() >= now)
		{
			return dateTimeStart <= dateTime;
		}
		return false;
	}

	public bool IsEventActive(string eventId)
	{
		if (!scheduleDict.ContainsKey(eventId))
		{
			return false;
		}
		Schedule schedule = scheduleDict[eventId];
		DateTime now = DateTime.Now;
		DateTime dateTimeStart = schedule.GetDateTimeStart();
		DateTime dateTimeEnd = schedule.GetDateTimeEnd();
		if (now >= dateTimeStart)
		{
			return now <= dateTimeEnd;
		}
		return false;
	}

	public DateTime GetDateTimeStart(string eventId)
	{
		Schedule schedule = GetSchedule(eventId);
		if (schedule != null)
		{
			return schedule.GetDateTimeStart();
		}
		Utils.LogErrorIfEditor("Could not find GetDateTimeStart() for " + eventId);
		return DateTime.Now + new TimeSpan(3650, 0, 0, 0);
	}

	public DateTime GetDateTimeEnd(string eventId)
	{
		Schedule schedule = GetSchedule(eventId);
		if (schedule != null)
		{
			return schedule.GetDateTimeEnd();
		}
		Utils.LogErrorIfEditor("Could not find GetDateTimeEnd() for " + eventId);
		return DateTime.Now + new TimeSpan(3650, 0, 0, 0);
	}

	public int GetDuplicateIdCount(string eventId)
	{
		if (duplicateIdCount.ContainsKey(eventId))
		{
			return duplicateIdCount[eventId];
		}
		return 0;
	}

	private void IncrementDuplicateIdCount(string eventId)
	{
		if (duplicateIdCount.ContainsKey(eventId))
		{
			duplicateIdCount[eventId]++;
		}
		else
		{
			duplicateIdCount.Add(eventId, 1);
		}
	}

	private Schedule MakePreEventSchedule(Schedule schedule)
	{
		DateTime dateTimeStart = schedule.GetDateTimeStart();
		DateTime dateTime = dateTimeStart - ONE_DAY;
		dateTimeStart -= new TimeSpan(searchPeriod, 0, 0, 0);
		return new Schedule
		{
			id = "pre_" + schedule.id,
			startDay = dateTimeStart.Day,
			startMonth = dateTimeStart.Month,
			endDay = dateTime.Day,
			endMonth = dateTime.Month,
			specificYear = dateTimeStart.Year,
			priority = schedule.priority
		};
	}

	private void AddSchedule(Schedule schedule)
	{
		string id = schedule.id;
		int num = GetDuplicateIdCount(id);
		IncrementDuplicateIdCount(id);
		if (num > 0)
		{
			schedule.id = id + num;
			AddSchedule(schedule);
			return;
		}
		scheduleDict.Add(schedule.id, schedule);
		Schedule schedule2 = MakePreEventSchedule(schedule);
		preEventSchedules.Add(schedule2);
		scheduleDict.Add(schedule2.id, schedule2);
	}

	private static Schedule CreateScheduleOnDayOfWeek(string eventId, int startDay, int startMonth, int year, int duration, DayOfWeek targetWeekDay)
	{
		DateTime dateTime = new DateTime(year, startMonth, startDay);
		DateTime dateTime2 = dateTime.AddDays(duration - 1);
		Schedule schedule = new Schedule
		{
			id = eventId,
			startDay = dateTime.Day,
			startMonth = dateTime.Month,
			endDay = dateTime2.Day,
			endMonth = dateTime2.Month,
			specificYear = dateTime.Year,
			autoAdjust = true
		};
		dateTime = schedule.GetDateTimeStart();
		dateTime2 = schedule.GetDateTimeEnd();
		if (dateTime.DayOfWeek == targetWeekDay)
		{
			return schedule;
		}
		int num = (dateTime.DayOfWeek - targetWeekDay + 7) % 7;
		DateTime dateTime3 = dateTime - new TimeSpan(num, 0, 0, 0);
		DateTime dateTime4 = dateTime2 - new TimeSpan(num + 1, 0, 0, 0);
		schedule.specificYear = dateTime3.Year;
		schedule.startDay = dateTime3.Day;
		schedule.startMonth = dateTime3.Month;
		schedule.endDay = dateTime4.Day;
		schedule.endMonth = dateTime4.Month;
		return schedule;
	}

	private static bool DoesScheduleConflict(List<Schedule> schedules, Schedule testSchedule, bool canCoincide)
	{
		DateTime dateTimeStart = testSchedule.GetDateTimeStart();
		DateTime dateTimeEnd = testSchedule.GetDateTimeEnd();
		for (int i = 0; i < schedules.Count; i++)
		{
			DateTime dateTimeStart2 = schedules[i].GetDateTimeStart();
			DateTime dateTimeEnd2 = schedules[i].GetDateTimeEnd();
			if (canCoincide)
			{
				if (dateTimeStart == dateTimeStart2 || dateTimeEnd == dateTimeStart2)
				{
					return true;
				}
			}
			else if (dateTimeStart <= dateTimeEnd2 && dateTimeEnd >= dateTimeStart2)
			{
				return true;
			}
		}
		return false;
	}

	public static Schedule[] GetPopulateSchedules(Schedule[] baseSchedules, ScheduleGenerator[] scheduleGenerators)
	{
		DateTime now = DateTime.Now;
		List<Schedule> list = new List<Schedule>();
		foreach (Schedule schedule in baseSchedules)
		{
			if (schedule.autoAdjust)
			{
				DateTime dateTimeStart = schedule.GetDateTimeStart();
				DateTime dateTime = dateTimeStart.AddDays(schedule.autoAdjustDuration);
				int num = (dateTimeStart.DayOfWeek - schedule.autoAdjustDayOfWeek + 7) % 7;
				DateTime dateTime2 = dateTimeStart - new TimeSpan(num, 0, 0, 0);
				DateTime dateTime3 = dateTime - new TimeSpan(num + 1, 0, 0, 0);
				schedule.specificYear = dateTime2.Year;
				schedule.startDay = dateTime2.Day;
				schedule.startMonth = dateTime2.Month;
				schedule.endDay = dateTime3.Day;
				schedule.endMonth = dateTime3.Month;
			}
			list.Add(schedule);
		}
		foreach (ScheduleGenerator scheduleGenerator in scheduleGenerators)
		{
			if (scheduleGenerator.frequency == ScheduleGenerator.Frequency.Quarterly)
			{
				for (int k = 0; k < 5; k++)
				{
					int month = (now.Month - 1) / 3 * 3 + 1;
					DateTime dateTime4 = new DateTime(now.Year, month, 1).AddMonths(3 * k).AddDays(scheduleGenerator.searchOffset);
					Schedule schedule2 = CreateScheduleOnDayOfWeek(scheduleGenerator.id, dateTime4.Day, dateTime4.Month, dateTime4.Year, scheduleGenerator.duration, scheduleGenerator.startDay);
					schedule2.priority = scheduleGenerator.priority;
					DateTime dateTimeStart2 = schedule2.GetDateTimeStart();
					DateTime dateTime5 = schedule2.GetDateTimeEnd() - new TimeSpan(1, 0, 0, 0);
					bool flag = false;
					if (DoesScheduleConflict(list, schedule2, scheduleGenerator.canCoincide))
					{
						if (scheduleGenerator.searchDistance > 0)
						{
							DateTime dateTime6 = dateTimeStart2 - new TimeSpan(7 * scheduleGenerator.searchDistance, 0, 0, 0);
							DateTime dateTime7 = dateTime5 - new TimeSpan(7 * scheduleGenerator.searchDistance, 0, 0, 0);
							int num2 = 999;
							for (int l = -scheduleGenerator.searchDistance; l <= scheduleGenerator.searchDistance && Math.Abs(l) < num2; l++)
							{
								schedule2.specificYear = dateTime6.Year;
								schedule2.startDay = dateTime6.Day;
								schedule2.startMonth = dateTime6.Month;
								schedule2.endDay = dateTime7.Day;
								schedule2.endMonth = dateTime7.Month;
								if (!DoesScheduleConflict(list, schedule2, scheduleGenerator.canCoincide))
								{
									num2 = Math.Abs(l);
								}
								dateTime6.AddDays(7.0);
								dateTime7.AddDays(7.0);
							}
							flag = num2 <= scheduleGenerator.searchDistance;
						}
					}
					else
					{
						flag = true;
					}
					if (flag)
					{
						list.Add(schedule2);
					}
					else
					{
						Utils.LogErrorIfEditor("Unable to find date for `" + scheduleGenerator.id + "` schedule");
					}
				}
			}
			else
			{
				if (scheduleGenerator.frequency != ScheduleGenerator.Frequency.Weekly)
				{
					continue;
				}
				for (int m = 0; m < 53; m++)
				{
					DateTime dateTime8 = new DateTime(now.Year, now.Month, now.Day).AddDays(7 * m) - new TimeSpan(7 + scheduleGenerator.duration, 0, 0, 0);
					Schedule schedule3 = CreateScheduleOnDayOfWeek(scheduleGenerator.id, dateTime8.Day, dateTime8.Month, dateTime8.Year, scheduleGenerator.duration, scheduleGenerator.startDay);
					if (!DoesScheduleConflict(list, schedule3, scheduleGenerator.canCoincide))
					{
						list.Add(schedule3);
					}
				}
			}
		}
		list.Sort((Schedule a, Schedule b) => a.GetDateTimeStart().CompareTo(b.GetDateTimeStart()));
		list.RemoveAll((Schedule s) => s.GetDateTimeEnd() <= now);
		return list.ToArray();
	}

	private void Initialize()
	{
		RemoteEventDataController remoteEventDataController = RemoteEventDataController.singleton;
		if (remoteEventDataController != null && remoteEventDataController.remoteData != null && remoteEventDataController.remoteData.scheduleGenerators != null && remoteEventDataController.remoteData.baseSchedules != null)
		{
			scheduleGenerators = remoteEventDataController.remoteData.scheduleGenerators;
			baseSchedules = remoteEventDataController.remoteData.baseSchedules;
		}
		schedules = GetPopulateSchedules(baseSchedules, scheduleGenerators);
		for (int i = 0; i < schedules.Length; i++)
		{
			AddSchedule(schedules[i]);
		}
	}

	private void Awake()
	{
		singleton = this;
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
}
