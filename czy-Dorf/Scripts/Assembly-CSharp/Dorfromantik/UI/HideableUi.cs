using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class HideableUi : MonoBehaviour
	{
		private enum UiScreenAnimateMode
		{
			None = 0,
			FromScreenAnchor = 1,
			FromWorldAnchor_NOTIMPLENMENTED = 2,
			FromAnchoredPos = 3,
			NoAnimationAndSetActive = 4
		}

		public enum LockType
		{
			Regular = 0,
			LockedForever = 1
		}

		private sealed class _003CRebuildLayoutGroupNextFrame_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HideableUi _003C_003E4__this;

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
			public _003CRebuildLayoutGroupNextFrame_003Ed__41(int _003C_003E1__state)
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
				HideableUi hideableUi = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (hideableUi.isWaitingToRebuildLayoutGroup)
					{
						return false;
					}
					hideableUi.isWaitingToRebuildLayoutGroup = true;
					_003C_003E2__current = new WaitForEndOfFrame();
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					UiUtility.RebuildHorizontalOrVerticalLayoutGroupsAndCanvas(hideableUi.layoutGroupsToUpdate);
					hideableUi.isWaitingToRebuildLayoutGroup = false;
					return false;
				}
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
		private Canvas referenceCanvas;

		[SerializeField]
		private UiScreenAnimateMode animateMode;

		[SerializeField]
		private Camera uiCamera;

		[SerializeField]
		private RectTransform hiddenUiAnchor;

		[SerializeField]
		private RectTransform visibleUiAnchor;

		[SerializeField]
		private float spawnAnimationDuration;

		[SerializeField]
		private float animationStartDelay;

		[SerializeField]
		private Vector2 hiddenAnchorPos;

		[SerializeField]
		private bool shouldUseRectTransformScaleForHiddenAnchorPos;

		[SerializeField]
		private bool shouldUseWidthRectTransformForHiddenAnchorPos;

		[SerializeField]
		private bool shouldUseHeightRectTransformForHiddenAnchorPos;

		[SerializeField]
		private bool shouldWidthRectTransformForHiddenAnchorPosBeAdded = true;

		[SerializeField]
		private bool shouldHeightRectTransformForHiddenAnchorPosBeAdded = true;

		[SerializeField]
		private Vector2 additionalPadding = Vector2.zero;

		[SerializeField]
		private bool shouldUpdateOnResolutionChanged;

		[SerializeField]
		private SettingsRouter settingsRouter;

		[SerializeField]
		private bool shouldUpdateLayoutGroups;

		[SerializeField]
		private List<HorizontalOrVerticalLayoutGroup> layoutGroupsToUpdate;

		[SerializeField]
		private bool shouldHideOnAwake;

		[SerializeField]
		private bool shouldDisableOnHide = true;

		public BoolEvent OnVisibilityChanged;

		private RectTransform canvas;

		private RectTransform rectTransform;

		private LayoutElement layoutElement;

		private IngameMenu ingameMenu;

		private Vector3 originalPos;

		private Vector2 originalAnchoredPos;

		private bool isInitialized;

		private bool isShown;

		private bool isLocked;

		private LockType currentLockState;

		private bool isWaitingToRebuildLayoutGroup;

		private Sequence showSequence;

		public bool IsShown => isShown;

		protected virtual void Awake()
		{
			if (!isInitialized)
			{
				InitializeOriginalPos();
			}
			if (shouldUpdateOnResolutionChanged)
			{
				settingsRouter.OnResolutionChanged += UpdateBasedOnResolution;
			}
			if (shouldHideOnAwake)
			{
				Show(shouldShow: false, shouldAnimate: false);
			}
			OnVisibilityChanged?.Invoke(arg0: false);
		}

		private void OnDestroy()
		{
			if (shouldUpdateOnResolutionChanged)
			{
				settingsRouter.OnResolutionChanged -= UpdateBasedOnResolution;
			}
		}

		private void UpdateBasedOnResolution(Resolution obj)
		{
			Show(isShown, shouldAnimate: false);
		}

		private void InitializeOriginalPos()
		{
			rectTransform = GetComponent<RectTransform>();
			layoutElement = GetComponent<LayoutElement>();
			if (!referenceCanvas)
			{
				referenceCanvas = GetComponentInParent<Canvas>();
			}
			canvas = referenceCanvas.GetComponent<RectTransform>();
			if ((bool)rectTransform)
			{
				originalAnchoredPos = rectTransform.anchoredPosition;
			}
			isInitialized = true;
		}

		public virtual void Show(bool shouldShow, bool shouldAnimate = true, float overwriteDuration = -1f)
		{
			if (!isInitialized)
			{
				InitializeOriginalPos();
			}
			isShown = shouldShow;
			if (isLocked)
			{
				return;
			}
			switch (animateMode)
			{
			case UiScreenAnimateMode.None:
				base.gameObject.SetActive(shouldShow);
				if (shouldShow && shouldUpdateLayoutGroups)
				{
					UiUtility.RebuildHorizontalOrVerticalLayoutGroupsAndCanvas(layoutGroupsToUpdate);
				}
				break;
			case UiScreenAnimateMode.FromScreenAnchor:
				if (!rectTransform)
				{
					RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas, shouldShow ? visibleUiAnchor.position : hiddenUiAnchor.position, uiCamera, out var worldPoint);
					StartSpawnAnimation(worldPoint, shouldShow, shouldAnimate, overwriteDuration);
				}
				break;
			case UiScreenAnimateMode.FromAnchoredPos:
				if (shouldUseRectTransformScaleForHiddenAnchorPos)
				{
					UpdateHiddenAnchorPosFromRectTransform();
				}
				StartSpawnAnimation(shouldShow ? originalAnchoredPos : hiddenAnchorPos, shouldShow, shouldAnimate, overwriteDuration);
				break;
			}
			OnVisibilityChanged?.Invoke(shouldShow);
		}

		private void StartSpawnAnimation(Vector3 targetPos, bool shouldShow, bool shouldAnimate = true, float overwriteDuration = -1f)
		{
			float duration = ((!shouldAnimate) ? 0f : ((overwriteDuration < 0f) ? spawnAnimationDuration : overwriteDuration));
			if (shouldShow)
			{
				base.gameObject.SetActive(value: true);
			}
			Sequence sequence = showSequence;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence);
			}
			showSequence = DOTween.Sequence();
			if ((bool)layoutElement)
			{
				TweenSettingsExtensions.PrependCallback(showSequence, delegate
				{
					layoutElement.ignoreLayout = true;
				});
			}
			if ((bool)rectTransform)
			{
				TweenSettingsExtensions.Insert(showSequence, shouldAnimate ? animationStartDelay : 0f, DOTweenModuleUI.DOAnchorPos(rectTransform, targetPos, duration));
			}
			else
			{
				TweenSettingsExtensions.Insert(showSequence, shouldAnimate ? animationStartDelay : 0f, ShortcutExtensions.DOMove(base.transform, targetPos, duration));
			}
			if (!shouldShow && shouldDisableOnHide)
			{
				TweenSettingsExtensions.OnComplete(showSequence, delegate
				{
					base.gameObject.SetActive(value: false);
				});
			}
			if ((bool)layoutElement)
			{
				TweenSettingsExtensions.AppendCallback(showSequence, delegate
				{
					layoutElement.ignoreLayout = false;
				});
			}
			if (shouldShow && shouldUpdateLayoutGroups)
			{
				TweenSettingsExtensions.OnComplete(showSequence, delegate
				{
					StartCoroutine(UiUtility.RebuildHorizontalOrVerticalLayoutGroupsNextFrame(layoutGroupsToUpdate));
				});
			}
		}

		private IEnumerator RebuildLayoutGroupNextFrame()
		{
			return new _003CRebuildLayoutGroupNextFrame_003Ed__41(0)
			{
				_003C_003E4__this = this
			};
		}

		private void UpdateHiddenAnchorPosFromRectTransform()
		{
			hiddenAnchorPos = originalAnchoredPos;
			if (shouldUseWidthRectTransformForHiddenAnchorPos)
			{
				if (shouldWidthRectTransformForHiddenAnchorPosBeAdded)
				{
					hiddenAnchorPos.x += Math.Abs(rectTransform.sizeDelta.x) + Math.Abs(originalPos.x);
				}
				else
				{
					hiddenAnchorPos.x -= Math.Abs(rectTransform.sizeDelta.x) + Math.Abs(originalPos.x);
				}
			}
			if (shouldUseHeightRectTransformForHiddenAnchorPos)
			{
				if (shouldHeightRectTransformForHiddenAnchorPosBeAdded)
				{
					hiddenAnchorPos.y += Math.Abs(rectTransform.sizeDelta.y) + Math.Abs(additionalPadding.y);
				}
				else
				{
					hiddenAnchorPos.y -= Math.Abs(rectTransform.sizeDelta.y) + Math.Abs(additionalPadding.y);
				}
			}
		}

		public void Lock(bool shouldLock, LockType newLockState = LockType.Regular)
		{
			if (currentLockState != LockType.LockedForever)
			{
				isLocked = shouldLock;
				currentLockState = newLockState;
			}
		}

		public void SetHiddenAnchoredPos(Vector2 targetHiddenAnchoredPos)
		{
			hiddenAnchorPos = targetHiddenAnchoredPos;
		}

		private void _003CStartSpawnAnimation_003Eb__40_0()
		{
			layoutElement.ignoreLayout = true;
		}

		private void _003CStartSpawnAnimation_003Eb__40_1()
		{
			base.gameObject.SetActive(value: false);
		}

		private void _003CStartSpawnAnimation_003Eb__40_2()
		{
			layoutElement.ignoreLayout = false;
		}

		private void _003CStartSpawnAnimation_003Eb__40_3()
		{
			StartCoroutine(UiUtility.RebuildHorizontalOrVerticalLayoutGroupsNextFrame(layoutGroupsToUpdate));
		}
	}
}
