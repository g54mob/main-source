using System.Collections.Generic;
using UnityEngine;

public class EventLastChanceDialog : DialogNineSlice
{
	private enum LastChanceState
	{
		Idle = 0,
		ItemDetails = 1,
		PremiumInfo = 2,
		TicketPurchase = 3,
		PurchasePending = 4
	}

	public AsciiString ticketCountLabel;

	public AsciiString title;

	public AsciiString subtitle;

	public AsciiTextBox description;

	public DialogButton closeButton;

	public DialogButton infoButton;

	public DialogButton ticketButton;

	public DialogButton cashButton;

	public DialogButton skipButton;

	public AsciiString footnote;

	public EventPremiumInfoDialog premiumInfoDialog;

	public EventTicketPurchaseDialog ticketPurchaseDialog;

	public AsciiString pendingPurchasesLabel;

	public AsciiSprite loadingIcon;

	private LastChanceState currentLastChanceState;

	private BaseEventController2 eventController;

	public ItemSlot slotPrefab;

	private int rewardsOffsetY;

	private List<ItemSlot> rewardButtons = new List<ItemSlot>();

	public int debugRewardPoints = -1;

	private int SPACING;

	private int MIN_SLOT_WIDTH = 5;

	private int displayTicketCount;

	private int targetTicketCount;

	private Stack<ItemSlot> itemSlotPool = new Stack<ItemSlot>();

	private ItemDetailsDialog itemDetailsDialog => GameStates.Singleton.itemScreen.itemDetailsDialog;

	public bool skipRewards { get; set; }

	public void Show(BaseEventController2 eventController)
	{
		this.eventController = eventController;
		skipRewards = false;
		string text = Te.xt(eventController.data.name);
		title.SetValue("▶ " + text + " ◀");
		description.Text = string.Format(Te.xt("tid_reward_last_chance"), text);
		RecycleRewardButtons();
		rewardsOffsetY = 5 + description.lineCount;
		EventRewards.debugFakeRewardPoints = debugRewardPoints;
		foreach (Item earnedPremiumItem in eventController.rewards.GetEarnedPremiumItems(groupTreasures: true))
		{
			ItemSlot itemSlot = NewItemSlot();
			itemSlot.SetContent(earnedPremiumItem, earnedPremiumItem.count);
			rewardButtons.Add(itemSlot);
		}
		UpdatePremiumCost();
		string value = string.Format(Te.xt("tid_reward_premium_footnote"), "$20 USD");
		footnote.SetValue(value);
		base.SetState(State.In);
		SetLastChanceState(LastChanceState.Idle);
		UpdateTicketCount(jumpToValue: true);
	}

	public void Hide()
	{
		base.SetState(State.Out);
	}

	private void SetLastChanceState(LastChanceState newState)
	{
		switch (newState)
		{
		case LastChanceState.ItemDetails:
			itemDetailsDialog.Show();
			break;
		case LastChanceState.PremiumInfo:
			premiumInfoDialog.Show();
			break;
		case LastChanceState.TicketPurchase:
			ticketPurchaseDialog.Show();
			break;
		}
		currentLastChanceState = newState;
	}

