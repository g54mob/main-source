using UnityEngine;
using UnityEngine.UI;

public class TradeUI : MonoBehaviour
{
	private enum ViewStateEnum
	{
		Unknown = 0,
		CategoryList = 1,
		InventoryPlayer = 2,
		InventoryTrader = 3
	}

	public static TradeUI Instance;

	public UITooltips Tooltips;

	public UICategoryList CategoryList;

	public UIShipUpgradeSellableList ShipUpgradeListPlayer;

	public UITradeShipUpgradeList ShipUpgradeListTrader;

	public UIDroneUpgradeSellableList DroneUpgradeListPlayer;

	public UITradeDroneUpgradeList DroneUpgradeListTrader;

	public UIFuelList FuelListPlayer;

	public UITradeFuelList FuelListTrader;

	public UITextIconLabel RationsLabelPlayer;

	public UITextIconLabel RationsLabelTrader;

	public UITextLabel DerelictLabel;

	public PanelCommandHints commandHints;

	public Image borderSectionA;

	public Image borderSectionB;

	public Image borderSectionC;

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

	public Color blinkingScrapColor = Color.white;

	public Image seperationLineBetweenDroneAndShipUpgrades;

	public Image seperationLineBetweenUpgradeAndCrafting;

	private IUIList selectedList;

	private IUIList visibleListPlayer;

	private IUIList visibleListTrader;

	private IUIItem selectedCategoryItem;

	private IUIItem selectedItem;

	private ViewStateEnum currentViewState = ViewStateEnum.CategoryList;

	private int previousScrap = -1;

	private ColorBlinkManager scrapBlinkManager;

	public bool IsShowing { get; private set; }

	private void Awake()
	{
		Instance = this;
		selectedList = DroneUpgradeListPlayer;
	}

