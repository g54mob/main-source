using System;
using System.Threading;
using R3;

public static class ReactivePropertyIntervalExtensions
{
	public static Observable<int> Interval(this ReactiveProperty<int> property, float seconds, CancellationToken token)
	{
		return Observable.Interval(TimeSpan.FromSeconds(seconds), token).WithLatestFrom(property, (Unit _, int value) => value);
	}

	public static Observable<float> Interval(this ReactiveProperty<float> property, float seconds, int decimals, CancellationToken token)
	{
		return Observable.Interval(TimeSpan.FromSeconds(seconds), token).WithLatestFrom(property, (Unit _, float value) => MathF.Round(value, decimals, MidpointRounding.AwayFromZero));
	}

	public static Observable<double> Interval(this ReactiveProperty<double> property, float seconds, int decimals, CancellationToken token)
	{
		return Observable.Interval(TimeSpan.FromSeconds(seconds), token).WithLatestFrom(property, (Unit _, double value) => Math.Round(value, decimals, MidpointRounding.AwayFromZero));
	}

	public static Observable<int> IntervalChange(this ReactiveProperty<int> property, float seconds, CancellationToken token)
	{
		return from pair in property.Interval(seconds, token).Pairwise()
			select pair.Current - pair.Previous;
	}

	public static Observable<float> IntervalChange(this ReactiveProperty<float> property, float seconds, int decimals, CancellationToken token)
	{
		return from pair in property.Interval(seconds, decimals, token).Pairwise()
			select pair.Current - pair.Previous;
	}

	public static Observable<double> IntervalChange(this ReactiveProperty<double> property, float seconds, int decimals, CancellationToken token)
	{
		return from pair in property.Interval(seconds, decimals, token).Pairwise()
			select pair.Current - pair.Previous;
	}
}
