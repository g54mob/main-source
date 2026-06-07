using System;
using R3;
using UnityEngine;
using UnityEngine.UI;

public static class ObservableSubscribeToExtensions
{
	public static IDisposable SubscribeToSetActive(this Observable<bool> source, GameObject go)
	{
		return source.Subscribe(go, delegate(bool x, GameObject gameObject)
		{
			gameObject.SetActive(x);
		});
	}

	public static IDisposable SubscribeToSetInactive(this Observable<bool> source, GameObject go)
	{
		return source.Subscribe(go, delegate(bool x, GameObject gameObject)
		{
			gameObject.SetActive(!x);
		});
	}

	public static IDisposable SubscribeToSetToggle(this Observable<bool> source, GameObject active, GameObject inactive)
	{
		return source.Subscribe((active, inactive), delegate(bool x, (GameObject active, GameObject inactive) state)
		{
			state.active.SetActive(x);
			state.inactive.SetActive(!x);
		});
	}

	public static IDisposable SubscribeToSetToggle(this Observable<bool> source, Selectable active, Selectable inactive)
	{
		return source.Subscribe((active, inactive), delegate(bool x, (Selectable active, Selectable inactive) state)
		{
			state.active.interactable = x;
			state.inactive.interactable = !x;
		});
	}

	public static IDisposable SubscribeToLoadingBar(this Observable<TimerData> source, SegmentedLoadingBar bar)
	{
		return source.Subscribe(bar, delegate(TimerData x, SegmentedLoadingBar b)
		{
			b.SetNormalizedValue(x.Normalized);
		});
	}

	public static IDisposable SubscribeToLoadingBar(this Observable<float> source, SegmentedLoadingBar bar)
	{
		return source.Subscribe(bar, delegate(float t, SegmentedLoadingBar b)
		{
			b.SetNormalizedValue(t);
		});
	}

	public static IDisposable SubscribeToInteractable(this Observable<bool> source, params Selectable[] selectables)
	{
		return source.Subscribe(selectables, delegate(bool x, Selectable[] s)
		{
			for (int i = 0; i < s.Length; i++)
			{
				s[i].interactable = x;
			}
		});
	}

	public static IDisposable SubscribeToSlider(this Observable<float> source, Slider slider)
	{
		return source.Subscribe(slider, delegate(float x, Slider s)
		{
			s.SetValueWithoutNotify(x);
		});
	}

	public static IDisposable Subscribe(this Observable<bool> source, Action onTrue, Action onFalse)
	{
		return source.Subscribe(delegate(bool x)
		{
			if (x)
			{
				onTrue();
			}
			else
			{
				onFalse();
			}
		});
	}
}
