using UnityEngine;

public class ChallengeTracker : MonoBehaviour
{
	public PugText counterText;

	public Animator animator;

	private Coroutine challengeTracker_co;

	private string challengeTime;

	public GameObject container;

	private void Start()
	{
		container.SetActive(value: false);
	}

	public void ShowTracker(string whatToDisplay)
	{
		container.SetActive(value: true);
		counterText.Render(whatToDisplay);
		animator.SetTrigger(-1023692900);
	}

	public void UpdateTrackerInfo(string whatToDisplay)
	{
		animator.SetTrigger(454478554);
		counterText.Render(whatToDisplay);
	}

	public void HideTracker()
	{
		animator.SetTrigger(-269493070);
	}
}
