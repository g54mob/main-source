#define ENABLE_DEBUG_WARNINGS
using System;
using System.Collections.Generic;
using Data.Variables;
using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Utils.Enums;

namespace Presentation.UI
{
	public class SettingsDisplay : MonoBehaviour
	{
		[SerializeField]
		private Button _resetAllButton;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private TMP_Dropdown _resolutionDropdown;

		[SerializeField]
		private Toggle _limitFrameRateToggle;

		[SerializeField]
		private CanvasGroup _targetFrameRateContainer;

		[SerializeField]
		private Slider _targetFrameRateSlider;

		[SerializeField]
		private Toggle _vSyncToggle;

		[SerializeField]
		private Toggle _tiltShiftToggle;

		[SerializeField]
		private Toggle _modulesOutlineToggle;

		[SerializeField]
		private Toggle _deluxeEditionDrones;

		[SerializeField]
		private TMP_Dropdown _fullscreenModeDropdown;

		[SerializeField]
		private TMP_Dropdown _qualityDropdown;

		[SerializeField]
		private TMP_Dropdown _renderScaleDropdown;

		[SerializeField]
		private float _minAspectRatio = 1.5f;

		[SerializeField]
		private Slider _maxZoomLevelModifierSlider;

		[SerializeField]
		private ResolutionSO _resolutionSO;

		[SerializeField]
		private BoolVariableSO _limitFrameRateSO;

		[SerializeField]
		private TargetFrameRateSO _targetFrameRateSO;

		[SerializeField]
		private VSyncSO _vSyncSO;

		[SerializeField]
		private TiltShiftSO _tiltShiftSO;

		[SerializeField]
		private ModulesOutlineSO _modulesOutlineSO;

		[SerializeField]
		private BoolVariableSO _showDeluxeEditionDronesSO;

		[SerializeField]
		private AllowedFullscreenModeSO _allowedFullscreenMode;

		[SerializeField]
		private QualityLevelSO _qualityLevel;

		[SerializeField]
		private RenderScaleSO _renderScale;

		[SerializeField]
		private MaxZoomLevelModifierSO _maxZoomLevelModifier;

		private readonly List<string> _qualityLocaKeys = new List<string> { "Settings.DisplayQualityHigh", "Settings.DisplayQualityMedium", "Settings.DisplayQualityLow" };

		private readonly List<string> _renderScaleValues = new List<string> { "50%", "100%", "150%", "200%" };

		private readonly List<string> _qualityStrings = new List<string>();

		private readonly List<Resolution> _availableResolutions = new List<Resolution>();

		private void Awake()
		{
			_resetAllButton.onClick.AddListener(HandleReset);
			LocalizationUtility.OnLanguageUpdate += OnLanguageChanged;
			SetQualityStrings();
		}

		private void OnEnable()
		{
			InitAll();
		}

		private void InitAll()
		{
			InitResolutions();
			InitFrameRate();
			InitVSync();
			InitFullscreenMode();
			InitRenderScale();
			InitQualityLevels();
			InitTiltShift();
			InitModulesOutline();
			InitDeluxeEditionDrones();
			InitMaxZoomLevelModifier();
		}

		private void OnDestroy()
		{
			_fullscreenModeDropdown.onValueChanged.RemoveListener(SetFullscreen);
			_resolutionDropdown.onValueChanged.RemoveListener(SetResolution);
			_limitFrameRateToggle.onValueChanged.RemoveListener(SetLimitFrameRate);
			_targetFrameRateSlider.onValueChanged.RemoveListener(SetTargetFrameRate);
			_vSyncToggle.onValueChanged.RemoveListener(SetVSync);
			_renderScaleDropdown.onValueChanged.RemoveListener(SetRenderScale);
			_qualityDropdown.onValueChanged.RemoveListener(SetQualityLevel);
			_qualityDropdown.onValueChanged.RemoveListener(OnQualityChanged);
			_maxZoomLevelModifierSlider.onValueChanged.RemoveListener(SetMaxZoomLevelModifier);
			_tiltShiftToggle.onValueChanged.RemoveListener(SetTiltShift);
			_modulesOutlineToggle.onValueChanged.RemoveListener(SetModulesOutline);
			_deluxeEditionDrones.onValueChanged.RemoveListener(SetDeluxeEditionDrones);
			LocalizationUtility.OnLanguageUpdate -= OnLanguageChanged;
			_resetAllButton.onClick.RemoveListener(HandleReset);
		}

