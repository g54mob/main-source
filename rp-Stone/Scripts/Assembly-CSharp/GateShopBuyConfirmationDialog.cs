using System;
using System.Collections.Generic;
using UnityEngine;

public class GateShopBuyConfirmationDialog : ItemDetailsDialog
{
	private const string SHOP_BUY_ALL_ENABLED = "shop_buy_all";

	private const int insufficientResourcesBlinkDuration = 20;

	public Separator verticalSeparator;

	public AsciiString shopHasLabel;

	public AsciiString shopHasCount;

	public AsciiString youHaveLabel;

	public AsciiString youHaveCount;

	public DialogButton buyAllButton;

	public DialogButton buyOneButton;

	public DialogButton buyCashButton;

	public AsciiString costAllLabel;

	public AsciiString costOneLabel;

	public AsciiString costCashLabel;

	public AsciiString doubleKiEventLabel;

	public bool isCrystalShop;

	private ShopData.Entry _entryData;

	private int remainingCount;

	private int insufficientResourcesTicsRemaining;

	private int insufficientAllTicsRemaining;

	private bool shouldDrawBuyButtons;

	private bool showDoubleKiEventLabel;

	private int initialBuyButtonX;

	public ShopData.Entry entryData
	{
		get
		{
			return _entryData;
		}
		protected set
		{
			_entryData = value;
		}
	}

	public bool soldOut { get; private set; }

	public event Action<string> OnTreasuresPurchased;

	public event Action<Item> OnItemPurchased;

	public virtual void Setup(ShopData.Entry entryData, Item inventoryItem = null)
	{
		this.entryData = entryData;
		base.item = inventoryItem;
		MyUpdateContents();
	}

	private void MyUpdateContents()
	{
		if (base.item == null)
		{
			MakeItem();
		}
		shouldDrawBuyButtons = true;
		if (base.item.isLost)
		{
			Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId(base.item.id);
			if (firstItemWithId != null && firstItemWithId.lostCount >= 32 && !(this is LimitedTimeBundleConfirmationDialog))
			{
				shouldDrawBuyButtons = false;
			}
		}
		UpdateItemCountAndCost();
		soldOut = false;
		if (Height < 15)
		{
			Height = 15;
		}
		if ((bool)buyAllButton)
		{
			buyOneButton.PositionY = Height - buyOneButton.Height - 1;
		}
		if (isCrystalShop && entryData.cashCost > 0f)
		{
			buyOneButton.enabled = false;
		}
		else
		{
			buyOneButton.enabled = true;
		}
		int num = Height - 15;
		if ((bool)buyAllButton)
		{
			buyAllButton.PositionY = buyOneButton.PositionY - 5;
			if (num >= 5)
			{
				buyAllButton.PositionY--;
				num--;
			}
		}
		if ((bool)buyCashButton)
		{
			_ = entryData.cashCost;
			_ = 0f;
			buyCashButton.enabled = false;
		}
		shopHasLabel.PositionY = 2 + num / 2;
		shopHasCount.PositionY = shopHasLabel.PositionY + 1;
		if (!ProgressFlags.GetFlag("shop_buy_all"))
		{
			shopHasLabel.PositionY++;
			shopHasCount.PositionY += 2;
		}
		verticalSeparator.length = Height - 2;
		ReCenterVerticalPos();
	}

	private void MakeItem()
	{
		if (entryData.treasures != null && entryData.treasures.Length != 0)
		{
			Item prefabForId = ItemFactory.singleton.GetPrefabForId(entryData.treasures[0]);
			base.item = prefabForId;
			return;
		}
		string text = entryData.itemId;
		if (string.IsNullOrEmpty(text))
		{
			text = entryData.id;
		}
		if (!string.IsNullOrEmpty(text))
		{
			Item item = null;
			if (entryData.rarityBonus > 0)
			{
				int rarityBonus = entryData.rarityBonus;
				ItemData.Rarity rarity = new ItemData.Rarity(ItemData.Rarity.GetTypeForBonus(rarityBonus));
				rarity.levelBonus = rarityBonus;
				rarity.quality = ItemData.Rarity.GetQualityThreshold(rarityBonus);
				rarity.isPerfect = ItemData.Rarity.IsBonusPerfect(rarityBonus);
				item = ItemFactory.singleton.MakeItemWithLevelAndAbilities(text, 1, entryData.element, entryData.rngSeed, rarity);
			}
			else
			{
				item = Inventory.Singleton.MakeReward(text, 1, entryData.element, entryData.rngSeed);
			}
			if (item.isLost)
			{
				ItemFactory.SetItemLevelByDisplayLevel(item, 6f);
			}
			base.item = item;
		}
	}

