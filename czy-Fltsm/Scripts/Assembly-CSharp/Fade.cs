using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Fade : MonoBehaviour
{
	private static Fade _instance;

	private RawImage _rawImage;

	private IEnumerator _fadeCoroutine;

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			_rawImage = GetComponent<RawImage>();
		}
		else
		{
			Object.Destroy(GetComponentInParent<Canvas>().gameObject);
		}
	}

	private bool FadeInOut(Color color, float duration, UnityAction fadeInCallback, UnityAction fadeOutCallback)
	{
		if (_fadeCoroutine == null)
		{
			_fadeCoroutine = FadeInOutCoroutine(color, duration, fadeInCallback, fadeOutCallback);
			StartCoroutine(_fadeCoroutine);
			return true;
		}
		return false;
	}

	private IEnumerator FadeInOutCoroutine(Color color, float duration, UnityAction fadeInCallback, UnityAction fadeOutCallback)
	{
		Color from = new Color(color.r, color.g, color.b, 0f);
		Color to = new Color(color.r, color.g, color.b, 1f);
		yield return FadeCoroutine(from, to, duration / 2f);
		yield return null;
		yield return null;
		fadeInCallback?.Invoke();
		yield return FadeCoroutine(to, from, duration / 2f);
		fadeOutCallback?.Invoke();
		_fadeCoroutine = null;
	}

	private IEnumerator FadeCoroutine(Color startColor, Color targetColor, float duration)
	{
		float time = 0f;
		while (time < duration)
		{
			yield return null;
			time += Time.unscaledDeltaTime;
			_rawImage.color = Color.Lerp(startColor, targetColor, time / duration);
		}
		_rawImage.color = targetColor;
	}

	public static bool InOut(UnityAction fadeInCallback, UnityAction fadeOutCallback)
	{
		return _instance.FadeInOut(Color.black, 1f, fadeInCallback, fadeOutCallback);
	}

	public static bool InOut(Color color, float time, UnityAction fadeInCallback, UnityAction fadeOutCallback)
	{
		return _instance.FadeInOut(color, time, fadeInCallback, fadeOutCallback);
	}

	public static IEnumerator FadeInOutRoutine(Color color, float time, UnityAction fadeInCallback, UnityAction fadeOutCallback)
	{
		return _instance.FadeInOutCoroutine(color, time, fadeInCallback, fadeOutCallback);
	}

	public static IEnumerator FadeInCoroutine(float duration)
	{
		return _instance.FadeCoroutine(new Color(0f, 0f, 0f, 0f), Color.black, duration);
	}

	public static IEnumerator FadeOutCoroutine(float duration)
	{
		return _instance.FadeCoroutine(Color.black, new Color(0f, 0f, 0f, 0f), duration);
	}
}