		private void HandleReset()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("ModalWarning.Title", "ModalWarning.ResetSettingsGeneric", Sizes.S, ResetDisplay, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalWarning.ResetBindingsConfirmButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void ResetDisplay()
		{
			_resolutionSO.ResetToDefault();
			_targetFrameRateSO.ResetToDefault();
			_limitFrameRateSO.ResetToDefault();
			_vSyncSO.ResetToDefault();
			_tiltShiftSO.ResetToDefault();
			_modulesOutlineSO.ResetToDefault();
			_allowedFullscreenMode.ResetToDefault();
			_qualityLevel.ResetToDefault();
			_renderScale.ResetToDefault();
			_maxZoomLevelModifier.ResetToDefault();
			InitAll();
		}

		private void OnQualityChanged(int index)
		{
			SetTiltShift(_tiltShiftToggle.isOn);
			SetLimitFrameRate(_limitFrameRateToggle.isOn);
			SetTargetFrameRate(_targetFrameRateSlider.value);
		}

		private void OnLanguageChanged()
		{
			SetQualityStrings();
			InitQualityLevels();
			InitFullscreenMode();
		}

		private void SetQualityStrings()
		{
			_qualityStrings.Clear();
			for (int i = 0; i < _qualityLocaKeys.Count; i++)
			{
				_qualityStrings.Add(LocalizationUtility.GetLocalizedText(_qualityLocaKeys[i]));
			}
		}

		private void InitRenderScale()
		{
			_renderScaleDropdown.options.Clear();
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			for (int i = 0; i < _renderScaleValues.Count; i++)
			{
				list.Add(new TMP_Dropdown.OptionData(_renderScaleValues[i]));
			}
			_renderScaleDropdown.options = list;
			_renderScaleDropdown.SetValueWithoutNotify(_renderScale.Value);
			_renderScaleDropdown.onValueChanged.AddListener(SetRenderScale);
		}

		private void SetRenderScale(int renderScaleIndex)
		{
			_renderScale.SetValue(renderScaleIndex);
		}

		private void InitQualityLevels()
		{
			_qualityDropdown.options.Clear();
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			for (int i = 0; i < _qualityStrings.Count; i++)
			{
				list.Add(new TMP_Dropdown.OptionData(_qualityStrings[i]));
			}
			_qualityDropdown.options = list;
			_qualityDropdown.SetValueWithoutNotify(_qualityLevel.Value);
			_qualityDropdown.onValueChanged.RemoveListener(SetQualityLevel);
			_qualityDropdown.onValueChanged.AddListener(SetQualityLevel);
		}

		private void SetQualityLevel(int value)
		{
			_qualityLevel.SetValue(value);
		}

		private void InitResolutions()
		{
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			_resolutionDropdown.options.Clear();
			_availableResolutions.Clear();
			for (int num = Screen.resolutions.Length - 1; num >= 0; num--)
			{
				Resolution item = Screen.resolutions[num];
				if ((float)item.width / (float)item.height < _minAspectRatio)
				{
					continue;
				}
				if (_availableResolutions.Count > 0)
				{
					List<Resolution> availableResolutions = _availableResolutions;
					if (availableResolutions[availableResolutions.Count - 1].width == item.width)
					{
						List<Resolution> availableResolutions2 = _availableResolutions;
						if (availableResolutions2[availableResolutions2.Count - 1].height == item.height)
						{
							continue;
						}
					}
				}
				list.Add(new TMP_Dropdown.OptionData($"{item.width}x{item.height}"));
				_availableResolutions.Add(item);
			}
			_resolutionDropdown.options = list;
			_resolutionDropdown.onValueChanged.AddListener(SetResolution);
			SelectCurrentResolutionInDropdown();
		}

		private void SelectCurrentResolutionInDropdown()
		{
			if (Screen.fullScreenMode == FullScreenMode.Windowed || !TryGetResolutionIndex(Screen.currentResolution.width, Screen.currentResolution.height, out var index))
			{
				index = GetClosestResolutionIndex(Screen.width, Screen.height);
			}
			_resolutionDropdown.SetValueWithoutNotify(index);
		}

		private void InitFrameRate()
		{
			_limitFrameRateToggle.isOn = _limitFrameRateSO.Value;
			_targetFrameRateContainer.alpha = (_limitFrameRateSO.Value ? 1f : 0.2f);
			_targetFrameRateContainer.interactable = _limitFrameRateSO.Value;
			_targetFrameRateSlider.value = _targetFrameRateSO.Value;
			_limitFrameRateToggle.onValueChanged.AddListener(SetLimitFrameRate);
			_targetFrameRateSlider.onValueChanged.AddListener(SetTargetFrameRate);
		}

		private void InitVSync()
		{
			_vSyncToggle.isOn = _vSyncSO.Value;
			_vSyncToggle.onValueChanged.AddListener(SetVSync);
		}

		private void InitTiltShift()
		{
			_qualityDropdown.onValueChanged.AddListener(OnQualityChanged);
			_tiltShiftToggle.onValueChanged.AddListener(SetTiltShift);
			_tiltShiftToggle.isOn = _tiltShiftSO.Value;
		}

		private void InitModulesOutline()
		{
			_modulesOutlineToggle.onValueChanged.AddListener(SetModulesOutline);
			_modulesOutlineToggle.isOn = _modulesOutlineSO.Value;
		}

		private void InitDeluxeEditionDrones()
		{
			_deluxeEditionDrones.onValueChanged.AddListener(SetDeluxeEditionDrones);
			_deluxeEditionDrones.isOn = _showDeluxeEditionDronesSO.Value;
		}

		private void SetDeluxeEditionDrones(bool showDeluxeDrones)
		{
			_showDeluxeEditionDronesSO.SetValue(showDeluxeDrones);
		}

		private void InitFullscreenMode()
		{
			_fullscreenModeDropdown.options.Clear();
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			int valueWithoutNotify = 0;
			AllowedFullscreenMode fullScreenMode = GetFullScreenMode();
			SetFullscreen((int)fullScreenMode);
			foreach (AllowedFullscreenMode value in Enum.GetValues(typeof(AllowedFullscreenMode)))
			{
				list.Add(new TMP_Dropdown.OptionData(LocalizationUtility.GetLocalizedText("Settings.DisplayMode" + value)));
				if (fullScreenMode == value)
				{
					valueWithoutNotify = list.Count - 1;
				}
			}
			_fullscreenModeDropdown.options = list;
			_fullscreenModeDropdown.SetValueWithoutNotify(valueWithoutNotify);
			_fullscreenModeDropdown.onValueChanged.RemoveListener(SetFullscreen);
			_fullscreenModeDropdown.onValueChanged.AddListener(SetFullscreen);
		}

		private AllowedFullscreenMode GetFullScreenMode()
		{
			return Screen.fullScreenMode switch
			{
				FullScreenMode.Windowed => AllowedFullscreenMode.Windowed, 
				FullScreenMode.ExclusiveFullScreen => AllowedFullscreenMode.Fullscreen, 
				FullScreenMode.FullScreenWindow => AllowedFullscreenMode.BorderlessFullscreen, 
				FullScreenMode.MaximizedWindow => AllowedFullscreenMode.BorderlessFullscreen, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		private void SetFullscreen(int index)
		{
			_allowedFullscreenMode.SetValue((AllowedFullscreenMode)index);
			if (Enum.IsDefined(typeof(AllowedFullscreenMode), index))
			{
				_fullscreenModeDropdown.SetValueWithoutNotify(index);
			}
		}

		private void SetResolution(int index)
		{
			_resolutionSO.SetValue(_availableResolutions[index].width, _availableResolutions[index].height);
		}

		private void SetLimitFrameRate(bool value)
		{
			_limitFrameRateSO.SetValue(value);
			_targetFrameRateContainer.alpha = (value ? 1f : 0.2f);
			_targetFrameRateContainer.interactable = value;
			_targetFrameRateSlider.value = _targetFrameRateSO.Value;
		}

		private void SetTargetFrameRate(float value)
		{
			_targetFrameRateSO.SetValue((int)value);
		}

		private void SetVSync(bool value)
		{
			_vSyncSO.SetValue(value);
		}

		private void SetTiltShift(bool value)
		{
			_tiltShiftSO.SetValue(value);
		}

		private void SetModulesOutline(bool value)
		{
			_modulesOutlineSO.SetValue(value);
		}

		private bool TryGetResolutionIndex(int width, int height, out int index)
		{
			for (index = 0; index < _availableResolutions.Count; index++)
			{
				if (_availableResolutions[index].width == width && _availableResolutions[index].height == height)
				{
					return true;
				}
			}
			this.LogWarning("Resolution not found in available resolutions", "TryGetResolutionIndex", 360);
			index = -1;
			return false;
		}

		private int GetClosestResolutionIndex(int width, int height)
		{
			Vector2Int vector2Int = new Vector2Int(width, height);
			Vector2Int vector2Int2 = new Vector2Int(int.MaxValue, int.MaxValue);
			int result = 0;
			for (int i = 0; i < _availableResolutions.Count; i++)
			{
				Vector2Int vector2Int3 = new Vector2Int(_availableResolutions[i].width, _availableResolutions[i].height);
				if (vector2Int3 == vector2Int)
				{
					return i;
				}
				Vector2Int vector2Int4 = vector2Int - vector2Int3;
				if (vector2Int4.sqrMagnitude <= vector2Int2.sqrMagnitude)
				{
					vector2Int2 = vector2Int4;
					result = i;
				}
			}
			return result;
		}

		private void InitMaxZoomLevelModifier()
		{
			_maxZoomLevelModifierSlider.value = _maxZoomLevelModifier.Value;
			_maxZoomLevelModifierSlider.onValueChanged.AddListener(SetMaxZoomLevelModifier);
		}

		private void SetMaxZoomLevelModifier(float modifier)
		{
			_maxZoomLevelModifier.SetValue(Mathf.FloorToInt(modifier));
		}
	}
}
