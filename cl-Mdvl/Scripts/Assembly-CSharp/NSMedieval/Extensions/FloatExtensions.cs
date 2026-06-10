using UnityEngine;

namespace NSMedieval.Extensions
{
	public static class FloatExtensions
	{
		public static bool IsCloseToZero(this float value)
		{
			return value.IsCloseTo(0f);
		}

		public static bool IsCloseTo(this float value, float compareTo, float epsilon = 0.001f)
		{
			return Mathf.Abs(value - compareTo) < epsilon;
		}
	}
}
