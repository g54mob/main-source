using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TownStatsPanel : MenuPanel
{
	public GameObject townStatLevelListItemPrefab;

	public LayoutGroup statGroup;

	public Image biomeImage;

	public TextMeshProUGUI biomeLabel;

	public MenuButton biomeButton;

	public MenuButton townNameButton;

	public TextMeshProUGUI townNameLabel;

	public TextMeshProUGUI levelUpCommand;

	public TextMeshProUGUI townLevelLabel;

	public TextMeshProUGUI levelNextLabel;

	public TextMeshProUGUI townXP;

	public TextMeshProUGUI townXPRate;

	public Image townXPImage;

	public PlayerMessageItem townLogItem;

	public MenuButton townLogButton;

	public Transform debugRegion;

	public TextMeshProUGUI debugText;

	public Image townExperiencePoint;

	public Slider levelUpSlider;

	public MenuButton levelUpButton;

	public TownStatListItem workerStat;

	public TownStatListItem landStat;

	public TownStatListItem townPerkPointStat;

	public TownProgressBarItem fulfillmentProgress;

	public MenuButton xpIconButton;

	private bool debugHasUpdated;

	private readonly List<TownStatListItem> listItems = new List<TownStatListItem>();

	private readonly List<TownStatLevelListItem> levelStatItems = new List<TownStatLevelListItem>();

	private readonly Dictionary<ItemType, CurrencyListItem> currencyListItems = new Dictionary<ItemType, CurrencyListItem>();

	[NonSerialized]
	public bool isTownLevelStale;

	private double lastDisplayedPopulation = double.MinValue;

	private double lastDisplayedRate = double.MaxValue;

	private Flag lastDisplayedLevelReadyState;

	private double lastDisplayedTownXP;

	private int lastDisplayedFulfillmentScore = int.MinValue;

	private double lastDisplayedCumulativeXP;

	public SingleSelectionManager singleSelectionManager;

	public bool useFrequentQuestUpdates;

	public const bool useNotifications = true;

	public override void Initialize()
	{
		base.Initialize();
		debugRegion.gameObject.SetActive(value: false);
		townNameButton.AddPointerClickTrigger(OnTownNamePressed);
		townNameButton.buttonState = CustomButtonState.Translucent;
		AddUtilityItem(landStat, "HousingPlots", IconManager.Instance.land);
		landStat.AddPointerClickTrigger(OnHousingPlotsClicked);
		landStat.tooltipModifier = TooltipModifier.ShowProductionDetails;
		landStat.tooltipOptions = MenuPanel.m.currencyTooltipOptions;
		landStat.tooltipEntity = EntityId.FromItem(ItemType.UtilityLand);
		landStat.buttonState = CustomButtonState.Default;
		AddUtilityItem(workerStat, "Workers", IconManager.Instance.worker);
		workerStat.AddPointerClickTrigger(OnWorkersClicked);
		workerStat.tooltipModifier = TooltipModifier.ShowProductionDetails;
		workerStat.tooltipOptions = MenuPanel.m.currencyTooltipOptions;
		workerStat.tooltipEntity = EntityId.FromItem(ItemType.Worker);
		workerStat.buttonState = CustomButtonState.Default;
		AddUtilityItem(townPerkPointStat, "TownPerks", IconManager.Instance.experiencePointPurple);
		townPerkPointStat.AddPointerClickTrigger(OnTownPerksPressed);
		townPerkPointStat.tooltipEntity = EntityId.FromItem(ItemType.UtilityPrestigePoint);
		townPerkPointStat.buttonState = CustomButtonState.Background;
		levelUpButton.AddPointerClickTrigger(OnLevelUpClicked);
		levelUpButton.highlightTextDelegate = HighlightTextTownLevel;
		levelUpButton.isTooltipUpdatedEverySimulationStep = true;
		townXPImage.sprite = IconManager.Instance.townLevel;
		townExperiencePoint.sprite = IconManager.DefaultSpriteForItem(ItemType.TownExperiencePoint);
		townLogButton.AddPointerClickTrigger(OnClickedLog);
		singleSelectionManager = new SingleSelectionManager(OnSelectionChangedByManager);
		biomeButton.AddPointerClickTrigger(OnClickedBiome);
		fulfillmentProgress.highlightTextDelegate = FulfillmentHighlightText;
		fulfillmentProgress.AddPointerClickTrigger(OnFulfillmentPressed);
		fulfillmentProgress.buttonState = CustomButtonState.Default;
		xpIconButton.tooltipEntity = EntityId.FromItem(ItemType.TownExperiencePoint);
		xpIconButton.tooltipModifier = TooltipModifier.ShowProductionDetails;
		TooltipOptions tooltipOptions = new TooltipOptions();
		tooltipOptions.tooltipAnchorPlacement = TextAnchor.MiddleCenter;
		tooltipOptions.tooltipDisplayPlacement = TextAnchor.MiddleCenter;
		tooltipOptions.tooltipCenterY = true;
		tooltipOptions.tooltipCenterX = true;
		tooltipOptions.panelSize = new Vector2(800f, 800f);
		xpIconButton.tooltipOptions = tooltipOptions;
		xpIconButton.AddPointerClickTrigger(OnXPIconClicked);
	}

	private string FulfillmentHighlightText()
	{
		return TextDisplay.FulfillmentTooltipForTown(displayedTown);
	}

	private string HighlightTextTownLevel()
	{
		double num = displayedTown.levelUpCost - lastDisplayedTownXP;
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append(TextDisplay.FormattedKeyValue("TownLevel", TextDisplay.LocalizedNumber(displayedTown.townLevel)));
		pooledStringBuilder.Append(TextDisplay.NewLine);
		pooledStringBuilder.Append(TextDisplay.FormattedKeyValue("Next", TextDisplay.LocalizedNumber(num)));
		TextDisplay.AppendIfSpaced(pooledStringBuilder);
		pooledStringBuilder.Append(TextDisplay.LabelForItem(ItemType.TownExperiencePoint));
		if (displayedTown.cachedTownXPState.frameDelta > 0.0 && TimeManager.SimulationDelta > 0f)
		{
			double num2 = displayedTown.cachedTownXPState.frameDelta / (double)TimeManager.SimulationDelta;
			double num3 = num / num2;
			if (num3 < 3.4028234663852886E+38)
			{
				pooledStringBuilder.Append(TextDisplay.NewLine);
				pooledStringBuilder.Append(TextDisplay.FormattedHoursMinutesSeconds(GameUtility.AsTruncatedFloat(num3)));
			}
		}
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}

	private string HighlightTextPrestigePoints()
	{
		return TextDisplay.LabelForItem(ItemType.UtilityPrestigePoint);
	}

	public override void ResetPanel()
	{
		base.ResetPanel();
		lastDisplayedTownXP = double.MaxValue;
		lastDisplayedLevelReadyState = Flag.Unknown;
		townLogItem.Reset();
	}

	public override void CreateItems()
	{
		base.CreateItems();
		fulfillmentProgress.progressBar.fillImage.color = ColorManager.fulfillment;
	}

	public void SetStale()
	{
		lastDisplayedTownXP = double.MaxValue;
		lastDisplayedPopulation = 3.4028234663852886E+38;
	}

	public void ReloadBiomeInfo()
	{
		biomeLabel.text = TextDisplay.LabelForBiome(displayedTown.biomeType);
		biomeImage.sprite = IconManager.SpriteForBiome(displayedTown.biomeType);
		biomeButton.tooltipEntity = EntityId.FromBiome(displayedTown.biomeType);
		biomeButton.tooltipModifier = TooltipModifier.ShowProductionDetails;
		biomeButton.tooltipOptions = MenuManager.Instance.recipeLabelTooltipOptions;
	}

	public void ReloadTownName()
	{
		townNameLabel.text = displayedTown.townName;
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		ReloadTownName();
		UpdateTownLevelDisplay();
		ReloadBiomeInfo();
		levelNextLabel.text = "Next".Localized() + ":";
		levelUpCommand.text = "LevelUpButton".Localized().ToUpper();
		foreach (TownStatListItem listItem in listItems)
		{
			listItem.ReloadLabel();
		}
		foreach (TownStatLevelListItem levelStatItem in levelStatItems)
		{
			levelStatItem.ReloadLabels();
		}
		isSimulationDataStale = true;
		UpdateSimulationDisplay();
		UpdateDynamicDisplay();
	}

	private void DisplayFulfillmentScore()
	{
		lastDisplayedFulfillmentScore = displayedTown.fulfillmentScore;
		int q = GameUtility.HappinessQuintileForSupplyRate(displayedTown.happinessAverage);
		fulfillmentProgress.iconImage.sprite = IconManager.SpriteForHappinessQuintile(q);
		fulfillmentProgress.primaryLabel.text = TextDisplay.LocalizedNumber(lastDisplayedFulfillmentScore);
	}

	public override bool IsFixedPosition()
	{
		return true;
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		ReloadTownDetails();
	}

	public void ReloadTownDetails()
	{
		ReloadTownName();
		UpdateTownLevelDisplay();
		UpdateDisplayedTownXP();
		ReloadBiomeInfo();
	}

	public void UpdateDisplayedTownXP()
	{
		lastDisplayedTownXP = displayedTown.cachedTownXPState.currentCount;
		_ = displayedTown.levelUpCost - lastDisplayedTownXP;
		_ = 0.0;
		townXP.text = TextDisplay.LocalizedNumber(lastDisplayedTownXP) + " / " + TextDisplay.LocalizedNumber(displayedTown.levelUpCost);
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		if (displayedTown.workerState == null)
		{
			return;
		}
		if (isTownLevelStale)
		{
			UpdateTownLevelDisplay();
		}
		foreach (TownStatLevelListItem levelStatItem in levelStatItems)
		{
			levelStatItem.UpdateSimulationDisplay();
		}
		foreach (CurrencyListItem value in currencyListItems.Values)
		{
			value.UpdateSimulationDisplay();
		}
		double perSecondAttemptedDelta = displayedTown.cachedTownXPState.perSecondAttemptedDelta;
		if (!GameUtility.NearlyEquals(lastDisplayedRate, perSecondAttemptedDelta))
		{
			TextDisplay.SetRate(townXPRate, displayedTown.cachedTownXPState.perSecondAttemptedDelta);
			lastDisplayedRate = perSecondAttemptedDelta;
		}
		if (GameUtility.NotEquals(lastDisplayedCumulativeXP, displayedTown.cumulativeXP))
		{
			UpdateDisplayedTownXP();
		}
		if (displayedTown.fulfillmentScore != lastDisplayedFulfillmentScore)
		{
			DisplayFulfillmentScore();
		}
		if (displayedTown.happinessMax > 0f)
		{
			TextDisplay.SetPercent(fulfillmentProgress.countLabel, displayedTown.happinessAverage);
			fulfillmentProgress.progressBar.slider.value = displayedTown.happinessAverage;
		}
		else
		{
			TextDisplay.SetPercent(fulfillmentProgress.countLabel, 0f);
			fulfillmentProgress.progressBar.slider.value = 0f;
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		if (!debugHasUpdated)
		{
			debugHasUpdated = true;
		}
		base.UpdateDynamicDisplay();
		ItemState cachedTownXPState = displayedTown.cachedTownXPState;
		levelUpSlider.value = Mathf.Clamp01(GameUtility.AsFloat(cachedTownXPState.currentCount / displayedTown.levelUpCost));
		if (displayedTown.workerState == null)
		{
			return;
		}
		workerStat.TryUpdateWithValue(GameUtility.AsFloat(displayedTown.population), GameUtility.AsFloat(displayedTown.workerState.numAvailable));
		if (MenuPanel.gm.isLandInfinite)
		{
			landStat.availableLabel.SetText("∞");
		}
		else
		{
			landStat.TryUpdateWithValue(0f, GameUtility.AsFloat(displayedTown.landState.currentCount));
		}
		townPerkPointStat.TryUpdateWithValue(0f, GameUtility.AsFloat(displayedTown.townPerkPointState.numAvailable));
		UpdateTownPerksButton();
		if (displayedTown.hasRewardToClaim)
		{
			if (displayedTown.lastClaimedRewardLevel < 3)
			{
				levelUpButton.buttonState = CustomButtonState.HighlightFlashing;
			}
			else
			{
				levelUpButton.buttonState = CustomButtonState.BlueFlashing;
			}
		}
		else
		{
			levelUpButton.buttonState = CustomButtonState.Background;
		}
	}

	public void UpdateTownPerksButton()
	{
		if (displayedTown.hasTownPerkAvailable)
		{
			if (MenuPanel.gm.hasOpenedPerksPanel)
			{
				townPerkPointStat.buttonState = CustomButtonState.Default;
			}
			else
			{
				townPerkPointStat.buttonState = CustomButtonState.HighlightFlashing;
			}
			return;
		}
		if (displayedTown.townPerkPointState.currentCount <= 0.0)
		{
			townPerkPointStat.gameObject.SetActive(value: false);
		}
		townPerkPointStat.buttonState = CustomButtonState.Background;
	}

	private void UpdateTownLevelDisplay()
	{
		townLevelLabel.text = TextDisplay.GetFormattedLevel(displayedTown.townLevel);
		isTownLevelStale = false;
	}

	private void AddUtilityItem(TownStatListItem result, string localizationKey, Sprite s)
	{
		result.localizationKeyTotal = localizationKey;
		listItems.Add(result);
		result.iconImage.sprite = s;
		result.ConfigureTextAnimation();
	}

	private void OnFulfillmentPressed()
	{
		MenuPanel.m.navigationPanel.SelectPanel(MenuPanelType.Markets);
	}

	private void OnLevelUpClicked()
	{
		if (!levelUpButton.shouldIgnoreAction && displayedTown.hasRewardToClaim)
		{
			displayedTown.ClaimLevelRewards();
		}
	}

	private void OnWorkersClicked()
	{
		MenuPanel.m.buildingsPanel.Show();
		MenuPanel.m.buildingsPanel.QueueJumpToBuilding(BuildingType.House);
	}

	private void OnHousingPlotsClicked()
	{
		MenuManager.Instance.buildingsPanel.Show();
	}

	private void OnClickedHappiness()
	{
		MenuManager.Instance.navigationPanel.SelectPanel(MenuPanelType.Markets);
	}

	private void OnClickedLog()
	{
	}

	private void OnClickedBiome()
	{
		MenuManager.Instance.tooltipPanel.ToggleEntityPinState(EntityId.FromBiome(displayedTown.biomeType));
	}

	protected override void UpdateItemAvailability()
	{
		base.UpdateItemAvailability();
		landStat.gameObject.SetActive(value: true);
		workerStat.gameObject.SetActive(value: true);
		townPerkPointStat.gameObject.SetActive(value: true);
	}

	public override bool ShouldBeAvailable()
	{
		return true;
	}

	public void AnimateHousingPlotStat()
	{
		landStat.textFlashAnimation.Run();
	}

	public void AnimateWorkerStat()
	{
		workerStat.textFlashAnimation.Run();
	}

	public void OnInventoryButtonPressed()
	{
		MenuPanel.m.inventoryPanelPopup.ToggleDisplayForTown(displayedTown);
	}

	public void OnTownPerksPressed()
	{
		MenuPanel.m.townPerksPanel.ToggleDisplayForTown(displayedTown);
	}

	public void OnTownNamePressed()
	{
		MenuManager.Instance.textEntryPanel.ShowWithDefaultText(displayedTown.townName, "OK", MenuPanel.gm.OnTownNameChanged);
	}

	private string HighlightTextTownResets()
	{
		return "TownResets".Localized();
	}

	public void OnSelectionChangedByManager(EntityId id, bool nextState)
	{
		if (id.TryAsItem(out var i) && currencyListItems.TryGetValue(i, out var value))
		{
			if (!nextState)
			{
				value.RemoveSelection();
			}
			TooltipPanel tooltipPanel = MenuManager.Instance.tooltipPanel;
			if (nextState)
			{
				tooltipPanel.LoadEntityProduction(id);
				tooltipPanel.Pin();
			}
			else
			{
				tooltipPanel.Unpin();
			}
		}
	}

	private void OnXPIconClicked()
	{
		MenuManager.Instance.tooltipPanel.ToggleEntityPinState(xpIconButton.tooltipEntity);
	}
}
