namespace NSMedieval.Tools.Math
{
	public static class PercentageTools
	{
		public static float GetPercentOfYFromX(float x, float y)
		{
			return y / x * 100f;
		}

		public static float GetPercentage(float n, float p)
		{
			return p / 100f * n;
		}
	}
}
