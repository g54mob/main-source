using System;
using R3;
using UnityEngine;

public class ReactiveResources : MonoBehaviour
{
	[SerializeField]
	private float updateIntervalSeconds = 0.05f;

	private TimeSpan _intervalTimeSpan;

	private void Start()
	{
		_intervalTimeSpan = TimeSpan.FromSeconds(updateIntervalSeconds);
		DisposableBag bag = new DisposableBag(8);
		Database.State.Game.Launched.SubscribeToSetActive(UI.Registry.resources.pingReleased).AddTo(ref bag);
		Database.State.Game.Launched.SubscribeToSetInactive(UI.Registry.resources.pingUnreleased).AddTo(ref bag);
		Database.State.Resources.Load.Select((float x) => x >= 0.9f && x < 1f).DistinctUntilChanged().SubscribeToSetActive(UI.Registry.resources.warningTicker);
		Database.State.Resources.Load.Select((float x) => x >= 1f).DistinctUntilChanged().SubscribeToSetActive(UI.Registry.resources.criticalTicker);
		Database.State.Studio.Paused.SubscribeToSetActive(UI.Registry.resources.pausedTicker).AddTo(ref bag);
		SubscribeResource(Database.State.Resources.Players, 0, UI.Registry.resources.player, NumericFormat.Integer9).AddTo(ref bag);
		SubscribeMoney(Database.State.Resources.Money, UI.Registry.resources.money).AddTo(ref bag);
		SubscribeResourcePercentage(Database.State.Resources.Hype, 2, UI.Registry.resources.hype, NumericFormat.Percentage).AddTo(ref bag);
		SubscribeResourcePercentage(Database.State.Resources.Load, 2, UI.Registry.resources.load, NumericFormat.Percentage).AddTo(ref bag);
		SubscribeResource(Database.State.Resources.Bugs, 0, UI.Registry.resources.bugs, NumericFormat.Integer3).AddTo(ref bag);
		SubscribeResource(Database.State.Resources.Ping, 0, UI.Registry.resources.ping, NumericFormat.Integer3).AddTo(ref bag);
		SubscribeResource(Database.State.Prestige.Fans, 0, UI.Registry.resources.fans, NumericFormat.Integer9).AddTo(ref bag);
		SubscribeResource(Database.State.Prestige.Data, 1, UI.Registry.resources.data, NumericFormat.Data).AddTo(ref bag);
		SubscribeResource(Database.Derived.DataCapacity, 1, UI.Registry.resources.dataMax, NumericFormat.DataMax).AddTo(ref bag);
		bag.AddTo(this);
	}

	private IDisposable SubscribeResource<T>(Observable<T> property, int decimals, ValueNumericDisplay display, NumericFormat format) where T : struct, IConvertible
	{
		return (from value in property.ThrottleLast(_intervalTimeSpan)
			select Math.Round(Convert.ToDouble(value), decimals, MidpointRounding.AwayFromZero)).DistinctUntilChanged().SubscribeToValueDisplay(display, format, updateIntervalSeconds);
	}

	private IDisposable SubscribeResourcePercentage<T>(Observable<T> property, int decimals, ValueNumericDisplay display, NumericFormat format) where T : struct, IConvertible
	{
		return (from value in property.ThrottleLast(_intervalTimeSpan)
			select Math.Round(Convert.ToDouble(value) * 100.0, decimals, MidpointRounding.AwayFromZero)).DistinctUntilChanged().SubscribeToValueDisplay(display, format, updateIntervalSeconds);
	}

	private IDisposable SubscribeMoney(Observable<double> property, ValueNumericDisplay display)
	{
		return (from value in property.ThrottleLast(_intervalTimeSpan)
			where !Database.State.Auction.DrainingEscrow
			select Math.Round(value, 0, MidpointRounding.AwayFromZero)).DistinctUntilChanged().SubscribeToValueDisplay(display, NumericFormat.Currency, updateIntervalSeconds);
	}
}
