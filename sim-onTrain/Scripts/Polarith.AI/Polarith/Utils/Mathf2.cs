namespace Polarith.Utils
{
	public static class Mathf2
	{
		public const float Epsilon = 1E-06f;

		private const float squareRootUrq = 10f;

		private const float quadraticUrq = 0.1f;

		public static bool Approximately(float a, float b)
		{
			return ((a < b) ? (b - a) : (a - b)) <= 1E-06f;
		}

		public static float MapLinear(float newMin, float newMax, float oldMin, float oldMax, float oldValue, bool clamp = true)
		{
			if (clamp && oldValue <= oldMin)
			{
				return newMin;
			}
			if (clamp && oldValue >= oldMax)
			{
				return newMax;
			}
			if (oldMax - oldMin != 0f)
			{
				return (newMax - newMin) * ((oldValue - oldMin) / (oldMax - oldMin)) + newMin;
			}
			return float.PositiveInfinity;
		}

		public static float MapUrq(float urq, float min, float max, float value)
		{
			if ((urq == 0f || value == 0f) && max - min == 0f)
			{
				return float.PositiveInfinity;
			}
			return urq * value / (urq * value - value + max - min);
		}
	}
}