	private void UpdateItemCountAndCost()
	{
		showDoubleKiEventLabel = entryData.itemId == "ki_crystal" && EventController.singleton.IsEventActive("2xKi");
		remainingCount = entryData.copies.GetValue() - entryData.amountPurchased.GetValue();
		if (showDoubleKiEventLabel)
		{
			shopHasCount.SetValue("  " + remainingCount);
			remainingCount *= 2;
		}
		else
		{
			shopHasCount.SetValue("x" + remainingCount);
		}
		if ((bool)buyAllButton)
		{
			if (remainingCount > 1 && ProgressFlags.GetFlag("shop_buy_all"))
			{
				buyAllButton.enabled = true;
				buyAllButton.label.SetValue(string.Format(Te.xt("Buy All {0}"), remainingCount));
			}
			else
			{
				buyAllButton.enabled = false;
			}
		}
		_SetCostForLabel(ShopController.ComputeKiCostAllRemainingCopies(entryData), costAllLabel);
		_SetCostForLabel(ShopController.ComputeKiCost(entryData), costOneLabel);
		if (entryData.cashCost > 0f)
		{
			string localizedPriceString = InAppPurchaseController.singleton.GetLocalizedPriceString(entryData.GetPurchaseId());
			costCashLabel.SetValue(localizedPriceString);
		}
	}

	private void _SetCostForLabel(int cost, AsciiString label)
	{
		if (isCrystalShop)
		{
			label.SetValue("♦ " + Utils.FormatNumber(cost));
			label.SetColorMask(new List<Color> { Color.magenta });
		}
		else
		{
			label.SetValue("@" + Utils.FormatNumber(cost));
			label.color = ((cost > Money()) ? ColorConstants.darkGrey : ColorConstants.white);
		}
	}

	protected override void UpdateIcon()
	{
		if (string.IsNullOrEmpty(entryData.iconId))
		{
			base.UpdateIcon();
		}
		else
		{
			icon = IconLoader.Singleton.GetSharedIcon(entryData.iconId);
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		insufficientResourcesTicsRemaining--;
		insufficientAllTicsRemaining--;
		if ((bool)buyAllButton && buyAllButton.enabled)
		{
			buyAllButton.UpdateTic();
		}
		if ((bool)buyOneButton && buyOneButton.enabled)
		{
			buyOneButton.UpdateTic();
		}
		if ((bool)buyCashButton && buyCashButton.enabled)
		{
			buyCashButton.isDisabledState = InAppPurchaseController.singleton.HasPendingPurchases();
			buyCashButton.UpdateTic();
		}
		UpdateShowBuyButton();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY;
		if (base.CurrentState != State.Idle && !base.forceDrawRegardlessOfState)
		{
			return;
		}
		verticalSeparator.Draw(r, offsetX, offsetY);
		if (remainingCount > 0)
		{
			shopHasLabel.Draw(r, offsetX, offsetY);
			shopHasCount.Draw(r, offsetX, offsetY);
		}
		if (shouldDrawBuyButtons)
		{
			if ((bool)buyAllButton && buyAllButton.enabled)
			{
				buyAllButton.Draw(r, offsetX, offsetY);
			}
			if (buyOneButton.enabled)
			{
				if ((bool)buyAllButton || ((bool)buyCashButton && buyCashButton.enabled) || icon == null)
				{
					buyOneButton.Draw(r, offsetX, offsetY);
				}
				else
				{
					buyOneButton.Draw(r, offsetX, icon.lastDrawY);
				}
			}
			int num = buyOneButton.Width / 2;
			if ((bool)buyAllButton && buyAllButton.enabled)
			{
				int offsetX2 = offsetX + buyAllButton.PositionX + num;
				int offsetY2 = offsetY + buyAllButton.PositionY;
				if (_BlinkColor(insufficientAllTicsRemaining))
				{
					costAllLabel.Draw(r, offsetX2, offsetY2, ColorConstants.red);
				}
				else
				{
					costAllLabel.Draw(r, offsetX2, offsetY2);
				}
			}
			if (buyOneButton.enabled)
			{
				int offsetX2 = offsetX + buyOneButton.PositionX + num;
				int offsetY2 = buyOneButton.lastDrawY;
				if (_BlinkColor(insufficientResourcesTicsRemaining))
				{
					costOneLabel.Draw(r, offsetX2, offsetY2, ColorConstants.red);
				}
				else
				{
					costOneLabel.Draw(r, offsetX2, offsetY2);
				}
			}
			if ((bool)buyCashButton && buyCashButton.enabled)
			{
				if (icon != null && !buyOneButton.enabled && entryData.baseCost.GetValue() == 0)
				{
					buyCashButton.Draw(r, offsetX, icon.lastDrawY - 1);
				}
				else
				{
					buyCashButton.Draw(r, offsetX, offsetY);
				}
				int offsetX2 = offsetX + buyCashButton.PositionX + num;
				int offsetY2 = buyCashButton.lastDrawY;
				costCashLabel.Draw(r, offsetX2, offsetY2);
			}
		}
		if (showDoubleKiEventLabel)
		{
			doubleKiEventLabel.Draw(r, offsetX + shopHasCount.PositionX, offsetY + shopHasCount.PositionY);
		}
	}

	private bool _BlinkColor(int ticsRemaining)
	{
		if (ticsRemaining > 0)
		{
			int num = 10;
			int num2 = num >> 1;
			if (ticsRemaining % num > num2)
			{
				return true;
			}
		}
		return false;
	}

	private long Money()
	{
		if (isCrystalShop)
		{
			Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("ki_crystal");
			if (firstItemWithId != null)
			{
				return firstItemWithId.count;
			}
			return 0L;
		}
		return InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi);
	}

