using System;
using TMPro;
using UnityEngine;

public class MinigameHeader : MonoBehaviour
{
	public TownStatLevelListItem xpLevelDisplay;

	public CapacityRegion energyCapacityRegion;

	public CapacityRegion rewardCapacityRegion;

	public MinigamePanelParent parentPanel;

	public TextMeshProUGUI yieldLabel;

	public ItemType rewardItem;

	private ItemState rewardState;

	private TextFlashAnimation energyFlashAnimation;

	public void Initialize()
	{
		energyFlashAnimation = new TextFlashAnimation(energyCapacityRegion.label);
	}

	public void LoadPanel(MinigamePanelParent p)
	{
		parentPanel = p;
		energyCapacityRegion.iconImage.sprite = IconManager.SpriteForItem(parentPanel.energyTracker.energyType);
		xpLevelDisplay.LoadStat(p.levelStat);
		xpLevelDisplay.levelUpButton.AddPointerClickTrigger(LevelUp);
	}

	private void LevelUp()
	{
		GameManager.Instance.MinigameLevelUp(parentPanel);
		ReloadLabels();
	}

	public void UpdateSimulationDisplay()
	{
		xpLevelDisplay.UpdateSimulationDisplay();
	}

	public void UpdateDynamicDisplay()
	{
		EnergyTracker energyTracker = parentPanel.energyTracker;
		energyCapacityRegion.TryUpdateDisplay(Math.Floor(energyTracker.currentCount), energyTracker.maxCount);
		energyFlashAnimation.UpdateAnimation();
		if (rewardState != null)
		{
			rewardCapacityRegion.TryUpdateDisplay(rewardState);
		}
	}

	public void RunEnergyFlashAnimation()
	{
		energyFlashAnimation.Run();
	}

	public void OnActiveTownChanged()
	{
		UpdateRewardCache();
	}

	public void SetReward(ItemType t)
	{
		rewardItem = t;
		UpdateRewardCache();
		rewardCapacityRegion.iconImage.sprite = IconManager.SpriteForItem(t);
	}

	private void UpdateRewardCache()
	{
		if (GameManager.Instance.activeTown != null && GameManager.Instance.activeTown.inventory.TryGetValue(rewardItem, out var value))
		{
			rewardState = value;
		}
	}

	public void ReloadLabels()
	{
		if (null == parentPanel)
		{
			Debug.LogError("Null parent panel on minigame header");
			return;
		}
		string localizedValue = $"{parentPanel.yieldBaselineUpgraded} " + TextDisplay.Multiplier + TextDisplay.LocalizedNumber(parentPanel.yieldMultiplier);
		yieldLabel.text = TextDisplay.FormattedKeyValue("Yield", localizedValue);
	}
}
