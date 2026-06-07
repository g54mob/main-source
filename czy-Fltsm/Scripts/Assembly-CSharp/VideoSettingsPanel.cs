using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettingsPanel : SettingsPanel
{
	internal class ResolutionOption : TMP_Dropdown.OptionData
	{
		public Resolution Resolution;

		public ResolutionOption(Resolution resolution)
			: base(resolution.ToString())
		{
			Resolution = resolution;
		}
	}

	[Header("Components")]
	[Tooltip("Dropdown for full-screen modes.")]
	[SerializeField]
	private TMP_Dropdown _fullScreenModesDropdown;

	[Tooltip("Dropdown to choose the game's resolution.")]
	[SerializeField]
	private TMP_Dropdown _resolutionDropDown;

	[Tooltip("Dropdown to choose the texture quality.")]
	[SerializeField]
	private TMP_Dropdown _graphicsQualityDropdown;

	[Tooltip("Slider to set UI scale.")]
	[SerializeField]
	private InteractableSlider _uiSlider;

	[Tooltip("Toggle vSync.")]
	[SerializeField]
	private Toggle _vSyncToggle;

	[Header("Localization")]
	[Tooltip("The full screen option to populate the video panel with.")]
	[SerializeField]
	private List<FullScreenOption> _fullScreenOptions = new List<FullScreenOption>();

	[Tooltip("Localized strings for the graphics quality options.")]
	[SerializeField]
	private List<LocalizedString> _graphicsQualityOptions = new List<LocalizedString>();

	private bool _initialized;

	private int _fullScreenModeIndex;

	private int _resolutionIndex;

	private int _graphicsQualityIndex;

	[HideInInspector]
	private GraphicsPlayerData _graphicsPlayerData;

	protected override void OnEnable()
	{
		base.OnEnable();
		_fullScreenModesDropdown.onValueChanged.AddListener(OnValueChanged);
		_resolutionDropDown.onValueChanged.AddListener(OnValueChanged);
		_graphicsQualityDropdown.onValueChanged.AddListener(OnValueChanged);
		_vSyncToggle.onValueChanged.AddListener(OnVSyncChanged);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		_fullScreenModesDropdown.onValueChanged.RemoveListener(OnValueChanged);
		_resolutionDropDown.onValueChanged.RemoveListener(OnValueChanged);
		_graphicsQualityDropdown.onValueChanged.RemoveListener(OnValueChanged);
		_vSyncToggle.onValueChanged.RemoveListener(OnVSyncChanged);
		_fullScreenModesDropdown.value = _fullScreenModeIndex;
		_resolutionDropDown.value = _resolutionIndex;
		_graphicsQualityDropdown.value = _graphicsQualityIndex;
		UpdateApplyButton();
	}

	public override void Load(Settings playerData)
	{
		_graphicsPlayerData = playerData.GraphicsPlayerData;
		if (!_initialized)
		{
			SetFullScreenOptions();
			SetResolutionOptions();
			SetQualityOptions();
			_initialized = true;
		}
		_fullScreenModesDropdown.value = (_fullScreenModeIndex = ReturnFullScreenModeIndex());
		_resolutionDropDown.value = (_resolutionIndex = ReturnResolutionDropDownIndex(ReturnCurrentResolution()));
		_graphicsQualityDropdown.value = (_graphicsQualityIndex = QualitySettings.GetQualityLevel());
		_vSyncToggle.isOn = QualitySettings.vSyncCount == 1;
		SetValues(_graphicsPlayerData);
	}

	public override void ApplyChanges()
	{
		ApplyGraphicsQualityChanges();
		ApplyResolutionChanges();
		UpdateApplyButton();
	}

	protected override void Reset()
	{
		_graphicsPlayerData.ResetSettings();
		SetValues(_graphicsPlayerData);
		_fullScreenModesDropdown.value = (_fullScreenModeIndex = 0);
		_graphicsQualityDropdown.value = (_graphicsQualityIndex = Mathf.Min(4, _graphicsQualityDropdown.options.Count));
		_resolutionDropDown.value = (_resolutionIndex = 0);
		QualitySettings.SetQualityLevel(_graphicsQualityIndex, applyExpensiveChanges: false);
		SetResolution(_resolutionIndex, _fullScreenModeIndex);
	}

	private void SetValues(GraphicsPlayerData data)
	{
		_fullScreenModesDropdown.value = _fullScreenModeIndex;
		_resolutionDropDown.value = _resolutionIndex;
		_graphicsQualityDropdown.value = _graphicsQualityIndex;
		_uiSlider.SetValue(data.UIScale);
	}

	private void SetResolutionOptions()
	{
		if (0 >= _resolutionDropDown.options.Count)
		{
			Resolution[] resolutions = Screen.resolutions;
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>(resolutions.Length);
			for (int num = resolutions.Length - 1; num >= 0; num--)
			{
				list.Add(new ResolutionOption(resolutions[num]));
			}
			_resolutionDropDown.AddOptions(list);
		}
	}

	private void SetFullScreenOptions()
	{
		_fullScreenModesDropdown.options.Clear();
		using ListPool<string>.List list = ListPool<string>.Get();
		for (int i = 0; i < _fullScreenOptions.Count; i++)
		{
			list.Add(_fullScreenOptions[i].FullScreenOptionText);
		}
		_fullScreenModesDropdown.AddOptions(list);
	}

	private void ApplyResolutionChanges()
	{
		if (SetResolution(_resolutionDropDown.value, _fullScreenModesDropdown.value) && PopUpDialog.Instance.TryOpenPopUpDialog(GameManager.Settings.UISettings.RevertChangesDialogProperties))
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(OnApplyResolutionChangesDialogResult);
		}
	}

	private void OnApplyResolutionChangesDialogResult(bool result)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(OnApplyResolutionChangesDialogResult);
		if (result)
		{
			_resolutionIndex = _resolutionDropDown.value;
			_fullScreenModeIndex = _fullScreenModesDropdown.value;
		}
		else
		{
			_resolutionDropDown.value = _resolutionIndex;
			_fullScreenModesDropdown.value = _fullScreenModeIndex;
			SetResolution(_resolutionIndex, _fullScreenModeIndex);
		}
		UpdateApplyButton();
	}

	private bool SetResolution(int resolutionIndex, int fullScreenModeIndex)
	{
		ResolutionOption resolutionOption = _resolutionDropDown.options[resolutionIndex] as ResolutionOption;
		FullScreenMode fullScreenMode = _fullScreenOptions[fullScreenModeIndex].FullScreenMode;
		if (Screen.fullScreenMode == fullScreenMode && AreIdenticalResolutions(Screen.currentResolution, resolutionOption.Resolution))
		{
			return false;
		}
		Screen.SetResolution(resolutionOption.Resolution.width, resolutionOption.Resolution.height, fullScreenMode, resolutionOption.Resolution.refreshRateRatio);
		return true;
	}

	private void SetQualityOptions()
	{
		using ListPool<string>.List options = ListPool<string>.Get(QualitySettings.names);
		_graphicsQualityDropdown.ClearOptions();
		_graphicsQualityDropdown.AddOptions(options);
	}

	private void ApplyGraphicsQualityChanges()
	{
		if (_graphicsQualityDropdown.value == _graphicsQualityIndex)
		{
			QualitySettings.vSyncCount = (_vSyncToggle.isOn ? 1 : 0);
			return;
		}
		QualitySettings.SetQualityLevel(_graphicsQualityDropdown.value, applyExpensiveChanges: false);
		_graphicsQualityIndex = _graphicsQualityDropdown.value;
		_vSyncToggle.SetIsOnWithoutNotify(QualitySettings.vSyncCount == 1);
	}

	public void UpdateUIScale()
	{
		float num = (float)Math.Round(_uiSlider.ReturnValue(), 2);
		if (Mathf.Approximately(num, 1f))
		{
			num = 1f;
		}
		_graphicsPlayerData.UIScale = num;
		_uiSlider.SetValue(num);
		SettingsEvent.DispatchUIScaleChangedEvent(_graphicsPlayerData.UIScale);
	}

	public override bool HasChanges()
	{
		if (!HasWindowChanges())
		{
			return HasQualitityChanges();
		}
		return true;
	}

	public bool HasWindowChanges()
	{
		if (_fullScreenModesDropdown.value == _fullScreenModeIndex)
		{
			return _resolutionDropDown.value != _resolutionIndex;
		}
		return true;
	}

	public bool HasQualitityChanges()
	{
		return _graphicsQualityDropdown.value != _graphicsQualityIndex;
	}

	private int ReturnFullScreenModeIndex()
	{
		for (int i = 0; i < _fullScreenOptions.Count; i++)
		{
			if (_fullScreenOptions[i].FullScreenMode == Screen.fullScreenMode)
			{
				return i;
			}
		}
		return 0;
	}

	private int ReturnResolutionDropDownIndex(Resolution resolution)
	{
		int result = 0;
		int num = int.MaxValue;
		for (int i = 0; i < _resolutionDropDown.options.Count; i++)
		{
			Resolution resolution2 = (_resolutionDropDown.options[i] as ResolutionOption).Resolution;
			if (resolution2.width == resolution.width && resolution2.height == resolution.height)
			{
				int num2 = Mathf.Abs((int)resolution.refreshRateRatio.value - (int)resolution2.refreshRateRatio.value);
				if (num2 < num)
				{
					result = i;
					num = num2;
				}
			}
		}
		return result;
	}

	private int ReturnCurrentResolutionIndex()
	{
		return ReturnResolutionDropDownIndex(ReturnCurrentResolution());
	}

	private Resolution ReturnCurrentResolution()
	{
		if (Screen.fullScreenMode == FullScreenMode.Windowed)
		{
			return new Resolution
			{
				height = Screen.height,
				width = Screen.width
			};
		}
		return Screen.currentResolution;
	}

	private bool AreIdenticalResolutions(Resolution x, Resolution y)
	{
		if (x.width == y.width && x.height == y.height && x.refreshRateRatio.numerator == y.refreshRateRatio.numerator)
		{
			return x.refreshRateRatio.denominator == y.refreshRateRatio.denominator;
		}
		return false;
	}

	private void OnValueChanged(int index)
	{
		UpdateApplyButton();
	}

	private void OnVSyncChanged(bool value)
	{
		QualitySettings.vSyncCount = (value ? 1 : 0);
	}
}
