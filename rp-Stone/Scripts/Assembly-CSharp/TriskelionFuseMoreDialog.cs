using System;
using System.Collections.Generic;
using UnityEngine;

public class TriskelionFuseMoreDialog : DialogNineSlice
{
	[Serializable]
	public class IngredientRow
	{
		private readonly int ROW_WIDTH = 14;

		public AsciiString nameLabel;

		public AsciiString amountLabel;

		private int currentAmount;

		public int displayAmount { get; private set; }

		public void SetAmount(int value)
		{
			currentAmount = value;
		}

		public void UpdateTic()
		{
			int num = currentAmount - displayAmount;
			if (num > 1000)
			{
				displayAmount += 500;
			}
			else if (num < -1000)
			{
				displayAmount -= 500;
			}
			else if (num > 100)
			{
				displayAmount += 50;
			}
			else if (num < -100)
			{
				displayAmount -= 50;
			}
			else if (num > 10)
			{
				displayAmount += 5;
			}
			else if (num < -10)
			{
				displayAmount -= 5;
			}
			else if (num > 0)
			{
				displayAmount++;
			}
			else if (num < 0)
			{
				displayAmount--;
			}
			if (num != 0)
			{
				amountLabel.SetValue(displayAmount.ToString());
			}
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
		{
			nameLabel.Draw(r, offsetX - languageAdjustmentRows, offsetY);
			amountLabel.Draw(r, offsetX + ROW_WIDTH + languageAdjustmentRows, offsetY);
		}
	}

	private const float TIME_PER_FUSION = 1.84818f;

	public DialogButton closeButton;

	public ItemSlot centerFrame;

	public int iconOffsetX;

	public int iconOffsetY;

	public EnchantmentProgressBar progressBar;

	public DialogButton plusButton;

	public DialogButton minusButton;

	public AsciiString estimatedTime;

	public DialogButton confirmationButton;

	public IngredientRow commonRow;

	public IngredientRow rareRow;

	public IngredientRow heroicRow;

	public IngredientRow epicRow;

	public IngredientRow legendaryRow;

	public IngredientRow transcendentRow;

	public int ingredientRowX;

	public int ingredientRowY;

	private int initialWindowHeight;

	private static int languageAdjustmentRows;

	private List<int[]> selectedEnchantmentStack = new List<int[]>();

	private List<int> kiCostStack = new List<int>();

	private int selectedUpgradeSteps;

	private int fuseKiCost;

	private int insufficientKiCounter;

	private int[] selectedEnchantments;

	private int[] simplifiedEnchantmentInventory = new int[21];

	private List<Item> automationItemsUsed = new List<Item>();

	public bool automationEnabled { get; set; }

	public int totalIngredientCount { get; private set; }

	public void Show()
	{
		base.SetState(State.In);
		if (selectedEnchantmentStack.Count == 0)
		{
			ComputeUpgrade(centerFrame.item, 1);
		}
		selectedUpgradeSteps = 0;
		UpdatePlusMinusButtons();
		UpdateProgressBar();
		UpdateIngredientCounts();
		automationEnabled = false;
		selectedEnchantments = null;
		if (Te.id == "RU")
		{
			languageAdjustmentRows = 1;
		}
		else if (Te.id == "FR")
		{
			languageAdjustmentRows = -1;
		}
		else if (Te.id == "JP" || Te.id == "TK")
		{
			languageAdjustmentRows = -2;
		}
		else if (Te.id == "ZH-CN" || Te.id == "ZH-TW" || Te.id == "KR")
		{
			languageAdjustmentRows = -4;
		}
		else
		{
			languageAdjustmentRows = 0;
		}
	}

