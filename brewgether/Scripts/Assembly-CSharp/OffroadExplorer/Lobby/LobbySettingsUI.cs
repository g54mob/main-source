using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace OffroadExplorer.Lobby
{
	public class LobbySettingsUI
	{
		private readonly VisualElement _root;

		private Button _tabGraphics;

		private Button _tabAudio;

		private Button _tabControls;

		private VisualElement _contentGraphics;

		private VisualElement _contentAudio;

		private VisualElement _contentControls;

		private DropdownField _dropdownResolution;

		private DropdownField _dropdownFullscreen;

		private Toggle _toggleVsync;

		private DropdownField _dropdownTargetFps;

		private DropdownField _dropdownQuality;

		private DropdownField _dropdownShadows;

		private DropdownField _dropdownAA;

		private Slider _sliderRenderScale;

		private Label _valueRenderScale;

		private Slider _sliderFov;

		private Label _valueFov;

		private Slider _sliderBrightness;

		private Label _valueBrightness;

		private Slider _sliderGamma;

		private Label _valueGamma;

		private Slider _sliderShadowLift;

		private Label _valueShadowLift;

		private Slider _sliderMaster;

		private Label _valueMaster;

		private Slider _sliderMusic;

		private Label _valueMusic;

		private Slider _sliderSfx;

		private Label _valueSfx;

		private Slider _sliderAmbience;

		private Label _valueAmbience;

		private Slider _sliderVoice;

		private Label _valueVoice;

		private Slider _sliderVehicle;

		private Label _valueVehicle;

		private Slider _sliderMic;

		private Label _valueMic;

		private Toggle _toggleMicMute;

		private Slider _sliderSensX;

		private Label _valueSensX;

		private Slider _sliderSensY;

		private Label _valueSensY;

		private Button _btnApply;

		private Button _btnReset;

		private Button _btnBack;

		private List<Resolution> _availableResolutions;

		private bool _isUpdatingUI;

		private VisualElement _resolutionConfirmOverlay;

		private Label _resolutionConfirmCountdown;

		private bool _subscribedToResolutionEvents;

		private static readonly int[] FpsValues;

		private static readonly int[] ShadowValues;

		private static readonly int[] AAValues;

		private static string[] FullscreenOptions => null;

		private static string[] FpsOptions => null;

		private static string[] QualityOptions => null;

		private static string[] ShadowOptions => null;

		private static string[] AAOptions => null;

		public event Action OnBackRequested
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public LobbySettingsUI(VisualElement root)
		{
		}

		public void OnScreenShown()
		{
		}

		public void Dispose()
		{
		}

		private void SubscribeToResolutionEvents()
		{
		}

		private void QueryElements()
		{
		}

		private void RegisterCallbacks()
		{
		}

		private static string FormatPercent(float v)
		{
			return null;
		}

		private static void BindSliderLabel(Slider slider, Label label, Func<float, string> fmt)
		{
		}

		private static void EnableSliderClickToPosition(Slider slider)
		{
		}

		private void CreateResolutionConfirmationOverlay()
		{
		}

		private void OnResolutionConfirmationNeeded(float secondsRemaining)
		{
		}

		private void OnResolutionConfirmationComplete(bool wasConfirmed)
		{
		}

		private void SwitchTab(string tab)
		{
		}

		private static void SetTabActive(Button tab, bool active)
		{
		}

		private static void SetContentVisible(VisualElement content, bool visible)
		{
		}

		private void PopulateDropdowns()
		{
		}

		public void LoadCurrentSettings()
		{
		}

		private static void SetSlider(Slider slider, Label label, float value, Func<float, string> fmt)
		{
		}

		private void OnResolutionChanged(ChangeEvent<string> evt)
		{
		}

		private void OnFullscreenChanged(ChangeEvent<string> evt)
		{
		}

		private void OnVSyncChanged(ChangeEvent<bool> evt)
		{
		}

		private void OnTargetFPSChanged(ChangeEvent<string> evt)
		{
		}

		private void OnQualityPresetChanged(ChangeEvent<string> evt)
		{
		}

		private void OnShadowQualityChanged(ChangeEvent<string> evt)
		{
		}

		private void OnAntiAliasingChanged(ChangeEvent<string> evt)
		{
		}

		private void OnRenderScaleChanged(ChangeEvent<float> evt)
		{
		}

		private void OnFOVChanged(ChangeEvent<float> evt)
		{
		}

		private void OnBrightnessChanged(ChangeEvent<float> evt)
		{
		}

		private void OnGammaChanged(ChangeEvent<float> evt)
		{
		}

		private void OnShadowLiftChanged(ChangeEvent<float> evt)
		{
		}

		private void OnMasterVolumeChanged(ChangeEvent<float> evt)
		{
		}

		private void OnMusicVolumeChanged(ChangeEvent<float> evt)
		{
		}

		private void OnSFXVolumeChanged(ChangeEvent<float> evt)
		{
		}

		private void OnAmbienceVolumeChanged(ChangeEvent<float> evt)
		{
		}

		private void OnVoiceVolumeChanged(ChangeEvent<float> evt)
		{
		}

		private void OnVehicleVolumeChanged(ChangeEvent<float> evt)
		{
		}

		private void OnMicVolumeChanged(ChangeEvent<float> evt)
		{
		}

		private void OnMicMuteChanged(ChangeEvent<bool> evt)
		{
		}

		private void OnMouseSensitivityXChanged(ChangeEvent<float> evt)
		{
		}

		private void OnMouseSensitivityYChanged(ChangeEvent<float> evt)
		{
		}

		private void OnApplyClicked()
		{
		}

		private void OnResetClicked()
		{
		}
	}
}
