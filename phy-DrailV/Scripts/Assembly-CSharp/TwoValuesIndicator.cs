using UnityEngine;

public class TwoValuesIndicator : MonoBehaviour
{
	public IndicatorGauge currentIndicator;

	public IndicatorGauge targetIndicator;

	public void UpdateIndicator(float currentMinValue, float currentMaxValue, float currentValue, float unitsToBuy)
	{
		currentIndicator.minValue = currentMinValue;
		currentIndicator.maxValue = currentMaxValue;
		currentIndicator.Value = currentValue;
		targetIndicator.minValue = 0f;
		targetIndicator.maxValue = currentIndicator.maxValue - currentIndicator.Value;
		targetIndicator.minAngle = Mathf.Lerp(currentIndicator.minAngle, currentIndicator.maxAngle, currentIndicator.GetNormalizedValue());
		targetIndicator.maxAngle = currentIndicator.maxAngle;
		targetIndicator.Value = unitsToBuy;
	}

	public float GetTotalValue()
	{
		return currentIndicator.Value + targetIndicator.Value;
	}
}
