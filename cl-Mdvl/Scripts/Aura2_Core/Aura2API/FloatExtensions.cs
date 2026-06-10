using UnityEngine;

namespace Aura2API
{
	public static class FloatExtensions
	{
		public static readonly float[] Array4x0 = new float[4];

		public static readonly float[] Array32x0 = new float[32];

		public static float Snap(this float value, float snapValue)
		{
			return Mathf.Round(value / snapValue) * snapValue;
		}

		public static float SnapMin(this float value, float snapValue)
		{
			return Mathf.Max(value.Snap(snapValue), snapValue);
		}
	}
}
