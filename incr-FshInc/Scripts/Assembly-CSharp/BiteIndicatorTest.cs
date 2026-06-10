using System.Collections;
using UnityEngine;

public class BiteIndicatorTest : MonoBehaviour, IBiteIndicatorResultHandler
{
	[Header("Test Settings")]
	public BiteIndicatorMinigame biteIndicator;

	public float testReactionTime = 2f;

	public bool autoTest;

	public float autoTestDelay = 3f;

	private TestFishingManager mockManager;

	private void Start()
	{
		mockManager = base.gameObject.AddComponent<TestFishingManager>();
		if (autoTest)
		{
			StartCoroutine(RunAutoTest());
		}
	}

	private void Update()
	{
	}

	private void TestBiteIndicator()
	{
		if (biteIndicator == null)
		{
			Debug.LogError("BiteIndicatorMinigame reference is null!");
		}
		else
		{
			biteIndicator.StartMinigame(mockManager, testReactionTime);
		}
	}

	private IEnumerator SimulatePerfectClick()
	{
		TestBiteIndicator();
		float perfectTime = testReactionTime * 0.45f;
		yield return new WaitForSeconds(perfectTime);
		Debug.Log($"Simulating perfect click at {perfectTime} seconds...");
	}

	private IEnumerator RunAutoTest()
	{
		yield return new WaitForSeconds(autoTestDelay);
		Debug.Log("=== AUTO TEST SEQUENCE STARTING ===");
		Debug.Log("Test 1: Normal Timing");
		TestBiteIndicator();
		yield return new WaitForSeconds(testReactionTime + 1f);
		Debug.Log("Test 2: Quick Timing (should not be perfect)");
		TestBiteIndicator();
		yield return new WaitForSeconds(0.1f);
		yield return new WaitForSeconds(testReactionTime + 1f);
		Debug.Log("Test 3: Perfect Timing Simulation");
		StartCoroutine(SimulatePerfectClick());
		Debug.Log("=== AUTO TEST SEQUENCE COMPLETE ===");
	}

	public void OnBiteIndicatorResult(bool playerClicked, bool perfectTiming)
	{
		string text = ((!playerClicked) ? "Too Slow" : (perfectTiming ? "PERFECT!" : "Good"));
		Debug.Log("<color=" + (perfectTiming ? "green" : (playerClicked ? "yellow" : "red")) + ">Bite Indicator Result: " + text + "</color>");
		if (perfectTiming)
		{
			Debug.Log("Perfect catch bonus should be applied!");
		}
	}
}
