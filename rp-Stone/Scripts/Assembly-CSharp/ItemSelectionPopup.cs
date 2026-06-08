using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectionPopup : PopUpModalScreen
{
	public enum Mode
	{
		Fissure = 0,
		Triskelion = 1,
		TriskelionBoost = 2,
		Moondial = 3,
		LostItemBoost = 4,
		NameTag = 5,
		CustomItemList = 6
	}

	public AsciiTextBox titleBox;

	public ScrollContainer scrollContainer;

	public ItemSelectedContextButtons itemSelectedContextButtons;

	public AsciiString edgeCaseInfoLabel;

	public ItemRow rowPrefab;

	public ItemSlot slotPrefab;

	public int fiveColumnsMinScreenWidth = 65;

	public Action<Item> OnItemSelected;

	private List<AsciiObject> rows = new List<AsciiObject>();

	private Dictionary<AsciiObject, Stack<AsciiObject>> rowPoolDict = new Dictionary<AsciiObject, Stack<AsciiObject>>();

	private Stack<ItemSlot> slotPool = new Stack<ItemSlot>();

	private bool isShowingDetails;

	private int lastGridWidth;

	private int lastGridHeight;

	private int lastAnvilPosY;

	private int lastColumnCount;

	public Item selectedItem { get; set; }

	private ItemDetailsDialog itemDetailsDialog => GameStates.Singleton.itemScreen.itemDetailsDialog;

	public Mode mode { get; set; }

	public List<Item> customItemList { get; set; }

	public static ItemSelectionPopup singleton { get; private set; }

	public override void Show()
	{
		base.Show();
		selectedItem = null;
		UpdateContents();
	}

	public override void Hide()
	{
		base.Hide();
		customItemList = null;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		scrollContainer.UpdateTic();
		if (isShowingDetails)
		{
			itemDetailsDialog.UpdateTic();
			if (itemDetailsDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				isShowingDetails = false;
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		UpdateGridSizeChanged(r.width, r.height);
		offsetX = r.width - Width >> 1;
		base.Draw(r, offsetX - PositionX - (Width >> 1), offsetY);
		offsetY += PositionY + (int)transitionOffsetY;
		titleBox.Draw(r, offsetX, offsetY);
		edgeCaseInfoLabel.Draw(r, offsetX, offsetY);
		scrollContainer.Draw(r, offsetX, offsetY);
		if (isShowingDetails)
		{
			itemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
	}

	private void UpdateGridSizeChanged(int gridWidth, int gridHeight)
	{
		if (lastGridWidth != gridWidth || lastGridHeight != gridHeight)
		{
			lastGridWidth = gridWidth;
			lastGridHeight = gridHeight;
			if (gridWidth >= fiveColumnsMinScreenWidth)
			{
				SetColumnCount(5);
			}
			else
			{
				SetColumnCount(4);
			}
			scrollContainer.Height = gridHeight - scrollContainer.PositionY;
			scrollContainer.scrollBar.Height = scrollContainer.Height;
			UpdateContents();
		}
	}

	private void SetColumnCount(int columns)
	{
		if (lastColumnCount != columns)
		{
			lastColumnCount = columns;
			scrollContainer.Width = columns * (slotPrefab.Width - 1) + 1;
			Width = scrollContainer.PositionX + scrollContainer.Width;
			scrollContainer.scrollBar.PositionX = Width;
		}
	}

	protected override void Update()
	{
		if (!isShowingDetails)
		{
			base.Update();
		}
	}

	private void UpdateContents()
	{
		RemoveSlotCallbacks();
		itemSelectedContextButtons.Hide();
		RecycleAllSlots();
		RecycleAllRows();
		List<Item> list = ((mode == Mode.Fissure) ? Inventory.Singleton.GetBreakableItems() : ((mode == Mode.Triskelion) ? Inventory.Singleton.GetEnchantableItems() : ((mode == Mode.TriskelionBoost) ? Inventory.Singleton.GetEnchantBoostItems() : ((mode == Mode.Moondial) ? Inventory.Singleton.GetMutatableItems() : ((mode == Mode.LostItemBoost) ? Inventory.Singleton.GetLostItemBoostItems() : ((mode != Mode.NameTag) ? customItemList : Inventory.Singleton.GetNameTaggableItems()))))));
		Inventory.Sort(list);
		ItemRow itemRow = null;
		for (int i = 0; i < list.Count; i++)
		{
			Item item = list[i];
			if (!(item == null) && (mode != Mode.Fissure || !(item.id == "craft_book")))
			{
				ItemSlot slot = GetSlot();
				slot.SetContent(item, item.count);
				if (!Features.SCROLL_BY_DRAGGING)
				{
					slot.touchDownDelay = 0;
				}
				slot.OnPressed += HandleSlotPressed;
				slot.OnSecondaryPressed += HandleSlotSecondaryPressed;
				if (itemRow == null || itemRow.IsFull(slot.Width))
				{
					itemRow = AddRow(rowPrefab) as ItemRow;
				}
				itemRow.AddSlot(slot);
			}
		}
		if (mode == Mode.Triskelion && list.Count == 0)
		{
			edgeCaseInfoLabel.SetValue(Te.xt("You have no enchantments."));
		}
		else
		{
			edgeCaseInfoLabel.Clear();
		}
		scrollContainer.ConstrainScrollY();
	}

	private void RemoveSlotCallbacks()
	{
		for (int i = 0; i < rows.Count; i++)
		{
			MultiSlotRow multiSlotRow = rows[i] as MultiSlotRow;
			for (int j = 0; j < multiSlotRow.slots.Count; j++)
			{
				ItemSlot obj = multiSlotRow.slots[j] as ItemSlot;
				obj.OnPressed -= HandleSlotPressed;
				obj.OnSecondaryPressed -= HandleSlotSecondaryPressed;
			}
		}
	}

	private void ShowItemDetails(Item item)
	{
		if (item != null)
		{
			itemDetailsDialog.item = item;
			itemDetailsDialog.Show();
			isShowingDetails = true;
		}
	}

	private void HandleSlotPressed(DialogButton button)
	{
		ItemSlot itemSlot = button as ItemSlot;
		selectedItem = itemSlot.item;
		selectedItem.hasInteracted = true;
		itemSlot.UpdateBadge();
		if (OnItemSelected != null)
		{
			OnItemSelected(selectedItem);
		}
		Hide();
	}

	private void HandleSlotSecondaryPressed(DialogButton button)
	{
		ItemSlot itemSlot = button as ItemSlot;
		itemSlot.item.hasInteracted = true;
		itemSlot.UpdateBadge();
		ShowItemDetails(itemSlot.item);
	}

	private ItemSlot GetSlot()
	{
		if (slotPool.Count > 0)
		{
			return slotPool.Pop();
		}
		ItemSlot itemSlot = UnityEngine.Object.Instantiate(slotPrefab);
		itemSlot.transform.parent = base.transform;
		return itemSlot;
	}

	private AsciiObject AddRow(AsciiObject rowPrefab, bool top = false)
	{
		AsciiObject asciiObject;
		if (rowPoolDict.ContainsKey(rowPrefab) && rowPoolDict[rowPrefab].Count > 0)
		{
			asciiObject = rowPoolDict[rowPrefab].Pop();
		}
		else
		{
			asciiObject = UnityEngine.Object.Instantiate(rowPrefab);
			asciiObject.sourcePrefab = rowPrefab;
			asciiObject.transform.parent = base.transform;
		}
		asciiObject.Width = scrollContainer.Width;
		rows.Add(asciiObject);
		scrollContainer.AddRow(asciiObject, top);
		return asciiObject;
	}

	private void RecycleAllSlots()
	{
		for (int i = 0; i < rows.Count; i++)
		{
			ItemRow itemRow = rows[i] as ItemRow;
			for (int j = 0; j < itemRow.slots.Count; j++)
			{
				slotPool.Push(itemRow.slots[j] as ItemSlot);
			}
			itemRow.slots.Clear();
		}
	}

	private void RecycleAllRows()
	{
		scrollContainer.Clear();
		for (int num = rows.Count - 1; num >= 0; num--)
		{
			AsciiObject key = rows[num].sourcePrefab;
			Stack<AsciiObject> stack;
			if (rowPoolDict.ContainsKey(key))
			{
				stack = rowPoolDict[key];
			}
			else
			{
				stack = new Stack<AsciiObject>();
				rowPoolDict.Add(key, stack);
			}
			stack.Push(rows[num]);
		}
		rows.Clear();
	}

	protected override void OnDestroy()
	{
		RemoveSlotCallbacks();
		base.OnDestroy();
	}

	protected override void Awake()
	{
		base.Awake();
		singleton = this;
	}
}
