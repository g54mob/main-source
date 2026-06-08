using System;

public class GateShopSlot : DialogButton
{
	public enum Mode
	{
		Normal = 0,
		Sold = 1
	}

	public int iconPosX;

	public int iconPosY;

	public int maxNameCharactersPerLine = 11;

	public AsciiString nameLabel0;

	public AsciiString nameLabel1;

	public AsciiString nameLabel2;

	public AsciiString nameLabel3;

	public AsciiString costLabel;

	public AsciiString kiRewardLabel;

	public AsciiString itemCountLabel;

	public AsciiString soldLabel;

	public int tallIconOffsetY = 1;

	[NonSerialized]
	public ShopData.Entry entry;

	protected AsciiSprite icon;

	private int label2_defaultY;

	private bool hadEnoughMoney;

	public Mode mode { get; set; }

	public bool isWatchToEarn { get; private set; }

	public virtual void SetContent(ShopData.Entry entryData)
	{
		entry = entryData;
		mode = Mode.Normal;
		isWatchToEarn = false;
		kiRewardLabel.Clear();
		if (entryData.id.StartsWith("watch_to_earn"))
		{
			isWatchToEarn = true;
			SetupAsWatchToEarn(entryData);
		}
		else if (entryData.treasures != null && entryData.treasures.Length != 0)
		{
			SetupAsTreasure(entryData);
		}
		else
		{
			SetupAsItem(entryData);
		}
	}

	private void SetupAsItem(ShopData.Entry entryData)
	{
		int value = entryData.copies.GetValue();
		int num = value - entryData.amountPurchased.GetValue();
		if (value >= 0 && num <= 0)
		{
			mode = Mode.Sold;
			icon = null;
			ClearTitle();
			return;
		}
		Item itemPrefab = null;
		if (!string.IsNullOrEmpty(entryData.itemId))
		{
			itemPrefab = ItemFactory.singleton.GetPrefabForId(entryData.itemId);
		}
		else if (!string.IsNullOrEmpty(entryData.id))
		{
			itemPrefab = ItemFactory.singleton.GetPrefabForId(entryData.id);
		}
		SetupIcon(entryData, itemPrefab);
		SetupTitle(entryData, itemPrefab);
		SetupCost(entryData);
		SetupCount(entryData);
	}

	private void SetupAsTreasure(ShopData.Entry entryData)
	{
		int value = entryData.copies.GetValue();
		int num = value - entryData.amountPurchased.GetValue();
		if (value >= 0 && num <= 0)
		{
			mode = Mode.Sold;
			return;
		}
		Item prefabForId = ItemFactory.singleton.GetPrefabForId(entryData.treasures[0]);
		SetupIcon(entryData, prefabForId);
		SetupTitle(entryData, prefabForId);
		SetupCost(entryData);
		SetupCount(entryData);
	}

	private void SetupAsKiPurchase(ShopData.Entry entryData)
	{
	}

	private void SetupAsWatchToEarn(ShopData.Entry entryData)
	{
		int value = entryData.copies.GetValue();
		int num = value - entryData.amountPurchased.GetValue();
		if (value >= 0 && num <= 0)
		{
			mode = Mode.Sold;
			icon = null;
			ClearTitle();
		}
		else
		{
			SetupIcon(entryData);
			SetupTitle(entryData);
			int num2 = entry.kiReward.GetValue() + entry.kiPerLevel.GetValue() * XPController.singleton.currentLevel;
			kiRewardLabel.SetValue("+@" + Utils.FormatNumber(num2));
			costLabel.Clear();
		}
	}

	protected virtual void SetupIcon(ShopData.Entry entryData, Item itemPrefab = null)
	{
		if (entryData.iconId != null && entryData.iconId != "")
		{
			icon = IconLoader.Singleton.GetSharedIcon(entryData.iconId);
		}
		else if (itemPrefab != null)
		{
			ItemData.Rarity.Type baseRarity = ItemData.Rarity.Type.Common;
			if (entryData.rarityBonus > 0)
			{
				baseRarity = ItemData.Rarity.GetTypeForBonus(entryData.rarityBonus);
			}
			icon = IconLoader.Singleton.GetSharedIcon(itemPrefab.iconPath, 'o', ItemData.CharForElement(entryData.element), baseRarity);
		}
		else
		{
			mode = Mode.Sold;
		}
	}

	protected virtual void SetupTitle(ShopData.Entry entryData, Item itemPrefab = null)
	{
		if (entryData.title != null)
		{
			SetTitle(Te.xt(entryData.title));
		}
		else if (itemPrefab != null)
		{
			string enchantmentDisplayName;
			if (entryData.rarityBonus > 0 && itemPrefab.id == "enchantment")
			{
				enchantmentDisplayName = EnchantmentWeapon.GetEnchantmentDisplayName(ItemData.Rarity.GetTypeForBonus(entryData.rarityBonus));
				enchantmentDisplayName = Te.xt(enchantmentDisplayName);
			}
			else
			{
				enchantmentDisplayName = Te.xt(itemPrefab.displayName);
			}
			string newValue = Te.xt(ItemData.ReplacementTidForElement(entryData.element));
			enchantmentDisplayName = enchantmentDisplayName.Replace("<element>", newValue);
			if (entryData.rarityBonus > 0)
			{
				enchantmentDisplayName = enchantmentDisplayName + " +" + entryData.rarityBonus;
			}
			SetTitle(enchantmentDisplayName);
		}
	}

