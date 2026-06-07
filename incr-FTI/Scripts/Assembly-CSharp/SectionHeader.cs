using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SectionHeader : MenuButton
{
	public TextMeshProUGUI primaryLabel;

	public Image collapseButtonImage;

	public Image buildingImage;

	public MenuListPanel parentPanel;

	public LayoutManager layoutManager;

	public MenuButton headerNavigationButton;

	[NonSerialized]
	public string localizationKey;

	private int initializationCount;

	public virtual void Initialize()
	{
		useOutlineHighlight = true;
		AddPointerClickTrigger(OnDisplayToggleClicked);
		AddRightClickTrigger(OnDisplayRightClicked);
		layoutManager = new LayoutManager((RectTransform)base.transform);
		layoutManager.minimizationResponder = OnMinimizationStateChanged;
		initializationCount++;
		if (null != headerNavigationButton)
		{
			headerNavigationButton.AddPointerClickTrigger(OnHeaderNavigationClicked);
		}
	}

	private void OnHeaderNavigationClicked()
	{
		_ = MenuManager.Instance.tooltipPanel;
		if (!(parentPanel is ProductionListPanelCombined productionListPanelCombined))
		{
			return;
		}
		bool num = productionListPanelCombined.displayedLayoutRoot == layoutManager;
		productionListPanelCombined.ClearAllSearchProperties();
		MenuManager.Instance.navigationPanel.SelectBuildingCategory(BuildingCategory.None, sendEvent: false);
		if (!num)
		{
			productionListPanelCombined.displayedLayoutRoot = layoutManager;
			if (layoutManager.linkedObject is BuildingState buildingState)
			{
				productionListPanelCombined.entityFilter = buildingState.AsEntity();
			}
			else if (layoutManager.linkedObject is EntityId entityId)
			{
				productionListPanelCombined.entityFilter = entityId.GetCopy();
			}
		}
		MenuManager.Instance.OnSearchPropertiesChanged();
	}

	public virtual void ReloadLabels()
	{
		if (localizationKey != null)
		{
			primaryLabel.text = localizationKey.Localized();
		}
	}

	public void UpdateMinimizationSprite()
	{
		if (layoutManager.isRoot)
		{
			collapseButtonImage.sprite = IconManager.Instance.arrowNavigateBack;
		}
		else
		{
			MenuManager.Instance.SetCollapsed(collapseButtonImage, parentPanel?.IsMinimized(layoutManager) ?? false);
		}
	}

	public void OnMinimizationStateChanged(bool isMinimized)
	{
		UpdateMinimizationSprite();
	}

	public void OnDisplayRightClicked()
	{
		MenuListPanel menuListPanel = parentPanel;
		if ((object)menuListPanel != null)
		{
			menuListPanel.ToggleMinimizationForAllSimilarHeaders(layoutManager);
			parentPanel.isItemAvailabilityStale = true;
		}
	}

	public void OnDisplayToggleClicked()
	{
		if (!(null != parentPanel))
		{
			return;
		}
		if (parentPanel is ProductionListPanelCombined productionListPanelCombined && layoutManager.isRoot)
		{
			productionListPanelCombined.ClearAllSearchProperties();
			MenuManager.Instance.navigationPanel.SelectBuildingCategory(BuildingCategory.None, sendEvent: false);
			MenuManager.Instance.OnSearchPropertiesChanged();
			return;
		}
		MenuListPanel menuListPanel = parentPanel;
		if ((object)menuListPanel != null)
		{
			HeaderCollapseManager activeHeaderCollapseManager = menuListPanel.activeHeaderCollapseManager;
			if (UserInput.isControlKeyDown)
			{
				parentPanel.ToggleMinimizationForAllSimilarHeaders(layoutManager);
			}
			else
			{
				activeHeaderCollapseManager.ToggleMinimized(layoutManager.minimizationKey);
			}
		}
		parentPanel.isItemAvailabilityStale = true;
	}

	public bool HasActiveChildren()
	{
		foreach (LayoutItem childItem in layoutManager.childItems)
		{
			if (childItem.isValid)
			{
				return true;
			}
		}
		if (GameManager.everythingUnlocked)
		{
			return layoutManager.childItems.Count > 0;
		}
		return false;
	}

	public virtual void SetIndentLevel(float level)
	{
		float num = 32f * level;
		layoutManager.layoutRect.SetLeft(num + 3f);
		if (TryGetComponent<Image>(out var component))
		{
			component.raycastPadding = new Vector4(0f - num, 0f, 0f, 0f);
		}
	}
}
