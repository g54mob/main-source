using UnityEngine;

public class TimingValidationRunner
{
	public static void RunValidation()
	{
		Debug.Log("=== BITE INDICATOR TIMING VALIDATION ===");
		float[] array = new float[4] { 0.7f, 1f, 1.5f, 2f };
		float[] array2 = new float[4] { 0f, 0.1f, 0.2f, 0.5f };
		float[] array3 = array;
		foreach (float reactionTime in array3)
		{
			float[] array4 = array2;
			foreach (float perfectCatchTimeWindow in array4)
			{
				ValidateTimingWindow(reactionTime, perfectCatchTimeWindow);
				Debug.Log("");
			}
		}
	}

	private static void ValidateTimingWindow(float reactionTime, float perfectCatchTimeWindow)
	{
		float num = 0.4f;
		float num2 = 0.5f;
		float num3 = reactionTime * num;
		float num4 = reactionTime * num2;
		float num5 = ((perfectCatchTimeWindow > 0f) ? (1f + perfectCatchTimeWindow) : 1f);
		float num6 = num3;
		float a = num4 * num5;
		a = Mathf.Min(a, reactionTime * 0.9f);
		Debug.Log($"Reaction Time: {reactionTime}s, Perfect Catch Window: {perfectCatchTimeWindow}");
		Debug.Log($"  -> Perfect Window: {num6:F2}s - {a:F2}s ({a - num6:F2}s duration)");
		Debug.Log($"  -> Window as percentage: {num6 / reactionTime * 100f:F1}% - {a / reactionTime * 100f:F1}%");
		if (num6 >= a)
		{
			Debug.LogError("  -> ERROR: Invalid window - start >= end!");
		}
		if (a > reactionTime)
		{
			Debug.LogError("  -> ERROR: Window exceeds reaction time!");
		}
		if (num6 < 0f)
		{
			Debug.LogError("  -> ERROR: Negative window start!");
		}
	}
}
