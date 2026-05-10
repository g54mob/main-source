using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.ScriptableSettings;
using UnityEngine;

public class Settings : MonoSingleton<Settings>
{
	private int __MSAA;

	[SerializeField]
	private int _baseMSAA;

	private float __musicVolume;

	private float __UIVolume;

	private float __SFXVolume;

	private float __AmbienceVolume;

	private float __DialogueVolume;

	private bool __isSoundOn;

	private bool __isYAxisInverted;

	private bool __VSync;

	[SerializeField]
	private List<int> _FPSPresets;

	[field: SerializeField]
	public SettingObject<int> GraphicsPreset { get; private set; }

	[field: SerializeField]
	public SettingObject<Vector2Int> Resolution { get; private set; }

	[field: SerializeField]
	public SettingObject<FullScreenMode> FullScreen { get; private set; }

	[field: SerializeField]
	public SettingObject<int> FPSTarget { get; private set; }

	public float MusicVolume
	{
		get
		{
			return __musicVolume;
		}
		set
		{
			__musicVolume = value;
			Settings.OnSettingsUpdated?.Invoke();
		}
	}

	public float UIVolume
	{
		get
		{
			return __UIVolume;
		}
		set
		{
			__UIVolume = value;
			Settings.OnSettingsUpdated?.Invoke();
		}
	}

	public float SFXVolume
	{
		get
		{
			return __SFXVolume;
		}
		set
		{
			__SFXVolume = value;
			Settings.OnSettingsUpdated?.Invoke();
		}
	}

	public float AmbienceVolume
	{
		get
		{
			return __AmbienceVolume;
		}
		set
		{
			__AmbienceVolume = value;
			Settings.OnSettingsUpdated?.Invoke();
		}
	}

	public float DialogueVolume
	{
		get
		{
			return __DialogueVolume;
		}
		set
		{
			__DialogueVolume = value;
			Settings.OnSettingsUpdated?.Invoke();
		}
	}

	public bool IsSoundOn
	{
		get
		{
			return __isSoundOn;
		}
		set
		{
			__isSoundOn = value;
			Settings.OnSettingsUpdated?.Invoke();
		}
	}

	public bool IsYAxisInverted
	{
		get
		{
			return __isYAxisInverted;
		}
		set
		{
			__isYAxisInverted = value;
			Settings.OnSettingsUpdated?.Invoke();
		}
	}

	public bool VSync
	{
		get
		{
			return __VSync;
		}
		set
		{
			QualitySettings.vSyncCount = (value ? 1 : 0);
			__VSync = value;
			Settings.OnSettingsUpdated?.Invoke();
		}
	}

	public int MSAA
	{
		get
		{
			return __MSAA;
		}
		set
		{
			QualitySettings.antiAliasing = value * 2;
			__MSAA = value;
			Settings.OnSettingsUpdated?.Invoke();
		}
	}

	public static event Action OnSettingsUpdated;

	public static event Action<string, string> OnCurrentDisplayUpdated;

	protected override void SingletonAwake()
	{
		UpdateResolution();
		Resolution.ValueChanged += OnResolutionChanged;
		FullScreen.ValueChanged += OnFullscreenModeChanged;
		UpdateQualityLevel();
		GraphicsPreset.ValueChanged += OnGraphicsPresetChanged;
		UpdateTargetFPS();
		FPSTarget.ValueChanged += OnTargetFramerateChanged;
	}

	protected override void OnSingletonDestroy()
	{
		Resolution.ValueChanged -= OnResolutionChanged;
		FullScreen.ValueChanged -= OnFullscreenModeChanged;
		GraphicsPreset.ValueChanged -= OnGraphicsPresetChanged;
		FPSTarget.ValueChanged -= OnTargetFramerateChanged;
	}

	private void UpdateResolution()
	{
		Vector2Int vector2Int = Resolution.GetValue();
		if (vector2Int == Vector2Int.zero)
		{
			vector2Int = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
			Resolution.SetValue(vector2Int);
		}
		Screen.SetResolution(vector2Int.x, vector2Int.y, FullScreen.GetValue());
	}

	private void UpdateQualityLevel()
	{
		QualitySettings.SetQualityLevel(GraphicsPreset.GetValue());
	}

	private void UpdateTargetFPS()
	{
		int value = FPSTarget.GetValue();
		Application.targetFrameRate = ((value <= 0) ? (-1) : value);
	}

	private void OnGraphicsPresetChanged(int value)
	{
		UpdateQualityLevel();
	}

	private void OnFullscreenModeChanged(FullScreenMode obj)
	{
		UpdateResolution();
	}

	private void OnResolutionChanged(Vector2Int obj)
	{
		UpdateResolution();
	}

	private void OnTargetFramerateChanged(int obj)
	{
		UpdateTargetFPS();
	}
}
