using System.Collections.Generic;
using UnityEngine;

public class GlobalClock : MonoBehaviour
{
	public const int SECONDS_PER_MINUTE = 60;

	public const int MINUTES_PER_HOUR = 60;

	public const int HOURS_PER_DAY = 24;

	public const int DAYS_PER_MONTH = 30;

	public const int MONTHS_PER_YEAR = 12;

	public static int startingYear = 0;

	public static int startingMonth = 0;

	public static int startingDay = 0;

	public static int startingHour = 0;

	public static int startingMinute = 0;

	public static float standardTimescale = 150f;

	public List<string> scenesWithClockAdvancement = new List<string>();

	public TimeDisplay timeDisplayRef;

	private TimeSpan currentTimespan;

	private TimeSpan lastFrameTimespan;

	private bool inGameTimeEnabled = true;

	private List<TimeTrigger> triggerList = new List<TimeTrigger>();

	private List<TimeTrigger> tempTriggerList = new List<TimeTrigger>();

	private List<TimeTrigger> triggersToExecute = new List<TimeTrigger>();

	private SceneManagerBase sceneRef;

	private void Awake()
	{
		currentTimespan = GetStartingTimespan();
		lastFrameTimespan = GetStartingTimespan();
	}

	private static TimeSpan GetStartingTimespan()
	{
		return new TimeSpan(0f, startingMinute, startingHour, startingDay, startingMonth, startingYear);
	}

	public float GetGameSecondsSinceLastFrame()
	{
		return GetGameSecondsSinceTimespan(lastFrameTimespan);
	}

	public float GetGameSecondsSinceTimespan(TimeSpan span)
	{
		return (currentTimespan - span).GetTotalSeconds();
	}

	public SaveableDateTime GetSavedDateTime()
	{
		return new SaveableDateTime(currentTimespan);
	}

	public void LoadSavedDateTime(SaveableDateTime savedDateTime)
	{
		currentTimespan = GetTimespanFromSaveableDateTime(savedDateTime);
		lastFrameTimespan = GetTimespanFromSaveableDateTime(savedDateTime);
	}

	public static TimeSpan GetTimespanFromSaveableDateTime(SaveableDateTime savedDateTime)
	{
		if (savedDateTime == null)
		{
			return GetStartingTimespan();
		}
		return savedDateTime.Load();
	}

	public bool CurrentDateWithinDateRange(DateRange range)
	{
		if (!range.startDate.forever)
		{
			bool flag = range.startDate.year != 0;
			bool flag2 = range.startDate.month != 0;
			bool flag3 = range.startDate.day != 0;
			if (flag && currentTimespan.GetYears() < range.startDate.year)
			{
				return false;
			}
			if (flag2 && currentTimespan.GetMonths() < range.startDate.month)
			{
				if (!flag)
				{
					return false;
				}
				if (flag && currentTimespan.GetYears() == range.startDate.year)
				{
					return false;
				}
			}
			if (flag3 && currentTimespan.GetDays() < range.startDate.day)
			{
				if (!flag2)
				{
					return false;
				}
				if (flag2 && currentTimespan.GetMonths() == range.startDate.month)
				{
					return false;
				}
			}
		}
		if (!range.endDate.forever)
		{
			bool flag = range.endDate.year != 0;
			bool flag2 = range.endDate.month != 0;
			bool flag3 = range.endDate.day != 0;
			if (flag && currentTimespan.GetYears() > range.endDate.year)
			{
				return false;
			}
			if (flag2 && currentTimespan.GetMonths() > range.endDate.month)
			{
				if (!flag)
				{
					return false;
				}
				if (flag && currentTimespan.GetYears() == range.endDate.year)
				{
					return false;
				}
			}
			if (flag3 && currentTimespan.GetDays() > range.endDate.day)
			{
				if (!flag2)
				{
					return false;
				}
				if (flag2 && currentTimespan.GetMonths() == range.endDate.month)
				{
					return false;
				}
			}
		}
		return true;
	}

