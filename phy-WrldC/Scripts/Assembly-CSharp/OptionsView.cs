using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsView : BaseGUIView
{
	public const string ApplyButtonEvent = "OptionsView.ApplyButtonEvent";

	public const string CloseButtonEvent = "OptionsView.CloseButtonEvent";

	public const string ClearProfileButtonEvent = "OptionsView.ClearProfileButtonEvent";

	private Toggle generalTabToggle;

	private SliderManager masterVolumeSlider;

	private SliderManager musicVolumeSlider;

	private SliderManager effectsVolumeSlider;

	private Toggle enableCheatsToggle;

	private Button clearProfileButton;

	private Toggle fullscreenToggle;

	private Toggle borderlessToggle;

	private Toggle vSyncToggle;

	private SliderManager cameraSensitivitySlider;

	private Toggle cameraKeysToggle;

	private KeyAssignment cameraForwardKey;

	private KeyAssignment cameraBackwardKey;

	private KeyAssignment cameraLeftKey;

	private KeyAssignment cameraRightKey;

	private KeyAssignment cameraUpKey;

	private KeyAssignment cameraDownKey;

	private Toggle axesJoystickToggle;

	private Toggle cameraJoystickToggle;

	private TextMeshProUGUI fpsLimitLabel;

	private Toggle replayDisableToggle;

	private TextMeshProUGUI replayAccuracyLabel;

	private Toggle replayRemoveAudiosToggle;

	private Toggle replayRemoveDecalsToggle;

	private Toggle replayRemoveParticlesToggle;

	private Button applyButton;

	private Button closeButton;

	private Button winCloseButton;

	public TextSelector LanguageSelector { get; private set; }

	public ComboBoxProperties DisplayComboBox { get; set; }

	public ComboBoxProperties ResolutionComboBox { get; private set; }

	public TextSelector FPSLimitSelector { get; private set; }

	public TextSelector QualitySelector { get; private set; }

	public TextSelector ReplayAccuracySelector { get; private set; }

	public override void Initialize()
	{
		generalTabToggle = mainPanel.transform.FindComponent<Toggle>("GeneralTab", isRecursively: true);
		LanguageSelector = mainPanel.transform.FindComponent<TextSelector>("LanguageSelector", isRecursively: true);
		masterVolumeSlider = mainPanel.transform.FindComponent<SliderManager>("MasterVolumeSlider", isRecursively: true);
		musicVolumeSlider = mainPanel.transform.FindComponent<SliderManager>("MusicVolumeSlider", isRecursively: true);
		effectsVolumeSlider = mainPanel.transform.FindComponent<SliderManager>("EffectsVolumeSlider", isRecursively: true);
		enableCheatsToggle = mainPanel.transform.FindComponent<Toggle>("EnableCheatsToggle", isRecursively: true);
		clearProfileButton = mainPanel.transform.FindComponent<Button>("ClearProfileButton", isRecursively: true);
		DisplayComboBox = mainPanel.transform.FindComponent<ComboBoxProperties>("DisplayComboBox", isRecursively: true);
		ResolutionComboBox = mainPanel.transform.FindComponent<ComboBoxProperties>("ResolutionComboBox", isRecursively: true);
		fullscreenToggle = mainPanel.transform.FindComponent<Toggle>("FullscreenToggle", isRecursively: true);
		borderlessToggle = mainPanel.transform.FindComponent<Toggle>("BorderlessToggle", isRecursively: true);
		vSyncToggle = mainPanel.transform.FindComponent<Toggle>("VSyncToggle", isRecursively: true);
		FPSLimitSelector = mainPanel.transform.FindComponent<TextSelector>("FPSLimitSelector", isRecursively: true);
		QualitySelector = mainPanel.transform.FindComponent<TextSelector>("QualitySelector", isRecursively: true);
		cameraSensitivitySlider = mainPanel.transform.FindComponent<SliderManager>("CameraSensitivitySlider", isRecursively: true);
		cameraKeysToggle = mainPanel.transform.FindComponent<Toggle>("CameraKeysToggle", isRecursively: true);
		cameraForwardKey = mainPanel.transform.FindComponent<KeyAssignment>("CameraForwardKey", isRecursively: true);
		cameraBackwardKey = mainPanel.transform.FindComponent<KeyAssignment>("CameraBackwardKey", isRecursively: true);
		cameraLeftKey = mainPanel.transform.FindComponent<KeyAssignment>("CameraLeftKey", isRecursively: true);
		cameraRightKey = mainPanel.transform.FindComponent<KeyAssignment>("CameraRightKey", isRecursively: true);
		cameraUpKey = mainPanel.transform.FindComponent<KeyAssignment>("CameraUpKey", isRecursively: true);
		cameraDownKey = mainPanel.transform.FindComponent<KeyAssignment>("CameraDownKey", isRecursively: true);
		axesJoystickToggle = mainPanel.transform.FindComponent<Toggle>("AxesJoystickToggle", isRecursively: true);
		cameraJoystickToggle = mainPanel.transform.FindComponent<Toggle>("CameraJoystickToggle", isRecursively: true);
		fpsLimitLabel = mainPanel.transform.FindComponent<TextMeshProUGUI>("FPSLimitLabel", isRecursively: true);
		replayDisableToggle = mainPanel.transform.FindComponent<Toggle>("ReplayDisableToggle", isRecursively: true);
		ReplayAccuracySelector = mainPanel.transform.FindComponent<TextSelector>("ReplayAccuracySelector", isRecursively: true);
		replayAccuracyLabel = mainPanel.transform.FindComponent<TextMeshProUGUI>("ReplayAccuracyLabel", isRecursively: true);
		replayRemoveAudiosToggle = mainPanel.transform.FindComponent<Toggle>("ReplayRemoveAudiosToggle", isRecursively: true);
		replayRemoveDecalsToggle = mainPanel.transform.FindComponent<Toggle>("ReplayRemoveDecalsToggle", isRecursively: true);
		replayRemoveParticlesToggle = mainPanel.transform.FindComponent<Toggle>("ReplayRemoveParticlesToggle", isRecursively: true);
		applyButton = mainPanel.transform.FindComponent<Button>("ApplyButton", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		winCloseButton = mainPanel.transform.FindComponent<Button>("WinCloseButton", isRecursively: true);
		LanguageSelector.Initialize();
		masterVolumeSlider.ConfigureProperties(5f, 0f, 10f, 0.5f, "{0:0.0}");
		musicVolumeSlider.ConfigureProperties(5f, 0f, 10f, 0.5f, "{0:0.0}");
		effectsVolumeSlider.ConfigureProperties(5f, 0f, 10f, 0.5f, "{0:0.0}");
		cameraSensitivitySlider.ConfigureProperties(5f, 0f, 10f, 0.5f, "{0:0.0}");
		DisplayComboBox.Initialize();
		ResolutionComboBox.Initialize();
		FPSLimitSelector.Initialize();
		QualitySelector.Initialize();
		cameraForwardKey.Initialize();
		cameraBackwardKey.Initialize();
		cameraLeftKey.Initialize();
		cameraRightKey.Initialize();
		cameraUpKey.Initialize();
		cameraDownKey.Initialize();
		ReplayAccuracySelector.Initialize();
		applyButton.onClick.AddListener(delegate
		{
			NotifyChange("OptionsView.ApplyButtonEvent");
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("OptionsView.CloseButtonEvent");
		});
		winCloseButton.onClick.AddListener(delegate
		{
			NotifyChange("OptionsView.CloseButtonEvent");
		});
		clearProfileButton.onClick.AddListener(delegate
		{
			ClearProfileButtonHandler();
		});
		LanguageSelector.OnValueChangedEvent += delegate
		{
			ActiveApplyButton();
		};
		masterVolumeSlider.OnValueChangedEvent += delegate
		{
			ActiveApplyButton();
		};
		musicVolumeSlider.OnValueChangedEvent += delegate
		{
			ActiveApplyButton();
		};
		effectsVolumeSlider.OnValueChangedEvent += delegate
		{
			ActiveApplyButton();
		};
		enableCheatsToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		ComboBoxProperties displayComboBox = DisplayComboBox;
		displayComboBox.OnValueChangedEvent = (Action<string>)Delegate.Combine(displayComboBox.OnValueChangedEvent, (Action<string>)delegate
		{
			ActiveApplyButton();
		});
		ComboBoxProperties resolutionComboBox = ResolutionComboBox;
		resolutionComboBox.OnValueChangedEvent = (Action<string>)Delegate.Combine(resolutionComboBox.OnValueChangedEvent, (Action<string>)delegate
		{
			ActiveApplyButton();
		});
		fullscreenToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		borderlessToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		vSyncToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		FPSLimitSelector.OnValueChangedEvent += delegate
		{
			ActiveApplyButton();
		};
		QualitySelector.OnValueChangedEvent += delegate
		{
			ActiveApplyButton();
		};
		cameraSensitivitySlider.OnValueChangedEvent += delegate
		{
			ActiveApplyButton();
		};
		cameraKeysToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		cameraForwardKey.OnKeyAssignment += delegate
		{
			ActiveApplyButton();
		};
		cameraBackwardKey.OnKeyAssignment += delegate
		{
			ActiveApplyButton();
		};
		cameraLeftKey.OnKeyAssignment += delegate
		{
			ActiveApplyButton();
		};
		cameraRightKey.OnKeyAssignment += delegate
		{
			ActiveApplyButton();
		};
		cameraUpKey.OnKeyAssignment += delegate
		{
			ActiveApplyButton();
		};
		cameraDownKey.OnKeyAssignment += delegate
		{
			ActiveApplyButton();
		};
		axesJoystickToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		cameraJoystickToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		replayDisableToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		ReplayAccuracySelector.OnValueChangedEvent += delegate
		{
			ActiveApplyButton();
		};
		replayRemoveAudiosToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		replayRemoveDecalsToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		replayRemoveParticlesToggle.onValueChanged.AddListener(delegate
		{
			ActiveApplyButton();
		});
		fullscreenToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			SetBorderlessInteractivity(isOn);
		});
		vSyncToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			SetFPSLimitInteractivity(!isOn);
		});
		cameraKeysToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			SetCameraKeysInteractivity(!isOn);
		});
		replayDisableToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			SetReplayElementsInteractivity(!isOn);
		});
	}

	private void ActiveApplyButton()
	{
		if (!applyButton.interactable)
		{
			applyButton.interactable = true;
		}
	}

	private void SetCameraKeysInteractivity(bool isInteractable)
	{
		cameraForwardKey.IsInteractable = isInteractable;
		cameraBackwardKey.IsInteractable = isInteractable;
		cameraLeftKey.IsInteractable = isInteractable;
		cameraRightKey.IsInteractable = isInteractable;
		cameraUpKey.IsInteractable = isInteractable;
		cameraDownKey.IsInteractable = isInteractable;
	}

	private void SetBorderlessInteractivity(bool isInteractable)
	{
		SetGenericToggleInteractivity(borderlessToggle, isInteractable);
	}

	private void SetFPSLimitInteractivity(bool isInteractable)
	{
		fpsLimitLabel.color = new Color(fpsLimitLabel.color.r, fpsLimitLabel.color.g, fpsLimitLabel.color.b, isInteractable ? 1f : 0.5f);
		FPSLimitSelector.IsInteractable = isInteractable;
	}

	private void SetReplayElementsInteractivity(bool isInteractable)
	{
		replayAccuracyLabel.color = new Color(replayAccuracyLabel.color.r, replayAccuracyLabel.color.g, replayAccuracyLabel.color.b, isInteractable ? 1f : 0.5f);
		ReplayAccuracySelector.IsInteractable = isInteractable;
		SetGenericToggleInteractivity(replayRemoveAudiosToggle, isInteractable);
		SetGenericToggleInteractivity(replayRemoveDecalsToggle, isInteractable);
		SetGenericToggleInteractivity(replayRemoveParticlesToggle, isInteractable);
	}

	private void SetGenericToggleInteractivity(Toggle toggle, bool isInteractable)
	{
		toggle.interactable = isInteractable;
		TextMeshProUGUI textMeshProUGUI = toggle.transform.FindComponent<TextMeshProUGUI>("Label", isRecursively: true);
		TextMeshProUGUI textMeshProUGUI2 = toggle.transform.FindComponent<TextMeshProUGUI>("Checkmark", isRecursively: true);
		textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, isInteractable ? 1f : 0.5f);
		textMeshProUGUI2.color = new Color(textMeshProUGUI2.color.r, textMeshProUGUI2.color.g, textMeshProUGUI2.color.b, isInteractable ? 1f : 0.5f);
	}

	private void ClearProfileButtonHandler()
	{
		string text = LanguagesManager.Instance.GetText("message.header.options.clearprofile");
		string text2 = LanguagesManager.Instance.GetText("message.infos.options.clearprofile");
		GUIManager.Instance.ShowMessageBox(text, text2, delegate
		{
			NotifyChange("OptionsView.ClearProfileButtonEvent");
		});
	}

	public void SelectFirstTab()
	{
		if (!generalTabToggle.isOn)
		{
			generalTabToggle.isOn = true;
		}
	}

	public void SetVolumes(float master, float music, float effects)
	{
		masterVolumeSlider.SetCurrentValue(master);
		musicVolumeSlider.SetCurrentValue(music);
		effectsVolumeSlider.SetCurrentValue(effects);
	}

	public void SetEnableCheatsToggleValue(bool isOn)
	{
		if (enableCheatsToggle.isOn != isOn)
		{
			enableCheatsToggle.SetValue(isOn);
		}
	}

	public void SetCameraSensitivity(float sensitivity)
	{
		cameraSensitivitySlider.SetCurrentValue(sensitivity);
	}

	public void SetCameraKeys(KeyCode forward, KeyCode backward, KeyCode left, KeyCode right, KeyCode up, KeyCode down)
	{
		cameraForwardKey.SetKey(forward);
		cameraBackwardKey.SetKey(backward);
		cameraLeftKey.SetKey(left);
		cameraRightKey.SetKey(right);
		cameraUpKey.SetKey(up);
		cameraDownKey.SetKey(down);
	}

	public float GetMasterVolume()
	{
		return masterVolumeSlider.CurrentValue;
	}

	public float GetMusicVolume()
	{
		return musicVolumeSlider.CurrentValue;
	}

	public float GetEffectsVolume()
	{
		return effectsVolumeSlider.CurrentValue;
	}

	public bool GetEnableCheatsToggleValue()
	{
		return enableCheatsToggle.isOn;
	}

	public float GetCameraSensitivity()
	{
		return cameraSensitivitySlider.CurrentValue;
	}

	public KeyCode GetCameraForwardKey()
	{
		return cameraForwardKey.Key;
	}

	public KeyCode GetCameraBackwardKey()
	{
		return cameraBackwardKey.Key;
	}

	public KeyCode GetCameraLeftKey()
	{
		return cameraLeftKey.Key;
	}

	public KeyCode GetCameraRightKey()
	{
		return cameraRightKey.Key;
	}

	public KeyCode GetCameraUpKey()
	{
		return cameraUpKey.Key;
	}

	public KeyCode GetCameraDownKey()
	{
		return cameraDownKey.Key;
	}

	public bool IsCameraKeysDisabled()
	{
		return cameraKeysToggle.isOn;
	}

	public void SetCameraKeysToggleValue(bool isOn)
	{
		if (cameraKeysToggle.isOn != isOn)
		{
			cameraKeysToggle.SetValue(isOn);
		}
		SetCameraKeysInteractivity(!isOn);
	}

	public void SetAxesJoystickToggleValue(bool isOn)
	{
		if (axesJoystickToggle.isOn != isOn)
		{
			axesJoystickToggle.SetValue(isOn);
		}
	}

	public bool GetAxesJoystickToggleValue()
	{
		return axesJoystickToggle.isOn;
	}

	public void SetCameraJoystickToggleValue(bool isOn)
	{
		if (cameraJoystickToggle.isOn != isOn)
		{
			cameraJoystickToggle.SetValue(isOn);
		}
	}

	public bool GetCameraJoystickToggleValue()
	{
		return cameraJoystickToggle.isOn;
	}

	public bool IsFullscreenActivated()
	{
		return fullscreenToggle.isOn;
	}

	public void SetFullscreenToggleValue(bool isOn)
	{
		if (fullscreenToggle.isOn != isOn)
		{
			fullscreenToggle.SetValue(isOn);
		}
	}

	public bool IsBorderlessActivated()
	{
		return borderlessToggle.isOn;
	}

	public void SetBorderlessToggleValue(bool isOn)
	{
		if (borderlessToggle.isOn != isOn)
		{
			borderlessToggle.SetValue(isOn);
		}
	}

	public bool IsVSyncActivated()
	{
		return vSyncToggle.isOn;
	}

	public void SetVSyncActivatedToggleValue(bool isOn)
	{
		if (vSyncToggle.isOn != isOn)
		{
			vSyncToggle.SetValue(isOn);
		}
		SetFPSLimitInteractivity(!isOn);
	}

	public void SetReplayDisableToggleValue(bool isOn)
	{
		if (replayDisableToggle.isOn != isOn)
		{
			replayDisableToggle.SetValue(isOn);
		}
		SetReplayElementsInteractivity(!isOn);
	}

	public bool IsReplayDisabled()
	{
		return replayDisableToggle.isOn;
	}

	public void SetReplayRemoveAudiosValue(bool isOn)
	{
		if (replayRemoveAudiosToggle.isOn != isOn)
		{
			replayRemoveAudiosToggle.SetValue(isOn);
		}
	}

	public void SetReplayRemoveDecalsValue(bool isOn)
	{
		if (replayRemoveDecalsToggle.isOn != isOn)
		{
			replayRemoveDecalsToggle.SetValue(isOn);
		}
	}

	public void SetReplayRemoveParticlesValue(bool isOn)
	{
		if (replayRemoveParticlesToggle.isOn != isOn)
		{
			replayRemoveParticlesToggle.SetValue(isOn);
		}
	}

	public bool ShouldReplayRemoveAudios()
	{
		return replayRemoveAudiosToggle.isOn;
	}

	public bool ShouldReplayRemoveDecals()
	{
		return replayRemoveDecalsToggle.isOn;
	}

	public bool ShouldReplayRemoveParticles()
	{
		return replayRemoveParticlesToggle.isOn;
	}

	public void SetApplyButtonInteractivity(bool isInteractable)
	{
		applyButton.interactable = isInteractable;
	}
}
