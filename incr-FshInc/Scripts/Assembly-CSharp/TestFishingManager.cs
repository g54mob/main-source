using UnityEngine;

public class TestFishingManager : FishingManager
{
	public new void OnBiteIndicatorResult(bool playerClicked, bool perfectTiming)
	{
		string text = ((!playerClicked) ? "Too Slow" : (perfectTiming ? "PERFECT!" : "Good"));
		Debug.Log("<color=" + (perfectTiming ? "green" : (playerClicked ? "yellow" : "red")) + ">TEST - Bite Indicator Result: " + text + "</color>");
		if (perfectTiming)
		{
			Debug.Log("TEST - Perfect catch bonus should be applied!");
		}
	}
}
