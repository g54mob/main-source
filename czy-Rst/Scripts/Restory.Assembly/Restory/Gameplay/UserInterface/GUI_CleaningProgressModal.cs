using System;
using DG.Tweening;
using Mandragora.PWS;
using Restory.Data.Elements.Condition;
using Restory.Data.Equipment;
using Restory.Gameplay.Cleaning;
using Restory.Gameplay.Soldering;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_CleaningProgressModal : MonoBehaviour
	{
		[SerializeField]
		private Image elementStateIcon;

		[SerializeField]
		private TMP_Text elementNameText;

		[SerializeField]
		private DirtyElementCondition dirtyElementCondition;

		[SerializeField]
		private BurntElementCondition burntElementCondition;

		[SerializeField]
		private float stateIconSizeChangeDuration = 2.5f;

		[SerializeField]
		private GUI_CleaningProgressDirtTypeSection sectionDirt;

		[SerializeField]
		private GUI_CleaningProgressDirtTypeSection sectionRust;

		[SerializeField]
		private GUI_CleaningProgressDirtTypeSection sectionBurnt;

		[SerializeField]
		private string dirtCleanLocalizationKey;

		[SerializeField]
		private string rustCleanLocalizationKey;

		[SerializeField]
		private string burntResolderLocalizationKey;

		[SerializeField]
		private string toolRequiredLocalizationKey;

		[SerializeField]
		private CleaningToolInfo rustCleaningTool;

		private TweenSequencesService tweenSequences;

		private Sequence iconSequence;

		private CleaningProgressInPercentage initialCleaningProgress;

		private CleaningProgressInPercentage currentCleaningProgress;

		private SolderingProgressInPercentage initialSolderingProgress;

		private SolderingProgressInPercentage currentSolderingProgress;

		private CleaningProgressWeights cleaningProgressWeights;

		private int nextSectionNumber;

		public bool InAnimation
		{
			get
			{
				if (!iconSequence.IsActive() && !sectionDirt.IsInAnimation)
				{
					return sectionBurnt.IsInAnimation;
				}
				return true;
			}
		}

		public event Action OnNonFinalDirtSectionCrossOutAnimationStarted;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void OnDisable()
		{
			if (sectionDirt.MonoShellExists())
			{
				sectionDirt.OnCrossOutAnimationStarted -= ResolveCrossOutAnimationStarted;
			}
			if (sectionRust.MonoShellExists())
			{
				sectionRust.OnCrossOutAnimationStarted -= ResolveCrossOutAnimationStarted;
			}
			if (sectionBurnt.MonoShellExists())
			{
				sectionBurnt.OnCrossOutAnimationStarted -= ResolveCrossOutAnimationStarted;
			}
		}

		private void OnDestroy()
		{
			if (iconSequence != null)
			{
				tweenSequences.Kill(iconSequence);
			}
		}

		public void Init(string elementName, InitialCleaningData initialCleaningData)
		{
			elementNameText.text = elementName;
			SetInitialProgress(initialCleaningData);
		}

		public void SetInitialProgress(InitialCleaningData initialCleaningData)
		{
			initialCleaningProgress = initialCleaningData.CleaningProgress;
			currentCleaningProgress = initialCleaningProgress;
			initialSolderingProgress = initialCleaningData.SolderingProgress;
			currentSolderingProgress = initialSolderingProgress;
			cleaningProgressWeights = initialCleaningData.GetWeights();
			nextSectionNumber = 1;
			SetupDirtSection();
			SetupRustSection();
			SetupBurntSection();
		}

		private void SetupDirtSection()
		{
			if (initialCleaningProgress.RedAndGreenChannel < 1f || initialSolderingProgress.Soot < 1f)
			{
				SetUpCleaningProgressSection(sectionDirt, CalculateCombinedDirtCleaningProgress(), dirtCleanLocalizationKey);
				sectionDirt.gameObject.SetActive(value: true);
			}
			else
			{
				sectionDirt.gameObject.SetActive(value: false);
			}
		}

		private void SetupRustSection()
		{
			if (initialCleaningProgress.BlueChannel < 1f)
			{
				SetUpCleaningProgressSection(sectionRust, currentCleaningProgress.BlueChannel, rustCleanLocalizationKey);
				sectionRust.gameObject.SetActive(value: true);
			}
			else
			{
				sectionRust.gameObject.SetActive(value: false);
			}
		}

		private void SetupBurntSection()
		{
			if (initialSolderingProgress.IsResoldered())
			{
				elementStateIcon.sprite = dirtyElementCondition.Icon;
				sectionBurnt.gameObject.SetActive(value: false);
				return;
			}
			SetUpCleaningProgressSection(sectionBurnt, initialSolderingProgress.Burnt, burntResolderLocalizationKey);
			sectionBurnt.gameObject.SetActive(value: true);
			if (initialSolderingProgress.Soot < 1f || !initialCleaningProgress.IsFullyCleaned())
			{
				elementStateIcon.sprite = dirtyElementCondition.Icon;
				sectionBurnt.Deactivate();
			}
			else
			{
				elementStateIcon.sprite = burntElementCondition.Icon;
			}
		}

		public void UpdateCleaningProgress(CleaningProgressInPercentage cleaningProgress, SolderingProgressInPercentage solderingProgress)
		{
			currentCleaningProgress = cleaningProgress;
			currentSolderingProgress = solderingProgress;
			if (sectionDirt.gameObject.activeSelf)
			{
				sectionDirt.UpdateProgress(CalculateCombinedDirtCleaningProgress());
			}
			if (sectionRust.gameObject.activeSelf)
			{
				sectionRust.UpdateProgress(currentCleaningProgress.BlueChannel);
			}
		}

		public void UpdateSolderingProgress(SolderingProgressInPercentage solderingProgress)
		{
			if (initialSolderingProgress.IsResoldered() || solderingProgress.UnconfirmedProgress)
			{
				return;
			}
			currentSolderingProgress = solderingProgress;
			if (currentCleaningProgress.IsFullyCleaned() && !(currentSolderingProgress.Soot < 1f))
			{
				if (sectionBurnt.Deactivated)
				{
					sectionBurnt.Activate();
					elementStateIcon.sprite = burntElementCondition.Icon;
				}
				else
				{
					sectionBurnt.UpdateProgress(solderingProgress.Burnt);
				}
			}
		}

		private void ChangeElementStateIcon(Sprite newIcon)
		{
			if (iconSequence != null)
			{
				tweenSequences.Kill(iconSequence);
			}
			iconSequence = tweenSequences.Create();
			iconSequence.Append(elementStateIcon.rectTransform.DOScale(1.5f, stateIconSizeChangeDuration * 0.25f)).Append(elementStateIcon.rectTransform.DOScale(0f, stateIconSizeChangeDuration * 0.25f)).AppendCallback(delegate
			{
				elementStateIcon.sprite = newIcon;
			})
				.Append(elementStateIcon.rectTransform.DOScale(1.5f, stateIconSizeChangeDuration * 0.25f))
				.Append(elementStateIcon.rectTransform.DOScale(1f, stateIconSizeChangeDuration * 0.25f));
		}

		private void SetUpCleaningProgressSection(GUI_CleaningProgressDirtTypeSection targetSection, float initialCleaningProgressChannelValue, string dirtTypeCleanLocalizationKey)
		{
			targetSection.OnCrossOutAnimationStarted -= ResolveCrossOutAnimationStarted;
			if (initialCleaningProgressChannelValue < 1f)
			{
				targetSection.SetUpInitialCleanableState(nextSectionNumber++, dirtTypeCleanLocalizationKey, initialCleaningProgressChannelValue);
				targetSection.gameObject.SetActive(value: true);
				targetSection.OnCrossOutAnimationStarted += ResolveCrossOutAnimationStarted;
			}
			else
			{
				targetSection.gameObject.SetActive(value: false);
			}
		}

		private void ResolveCrossOutAnimationStarted(GUI_CleaningProgressDirtTypeSection dirtTypeSection)
		{
			if (!currentCleaningProgress.IsFullyCleaned() || !currentSolderingProgress.IsResoldered())
			{
				this.OnNonFinalDirtSectionCrossOutAnimationStarted?.Invoke();
			}
		}

		private float CalculateCombinedDirtCleaningProgress()
		{
			return currentCleaningProgress.RedAndGreenChannel * cleaningProgressWeights.RedAndGreenChannelsWeight + currentSolderingProgress.Soot * cleaningProgressWeights.SootWeight;
		}
	}
}