	private void RegisterSceneRef()
	{
		sceneRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		sceneRef.CheckTitle();
	}

	private void Update()
	{
		if (sceneRef == null)
		{
			RegisterSceneRef();
		}
		if (inGameTimeEnabled && (!(CheatEngine.cheatRef != null) || CheatEngine.cheatRef.inGameTimeEnabled) && (!(sceneRef != null) || !sceneRef.IsAtTitleScreen()))
		{
			float totalHours = currentTimespan.GetTotalHours();
			lastFrameTimespan.UpdateFromExistingTimespan(currentTimespan);
			currentTimespan.AddTime(GetRealWorldTimeDeltaTime());
			float totalHours2 = currentTimespan.GetTotalHours();
			if (Mathf.FloorToInt(totalHours2) > Mathf.FloorToInt(totalHours))
			{
				GoalsController.SetGoalEvent(GoalCondition.HOURS_PLAYED, Mathf.FloorToInt(totalHours2));
			}
			CheckTriggers();
		}
	}

	public void SetInGameTimeEnabled(bool val)
	{
		inGameTimeEnabled = val;
	}

	public TimeSpan GetCurrentTimespan()
	{
		return currentTimespan.GetCopy();
	}

	public void SetCurrentTimespan(TimeSpan newTimespan)
	{
		lastFrameTimespan.UpdateFromExistingTimespan(currentTimespan);
		currentTimespan.UpdateFromExistingTimespan(newTimespan);
	}

	public void AddTimespan(TimeSpan newTimespan)
	{
		lastFrameTimespan.UpdateFromExistingTimespan(currentTimespan);
		currentTimespan += newTimespan;
	}

	public static int SecondsPerHour()
	{
		return 3600;
	}

	public static int SecondsPerDay()
	{
		return SecondsPerHour() * 24;
	}

	public static int SecondsPerMonth()
	{
		return SecondsPerDay() * 30;
	}

	public static int SecondsPerYear()
	{
		return SecondsPerMonth() * 12;
	}

	public float GetGameTimeDeltaTime()
	{
		return Time.deltaTime * standardTimescale;
	}

	public float GetRealWorldTimeDeltaTime()
	{
		return Time.unscaledDeltaTime;
	}

	public void RegisterTimeTrigger(TimeSpan timeFromNow, TimeTriggerCallback callback)
	{
		TimeSpan copy = currentTimespan.GetCopy();
		copy += timeFromNow;
		TimeTrigger item = new TimeTrigger
		{
			triggerTime = copy,
			callback = callback
		};
		int index = 0;
		for (int i = 0; i < triggerList.Count; i++)
		{
			if (triggerList[i].triggerTime > item.triggerTime)
			{
				index = i;
				break;
			}
		}
		triggerList.Insert(index, item);
	}

	public int GetSecond()
	{
		return Mathf.RoundToInt(currentTimespan.GetSeconds());
	}

	public int GetMinute()
	{
		return currentTimespan.GetMinutes();
	}

	public int GetHour()
	{
		return currentTimespan.GetHours();
	}

	public int GetDay()
	{
		return currentTimespan.GetDays();
	}

	public int GetMonth()
	{
		return currentTimespan.GetMonths();
	}

	public int GetYear()
	{
		return currentTimespan.GetYears();
	}

	private void CheckTriggers()
	{
		tempTriggerList.Clear();
		triggersToExecute.Clear();
		tempTriggerList.AddRange(triggerList);
		for (int i = 0; i < tempTriggerList.Count && currentTimespan >= tempTriggerList[i].triggerTime; i++)
		{
			triggersToExecute.Add(tempTriggerList[i]);
			triggerList.RemoveAt(0);
		}
		for (int j = 0; j < triggersToExecute.Count; j++)
		{
			triggersToExecute[j].callback();
		}
	}
}
