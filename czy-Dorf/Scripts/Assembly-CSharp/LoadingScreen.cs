using System;
using DG.Tweening;
using Dorfromantik;
using Dorfromantik.UI.Components;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	[SerializeField]
	private float showDuration = 0.1f;

	[SerializeField]
	private float hideDuration = 1f;

	[SerializeField]
	private float fastLoadFadeDuration = 1f;

	[SerializeField]
	private Image screenBlend;

	[SerializeField]
	private ProgressBar progressBar;

	[SerializeField]
	[FormerlySerializedAs("loadingUi")]
	private CanvasGroup loadingUiCanvasGroup;

	[FormerlySerializedAs("loadingBarCanvasGroup")]
	[SerializeField]
	private CanvasGroup progressIndicatorCanvasGroup;

	[SerializeField]
	private UiIconButton fastLoadButton;

	[SerializeField]
	private LoadingProgressRouter loadingProgressRouter;

	[SerializeField]
	private SettingsRouter settingsRouter;

	private Sequence fadeTween;

	private bool active;

	private void Awake()
	{
		loadingProgressRouter.OnProgressChanged += UpdateProgress;
		loadingProgressRouter.OnToggleLoadingUi += ToggleLoadingUi;
	}

	private void ToggleLoadingUi()
	{
		loadingUiCanvasGroup.gameObject.SetActive(!loadingUiCanvasGroup.gameObject.activeSelf);
	}

	private void UpdateProgress(float newProgress)
	{
		progressBar.currentPercent = newProgress * 100f;
	}

	public void Show(bool newShow, bool animate = true)
	{
		Sequence sequence = fadeTween;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence);
		}
		fadeTween = DOTween.Sequence();
		if (newShow)
		{
			loadingUiCanvasGroup.gameObject.SetActive(value: true);
			base.gameObject.SetActive(value: true);
			loadingProgressRouter.StartProgress();
			EnableFastLoading(enableFastLoading: false, animate: false);
		}
		else
		{
			TweenSettingsExtensions.Insert(fadeTween, 0f, DOTweenModuleUI.DOFade(progressIndicatorCanvasGroup, 1f, hideDuration));
			TweenSettingsExtensions.Insert(fadeTween, 0f, DOTweenModuleUI.DOFade(screenBlend, 0f, hideDuration));
		}
		float duration = ((!animate) ? 0f : (newShow ? showDuration : hideDuration));
		Tween tween = DOTweenModuleUI.DOFade(loadingUiCanvasGroup, newShow ? 1 : 0, duration);
		if (!newShow)
		{
			tween.onComplete = (TweenCallback)Delegate.Combine(tween.onComplete, (TweenCallback)delegate
			{
				base.gameObject.SetActive(value: false);
			});
		}
	}

	private void OnDestroy()
	{
		loadingProgressRouter.OnProgressChanged -= UpdateProgress;
		loadingProgressRouter.OnToggleLoadingUi -= ToggleLoadingUi;
	}

	public void ToggleFastLoading()
	{
		if (loadingProgressRouter.IsLoading)
		{
			EnableFastLoading(!loadingProgressRouter.FastLoadingEnabled);
		}
	}

	private void EnableFastLoading(bool enableFastLoading, bool animate = true)
	{
		loadingProgressRouter.SetFastLoadingEnabled(enableFastLoading);
		fastLoadButton.SetVisualStateActivated(loadingProgressRouter.FastLoadingEnabled);
		if ((bool)OverwritingSingleton<GameSession>.Instance)
		{
			OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup -= EnableIngameCamera;
		}
		if (enableFastLoading)
		{
			screenBlend.gameObject.SetActive(value: true);
		}
		Sequence sequence = fadeTween;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence);
		}
		fadeTween = DOTween.Sequence();
		TweenSettingsExtensions.Insert(fadeTween, 0f, DOTweenModuleUI.DOFade(screenBlend, enableFastLoading ? 1 : 0, animate ? fastLoadFadeDuration : 0f));
		if (enableFastLoading)
		{
			TweenSettingsExtensions.Insert(fadeTween, 0f, DOTweenModuleUI.DOFade(progressIndicatorCanvasGroup, 1f, animate ? fastLoadFadeDuration : 0f));
			TweenSettingsExtensions.OnComplete(fadeTween, DisableIngameCamera);
			OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup += EnableIngameCamera;
			return;
		}
		EnableIngameCamera();
		TweenSettingsExtensions.Insert(fadeTween, 0f, DOTweenModuleUI.DOFade(progressIndicatorCanvasGroup, 1f, animate ? fastLoadFadeDuration : 0f));
		TweenSettingsExtensions.OnComplete(fadeTween, delegate
		{
			screenBlend.gameObject.SetActive(value: false);
		});
	}

	private void EnableIngameCamera()
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup -= EnableIngameCamera;
			OverwritingSingleton<IngameUi>.Instance.mainCamera.enabled = true;
			OverwritingSingleton<IngameUi>.Instance.uiCamera.enabled = true;
			SetTargetFrameBudget(-1);
		}
	}

	private void DisableIngameCamera()
	{
		OverwritingSingleton<IngameUi>.Instance.mainCamera.enabled = false;
		OverwritingSingleton<IngameUi>.Instance.uiCamera.enabled = false;
		SetTargetFrameBudget(150);
	}

	public void SetTargetFrameBudget(int targetBudget)
	{
		OverwritingSingleton<IngameUi>.Instance.saveLoadSystem.overrideFrameBudget = targetBudget;
	}

	private void _003CShow_003Eb__15_0()
	{
		base.gameObject.SetActive(value: false);
	}

	private void _003CEnableFastLoading_003Eb__18_0()
	{
		screenBlend.gameObject.SetActive(value: false);
	}
}
