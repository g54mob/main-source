using System;
using System.Collections;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
	public Image[] fadeImages;

	public Canvas canvas;

	private const float defaultFadeTime = 1f;

	private EasingFunction.Ease ease = EasingFunction.Ease.Linear;

	public static FadeManager instance;

	public bool busy;

	public StudioEventEmitter fadeControlEmitter;

	private Action _callback;

	private void Awake()
	{
		if (instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		int sortingOrder = canvas.sortingOrder;
		canvas.sortingOrder = sortingOrder - 1;
		canvas.sortingOrder = sortingOrder + 1;
	}

	public void FadeIn(float fadeTimeSec = 1f)
	{
		StopAllCoroutines();
		StartCoroutine(FadeInInternalCo(fadeTimeSec));
	}

	public void FadeOut(float fadeTimeSec = 1f)
	{
		StopAllCoroutines();
		StartCoroutine(FadeOutInternalCo(fadeTimeSec));
	}

	private IEnumerator FadeInInternalCo(float fadeTimeSec = 1f)
	{
		busy = true;
		fadeControlEmitter.Play();
		Image[] array = fadeImages;
		foreach (Image image in array)
		{
			image.gameObject.SetActive(value: true);
			image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
		}
		float time = 0f;
		while (time < fadeTimeSec)
		{
			float a = EasingFunction.Evaluate(ease, time / fadeTimeSec);
			array = fadeImages;
			foreach (Image image2 in array)
			{
				image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, a);
			}
			time += Time.deltaTime;
			yield return null;
		}
		array = fadeImages;
		foreach (Image image3 in array)
		{
			image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 1f);
		}
	}

	private IEnumerator FadeOutInternalCo(float fadeTimeSec = 1f)
	{
		fadeControlEmitter.Stop();
		yield return new WaitForSeconds(1f);
		Image[] array = fadeImages;
		foreach (Image image in array)
		{
			image.gameObject.SetActive(value: true);
			image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
		}
		float time = 0f;
		while (time < fadeTimeSec)
		{
			float num = EasingFunction.Evaluate(ease, time / fadeTimeSec);
			array = fadeImages;
			foreach (Image image2 in array)
			{
				image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, 1f - num);
			}
			time += Time.deltaTime;
			yield return null;
		}
		array = fadeImages;
		foreach (Image image3 in array)
		{
			image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 0f);
			image3.gameObject.SetActive(value: false);
		}
		busy = false;
	}

	public static void SetFaded()
	{
		if (instance != null)
		{
			instance.StopAllCoroutines();
			Image[] array = instance.fadeImages;
			foreach (Image image in array)
			{
				image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
			}
		}
	}

	public static void SetUnfaded()
	{
		if (instance != null)
		{
			instance.StopAllCoroutines();
			Image[] array = instance.fadeImages;
			foreach (Image image in array)
			{
				image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
			}
		}
	}

	public static IEnumerator FadeInCo()
	{
		if (instance == null)
		{
			return null;
		}
		instance.StopAllCoroutines();
		return instance.FadeInInternalCo();
	}

	public static IEnumerator FadeOutCo()
	{
		if (instance == null)
		{
			return null;
		}
		instance.StopAllCoroutines();
		return instance.FadeOutInternalCo();
	}

	public static bool IsFaded()
	{
		if (instance == null)
		{
			return false;
		}
		return instance.fadeImages[0].color.a > 0.5f;
	}
}