	public void Hide()
	{
		selectedEnchantmentStack.Clear();
		kiCostStack.Clear();
		selectedUpgradeSteps = 0;
		base.SetState(State.Out);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		insufficientKiCounter--;
		if (base.CurrentState == State.Idle)
		{
			closeButton.UpdateTic();
			if (minusButton.enabled)
			{
				minusButton.UpdateTic();
			}
			if (plusButton.enabled)
			{
				plusButton.UpdateTic();
			}
			confirmationButton.UpdateTic();
			commonRow.UpdateTic();
			rareRow.UpdateTic();
			heroicRow.UpdateTic();
			epicRow.UpdateTic();
			legendaryRow.UpdateTic();
			transcendentRow.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState != State.Idle)
		{
			return;
		}
		offsetX += PositionX;
		offsetY += PositionY;
		closeButton.Draw(r, offsetX, offsetY);
		centerFrame.Draw(r, offsetX + iconOffsetX, offsetY + iconOffsetY);
		progressBar.Draw(r, offsetX, offsetY);
		if (minusButton.enabled)
		{
			minusButton.Draw(r, offsetX, offsetY);
		}
		else
		{
			r.SetCell(offsetX + minusButton.PositionX + 2, offsetY + minusButton.PositionY + 1, 45, ColorConstants.darkGrey);
		}
		if (plusButton.enabled)
		{
			plusButton.Draw(r, offsetX, offsetY);
		}
		else
		{
			r.SetCell(offsetX + plusButton.PositionX + 2, offsetY + plusButton.PositionY + 1, 43, ColorConstants.darkGrey);
		}
		int num = 0;
		if (commonRow.displayAmount > 0)
		{
			commonRow.Draw(r, offsetX + ingredientRowX, offsetY + num + ingredientRowY);
			num++;
		}
		if (rareRow.displayAmount > 0)
		{
			rareRow.Draw(r, offsetX + ingredientRowX, offsetY + num + ingredientRowY);
			num++;
		}
		if (heroicRow.displayAmount > 0)
		{
			heroicRow.Draw(r, offsetX + ingredientRowX, offsetY + num + ingredientRowY);
			num++;
		}
		if (epicRow.displayAmount > 0)
		{
			epicRow.Draw(r, offsetX + ingredientRowX, offsetY + num + ingredientRowY);
			num++;
		}
		if (legendaryRow.displayAmount > 0)
		{
			legendaryRow.Draw(r, offsetX + ingredientRowX, offsetY + num + ingredientRowY);
			num++;
		}
		if (transcendentRow.displayAmount > 0)
		{
			transcendentRow.Draw(r, offsetX + ingredientRowX, offsetY + num + ingredientRowY);
			num++;
		}
		if (num >= 1 && totalIngredientCount > 6)
		{
			estimatedTime.Draw(r, offsetX, offsetY + num);
			num += 2;
		}
		if (num > 0)
		{
			if (insufficientKiCounter > 0 && insufficientKiCounter % 6 >= 3)
			{
				confirmationButton.label.color = ColorConstants.red;
			}
			else
			{
				confirmationButton.label.color = ColorConstants.white;
			}
			confirmationButton.Draw(r, offsetX, offsetY + num);
			num += confirmationButton.Height;
		}
		Height = initialWindowHeight + num;
	}

	public void SimplifyEnchantmentMemory()
	{
		for (int i = 1; i < simplifiedEnchantmentInventory.Length; i++)
		{
			simplifiedEnchantmentInventory[i] = 0;
		}
		List<Item> enchantBoostItems = Inventory.Singleton.GetEnchantBoostItems();
		for (int j = 0; j < enchantBoostItems.Count; j++)
		{
			Item item = enchantBoostItems[j];
			if (!(item == null) && IsQualifiedAsIngredient(item))
			{
				int rarityBonus = item.GetRarityBonus();
				simplifiedEnchantmentInventory[rarityBonus] += item.count;
			}
		}
	}

	private bool IsQualifiedAsIngredient(Item item)
	{
		int rarityBonus = item.GetRarityBonus();
		if (rarityBonus < 1 || rarityBonus > 20)
		{
			return false;
		}
		if (ItemFactory.GetLevelDisplayIntegerForItem(item) > 1)
		{
			return false;
		}
		if (item.rarity.quality > ItemData.Rarity.GetQualityThreshold(rarityBonus))
		{
			return false;
		}
		return true;
	}

