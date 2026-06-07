#define ENABLE_DEBUG_ERRORS
using System;
using Data.UI.Controls;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI
{
	public class ButtonShortCut : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference _inputAction;

		[SerializeField]
		private SettingsRebindRuntimeInfo _rebindInfo;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _shortcutIcon;

		[SerializeField]
		private TMP_Text _shortcutText;

		private SettingsRebindActionData _rebindActionData;

		private bool _initialized;

		private void Start()
		{
			Init();
		}

		public void Init()
		{
			if (_initialized)
			{
				return;
			}
			if (_inputAction == null || _rebindInfo == null)
			{
				_shortcutIcon.SetActive(value: false);
				return;
			}
			if (_button != null)
			{
				_inputAction.action.performed += ActionPerformed;
			}
			if (!_rebindInfo.TryGetRebindActionData(_inputAction, out var rebindActionData))
			{
				_shortcutIcon.SetActive(value: false);
				this.LogError("You're using a shortcut that doesn't have a rebind?", "Init", 44);
				return;
			}
			_rebindActionData = rebindActionData[0];
			SettingsRebindActionData rebindActionData2 = _rebindActionData;
			rebindActionData2.OnChanged = (Action)Delegate.Combine(rebindActionData2.OnChanged, new Action(OnInputChanged));
			OnInputChanged();
			_initialized = true;
		}

		private void OnInputChanged()
		{
			if (_shortcutIcon == null)
			{
				this.LogError("_shortcutIcon is null. This should never happen", "OnInputChanged", 57);
				return;
			}
			if (!_rebindInfo.TryGetRebindActions(_inputAction, out var rebindActions))
			{
				_shortcutIcon.SetActive(value: false);
				this.LogError("There are no SettingsRebindAction for my SettingsRebindActionData, there should always be atleast 1?", "OnInputChanged", 64);
				return;
			}
			foreach (SettingsRebindAction item in rebindActions)
			{
				if (!item.IsUnbound())
				{
					_shortcutText.SetText(item.GetBindingString(omitModifier: true));
					_shortcutIcon.SetActive(value: true);
					return;
				}
			}
			_shortcutIcon.SetActive(value: false);
		}

		private void OnDestroy()
		{
			if (_button != null && _inputAction != null)
			{
				_inputAction.action.performed -= ActionPerformed;
			}
			if (_rebindActionData != null)
			{
				SettingsRebindActionData rebindActionData = _rebindActionData;
				rebindActionData.OnChanged = (Action)Delegate.Remove(rebindActionData.OnChanged, new Action(OnInputChanged));
			}
		}

		private void ActionPerformed(InputAction.CallbackContext obj)
		{
			if (_button.interactable)
			{
				_button.onClick.Invoke();
			}
		}
	}
}
