using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public class GlobalTimeController : MonoBehaviour
	{
		public readonly struct TimeInfo
		{
			public readonly float time;

			public readonly float dayF;

			public readonly int day;

			public readonly int minute;

			public readonly int hour;

			public readonly int week;

			public readonly int month;

			public readonly int year;

			public readonly int dayOfWeek;

			public TimeInfo(float time)
			{
				this.time = 0f;
				dayF = 0f;
				day = 0;
				minute = 0;
				hour = 0;
				week = 0;
				month = 0;
				year = 0;
				dayOfWeek = 0;
			}
		}

		[Header("time settings")]
		public const float secondsPerGameDay = 960f;

		private static float[] TimeSteps;

		private static float _superFastSpeed;

		private int _maxTimeStepSelection;

		[Header("adaptive speed")]
		public bool enableAdaptiveSpeed;

		[Tooltip("the maximum delta time each frame should last. if the real delta is bigger, the game will reduce the current time scale (when enableAdaptiveSpeed is enabled).")]
		public float maxDelta;

		private Queue<float> _unscaledDeltaHistory;

		private const float PRECISION = 5E-05f;

		internal float _time;

		[Header("Current Time")]
		public float dayF;

		public int minute;

		public int hour;

		public int day;

		public int week;

		public int month;

		public int year;

		public int dayOfWeek;

		private List<Action> _nextFrameActions;

		private List<Action> _endOfFrameActions;

		private float _preFocusTimeScale;

		private float _currentTimescaleTweenValue;

		public const int DayBegin = 6;

		public const int DayEnd = 19;

		private static string[] _weekDaysKeys;

		private static string[] _weekDaysShortKeys;

		private float _visualTimeSpeed;

		private float _visualDayF;

		private float _unloadedLevelTime;

		[JsonIgnore]
		private FrameCachedValue<float> _actualVisualDayF;

		public int MaxTimeStepSelection
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int CurrentTimeStepSelection { get; private set; }

		public int LastPlayerSelection { get; private set; }

		public int ResumeSpeed { get; private set; }

		public float CurrentScale { get; private set; }

		public float CurrentTimescaleOverride { get; set; }

		public bool IsSystemPaused => false;

		public float TimeLastSpeedChanged { get; private set; }

		public float SecondsSinceLastSpeedChange => 0f;

		public float ExactDayF => 0f;

		public Tween TimescaleTween { get; set; }

		public bool IsVisualTimeOverrideEnabled { get; private set; }

		public float VisualTimeSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public float VisualDayF => 0f;

		public static float UnscaledSmoothDeltaTime { get; private set; }

		private static ConcurrentQueue<float> _unscaledDeltaTimes { get; set; }

		public static event EventHandler TimeSettingChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler DayOfWeekChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler DayChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler HourChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler DayNightChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler MinuteChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler VisualDayFChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void SlowGameSpeedTo(int selection)
		{
		}

		public void SetGameSpeed(int selection, bool isSystemChange = true)
		{
		}

		private void OnTimeScaleChanged()
		{
		}

		private void PlayTimeSound(int from, int to)
		{
		}

		public void Pause(bool isSystemPause = true)
		{
		}

		public bool IsPaused()
		{
			return false;
		}

		public void Resume()
		{
		}

		public void TogglePause()
		{
		}

		public void Start()
		{
		}

		public bool CanUserChangeSpeed()
		{
			return false;
		}

		private void OnUnlockStateChanged(object sender, EventArgs e)
		{
		}

		public void Reset()
		{
		}

		private void RaiseDayOfWeekChangedEvent()
		{
		}

		private void RaiseDayChangedEvent()
		{
		}

		private void RaiseHourChangedEvent()
		{
		}

		private void RaiseDayNightChangedEvent()
		{
		}

		private void RaiseMinuteChangedEvent()
		{
		}

		public void ExecuteAtEndOfNextFrame(Action action)
		{
		}

		public void ExecuteAtStartOfNextFrame(Action action)
		{
		}

		public void ExecuteAtEndOfFrame(Action action)
		{
		}

		private void LateUpdate()
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private void SetTimeScale(float newScale)
		{
		}

		public void SetTweenGameSpeed(int timeStep, float duration, Ease ease)
		{
		}

		private void Update()
		{
		}

		private static bool CanBeSuperFast()
		{
			return false;
		}

		public bool IsDaytime()
		{
			return false;
		}

		internal void RecalculateGametime()
		{
		}

		public static TimeInfo GetTimeInfo(float time)
		{
			return default(TimeInfo);
		}

		public static float GetSecondsPerGameMinute()
		{
			return 0f;
		}

		public float GetDifferenceInHours(float timeInSeconds)
		{
			return 0f;
		}

		public static float ConvertHoursToDayF(float hoursF)
		{
			return 0f;
		}

		public static float ConvertDayFToHoursF(float daysF)
		{
			return 0f;
		}

		public static float ConvertDayFToRealtimeSeconds(float daysF)
		{
			return 0f;
		}

		public float CalculateNextDayF(float hoursF)
		{
			return 0f;
		}

		public static int CalculateDay(float timeSinceGameStartInSeconds)
		{
			return 0;
		}

		public static int CalculateHour(float timeSinceGameStartInSeconds)
		{
			return 0;
		}

		public static float CalculateDayF(float timeSinceGameStartInSeconds)
		{
			return 0f;
		}

		public static float CalculatePreciseDayF(float timeSinceGameStartInSeconds)
		{
			return 0f;
		}

		public static string GetDurationTextKeyFromInGameSeconds(float seconds)
		{
			return null;
		}

		public static string GetDurationTextKey(float durationInDaysF, TooltipData durationTooltip = null, float customStartTime = -1f)
		{
			return null;
		}

		public static string GetDurationTextKeyWithoutDetailTooltip(float durationInDaysF)
		{
			return null;
		}

		public static string GetGameTimeStringForFutureEvent(float inDaysF, float customStartTime = -1f)
		{
			return null;
		}

		public static string GetTimeRemainingStringKeyFromDuration(float gameTimeRemaining)
		{
			return null;
		}

		public static string GetHourStringInPlayerSettingFormat(int hour)
		{
			return null;
		}

		public static string GetTimeStringInPlayerSettingFormat(int hours, int minutes)
		{
			return null;
		}

		public static int CalculateDayOfWeek(float timeSinceGameStartInSeconds)
		{
			return 0;
		}

		public string GetDayNameKey()
		{
			return null;
		}

		public static string GetDayNameKey(int weekDay)
		{
			return null;
		}

		public string GetShortDayNameKey()
		{
			return null;
		}

		public static string GetShortDayNameKey(int weekDay)
		{
			return null;
		}

		public string GetFormattedTimeKey()
		{
			return null;
		}

		public static float ConvertRealTimeSecondsToGameDayF(float seconds)
		{
			return 0f;
		}

		public static float ConvertRealSecondsToGameSeconds(float seconds)
		{
			return 0f;
		}

		public static float ConvertRealMinutesToGameMinutes(float minutes)
		{
			return 0f;
		}

		public static float ConvertGameMinutesToRealMinutes(float gameMinutes)
		{
			return 0f;
		}

		public static float ConvertGameHoursToRealSeconds(float hours)
		{
			return 0f;
		}

		public static float ConvertRealSecondsToGameHours(float realSeconds)
		{
			return 0f;
		}

		public void Forward(int days = 0, int hours = 0, int minutes = 0, int seconds = 0)
		{
		}

		public float GetGameTimeAsOfStartOfCurrentHour()
		{
			return 0f;
		}

		public void SetVisualDayFOverride(float newDayF)
		{
		}

		public void SetVisualTimeOverrideEnabled(bool isEnabled)
		{
		}

		private void UpdateUnloadedLevelTime()
		{
		}

		private void UpdateVisualTime()
		{
		}

		public string GetFormattedVisualTimeKey()
		{
			return null;
		}

		private static void UpdateSmoothUnscaledTime()
		{
		}

		public void WaitForEndOfXFrames(int i, Action callback)
		{
		}

		public void WaitForStartOfXFrames(int i, Action callback)
		{
		}
	}
}