	private void Start()
	{
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		borderSectionA = null;
		borderSectionB = null;
		borderSectionC = null;
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
		UITooltips.MakeActive(Tooltips);
		base.gameObject.SetActive(true);
		previousScrap = -1;
		if (scrapBlinkManager != null)
		{
			RationsLabelPlayer.label.color = activeTitleTextColor;
			scrapBlinkManager = null;
		}
		Refresh();
		RefreshScrap();
		ResetToInitialState(false);
		commandHints.PageCommand.enabled = false;
		if (((IUIMultiPageList)ShipUpgradeListPlayer).NumberOfPages() > 1)
		{
			commandHints.PageCommand.enabled = true;
		}
		DerelictLabel.label.text = GalaxyMapManager.Instance.SelectedDungeon.Name;
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
			visibleListPlayer = DroneUpgradeListPlayer;
			visibleListTrader = DroneUpgradeListTrader;
		}
		if (!preserveCategory)
		{
			ShipUpgradeListPlayer.gameObject.SetActive(false);
			DroneUpgradeListPlayer.gameObject.SetActive(true);
			FuelListPlayer.gameObject.SetActive(false);
			ShipUpgradeListTrader.gameObject.SetActive(false);
			DroneUpgradeListTrader.gameObject.SetActive(true);
			FuelListTrader.gameObject.SetActive(false);
		}
		if (selectedItem != null)
		{
			selectedItem.ClearSelection();
		}
		selectedItem = null;
	}

	public void Hide()
	{
		base.gameObject.SetActive(false);
		IsShowing = false;
		SystemOverlayUI.Instance.IsVisible = true;
		GalaxyMapManager.Instance.CloseTradingPost();
	}

	public void Refresh()
	{
		ShipUpgradeListPlayer.Refresh();
		DroneUpgradeListPlayer.Refresh();
		FuelListPlayer.Refresh();
		ShipUpgradeListTrader.Refresh();
		DroneUpgradeListTrader.Refresh();
		FuelListTrader.Refresh();
		CategoryList.Refresh();
	}

	public void RefreshScrap()
	{
		Inventory inventory = ((TradingPostInfo)GalaxyMapManager.Instance.SelectedDungeon).Inventory;
		string arg = GlobalSettings.GameState.ThePlayer.Inventory.Scrap.ToString();
		string arg2 = inventory.Scrap.ToString();
		if (previousScrap != -1 && GlobalSettings.GameState.ThePlayer.Inventory.Scrap != previousScrap)
		{
			if (scrapBlinkManager == null)
			{
				scrapBlinkManager = new ColorBlinkManager();
			}
			scrapBlinkManager.Start(activeTitleTextColor, blinkingScrapColor, 0.2f, 5);
		}
		previousScrap = GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
		RationsLabelPlayer.label.text = string.Format("{0}/{1}", arg, GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax);
		RationsLabelTrader.label.text = string.Format("{0}", arg2);
		FuelListTrader.Refresh();
	}

	public void Update()
	{
		if (selectedList != null && !DialogUI.Instance.IsShowing)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				selectedList.LoseFocus();
				Hide();
				Input.ResetInputAxes();
				GalaxyMapManager.Instance.CloseModificationsButtonPressed();
				GalaxyMapManager.Instance.CloseTradingPostButtonPressed();
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
						ShipUpgradeListPlayer.gameObject.SetActive(false);
						DroneUpgradeListPlayer.gameObject.SetActive(false);
						FuelListPlayer.gameObject.SetActive(false);
						ShipUpgradeListTrader.gameObject.SetActive(false);
						DroneUpgradeListTrader.gameObject.SetActive(false);
						FuelListTrader.gameObject.SetActive(false);
						visibleListTrader = null;
						switch (CategoryList.CurrentHighlightedIndex)
						{
						case 0:
							selectedList = DroneUpgradeListPlayer;
							visibleListTrader = DroneUpgradeListTrader;
							break;
						case 1:
							selectedList = ShipUpgradeListPlayer;
							visibleListTrader = ShipUpgradeListTrader;
							break;
						case 2:
							selectedList = FuelListPlayer;
							visibleListTrader = FuelListTrader;
							break;
						}
						selectedList.UnderlyingGameObject.SetActive(true);
						selectedList.MoveToTop();
						visibleListPlayer = selectedList;
						if (visibleListTrader != null)
						{
							visibleListTrader.UnderlyingGameObject.SetActive(true);
						}
						if (selectedItem != null)
						{
							selectedItem.ClearSelection();
						}
						if (selectedList.ItemCount > 0)
						{
							SetView(ViewStateEnum.InventoryPlayer);
						}
						else if (visibleListTrader != null && visibleListTrader.ItemCount > 0)
						{
							visibleListTrader.MoveToTop();
							SetView(ViewStateEnum.InventoryTrader);
							selectedItem = visibleListTrader.SelectHighlightedItem();
							selectedItem.Highlight();
						}
						else
						{
							selectedItem = null;
						}
						if (selectedList.GetHighlightedItem() != null)
						{
							selectedList.GetHighlightedItem().Highlight();
						}
						GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
					}
					break;
				case ViewStateEnum.InventoryPlayer:
				{
					if (selectedItem != null)
					{
						selectedItem.ClearSelection();
					}
					IUIItem highlightedItem2 = selectedList.GetHighlightedItem();
					if (highlightedItem2 == null)
					{
						break;
					}
					int num2 = 0;
					bool flag2 = false;
					if (highlightedItem2.InventoryItem != null)
					{
						num2 = (int)highlightedItem2.InventoryItem.SellValue;
					}
					else if (selectedList is IUISellableList)
					{
						IUISellableList iUISellableList2 = (IUISellableList)selectedList;
						if (iUISellableList2 == visibleListPlayer)
						{
							if (!((IUISellableList)visibleListTrader).CanBuy(((UIModItem)highlightedItem2).Tag))
							{
								flag2 = true;
							}
						}
						else if (!((IUISellableList)visibleListPlayer).CanBuy(((UIModItem)highlightedItem2).Tag))
						{
							flag2 = true;
						}
					}
					if (!flag2 && GlobalSettings.GameState.ThePlayer.Inventory.Scrap + num2 > GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax)
					{
						flag2 = true;
					}
					Inventory inventory = ((TradingPostInfo)GalaxyMapManager.Instance.SelectedDungeon).Inventory;
					if (highlightedItem2.IsActive && !flag2 && num2 <= inventory.Scrap)
					{
						inventory.Scrap -= num2;
						visibleListTrader.AddBackendItem(highlightedItem2);
						if (selectedList.RemoveBackendSelectedItem())
						{
							if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap + num2 <= GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax)
							{
								GlobalSettings.GameState.ThePlayer.Inventory.Scrap += num2;
							}
							else
							{
								GlobalSettings.GameState.ThePlayer.Inventory.Scrap = GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax;
							}
							if (visibleListPlayer.ItemCount == 0)
							{
								selectedList = CategoryList;
								SetView(ViewStateEnum.CategoryList);
								selectedCategoryItem.Highlight();
							}
							visibleListTrader.Refresh();
							GameAudio.Play2DSFX(GameAudio.SoundEnum.UIUnEquip);
						}
						RefreshScrap();
					}
					else
					{
						CommonAudioHelper.Instance.PlayErrorSound();
					}
					break;
				}
				case ViewStateEnum.InventoryTrader:
				{
					if (selectedItem != null)
					{
						selectedItem.ClearSelection();
					}
					IUIItem highlightedItem = selectedList.GetHighlightedItem();
					if (highlightedItem == null)
					{
						break;
					}
					int num = 0;
					bool flag = false;
					if (highlightedItem.InventoryItem != null)
					{
						num = (int)highlightedItem.InventoryItem.SellValue;
					}
					else if (selectedList is IUISellableList)
					{
						IUISellableList iUISellableList = (IUISellableList)selectedList;
						if (iUISellableList == visibleListPlayer)
						{
							if (!((IUISellableList)visibleListTrader).CanBuy(((UIModItem)highlightedItem).Tag))
							{
								flag = true;
							}
						}
						else if (!((IUISellableList)visibleListPlayer).CanBuy(((UIModItem)highlightedItem).Tag))
						{
							flag = true;
						}
					}
					if (highlightedItem.IsActive && !flag && num <= GlobalSettings.GameState.ThePlayer.Inventory.Scrap)
					{
						GlobalSettings.GameState.ThePlayer.Inventory.Scrap -= num;
						visibleListPlayer.AddBackendItem(highlightedItem);
						if (selectedList.RemoveBackendSelectedItem())
						{
							((TradingPostInfo)GalaxyMapManager.Instance.SelectedDungeon).Inventory.Scrap += num;
							if (visibleListTrader.ItemCount == 0)
							{
								selectedList = CategoryList;
								SetView(ViewStateEnum.CategoryList);
								selectedCategoryItem.Highlight();
							}
							visibleListPlayer.Refresh();
						}
						RefreshScrap();
						GameAudio.Play2DSFX(GameAudio.SoundEnum.UIEquip);
					}
					else
					{
						CommonAudioHelper.Instance.PlayErrorSound();
					}
					break;
				}
				}
				Input.ResetInputAxes();
			}
			bool flag3 = false;
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
				flag3 = true;
				if (currentViewState == ViewStateEnum.CategoryList)
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
				}
				else
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
				}
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
				flag3 = true;
				if (currentViewState == ViewStateEnum.CategoryList)
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
				}
				else
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
				}
				Input.ResetInputAxes();
			}
			if (flag3)
			{
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
						ShipUpgradeListPlayer.gameObject.SetActive(false);
						DroneUpgradeListPlayer.gameObject.SetActive(false);
						FuelListPlayer.gameObject.SetActive(false);
						ShipUpgradeListTrader.gameObject.SetActive(false);
						DroneUpgradeListTrader.gameObject.SetActive(false);
						FuelListTrader.gameObject.SetActive(false);
						visibleListTrader = null;
						switch (CategoryList.CurrentHighlightedIndex)
						{
						case 0:
							visibleListPlayer = DroneUpgradeListPlayer;
							visibleListTrader = DroneUpgradeListTrader;
							break;
						case 1:
							visibleListPlayer = ShipUpgradeListPlayer;
							visibleListTrader = ShipUpgradeListTrader;
							break;
						case 2:
							visibleListPlayer = FuelListPlayer;
							visibleListTrader = FuelListTrader;
							break;
						}
						if (visibleListPlayer != null)
						{
							visibleListPlayer.UnderlyingGameObject.SetActive(true);
							visibleListPlayer.Refresh();
						}
						if (visibleListTrader != null)
						{
							visibleListTrader.UnderlyingGameObject.SetActive(true);
							visibleListTrader.Refresh();
						}
						if (selectedItem != null)
						{
							selectedItem.ClearSelection();
						}
						selectedItem = null;
						selectedList = CategoryList;
					}
				}
				else if (currentViewState == ViewStateEnum.InventoryPlayer && selectedItem != null)
				{
					selectedItem.ClearSelection();
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
					if (visibleListPlayer.ItemCount > 0 || visibleListTrader.ItemCount > 0)
					{
						if (visibleListPlayer.ItemCount > 0)
						{
							SetView(ViewStateEnum.InventoryPlayer);
						}
						else if (visibleListTrader.ItemCount > 0)
						{
							SetView(ViewStateEnum.InventoryTrader);
						}
						selectedList.LoseFocus();
						if (visibleListPlayer.ItemCount > 0)
						{
							selectedList = visibleListPlayer;
						}
						else
						{
							selectedList = visibleListTrader;
						}
						selectedList.MoveToTopOrSelected();
						if (selectedList.ItemCount > 0)
						{
							if (selectedItem != null)
							{
								selectedItem.ClearSelection();
							}
							GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
						}
						else
						{
							selectedItem = null;
						}
					}
					Input.ResetInputAxes();
				}
				break;
			case ViewStateEnum.InventoryPlayer:
				if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.PageUp))
				{
					bool flag6 = false;
					bool flag7 = false;
					selectedList.LoseFocus();
					if (selectedList is IUIMultiPageList)
					{
						if (Input.GetKeyDown(KeyCode.PageDown))
						{
							flag6 = ((IUIMultiPageList)selectedList).PageForward();
						}
						else
						{
							flag7 = ((IUIMultiPageList)selectedList).PageBack();
						}
					}
					if (selectedItem != null)
					{
						selectedItem.ClearSelection();
						selectedItem.ClearHighlight();
					}
					if (flag6)
					{
						selectedList.MoveToTop();
					}
					else if (flag7)
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
						if (!FuelListPlayer.enabled)
						{
							selectedList.GotFocus();
						}
					}
					Input.ResetInputAxes();
				}
				else if (Input.GetButtonDown("Left"))
				{
					SetView(ViewStateEnum.CategoryList);
					selectedList.LoseFocus();
					selectedList = CategoryList;
					selectedList.MoveToTopOrSelected();
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
					Input.ResetInputAxes();
				}
				else if (Input.GetButtonDown("Right"))
				{
					if (visibleListTrader.ItemCount > 0)
					{
						selectedList.LoseFocus();
						SetView(ViewStateEnum.InventoryTrader);
						selectedList = visibleListTrader;
						selectedList.MoveToTopOrSelected();
						GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
					}
					Input.ResetInputAxes();
				}
				break;
			case ViewStateEnum.InventoryTrader:
				if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.PageUp))
				{
					bool flag4 = false;
					bool flag5 = false;
					selectedList.LoseFocus();
					if (selectedList is IUIMultiPageList)
					{
						if (Input.GetKeyDown(KeyCode.PageDown))
						{
							flag4 = ((IUIMultiPageList)selectedList).PageForward();
						}
						else
						{
							flag5 = ((IUIMultiPageList)selectedList).PageBack();
						}
					}
					if (selectedItem != null)
					{
						selectedItem.ClearSelection();
					}
					if (flag4)
					{
						selectedList.MoveToTop();
					}
					else if (flag5)
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
						if (!FuelListTrader.enabled)
						{
							selectedList.GotFocus();
						}
					}
					Input.ResetInputAxes();
				}
				else if (Input.GetButtonDown("Left"))
				{
					selectedList.LoseFocus();
					if (visibleListPlayer.ItemCount > 0)
					{
						SetView(ViewStateEnum.InventoryPlayer);
						selectedList = visibleListPlayer;
						GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
					}
					else
					{
						SetView(ViewStateEnum.CategoryList);
						selectedList = CategoryList;
						GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
					}
					selectedList.MoveToTopOrSelected();
					Input.ResetInputAxes();
				}
				break;
			}
		}
		if (scrapBlinkManager != null)
		{
			Color color = scrapBlinkManager.Update(Time.deltaTime);
			if (scrapBlinkManager.IsActive)
			{
				RationsLabelPlayer.label.color = color;
				return;
			}
			RationsLabelPlayer.label.color = activeTitleTextColor;
			scrapBlinkManager = null;
		}
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
		if (borderSectionC != null)
		{
			borderSectionC.color = deSelectedBorderColor;
		}
		UITooltips.CurrentTooltip.enabled = false;
		UITooltips.CurrentTooltip.label.text = string.Empty;
		switch (newState)
		{
		case ViewStateEnum.CategoryList:
			if (borderSectionA != null)
			{
				borderSectionA.color = selectedBorderColor;
			}
			commandHints.SetEnterInactive();
			commandHints.PageCommand.enabled = false;
			break;
		case ViewStateEnum.InventoryPlayer:
			if (borderSectionB != null)
			{
				borderSectionB.color = selectedBorderColor;
			}
			commandHints.SetEnterActive("[ENTER] = SELL FOR SCRAP");
			commandHints.PageCommand.enabled = false;
			if (((IUIMultiPageList)DroneUpgradeListPlayer).NumberOfPages() > 1)
			{
				commandHints.PageCommand.enabled = true;
			}
			else
			{
				commandHints.PageCommand.enabled = false;
			}
			break;
		case ViewStateEnum.InventoryTrader:
			if (borderSectionC != null)
			{
				borderSectionC.color = selectedBorderColor;
			}
			commandHints.SetEnterActive("[ENTER] = BUY WITH SCRAP");
			commandHints.PageCommand.enabled = false;
			if (((IUIMultiPageList)DroneUpgradeListTrader).NumberOfPages() > 1)
			{
				commandHints.PageCommand.enabled = true;
			}
			else
			{
				commandHints.PageCommand.enabled = false;
			}
			break;
		}
	}
}
