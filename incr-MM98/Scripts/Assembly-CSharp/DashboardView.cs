using System;
using Cysharp.Threading.Tasks;
using MessagePipe;
using R3;
using TMPro;
using UnityEngine;

public class DashboardView : MonoBehaviour, IMainView
{
	[SerializeField]
	private TMP_Text studioName;

	[SerializeField]
	private TMP_Text studioTime;

	[SerializeField]
	private TMP_Text gameTime;

	[SerializeField]
	private ValueNumericDisplay totalServers;

	[SerializeField]
	private ValueNumericDisplay gameEarnings;

	[SerializeField]
	private ValueNumericDisplay studioEarnings;

	[SerializeField]
	private ValueNumericDisplay releases;

	[SerializeField]
	private ValueNumericDisplay tickrate;

	[SerializeField]
	private GameObject prereleaseText;

	[SerializeField]
	private FloatGraph playerCountGraph;

	[SerializeField]
	private FloatGraph loadGraph;

	public void Initialize()
	{
		R3.DisposableBag bag = default(R3.DisposableBag);
		EventHub.Scene.Subscribe(delegate
		{
			HandlePrestige();
		}, Array.Empty<MessageHandlerFilter<Prestiged>>()).AddTo(ref bag);
		Database.State.Studio.Name.SubscribeToText(studioName).AddTo(ref bag);
		Database.State.Studio.Time.ThrottleLastHalfSecond().FormatTimeHours().SubscribeToText(studioTime)
			.AddTo(ref bag);
		Database.State.Game.Time.ThrottleLastHalfSecond().FormatTimeHours().SubscribeToText(gameTime)
			.AddTo(ref bag);
		Database.State.Resources.Nodes.SubscribeToValueDisplay(totalServers, NumericFormat.Integer3, 0.5f).AddTo(ref bag);
		Database.State.Resources.MoneyLifetime.ThrottleLastHalfSecond().SubscribeToValueDisplay(gameEarnings, NumericFormat.Currency, 0.5f).AddTo(ref bag);
		Database.State.Metrics.MoneyLifetime.ThrottleLastHalfSecond().SubscribeToValueDisplay(studioEarnings, NumericFormat.Currency, 0.5f).AddTo(ref bag);
		Database.State.Metrics.Releases.CombineLatest(Database.State.Game.Launched, (int r, bool x) => (!x) ? (r - 1) : r).SubscribeToValueDisplay(releases, NumericFormat.Integer3, 0.5f).AddTo(ref bag);
		Database.State.Resources.TickRate.ThrottleLastTenthSecond().SubscribeToValueDisplay(tickrate, NumericFormat.Tickrate, 0.5f).AddTo(ref bag);
		Database.State.Game.Launched.SubscribeToSetInactive(prereleaseText).AddTo(ref bag);
		(from _ in Database.State.Resources.Load.Interval(1f, 2, this.GetCancellationTokenOnDestroy())
			where !Database.Disposed && !Database.State.Studio.Paused.CurrentValue
			select _).Percentage(2).Subscribe(loadGraph.AddSample).AddTo(this);
		Database.State.Resources.PlayersPerSecond.Subscribe(playerCountGraph.AddSample).AddTo(this);
		bag.AddTo(this);
		Hide();
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		UI.Registry.taskbar.dashboard.ForcePressed();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
		UI.Registry.taskbar.dashboard.Clear();
	}

	private void HandlePrestige()
	{
		playerCountGraph.Clear();
		loadGraph.Clear();
	}
}
