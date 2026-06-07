using TMPro;
using UnityEngine.UI;

public class TownProgressBarItem : MenuButton
{
	private float displayedTotal = float.MinValue;

	private float displayedAvailable = float.MinValue;

	public Image iconImage;

	public TextMeshProUGUI primaryLabel;

	public TextMeshProUGUI countLabel;

	public ProgressBar progressBar;

	public void TryUpdateWithValue(float available, float max)
	{
		if (GameUtility.NotEquals(displayedTotal, max) || GameUtility.NotEquals(displayedAvailable, available))
		{
			displayedAvailable = available;
			displayedTotal = max;
			TextDisplay.SetFraction(countLabel, available, max);
			if (GameUtility.IsNotZero(max))
			{
				progressBar.slider.value = available / max;
				return;
			}
			progressBar.slider.value = 0f;
			TextDisplay.SetNumber(countLabel, 0.0);
		}
	}
}
