using UnityEngine;

namespace Brewery.NPC.Simple
{
	[CreateAssetMenu(fileName = "ClerkScheduleConfig", menuName = "Brewery/NPC/Clerk Schedule Config")]
	public class ClerkScheduleConfig : ScriptableObject
	{
		[Header("Work Hours")]
		[Tooltip("Hour when clerks start work (0-23, default 9am)")]
		[Range(0f, 23f)]
		public int workStartHour;

		[Tooltip("Hour when clerks end work (0-23, default 9pm)")]
		[Range(0f, 23f)]
		public int workEndHour;

		[Header("After-Work Behavior")]
		[Tooltip("Should clerks visit bar after work before going home?")]
		public bool visitBarAfterWork;

		[Header("Debug")]
		[Tooltip("Log detailed schedule decisions")]
		public bool logScheduleDebug;

		private void OnValidate()
		{
		}

		public bool IsWorkHours(int hour)
		{
			return false;
		}

		public bool IsTimeToLeaveWork(int hour)
		{
			return false;
		}

		public bool IsBeforeWork(int hour)
		{
			return false;
		}
	}
}
