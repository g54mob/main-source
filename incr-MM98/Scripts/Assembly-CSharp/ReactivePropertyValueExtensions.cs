using System;
using System.Runtime.CompilerServices;
using R3;

public static class ReactivePropertyValueExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Observable<int> PrependCurrent(this ReactiveProperty<int> property)
	{
		return property.Prepend(property.CurrentValue);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Observable<float> PrependCurrent(this ReactiveProperty<float> property)
	{
		return property.Prepend(property.CurrentValue);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Observable<double> PrependCurrent(this ReactiveProperty<double> property)
	{
		return property.Prepend(property.CurrentValue);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Observable<string> PrependCurrent(this ReactiveProperty<string> property)
	{
		return property.Prepend(property.CurrentValue);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Increment(this ReactiveProperty<int> property, int minimum = 0)
	{
		property.AddValue(1, minimum);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Decrement(this ReactiveProperty<int> property, int minimum = 0)
	{
		property.SubtractValue(1, minimum);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void StartTimer(this ReactiveProperty<TimerData> property, float duration)
	{
		property.StartTimer(0f, duration);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void StartTimer(this ReactiveProperty<TimerData> property, float current, float duration)
	{
		property.Value = new TimerData(current, duration);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void StopTimer(this ReactiveProperty<TimerData> property)
	{
		property.Value = TimerData.Empty;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ResetTimer(this ReactiveProperty<TimerData> property)
	{
		property.Value = new TimerData(property.Value.Duration);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool AdvanceTimer(this ReactiveProperty<TimerData> property, float deltaTime)
	{
		if (!property.Value.IsActive)
		{
			return false;
		}
		property.Value = property.Value.Advance(deltaTime);
		return property.Value.IsDone;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddValue(this ReactiveProperty<int> property, int value, int minimum = 0)
	{
		property.Value = Math.Max(minimum, property.Value + value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddValue(this ReactiveProperty<float> property, float value, float minimum = 0f)
	{
		property.Value = Math.Max(minimum, property.Value + value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddValue(this ReactiveProperty<double> property, double value, double minimum = 0.0)
	{
		property.Value = Math.Max(minimum, property.Value + value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void SubtractValue(this ReactiveProperty<int> property, int value, int minimum = 0)
	{
		property.Value = Math.Max(minimum, property.Value - value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void SubtractValue(this ReactiveProperty<float> property, float value, float minimum = 0f)
	{
		property.Value = Math.Max(minimum, property.Value - value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void SubtractValue(this ReactiveProperty<double> property, double value, double minimum = 0.0)
	{
		property.Value = Math.Max(minimum, property.Value - value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void SetValue(this ReactiveProperty<int> property, int value, int minimum = 0)
	{
		property.Value = Math.Max(minimum, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void SetValue(this ReactiveProperty<float> property, float value, float minimum = 0f)
	{
		property.Value = Math.Max(minimum, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void SetValue(this ReactiveProperty<double> property, double value, double minimum = 0.0)
	{
		property.Value = Math.Max(minimum, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsNullOrEmpty(this ReactiveProperty<string> property)
	{
		return string.IsNullOrEmpty(property.Value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsNotNullOrEmpty(this ReactiveProperty<string> property)
	{
		return !string.IsNullOrEmpty(property.Value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Toggle(this ReactiveProperty<bool> property)
	{
		property.Value = !property.Value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Observable<Unit> IsTrue(this Observable<bool> property)
	{
		return from _ in property
			where _
			select Unit.Default;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Observable<Unit> IsFalse(this Observable<bool> property)
	{
		return from _ in property
			where !_
			select Unit.Default;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Observable<bool> IsValue(this Observable<bool> property, bool value)
	{
		return property.Where((bool x) => x == value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Observable<bool> Invert(this Observable<bool> property)
	{
		return property.Select((bool x) => !x);
	}
}
