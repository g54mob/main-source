using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_TaskAnimation : MonoBehaviour
	{
		[SerializeField]
		private RectTransform progressRectTransform;

		[SerializeField]
		private CanvasGroup progressCanvasGroup;

		[SerializeField]
		[Min(0f)]
		private float progressFadeDuration = 0.5f;

		[SerializeField]
		[Min(0f)]
		private float progressScaleChangeDuration = 0.5f;

		[SerializeField]
		private RectTransform progressLightRectTransform;

		[SerializeField]
		[Min(0f)]
		private float lightDuration = 1f;

		[SerializeField]
		private CanvasGroup descriptionCanvasGroup;

		[SerializeField]
		[Min(0f)]
		private float descriptionFadeDuration = 0.5f;

		[SerializeField]
		private RectTransform lineDescriptionRectTransform;

		[SerializeField]
		[Min(0f)]
		private float lineMoveDuration = 0.5f;

		private Sequence taskCompleteSequence;

		private TweenSequencesService tweenSequences;

		public bool InAnimation => taskCompleteSequence.IsActive();

		public bool IsTaskCompletePlayed => Mathf.Approximately(lineDescriptionRectTransform.localScale.x, 1f);

		public event Action OnLineAnimationStarted;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void OnDisable()
		{
			if (taskCompleteSequence != null)
			{
				tweenSequences.Kill(taskCompleteSequence);
				taskCompleteSequence = null;
			}
		}

		public void PlayTaskComplete()
		{
			if (!IsTaskCompletePlayed)
			{
				if (taskCompleteSequence != null)
				{
					tweenSequences.Kill(taskCompleteSequence);
				}
				taskCompleteSequence = tweenSequences.Create();
				taskCompleteSequence.OnStart(delegate
				{
					SetDefaultParams();
				}).Append(progressLightRectTransform.DOLocalMoveX(1080f, lightDuration)).Append(progressCanvasGroup.DOFade(0f, progressFadeDuration))
					.AppendCallback(delegate
					{
						this.OnLineAnimationStarted?.Invoke();
					})
					.Append(descriptionCanvasGroup.DOFade(0.5f, descriptionFadeDuration))
					.Join(lineDescriptionRectTransform.DOScaleX(1f, lineMoveDuration))
					.Join(progressRectTransform.DOScaleY(0f, progressScaleChangeDuration))
					.AppendCallback(delegate
					{
						progressRectTransform.gameObject.SetActive(value: false);
					})
					.SetEase(Ease.Linear);
			}
		}

		public void ResetTaskComplete()
		{
			if (taskCompleteSequence != null)
			{
				tweenSequences.Kill(taskCompleteSequence);
				taskCompleteSequence = null;
			}
			SetDefaultParams();
		}

		private void SetDefaultParams()
		{
			Vector3 localPosition = progressLightRectTransform.localPosition;
			localPosition.x = -80f;
			progressLightRectTransform.localPosition = localPosition;
			progressCanvasGroup.alpha = 1f;
			progressRectTransform.localScale = Vector3.one;
			progressRectTransform.gameObject.SetActive(value: true);
			descriptionCanvasGroup.alpha = 1f;
			lineDescriptionRectTransform.localScale = new Vector3(0f, 1f, 1f);
		}
	}
}
