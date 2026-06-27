using System;
using DG.Tweening;
using Restory.Data.ToDoList;
using Restory.ObjectPools;
using Restory.UserInterface;
using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Views.ToDoList
{
	public sealed class GUI_ToDoItemView : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private GUI_LocalisedText titleText;

		[SerializeField]
		private LayoutElement layoutElement;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private RectTransform lineTransform;

		[SerializeField]
		[Min(0f)]
		private float layoutElementPreferredHeight = 70f;

		[SerializeField]
		[Min(0f)]
		private float lineDuration = 1f;

		[SerializeField]
		private Ease lineEase = Ease.OutCubic;

		[SerializeField]
		[Min(0f)]
		private float fadeDuration = 1f;

		[SerializeField]
		private float minDelayBetweenAddAndCompleteAnimation = 1f;

		private ToDoItem item;

		private Sequence addSequence;

		private Sequence completeSequence;

		private TweenSequencesService tweenSequences;

		private bool wasCompleteAnimationRequestedDuringAddAnimation;

		private Action<GUI_ToDoItemView> enqueuedCompleteAnimationCompletionCallback;

		public ToDoItem Item => item;

		public event Action OnCompletionAnimationStarted;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void Awake()
		{
			layoutElementPreferredHeight = layoutElement.preferredHeight;
		}

		private void OnEnable()
		{
			layoutElementPreferredHeight = layoutElement.preferredHeight;
		}

		public void SetData(ToDoItem item, bool resetComplete = true)
		{
			this.item = item;
			if (resetComplete)
			{
				ResetAnimation();
			}
			titleText.LocalizationID = this.item.NameLocalizationId;
		}

		public void StartAddAnimation(Action<GUI_ToDoItemView> onComplete = null)
		{
			if (addSequence.IsActive())
			{
				tweenSequences.Kill(addSequence);
				addSequence = null;
			}
			if (completeSequence.IsActive())
			{
				tweenSequences.Kill(completeSequence);
				completeSequence = null;
			}
			lineTransform.localScale = new Vector3(0f, 1f, 1f);
			canvasGroup.alpha = 0f;
			layoutElement.preferredHeight = 0f;
			addSequence = tweenSequences.Create();
			addSequence.Append(canvasGroup.DOFade(1f, fadeDuration));
			addSequence.Join(DOTween.To(() => 0f, delegate(float t)
			{
				layoutElement.preferredHeight = LayoutUtility.GetPreferredHeight((RectTransform)titleText.transform) * t;
			}, 1f, fadeDuration));
			onComplete = (Action<GUI_ToDoItemView>)Delegate.Combine(onComplete, new Action<GUI_ToDoItemView>(ResolveAddAnimationCompleted));
			addSequence.OnComplete(delegate
			{
				layoutElement.preferredHeight = -1f;
				onComplete?.Invoke(this);
			});
		}

		public void StartOrEnqueueCompleteAnimation(Action<GUI_ToDoItemView> onComplete = null)
		{
			if (addSequence.IsActive())
			{
				wasCompleteAnimationRequestedDuringAddAnimation = true;
				enqueuedCompleteAnimationCompletionCallback = onComplete;
			}
			else
			{
				StartCompleteAnimation(onComplete);
			}
		}

		public void ResetAnimation()
		{
			if (addSequence.IsActive())
			{
				tweenSequences.Kill(addSequence);
				addSequence = null;
			}
			if (completeSequence.IsActive())
			{
				tweenSequences.Kill(completeSequence);
				completeSequence = null;
			}
			lineTransform.localScale = new Vector3(0f, 1f, 1f);
			canvasGroup.alpha = 1f;
			layoutElement.preferredHeight = -1f;
			wasCompleteAnimationRequestedDuringAddAnimation = false;
			enqueuedCompleteAnimationCompletionCallback = null;
		}

		public void Clean()
		{
			item = null;
			ResetAnimation();
			titleText.LocalizationID = string.Empty;
		}

		private void ResolveAddAnimationCompleted(GUI_ToDoItemView _)
		{
			if (wasCompleteAnimationRequestedDuringAddAnimation)
			{
				StartCompleteAnimation(enqueuedCompleteAnimationCompletionCallback, minDelayBetweenAddAndCompleteAnimation);
			}
		}

		private void StartCompleteAnimation(Action<GUI_ToDoItemView> onComplete, float delayBeforeAnimationStart = 0f)
		{
			if (completeSequence.IsActive())
			{
				tweenSequences.Kill(completeSequence);
				completeSequence = null;
			}
			lineTransform.localScale = new Vector3(0f, 1f, 1f);
			canvasGroup.alpha = 1f;
			layoutElement.preferredHeight = LayoutUtility.GetPreferredHeight((RectTransform)titleText.transform);
			completeSequence = tweenSequences.Create();
			completeSequence.AppendInterval(delayBeforeAnimationStart);
			completeSequence.AppendCallback(delegate
			{
				this.OnCompletionAnimationStarted?.Invoke();
			});
			completeSequence.Append(lineTransform.DOScaleX(1f, lineDuration).SetEase(lineEase));
			completeSequence.Append(canvasGroup.DOFade(0f, fadeDuration));
			completeSequence.Join(DOTween.To(() => 1f, delegate(float t)
			{
				layoutElement.preferredHeight = LayoutUtility.GetPreferredHeight((RectTransform)titleText.transform) * t;
			}, 0f, fadeDuration));
			completeSequence.OnComplete(delegate
			{
				onComplete?.Invoke(this);
			});
		}
	}
}
