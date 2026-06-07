using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using FrostweepGames.Plugins.DesktopRuntimeMonitorSwitch;
using UltimateReplay;
using UnityEngine;

public class OptionsController : BaseController<OptionsView, OptionsModel>
{
	private LanguagesManager languagesManager;

	private bool shouldSaveValuesOnDisk;

	private float saveOnDiskTimerCounter;

	private bool wasDisplayScreenChanged;

	private bool wasLanguageChanged;

	private DisplayInfo[] displays;

	public OptionsController(OptionsView view, OptionsModel model, LanguagesManager languagesManager)
		: base(view, model, true)
	{
		this.languagesManager = languagesManager;
		displays = RuntimeMonitorSwitchLib.GetDisplays().ToArray();
		view.LanguageSelector.ClearAllTexts();
		foreach (KeyValuePair<string, string> item in languagesManager.GetLanguagesConfig())
		{
			view.LanguageSelector.AddText(item.Key, item.Value);
		}
		UpdateDisplayComboBoxOptions();
		UpdateResolutionComboBoxOptions();
		UpdateFPSLimitLabels();
		UpdateGraphicQualityLabels();
		UpdateReplayAccuracyLabels();
		languagesManager.OnLanguageChangedEvent += delegate
		{
			UpdateDisplayComboBoxOptions();
			UpdateFPSLimitLabels();
			UpdateGraphicQualityLabels();
			UpdateReplayAccuracyLabels();
		};
		GameManager.Instance.UpdateAuxiliary += UpdateAuxiliary;
		RebuildView();
	}

