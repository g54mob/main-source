using System;
using DG.Tweening;
using Restory.ObjectPools;
using Restory.UserInterface;
using Restory.UserInterface.ElementPresets;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_CleaningProgressDirtTypeSection : UIBehaviour, ICleanableComponent
	{
		[SerializeField]
		private TMP_Text numberText;

		[SerializeField]
		private GUI_LocalisedText dirtTypeNameText;

		[SerializeField]
		private TMP_Text progressText;

		[SerializeField]
		private Toggle completeToggle;

		[SerializeField]
		private Slider progressSlider;

		[SerializeField]
		private GUI_TaskAnimation taskAnimation;

		[SerializeField]
		private GUI_LocalisedText toolRequiredText;

		[SerializeField]
		private GUI_LocalisedText requiredToolNameText;

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName disabledPreset = PresetName.Disabled;

		[SerializeField]
		private float toggleFadeDuration = 0.5f;

		private TweenSequencesService tweenSequences;

		private Color checkmarkColor;

		private PresetName currentPreset;

		private Sequence transitionSequence;

		private readonly float initialCheckmarkScale = 0.7f;

		private readonly float middleCheckmarkScale = 2.1f;

		private readonly float targetCheckmarkScale = 1f;

		public bool IsInAnimation
		{
			get
			{
				if (!transitionSequence.IsActive())
				{
					return taskAnimation.InAnimation;
				}
				return true;
			}
		}

		public bool Deactivated => currentPreset == PresetName.Disabled;

		public event Action<GUI_CleaningProgressDirtTypeSection> OnCrossOutAnimationStarted;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
			checkmarkColor = completeToggle.graphic.color;
			checkmarkColor.a = 0f;
		}

		protected override void OnEnable()
		{
			taskAnimation.OnLineAnimationStarted += ResolveLineAnimationStarted;
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			if (transitionSequence.IsActive())
			{
				transitionSequence.Kill();
			}
			if (taskAnimation.MonoShellExists())
			{
				taskAnimation.OnLineAnimationStarted -= ResolveLineAnimationStarted;
			}
			base.OnDisable();
		}

		public void Activate()
		{
			SetPreset(normalPreset);
		}

		public void Deactivate()
		{
			SetPreset(disabledPreset);
		}

		public void SetUpInitialUncleanableState(int progressSectionNumber, string dirtTypeCleaningLocalizationKey, float progressValue, string toolRequiredLocalizationKey, string rustCleaningToolNameLocalizationKey)
		{
			SetUpInitialState(progressSectionNumber, dirtTypeCleaningLocalizationKey, progressValue);
			toolRequiredText.LocalizationID = toolRequiredLocalizationKey;
			requiredToolNameText.LocalizationID = rustCleaningToolNameLocalizationKey;
			SetPreset(disabledPreset);
		}

		public void SetUpInitialCleanableState(int progressSectionNumber, string dirtTypeCleaningLocalizationKey, float progressValue)
		{
			SetPreset(normalPreset);
			SetUpInitialState(progressSectionNumber, dirtTypeCleaningLocalizationKey, progressValue);
		}

		private void SetUpInitialState(int progressSectionNumber, string dirtTypeCleaningLocalizationKey, float progressValue)
		{
			numberText.text = $"{progressSectionNumber})";
			dirtTypeNameText.LocalizationID = dirtTypeCleaningLocalizationKey;
			progressSlider.value = progressValue;
			int num = (int)(progressValue * 100f);
			progressText.text = $"{num}%";
			completeToggle.isOn = progressValue >= 1f;
			taskAnimation.ResetTaskComplete();
		}

		public void UpdateProgress(float progressValue)
		{
			if (!completeToggle.isOn)
			{
				progressSlider.value = progressValue;
				int num = (int)(progressValue * 100f);
				progressText.text = $"{num}%";
				if (!(progressValue < 1f))
				{
					ShowToggleIcon();
					taskAnimation.PlayTaskComplete();
				}
			}
		}

		public void Clean()
		{
			numberText.text = string.Empty;
			dirtTypeNameText.LocalizationID = string.Empty;
			progressText.text = string.Empty;
			completeToggle.isOn = false;
			progressSlider.value = 0f;
			taskAnimation.ResetTaskComplete();
		}

		private void ShowToggleIcon()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			completeToggle.graphic.color = checkmarkColor;
			completeToggle.graphic.transform.localScale = Vector3.one * initialCheckmarkScale;
			completeToggle.isOn = true;
			Sequence sequence = DOTween.Sequence();
			sequence.Append(completeToggle.graphic.transform.DOScale(middleCheckmarkScale, toggleFadeDuration / 2f)).Append(completeToggle.graphic.transform.DOScale(targetCheckmarkScale, toggleFadeDuration / 2f));
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(completeToggle.graphic.DOFade(1f, toggleFadeDuration)).Join(sequence).SetEase(Ease.InQuad);
		}

		private void ResolveLineAnimationStarted()
		{
			this.OnCrossOutAnimationStarted?.Invoke(this);
		}

		private void SetPreset(PresetName presetName)
		{
			presetSwitcher.ActivatePreset(presetName);
			currentPreset = presetName;
		}
	}
}
