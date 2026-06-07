using System;
using R3;
using UnityEngine.UI;

public static class ObservableButtonExtensions
{
	public static IDisposable OnClickThrottle(this Button button, float seconds, Action action)
	{
		return button.OnClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(seconds)).Do(delegate
		{
			action();
		})
			.Do(button, delegate(Unit _, Button x)
			{
				x.interactable = false;
			})
			.SelectMany((Unit _) => Observable.Timer(TimeSpan.FromSeconds(seconds)))
			.Do(button, delegate(Unit _, Button x)
			{
				x.interactable = true;
			})
			.Subscribe();
	}
}
