using System;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
	[NonSerialized]
	public Canvas canvas;

	private GraphicRaycaster graphicRaycaster;

	public Image panelBackgroundImage;

	public Image scrollViewBackgroundImage;

	[NonSerialized]
	public string headerLocalizationKey;

	[NonSerialized]
	public Sprite headerSprite;

	public DraggableHeader header;

	public CanvasGroup canvasGroup;

	[NonSerialized]
	public bool isTownLayoutStale;

	public bool isItemAvailabilityStale;

	[NonSerialized]
	public bool isPriorityStale;

	[NonSerialized]
	public bool isProductionLimitStale;

	[NonSerialized]
	public bool isPauseStale;

	[NonSerialized]
	public bool isAutoAssignStale;

	[NonSerialized]
	public bool isAutoClaimStale;

	[NonSerialized]
	public bool isLocked;

	[NonSerialized]
	public bool isSimulationDataStale;

	[NonSerialized]
	public MenuPanelType panelType;

	public bool targetVisibilityState;

	public bool isPinned;

	[NonSerialized]
	public PanelCategory panelCategory;

	[NonSerialized]
	public bool alertStateSelf;

	public const float TopMargin = 100f;

	public const float BottomMargin = 4f;

	public const float SideMargin = 4f;

	public const float SidePanelWidth = 300f;

	public const float NavigationMenuHeight = 70f;

	[NonSerialized]
	public bool isLabelReloadQueued;

	[NonSerialized]
	public bool hasCreatedItems;

	[NonSerialized]
	public bool skipAlert;

	protected readonly StringBuilder panelStringBuilder = new StringBuilder(50);

	[NonSerialized]
	public Town displayedTown;

	protected static GameManager gm => GameManager.Instance;

	protected static MenuManager m => MenuManager.Instance;

	public bool isTownNavigationPanel => panelCategory == PanelCategory.CenteredTown;

	public bool isBackgroundPanel => panelCategory == PanelCategory.Background;

	public string layoutPrefKey
	{
		get
		{
			if (panelType == MenuPanelType.InventoryPopup || panelType == MenuPanelType.QuestsPopup)
			{
				return "Layout" + headerLocalizationKey + "Popup";
			}
			return "Layout" + headerLocalizationKey;
		}
	}

	public string visibilityPrefKey
	{
		get
		{
			if (panelType == MenuPanelType.InventoryPopup || panelType == MenuPanelType.QuestsPopup)
			{
				return "Visibility" + headerLocalizationKey + "Popup";
			}
			return "Visibility" + headerLocalizationKey;
		}
	}

	public bool isPinnable => null != canvasGroup;

	protected virtual void Awake()
	{
	}

	public virtual void Initialize()
	{
		isLabelReloadQueued = true;
		if (null != header)
		{
			header.Initialize(this);
		}
	}

	public void AddCanvas()
	{
		if (null == canvas)
		{
			canvas = base.gameObject.GetComponent<Canvas>();
			if (null == canvas)
			{
				canvas = base.gameObject.AddComponent<Canvas>();
			}
		}
		if (null == graphicRaycaster)
		{
			graphicRaycaster = base.gameObject.AddComponent<GraphicRaycaster>();
		}
	}

	protected virtual void Update()
	{
	}

	public void UpdateIfVisible()
	{
		if (targetVisibilityState)
		{
			UpdateDynamicDisplay();
		}
	}

	public virtual void FlagAllStaticDataStale()
	{
		isSimulationDataStale = true;
		isTownLayoutStale = true;
		isItemAvailabilityStale = true;
		isSimulationDataStale = true;
	}

	public void ForceRefreshTownLayout()
	{
		FlagAllStaticDataStale();
		if (IsVisible())
		{
			UpdateDynamicDisplay();
		}
	}

	protected virtual void UpdateSimulationDisplay()
	{
		isSimulationDataStale = false;
	}

	protected virtual void UpdateDynamicDisplay()
	{
		if (isSimulationDataStale)
		{
			UpdateSimulationDisplay();
		}
		if (isTownLayoutStale)
		{
			CreateLayoutForActiveTown();
			isItemAvailabilityStale = true;
			UpdateStaticDisplay();
		}
		if (isItemAvailabilityStale)
		{
			PerformUpdateItemAvailability();
		}
		if (isProductionLimitStale)
		{
			UpdateProductionLimitDisplay();
		}
		if (isPriorityStale)
		{
			UpdatePriorityDisplay();
		}
		if (isAutoAssignStale)
		{
			UpdateAutoAssignDisplay();
		}
		if (isAutoClaimStale)
		{
			UpdateAutoClaimDisplay();
		}
		if (isPauseStale)
		{
			UpdatePauseDisplay();
		}
	}

	public virtual void PerformUpdateItemAvailability()
	{
		UpdateItemAvailability();
	}

	protected virtual void UpdateItemAvailability()
	{
		isItemAvailabilityStale = false;
		if (this is ProductionListPanel productionListPanel)
		{
			if (this is ProductionListPanelCombined productionListPanelCombined)
			{
				if (productionListPanelCombined.categoryFilter == BuildingCategory.Trading)
				{
					productionListPanelCombined.SetTradingHeadersSuppressedFromSearch(nextState: false);
					productionListPanelCombined.SetCategoriesSuppressedFromSearch(nextState: false);
				}
				else if (productionListPanelCombined.categoryFilter == BuildingCategory.Markets)
				{
					productionListPanelCombined.SetTradingHeadersSuppressedFromSearch(nextState: true);
					productionListPanelCombined.SetCategoriesSuppressedFromSearch(nextState: false);
				}
				else if (productionListPanelCombined.categoryFilter != BuildingCategory.None)
				{
					productionListPanelCombined.SetTradingHeadersSuppressedFromSearch(nextState: true);
					productionListPanelCombined.SetCategoriesSuppressedFromSearch(nextState: true);
				}
				else if (MenuManager.isSearchApplied)
				{
					if (productionListPanelCombined.entityFilter.type == EntityType.BuildingCategory)
					{
						productionListPanelCombined.SetTradingHeadersSuppressedFromSearch(nextState: false);
						productionListPanelCombined.SetCategoriesSuppressedFromSearch(nextState: false);
					}
					else
					{
						productionListPanelCombined.SetTradingHeadersSuppressedFromSearch(nextState: true);
						productionListPanelCombined.SetCategoriesSuppressedFromSearch(nextState: true);
					}
				}
				else
				{
					productionListPanelCombined.SetTradingHeadersSuppressedFromSearch(nextState: false);
					productionListPanelCombined.SetCategoriesSuppressedFromSearch(nextState: false);
				}
			}
			productionListPanel.UpdateHeaderAvailability();
		}
		else if (this is BuildingsPanel buildingsPanel)
		{
			buildingsPanel.UpdateHeaderAvailability();
		}
		else if (this is InventoryPanel inventoryPanel)
		{
			inventoryPanel.UpdateHeaderAvailability();
		}
		else if (this is QuestsPanel questsPanel)
		{
			questsPanel.UpdateHeaderAvailability();
		}
	}

	public void TryShow()
	{
		if (!isLocked)
		{
			Show();
		}
	}

	public virtual void ResetPanel()
	{
		Hide();
		isLocked = true;
		if (panelCategory == PanelCategory.CenteredTown)
		{
			SetRectFillFrame();
		}
		else if (panelType == MenuPanelType.Perks)
		{
			RectTransform component = GetComponent<RectTransform>();
			component.pivot = new Vector2(0.5f, 0.5f);
			component.SetWidth(900f);
			component.SetHeight(700f);
		}
		else if (panelType == MenuPanelType.TownPerks)
		{
			RectTransform component2 = GetComponent<RectTransform>();
			component2.pivot = new Vector2(0.5f, 0.5f);
			component2.SetWidth(900f);
			component2.SetHeight(700f);
		}
		else if (panelType == MenuPanelType.UpgradesPopup)
		{
			RectTransform component3 = GetComponent<RectTransform>();
			component3.pivot = new Vector2(0.5f, 0.5f);
			component3.SetWidth(1200f);
			component3.SetHeight(600f);
		}
		else if (panelType == MenuPanelType.Upgrades)
		{
			RectTransform component4 = GetComponent<RectTransform>();
			component4.pivot = new Vector2(0.5f, 0.5f);
			component4.SetWidth(1200f);
			component4.SetHeight(800f);
		}
		else if (panelType == MenuPanelType.World)
		{
			RectTransform component5 = GetComponent<RectTransform>();
			component5.pivot = new Vector2(0.5f, 0.5f);
			component5.SetWidth(1440f);
			component5.SetHeight(800f);
		}
		else if (panelType == MenuPanelType.Controls)
		{
			RectTransform component6 = GetComponent<RectTransform>();
			component6.pivot = new Vector2(0.5f, 0.5f);
			component6.SetWidth(700f);
			component6.SetHeight(700f);
		}
		else if (panelType == MenuPanelType.QuestsPopup)
		{
			if (MenuManager.CategoryForMenu(panelType) == PanelCategory.FloatingModal)
			{
				header.SetFixed(nextState: false);
				RectTransform component7 = GetComponent<RectTransform>();
				component7.anchorMin = new Vector2(0.5f, 0.5f);
				component7.anchorMax = new Vector2(0.5f, 0.5f);
				component7.pivot = new Vector2(0.5f, 0.5f);
				component7.SetWidth(700f);
				component7.SetHeight(800f);
			}
		}
		else if (panelType == MenuPanelType.Log)
		{
			if (MenuManager.CategoryForMenu(panelType) == PanelCategory.FloatingModal)
			{
				header.SetFixed(nextState: false);
				RectTransform component8 = GetComponent<RectTransform>();
				component8.anchorMin = new Vector2(0.5f, 0.5f);
				component8.anchorMax = new Vector2(0.5f, 0.5f);
				component8.pivot = new Vector2(0.5f, 0.5f);
				component8.SetWidth(700f);
				component8.SetHeight(800f);
			}
		}
		else if (panelType == MenuPanelType.Research)
		{
			RectTransform component9 = GetComponent<RectTransform>();
			component9.pivot = new Vector2(0.5f, 0.5f);
			component9.SetWidth(1200f);
			component9.SetHeight(800f);
		}
		else if (panelType == MenuPanelType.Buildings)
		{
			RectTransform component10 = GetComponent<RectTransform>();
			component10.pivot = new Vector2(0.5f, 0.5f);
			component10.SetWidth(1200f);
			component10.SetHeight(800f);
		}
		else if (panelType != MenuPanelType.ConstructionDetails && panelType != MenuPanelType.TimeTokens && panelCategory == PanelCategory.FloatingModal)
		{
			SetRectCenter();
		}
	}

	public virtual bool IsFixedPosition()
	{
		return false;
	}

	public void SetLockedState(bool nextState)
	{
		_ = isLocked;
		isLocked = nextState;
		if (isLocked)
		{
			Hide();
			if (gm.gameState == GameState.InGame)
			{
				MenuManager.Instance.navigationPanel.SetButtonVisibilityForPanel(panelType, IsNavigationButtonVisible());
			}
		}
		else if (gm.gameState == GameState.InGame)
		{
			MenuManager.Instance.navigationPanel.SetButtonVisibilityForPanel(panelType, IsNavigationButtonVisible());
		}
	}

	protected void SetRectCenter()
	{
		RectTransform component = GetComponent<RectTransform>();
		component.pivot = new Vector2(0.5f, 0.5f);
		component.SetWidth(1000f);
		component.SetHeight(600f);
	}

	protected void SetRectFillFrame()
	{
		RectTransform component = GetComponent<RectTransform>();
		component.pivot = new Vector2(0.5f, 0.5f);
		component.anchorMin = new Vector2(0f, 0f);
		component.anchorMax = new Vector2(1f, 1f);
		component.SetTop(0f);
		component.SetBottom(0f);
		component.SetLeft(0f);
		component.SetRight(0f);
	}

	public virtual void ReloadLabels()
	{
		isLabelReloadQueued = false;
		if (null != header)
		{
			header.ReloadLabels();
		}
	}

	public void ManuallyOpen()
	{
		PlayerPrefs.SetInt(visibilityPrefKey, 1);
		Show();
		TrySendToFront();
	}

	public virtual void ManuallyClose()
	{
		Unpin();
		PlayerPrefs.DeleteKey(visibilityPrefKey);
		Hide();
	}

	public void TrySendToFront()
	{
		if (panelCategory == PanelCategory.DismissableModal || panelCategory == PanelCategory.FixedModal || panelCategory == PanelCategory.FloatingModal)
		{
			base.transform.SetAsLastSibling();
		}
	}

	public void LoadLayout(string layoutString)
	{
		RectTransform component = GetComponent<RectTransform>();
		string[] array = layoutString.Split(',');
		if (array.Length >= 8)
		{
			float.TryParse(array[6], NumberStyles.Float, CultureInfo.InvariantCulture, out var result);
			float.TryParse(array[7], NumberStyles.Float, CultureInfo.InvariantCulture, out var result2);
			component.anchorMin = new Vector2(result, result2);
			component.anchorMax = new Vector2(result, result2);
		}
		if (array.Length >= 4)
		{
			float.TryParse(array[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var result3);
			float.TryParse(array[3], NumberStyles.Float, CultureInfo.InvariantCulture, out var result4);
			component.sizeDelta = new Vector2(result3, result4);
		}
		if (array.Length >= 6)
		{
			float.TryParse(array[4], NumberStyles.Float, CultureInfo.InvariantCulture, out var result5);
			float.TryParse(array[5], NumberStyles.Float, CultureInfo.InvariantCulture, out var result6);
			component.anchoredPosition = new Vector2(result5, result6);
			float num = component.sizeDelta.y * 0.5f;
			float num2 = (float)Screen.height - 100f;
			if (component.position.y + num > num2)
			{
				component.position = new Vector3(component.position.x, num2 - num, 0f);
			}
		}
	}

	public string GetLayoutString()
	{
		RectTransform component = GetComponent<RectTransform>();
		Vector3 position = component.position;
		Vector2 sizeDelta = component.sizeDelta;
		Vector2 anchoredPosition = component.anchoredPosition;
		Vector2 anchorMin = component.anchorMin;
		return $"{position.x},{position.y},{sizeDelta.x},{sizeDelta.y},{anchoredPosition.x},{anchoredPosition.y},{anchorMin.x},{anchorMin.y}";
	}

	public void SaveLayout()
	{
		if (headerLocalizationKey != null)
		{
			PlayerPrefs.SetString(layoutPrefKey, GetLayoutString());
		}
	}

	public void ToggleDisplayForTown(Town t)
	{
		if (IsVisible())
		{
			if (t == displayedTown)
			{
				Hide();
			}
			else
			{
				ShowForTown(t);
			}
		}
		else
		{
			ShowForTown(t);
		}
	}

	public void ShowForTown(Town t)
	{
		SetDisplayedTown(t);
		Show();
	}

	public void ToggleDisplay()
	{
		if (IsVisible())
		{
			Hide();
		}
		else
		{
			Show();
		}
	}

	public virtual void Show()
	{
		if (gm.gameState == GameState.InGame)
		{
			isSimulationDataStale = true;
			UpdateDynamicDisplay();
		}
		MenuManager.Instance.ShowMenu(this);
		if (isLabelReloadQueued)
		{
			ReloadLabels();
		}
		ApplyStateAnimations();
	}

	public virtual void Hide()
	{
		MenuManager.Instance.HideMenu(this);
	}

	public virtual void CreateItems()
	{
		hasCreatedItems = true;
	}

	public bool IsVisible()
	{
		if (ShouldBecomeInactiveOnHide())
		{
			return base.gameObject.activeSelf;
		}
		if (null != canvas)
		{
			return canvas.enabled;
		}
		return base.gameObject.activeSelf;
	}

	public virtual void UpdateStaticDisplay()
	{
		PerformUpdateItemAvailability();
		ReloadLabels();
	}

	public virtual void UpdatePauseDisplay()
	{
		isPauseStale = false;
	}

	public virtual void UpdateProductionLimitDisplay()
	{
		isProductionLimitStale = false;
	}

	public virtual void UpdatePriorityDisplay()
	{
		isPriorityStale = false;
	}

	public virtual void UpdateAutoClaimDisplay()
	{
		isAutoClaimStale = false;
	}

	public virtual void UpdateAutoAssignDisplay()
	{
		isAutoAssignStale = false;
	}

	public void CalcPanelAvailability()
	{
		if (isLocked && (ShouldBeAvailable() || GameManager.everythingUnlocked))
		{
			Unlock();
		}
	}

	private void Unlock()
	{
		SetLockedState(nextState: false);
		if (gm.gameState == GameState.InGame)
		{
			OnBecameAvailableDuringGame();
		}
	}

	protected virtual void OnBecameAvailableDuringGame()
	{
		if (panelType != MenuPanelType.UpgradesPopup)
		{
			gm.TryAddUnlock(EntityId.FromMenuPanel(panelType));
			if (isBackgroundPanel)
			{
				Show();
			}
			else if (!IsVisible() && !GameManager.everythingUnlocked)
			{
				AddAlertState();
			}
		}
	}

	public virtual bool ShouldBeAvailable()
	{
		return true;
	}

	protected virtual void ApplyStateAnimations()
	{
	}

	public virtual bool ShouldBeInAlertState()
	{
		return false;
	}

	public void AddAlertState()
	{
		alertStateSelf = true;
		MenuManager.Instance.navigationPanel.CalcAlertForPanel(this);
	}

	public void ShowIfUnlocked()
	{
		if (!isLocked)
		{
			Show();
		}
	}

	public virtual bool ShouldBecomeInactiveOnHide()
	{
		return false;
	}

	public virtual bool IsNavigationButtonVisible()
	{
		if (panelType == MenuPanelType.Inventory)
		{
			return false;
		}
		return !isLocked;
	}

	public virtual void CreateLayoutForActiveTown()
	{
		isTownLayoutStale = false;
	}

	public void Pin()
	{
		isPinned = true;
		UpdatePinnedDisplay();
	}

	public virtual void Unpin()
	{
		isPinned = false;
		UpdatePinnedDisplay();
	}

	public void UpdatePinnedDisplay()
	{
		if (isPinnable)
		{
			if (null != header)
			{
				header.closeButton.gameObject.SetActive(isPinned);
			}
			if (null != canvasGroup)
			{
				canvasGroup.blocksRaycasts = isPinned;
				canvasGroup.interactable = isPinned;
			}
			if (this is MenuListPanel menuListPanel && null != menuListPanel.scrollRect && menuListPanel.scrollRect.TryGetComponent<Image>(out var component))
			{
				component.raycastTarget = isPinned;
			}
		}
	}

	public virtual void SetDisplayedTown(Town t)
	{
		if (displayedTown != t)
		{
			isTownLayoutStale = true;
		}
		displayedTown = t;
	}
}
