using System.Collections.Generic;
using Coffee.UIExtensions;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class RewardPanel : MenuListPanel
{
	public TextMeshProUGUI headerLabel;

	public GameObject descriptionListItemPrefab;

	public GameObject listItemPrefab;

	public LabelButton footerButton;

	public UIParticle backgroundParticles;

	private int displayIndex;

	private ListItemPool<RewardListItem> rewardListItemPool;

	private ListItemPool<TextLabel> descriptionItemPool;

	public override void Show()
	{
		if (!IsVisible())
		{
			base.transform.localScale = Vector3.one;
			float num = 0.1f;
			base.transform.DOPunchScale(new Vector3(num, num, num), 1f, 5, 0.5f);
		}
		SoundManager.PlayRewardGain();
		base.Show();
		backgroundParticles.Clear();
		backgroundParticles.StartEmission();
		backgroundParticles.Play();
		footerButton.buttonState = CustomButtonState.BlueFlashing;
		SoundManager.PlayMenuOpen();
	}

	public override void Hide()
	{
		if (IsVisible() && GameManager.GameState == GameState.InGame)
		{
			SoundManager.PlayMenuClose();
		}
		base.Hide();
		backgroundParticles.StopEmission();
	}

	public override void Initialize()
	{
		base.Initialize();
		footerButton.AddPointerClickTrigger(OnFooterButtonClicked);
		descriptionItemPool = new ListItemPool<TextLabel>(descriptionListItemPrefab);
		rewardListItemPool = new ListItemPool<RewardListItem>(listItemPrefab);
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		footerButton.label.text = "OK".Localized();
	}

	private void ResetWithHeader(string localizationKey)
	{
		rewardListItemPool.Reset();
		descriptionItemPool.Reset();
		headerLabel.text = localizationKey.Localized();
		displayIndex = 0;
	}

	private RewardListItem GetRewardItem()
	{
		RewardListItem item = rewardListItemPool.GetItem(displayIndex, layoutGroup.transform);
		displayIndex++;
		item.ResetRewardItem();
		return item;
	}

	private TextLabel GetDescriptionItem()
	{
		TextLabel item = descriptionItemPool.GetItem(displayIndex, layoutGroup.transform);
		displayIndex++;
		return item;
	}

	private void ShowUnlockedModifiers(List<ProductionModifier> modifiers, StateManager r, ResearchType t, string localizationKey)
	{
		if (modifiers == null)
		{
			return;
		}
		foreach (ProductionModifier modifier in modifiers)
		{
			if (modifier is ProductionModifierResearch productionModifierResearch && productionModifierResearch.researchState.type == t)
			{
				RewardListItem listItem = GetListItem();
				listItem.iconImage.sprite = IconManager.SpriteForState(r);
				string arg = string.Format(TextDisplay.LocalizedTwoValueFormat(), "ProcessingSpeed".Localized(), TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
				string format = TextDisplay.LocalizedKeyValueFormat();
				listItem.primaryLabel.text = string.Format(format, TextDisplay.LabelForEntity(r.AsEntity()), arg);
				break;
			}
		}
	}

	public void ShowSpecialResearchTooltip(ResearchType t)
	{
		switch (t)
		{
		case ResearchType.InfiniteResourceRegeneration:
		{
			RewardListItem listItem3 = GetListItem();
			listItem3.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem3.primaryLabel.text = TextDisplay.FormattedKeyValue("ResourceRegen", TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteKnowledgeSpeed:
		{
			RewardListItem listItem2 = GetListItem();
			listItem2.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem2.primaryLabel.text = TextDisplay.FormattedKeyValue("KnowledgeSpeed", TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteManaReactorProductivity:
		{
			RewardListItem listItem = GetListItem();
			listItem.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem.primaryLabel.text = TextDisplay.FormattedKeyValue("ManaReactorProductivity", TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteMarketSellSpeed:
		{
			RewardListItem listItem12 = GetListItem();
			listItem12.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem12.primaryLabel.text = TextDisplay.FormattedKeyValue("MarketSellSpeed", TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteSkillGainSpeed:
		{
			RewardListItem listItem11 = GetListItem();
			listItem11.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem11.primaryLabel.text = TextDisplay.FormattedKeyValue("SkillGainSpeed", TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteCraftingSpeed:
		{
			RewardListItem listItem10 = GetListItem();
			listItem10.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem10.primaryLabel.text = TextDisplay.FormattedKeyValue("CraftingSpeed", TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteProspectingSpeed:
		{
			RewardListItem listItem9 = GetListItem();
			listItem9.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem9.primaryLabel.text = TextDisplay.FormattedKeyValue("ProspectingSpeed", TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteCultivationSpeed:
		{
			RewardListItem listItem8 = GetListItem();
			listItem8.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem8.primaryLabel.text = TextDisplay.FormattedKeyValue("CultivationSpeed", TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteNaturalResourceCapacity:
		{
			RewardListItem listItem7 = GetListItem();
			listItem7.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem7.primaryLabel.text = TextDisplay.FormattedKeyValue("NaturalResourceCapacity", TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteGoodsConsumption:
		{
			RewardListItem listItem6 = GetListItem();
			listItem6.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem6.primaryLabel.text = TextDisplay.FormattedKeyValue("GoodsConsumption", TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteOmniTempleProductivity:
		{
			string arg2 = string.Format(TextDisplay.LocalizedTwoValueFormat(), TextDisplay.LabelForBuilding(BuildingType.OmniTemple), "Productivity".Localized());
			string format2 = TextDisplay.CurrentLanguageKeyValueFormat();
			RewardListItem listItem5 = GetListItem();
			listItem5.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem5.primaryLabel.text = string.Format(format2, arg2, TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		case ResearchType.InfiniteOmnistoneValue:
		{
			string arg = string.Format(TextDisplay.LocalizedTwoValueFormat(), TextDisplay.LabelForItem(ItemType.Omnistone), "SellValue".Localized());
			string format = TextDisplay.CurrentLanguageKeyValueFormat();
			RewardListItem listItem4 = GetListItem();
			listItem4.iconImage.sprite = IconManager.SpriteForResearch(t);
			listItem4.primaryLabel.text = string.Format(format, arg, TextDisplay.SignedPercent(Research.GrowthValueForResearch(t)));
			return;
		}
		}
		foreach (RecipeState value in MenuPanel.gm.activeTown.recipes.Values)
		{
			ShowUnlockedModifiers(value.productionSpeedModifiers, value, t, "ProcessingSpeed");
			ShowUnlockedModifiers(value.productionAmountModifiers, value, t, "Productivity");
		}
		foreach (FarmingState value2 in MenuPanel.gm.activeTown.farmingItems.Values)
		{
			ShowUnlockedModifiers(value2.productionSpeedModifiers, value2, t, "ProcessingSpeed");
			ShowUnlockedModifiers(value2.productionAmountModifiers, value2, t, "Productivity");
		}
		foreach (MiningState value3 in MenuPanel.gm.activeTown.miningItems.Values)
		{
			ShowUnlockedModifiers(value3.productionSpeedModifiers, value3, t, "ProcessingSpeed");
			ShowUnlockedModifiers(value3.productionAmountModifiers, value3, t, "Productivity");
		}
		foreach (SellState value4 in MenuPanel.gm.activeTown.marketItems.Values)
		{
			ShowUnlockedModifiers(value4.productionSpeedModifiers, value4, t, "ProcessingSpeed");
			ShowUnlockedModifiers(value4.productionAmountModifiers, value4, t, "Productivity");
		}
	}

	private void TryShowRewardsOfType(List<EntityLevel> list, EntityType t)
	{
		if ((t == EntityType.Research && !GameManager.IsGlobalQuestComplete(QuestType.SchoolForResearchPanel)) || (t == EntityType.Upgrade && !GameManager.IsGlobalQuestComplete(QuestType.ResearchForUpgrades)))
		{
			return;
		}
		foreach (EntityLevel item in list)
		{
			if (item.entityId.type != t)
			{
				continue;
			}
			RewardListItem listItem = GetListItem();
			listItem.iconImage.sprite = IconManager.SpriteForEntity(item.entityId);
			ItemType i;
			if (item.entityId.type == EntityType.Research && item.level == int.MaxValue)
			{
				listItem.primaryLabel.text = TextDisplay.FormattedKeyValue("PermanentResearch", TextDisplay.LabelForEntity(item.entityId));
			}
			else if (item.entityId.TryAsItem(out i))
			{
				if (Item.IsUtility(i))
				{
					listItem.primaryLabel.text = TextDisplay.LabelForItem(i);
				}
				else
				{
					listItem.primaryLabel.text = TextDisplay.FormattedKeyValue(TextDisplay.LocalizationKeyForRewardEntity(item.entityId.type), TextDisplay.LabelForEntity(item.entityId));
				}
			}
			else if (item.level > 0)
			{
				listItem.primaryLabel.text = TextDisplay.FormattedRewardEntityWithType(item.entityId, item.level + 1);
			}
			else if (LocalizationManager.IsEnglish())
			{
				listItem.primaryLabel.text = "New " + TextDisplay.LabelForEntityType(item.entityId.type) + ": " + TextDisplay.LabelForEntity(item.entityId);
			}
			else
			{
				listItem.primaryLabel.text = TextDisplay.FormattedRewardEntityWithType(item.entityId);
			}
			if (item.entityId.UsesTooltipPanel())
			{
				listItem.titleButtonImage.raycastTarget = true;
				listItem.loadedEntity = item.entityId;
				listItem.titleButton.tooltipEntity = item.entityId;
			}
		}
	}

	public void ShowRecentUpgradePurchases()
	{
		ResetWithHeader("Upgrades");
		if (MenuPanel.gm.recentPurchasedUpgrades.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<UpgradeType, int> recentPurchasedUpgrade in MenuPanel.gm.recentPurchasedUpgrades)
		{
			RewardListItem listItem = GetListItem();
			listItem.iconImage.sprite = IconManager.SpriteForUpgrade(recentPurchasedUpgrade.Key);
			listItem.primaryLabel.text = TextDisplay.LabelForUpgradeLevel(recentPurchasedUpgrade.Key, recentPurchasedUpgrade.Value);
		}
		MenuPanel.gm.recentPurchasedUpgrades.Clear();
		ResizeHeight();
		Show();
	}

	public void ShowRecentlyUnlocked()
	{
		ResetWithHeader("Reward");
		foreach (KeyValuePair<ItemType, double> item in MenuPanel.gm.recentQuestRewards.items)
		{
			RewardListItem listItem = GetListItem();
			listItem.iconImage.sprite = IconManager.SpriteForItem(item.Key);
			listItem.primaryLabel.text = string.Format(TextDisplay.KeyValueFormatSpaced, TextDisplay.LabelForItem(item.Key), "+" + TextDisplay.LocalizedNumber(item.Value));
		}
		MenuPanel.gm.recentQuestRewards.Clear();
		foreach (EntityLevel recentRewardResult in MenuPanel.gm.recentRewardResults)
		{
			BiomeType t;
			ItemType i2;
			if (recentRewardResult.entityId.TryAsResearch(out var i))
			{
				ShowSpecialResearchTooltip(i);
			}
			else if (recentRewardResult.entityId.TryAsBiome(out t))
			{
				string format = TextDisplay.LocalizedTwoValueFormat();
				string arg = TextDisplay.LabelForBiome(t);
				int level = recentRewardResult.level;
				LocalizationManager.IsEnglish();
				string formattedLevel = TextDisplay.GetFormattedLevel(level);
				string arg2 = string.Format(format, arg, formattedLevel);
				string text = string.Format(format, "LevelUpExclamation".Localized(), arg2);
				RewardListItem listItem2 = GetListItem();
				listItem2.iconImage.sprite = IconManager.SpriteForBiome(t);
				listItem2.primaryLabel.text = text;
			}
			else if (recentRewardResult.entityId.TryAsItem(out i2))
			{
				RewardListItem listItem3 = GetListItem();
				listItem3.iconImage.sprite = IconManager.SpriteForItem(i2);
				listItem3.primaryLabel.text = string.Format(TextDisplay.KeyValueFormatSpaced, TextDisplay.LabelForItem(i2), "+" + TextDisplay.LocalizedNumber(recentRewardResult.level));
			}
		}
		MenuPanel.gm.recentRewardResults.Clear();
		foreach (EntityType item2 in Data.Instance.entityTypeHierarchy)
		{
			TryShowRewardsOfType(MenuPanel.gm.recentlyUnlockedEntities, item2);
		}
		MenuPanel.gm.recentlyUnlockedEntities.Clear();
		ResizeHeight();
		Show();
	}

	private void ResizeHeight()
	{
		int num = 0;
		foreach (Transform item in layoutGroup.transform)
		{
			if (item.gameObject.activeSelf)
			{
				num++;
			}
		}
		num = Mathf.Clamp(num, 4, 8);
		int num2 = 46;
		int num3 = 46;
		int num4 = 80;
		if (base.transform is RectTransform rt)
		{
			rt.SetHeight(num2 + num4 + num * num3);
		}
	}

	public void ShowLevelUp(Town town, int nextLevel)
	{
		ResetWithHeader("LevelUpExclamation");
		RewardListItem listItem = GetListItem();
		listItem.iconImage.sprite = IconManager.Instance.townLevel;
		listItem.primaryLabel.text = string.Format(TextDisplay.KeyValueFormatSpaced, "TownLevel".Localized(), TextDisplay.LocalizedNumber(nextLevel));
		RewardListItem listItem2 = GetListItem();
		listItem2.iconImage.sprite = IconManager.Instance.panelHarvesting;
		string text = TextDisplay.Percent(0.5f);
		listItem2.primaryLabel.text = "ResourceCapacity".Localized() + " +" + text;
		foreach (EntityLevel recentlyUnlockedEntity in MenuPanel.gm.recentlyUnlockedEntities)
		{
			RewardListItem listItem3 = GetListItem();
			listItem3.iconImage.sprite = IconManager.SpriteForEntity(recentlyUnlockedEntity.entityId);
			listItem3.primaryLabel.text = TextDisplay.FormattedKeyValue(TextDisplay.LocalizationKeyForRewardEntity(recentlyUnlockedEntity.entityId.type), TextDisplay.LabelForEntity(recentlyUnlockedEntity.entityId));
		}
		ResizeHeight();
		Show();
	}

	private RewardListItem GetListItem()
	{
		return GetRewardItem();
	}

	public void ShowTimeTokens(int totalSeconds)
	{
		ResetWithHeader("IdleGain");
		RewardListItem listItem = GetListItem();
		listItem.iconImage.sprite = IconManager.Instance.productionTime;
		if (LocalizationManager.IsEnglish())
		{
			string text = TextDisplay.FormattedHoursMinutesSeconds(totalSeconds);
			listItem.primaryLabel.text = "You were away for " + text;
		}
		else
		{
			listItem.primaryLabel.text = string.Format("TotalSecondsOffline".Localized(), TextDisplay.LocalizedNumber(totalSeconds));
		}
		float value = (float)totalSeconds / 60f;
		RewardListItem listItem2 = GetListItem();
		listItem2.iconImage.sprite = IconManager.SpriteForItem(ItemType.TimeToken);
		listItem2.primaryLabel.text = string.Format("TimeTokenEarnings".Localized(), TextDisplay.LocalizedNumber(value, round: false));
		listItem2.tooltipEntity = EntityId.FromItem(ItemType.TimeToken);
		listItem2.tooltipModifier = TooltipModifier.ShowGuide;
		listItem2.tooltipOptions = MenuManager.Instance.rewardTooltipOptions;
		if (MenuPanel.gm.timeTokenState.currentCount >= MenuPanel.gm.timeTokenState.maxCount)
		{
			string text2 = listItem2.primaryLabel.text;
			string arg = "(" + TextDisplay.FormattedKeyValue("Max", TextDisplay.LocalizedNumber(MenuPanel.gm.timeTokenState.maxCount)) + ")";
			listItem2.primaryLabel.text = string.Format(TextDisplay.LocalizedTwoValueFormat(), text2, arg);
		}
		ManuallyOpen();
	}

	private void OnFooterButtonClicked()
	{
		Hide();
	}
}