	public bool ComputeUpgrade(Item targetItem, int steps)
	{
		int rarityBonus = targetItem.GetRarityBonus();
		if (rarityBonus + steps > 21)
		{
			return false;
		}
		int num = ((targetItem.rarity != null) ? targetItem.rarity.quality : 0);
		int num2 = ItemData.Rarity.GetQualityThreshold(rarityBonus + steps) - num;
		int item = num2;
		bool flag = IsQualifiedAsIngredient(targetItem);
		int[] array = new int[21];
		while (selectedEnchantmentStack.Count >= steps)
		{
			int index = selectedEnchantmentStack.Count - 1;
			selectedEnchantmentStack.RemoveAt(index);
			kiCostStack.RemoveAt(index);
		}
		int num3 = 0;
		int num4 = simplifiedEnchantmentInventory.Length - 1;
		while (num4 >= 1 && num2 > 0)
		{
			int num5 = simplifiedEnchantmentInventory[num4];
			if (flag && rarityBonus == num4)
			{
				num5--;
			}
			if (num5 > 0)
			{
				int qualityThreshold = ItemData.Rarity.GetQualityThreshold(num4);
				if (qualityThreshold <= num2)
				{
					int num6 = Mathf.Min(num5, num2 / qualityThreshold);
					int num7 = qualityThreshold * num6;
					array[num4] += num6;
					num2 -= num7;
					num3 += num6;
					if (num2 == 0 && num3 % 3 > 0)
					{
						num4 = 2;
						num2 = 1;
					}
				}
			}
			num4--;
		}
		if (num2 == 0 && num3 >= 3)
		{
			selectedEnchantmentStack.Add(array);
			kiCostStack.Add(item);
			return true;
		}
		return false;
	}

	private void UpdatePlusMinusButtons()
	{
		minusButton.enabled = selectedUpgradeSteps > 0;
		plusButton.enabled = selectedEnchantmentStack.Count > selectedUpgradeSteps;
	}

	private void UpdateProgressBar()
	{
		if (centerFrame.item.rarity.levelBonus == 21)
		{
			progressBar.Setup(1f, ColorConstants.white);
			progressBar.isRainbow = true;
			progressBar.maxEnchantment = true;
			return;
		}
		int levelBonus = centerFrame.item.rarity.levelBonus;
		int num = centerFrame.item.rarity.quality;
		int qualityThreshold = ItemData.Rarity.GetQualityThreshold(levelBonus);
		int qualityThreshold2 = ItemData.Rarity.GetQualityThreshold(levelBonus + 1);
		if (selectedUpgradeSteps > 0)
		{
			num = ItemData.Rarity.GetQualityThreshold(levelBonus + selectedUpgradeSteps);
		}
		int bonusForQuality = ItemData.Rarity.GetBonusForQuality(num);
		float num2 = (float)(num - qualityThreshold) / (float)(qualityThreshold2 - qualityThreshold);
		if (num2 > 1f && bonusForQuality != 21)
		{
			int qualityThreshold3 = ItemData.Rarity.GetQualityThreshold(bonusForQuality);
			int qualityThreshold4 = ItemData.Rarity.GetQualityThreshold(bonusForQuality + 1);
			float num3 = (float)(num - qualityThreshold3) / (float)(qualityThreshold4 - qualityThreshold3);
			num2 = (float)(bonusForQuality - levelBonus) + num3;
		}
		progressBar.Setup(num2, ItemData.Rarity.GetColorForBonus(bonusForQuality));
		progressBar.isRainbow = bonusForQuality >= 16;
		progressBar.maxEnchantment = bonusForQuality == 21;
	}

	private void UpdateIngredientCounts()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		fuseKiCost = 0;
		if (selectedUpgradeSteps > 0 && selectedEnchantmentStack.Count > selectedUpgradeSteps - 1)
		{
			int[] array = selectedEnchantmentStack[selectedUpgradeSteps - 1];
			for (int i = 1; i < array.Length; i++)
			{
				switch (ItemData.Rarity.GetTypeForBonus(i))
				{
				case ItemData.Rarity.Type.Uncommon:
					num += array[i];
					break;
				case ItemData.Rarity.Type.Rare:
					num2 += array[i];
					break;
				case ItemData.Rarity.Type.Heroic:
					num3 += array[i];
					break;
				case ItemData.Rarity.Type.Epic:
					num4 += array[i];
					break;
				case ItemData.Rarity.Type.Legendary:
					num5 += array[i];
					break;
				case ItemData.Rarity.Type.Transcendent:
					num6 += array[i];
					break;
				}
			}
			fuseKiCost = kiCostStack[selectedUpgradeSteps - 1];
		}
		commonRow.SetAmount(num);
		rareRow.SetAmount(num2);
		heroicRow.SetAmount(num3);
		epicRow.SetAmount(num4);
		legendaryRow.SetAmount(num5);
		transcendentRow.SetAmount(num6);
		totalIngredientCount = num + num2 + num3 + num4 + num5 + num6;
		string arg = Utils.FormatTimeCasual(Mathf.RoundToInt(1.84818f * (float)totalIngredientCount / 3f));
		estimatedTime.SetValue(string.Format(Te.xt("tid_triskelion_2"), arg));
		confirmationButton.label.SetValue("@" + Utils.FormatNumber(fuseKiCost));
	}

