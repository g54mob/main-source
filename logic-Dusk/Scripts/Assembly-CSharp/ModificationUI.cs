using UnityEngine;
using UnityEngine.UI;

public class ModificationUI : MonoBehaviour
{
	private enum ViewStateEnum
	{
		Unknown = 0,
		CategoryList = 1,
		Inventory = 2,
		ModificationPanel = 3,
		QueuePanel = 4
	}

	public static ModificationUI Instance;

	public UITooltips Tooltips;

	public UICategoryList CategoryList;

	public UIDroneList DroneList;

	public UIShipList ShipList;

	public UIShipUpgradeList ShipUpgradeList;

	public UIDroneUpgradeList DroneUpgradeList;

	public UICraftingList CraftingList;

	public UIModContainer ModificationContainer;

	public UIModContainer QueueContainer;

	public UIScrapLabel RationsLabel;

	public PanelCommandHints commandHints;

	public Image borderSectionA;

	public Image borderSectionB;

	public Color deSelectedBorderColor = Color.white;

	public Color selectedBorderColor = Color.blue;

	public Color selectedItemColor = Color.white;

	public Color highlightedItemColor = Color.white;

	public Color disabeledItemTextColor = Color.white;

	public Color highlightedDisabledItemColor = Color.white;

	public Color enabledItemTextColor = Color.white;

	public Color enabledItemIconColor = Color.white;

	public Color errorBorderColor = Color.red;

	public Color errorTextColor = Color.red;

	public Color activeTitleTextColor = Color.blue;

	public Color inactiveTitleTextColor = Color.blue;

	public Image seperationLineBetweenDroneAndShipUpgrades;

	public Image seperationLineBetweenUpgradeAndCrafting;

	private IUIList selectedList;

	private IUIList visibleList;

	private IUIItem selectedCategoryItem;

	private IUIItem selectedItem;

	private ViewStateEnum currentViewState = ViewStateEnum.CategoryList;

	public bool IsShowing { get; private set; }

	public IUIItem selectedInventoryItem { get; set; }

	private void Awake()
	{
		Instance = this;
		selectedList = DroneList;
	}

	private void Start()
	{
		Refresh();
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		borderSectionA = null;
		borderSectionB = null;
		seperationLineBetweenDroneAndShipUpgrades = null;
		seperationLineBetweenUpgradeAndCrafting = null;
	}

	public void Show()
	{
		if (selectedList != null)
		{
			selectedList.LoseFocus();
		}
		if (selectedCategoryItem != null)
		{
			selectedCategoryItem.ClearSelection();
			selectedCategoryItem = null;
		}
		ModificationContainer.Hide();
		QueueContainer.Show();
		UITooltips.MakeActive(Tooltips);
		base.gameObject.SetActive(true);
		Refresh();
		RefreshScrap();
		ResetToInitialState(false);
		commandHints.PageCommand.enabled = false;
		if (((IUIMultiPageList)ShipUpgradeList).NumberOfPages() > 1)
		{
			commandHints.PageCommand.enabled = true;
		}
		IsShowing = true;
	}

	private void ResetToInitialState(bool preserveCategory)
	{
		SetView(ViewStateEnum.CategoryList);
		selectedList = CategoryList;
		if (!preserveCategory)
		{
			selectedList.MoveToTop();
			selectedCategoryItem = selectedList.SelectHighlightedItem();
		}
		else
		{
			selectedList.MoveToTopOrSelected();
		}
		selectedCategoryItem.Highlight();
		if (selectedItem != null)
		{
			selectedItem.ClearSelection();
			selectedItem = null;
		}
		if (!preserveCategory)
		{
			visibleList = DroneList;
		}
		if (!preserveCategory)
		{
			DroneList.gameObject.SetActive(true);
			ShipList.gameObject.SetActive(false);
			ShipUpgradeList.gameObject.SetActive(false);
			DroneUpgradeList.gameObject.SetActive(false);
			CraftingList.gameObject.SetActive(false);
		}
		visibleList.MoveToTop();
		if (selectedItem != null)
		{
			selectedItem.ClearSelection();
		}
		if (visibleList.ItemCount > 0)
		{
			selectedItem = visibleList.SelectHighlightedItem();
			selectedItem.ClearHighlight();
		}
		else
		{
			selectedItem = null;
		}
		if (selectedItem != null)
		{
			ModificationContainer.Show();
			ModificationContainer.SetItem(selectedItem, false);
		}
		else
		{
			ModificationContainer.Hide();
		}
	}

