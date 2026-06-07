using UnityEngine;

namespace GameKit.Utilities
{
	public static class Quaternions
	{
		public static float GetRate(this Quaternion a, Quaternion goal, float duration, out float angle, uint interval = 1u, float tolerance = 0f)
		{
			angle = default(float);
			return 0f;
		}

		public static bool Matches(this Quaternion a, Quaternion b, bool precise = false)
		{
			return false;
		}

		public static float Angle(this Quaternion a, Quaternion b, bool precise = false)
		{
			return 0f;
		}
	}
}
