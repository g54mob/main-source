using System;
using System.Collections;
using Pug.UnityExtensions;
using UnityEngine;
using UnityEngine.Serialization;

public class LoadingScene : MonoBehaviour
{
	public LoadingProgressBar progressBar;

	public SpriteRenderer pugstormLogo;

	[FormerlySerializedAs("soldOutLogo")]
	public SpriteRenderer publisherLogo;

	public SceneHandler sceneHandler;

	public Camera initialCamera;

	public SceneReference sceneToLoad;

	private const float LOGO_STATIC_TIME = 4f;

	private const float LOGO_FADE_IN_TIME = 1f;

	private const float LOGO_FADE_OUT_TIME = 0.5f;

	private void Awake()
	{
		progressBar.gameObject.SetActive(value: false);
		pugstormLogo.gameObject.SetActive(value: false);
		publisherLogo.gameObject.SetActive(value: false);
	}

	private void Start()
	{
		StartCoroutine(ProgressiveLoader());
	}

	private IEnumerator ProgressiveLoader()
	{
		float loadingBarProgress = 0f;
		progressBar.gameObject.SetActive(value: true);
		progressBar.SetAlpha(1f);
		progressBar.SetProgress(loadingBarProgress);
		yield return Yielders.WaitForEndOfFrame();
		yield return Yielders.WaitForEndOfFrame();
		loadingBarProgress += 0.05f;
		progressBar.SetProgress(loadingBarProgress);
		foreach (float item in Manager.InitializeGlobalManager(allowAsyncOperations: true))
		{
			progressBar.SetProgress(loadingBarProgress + item * 0.9f);
			yield return Yielders.WaitForEndOfFrame();
		}
		loadingBarProgress += 0.9f;
		progressBar.SetProgress(loadingBarProgress);
		sceneHandler.gameObject.SetActive(value: true);
		Manager.camera.uiCamera.enabled = false;
		for (int i = 0; i < 5; i++)
		{
			yield return Yielders.WaitForEndOfFrame();
		}
		GC.Collect();
		yield return null;
		loadingBarProgress += 0.05f;
		progressBar.SetProgress(loadingBarProgress);
		yield return new WaitForSecondsRealtime(0.5f);
		yield return Fade(progressBar, 1f, 0f, 0.5f);
		progressBar.gameObject.SetActive(value: false);
		Manager.camera.uiCamera.enabled = true;
		initialCamera.gameObject.SetActive(value: false);
		yield return new WaitForSecondsRealtime(0.5f);
		if (CommandLineArgs.Has("-benchmark"))
		{
			Manager.load.QueueScene("Benchmark", 0f, 0f, FadePresets.cut);
			yield break;
		}
		yield return ShowLogo(pugstormLogo);
		yield return ShowLogo(publisherLogo);
		Manager.load.QueueScene(sceneToLoad.SceneName, 0f, 1.5f, FadePresets.blackToBlack);
	}

	private IEnumerator Fade(SpriteRenderer sprite, float fromAlpha, float toAlpha, float time)
	{
		TimerSimple waitTimer = new TimerSimple(time, unscaled: true);
		sprite.SetAlpha(fromAlpha);
		waitTimer.Start(time);
		while (waitTimer.isRunning && !waitTimer.isTimerElapsed)
		{
			sprite.SetAlpha(Mathf.Lerp(fromAlpha, toAlpha, waitTimer.elapsedRatio));
			yield return null;
		}
		sprite.SetAlpha(toAlpha);
	}

	private IEnumerator Fade(LoadingProgressBar sprite, float fromAlpha, float toAlpha, float time)
	{
		TimerSimple waitTimer = new TimerSimple(time, unscaled: true);
		sprite.SetAlpha(fromAlpha);
		waitTimer.Start(time);
		while (waitTimer.isRunning && !waitTimer.isTimerElapsed)
		{
			sprite.SetAlpha(Mathf.Lerp(fromAlpha, toAlpha, waitTimer.elapsedRatio));
			yield return null;
		}
		sprite.SetAlpha(toAlpha);
	}

	private IEnumerator WaitWithInputInterrupt(float time)
	{
		TimerSimple waitTimer = new TimerSimple(time, unscaled: true);
		waitTimer.Start(time);
		while (waitTimer.isRunning && !waitTimer.isTimerElapsed && !Manager.input.GetAnyButton())
		{
			yield return null;
		}
	}

	private IEnumerator ShowLogo(SpriteRenderer logo)
	{
		logo.gameObject.SetActive(value: true);
		yield return Fade(logo, 0f, 1f, 1f);
		yield return WaitWithInputInterrupt(4f);
		yield return Fade(logo, 1f, 0f, 0.5f);
		logo.gameObject.SetActive(value: false);
	}
}
