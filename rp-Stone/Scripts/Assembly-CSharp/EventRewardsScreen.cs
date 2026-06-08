using System;
using System.Collections.Generic;
using UnityEngine;

public class EventRewardsScreen : DialogNineSlice
{
	private enum RewardScreenState
	{
		Idle = 0,
		ItemDetails = 1,
		PremiumInfo = 2,
		TicketPurchase = 3
	}

	public AsciiString ticketCountLabel;

	public CountdownClockUI clock;

	public DialogButton closeButton;

	public AsciiString title;

	public AsciiTextBox description;

	public EventRewardsContainer rewardsContainer;

	public AsciiString unlockPremiumHeader;

	public DialogButton infoButton;

	public DialogButton ticketButton;

	public DialogButton cashButton;

	public EventPremiumInfoDialog premiumInfoDialog;

	public EventTicketPurchaseDialog ticketPurchaseDialog;

	public AsciiString pendingPurchasesLabel;

	public AsciiSprite loadingIcon;

	private AsciiRenderProcedural.Clip myClip;

	private RewardScreenState currentRewardScreenState;

	private BaseEventController2 eventController;

	private int displayTicketCount;

	private int targetTicketCount;

	private ItemDetailsDialog itemDetailsDialog => GameStates.Singleton.itemScreen.itemDetailsDialog;

	public string[] deepLinkParams { get; set; }

	public event Action OnEventPurchased;

	public void Show(Data.EventRewardCollection rewardCollection, BaseEventController2 eventController)
	{
		this.eventController = eventController;
		rewardsContainer.Setup(rewardCollection, eventController);
		if (!eventController.isPremiumActiveForEvent && eventController.HasPremiumAccess())
		{
			eventController.isPremiumActiveForEvent = true;
			rewardsContainer.OpenLocks();
		}
		UpdateTicketCount(jumpToValue: true);
		infoButton.enabled = false;
		cashButton.enabled = false;
		SetState(State.In);
		SetRewardScreenState(RewardScreenState.Idle);
	}

	public void SetEventEndDate(DateTime eventEndDate)
	{
		clock.Setup(eventEndDate);
	}

	public void Hide()
	{
		SetState(State.Out);
	}

	private void SetRewardScreenState(RewardScreenState newState)
	{
		switch (newState)
		{
		case RewardScreenState.ItemDetails:
			itemDetailsDialog.Show();
			break;
		case RewardScreenState.PremiumInfo:
			premiumInfoDialog.Show();
			break;
		case RewardScreenState.TicketPurchase:
			ticketPurchaseDialog.Show();
			break;
		}
		currentRewardScreenState = newState;
	}

