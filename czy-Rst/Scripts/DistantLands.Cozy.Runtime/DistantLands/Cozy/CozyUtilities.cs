using UnityEngine;

namespace DistantLands.Cozy
{
	public class CozyUtilities
	{
		public static float Remap(float sourceStart, float sourceEnd, float destinationStart, float destinationEnd, float value)
		{
			float t = Mathf.InverseLerp(sourceStart, sourceEnd, value);
			return Mathf.Lerp(destinationStart, destinationEnd, t);
		}

		public static T GetOverriableDefault<T>()
		{
			return default(T);
		}

		public static Color GetOverriableDefault()
		{
			return Color.clear;
		}
	}
}
