using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dorfromantik.UI
{
	public class UiStatsScreen : MonoBehaviour
	{
		private sealed class _003C_003Ec__DisplayClass37_0
		{
			public TextMeshProUGUI displayedStatsText;

			public UiStatsScreen _003C_003E4__this;

			internal void _003CAnimateStatsTexts_003Eb__0()
			{
				_003C_003E4__this.SetTextColorAlpha(displayedStatsText, 0);
			}
		}

		[SerializeField]
		internal bool isLeftSided;

		[SerializeField]
		private RewardSystem rewardSystem;

		[SerializeField]
		private SceneLoader sceneLoader;

		[SerializeField]
		private RectTransform titleTextContainer;

		[SerializeField]
		private RectTransform statsContainer;

		[SerializeField]
		private RectTransform statsContainerText;

		[SerializeField]
		private RectTransform statsBottomGradientContainer;

		[SerializeField]
		private List<RectTransform> classicModeStatRectTransforms;

		[SerializeField]
		private TooltipTarget perfectPlacementTooltipTarget;

		[SerializeField]
		private TextMeshProUGUI playtimeNumberLabel;

		[SerializeField]
		private TextMeshProUGUI tilesPlacedNumberLabel;

		[SerializeField]
		private TextMeshProUGUI completedQuestsLabel;

		[SerializeField]
		private TextMeshProUGUI perfectPlacementNumberLabel;

		[SerializeField]
		private TextMeshProUGUI completedFlagsLabel;

		[SerializeField]
		private TextMeshProUGUI currentScoreLabel;

		[SerializeField]
		private float animationTitleContainerDuration = 0.3f;

		[SerializeField]
		private float animationTitleTextDuration = 0.2f;

		[SerializeField]
		private float animationStatsContainerDuration = 0.3f;

		[SerializeField]
		private float animationStatsTextsDuration = 0.4f;

		[SerializeField]
		private float animationStatsTextsInterval = -0.35f;

		[SerializeField]
		private float animationStatsBottomGradientContainerDuration = 0.2f;

		[SerializeField]
		private bool isDisplayed;

		[SerializeField]
		private GameModeId currentGameMode;

		[SerializeField]
		private List<TextMeshProUGUI> displayedStatsTexts = new List<TextMeshProUGUI>();

		private Sequence onInteractionSequence;

		private TextMeshProUGUI titleTextLabel;

		private Dictionary<TextMeshProUGUI, string> textsByTextMeshProUGUI = new Dictionary<TextMeshProUGUI, string>();

		private List<TextMeshProUGUI> statsNumberTextMeshPros = new List<TextMeshProUGUI>();

		private void Awake()
		{
			LocalizationManager.Instance.OnLanguageChanged += UpdateCurrentDisplayedStatsTextsLists;
			sceneLoader.OnSceneLoaded += UpdateAndSetVisibilityForStatsTextsDependingOnGameMode;
		}

		private void Start()
		{
			titleTextLabel = titleTextContainer.GetComponentInChildren<TextMeshProUGUI>();
			isDisplayed = true;
			UpdateAndSetVisibilityForStatsTextsDependingOnGameMode(shouldOverrideCheck: true);
			UpdateCurrentDisplayedStatsTextsLists();
			ToggleStatsDetails(shouldAnimate: false);
		}

		private void OnDestroy()
		{
			if ((bool)LocalizationManager.Instance)
			{
				LocalizationManager.Instance.OnLanguageChanged -= UpdateCurrentDisplayedStatsTextsLists;
			}
			if ((bool)sceneLoader)
			{
				sceneLoader.OnSceneLoaded -= UpdateAndSetVisibilityForStatsTextsDependingOnGameMode;
			}
		}

		public void ToggleStatsDetails(bool shouldAnimate)
		{
			Sequence sequence = onInteractionSequence;
			if (sequence != null)
			{
				TweenExtensions.Kill(sequence, complete: true);
			}
			onInteractionSequence = DOTween.Sequence();
			isDisplayed = !isDisplayed;
			if (isDisplayed)
			{
				UpdateStats();
				AnimateTitleContainer(shouldAnimate);
				AnimateTitleText(shouldAnimate);
				AnimateStatsContainer(shouldAnimate);
				AnimateStatsContainerBottomGradient(shouldAnimate);
			}
			else
			{
				AnimateStatsContainerBottomGradient(shouldAnimate);
				AnimateStatsContainer(shouldAnimate);
				AnimateTitleText(shouldAnimate);
				AnimateTitleContainer(shouldAnimate);
			}
		}

		private void UpdateStats()
		{
			if (!(OverwritingSingleton<GameSession>.Instance == null) && !(OverwritingSingleton<IngameUi>.Instance == null))
			{
				statsNumberTextMeshPros.Clear();
				int num = Mathf.FloorToInt(rewardSystem.Playtime / 3600f);
				int num2 = Mathf.FloorToInt((rewardSystem.Playtime - (float)(num * 3600)) / 60f);
				playtimeNumberLabel.text = $"{num:#0}:{num2:00}";
				statsNumberTextMeshPros.Add(playtimeNumberLabel);
				tilesPlacedNumberLabel.text = OverwritingSingleton<IngameUi>.Instance.world.TotalTileCount.ToString();
				statsNumberTextMeshPros.Add(tilesPlacedNumberLabel);
				perfectPlacementNumberLabel.text = rewardSystem.PerfectPlacementCount.ToString();
				int surroundedTilesCount = rewardSystem.SurroundedTilesCount;
				perfectPlacementTooltipTarget.enabled = surroundedTilesCount > 0;
				if (surroundedTilesCount > 0)
				{
					perfectPlacementNumberLabel.text += $" ({(float)rewardSystem.PerfectPlacementCount / (float)surroundedTilesCount * 100f:##0.0}%)";
				}
				statsNumberTextMeshPros.Add(perfectPlacementNumberLabel);
				completedQuestsLabel.text = rewardSystem.Level.ToString();
				statsNumberTextMeshPros.Add(completedQuestsLabel);
				completedFlagsLabel.text = (rewardSystem.QuestFulfilledCount - rewardSystem.Level).ToString();
				statsNumberTextMeshPros.Add(completedFlagsLabel);
				currentScoreLabel.text = rewardSystem.Score.ToString();
				statsNumberTextMeshPros.Add(currentScoreLabel);
				UpdateStatsValuesInTextDictionary();
			}
		}

		private void AnimateTitleContainer(bool shouldAnimate = true)
		{
			float endValue = 0f;
			if (isDisplayed)
			{
				endValue = 1f;
			}
			TweenSettingsExtensions.Append(onInteractionSequence, ShortcutExtensions.DOScaleX(titleTextContainer, endValue, shouldAnimate ? animationTitleContainerDuration : 0f));
		}

		private void AnimateTitleText(bool shouldAnimate = true)
		{
			string endValue = " ";
			if (isDisplayed)
			{
				endValue = titleTextLabel.GetComponent<LocalizedText>().textString;
			}
			TweenSettingsExtensions.Append(onInteractionSequence, ShortcutExtensionsTMPText.DOText(titleTextLabel, endValue, shouldAnimate ? animationTitleTextDuration : 0f));
		}

		private void AnimateStatsContainer(bool shouldAnimate = true)
		{
			TweenSettingsExtensions.Append(onInteractionSequence, ShortcutExtensions.DOScaleY(statsContainer, isDisplayed ? 1 : 0, shouldAnimate ? animationStatsContainerDuration : 0f));
		}

		private void AnimateStatsContainerBottomGradient(bool shouldAnimate = true)
		{
			TweenSettingsExtensions.Append(onInteractionSequence, ShortcutExtensions.DOScaleY(statsBottomGradientContainer, isDisplayed ? 1f : 0f, shouldAnimate ? animationStatsBottomGradientContainerDuration : 0f));
		}

		private void AnimateStatsTexts(bool shouldAnimate = true)
		{
			using List<TextMeshProUGUI>.Enumerator enumerator = displayedStatsTexts.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass37_0();
				CS_0024_003C_003E8__locals11._003C_003E4__this = this;
				CS_0024_003C_003E8__locals11.displayedStatsText = enumerator.Current;
				if (!CS_0024_003C_003E8__locals11.displayedStatsText.gameObject.activeSelf)
				{
					continue;
				}
				if (isDisplayed)
				{
					CS_0024_003C_003E8__locals11.displayedStatsText.text = " ";
					SetTextColorAlpha(CS_0024_003C_003E8__locals11.displayedStatsText, 1);
					TweenSettingsExtensions.Append(onInteractionSequence, ShortcutExtensionsTMPText.DOText(CS_0024_003C_003E8__locals11.displayedStatsText, textsByTextMeshProUGUI[CS_0024_003C_003E8__locals11.displayedStatsText], shouldAnimate ? animationStatsTextsDuration : 0f));
				}
				else
				{
					TweenSettingsExtensions.Append(onInteractionSequence, ShortcutExtensionsTMPText.DOText(CS_0024_003C_003E8__locals11.displayedStatsText, " ", shouldAnimate ? animationStatsTextsDuration : 0f));
				}
				if (Enumerable.Last(displayedStatsTexts) != CS_0024_003C_003E8__locals11.displayedStatsText)
				{
					TweenSettingsExtensions.AppendInterval(onInteractionSequence, animationStatsTextsInterval);
				}
				if (!isDisplayed)
				{
					TweenSettingsExtensions.AppendCallback(onInteractionSequence, delegate
					{
						CS_0024_003C_003E8__locals11._003C_003E4__this.SetTextColorAlpha(CS_0024_003C_003E8__locals11.displayedStatsText, 0);
					});
				}
			}
		}

		public void HideStatsDetailsFromMenuHidden(bool showMenu)
		{
			if (isDisplayed && !showMenu)
			{
				ToggleStatsDetails(shouldAnimate: true);
			}
		}

		private void UpdateCurrentDisplayedStatsTextsLists()
		{
			UpdateStats();
			displayedStatsTexts.Clear();
			displayedStatsTexts = Enumerable.ToList(statsContainerText.GetComponentsInChildren<TextMeshProUGUI>());
			textsByTextMeshProUGUI.Clear();
			foreach (TextMeshProUGUI displayedStatsText in displayedStatsTexts)
			{
				textsByTextMeshProUGUI.Add(displayedStatsText, displayedStatsText.text ?? "");
			}
			currentGameMode = OverwritingSingleton<GameSession>.Instance.GameMode.id;
		}

		private void UpdateStatsValuesInTextDictionary()
		{
			foreach (TextMeshProUGUI statsNumberTextMeshPro in statsNumberTextMeshPros)
			{
				if (textsByTextMeshProUGUI.ContainsKey(statsNumberTextMeshPro))
				{
					textsByTextMeshProUGUI[statsNumberTextMeshPro] = statsNumberTextMeshPro.text;
				}
			}
		}

		private void SetTextColorAlpha(TextMeshProUGUI text, int alpha)
		{
			if (alpha < 0 || alpha > 1)
			{
				throw new ArgumentException($"passed alpha value for text color must be between 0 and 1! ({this})");
			}
			Color color = text.color;
			color.a = alpha;
			text.color = color;
		}

		private void UpdateAndSetVisibilityForStatsTextsDependingOnGameMode(bool shouldOverrideCheck = false)
		{
			if (!OverwritingSingleton<GameSession>.Instance && !shouldOverrideCheck)
			{
				return;
			}
			if (OverwritingSingleton<GameSession>.Instance.GameMode.id == GameModeId.Creative)
			{
				foreach (RectTransform classicModeStatRectTransform in classicModeStatRectTransforms)
				{
					classicModeStatRectTransform.gameObject.SetActive(value: false);
				}
				return;
			}
			foreach (RectTransform classicModeStatRectTransform2 in classicModeStatRectTransforms)
			{
				classicModeStatRectTransform2.gameObject.SetActive(value: true);
			}
		}

		private void UpdateAndSetVisibilityForStatsTextsDependingOnGameMode(Scene scene)
		{
			UpdateAndSetVisibilityForStatsTextsDependingOnGameMode();
		}
	}
}
