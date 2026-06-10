using UnityEngine;

public static class BiteIndicatorTimingValidator
{
	public static void ValidateTimingWindow(float reactionTime, float perfectCatchTimeWindow)
	{
		float num = 0.4f;
		float num2 = 0.5f;
		float num3 = reactionTime * num;
		float num4 = reactionTime * num2;
		float num5 = ((perfectCatchTimeWindow > 0f) ? (1f + perfectCatchTimeWindow) : 1f);
		float num6 = num3;
		float a = num4 * num5;
		a = Mathf.Min(a, reactionTime * 0.9f);
		Debug.Log("=== TIMING VALIDATION ===");
		Debug.Log($"Reaction Time: {reactionTime}s");
		Debug.Log($"Perfect Catch Time Window: {perfectCatchTimeWindow}");
		Debug.Log($"Perfect Window Start: {num6}s ({num6 / reactionTime * 100f:F1}%)");
		Debug.Log($"Perfect Window End: {a}s ({a / reactionTime * 100f:F1}%)");
		Debug.Log($"Perfect Window Duration: {a - num6}s");
		Debug.Log($"Window Scale Factor: {num5}");
	}
}
