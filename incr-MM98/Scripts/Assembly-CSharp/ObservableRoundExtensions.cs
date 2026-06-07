using System;
using R3;

public static class ObservableRoundExtensions
{
	public static Observable<float> Round(this Observable<float> source, int decimals = 0)
	{
		return source.Select(decimals, RoundFloat);
	}

	public static Observable<float> Percentage(this Observable<float> source, int decimals = 0)
	{
		return source.Select((float x) => x * 100f).Round(decimals);
	}

	public static Observable<double> Round(this Observable<double> source, int decimals = 0)
	{
		return source.Select(decimals, RoundDouble);
	}

	public static Observable<double> Percentage(this Observable<double> source, int decimals = 0)
	{
		return source.Select((double x) => x * 100.0).Round(decimals);
	}

	public static Observable<int> AsInt<T>(this Observable<T> source) where T : IConvertible
	{
		return source.Select((T x) => Convert.ToInt32(x));
	}

	public static Observable<float> AsFloat<T>(this Observable<T> source) where T : IConvertible
	{
		return source.Select((T x) => Convert.ToSingle(x));
	}

	public static Observable<double> AsDouble<T>(this Observable<T> source) where T : IConvertible
	{
		return source.Select((T x) => Convert.ToDouble(x));
	}

	private static float RoundFloat(float x, int d)
	{
		return (float)Math.Round(x, d, MidpointRounding.AwayFromZero);
	}

	private static double RoundDouble(double x, int d)
	{
		return Math.Round(x, d, MidpointRounding.AwayFromZero);
	}
}
