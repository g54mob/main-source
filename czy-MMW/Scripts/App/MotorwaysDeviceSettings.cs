using System.Collections.Generic;
using Factory;

public class MotorwaysDeviceSettings : BaseDeviceSettings, ICreatedInScopeHandler
{
	[Dependency]
	private IHardwareCapabilities _hardwareCapabilities;

	[Dependency]
	private IAudioSystem _audioSystem;

	private string _colorfulOption = "Colorful";

	private bool _isNightModeEnabled;

	private int _antiAliasingLevel;

	private bool _isUsingDefaultAntiAliasing = true;

	private int _selectedDisplay;

	private const bool DefaultZoomEnabled = true;

	private bool _isZoomEnabled = true;

	private const int DefaultZoomLevel = 2;

	private int _zoomLevel = 2;

	private const int DefaultVolume = 3;

	private int _volumeSetting = 3;

	private const int DefaultSoundscape = 2;

	private int _soundscape = 2;

	private bool _isChallengeRemindersEnabledSetting = true;

	private bool _isContentRemindersEnabledSetting = true;

	private const string ColorfulKey = "ColorfulOption";

	private const string NightModeKey = "NightMode";

	private const string AntiAliasingLevelKey = "AntiAliasingLevel";

	private const string DefaultAntiAliasingLevelKey = "IsDefaultAntiAliasing";

	private const string VolumeKey = "VolumeSetting";

	private const string SoundscapeKey = "Soundscape";

	private const string IsChallengeRemindersEnabledKey = "IsChallengeRemindersEnabled";

	private const string IsContentRemindersEnabledKey = "IsContentRemindersEnabled";

	private const string ZoomEnabledKey = "TouchZoomEnabled";

	private const string ZoomLevelKey = "ZoomLevel";

	public string ColorfulOption
	{
		get
		{
			return _colorfulOption;
		}
		set
		{
			if (_colorfulOption != value)
			{
				_colorfulOption = value;
				OnValueChanged();
			}
		}
	}

	public bool IsNightModeEnabled
	{
		get
		{
			return _isNightModeEnabled;
		}
		set
		{
			if (_isNightModeEnabled != value)
			{
				_isNightModeEnabled = value;
				OnValueChanged();
			}
		}
	}

	public int AntiAliasingLevel
	{
		get
		{
			if (!_hardwareCapabilities.SupportsAntiAliasingOptions)
			{
				return _hardwareCapabilities.DefaultAntiAliasingLevel;
			}
			return _antiAliasingLevel;
		}
		set
		{
			if (_hardwareCapabilities.SupportsAntiAliasingOptions)
			{
				_isUsingDefaultAntiAliasing = false;
				if (_antiAliasingLevel != value)
				{
					_antiAliasingLevel = value;
					OnValueChanged();
				}
			}
		}
	}

	public int SelectedDisplay
	{
		get
		{
			if (!_hardwareCapabilities.SupportsMultipleDisplays)
			{
				return 1;
			}
			return _selectedDisplay;
		}
		set
		{
			if (_hardwareCapabilities.SupportsMultipleDisplays && _selectedDisplay != value)
			{
				_selectedDisplay = value;
				OnValueChanged();
			}
		}
	}

	public bool IsZoomEnabled
	{
		get
		{
			return _isZoomEnabled;
		}
		set
		{
			if (_isZoomEnabled != value)
			{
				_isZoomEnabled = value;
				OnValueChanged();
			}
		}
	}

	public int ZoomLevel
	{
		get
		{
			return _zoomLevel;
		}
		set
		{
			if (_zoomLevel != value)
			{
				_zoomLevel = value;
				OnValueChanged();
			}
		}
	}

	public int VolumeSetting
	{
		get
		{
			return _volumeSetting;
		}
		set
		{
			int num = (_audioSystem.RequiresVolumeControl ? value : 3);
			if (_volumeSetting != num)
			{
				_volumeSetting = num;
				OnValueChanged();
			}
		}
	}

	public int Soundscape
	{
		get
		{
			return _soundscape;
		}
		set
		{
			if (_soundscape != value)
			{
				_soundscape = value;
				OnValueChanged();
			}
		}
	}

	public bool IsChallengeRemindersEnabledSetting
	{
		get
		{
			return _isChallengeRemindersEnabledSetting;
		}
		set
		{
			if (_isChallengeRemindersEnabledSetting != value)
			{
				_isChallengeRemindersEnabledSetting = value;
				OnValueChanged();
			}
		}
	}

	public bool IsContentRemindersEnabledSetting
	{
		get
		{
			return _isContentRemindersEnabledSetting;
		}
		set
		{
			if (_isContentRemindersEnabledSetting != value)
			{
				_isContentRemindersEnabledSetting = value;
				OnValueChanged();
			}
		}
	}

