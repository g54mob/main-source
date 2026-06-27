using System;
using System.Collections.Generic;
using DG.Tweening;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Views.SettingsMenu
{
	public class GUI_SettingsMenuView : MonoBehaviour
	{
		private const string SOUND_GROUP = "Sound";

		private const string LANGUAGE_GROUP = "Language";

		private const string GRAPHICS_GROUP = "Graphics";

		[SerializeField]
		private Button closeButton;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		[Min(0f)]
		private float showHideDuration = 0.25f;

		[SerializeField]
		private Slider masterVolumeSlider;

		[SerializeField]
		private Slider musicVolumeSlider;

		[SerializeField]
		private Slider sfxVolumeSlider;

		[SerializeField]
		private TMP_Dropdown languageDropdown;

		[SerializeField]
		private TMP_Dropdown resolutionDropdown;

		[SerializeField]
		private TMP_Dropdown screenModeDropdown;

		[SerializeField]
		private TMP_Dropdown monitorDropdown;

		[SerializeField]
		private Toggle vSyncToggle;

		[SerializeField]
		private TMP_Dropdown fpsLockDropdown;

		private Sequence currentSequence;

		private TweenSequencesService tweenSequencesService;

		public event Action OnCloseClicked;

		public event Action<float> OnMasterVolumeChanged;

		public event Action<float> OnMusicVolumeChanged;

		public event Action<float> OnSFXVolumeChanged;

		public event Action<int> OnLanguageChanged;

		public event Action<int> OnResolutionChanged;

		public event Action<int> OnScreenModeChanged;

		public event Action<int> OnMonitorChanged;

		public event Action<bool> OnVSyncChanged;

		public event Action<int> OnFpsLockChanged;

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		private void OnEnable()
		{
			masterVolumeSlider.onValueChanged.AddListener(ResolveMasterVolumeSliderOnValueChanged);
			musicVolumeSlider.onValueChanged.AddListener(ResolveMusicVolumeSliderOnValueChanged);
			sfxVolumeSlider.onValueChanged.AddListener(ResolveSFXVolumeSliderOnValueChanged);
			languageDropdown.onValueChanged.AddListener(ResolveLanguageChanged);
			resolutionDropdown.onValueChanged.AddListener(ResolveResolutionChanged);
			screenModeDropdown.onValueChanged.AddListener(ResolveScreenModeChanged);
			monitorDropdown.onValueChanged.AddListener(ResolveMonitorChanged);
			vSyncToggle.onValueChanged.AddListener(ResolveVSyncChanged);
			fpsLockDropdown.onValueChanged.AddListener(ResolveFpsLockChanged);
			closeButton.onClick.AddListener(ResolveCloseButtonOnClick);
		}

		private void OnDisable()
		{
			masterVolumeSlider.onValueChanged.RemoveListener(ResolveMasterVolumeSliderOnValueChanged);
			musicVolumeSlider.onValueChanged.RemoveListener(ResolveMusicVolumeSliderOnValueChanged);
			sfxVolumeSlider.onValueChanged.RemoveListener(ResolveSFXVolumeSliderOnValueChanged);
			languageDropdown.onValueChanged.RemoveListener(ResolveLanguageChanged);
			resolutionDropdown.onValueChanged.RemoveListener(ResolveResolutionChanged);
			screenModeDropdown.onValueChanged.RemoveListener(ResolveScreenModeChanged);
			monitorDropdown.onValueChanged.RemoveListener(ResolveMonitorChanged);
			vSyncToggle.onValueChanged.RemoveListener(ResolveVSyncChanged);
			fpsLockDropdown.onValueChanged.RemoveListener(ResolveFpsLockChanged);
			closeButton.onClick.RemoveListener(ResolveCloseButtonOnClick);
		}

		public void Show()
		{
			if (tweenSequencesService == null)
			{
				canvasGroup.alpha = 1f;
				base.gameObject.SetActive(value: true);
				return;
			}
			tweenSequencesService.Kill(currentSequence);
			currentSequence = tweenSequencesService.Create();
			currentSequence.OnStart(delegate
			{
				base.gameObject.SetActive(value: true);
			});
			currentSequence.SetUpdate(isIndependentUpdate: true);
			currentSequence.Append(canvasGroup.DOFade(1f, showHideDuration));
		}

		public void Hide()
		{
			if (tweenSequencesService == null)
			{
				canvasGroup.alpha = 0f;
				base.gameObject.SetActive(value: false);
				return;
			}
			tweenSequencesService.Kill(currentSequence);
			currentSequence = tweenSequencesService.Create();
			currentSequence.SetUpdate(isIndependentUpdate: true);
			currentSequence.Append(canvasGroup.DOFade(0f, showHideDuration));
			currentSequence.OnComplete(delegate
			{
				base.gameObject.SetActive(value: false);
			});
		}

		public void SetMasterVolumeValue(float value, bool notify)
		{
			SetSliderValue(masterVolumeSlider, value, notify);
		}

		public void SetMusicVolumeValue(float value, bool notify)
		{
			SetSliderValue(musicVolumeSlider, value, notify);
		}

		public void SetSFXVolumeValue(float value, bool notify)
		{
			SetSliderValue(sfxVolumeSlider, value, notify);
		}

		public void SetLanguageIndex(int index, bool notify)
		{
			if (notify)
			{
				languageDropdown.value = index;
			}
			else
			{
				languageDropdown.SetValueWithoutNotify(index);
			}
		}

		public void SetLanguageOptions(List<string> options)
		{
			languageDropdown.ClearOptions();
			languageDropdown.AddOptions(options);
		}

		public void SetResolutionIndex(int index, bool notify)
		{
			if (notify)
			{
				resolutionDropdown.value = index;
			}
			else
			{
				resolutionDropdown.SetValueWithoutNotify(index);
			}
		}

		public void SetResolutionOptions(List<string> options)
		{
			resolutionDropdown.ClearOptions();
			resolutionDropdown.AddOptions(options);
		}

		public void SetScreenModeIndex(int index, bool notify)
		{
			if (notify)
			{
				screenModeDropdown.value = index;
			}
			else
			{
				screenModeDropdown.SetValueWithoutNotify(index);
			}
		}

		public void SetMonitorIndex(int index, bool notify)
		{
			if (notify)
			{
				monitorDropdown.value = index;
			}
			else
			{
				monitorDropdown.SetValueWithoutNotify(index);
			}
		}

		public void SetMonitorOptions(List<string> options)
		{
			monitorDropdown.ClearOptions();
			monitorDropdown.AddOptions(options);
		}

		public void SetVSyncEnabled(bool enabled, bool notify)
		{
			if (notify)
			{
				vSyncToggle.isOn = enabled;
			}
			else
			{
				vSyncToggle.SetIsOnWithoutNotify(enabled);
			}
		}

		public void SetFpsLockIndex(int index, bool notify)
		{
			if (notify)
			{
				fpsLockDropdown.value = index;
			}
			else
			{
				fpsLockDropdown.SetValueWithoutNotify(index);
			}
		}

		public void SetFpsLockOptions(List<string> options)
		{
			fpsLockDropdown.ClearOptions();
			fpsLockDropdown.AddOptions(options);
		}

		private void SetSliderValue(Slider slider, float value, bool notify)
		{
			if (notify)
			{
				slider.value = value;
			}
			else
			{
				slider.SetValueWithoutNotify(value);
			}
		}

		private void ResolveMasterVolumeSliderOnValueChanged(float value)
		{
			this.OnMasterVolumeChanged?.Invoke(value);
		}

		private void ResolveMusicVolumeSliderOnValueChanged(float value)
		{
			this.OnMusicVolumeChanged?.Invoke(value);
		}

		private void ResolveSFXVolumeSliderOnValueChanged(float value)
		{
			this.OnSFXVolumeChanged?.Invoke(value);
		}

		private void ResolveLanguageChanged(int index)
		{
			this.OnLanguageChanged?.Invoke(index);
		}

		private void ResolveResolutionChanged(int index)
		{
			this.OnResolutionChanged?.Invoke(index);
		}

		private void ResolveScreenModeChanged(int index)
		{
			this.OnScreenModeChanged?.Invoke(index);
		}

		private void ResolveMonitorChanged(int index)
		{
			this.OnMonitorChanged?.Invoke(index);
		}

		private void ResolveVSyncChanged(bool value)
		{
			this.OnVSyncChanged?.Invoke(value);
		}

		private void ResolveFpsLockChanged(int index)
		{
			this.OnFpsLockChanged?.Invoke(index);
		}

		private void ResolveCloseButtonOnClick()
		{
			this.OnCloseClicked?.Invoke();
		}
	}
}
