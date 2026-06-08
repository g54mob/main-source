using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetailsDialog : DialogNineSlice
{
	private enum ItemDetailsState
	{
		Normal = 0,
		ColorPicker = 1
	}

	public int maxLayoutHeight = 23;

	public AsciiString title;

	public AsciiString lostSubtitle;

	public AsciiString signature;

	public int iconPadTop;

	public int iconPosX;

	public int iconPosY;

	public AsciiString itemCountLabel;

	public int baseStatsOffsetY;

	public int baseStatsColumnCount = 3;

	public int baseStatsColumnSpacing = 12;

	public int baseStatsRowSpacing = 1;

	public AsciiString baseStatLabel;

	public AsciiString baseStatValue;

	private List<AsciiString> baseStatLabelList = new List<AsciiString>();

	private List<AsciiString> baseStatValueList = new List<AsciiString>();

	private Stack<AsciiString> baseStatLabelPool = new Stack<AsciiString>();

	public Separator separator;

	public int descriptionPadTop;

	public int descriptionMaxWidth = 9999;

	public AsciiString descriptionLine1;

	public DialogButton closeButton;

	public DialogButton rerollEnchantmentButton;

	public AsciiString rerollCost;

	public AsciiString rerollDiscount;

	public XPBar xpBarPrefab;

	private XPBar xpBar;

	public SettingsToggleButton bigHeadToggle;

	public AsciiString bigHeadLabel;

	public AsciiColorPicker colorPicker;

	public DialogButton useButton;

	public DialogButton applyButton;

	public DialogButton editButton;

	private AsciiObject[] _customButtons;

	private int customButtonsTotalWidth;

	private int customElementsLayoutHeight;

	private Item _item;

	protected AsciiSprite icon;

	private bool isIconTall;

	private List<AsciiString> descriptionLines = new List<AsciiString>();

	private int initialHeight;

	private int initialPosY;

	private int initialDescriptionPosY;

	protected bool trimTop;

	protected bool trimSeparator;

	protected bool trimBasicStats;

	protected bool trimIconTop;

	private Color initialTitleColor;

	private Color initialDescriptionColor;

	private Color initialBorderColor;

	private int insufficientKiForReroll;

	private ItemDetailsState currentItemDetailsState;

	private PrismaticCosmetic prismaticCosmetic;

	private int _basicStatsLayoutSpaceY;

	private int _basicStatsRowCount;

	private Stack<AsciiString> descriptionLinePool = new Stack<AsciiString>();

	private AsciiObject[] customButtons
	{
		get
		{
			if (_customButtons == null)
			{
				_customButtons = new AsciiObject[3] { useButton, applyButton, editButton };
			}
			return _customButtons;
		}
	}

	public Item item
	{
		get
		{
			return _item;
		}
		set
		{
			_item = value;
			if (_item != null)
			{
				UpdateContents();
			}
		}
	}

	public bool hasReroll { get; set; }

	public bool forceDrawRegardlessOfState { get; set; }

	private void SetItemDetailsState(ItemDetailsState newState)
	{
		if (newState == ItemDetailsState.ColorPicker)
		{
			prismaticCosmetic = item as PrismaticCosmetic;
			if (prismaticCosmetic != null)
			{
				colorPicker.SetStartingColor(prismaticCosmetic.customColor);
			}
			colorPicker.Show();
		}
		currentItemDetailsState = newState;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (closeButton != null)
		{
			closeButton.UpdateTic();
		}
		if (IsXP())
		{
			xpBar.UpdateTic();
		}
		if (HasReroll())
		{
			rerollEnchantmentButton.UpdateTic();
			insufficientKiForReroll--;
		}
		if (IsMoonStone() || IsMindStone())
		{
			bigHeadToggle.UpdateTic();
		}
		for (int i = 0; i < customButtons.Length; i++)
		{
			AsciiObject asciiObject = customButtons[i];
			if (asciiObject != null && asciiObject.enabled)
			{
				asciiObject.UpdateTic();
			}
		}
		if (currentItemDetailsState != ItemDetailsState.ColorPicker)
		{
			return;
		}
		colorPicker.UpdateTic();
		if (prismaticCosmetic != null)
		{
			prismaticCosmetic.customColor = colorPicker.currentColor;
			ApplyBorderColor(prismaticCosmetic.GetCosmeticLabelColor(null));
		}
		if (colorPicker.CurrentState != State.Disabled)
		{
			return;
		}
		if (prismaticCosmetic != null && prismaticCosmetic.targetItem != null && prismaticCosmetic.targetItem.appliedGroupId != null)
		{
			Weapon weapon = Inventory.Singleton.GetItem(prismaticCosmetic.targetItem.appliedGroupId) as Weapon;
			if (weapon != null)
			{
				weapon.cosmetic = null;
				weapon.ReloadSprites();
			}
		}
		SetItemDetailsState(ItemDetailsState.Normal);
	}

	protected virtual void UpdateContents()
	{
		ItemData.Rarity.Type rarityType = item.GetRarityType();
		string text = item.GetName();
		if (item.level >= 1 && item.showLevelInTitle)
		{
			string starRatingStringForItem = ItemFactory.GetStarRatingStringForItem(item);
			text = starRatingStringForItem + " " + text + " " + starRatingStringForItem;
		}
		title.SetValue(text);
		ItemData.Rarity.TintString(title, initialTitleColor, item);
		if (item.isSigned)
		{
			signature.SetValue(item.signature);
		}
		else
		{
			signature.Clear();
		}
		GameStates singleton = GameStates.Singleton;
		WorkstationScreen.State state = singleton.workstationScreen.currentState;
		hasReroll = rarityType != ItemData.Rarity.Type.Common && item.id != "enchantment" && singleton.CurrentState == GameStates.State.WorkstationScreen && (state == WorkstationScreen.State.Anvil || state == WorkstationScreen.State.MoondialStone);
		if (hasReroll)
		{
			ItemData.Rarity.TintString(rerollEnchantmentButton.label, ColorConstants.lightGrey, item);
			rerollCost.SetValue(MakeCostString(item.ComputeRerollCost()));
			if (HamartiaEventController.IsEventActive())
			{
				rerollDiscount.SetValue("-90%");
			}
			else
			{
				rerollDiscount.Clear();
			}
		}
		UpdateIcon();
		isIconTall = icon != null && icon.height >= 5;
		if (IsXP())
		{
			XPController singleton2 = XPController.singleton;
			xpBar.levelNumber = singleton2.currentLevel;
			xpBar.startXP = singleton2.currentXP;
			xpBar.endXP = singleton2.currentXP;
			xpBar.totalXP = singleton2.nextXpThreshold;
			xpBar.isMaxLevel = singleton2.isMaxLevel;
			xpBar.RefreshVisuals();
			xpBar.PrepareToShow();
		}
		try
		{
			if (icon != null)
			{
				AsciiSpritePPRainbow component = icon.GetComponent<AsciiSpritePPRainbow>();
				title.isRainbow = component != null && component.enabled;
			}
			else
			{
				title.isRainbow = false;
			}
		}
		catch (Exception)
		{
		}
		Weapon weapon = item as Weapon;
		if (weapon != null)
		{
			Cosmetic cosmetic = weapon.GetCosmetic();
			if (cosmetic != null)
			{
				Color cosmeticLabelColor = cosmetic.GetCosmeticLabelColor(weapon);
				ApplyBorderColor(cosmeticLabelColor);
			}
			else
			{
				ApplyBorderColor(Color.white);
			}
		}
		else if (item is Cosmetic)
		{
			Cosmetic cosmetic2 = item as Cosmetic;
			ApplyBorderColor(cosmetic2.GetCosmeticLabelColor(null));
		}
		else
		{
			ApplyBorderColor(Color.white);
		}
		if (item.isLost)
		{
			int lostCount = item.lostCount;
			int nextLostCountGoal = item.GetNextLostCountGoal();
			itemCountLabel.SetValue("[" + lostCount + "/" + nextLostCountGoal + "]");
		}
		else if (item.collectionGoal > 0)
		{
			itemCountLabel.Clear();
		}
		else
		{
			SetCount(item.count);
		}
		bool flag = singleton.CurrentState == GameStates.State.ItemScreen || singleton.CurrentState == GameStates.State.PlayItemScreen;
		if (useButton != null)
		{
			if (item.id == "name_tag" && flag)
			{
				useButton.enabled = true;
			}
			else
			{
				useButton.enabled = false;
			}
		}
		if (applyButton != null)
		{
			Cosmetic cosmetic3 = item as Cosmetic;
			if (cosmetic3 != null && flag)
			{
				applyButton.enabled = true;
				if (cosmetic3.targetItem.appliedGroupId == null)
				{
					applyButton.label.SetValue(Te.xt("Apply"));
				}
				else
				{
					applyButton.label.SetValue(Te.xt("Remove"));
				}
			}
			else
			{
				applyButton.enabled = false;
			}
		}
		if (editButton != null)
		{
			if (item as PrismaticCosmetic != null && flag)
			{
				editButton.enabled = true;
			}
			else
			{
				editButton.enabled = false;
			}
		}
		RecycleDescriptionLines();
		if (item.collectionGoal > 0)
		{
			AddDescriptionLine(string.Format(Te.xt("tid_x_of_y"), item.count, item.collectionGoal));
			AddDescriptionLine("");
		}
		text = item.GetDescription();
		if (text != null)
		{
			AddDescriptionLine(text);
		}
		else
		{
			text = item.description.line1;
			if (text != "")
			{
				string newValue = Te.xt(ItemData.ReplacementTidForElement(item.element));
				text = Te.xt(text);
				AddDescriptionLine(text.Replace("<element>", newValue));
			}
			text = item.description.line2;
			if (text != "")
			{
				text = Te.xt(text);
				AddDescriptionLine(text);
			}
			text = item.description.line3;
			if (text != "")
			{
				text = Te.xt(text);
				AddDescriptionLine(text);
			}
		}
		float levelDisplayValueForItem = ItemFactory.GetLevelDisplayValueForItem(item);
		int num = 0;
		int num2 = 0;
		float num3 = 0f;
		int num4 = 0;
		float num5 = 0f;
		float num6 = 0f;
		List<ItemData.Ability> list = new List<ItemData.Ability>();
		List<float> list2 = new List<float>();
		try
		{
			WeaponActivatedAbility component2 = item.GetComponent<WeaponActivatedAbility>();
			if (component2 != null)
			{
				for (int i = 0; i < component2.abilityStats.Length; i++)
				{
					ItemData.Ability ability = component2.abilityStats[i];
					if (ability.applyRarity || ability.stat.computeEvenIfRareOnly || !ability.stat.rareStatOnly)
					{
						list.Add(ability);
						list2.Add(1f);
					}
				}
			}
		}
		catch (Exception)
		{
		}
		for (int j = 0; item.abilities != null && j < item.abilities.Count; j++)
		{
			ItemData.Ability ability2 = item.abilities[j];
			float num7 = levelDisplayValueForItem;
			if (!ability2.applyRarity && ability2.stat != null && ability2.stat.rareStatOnly)
			{
				continue;
			}
			if (ability2.stat != null)
			{
				if (ability2.applyRarity)
				{
					num7 = ((!ability2.stat.rareStatOnly) ? (num7 + (float)item.rarity.levelBonus) : ((float)item.rarity.levelBonus));
				}
				if (ability2.stat.type == ItemData.Stat.Type.Damage)
				{
					continue;
				}
				if (ability2.stat.type == ItemData.Stat.Type.Health)
				{
					num2 += Mathf.FloorToInt(ability2.stat.Compute(num7));
					continue;
				}
				if (ability2.stat.type == ItemData.Stat.Type.EvadeChance)
				{
					num3 += ability2.stat.Compute(num7);
					continue;
				}
				if (ability2.stat.type == ItemData.Stat.Type.AttackSpeed)
				{
					num4 += Mathf.RoundToInt(ability2.stat.Compute(num7));
					continue;
				}
				if (ability2.stat.type == ItemData.Stat.Type.ArmorPerSecond)
				{
					num5 += ability2.stat.Compute(num7);
					continue;
				}
				if (ability2.stat.type == ItemData.Stat.Type.MaxArmor)
				{
					num6 += ability2.stat.Compute(num7);
					continue;
				}
				if (ability2.stat.type == ItemData.Stat.Type.Range)
				{
					continue;
				}
			}
			int num8 = -1;
			for (int k = 0; k < list.Count; k++)
			{
				if (ability2.id == list[k].id)
				{
					num8 = k;
					break;
				}
			}
			if (num8 < 0)
			{
				list.Add(ability2);
				list2.Add(1f);
			}
			else
			{
				list2[num8] += 1f;
			}
		}
		for (int l = 0; l < list.Count; l++)
		{
			ItemData.Ability ability3 = list[l];
			string description = ability3.GetDescription(item, list2[l]);
			if (string.IsNullOrEmpty(description))
			{
				Utils.LogWarning("Ability " + ability3.id + " has no description.");
				continue;
			}
			bool rarityTint = ability3.applyRarity && item.rarity != null && item.rarity.type != ItemData.Rarity.Type.Common;
			int num9 = Mathf.Min(Width - 2, descriptionMaxWidth);
			if (description.Length > num9 || description.Contains("\n"))
			{
				string[] array = Utils.BreakIntoLines(description, num9);
				for (int m = 0; m < array.Length; m++)
				{
					AddDescriptionLine(array[m], rarityTint, breakLinesIfNeeded: false);
				}
			}
			else
			{
				AddDescriptionLine(description, rarityTint, breakLinesIfNeeded: false);
			}
		}
		ClearBasicStatLabels();
		if (item.showBasicStats && weapon != null)
		{
			num = ComputeDamageDisplay(weapon);
			if (num > 0)
			{
				AddBasicStat(Te.xt("Damage"), num.ToString(), GetRarityTypeForStatType(item, ItemData.Stat.Type.Damage));
				weapon.UpdateAttackTicsWithAttackSpeed(num4);
				float num10 = (float)(weapon.GetCastTics() + weapon.GetPerfTics() + weapon.GetCooldown()) / 30f;
				float num11 = (float)num / num10;
				AddBasicStat(Te.xt("Dmg/Sec"), num11.ToString("0.##"), GetRarityTypeForStatType(item, ItemData.Stat.Type.AttackSpeed));
				weapon.UpdateRange();
				AddBasicStat(Te.xt("Range"), weapon.range.ToString(), GetRarityTypeForStatType(item, ItemData.Stat.Type.Range));
			}
			if (num2 > 0)
			{
				AddBasicStat(Te.xt("Health"), "+" + num2, GetRarityTypeForStatType(item, ItemData.Stat.Type.Health));
			}
			if (num5 > 0f)
			{
				num5 += GameStates.Singleton.hero.armorPerSecond;
				AddBasicStat(Te.xt("Armor/Sec"), num5.ToString("0.##"), GetRarityTypeForStatType(item, ItemData.Stat.Type.ArmorPerSecond));
			}
			if (num6 > 0f)
			{
				AddBasicStat(Te.xt("Armor"), num6.ToString("0.##"), GetRarityTypeForStatType(item, ItemData.Stat.Type.MaxArmor));
			}
			if (num3 > 0f)
			{
				AddBasicStat(Te.xt("Evade"), num3.ToString("0.##") + "%", GetRarityTypeForStatType(item, ItemData.Stat.Type.EvadeChance));
			}
		}
		LayoutBasicStats(baseStatsColumnCount, baseStatsColumnSpacing, baseStatsRowSpacing);
		RecalculateHeight();
	}

	private void ApplyBorderColor(Color c)
	{
		edgeSymbols.color = initialBorderColor * c;
		separator.color = edgeSymbols.color;
		closeButton.edgeSymbols.color = edgeSymbols.color;
		closeButton.label.color = ColorConstants.lightGrey * c;
	}

	public void SetCount(int value)
	{
		if (value > 1)
		{
			itemCountLabel.SetValue("x" + value);
		}
		else
		{
			itemCountLabel.Clear();
		}
	}

	protected virtual void RecalculateHeight()
	{
		int num = maxLayoutHeight;
		Height = 1;
		Height += 2;
		if (item.isLost)
		{
			Height++;
		}
		Height += iconPadTop + 5;
		if (isIconTall)
		{
			Height += 2;
		}
		Height += GetBasicStatsLayoutSpaceY() + baseStatsOffsetY;
		Height += descriptionPadTop;
		if (descriptionLines.Count > 0)
		{
			Height += 2;
			Height += descriptionLines.Count;
			Height++;
		}
		if (Height < num)
		{
			Height++;
		}
		trimTop = false;
		if (Height > num)
		{
			trimTop = true;
			Height--;
		}
		trimSeparator = false;
		if (Height > num)
		{
			trimSeparator = true;
			Height -= 2;
		}
		trimBasicStats = false;
		if (Height > num)
		{
			trimBasicStats = true;
			Height -= _basicStatsRowCount;
			LayoutBasicStats(baseStatsColumnCount, baseStatsColumnSpacing, Mathf.Max(0, baseStatsRowSpacing - 1));
		}
		trimIconTop = false;
		if (Height > num)
		{
			trimIconTop = true;
			Height--;
		}
		if (IsXP())
		{
			Height += 2;
		}
		if (IsMoonStone())
		{
			Height += 5;
			bigHeadToggle.isOn = HeroSettings.bigHeadEnabled;
			bigHeadLabel.SetValue(Te.xt("tid_bighead_label"));
		}
		else if (IsMindStone())
		{
			Height += 5;
			bigHeadToggle.isOn = MindStoneController.singleton.enabled;
			bigHeadToggle.JumpAnimation();
			bigHeadLabel.SetValue(Te.xt("tid_mind_stone_00"));
		}
		customButtonsTotalWidth = 0;
		customElementsLayoutHeight = 0;
		for (int i = 0; i < customButtons.Length; i++)
		{
			AsciiObject asciiObject = customButtons[i];
			if (asciiObject != null && asciiObject.enabled)
			{
				customButtonsTotalWidth += asciiObject.Width + 1;
				customElementsLayoutHeight = asciiObject.Height + 1;
			}
		}
		if (customButtonsTotalWidth > 0)
		{
			customButtonsTotalWidth--;
		}
		Height += customElementsLayoutHeight;
		ReCenterVerticalPos();
	}

	protected virtual void UpdateIcon()
	{
		icon = item.GetIcon();
	}

	private void AddBasicStat(string labelStr, string valueStr, ItemData.Rarity.Type rarityType = ItemData.Rarity.Type.Common)
	{
		AsciiString pooledBasicStatLabel = GetPooledBasicStatLabel();
		AsciiString pooledBasicStatLabel2 = GetPooledBasicStatLabel();
		pooledBasicStatLabel.SetValue(labelStr);
		pooledBasicStatLabel2.SetValue(valueStr);
		if (rarityType == ItemData.Rarity.Type.Common)
		{
			pooledBasicStatLabel.color = baseStatLabel.color;
			pooledBasicStatLabel2.color = baseStatValue.color;
			pooledBasicStatLabel.isRainbow = false;
			pooledBasicStatLabel2.isRainbow = false;
		}
		else
		{
			ItemData.Rarity.TintString(pooledBasicStatLabel, baseStatLabel.color, item);
			ItemData.Rarity.TintString(pooledBasicStatLabel2, baseStatValue.color, item);
		}
		baseStatLabelList.Add(pooledBasicStatLabel);
		baseStatValueList.Add(pooledBasicStatLabel2);
	}

	private void LayoutBasicStats(int columnCount, int columnSpacing, int rowSpacing)
	{
		int count = baseStatLabelList.Count;
		if (count == 0)
		{
			_basicStatsLayoutSpaceY = 0;
			return;
		}
		int num = (count - 1) / columnCount + 1;
		_basicStatsLayoutSpaceY = num * (2 + rowSpacing) - rowSpacing + 1;
		_basicStatsRowCount = num;
		for (int i = 0; i < num; i++)
		{
			int num2 = i * columnCount;
			int num3 = Mathf.Min(num2 + columnCount - 1, count - 1);
			int num4 = num3 - num2 + 1;
			for (int j = num2; j <= num3; j++)
			{
				int num5 = (j - num2) * columnSpacing - (num4 - 1) * columnSpacing / 2;
				int num6 = i * (2 + rowSpacing);
				num5 += iconPosX;
				baseStatValueList[j].PositionX = num5;
				baseStatLabelList[j].PositionY = num6;
				baseStatLabelList[j].PositionX = num5;
				baseStatValueList[j].PositionY = num6 + 1;
			}
		}
	}

	private int GetBasicStatsLayoutSpaceY()
	{
		return _basicStatsLayoutSpaceY;
	}

	private AsciiString GetPooledBasicStatLabel()
	{
		if (baseStatLabelPool.Count > 0)
		{
			return baseStatLabelPool.Pop();
		}
		return new AsciiString
		{
			alignment = AsciiString.Alignment.Center
		};
	}

	private void ClearBasicStatLabels()
	{
		for (int i = 0; i < baseStatLabelList.Count; i++)
		{
			RecycleBasicStatLabel(baseStatLabelList[i]);
			RecycleBasicStatLabel(baseStatValueList[i]);
		}
		baseStatLabelList.Clear();
		baseStatValueList.Clear();
	}

	private void RecycleBasicStatLabel(AsciiString str)
	{
		baseStatLabelPool.Push(str);
	}

	private void AddDescriptionLine(string message, bool rarityTint = false, bool breakLinesIfNeeded = true)
	{
		if (breakLinesIfNeeded)
		{
			int num = Width - 2;
			if (message.Length > num || message.Contains("\n"))
			{
				string[] array = Utils.BreakIntoLines(message, num);
				if (array.Length > 1)
				{
					for (int i = 0; i < array.Length; i++)
					{
						AddDescriptionLine(array[i], rarityTint, breakLinesIfNeeded: false);
					}
					return;
				}
			}
		}
		AsciiString nextDescriptionLine = GetNextDescriptionLine();
		if (message.StartsWith("treasureDropData:"))
		{
			message = message.Substring(17);
			SetupTreasureDropDataColorMask(nextDescriptionLine, message);
		}
		else
		{
			nextDescriptionLine.SetValue(message);
		}
		descriptionLines.Add(nextDescriptionLine);
		if (rarityTint)
		{
			ItemData.Rarity.TintString(nextDescriptionLine, initialDescriptionColor, item);
			return;
		}
		nextDescriptionLine.color = initialDescriptionColor;
		nextDescriptionLine.isRainbow = false;
	}

	protected void ReCenterVerticalPos()
	{
		PositionY = initialPosY - (Height - initialHeight) / 2;
	}

	private AsciiString GetNextDescriptionLine()
	{
		if (descriptionLinePool.Count > 0)
		{
			return descriptionLinePool.Pop();
		}
		return new AsciiString
		{
			color = descriptionLine1.color,
			alignment = descriptionLine1.alignment,
			PositionX = descriptionLine1.PositionX
		};
	}

	private void RecycleDescriptionLines()
	{
		for (int i = 0; i < descriptionLines.Count; i++)
		{
			descriptionLines[i].ClearColorMask();
			descriptionLinePool.Push(descriptionLines[i]);
		}
		descriptionLines.Clear();
	}

	public void Show()
	{
		base.SetState(State.In);
	}

	public void Hide()
	{
		base.SetState(State.Out);
	}

	private void HandleOnClickedOutside()
	{
		Hide();
	}

	private void Update()
	{
		if (base.CurrentState == State.Idle && Input.GetKeyDown(KeyCode.Escape))
		{
			Hide();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY;
		if (base.CurrentState != State.Idle && !forceDrawRegardlessOfState)
		{
			return;
		}
		if (closeButton != null)
		{
			closeButton.Draw(r, offsetX, offsetY);
		}
		if (trimTop)
		{
			offsetY--;
		}
		signature.Draw(r, offsetX, offsetY);
		title.Draw(r, offsetX, offsetY);
		if (item.isLost)
		{
			offsetY++;
			lostSubtitle.Draw(r, offsetX, offsetY);
		}
		if (HasReroll())
		{
			rerollEnchantmentButton.Draw(r, offsetX, offsetY);
			if (insufficientKiForReroll > 0 && (insufficientKiForReroll <= 3 || insufficientKiForReroll >= 7))
			{
				rerollCost.Draw(r, offsetX + rerollEnchantmentButton.PositionX, offsetY + rerollEnchantmentButton.PositionY, ColorConstants.red);
			}
			else
			{
				rerollCost.Draw(r, offsetX + rerollEnchantmentButton.PositionX, offsetY + rerollEnchantmentButton.PositionY);
			}
			rerollDiscount.Draw(r, offsetX + rerollEnchantmentButton.PositionX, offsetY + rerollEnchantmentButton.PositionY);
		}
		offsetY += iconPadTop;
		if (trimIconTop)
		{
			offsetY--;
		}
		if (IsXP())
		{
			xpBar.Draw(r, offsetX + iconPosX, offsetY + iconPosY + 1);
			offsetY += 2;
		}
		else if (icon != null)
		{
			if (isIconTall)
			{
				offsetY++;
			}
			icon.Draw(r, offsetX + iconPosX, offsetY + iconPosY);
			if (isIconTall)
			{
				offsetY++;
			}
		}
		int num = offsetX;
		if (icon != null && icon.width > 5)
		{
			num += (icon.width - 5) / 2;
		}
		itemCountLabel.Draw(r, num, offsetY);
		offsetY = ((!trimBasicStats) ? (offsetY + baseStatsOffsetY) : (offsetY - 1));
		if (item.showBasicStats && baseStatLabelList.Count > 0)
		{
			for (int i = 0; i < baseStatLabelList.Count; i++)
			{
				baseStatLabelList[i].Draw(r, offsetX, offsetY + 8);
				baseStatValueList[i].Draw(r, offsetX, offsetY + 8);
			}
			offsetY += GetBasicStatsLayoutSpaceY();
		}
		offsetY -= 6;
		if (IsMoonStone() || IsMindStone())
		{
			bigHeadLabel.Draw(r, offsetX, offsetY);
			bigHeadToggle.Draw(r, offsetX, offsetY);
			offsetY += 6;
		}
		num = offsetX - customButtonsTotalWidth / 2;
		for (int j = 0; j < customButtons.Length; j++)
		{
			AsciiObject asciiObject = customButtons[j];
			if (asciiObject != null && asciiObject.enabled)
			{
				asciiObject.Draw(r, num, offsetY);
				num += asciiObject.Width + 1;
			}
		}
		offsetY += customElementsLayoutHeight;
		if (descriptionLines.Count > 0)
		{
			if (trimSeparator)
			{
				offsetY--;
			}
			separator.Draw(r, offsetX, offsetY);
			if (trimSeparator)
			{
				offsetY--;
			}
			offsetY += descriptionPadTop;
			for (int k = 0; k < descriptionLines.Count; k++)
			{
				descriptionLines[k].PositionY = initialDescriptionPosY + k;
				descriptionLines[k].Draw(r, offsetX, offsetY);
			}
		}
		if (currentItemDetailsState == ItemDetailsState.ColorPicker)
		{
			colorPicker.Draw(r, r.width / 2, r.height / 2);
		}
	}

	public static int ComputeDamageDisplay(Weapon weapon)
	{
		Damage dmg = new Damage();
		dmg.amount = weapon.baseDamage;
		weapon.ForEachStatModController(delegate(StatModController controller)
		{
			controller.ModDamage(dmg, null);
		});
		return dmg.amount;
	}

	public static ItemData.Rarity.Type GetRarityTypeForStatType(Item item, ItemData.Stat.Type statType)
	{
		ItemData.Rarity.Type result = ItemData.Rarity.Type.Common;
		if (item.abilities != null)
		{
			for (int i = 0; i < item.abilities.Count; i++)
			{
				if (item.abilities[i].applyRarity && item.abilities[i].stat != null && item.abilities[i].stat.type == statType)
				{
					return item.rarity.type;
				}
			}
		}
		return result;
	}

	private void HandleCloseButtonPressed(DialogButton button)
	{
		Hide();
	}

	private bool IsXP()
	{
		if (xpBar != null)
		{
			return item.id == "xp_stone";
		}
		return false;
	}

	private bool IsMoonStone()
	{
		if (bigHeadToggle != null)
		{
			return item.id == "moon_stone";
		}
		return false;
	}

	private bool IsMindStone()
	{
		if (bigHeadToggle != null)
		{
			return item.id == "mind_stone";
		}
		return false;
	}

	private bool HasReroll()
	{
		if (hasReroll)
		{
			return GameStates.Singleton.CurrentState == GameStates.State.WorkstationScreen;
		}
		return false;
	}

	private string MakeCostString(int amount)
	{
		if (amount == 0)
		{
			return Te.xt("FREE");
		}
		return "@" + Utils.FormatNumber(amount);
	}

	private void SetupTreasureDropDataColorMask(AsciiString line, string message)
	{
		List<Color> list = new List<Color>();
		ItemData.Rarity.Type type = ItemData.Rarity.Type.Uncommon;
		for (int i = 0; i < message.Length; i++)
		{
			Color colorForRarity = ItemData.Rarity.GetColorForRarity(type);
			list.Add(colorForRarity);
			if (message[i] == ' ')
			{
				type++;
			}
		}
		line.SetValue(message);
		line.SetColorMask(list);
	}

	private void HandleRerollEnchantmentPressed(DialogButton btn)
	{
		if (item.ComputeRerollCost() > InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi))
		{
			insufficientKiForReroll = 10;
		}
	}

	private void HandleBigHeadTogglePressed(DialogButton btn)
	{
		if (IsMoonStone())
		{
			HeroSettings.bigHeadEnabled = bigHeadToggle.isOn;
		}
		else if (IsMindStone())
		{
			MindStoneController.singleton.enabled = bigHeadToggle.isOn;
			if (bigHeadToggle.isOn)
			{
				SfxController.singleton.Play("mindstone_on");
			}
			else
			{
				SfxController.singleton.Play("mindstone_off");
			}
		}
	}

	private void HandleEditPressed(DialogButton btn)
	{
		if (item != null && item is PrismaticCosmetic)
		{
			SetItemDetailsState(ItemDetailsState.ColorPicker);
		}
	}

	protected override void Start()
	{
		base.Start();
		initialHeight = Height;
		initialPosY = PositionY;
		initialDescriptionPosY = descriptionLine1.PositionY;
		base.OnClickedOutside += HandleOnClickedOutside;
		if (closeButton != null)
		{
			closeButton.OnPressed += HandleCloseButtonPressed;
		}
		if (rerollEnchantmentButton != null)
		{
			rerollEnchantmentButton.OnPressed += HandleRerollEnchantmentPressed;
		}
		if (bigHeadToggle != null)
		{
			bigHeadToggle.OnPressed += HandleBigHeadTogglePressed;
		}
		initialTitleColor = title.color;
		initialDescriptionColor = descriptionLine1.color;
		initialBorderColor = edgeSymbols.color;
	}

	protected virtual void OnDestroy()
	{
		base.OnClickedOutside -= HandleOnClickedOutside;
		if (closeButton != null)
		{
			closeButton.OnPressed -= HandleCloseButtonPressed;
		}
		if (rerollEnchantmentButton != null)
		{
			rerollEnchantmentButton.OnPressed -= HandleRerollEnchantmentPressed;
		}
		if (bigHeadToggle != null)
		{
			bigHeadToggle.OnPressed -= HandleBigHeadTogglePressed;
		}
		if (editButton != null)
		{
			editButton.OnPressed -= HandleEditPressed;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (xpBarPrefab != null)
		{
			xpBar = UnityEngine.Object.Instantiate(xpBarPrefab);
			xpBar.Load();
		}
		if (editButton != null)
		{
			editButton.OnPressed += HandleEditPressed;
		}
	}
}
