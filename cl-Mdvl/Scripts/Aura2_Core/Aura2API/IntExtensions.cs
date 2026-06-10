using UnityEngine;

namespace Aura2API
{
	public static class IntExtensions
	{
		public static int Snap(this int value, int snapValue)
		{
			return Mathf.RoundToInt((float)value / (float)snapValue) * snapValue;
		}

		public static int SnapMin(this int value, int snapValue)
		{
			return Mathf.Max(value.Snap(snapValue), snapValue);
		}
	}
}
