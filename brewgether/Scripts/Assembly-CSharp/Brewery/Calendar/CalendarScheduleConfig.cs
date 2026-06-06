using System;
using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Calendar
{
	[CreateAssetMenu(fileName = "CalendarScheduleConfig", menuName = "Brewery/Calendar/Schedule Config", order = 10)]
	public class CalendarScheduleConfig : ScriptableObject
	{
		[Serializable]
		public class WeeklySlot
		{
			[Tooltip("Purely for Inspector readability — not used at runtime.")]
			public string DayOfWeekLabel;

			[Tooltip("Events that always fire on this day of the week.")]
			public CalendarEventDefinition[] GuaranteedEvents;

			[Tooltip("Pool of events from which exactly one is picked (weighted).")]
			public PooledEvent[] PickOneFromPool;

			[Tooltip("Probability [0..1] of also layering a trend event on top of whatever fires.")]
			[Range(0f, 1f)]
			public float BackgroundNoiseChance;
		}

		[Serializable]
		public struct PooledEvent
		{
			public CalendarEventDefinition Event;

			[Min(0f)]
			public float Weight;
		}

		[Serializable]
		public struct MonthlyFestival
		{
			public CalendarEventDefinition EventDef;

			[Min(1f)]
			public int TriggerEveryNDays;

			[Min(0f)]
			public int OffsetDays;

			[Tooltip("Festival only starts firing on or after this day index. 0 = available from day 1.")]
			[Min(0f)]
			public int DayIndexMustBeAtLeast;
		}

		[Header("Generation")]
		[Tooltip("Deterministic seed. Same seed + same day index => same events on every client.")]
		[SerializeField]
		private int m_ScheduleSeed;

		[Tooltip("First day treated as 'day 1' in the calendar UI.")]
		[SerializeField]
		private int m_CalendarStartDayIndex;

		[Tooltip("When true, the weeklySchedule array is consulted to pick today's events.")]
		[SerializeField]
		private bool m_WeeklyCycleEnabled;

		[Header("Weekly schedule (index 0 = Monday)")]
		[SerializeField]
		private WeeklySlot[] m_WeeklySchedule;

		[Header("Monthly festivals")]
		[SerializeField]
		private MonthlyFestival[] m_MonthlyFestivals;

		[Header("Background trend pool (for the daily noise layer)")]
		[Tooltip("Populated by CalendarEventAssetGenerator — the 'event.tag_trend.*' assets. Each day has a small chance to also fire one of these on top of the guaranteed events.")]
		[SerializeField]
		private CalendarEventDefinition[] m_BackgroundTrendPool;

		[Header("Event catalogue (runtime lookup)")]
		[Tooltip("Direct references to every calendar event the runtime should know about. Populated automatically by CalendarEventAssetGenerator. Required because event assets live outside Resources/ and would be stripped from builds otherwise.")]
		[SerializeField]
		private CalendarEventDefinition[] m_EventCatalog;

		[Header("Global safety clamps (per category multiplier)")]
		[Tooltip("Upper bound applied to every compiled category multiplier before the tag/base/faction/catalyst multipliers combine.")]
		[SerializeField]
		private float m_MaxStackedMult;

		[Tooltip("Lower bound applied to every compiled category multiplier.")]
		[SerializeField]
		private float m_MinStackedMult;

		[Header("Preview")]
		[Tooltip("How many days the CalendarManager pre-generates into 'upcomingEvents' for the UI.")]
		[Min(1f)]
		[SerializeField]
		private int m_PreviewHorizonDays;

		private static readonly string[] WeekdayLabels;

		public int ScheduleSeed => 0;

		public int CalendarStartDayIndex => 0;

		public bool WeeklyCycleEnabled => false;

		public IReadOnlyList<WeeklySlot> WeeklySchedule => null;

		public IReadOnlyList<MonthlyFestival> MonthlyFestivals => null;

		public IReadOnlyList<CalendarEventDefinition> BackgroundTrendPool => null;

		public IReadOnlyList<CalendarEventDefinition> EventCatalog => null;

		public float MaxStackedMult => 0f;

		public float MinStackedMult => 0f;

		public int PreviewHorizonDays => 0;

		private void OnValidate()
		{
		}
	}
}
