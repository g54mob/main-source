using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ItemSlotsBarUI : ItemSlotsUIContainer
{
	[NonSerialized]
	public int activeHotBarRow;

	[NonSerialized]
	public int previousActiveHotBarRow;

	[NonSerialized]
	private bool _showHotbarArrowButtons = true;

	public Transform hotBarSwapButtonsContainer;

	public SpriteRenderer activeHotBarIndicator;

	public SpriteRenderer activeHotBarIndicatorBackground;

	public ButtonUIElement upArrow;

	public ButtonUIElement downArrow;

	public int hintHotbarOffsetIndex;

	private int hintHotbarStartIndexOffset;

	private List<int> cachedInventorySizes;

	public override int MAX_ROWS => 1;

	public override int MAX_COLUMNS => 10;

	private int startIndexOffset
	{
		get
		{
			if (!(Manager.main.player != null))
			{
				return 0;
			}
			return Manager.main.player.hotbarStartIndex;
		}
	}

	public override int startSlotIndex => base.startSlotIndex + (isHintHotbar ? hintHotbarStartIndexOffset : startIndexOffset);

	public bool isHintHotbar => hintHotbarOffsetIndex != 0;

	public override void Init()
	{
		base.Init();
		UpdateSpread();
		if (isHintHotbar)
		{
			UpdateActiveHintHotBar();
		}
		else
		{
			UpdateActiveHotBar();
		}
		UpdateHotbarArrowButtons();
	}

	private void Update()
	{
		bool flag = !Manager.ui.isAnyInventoryShowing && !Manager.ui.instrumentUI.isShowing && Manager.sceneHandler != null && Manager.sceneHandler.isInGame && !Manager.load.IsScreenBlack() && Manager.main.player != null && !Manager.main.player.guestMode;
		if (isHintHotbar && flag)
		{
			flag = Manager.main.player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.HOT_BAR_SWAP_MODIFIER);
		}
		if (flag != itemSlotsRoot.activeSelf)
		{
			itemSlotsRoot.SetActive(flag);
		}
		if (flag && NeedsUpdate())
		{
			if (isHintHotbar)
			{
				UpdateActiveHintHotBar();
			}
			else
			{
				UpdateActiveHotBar();
			}
		}
		UpdateHotbarArrowButtons();
	}

	private void UpdateHotbarArrowButtons()
	{
		if (_showHotbarArrowButtons != Manager.prefs.ShowHotbarArrows)
		{
			_showHotbarArrowButtons = Manager.prefs.ShowHotbarArrows;
			upArrow?.gameObject.SetActive(_showHotbarArrowButtons);
			downArrow?.gameObject.SetActive(_showHotbarArrowButtons);
		}
	}

	protected override void LateUpdate()
	{
		if (isShowing && hotBarSwapButtonsContainer != null)
		{
			hotBarSwapButtonsContainer.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		}
	}

	private void UpdateSpread()
	{
		float num = (0f - (float)(itemSlots.Count - 1) / 2f) * spread;
		for (int i = 0; i < itemSlots.Count; i++)
		{
			itemSlots[i].transform.localPosition = new Vector3(num + (float)i * spread, 0f, 0f);
		}
		UpdateBackgroundSize();
	}

	public InventorySlotUI GetEquipmentSlot(int index)
	{
		return itemSlots[index] as InventorySlotUI;
	}

	private bool CanSwapHotBar()
	{
		if (Manager.main.player == null)
		{
			return false;
		}
		if (Manager.main.player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.QUICK_SWAP_TORCH))
		{
			return false;
		}
		return true;
	}

	public void MoveToNextHotBar()
	{
		if (CanSwapHotBar())
		{
			activeHotBarRow = ((activeHotBarRow - 1 < 0) ? (GetMaxHotBars() - 1) : (activeHotBarRow - 1));
			UpdateActiveHotBar();
			AudioManager.Sfx(SfxTableID.inventorySFXHotbarEquip, Manager.main.player.transform.position);
		}
	}

	public void MoveToPreviousHotBar()
	{
		if (CanSwapHotBar())
		{
			activeHotBarRow = (activeHotBarRow + 1) % GetMaxHotBars();
			UpdateActiveHotBar();
			AudioManager.Sfx(SfxTableID.inventorySFXHotbarEquip, Manager.main.player.transform.position);
		}
	}

	private bool NeedsUpdate()
	{
		bool result = false;
		PlayerController playerController = Manager.main.player;
		if (playerController == null)
		{
			return false;
		}
		if (isHintHotbar && previousActiveHotBarRow != Manager.ui.itemSlotsBar.activeHotBarRow)
		{
			previousActiveHotBarRow = Manager.ui.itemSlotsBar.activeHotBarRow;
			return true;
		}
		if (cachedInventorySizes == null)
		{
			cachedInventorySizes = new List<int>();
			for (int i = 0; i < 5; i++)
			{
				cachedInventorySizes.Add(0);
			}
			result = true;
		}
		int size = playerController.playerInventoryHandler.size;
		if (cachedInventorySizes[0] != size)
		{
			cachedInventorySizes[0] = size;
			result = true;
		}
		for (int j = 0; j < 4; j++)
		{
			if (cachedInventorySizes[j + 1] != playerController.equipmentHandler.pouchInventorySlotsHandlers[j].size)
			{
				cachedInventorySizes[j + 1] = playerController.equipmentHandler.pouchInventorySlotsHandlers[j].size;
				result = true;
			}
		}
		return result;
	}

	private void UpdateActiveHotBar()
	{
		if (Manager.main.player == null || isHintHotbar)
		{
			return;
		}
		Manager.main.player.equippedSlotIndex -= Manager.main.player.hotbarStartIndex;
		Manager.main.player.hotbarStartIndex = GetStartIndexOffset(out var newActiveHotBarRow, out var maxRows);
		activeHotBarRow = newActiveHotBarRow;
		int maxColumns = GetMaxColumns(startIndexOffset);
		Manager.main.player.hotbarEndIndex = Manager.main.player.hotbarStartIndex + maxColumns;
		Manager.main.player.equippedSlotIndex = math.min(Manager.main.player.equippedSlotIndex + Manager.main.player.hotbarStartIndex, Manager.main.player.hotbarEndIndex - 1);
		Manager.main.player.EquipSlot(Manager.main.player.equippedSlotIndex);
		for (int i = 0; i < 10; i++)
		{
			if (i < maxColumns)
			{
				((InventorySlotUI)itemSlots[i]).Activate();
			}
			else
			{
				((InventorySlotUI)itemSlots[i]).Deactivate();
			}
		}
		Manager.main.player.UpdateAllEquipmentSlots();
		UpdateHotBarIndicator(maxRows);
	}

	private void UpdateActiveHintHotBar()
	{
		if (Manager.main.player == null || !isHintHotbar)
		{
			return;
		}
		activeHotBarRow = Manager.ui.itemSlotsBar.activeHotBarRow + hintHotbarOffsetIndex;
		int maxHotBars = GetMaxHotBars();
		if (activeHotBarRow < 0)
		{
			activeHotBarRow = maxHotBars - 1;
		}
		if (activeHotBarRow >= maxHotBars)
		{
			activeHotBarRow = 0;
		}
		hintHotbarStartIndexOffset = GetStartIndexOffset(out var newActiveHotBarRow, out var _);
		activeHotBarRow = newActiveHotBarRow;
		int maxColumns = GetMaxColumns(hintHotbarStartIndexOffset);
		for (int i = 0; i < 10; i++)
		{
			if (i < maxColumns)
			{
				((InventorySlotUI)itemSlots[i]).Activate();
			}
			else
			{
				((InventorySlotUI)itemSlots[i]).Deactivate();
			}
		}
	}

	private void UpdateHotBarIndicator(int maxRows)
	{
		activeHotBarIndicatorBackground.size = new Vector2(activeHotBarIndicatorBackground.size.x, (float)(maxRows * 2) * 0.0625f);
		activeHotBarIndicator.transform.localPosition = new Vector3(0f, 1f / 32f - (float)(activeHotBarRow * 2) * 0.0625f + (float)(maxRows - 1) * 0.0625f, 0f);
	}

	private int GetStartIndexOffset(out int newActiveHotBarRow, out int maxRows)
	{
		maxRows = 0;
		newActiveHotBarRow = 0;
		PlayerController playerController = Manager.main.player;
		if (playerController == null)
		{
			return 0;
		}
		List<int> list = new List<int>();
		int size = playerController.playerInventoryHandler.size;
		for (int i = 0; i < size; i += 10)
		{
			list.Add(i);
		}
		for (int j = 0; j < 4; j++)
		{
			if (playerController.equipmentHandler.pouchInventorySlotsHandlers[j].size > 0)
			{
				list.Add(playerController.equipmentHandler.pouchInventorySlotsHandlers[j].startPosInBuffer);
			}
		}
		maxRows = list.Count;
		newActiveHotBarRow = math.clamp(activeHotBarRow, 0, maxRows - 1);
		return list[newActiveHotBarRow];
	}

	private int GetMaxHotBars()
	{
		PlayerController playerController = Manager.main.player;
		if (playerController == null)
		{
			return 0;
		}
		int num = 0;
		int size = playerController.playerInventoryHandler.size;
		for (int i = 0; i < size; i += 10)
		{
			num++;
		}
		for (int j = 0; j < 4; j++)
		{
			if (playerController.equipmentHandler.pouchInventorySlotsHandlers[j].size > 0)
			{
				num++;
			}
		}
		return num;
	}

	private int GetMaxColumns(int startIndex)
	{
		PlayerController playerController = Manager.main.player;
		if (playerController == null)
		{
			return 0;
		}
		int size = playerController.playerInventoryHandler.size;
		if (startIndex < size)
		{
			int num = size % 10;
			if (startIndex == size - num)
			{
				return num;
			}
			return 10;
		}
		for (int i = 0; i < 4; i++)
		{
			if (startIndex == playerController.equipmentHandler.pouchInventorySlotsHandlers[i].startPosInBuffer)
			{
				return playerController.equipmentHandler.pouchInventorySlotsHandlers[i].size;
			}
		}
		return 0;
	}
}
