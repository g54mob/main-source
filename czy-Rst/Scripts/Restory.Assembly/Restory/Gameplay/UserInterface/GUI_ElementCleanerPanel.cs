using System;
using DG.Tweening;
using Mandragora.PWS;
using Restory.Data.Localization;
using Restory.Gameplay.Cleaning;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Soldering;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_ElementCleanerPanel : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private float fadeDuration = 0.5f;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private GUI_CleaningProgressModal cleaningProgressModal;

		private TweenSequencesService tweenSequences;

		private LocalizationSystem localizationSystem;

		private Sequence transitionSequence;

		public bool InAnimation => cleaningProgressModal.InAnimation;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences, LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
			this.tweenSequences = tweenSequences;
		}

		public void Initialize()
		{
			canvasGroup.alpha = 0f;
			base.gameObject.SetActive(value: false);
		}

		public void Dispose()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
				transitionSequence = null;
			}
		}

		public void Init(ElementBase element, InitialCleaningData initialCleaningData)
		{
			cleaningProgressModal.Init(localizationSystem.GetTranslation(element.Info.NameLocalizationKey), initialCleaningData);
		}

		public void ResetCleaningProgressToNewValue(InitialCleaningData initialCleaningData)
		{
			cleaningProgressModal.SetInitialProgress(initialCleaningData);
		}

		public void UpdateCleaningProgress(CleaningProgressInPercentage cleaningProgress, SolderingProgressInPercentage solderingProgress)
		{
			cleaningProgressModal.UpdateCleaningProgress(cleaningProgress, solderingProgress);
		}

		public void UpdateSolderingProgress(SolderingProgressInPercentage solderingProgress)
		{
			cleaningProgressModal.UpdateSolderingProgress(solderingProgress);
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(canvasGroup.DOFade(1f, fadeDuration)).SetEase(Ease.InQuad);
		}

		public void Hide()
		{
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(canvasGroup.DOFade(0f, fadeDuration)).SetEase(Ease.OutQuad).OnComplete(delegate
			{
				base.gameObject.SetActive(value: false);
			});
		}
	}
}