	public void Hide()
	{
		base.gameObject.SetActive(false);
		IsShowing = false;
		SystemOverlayUI.Instance.IsVisible = true;
	}

	public void Refresh()
	{
		DroneList.Refresh();
		ShipList.Refresh();
		ShipUpgradeList.Refresh();
		DroneUpgradeList.Refresh();
		CraftingList.Refresh();
		CategoryList.Refresh();
	}

	public void RefreshScrap()
	{
		int num = 0;
		if (QueueContainer.modList != null)
		{
			num = QueueContainer.modList.GetTotalCost();
		}
		string text = num.ToString();
		if (num > 0)
		{
			text = "+" + text;
		}
		RationsLabel.label.text = string.Format("{0} ({1})", GlobalSettings.GameState.ThePlayer.Inventory.Scrap, text);
		RationsLabel.maxScrapLabel.text = string.Format("(max {0})", GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax);
		if (ModificationContainer.modList != null)
		{
			ModificationContainer.modList.RefreshListOnScrap(num);
		}
	}

	public void Update()
	{
		if (selectedList == null || DialogUI.Instance.IsShowing)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (QueueContainer.modList.ItemCount > 0)
			{
				DialogUI.Instance.ShowDialog("Queue not Empty", "There are items in the queue that haven't yet been executed.  Closing this window will clear the queue.\r\n\r\nReally close it?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string input)
				{
					if (result == ModalWindowResult.Yes)
					{
						Close();
					}
				}, 1);
			}
			else
			{
				Close();
			}
			return;
		}
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			switch (currentViewState)
			{
			case ViewStateEnum.CategoryList:
				if (selectedCategoryItem != null)
				{
					selectedCategoryItem.ClearSelection();
				}
				selectedCategoryItem = CategoryList.SelectHighlightedItem();
				if (selectedCategoryItem != null)
				{
					DroneList.gameObject.SetActive(false);
					ShipList.gameObject.SetActive(false);
					ShipUpgradeList.gameObject.SetActive(false);
					DroneUpgradeList.gameObject.SetActive(false);
					CraftingList.gameObject.SetActive(false);
					switch (CategoryList.CurrentHighlightedIndex)
					{
					case 0:
						selectedList = DroneList;
						break;
					case 1:
						selectedList = DroneUpgradeList;
						break;
					case 2:
						selectedList = ShipList;
						break;
					case 3:
						selectedList = ShipUpgradeList;
						break;
					case 4:
						selectedList = CraftingList;
						break;
					}
					selectedList.UnderlyingGameObject.SetActive(true);
					selectedList.MoveToTop();
					visibleList = selectedList;
					if (selectedItem != null)
					{
						selectedItem.ClearSelection();
					}
					if (selectedList.ItemCount > 0)
					{
						SetView(ViewStateEnum.Inventory);
						selectedItem = selectedList.SelectHighlightedItem();
						selectedItem.Highlight();
					}
					else
					{
						selectedItem = null;
					}
					if (selectedItem != null)
					{
						ModificationContainer.Show();
						ModificationContainer.SetItem(selectedItem, false);
						GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
					}
					else
					{
						ModificationContainer.Hide();
						selectedList = CategoryList;
						CommonAudioHelper.Instance.PlayErrorSound();
					}
				}
				break;
			case ViewStateEnum.Inventory:
				if (selectedItem != null)
				{
					ModificationContainer.Hide();
					selectedItem.ClearSelection();
				}
				selectedItem = selectedList.SelectHighlightedItem();
				if (selectedItem != null)
				{
					ModificationContainer.Show();
					ModificationContainer.SetItem(selectedItem, false);
					SetView(ViewStateEnum.ModificationPanel);
					selectedList.LoseFocus();
					selectedList = ModificationContainer.modList;
					selectedList.MoveToTopOrSelected();
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
				}
				else
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
				break;
			case ViewStateEnum.ModificationPanel:
				if (ModificationContainer.modList.ItemCount > 0)
				{
					IUIItem highlightedItem = selectedList.GetHighlightedItem();
					if (highlightedItem != null && highlightedItem.IsActive)
					{
						QueueContainer.SetItem(highlightedItem, false);
						GameAudio.Play2DSFX(GameAudio.SoundEnum.UIEquip);
					}
					else
					{
						CommonAudioHelper.Instance.PlayErrorSound();
					}
				}
				else
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
				break;
			case ViewStateEnum.QueuePanel:
				if (selectedList.DeleteHighlightedItem())
				{
					if (QueueContainer.modList.ItemCount == 0)
					{
						commandHints.SetEnterInactive();
					}
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UIUnEquip);
				}
				break;
			}
			Input.ResetInputAxes();
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			if (QueueContainer.modList != null)
			{
				if (QueueContainer.modList.Execute())
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UIDialogShow);
					Refresh();
					ModificationContainer.modList.Clear(false);
					ModificationContainer.SetInactive();
					ModificationContainer.HideHeader();
					ResetToInitialState(true);
				}
				else
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
			}
			Input.ResetInputAxes();
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			if (QueueContainer.modList != null && QueueContainer.modList.ItemCount > 0)
			{
				QueueContainer.modList.Clear(true);
				commandHints.SetEnterInactive();
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UIUnEquip);
			}
			else
			{
				CommonAudioHelper.Instance.PlayErrorSound();
			}
			Input.ResetInputAxes();
		}
		bool flag = false;
		if (Input.GetButtonDown("Down"))
		{
			if (selectedList.MoveDown())
			{
				if (selectedList is IUIMultiPageList)
				{
					if (((IUIMultiPageList)selectedList).CurrentPageIndex < ((IUIMultiPageList)selectedList).NumberOfPages() - 1)
					{
						((IUIMultiPageList)selectedList).PageForward();
					}
					else
					{
						((IUIMultiPageList)selectedList).MoveToFirstPage();
					}
				}
				selectedList.MoveToTop();
			}
			flag = true;
			Input.ResetInputAxes();
		}
		else if (Input.GetButtonDown("Up"))
		{
			if (selectedList.MoveUp())
			{
				if (selectedList is IUIMultiPageList)
				{
					if (((IUIMultiPageList)selectedList).CurrentPageIndex > 0)
					{
						((IUIMultiPageList)selectedList).PageBack();
					}
					else
					{
						((IUIMultiPageList)selectedList).MoveToLastPage();
					}
				}
				selectedList.MoveToBottom();
			}
			flag = true;
			Input.ResetInputAxes();
		}
		if (flag)
		{
			switch (currentViewState)
			{
			case ViewStateEnum.CategoryList:
			case ViewStateEnum.ModificationPanel:
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
				break;
			case ViewStateEnum.Inventory:
			case ViewStateEnum.QueuePanel:
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
				break;
			}
			if (currentViewState == ViewStateEnum.CategoryList)
			{
				if (selectedCategoryItem != null)
				{
					selectedCategoryItem.ClearSelection();
				}
				selectedCategoryItem = CategoryList.SelectHighlightedItem();
				selectedCategoryItem.Highlight();
				if (selectedCategoryItem != null)
				{
					DroneList.gameObject.SetActive(false);
					ShipList.gameObject.SetActive(false);
					ShipUpgradeList.gameObject.SetActive(false);
					DroneUpgradeList.gameObject.SetActive(false);
					CraftingList.gameObject.SetActive(false);
					switch (CategoryList.CurrentHighlightedIndex)
					{
					case 0:
						visibleList = DroneList;
						break;
					case 1:
						visibleList = DroneUpgradeList;
						break;
					case 2:
						visibleList = ShipList;
						break;
					case 3:
						visibleList = ShipUpgradeList;
						break;
					case 4:
						visibleList = CraftingList;
						break;
					}
					visibleList.UnderlyingGameObject.SetActive(true);
					visibleList.MoveToTop();
					if (selectedItem != null)
					{
						selectedItem.ClearSelection();
					}
					if (visibleList.ItemCount > 0)
					{
						selectedItem = visibleList.SelectHighlightedItem();
						selectedItem.ClearHighlight();
					}
					else
					{
						selectedItem = null;
					}
					if (selectedItem != null)
					{
						ModificationContainer.Show();
						ModificationContainer.SetItem(selectedItem, false);
					}
					else
					{
						ModificationContainer.Hide();
						selectedList = CategoryList;
					}
				}
			}
			else if (currentViewState == ViewStateEnum.Inventory)
			{
				if (selectedItem != null)
				{
					selectedItem.ClearSelection();
				}
				selectedItem = selectedList.SelectHighlightedItem();
				if (selectedItem != null)
				{
					selectedItem.Highlight();
					ModificationContainer.Show();
					ModificationContainer.SetItem(selectedItem, true);
				}
			}
		}
		switch (currentViewState)
		{
		case ViewStateEnum.CategoryList:
			if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.PageUp))
			{
				if (selectedCategoryItem != null)
				{
					selectedCategoryItem.ClearSelection();
				}
				if (Input.GetKeyDown(KeyCode.PageDown))
				{
					selectedList.MoveToBottom();
				}
				else
				{
					selectedList.MoveToTop();
				}
				selectedCategoryItem = CategoryList.SelectHighlightedItem();
				selectedCategoryItem.Highlight();
				if (selectedCategoryItem != null)
				{
					DroneList.gameObject.SetActive(false);
					ShipList.gameObject.SetActive(false);
					ShipUpgradeList.gameObject.SetActive(false);
					DroneUpgradeList.gameObject.SetActive(false);
					CraftingList.gameObject.SetActive(false);
					switch (CategoryList.CurrentHighlightedIndex)
					{
					case 0:
						visibleList = DroneList;
						break;
					case 1:
						visibleList = DroneUpgradeList;
						break;
					case 2:
						visibleList = ShipList;
						break;
					case 3:
						visibleList = ShipUpgradeList;
						break;
					case 4:
						visibleList = CraftingList;
						break;
					}
					visibleList.UnderlyingGameObject.SetActive(true);
					visibleList.MoveToTop();
					if (selectedItem != null)
					{
						selectedItem.ClearSelection();
					}
					if (visibleList.ItemCount > 0)
					{
						selectedItem = visibleList.SelectHighlightedItem();
						selectedItem.ClearHighlight();
					}
					else
					{
						selectedItem = null;
					}
					if (selectedItem != null)
					{
						ModificationContainer.Show();
						ModificationContainer.SetItem(selectedItem, false);
					}
					else
					{
						ModificationContainer.Hide();
						selectedList = CategoryList;
					}
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
					Input.ResetInputAxes();
				}
			}
			else
			{
				if (!Input.GetButtonDown("Right"))
				{
					break;
				}
				SetView(ViewStateEnum.Inventory);
				selectedList.LoseFocus();
				selectedList = visibleList;
				selectedList.MoveToTopOrSelected();
				if (selectedList.ItemCount > 0)
				{
					SetView(ViewStateEnum.Inventory);
					if (selectedItem != null)
					{
						selectedItem.ClearSelection();
					}
					selectedItem = selectedList.SelectHighlightedItem();
					selectedItem.Highlight();
				}
				else
				{
					selectedItem = null;
				}
				if (selectedItem != null)
				{
					ModificationContainer.Show();
					ModificationContainer.SetItem(selectedItem, false);
				}
				else
				{
					ModificationContainer.Hide();
				}
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
				Input.ResetInputAxes();
			}
			break;
		case ViewStateEnum.Inventory:
			if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.PageUp))
			{
				bool flag2 = false;
				bool flag3 = false;
				selectedList.LoseFocus();
				if (selectedList is IUIMultiPageList)
				{
					if (Input.GetKeyDown(KeyCode.PageDown))
					{
						flag2 = ((IUIMultiPageList)selectedList).PageForward();
					}
					else
					{
						flag3 = ((IUIMultiPageList)selectedList).PageBack();
					}
				}
				if (selectedItem != null)
				{
					selectedItem.ClearSelection();
				}
				if (flag2)
				{
					selectedList.MoveToTop();
				}
				else if (flag3)
				{
					selectedList.MoveToBottom();
				}
				else
				{
					if (Input.GetKeyDown(KeyCode.PageDown))
					{
						selectedList.MoveToBottom();
					}
					else
					{
						selectedList.MoveToTop();
					}
					selectedList.GotFocus();
				}
				selectedItem = selectedList.SelectHighlightedItem();
				if (selectedItem != null)
				{
					selectedItem.Select();
					selectedItem.Highlight();
					ModificationContainer.Show();
					ModificationContainer.SetItem(selectedItem, false);
				}
				switch (currentViewState)
				{
				case ViewStateEnum.CategoryList:
				case ViewStateEnum.ModificationPanel:
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
					break;
				case ViewStateEnum.Inventory:
				case ViewStateEnum.QueuePanel:
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
					break;
				}
				Input.ResetInputAxes();
			}
			else if (Input.GetButtonDown("Left"))
			{
				SetView(ViewStateEnum.CategoryList);
				selectedInventoryItem = null;
				selectedList.LoseFocus();
				selectedList = CategoryList;
				selectedList.MoveToTopOrSelected();
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
				Input.ResetInputAxes();
			}
			else if (Input.GetButtonDown("Right"))
			{
				SetView(ViewStateEnum.ModificationPanel);
				selectedInventoryItem = selectedItem;
				selectedList.LoseFocus();
				selectedList = ModificationContainer.modList;
				selectedList.MoveToTopOrSelected();
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
				Input.ResetInputAxes();
			}
			break;
		case ViewStateEnum.ModificationPanel:
			if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.PageUp))
			{
				selectedList.LoseFocus();
				if (selectedItem != null)
				{
					selectedItem.ClearSelection();
				}
				if (Input.GetKeyDown(KeyCode.PageDown))
				{
					selectedList.MoveToBottom();
				}
				else
				{
					selectedList.MoveToTop();
				}
				selectedItem = selectedList.SelectHighlightedItem();
				if (selectedItem != null)
				{
					selectedItem.Highlight();
				}
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
				Input.ResetInputAxes();
			}
			else if (Input.GetButtonDown("Left"))
			{
				selectedList.LoseFocus();
				selectedList = null;
				SetView(ViewStateEnum.Inventory);
				selectedList = visibleList;
				if (selectedList == null)
				{
					if (ShipUpgradeList.CurrentPageIndex == 0)
					{
						selectedList = CraftingList;
					}
					else
					{
						selectedList = DroneUpgradeList;
					}
				}
				selectedList.MoveToTopOrSelected();
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
				Input.ResetInputAxes();
			}
			else if (Input.GetButtonDown("Right"))
			{
				SetView(ViewStateEnum.QueuePanel);
				selectedList.LoseFocus();
				selectedList = QueueContainer.modList;
				selectedList.MoveToTopOrSelected();
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
				Input.ResetInputAxes();
			}
			break;
		case ViewStateEnum.QueuePanel:
			if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.PageUp))
			{
				selectedList.LoseFocus();
				if (selectedItem != null)
				{
					selectedItem.ClearSelection();
				}
				if (Input.GetKeyDown(KeyCode.PageDown))
				{
					selectedList.MoveToBottom();
				}
				else
				{
					selectedList.MoveToTop();
				}
				selectedItem = selectedList.SelectHighlightedItem();
				if (selectedItem != null)
				{
					selectedItem.Highlight();
				}
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
				Input.ResetInputAxes();
			}
			else if (Input.GetButtonDown("Left"))
			{
				SetView(ViewStateEnum.ModificationPanel);
				selectedList.LoseFocus();
				selectedList = ModificationContainer.modList;
				selectedList.MoveToTopOrSelected();
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
				Input.ResetInputAxes();
			}
			break;
		}
	}

	private void Close()
	{
		selectedList.LoseFocus();
		Hide();
		Input.ResetInputAxes();
		GalaxyMapManager.Instance.CloseModificationsButtonPressed();
		GameAudio.Play2DSFX(GameAudio.SoundEnum.UIExitMenu);
	}

	private void SetView(ViewStateEnum newState)
	{
		currentViewState = newState;
		if (borderSectionA != null)
		{
			borderSectionA.color = deSelectedBorderColor;
		}
		if (borderSectionB != null)
		{
			borderSectionB.color = deSelectedBorderColor;
		}
		ModificationContainer.SetInactive();
		QueueContainer.SetInactive();
		UITooltips.CurrentTooltip.enabled = false;
		UITooltips.CurrentTooltip.label.text = string.Empty;
		switch (newState)
		{
		case ViewStateEnum.CategoryList:
			if (borderSectionA != null)
			{
				borderSectionA.color = selectedBorderColor;
			}
			break;
		case ViewStateEnum.Inventory:
			if (borderSectionB != null)
			{
				borderSectionB.color = selectedBorderColor;
			}
			commandHints.SetEnterActive("[ENTER] = SHOW AVAILABLE MODS");
			commandHints.PageCommand.enabled = false;
			if (((IUIMultiPageList)DroneUpgradeList).NumberOfPages() > 1)
			{
				commandHints.PageCommand.enabled = true;
			}
			break;
		case ViewStateEnum.ModificationPanel:
			ModificationContainer.SetActive();
			if (ModificationContainer.modList.ItemCount > 0)
			{
				commandHints.SetEnterActive("[ENTER] = QUEUE MOD");
			}
			else
			{
				commandHints.SetEnterInactive();
			}
			commandHints.PageCommand.enabled = false;
			break;
		case ViewStateEnum.QueuePanel:
			QueueContainer.SetActive();
			if (QueueContainer.modList.ItemCount > 0)
			{
				commandHints.SetEnterActive("[ENTER] = REMOVE MOD");
			}
			else
			{
				commandHints.SetEnterInactive();
			}
			commandHints.PageCommand.enabled = false;
			break;
		}
	}
}
