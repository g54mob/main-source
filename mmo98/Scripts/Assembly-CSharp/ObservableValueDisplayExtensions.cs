using System;
using R3;

public static class ObservableValueDisplayExtensions
{
	public static IDisposable SubscribeToValueDisplay(this Observable<int> source, ValueNumericDisplay display, NumericFormat format, float duration)
	{
		return source.Subscribe((display, format, duration), delegate(int x, (ValueNumericDisplay display, NumericFormat format, float duration) state)
		{
			state.display.Animate(x, state.format, state.duration);
		});
	}

	public static IDisposable SubscribeToValueDisplay(this Observable<float> source, ValueNumericDisplay display, NumericFormat format, float duration)
	{
		return source.Subscribe((display, format, duration), delegate(float x, (ValueNumericDisplay display, NumericFormat format, float duration) state)
		{
			state.display.Animate(x, state.format, state.duration);
		});
	}

	public static IDisposable SubscribeToValueDisplay(this Observable<double> source, ValueNumericDisplay display, NumericFormat format, float duration)
	{
		return source.Subscribe((display, format, duration), delegate(double x, (ValueNumericDisplay display, NumericFormat format, float duration) state)
		{
			state.display.Animate(x, state.format, state.duration);
		});
	}

	public static IDisposable SubscribeToValueDisplay<T>(this Observable<T> source, ValueStringDisplay display, float duration)
	{
		return source.Subscribe((display, duration), delegate(T x, (ValueStringDisplay display, float duration) state)
		{
			state.display.Animate(x.ToString(), state.duration);
		});
	}

	public static IDisposable SubscribeToBoxArtDisplay(this Observable<BoxArtTexture> source, BoxArtDisplay display, float duration)
	{
		return source.Subscribe((display, duration), delegate(BoxArtTexture x, (BoxArtDisplay display, float duration) state)
		{
			state.display.Animate(x, state.duration);
		});
	}
}
