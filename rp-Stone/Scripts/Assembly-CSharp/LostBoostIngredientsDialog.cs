using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class LostBoostIngredientsDialog : DialogNineSlice
{
	private enum BoostState
	{
		Idle = 0,
		SelectingItem = 1,
		IngredientCountDialog = 2
	}

	public int _lostBoostPointsCost;

	private SafeInt lostBoostPointsCost;

	public int[] _lostBoostsPerLevel;

	public DialogButton closeButton;

	public AsciiString title;

	public AsciiTextBox subtitle;

	public int iconOffsetX;

	public int iconOffsetY = 7;

	public AsciiString percentBG;

	public AsciiString percentValue;

	public int ingredientsOffsetY = 12;

	public DialogButton boostButton;

	public DialogButton addButton;

	public ItemSlot slotPrefab;

	private List<DialogButton> ingredientButtons = new List<DialogButton>();

	public LostBoostIngredientCountDialog ingredientCountDialog;

	private AsciiSprite icon;

	private int initialHeight;

	private SafeInt boostsUsed;

	private BoostState currentBoostState;

	private Item selectedIngredient;

	public Dictionary<Item, int> ingredientAmounts = new Dictionary<Item, int>();

	private readonly int INGREDIENT_LIMIT = 10;

	private readonly int[] INGREDIENTS_X = new int[11]
	{
		0, -3, -8, -12, -17, -19, -20, -20, -20, -20,
		-20
	};

	private readonly int INGREDIENT_WIDTH = 7;

	private readonly int[][] INGREDIENTS_SPACING = new int[11][]
	{
		new int[1],
		new int[1],
		new int[1] { 3 },
		new int[2] { 2, 2 },
		new int[3] { 2, 2, 2 },
		new int[4] { 1, 1, 1, 1 },
		new int[5] { -1, 0, 0, 0, 0 },
		new int[6] { -2, -2, -1, -1, -1, -1 },
		new int[7] { -3, -2, -2, -2, -2, -2, -2 },
		new int[8] { -3, -3, -3, -3, -3, -3, -2, -2 },
		new int[9] { -4, -4, -3, -3, -3, -3, -3, -3, -3 }
	};

	private Stack<ItemSlot> itemSlotPool = new Stack<ItemSlot>();

	public void Show(Item item)
	{
		base.SetState(State.In);
		string text = item.GetName();
		string starRatingStringForItem = ItemFactory.GetStarRatingStringForItem(item);
		text = starRatingStringForItem + " " + text + " " + starRatingStringForItem;
		title.SetValue(text);
		title.color = item.GetLabelColor();
		text = Te.xt("tid_anvil_12");
		int lostCount = item.lostCount;
		int nextLostCountGoal = item.GetNextLostCountGoal();
		string arg = lostCount + "/" + nextLostCountGoal;
		string arg2 = lostCount + 1 + "/" + nextLostCountGoal;
		text = string.Format(text, arg, arg2);
		subtitle.Text = text;
		icon = item.GetIcon();
		boostsUsed = new SafeInt(item.lostBoostsUsed);
		percentValue.SetValue(" 0%");
		ingredientButtons.Add(addButton);
		boostButton.enabled = false;
		ingredientCountDialog.canJumpToEnd = item.lostBoostsUsed > 0;
		Height = initialHeight;
	}

	public void Hide()
	{
		base.SetState(State.Out);
		RecycleIngredientButtons();
		ItemSelectionPopup singleton = ItemSelectionPopup.singleton;
		singleton.OnItemSelected = (Action<Item>)Delegate.Remove(singleton.OnItemSelected, new Action<Item>(HandleItemSelected));
	}

	public void SubtractFromInventory()
	{
		foreach (KeyValuePair<Item, int> ingredientAmount in ingredientAmounts)
		{
			Item key = ingredientAmount.Key;
			int value = ingredientAmount.Value;
			Inventory.Singleton.RemoveItem(key, value);
		}
	}

	public void ClearIngredientAmounts()
	{
		ingredientAmounts.Clear();
	}

	private void Complete()
	{
		Hide();
	}

	private void Cancel()
	{
		ingredientAmounts.Clear();
		Hide();
	}

	private void SetBoostState(BoostState newState)
	{
		switch (newState)
		{
		case BoostState.SelectingItem:
		{
			ItemSelectionPopup.singleton.mode = ItemSelectionPopup.Mode.LostItemBoost;
			ItemSelectionPopup.singleton.Show();
			ItemSelectionPopup singleton = ItemSelectionPopup.singleton;
			singleton.OnItemSelected = (Action<Item>)Delegate.Combine(singleton.OnItemSelected, new Action<Item>(HandleItemSelected));
			break;
		}
		case BoostState.IngredientCountDialog:
		{
			int startingAmount = Mathf.Max(0, GetIngredientAmount(selectedIngredient));
			int lostBoostPointsWithoutThisItem = ComputeLostBoostPointsWithoutItem(selectedIngredient);
			ingredientCountDialog.Show(selectedIngredient, startingAmount, lostBoostPointsWithoutThisItem, ComputeBoostPointsCost());
			break;
		}
		}
		currentBoostState = newState;
	}

	public override void UpdateTic()
	{
		if (currentBoostState == BoostState.SelectingItem)
		{
			ItemSelectionPopup.singleton.UpdateTic();
			if (ItemSelectionPopup.singleton.currentState == PopUpModalScreen.State.Disabled)
			{
				SetBoostState(BoostState.Idle);
			}
			return;
		}
		if (currentBoostState == BoostState.IngredientCountDialog)
		{
			ingredientCountDialog.UpdateTic();
			if (ingredientCountDialog.CurrentState == State.Disabled)
			{
				SetIngredientAmount(selectedIngredient, ingredientCountDialog.amountToAdd);
				SetBoostState(BoostState.Idle);
			}
			return;
		}
		base.UpdateTic();
		if (base.CurrentState != State.Idle)
		{
			return;
		}
		closeButton.UpdateTic();
		foreach (DialogButton ingredientButton in ingredientButtons)
		{
			ingredientButton.UpdateTic();
		}
		if (boostButton.enabled)
		{
			boostButton.UpdateTic();
		}
	}

	private void SetIngredientAmount(Item item, int amount)
	{
		if (ingredientAmounts.ContainsKey(item))
		{
			if (amount == 0)
			{
				ingredientAmounts.Remove(item);
				for (int i = 0; i < ingredientButtons.Count; i++)
				{
					ItemSlot itemSlot = ingredientButtons[i] as ItemSlot;
					if (itemSlot != null && itemSlot.item == item)
					{
						ingredientButtons.RemoveAt(i);
						RecycleIngredientButton(itemSlot);
						break;
					}
				}
			}
			else
			{
				ingredientAmounts[item] = amount;
				foreach (DialogButton ingredientButton in ingredientButtons)
				{
					ItemSlot itemSlot2 = ingredientButton as ItemSlot;
					if (itemSlot2 != null && itemSlot2.item == item)
					{
						itemSlot2.count = amount;
						break;
					}
				}
			}
		}
		else if (amount > 0)
		{
			ingredientAmounts.Add(item, amount);
			ingredientButtons.Remove(addButton);
			ItemSlot itemSlot3 = NewItemSlot();
			itemSlot3.SetContent(item, amount);
			ingredientButtons.Add(itemSlot3);
		}
		if (ingredientButtons.Count < INGREDIENT_LIMIT && !ingredientButtons.Contains(addButton))
		{
			ingredientButtons.Add(addButton);
		}
		UpdatePercentage();
	}

	private int GetIngredientAmount(Item item)
	{
		if (ingredientAmounts.ContainsKey(item))
		{
			return ingredientAmounts[item];
		}
		return 0;
	}

	private void UpdatePercentage()
	{
		float num = ComputePercentage();
		percentValue.SetValue(ConvertPercentageToString(num));
		if (num >= 1f)
		{
			boostButton.enabled = true;
			Height = initialHeight + addButton.Height;
			ingredientButtons.Remove(addButton);
		}
		else
		{
			boostButton.enabled = false;
			Height = initialHeight;
		}
	}

	public float ComputePercentage()
	{
		return (float)ComputeLostBoostPointsWithoutItem(null) / (float)ComputeBoostPointsCost();
	}

	public static string ConvertPercentageToString(float p)
	{
		if (p < 0.0005f)
		{
			return " 0%";
		}
		if (p >= 1f)
		{
			return " 100%";
		}
		string text = (Mathf.Floor(p * 1000f) / 10f).ToString("0.0");
		text += "%";
		if (text.Length % 2 == 0)
		{
			text = " " + text;
		}
		return text;
	}

	private int ComputeLostBoostPointsWithoutItem(Item itemToExclude)
	{
		int num = 0;
		foreach (KeyValuePair<Item, int> ingredientAmount in ingredientAmounts)
		{
			Item key = ingredientAmount.Key;
			if (!(key == itemToExclude))
			{
				int lostBoostPoints = key.GetLostBoostPoints();
				int value = ingredientAmount.Value;
				num += lostBoostPoints * value;
			}
		}
		return num;
	}

	private int ComputeBoostPointsCost()
	{
		return lostBoostPointsCost.GetValue() * (boostsUsed.GetValue() + 1);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetY += PositionY;
		if (base.CurrentState == State.Idle)
		{
			closeButton.Draw(r, offsetX, offsetY);
			title.Draw(r, offsetX, offsetY);
			subtitle.Draw(r, offsetX, offsetY);
			icon.Draw(r, offsetX + iconOffsetX, offsetY + iconOffsetY);
			percentBG.Draw(r, offsetX, offsetY);
			percentValue.Draw(r, offsetX, offsetY);
			DrawIngredients(r, offsetX, offsetY);
			if (boostButton.enabled)
			{
				boostButton.Draw(r, offsetX, offsetY);
			}
			if (currentBoostState == BoostState.SelectingItem)
			{
				ItemSelectionPopup.singleton.Draw(r, offsetX, offsetY);
			}
			else if (currentBoostState == BoostState.IngredientCountDialog)
			{
				ingredientCountDialog.Draw(r, r.width >> 1, r.height >> 1);
			}
		}
	}

	private void DrawIngredients(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetY += ingredientsOffsetY;
		int num = offsetX + INGREDIENTS_X[ingredientButtons.Count];
		for (int i = 0; i < ingredientButtons.Count; i++)
		{
			DialogButton dialogButton = ingredientButtons[i];
			if (i > 0)
			{
				int num2 = INGREDIENTS_SPACING[ingredientButtons.Count][i - 1];
				num += INGREDIENT_WIDTH + num2;
			}
			dialogButton.Draw(r, num, offsetY);
		}
	}

	public bool CanLostItemBeBoosted(Item item)
	{
		if (!item.isLost)
		{
			return false;
		}
		int num = 0;
		int levelDisplayIntegerForItem = ItemFactory.GetLevelDisplayIntegerForItem(item);
		for (int i = 6; i <= levelDisplayIntegerForItem && i - 6 < _lostBoostsPerLevel.Length; i++)
		{
			num += _lostBoostsPerLevel[i - 6];
		}
		return item.lostBoostsUsed < num;
	}

	protected virtual void Update()
	{
		if (currentBoostState == BoostState.Idle && Input.GetKeyDown(KeyCode.Escape))
		{
			Cancel();
		}
	}

	private void HandleItemSelected(Item item)
	{
		ItemSelectionPopup singleton = ItemSelectionPopup.singleton;
		singleton.OnItemSelected = (Action<Item>)Delegate.Remove(singleton.OnItemSelected, new Action<Item>(HandleItemSelected));
		selectedIngredient = item;
		SetBoostState(BoostState.IngredientCountDialog);
	}

	private void HandleSlotPressed(DialogButton btn)
	{
		ItemSlot itemSlot = btn as ItemSlot;
		selectedIngredient = itemSlot.item;
		SetBoostState(BoostState.IngredientCountDialog);
	}

	private void HandleAddButtonPressed(DialogButton btn)
	{
		SetBoostState(BoostState.SelectingItem);
	}

	private void HandleBoostButtonPressed(DialogButton btn)
	{
		Complete();
	}

	private void HandleCloseButtonPressed(DialogButton btn)
	{
		Cancel();
	}

	private void HandleClickedOutside()
	{
		Cancel();
	}

	private ItemSlot NewItemSlot()
	{
		ItemSlot itemSlot = UnityEngine.Object.Instantiate(slotPrefab);
		itemSlot.OnPressed += HandleSlotPressed;
		return itemSlot;
	}

	private void RecycleIngredientButton(ItemSlot slot)
	{
		itemSlotPool.Push(slot);
	}

	private void RecycleIngredientButtons()
	{
		foreach (DialogButton ingredientButton in ingredientButtons)
		{
			if (ingredientButton != addButton)
			{
				ItemSlot itemSlot = ingredientButton as ItemSlot;
				if (itemSlot == null)
				{
					Debug.LogError("Recycling '" + itemSlot?.ToString() + "', but it's not of type ItemSlot.");
				}
				else
				{
					itemSlotPool.Push(itemSlot);
				}
			}
		}
		ingredientButtons.Clear();
	}

	protected override void Awake()
	{
		base.Awake();
		base.OnClickedOutside += HandleClickedOutside;
		closeButton.OnPressed += HandleCloseButtonPressed;
		addButton.OnPressed += HandleAddButtonPressed;
		boostButton.OnPressed += HandleBoostButtonPressed;
		initialHeight = Height;
		lostBoostPointsCost = new SafeInt(_lostBoostPointsCost);
	}

	protected void OnDestroy()
	{
		base.OnClickedOutside -= HandleClickedOutside;
		closeButton.OnPressed -= HandleCloseButtonPressed;
		addButton.OnPressed -= HandleAddButtonPressed;
		boostButton.OnPressed -= HandleBoostButtonPressed;
	}
}
