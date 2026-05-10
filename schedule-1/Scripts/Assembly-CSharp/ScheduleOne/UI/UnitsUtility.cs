namespace ScheduleOne.UI
{
	public static class UnitsUtility
	{
		public enum ERoundingType
		{
			None = 0,
			Nearest = 1,
			Up = 2,
			Down = 3
		}

		public static string FormatShortDistance(float meters, ERoundingType roundingType = ERoundingType.Nearest, int decimalPoints = 0)
		{
			return null;
		}

		public static string FormatSpeed(float metersPerSecond, ERoundingType roundingType = ERoundingType.Nearest, int decimalPoints = 1)
		{
			return null;
		}

		private static float RoundValue(float value, ERoundingType roundingType, int decimalPoints)
		{
			return 0f;
		}
	}
}
