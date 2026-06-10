using System;
using System.Collections;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Repository;
using NSMedieval.Tutorial;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

namespace NSMedieval.UI
{
	public class TutorialPanelView : MonoBehaviour
	{
		private const string CenterShowAnimation = "TutorialCenterIn";

		private const string CenterHideAnimation = "TutorialCenterOut";

		private const string RightShowAnimation = "TutorialRightIn";

		private const string RightHideAnimation = "TutorialRightOut";

		private const float AnimationEndDelay = 0.5f;

		private const float NextButtonFadeAnimationDuration = 0.3f;

		private const float RightAnimationDuration = 0.5f;

		private const int RightAnimationDistance = 500;

		[Header("Right Panel")]
		[SerializeField]
		private TMP_Text rightTitle;

		[SerializeField]
		private TMP_Text rightInfo;

		[SerializeField]
		private TMP_Text rightStepCounter;

		[SerializeField]
		private SoundButton rightNextButton;

		[SerializeField]
		private CanvasGroup rightButtonHighlightCanvasGroup;

		[SerializeField]
		private LayoutGroupView tasksGroup;

		[SerializeField]
		private Animator rightAnimator;

		[Header("Center Panel")]
		[SerializeField]
		private TMP_Text centerTitle;

		[SerializeField]
		private TMP_Text centerInfo;

		[SerializeField]
		private TMP_Text centerStepCounter;

		[SerializeField]
		private VideoPlayer centerVideoPlayer;

		[SerializeField]
		private SoundButton centerNextButton;

		[SerializeField]
		private Animator centerAnimator;

		private readonly List<TutorialTaskView> taskViews = new List<TutorialTaskView>();

		private TutorialStep tutorialStep;

		public event Action PanelHideReadyEvent;

		public event Action PanelShowReadyEvent;

		private void Start()
		{
			if (!TutorialManager.IsTutorialActive)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			centerAnimator.gameObject.SetActive(value: true);
			centerAnimator.Play("TutorialCenterOut");
			rightAnimator.gameObject.SetActive(value: true);
			rightAnimator.Play("TutorialRightOut");
			HideRightNextButton();
			rightNextButton.onClick.AddListener(delegate
			{
				StartCoroutine(HideRightCoroutine());
			});
			HideCenterNextButton();
			centerNextButton.onClick.AddListener(delegate
			{
				StartCoroutine(HideCenterCoroutine());
			});
		}

