using System;
using System.Collections;
using UnityEngine;

[Obsolete("Deprecated. Use FadeOutScreenTween instead.", true)]
public class FadeOutScreen : MonoBehaviour
{
	[SerializeField]
	private float fadeSpeed = 1f;

	private Animator animator;

	private bool fading;

	public bool FadedOut { get; private set; }

	public bool FadedIn { get; private set; }

	public bool IsFading
	{
		get
		{
			if (!fading)
			{
				return FadedOut;
			}
			return true;
		}
	}

	private void Start()
	{
		animator = GetComponent<Animator>();
		if ((bool)animator)
		{
			animator.SetFloat("FadeSpeed", fadeSpeed);
		}
		FadedIn = true;
		FadedOut = false;
		fading = false;
	}

	public void FadeOut()
	{
		if (!FadedOut && !fading)
		{
			fading = true;
			animator.SetTrigger("FadeOut");
			FadedIn = false;
			StartCoroutine(SetFadedOutCoroutine());
		}
	}

	private IEnumerator SetFadedOutCoroutine()
	{
		yield return new WaitForSeconds(1f / fadeSpeed);
		FadedOut = true;
		fading = false;
		Debug.LogWarning("Faded out");
	}

	public void FadeIn()
	{
		if (!FadedIn && !fading)
		{
			fading = true;
			animator.SetTrigger("FadeIn");
			FadedOut = false;
			StartCoroutine(SetFadedInCoroutine());
		}
	}

	private IEnumerator SetFadedInCoroutine()
	{
		yield return new WaitForSeconds(1f / fadeSpeed);
		FadedIn = true;
		fading = false;
		Debug.LogWarning("Faded in");
	}

	public void OnFadeOutComplete()
	{
		FadedOut = true;
	}

	public void OnFadeInComplete()
	{
		FadedIn = true;
	}
}
