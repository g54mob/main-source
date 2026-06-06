using System;
using System.Collections.Specialized;
using Cysharp.Text;
using MessagePipe;
using ObservableCollections;
using R3;
using TMPro;
using UnityEngine;

public class HistoryPopup : Popup
{
	[SerializeField]
	private Transform entryParent;

	[SerializeField]
	private HistoryEntry entryPrefab;

	[SerializeField]
	private TMP_Text titleText;

	[SerializeField]
	private TMP_Text moneyText;

	[SerializeField]
	private TMP_Text playersText;

	[SerializeField]
	private TMP_Text playtimeText;

	[SerializeField]
	private TMP_Text incomeText;

	[SerializeField]
	private GameObject incomeWrapper;

	private HistoryEntryData? _selected;

	private ISynchronizedView<HistoryEntryData, HistoryEntry> _entries;

	private HistoryEntry _currentRelease;

	private IDisposable _subscription;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		_currentRelease = UnityEngine.Object.Instantiate(entryPrefab, entryParent);
		_entries = Database.State.History.Releases.CreateView<HistoryEntry>(CreateHistoryEntry).AddTo(this);
		_entries.ViewChanged += HandleCleanup;
		(from _ in Database.State.Game.Name.ThrottleLastHalfSecond().DistinctUntilChanged()
			select Database.Commands.History.CreateHistory()).Subscribe(UpdateCurrentReleaseEntry).AddTo(this);
	}

	protected override void OnDestroy()
	{
		_subscription?.Dispose();
	}

	private void HandleCleanup(in SynchronizedViewChangedEventArgs<HistoryEntryData, HistoryEntry> ctx)
	{
		if (ctx.Action == NotifyCollectionChangedAction.Remove)
		{
			UnityEngine.Object.Destroy(ctx.OldItem.View.gameObject);
		}
	}

	private HistoryEntry CreateHistoryEntry(HistoryEntryData history)
	{
		HistoryEntry historyEntry = UnityEngine.Object.Instantiate(entryPrefab, entryParent);
		historyEntry.Setup(history);
		historyEntry.Selected += OnHistorySelected;
		return historyEntry;
	}

	private void UpdateCurrentReleaseEntry(HistoryEntryData history)
	{
		_currentRelease.Setup(history);
		_currentRelease.Selected += OnHistorySelected;
		_currentRelease.transform.SetAsLastSibling();
	}

	private void OnHistorySelected(HistoryEntryData history)
	{
		if (_selected.HasValue && _selected.Value.Release == history.Release)
		{
			return;
		}
		_selected = history;
		foreach (HistoryEntry entry in _entries)
		{
			entry.SetSelected(history);
		}
		if (_currentRelease.SetSelected(history))
		{
			titleText.SetText(history.Title);
			ObserveCurrentRelease();
			return;
		}
		_subscription?.Dispose();
		TimeSpan timeSpan = TimeSpan.FromSeconds(history.Time);
		titleText.SetText(history.Title);
		moneyText.SetTextFormat(NumericFormat.Currency.Value(), history.Money);
		playersText.SetTextFormat(NumericFormat.Integer9.Value(), history.Players);
		playtimeText.SetTextFormat("{0:000}:{1:00}:{2:00}", (int)timeSpan.TotalHours, timeSpan.Minutes, timeSpan.Seconds);
		incomeWrapper.SetActive(value: false);
	}

	public override void ShowContent()
	{
		if (!_selected.HasValue)
		{
			OnHistorySelected(Database.Commands.History.CreateHistory());
		}
		base.ShowContent();
	}

	public override void HideContent()
	{
		base.HideContent();
		_subscription?.Dispose();
	}

	private void ObserveCurrentRelease()
	{
		DisposableBagBuilder disposableBagBuilder = MessagePipe.DisposableBag.CreateBuilder();
		Database.State.Resources.MoneyLifetime.ThrottleLastSecond().Prepend(Database.State.Resources.MoneyLifetime.Value).DistinctUntilChanged()
			.Format(NumericFormat.Currency.Value())
			.SubscribeToText(moneyText)
			.AddTo(disposableBagBuilder);
		Database.State.Resources.Players.ThrottleLastSecond().Prepend(Database.State.Resources.Players.Value).DistinctUntilChanged()
			.Format(NumericFormat.Integer9.Value())
			.SubscribeToText(playersText)
			.AddTo(disposableBagBuilder);
		Database.State.Game.Time.ThrottleLastSecond().Prepend(Database.State.Game.Time.Value).DistinctUntilChanged()
			.FormatTimeHours()
			.SubscribeToText(playtimeText)
			.AddTo(disposableBagBuilder);
		incomeWrapper.SetActive(value: false);
		_subscription?.Dispose();
		_subscription = disposableBagBuilder.Build();
	}
}
