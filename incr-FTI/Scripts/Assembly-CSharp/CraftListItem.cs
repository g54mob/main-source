using TMPro;
using UnityEngine.UI;

public class CraftListItem : CommonListItem
{
	public Image itemImage;

	public TextMeshProUGUI itemLabel;

	public MenuButton titleButton;

	public CostGrid costGridInput;

	public new RecipeState state;

	public void UpdateBuildingData()
	{
		UpdateStaticDisplay();
	}

	public override void Initialize()
	{
		costGridInput.useWideIcon = true;
		costGridInput.HideBackground();
		base.Initialize();
		LoadAlert(itemLabel.transform);
		rateDisplayRegion.rateDisplayMode = RateDisplayMode.OutputRate;
		rateDisplayRegion.ratioDisplayMode = RatioDisplayMode.RecipeRatio;
		rateDisplayRegion.iconDisplayMode = IconDisplayMode.PauseState;
		titleButton.AddPointerClickTrigger(base.OnTitleLabelClicked);
		titleButton.tooltipOptions = MenuManager.Instance.recipeLabelTooltipOptions;
		titleButton.tooltipModifier = TooltipModifier.ShowGuide;
	}

	public void LoadState(RecipeState r)
	{
		state = r;
		itemImage.sprite = IconManager.SpriteForRecipeType(r.type);
		LoadCommonState(r);
		titleButton.tooltipEntity = EntityId.FromRecipe(r.type);
	}

	public override void ReloadLabelParent()
	{
		base.ReloadLabelParent();
		itemLabel.text = TextDisplay.LabelForRecipeType(state.type);
	}

	public override void LoadCost()
	{
		base.LoadCost();
		costGridInput.Clear();
		foreach (ItemRateData item in state.input)
		{
			costGridInput.AddInput(item);
		}
		costGridInput.AddSpacerArrow();
		foreach (ItemRateData item2 in state.output)
		{
			costGridInput.AddOutput(item2);
		}
		costGridInput.PerformLayout();
	}

	public override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (state != null)
		{
			costGridInput.UpdateDynamicAffordability();
		}
	}
}