	protected void Update()
	{
		if (base.CurrentState == State.Idle && Input.GetKey(KeyCode.Escape))
		{
			if (currentRewardScreenState == RewardScreenState.Idle)
			{
				Hide();
			}
			else if (currentRewardScreenState == RewardScreenState.ItemDetails)
			{
				itemDetailsDialog.Hide();
			}
			else if (currentRewardScreenState == RewardScreenState.PremiumInfo)
			{
				premiumInfoDialog.Hide();
			}
			else if (currentRewardScreenState == RewardScreenState.TicketPurchase)
			{
				ticketPurchaseDialog.Hide();
			}
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState != State.Idle)
		{
			return;
		}
		UpdateTicketLabel();
		if (currentRewardScreenState == RewardScreenState.Idle)
		{
			if (deepLinkParams != null)
			{
				if (deepLinkParams.Length >= 2 && deepLinkParams[1] == "rewards")
				{
					SetRewardScreenState(RewardScreenState.PremiumInfo);
				}
				deepLinkParams = null;
				return;
			}
			clock.UpdateTic();
			closeButton.UpdateTic();
			rewardsContainer.UpdateTic();
			if (infoButton.enabled)
			{
				infoButton.UpdateTic();
			}
			ticketButton.UpdateTic();
			if (cashButton.enabled)
			{
				cashButton.UpdateTic();
			}
		}
		else if (currentRewardScreenState == RewardScreenState.ItemDetails)
		{
			itemDetailsDialog.UpdateTic();
			if (itemDetailsDialog.CurrentState == State.Disabled)
			{
				SetRewardScreenState(RewardScreenState.Idle);
			}
		}
		else if (currentRewardScreenState == RewardScreenState.PremiumInfo)
		{
			premiumInfoDialog.UpdateTic();
			if (premiumInfoDialog.CurrentState == State.Disabled)
			{
				SetRewardScreenState(RewardScreenState.Idle);
			}
		}
		else if (currentRewardScreenState == RewardScreenState.TicketPurchase)
		{
			ticketPurchaseDialog.UpdateTic();
			if (ticketPurchaseDialog.CurrentState == State.Disabled)
			{
				SetRewardScreenState(RewardScreenState.Idle);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		int num = (int)((float)Width * scaleX);
		int num2 = (int)((float)Height * scaleY);
		myClip.left = r.width - num >> 1;
		myClip.right = myClip.left;
		myClip.top = r.height - num2 >> 1;
		myClip.bottom = myClip.top;
		r.PushClip(myClip);
		ticketCountLabel.Draw(r, offsetX, offsetY);
		clock.Draw(r, offsetX, offsetY);
		closeButton.Draw(r, offsetX, offsetY);
		title.Draw(r, offsetX, offsetY);
		description.Draw(r, offsetX, offsetY);
		rewardsContainer.Width = r.width;
		rewardsContainer.Draw(r, 0, offsetY);
		if (!eventController.HasPremiumAccess())
		{
			unlockPremiumHeader.Draw(r, offsetX, offsetY);
			if (infoButton.enabled)
			{
				infoButton.Draw(r, offsetX, offsetY);
			}
			if (cashButton.enabled)
			{
				cashButton.Draw(r, offsetX, offsetY);
			}
			if (infoButton.enabled || cashButton.enabled)
			{
				ticketButton.Draw(r, offsetX, offsetY);
			}
			else
			{
				ticketButton.Draw(r, offsetX + 5, offsetY);
			}
		}
		r.PopClip();
		if (currentRewardScreenState == RewardScreenState.ItemDetails)
		{
			itemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentRewardScreenState == RewardScreenState.PremiumInfo)
		{
			premiumInfoDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentRewardScreenState == RewardScreenState.TicketPurchase)
		{
			ticketPurchaseDialog.Draw(r, r.width >> 1, r.height >> 1);
			if (ticketPurchaseDialog.CurrentState == State.Idle)
			{
				ticketCountLabel.Draw(r, offsetX + 5, -ticketCountLabel.PositionY);
			}
		}
		if (InAppPurchaseController.singleton.HasPendingPurchases())
		{
			loadingIcon.Draw(r, 0, 0);
			pendingPurchasesLabel.Draw(r, 0, 0);
		}
	}

	private void UpdateTicketCount(bool jumpToValue)
	{
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("event_ticket");
		targetTicketCount = ((firstItemWithId != null) ? firstItemWithId.count : 0);
		if (jumpToValue)
		{
			displayTicketCount = targetTicketCount;
			ticketCountLabel.Clear();
			UpdateTicketLabel();
		}
	}

	private void UpdateTicketLabel()
	{
		bool flag = false;
		if (displayTicketCount < targetTicketCount)
		{
			flag = true;
			if (targetTicketCount - displayTicketCount > 20)
			{
				displayTicketCount += 10;
			}
			else
			{
				displayTicketCount++;
			}
		}
		else if (displayTicketCount > targetTicketCount)
		{
			flag = true;
			if (displayTicketCount - targetTicketCount > 20)
			{
				displayTicketCount -= 10;
			}
			else
			{
				displayTicketCount--;
			}
		}
		if (flag || ticketCountLabel.Length == 0)
		{
			string text = Utils.FormatNumber(displayTicketCount);
			ticketCountLabel.SetValue("░ " + text);
		}
	}

	private void UpdatePremiumCost()
	{
		string localizedPriceString = InAppPurchaseController.singleton.GetLocalizedPriceString(SubscriptionController.EVENTS_SUBSCRIPTION_ID);
		cashButton.label.SetValue(localizedPriceString);
	}

	private void HandleClosePressed(DialogButton btn)
	{
		Hide();
	}

	private void HandleItemSelected(Item item, Data.EventReward entryData)
	{
		itemDetailsDialog.item = item;
		if (item.count != entryData.count)
		{
			itemDetailsDialog.SetCount(entryData.count);
		}
		SetRewardScreenState(RewardScreenState.ItemDetails);
	}

	private void HandleInfoButtonPressed(DialogButton btn)
	{
		SetRewardScreenState(RewardScreenState.PremiumInfo);
	}

	private void HandleTicketsButtonPressed(DialogButton btn)
	{
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("event_ticket");
		if (firstItemWithId != null && firstItemWithId.count >= EventController.TICKET_COST.GetValue())
		{
			Inventory.Singleton.RemoveItem(firstItemWithId, EventController.TICKET_COST.GetValue());
			UpdateTicketCount(jumpToValue: false);
			AfterEventPurchased();
		}
		else
		{
			SetRewardScreenState(RewardScreenState.TicketPurchase);
		}
	}

	private void HandleCashButtonPressed(DialogButton btn)
	{
		InAppPurchaseController.singleton.BuyProduct(SubscriptionController.EVENTS_SUBSCRIPTION_ID);
	}

	private void HandleTicketAmountChanged()
	{
		UpdateTicketCount(jumpToValue: false);
	}

	private void HandleSubscriptionAdded(SubscriptionController.SubData subData)
	{
		if (subData.id == SubscriptionController.EVENTS_SUBSCRIPTION_ID)
		{
			AfterEventPurchased();
		}
	}

	private void AfterEventPurchased()
	{
		if (eventController != null)
		{
			eventController.isPremiumActiveForEvent = true;
			rewardsContainer.OpenLocks();
		}
		if (this.OnEventPurchased != null)
		{
			this.OnEventPurchased();
		}
	}

	private void OnDestroy()
	{
		closeButton.OnPressed -= HandleClosePressed;
		rewardsContainer.OnItemSelected -= HandleItemSelected;
		infoButton.OnPressed -= HandleInfoButtonPressed;
		ticketButton.OnPressed -= HandleTicketsButtonPressed;
		cashButton.OnPressed -= HandleCashButtonPressed;
		ticketPurchaseDialog.OnTicketAmountChanged -= HandleTicketAmountChanged;
		SubscriptionController.OnSubscriptionAdded -= HandleSubscriptionAdded;
	}

	protected override void Awake()
	{
		base.Awake();
		closeButton.OnPressed += HandleClosePressed;
		rewardsContainer.OnItemSelected += HandleItemSelected;
		infoButton.OnPressed += HandleInfoButtonPressed;
		ticketButton.OnPressed += HandleTicketsButtonPressed;
		cashButton.OnPressed += HandleCashButtonPressed;
		ticketPurchaseDialog.OnTicketAmountChanged += HandleTicketAmountChanged;
		SubscriptionController.OnSubscriptionAdded += HandleSubscriptionAdded;
	}

	protected override void Start()
	{
		base.Start();
		ticketButton.label.SetValue("░ " + EventController.TICKET_COST.GetValue());
		List<Color> colorMask = new List<Color> { ColorConstants.rarityUncommon };
		ticketCountLabel.SetColorMask(colorMask);
		ticketButton.label.SetColorMask(colorMask);
	}
}
