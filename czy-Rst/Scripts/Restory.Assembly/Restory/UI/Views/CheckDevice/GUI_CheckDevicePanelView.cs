using DG.Tweening;
using Restory.UserInterface;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Views.CheckDevice
{
	public sealed class GUI_CheckDevicePanelView : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup titleCanvasGroup;

		[SerializeField]
		private GUI_LocalisedText titleText;

		[SerializeField]
		[Min(0f)]
		private float titleFadeDuration = 0.3f;

		[SerializeField]
		private CanvasGroup errorCanvasGroup;

		[SerializeField]
		private GUI_LocalisedText errorText;

		[SerializeField]
		[Min(0f)]
		private float errorFadeDuration = 0.3f;

		private Sequence titleSequence;

		private Sequence errorSequence;

		private TweenSequencesService tweenSequences;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		public void ShowTitle(string titleLocalizationID, bool instantly)
		{
			if (titleSequence != null)
			{
				tweenSequences.Kill(titleSequence);
			}
			titleText.LocalizationID = titleLocalizationID;
			if (instantly)
			{
				titleCanvasGroup.gameObject.SetActive(value: true);
				titleCanvasGroup.alpha = 1f;
				return;
			}
			titleSequence = tweenSequences.Create();
			titleSequence.OnStart(delegate
			{
				titleCanvasGroup.gameObject.SetActive(value: true);
			});
			titleSequence.Append(titleCanvasGroup.DOFade(1f, titleFadeDuration));
		}

		public void HideTitle()
		{
			if (titleSequence != null)
			{
				tweenSequences.Kill(titleSequence);
			}
			titleSequence = tweenSequences.Create();
			titleSequence.Append(titleCanvasGroup.DOFade(0f, titleFadeDuration));
			titleSequence.OnComplete(delegate
			{
				titleCanvasGroup.gameObject.SetActive(value: false);
			});
		}

		public void ShowError(string errorLocalizationID, bool instantly)
		{
			if (errorSequence != null)
			{
				tweenSequences.Kill(errorSequence);
			}
			errorText.LocalizationID = errorLocalizationID;
			if (instantly)
			{
				errorCanvasGroup.gameObject.SetActive(value: true);
				errorCanvasGroup.alpha = 1f;
				return;
			}
			errorSequence = tweenSequences.Create();
			errorSequence.OnStart(delegate
			{
				errorCanvasGroup.gameObject.SetActive(value: true);
			});
			errorSequence.Append(errorCanvasGroup.DOFade(1f, errorFadeDuration));
		}

		public void HideError()
		{
			if (errorSequence != null)
			{
				tweenSequences.Kill(errorSequence);
			}
			errorSequence = tweenSequences.Create();
			errorSequence.Append(errorCanvasGroup.DOFade(0f, errorFadeDuration));
			errorSequence.OnComplete(delegate
			{
				errorCanvasGroup.gameObject.SetActive(value: false);
			});
		}
	}
}