		public void UpdateDataAndShow(TutorialStep tutorialStep)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\TutorialPanelView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Updating tutorial panel with step ");
				messageBuilder.AppendFormatted(tutorialStep.GetType().Name);
			}
			Log.Trace(messageBuilder);
			this.tutorialStep = tutorialStep;
			if (tutorialStep.Tasks == null || tutorialStep.Tasks.Count == 0)
			{
				UpdateCenterPanel();
			}
			else
			{
				UpdateRightPanel();
			}
		}

		private void OnStepComplete()
		{
			tutorialStep.StepCompleteEvent -= OnStepComplete;
			StartCoroutine(ShowRightNextButton());
		}

		private IEnumerator ShowRightNextButton()
		{
			rightNextButton.interactable = true;
			yield return new WaitForSecondsRealtime(0.5f);
			CanvasGroup buttonCanvasGroup = rightNextButton.GetComponent<CanvasGroup>();
			float targetAlpha = 1f;
			float startAlpha = (buttonCanvasGroup.alpha = 0f);
			rightNextButton.GetComponent<RectTransform>();
			float time = 0f;
			while (time < 0.3f)
			{
				time += Time.unscaledDeltaTime;
				buttonCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / 0.3f);
				yield return null;
			}
			buttonCanvasGroup.alpha = targetAlpha;
			rightButtonHighlightCanvasGroup.alpha = 0f;
			time = 0f;
			float fadeTime = 0.1f;
			while (time < fadeTime)
			{
				time += Time.unscaledDeltaTime;
				rightButtonHighlightCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeTime);
				yield return null;
			}
			yield return new WaitForSecondsRealtime(2.2f);
			time = 0f;
			while (time < fadeTime)
			{
				time += Time.unscaledDeltaTime;
				rightButtonHighlightCanvasGroup.alpha = Mathf.Lerp(targetAlpha, startAlpha, time / fadeTime);
				yield return null;
			}
			rightButtonHighlightCanvasGroup.alpha = 0f;
		}

		private void HideRightNextButton()
		{
			rightNextButton.interactable = false;
			rightNextButton.GetComponent<CanvasGroup>().alpha = 0f;
			rightButtonHighlightCanvasGroup.alpha = 0f;
		}

		private void UpdateRightPanel()
		{
			HideRightNextButton();
			rightTitle.SetText(tutorialStep.GetName());
			rightInfo.SetText(tutorialStep.GetInfo());
			rightStepCounter.SetText(tutorialStep.GetStepCounter());
			taskViews.SetAllActive(active: false);
			foreach (TutorialStepTask task in tutorialStep.Tasks)
			{
				taskViews.GetNext(tasksGroup).SetData(task);
			}
			tutorialStep.StepCompleteEvent += OnStepComplete;
			StartCoroutine(ShowRightCoroutine());
		}

		private IEnumerator ShowRightCoroutine()
		{
			Log.Debug("Showing right tutorial panel", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\TutorialPanelView.cs");
			yield return PlayAnimationAndWait(rightAnimator, "TutorialRightIn");
			this.PanelShowReadyEvent?.Invoke();
		}

		private IEnumerator HideRightCoroutine()
		{
			Log.Debug("Hiding right tutorial panel", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\TutorialPanelView.cs");
			HideRightNextButton();
			yield return PlayAnimationAndWait(rightAnimator, "TutorialRightOut");
			this.PanelHideReadyEvent?.Invoke();
		}

		private void UpdateCenterPanel()
		{
			centerTitle.SetText(tutorialStep.GetName());
			centerInfo.SetText(tutorialStep.GetInfo());
			centerStepCounter.SetText(tutorialStep.GetStepCounter());
			centerVideoPlayer.clip = MonoRepository<VideoClipRepository, KeyVideoClipPair>.Instance.GetClip("welcome");
			StartCoroutine(ShowCenterCoroutine());
		}

		private IEnumerator ShowCenterCoroutine()
		{
			Log.Debug("Showing center tutorial panel", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\TutorialPanelView.cs");
			yield return PlayAnimationAndWait(centerAnimator, "TutorialCenterIn");
			yield return new WaitForSecondsRealtime(1f);
			ShowCenterNextButton();
			this.PanelShowReadyEvent?.Invoke();
		}

		private IEnumerator HideCenterCoroutine()
		{
			Log.Debug("Hiding center tutorial panel", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\TutorialPanelView.cs");
			HideCenterNextButton();
			yield return PlayAnimationAndWait(centerAnimator, "TutorialCenterOut");
			this.PanelHideReadyEvent?.Invoke();
		}

		private void ShowCenterNextButton()
		{
			centerNextButton.gameObject.SetActive(value: true);
			centerNextButton.interactable = true;
		}

		private void HideCenterNextButton()
		{
			centerNextButton.gameObject.SetActive(value: false);
			centerNextButton.interactable = false;
		}

		private IEnumerator PlayAnimationAndWait(Animator animator, string animationName)
		{
			animator.Play(animationName);
			yield return null;
			float clipLenght = animator.GetCurrentAnimatorStateInfo(0).length;
			yield return new WaitForSecondsRealtime(clipLenght);
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(26, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\TutorialPanelView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(animator);
				messageBuilder.AppendLiteral(" Finished ");
				messageBuilder.AppendFormatted(animationName);
				messageBuilder.AppendLiteral(" after ");
				messageBuilder.AppendFormatted(clipLenght);
				messageBuilder.AppendLiteral(" seconds.");
			}
			Log.Trace(messageBuilder);
			yield return new WaitForSecondsRealtime(0.5f);
		}
	}
}
