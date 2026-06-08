using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemScreen : ScrollContainerScreen, IActivatable
{
	public enum Mode
	{
		Inventory = 0,
		Anvil = 1
	}

	public enum State
	{
		Normal = 0,
		Dragging = 1,
		EquipPending = 2,
		ItemDetails = 3,
		OpeningTreasure = 4,
		CraftBook = 5,
		GoalBook = 6,
		SelectingItemToTag = 7,
		NameTagInput = 8,
		SelectingItemToApplyCosmetic = 9
	}

	public int fiveColumnsMinScreenWidth = 70;

	public int heroPosX;

	public int heroPosY;

	public ItemSlot leftEquippedFrame;

	public ItemSlot rightEquippedFrame;

	public AsciiString equippedLevelLabel;

	public Separator topSeparator;

	public AsciiSprite itemDragBG;

	public AsciiSprite itemDragVfx;

	public AsciiSprite ftueEquipSword;

	public AsciiString ftueEquipSwordLabel;

	public AsciiSprite dragInvalidIndicator;

	public ItemRow rowPrefab;

	public ItemSlot slotPrefab;

	public ItemDetailsDialog itemDetailsDialogPrefab;

	public OpenTreasureDialog openTreasureDialogPrefab;

	private OpenTreasureDialog openTreasureDialog;

	public ItemSelectedContextButtons itemSelectedContextButtons;

	public AsciiString selectItemToTagTitle;

	public NameTagInputDialog nameTagInput;

	public AsciiTextBox selectItemToApplyCosmetic;

	public AsciiSprite selectedSlotBorder;

	public RollingMessage rollingMessage;

	public Stack<ItemSlot> slotPool = new Stack<ItemSlot>();

	private int stateElapsedTics;

	private DialogButton draggingButton;

	private ItemSlot draggingItemSlot;

	private Item draggingItem;

	private bool isLeft;

	private bool isRight;

	private bool isInvalidSlotDrag;

	private bool openAllTreasures;

	private bool fastForwardTreasuresScheduled;

	private int fastForwardAdPlacementScheduled;

	private int fastForwardAdPlacementCount;

	private float fastForwardAdPlacementLastTimestamp;

	private int heroEquipmentLayoutOffsetX;

	private int lastGridWidth;

	private int lastGridHeight;

	private int lastOffsetY;

	private int lastAnvilPosY;

	private int lastColumnCount;

	private string ftueFlagKey = "ftue_equip_sword";

	private string swordId = "dirty_sword";

	private ModalFade _modalFade;

	private bool _updateScheduledEquipmentLayoutOffsetX;

	private bool useNameTagPending;

	private string applyCosmeticId;

	public ItemDetailsDialog itemDetailsDialog { get; private set; }

	public Mode mode { get; set; }

	public State currentState { get; private set; }

	public override void Activate()
	{
		base.Activate();
		ScheduleUpdateToHeroEquipmentLayoutOffsetX();
		SetState(State.Normal);
	}

	public void SetState(State newState)
	{
		if (currentState == State.EquipPending)
		{
			draggingItemSlot = null;
		}
		else if (currentState == State.SelectingItemToTag)
		{
			ItemSelectionPopup singleton = ItemSelectionPopup.singleton;
			singleton.OnItemSelected = (Action<Item>)Delegate.Remove(singleton.OnItemSelected, new Action<Item>(HandleItemSelectedToTag));
		}
		else if (currentState == State.SelectingItemToApplyCosmetic)
		{
			ItemSelectionPopup singleton2 = ItemSelectionPopup.singleton;
			singleton2.OnItemSelected = (Action<Item>)Delegate.Remove(singleton2.OnItemSelected, new Action<Item>(HandleItemSelectedToApplyCosmetic));
		}
		switch (newState)
		{
		case State.Dragging:
			EmitFromButton(draggingButton);
			scrollContainer.dragVelocity = 0f;
			break;
		case State.CraftBook:
			CraftBookScreen.singleton.Show();
			break;
		case State.GoalBook:
			GoalBookScreen.singleton.Show();
			break;
		case State.SelectingItemToTag:
		{
			nameTagInput.item = null;
			ItemSelectionPopup.singleton.mode = ItemSelectionPopup.Mode.NameTag;
			ItemSelectionPopup.singleton.Show();
			ItemSelectionPopup singleton4 = ItemSelectionPopup.singleton;
			singleton4.OnItemSelected = (Action<Item>)Delegate.Combine(singleton4.OnItemSelected, new Action<Item>(HandleItemSelectedToTag));
			break;
		}
		case State.NameTagInput:
			nameTagInput.Show();
			break;
		case State.SelectingItemToApplyCosmetic:
		{
			ItemSelectionPopup.singleton.Show();
			ItemSelectionPopup singleton3 = ItemSelectionPopup.singleton;
			singleton3.OnItemSelected = (Action<Item>)Delegate.Combine(singleton3.OnItemSelected, new Action<Item>(HandleItemSelectedToApplyCosmetic));
			break;
		}
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	private void EmitFromButton(DialogButton button)
	{
		if (button != null)
		{
			SpriteEmitter componentInChildren = itemDragVfx.GetComponentInChildren<SpriteEmitter>();
			if (componentInChildren != null)
			{
				componentInChildren.TryToEmit(button.lastDrawnX - button.clickPaddingLeft, button.lastDrawnY - button.clickPaddingTop);
			}
		}
	}

	public bool IsDraggingFromEquipSlot()
	{
		if (currentState == State.Dragging)
		{
			return draggingItemSlot == null;
		}
		return false;
	}

	public override void UpdateTic()
	{
		stateElapsedTics++;
		Hero hero = GameStates.Singleton.hero;
		if (currentState == State.EquipPending)
		{
			base.UpdateTic();
			if (isLeft && leftEquippedFrame.enabled)
			{
				leftEquippedFrame.UpdateTic();
			}
			if (isRight && rightEquippedFrame.enabled)
			{
				rightEquippedFrame.UpdateTic();
			}
		}
		else if (currentState == State.Normal)
		{
			base.UpdateTic();
			if (mode == Mode.Inventory)
			{
				if (hero.LeftHand != null)
				{
					leftEquippedFrame.UpdateTic();
				}
				else
				{
					leftEquippedFrame.activated = false;
				}
				if (hero.RightHand != null)
				{
					rightEquippedFrame.UpdateTic();
				}
				else
				{
					rightEquippedFrame.activated = false;
				}
				UtilityBeltUI.singleton.UpdateTic();
			}
			else if (mode == Mode.Anvil)
			{
				if (leftEquippedFrame.enabled)
				{
					leftEquippedFrame.UpdateTic();
				}
				if (rightEquippedFrame.enabled)
				{
					rightEquippedFrame.UpdateTic();
				}
			}
			if (draggingItemSlot != null)
			{
				bool flag = Mathf.Abs(AsciiMouse.singleton.dragAccumulatedX) >= 2 || AsciiMouse.singleton.dragAccumulatedY != 0;
				if (stateElapsedTics < Features.ITEM_DRAG_MIN_TICS_WITHOUT_MOVE && flag)
				{
					draggingButton = null;
					draggingItemSlot = null;
					draggingItem = null;
				}
				else if (stateElapsedTics >= Features.ITEM_DRAG_AUTO_INIT_NO_MOVE_TICS || (stateElapsedTics >= Features.ITEM_DRAG_MIN_TICS_WITHOUT_MOVE && flag))
				{
					draggingItemSlot.activated = false;
					SetState(State.Dragging);
				}
			}
			else if (draggingItem != null)
			{
				AsciiMouse singleton = AsciiMouse.singleton;
				if (!singleton.isDown0)
				{
					draggingItem = null;
				}
				else if (Mathf.Abs(singleton.dragAccumulatedX) >= 2 || singleton.dragAccumulatedY != 0)
				{
					SetState(State.Dragging);
				}
			}
		}
		else if (currentState == State.Dragging)
		{
			if (draggingItem != null && !AsciiMouse.singleton.isDown0)
			{
				Weapon weapon = draggingItem as Weapon;
				if (weapon == null)
				{
					Utils.Log("Can only equip weapons");
				}
				else if (isLeft)
				{
					EquipLeft(weapon);
				}
				else if (isRight)
				{
					EquipRight(weapon);
				}
				else if (AsciiMouse.singleton.y >= scrollContainer.lastContainerDrawY && AsciiMouse.singleton.x >= scrollContainer.lastContainerDrawX)
				{
					if (draggingItem == leftEquippedFrame.item)
					{
						UnequipLeft();
					}
					else if (draggingItem == rightEquippedFrame.item)
					{
						UnequipRight();
					}
				}
				if (isInvalidSlotDrag)
				{
					SfxController.singleton.Play("error");
				}
			}
			if (draggingItem == null || !AsciiMouse.singleton.isDown0)
			{
				draggingItemSlot = null;
				draggingItem = null;
				SetState(State.Normal);
			}
		}
		else if (currentState == State.ItemDetails)
		{
			itemDetailsDialog.UpdateTic();
			if (itemDetailsDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				if (useNameTagPending)
				{
					useNameTagPending = false;
					SetState(State.SelectingItemToTag);
				}
				else
				{
					SetState(State.Normal);
				}
			}
		}
		else if (currentState == State.OpeningTreasure)
		{
			openTreasureDialog.UpdateTic();
			if (openAllTreasures && openTreasureDialog.CurrentState == DialogNineSlice.State.Out && Inventory.Singleton.GetLastTreasure() != null)
			{
				if (!UpdateOpenAllTreasuresFastForward())
				{
					OpenNextTreasure();
				}
			}
			else if (openTreasureDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				if (openAllTreasures)
				{
					GameStates.Singleton.TryToSaveProgress();
				}
				SetState(State.Normal);
			}
		}
		else if (currentState == State.CraftBook)
		{
			CraftBookScreen.singleton.UpdateTic();
			if (CraftBookScreen.singleton.currentState == BaseBookScreen.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.GoalBook)
		{
			GoalBookScreen.singleton.UpdateTic();
			if (GoalBookScreen.singleton.currentState == BaseBookScreen.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.SelectingItemToTag)
		{
			ItemSelectionPopup.singleton.UpdateTic();
			if (ItemSelectionPopup.singleton.currentState == PopUpModalScreen.State.Disabled)
			{
				if (nameTagInput.item != null)
				{
					SetState(State.NameTagInput);
				}
				else
				{
					SetState(State.Normal);
				}
			}
		}
		else if (currentState == State.NameTagInput)
		{
			nameTagInput.UpdateTic();
			if (nameTagInput.CurrentState == DialogNineSlice.State.Disabled)
			{
				UpdateContents();
				SetState(State.Normal);
			}
		}
		else if (currentState == State.SelectingItemToApplyCosmetic)
		{
			ItemSelectionPopup.singleton.UpdateTic();
			if (ItemSelectionPopup.singleton.currentState == PopUpModalScreen.State.Disabled)
			{
				if (ItemSelectionPopup.singleton.selectedItem != null)
				{
					ShowItemDetails(ItemSelectionPopup.singleton.selectedItem);
				}
				else
				{
					SetState(State.Normal);
				}
			}
		}
		UpdateItemSelectedContextButtons();
	}

	private void UpdateItemSelectedContextButtons()
	{
		if (itemSelectedContextButtons.isEquipmentSlot)
		{
			if (currentState == State.Normal)
			{
				itemSelectedContextButtons.UpdateTic();
			}
		}
		else if (itemSelectedContextButtons.selectedItemSlot != null && itemSelectedContextButtons.currentState == ItemSelectedContextButtons.State.Idle && itemSelectedContextButtons.stateElapsedTics >= 7 && (itemSelectedContextButtons.selectedItemSlot.lastDrawY < scrollContainer.lastContainerDrawY - 1 || itemSelectedContextButtons.selectedItemSlot.lastDrawY + itemSelectedContextButtons.Height > GameStates.Singleton.asciiRenderer.height))
		{
			itemSelectedContextButtons.UpdateTic();
			itemSelectedContextButtons.Hide();
		}
		else if (currentState == State.Normal)
		{
			itemSelectedContextButtons.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		UpdateGridSizeChanged(r.width, r.height, PositionY);
		int num = 0;
		if (mode == Mode.Inventory && UtilityBeltUI.singleton.displayedWidth > 0 && !GameStates.Singleton.navBar.IsTransitioning())
		{
			int displayedWidth = UtilityBeltUI.singleton.displayedWidth;
			int num2 = scrollContainer.PositionX + scrollContainer.Width + offsetX - 1;
			if (num2 > r.width - displayedWidth)
			{
				num = r.width - displayedWidth - num2;
			}
		}
		base.Draw(r, offsetX + num, offsetY);
		int num3 = (scrollContainer.IsScrollBarEnabled() ? (-2) : 0);
		if (mode == Mode.Inventory)
		{
			offsetX += num;
			topSeparator.Draw(r, offsetX, offsetY);
			offsetX += num3;
			UpdateHeroEquipmentLayoutOffsetX();
			Hero hero = GameStates.Singleton.hero;
			int num4 = offsetX + heroPosX - hero.PositionX;
			int offsetY2 = offsetY + heroPosY - hero.PositionZ + hero.PositionY;
			num4 = ((hero.lookDirection != Character.LookDirection.Right) ? (num4 - heroEquipmentLayoutOffsetX) : (num4 + heroEquipmentLayoutOffsetX));
			hero.Draw(r, num4, offsetY2);
			leftEquippedFrame.Draw(r, offsetX, offsetY);
			rightEquippedFrame.Draw(r, offsetX, offsetY);
			if ((bool)rightEquippedFrame.item)
			{
				Weapon weapon = rightEquippedFrame.item as Weapon;
				if (weapon != null && weapon.handType == Weapon.HandType.DoubleHanded)
				{
					num4 = leftEquippedFrame.lastDrawX + 1;
					offsetY2 = leftEquippedFrame.lastDrawY + 1;
					DrawItemIcon(rightEquippedFrame.item, r, num4 + 3, offsetY2 + 1, drawLevelLabel: false, darken: true);
				}
			}
			rollingMessage.Draw(r, offsetX, offsetY);
			offsetX -= num;
			UtilityBeltUI.singleton.Draw(r, offsetX, offsetY);
		}
		else if (mode == Mode.Anvil)
		{
			if (leftEquippedFrame.enabled)
			{
				leftEquippedFrame.Draw(r, offsetX, offsetY);
			}
			if (rightEquippedFrame.enabled)
			{
				rightEquippedFrame.Draw(r, offsetX, offsetY);
			}
		}
		if (currentState == State.Dragging && draggingItem != null)
		{
			int num4 = AsciiMouse.singleton.x;
			int offsetY2 = AsciiMouse.singleton.y;
			isLeft = false;
			isRight = false;
			isInvalidSlotDrag = false;
			isLeft = num4 >= leftEquippedFrame.lastDrawX - 1 && num4 < leftEquippedFrame.lastDrawX + leftEquippedFrame.Width + 3 && offsetY2 >= leftEquippedFrame.lastDrawY && offsetY2 < leftEquippedFrame.lastDrawY + leftEquippedFrame.Height + 1;
			isRight = num4 >= rightEquippedFrame.lastDrawX - 1 && num4 < rightEquippedFrame.lastDrawX + rightEquippedFrame.Width + 3 && offsetY2 >= rightEquippedFrame.lastDrawY && offsetY2 < rightEquippedFrame.lastDrawY + rightEquippedFrame.Height + 1;
			if (mode == Mode.Inventory)
			{
				Weapon weapon2 = draggingItem as Weapon;
				if (weapon2 != null)
				{
					if ((isRight || isLeft) && weapon2.handType == Weapon.HandType.DoubleHanded)
					{
						isLeft = (isRight = true);
					}
					else if (isLeft && (weapon2.handType == Weapon.HandType.RightOnly || weapon2.handType == Weapon.HandType.CannotEquip))
					{
						isLeft = false;
						DrawInvalidIndicatorOnFrame(r, leftEquippedFrame);
					}
					else if (isRight && (weapon2.handType == Weapon.HandType.LeftOnly || weapon2.handType == Weapon.HandType.CannotEquip))
					{
						isRight = false;
						DrawInvalidIndicatorOnFrame(r, rightEquippedFrame);
					}
				}
				else if (isLeft)
				{
					isLeft = false;
					DrawInvalidIndicatorOnFrame(r, leftEquippedFrame);
				}
				else if (isRight)
				{
					isRight = false;
					DrawInvalidIndicatorOnFrame(r, rightEquippedFrame);
				}
			}
			else
			{
				_ = mode;
				_ = 1;
			}
			num4--;
			offsetY2--;
			if (isLeft)
			{
				HighlightFrame(r, leftEquippedFrame);
			}
			if (isRight)
			{
				HighlightFrame(r, rightEquippedFrame);
			}
			DrawDraggingIcon(r);
		}
		DrawFtueEquipSword(r);
		if (currentState == State.EquipPending && draggingItemSlot != null)
		{
			selectedSlotBorder.Draw(r, draggingItemSlot.lastDrawX, draggingItemSlot.lastDrawY);
			if (isLeft)
			{
				BlinkFrame(r, leftEquippedFrame);
			}
			if (isRight)
			{
				BlinkFrame(r, rightEquippedFrame);
			}
		}
		itemSelectedContextButtons.Draw(r, 0, 0);
		UpdateModalFade();
		DrawFtueEquipSwordPart2(r);
		if (currentState == State.ItemDetails)
		{
			itemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.OpeningTreasure)
		{
			openTreasureDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.CraftBook)
		{
			CraftBookScreen.singleton.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.GoalBook)
		{
			GoalBookScreen.singleton.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.SelectingItemToTag)
		{
			ItemSelectionPopup.singleton.Draw(r, r.width >> 1, 2);
			selectItemToTagTitle.Draw(r, r.width >> 1, 0);
		}
		else if (currentState == State.NameTagInput)
		{
			nameTagInput.Draw(r, (r.width - nameTagInput.Width) / 2, (r.height - nameTagInput.Height) / 2);
		}
		else if (currentState == State.SelectingItemToApplyCosmetic)
		{
			ItemSelectionPopup.singleton.Draw(r, r.width >> 1, 2);
			selectItemToApplyCosmetic.Draw(r, r.width >> 1, 0);
		}
	}

	private void DrawInvalidIndicatorOnFrame(AsciiRenderProcedural r, ItemSlot equipmentFrame)
	{
		isInvalidSlotDrag = true;
		dragInvalidIndicator.Draw(r, equipmentFrame.lastDrawX, equipmentFrame.lastDrawY);
	}

	private void HighlightFrame(AsciiRenderProcedural r, DialogNineSlice frame)
	{
		for (int i = 0; i < frame.Width; i++)
		{
			for (int j = 0; j < frame.Height; j++)
			{
				if (i == 0 || j == 0 || i == frame.Width - 1 || j == frame.Height - 1)
				{
					r.GetCell(frame.lastDrawX + i, frame.lastDrawY + j)?.SetForeground(ColorConstants.white);
				}
			}
		}
	}

	public void DrawDraggingIcon(AsciiRenderProcedural r)
	{
		if (currentState == State.Dragging && draggingItem != null)
		{
			int num = AsciiMouse.singleton.x - 1;
			int num2 = AsciiMouse.singleton.y - 1;
			itemDragBG.Draw(r, num, num2);
			DrawItemIcon(draggingItem, r, num, num2, drawLevelLabel: false);
		}
	}

	private void BlinkFrame(AsciiRenderProcedural r, DialogNineSlice frame)
	{
		if (stateElapsedTics % 16 < 8)
		{
			HighlightFrame(r, frame);
		}
	}

	private void DrawItemIcon(Item item, AsciiRenderProcedural r, int x, int y, bool drawLevelLabel = true, bool darken = false)
	{
		if (item == null)
		{
			return;
		}
		AsciiSprite icon = item.GetIcon();
		if (icon != null)
		{
			if (darken)
			{
				icon.Draw(r, x, y, 0.5f);
			}
			else
			{
				icon.Draw(r, x, y);
			}
		}
		if (drawLevelLabel)
		{
			DrawItemLevel(item, r, x, y);
		}
	}

	public void DrawItemLevel(Item item, AsciiRenderProcedural r, int x, int y)
	{
		if (!(item == null) && !(ItemFactory.GetLevelDisplayValueForItem(item) <= 1f))
		{
			string value = "L:" + ItemFactory.GetLevelDisplayStringForItem(item);
			equippedLevelLabel.SetValue(value);
			equippedLevelLabel.Draw(r, x, y);
		}
	}

	private void UpdateGridSizeChanged(int gridWidth, int gridHeight, int offsetY)
	{
		if (lastGridWidth != gridWidth || lastGridHeight != gridHeight || lastOffsetY != offsetY || (mode == Mode.Anvil && lastAnvilPosY != AnvilScreen.singleton.PositionY))
		{
			lastGridWidth = gridWidth;
			lastGridHeight = gridHeight;
			lastOffsetY = offsetY;
			if (gridWidth >= fiveColumnsMinScreenWidth)
			{
				SetColumnCount(5);
			}
			else
			{
				SetColumnCount(4);
			}
			scrollContainer.Height = Mathf.Max(5, gridHeight - scrollContainer.PositionY - offsetY);
			if (mode == Mode.Anvil)
			{
				scrollContainer.Height -= AnvilScreen.singleton.PositionY + 1;
				lastAnvilPosY = AnvilScreen.singleton.PositionY;
			}
			scrollContainer.scrollBar.Height = scrollContainer.Height - (scrollContainer.scrollBar.PositionY - scrollContainer.PositionY);
			UpdateContents();
		}
	}

	private void SetColumnCount(int columns)
	{
		if (lastColumnCount != columns)
		{
			lastColumnCount = columns;
			scrollContainer.Width = columns * (slotPrefab.Width - 1) + 1;
			scrollContainer.scrollBar.PositionX = scrollContainer.PositionX + scrollContainer.Width;
			Width = scrollContainer.Width + 3;
			topSeparator.length = Width;
			if (mode == Mode.Inventory)
			{
				heroPosX = Width / 2 + 3;
				leftEquippedFrame.PositionX = heroPosX - 17;
				rightEquippedFrame.PositionX = heroPosX + 9;
			}
		}
	}

	public override void UpdateContents()
	{
		UpdateEquippedSlots();
		ScheduleUpdateToHeroEquipmentLayoutOffsetX();
		RemoveSlotCallbacks();
		itemSelectedContextButtons.Hide();
		ItemRow itemRow;
		for (int i = 0; i < rows.Count; i++)
		{
			itemRow = rows[i] as ItemRow;
			for (int j = 0; j < itemRow.slots.Count; j++)
			{
				slotPool.Push(itemRow.slots[j] as ItemSlot);
			}
			itemRow.slots.Clear();
		}
		RecycleAllRows();
		List<Item> list;
		Item item;
		Item item2;
		if (mode == Mode.Anvil)
		{
			list = Inventory.Singleton.GetCraftableItems();
			item = AnvilScreen.singleton.firstSlot;
			item2 = AnvilScreen.singleton.secondSlot;
		}
		else
		{
			list = Inventory.Singleton.GetAllItems();
			item = GameStates.Singleton.hero.LeftHand;
			item2 = GameStates.Singleton.hero.RightHand;
		}
		Inventory.Sort(list);
		string text = ((item == null) ? null : item.GetGroupId());
		string text2 = ((item2 == null) ? null : item2.GetGroupId());
		itemRow = null;
		for (int k = 0; k < list.Count; k++)
		{
			Item item3 = list[k];
			if (item3 == null)
			{
				continue;
			}
			string groupId = item3.GetGroupId();
			int num = 0;
			if (groupId == text)
			{
				num += leftEquippedFrame.count;
			}
			if (groupId == text2)
			{
				num += rightEquippedFrame.count;
			}
			if (item3.count > num)
			{
				ItemSlot slot = GetSlot();
				slot.SetContent(item3, item3.count - num);
				if (!Features.SCROLL_BY_DRAGGING)
				{
					slot.touchDownDelay = 0;
				}
				slot.OnDown += HandleOnSlotDown;
				slot.OnPressed += HandleOnSlotPressed;
				slot.OnSecondaryPressed += HandleOnSecondaryPressed;
				if (itemRow == null || itemRow.IsFull(slot.Width))
				{
					itemRow = AddRowFromPrefab(rowPrefab) as ItemRow;
				}
				itemRow.AddSlot(slot);
			}
		}
		scrollContainer.ConstrainScrollY();
	}

	public void UpdateContentForItemCountChange(Item item)
	{
		if (item == null)
		{
			return;
		}
		for (int i = 0; i < rows.Count; i++)
		{
			ItemRow itemRow = rows[i] as ItemRow;
			for (int j = 0; j < itemRow.slots.Count; j++)
			{
				ItemSlot itemSlot = itemRow.slots[j] as ItemSlot;
				if (itemSlot.item == item)
				{
					UpdateEquippedSlots();
					Item item2;
					Item item3;
					if (mode == Mode.Anvil)
					{
						item2 = AnvilScreen.singleton.firstSlot;
						item3 = AnvilScreen.singleton.secondSlot;
					}
					else
					{
						item2 = GameStates.Singleton.hero.LeftHand;
						item3 = GameStates.Singleton.hero.RightHand;
					}
					string text = ((item2 == null) ? null : item2.GetGroupId());
					string text2 = ((item3 == null) ? null : item3.GetGroupId());
					string groupId = item.GetGroupId();
					int num = 0;
					if (groupId == text)
					{
						num += leftEquippedFrame.count;
					}
					if (groupId == text2)
					{
						num += rightEquippedFrame.count;
					}
					if (item.count <= num)
					{
						UpdateContents();
					}
					else
					{
						itemSlot.count = item.count - num;
					}
					return;
				}
			}
		}
		UpdateContents();
	}

	private bool UpdateOpenAllTreasuresFastForward()
	{
		if (fastForwardTreasuresScheduled)
		{
			fastForwardTreasuresScheduled = false;
			FastForwardTreasures(AdsWrapper.TREASURE_COUNT_TO_FAST_FORWARD);
		}
		else if (fastForwardAdPlacementScheduled > 0 && !SubscriptionController.singleton.HasSubscription(SubscriptionController.EVENTS_SUBSCRIPTION_ID))
		{
			fastForwardAdPlacementScheduled--;
			if (fastForwardAdPlacementScheduled == 0)
			{
				fastForwardAdPlacementCount++;
				fastForwardAdPlacementLastTimestamp = Time.realtimeSinceStartup;
				AdsWrapper.singleton.ShowRewardedAd(delegate(bool success)
				{
					if (success)
					{
						AnalyticsMacros.WatchedFastForward();
						FastForwardTreasures(AdsWrapper.TREASURE_COUNT_TO_FAST_FORWARD);
					}
					else
					{
						AnalyticsMacros.FailedToShowAd();
					}
				});
				return true;
			}
		}
		return false;
	}

	private void FastForwardTreasures(int amount)
	{
		List<TreasureItem> treasures = Inventory.Singleton.GetTreasures();
		treasures.Sort((TreasureItem treasureA, TreasureItem treasureB) => -treasureA.type.CompareTo(treasureB.type));
		int num = 1;
		int num2 = treasures.Count - num;
		TreasureItem.Type type = TreasureItem.Type.Humble;
		while (amount-- > 0 && num2 >= 0)
		{
			TreasureItem treasureItem = treasures[num2];
			if (treasureItem == openTreasureDialog.treasure || treasureItem == null)
			{
				num++;
				amount++;
			}
			else
			{
				if (treasureItem.type >= TreasureItem.Type.Epic && type < TreasureItem.Type.Epic)
				{
					break;
				}
				type = treasureItem.type;
				treasureItem.GrantRewards(treasureItem.MakeAllRewards());
				num = 1;
			}
			num2 = treasures.Count - num;
		}
	}

	private bool ShowFtueEquipSword()
	{
		if (ProgressFlags.GetFlag(ftueFlagKey))
		{
			return false;
		}
		if (!Inventory.Singleton.HasItemById(swordId))
		{
			return false;
		}
		if (itemSelectedContextButtons.isShowing)
		{
			return false;
		}
		Hero hero = GameStates.Singleton.hero;
		if ((hero.LeftHand != null && hero.LeftHand.id == swordId) || (hero.RightHand != null && hero.RightHand.id == swordId) || Inventory.Singleton.GetItemCount() >= 6)
		{
			ProgressFlags.SetFlag(ftueFlagKey);
			QuestController.singleton.MakeAvailable("clean_sword");
			return false;
		}
		return draggingItem == null;
	}

	private void DrawFtueEquipSword(AsciiRenderProcedural r)
	{
		if (!ShowFtueEquipSword() || !(Mathf.Repeat(Time.realtimeSinceStartup, 1f) < 0.8f))
		{
			return;
		}
		ftueEquipSwordLabel.SetValue(Te.xt("Tap to equip Sword"));
		for (int i = 0; i < rows.Count; i++)
		{
			ItemRow itemRow = rows[i] as ItemRow;
			if (!(itemRow != null))
			{
				continue;
			}
			for (int j = 0; j < itemRow.slots.Count; j++)
			{
				ItemSlot itemSlot = itemRow.slots[j] as ItemSlot;
				if (itemSlot != null && itemSlot.item.id == swordId)
				{
					int offsetX = itemSlot.lastDrawX + (itemSlot.Width >> 1);
					int offsetY = itemSlot.lastDrawY + itemSlot.Height;
					ftueEquipSword.Draw(r, offsetX, offsetY);
					ftueEquipSwordLabel.Draw(r, offsetX, offsetY);
					return;
				}
			}
		}
	}

	private void UpdateModalFade()
	{
		if (_modalFade != null && mode == Mode.Inventory)
		{
			_modalFade.active = currentState == State.EquipPending;
		}
	}

	private void DrawFtueEquipSwordPart2(AsciiRenderProcedural r)
	{
		if (ProgressFlags.GetFlag(ftueFlagKey) || !(_modalFade != null) || currentState != State.EquipPending)
		{
			return;
		}
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				if (i < leftEquippedFrame.lastDrawnX || i >= rightEquippedFrame.lastDrawX + rightEquippedFrame.Width || j >= leftEquippedFrame.lastDrawnY + leftEquippedFrame.Height)
				{
					AsciiCellProcedural cell = r.GetCell(i, j);
					_modalFade.ApplyModalFadeToCell(cell);
				}
			}
		}
	}

	public override void Deactivate()
	{
		base.Deactivate();
		itemSelectedContextButtons.Hide();
	}

	private void HandleOnSlotDown(DialogButton button)
	{
		if (currentState != State.EquipPending)
		{
			stateElapsedTics = 0;
			draggingButton = button;
			draggingItemSlot = button as ItemSlot;
			draggingItem = draggingItemSlot.item;
			draggingItem.SetHasInteracted(value: true);
			draggingItemSlot.UpdateBadge();
		}
	}

	private void HandleOnSlotPressed(DialogButton button)
	{
		bool flag = false;
		if (currentState == State.EquipPending)
		{
			flag = button == draggingItemSlot;
			SetState(State.Normal);
		}
		draggingItemSlot = null;
		draggingItem = null;
		ItemSlot itemSlot = button as ItemSlot;
		if (itemSlot.item.id == "craft_book")
		{
			SetState(State.CraftBook);
		}
		else if (itemSlot.item.id == "goal_book")
		{
			SetState(State.GoalBook);
		}
		else if (mode == Mode.Anvil && (leftEquippedFrame.item == null || rightEquippedFrame.item == null))
		{
			if (leftEquippedFrame.item == null)
			{
				EquipLeft(itemSlot.item as Weapon);
			}
			else if (rightEquippedFrame.item == null)
			{
				EquipRight(itemSlot.item as Weapon);
			}
		}
		else
		{
			if (!flag)
			{
				itemSelectedContextButtons.mode = mode;
				itemSelectedContextButtons.isEquipmentSlot = false;
				itemSelectedContextButtons.Show(itemSlot);
			}
			int num = GameStates.Singleton.asciiRenderer.height - itemSelectedContextButtons.Height;
			int lastDrawY = itemSlot.lastDrawY;
			if (lastDrawY > num)
			{
				scrollContainer.SetScrollY(scrollContainer.ScrollY + lastDrawY - num, jumpToPosition: false);
			}
			else
			{
				int lastContainerDrawY = scrollContainer.lastContainerDrawY;
				if (lastDrawY < lastContainerDrawY)
				{
					scrollContainer.SetScrollY(scrollContainer.ScrollY + lastDrawY - lastContainerDrawY, jumpToPosition: false);
				}
			}
		}
		itemSlot.item.SetHasInteracted(value: true);
		itemSlot.UpdateBadge();
	}

	public void ShowItemDetails(Item item)
	{
		TreasureItem treasureItem = item as TreasureItem;
		if (treasureItem != null)
		{
			SetState(State.OpeningTreasure);
			openTreasureDialog.Setup(treasureItem, openAllTreasures);
			openTreasureDialog.Show();
			AnalyticsMacros.OpenTreasure(treasureItem);
		}
		else
		{
			SetState(State.ItemDetails);
			itemDetailsDialog.item = item;
			itemDetailsDialog.Show();
			AnalyticsMacros.ItemDetails(item);
		}
	}

	private void OpenNextTreasure()
	{
		TreasureItem lastTreasure = Inventory.Singleton.GetLastTreasure();
		if (lastTreasure == null || (lastTreasure.type == TreasureItem.Type.Gold && !CosmeticController.singleton.HasCosmeticsToDrop(countFinalCollectionItems: false)) || (lastTreasure.type == TreasureItem.Type.Prismatic && !CosmeticController.singleton.HasCosmeticsToDrop(countFinalCollectionItems: false, "prismatic")))
		{
			openAllTreasures = false;
			SetState(State.Normal);
		}
		else
		{
			ShowItemDetails(lastTreasure);
		}
	}

	public void EquipLeft(Weapon weapon)
	{
		SfxController.singleton.Play("equip");
		if (mode == Mode.Inventory)
		{
			if (rightEquippedFrame.item == weapon && draggingItemSlot != null)
			{
				rollingMessage.Show(Te.xt("Cannot equip identical items"), Color.grey);
			}
			GameStates.Singleton.hero.EquipLeft(weapon);
			AnalyticsMacros.ItemEquipped(weapon, "left");
		}
		else if (mode == Mode.Anvil)
		{
			AnvilScreen.singleton.firstSlot = weapon;
		}
		UpdateContents();
	}

	public void EquipRight(Weapon weapon, bool playSfx = true)
	{
		if (playSfx)
		{
			SfxController.singleton.Play("equip");
		}
		if (mode == Mode.Inventory)
		{
			if (leftEquippedFrame.item == weapon && draggingItemSlot != null)
			{
				rollingMessage.Show(Te.xt("Cannot equip identical items"), Color.grey);
			}
			GameStates.Singleton.hero.EquipRight(weapon);
			AnalyticsMacros.ItemEquipped(weapon, "right");
		}
		else if (mode == Mode.Anvil)
		{
			AnvilScreen.singleton.secondSlot = weapon;
		}
		UpdateContents();
	}

	private void UnequipLeft()
	{
		draggingItem = null;
		if (mode == Mode.Inventory)
		{
			Hero hero = GameStates.Singleton.hero;
			if (hero.LeftHand != null)
			{
				hero.Unequip(hero.LeftHand);
			}
			else if (hero.RightHand != null && hero.RightHand.handType == Weapon.HandType.DoubleHanded)
			{
				hero.Unequip(hero.RightHand);
			}
		}
		else if (mode == Mode.Anvil)
		{
			AnvilScreen.singleton.firstSlot = null;
		}
		UpdateContents();
		EmitFromButton(leftEquippedFrame);
		SfxController.singleton.Play("unequip");
	}

	private void UnequipRight()
	{
		draggingItem = null;
		if (mode == Mode.Inventory)
		{
			Hero hero = GameStates.Singleton.hero;
			hero.Unequip(hero.RightHand);
		}
		else if (mode == Mode.Anvil)
		{
			AnvilScreen.singleton.secondSlot = null;
		}
		UpdateContents();
		EmitFromButton(rightEquippedFrame);
		SfxController.singleton.Play("unequip");
	}

	private void UpdateEquippedSlots()
	{
		if (mode == Mode.Inventory)
		{
			leftEquippedFrame.SetContent(GameStates.Singleton.hero.LeftHand, 1);
			rightEquippedFrame.SetContent(GameStates.Singleton.hero.RightHand, 1);
		}
		else if (mode == Mode.Anvil)
		{
			leftEquippedFrame.SetContent(AnvilScreen.singleton.firstSlot, 1);
			rightEquippedFrame.SetContent(AnvilScreen.singleton.secondSlot, AnvilScreen.singleton.secondSlotCount);
		}
	}

	private void HandleOnLeftEquipDown(DialogButton button)
	{
		if (currentState == State.EquipPending)
		{
			return;
		}
		stateElapsedTics = 0;
		if (mode == Mode.Inventory)
		{
			Hero hero = GameStates.Singleton.hero;
			if (hero.LeftHand != null)
			{
				draggingItem = hero.LeftHand;
			}
			else if (hero.RightHand != null && hero.RightHand.handType == Weapon.HandType.DoubleHanded)
			{
				draggingItem = hero.RightHand;
			}
		}
		else if (mode == Mode.Anvil)
		{
			draggingItem = AnvilScreen.singleton.firstSlot;
		}
		draggingButton = button;
	}

	private void HandleOnRightEquipDown(DialogButton button)
	{
		if (currentState != State.EquipPending)
		{
			stateElapsedTics = 0;
			if (mode == Mode.Inventory)
			{
				draggingItem = GameStates.Singleton.hero.RightHand;
			}
			else if (mode == Mode.Anvil)
			{
				draggingItem = AnvilScreen.singleton.secondSlot;
			}
			draggingButton = button;
		}
	}

	private void HandleOnLeftEquipPressed(DialogButton button)
	{
		if (currentState == State.EquipPending)
		{
			if (draggingItemSlot != null)
			{
				AssertSlot(draggingItemSlot);
				AssertItem(draggingItemSlot.item);
				EquipLeft(draggingItemSlot.item as Weapon);
			}
			SetState(State.Normal);
		}
		else if (mode == Mode.Inventory)
		{
			ItemSlot slot = button as ItemSlot;
			itemSelectedContextButtons.mode = mode;
			itemSelectedContextButtons.isEquipmentSlot = true;
			itemSelectedContextButtons.Show(slot);
		}
		else
		{
			UnequipLeft();
		}
	}

	private void HandleOnRightEquipPressed(DialogButton button)
	{
		if (currentState == State.EquipPending)
		{
			if (draggingItemSlot != null)
			{
				EquipRight(draggingItemSlot.item as Weapon);
			}
			SetState(State.Normal);
		}
		else if (mode == Mode.Inventory)
		{
			ItemSlot slot = button as ItemSlot;
			itemSelectedContextButtons.mode = mode;
			itemSelectedContextButtons.isEquipmentSlot = true;
			itemSelectedContextButtons.Show(slot);
		}
		else
		{
			UnequipRight();
		}
	}

	private void HandleOnSecondaryPressed(DialogButton button)
	{
		ItemSlot itemSlot = button as ItemSlot;
		if (itemSlot.item != null)
		{
			itemSlot.item.SetHasInteracted(value: true);
			itemSlot.UpdateBadge();
			itemSelectedContextButtons.Hide();
			openAllTreasures = false;
			ShowItemDetails(itemSlot.item);
		}
	}

	private void AssertSlot(ItemSlot slot)
	{
		_ = slot.item;
	}

	private void AssertItem(Item item)
	{
		_ = item.hasInteracted;
	}

	private void AssertContextButtons(ItemSelectedContextButtons contextButtons)
	{
		_ = contextButtons.enabled;
	}

	private void HandleOnItemEquipContextButton(ItemSlot itemSlot)
	{
		if (itemSelectedContextButtons.isEquipmentSlot)
		{
			if (itemSlot == leftEquippedFrame)
			{
				UnequipLeft();
			}
			else
			{
				UnequipRight();
			}
			return;
		}
		if (itemSlot.item is TreasureItem)
		{
			openAllTreasures = true;
			TreasureItem lastTreasure = Inventory.Singleton.GetLastTreasure();
			if (lastTreasure != null)
			{
				ShowItemDetails(lastTreasure);
			}
			else
			{
				ShowItemDetails(itemSlot.item);
			}
			return;
		}
		Weapon weapon = itemSlot.item as Weapon;
		if ((bool)weapon)
		{
			draggingItemSlot = itemSlot;
			isLeft = weapon.handType != Weapon.HandType.RightOnly || mode == Mode.Anvil;
			isRight = weapon.handType != Weapon.HandType.LeftOnly || mode == Mode.Anvil;
			itemSelectedContextButtons.Hide();
			SetState(State.EquipPending);
		}
	}

	private void HandleOnItemDetailsContextButton(ItemSlot itemSlot)
	{
		openAllTreasures = false;
		ShowItemDetails(itemSlot.item);
	}

	private void HandleStopOpenAllTreasures()
	{
		openAllTreasures = false;
	}

	private void HandleFastForwardTreasureAnimations()
	{
		fastForwardTreasuresScheduled = true;
		fastForwardAdPlacementScheduled = 0;
	}

	private void HandleScrollBarPercentChanged(ScrollBar bar)
	{
		if (itemSelectedContextButtons.selectedItemSlot != null)
		{
			itemSelectedContextButtons.Hide();
		}
	}

	private void ScheduleUpdateToHeroEquipmentLayoutOffsetX()
	{
		_updateScheduledEquipmentLayoutOffsetX = true;
	}

	private void UpdateHeroEquipmentLayoutOffsetX()
	{
		if (!_updateScheduledEquipmentLayoutOffsetX)
		{
			return;
		}
		_updateScheduledEquipmentLayoutOffsetX = false;
		Hero hero = GameStates.Singleton.hero;
		Weapon leftHand = hero.LeftHand;
		Weapon rightHand = hero.RightHand;
		int num = -1;
		int num2 = 1;
		if (leftHand != null && leftHand.GetCurrentSprite() != null)
		{
			AsciiSprite currentSprite = leftHand.GetCurrentSprite();
			if (!currentSprite.loaded)
			{
				_updateScheduledEquipmentLayoutOffsetX = true;
			}
			else
			{
				num = Mathf.Min(num, 1 - currentSprite.pivotX);
				num2 = Mathf.Max(num2, currentSprite.width - currentSprite.pivotX);
			}
		}
		if (rightHand != null && rightHand.GetCurrentSprite() != null)
		{
			AsciiSprite currentSprite2 = rightHand.GetCurrentSprite();
			if (!currentSprite2.loaded)
			{
				_updateScheduledEquipmentLayoutOffsetX = true;
			}
			else
			{
				num = Mathf.Min(num, 1 - currentSprite2.pivotX);
				num2 = Mathf.Max(num2, currentSprite2.width - currentSprite2.pivotX);
			}
		}
		int num3 = (num + num2) * 2 / -5;
		if (num3 == 1 || num3 == -1)
		{
			num3 = 0;
		}
		heroEquipmentLayoutOffsetX = num3;
	}

	private void HandleUseItemPressed(DialogButton btn)
	{
		if (itemDetailsDialog.item != null && itemDetailsDialog.item.id == "name_tag")
		{
			useNameTagPending = true;
			itemDetailsDialog.Hide();
			itemSelectedContextButtons.Hide();
		}
	}

	private void HandleItemSelectedToTag(Item item)
	{
		ItemSelectionPopup singleton = ItemSelectionPopup.singleton;
		singleton.OnItemSelected = (Action<Item>)Delegate.Remove(singleton.OnItemSelected, new Action<Item>(HandleItemSelectedToTag));
		nameTagInput.item = item;
	}

	private void HandleApplyCosmeticPressed(DialogButton btn)
	{
		if (itemDetailsDialog.item == null)
		{
			return;
		}
		Cosmetic cosmetic = itemDetailsDialog.item as Cosmetic;
		if (cosmetic == null)
		{
			return;
		}
		if (cosmetic.targetItem.appliedGroupId == null)
		{
			applyCosmeticId = cosmetic.cosmeticCollection.collectionId;
			List<Item> list = Inventory.Singleton.FindItems(cosmetic.targetItem.itemId, cosmetic.targetItem.element);
			ItemSelectionPopup.singleton.customItemList = list;
			ItemSelectionPopup.singleton.mode = ItemSelectionPopup.Mode.CustomItemList;
			if (list.Count > 0)
			{
				selectItemToApplyCosmetic.Text = Te.xt("Choose weapon to accessorize");
				selectItemToApplyCosmetic.positionY = 1;
			}
			else
			{
				selectItemToApplyCosmetic.Text = Te.xt("You don't own any weapons compatible with this cosmetic");
				selectItemToApplyCosmetic.positionY = 5;
			}
			SetState(State.SelectingItemToApplyCosmetic);
			return;
		}
		btn.label.SetValue(Te.xt("Apply"));
		Item item = Inventory.Singleton.GetItem(cosmetic.targetItem.appliedGroupId);
		Weapon weapon = item as Weapon;
		if (item != null && item.cosmetic != null)
		{
			if (weapon != null)
			{
				weapon.RemoveCosmeticFromSprites();
			}
			item.cosmeticId = null;
			item.cosmetic = null;
		}
		cosmetic.targetItem.appliedGroupId = null;
		if (weapon != null)
		{
			weapon.ReloadSprites();
		}
		UpdateContents();
	}

	private void HandleItemSelectedToApplyCosmetic(Item item)
	{
		ItemSelectionPopup singleton = ItemSelectionPopup.singleton;
		singleton.OnItemSelected = (Action<Item>)Delegate.Remove(singleton.OnItemSelected, new Action<Item>(HandleItemSelectedToApplyCosmetic));
		Weapon weapon = item as Weapon;
		if (item.cosmetic != null)
		{
			if (weapon != null)
			{
				weapon.RemoveCosmeticFromSprites();
			}
			item.cosmetic.targetItem.appliedGroupId = null;
		}
		item.cosmeticId = applyCosmeticId;
		Cosmetic cosmetic = itemDetailsDialog.item as Cosmetic;
		if (!(cosmetic == null))
		{
			cosmetic.targetItem.appliedGroupId = item.GetGroupId();
			if (weapon != null)
			{
				weapon.cosmetic = cosmetic;
				weapon.ReloadSprites();
			}
			UpdateContents();
		}
	}

	private void Awake()
	{
		_modalFade = GetComponent<ModalFade>();
		itemSelectedContextButtons = UnityEngine.Object.Instantiate(itemSelectedContextButtons);
		itemSelectedContextButtons.transform.SetParent(base.transform);
		itemDetailsDialog = UnityEngine.Object.Instantiate(itemDetailsDialogPrefab);
	}

	private void Start()
	{
		if (openTreasureDialogPrefab != null)
		{
			openTreasureDialog = UnityEngine.Object.Instantiate(openTreasureDialogPrefab);
			openTreasureDialog.OnStopOpenAll += HandleStopOpenAllTreasures;
			openTreasureDialog.OnSkipAll += HandleFastForwardTreasureAnimations;
		}
		leftEquippedFrame.OnDown += HandleOnLeftEquipDown;
		leftEquippedFrame.OnPressed += HandleOnLeftEquipPressed;
		leftEquippedFrame.OnSecondaryPressed += HandleOnSecondaryPressed;
		rightEquippedFrame.OnDown += HandleOnRightEquipDown;
		rightEquippedFrame.OnPressed += HandleOnRightEquipPressed;
		rightEquippedFrame.OnSecondaryPressed += HandleOnSecondaryPressed;
		itemSelectedContextButtons.OnDetails += HandleOnItemDetailsContextButton;
		itemSelectedContextButtons.OnEquip += HandleOnItemEquipContextButton;
		scrollContainer.scrollBar.OnPercentChanged += HandleScrollBarPercentChanged;
		itemDetailsDialog.useButton.OnPressed += HandleUseItemPressed;
		itemDetailsDialog.applyButton.OnPressed += HandleApplyCosmeticPressed;
		itemDragBG.Load();
		itemDragVfx.Load();
		ftueEquipSword.Load();
	}

	protected override void OnDestroy()
	{
		RemoveSlotCallbacks();
		base.OnDestroy();
	}

	private void RemoveSlotCallbacks()
	{
		draggingItemSlot = null;
		draggingItem = null;
		for (int i = 0; i < rows.Count; i++)
		{
			MultiSlotRow multiSlotRow = rows[i] as MultiSlotRow;
			for (int j = 0; j < multiSlotRow.slots.Count; j++)
			{
				ItemSlot obj = multiSlotRow.slots[j] as ItemSlot;
				obj.OnDown -= HandleOnSlotDown;
				obj.OnPressed -= HandleOnSlotPressed;
				obj.OnSecondaryPressed -= HandleOnSecondaryPressed;
			}
		}
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

	public int GetStateNumericRepresentation()
	{
		return (int)currentState * 100;
	}
}
