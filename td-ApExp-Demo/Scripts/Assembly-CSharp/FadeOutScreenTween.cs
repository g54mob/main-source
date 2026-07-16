using System.Collections;
using UnityEngine;

public class FadeOutScreenTween : MonoBehaviour
{
	[SerializeField]
	private float fadeSpeed = 1f;

	[SerializeField]
	private Tweener tweener;

	private Coroutine delayCoroutine;

	public bool FadedOut { get; private set; }

	public bool FadedIn { get; private set; }

	public bool IsFading { get; private set; }

	private void Start()
	{
		if (tweener != null)
		{
			tweener.FadeDuration = 1f / fadeSpeed;
			tweener.OnFadeToEnd += OnFadeOutComplete;
			tweener.OnFadeToStart += OnFadeInComplete;
		}
		FadedIn = true;
		FadedOut = false;
		IsFading = false;
	}

	public void FadeOut()
	{
		if (!FadedOut && !IsFading)
		{
			IsFading = true;
			FadedIn = false;
			tweener.Fade(isToEndAlpha: true);
		}
	}

	public void FadeIn()
	{
		if (!FadedIn && !IsFading)
		{
			IsFading = true;
			FadedOut = false;
			tweener.Fade(isToEndAlpha: false);
		}
	}

	private void OnFadeOutComplete()
	{
		FadedOut = true;
		IsFading = false;
		Debug.Log("Fade out complete");
	}

	private void OnFadeInComplete()
	{
		FadedIn = true;
		IsFading = false;
		Debug.Log("Fade in complete");
	}

	private void OnDestroy()
	{
		if (tweener != null)
		{
			tweener.OnFadeToEnd -= OnFadeOutComplete;
			tweener.OnFadeToStart -= OnFadeInComplete;
		}
	}

	public void BlackScreen()
	{
		GetComponent<CanvasGroup>().alpha = 1f;
		FadedIn = false;
		OnFadeOutComplete();
	}

	public void FadeOutDelay(float delay)
	{
		if (!FadedOut && !IsFading)
		{
			IsFading = true;
			FadedIn = false;
			if (delayCoroutine != null)
			{
				StopCoroutine(delayCoroutine);
			}
			delayCoroutine = StartCoroutine(DelayFade(isToEndAlpha: true, delay));
		}
	}

	public void FadeInDelay(float delay)
	{
		if (!FadedIn && !IsFading)
		{
			IsFading = true;
			FadedOut = false;
			if (delayCoroutine != null)
			{
				StopCoroutine(delayCoroutine);
			}
			delayCoroutine = StartCoroutine(DelayFade(isToEndAlpha: false, delay));
		}
	}

	private IEnumerator DelayFade(bool isToEndAlpha, float delay)
	{
		yield return new WaitForSeconds(delay);
		tweener.Fade(isToEndAlpha);
	}
}
