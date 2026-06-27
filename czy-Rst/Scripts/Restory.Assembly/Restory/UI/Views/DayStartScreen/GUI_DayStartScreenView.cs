using System;
using DG.Tweening;
using Restory.Data.Localization;
using Restory.Data.TimeSystems;
using Restory.Utils;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.UI.Views.DayStartScreen
{
	public class GUI_DayStartScreenView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI dayText;

		[SerializeField]
		private string firstDayLocalizationKey;

		[SerializeField]
		private string dayLocalizationKey;

		[SerializeField]
		private GameObject screen;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		[Min(0f)]
		private float showHideDuration = 1f;

		private LocalizationSystem localizationSystem;

		private TweenSequencesService tweenSequences;

		private Sequence showHideSequence;

		public float CanvasGroupAlpha => canvasGroup.alpha;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem, TweenSequencesService tweenSequences)
		{
			this.localizationSystem = localizationSystem;
			this.tweenSequences = tweenSequences;
		}

		public void Show(bool instantly)
		{
			if (showHideSequence != null)
			{
				tweenSequences.Kill(showHideSequence);
				showHideSequence = null;
			}
			if (instantly)
			{
				screen.SetActive(value: true);
				canvasGroup.alpha = 1f;
				canvasGroup.blocksRaycasts = true;
				canvasGroup.interactable = true;
				return;
			}
			showHideSequence = tweenSequences.Create();
			showHideSequence.OnStart(delegate
			{
				screen.SetActive(value: true);
				canvasGroup.blocksRaycasts = true;
			}).Append(canvasGroup.DOFade(1f, showHideDuration)).OnComplete(delegate
			{
				canvasGroup.interactable = true;
			});
		}

		public void Hide(bool instantly, Action onFullyHiddenCallback = null)
		{
			if (showHideSequence != null)
			{
				tweenSequences.Kill(showHideSequence);
				showHideSequence = null;
			}
			if (instantly)
			{
				screen.SetActive(value: false);
				canvasGroup.alpha = 0f;
				canvasGroup.blocksRaycasts = false;
				canvasGroup.interactable = false;
				return;
			}
			showHideSequence = tweenSequences.Create();
			showHideSequence.OnStart(delegate
			{
				canvasGroup.interactable = false;
			}).Append(canvasGroup.DOFade(0f, showHideDuration)).OnComplete(delegate
			{
				canvasGroup.blocksRaycasts = false;
				screen.SetActive(value: false);
				onFullyHiddenCallback?.Invoke();
			});
		}

		public void SetText(int day, DayOfWeekInfo dayOfWeekInfo)
		{
			base.gameObject.SetActive(value: true);
			if (day == 1)
			{
				dayText.text = localizationSystem.GetTranslation(firstDayLocalizationKey);
			}
			else
			{
				dayText.text = $"{localizationSystem.GetTranslation(dayLocalizationKey)} {day}, {localizationSystem.GetTranslation(dayOfWeekInfo.LocalizationKey)}";
			}
		}
	}
}
