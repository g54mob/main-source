using System;
using System.Collections.Generic;
using UnityEngine;

public class EventRewardsColumn : AsciiObject
{
	public DialogButton topButton;

	public DialogButton botButton;

	public AsciiString topCountLabel;

	public AsciiString botCountLabel;

	public AsciiString topRarityLabel;

	public AsciiString botRarityLabel;

	public AsciiString topLevelLabel;

	public int lockSymbol = 19;

	public Color lockColor;

	public int lockX = 4;

	public int lockY = 8;

	private string eventSignature;

	private DateTime eventStartDate;

	private AsciiSprite topSprite;

	private AsciiSprite botSprite;

	private bool _grayedOut;

	private List<Color> grayTextMask = new List<Color>
	{
		ColorConstants.lightGrey,
		ColorConstants.lightGrey,
		ColorConstants.lightGrey,
		ColorConstants.lightGrey,
		ColorConstants.lightGrey,
		ColorConstants.lightGrey,
		ColorConstants.lightGrey,
		ColorConstants.lightGrey
	};

	private float flashValue;

	private Color bgFlashColor = Color.black;

	private bool isFlashingBG;

	public Data.EventReward topData { get; private set; }

	public Data.EventReward botData { get; private set; }

	public bool drawLock { get; set; }

	public int maxEnchantmentBonus { get; set; }

	public int maxTreasureLevel { get; set; }

	public bool isGrayedOut
	{
		get
		{
			return _grayedOut;
		}
		set
		{
			_grayedOut = value;
			UpdateGrayedOutLabels();
		}
	}

	public bool isBestFreeReward { get; set; }

	public event Action<Item, Data.EventReward> OnItemSelected;

	public void Setup(Data.EventReward topReward, Data.EventReward botReward, string eventSignature, DateTime eventStartDate)
	{
		topData = topReward;
		botData = botReward;
		this.eventSignature = eventSignature;
		this.eventStartDate = eventStartDate;
		topSprite = GetIcon(topReward);
		botSprite = GetIcon(botReward);
		SetCountLabel(topReward, topCountLabel);
		SetCountLabel(botReward, botCountLabel);
		SetRarityLabel(topReward, topRarityLabel);
		SetRarityLabel(botReward, botRarityLabel);
		SetLevelLabel(topReward, topLevelLabel);
	}

	private AsciiSprite GetIcon(Data.EventReward entryData)
	{
		if (!string.IsNullOrEmpty(entryData.iconPath))
		{
			return IconLoader.Singleton.GetSharedIcon(entryData.iconPath);
		}
		if (entryData.item != null)
		{
			return entryData.item.GetIcon();
		}
		Item item = null;
		if (!string.IsNullOrEmpty(entryData.itemId))
		{
			item = ItemFactory.singleton.GetPrefabForId(entryData.itemId);
		}
		if (item != null)
		{
			if (entryData.cosmeticId != null)
			{
				CosmeticController.Collection collection = CosmeticController.singleton.GetCollection(entryData.cosmeticId);
				Cosmetic cosmetic = (Cosmetic)(entryData.item = CosmeticController.singleton.InstantiateCosmeticItem(new CosmeticController.ItemEntry(entryData.itemId, entryData.element), collection));
				return cosmetic.GetIcon();
			}
			ItemData.Rarity.Type baseRarity = ItemData.Rarity.Type.Common;
			if (entryData.rarityBonus > 0)
			{
				baseRarity = ItemData.Rarity.GetTypeForBonus(entryData.rarityBonus);
			}
			return IconLoader.Singleton.GetSharedIcon(item.iconPath, 'o', ItemData.CharForElement(entryData.element), baseRarity);
		}
		Utils.LogErrorIfEditor("Couldn't find reward icon for data: " + entryData);
		return null;
	}

	private void SetCountLabel(Data.EventReward data, AsciiString label)
	{
		if (data.count > 1)
		{
			label.SetValue("x" + Utils.FormatNumber(data.count));
		}
		else
		{
			label.Clear();
		}
	}

	private void SetRarityLabel(Data.EventReward data, AsciiString label)
	{
		int rarityBonus = data.rarityBonus;
		if (rarityBonus > 0)
		{
			label.SetValue("+" + rarityBonus);
			if (rarityBonus >= 16)
			{
				label.isRainbow = true;
				return;
			}
			label.color = ItemData.Rarity.GetColorForBonus(rarityBonus);
			label.isRainbow = false;
		}
		else
		{
			label.Clear();
		}
	}

	private void SetLevelLabel(Data.EventReward data, AsciiString label)
	{
		int level = data.level;
		if (level > 0)
		{
			string starRatingStringForDisplayLevel = ItemFactory.GetStarRatingStringForDisplayLevel(level);
			label.SetValue(starRatingStringForDisplayLevel);
		}
		else
		{
			label.Clear();
		}
	}

	private void UpdateGrayedOutLabels()
	{
		if (isGrayedOut)
		{
			topCountLabel.SetColorMask(grayTextMask);
			botCountLabel.SetColorMask(grayTextMask);
			topRarityLabel.SetColorMask(grayTextMask);
			botRarityLabel.SetColorMask(grayTextMask);
			topLevelLabel.SetColorMask(grayTextMask);
		}
		else
		{
			topCountLabel.ClearColorMask();
			botCountLabel.ClearColorMask();
			topRarityLabel.ClearColorMask();
			botRarityLabel.ClearColorMask();
			topLevelLabel.ClearColorMask();
		}
	}

	public void FlashRewardsWhite()
	{
		flashValue = 4f;
		bgFlashColor = ColorConstants.grey;
		isFlashingBG = true;
	}

