using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Dorfromantik.UI.Components;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dorfromantik.UI.Ingame
{
	public class UiGameOverScreen : MonoBehaviour
	{
		[SerializeField]
		private RewardSystem rewardSystem;

		[SerializeField]
		private LeaderboardManager leaderboardManager;

		[SerializeField]
		private Button tryAgainButton;

		[SerializeField]
		private Button saveButton;

		[SerializeField]
		private Selectable defaultSelectable;

		[SerializeField]
		private List<HideableUi> additionalObjectsToHideOnGameOver;

		[SerializeField]
		private List<HideableUi> additionalObjectsToShowOnGameOver;

		[SerializeField]
		private TextMeshProUGUI scoreLabel;

		[SerializeField]
		private UiIconButtonIngame undoButton;

		[SerializeField]
		private HorizontalOrVerticalLayoutGroup undoButtonParentLayoutGroupWhilePlaying;

		[SerializeField]
		private HorizontalOrVerticalLayoutGroup undoButtonParentLayoutGroupWhileGameover;

		[SerializeField]
		private RectTransform undoButtonSpacerToTileStack;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private InteractionRestriction interactionRestriction;

		[SerializeField]
		private RectTransform titleLabelRectTransform;

		[SerializeField]
		private RectTransform highscoreLabelRectTransform;

		[SerializeField]
		private float animationTitleSpawnDuration = 0.5f;

		[SerializeField]
		private float animationTitleShowDuration = 2f;

		[SerializeField]
		private float animationTitlePunchScaleFactor = 0.08f;

		[SerializeField]
		private float animationTitlePunchDuration = 0.2f;

		[SerializeField]
		private float animationScoreInitialDelay = 0.3f;

		[SerializeField]
		private float animationScoreDuration = 0.5f;

		[SerializeField]
		private float animationScorePunchScaleFactor = 0.08f;

		[SerializeField]
		private float animationScorePunchDuration = 0.2f;

		[SerializeField]
		private float undoToTileStackSpacerAnimationDuration = 0.1f;

		[SerializeField]
		private float bottomRightHorizontalLayoutGroupAnimationDuration = 0.1f;

		[SerializeField]
		private float animationHidingPlayUiGameObjectsDuration = 0.5f;

		[SerializeField]
		private bool isShown;

		[SerializeField]
		private int bottomRightUndoHorizontalLayoutGroupPaddingRightDefault;

		[SerializeField]
		private Vector2 bottomRightUndoToTileStackSpacerDefaultSizeDelta;

		private Sequence onInteractionSequence;

		private Sequence onTitleScoreSequence;

		private Sequence onScoreSequence;

		private Sequence onUndoButtonAnimationSequence;

		public bool DBG_hasNewHighscore;

		private void Awake()
		{
			Show(shouldShow: false, shouldAnimate: false, isCalledOnInitialize: true);
			if (defaultSelectable == null)
			{
				defaultSelectable = saveButton;
			}
		}

		private void OnEnable()
		{
			rewardSystem.OnScoreChanged += UpdateScoreLabel;
			inputRouter.SetInteractionRestriction(interactionRestriction);
			if (bottomRightUndoHorizontalLayoutGroupPaddingRightDefault == 0 && (bool)undoButtonParentLayoutGroupWhilePlaying)
			{
				bottomRightUndoHorizontalLayoutGroupPaddingRightDefault = undoButtonParentLayoutGroupWhilePlaying.padding.right;
			}
			if ((bool)undoButtonSpacerToTileStack)
			{
				bottomRightUndoToTileStackSpacerDefaultSizeDelta = undoButtonSpacerToTileStack.sizeDelta;
			}
		}

		internal void Show(bool shouldShow, bool shouldAnimate = true, bool isCalledOnInitialize = false)
		{
			onInteractionSequence = KillAndRecreateSequence(onInteractionSequence);
			base.gameObject.SetActive(shouldShow);
			UpdateScoreLabel(rewardSystem.Score);
			AnimateTitleAndScore(shouldAnimate);
			AnimateUndoButton(shouldShow, shouldAnimate);
			if ((bool)Singleton<MainMenuUi>.Instance)
			{
				Singleton<MainMenuUi>.Instance.ShowScoreScreen(inputRouter.GameState == GameState.NavigationBar || shouldShow, inputRouter.GameState == GameState.NavigationBar || !shouldShow);
			}
			if (!isCalledOnInitialize)
			{
				UpdateVisibilityForAdditionalObjectsToHideOnGameOver(shouldShow, shouldAnimate);
			}
			UpdateVisibilityForAdditionalObjectsToShowOnGameOver(shouldShow, shouldAnimate);
			isShown = shouldShow;
			if (shouldShow && inputRouter.GameState == GameState.Playing)
			{
				Debug.Log($"GameOver screen - select {defaultSelectable}");
				defaultSelectable.Select();
			}
			else if (!shouldShow && !isCalledOnInitialize)
			{
				defaultSelectable.OnDeselect(null);
				EventSystem.current.SetSelectedGameObject(null);
			}
		}

		private void UpdateVisibilityForAdditionalObjectsToHideOnGameOver(bool shouldShow, bool shouldAnimate)
		{
			foreach (HideableUi item in additionalObjectsToHideOnGameOver)
			{
				if ((bool)item)
				{
					if (!shouldShow)
					{
						item.Lock(shouldLock: false);
					}
					item.Show(!shouldShow, shouldAnimate);
					if (shouldShow)
					{
						item.Lock(shouldLock: true);
					}
				}
			}
		}

		private void UpdateVisibilityForAdditionalObjectsToShowOnGameOver(bool shouldShow, bool shouldAnimate)
		{
			foreach (HideableUi item in additionalObjectsToShowOnGameOver)
			{
				if ((bool)item)
				{
					item.Show(shouldShow, shouldAnimate);
				}
			}
		}

		private void AnimateUndoButton(bool isGameOverState, bool shouldAnimate)
		{
			if (!undoButton)
			{
				return;
			}
			List<HorizontalOrVerticalLayoutGroup> list = new List<HorizontalOrVerticalLayoutGroup>();
			if (isGameOverState)
			{
				undoButton.transform.parent = undoButtonParentLayoutGroupWhileGameover.transform;
				undoButton.transform.SetAsLastSibling();
				list.Add(undoButtonParentLayoutGroupWhileGameover);
				if ((bool)undoButtonParentLayoutGroupWhileGameover.GetComponentInParent<HorizontalOrVerticalLayoutGroup>())
				{
					list.Add(undoButtonParentLayoutGroupWhileGameover.GetComponentInParent<HorizontalOrVerticalLayoutGroup>());
				}
			}
			else
			{
				undoButton.transform.parent = undoButtonParentLayoutGroupWhilePlaying.transform;
				undoButton.transform.SetAsFirstSibling();
				list.Add(undoButtonParentLayoutGroupWhilePlaying);
				if ((bool)undoButtonParentLayoutGroupWhilePlaying.GetComponentInParent<HorizontalOrVerticalLayoutGroup>())
				{
					list.Add(undoButtonParentLayoutGroupWhilePlaying.GetComponentInParent<HorizontalOrVerticalLayoutGroup>());
				}
			}
			UiUtility.RebuildHorizontalOrVerticalLayoutGroupsAndCanvas(list);
		}

		private void DBG_ToggleShow()
		{
			Show(!isShown);
		}

		private void AnimateTitleAndScore(bool shouldAnimate = true)
		{
			onTitleScoreSequence = KillAndRecreateSequence(onTitleScoreSequence);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(titleLabelRectTransform, isShown ? Vector2.zero : Vector2.one, animationTitleSpawnDuration);
			TweenSettingsExtensions.Append(onTitleScoreSequence, tweenerCore);
			if (!isShown)
			{
				Tweener t = ShortcutExtensions.DOPunchScale(titleLabelRectTransform, Vector2.one * animationTitlePunchScaleFactor, animationTitlePunchDuration);
				TweenSettingsExtensions.Append(onTitleScoreSequence, t);
				TweenSettingsExtensions.AppendInterval(onTitleScoreSequence, animationTitleShowDuration);
				TweenSettingsExtensions.Append(onTitleScoreSequence, ShortcutExtensions.DOScale(titleLabelRectTransform, Vector2.zero, animationTitleSpawnDuration));
			}
			onScoreSequence = KillAndRecreateSequence(onScoreSequence);
			TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(highscoreLabelRectTransform, isShown ? Vector2.zero : Vector2.one, animationScoreDuration);
			TweenSettingsExtensions.Append(onScoreSequence, t2);
			if (!isShown)
			{
				TweenSettingsExtensions.Append(onScoreSequence, ShortcutExtensions.DOPunchScale(highscoreLabelRectTransform, Vector2.one * animationScorePunchScaleFactor, animationScorePunchDuration));
			}
			TweenSettingsExtensions.Insert(onTitleScoreSequence, tweenerCore.position + animationScoreInitialDelay, onScoreSequence);
			if (!isShown)
			{
				_ = DBG_hasNewHighscore;
			}
			if (!isShown)
			{
				TweenSettingsExtensions.PrependCallback(onTitleScoreSequence, delegate
				{
					titleLabelRectTransform.gameObject.SetActive(value: true);
				});
			}
			else
			{
				TweenSettingsExtensions.AppendCallback(onTitleScoreSequence, delegate
				{
					titleLabelRectTransform.gameObject.SetActive(value: false);
				});
			}
			TweenSettingsExtensions.Append(onInteractionSequence, onTitleScoreSequence);
		}

		private Sequence KillAndRecreateSequence(Sequence sequence)
		{
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			return DOTween.Sequence();
		}

		private void UpdateScoreLabel(int newScore)
		{
			scoreLabel.text = rewardSystem.Score.ToString();
			_ = leaderboardManager.GetCurrentLeaderboard() == null;
		}

		private void OnDisable()
		{
			rewardSystem.OnScoreChanged -= UpdateScoreLabel;
		}

		public void SelectDefault()
		{
			defaultSelectable.Select();
		}

		private void _003CAnimateTitleAndScore_003Eb__42_0()
		{
			titleLabelRectTransform.gameObject.SetActive(value: true);
		}

		private void _003CAnimateTitleAndScore_003Eb__42_1()
		{
			titleLabelRectTransform.gameObject.SetActive(value: false);
		}
	}
}
