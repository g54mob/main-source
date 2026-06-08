using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Dorfromantik.UI
{
	public class UiSpecialSwitchAvailable : UiSpecialSteamAwards
	{
		private sealed class _003CAnimateLogoIdle_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UiSpecialSwitchAvailable _003C_003E4__this;

			private CanvasGroup _003ClogoActiveCanvasGroup_003E5__2;

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
			public _003CAnimateLogoIdle_003Ed__8(int _003C_003E1__state)
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
				UiSpecialSwitchAvailable uiSpecialSwitchAvailable = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (uiSpecialSwitchAvailable.isIdleAnimating)
					{
						uiSpecialSwitchAvailable.ResetLogoIdle();
					}
					_003ClogoActiveCanvasGroup_003E5__2 = uiSpecialSwitchAvailable.logoActive.GetComponent<CanvasGroup>();
					break;
				case 1:
					_003C_003E1__state = -1;
					break;
				}
				if (uiSpecialSwitchAvailable.shouldIdleAnimation)
				{
					uiSpecialSwitchAvailable.isIdleAnimating = true;
					Sequence onIdleSequence = uiSpecialSwitchAvailable.onIdleSequence;
					if (onIdleSequence != null)
					{
						TweenExtensions.Kill(onIdleSequence, complete: true);
					}
					uiSpecialSwitchAvailable.onIdleSequence = DOTween.Sequence();
					TweenSettingsExtensions.Insert(uiSpecialSwitchAvailable.onIdleSequence, 0f, ShortcutExtensions.DOPunchScale(uiSpecialSwitchAvailable.logo.transform, uiSpecialSwitchAvailable.logoIdlePunch, uiSpecialSwitchAvailable.logoIdleDuration, uiSpecialSwitchAvailable.logoIdleVibration, uiSpecialSwitchAvailable.logoIdleElasticity));
					TweenSettingsExtensions.Insert(uiSpecialSwitchAvailable.onIdleSequence, 0f, DOTweenModuleUI.DOFade(_003ClogoActiveCanvasGroup_003E5__2, 1f, 0.5f));
					TweenSettingsExtensions.Insert(uiSpecialSwitchAvailable.onIdleSequence, uiSpecialSwitchAvailable.logoIdleDuration + uiSpecialSwitchAvailable.logoIdleMaxDelaySeconds - 1f, DOTweenModuleUI.DOFade(_003ClogoActiveCanvasGroup_003E5__2, 0f, 0.5f));
					_003C_003E2__current = new WaitForSeconds(uiSpecialSwitchAvailable.logoIdleDuration + uiSpecialSwitchAvailable.logoIdleMaxDelaySeconds);
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
		protected GameObject logoActive;

		protected override void Start()
		{
			foreach (RectTransform item in outlineContainer.transform)
			{
				if (item.parent == outlineContainer.transform && !outlineRectTransforms.Contains(item))
				{
					outlineRectTransforms.Add(item);
				}
			}
			textInactiveCanvasGroup = textInactive.GetComponent<CanvasGroup>();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			HandleLogoIdleAnimation(shouldIdleAnimation: true);
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
		}

		public void DBG_StartHandleLogoIdleAnimation(bool shouldStart)
		{
			HandleLogoIdleAnimation(shouldStart);
		}

		protected override void AnimateText(bool shouldSetActive)
		{
		}

		protected override IEnumerator AnimateLogoIdle()
		{
			return new _003CAnimateLogoIdle_003Ed__8(0)
			{
				_003C_003E4__this = this
			};
		}
	}
}
