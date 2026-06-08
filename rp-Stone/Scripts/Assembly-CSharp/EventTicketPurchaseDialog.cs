using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class EventTicketPurchaseDialog : TwoChoiceDialog
{
	private enum TicketPurchaseState
	{
		Normal = 0,
		DeliverItems = 1
	}

	public AsciiString crystalCountLabel;

	public AsciiString title;

	public DialogButton purchaseButton1;

	public DialogButton purchaseButton2;

	public DialogButton purchaseButton3;

	public DialogButton purchaseButton4;

	public AsciiString bonus1;

	public AsciiString bonus2;

	public AsciiString bonus3;

	public AsciiString bonus4;

	private int bonusEnabledCount;

	public AsciiString footnote;

	private TicketPurchaseState currentTicketPurchaseState;

	private List<string> bundlesToDeliver = new List<string>();

	private Dictionary<string, SafeInt> pcCrystalCosts;

	private List<Color> crystalCostMask = new List<Color>(new Color[1] { ColorConstants.magenta });

	private int cooldownUpdateInAppPurchases;

	private DialogButton flashingButton;

	private int flashingCountdown;

	private int displayCrystalCount;

	private int targetCrystalCount;

	public event Action OnTicketAmountChanged;

	private void InitCrystalPrices()
	{
		pcCrystalCosts = new Dictionary<string, SafeInt>();
		pcCrystalCosts.Add("iap_tickets_0", new SafeInt(10));
		pcCrystalCosts.Add("iap_tickets_1", new SafeInt(36));
		pcCrystalCosts.Add("iap_tickets_2", new SafeInt(160));
		pcCrystalCosts.Add("iap_tickets_3", new SafeInt(300));
	}

	public override void Show()
	{
		UpdateCrystalCount(jumpToValue: true);
		UpdateTitle();
		SetMessage(Te.xt("tid_relic_58_b2"));
		SetupPriceLabel(purchaseButton1.label, "iap_tickets_0");
		SetupPriceLabel(purchaseButton2.label, "iap_tickets_1");
		SetupPriceLabel(purchaseButton3.label, "iap_tickets_2");
		SetupPriceLabel(purchaseButton4.label, "iap_tickets_3");
		bonusEnabledCount = 0;
		SetupBonusLabel(bonus1, "iap_tickets_0", 5);
		SetupBonusLabel(bonus2, "iap_tickets_1", 20);
		SetupBonusLabel(bonus3, "iap_tickets_2", 100);
		SetupBonusLabel(bonus4, "iap_tickets_3", 200);
		int height = Height;
		int positionY = PositionY;
		base.Show();
		Height = height;
		PositionY = positionY;
		SetTicketPurchaseState(TicketPurchaseState.Normal);
	}

	public override void Hide()
	{
		if (!cancelButton.isDisabledState)
		{
			base.Hide();
		}
	}

	private void UpdateTitle()
	{
		string text = "░ " + Te.xt("tid_relic_58_a") + " ░";
		title.SetValue(text);
		List<Color> list = new List<Color>(text.Length);
		list.Add(ColorConstants.rarityUncommon);
		for (int i = 0; i < text.Length - 2; i++)
		{
			list.Add(ColorConstants.white);
		}
		list.Add(ColorConstants.rarityUncommon);
		title.SetColorMask(list);
	}

	private void SetupPriceLabel(AsciiString label, string iapId)
	{
		string value = "♦ " + pcCrystalCosts[iapId].GetValue();
		label.SetColorMask(crystalCostMask);
		label.SetValue(value);
	}

	private void SetupBonusLabel(AsciiString label, string productId, int bonusAmount)
	{
		if (!PromotionsController.singleton.HasPurchased(productId))
		{
			bonusEnabledCount++;
			label.SetValue(string.Format(Te.xt("tid_ticket_bonus"), "+" + bonusAmount));
		}
	}

	private void SetTicketPurchaseState(TicketPurchaseState newState)
	{
		currentTicketPurchaseState = newState;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState != State.Idle)
		{
			return;
		}
		UpdateCrystalCountLabel();
		UpdateFlashingButton();
		if (currentTicketPurchaseState == TicketPurchaseState.Normal)
		{
			purchaseButton1.UpdateTic();
			purchaseButton2.UpdateTic();
			purchaseButton3.UpdateTic();
			purchaseButton4.UpdateTic();
			UpdateInAppPurchases();
			UpdateButtonStates();
		}
		else
		{
			if (currentTicketPurchaseState != TicketPurchaseState.DeliverItems)
			{
				return;
			}
			if (bundlesToDeliver.Count <= 0)
			{
				SetTicketPurchaseState(TicketPurchaseState.Normal);
				return;
			}
			string text = bundlesToDeliver[0];
			bundlesToDeliver.RemoveAt(0);
			int num = 0;
			switch (text)
			{
			case "iap_tickets_0":
				num = 5;
				break;
			case "iap_tickets_1":
				num = 20;
				break;
			case "iap_tickets_2":
				num = 100;
				break;
			case "iap_tickets_3":
				num = 200;
				break;
			}
			if (!PromotionsController.singleton.HasPurchased(text))
			{
				PromotionsController.singleton.SetPurchased(text);
				num *= 2;
				bonusEnabledCount--;
			}
			Item item = Inventory.Singleton.MakeReward("event_ticket", 1);
			Inventory.Singleton.AddItem(item, num, updateAchievements: false);
			if (this.OnTicketAmountChanged != null)
			{
				this.OnTicketAmountChanged();
			}
			GameStates.Singleton.TryToSaveProgress();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			crystalCountLabel.Draw(r, r.width >> 1, 0);
			title.Draw(r, offsetX, offsetY);
			purchaseButton1.Draw(r, offsetX, offsetY);
			purchaseButton2.Draw(r, offsetX, offsetY);
			purchaseButton3.Draw(r, offsetX, offsetY);
			purchaseButton4.Draw(r, offsetX, offsetY);
			if (!PromotionsController.singleton.HasPurchased("iap_tickets_0"))
			{
				bonus1.Draw(r, offsetX, offsetY);
			}
			if (!PromotionsController.singleton.HasPurchased("iap_tickets_1"))
			{
				bonus2.Draw(r, offsetX, offsetY);
			}
			if (!PromotionsController.singleton.HasPurchased("iap_tickets_2"))
			{
				bonus3.Draw(r, offsetX, offsetY);
			}
			if (!PromotionsController.singleton.HasPurchased("iap_tickets_3"))
			{
				bonus4.Draw(r, offsetX, offsetY);
			}
			if (bonusEnabledCount > 0)
			{
				footnote.Draw(r, offsetX, offsetY);
			}
		}
	}

	private void UpdateInAppPurchases()
	{
	}

	private void UpdateButtonStates()
	{
		bool flag = InAppPurchaseController.singleton.HasPurchasesToDeliver() || InAppPurchaseController.singleton.HasPendingPurchases();
		cancelButton.isDisabledState = flag;
		purchaseButton1.isDisabledState = flag;
		purchaseButton2.isDisabledState = flag;
		purchaseButton3.isDisabledState = flag;
		purchaseButton4.isDisabledState = flag;
		clickOutsideHides = !flag;
	}

	private bool HasEnoughCrystals(string productId)
	{
		int value = pcCrystalCosts[productId].GetValue();
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("ki_crystal");
		if (firstItemWithId != null)
		{
			return value <= firstItemWithId.count;
		}
		return false;
	}

	private void SubtractCrystals(string productId)
	{
		int value = pcCrystalCosts[productId].GetValue();
		Inventory.Singleton.RemoveItemById("ki_crystal", value);
	}

	private void FlashRed(DialogButton btn)
	{
		flashingButton = btn;
		flashingCountdown = 9;
	}

	private void UpdateFlashingButton()
	{
		if (flashingCountdown >= 0 && flashingButton != null)
		{
			flashingCountdown--;
			if ((flashingCountdown >= 0 && flashingCountdown <= 2) || flashingCountdown >= 7)
			{
				flashingButton.label.color = ColorConstants.red;
				flashingButton.label.ClearColorMask();
			}
			else
			{
				flashingButton.label.color = ColorConstants.white;
				flashingButton.label.SetColorMask(crystalCostMask);
			}
		}
	}

	private void UpdateCrystalCount(bool jumpToValue)
	{
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("ki_crystal");
		targetCrystalCount = ((firstItemWithId != null) ? firstItemWithId.count : 0);
		if (jumpToValue)
		{
			displayCrystalCount = targetCrystalCount;
			UpdateCrystalCountLabel();
		}
	}

	private void UpdateCrystalCountLabel()
	{
		bool flag = false;
		if (displayCrystalCount < targetCrystalCount)
		{
			flag = true;
			if (targetCrystalCount - displayCrystalCount > 20)
			{
				displayCrystalCount += 10;
			}
			else
			{
				displayCrystalCount++;
			}
		}
		else if (displayCrystalCount > targetCrystalCount)
		{
			flag = true;
			if (displayCrystalCount - targetCrystalCount > 20)
			{
				displayCrystalCount -= 10;
			}
			else
			{
				displayCrystalCount--;
			}
		}
		if (flag || crystalCountLabel.Length == 0)
		{
			string text = Utils.FormatNumber(displayCrystalCount);
			crystalCountLabel.SetValue("♦ " + text);
		}
	}

	private void TryPurchase(string productId, DialogButton btn)
	{
		if (HasEnoughCrystals(productId))
		{
			SubtractCrystals(productId);
			SfxController.singleton.Play("buy");
			UpdateCrystalCount(jumpToValue: false);
			bundlesToDeliver.Add(productId);
			SetTicketPurchaseState(TicketPurchaseState.DeliverItems);
		}
		else
		{
			SfxController.singleton.Play("error");
			FlashRed(btn);
		}
	}

	private void HandlePurchase1(DialogButton btn)
	{
		TryPurchase("iap_tickets_0", btn);
	}

	private void HandlePurchase2(DialogButton btn)
	{
		TryPurchase("iap_tickets_1", btn);
	}

	private void HandlePurchase3(DialogButton btn)
	{
		TryPurchase("iap_tickets_2", btn);
	}

	private void HandlePurchase4(DialogButton btn)
	{
		TryPurchase("iap_tickets_3", btn);
	}

	protected override void Start()
	{
		base.Start();
		crystalCountLabel.SetColorMask(crystalCostMask);
		purchaseButton3.label.PositionX--;
		purchaseButton4.label.PositionX--;
	}

	protected override void Awake()
	{
		base.Awake();
		purchaseButton1.OnPressed += HandlePurchase1;
		purchaseButton2.OnPressed += HandlePurchase2;
		purchaseButton3.OnPressed += HandlePurchase3;
		purchaseButton4.OnPressed += HandlePurchase4;
		InitCrystalPrices();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		purchaseButton1.OnPressed -= HandlePurchase1;
		purchaseButton2.OnPressed -= HandlePurchase2;
		purchaseButton3.OnPressed -= HandlePurchase3;
		purchaseButton4.OnPressed -= HandlePurchase4;
	}
}