	protected virtual void SetupCost(ShopData.Entry entryData)
	{
		int num = ShopController.ComputeKiCost(entryData);
		if (entryData.cashCost > 0f)
		{
			if (num > 0)
			{
				costLabel.Clear();
				return;
			}
			string localizedPriceString = InAppPurchaseController.singleton.GetLocalizedPriceString(entryData.id);
			costLabel.SetValue(localizedPriceString);
			costLabel.color = ColorConstants.white;
		}
		else
		{
			costLabel.SetValue("@" + Utils.FormatNumber(num));
			UpdateCostColor();
		}
	}

	private void SetupCount(ShopData.Entry entryData)
	{
		int num = entryData.copies.GetValue() - entryData.amountPurchased.GetValue();
		if (num > 1)
		{
			if (entryData.itemId == "ki_crystal" && EventController.singleton.IsEventActive("2xKi"))
			{
				num *= 2;
			}
			itemCountLabel.SetValue("x" + num);
		}
		else
		{
			itemCountLabel.Clear();
		}
	}

	private void ClearTitle()
	{
		nameLabel0.Clear();
		nameLabel1.Clear();
		nameLabel2.Clear();
		nameLabel3.Clear();
	}

	private void SetTitle(string title)
	{
		if (string.IsNullOrEmpty(title))
		{
			ClearTitle();
			return;
		}
		string[] array = Utils.InsertLineBreaks(title, maxNameCharactersPerLine).Split(new char[1] { '\n' });
		if (array.Length == 1)
		{
			nameLabel0.Clear();
			nameLabel1.Clear();
			nameLabel2.SetValue(array[0].Trim());
			nameLabel3.Clear();
			nameLabel2.PositionY = label2_defaultY;
		}
		else if (array.Length == 2)
		{
			nameLabel0.Clear();
			nameLabel1.SetValue(array[0].Trim());
			nameLabel2.SetValue(array[1].Trim());
			nameLabel3.Clear();
		}
		else if (array.Length == 3)
		{
			nameLabel0.SetValue(array[0].Trim());
			nameLabel1.SetValue(array[1].Trim());
			nameLabel2.SetValue(array[2].Trim());
			nameLabel3.Clear();
		}
		else if (array.Length >= 4)
		{
			nameLabel0.SetValue(array[0].Trim());
			nameLabel1.SetValue(array[1].Trim());
			nameLabel2.SetValue(array[2].Trim());
			nameLabel3.SetValue(array[3].Trim());
		}
		if (array.Length >= 3 && nameLabel1.PositionY <= nameLabel0.PositionY)
		{
			nameLabel1.PositionY = nameLabel0.PositionY + 1;
		}
		if (array.Length >= 2 && nameLabel2.PositionY <= nameLabel1.PositionY)
		{
			nameLabel2.PositionY = nameLabel1.PositionY + 1;
		}
		if (array.Length >= 2 && nameLabel3.PositionY <= nameLabel2.PositionY)
		{
			nameLabel3.PositionY = nameLabel2.PositionY + 1;
		}
	}

	private void UpdateCostColor()
	{
		if (HasEnoughMoney())
		{
			costLabel.color = ColorConstants.white;
		}
		else
		{
			costLabel.color = ColorConstants.darkGrey;
		}
	}

	public override void UpdateTic()
	{
		if (mode == Mode.Normal)
		{
			base.UpdateTic();
			if (hadEnoughMoney != HasEnoughMoney())
			{
				hadEnoughMoney = HasEnoughMoney();
				UpdateCostColor();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		int num = offsetX + PositionX;
		int num2 = offsetY + PositionY;
		if (mode == Mode.Sold)
		{
			soldLabel.Draw(r, num, num2);
			return;
		}
		int num3 = ((icon != null && icon.height > 3) ? tallIconOffsetY : 0);
		if (icon != null)
		{
			icon.Draw(r, num + iconPosX, num2 + iconPosY + num3);
		}
		DrawName(r, offsetX, offsetY);
		kiRewardLabel.Draw(r, num, num2 + num3);
		costLabel.Draw(r, num, num2 + num3);
		itemCountLabel.Draw(r, num, num2 + num3);
	}

	protected void DrawName(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int offsetX2 = offsetX + PositionX;
		int offsetY2 = offsetY + PositionY;
		nameLabel0.Draw(r, offsetX2, offsetY2);
		nameLabel1.Draw(r, offsetX2, offsetY2);
		nameLabel2.Draw(r, offsetX2, offsetY2);
	}

	private bool HasEnoughMoney()
	{
		return InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi) >= ShopController.ComputeKiCost(entry);
	}

	protected override void Awake()
	{
		base.Awake();
		label2_defaultY = nameLabel1.PositionY;
	}
}
