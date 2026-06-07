using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerksPanel : MenuListPanel
{
	public LabelButton resetButton;

	public TextMeshProUGUI cooldownText;

	private readonly Dictionary<PerkType, PerkListItem> perkListItems = new Dictionary<PerkType, PerkListItem>(new PerkEqualityComparer());

	public GameObject perkListItemPrefab;

	public PanelHeader panelHeader;

	public bool isCostInfoStale;

	public bool areValuesStale;

	public bool areCountsStale;

	public Image perkIconImage;

	public TextMeshProUGUI perkPointCount;

	public bool isHeaderDataStale;

	private CountableState cachedPerkPointState;

	public bool isGlobal;

	public bool hasBeenViewed;

	public TextMeshProUGUI descriptionLabel;

	private PerkListItem highlightedItem;

	private long lastDisplayedDiff;

	private TextFlashAnimation cooldownFlashAnimation;

	public override void Initialize()
	{
		base.Initialize();
		panelHeader.Initialize();
		RemoveAutoLayout();
		resetButton.AddPointerClickTrigger(OnResetClicked);
		cooldownFlashAnimation = new TextFlashAnimation(cooldownText);
		resetButton.gameObject.SetActive(value: false);
		cooldownText.gameObject.SetActive(value: false);
	}

	public override void FlagAllStaticDataStale()
	{
		base.FlagAllStaticDataStale();
		isCostInfoStale = true;
		isHeaderDataStale = true;
		areValuesStale = true;
		areCountsStale = true;
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		if (isGlobal)
		{
			cachedPerkPointState = MenuPanel.gm.questCoinState;
			{
				foreach (KeyValuePair<PerkType, PerkState> globalPerk in MenuPanel.gm.globalPerks)
				{
					primaryLayoutManager.AddItemWithHeight(globalPerk.Value, itemHeight);
				}
				return;
			}
		}
		cachedPerkPointState = displayedTown.townPerkPointState;
		foreach (KeyValuePair<PerkType, PerkState> townPerk in displayedTown.townPerks)
		{
			primaryLayoutManager.AddItemWithHeight(townPerk.Value, itemHeight);
		}
	}

	protected override void AssignKeyToItem(object key, MonoBehaviour item)
	{
		if (key is PerkState s && item is PerkListItem perkListItem)
		{
			perkListItem.LoadState(s);
			perkListItem.OnStateAssignmentChanged();
		}
	}

	protected override MonoBehaviour CreateListItemForPool()
	{
		return CreateCommonListItemForPool(perkListItemPrefab);
	}

	public override void CreateItems()
	{
		if (isGlobal)
		{
			cachedPerkPointState = MenuPanel.gm.questCoinState;
			panelHeader.iconImage.sprite = IconManager.Instance.questCoin;
			perkIconImage.sprite = IconManager.DefaultSpriteForItem(ItemType.UtilityQuestCoin);
		}
		else
		{
			panelHeader.iconImage.sprite = IconManager.Instance.experiencePointPurple;
			perkIconImage.sprite = IconManager.DefaultSpriteForItem(ItemType.UtilityPrestigePoint);
		}
		base.CreateItems();
	}

	public override void Show()
	{
		if (displayedTown != null || isGlobal)
		{
			base.Show();
			if (isGlobal)
			{
				MenuPanel.gm.hasOpenedQuestCoinsPanel = true;
				MenuManager.Instance.navigationPanel.UpdateQuestCoinsButton();
			}
			else
			{
				MenuPanel.gm.hasOpenedPerksPanel = true;
			}
			hasBeenViewed = true;
			if (isGlobal)
			{
				hasBeenViewed = true;
			}
			else
			{
				MenuManager.Instance.townStatsPanel.UpdateTownPerksButton();
			}
		}
	}

	public void UpdateHeaderData()
	{
		panelHeader.countLabel.text = TextDisplay.LocalizedNumber(cachedPerkPointState.numAvailable);
		isHeaderDataStale = false;
	}

	protected override bool ShouldItemBeValid(object obj)
	{
		if (obj is PerkState perkState)
		{
			return perkState.availability != BuildObjectAvailability.Disabled;
		}
		return false;
	}

	protected override void UpdateItemAvailability()
	{
		base.UpdateItemAvailability();
		TextDisplay.SetNumber(perkPointCount, cachedPerkPointState.currentCount);
	}

	protected override void ApplyStateAnimations()
	{
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		if (cachedPerkPointState != null)
		{
			if (cachedPerkPointState.AsEntity().TryAsItem(out var i))
			{
				panelHeader.primaryLabel.text = TextDisplay.LabelForItem(i, tryPlural: true);
			}
			else
			{
				panelHeader.primaryLabel.text = TextDisplay.LabelForEntity(cachedPerkPointState.AsEntity());
			}
			ReloadPerkDescription();
			resetButton.label.text = "Reset".Localized();
			areValuesStale = false;
		}
	}

	private void ReloadPerkDescription()
	{
		if (null != highlightedItem)
		{
			descriptionLabel.text = TextDisplay.DescriptionForPerk(highlightedItem.perkState);
		}
		else
		{
			descriptionLabel.text = string.Empty;
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		panelHeader.UpdateDynamicDisplay();
		if (isCostInfoStale)
		{
			UpdateCosts();
		}
		if (isHeaderDataStale)
		{
			UpdateHeaderData();
		}
		if (areCountsStale)
		{
			UpdateCounts();
		}
		cooldownFlashAnimation.UpdateAnimation();
		long num = ((!isGlobal) ? displayedTown.lastTownPerkResetTimestamp : MenuPanel.gm.lastGlobalPerkResetTimestamp);
		long num2 = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - num;
		if (num2 >= 72000)
		{
			num2 = 72000L;
		}
		if (num2 != lastDisplayedDiff)
		{
			lastDisplayedDiff = num2;
			long num3 = 72000 - num2;
			if ((float)num3 <= 0f)
			{
				resetButton.buttonState = CustomButtonState.Default;
				cooldownText.text = string.Empty;
			}
			else
			{
				resetButton.buttonState = CustomButtonState.Disabled;
				cooldownText.text = TextDisplay.FormattedHoursMinutesSeconds(num3);
			}
		}
		if (areValuesStale)
		{
			ReloadLabels();
		}
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
	}

	public override void UpdateStaticDisplay()
	{
		base.UpdateStaticDisplay();
		UpdateHeaderData();
		UpdateCosts();
		UpdateCounts();
	}

	public void UpdateStaticDisplayForListItem(PerkType t)
	{
		if (perkListItems.TryGetValue(t, out var value))
		{
			value.UpdateCountsAndCost();
		}
	}

	public void UpdateCounts()
	{
		foreach (KeyValuePair<PerkType, PerkListItem> perkListItem in perkListItems)
		{
			perkListItem.Value.UpdateCount();
		}
		areCountsStale = false;
	}

	public void UpdateCosts()
	{
		isCostInfoStale = false;
		foreach (KeyValuePair<PerkType, PerkListItem> perkListItem in perkListItems)
		{
			perkListItem.Value.LoadCost();
		}
	}

	public void AnimatePanelHeader()
	{
		panelHeader.AnimateCount();
	}

	public override bool ShouldBeAvailable()
	{
		return true;
	}

	public override bool IsNavigationButtonVisible()
	{
		if (isGlobal)
		{
			return MenuPanel.gm.hasEarnedQuestCoin;
		}
		return !isLocked;
	}

	public void OnHighlighted(PerkListItem listItem)
	{
		highlightedItem = listItem;
		ReloadPerkDescription();
	}

	private void OnResetClicked()
	{
		if (resetButton.shouldIgnoreAction)
		{
			cooldownFlashAnimation.Run();
		}
		else if (isGlobal)
		{
			MenuPanel.gm.ResetGlobalPerks();
		}
		else
		{
			displayedTown.ResetTownPerks();
		}
	}
}
