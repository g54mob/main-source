using UnityEngine;

public class MinMaxAttribute : PropertyAttribute
{
	public float MinLimit;

	public float MaxLimit = 1f;

	public bool DrawRangeValue;

	public MinMaxAttribute(float min, float max, bool drawRangeValue = true)
	{
		MinLimit = min;
		MaxLimit = max;
		DrawRangeValue = drawRangeValue;
	}
}
