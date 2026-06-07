using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyListItem : SelectableButton
{
	public ConsumableState itemState;

	public Image iconImage;

	public TextMeshProUGUI countLabel;

	public TextMeshProUGUI rateLabel;

	private double lastDisplayedValue = double.MaxValue;

	private double lastDisplayedRate = double.MaxValue;

	public void UpdateSimulationDisplay()
	{
		if (itemState == null)
		{
			Debug.LogError("null itemstate on currency item");
			return;
		}
		double a = itemState.currentCount;
		if (itemState.frameIsLimitingInput && itemState.perSecondAttemptedDelta < 0.0)
		{
			a = 0.0;
		}
		if (GameUtility.NotEquals(a, lastDisplayedValue))
		{
			lastDisplayedValue = a;
			TextDisplay.SetNumber(countLabel, lastDisplayedValue);
		}
		if (GameUtility.NotEquals(lastDisplayedRate, itemState.perSecondAttemptedDelta))
		{
			lastDisplayedRate = itemState.perSecondAttemptedDelta;
			TextDisplay.SetRate(rateLabel, GameUtility.AsFloat(lastDisplayedRate));
		}
	}

	public void LoadState(ConsumableState state)
	{
		itemState = state;
		iconImage.sprite = IconManager.SpriteForState(state);
		tooltipModifier = TooltipModifier.ShowProductionDetails;
	}
}
