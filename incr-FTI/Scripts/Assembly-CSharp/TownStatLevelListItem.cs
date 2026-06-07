using TMPro;
using UnityEngine.UI;

public class TownStatLevelListItem : MenuButton
{
	public Image iconImage;

	public TextMeshProUGUI primaryLabel;

	public ProgressBar progressBar;

	private LevelStat displayedStat;

	public LabelButton levelUpButton;

	private int displayedLevel = int.MaxValue;

	private bool lastDisplayedLevelUpState;

	public void LoadStat(LevelStat stat)
	{
		displayedStat = stat;
		iconImage.sprite = IconManager.SpriteForItem(stat.iconItem);
		levelUpButton.gameObject.SetActive(value: false);
		levelUpButton.buttonState = CustomButtonState.HighlightFlashing;
		progressBar.SetStale();
	}

	public void UpdateSimulationDisplay()
	{
		progressBar.TryUpdateDisplay(displayedStat);
		bool flag = displayedStat.progressToNextLevel >= 1f;
		if (flag != lastDisplayedLevelUpState)
		{
			lastDisplayedLevelUpState = flag;
			levelUpButton.gameObject.SetActive(flag);
			progressBar.label.gameObject.SetActive(!flag);
		}
		if (displayedStat.level != displayedLevel)
		{
			ReloadLabels();
		}
	}

	public void OnLevelClicked()
	{
	}

	public void ReloadLabels()
	{
		levelUpButton.label.text = "LevelUpButton".Localized();
		displayedLevel = displayedStat.level;
		TextDisplay.SetStatLevel(primaryLabel, displayedStat.localizationKey, displayedLevel);
	}
}
