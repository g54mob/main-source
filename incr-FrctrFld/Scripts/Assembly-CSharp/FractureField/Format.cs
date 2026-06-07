namespace FractureField
{
	public static class Format
	{
		public class FormatDurationOptions
		{
			public int MaxPartCount { get; set; }

			public bool UseColons { get; set; }

			public bool UseFullPartNames { get; set; }

			public bool ShowMilliseconds { get; set; }
		}

		public static string Duration(long milliseconds, FormatDurationOptions options = null)
		{
			return null;
		}

		public static string Pluralize(float count, string singular, string plural = null, bool includeCount = true)
		{
			return null;
		}
	}
}