	private void HandleBuyAllPressed(DialogButton button)
	{
		if (!isCrystalShop || !(entryData.cashCost > 0f))
		{
			int num = ShopController.ComputeKiCostAllRemainingCopies(entryData);
			if (num > Money())
			{
				insufficientAllTicsRemaining = 20;
				SfxController.singleton.Play("click");
				return;
			}
			_DeductMoney(num);
			_GrantItem(entryData.copies.GetValue() - entryData.amountPurchased.GetValue());
			entryData.amountPurchased = entryData.copies;
			_CheckSoldOut();
			SfxController.singleton.Play("buy");
		}
	}

	private void HandleBuyOnePressed(DialogButton button)
	{
		if (!isCrystalShop || !(entryData.cashCost > 0f))
		{
			int num = ShopController.ComputeKiCost(entryData);
			if (num > Money())
			{
				insufficientResourcesTicsRemaining = 20;
				SfxController.singleton.Play("click");
				return;
			}
			_DeductMoney(num);
			_GrantItem(1);
			++entryData.amountPurchased;
			_CheckSoldOut();
			SfxController.singleton.Play("buy");
		}
	}

	private void HandleBuyCashPressed(DialogButton button)
	{
		InAppPurchaseController.singleton.BuyProduct(entryData.GetPurchaseId());
		if (entryData.copies.GetValue() > 0 && entryData.itemId != "ki_crystal")
		{
			++entryData.amountPurchased;
			_CheckSoldOut();
		}
		SfxController.singleton.Play("click");
	}

	private void _GrantItem(int amount)
	{
		if (!(base.item != null))
		{
			return;
		}
		if (IsTreasure())
		{
			while (--amount >= 0)
			{
				for (int i = 0; i < entryData.treasures.Length; i++)
				{
					if (this.OnTreasuresPurchased != null)
					{
						this.OnTreasuresPurchased(entryData.treasures[i]);
					}
					else
					{
						Utils.LogError("Treasure " + entryData.treasures[i] + " purchased, but nobody is listening to the OnTreasuresPurchased event");
					}
				}
			}
		}
		else
		{
			base.item = Inventory.Singleton.GainItem(base.item, amount);
			if (this.OnItemPurchased != null)
			{
				this.OnItemPurchased(base.item);
			}
			MyUpdateContents();
		}
		ShopController.singleton.totalPurchases++;
	}

	private void _DeductMoney(long amount)
	{
		if (isCrystalShop)
		{
			Inventory.Singleton.RemoveItemById("ki_crystal", (int)amount);
		}
		else
		{
			InventoryResources.singleton.RemoveResourceOfType(Data.Resource.Xi, amount);
		}
	}

	private void _CheckSoldOut()
	{
		if (entryData.amountPurchased >= entryData.copies && entryData.copies.GetValue() >= 0)
		{
			if (!IsTreasure())
			{
				ProgressFlags.SetFlag("shop_buy_all");
			}
			soldOut = true;
			Hide();
		}
		else if (IsTreasure())
		{
			Hide();
		}
		else
		{
			UpdateItemCountAndCost();
			if (isCrystalShop)
			{
				HideBuyButton();
			}
		}
	}

	private void HideBuyButton()
	{
		buyOneButton.PositionX += 120;
	}

	private void UpdateShowBuyButton()
	{
		if (buyOneButton.PositionX > initialBuyButtonX)
		{
			buyOneButton.PositionX--;
			if (buyOneButton.PositionX <= initialBuyButtonX + 100)
			{
				buyOneButton.PositionX = initialBuyButtonX;
			}
		}
	}

	public bool IsTreasure()
	{
		if (entryData != null && entryData.treasures != null)
		{
			return entryData.treasures.Length != 0;
		}
		return false;
	}

	protected override void Start()
	{
		base.Start();
		if ((bool)buyAllButton)
		{
			buyAllButton.OnPressed += HandleBuyAllPressed;
		}
		if ((bool)buyOneButton)
		{
			buyOneButton.OnPressed += HandleBuyOnePressed;
		}
		if ((bool)buyCashButton)
		{
			buyCashButton.OnPressed += HandleBuyCashPressed;
		}
		initialBuyButtonX = buyOneButton.PositionX;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if ((bool)buyAllButton)
		{
			buyAllButton.OnPressed -= HandleBuyAllPressed;
		}
		if ((bool)buyOneButton)
		{
			buyOneButton.OnPressed -= HandleBuyOnePressed;
		}
		if ((bool)buyCashButton)
		{
			buyCashButton.OnPressed -= HandleBuyCashPressed;
		}
	}
}
