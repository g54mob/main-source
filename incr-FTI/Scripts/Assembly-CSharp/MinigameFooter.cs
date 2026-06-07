using TMPro;
using UnityEngine;

public class MinigameFooter : MonoBehaviour
{
	public RewardSection rewardSection;

	public RewardSection perfectionBonusSection;

	public TextMeshProUGUI totalCollectedLabel;

	public LabelButton resetButton;

	public MinigamePanel parentPanel;

	public RectTransform perfectionBonusTransform;

	public TextMeshProUGUI perfectionBonusLabel;

	public void Initialize()
	{
		rewardSection.Initialize();
		perfectionBonusSection.Initialize();
	}

	public void CreateItems(MinigamePanel p)
	{
		parentPanel = p;
		resetButton.AddPointerClickTrigger(OnClaimRewardPressed);
		resetButton.buttonState = CustomButtonState.Disabled;
	}

	public void UpdateDynamicDisplay()
	{
		rewardSection.UpdateDynamicDisplay();
		perfectionBonusSection.UpdateDynamicDisplay();
	}

	public void ReloadLabels()
	{
		perfectionBonusLabel.text = "PerfectionBonus".Localized();
		resetButton.label.text = "Reset".Localized();
		totalCollectedLabel.text = "TotalCollected".Localized();
	}

	public void OnClaimRewardPressed()
	{
		if (resetButton.allowsAction)
		{
			parentPanel.OnClaimRewardPressed();
		}
	}

	public void SetReward(ItemType t)
	{
		rewardSection.iconImage.sprite = IconManager.SpriteForItem(parentPanel.rewardItem);
		perfectionBonusSection.iconImage.sprite = IconManager.SpriteForItem(parentPanel.rewardItem);
	}

	public void ResetMinigame()
	{
		perfectionBonusTransform.gameObject.SetActive(value: false);
		resetButton.buttonState = CustomButtonState.Disabled;
		ResetRewardSection();
	}

	public void ResetRewardSection()
	{
		rewardSection.SetValue(0f);
	}

	public void SetPerfect(double amount, bool animated = true)
	{
		perfectionBonusTransform.gameObject.SetActive(value: true);
		if (animated)
		{
			perfectionBonusSection.SetValue(0f);
			perfectionBonusSection.AnimateToValue(GameUtility.AsFloat(amount));
		}
		else
		{
			perfectionBonusSection.SetValue(GameUtility.AsFloat(amount));
		}
	}
}
