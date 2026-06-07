using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesPanel : MenuListPanel
{
	public GameObject upgradeListItemPrefab;

	private readonly Dictionary<BuildObjectAvailability, SectionHeader> upgradeHeaders = new Dictionary<BuildObjectAvailability, SectionHeader>(new AvailabilityComparer());

	public TextMeshProUGUI descriptionLabel;

	private UpgradeListItem highlightedItem;

	private CountableState filter;

	public SearchHeader controlsHeader;

	private readonly List<ItemType> filteredCoinTypes = new List<ItemType>();

	public ImageButton coinFilterButtonYellow;

	public ImageButton coinFilterButtonRed;

	public ImageButton coinFilterButtonBlue;

	public ImageButton coinFilterButtonPurple;

	public ImageButton coinFilterButtonOmni;

	public ImageButton coinFilterButtonClear;

	public LayoutGroup coinFilterLayoutGroup;

	private Dictionary<ItemType, ImageButton> coinFilterButtons = new Dictionary<ItemType, ImageButton>(new ItemEqualityComparer());

	public SectionHeaderSearch sectionHeaderSearch;

	public override void Initialize()
	{
		base.Initialize();
		sectionHeaderSearch.Initialize();
		sectionHeaderSearch.isUpgrades = true;
		primaryLayoutManager.areChildRecordsPersistent = true;
		headerCollapseManager = new HeaderCollapseManager();
		RemoveAutoLayout();
		controlsHeader.purchaseAllButton.AddPointerClickTrigger(OnPurchaseAllPressed);
		controlsHeader.searchChangeDelegate = OnSearchTextChanged;
		controlsHeader.Initialize();
		controlsHeader.searchClearDelegate = OnSearchCleared;
		coinFilterButtons[ItemType.YellowCoin] = coinFilterButtonYellow;
		coinFilterButtons[ItemType.RedCoin] = coinFilterButtonRed;
		coinFilterButtons[ItemType.BlueCoin] = coinFilterButtonBlue;
		coinFilterButtons[ItemType.PurpleCoin] = coinFilterButtonPurple;
		coinFilterButtons[ItemType.OmniCoin] = coinFilterButtonOmni;
		foreach (KeyValuePair<ItemType, ImageButton> coinFilterButton in coinFilterButtons)
		{
			coinFilterButton.Value.iconImage.sprite = IconManager.DefaultSpriteForItem(coinFilterButton.Key);
			coinFilterButton.Value.buttonState = CustomButtonState.Background;
		}
		coinFilterButtonClear.buttonState = CustomButtonState.Background;
		coinFilterButtonYellow.AddPointerClickTrigger(OnCoinFilterYellowPressed);
		coinFilterButtonRed.AddPointerClickTrigger(OnCoinFilterRedPressed);
		coinFilterButtonBlue.AddPointerClickTrigger(OnCoinFilterBluePressed);
		coinFilterButtonPurple.AddPointerClickTrigger(OnCoinFilterPurplePressed);
		coinFilterButtonOmni.AddPointerClickTrigger(OnCoinFilterOmniPressed);
		coinFilterButtonClear.AddPointerClickTrigger(OnCoinFilterClearPressed);
		controlsHeader.SetFilterDisplay(filter, EntityId.None, isSearchApplied: false);
	}

	private void OnCoinFilterYellowPressed()
	{
		ToggleCoinFilter(ItemType.YellowCoin);
	}

	private void OnCoinFilterRedPressed()
	{
		ToggleCoinFilter(ItemType.RedCoin);
	}

	private void OnCoinFilterBluePressed()
	{
		ToggleCoinFilter(ItemType.BlueCoin);
	}

	private void OnCoinFilterPurplePressed()
	{
		ToggleCoinFilter(ItemType.PurpleCoin);
	}

	private void OnCoinFilterOmniPressed()
	{
		ToggleCoinFilter(ItemType.OmniCoin);
	}

	private void OnCoinFilterClearPressed()
	{
		filteredCoinTypes.Clear();
		isItemAvailabilityStale = true;
	}

	private void ToggleCoinFilter(ItemType t)
	{
		if (filteredCoinTypes.Contains(t))
		{
			filteredCoinTypes.Remove(t);
		}
		else
		{
			filteredCoinTypes.Add(t);
		}
		isItemAvailabilityStale = true;
	}

	public override void Show()
	{
		SetFilter(null);
		isSimulationDataStale = true;
		MenuPanel.gm.hasOpenedUpgradesPanel = true;
		MenuManager.Instance.navigationPanel.upgradesButton.isSelected = true;
		base.Show();
	}

	public void ShowWithFilter(CountableState f)
	{
		SetFilter(f);
		isSimulationDataStale = true;
		base.Show();
	}

	public void SetFilter(CountableState f)
	{
		if (f != filter)
		{
			filter = f;
			OnSearchPropertiesChanged();
			if (f == null)
			{
				header.displayedEntity = EntityId.None;
			}
			else
			{
				header.displayedEntity = f.AsEntity();
			}
		}
	}

	protected override void UpdateItemAvailability()
	{
		base.UpdateItemAvailability();
		ReloadCoinButtonStates();
	}

	public void ReloadCoinButtonStates()
	{
		int num = 0;
		foreach (KeyValuePair<ItemType, ImageButton> coinFilterButton in coinFilterButtons)
		{
			bool flag = !displayedTown.inventory[coinFilterButton.Key].isLocked;
			coinFilterButton.Value.gameObject.SetActive(flag);
			coinFilterButton.Value.isSelected = filteredCoinTypes.Contains(coinFilterButton.Key);
			if (flag)
			{
				num++;
			}
		}
		coinFilterLayoutGroup.gameObject.SetActive(num >= 2);
		coinFilterButtonClear.isSelected = filteredCoinTypes.Count > 0;
	}

	public void UpdateFilterHeader()
	{
		if (filter != null || !string.IsNullOrEmpty(controlsHeader.searchField.text))
		{
			sectionHeaderSearch.gameObject.SetActive(value: true);
			((RectTransform)scrollRect.transform).SetTop(124f);
			sectionHeaderSearch.UpdateUpgradesDisplay(controlsHeader.searchField.text, filter);
		}
		else
		{
			sectionHeaderSearch.gameObject.SetActive(value: false);
			((RectTransform)scrollRect.transform).SetTop(78f);
		}
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		sectionHeaderSearch.ReloadLabels();
		UpdateFilterHeader();
		foreach (KeyValuePair<BuildObjectAvailability, SectionHeader> upgradeHeader in upgradeHeaders)
		{
			upgradeHeader.Value.primaryLabel.text = TextDisplay.LocalizationKeyforAvailability(upgradeHeader.Key).Localized();
		}
		controlsHeader.purchaseAllButton.label.text = "ClaimAll".Localized();
	}

	public override void FlagAllStaticDataStale()
	{
		base.FlagAllStaticDataStale();
		arePanelCostsStale = true;
	}

	protected override void ApplyStateAnimations()
	{
		foreach (UpgradeListItem value in visibleListItems.Values)
		{
			value.purchaseUpgradeButton.AnimateInstant();
		}
	}

	public override void Hide()
	{
		base.Hide();
		MenuManager.Instance.navigationPanel.upgradesButton.isSelected = false;
		controlsHeader.searchField.text = string.Empty;
		OnSearchTextChanged();
		ClearAllAlertStates();
	}

	private void ReloadUpgradeDescription()
	{
		if (null != highlightedItem && highlightedItem.upgrade != null)
		{
			descriptionLabel.text = TextDisplay.DescriptionForUpgrade(highlightedItem.upgrade.type);
		}
		else
		{
			descriptionLabel.text = string.Empty;
		}
	}

	public void ClearAllAlertStates()
	{
		foreach (UpgradeListItem value in visibleListItems.Values)
		{
			value.ClearAlertState();
		}
	}

	private bool HasUpgradesToClaim()
	{
		if (displayedTown.hasUpgradeToClaim)
		{
			foreach (Upgrade value in displayedTown.upgrades.Values)
			{
				if (PassesFilter(value) && value.IsReadyToPurchase())
				{
					return true;
				}
			}
		}
		return false;
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		if (HasUpgradesToClaim())
		{
			controlsHeader.purchaseAllButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		else
		{
			controlsHeader.purchaseAllButton.buttonState = CustomButtonState.Disabled;
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		bool num = isItemAvailabilityStale;
		base.UpdateDynamicDisplay();
		if (null != highlightedItem)
		{
			if (!highlightedItem.isPointerInsideButton)
			{
				highlightedItem = null;
				descriptionLabel.text = string.Empty;
			}
		}
		else if (descriptionLabel.text.Length > 0)
		{
			descriptionLabel.text = string.Empty;
		}
		if (num)
		{
			ReloadUpgradeDescription();
		}
	}

	public void OnHighlighted(UpgradeListItem listItem)
	{
		highlightedItem = listItem;
		ReloadUpgradeDescription();
	}

	private void GetCategoryHeader(BuildObjectAvailability category)
	{
		string localizationKey = TextDisplay.LocalizationKeyforAvailability(category);
		SectionHeader sectionHeader = MenuManager.InstantiatedSimpleSectionHeader(layoutGroup.transform, localizationKey);
		upgradeHeaders[category] = sectionHeader;
		primaryLayoutManager.AddChildManagerWithHeight(sectionHeader.layoutManager, EntityId.FromGeneric((int)category), simpleHeaderHeight);
		sectionHeader.parentPanel = this;
	}

	private void AddItemsInCategory(BuildObjectAvailability availability)
	{
		if (!upgradeHeaders.TryGetValue(availability, out var value))
		{
			return;
		}
		foreach (Upgrade value2 in displayedTown.upgrades.Values)
		{
			if (value2.derivedAvailability == availability)
			{
				value.layoutManager.AddItemWithHeight(value2, itemHeight);
			}
		}
	}

	protected override MonoBehaviour CreateListItemForPool()
	{
		UpgradeListItem component = MenuManager.GetMenuObject(upgradeListItemPrefab, layoutGroup.transform).GetComponent<UpgradeListItem>();
		component.Initialize();
		component.parentPanel = this;
		return component;
	}

	public override void CreateItems()
	{
		base.CreateItems();
		GetCategoryHeader(BuildObjectAvailability.Available);
		GetCategoryHeader(BuildObjectAvailability.InProgress);
		GetCategoryHeader(BuildObjectAvailability.Locked);
		GetCategoryHeader(BuildObjectAvailability.Completed);
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		AddItemsInCategory(BuildObjectAvailability.Available);
		AddItemsInCategory(BuildObjectAvailability.InProgress);
		AddItemsInCategory(BuildObjectAvailability.Locked);
		AddItemsInCategory(BuildObjectAvailability.Completed);
	}

	protected override void AssignKeyToItem(object key, MonoBehaviour item)
	{
		if (key is Upgrade u && item is UpgradeListItem upgradeListItem)
		{
			upgradeListItem.LoadUpgrade(u);
			upgradeListItem.OnStateAssignmentChanged();
		}
	}

	private bool PassesFilter(Upgrade u)
	{
		if (filter != null)
		{
			EntityId entityId = filter.AsEntity();
			if (!u.def.linkedEntity.Equals(entityId) && !u.def.popupParentEntity.Contains(entityId))
			{
				return false;
			}
		}
		if (controlsHeader.searchField.text.Length > 0)
		{
			string text = TextDisplay.LabelForUpgrade(u.type);
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (LocalizationManager.LocalizedIndexOf(text, controlsHeader.searchField.text) < 0)
			{
				return false;
			}
		}
		if (filteredCoinTypes.Count > 0)
		{
			if (u.displayAvailability != BuildObjectAvailability.Available)
			{
				return false;
			}
			if (!filteredCoinTypes.Contains(u.cachedCurrentCostItem.type))
			{
				return false;
			}
		}
		return true;
	}

	protected override bool ShouldItemBeValid(object obj)
	{
		if (obj is Upgrade u)
		{
			return PassesFilter(u);
		}
		return true;
	}

	public override bool ShouldBeAvailable()
	{
		return GameManager.IsGlobalQuestComplete(QuestType.ResearchForUpgrades);
	}

	public void SetDefaultHidden()
	{
		headerCollapseManager.SetMinimized(2);
		headerCollapseManager.SetMinimized(3);
	}

	protected override void OnBecameAvailableDuringGame()
	{
		base.OnBecameAvailableDuringGame();
		isTownLayoutStale = true;
		isItemAvailabilityStale = true;
		SetDefaultHidden();
	}

	public void FormatAsPopup(bool isPopup)
	{
		header.gameObject.SetActive(isPopup);
		panelBackgroundImage.enabled = isPopup;
		((RectTransform)controlsHeader.transform).SetPosY(isPopup ? (-34f) : 0f);
		((RectTransform)scrollRect.transform).SetTop(isPopup ? 82f : 48f);
		scrollViewBackgroundImage.color = (isPopup ? ColorManager.menuBackgroundColorOpaque : ColorManager.menuBackgroundColorTransparent);
	}

	public bool TryGetFilter(out CountableState f)
	{
		f = filter;
		return f != null;
	}

	private void OnPurchaseAllPressed()
	{
		if (controlsHeader.purchaseAllButton.shouldIgnoreAction)
		{
			return;
		}
		GameUtility.reusableUpgradeList.Clear();
		foreach (Upgrade value in displayedTown.upgrades.Values)
		{
			if (PassesFilter(value))
			{
				GameUtility.reusableUpgradeList.Add(value);
			}
		}
		displayedTown.PurchaseAllUpgradesInList(GameUtility.reusableUpgradeList);
		MenuPanel.m.upgradesPanel.isTownLayoutStale = true;
	}

	public void OnSearchCleared()
	{
		SetFilter(null);
		OnSearchTextChanged();
	}

	public void OnSearchTextChanged()
	{
		OnSearchPropertiesChanged();
	}

	public void OnSearchPropertiesChanged()
	{
		FlagAllStaticDataStale();
		ReloadLabels();
		bool isSearchApplied = filter != null || !string.IsNullOrEmpty(controlsHeader.searchField.text);
		controlsHeader.SetFilterDisplay(filter, EntityId.None, isSearchApplied);
		UpdateFilterHeader();
	}
}
