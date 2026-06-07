using R3;
using UnityEngine;

public static class ObservableMergeExtensions
{
	public static Observable<TValue> MergeTrigger<TValue, TTrigger>(this Observable<TValue> source, Observable<TTrigger> trigger)
	{
		return source.Merge(trigger.CombineLatest(source, (TTrigger _, TValue value) => value));
	}

	public static Observable<float> Normalized(this Observable<float> source, Observable<float> target)
	{
		return source.CombineLatest(target, (float current, float num) => (!(num <= 0f)) ? Mathf.Clamp01(current / num) : 0f);
	}

	public static Observable<float> Normalized(this Observable<double> source, Observable<double> target)
	{
		return source.CombineLatest(target, (double current, double num) => (!(num <= 0.0)) ? Mathf.Clamp01((float)(current / num)) : 0f);
	}
}