	public Item GetNextForAutomation()
	{
		for (int num = selectedEnchantments.Length - 1; num >= 1; num--)
		{
			if (selectedEnchantments[num] > 0)
			{
				selectedEnchantments[num]--;
				totalIngredientCount--;
				if (totalIngredientCount <= 0)
				{
					selectedEnchantments = null;
				}
				return GetNextForAutomation(num);
			}
		}
		return null;
	}

	public void ReportTransactionCompleted()
	{
		automationEnabled = selectedEnchantments != null;
		automationItemsUsed.Clear();
		if (automationEnabled)
		{
			automationItemsUsed.Add(centerFrame.item);
		}
	}

	private Item GetNextForAutomation(int bonusValue)
	{
		List<Item> enchantBoostItems = Inventory.Singleton.GetEnchantBoostItems();
		for (int i = 0; i < enchantBoostItems.Count; i++)
		{
			Item item = enchantBoostItems[i];
			if (item == null || item.GetRarityBonus() != bonusValue || !IsQualifiedAsIngredient(item))
			{
				continue;
			}
			bool flag = false;
			int num = 0;
			for (int j = 0; j < automationItemsUsed.Count; j++)
			{
				if (item == automationItemsUsed[j])
				{
					num++;
					if (num >= item.count)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				automationItemsUsed.Add(item);
				return item;
			}
		}
		return null;
	}

	protected virtual void Update()
	{
		if (base.CurrentState == State.Idle && Input.GetKeyDown(KeyCode.Escape))
		{
			Hide();
		}
	}

	private void HandleConfirmationButtonPressed(DialogButton btn)
	{
		if (fuseKiCost > InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi))
		{
			insufficientKiCounter = 18;
			return;
		}
		InventoryResources.singleton.RemoveResourceOfType(Data.Resource.Xi, fuseKiCost);
		if (selectedUpgradeSteps > 0)
		{
			automationEnabled = true;
			selectedEnchantments = selectedEnchantmentStack[selectedUpgradeSteps - 1];
			automationItemsUsed.Clear();
			automationItemsUsed.Add(centerFrame.item);
		}
		Hide();
	}

	private void HandlePlusButtonPressed(DialogButton btn)
	{
		selectedUpgradeSteps++;
		ComputeUpgrade(centerFrame.item, selectedUpgradeSteps + 1);
		UpdatePlusMinusButtons();
		UpdateProgressBar();
		UpdateIngredientCounts();
	}

	private void HandleMinusButtonPressed(DialogButton btn)
	{
		selectedUpgradeSteps--;
		if (selectedEnchantmentStack.Count > selectedUpgradeSteps + 1)
		{
			int index = selectedEnchantmentStack.Count - 1;
			selectedEnchantmentStack.RemoveAt(index);
			kiCostStack.RemoveAt(index);
		}
		UpdatePlusMinusButtons();
		UpdateProgressBar();
		UpdateIngredientCounts();
	}

	private void HandleCloseButtonPressed(DialogButton btn)
	{
		Hide();
	}

	private void HandleClickedOutside()
	{
		Hide();
	}

	protected override void Awake()
	{
		base.Awake();
		initialWindowHeight = Height;
		base.OnClickedOutside += HandleClickedOutside;
		closeButton.OnPressed += HandleCloseButtonPressed;
		plusButton.OnPressed += HandlePlusButtonPressed;
		minusButton.OnPressed += HandleMinusButtonPressed;
		confirmationButton.OnPressed += HandleConfirmationButtonPressed;
	}

	protected void OnDestroy()
	{
		base.OnClickedOutside -= HandleClickedOutside;
		closeButton.OnPressed -= HandleCloseButtonPressed;
		plusButton.OnPressed -= HandlePlusButtonPressed;
		minusButton.OnPressed -= HandleMinusButtonPressed;
		confirmationButton.OnPressed -= HandleConfirmationButtonPressed;
	}
}
