using UnityEngine;

public class OverlayBannerChallenge : MonoBehaviour
{
	public Animator animator;

	public PugTextEffectFade entranceFadeFX;

	private Coroutine co_text;

	public PugText challengeText;

	private string textToDisplay;

	public void ShowChallengeText(string textToDisplay)
	{
		base.gameObject.SetActive(value: true);
		animator.SetTrigger(-1023692900);
		this.textToDisplay = textToDisplay;
		challengeText.Render(this.textToDisplay);
	}

	public void HideChallengeText()
	{
		animator.SetTrigger(-269493070);
	}
}
