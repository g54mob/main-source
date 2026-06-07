using TMPro;
using UnityEngine;

public class WorldLevelListItem : MonoBehaviour
{
	public TextMeshProUGUI primaryLabel;

	public TextMeshProUGUI levelLabel;

	public ProgressBar progressBar;

	public LabelButton levelUpButton;

	private LevelStat displayedStat;

	private int displayedLevel = int.MinValue;

	public void LoadState(LevelStat stat)
	{
		displayedStat = stat;
		progressBar.SetStale();
	}

	public void UpdateLabels()
	{
		if (displayedStat != null)
		{
			if (displayedStat.localizationKey != null)
			{
				primaryLabel.text = displayedStat.localizationKey.Localized();
			}
			else
			{
				primaryLabel.text = string.Empty;
			}
		}
	}

	public void UpdateDynamicDisplay()
	{
		if (displayedStat.level != displayedLevel)
		{
			displayedLevel = displayedStat.level;
			TextDisplay.FormatLevelAbbreviation(levelLabel, displayedLevel);
		}
		progressBar.TryUpdateDisplay(displayedStat.points - (double)displayedStat.currentLevelFloor, displayedStat.currentLevelCeil - displayedStat.currentLevelFloor);
		if (displayedStat.progressToNextLevel >= 1f)
		{
			levelUpButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		else
		{
			levelUpButton.buttonState = CustomButtonState.Disabled;
		}
	}
}
