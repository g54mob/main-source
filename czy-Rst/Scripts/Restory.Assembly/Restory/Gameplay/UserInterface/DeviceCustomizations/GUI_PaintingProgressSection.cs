using System;
using DG.Tweening;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.Equipment;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.ObjectPools;
using Restory.UserInterface;
using Restory.UserInterface.ElementPresets;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.Gameplay.UserInterface.DeviceCustomizations
{
	public class GUI_PaintingProgressSection : UIBehaviour, ICleanableComponent
	{
		[SerializeField]
		private TMP_Text numberText;

		[SerializeField]
		private GUI_LocalisedText descriptionText;

		[SerializeField]
		private TMP_Text progressText;

		[SerializeField]
		private Toggle completeToggle;

		[SerializeField]
		private Slider progressSlider;

		[SerializeField]
		private GUI_TaskAnimation taskAnimation;

		[SerializeField]
		private GameObject paletteRequiredContainer;

		[SerializeField]
		private Toggle requiredPaletteWasAppliedToggle;

		[SerializeField]
		private GUI_LocalisedText paletteRequiredText;

		[SerializeField]
		private GUI_LocalisedText requiredPaletteNameText;

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

		private PaintingPaletteInfo requiredPalette;

		private PaintableDevice paintableDevice;

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

		public event Action<GUI_PaintingProgressSection> OnCrossOutAnimationStarted;

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

		public void Initialize(int progressSectionNumber, PaintableDevice paintableDevice, DeviceWorkType deviceWorkType, PaintingPaletteInfo requiredPaletteInfo, float progressValue)
		{
			this.paintableDevice = paintableDevice;
			requiredPalette = requiredPaletteInfo;
			SetPreset(normalPreset);
			SetUpInitialState(progressSectionNumber, progressValue);
			SetUpDescription(deviceWorkType);
			SetUpPaletteSection(requiredPaletteInfo);
		}

		private void SetUpDescription(DeviceWorkType deviceWorkType)
		{
			descriptionText.LocalizationID = deviceWorkType.LocalizationKey;
		}

		private void SetUpPaletteSection(PaintingPaletteInfo requiredPaletteInfo)
		{
			if (paletteRequiredContainer.activeSelf != (bool)requiredPaletteInfo)
			{
				paletteRequiredContainer.SetActive(requiredPaletteInfo);
			}
			if ((bool)requiredPaletteInfo)
			{
				requiredPaletteNameText.LocalizationID = requiredPaletteInfo.NameLocalizationKey;
			}
			if ((bool)requiredPaletteWasAppliedToggle)
			{
				requiredPaletteWasAppliedToggle.isOn = false;
			}
		}

		private void SetUpInitialState(int progressSectionNumber, float progressValue)
		{
			numberText.text = $"{progressSectionNumber})";
			progressSlider.value = progressValue;
			int num = (int)(progressValue * 100f);
			progressText.text = $"{num}%";
			completeToggle.isOn = progressValue >= 1f;
			taskAnimation.ResetTaskComplete();
		}

		public void UpdateProgress(float progressValue)
		{
			UpdatePaletteCheckmark();
			progressSlider.value = progressValue;
			int num = (int)(progressValue * 100f);
			progressText.text = $"{num}%";
			if (progressValue >= 1f)
			{
				if (!taskAnimation.InAnimation && !taskAnimation.IsTaskCompletePlayed)
				{
					ShowToggleIcon();
					taskAnimation.PlayTaskComplete();
				}
			}
			else
			{
				taskAnimation.ResetTaskComplete();
			}
		}

		private void UpdatePaletteCheckmark()
		{
			if ((bool)requiredPaletteWasAppliedToggle && (bool)paintableDevice)
			{
				requiredPaletteWasAppliedToggle.isOn = paintableDevice.ContainsPalette(requiredPalette);
			}
		}

		public void Clean()
		{
			numberText.text = string.Empty;
			descriptionText.LocalizationID = string.Empty;
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
