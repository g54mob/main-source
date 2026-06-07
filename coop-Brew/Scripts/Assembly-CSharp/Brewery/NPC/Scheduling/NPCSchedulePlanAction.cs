using System;
using UnityEngine;

namespace Brewery.NPC.Scheduling
{
	[Serializable]
	public struct NPCSchedulePlanAction
	{
		[Tooltip("Type of action this segment represents")]
		public ScheduleActionType ActionType;

		[Header("Hotspot Wandering (WanderHotspots only)")]
		[Tooltip("Name of the hotspot set to visit (e.g., 'Parks', 'Stores')")]
		public string HotspotSetName;

		[Tooltip("Minimum and maximum number of hotspot stops")]
		public Vector2Int StopCountRange;

		[Tooltip("Minimum and maximum stay duration (in seconds) at each hotspot")]
		public Vector2 StayDurationRange;

		[Header("Wait Until Time (WaitUntilTime only)")]
		[Tooltip("Hour to wait until (0-23)")]
		[Range(0f, 23f)]
		public int WaitHour;

		[Tooltip("Minute to wait until (0-59)")]
		[Range(0f, 59f)]
		public int WaitMinute;

		[Header("Debug")]
		[Tooltip("Optional description for this action")]
		public string Description;

		public static NPCSchedulePlanAction CreateGoHome()
		{
			return default(NPCSchedulePlanAction);
		}

		public static NPCSchedulePlanAction CreateGoToWork()
		{
			return default(NPCSchedulePlanAction);
		}

		public static NPCSchedulePlanAction CreateIdleAtWork()
		{
			return default(NPCSchedulePlanAction);
		}

		public static NPCSchedulePlanAction CreateWanderHotspots(string setName, int minStops, int maxStops, float minStay, float maxStay)
		{
			return default(NPCSchedulePlanAction);
		}

		public static NPCSchedulePlanAction CreateGoToBar()
		{
			return default(NPCSchedulePlanAction);
		}

		public static NPCSchedulePlanAction CreateWaitUntilTime(int hour, int minute)
		{
			return default(NPCSchedulePlanAction);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
