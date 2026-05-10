using UnityEngine.UI;

public class CanvasScalerWithMultiplier : CanvasScaler
{
	private const float kLogBase = 2f;

	private float CalculateBseScaleFactorForScreenSize()
	{
		return 0f;
	}

	protected override void HandleScaleWithScreenSize()
	{
	}
}
