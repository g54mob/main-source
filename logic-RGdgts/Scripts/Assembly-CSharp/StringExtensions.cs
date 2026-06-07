public static class StringExtensions
{
	public enum StringFormatter
	{
		AngularVelocity = 0,
		LinearVelocity = 1
	}

	public static string Truncate(this string value, int maxLength)
	{
		return null;
	}

	public static string FormatTime(float time, bool showHours, int decimalDigits)
	{
		return null;
	}

	private static void FormatTimeSplit(float time, int decimalDigits, out string hoursString, out string minutesString, out string secondsString)
	{
		hoursString = null;
		minutesString = null;
		secondsString = null;
	}

	public static void FormatTimeSplit(float time, out string hoursString, out string minutesString, out string secondsString, out int hours, out int minutes, out float seconds)
	{
		hoursString = null;
		minutesString = null;
		secondsString = null;
		hours = default(int);
		minutes = default(int);
		seconds = default(float);
	}

	public static string ConvertToCurrentCulture(this string text)
	{
		return null;
	}

	public static string FormatFloatToString(float value, StringFormatter stringFormatter)
	{
		return null;
	}

	public static string FirstLetterToUpper(this string str)
	{
		return null;
	}

	public static string FirstLetterToLower(this string str)
	{
		return null;
	}
}
