using System;
using System.Collections.Generic;
using Assets.Scripts.Settings;
using Rewired.UI.ControlMapper;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Input.Gui
{
	public class ControlMapperAdvancedSettingsWindow : Window
	{
		public enum ButtonIdentifier
		{
			Done = 0,
			Cancel = 1
		}

		[SerializeField]
		private CustomToggle _androidGamepadSupportInputToggle;

		[SerializeField]
		private RectTransform _androidGamepadSupportRootElement;

		private Dictionary<int, Action<int>> _buttonCallbacks;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private Text _cancelButtonLabel;

		[SerializeField]
		private RectTransform _directInputRootElement;

		[SerializeField]
		private CustomToggle _directInputToggle;

		[SerializeField]
		private Button _doneButton;

		[SerializeField]
		private Text _doneButtonLabel;

		private bool _initialAndroidGamepadSupportSetting;

		private bool _initialDirectInputSetting;

		private GeneralSettings _settings;

		public override void Cancel()
		{
			if (!base.initialized)
			{
				return;
			}
			_settings.UseDirectInput.Value = _initialDirectInputSetting;
			_settings.SupportUnknownGamepadsOnAndroid.Value = _initialAndroidGamepadSupportSetting;
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
			if (_doneButton == null || _cancelButton == null || _doneButtonLabel == null || _cancelButtonLabel == null || _directInputRootElement == null || _androidGamepadSupportRootElement == null)
			{
				Debug.LogError("Rewired Control Mapper: All inspector values must be assigned!");
				return;
			}
			_settings = Game.Instance.Settings.Gameplay.General;
			_initialDirectInputSetting = _settings.UseDirectInput;
			_initialAndroidGamepadSupportSetting = _settings.SupportUnknownGamepadsOnAndroid;
			_buttonCallbacks = new Dictionary<int, Action<int>>();
			_doneButtonLabel.text = ControlMapper.GetLanguage().done;
			_cancelButtonLabel.text = ControlMapper.GetLanguage().cancel;
			_directInputToggle.isOn = _initialDirectInputSetting;
			_androidGamepadSupportInputToggle.isOn = _initialAndroidGamepadSupportSetting;
			if (Game.Instance.Device.IsMobileBuild)
			{
				_directInputRootElement.gameObject.SetActive(value: false);
			}
			else
			{
				_androidGamepadSupportRootElement.gameObject.SetActive(value: false);
			}
			base.Initialize(id, isFocusedCallback);
		}

		public void OnAndroidGamepadSupportEnabledChanged(bool state)
		{
			if (base.initialized)
			{
				_settings.SupportUnknownGamepadsOnAndroid.Value = state;
			}
		}

		public void OnCancel()
		{
			Cancel();
		}

		public void OnDirectInputEnabledChanged(bool state)
		{
			if (base.initialized)
			{
				_settings.UseDirectInput.Value = state;
			}
		}

		public void OnDone()
		{
			if (base.initialized)
			{
				_settings.UseDirectInput.CommitChanges();
				_settings.SupportUnknownGamepadsOnAndroid.CommitChanges();
				if (_initialAndroidGamepadSupportSetting != (bool)_settings.SupportUnknownGamepadsOnAndroid && Game.Instance.Device.IsAndroidBuild)
				{
					Application.Quit();
				}
				if (_buttonCallbacks.TryGetValue(0, out var value))
				{
					value(base.id);
				}
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
	}
}
