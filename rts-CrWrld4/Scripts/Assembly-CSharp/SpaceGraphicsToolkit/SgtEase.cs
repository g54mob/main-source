namespace SpaceGraphicsToolkit
{
	public static class SgtEase
	{
		public enum Type
		{
			Linear = 0,
			Smoothstep = 1,
			Sinusoidial = 2,
			Quadratic = 3,
			Circular = 4,
			Cubic = 5,
			Quartic = 6,
			Quintic = 7,
			Exponential = 8
		}

		public static float Evaluate(Type ease, float t)
		{
			return 0f;
		}
	}
}
