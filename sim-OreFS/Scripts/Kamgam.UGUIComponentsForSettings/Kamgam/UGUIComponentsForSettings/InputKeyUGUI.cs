using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	[SelectionBase]
	public class InputKeyUGUI : MonoBehaviour
	{
		public delegate void OnChangedDelegate(UniversalKeyCode key, UniversalKeyCode modifierKey);

		public Func<UniversalKeyCode, string> KeyCodeToKeyNameFunc;

		[SerializeField]
		protected UniversalKeyCode _key;

		[SerializeField]
		protected UniversalKeyCode _modifierKey;

		public bool AllowMouseButtons;

		public bool AllowKeyCombinations;

		public bool AllowAbortWithCancelButton;

		public UnityEvent<UniversalKeyCode, UniversalKeyCode> OnChangedEvent;

		public OnChangedDelegate OnChanged;

		public Button Button;

		public GameObject Normal;

		public GameObject Active;

		public TextMeshProUGUI TextTf;

		public TextMeshProUGUI KeyNameTf;

		public TextMeshProUGUI ActiveTextTf;

		protected bool waitForKeyRelease;

		protected UniversalKeyCode _modifierKeyWhileActive;

		protected UniversalKeyCode _keyWhileActive;

		protected bool _aKeyWasPressedWhileActive;

		public UniversalKeyCode Key
		{
			get
			{
				return _key;
			}
			set
			{
				if (value != _key)
				{
					_key = value;
					UpdateKeyName();
				}
			}
		}

		public UniversalKeyCode ModifierKey
		{
			get
			{
				return _modifierKey;
			}
			set
			{
				if (value != _modifierKey)
				{
					_modifierKey = value;
					UpdateKeyName();
				}
			}
		}

		public bool IsActive => Active.activeSelf;

		public string Text
		{
			get
			{
				return TextTf.text;
			}
			set
			{
				if (!(value == Text))
				{
					TextTf.text = value;
				}
			}
		}

		public string KeyName
		{
			get
			{
				return KeyNameTf.text;
			}
			set
			{
				if (!(value == KeyName))
				{
					KeyNameTf.text = value;
				}
			}
		}

		public string ActiveText
		{
			get
			{
				return ActiveTextTf.text;
			}
			set
			{
				if (!(value == ActiveText))
				{
					ActiveTextTf.text = value;
				}
			}
		}

		public void SetActive(bool active)
		{
			bool num = IsActive != active && active;
			bool flag = IsActive != active && !active;
			if (num)
			{
				InputUtils.ResetStuckKeyStates();
			}
			if (num && InputUtils.AnyKey())
			{
				waitForKeyRelease = true;
			}
			if (flag && EventSystem.current != null)
			{
				SelectionUtils.SetSelected(Button.gameObject);
			}
			Normal.SetActive(!active);
			Active.SetActive(active);
			Button.interactable = !active;
			if (active)
			{
				_modifierKeyWhileActive = UniversalKeyCode.None;
				_keyWhileActive = UniversalKeyCode.None;
				_aKeyWasPressedWhileActive = false;
			}
		}

		public void UpdateKeyName()
		{
			if (ModifierKey != UniversalKeyCode.None)
			{
				if (KeyCodeToKeyNameFunc == null)
				{
					KeyName = InputUtils.UniversalKeyName(ModifierKey) + " + " + InputUtils.UniversalKeyName(Key);
				}
				else
				{
					KeyName = KeyCodeToKeyNameFunc(ModifierKey) + " + " + KeyCodeToKeyNameFunc(Key);
				}
			}
			else if (KeyCodeToKeyNameFunc == null)
			{
				KeyName = InputUtils.UniversalKeyName(Key);
			}
			else
			{
				KeyName = KeyCodeToKeyNameFunc(Key);
			}
		}

		public bool IsCancelKeyPressed()
		{
			return InputUtils.CancelDown();
		}

		public void OnEnable()
		{
			Refresh();
		}

		public void OnDisable()
		{
			if (IsActive)
			{
				waitForKeyRelease = false;
				SetActive(active: false);
			}
		}

		public void Refresh()
		{
			UpdateKeyName();
		}

		public void Update()
		{
			if (!InputUtils.AnyKey())
			{
				waitForKeyRelease = false;
			}
			if (!IsActive || waitForKeyRelease)
			{
				return;
			}
			if (AllowAbortWithCancelButton && IsCancelKeyPressed())
			{
				SetActive(active: false);
			}
			bool flag = InputUtils.GetUniversalKeyUp(excludeModifierKeys: false, excludeMouseButtons: true) != UniversalKeyCode.None;
			bool flag2 = InputUtils.MouseUp();
			if (_aKeyWasPressedWhileActive && (flag || flag2))
			{
				SetActive(active: false);
				if (!flag2 || AllowMouseButtons)
				{
					if (_modifierKeyWhileActive != UniversalKeyCode.None && _keyWhileActive == UniversalKeyCode.None)
					{
						ModifierKey = UniversalKeyCode.None;
						Key = _modifierKeyWhileActive;
					}
					else
					{
						if (AllowKeyCombinations)
						{
							ModifierKey = _modifierKeyWhileActive;
						}
						else
						{
							ModifierKey = UniversalKeyCode.None;
						}
						Key = _keyWhileActive;
					}
					OnChanged?.Invoke(Key, ModifierKey);
					OnChangedEvent.Invoke(Key, ModifierKey);
				}
			}
			if (InputUtils.AnyKeyDown())
			{
				_aKeyWasPressedWhileActive = true;
				UniversalKeyCode modifierKeyDown = InputUtils.GetModifierKeyDown();
				if (modifierKeyDown != UniversalKeyCode.None)
				{
					_modifierKeyWhileActive = modifierKeyDown;
				}
				UniversalKeyCode universalKeyDown = InputUtils.GetUniversalKeyDown(excludeModifierKeys: true, !AllowMouseButtons);
				if (universalKeyDown != UniversalKeyCode.None)
				{
					_keyWhileActive = universalKeyDown;
				}
			}
		}
	}
}