	protected override void SyncViewWithModel()
	{
		view.LanguageSelector.SetSelectedText(model.Language);
		view.SetVolumes(model.MasterVolume, model.MusicVolume, model.EffectsVolume);
		view.SetEnableCheatsToggleValue(model.IsCheatsEnabled);
		view.SetFullscreenToggleValue(model.IsFullscreen);
		view.SetBorderlessToggleValue(model.IsBorderless);
		view.SetVSyncActivatedToggleValue(model.IsVSyncActivated);
		view.FPSLimitSelector.SetSelectedText(model.FPSLimitValue.ToString());
		view.QualitySelector.SetSelectedText(model.GraphicQualityValue.ToString());
		view.SetCameraSensitivity(model.CameraSensitivity);
		view.SetCameraKeysToggleValue(model.IsCameraKeysDisabled);
		view.SetCameraKeys(model.CameraForwardKey, model.CameraBackwardKey, model.CameraLeftKey, model.CameraRightKey, model.CameraUpKey, model.CameraDownKey);
		view.SetAxesJoystickToggleValue(model.IsJoystickAxesDisabled);
		view.SetCameraJoystickToggleValue(model.IsJoystickCameraControlDisabled);
		view.DisplayComboBox.SetComboBoxIndexSelected(model.DisplayIndex);
		UpdateResolutionComboBoxValue();
		view.SetReplayDisableToggleValue(model.IsReplayDisabled);
		view.ReplayAccuracySelector.SetSelectedText(model.ReplayAccuracyValue.ToString());
		view.SetReplayRemoveAudiosValue(model.ShouldRemoveAudiosReplay);
		view.SetReplayRemoveDecalsValue(model.ShouldRemoveDecalsReplay);
		view.SetReplayRemoveParticlesValue(model.ShouldRemoveParticlesReplay);
		view.SetApplyButtonInteractivity(isInteractable: false);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "OptionsModel.ValuesChangedEvent"))
		{
			if (eventName == "OptionsModel.SaveValuesOnDiskEvent")
			{
				shouldSaveValuesOnDisk = true;
				saveOnDiskTimerCounter = 0f;
			}
			return;
		}
		bool flag = (bool)data[0];
		languagesManager.SetCurrentLanguage(model.Language, flag && wasLanguageChanged);
		wasLanguageChanged = false;
		GameManager.Instance.MasterAudioMixer.SetFloat("MasterVolume", Util.LinearToDecibel(model.MasterVolume / 10f));
		GameManager.Instance.MusicAudioMixer.SetFloat("MusicVolume", Util.LinearToDecibel(model.MusicVolume / 10f));
		GameManager.Instance.EffectsAudioMixer.SetFloat("EffectsVolume", Util.LinearToDecibel(model.EffectsVolume / 10f));
		if (!Application.isEditor)
		{
			FullScreenMode fullScreenMode = ((!model.IsFullscreen) ? FullScreenMode.Windowed : (model.IsBorderless ? FullScreenMode.FullScreenWindow : FullScreenMode.ExclusiveFullScreen));
			if (wasDisplayScreenChanged)
			{
				PlayerPrefs.SetInt("UnitySelectMonitor", model.DisplayIndex);
				RuntimeMonitorSwitchLib.SetDisplay(model.DisplayIndex, model.ScreenWidth, model.ScreenHeight, model.IsFullscreen);
				view.StartCoroutine(LateUpdateToNativeResolution());
			}
			else
			{
				if (model.IsNativeResolution)
				{
					Resolution resolution = Screen.resolutions[Screen.resolutions.Length - 1];
					if (Screen.currentResolution.width != resolution.width || Screen.currentResolution.height != resolution.height || Screen.currentResolution.refreshRate != resolution.refreshRate)
					{
						model.ScreenWidth = resolution.width;
						model.ScreenHeight = resolution.height;
						model.ScreenRefreshRate = resolution.refreshRate;
						Screen.SetResolution(model.ScreenWidth, model.ScreenHeight, fullScreenMode, model.ScreenRefreshRate);
					}
				}
				if (!model.IsNativeResolution)
				{
					Screen.SetResolution(model.ScreenWidth, model.ScreenHeight, fullScreenMode, model.ScreenRefreshRate);
				}
				if (fullScreenMode != Screen.fullScreenMode && model.IsNativeResolution)
				{
					Screen.fullScreenMode = fullScreenMode;
				}
			}
		}
		QualitySettings.vSyncCount = (model.IsVSyncActivated ? 1 : 0);
		UpdateFPSLimitValue(model.FPSLimitValue);
		UpdateGraphicQualityValue(model.GraphicQualityValue);
		GameManager.Instance.CameraManager.SetCamerasSensitivity(model.CameraSensitivity);
		GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardUsability(!model.IsCameraKeysDisabled);
		GameManager.Instance.CameraManager.OrbitCamera.SetMovementKeys(model.CameraForwardKey, model.CameraBackwardKey, model.CameraLeftKey, model.CameraRightKey, model.CameraUpKey, model.CameraDownKey);
		GameManager.Instance.CameraManager.OrbitCamera.IsJoystickRotationActive = !model.IsJoystickCameraControlDisabled;
		SetAllReplayButtonsInteractive(!model.IsReplayDisabled);
		UpdateReplayAccuracyValue(model.ReplayAccuracyValue);
		AudioEffectsManager.Instance.SetAudioReplayStatus(model.ShouldRemoveAudiosReplay);
		VisualEffectsManager.Instance.SetDecalsReplayStatus(model.ShouldRemoveDecalsReplay);
		VisualEffectsManager.Instance.SetParticlesReplayStatus(model.ShouldRemoveParticlesReplay);
		GUIManager.Instance.ReplayView.GifRecordingView.SetRecordingSettings(model.GifDuration, model.GifFPS, model.GifSize, model.GifQuality);
		IEnumerator LateUpdateToNativeResolution()
		{
			yield return new WaitForEndOfFrame();
			SetNativeResolution();
			UpdateResolutionComboBoxOptions();
			UpdateResolutionComboBoxValue();
			wasDisplayScreenChanged = false;
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		string headerText;
		string infoText;
		switch (eventName)
		{
		case "OptionsView.ApplyButtonEvent":
		{
			if (model.Language != view.LanguageSelector.GetSelectedTextId())
			{
				model.Language = view.LanguageSelector.GetSelectedTextId();
				wasLanguageChanged = true;
			}
			model.MasterVolume = view.GetMasterVolume();
			model.MusicVolume = view.GetMusicVolume();
			model.EffectsVolume = view.GetEffectsVolume();
			model.IsCheatsEnabled = view.GetEnableCheatsToggleValue();
			int selectedIndex = view.DisplayComboBox.GetSelectedIndex();
			if (model.DisplayIndex != selectedIndex)
			{
				model.DisplayIndex = selectedIndex;
				wasDisplayScreenChanged = true;
			}
			int selectedIndex2 = view.ResolutionComboBox.GetSelectedIndex();
			if (selectedIndex2 < Screen.resolutions.Length && !wasDisplayScreenChanged && (Screen.currentResolution.width != Screen.resolutions[selectedIndex2].width || Screen.currentResolution.height != Screen.resolutions[selectedIndex2].height || Screen.currentResolution.refreshRate != Screen.resolutions[selectedIndex2].refreshRate))
			{
				model.ScreenWidth = Screen.resolutions[selectedIndex2].width;
				model.ScreenHeight = Screen.resolutions[selectedIndex2].height;
				model.ScreenRefreshRate = Screen.resolutions[selectedIndex2].refreshRate;
				model.IsNativeResolution = false;
			}
			model.IsFullscreen = view.IsFullscreenActivated();
			model.IsBorderless = view.IsBorderlessActivated();
			model.IsVSyncActivated = view.IsVSyncActivated();
			if (Enum.TryParse<OptionsModel.FPSLimit>(view.FPSLimitSelector.GetSelectedTextId(), out var result))
			{
				model.FPSLimitValue = result;
			}
			if (Enum.TryParse<OptionsModel.GraphicQuality>(view.QualitySelector.GetSelectedTextId(), out var result2))
			{
				model.GraphicQualityValue = result2;
			}
			model.CameraSensitivity = view.GetCameraSensitivity();
			model.IsCameraKeysDisabled = view.IsCameraKeysDisabled();
			model.CameraForwardKey = view.GetCameraForwardKey();
			model.CameraBackwardKey = view.GetCameraBackwardKey();
			model.CameraLeftKey = view.GetCameraLeftKey();
			model.CameraRightKey = view.GetCameraRightKey();
			model.CameraUpKey = view.GetCameraUpKey();
			model.CameraDownKey = view.GetCameraDownKey();
			model.IsJoystickAxesDisabled = view.GetAxesJoystickToggleValue();
			model.IsJoystickCameraControlDisabled = view.GetCameraJoystickToggleValue();
			model.IsReplayDisabled = view.IsReplayDisabled();
			if (Enum.TryParse<OptionsModel.ReplayAccuracy>(view.ReplayAccuracySelector.GetSelectedTextId(), out var result3))
			{
				model.ReplayAccuracyValue = result3;
			}
			model.ShouldRemoveAudiosReplay = view.ShouldReplayRemoveAudios();
			model.ShouldRemoveDecalsReplay = view.ShouldReplayRemoveDecals();
			model.ShouldRemoveParticlesReplay = view.ShouldReplayRemoveParticles();
			model.ApplyOptions();
			view.SetApplyButtonInteractivity(isInteractable: false);
			SaveValuesOnDisk();
			break;
		}
		case "OptionsView.CloseButtonEvent":
			GameManager.Instance.ExitSubState();
			break;
		case "OptionsView.ClearProfileButtonEvent":
			if (File.Exists(PathNames.UserProfileAES))
			{
				File.Delete(PathNames.UserProfileAES);
			}
			RemoveAllSaveFiles(PathNames.BestCreationsCampaign);
			RemoveAllSaveFiles(PathNames.BestCreationsSandbox);
			headerText = LanguagesManager.Instance.GetText("message.header.options.restart");
			infoText = LanguagesManager.Instance.GetText("message.infos.options.restart");
			view.StartCoroutine(ShowRestartMessageDelay());
			break;
		}
		void RemoveAllSaveFiles(string directoryPath)
		{
			if (Directory.Exists(directoryPath))
			{
				string[] files = Directory.GetFiles(directoryPath, "*.sav", SearchOption.TopDirectoryOnly);
				for (int i = 0; i < files.Length; i++)
				{
					File.Delete(files[i]);
				}
			}
		}
		IEnumerator ShowRestartMessageDelay()
		{
			yield return new WaitForSeconds(0.15f);
			GUIManager.Instance.ShowMessageBox(headerText, infoText, delegate
			{
			}, isCancelEnabled: false);
		}
	}

	private void SetNativeResolution()
	{
		Resolution resolution = Screen.resolutions[Screen.resolutions.Length - 1];
		model.ScreenWidth = resolution.width;
		model.ScreenHeight = resolution.height;
		model.ScreenRefreshRate = resolution.refreshRate;
		Screen.SetResolution(model.ScreenWidth, model.ScreenHeight, model.IsFullscreen, model.ScreenRefreshRate);
		model.IsNativeResolution = true;
	}

	private void UpdateDisplayComboBoxOptions()
	{
		string text = languagesManager.GetText("label.text.options.monitor", "Monitor");
		int num = 1;
		view.DisplayComboBox.ClearOptions();
		DisplayInfo[] array = displays;
		for (int i = 0; i < array.Length; i++)
		{
			_ = array[i];
			view.DisplayComboBox.AddComboBoxOption($"{text} {num++}");
		}
		view.DisplayComboBox.SetComboBoxIndexSelected(model.DisplayIndex);
	}

	private void UpdateResolutionComboBoxOptions()
	{
		view.ResolutionComboBox.ClearOptions();
		Resolution[] resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i++)
		{
			Resolution resolution = resolutions[i];
			view.ResolutionComboBox.AddComboBoxOption(resolution.width + "x" + resolution.height + " (" + resolution.refreshRate + " Hz)");
		}
	}

	private void UpdateResolutionComboBoxValue()
	{
		bool flag = false;
		if (!model.IsNativeResolution)
		{
			for (int i = 0; i < Screen.resolutions.Length; i++)
			{
				if (model.ScreenWidth == Screen.resolutions[i].width && model.ScreenHeight == Screen.resolutions[i].height && model.ScreenRefreshRate == Screen.resolutions[i].refreshRate)
				{
					view.ResolutionComboBox.SetComboBoxIndexSelected(i);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			view.ResolutionComboBox.SetComboBoxIndexSelected(view.ResolutionComboBox.GetOptionsCount() - 1);
		}
	}

	private void UpdateFPSLimitLabels()
	{
		string text = languagesManager.GetText("label.text.options.fps.unlimited", "Unlimited");
		view.FPSLimitSelector.ClearAllTexts();
		view.FPSLimitSelector.AddText(OptionsModel.FPSLimit.FPS30.ToString(), "30");
		view.FPSLimitSelector.AddText(OptionsModel.FPSLimit.FPS60.ToString(), "60");
		view.FPSLimitSelector.AddText(OptionsModel.FPSLimit.FPS120.ToString(), "120");
		view.FPSLimitSelector.AddText(OptionsModel.FPSLimit.FPS144.ToString(), "144");
		view.FPSLimitSelector.AddText(OptionsModel.FPSLimit.Unlimited.ToString(), text);
		view.FPSLimitSelector.SetSelectedText(model.FPSLimitValue.ToString());
	}

	private void UpdateFPSLimitValue(OptionsModel.FPSLimit fpsLimitValue)
	{
		switch (fpsLimitValue)
		{
		case OptionsModel.FPSLimit.Unlimited:
			Application.targetFrameRate = -1;
			break;
		case OptionsModel.FPSLimit.FPS30:
			Application.targetFrameRate = 30;
			break;
		case OptionsModel.FPSLimit.FPS60:
			Application.targetFrameRate = 60;
			break;
		case OptionsModel.FPSLimit.FPS120:
			Application.targetFrameRate = 120;
			break;
		case OptionsModel.FPSLimit.FPS144:
			Application.targetFrameRate = 144;
			break;
		default:
			Application.targetFrameRate = -1;
			break;
		}
	}

	private void UpdateGraphicQualityLabels()
	{
		string text = languagesManager.GetText("label.text.options.quality.low", "Low");
		string text2 = languagesManager.GetText("label.text.options.quality.high", "High");
		view.QualitySelector.ClearAllTexts();
		view.QualitySelector.AddText(OptionsModel.GraphicQuality.Low.ToString(), text);
		view.QualitySelector.AddText(OptionsModel.GraphicQuality.High.ToString(), text2);
		view.QualitySelector.SetSelectedText(model.GraphicQualityValue.ToString());
	}

	private void UpdateGraphicQualityValue(OptionsModel.GraphicQuality graphicQualityValue)
	{
		int qualityLevel = QualitySettings.GetQualityLevel();
		if (graphicQualityValue != (OptionsModel.GraphicQuality)qualityLevel)
		{
			QualitySettings.SetQualityLevel((int)graphicQualityValue, applyExpensiveChanges: true);
			string text = $"NEW GRAPHIC QUALITY = {(int)graphicQualityValue} - {QualitySettings.names[(int)graphicQualityValue]}";
			Debug.Log(text);
			GUIManager.Instance.MainMenuView.SetRuntimeDebugText($"T[{Time.realtimeSinceStartup}]:\n{text}");
		}
	}

	private void UpdateReplayAccuracyLabels()
	{
		string text = languagesManager.GetText("label.text.options.replayaccuracy.low", "Low");
		string text2 = languagesManager.GetText("label.text.options.replayaccuracy.normal", "Normal");
		string text3 = languagesManager.GetText("label.text.options.replayaccuracy.high", "High");
		view.ReplayAccuracySelector.ClearAllTexts();
		view.ReplayAccuracySelector.AddText(OptionsModel.ReplayAccuracy.Low.ToString(), text);
		view.ReplayAccuracySelector.AddText(OptionsModel.ReplayAccuracy.Normal.ToString(), text2);
		view.ReplayAccuracySelector.AddText(OptionsModel.ReplayAccuracy.High.ToString(), text3);
		view.ReplayAccuracySelector.SetSelectedText(model.ReplayAccuracyValue.ToString());
	}

	private void UpdateReplayAccuracyValue(OptionsModel.ReplayAccuracy replayAccuracy)
	{
		switch (replayAccuracy)
		{
		case OptionsModel.ReplayAccuracy.Low:
			ReplayManager.Instance.SetRecordFPS(8);
			break;
		case OptionsModel.ReplayAccuracy.Normal:
			ReplayManager.Instance.SetRecordFPS(15);
			break;
		case OptionsModel.ReplayAccuracy.High:
			ReplayManager.Instance.SetRecordFPS(30);
			break;
		default:
			ReplayManager.Instance.SetRecordFPS(15);
			break;
		}
	}

	private void SetAllReplayButtonsInteractive(bool isInteractable)
	{
		GUIManager.Instance.PauseView.SetReplayButtonInteractive(isInteractable);
		GUIManager.Instance.LevelCompletedView.SetReplayButtonInteractive(isInteractable);
	}

	private void SaveValuesOnDisk()
	{
		XDocument.Parse(model.XmlSerialize()).Save(PathNames.Options);
	}

	private void UpdateAuxiliary()
	{
		if (shouldSaveValuesOnDisk)
		{
			saveOnDiskTimerCounter += Time.unscaledDeltaTime;
			if (saveOnDiskTimerCounter >= 3f)
			{
				SaveValuesOnDisk();
				shouldSaveValuesOnDisk = false;
				Debug.Log("Options saved on disk!");
			}
		}
	}
}
