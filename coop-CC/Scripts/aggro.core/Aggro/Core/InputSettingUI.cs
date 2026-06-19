using System;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

namespace Aggro.Core
{
	public class InputSettingUI : AggroSettingUI
	{
		public Image inputIcon;

		public GameObject conflictContainer;

		[Space]
		public Button rebindButton;

		public Button revertButton;

		[Space]
		public EventReference rebindSelected;

		public EventReference revertSelected;

		private InputSetting _setting;

		private bool _releaseControl;

		private bool _hasControl;

		private Action _onRebindingStart;

		private Action _onRebindingComplete;

		private static List<AggroSettingBase> _baseSettings = new List<AggroSettingBase>();

		private List<InputSetting> _otherSettings = new List<InputSetting>();

		public override void Set(AggroSettingBase setting)
		{
			if (setting is InputSetting inputSetting)
			{
				_setting = inputSetting;
				_baseSettings.Clear();
				AggroSettings.GetSettings(_setting.category, _baseSettings);
				for (int i = 0; i < _baseSettings.Count; i++)
				{
					if (_baseSettings[i] is InputSetting inputSetting2 && inputSetting2 != inputSetting)
					{
						_otherSettings.Add(inputSetting2);
					}
				}
			}
			else
			{
				Debug.LogWarning("[SETTINGS] Invalid setting type for InputSetting!");
			}
		}

		public override void Refresh()
		{
			RefreshIcon();
		}

		public bool CanShow()
		{
			return _setting.SupportsMode(AggroSettings.inputMode);
		}

		public void Showing()
		{
			if (_setting.IsReadOnly(AggroSettings.inputMode))
			{
				rebindButton.interactable = false;
				revertButton.interactable = false;
			}
			else
			{
				rebindButton.interactable = true;
				revertButton.interactable = true;
			}
			RefreshIcon();
		}

		public void SetOnRebindingCallback(Action onStart, Action onComplete)
		{
			_onRebindingStart = onStart;
			_onRebindingComplete = onComplete;
		}

		public void OnRebind()
		{
			AggroUtil.PlaySfxIfValid(rebindSelected);
			if (_onRebindingStart != null)
			{
				_onRebindingStart();
			}
			if (_setting.TryPerformRebinding(AggroSettings.inputMode))
			{
				AggroSettings.TakeInputControl();
				_hasControl = true;
			}
		}

		public void OnRevert()
		{
			AggroUtil.PlaySfxIfValid(revertSelected);
			_setting.SetToDefault();
			RefreshIcon();
		}

		private void LateUpdate()
		{
			if (_releaseControl)
			{
				_releaseControl = false;
				_hasControl = false;
				if (_onRebindingComplete != null)
				{
					_onRebindingComplete();
				}
				RefreshIcon();
				AggroSettings.ReleaseInputControl(rebindButton.gameObject);
			}
			if (_hasControl)
			{
				if (!_setting.isRebinding)
				{
					_hasControl = false;
					_setting.Save();
					_releaseControl = true;
				}
				else if (AggroSettings.inputMode != _setting.rebindMode)
				{
					_setting.CancelRebind();
				}
			}
			bool active = false;
			switch (AggroSettings.inputMode)
			{
			case InputMode.KBM:
			{
				for (int j = 0; j < _otherSettings.Count; j++)
				{
					InputSetting other2 = _otherSettings[j];
					if (_setting.DoesKbmConflict(other2))
					{
						active = true;
						break;
					}
				}
				break;
			}
			case InputMode.Gamepad:
			{
				for (int i = 0; i < _otherSettings.Count; i++)
				{
					InputSetting other = _otherSettings[i];
					if (_setting.DoesGamepadConflict(other))
					{
						active = true;
						break;
					}
				}
				break;
			}
			default:
				throw new InvalidEnumException();
			}
			conflictContainer.SetActive(active);
		}

		private void RefreshIcon()
		{
			if (_setting.SupportsMode(AggroSettings.inputMode))
			{
				string path = AggroSettings.inputMode switch
				{
					InputMode.KBM => _setting.GetKbmPath(), 
					InputMode.Gamepad => _setting.GetGamepadPath(), 
					_ => throw new InvalidEnumException(), 
				};
				inputIcon.sprite = GlobalScriptableObject<AggroSettingsObject>.instance.GetInputSprite(path);
			}
		}
	}
}
