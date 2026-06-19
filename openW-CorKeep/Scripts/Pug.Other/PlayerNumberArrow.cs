using UnityEngine;

public class PlayerNumberArrow : MonoBehaviour
{
	public PugColorCyclingController pccc;

	public SpriteRenderer numberSpriteRenderer;

	public Animator animator;

	public Sprite[] numberSprites;

	private int playerNumber;

	public void SetPlayerNumber(int number)
	{
		playerNumber = number;
		if (number >= 0 && number <= 4)
		{
			numberSpriteRenderer.sprite = numberSprites[number];
			pccc.SetPaletteFromPatternFrame(number);
		}
	}

	public void PlayWiggle(bool autoFade = false)
	{
		pccc.Play(playerNumber, loop: true, 2f);
		if (!autoFade)
		{
			animator.SetTrigger("wiggle");
		}
		else
		{
			animator.SetTrigger("wiggleAndFade");
		}
	}

	public void StopWiggle()
	{
		pccc.Stop(playerNumber);
		pccc.SetPaletteFromPatternFrame(playerNumber);
		animator.SetTrigger("show");
	}

	public void Hide()
	{
		animator.SetTrigger("hide");
	}
}
