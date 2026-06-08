using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Dorfromantik.UI
{
	public class UiSpecialSteamAwards : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
	{
		private sealed class _003CAnimateLogoIdle_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UiSpecialSteamAwards _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CAnimateLogoIdle_003Ed__41(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				UiSpecialSteamAwards uiSpecialSteamAwards = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					Sequence onIdleSequence = uiSpecialSteamAwards.onIdleSequence;
					if (onIdleSequence != null)
					{
						TweenExtensions.Kill(onIdleSequence, complete: true);
					}
					uiSpecialSteamAwards.onIdleSequence = DOTween.Sequence();
					break;
				}
				case 1:
					_003C_003E1__state = -1;
					break;
				}
				if (uiSpecialSteamAwards.shouldIdleAnimation)
				{
					uiSpecialSteamAwards.isIdleAnimating = true;
					TweenSettingsExtensions.Append(uiSpecialSteamAwards.onInteractionSequence, ShortcutExtensions.DOPunchScale(uiSpecialSteamAwards.logo.transform, uiSpecialSteamAwards.logoIdlePunch, uiSpecialSteamAwards.logoIdleDuration, uiSpecialSteamAwards.logoIdleVibration, uiSpecialSteamAwards.logoIdleElasticity));
					_003C_003E2__current = new WaitForSeconds(UnityEngine.Random.Range(uiSpecialSteamAwards.logoIdleDuration, uiSpecialSteamAwards.logoIdleMaxDelaySeconds));
					_003C_003E1__state = 1;
					return true;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		[SerializeField]
		protected GameObject outlineContainer;

		[SerializeField]
		protected GameObject logo;

		[SerializeField]
		private bool changeOutlinesOnHover = true;

		[SerializeField]
		protected GameObject textActive;

		[SerializeField]
		protected GameObject textInactive;

		[SerializeField]
		private AudioClipOptions clickSound;

		[SerializeField]
		private AudioClipOptions hoverSound;

		[SerializeField]
		private float outlineDefaultSizeDeltaY = -50f;

		[SerializeField]
		private float outlineActiveHighlightedSizeDeltaY;

		[SerializeField]
		private float outlineSizeDeltaDuration = 0.4f;

		[SerializeField]
		private float outlineSizeSizeDelay = 0.25f;

		[SerializeField]
		private float logoSizeFactor = 1.2f;

		[SerializeField]
		private float logoSizeDuration = 0.4f;

		[SerializeField]
		private float logoSizeDelay;

		[SerializeField]
		protected bool shouldIdle;

		[SerializeField]
		protected Vector3 logoIdlePunch = new Vector3(0.2f, 0.2f, 0.2f);

		[SerializeField]
		protected float logoIdleDuration = 3f;

		[SerializeField]
		protected int logoIdleVibration = 1;

		[SerializeField]
		protected float logoIdleElasticity = 0.05f;

		[SerializeField]
		protected float logoIdleMaxDelaySeconds = 10f;

		[SerializeField]
		private float textTransitionDuration = 0.5f;

		[SerializeField]
		private float textTransitionDelay = 0.2f;

		[SerializeField]
		private UnityEvent onClick;

		[SerializeField]
		private UiVisualState uiVisualState;

		[SerializeField]
		protected bool shouldIdleAnimation = true;

		[SerializeField]
		protected bool isIdleAnimating;

		protected List<RectTransform> outlineRectTransforms = new List<RectTransform>();

		protected Sequence onInteractionSequence;

		protected Sequence onIdleSequence;

		protected CanvasGroup textActiveCanvasGroup;

		protected CanvasGroup textInactiveCanvasGroup;

		protected virtual void Start()
		{
			foreach (RectTransform item in outlineContainer.transform)
			{
				if (item.parent == outlineContainer.transform && !outlineRectTransforms.Contains(item))
				{
					outlineRectTransforms.Add(item);
				}
			}
			textActiveCanvasGroup = textActive.GetComponent<CanvasGroup>();
			textInactiveCanvasGroup = textInactive.GetComponent<CanvasGroup>();
			HandleLogoIdleAnimation(shouldIdleAnimation);
		}

		protected virtual void OnEnable()
		{
			SetVisualState(UiVisualState.Default);
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			AudioManager.Instance.PlayGlobalSound(hoverSound);
			SetVisualState(UiVisualState.Active);
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			SetVisualState(UiVisualState.Default);
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			AudioManager.Instance.PlayGlobalSound(clickSound);
			onClick?.Invoke();
		}

		private void SetVisualState(UiVisualState uiVisualState)
		{
			if (this.uiVisualState == uiVisualState)
			{
				return;
			}
			this.uiVisualState = uiVisualState;
			Sequence sequence = onInteractionSequence;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			onInteractionSequence = DOTween.Sequence();
			switch (uiVisualState)
			{
			case UiVisualState.Default:
			{
				AnimateOutlines(outlineDefaultSizeDeltaY);
				AnimateLogo(1f);
				AnimateText(shouldSetActive: false);
				if (!shouldIdle)
				{
					break;
				}
				Sequence sequence3 = onInteractionSequence;
				if (sequence3 != null)
				{
					TweenSettingsExtensions.OnComplete(sequence3, delegate
					{
						HandleLogoIdleAnimation(shouldIdleAnimation: true);
					});
				}
				break;
			}
			case UiVisualState.Highlighted:
			case UiVisualState.Active:
				if (shouldIdle)
				{
					HandleLogoIdleAnimation(shouldIdleAnimation: false);
					Sequence sequence2 = onIdleSequence;
					if (sequence2 != null)
					{
						TweenSettingsExtensions.OnComplete(sequence2, delegate
						{
							AnimateLogo(logoSizeFactor);
						});
					}
				}
				else
				{
					AnimateLogo(logoSizeFactor);
				}
				AnimateOutlines(outlineActiveHighlightedSizeDeltaY);
				AnimateText(shouldSetActive: true);
				break;
			default:
				throw new ArgumentOutOfRangeException("uiVisualState", uiVisualState, null);
			}
		}

		private void AnimateOutlines(float topBottomDelta)
		{
			if (!changeOutlinesOnHover)
			{
				return;
			}
			float num = ((uiVisualState == UiVisualState.Default) ? logoSizeDelay : outlineSizeSizeDelay);
			foreach (RectTransform outlineRectTransform in outlineRectTransforms)
			{
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f + num, DOTweenModuleUI.DOSizeDelta(outlineRectTransform, new Vector2(outlineRectTransform.sizeDelta.x, topBottomDelta), outlineSizeDeltaDuration));
			}
		}

		private void AnimateLogo(float endValue)
		{
			float num = ((uiVisualState == UiVisualState.Default) ? outlineSizeSizeDelay : logoSizeDelay);
			TweenSettingsExtensions.Insert(onInteractionSequence, 0f + num, ShortcutExtensions.DOScale(logo.transform, endValue, logoSizeDuration));
		}

		protected virtual void AnimateText(bool shouldSetActive)
		{
			if (shouldSetActive)
			{
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOFade(textInactiveCanvasGroup, 0f, textTransitionDuration));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f + textTransitionDelay, DOTweenModuleUI.DOFade(textActiveCanvasGroup, 1f, textTransitionDuration));
			}
			else
			{
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, DOTweenModuleUI.DOFade(textActiveCanvasGroup, 0f, textTransitionDuration));
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f + textTransitionDelay, DOTweenModuleUI.DOFade(textInactiveCanvasGroup, 1f, textTransitionDuration));
			}
		}

		protected void HandleLogoIdleAnimation(bool shouldIdleAnimation)
		{
			this.shouldIdleAnimation = shouldIdleAnimation;
			if (isIdleAnimating && !this.shouldIdleAnimation)
			{
				ResetLogoIdle();
			}
			if (uiVisualState == UiVisualState.Default && this.shouldIdleAnimation)
			{
				StartCoroutine(AnimateLogoIdle());
			}
		}

		protected virtual IEnumerator AnimateLogoIdle()
		{
			return new _003CAnimateLogoIdle_003Ed__41(0)
			{
				_003C_003E4__this = this
			};
		}

		protected void ResetLogoIdle()
		{
			Sequence sequence = onIdleSequence;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			onIdleSequence = DOTween.Sequence();
			StopCoroutine(AnimateLogoIdle());
			TweenSettingsExtensions.Insert(onIdleSequence, 0f, ShortcutExtensions.DOScale(logo.transform, 1f, 0.5f));
			isIdleAnimating = false;
		}

		private void _003CSetVisualState_003Eb__36_0()
		{
			HandleLogoIdleAnimation(shouldIdleAnimation: true);
		}

		private void _003CSetVisualState_003Eb__36_1()
		{
			AnimateLogo(logoSizeFactor);
		}
	}
}
