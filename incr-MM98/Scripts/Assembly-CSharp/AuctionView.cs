using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using UnityEngine.UI;

public class AuctionView : MonoBehaviour, IMainView
{
	[SerializeField]
	private ResearchNode unlockResearch = ResearchNode.Day1DLC;

	[SerializeField]
	private Button openButton;

	[SerializeField]
	private Button salvageButton;

	[SerializeField]
	private Button sellButton;

	[SerializeField]
	private Button withdrawButton;

	[SerializeField]
	private ValueNumericDisplay pendingDisplay;

	[SerializeField]
	private float incomeDuration = 0.5f;

	[SerializeField]
	private float withdrawDuration = 1f;

	public void Initialize()
	{
		openButton.onClick.AddListener(Database.Commands.Auction.OpenLootchest);
		salvageButton.onClick.AddListener(Database.Commands.Auction.SalvageLootchest);
		sellButton.onClick.AddListener(Database.Commands.Auction.SellLootchest);
		withdrawButton.OnClickThrottle(1f, WithdrawStarted).AddTo(this);
		Database.State.Auction.AvailableLootchests.Select((int x) => x > 0).DistinctUntilChanged().SubscribeToInteractable(openButton)
			.AddTo(this);
		Database.State.Auction.CurrentLootItem.Select((LootItem? x) => x.HasValue).Subscribe((openButton, salvageButton, sellButton), ToggleButtons).AddTo(this);
		(from _ in Database.State.Auction.EscrowMoney.ThrottleFirstLast(TimeSpan.FromSeconds(incomeDuration))
			where !Database.State.Auction.DrainingEscrow
			select _).SubscribeToValueDisplay(pendingDisplay, NumericFormat.Escrow, incomeDuration).AddTo(this);
		Database.State.Research.Unlocked.ObserveContains(unlockResearch).SubscribeToSetActive(UI.Registry.taskbar.auction.gameObject).AddTo(this);
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		UI.Registry.taskbar.auction.ForcePressed();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
		UI.Registry.taskbar.auction.Clear();
	}

	private static void ToggleButtons(bool value, (Button open, Button salvage, Button sell) buttons)
	{
		buttons.open.gameObject.SetActive(!value);
		buttons.salvage.gameObject.SetActive(value);
		buttons.sell.gameObject.SetActive(value);
	}

	private void WithdrawStarted()
	{
		if (!Database.State.Auction.DrainingEscrow && !(Database.State.Auction.EscrowMoney.Value <= 0.0))
		{
			DrainEscrowAsync(this.GetCancellationTokenOnDestroy()).Forget();
		}
	}

	private async UniTaskVoid DrainEscrowAsync(CancellationToken token)
	{
		Database.State.Auction.DrainingEscrow = true;
		Database.Commands.Auction.WithdrawMoney();
		UniTask uniTask = pendingDisplay.AnimateAsync(0.0, NumericFormat.Escrow, withdrawDuration, token);
		UniTask uniTask2 = UI.Registry.resources.money.AnimateAsync(Database.State.Resources.Money.Value, NumericFormat.Currency, withdrawDuration, token);
		await UniTask.WhenAll(uniTask, uniTask2);
		Database.State.Auction.DrainingEscrow = false;
		pendingDisplay.Animate(Database.State.Auction.EscrowMoney.Value, NumericFormat.Escrow, incomeDuration);
	}
}