	public void OnCreatedInScope(IScope scope)
	{
		_antiAliasingLevel = _hardwareCapabilities.DefaultAntiAliasingLevel;
		if (_antiAliasingLevel > 0)
		{
			_isUsingDefaultAntiAliasing = false;
		}
	}

	protected override void LoadFromJson(JSON.Dictionary asJson)
	{
		base.LoadFromJson(asJson);
		_colorfulOption = asJson.GetString("ColorfulOption");
		_isNightModeEnabled = asJson.GetBool("NightMode");
		_antiAliasingLevel = asJson.GetInt("AntiAliasingLevel", _hardwareCapabilities.DefaultAntiAliasingLevel);
		_isUsingDefaultAntiAliasing = asJson.GetBool("IsDefaultAntiAliasing", _hardwareCapabilities.DefaultAntiAliasingLevel == 0);
		_volumeSetting = asJson.GetInt("VolumeSetting", 3);
		_soundscape = asJson.GetInt("Soundscape", 2);
		_isChallengeRemindersEnabledSetting = asJson.GetBool("IsChallengeRemindersEnabled");
		_isContentRemindersEnabledSetting = asJson.GetBool("IsContentRemindersEnabled");
		_zoomLevel = asJson.GetInt("ZoomLevel", 2);
		_isZoomEnabled = asJson.GetBool("TouchZoomEnabled", defaultValue: true);
	}

	protected override void SaveToJson(Dictionary<string, object> jsonDictionary)
	{
		base.SaveToJson(jsonDictionary);
		jsonDictionary["ColorfulOption"] = _colorfulOption;
		jsonDictionary["NightMode"] = _isNightModeEnabled;
		jsonDictionary["AntiAliasingLevel"] = _antiAliasingLevel;
		jsonDictionary["IsDefaultAntiAliasing"] = _isUsingDefaultAntiAliasing;
		jsonDictionary["VolumeSetting"] = _volumeSetting;
		jsonDictionary["Soundscape"] = _soundscape;
		jsonDictionary["IsChallengeRemindersEnabled"] = _isChallengeRemindersEnabledSetting;
		jsonDictionary["IsContentRemindersEnabled"] = _isContentRemindersEnabledSetting;
		jsonDictionary["ZoomLevel"] = _zoomLevel;
		jsonDictionary["TouchZoomEnabled"] = _isZoomEnabled;
	}

	protected override void MergeValues(ForwardCompatibleJsonSaveData otherSaveData)
	{
		base.MergeValues(otherSaveData);
		if (otherSaveData is MotorwaysDeviceSettings motorwaysDeviceSettings)
		{
			ColorfulOption = ChooseLatest(_colorfulOption, motorwaysDeviceSettings._colorfulOption, motorwaysDeviceSettings.UtcTimestamp);
			IsNightModeEnabled = ChooseLatest(_isNightModeEnabled, motorwaysDeviceSettings._isNightModeEnabled, motorwaysDeviceSettings.UtcTimestamp);
			VolumeSetting = ChooseLatest(_volumeSetting, motorwaysDeviceSettings._volumeSetting, motorwaysDeviceSettings.UtcTimestamp);
			Soundscape = ChooseLatest(_soundscape, motorwaysDeviceSettings._soundscape, motorwaysDeviceSettings.UtcTimestamp);
			IsChallengeRemindersEnabledSetting = ChooseLatest(_isChallengeRemindersEnabledSetting, motorwaysDeviceSettings._isChallengeRemindersEnabledSetting, motorwaysDeviceSettings.UtcTimestamp);
			IsContentRemindersEnabledSetting = ChooseLatest(_isContentRemindersEnabledSetting, motorwaysDeviceSettings._isContentRemindersEnabledSetting, motorwaysDeviceSettings.UtcTimestamp);
			SelectedDisplay = ChooseLatest(_selectedDisplay, motorwaysDeviceSettings._selectedDisplay, motorwaysDeviceSettings.UtcTimestamp);
			ZoomLevel = ChooseLatest(_zoomLevel, motorwaysDeviceSettings._zoomLevel, motorwaysDeviceSettings.UtcTimestamp);
			IsZoomEnabled = ChooseLatest(_isZoomEnabled, motorwaysDeviceSettings._isZoomEnabled, motorwaysDeviceSettings.UtcTimestamp);
			if (!_isUsingDefaultAntiAliasing || !motorwaysDeviceSettings._isUsingDefaultAntiAliasing)
			{
				_isUsingDefaultAntiAliasing = false;
				AntiAliasingLevel = ChooseLatest(_antiAliasingLevel, motorwaysDeviceSettings._antiAliasingLevel, motorwaysDeviceSettings.UtcTimestamp);
			}
		}
	}
}
