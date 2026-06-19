using System;
using I2.Loc;

[Serializable]
public class SaveableDateTime
{
	public float seconds;

	public int minutes;

	public int hours;

	public int days;

	public int months;

	public int years;

	public SaveableDateTime(TimeSpan timeSpan)
	{
		seconds = timeSpan.GetSeconds();
		minutes = timeSpan.GetMinutes();
		hours = timeSpan.GetHours();
		days = timeSpan.GetDays();
		months = timeSpan.GetMonths();
		years = timeSpan.GetYears();
	}

	public TimeSpan Load()
	{
		return new TimeSpan(seconds, minutes, hours, days, months, years);
	}

	public string GetFormattedTime()
	{
		return GetFormattedTimeFromValues(hours + days * 24 + months * 30 * 24 + years * 12 * 30 * 24, minutes);
	}

	public static string GetFormattedTimeFromValues(int hoursValue, int minutesValue)
	{
		string gUI_FILE_FORMATTEDTIME = ScriptLocalization.GUI.GUI_FILE_FORMATTEDTIME;
		int length = gUI_FILE_FORMATTEDTIME.IndexOf("[hours");
		int startIndex = gUI_FILE_FORMATTEDTIME.IndexOf("hours]") + 6;
		gUI_FILE_FORMATTEDTIME = gUI_FILE_FORMATTEDTIME.Substring(0, length) + hoursValue + gUI_FILE_FORMATTEDTIME.Substring(startIndex);
		int length2 = gUI_FILE_FORMATTEDTIME.IndexOf("[min");
		int startIndex2 = gUI_FILE_FORMATTEDTIME.IndexOf("minutes]") + 8;
		return gUI_FILE_FORMATTEDTIME.Substring(0, length2) + minutesValue + gUI_FILE_FORMATTEDTIME.Substring(startIndex2);
	}
}
