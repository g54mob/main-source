using UnityEngine;

namespace Brewery.NPC.Scheduling
{
	[CreateAssetMenu(fileName = "ScheduleProfile", menuName = "Brewery/NPC/Schedule Profile", order = 200)]
	public class NPCScheduleProfile : ScriptableObject
	{
		[Header("Role Configuration")]
		[Tooltip("The role this profile is designed for")]
		[SerializeField]
		private NPCRoles role;

		[Header("Daily Plans")]
		[Tooltip("Schedule to use on weekdays (Monday-Friday)")]
		[SerializeField]
		private NPCDailyPlan weekdayPlan;

		[Tooltip("Optional schedule for weekends (Saturday-Sunday). If null, uses weekday plan.")]
		[SerializeField]
		private NPCDailyPlan weekendPlan;

		[Header("Bar Visit Configuration (Townsfolk)")]
		[Tooltip("Range of hours for random bar visit start time (e.g., 18-19 for 6 PM to 7 PM, concentrates early visits)")]
		[SerializeField]
		private Vector2Int barStartHourRange;

		[Tooltip("Maximum number of attempts to wait for bar inventory before giving up")]
		[SerializeField]
		private int maxBarWaitAttempts;

		[Tooltip("Seconds to wait between bar purchase retry attempts")]
		[SerializeField]
		private float barRetryIntervalSeconds;

		[Header("Hotspot Configuration (Townsfolk)")]
		[Tooltip("Minimum cooldown in in-game minutes before revisiting the same hotspot")]
		[SerializeField]
		private float hotspotRevisitCooldownMinutes;

		[Tooltip("Maximum distance (in meters) to consider a hotspot reachable")]
		[SerializeField]
		private float maxHotspotDistance;

		[Header("Work Configuration (Store Clerk)")]
		[Tooltip("If true, clerk will take short breaks to wander nearby during work hours")]
		[SerializeField]
		private bool allowWorkBreaks;

		[Tooltip("Duration of work breaks in minutes (if allowed)")]
		[SerializeField]
		private Vector2 workBreakDurationMinutes;

		public NPCRoles Role => default(NPCRoles);

		public NPCDailyPlan WeekdayPlan => null;

		public NPCDailyPlan WeekendPlan => null;

		public Vector2Int BarStartHourRange => default(Vector2Int);

		public int MaxBarWaitAttempts => 0;

		public float BarRetryIntervalSeconds => 0f;

		public float HotspotRevisitCooldownMinutes => 0f;

		public float MaxHotspotDistance => 0f;

		public bool AllowWorkBreaks => false;

		public Vector2 WorkBreakDurationMinutes => default(Vector2);

		public NPCDailyPlan GetPlanForDay(int dayIndex)
		{
			return null;
		}

		public NPCScheduleSegment GetSegmentAtTime(int dayIndex, int hour, int minute)
		{
			return null;
		}

		public NPCScheduleSegment GetNextSegment(int dayIndex, int hour, int minute)
		{
			return null;
		}

		public int CalculateBarHourForNPC(string npcId, int dayIndex)
		{
			return 0;
		}

		private void OnValidate()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string GetDebugSummary()
		{
			return null;
		}
	}
}