	protected void Update()
	{
		if (base.CurrentState == State.Idle && Input.GetKey(KeyCode.Escape))
		{
			if (currentLastChanceState == LastChanceState.Idle)
			{
				Hide();
			}
			else if (currentLastChanceState == LastChanceState.ItemDetails)
			{
				itemDetailsDialog.Hide();
			}
			else if (currentLastChanceState == LastChanceState.PremiumInfo)
			{
				premiumInfoDialog.Hide();
			}
			else if (currentLastChanceState == LastChanceState.TicketPurchase)
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
		if (currentLastChanceState == LastChanceState.Idle)
		{
			closeButton.UpdateTic();
			foreach (ItemSlot rewardButton in rewardButtons)
			{
				rewardButton.UpdateTic();
			}
			infoButton.UpdateTic();
			ticketButton.UpdateTic();
			cashButton.UpdateTic();
			skipButton.UpdateTic();
		}
		else if (currentLastChanceState == LastChanceState.ItemDetails)
		{
			itemDetailsDialog.UpdateTic();
			if (itemDetailsDialog.CurrentState == State.Disabled)
			{
				SetLastChanceState(LastChanceState.Idle);
			}
		}
		else if (currentLastChanceState == LastChanceState.PremiumInfo)
		{
			premiumInfoDialog.UpdateTic();
			if (premiumInfoDialog.CurrentState == State.Disabled)
			{
				SetLastChanceState(LastChanceState.Idle);
			}
		}
		else
		{
			if (currentLastChanceState != LastChanceState.TicketPurchase)
			{
				return;
			}
			ticketPurchaseDialog.UpdateTic();
			UpdateTicketLabel();
			if (ticketPurchaseDialog.CurrentState == State.Disabled)
			{
				Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("event_ticket");
				if (firstItemWithId != null && firstItemWithId.count >= EventController.TICKET_COST.GetValue())
				{
					HandleTicketsButtonPressed(null);
				}
				else
				{
					SetLastChanceState(LastChanceState.Idle);
				}
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			title.Draw(r, offsetX, offsetY);
			subtitle.Draw(r, offsetX, offsetY);
			description.Draw(r, offsetX, offsetY);
			closeButton.Draw(r, offsetX, offsetY);
			DrawRewards(r, r.width / 2, offsetY);
			ticketButton.Draw(r, offsetX - 3, offsetY);
			skipButton.Draw(r, offsetX - 3, offsetY);
			if (currentLastChanceState == LastChanceState.ItemDetails)
			{
				itemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
			}
			else if (currentLastChanceState == LastChanceState.PremiumInfo)
			{
				premiumInfoDialog.Draw(r, r.width >> 1, r.height >> 1);
			}
			else if (currentLastChanceState == LastChanceState.TicketPurchase)
			{
				ticketPurchaseDialog.Draw(r, r.width >> 1, r.height >> 1);
			}
			if (currentLastChanceState == LastChanceState.TicketPurchase && ticketPurchaseDialog.CurrentState == State.Idle)
			{
				ticketCountLabel.Draw(r, (r.width >> 1) + 5, 0);
			}
			else
			{
				ticketCountLabel.Draw(r, r.width >> 1, 0);
			}
			if (InAppPurchaseController.singleton.HasPendingPurchases())
			{
				loadingIcon.Draw(r, 0, 0);
				pendingPurchasesLabel.Draw(r, 0, 0);
			}
		}
	}

	private void DrawRewards(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetY += rewardsOffsetY;
		int num = 0;
		for (int i = 0; i < rewardButtons.Count; i++)
		{
			ItemSlot slot = rewardButtons[i];
			num += _GetSlotWidth(slot) + SPACING;
		}
		num -= SPACING;
		if (num <= Width - 4)
		{
			_DrawUntil(r, offsetX, offsetY + 3, 0, num);
			return;
		}
		int spaceRemaining = num / 2;
		int num2 = _DrawUntil(r, offsetX, offsetY, 0, spaceRemaining);
		offsetY += 6;
		_DrawUntil(r, offsetX, offsetY, num2 + 1, num);
	}

	private int _DrawUntil(AsciiRenderProcedural r, int offsetX, int offsetY, int startIndex, int spaceRemaining)
	{
		int num = rewardButtons.Count - 1;
		int num2 = 0;
		for (int i = startIndex; i <= num; i++)
		{
			ItemSlot slot = rewardButtons[i];
			int num3 = _GetSlotWidth(slot);
			spaceRemaining -= num3 + SPACING;
			if (spaceRemaining < 0)
			{
				num = i - 1;
				break;
			}
			num2 += num3 + SPACING;
		}
		num2 -= SPACING;
		int num4 = offsetX - num2 / 2;
		for (int j = startIndex; j <= num; j++)
		{
			ItemSlot itemSlot = rewardButtons[j];
			int num5 = _GetSlotWidth(itemSlot);
			itemSlot.Draw(r, num4 + (num5 - itemSlot.Width) / 2, offsetY);
			num4 += num5 + SPACING;
		}
		return num;
	}

	private int _GetSlotWidth(ItemSlot slot)
	{
		int num = MIN_SLOT_WIDTH;
		if (slot.icon != null && slot.icon.width > num)
		{
			num = slot.icon.width;
		}
		return num;
	}

	private void UpdateTicketCount(bool jumpToValue)
	{
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("event_ticket");
		targetTicketCount = ((firstItemWithId != null) ? firstItemWithId.count : 0);
		if (jumpToValue)
		{
			displayTicketCount = targetTicketCount;
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

	private void HandleInfoButtonPressed(DialogButton btn)
	{
		SetLastChanceState(LastChanceState.PremiumInfo);
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
			SetLastChanceState(LastChanceState.TicketPurchase);
		}
	}

	private void HandleCashButtonPressed(DialogButton btn)
	{
		InAppPurchaseController.singleton.BuyProduct(SubscriptionController.EVENTS_SUBSCRIPTION_ID);
	}

	private void HandleSkipButtonPressed(DialogButton btn)
	{
		skipRewards = true;
		Hide();
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
		}
		Hide();
	}

	private void HandleSlotPressed(DialogButton btn)
	{
		ItemSlot itemSlot = btn as ItemSlot;
		itemDetailsDialog.item = itemSlot.item;
		SetLastChanceState(LastChanceState.ItemDetails);
	}

	private ItemSlot NewItemSlot()
	{
		ItemSlot itemSlot = Object.Instantiate(slotPrefab);
		itemSlot.OnPressed += HandleSlotPressed;
		return itemSlot;
	}

	private void RecycleRewardButtons()
	{
		foreach (ItemSlot rewardButton in rewardButtons)
		{
			ItemSlot itemSlot = rewardButton as ItemSlot;
			if (itemSlot == null)
			{
				Debug.LogError("Recycling '" + itemSlot?.ToString() + "', but it's not of type ItemSlot.");
			}
			else
			{
				itemSlotPool.Push(itemSlot);
			}
		}
		rewardButtons.Clear();
	}

	private void OnDestroy()
	{
		closeButton.OnPressed -= HandleClosePressed;
		infoButton.OnPressed -= HandleInfoButtonPressed;
		ticketButton.OnPressed -= HandleTicketsButtonPressed;
		cashButton.OnPressed -= HandleCashButtonPressed;
		skipButton.OnPressed -= HandleSkipButtonPressed;
		ticketPurchaseDialog.OnTicketAmountChanged -= HandleTicketAmountChanged;
		SubscriptionController.OnSubscriptionAdded -= HandleSubscriptionAdded;
	}

	protected override void Awake()
	{
		base.Awake();
		closeButton.OnPressed += HandleClosePressed;
		infoButton.OnPressed += HandleInfoButtonPressed;
		ticketButton.OnPressed += HandleTicketsButtonPressed;
		cashButton.OnPressed += HandleCashButtonPressed;
		skipButton.OnPressed += HandleSkipButtonPressed;
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
