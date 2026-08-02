using UnityEngine;

public class RadialSelector : UIPanelBase
{
	public UltimateRadialMenu radialMenu;

	public InventoryController bottomInventory;

	public Color defaultColor;

	public Color hoverColor;

	public Color selectedColor;

	public int lastHoveredIndex;

	public int lastSelectedIndex;

	private bool selecting;

	public InventoryManagerUI inventoryManagerUI;

	private EastUpPlayerItemManager itemChooser;

	private void Start()
	{
		itemChooser = GetComponentInParent<EastUpPlayerItemManager>();
		radialMenu.OnRadialButtonEnter += SelectRadialMenu;
		radialMenu.OnRadialMenuStartingToDisable += SelectLast;
		radialMenu.OnRadialMenuEnabled += EnableMenu;
	}

	private void SelectRadialMenu(int index)
	{
		if (selecting)
		{
			return;
		}
		lastHoveredIndex = index;
		foreach (UltimateRadialMenu.UltimateRadialButton ultimateRadialButton in radialMenu.UltimateRadialButtonList)
		{
			if (ultimateRadialButton.buttonIndex == lastSelectedIndex)
			{
				ultimateRadialButton.radialImage.color = selectedColor;
			}
			else if (ultimateRadialButton.buttonIndex == index && ultimateRadialButton.buttonIndex != lastSelectedIndex)
			{
				ultimateRadialButton.radialImage.color = hoverColor;
			}
			else
			{
				ultimateRadialButton.radialImage.color = defaultColor;
			}
		}
	}

	private void EnableMenu()
	{
		ChangePanelActive();
		selecting = false;
	}

	public void SetIcons()
	{
		int num = 0;
		foreach (InventorySlot inventorySlot in bottomInventory.inventorySlots)
		{
			if (inventorySlot.InventoryItem.collectableItemData != null)
			{
				radialMenu.UltimateRadialButtonList[num].icon.enabled = true;
				radialMenu.UltimateRadialButtonList[num].icon.sprite = inventorySlot.InventoryItem.collectableItemData.itemImage;
			}
			else
			{
				radialMenu.UltimateRadialButtonList[num].icon.enabled = false;
			}
			num++;
		}
	}

	private void SelectLast()
	{
		ChangePanelActive();
		selecting = true;
		lastSelectedIndex = lastHoveredIndex;
		foreach (UltimateRadialMenu.UltimateRadialButton ultimateRadialButton in radialMenu.UltimateRadialButtonList)
		{
			if (ultimateRadialButton.buttonIndex == lastSelectedIndex)
			{
				ultimateRadialButton.radialImage.color = selectedColor;
			}
			else
			{
				ultimateRadialButton.radialImage.color = defaultColor;
			}
		}
		int index = ((lastSelectedIndex != 0) ? lastSelectedIndex : 0);
		Debug.Log(lastSelectedIndex);
		itemChooser.ChooseItemWithIndex(index);
	}

	public void ChangePanelActive()
	{
		if (!isPanelOpen)
		{
			SetIcons();
			Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(this);
			Cursor.lockState = CursorLockMode.Confined;
			ShowPanel();
			TrainGameManager.isMouseLocked = true;
			inventoryManagerUI.HidePanel();
			inventoryManagerUI.isOpenedExternal = false;
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
			Singleton<MainUIManager>.Instance.OnInGamePanelClosed.Invoke(this);
			HidePanel();
			TrainGameManager.isMouseLocked = false;
		}
	}
}
