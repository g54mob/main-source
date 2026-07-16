using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WorldTime : MonoBehaviour
{
	[Header("Date")]
	[SerializeField]
	private GameDate startDate;

	[SerializeField]
	private GameDate currentDate;

	[Header("Time")]
	[SerializeField]
	[Range(0f, 10f)]
	private float tickRate;

	[SerializeField]
	[Range(0f, 60f)]
	private byte tickAmount;

	[SerializeField]
	[Range(0f, 60f)]
	private byte minutesAmount;

	[SerializeField]
	[Range(0f, 24f)]
	private byte hoursAmount;

	[SerializeField]
	[Range(6f, 24f)]
	private byte startDayHour;

	[SerializeField]
	[Range(0f, 5f)]
	private byte endDayHour;

	[SerializeField]
	[Range(0f, 24f)]
	private byte startOfWorkday;

	[SerializeField]
	[Range(0f, 24f)]
	private byte endOfWorkday;

	private bool timeStopped;

	[SerializeField]
	public GameTime startTime;

	[SerializeField]
	private GameTime globalTime;

	[SerializeField]
	private bool useStopTime;

	[SerializeField]
	private GameTime stopTime;

	[Header("Seasons")]
	[SerializeField]
	private Season[] seasons;

	private byte currentSeasonId;

	public UnityEvent OnSeasonChange;

	public UnityEvent OnBeginDay;

	public UnityEvent OnEndDay;

	public UnityEvent OnGameStart;

	public UnityEvent OnTick;

	public UnityEvent OnGlolbalTimeTickFinished = new UnityEvent();

	public UnityEvent OnHourlyTick;

	public UnityEvent OnEvaluateDay;

	public UnityEvent OnBeginOfWorkDay;

	public UnityEvent OnEndOfWorkDay;

	public UnityEvent OnForcedEndDay;

	public UnityEvent OnNewDay;

	public UnityEvent OnNewWeek;

	public UnityEvent OnNewMonth;

	public UnityEvent OnFinishedLoadNewDay;

	private List<TimeTriggerEvent> timeTriggerEvents = new List<TimeTriggerEvent>();

	private TMP_Text[] worldTimeLabels;

	private TMP_Text[] worldDayLabels;

	private float totalTickAmount;

	private float currentTick;

	private bool loadedFromSaveFile;

	public static WorldTime instance;

	private bool workdayOver;

	private float t;

	private float previousDayAlpha;

	private float dayAlpha;

	public static float GetTotalAmountOfTicks()
	{
		return instance.totalTickAmount;
	}

	public static float GetCurrentTick()
	{
		return instance.currentTick;
	}

	public static bool IsWorldTimeStopped()
	{
		return instance.timeStopped;
	}

	public static GameTime GetGlobalTime()
	{
		return instance.globalTime;
	}

	public static byte GetStopTime()
	{
		return instance.stopTime.hour;
	}

	public static byte GetEndDayHour()
	{
		return instance.endDayHour;
	}

	public static byte GetEndOfWorkDay()
	{
		return instance.endOfWorkday;
	}

	public static byte GetStartOfWorkDay()
	{
		return instance.startOfWorkday;
	}

	public static void LoadCurrentDate(GameDate date)
	{
		instance.currentDate = date;
		instance.loadedFromSaveFile = true;
	}

	public static GameDate GetCurrentDate()
	{
		return instance.currentDate;
	}

	public static int GetTotalWorkhours()
	{
		return instance.endOfWorkday - instance.startOfWorkday;
	}

	public static void SetEndWorkdayHour(byte value)
	{
		instance.endOfWorkday = value;
	}

	public static void SetBeginWorkdayHour(byte value)
	{
		instance.startOfWorkday = value;
	}

	public static bool IsWorkdayOver()
	{
		return instance.workdayOver;
	}

	public static GameTime GetEndOfWorkDayTime()
	{
		return new GameTime
		{
			hour = instance.endOfWorkday,
			minute = 0
		};
	}

	public static void CreateNewTriggerMoment(TimeTriggerEvent triggerEvent)
	{
		instance.timeTriggerEvents.Add(triggerEvent);
	}

	public static void TriggerNextDay()
	{
		instance.timeStopped = true;
		instance.EndDay();
		CafeShopManager.ClearoutCustomers();
	}

	public static void ForceNextDay()
	{
		instance.timeStopped = true;
		instance.ForceEndOfWorkDay();
		instance.EndDay();
		CafeShopManager.ClearoutCustomers();
	}

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		if (useStopTime)
		{
			totalTickAmount = ((float)(int)stopTime.hour - (float)(int)startTime.hour) / ((float)(int)tickAmount / 60f);
		}
		else
		{
			totalTickAmount = (((float)(int)endDayHour < (float)(int)startTime.hour) ? ((float)(int)hoursAmount + (float)(int)endDayHour - (float)(int)startTime.hour) : ((float)(int)hoursAmount - ((float)(int)hoursAmount - (float)(int)endDayHour) - (float)(int)startTime.hour)) / ((float)(int)tickAmount / 60f);
		}
	}

	private void Start()
	{
		worldTimeLabels = (from x in GameObject.FindGameObjectsWithTag("WorldTimeLabel").ToList()
			select x.GetComponent<TMP_Text>()).ToArray();
		worldDayLabels = (from x in GameObject.FindGameObjectsWithTag("WorldDayLabel").ToList()
			select x.GetComponent<TMP_Text>()).ToArray();
		OnTick.AddListener(delegate
		{
			UpdateWorldTimeLables();
		});
		UpdateWorldTimeLables();
		BeginGameTime();
	}

	private void Update()
	{
		GameTick();
	}

	public static void SetWorldDayLabels(TMP_Text[] labels)
	{
		instance.worldDayLabels = labels.ToArray();
		UpdateWorldTimeLables();
	}

	public static void SetWorldTimeLabels(TMP_Text[] labels)
	{
		instance.worldTimeLabels = labels.ToArray();
		UpdateWorldTimeLables();
	}

	public static void UpdateWorldTimeLables()
	{
		if (instance.worldDayLabels.Length == 0)
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("WorldTimeDay");
			List<TMP_Text> list = new List<TMP_Text>();
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i].GetComponent<TMP_Text>());
			}
			instance.worldDayLabels = list.ToArray();
		}
		instance.worldTimeLabels.ToList().ForEach(delegate(TMP_Text x)
		{
			x.text = GetGlobalTime().GetTimeFormatted();
		});
		instance.worldDayLabels.ToList().ForEach(delegate(TMP_Text x)
		{
			x.text = instance.currentDate.day.ToString();
		});
	}

	public void IncreaseTick()
	{
		tickRate += 0.2f;
	}

	public void DecreaseTick()
	{
		tickRate -= 0.2f;
	}

	public static void PauseSimulation()
	{
		instance.timeStopped = true;
	}

	public static void ResumeSimulation()
	{
		instance.timeStopped = false;
	}

	public static void PauseGame()
	{
		instance.timeStopped = true;
		Time.timeScale = 0.05f;
	}

	public static void ResumeGame()
	{
		instance.timeStopped = false;
		Time.timeScale = 1f;
	}

	private void BeginGameTime()
	{
		if (!loadedFromSaveFile)
		{
			currentDate = startDate;
		}
		currentSeasonId = 0;
		currentTick = 0f;
		globalTime = startTime;
	}

	private void CalculateSeason()
	{
		for (byte b = 0; b < seasons.Length; b++)
		{
			if (GameDate.IsDateBetweenMonths(currentDate, seasons[b].fromDate, seasons[b].toDate))
			{
				if (currentSeasonId != b)
				{
					currentSeasonId = b;
					OnSeasonChange.Invoke();
				}
				break;
			}
		}
	}

	public static float GetDaytimeAlpha()
	{
		return instance.dayAlpha;
	}

	private void GameTick()
	{
		if (useStopTime)
		{
			if (globalTime.hour >= stopTime.hour && globalTime.minute >= 0)
			{
				timeStopped = true;
			}
			if (stopTime.hour == 24 && globalTime.hour == 0 && globalTime.minute >= 0)
			{
				timeStopped = true;
			}
			else if (stopTime.hour >= 0 && stopTime.hour <= 6 && globalTime.hour >= stopTime.hour && globalTime.minute >= 0)
			{
				timeStopped = true;
			}
		}
		if (t < 1f)
		{
			t += tickRate * Time.deltaTime;
			currentTick += tickRate * Time.deltaTime;
			return;
		}
		t = 0f;
		OnTick.Invoke();
		if (timeStopped)
		{
			t = 0f;
			return;
		}
		UpdateDayTimeAlpha();
		globalTime.Tick(tickAmount, minutesAmount, hoursAmount, currentDate, OnGlolbalTimeTickFinished);
		TriggerTimeEvents();
		if (globalTime.minute == 0)
		{
			OnHourlyTick.Invoke();
		}
		if (useStopTime && globalTime.ReachedEndOfDay(stopTime.hour, startDayHour))
		{
			timeStopped = true;
			return;
		}
		if (globalTime.hour == startOfWorkday && globalTime.minute == 0)
		{
			BeginWorkDay();
		}
		if (globalTime.hour == endOfWorkday && globalTime.minute == 0)
		{
			EndWorkDay();
		}
		if (globalTime.ReachedEndOfDay(endDayHour, startDayHour))
		{
			EndDay();
		}
	}

	private void TriggerTimeEvents()
	{
		timeTriggerEvents.RemoveAll((TimeTriggerEvent t) => t.isTriggered && t.triggerOnce);
		foreach (TimeTriggerEvent timeTriggerEvent in timeTriggerEvents)
		{
			if (timeTriggerEvent.CheckTimeMoment(currentDate, globalTime))
			{
				timeTriggerEvent.Trigger();
			}
		}
	}

	private void UpdateDayTimeAlpha()
	{
		previousDayAlpha = dayAlpha;
		float num = (float)(int)globalTime.hour + Mathf.InverseLerp(0f, 60f, (int)globalTime.minute);
		if (num < (float)(int)startDayHour)
		{
			num = 24f + (float)(int)globalTime.hour + (float)(int)globalTime.minute * 0.01f;
		}
		float b = Mathf.InverseLerp((int)startDayHour, hoursAmount + endDayHour, num);
		dayAlpha = Mathf.Lerp(previousDayAlpha, b, t);
	}

	private void BeginWorkDay()
	{
		workdayOver = false;
		OnBeginOfWorkDay.Invoke();
	}

	private void EndWorkDay()
	{
		workdayOver = true;
		OnEndOfWorkDay.Invoke();
	}

	private void ForceEndOfWorkDay()
	{
		workdayOver = true;
		OnForcedEndDay.Invoke();
	}

	private void BeginDay()
	{
		timeStopped = false;
		currentTick = 0f;
		globalTime.minute = 0;
		globalTime.hour = startDayHour;
		currentDate.NextDay();
		OnTick.Invoke();
		TriggerTimeEvents();
		OnBeginDay.Invoke();
		OnNewDay.Invoke();
		if (currentDate.FirstDayOfWeek())
		{
			OnNewWeek.Invoke();
		}
		else if (currentDate.FirstDayOfTheMonth())
		{
			OnNewMonth.Invoke();
		}
	}

	private void EndDay()
	{
		timeStopped = true;
		t = 0f;
		OnEndDay.Invoke();
		if (currentDate.FirstDayOfTheMonth())
		{
			CalculateSeason();
		}
		OnEvaluateDay.Invoke();
		BeginDay();
	}
}
