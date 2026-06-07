using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldListItem : MenuButton
{
	public TextMeshProUGUI townNameLabel;

	public TextMeshProUGUI townLevelLabel;

	public TextMeshProUGUI biomeLabel;

	public TextMeshProUGUI xpDisplayLabel;

	public TextMeshProUGUI levelNextLabel;

	public Image backgroundImage;

	public Image biomeImage;

	public Image townNameBackground;

	public GameObject biomeRegion;

	public MenuButton levelUpButton;

	public LabelButton travelButton;

	public LabelButton createButton;

	private float lastDisplayedXP;

	public Slider levelUpSlider;

	public int townIndex;

	public MenuButton biomeButton;

	public LayoutGroup modifierIconGridUnique;

	public LayoutGroup modifierIconGridPositive;

	public LayoutGroup modifierIconGridNegative;

	public ImageButton researchButton;

	public ImageButton upgradesButton;

	public ImageButton constructionButton;

	private string queuedTownName;

	private BiomeType cachedBiomeType;

	private Town displayedTown;

	public LabelButton lockedButton;

	public TownStatListItem workerStat;

	public TownStatListItem landStat;

	public TownStatListItem townPerkPointStat;

	public TownProgressBarItem fulfillmentProgress;

	private int lastDisplayedFulfillmentScore = int.MinValue;

	private List<ModifierIcon> modifierIcons = new List<ModifierIcon>();

	private GameManager gm => GameManager.Instance;

	public void Initialize()
	{
		createButton.AddPointerClickTrigger(OnCreateButtonPressed);
		travelButton.AddPointerClickTrigger(OnTravelButtonPressed);
		landStat.tooltipEntity = EntityId.FromItem(ItemType.UtilityLand);
		landStat.buttonState = CustomButtonState.Background;
		landStat.highlightTextDelegate = OnHoverLand;
		workerStat.tooltipEntity = EntityId.FromItem(ItemType.Worker);
		workerStat.buttonState = CustomButtonState.Background;
		workerStat.highlightTextDelegate = OnHoverWorkers;
		townPerkPointStat.localizationKeyTotal = "TownPerks";
		townPerkPointStat.iconImage.sprite = IconManager.Instance.experiencePointPurple;
		townPerkPointStat.ConfigureTextAnimation();
		townPerkPointStat.AddPointerClickTrigger(OnTownPerksPressed);
		townPerkPointStat.tooltipEntity = EntityId.FromItem(ItemType.UtilityPrestigePoint);
		townPerkPointStat.buttonState = CustomButtonState.Background;
		landStat.AnimateInstant();
		workerStat.AnimateInstant();
		townPerkPointStat.AnimateInstant();
		researchButton.buttonState = CustomButtonState.Background;
		upgradesButton.buttonState = CustomButtonState.Background;
		constructionButton.buttonState = CustomButtonState.Background;
		researchButton.AnimateInstant();
		upgradesButton.AnimateInstant();
		constructionButton.AnimateInstant();
		researchButton.AddPointerClickTrigger(OnResearchPressed);
		upgradesButton.AddPointerClickTrigger(OnUpgradesPressed);
		constructionButton.AddPointerClickTrigger(OnConstructionPressed);
		researchButton.AddRightClickTrigger(ClaimAllResearch);
		upgradesButton.AddRightClickTrigger(ClaimAllUpgrades);
	}

	public void UpdateTownDisplay()
	{
		if (townIndex < gm.towns.Count)
		{
			displayedTown = gm.towns[townIndex];
			if (displayedTown == null)
			{
				FormatAsEmpty();
			}
			else
			{
				lockedButton.gameObject.SetActive(value: false);
				townNameBackground.enabled = true;
				townNameLabel.text = displayedTown.townName;
				levelUpButton.gameObject.SetActive(value: true);
				townPerkPointStat.gameObject.SetActive(value: true);
				fulfillmentProgress.gameObject.SetActive(value: true);
				researchButton.gameObject.SetActive(GameManager.IsGlobalQuestComplete(QuestType.SchoolForResearchPanel));
				upgradesButton.gameObject.SetActive(GameManager.IsGlobalQuestComplete(QuestType.ResearchForUpgrades));
				constructionButton.gameObject.SetActive(value: true);
				landStat.gameObject.SetActive(value: true);
				workerStat.gameObject.SetActive(value: true);
				ReloadLabels();
			}
		}
		else
		{
			displayedTown = null;
			FormatAsEmpty();
		}
		UpdateActionButtonDisplay();
	}

	public void UpdateAvailability()
	{
		UpdateTownDisplay();
	}

	private void FormatAsEmpty()
	{
		townNameLabel.text = string.Empty;
		townLevelLabel.text = string.Empty;
		levelUpButton.gameObject.SetActive(value: false);
		townPerkPointStat.gameObject.SetActive(value: false);
		fulfillmentProgress.gameObject.SetActive(value: false);
		townNameBackground.enabled = false;
		researchButton.gameObject.SetActive(value: false);
		upgradesButton.gameObject.SetActive(value: false);
		constructionButton.gameObject.SetActive(value: false);
		landStat.gameObject.SetActive(value: false);
		workerStat.gameObject.SetActive(value: false);
		ReloadLabels();
	}

	private void OnCreateButtonPressed()
	{
		if (createButton.shouldIgnoreAction)
		{
			return;
		}
		BiomeType key = GameManager.DefaultBiomeForIndex(townIndex);
		if (gm.biomeStates.TryGetValue(key, out var value) && value.isLocked)
		{
			if (!value.IsLockedButReadyToClaim())
			{
				return;
			}
			Quest q = value.PrimaryRequiredQuest();
			GameManager.Instance.ClaimQuestIndividually(q, trackUnlocks: false);
		}
		MenuManager.Instance.textEntryPanel.ShowWithDefaultText(string.Empty, "Create", OnNewTownNameEntered, OnNewTownCancelled);
	}

	private void OnTravelButtonPressed()
	{
		if (!travelButton.shouldIgnoreAction && townIndex < gm.towns.Count && gm.towns[townIndex] != null)
		{
			MenuManager.Instance.worldPanel.Hide();
			gm.LoadTownWithIndex(townIndex);
		}
	}

	private void OnClickedBackground()
	{
		if (townIndex == gm.activeTownIndex)
		{
			MenuManager.Instance.worldPanel.Hide();
			return;
		}
		if (townIndex < gm.towns.Count && gm.towns[townIndex] != null)
		{
			MenuManager.Instance.worldPanel.Hide();
			gm.LoadTownWithIndex(townIndex);
			return;
		}
		BiomeType key = GameManager.DefaultBiomeForIndex(townIndex);
		if (gm.biomeStates.TryGetValue(key, out var value) && !value.isLocked)
		{
			OnCreateButtonPressed();
		}
	}

	public void UpdateActionButtonDisplay()
	{
		bool flag = false;
		if (townIndex == gm.activeTownIndex)
		{
			travelButton.gameObject.SetActive(value: false);
			lockedButton.gameObject.SetActive(value: false);
			createButton.gameObject.SetActive(value: false);
			biomeImage.color = Color.white;
			biomeLabel.gameObject.SetActive(value: true);
			base.buttonState = CustomButtonState.Default;
			isSelected = true;
		}
		else
		{
			isSelected = false;
			if (townIndex < gm.towns.Count && gm.towns[townIndex] != null)
			{
				travelButton.gameObject.SetActive(value: true);
				lockedButton.gameObject.SetActive(value: false);
				createButton.gameObject.SetActive(value: false);
				biomeImage.color = Color.white;
				travelButton.buttonState = CustomButtonState.Default;
				biomeLabel.gameObject.SetActive(value: true);
				travelButton.gameObject.SetActive(value: true);
				base.buttonState = CustomButtonState.Default;
			}
			else
			{
				BiomeType key = GameManager.DefaultBiomeForIndex(townIndex);
				if (gm.biomeStates.TryGetValue(key, out var value) && !value.isLocked)
				{
					lockedButton.gameObject.SetActive(value: false);
					biomeLabel.gameObject.SetActive(value: true);
					biomeImage.color = Color.white;
					createButton.buttonState = CustomButtonState.BlueFlashing;
					travelButton.gameObject.SetActive(value: false);
					createButton.gameObject.SetActive(value: true);
					base.buttonState = CustomButtonState.Default;
				}
				else if (value != null && value.IsLockedButReadyToClaim())
				{
					lockedButton.gameObject.SetActive(value: false);
					biomeLabel.gameObject.SetActive(value: true);
					biomeImage.color = Color.white;
					createButton.buttonState = CustomButtonState.BlueFlashing;
					travelButton.gameObject.SetActive(value: false);
					createButton.gameObject.SetActive(value: true);
					base.buttonState = CustomButtonState.Default;
				}
				else
				{
					flag = true;
					biomeImage.color = new Color(0.7f, 0.7f, 0.7f, 0.4f);
					travelButton.gameObject.SetActive(value: false);
					lockedButton.gameObject.SetActive(value: true);
					travelButton.gameObject.SetActive(value: false);
					createButton.gameObject.SetActive(value: false);
					base.buttonState = CustomButtonState.Background;
				}
			}
		}
		travelButton.gameObject.SetActive(value: false);
		biomeLabel.color = (flag ? Color.gray : Color.white);
		foreach (ModifierIcon modifierIcon in modifierIcons)
		{
			modifierIcon.SetHidden(flag && gm.gameModifierBiomes == GameModifier.None);
		}
	}

	protected override Color GetColorForCurrentState()
	{
		if (isSelected)
		{
			return ColorManager.defaultSelection;
		}
		if (base.buttonState == CustomButtonState.Default)
		{
			return ColorManager.listItemBackground;
		}
		if (base.buttonState == CustomButtonState.Disabled)
		{
			return ColorManager.ColorForButtonState(CustomButtonState.Background);
		}
		return base.GetColorForCurrentState();
	}

	public void ReloadLabels()
	{
		UpdateActionButtonDisplay();
		if (displayedTown != null)
		{
			UpdateDisplayedXP();
			townLevelLabel.text = TextDisplay.LocalizedNumber(displayedTown.townLevel);
			levelNextLabel.text = "Next".Localized() + ":";
		}
		lockedButton.label.text = "Locked".Localized();
		createButton.label.text = "Create".Localized();
		travelButton.label.text = "Travel".Localized();
		UpdateBiome();
	}

	private void UpdateBiome()
	{
		if (displayedTown != null)
		{
			UpdateBiome(displayedTown.biomeType);
		}
		else
		{
			UpdateBiome(GameManager.DefaultBiomeForIndex(townIndex));
		}
	}

	private void UpdateBiome(BiomeType t)
	{
		cachedBiomeType = t;
		biomeLabel.text = TextDisplay.LabelForBiome(t);
	}

	public void InitializeBiome(BiomeType t)
	{
		AddPointerClickTrigger(OnClickedBackground);
		biomeButton.tooltipEntity = EntityId.FromBiome(t);
		biomeImage.sprite = IconManager.BackgroundForBiome(t);
		levelUpButton.AddPointerClickTrigger(OnLevelUpClicked);
		levelUpButton.highlightTextDelegate = HighlightTextTownLevel;
		levelUpButton.isTooltipUpdatedEverySimulationStep = true;
		fulfillmentProgress.highlightTextDelegate = FulfillmentHighlightText;
		fulfillmentProgress.buttonState = CustomButtonState.Default;
		fulfillmentProgress.progressBar.fillImage.color = ColorManager.fulfillment;
		lockedButton.tooltipEntity = EntityId.FromBiome(t);
		lockedButton.tooltipModifier = TooltipModifier.Requirements;
		lockedButton.tooltipOptions = MenuManager.Instance.lockedBiomeTooltipOptions;
		if (!Crafting.biomeCache.TryGetValue(t, out var value))
		{
			return;
		}
		foreach (BiomeModifier entityModifier in value.entityModifiers)
		{
			LayoutGroup parentGroup = modifierIconGridUnique;
			if (entityModifier.effect == BiomeModifierType.MarketDemand)
			{
				parentGroup = modifierIconGridPositive;
			}
			else if (entityModifier.effect != BiomeModifierType.UniqueBuilding && entityModifier.effect != BiomeModifierType.UniqueResource && entityModifier.effect != BiomeModifierType.UniqueRecipe && GameUtility.IsNotZero(entityModifier.multiplier))
			{
				parentGroup = ((!(entityModifier.multiplier > 1f)) ? ((!(null == modifierIconGridNegative)) ? modifierIconGridNegative : modifierIconGridPositive) : modifierIconGridPositive);
			}
			ModifierIcon modifierIcon = GetModifierIcon(parentGroup);
			modifierIcon.InitializeModifier();
			modifierIcon.LoadModifier(entityModifier);
			modifierIcon.highlightTextDelegate = modifierIcon.ModifierHighlightText;
			modifierIcon.tooltipOptions = MenuManager.Instance.centeredTooltipOptions;
			modifierIcons.Add(modifierIcon);
		}
	}

	private string HighlightTextTownLevel()
	{
		return TextDisplay.FormattedKeyValue("TownLevel", TextDisplay.LocalizedNumber(displayedTown.townLevel));
	}

	private void OnLevelUpClicked()
	{
		if (!levelUpButton.shouldIgnoreAction && displayedTown.hasRewardToClaim)
		{
			displayedTown.ClaimLevelRewards();
		}
	}

	private ModifierIcon GetModifierIcon(LayoutGroup parentGroup)
	{
		return MenuManager.GetMenuObject(MenuManager.Instance.modifierIconPrefab, parentGroup.transform).GetComponent<ModifierIcon>();
	}

	private void OnNewTownCancelled()
	{
		MenuManager.Instance.worldPanel.Show();
	}

	public void UpdateDynamicDisplay()
	{
		if (displayedTown != null)
		{
			if (GameUtility.NotEquals(displayedTown.cachedTownXPState.currentCount, lastDisplayedXP))
			{
				UpdateDisplayedXP();
			}
			workerStat.TryUpdateWithValue(GameUtility.AsFloat(displayedTown.population), GameUtility.AsFloat(displayedTown.workerState.numAvailable));
			landStat.TryUpdateWithValue(0f, GameUtility.AsFloat(displayedTown.landState.currentCount));
			townPerkPointStat.TryUpdateWithValue(0f, GameUtility.AsFloat(displayedTown.townPerkPointState.numAvailable));
			UpdateTownPerksButton();
			levelUpButton.buttonState = (displayedTown.hasRewardToClaim ? CustomButtonState.BlueFlashing : CustomButtonState.Background);
			upgradesButton.buttonState = (displayedTown.hasUpgradeToClaim ? CustomButtonState.BlueFlashing : CustomButtonState.Background);
			researchButton.buttonState = (displayedTown.hasResearchToClaim ? CustomButtonState.BlueFlashing : CustomButtonState.Background);
		}
	}

	public void UpdateSimulationDisplay()
	{
		if (displayedTown != null)
		{
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
			if (displayedTown.fulfillmentScore != lastDisplayedFulfillmentScore)
			{
				DisplayFulfillmentScore();
			}
		}
	}

	private void OnNewTownNameEntered(string s)
	{
		MenuManager.Instance.worldPanel.Hide();
		MenuManager.Instance.ClearSelections();
		Town town = new Town(GameManager.DefaultBiomeForIndex(townIndex), townIndex);
		town.townName = s;
		town.AssignDefaultTrades();
		gm.ConfirmTownIndex(townIndex);
		gm.towns[townIndex] = town;
		gm.CalcNumTowns();
		town.suppressUnlockNotifications = true;
		town.PrepareSecondaryTown();
		town.CalcPostLoadMetadata();
		town.RefreshAllTownMetadata();
		town.FillResourcesToMax();
		if (gm.isAutoAssignDefault)
		{
			foreach (BuildingState value in town.buildings.Values)
			{
				if (value.availability == BuildObjectAvailability.Available)
				{
					value.AssignDefaultAutoAssign();
				}
			}
			town.CalcAllAutoAssign();
		}
		gm.activeTownIndex = townIndex;
		gm.activeTown = gm.towns[townIndex];
		gm.FinalizeLoadedTown();
		town.suppressUnlockNotifications = false;
		GameManager.Instance.ShowRewardForCreatingBiome(town.biomeType);
	}

	public void UpdateDisplayedXP()
	{
		lastDisplayedXP = GameUtility.AsFloat(displayedTown.cachedTownXPState.currentCount);
		double num = displayedTown.levelUpCost - (double)lastDisplayedXP;
		if (num < 0.0)
		{
			num = 0.0;
		}
		StringBuilder sb = TextDisplay.sb;
		sb.Clear();
		sb.Append(TextDisplay.LocalizedNumber(num));
		xpDisplayLabel.SetText(sb);
		levelUpSlider.value = GameUtility.AsFloat((double)lastDisplayedXP / displayedTown.levelUpCost);
	}

	private void DisplayFulfillmentScore()
	{
		lastDisplayedFulfillmentScore = displayedTown.fulfillmentScore;
		int q = GameUtility.HappinessQuintileForSupplyRate(displayedTown.happinessAverage);
		fulfillmentProgress.iconImage.sprite = IconManager.SpriteForHappinessQuintile(q);
		fulfillmentProgress.primaryLabel.text = TextDisplay.LocalizedNumber(lastDisplayedFulfillmentScore);
	}

	private string FulfillmentHighlightText()
	{
		return TextDisplay.FulfillmentTooltipForTown(displayedTown);
	}

	public void UpdateTownPerksButton()
	{
		if (displayedTown.hasTownPerkAvailable)
		{
			if (gm.hasOpenedPerksPanel)
			{
				townPerkPointStat.buttonState = CustomButtonState.Default;
			}
			else
			{
				townPerkPointStat.buttonState = CustomButtonState.BlueFlashing;
			}
		}
		else
		{
			townPerkPointStat.buttonState = CustomButtonState.Background;
		}
	}

	public void OnTownPerksPressed()
	{
		MenuManager.Instance.townPerksPanel.ToggleDisplayForTown(displayedTown);
	}

	private void ClaimAllResearch()
	{
		gm.BeginTrackingUnlocks();
		foreach (ResearchState value in displayedTown.research.Values)
		{
			if (value.IsAvailable() && value.isReadyToClaim)
			{
				value.Claim();
			}
		}
		gm.ProcessMetadataQueue();
		gm.EndTrackingUnlocks();
		MenuManager.Instance.researchPanel.isTownLayoutStale = true;
	}

	private void ClaimAllUpgrades()
	{
		GameUtility.reusableUpgradeList.Clear();
		foreach (Upgrade value in displayedTown.upgrades.Values)
		{
			GameUtility.reusableUpgradeList.Add(value);
		}
		displayedTown.PurchaseAllUpgradesInList(GameUtility.reusableUpgradeList);
	}

	private void OnResearchPressed()
	{
		MenuManager.Instance.researchPanel.ToggleDisplayForTown(displayedTown);
	}

	private void OnUpgradesPressed()
	{
		MenuManager.Instance.upgradesPanel.ToggleDisplayForTown(displayedTown);
	}

	private void OnConstructionPressed()
	{
		MenuManager.Instance.buildingsPanel.ToggleDisplayForTown(displayedTown);
	}

	private string OnHoverLand()
	{
		if (displayedTown == null)
		{
			return null;
		}
		if (displayedTown.landState == null)
		{
			return null;
		}
		return string.Format(TextDisplay.LocalizedKeyValueFormat(), arg1: TextDisplay.LocalizedNumber(displayedTown.landState.numAvailable) + "/" + TextDisplay.LocalizedNumber(displayedTown.landState.maxCount), arg0: "Land".Localized());
	}

	private string OnHoverWorkers()
	{
		if (displayedTown == null)
		{
			return null;
		}
		if (displayedTown.workerState == null)
		{
			return null;
		}
		return string.Format(TextDisplay.LocalizedKeyValueFormat(), arg1: TextDisplay.LocalizedNumber(displayedTown.workerState.numAvailable) + "/" + TextDisplay.LocalizedNumber(displayedTown.workerState.currentCount), arg0: "Workers".Localized());
	}
}
