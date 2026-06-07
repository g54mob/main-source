using System;
using UnityEngine;
using UnityEngine.Events;

namespace MyStuff.Environment
{
	[Serializable]
	public class TimeEvent
	{
		[SerializeField]
		[HideInInspector]
		private string eventId;

		[Tooltip("Descriptive tag for this event")]
		[SerializeField]
		private string eventTag;

		[Tooltip("How often should this event repeat?")]
		[SerializeField]
		private EventRepeatMode repeatMode;

		[Tooltip("Hour of day (0-23)")]
		[SerializeField]
		[Range(0f, 23f)]
		private int hour;

		[Tooltip("Minute of hour (0-59)")]
		[SerializeField]
		[Range(0f, 59f)]
		private int minute;

		[Tooltip("Day of week (for weekly repeat mode)")]
		[SerializeField]
		private DayOfWeek weeklyDay;

		[Tooltip("Interval in in-game minutes (for interval repeat mode)")]
		[SerializeField]
		private float intervalMinutes;

		[Tooltip("Fire immediately if this event was missed before joining")]
		[SerializeField]
		private bool fireIfMissedOnJoin;

		[Tooltip("Only fire on server, don't broadcast to clients")]
		[SerializeField]
		private bool serverOnly;

		[Tooltip("Optional JSON data payload for this event")]
		[SerializeField]
		[TextArea(2, 5)]
		private string payloadJson;

		[Tooltip("Unity event callbacks (drag components here)")]
		[SerializeField]
		private UnityEvent onEventTriggered;

		[Tooltip("Enable/disable this event")]
		[SerializeField]
		private bool enabled;

		[NonSerialized]
		private Action<TimeEventContext> runtimeCallback;

		[NonSerialized]
		private float nextFireTimeNormalized;

		public string EventId => null;

		public string EventTag => null;

		public EventRepeatMode RepeatMode => default(EventRepeatMode);

		public int Hour => 0;

		public int Minute => 0;

		public DayOfWeek WeeklyDay => default(DayOfWeek);

		public float IntervalMinutes => 0f;

		public bool FireIfMissedOnJoin => false;

		public bool ServerOnly => false;

		public string PayloadJson => null;

		public UnityEvent OnEventTriggered => null;

		public bool Enabled => false;

		public float NextFireTimeNormalized
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Action<TimeEventContext> RuntimeCallback
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float CalculateNextFireTime(float currentNormalizedTime, int currentDayIndex, float dayLengthSeconds)
		{
			return 0f;
		}

		public void Invoke(TimeEventContext context)
		{
		}

		public void GenerateNewId()
		{
		}

		public static TimeEvent Create(string tag, int eventHour, int eventMinute, EventRepeatMode mode = EventRepeatMode.Daily, bool isServerOnly = true, bool fireIfMissed = false)
		{
			return null;
		}
	}
}
