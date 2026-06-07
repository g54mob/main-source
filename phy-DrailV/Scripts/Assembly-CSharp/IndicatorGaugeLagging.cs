using UnityEngine;

public class IndicatorGaugeLagging : IndicatorGauge
{
	public float updateThreshold = 0.001f;

	public float smoothTime = 0.2f;

	private bool needInitialValue = true;

	private float targetValue;

	private float previousValue;

	protected override void OnValueSet()
	{
		targetValue = value;
		if (needInitialValue)
		{
			previousValue = value;
			needInitialValue = false;
			SetNeedleRotation(value);
		}
		else
		{
			value = previousValue;
		}
	}

	private void Update()
	{
		float num = targetValue - value;
		if (!assumeIsPaused && Mathf.Abs(num) > updateThreshold)
		{
			float num2 = num / smoothTime;
			previousValue = (value += num2 * Time.deltaTime);
			SetNeedleRotation(value);
			FireValueChanged();
		}
	}
}
