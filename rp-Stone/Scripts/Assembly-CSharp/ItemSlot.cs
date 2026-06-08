using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : DialogButton, INewIndicatorProvider
{
	public int iconPosX;

	public AsciiString levelLabel;

	public AsciiString countLabel;

	public AsciiString rarityBonusLabel;

	public int abbreviationsX;

	public int abbreviationsY;

	public int overLevel5CountOffsetY;

	public int overCount1LevelOffsetX = -1;

	public bool showBadge = true;

	public bool lostItemCombineStarAndCount;

	private AsciiSprite _icon;

	private int _count;

	private int countOffsetY;

	private bool isMaxLevel;

	private Color initialLevelLabelColor;

	private Color initialRarityBonusLabelColor;

	private int initialBadgePosX;

	private List<int> abbreviationSymbols;

	private List<Color> abbreviationColors;

	private int lastItemLevel;

	private int lastLostCount;

	private int lastItemCount;

	public Item item { get; set; }

	public AsciiSprite icon => _icon;

	public int count
	{
		get
		{
			return _count;
		}
		set
		{
			_count = value;
			UpdateCountString();
		}
	}

	public void SetContent(Item item, int count)
	{
		this.item = item;
		this.count = count;
		if (item == null)
		{
			_icon = null;
		}
		else
		{
			_icon = item.GetIcon();
			if (item.GetRarityBonus() > 0)
			{
				rarityBonusLabel.SetValue("+" + item.GetRarityBonus());
				ItemData.Rarity.TintString(rarityBonusLabel, initialRarityBonusLabelColor, item);
			}
			else
			{
				rarityBonusLabel.Clear();
			}
		}
		UpdateLevelString();
		UpdateBadge();
		UpdateAbilityAbbreviations();
	}

	public void UpdateBadge()
	{
		if (item == null || item.hasInteracted || !showBadge)
		{
			badge.number = 0;
			return;
		}
		badge.number = -1;
		if (item != null && item.GetRarityType() != ItemData.Rarity.Type.Common)
		{
			badge.badgeString.PositionX = initialBadgePosX + 1;
		}
		else
		{
			badge.badgeString.PositionX = initialBadgePosX;
		}
	}

	private void UpdateAbilityAbbreviations()
	{
		if (abbreviationSymbols != null)
		{
			abbreviationSymbols.Clear();
			abbreviationColors.Clear();
		}
		if (!(item != null) || item.abilities == null || !item.procGenAbilities)
		{
			return;
		}
		for (int i = 0; i < item.abilities.Count; i++)
		{
			ItemData.Ability ability = item.abilities[i];
			if (ability.abbreviation == null || ability.abbreviation.Length <= 0)
			{
				continue;
			}
			Color color = ColorConstants.lightGrey;
			if (ability.applyRarity)
			{
				color = item.GetLabelColor();
				if (color == ColorConstants.white && item.GetRarityType() == ItemData.Rarity.Type.Transcendent)
				{
					color = ColorConstants.black;
				}
			}
			AddAbbreviation(ability.abbreviation[0], color);
		}
	}

	private void AddAbbreviation(int symbol, Color color)
	{
		if (abbreviationSymbols == null)
		{
			abbreviationSymbols = new List<int>();
			abbreviationColors = new List<Color>();
		}
		abbreviationSymbols.Add(symbol);
		abbreviationColors.Add(color);
	}

	private void UpdateLevelString()
	{
		if (item == null || ItemFactory.GetLevelDisplayValueForItem(item) <= 1f)
		{
			levelLabel.Clear();
		}
		else
		{
			countOffsetY = 0;
			isMaxLevel = ItemFactory.GetLevelDisplayIntegerForItem(item) == ItemFactory.MAX_DISPLAY_LEVEL;
			if (lostItemCombineStarAndCount && item.isLost)
			{
				string value;
				if (isMaxLevel)
				{
					value = ItemFactory.GetStarRatingStringForItem(item);
				}
				else
				{
					int lostCount = item.lostCount;
					int nextLostCountGoal = item.GetNextLostCountGoal();
					value = lostCount + "/" + nextLostCountGoal;
					value = ((nextLostCountGoal >= 10) ? ("[" + value + "]") : ("[ " + value + " ]"));
				}
				levelLabel.SetValue(value);
			}
			else if (item.showLevelInTitle)
			{
				string starRatingStringForItem = ItemFactory.GetStarRatingStringForItem(item);
				levelLabel.SetValue(starRatingStringForItem);
				int length = starRatingStringForItem.Length;
				if (length > 5 || (length == 5 && count >= 10) || (length == 4 && count >= 100) || (length == 3 && count >= 1000))
				{
					countOffsetY = overLevel5CountOffsetY;
				}
			}
			else
			{
				levelLabel.Clear();
			}
			if (ItemFactory.GetLevelDisplayIntegerForItem(item) == ItemFactory.MAX_DISPLAY_LEVEL)
			{
				ItemData.Rarity.TintString(levelLabel, ColorConstants.white, item);
			}
			else
			{
				ItemData.Rarity.TintString(levelLabel, initialLevelLabelColor, item);
			}
		}
		lastItemLevel = ((item == null) ? (-1) : item.level);
		lastLostCount = ((item == null) ? (-1) : item.lostCount);
	}

	private void UpdateCountString()
	{
		if (item != null && item.isLost)
		{
			if (ItemFactory.GetLevelDisplayIntegerForItem(item) == ItemFactory.MAX_DISPLAY_LEVEL)
			{
				countLabel.Clear();
			}
			else
			{
				int lostCount = item.lostCount;
				int nextLostCountGoal = item.GetNextLostCountGoal();
				countLabel.SetValue(lostCount + "/" + nextLostCountGoal);
				ItemData.Rarity.TintString(countLabel, initialLevelLabelColor, item);
			}
		}
		else if (count <= 1)
		{
			countLabel.Clear();
		}
		else
		{
			countLabel.SetValue("x" + count);
			countLabel.color = initialLevelLabelColor;
			countLabel.isRainbow = false;
		}
		lastItemCount = count;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (item != null && (lastItemLevel != item.level || lastItemCount != item.count || lastLostCount != item.lostCount))
		{
			UpdateLevelString();
			UpdateCountString();
		}
	}

	public void DrawCountLabel(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int offsetX2 = offsetX + PositionX;
		int num = offsetY + PositionY;
		countLabel.Draw(r, offsetX2, num + countOffsetY);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (item == null)
		{
			return;
		}
		int num = offsetX + PositionX;
		int num2 = offsetY + PositionY;
		if (_icon != null)
		{
			_icon.Draw(r, num + iconPosX, num2 + Height / 2);
		}
		int num3 = ((count > 1) ? overCount1LevelOffsetX : 0);
		if (item != null && item.isLost && !isMaxLevel && !lostItemCombineStarAndCount)
		{
			num3 = -3;
		}
		levelLabel.Draw(r, num + num3, num2);
		if (!item.isLost || !lostItemCombineStarAndCount)
		{
			DrawCountLabel(r, offsetX, offsetY);
		}
		if (abbreviationSymbols != null && abbreviationSymbols.Count > 0)
		{
			int num4 = num + abbreviationsX;
			int y = num2 + abbreviationsY;
			for (int i = 0; i < abbreviationSymbols.Count; i++)
			{
				Color color = abbreviationColors[i];
				if (color == ColorConstants.black)
				{
					color = AsciiString.GetRainbowColor(i, 2);
				}
				r.SetCell(num4, y, abbreviationSymbols[i], color);
				num4++;
			}
		}
		if (IsNewIndicating())
		{
			rarityBonusLabel.Draw(r, num - 1, num2);
		}
		else
		{
			rarityBonusLabel.Draw(r, num, num2);
		}
	}

	public bool IsNewIndicating()
	{
		if (item != null)
		{
			return !item.hasInteracted;
		}
		return false;
	}

	public Color GetNewIndicatorColor()
	{
		return badge.backgroundColor;
	}

	public string GetNewIndicatorString()
	{
		return "!";
	}

	protected override void Awake()
	{
		base.Awake();
		initialLevelLabelColor = levelLabel.color;
		initialRarityBonusLabelColor = rarityBonusLabel.color;
		initialBadgePosX = badge.badgeString.PositionX;
	}
}
