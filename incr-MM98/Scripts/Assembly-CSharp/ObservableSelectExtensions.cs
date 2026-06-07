using System;
using Cysharp.Text;
using R3;

public static class ObservableSelectExtensions
{
	private const string TimeFormatHours = "{0:000}:{1:00}:{2:00}";

	private const string TimeFormatMinutes = "{0:00}:{1:00}";

	public static Observable<string> Format<T>(this Observable<T> source, string format)
	{
		return source.Select(format, (T x, string f) => ZString.Format(f, x));
	}

	public static Observable<string> FormatTimeHours(this Observable<double> source)
	{
		return source.Select(FormatTimeHours);
	}

	public static Observable<string> FormatTimeMinutes(this Observable<double> source)
	{
		return source.Select(FormatTimeMinutes);
	}

	public static Observable<string> FormatTimeHours(this Observable<float> source)
	{
		return source.AsDouble().Select(FormatTimeHours);
	}

	public static Observable<string> FormatTimeMinutes(this Observable<float> source)
	{
		return source.AsDouble().Select(FormatTimeMinutes);
	}

	private static string FormatTimeHours(double time)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(time);
		return ZString.Format("{0:000}:{1:00}:{2:00}", (int)timeSpan.TotalHours, timeSpan.Minutes, timeSpan.Seconds);
	}

	private static string FormatTimeMinutes(double time)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(time);
		return ZString.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
	}
}
