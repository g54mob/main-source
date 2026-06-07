using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationPanel : MenuPanel
{
	public GameObject navigationButtonPrefab;

	public LayoutGroup layoutGroup;

	public LayoutGroup modalLayoutGroup;

	public readonly Dictionary<BuildingCategory, NavigationButton> recipeNavigationButtons = new Dictionary<BuildingCategory, NavigationButton>(new BuildingCategoryEqualityComparer());

	public readonly Dictionary<MenuPanelType, NavigationButton> townNavigationButtons = new Dictionary<MenuPanelType, NavigationButton>(new MenuPanelEqualityComparer());

	public readonly Dictionary<MenuPanelType, NavigationButton> worldNavigationButtons = new Dictionary<MenuPanelType, NavigationButton>(new MenuPanelEqualityComparer());

	[NonSerialized]
	public SingleSelectionManager selectionManager;

	public NavigationButton menuButton;

	public NavigationButton worldButton;

	public NavigationButton minigamesButton;

	public NavigationButton fullGameVersionButton;

	public NavigationButton rewardsButton;

	public NavigationButton timeTokensButton;

	public NavigationButton questCoinsButton;

	public NavigationButton logButton;

	[NonSerialized]
	public NavigationButton researchButton;

	[NonSerialized]
	public NavigationButton buildingsButton;

	[NonSerialized]
	public NavigationButton upgradesButton;

	private TextFlashAnimation perkProgressTextFlash;

	private TextFlashAnimation rewardsCountdownFlash;

	[NonSerialized]
	public double lastDisplayedTimeTokens = double.MinValue;

	private double lastDisplayedQuestCoins = double.MinValue;

	private int lastDisplayedTimeMode = int.MinValue;

	private long lastDisplayedRewardCountdown;

	public override void Initialize()
	{
		base.Initialize();
		menuButton.AddPointerClickTrigger(OnMenuPressed);
		menuButton.buttonState = CustomButtonState.Background;
		menuButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.GameMenu);
		menuButton.HideLabel();
		menuButton.InitializeButton();
		menuButton.slider.gameObject.SetActive(value: false);
		worldButton.AddPointerClickTrigger(OnWorldPressed);
		worldButton.buttonState = CustomButtonState.Default;
		worldButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.World);
		worldButton.HideLabel();
		worldButton.isModalPanelTrigger = true;
		worldButton.InitializeButton();
		worldButton.slider.gameObject.SetActive(value: false);
		timeTokensButton.AddPointerClickTrigger(OnTimeTokensPressed);
		timeTokensButton.buttonState = CustomButtonState.Default;
		timeTokensButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.TimeTokens);
		timeTokensButton.HideLabel();
		timeTokensButton.isModalPanelTrigger = true;
		timeTokensButton.InitializeButton();
		questCoinsButton.AddPointerClickTrigger(OnGlobalPerksPressed);
		questCoinsButton.buttonState = CustomButtonState.Default;
		questCoinsButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.Perks);
		questCoinsButton.HideLabel();
		questCoinsButton.isModalPanelTrigger = true;
		questCoinsButton.InitializeButton();
		questCoinsButton.slider.gameObject.SetActive(value: false);
		researchButton = MenuPanel.m.navigationPanel.CreateTownNavigationWithMenu(MenuPanelType.Research);
		upgradesButton = MenuPanel.m.navigationPanel.CreateTownNavigationWithMenu(MenuPanelType.Upgrades);
		buildingsButton = MenuPanel.m.navigationPanel.CreateTownNavigationWithMenu(MenuPanelType.Buildings);
		researchButton.AddPointerClickTrigger(OnResearchPressed);
		researchButton.iconImage.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Research);
		researchButton.buttonState = CustomButtonState.Default;
		researchButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.Research);
		researchButton.HideLabel();
		researchButton.isModalPanelTrigger = true;
		researchButton.InitializeButton();
		buildingsButton.AddPointerClickTrigger(OnBuildingsPressed);
		buildingsButton.iconImage.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Buildings);
		buildingsButton.buttonState = CustomButtonState.Default;
		buildingsButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.Buildings);
		buildingsButton.HideLabel();
		buildingsButton.isModalPanelTrigger = true;
		buildingsButton.InitializeButton();
		upgradesButton.AddPointerClickTrigger(OnUpgradesPressed);
		upgradesButton.iconImage.sprite = IconManager.SpriteForMenuPanel(MenuPanelType.Upgrades);
		upgradesButton.buttonState = CustomButtonState.Default;
		upgradesButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.Upgrades);
		upgradesButton.HideLabel();
		upgradesButton.isModalPanelTrigger = true;
		upgradesButton.InitializeButton();
		logButton.AddPointerClickTrigger(OnLogButtonPressed);
		logButton.buttonState = CustomButtonState.Background;
		logButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.Log);
		logButton.InitializeButton();
		logButton.HideLabel();
		logButton.isModalPanelTrigger = true;
		logButton.slider.gameObject.SetActive(value: false);
		minigamesButton.transform.parent.gameObject.SetActive(value: false);
		rewardsButton.AddPointerClickTrigger(OnRewardsPressed);
		rewardsButton.buttonState = CustomButtonState.Default;
		rewardsButton.highlightTextDelegate = () => "DailyReward".Localized();
		rewardsButton.InitializeButton();
		rewardsButton.slider.gameObject.SetActive(value: false);
		rewardsCountdownFlash = new TextFlashAnimation(rewardsButton.label);
		fullGameVersionButton.AddPointerClickTrigger(OnFullGamePressed);
		fullGameVersionButton.buttonState = CustomButtonState.Default;
		fullGameVersionButton.tooltipEntity = EntityId.FromMenuPanel(MenuPanelType.FullGame);
		fullGameVersionButton.HideLabel();
		fullGameVersionButton.isModalPanelTrigger = true;
		fullGameVersionButton.InitializeButton();
		fullGameVersionButton.slider.gameObject.SetActive(value: false);
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		foreach (NavigationButton value in recipeNavigationButtons.Values)
		{
			value.ReloadLabels();
		}
		foreach (NavigationButton value2 in worldNavigationButtons.Values)
		{
			value2.ReloadLabels();
		}
		foreach (NavigationButton value3 in townNavigationButtons.Values)
		{
			value3.ReloadLabels();
		}
		menuButton.label.text = "Menu".Localized();
	}

	public void CreateNavigationButtons()
	{
		selectionManager = new SingleSelectionManager(OnNavigationChangedByManager);
		fullGameVersionButton.transform.parent.gameObject.SetActive(value: true);
		CreateButtonWithPanel(BuildingCategory.Housing);
		CreateButtonWithPanel(BuildingCategory.Cultivation);
		CreateButtonWithPanel(BuildingCategory.Prospecting);
		CreateButtonWithPanel(BuildingCategory.Harvesting);
		CreateButtonWithPanel(BuildingCategory.Production);
		CreateButtonWithPanel(BuildingCategory.Markets);
		CreateButtonWithPanel(BuildingCategory.Trading);
		CreateButtonWithPanel(BuildingCategory.Research);
		CreateButtonWithPanel(BuildingCategory.Storage);
		LoadWorldModalNavigation(worldButton, MenuPanel.m.worldPanel);
		LoadWorldModalNavigation(menuButton, MenuPanel.m.gameMenuPanel);
		LoadWorldModalNavigation(buildingsButton, MenuPanel.m.buildingsPanel);
		LoadWorldModalNavigation(timeTokensButton, MenuPanel.m.timeTokensPanel);
		LoadWorldModalNavigation(questCoinsButton, MenuPanel.m.worldPerksPanel);
		LoadWorldModalNavigation(logButton, MenuPanel.m.logPanel);
		researchButton.animateSize = true;
		upgradesButton.animateSize = true;
		buildingsButton.animateSize = true;
	}

	protected override void UpdateItemAvailability()
	{
		base.UpdateItemAvailability();
		rewardsButton.transform.parent.gameObject.SetActive(value: false);
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (worldButton.isInAlertState)
		{
			worldButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		rewardsCountdownFlash.UpdateAnimation();
		researchButton.SetActionAvailability(!MenuPanel.gm.hasOpenedResearchPanel || displayedTown.hasResearchToClaim, useFlash: true);
		if (!MenuPanel.gm.hasOpenedUpgradesPanel)
		{
			upgradesButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		else if (displayedTown.hasUpgradeToClaim)
		{
			upgradesButton.buttonState = CustomButtonState.Default;
		}
		else
		{
			upgradesButton.buttonState = CustomButtonState.Background;
		}
		buildingsButton.SetActionAvailability(nextState: false);
		perkProgressTextFlash?.UpdateAnimation();
		long lastRewardClaimTimestamp = MenuPanel.gm.lastRewardClaimTimestamp;
		long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - lastRewardClaimTimestamp;
		if (num >= 72000)
		{
			num = 72000L;
		}
		long num2 = 72000 - num;
		long num3 = 120L;
		bool flag = true;
		if ((!(num2 <= num3 || flag)) ? (Mathf.RoundToInt((float)num / 60f) != Mathf.RoundToInt((float)lastDisplayedRewardCountdown / 60f)) : (num != lastDisplayedRewardCountdown))
		{
			lastDisplayedRewardCountdown = num;
			if ((float)num2 <= 0f)
			{
				rewardsButton.buttonState = CustomButtonState.HighlightFlashing;
				rewardsButton.label.text = string.Empty;
			}
			else
			{
				rewardsButton.buttonState = CustomButtonState.Disabled;
				if (num2 <= 120)
				{
					rewardsButton.label.text = TextDisplay.LocalizedNumber(num2) + "TimeSecondsAbbreviation".Localized();
				}
				else
				{
					rewardsButton.label.text = TextDisplay.FormattedHoursMinutesSeconds(num2);
				}
			}
		}
		double num4 = MenuPanel.gm.DisplayedTimeTokens();
		if (GameUtility.NotEquals(lastDisplayedTimeTokens, num4) || lastDisplayedTimeMode != TimeManager.timeMode)
		{
			UpdateTimeTokensButton(num4);
		}
		double numAvailable = MenuPanel.gm.questCoinState.numAvailable;
		if (GameUtility.NotEquals(lastDisplayedQuestCoins, numAvailable))
		{
			UpdateQuestCoinsButton();
		}
	}

	private void OnNavigationChangedByManager(EntityId id, bool nextState)
	{
		if (id.TryAsBuildingCategory(out var c))
		{
			ProductionListPanelCombined combinedProductionPanel = MenuManager.Instance.combinedProductionPanel;
			NavigationButton value;
			if (nextState)
			{
				combinedProductionPanel.ClearAllSearchProperties();
				combinedProductionPanel.SetCategoryFilter(c);
				combinedProductionPanel.TrySetRootFromCategory(c);
				MenuPanel.m.OnSearchPropertiesChanged();
				combinedProductionPanel.isItemAvailabilityStale = true;
				combinedProductionPanel.PerformUpdateItemAvailability();
			}
			else if (recipeNavigationButtons.TryGetValue(c, out value))
			{
				value.RemoveSelection();
			}
		}
	}

	public override void ResetPanel()
	{
		base.ResetPanel();
		foreach (KeyValuePair<BuildingCategory, NavigationButton> recipeNavigationButton in recipeNavigationButtons)
		{
			recipeNavigationButton.Value.SetAlertState(nextState: false);
			recipeNavigationButton.Value.gameObject.SetActive(value: false);
		}
		foreach (KeyValuePair<MenuPanelType, NavigationButton> worldNavigationButton in worldNavigationButtons)
		{
			worldNavigationButton.Value.SetAlertState(nextState: false);
			worldNavigationButton.Value.transform.parent.gameObject.SetActive(value: false);
		}
		foreach (KeyValuePair<MenuPanelType, NavigationButton> townNavigationButton in townNavigationButtons)
		{
			townNavigationButton.Value.SetAlertState(nextState: false);
			townNavigationButton.Value.transform.parent.gameObject.SetActive(value: false);
		}
		selectionManager?.ClearSelection();
		Hide();
	}

	private void LoadWorldModalNavigation(NavigationButton b, MenuPanel p)
	{
		worldNavigationButtons[p.panelType] = b;
		b.animateSize = false;
		b.LoadMenu(p.panelType, includeNav: false);
	}

	public NavigationButton CreateTownNavigationWithMenu(MenuPanelType p)
	{
		NavigationButton component = MenuManager.GetMenuObject(navigationButtonPrefab, modalLayoutGroup.transform).GetComponent<NavigationButton>();
		component.buttonState = CustomButtonState.Background;
		component.InitializeButton();
		component.animateSize = true;
		townNavigationButtons[p] = component;
		component.LoadMenu(p, includeNav: false);
		return component;
	}

	private void CreateButtonWithPanel(BuildingCategory category)
	{
		NavigationButton component = MenuManager.GetMenuObject(navigationButtonPrefab, layoutGroup.transform).GetComponent<NavigationButton>();
		component.buttonState = CustomButtonState.Background;
		component.InitializeButton();
		component.LoadSelectionManager(selectionManager);
		component.animateSize = true;
		recipeNavigationButtons[category] = component;
		component.LoadCategory(category);
	}

	public void SetButtonVisibilityForPanel(BuildingCategory c)
	{
		if (!recipeNavigationButtons.TryGetValue(c, out var value))
		{
			return;
		}
		bool active = false;
		switch (c)
		{
		case BuildingCategory.Trading:
			active = GameManager.IsGlobalQuestComplete(QuestType.SecondTownForTradingPost);
			break;
		case BuildingCategory.Housing:
		case BuildingCategory.Production:
		case BuildingCategory.Markets:
		case BuildingCategory.Harvesting:
		{
			if (displayedTown.buildings.TryGetValue(BuildingType.LumberMill, out var value2) && value2.availability == BuildObjectAvailability.Available)
			{
				active = true;
			}
			break;
		}
		default:
			foreach (BuildingState value3 in displayedTown.buildings.Values)
			{
				_ = value3.buildingDef.category;
				if (value3.buildingDef.category == c && value3.availability == BuildObjectAvailability.Available)
				{
					active = true;
					break;
				}
			}
			break;
		}
		value.gameObject.SetActive(active);
	}

	public void SetButtonVisibilityForCategory(BuildingCategory c, bool isVisible)
	{
		if (recipeNavigationButtons.TryGetValue(c, out var value))
		{
			value.gameObject.SetActive(isVisible);
		}
	}

	public void SetButtonVisibilityForPanel(MenuPanelType p, bool isVisible)
	{
		NavigationButton value2;
		if (worldNavigationButtons.TryGetValue(p, out var value))
		{
			if (MenuPanel.gm.gameState == GameState.InGame && isVisible && !value.gameObject.activeInHierarchy)
			{
				if (p == MenuPanelType.Perks)
				{
					value.SetAlertState(nextState: true);
				}
				else
				{
					value.SetAlertState(nextState: true);
				}
			}
			value.transform.parent.gameObject.SetActive(isVisible);
		}
		else if (townNavigationButtons.TryGetValue(p, out value2))
		{
			if (MenuPanel.gm.gameState == GameState.InGame && isVisible && !value2.gameObject.activeInHierarchy)
			{
				value2.SetAlertState(nextState: true);
			}
			value2.gameObject.SetActive(isVisible);
		}
		if (isVisible && !IsVisible())
		{
			Show();
		}
	}

	public bool HasAlertForPanel(MenuPanel p)
	{
		if (worldNavigationButtons.TryGetValue(p.panelType, out var value))
		{
			return value.isInAlertState;
		}
		return false;
	}

	public void CalcAlertForPanel(MenuPanel p)
	{
		if (!p.skipAlert)
		{
			if (p.alertStateSelf && p.IsVisible() && !p.ShouldBeInAlertState())
			{
				p.alertStateSelf = false;
			}
			SetAlertForPanel(p, p.alertStateSelf);
		}
	}

	public void SetAlertForPanel(MenuPanel p, bool nextState)
	{
		NavigationButton value2;
		if (worldNavigationButtons.TryGetValue(p.panelType, out var value))
		{
			value.SetAlertState(nextState);
		}
		else if (townNavigationButtons.TryGetValue(p.panelType, out value2))
		{
			value2.SetAlertState(nextState);
		}
	}

	public void SelectBuildingCategory(BuildingCategory t, bool sendEvent = true)
	{
		NavigationButton value;
		if (t == BuildingCategory.None)
		{
			selectionManager.ClearSelection();
			MenuManager.Instance.combinedProductionPanel.ClearAllSearchProperties();
		}
		else if (recipeNavigationButtons.TryGetValue(t, out value))
		{
			value.PerformSelection(sendEvent);
		}
	}

	public void SelectPanel(MenuPanelType t)
	{
		if (t == MenuPanelType.None)
		{
			t = MenuPanelType.All;
		}
		switch (t)
		{
		case MenuPanelType.CombinedProduction:
			SelectBuildingCategory(BuildingCategory.Production);
			return;
		case MenuPanelType.Recipes:
			SelectBuildingCategory(BuildingCategory.Production);
			return;
		case MenuPanelType.Harvesting:
			SelectBuildingCategory(BuildingCategory.Harvesting);
			return;
		case MenuPanelType.Cultivation:
			SelectBuildingCategory(BuildingCategory.Cultivation);
			return;
		case MenuPanelType.Prospecting:
			SelectBuildingCategory(BuildingCategory.Prospecting);
			return;
		case MenuPanelType.Markets:
			SelectBuildingCategory(BuildingCategory.Markets);
			return;
		case MenuPanelType.Trading:
			SelectBuildingCategory(BuildingCategory.Trading);
			return;
		case MenuPanelType.All:
			SelectBuildingCategory(BuildingCategory.None);
			return;
		}
		NavigationButton value2;
		if (worldNavigationButtons.TryGetValue(t, out var value))
		{
			value.PerformSelection();
		}
		else if (townNavigationButtons.TryGetValue(t, out value2))
		{
			value2.PerformSelection();
		}
	}

	public MenuPanelType MenuPanelForNavCode(int navCode)
	{
		return navCode switch
		{
			1 => MenuPanelType.Clickables, 
			2 => MenuPanelType.Buildings, 
			3 => MenuPanelType.Harvesting, 
			4 => MenuPanelType.Recipes, 
			5 => MenuPanelType.Cultivation, 
			6 => MenuPanelType.Prospecting, 
			7 => MenuPanelType.Markets, 
			8 => MenuPanelType.Trading, 
			9 => MenuPanelType.Research, 
			0 => MenuPanelType.Upgrades, 
			_ => MenuPanelType.None, 
		};
	}

	public void TryNavigate(int navCode)
	{
		MenuPanelType key = MenuPanelForNavCode(navCode);
		if (MenuPanel.m.menuPanels.TryGetValue(key, out var value) && !value.isLocked)
		{
			SelectPanel(value.panelType);
		}
	}

	public void UpdateTimeTokensButton(double roundedAmount)
	{
		lastDisplayedTimeTokens = roundedAmount;
		_ = TimeManager.timeMode;
		timeTokensButton.iconImage.sprite = IconManager.SpriteForTimeMode(TimeManager.timeMode);
		lastDisplayedTimeMode = TimeManager.timeMode;
		UpdateTimeTokensButtonState();
		if (lastDisplayedTimeTokens >= 1.0)
		{
			timeTokensButton.slider.value = GameUtility.AsTruncatedFloat(MenuPanel.gm.timeTokenState.currentCount / MenuPanel.gm.timeTokenState.maxCount);
		}
		if (lastDisplayedTimeTokens >= 1.0 && TimeManager.timeMode >= 0)
		{
			timeTokensButton.slider.gameObject.SetActive(value: true);
			timeTokensButton.labelBackground.enabled = true;
			timeTokensButton.ShowLabel();
			TextDisplay.SetNumber(timeTokensButton.label, lastDisplayedTimeTokens);
		}
		else
		{
			timeTokensButton.slider.gameObject.SetActive(value: false);
			timeTokensButton.labelBackground.enabled = false;
			timeTokensButton.label.text = string.Empty;
			timeTokensButton.HideLabel();
		}
	}

	public void UpdateTimeTokensButtonState()
	{
		if (lastDisplayedTimeTokens >= MenuPanel.gm.timeTokenState.maxCount && !MenuManager.Instance.timeTokensPanel.hasBeenViewed)
		{
			timeTokensButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		else if (TimeManager.timeMode < 0)
		{
			timeTokensButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		else
		{
			timeTokensButton.SetActionAvailability(lastDisplayedTimeTokens >= 1.0);
		}
	}

	public void UpdateQuestCoinsButton()
	{
		if (MenuPanel.gm.hasGlobalPerkAvailable)
		{
			if (!MenuPanel.gm.hasOpenedQuestCoinsPanel && MenuPanel.gm.questCoinState.currentCount >= 5.0)
			{
				questCoinsButton.buttonState = CustomButtonState.HighlightFlashing;
			}
			else
			{
				questCoinsButton.buttonState = CustomButtonState.Default;
			}
		}
		else
		{
			questCoinsButton.buttonState = CustomButtonState.Background;
		}
		double value = (lastDisplayedQuestCoins = MenuPanel.gm.questCoinState.numAvailable);
		questCoinsButton.ShowLabel();
		TextDisplay.SetNumber(questCoinsButton.label, value);
	}

	public void OnMenuPressed()
	{
		MenuManager.Instance.ShowGameMenu();
	}

	public void OnWorldPressed()
	{
		worldButton.buttonState = CustomButtonState.Default;
		MenuPanel.m.worldPanel.ToggleDisplay();
	}

	public void OnLogButtonPressed()
	{
		MenuPanel.m.logPanel.ToggleDisplayForTown(displayedTown);
	}

	public void OnResearchPressed()
	{
		MenuPanel.m.researchPanel.ToggleDisplayForTown(displayedTown);
	}

	public void OnBuildingsPressed()
	{
		MenuPanel.m.buildingsPanel.ToggleDisplayForTown(displayedTown);
	}

	public void OnUpgradesPressed()
	{
		MenuPanel.m.upgradesPanel.ToggleDisplayForTown(displayedTown);
	}

	public void OnRewardsPressed()
	{
		if (rewardsButton.shouldIgnoreAction)
		{
			rewardsCountdownFlash.Run();
		}
		else
		{
			MenuPanel.gm.ClaimRewards();
		}
	}

	public void OnMinigamesPressed()
	{
		MenuPanel.m.minigameSelectionPanel.ManuallyOpen();
	}

	public void OnFullGamePressed()
	{
		MenuPanel.m.fullGameVersionPanel.ManuallyOpen();
	}

	private void OnTimeTokensPressed()
	{
		MenuPanel.m.timeTokensPanel.ToggleDisplay();
	}

	public void OnGlobalPerksPressed()
	{
		MenuPanel.m.worldPerksPanel.ToggleDisplay();
	}
}
