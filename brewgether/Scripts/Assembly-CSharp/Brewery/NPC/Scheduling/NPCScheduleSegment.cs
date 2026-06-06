using System;
using UnityEngine;

namespace Brewery.NPC.Scheduling
{
	[Serializable]
	public class NPCScheduleSegment
	{
		[Header("Time Window")]
		[Tooltip("Start hour (0-23)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int startHour;

		[Tooltip("Start minute (0-59)")]
		[Range(0f, 59f)]
		[SerializeField]
		private int startMinute;

		[Tooltip("End hour (0-23)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int endHour;

		[Tooltip("End minute (0-59)")]
		[Range(0f, 59f)]
		[SerializeField]
		private int endMinute;

		[Header("Action")]
		[SerializeField]
		private NPCSchedulePlanAction action;

		[Header("Display")]
		[SerializeField]
		[Tooltip("Optional label for editor display")]
		private string label;

		public int StartHour => 0;

		public int StartMinute => 0;

		public int EndHour => 0;

		public int EndMinute => 0;

		public NPCSchedulePlanAction Action => default(NPCSchedulePlanAction);

		public string Label => null;

		public bool IsTimeInSegment(int hour, int minute)
		{
			return false;
		}

		public float GetNormalizedStartTime()
		{
			return 0f;
		}

		public float GetNormalizedEndTime()
		{
			return 0f;
		}

		public int GetDurationMinutes()
		{
			return 0;
		}

		public void Validate()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string GetEditorSummary()
		{
			return null;
		}

		public static NPCScheduleSegment CreateWorkShift(int startHour, int startMinute, int endHour, int endMinute)
		{
			return null;
		}

		public static NPCScheduleSegment CreateWanderSegment(int startHour, int startMinute, int endHour, int endMinute, string hotspotSet, int minStops, int maxStops)
		{
			return null;
		}

		public static NPCScheduleSegment CreateBarSegment(int startHour, int startMinute, int endHour, int endMinute)
		{
			return null;
		}
	}
}
