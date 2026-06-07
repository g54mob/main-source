namespace TheraBytes.BetterUi
{
	public static class AspectRatioExtensions
	{
		private const float LANDSCAPE5TO4 = 1.25f;

		private const float LANDSCAPE4TO3 = 1.3333334f;

		private const float LANDSCAPE3TO2 = 1.5f;

		private const float LANDSCAPE16TO10 = 1.6f;

		private const float LANDSCAPE5TO3 = 1.6666666f;

		private const float LANDSCAPE16TO9 = 1.7777778f;

		private const float LANDSCAPE21TO9 = 2.3703704f;

		private const float PORTRAIT21TO9 = 27f / 64f;

		private const float PORTRAIT16TO9 = 0.5625f;

		private const float PORTRAIT5TO3 = 0.6f;

		private const float PORTRAIT16TO10 = 0.625f;

		private const float PORTRAIT3TO2 = 2f / 3f;

		private const float PORTRAIT4TO3 = 0.75f;

		private const float PORTRAIT5TO4 = 0.8f;

		public static float GetRatioValue(this AspectRatio ratio)
		{
			return 0f;
		}

		public static string ToShortDetailedString(this AspectRatio ratio)
		{
			return null;
		}

		public static string ToShortString(this AspectRatio ratio)
		{
			return null;
		}
	}
}
