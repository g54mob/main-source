using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SectionHeaderSearch : MonoBehaviour
{
	public Image leftImage;

	public Image rightImage;

	public LabelButton leftButton;

	public LabelButton rightButton;

	public TextMeshProUGUI searchFilterLabel;

	[NonSerialized]
	public bool isUpgrades;

	[NonSerialized]
	public bool isInventory;

	public void Initialize()
	{
		leftButton.InitializeButton();
		rightButton.InitializeButton();
		leftButton.AddPointerClickTrigger(OnClickLeftButton);
		rightButton.AddPointerClickTrigger(OnClickRightButton);
		leftButton.gameObject.SetActive(value: false);
		rightButton.gameObject.SetActive(value: false);
	}

	public void UpdateUpgradesDisplay(string searchText, CountableState filter)
	{
		if (string.IsNullOrEmpty(searchText))
		{
			leftButton.gameObject.SetActive(value: false);
		}
		else
		{
			leftButton.gameObject.SetActive(value: true);
			leftButton.label.text = searchText;
			leftImage.sprite = IconManager.Instance.search;
			leftButton.buttonState = CustomButtonState.BlueFlashing;
		}
		if (filter != null)
		{
			rightButton.gameObject.SetActive(value: true);
			EntityId entityId = filter.AsEntity();
			rightImage.sprite = IconManager.SpriteForEntity(entityId);
			rightButton.label.text = TextDisplay.FormattedRewardEntityWithType(entityId);
			rightButton.buttonState = CustomButtonState.BlueFlashing;
		}
		else
		{
			rightButton.gameObject.SetActive(value: false);
		}
	}

	public void UpdateSearchDisplay()
	{
		if (isInventory)
		{
			if (MenuManager.Instance.inventoryPanel.filter != null)
			{
				leftButton.gameObject.SetActive(value: true);
				leftButton.label.text = TextDisplay.LabelForEntity(MenuManager.Instance.inventoryPanel.filter.AsEntity());
				leftImage.sprite = IconManager.SpriteForEntity(MenuManager.Instance.inventoryPanel.filter.AsEntity());
				leftButton.buttonState = CustomButtonState.BlueFlashing;
			}
			else if (MenuManager.Instance.inventoryPanel.specifiedFilter == SpecifiedFilter.PositiveGrowth)
			{
				leftButton.gameObject.SetActive(value: true);
				leftButton.label.text = "Increasing".Localized();
				leftImage.sprite = IconManager.Instance.increasing;
				leftButton.buttonState = CustomButtonState.BlueFlashing;
			}
			else if (MenuManager.Instance.inventoryPanel.specifiedFilter == SpecifiedFilter.NegativeGrowth)
			{
				leftButton.gameObject.SetActive(value: true);
				leftButton.label.text = "Decreasing".Localized();
				leftImage.sprite = IconManager.Instance.decreasing;
				leftButton.buttonState = CustomButtonState.BlueFlashing;
			}
			else
			{
				leftButton.gameObject.SetActive(value: false);
			}
			rightButton.gameObject.SetActive(value: false);
		}
		else
		{
			if (!MenuManager.isSearchApplied)
			{
				return;
			}
			if (string.IsNullOrEmpty(MenuManager.currentSearchText))
			{
				leftButton.gameObject.SetActive(value: false);
			}
			else
			{
				leftButton.gameObject.SetActive(value: true);
				leftButton.label.text = MenuManager.currentSearchText;
				leftImage.sprite = IconManager.Instance.search;
				leftButton.buttonState = CustomButtonState.BlueFlashing;
			}
			ProductionListPanelCombined combinedProductionPanel = MenuManager.Instance.combinedProductionPanel;
			if (combinedProductionPanel.entityFilter.type != EntityType.None)
			{
				rightButton.gameObject.SetActive(value: true);
				rightImage.sprite = IconManager.SpriteForEntity(combinedProductionPanel.entityFilter);
				rightButton.label.text = TextDisplay.LabelForEntity(combinedProductionPanel.entityFilter);
				rightButton.buttonState = CustomButtonState.BlueFlashing;
			}
			else if (combinedProductionPanel.itemFilter is StateManager stateManager)
			{
				rightButton.gameObject.SetActive(value: true);
				EntityId entityId = stateManager.AsEntity();
				rightImage.sprite = IconManager.SpriteForEntity(entityId);
				rightButton.buttonState = CustomButtonState.BlueFlashing;
				if (stateManager is SellState)
				{
					rightButton.label.text = "(" + "Markets".Localized() + ") " + TextDisplay.LabelForEntity(entityId);
				}
				else if (stateManager is TradingState)
				{
					rightButton.label.text = "(" + "Trading".Localized() + ") " + TextDisplay.LabelForEntity(entityId);
				}
				else
				{
					rightButton.label.text = TextDisplay.FormattedRewardEntityWithType(entityId);
				}
			}
			else if (combinedProductionPanel.itemFilter is CountableState countableState)
			{
				rightButton.gameObject.SetActive(value: true);
				EntityId entityId2 = countableState.AsEntity();
				rightImage.sprite = IconManager.SpriteForEntity(entityId2);
				rightButton.label.text = TextDisplay.FormattedRewardEntityWithType(entityId2);
				rightButton.buttonState = CustomButtonState.BlueFlashing;
			}
			else
			{
				rightButton.gameObject.SetActive(value: false);
			}
		}
	}

	public void ReloadLabels()
	{
		if (LocalizationManager.IsEnglish())
		{
			searchFilterLabel.gameObject.SetActive(value: true);
			searchFilterLabel.text = "Search Filters Active:";
		}
		else
		{
			searchFilterLabel.gameObject.SetActive(value: false);
		}
	}

	private void OnClickLeftButton()
	{
		if (isInventory)
		{
			MenuManager.Instance.inventoryPanel.SetFilter(null);
		}
		else if (isUpgrades)
		{
			MenuManager.Instance.upgradesPanel.controlsHeader.searchField.text = string.Empty;
			MenuManager.Instance.upgradesPanel.OnSearchTextChanged();
		}
		else
		{
			MenuManager.Instance.searchHeader.searchField.text = string.Empty;
			MenuManager.Instance.OnSearchPropertiesChanged();
		}
	}

	private void OnClickRightButton()
	{
		if (isInventory)
		{
			MenuManager.Instance.inventoryPanel.SetOverrideFilter(BuildingCategory.None);
			return;
		}
		if (isUpgrades)
		{
			MenuManager.Instance.upgradesPanel.OnSearchCleared();
			return;
		}
		MenuManager.Instance.combinedProductionPanel.ClearAllSearchProperties();
		MenuManager.Instance.OnSearchPropertiesChanged();
	}

	public bool TryAddPointerToSearch()
	{
		if (rightButton.gameObject.activeInHierarchy)
		{
			MenuManager.Instance.ShowPointerPanel((RectTransform)rightButton.transform);
			return true;
		}
		if (leftButton.gameObject.activeInHierarchy)
		{
			MenuManager.Instance.ShowPointerPanel((RectTransform)leftButton.transform);
			return true;
		}
		return false;
	}
}
