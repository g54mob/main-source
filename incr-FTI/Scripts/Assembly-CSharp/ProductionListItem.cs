using TMPro;
using UnityEngine.UI;

public class ProductionListItem : CommonListItem
{
	public Image iconImage;

	public TextMeshProUGUI label;

	public CostGrid costGrid;

	public MenuButton titleButton;

	public override void ReloadLabelParent()
	{
		base.ReloadLabelParent();
		label.text = TextDisplay.LabelForEntity(state.AsEntity());
	}

	public override void Initialize()
	{
		costGrid.useWideIcon = true;
		base.Initialize();
		LoadAlert(label.transform);
		rateDisplayRegion.rateDisplayMode = RateDisplayMode.OutputRate;
		rateDisplayRegion.ratioDisplayMode = RatioDisplayMode.RecipeRatio;
		titleButton.AddPointerClickTrigger(NavigateToEntity);
	}

	private void OnRecipeClick()
	{
		TryManuallyProduceFromCostGrid(costGrid);
	}

	private void NavigateToEntity()
	{
		ProductionListPanelCombined combinedProductionPanel = MenuManager.Instance.combinedProductionPanel;
		MenuManager.Instance.searchHeader.searchField.text = string.Empty;
		MenuManager.Instance.navigationPanel.SelectBuildingCategory(BuildingCategory.None, sendEvent: false);
		combinedProductionPanel.ClearAllSearchProperties();
		combinedProductionPanel.itemFilter = state;
		MenuManager.Instance.OnSearchPropertiesChanged();
	}

	public void LoadState(StateManager stateToLoad)
	{
		iconImage.sprite = IconManager.SpriteForState(stateToLoad);
		rateDisplayRegion.iconDisplayMode = IconDisplayMode.PauseState;
		LoadCommonState(stateToLoad);
		titleButton.tooltipEntity = stateToLoad.AsEntity();
	}

	public override void LoadCost()
	{
		base.LoadCost();
		costGrid.Clear();
		foreach (ItemRateData item in state.input)
		{
			costGrid.AddInput(item);
		}
		costGrid.AddSpacerArrow();
		costGrid.craftArrowDelegate = OnRecipeClick;
		if (CommonListItem.gm.tutorialQuestType == QuestType.WoodForHouse)
		{
			costGrid.SetSpacerFlashing(nextState: true);
		}
		else
		{
			costGrid.SetSpacerFlashing(nextState: false);
		}
		foreach (ItemRateData item2 in state.output)
		{
			costGrid.AddOutput(item2);
		}
		costGrid.PerformLayout();
		costGrid.UpdateColors();
	}

	public void UpdateBuildingData()
	{
		UpdateStaticDisplay();
	}

	public override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (state != null)
		{
			costGrid.UpdateDynamicAffordability();
		}
	}
}
