namespace Humanizer.Localisation
{
	public class ResourceKeys
	{
		public static class DateHumanize
		{
			public const string Now = "DateHumanize_Now";

			public const string Never = "DateHumanize_Never";

			private const string DateTimeFormat = "DateHumanize_{0}{1}{2}";

			private const string Ago = "Ago";

			private const string FromNow = "FromNow";

			public static string GetResourceKey(TimeUnit timeUnit, Tense timeUnitTense, int count = 1)
			{
				return null;
			}
		}

		public static class TimeSpanHumanize
		{
			private const string TimeSpanFormat = "TimeSpanHumanize_{0}{1}{2}";

			private const string Zero = "TimeSpanHumanize_Zero";

			public static string GetResourceKey(TimeUnit unit, int count = 1, bool toWords = false)
			{
				return null;
			}
		}

		public static class TimeUnitSymbol
		{
			private const string TimeUnitFormat = "TimeUnit_{0}";

			public static string GetResourceKey(TimeUnit unit)
			{
				return null;
			}
		}

		private const string Single = "Single";

		private const string Multiple = "Multiple";

		private static void ValidateRange(int count)
		{
		}
	}
}