	public override void UpdateTic()
	{
		topButton.UpdateTic();
		botButton.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		topButton.Draw(r, offsetX, offsetY);
		botButton.Draw(r, offsetX, offsetY);
		offsetX += lockX;
		float t = Time.deltaTime * 3f;
		flashValue = Mathf.Lerp(flashValue, 0f, t);
		if (topSprite != null)
		{
			topSprite.DrawColorAdd(r, offsetX + topData.iconX, offsetY + 2 + topData.iconY, Color.white * flashValue);
		}
		if (botSprite != null)
		{
			botSprite.DrawColorAdd(r, offsetX + botData.iconX, offsetY + 10 + botData.iconY, Color.white * flashValue);
		}
		topCountLabel.Draw(r, offsetX + topData.countX, offsetY + 2 + topData.countY);
		botCountLabel.Draw(r, offsetX + botData.countX, offsetY + 10 + botData.countY);
		topRarityLabel.Draw(r, offsetX + topData.rarityX, offsetY + topData.rarityY);
		botRarityLabel.Draw(r, offsetX + botData.rarityX, offsetY + botData.rarityY);
		topLevelLabel.Draw(r, offsetX, offsetY + topData.levelY);
		if (isGrayedOut || (!isBestFreeReward && topData.IsSpecialEventTreasure()))
		{
			for (int i = -5; i <= 5; i++)
			{
				for (int j = 0; j <= 6; j++)
				{
					if (!r.IsClipped(offsetX + i, offsetY + j))
					{
						AsciiCellProcedural cell = r.GetCell(offsetX + i, offsetY + j);
						if (cell != null)
						{
							Color foreground = cell.GetForeground();
							float num = foreground.r * 0.3f + foreground.g * 0.59f + foreground.b * 0.11f;
							Color foreground2 = new Color(num, num, num, foreground.a);
							cell.SetForeground(foreground2);
						}
					}
				}
			}
		}
		if (drawLock || isGrayedOut)
		{
			for (int k = -5; k <= 5; k++)
			{
				for (int l = 7; l <= 12; l++)
				{
					if (r.IsClipped(offsetX + k, offsetY + l))
					{
						continue;
					}
					AsciiCellProcedural cell2 = r.GetCell(offsetX + k, offsetY + l);
					if (cell2 != null)
					{
						if (isGrayedOut)
						{
							Color foreground3 = cell2.GetForeground();
							float num2 = foreground3.r * 0.3f + foreground3.g * 0.59f + foreground3.b * 0.11f;
							Color foreground4 = new Color(num2, num2, num2, foreground3.a);
							cell2.SetForeground(foreground4);
						}
						else
						{
							cell2.foregroundColor *= 0.4f;
						}
					}
				}
			}
		}
		if (drawLock)
		{
			r.SetCell(offsetX, offsetY + lockY + botData.lockY, lockSymbol, lockColor);
		}
		if (isGrayedOut)
		{
			for (int m = -5; m <= 5; m++)
			{
				for (int n = 0; n <= 12; n++)
				{
					if (!r.IsClipped(offsetX + m, offsetY + n))
					{
						AsciiCellProcedural cell3 = r.GetCell(offsetX + m, offsetY + n);
						if (cell3 != null)
						{
							Color foreground5 = cell3.GetForeground();
							float num3 = foreground5.r * 0.3f + foreground5.g * 0.59f + foreground5.b * 0.11f;
							Color foreground6 = new Color(num3, num3, num3, foreground5.a);
							cell3.SetForeground(foreground6);
						}
					}
				}
			}
		}
		if (!isFlashingBG)
		{
			return;
		}
		if (flashValue < 0.01f)
		{
			isFlashingBG = false;
			bgFlashColor = Color.black;
		}
		else
		{
			bgFlashColor = Color.Lerp(bgFlashColor, Color.black, t);
		}
		for (int num4 = -5; num4 < Width - 3; num4++)
		{
			for (int num5 = 0; num5 < Height; num5++)
			{
				if (!r.IsClipped(offsetX + num4, offsetY + num5))
				{
					AsciiCellProcedural cell4 = r.GetCell(offsetX + num4, offsetY + num5);
					if (cell4 != null)
					{
						cell4.backgroundColor = bgFlashColor;
					}
				}
			}
		}
	}

	private void FireItemPressed(Data.EventReward entryData)
	{
		if (this.OnItemSelected == null)
		{
			return;
		}
		if (entryData.item != null)
		{
			this.OnItemSelected(entryData.item, entryData);
			return;
		}
		Item item = null;
		if (!string.IsNullOrEmpty(entryData.itemId))
		{
			if (entryData.IsTreasure())
			{
				item = ItemFactory.singleton.GetPrefabForId(entryData.itemId);
				EventTreasureItem component = item.GetComponent<EventTreasureItem>();
				if (component != null)
				{
					component.maxEnchantmentBonus = maxEnchantmentBonus;
					component.maxTreasureLevel = maxTreasureLevel;
				}
				if (entryData.IsSpecialEventTreasure())
				{
					item.signature = eventSignature;
				}
			}
			else
			{
				item = EventRewards.InstantiateItem(entryData, eventStartDate);
			}
		}
		entryData.item = item;
		this.OnItemSelected(item, entryData);
	}

	private void HandleTopButtonPressed(DialogButton btn)
	{
		FireItemPressed(topData);
	}

	private void HandleBotButtonPressed(DialogButton btn)
	{
		FireItemPressed(botData);
	}

	private void Awake()
	{
		topButton.OnPressed += HandleTopButtonPressed;
		botButton.OnPressed += HandleBotButtonPressed;
	}
}
