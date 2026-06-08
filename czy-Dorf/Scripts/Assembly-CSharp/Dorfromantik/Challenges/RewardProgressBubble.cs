using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dorfromantik.Challenges
{
	public class RewardProgressBubble : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
	{
		private sealed class _003CSetupAfterDelay_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CSetupAfterDelay_003Ed__26(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E2__current = new WaitForSeconds(1.5f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
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
		private RawImage tileDisplay;

		[SerializeField]
		private Image progressBar;

		[SerializeField]
		private GameObject pinIcon;

		[SerializeField]
		private GameObject inProgressContainer;

		[SerializeField]
		private GameObject completedContainer;

		[SerializeField]
		private VfxManager vfxManager;

		private SessionQuestTooltip tooltip;

		private RewardTileViewer tileViewer;

		private SessionQuestBar sessionQuestBar;

		private RewardState levelState;

		public int index;

		private Sequence scaleAnimation;

		private Tween moveTween;

		private WatchedSessionQuest watchedSessionQuest;

		private RectTransform rectTransform;

		public SessionQuest Challenge => watchedSessionQuest.SessionQuest;

		private int WatchLevel => watchedSessionQuest.WatchLevel;

		private bool EffectWasWatched
		{
			get
			{
				return watchedSessionQuest.EffectWasWatched;
			}
			set
			{
				watchedSessionQuest.EffectWasWatched = value;
			}
		}

		public void Setup(int index, WatchedSessionQuest watchedSessionQuest, RewardTileViewer tileViewer, SessionQuestBar sessionQuestBar)
		{
			this.watchedSessionQuest = watchedSessionQuest;
			watchedSessionQuest.UpdateLevel(Challenge.CurrentLevelIndex);
			this.tileViewer = tileViewer;
			this.sessionQuestBar = sessionQuestBar;
			this.index = index;
			levelState = Challenge.GetLevelState(WatchLevel);
			base.name = "ChallengeUi " + Challenge.name;
			tileDisplay.texture = tileViewer.GetRenderTexture(WatchLevel, RewardState.InProgress);
			Challenge.OnProgressChanged -= UpdateProgressBar;
			Challenge.OnFulfillmentChanged -= UpdateFulfillmentDisplay;
			vfxManager.OnChallengeRewardClaimed -= ProceedAfterClaim;
			Challenge.OnPinned -= UpdatePinIcon;
			Challenge.OnProgressChanged += UpdateProgressBar;
			Challenge.OnFulfillmentChanged += UpdateFulfillmentDisplay;
			vfxManager.OnChallengeRewardClaimed += ProceedAfterClaim;
			Challenge.OnPinned += UpdatePinIcon;
			UpdateProgressBar(Challenge.GetCurrentProgress(WatchLevel));
			UpdateFulfillmentDisplay(Challenge, WatchLevel);
			UpdatePinIcon(Challenge.isPinned);
		}

		private void UpdatePinIcon(bool isPinned)
		{
			if (!this)
			{
				Debug.LogError("SessionQuestIngameDisplay is null but wants to Update Pin Icon");
			}
			else if (pinIcon == null)
			{
				Debug.LogError(base.name + " tries to update pinIcon but it's null", this);
			}
			else
			{
				pinIcon.SetActive(isPinned);
			}
		}

		private void ProceedAfterClaim(SessionQuest claimedChallenge, int claimedLevel)
		{
			if (claimedChallenge == Challenge && claimedLevel == WatchLevel)
			{
				Setup(index, watchedSessionQuest, tileViewer, sessionQuestBar);
				sessionQuestBar.ReorderDisplays();
			}
		}

		private void UpdateFulfillmentDisplay(SessionQuest sessionQuest, int fulfilledLevel)
		{
			if (!this)
			{
				Debug.LogError("SessionQuestIngameDisplay is null but wants to UpdateFulfillmentDisplay");
				return;
			}
			levelState = sessionQuest.GetLevelState(WatchLevel);
			inProgressContainer.SetActive(levelState != RewardState.Completed);
			completedContainer.SetActive(sessionQuest.CurrentState == RewardState.Completed);
			if (levelState == RewardState.Completed)
			{
				Sequence sequence = scaleAnimation;
				if (sequence != null)
				{
					TweenExtensions.Kill(sequence, complete: true);
				}
				scaleAnimation = DOTween.Sequence();
				TweenSettingsExtensions.Insert(scaleAnimation, 0f, ShortcutExtensions.DOPunchScale(base.transform, Vector3.one * 0.3f, 1.2f));
				TweenSettingsExtensions.Append(scaleAnimation, TweenSettingsExtensions.SetDelay(TweenSettingsExtensions.SetLoops(ShortcutExtensions.DOPunchRotation(base.transform, Vector3.right * 10f, 1.2f), -1, LoopType.Restart), 1f));
				completedContainer.SetActive(value: true);
				if (watchedSessionQuest.SessionQuest.CurrentState != RewardState.Completed)
				{
					if (base.gameObject.activeInHierarchy)
					{
						StartCoroutine(SetupAfterDelay());
					}
					else
					{
						Setup(index, watchedSessionQuest, tileViewer, sessionQuestBar);
					}
				}
			}
			else if (WatchLevel != Challenge.CurrentLevelIndex)
			{
				watchedSessionQuest.UpdateLevel(sessionQuest.CurrentLevelIndex);
				Setup(index, watchedSessionQuest, tileViewer, sessionQuestBar);
			}
		}

		private IEnumerator SetupAfterDelay()
		{
			return new _003CSetupAfterDelay_003Ed__26(0);
		}

		private void UpdateProgressBar(int currentProgress)
		{
			if (!this)
			{
				Challenge.OnProgressChanged -= UpdateProgressBar;
				Debug.LogWarning("SessionQuestIngameDisplay still listens to SessionQuest even after it was destroyed");
				return;
			}
			if (WatchLevel > Challenge.CurrentLevelIndex)
			{
				watchedSessionQuest.UpdateLevel(Challenge.CurrentLevelIndex);
				Setup(index, watchedSessionQuest, tileViewer, sessionQuestBar);
			}
			DOTweenModuleUI.DOFillAmount(progressBar, (float)Challenge.GetCurrentProgress(WatchLevel) / (float)Challenge.TargetCount(WatchLevel), 0.3f);
			completedContainer.SetActive(Challenge.GetCurrentProgress(WatchLevel) / Challenge.TargetCount(WatchLevel) >= 1);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			sessionQuestBar.ShowTooltip(index, Challenge, WatchLevel);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (Challenge.CurrentState != RewardState.Completed)
			{
				Challenge.Pin(!Challenge.isPinned);
				Challenge.OverwriteSaveState();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			sessionQuestBar.ShowTooltip(index, null, -1);
		}

		public void Destroy()
		{
			Challenge.OnProgressChanged -= UpdateProgressBar;
			Challenge.OnFulfillmentChanged -= UpdateFulfillmentDisplay;
			Challenge.OnPinned -= UpdatePinIcon;
			vfxManager.OnChallengeRewardClaimed -= ProceedAfterClaim;
		}

		public float GetProgress()
		{
			if (Challenge.CurrentState != RewardState.Completed)
			{
				return (float)Challenge.GetCurrentProgress(WatchLevel) / (float)Challenge.TargetCount(WatchLevel);
			}
			return 0f;
		}

		public void MoveTo(Vector2 targetAnchorPos, float animationDuration, bool deactivateOnComplete)
		{
			if (!rectTransform)
			{
				rectTransform = GetComponent<RectTransform>();
			}
			Tween tween = moveTween;
			if (tween != null)
			{
				TweenExtensions.Kill(tween);
			}
			if (animationDuration > 0f)
			{
				moveTween = TweenSettingsExtensions.SetEase(DOTweenModuleUI.DOAnchorPos(rectTransform, targetAnchorPos, animationDuration), Ease.InOutSine);
				if (deactivateOnComplete)
				{
					TweenSettingsExtensions.OnComplete(moveTween, delegate
					{
						base.gameObject.SetActive(value: false);
					});
				}
			}
			else
			{
				rectTransform.anchoredPosition = targetAnchorPos;
				if (deactivateOnComplete)
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}

		private void _003CMoveTo_003Eb__33_0()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
