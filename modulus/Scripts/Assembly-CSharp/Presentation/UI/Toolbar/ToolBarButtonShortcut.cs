#define ENABLE_DEBUG_ERRORS
using System;
using Data.UI.Controls;
using Presentation.FactoryFloor.Toolbar;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Presentation.UI.Toolbar
{
	public class ToolBarButtonShortcut : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference _groupInputAction;

		[SerializeField]
		private SettingsRebindRuntimeInfo _rebindInfo;

		[SerializeField]
		private ToolBarButton _toolBarButton;

		[SerializeField]
		private GameObject _shortcutIcon;

		[SerializeField]
		private TMP_Text _shortcutText;

		[SerializeField]
		private ToolBarButtonGroupsSO _toolBarButtonGroup;

		[Header("Selected")]
		[SerializeField]
		private CanvasGroup _buttonCanvasGroup;

		[SerializeField]
		[Range(0f, 1f)]
		private float _buttonCanvasInActiveAlpha = 0.5f;

		private SettingsRebindActionData _groupRebindActionData;

		private bool _initialized;

		private int _groupIndex = -1;

		private bool _hasBoundInput;

		private bool _isActiveInGroup;

		public bool IsSelected => _toolBarButton.IsSelected;

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
			_initialized = true;
			if (_groupInputAction == null || _rebindInfo == null || _toolBarButton == null)
			{
				_hasBoundInput = false;
				UpdateButtonVisuals();
				return;
			}
			_toolBarButton.Button.onClick.AddListener(OnButtonClicked);
			if (_groupInputAction != null)
			{
				_groupIndex = _toolBarButtonGroup.AddButton(_groupInputAction, this);
				_hasBoundInput = TryGetRebindActionData(_groupInputAction, out _groupRebindActionData);
			}
			if (_hasBoundInput)
			{
				OnInputChanged();
			}
			else
			{
				UpdateButtonVisuals();
			}
		}

		private void OnDestroy()
		{
			UnInit();
		}

		public void UnInit()
		{
			if (_initialized)
			{
				_initialized = false;
				if (_groupRebindActionData != null)
				{
					SettingsRebindActionData groupRebindActionData = _groupRebindActionData;
					groupRebindActionData.OnChanged = (Action)Delegate.Remove(groupRebindActionData.OnChanged, new Action(OnInputChanged));
				}
				if (_groupInputAction != null && _groupIndex != -1)
				{
					_toolBarButtonGroup.RemoveButton(_groupInputAction, _groupIndex);
				}
				if (_toolBarButton != null)
				{
					_toolBarButton.Button.onClick.RemoveListener(OnButtonClicked);
				}
			}
		}

		public void SetButtonActiveInGroup(bool shortcutActive)
		{
			if (_isActiveInGroup != shortcutActive)
			{
				_isActiveInGroup = shortcutActive;
				UpdateButtonVisuals();
			}
		}

		private bool TryGetRebindActionData(InputActionReference inputAction, out SettingsRebindActionData settingsRebindActionData)
		{
			if (!_rebindInfo.TryGetRebindActionData(inputAction, out var rebindActionData))
			{
				this.LogError("You're using a shortcut that doesn't have a rebind?", "TryGetRebindActionData", 110);
				settingsRebindActionData = null;
				return false;
			}
			settingsRebindActionData = rebindActionData[0];
			SettingsRebindActionData obj = settingsRebindActionData;
			obj.OnChanged = (Action)Delegate.Combine(obj.OnChanged, new Action(OnInputChanged));
			return true;
		}

		private void OnInputChanged()
		{
			_hasBoundInput = _groupInputAction != null && TryUpdateInputString(_groupInputAction);
			UpdateButtonVisuals();
		}

		private bool TryUpdateInputString(InputActionReference inputAction)
		{
			if (!_rebindInfo.TryGetRebindActions(inputAction, out var rebindActions))
			{
				this.LogError("There are no SettingsRebindAction for my SettingsRebindActionData, there should always be atleast 1?", "TryUpdateInputString", 130);
				return false;
			}
			foreach (SettingsRebindAction item in rebindActions)
			{
				if (!item.IsUnbound())
				{
					_shortcutText.SetText(item.GetBindingString(omitModifier: true));
					return true;
				}
			}
			return false;
		}

		private void UpdateButtonVisuals()
		{
			if (!(_buttonCanvasGroup == null))
			{
				_buttonCanvasGroup.alpha = ((!_hasBoundInput || _isActiveInGroup || _groupInputAction == null) ? 1f : _buttonCanvasInActiveAlpha);
				_shortcutIcon.SetActive(_hasBoundInput && _isActiveInGroup);
			}
		}

		public bool TryPressButtonShortcut()
		{
			if (!_toolBarButton.Button.interactable)
			{
				return false;
			}
			_toolBarButton.Button.onClick.Invoke();
			return true;
		}

		private void OnButtonClicked()
		{
			if (_groupInputAction != null)
			{
				_toolBarButtonGroup.SetLastPressedButton(_groupInputAction, _groupIndex);
			}
		}
	}
}
