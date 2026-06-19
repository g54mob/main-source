using UnityEngine;

namespace EasyTextEffects
{
	public static class TimeUtil
	{
		public enum TimeType
		{
			ScaledTime = 0,
			UnscaledTime = 1
		}

		public static float GetTime(TimeType timeType = TimeType.ScaledTime)
		{
			if (Application.isPlaying)
			{
				if (timeType != TimeType.ScaledTime)
				{
					return Time.unscaledTime;
				}
				return Time.time;
			}
			return 0f;
		}
	}
}
