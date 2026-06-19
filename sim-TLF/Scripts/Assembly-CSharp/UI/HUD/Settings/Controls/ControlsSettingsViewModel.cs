using System.Collections.Generic;
using System.Linq;
using Loxodon.Framework.ViewModels;
using Services.Save;
using Services.Save.Settings;
using StarterAssets;
using UnityEngine;
using Zenject;

namespace UI.HUD.Settings.Controls
{
	public class ControlsSettingsViewModel : ViewModelBase
	{
		private const float SnapStep = 0.1f;

		[Inject]
		private ISaveService _saveService;

		[Inject]
		private SceneControlsSettingsRegistry _registry;

		private FirstPersonController _fpc;

		private float _mouseSensitivity = 1f;

		private string _sensitivityDisplay = "1.0";

		private readonly List<Resolution> _resolutions = new List<Resolution>();

		private int _selectedResolutionIndex;

		private bool _isWindowed;

		public float MouseSensitivity
		{
			get
			{
				return _mouseSensitivity;
			}
			set
			{
				float num = Mathf.Round(value / 0.1f) * 0.1f;
				if (Set(ref _mouseSensitivity, num, "MouseSensitivity"))
				{
					SensitivityDisplay = num.ToString("F1");
					if (_fpc != null)
					{
						_fpc.RotationSpeed = num;
					}
					PushToRegistry();
				}
			}
		}

		public string SensitivityDisplay
		{
			get
			{
				return _sensitivityDisplay;
			}
			private set
			{
				Set(ref _sensitivityDisplay, value, "SensitivityDisplay");
			}
		}

		public int SelectedResolutionIndex
		{
			get
			{
				return _selectedResolutionIndex;
			}
			set
			{
				if (Set(ref _selectedResolutionIndex, value, "SelectedResolutionIndex"))
				{
					ApplyResolution();
					PushToRegistry();
				}
			}
		}

		public bool IsWindowed
		{
			get
			{
				return _isWindowed;
			}
			set
			{
				if (Set(ref _isWindowed, value, "IsWindowed"))
				{
					ApplyResolution();
					PushToRegistry();
				}
			}
		}

		public void Initialize()
		{
			_fpc = Object.FindFirstObjectByType<FirstPersonController>();
			float num = (_mouseSensitivity = Mathf.Round(((_fpc != null) ? _fpc.RotationSpeed : _mouseSensitivity) / 0.1f) * 0.1f);
			SensitivityDisplay = num.ToString("F1");
			BuildResolutionList();
		}

		public List<string> GetResolutionLabels()
		{
			return _resolutions.Select((Resolution r) => $"{r.width} x {r.height}").ToList();
		}

		private void BuildResolutionList()
		{
			_resolutions.Clear();
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution r = resolutions[i];
				if (!_resolutions.Any((Resolution x) => x.width == r.width && x.height == r.height))
				{
					_resolutions.Add(r);
				}
			}
			int curW = Screen.width;
			int curH = Screen.height;
			int num = _resolutions.FindIndex((Resolution x) => x.width == curW && x.height == curH);
			if (num < 0)
			{
				_resolutions.Add(new Resolution
				{
					width = curW,
					height = curH
				});
				num = _resolutions.Count - 1;
			}
			_selectedResolutionIndex = num;
			_isWindowed = Screen.fullScreenMode == FullScreenMode.Windowed;
		}

		private void ApplyResolution()
		{
			if (_selectedResolutionIndex >= 0 && _selectedResolutionIndex < _resolutions.Count)
			{
				Resolution resolution = _resolutions[_selectedResolutionIndex];
				FullScreenMode fullscreenMode = ((!_isWindowed) ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
				Screen.SetResolution(resolution.width, resolution.height, fullscreenMode);
			}
		}

		private void PushToRegistry()
		{
			if (_registry != null)
			{
				int resolutionWidth = 0;
				int resolutionHeight = 0;
				if (_selectedResolutionIndex >= 0 && _selectedResolutionIndex < _resolutions.Count)
				{
					resolutionWidth = _resolutions[_selectedResolutionIndex].width;
					resolutionHeight = _resolutions[_selectedResolutionIndex].height;
				}
				_registry.Set(new ControlsSettingsData
				{
					MouseSensitivity = _mouseSensitivity,
					ResolutionWidth = resolutionWidth,
					ResolutionHeight = resolutionHeight,
					Windowed = _isWindowed
				});
			}
		}

		public void SaveSettings()
		{
			if (_saveService != null && _registry != null)
			{
				PushToRegistry();
				_saveService.Save(_registry.SaveKey);
			}
		}
	}
}
