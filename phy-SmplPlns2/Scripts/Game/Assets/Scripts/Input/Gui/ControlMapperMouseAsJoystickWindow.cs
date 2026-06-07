using System;
using System.Collections.Generic;
using Assets.Scripts.Settings;
using Rewired.UI.ControlMapper;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Input.Gui
{
	public class ControlMapperMouseAsJoystickWindow : Window
	{
		public enum ButtonIdentifier
		{
			Done = 0,
			Cancel = 1,
			Default = 2
		}

		private Dictionary<int, Action<int>> _buttonCallbacks;

		[SerializeField]
		private RectTransform _calibratedValueMarkerX;

		[SerializeField]
		private RectTransform _calibratedValueMarkerY;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private Text _cancelButtonLabel;

		[SerializeField]
		private RectTransform _deadzoneAreaX;

		[SerializeField]
		private RectTransform _deadzoneAreaY;

		[SerializeField]
		private Slider _deadzoneSlider;

		[SerializeField]
		private Button _defaultButton;

		[SerializeField]
		private Text _defaultButtonLabel;

		[SerializeField]
		private Button _doneButton;

		[SerializeField]
		private Text _doneButtonLabel;

		[SerializeField]
		private CustomToggle _enabledButton;

		private float _initialDeadzone;

		private bool _initialEnabled;

		private bool _initialInvertPitch;

		private float _initialRange;

		[SerializeField]
		private CustomToggle _invertPitchButton;

		[SerializeField]
		private Slider _rangeSlider;

		[SerializeField]
		private RectTransform _rawValueMarkerX;

		[SerializeField]
		private RectTransform _rawValueMarkerY;

		private MouseJoystickSettings _settings;

		public override void Cancel()
		{
			if (!base.initialized)
			{
				return;
			}
			_settings.MouseJoystickEnabled.Value = false;
			_settings.MouseJoystickInvertPitch.Value = _initialInvertPitch;
			_settings.MouseJoystickDeadzone.Value = _initialDeadzone;
			_settings.MouseJoystickRange.Value = _initialRange;
			if (!_buttonCallbacks.TryGetValue(1, out var value))
			{
				if (cancelCallback != null)
				{
					cancelCallback();
				}
			}
			else
			{
				value(base.id);
			}
		}

		public override void Initialize(int id, Func<int, bool> isFocusedCallback)
		{
			if (_doneButton == null || _cancelButton == null || _defaultButton == null || _doneButtonLabel == null || _cancelButtonLabel == null || _defaultButtonLabel == null || _enabledButton == null || _deadzoneSlider == null || _rangeSlider == null || _calibratedValueMarkerX == null || _calibratedValueMarkerY == null || _rawValueMarkerX == null || _rawValueMarkerY == null || _deadzoneAreaX == null || _deadzoneAreaY == null)
			{
				Debug.LogError("Rewired Control Mapper: All inspector values must be assigned!");
				return;
			}
			_settings = Game.Instance.Settings.Gameplay.MouseJoystick;
			_initialEnabled = _settings.MouseJoystickEnabled.Value;
			_initialInvertPitch = _settings.MouseJoystickInvertPitch.Value;
			_initialDeadzone = _settings.MouseJoystickDeadzone.Value;
			_initialRange = _settings.MouseJoystickRange.Value;
			_buttonCallbacks = new Dictionary<int, Action<int>>();
			_doneButtonLabel.text = ControlMapper.GetLanguage().done;
			_cancelButtonLabel.text = ControlMapper.GetLanguage().cancel;
			_defaultButtonLabel.text = ControlMapper.GetLanguage().default_;
			_enabledButton.isOn = _initialEnabled;
			_invertPitchButton.isOn = _initialInvertPitch;
			_deadzoneSlider.value = DeadzoneToSlider(_initialDeadzone);
			_rangeSlider.value = RangeToSlider(_initialRange);
			Redraw();
			base.Initialize(id, isFocusedCallback);
		}

		public void OnCancel()
		{
			Cancel();
		}

		public void OnDeadzoneCancel()
		{
			if (base.initialized)
			{
				_settings.MouseJoystickDeadzone.Value = _initialDeadzone;
				Redraw();
			}
		}

		public void OnDeadzoneValueChange(float value)
		{
			if (base.initialized)
			{
				_settings.MouseJoystickDeadzone.Value = DeadzoneFromSlider(value);
				Redraw();
			}
		}

		public void OnDone()
		{
			if (base.initialized)
			{
				_settings.CommitChanges();
				if (_buttonCallbacks.TryGetValue(0, out var value))
				{
					value(base.id);
				}
			}
		}

		public void OnEnabledChanged(bool state)
		{
			if (base.initialized)
			{
				_settings.MouseJoystickEnabled.Value = state;
			}
		}

		public void OnInvertPitchChanged(bool state)
		{
			if (base.initialized)
			{
				_settings.MouseJoystickInvertPitch.Value = state;
				RedrawValueMarkers();
			}
		}

		public void OnRangeCancel()
		{
			if (base.initialized)
			{
				_settings.MouseJoystickRange.Value = _initialRange;
				RedrawValueMarkers();
			}
		}

		public void OnRangeValueChange(float value)
		{
			if (base.initialized)
			{
				_settings.MouseJoystickRange.Value = RangeFromSlider(value);
				RedrawValueMarkers();
			}
		}

		public void OnRestoreDefault()
		{
			if (base.initialized)
			{
				_settings.RestoreDefaults();
				_enabledButton.isOn = _settings.MouseJoystickEnabled.Value;
				_invertPitchButton.isOn = _settings.MouseJoystickInvertPitch.Value;
				_deadzoneSlider.value = DeadzoneToSlider(_settings.MouseJoystickDeadzone.Value);
				_rangeSlider.value = RangeToSlider(_settings.MouseJoystickRange.Value);
				Redraw();
			}
		}

		public void SetButtonCallback(ButtonIdentifier buttonIdentifier, Action<int> callback)
		{
			if (base.initialized && callback != null)
			{
				if (_buttonCallbacks.ContainsKey((int)buttonIdentifier))
				{
					_buttonCallbacks[(int)buttonIdentifier] = callback;
				}
				else
				{
					_buttonCallbacks.Add((int)buttonIdentifier, callback);
				}
			}
		}

		protected virtual void Start()
		{
			ControlMapper controlMapper = UnityEngine.Object.FindFirstObjectByType<ControlMapper>();
			SetButtonCallback(ButtonIdentifier.Done, controlMapper.CloseWindow);
			SetButtonCallback(ButtonIdentifier.Cancel, controlMapper.CloseWindow);
		}

		protected override void Update()
		{
			if (base.initialized)
			{
				base.Update();
				RedrawValueMarkers();
			}
		}

		private static float DeadzoneFromSlider(float value)
		{
			float min = Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickDeadzone.Min;
			float max = Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickDeadzone.Max;
			return Mathf.Clamp(min + (max - min) * value, min, max);
		}

		private static float DeadzoneToSlider(float value)
		{
			float min = Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickDeadzone.Min;
			float max = Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickDeadzone.Max;
			return Mathf.Clamp((value - min) / (max - min), 0f, 1f);
		}

		private static float RangeFromSlider(float value)
		{
			float min = Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickRange.Min;
			float max = Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickRange.Max;
			return Mathf.Clamp(min + (max - min) * value, min, max);
		}

		private static float RangeToSlider(float value)
		{
			float min = Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickRange.Min;
			float max = Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickRange.Max;
			return Mathf.Clamp((value - min) / (max - min), 0f, 1f);
		}

		private void Redraw()
		{
			RedrawDeadzones();
			RedrawValueMarkers();
		}

		private void RedrawDeadzones()
		{
			float value = _settings.MouseJoystickDeadzone.Value;
			float num = Mathf.Min((float)Screen.width / (float)Screen.height, (float)Screen.height / (float)Screen.width);
			float x = ((RectTransform)_deadzoneAreaX.parent).rect.width * value * num;
			_deadzoneAreaX.sizeDelta = new Vector2(x, _deadzoneAreaX.sizeDelta.y);
			float x2 = ((RectTransform)_deadzoneAreaY.parent).rect.width * value * num;
			_deadzoneAreaY.sizeDelta = new Vector2(x2, _deadzoneAreaY.sizeDelta.y);
		}

		private void RedrawValueMarkers()
		{
			bool value = _settings.MouseJoystickEnabled.Value;
			Vector2 mouseAsJoystickAxis = InputWrapper.GetMouseAsJoystickAxis();
			float num = ((RectTransform)_deadzoneAreaX.parent).rect.width;
			float num2 = (float)Screen.width / 2f;
			float num3 = (float)Screen.height / 2f;
			Vector2 mouseScreenPosition = InputWrapper.MouseScreenPosition;
			mouseScreenPosition.x = (value ? ((mouseScreenPosition.x - num2) / num2) : 0f);
			mouseScreenPosition.y = (value ? ((mouseScreenPosition.y - num3) / num3) : 0f);
			_calibratedValueMarkerX.anchoredPosition = new Vector2(num * 0.5f * mouseAsJoystickAxis.x, _calibratedValueMarkerX.anchoredPosition.y);
			_rawValueMarkerX.anchoredPosition = new Vector2(num * 0.5f * mouseScreenPosition.x, _rawValueMarkerX.anchoredPosition.y);
			_calibratedValueMarkerY.anchoredPosition = new Vector2(num * 0.5f * mouseAsJoystickAxis.y, _calibratedValueMarkerY.anchoredPosition.y);
			_rawValueMarkerY.anchoredPosition = new Vector2(num * 0.5f * mouseScreenPosition.y, _rawValueMarkerY.anchoredPosition.y);
		}
	}
}
