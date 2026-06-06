using System;
using R3;
using UnityEngine;
using UnityEngine.Localization;

public class EndingController : MonoBehaviour
{
	[SerializeField]
	public double players = 1000000.0;

	[SerializeField]
	public double lifetimeRevenue = 1000000.0;

	[SerializeField]
	public LocalizedString emailToastTitle;

	[SerializeField]
	public LocalizedString emailToastDescription;

	[SerializeField]
	public Sprite emailToastSprite;

	private IDisposable _endingConditionSubscription;

	private Toast _emailToast;

	private void Start()
	{
		Database.State.Studio.Ending.Subscribe(HandleEndingState).AddTo(this);
	}

	private void OnDestroy()
	{
		_endingConditionSubscription?.Dispose();
	}

	private void HandleEndingState(EndingState state)
	{
		_endingConditionSubscription?.Dispose();
		if (Database.State.Studio.Ending.Value == EndingState.InProgress)
		{
			TrackEndingCondition();
		}
		if (Database.State.Studio.Ending.Value == EndingState.Achieved)
		{
			ShowEmailToast();
		}
		else if ((bool)_emailToast)
		{
			MonoSingleton<ToastManager>.Instance.HideToast(_emailToast);
			_emailToast = null;
		}
	}

	private void TrackEndingCondition()
	{
		_endingConditionSubscription = Database.State.Resources.Players.ThrottleLastSecond().Select(players, (double current, double target) => current >= target).CombineLatest(Database.State.Metrics.MoneyLifetime.ThrottleLastSecond().Select(lifetimeRevenue, (double current, double target) => current >= target), (bool x, bool y) => x && y)
			.IsTrue()
			.Subscribe(delegate
			{
				TriggerEndingCondition();
			});
	}

	private void ShowEmailToast()
	{
		_emailToast = MonoSingleton<ToastManager>.Instance.ShowToast(emailToastTitle, emailToastDescription, emailToastSprite, delegate
		{
			UI.Registry.popup.mail.ShowContent();
		});
	}

	private void TriggerEndingCondition()
	{
		Database.State.Studio.EndingAchieved = GetDateTime();
		Database.State.Studio.Ending.Value = EndingState.Achieved;
		_endingConditionSubscription?.Dispose();
	}

	private static DateTime GetDateTime()
	{
		DateTime now = DateTime.Now;
		return new DateTime(1998, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);
	}
}
