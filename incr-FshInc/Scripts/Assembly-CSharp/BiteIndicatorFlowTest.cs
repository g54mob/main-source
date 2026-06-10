using UnityEngine;

public class BiteIndicatorFlowTest : MonoBehaviour
{
	[Header("Test Components")]
	public FishingManager fishingManager;

	public BiteIndicatorMinigame biteIndicator;

	[Header("Test Settings")]
	public bool logStateChanges = true;

	public bool logTimingDetails = true;

	private void Update()
	{
	}

	public void TestCompleteFlow()
	{
		if (fishingManager == null)
		{
			Debug.LogError("FishingManager reference is missing!");
			return;
		}
		Debug.Log("=== TESTING COMPLETE FISHING FLOW ===");
		LogCurrentState("Initial");
		TestBiteIndicatorIntegration();
	}

	private void TestBiteIndicatorIntegration()
	{
		Debug.Log("Testing Bite Indicator Integration...");
		if (fishingManager.biteIndicatorMinigame == null)
		{
			Debug.LogError("FishingManager.biteIndicatorMinigame is not assigned!");
			return;
		}
		TestTimingCalculations();
		TestStateFlow();
	}

	private void TestTimingCalculations()
	{
		if (!logTimingDetails)
		{
			return;
		}
		Debug.Log("=== TIMING CALCULATIONS TEST ===");
		float[] array = new float[5] { 0.5f, 0.7f, 1f, 1.5f, 2f };
		float[] array2 = new float[4] { 0f, 0.1f, 0.2f, 0.5f };
		float[] array3 = array;
		foreach (float reactionTime in array3)
		{
			float[] array4 = array2;
			foreach (float perfectWindow in array4)
			{
				ValidateTimingWindow(reactionTime, perfectWindow);
			}
		}
	}

	private void ValidateTimingWindow(float reactionTime, float perfectWindow)
	{
		float num = 0.4f;
		float num2 = 0.5f;
		float num3 = reactionTime * num;
		float num4 = reactionTime * num2;
		float num5 = ((perfectWindow > 0f) ? (1f + perfectWindow) : 1f);
		float num6 = num3;
		float a = num4 * num5;
		a = Mathf.Min(a, reactionTime * 0.9f);
		bool flag = num6 < a && num6 >= 0f && a <= reactionTime;
		if (logTimingDetails)
		{
			string text = (flag ? "✓" : "✗");
			Debug.Log($"{text} RT:{reactionTime}s PW:{perfectWindow} → Window:{num6:F2}s-{a:F2}s Duration:{a - num6:F2}s");
		}
		if (!flag)
		{
			Debug.LogError($"Invalid timing window: RT={reactionTime}, PW={perfectWindow}, Start={num6}, End={a}");
		}
	}

	private void TestStateFlow()
	{
		Debug.Log("=== STATE FLOW VALIDATION ===");
		string[] array = new string[7] { "Idle", "Casting", "WaitingForBite", "BiteIndicator", "Reacting", "ReelingIn", "FishCaught/FishLost" };
		Debug.Log("Expected state flow:");
		for (int i = 0; i < array.Length; i++)
		{
			string arg = ((i < array.Length - 1) ? " → " : "");
			Debug.Log($"  {i + 1}. {array[i]}{arg}");
		}
		Debug.Log("\nAuto-hook bypass: BiteIndicator and Reacting states are skipped");
		Debug.Log("  WaitingForBite → (auto-hook) → ReelingIn");
	}

	private void LogCurrentState(string context)
	{
		if (logStateChanges && fishingManager != null)
		{
			Debug.Log("[" + context + "] Fishing Manager State Logged");
		}
	}

	public void ResetTest()
	{
		Debug.Log("=== RESETTING TEST ===");
		if (biteIndicator != null && biteIndicator.gameObject.activeInHierarchy)
		{
			biteIndicator.StopMinigame();
		}
		Debug.Log("Test reset complete");
	}

	public void TestPerfectCatchBonus()
	{
		Debug.Log("=== PERFECT CATCH BONUS TEST ===");
		if (PlayerStats.Instance == null)
		{
			Debug.LogError("PlayerStats.Instance is null!");
			return;
		}
		float basePerfectStartProgress = PlayerStats.Instance.basePerfectStartProgress;
		float perfectStartProgressBonus = PlayerStats.Instance.PerfectStartProgressBonus;
		Debug.Log($"Base Perfect Start Progress: {basePerfectStartProgress * 100f}%");
		Debug.Log($"Current Perfect Start Progress: {perfectStartProgressBonus * 100f}%");
		if (perfectStartProgressBonus <= 0f)
		{
			Debug.LogWarning("Perfect start progress bonus is 0 or negative. Perfect catches may not provide bonus.");
		}
		else
		{
			Debug.Log($"Perfect catch will provide {perfectStartProgressBonus * 100f}% starting progress in reel-in minigame");
		}
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(10f, 10f, 200f, 30f), "Test Complete Flow (F)"))
		{
			TestCompleteFlow();
		}
		if (GUI.Button(new Rect(10f, 50f, 200f, 30f), "Test Perfect Catch Bonus"))
		{
			TestPerfectCatchBonus();
		}
		if (GUI.Button(new Rect(10f, 90f, 200f, 30f), "Reset Test (R)"))
		{
			ResetTest();
		}
	}
}
