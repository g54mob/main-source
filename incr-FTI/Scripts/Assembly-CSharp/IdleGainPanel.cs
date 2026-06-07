using TMPro;
using UnityEngine;

public class IdleGainPanel : MenuListPanel
{
	public TextMeshProUGUI headerLabel;

	public CapacityRegion processingProgressBar;

	public LabelButton confirmButton;

	public GameObject listItemPrefab;

	private int displayIndex;

	public override void Initialize()
	{
		base.Initialize();
		confirmButton.AddPointerClickTrigger(OnConfirmPressed);
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		headerLabel.text = "ProcessingIdleProgress".Localized();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if ((float)TimeManager.bonusTicksRemaining > 0f)
		{
			float value = 1f - (float)TimeManager.bonusTicksRemaining / (float)TimeManager.bonusTicksToApply;
			processingProgressBar.slider.value = value;
			_ = TimeManager.bonusTicksToApply;
			_ = TimeManager.bonusTicksRemaining;
			float num = (float)TimeManager.bonusTicksRemaining / (float)TimeManager.bonusTicksToApply;
			int num2 = Mathf.RoundToInt((1f - num) * (float)TimeManager.totalEarnedSeconds);
			processingProgressBar.label.text = TextDisplay.FormattedHoursMinutesSeconds(num2);
		}
		else
		{
			panelCategory = PanelCategory.DismissableModal;
			int totalEarnedSeconds = TimeManager.totalEarnedSeconds;
			confirmButton.buttonState = CustomButtonState.HighlightFlashing;
			processingProgressBar.slider.value = 1f;
			processingProgressBar.label.text = TextDisplay.FormattedHoursMinutesSeconds(totalEarnedSeconds);
		}
	}

	private void ResetWithHeader(string localizationKey)
	{
		displayIndex = 0;
		foreach (Transform item in layoutGroup.transform)
		{
			item.gameObject.SetActive(value: false);
		}
	}

	public void SetReadyToConfirm()
	{
		confirmButton.buttonState = CustomButtonState.HighlightFlashing;
	}

	private void OnConfirmPressed()
	{
		if (!confirmButton.shouldIgnoreAction)
		{
			ManuallyClose();
		}
	}

	public void AddLogResearchComplete(ResearchState rs)
	{
		RewardListItem listItem = GetListItem();
		string arg = TextDisplay.FormattedKeyValue("ResearchComplete", rs.GetLabel());
		string format = TextDisplay.LocalizedTwoValueFormat();
		listItem.primaryLabel.text = string.Format(format, arg, "(" + rs.parentTown.townName + ")");
		listItem.iconImage.sprite = IconManager.SpriteForResearch(rs.type);
		SoundManager.isNotificationSoundQueued = true;
	}

	public void AddLogLevelUp(Town town)
	{
		string format = TextDisplay.LocalizedTwoValueFormat();
		string text;
		if (LocalizationManager.IsEnglish())
		{
			text = "Town Level Up! " + town.townName + " reached Level " + TextDisplay.LocalizedNumber(town.townLevel);
		}
		else
		{
			string formattedLevel = TextDisplay.GetFormattedLevel(town.townLevel);
			string arg = string.Format(format, town.townName, formattedLevel);
			text = string.Format(format, "LevelUpExclamation".Localized(), arg);
		}
		RewardListItem listItem = GetListItem();
		listItem.iconImage.sprite = IconManager.SpriteForBiome(town.biomeType);
		listItem.primaryLabel.text = text;
		SoundManager.isNotificationSoundQueued = true;
	}

	private RewardListItem GetListItem()
	{
		if (displayIndex < layoutGroup.transform.childCount)
		{
			Transform child = layoutGroup.transform.GetChild(displayIndex);
			displayIndex++;
			child.gameObject.SetActive(value: true);
			RewardListItem component = child.GetComponent<RewardListItem>();
			component.iconImage.enabled = true;
			component.ResetRewardItem();
			return component;
		}
		displayIndex++;
		GameObject menuObject = MenuManager.GetMenuObject(listItemPrefab, layoutGroup.transform);
		menuObject.gameObject.SetActive(value: true);
		RewardListItem component2 = menuObject.GetComponent<RewardListItem>();
		component2.ResetRewardItem();
		return component2;
	}
}
