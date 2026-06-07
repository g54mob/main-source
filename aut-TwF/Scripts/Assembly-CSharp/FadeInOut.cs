using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
	[SerializeField]
	private AnimationCurve fadeInCurve;

	[SerializeField]
	private AnimationCurve fadeOutCurve;

	private Color defaultPanelColor;

	private Image panel;

	private Coroutine fadeCoroutine;

	private void Awake()
	{
		panel = GetComponent<Image>();
		defaultPanelColor = panel.color;
	}

	public void FadeIn(float time, Action<float> updateCallback = null, Action endCallback = null)
	{
		this.StartCoroutineCheckingVar(FadeCoroutine(fadeIn: true, time, defaultPanelColor, updateCallback, endCallback), ref fadeCoroutine, stopCoroutineIfRunning: true);
	}

	public void FadeIn(float time, Color color, Action<float> updateCallback = null, Action endCallback = null)
	{
		this.StartCoroutineCheckingVar(FadeCoroutine(fadeIn: true, time, color, updateCallback, endCallback), ref fadeCoroutine, stopCoroutineIfRunning: true);
	}

	public void FadeOut(float time, Action<float> updateCallback = null, Action endCallback = null)
	{
		this.StartCoroutineCheckingVar(FadeCoroutine(fadeIn: false, time, defaultPanelColor, updateCallback, endCallback), ref fadeCoroutine, stopCoroutineIfRunning: true);
	}

	public void FadeOut(float time, Color color, Action<float> updateCallback = null, Action endCallback = null)
	{
		this.StartCoroutineCheckingVar(FadeCoroutine(fadeIn: false, time, color, updateCallback, endCallback), ref fadeCoroutine, stopCoroutineIfRunning: true);
	}

	private IEnumerator FadeCoroutine(bool fadeIn, float time, Color color, Action<float> updateCallback = null, Action callabck = null)
	{
		float currentTime = 0f;
		Color auxColor = color;
		auxColor.a = ((!fadeIn) ? 1 : 0);
		bool gamePaused = GameManager.instance.IsGamePaused;
		panel.raycastTarget = fadeIn;
		while (currentTime < time)
		{
			currentTime += (gamePaused ? Time.unscaledDeltaTime : Time.deltaTime);
			currentTime = Mathf.Min(time, currentTime);
			float a = (fadeIn ? fadeInCurve.Evaluate(currentTime / time) : fadeOutCurve.Evaluate(currentTime / time));
			auxColor.a = a;
			panel.color = auxColor;
			updateCallback?.Invoke(currentTime / time);
			yield return null;
		}
		callabck?.Invoke();
		fadeCoroutine = null;
	}
}
