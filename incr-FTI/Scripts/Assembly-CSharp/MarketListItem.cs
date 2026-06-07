using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketListItem : CommonListItem
{
	public SellState sellState;

	public Image iconImage;

	public TextMeshProUGUI label;

	public TextMeshProUGUI targetSellRate;

	public TextMeshProUGUI fulfillmentBonusValue;

	public FulfillmentProgressBar fulfillmentProgressBar;

	public Slider bonusSlider;

	public CostGrid costGridInput;

	private float displayedUnitProgress;

	public MenuButton specialtyButton;

	public Image specialtyImage;

	public Image happinessQuintileImage;

	private int displayedHappinessQuintile;

	public void FinalizeLoad()
	{
		displayedUnitProgress = GameUtility.AsFloat(sellState.unitProgress);
	}

	public override void ReloadLabelParent()
	{
		base.ReloadLabelParent();
		label.text = TextDisplay.LabelForItem(sellState.itemType);
	}

	public override void Initialize()
	{
		base.Initialize();
		LoadAlert(label.transform);
		rateDisplayRegion.rateDisplayMode = RateDisplayMode.RecipeRate;
		rateDisplayRegion.ratioDisplayMode = RatioDisplayMode.RecipeRatio;
		rateDisplayRegion.iconDisplayMode = IconDisplayMode.PauseState;
		fulfillmentProgressBar.fulfillmentProgress.allowExtra = true;
		specialtyButton.buttonState = CustomButtonState.Background;
		specialtyButton.AddPointerClickTrigger(OnSpecialtyPressed);
		specialtyButton.highlightTextDelegate = SpecialtyTooltipDelegate;
		costGridInput.useWideIcon = true;
	}

	public void LoadState(SellState state)
	{
		displayedHappinessQuintile = -1;
		sellState = state;
		iconImage.sprite = IconManager.SpriteForItem(state.itemType);
		LoadCommonState(state);
		fulfillmentProgressBar.displayedSellState = state;
		fulfillmentProgressBar.fulfillmentProgress.SetStale();
	}

	public override void OnStateAssignmentChanged()
	{
		base.OnStateAssignmentChanged();
		UpdateSpecialtyButton();
		specialtyButton.AnimateInstant();
	}

	public void UpdateSpecialtyButton()
	{
		if (GameManager.Instance.specialtyCache.TryGetValue(sellState.itemType, out var value))
		{
			if (value == sellState.parentTown)
			{
				specialtyButton.isSelected = true;
				specialtyButton.buttonState = CustomButtonState.Background;
				specialtyButton.invalidReason = InvalidReason.None;
				specialtyImage.sprite = IconManager.Instance.specialtyOn;
			}
			else
			{
				specialtyButton.isSelected = false;
				specialtyButton.buttonState = CustomButtonState.Disabled;
				specialtyButton.invalidReason = InvalidReason.OtherTownSpecialty;
				specialtyImage.sprite = IconManager.SpriteForBiome(value.biomeType);
			}
		}
		else
		{
			if (sellState.parentTown.numSpecialtiesActive >= sellState.parentTown.maxNumSpecialties)
			{
				specialtyButton.buttonState = CustomButtonState.Disabled;
				specialtyButton.invalidReason = InvalidReason.MaxSpecialties;
			}
			else
			{
				specialtyButton.buttonState = CustomButtonState.Background;
				specialtyButton.invalidReason = InvalidReason.None;
			}
			specialtyButton.isSelected = false;
			specialtyImage.sprite = IconManager.Instance.specialtyOff;
		}
	}

	public override void LoadCost()
	{
		base.LoadCost();
		costGridInput.Clear();
		foreach (ItemRateData item in sellState.input)
		{
			costGridInput.AddInput(item);
		}
		costGridInput.AddSpacerArrow();
		costGridInput.craftArrowDelegate = OnRecipeClick;
		foreach (ItemRateData item2 in sellState.output)
		{
			costGridInput.AddOutput(item2);
		}
		costGridInput.PerformLayout();
		costGridInput.UpdateColors();
	}

	public override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (sellState == null)
		{
			return;
		}
		costGridInput.UpdateDynamicAffordability();
		float happinessRate = sellState.happinessRate;
		float recipeMaxRate = sellState.recipeMaxRate;
		float satisfactionSupplyRate = sellState.satisfactionSupplyRate;
		fulfillmentProgressBar.fulfillmentProgress.slider.value = sellState.fulfillmentRatio;
		if (recipeMaxRate > 0f)
		{
			if (recipeMaxRate <= happinessRate)
			{
				bonusSlider.value = 0f;
			}
			else
			{
				float value = Mathf.InverseLerp(happinessRate, recipeMaxRate, satisfactionSupplyRate);
				bonusSlider.value = value;
			}
		}
		else
		{
			bonusSlider.value = 0f;
		}
		TextDisplay.SetRate(targetSellRate, happinessRate);
		TextDisplay.SetPercent(fulfillmentProgressBar.fulfillmentProgress.label, sellState.fulfillmentRatio);
		if (sellState.happinessQuintile != displayedHappinessQuintile)
		{
			displayedHappinessQuintile = sellState.happinessQuintile;
			fulfillmentBonusValue.text = "+" + TextDisplay.LocalizedNumber(sellState.fulfillmentScore);
			fulfillmentBonusValue.color = ColorManager.ColorForHappinessQuintile(displayedHappinessQuintile);
			happinessQuintileImage.sprite = IconManager.SpriteForHappinessQuintile(displayedHappinessQuintile);
		}
	}

	public void UpdateBuildingData()
	{
		UpdateStaticDisplay();
	}

	public void OnSpecialtyPressed()
	{
		bool flag = false;
		if (specialtyButton.shouldIgnoreAction)
		{
			if (specialtyButton.invalidReason != InvalidReason.None)
			{
				MenuManager.Instance.ShowMessage(specialtyButton.invalidReason);
			}
			return;
		}
		if (sellState.isSpecialty)
		{
			sellState.isSpecialty = false;
			CommonListItem.gm.specialtyCache.Remove(sellState.itemType);
			if (sellState.parentTown.numSpecialtiesActive >= sellState.parentTown.maxNumSpecialties)
			{
				flag = true;
			}
			sellState.parentTown.numSpecialtiesActive--;
			sellState.parentTown.isTownPerkValidityStale = true;
		}
		else
		{
			sellState.isSpecialty = true;
			CommonListItem.gm.specialtyCache[sellState.itemType] = sellState.parentTown;
			sellState.parentTown.numSpecialtiesActive++;
			if (sellState.parentTown.numSpecialtiesActive >= sellState.parentTown.maxNumSpecialties)
			{
				flag = true;
			}
			sellState.parentTown.isTownPerkValidityStale = true;
		}
		if (flag)
		{
			MenuManager.Instance.combinedProductionPanel.ReloadSpecialtyButtons();
		}
		else
		{
			UpdateSpecialtyButton();
		}
		sellState.PerformCalcSpeed();
		sellState.CalcDemand();
		LoadCost();
	}

	public override void UpdateRegionAvailability()
	{
		base.UpdateRegionAvailability();
		specialtyButton.gameObject.SetActive(CommonListItem.gm.LevelOfGlobalPerk(PerkType.Specialization) > 0);
	}

	private string SpecialtyTooltipDelegate()
	{
		string text = "Specialty".Localized() + TextDisplay.NewLine + "SpecialtyDescription".Localized();
		if (specialtyButton.invalidReason == InvalidReason.OtherTownSpecialty && CommonListItem.gm.specialtyCache.TryGetValue(sellState.itemType, out var value))
		{
			text += $"\n{TextDisplay.TextForInvalidReason(InvalidReason.OtherTownSpecialty)} ({value.townName})";
		}
		else if (specialtyButton.invalidReason == InvalidReason.MaxSpecialties)
		{
			text += $"\n{TextDisplay.TextForInvalidReason(InvalidReason.MaxSpecialties)} ({TextDisplay.LocalizedNumber(sellState.parentTown.maxNumSpecialties)})";
		}
		return text;
	}

	private void OnRecipeClick()
	{
		TryManuallyProduceFromCostGrid(costGridInput);
	}
}
