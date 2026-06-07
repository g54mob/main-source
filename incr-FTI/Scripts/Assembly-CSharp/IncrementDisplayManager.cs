using TMPro;

public class IncrementDisplayManager
{
	private readonly TextMeshProUGUI decreaseLabel;

	private readonly TextMeshProUGUI increaseLabel;

	private int lastDisplayedMultiple;

	public bool hideLabelWhenDefault;

	public IncrementDisplayManager(TextMeshProUGUI increase, TextMeshProUGUI decrease)
	{
		increaseLabel = increase;
		decreaseLabel = decrease;
	}

	public void UpdateDynamicDisplay(int incrementValue)
	{
		if (incrementValue != lastDisplayedMultiple)
		{
			lastDisplayedMultiple = incrementValue;
			TextDisplay.FormatDecreaseLabel(decreaseLabel, lastDisplayedMultiple, hideLabelWhenDefault);
			TextDisplay.FormatIncreaseLabel(increaseLabel, lastDisplayedMultiple, hideLabelWhenDefault);
		}
	}
}
