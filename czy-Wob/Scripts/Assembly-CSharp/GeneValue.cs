public class GeneValue
{
	private float val;

	private float minVal;

	private float maxVal;

	private float defaultMaxVal;

	private float? trueValForDisplay;

	private float? trueMaxValForDisplay;

	public void SetValues(float newVal, float newMinVal, float newMaxVal, float newDefaultMaxVal, float? trueMax = null, float? trueVal = null)
	{
		val = newVal;
		minVal = newMinVal;
		maxVal = newMaxVal;
		defaultMaxVal = newDefaultMaxVal;
		trueValForDisplay = trueVal;
		trueMaxValForDisplay = trueMax;
	}

	public float GetValue()
	{
		return val;
	}

	public float GetMinValue()
	{
		return minVal;
	}

	public float GetMaxValue()
	{
		return maxVal;
	}

	public float GetDefaultMaxValue()
	{
		return defaultMaxVal;
	}

	public float? GetTrueValueForDisplay()
	{
		return trueValForDisplay;
	}

	public float? GetTrueMaxValueForDisplay()
	{
		return trueMaxValForDisplay;
	}
}
