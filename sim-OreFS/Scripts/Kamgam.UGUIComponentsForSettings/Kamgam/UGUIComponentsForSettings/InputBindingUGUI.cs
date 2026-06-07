using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.Switch;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	[SelectionBase]
	public class InputBindingUGUI : MonoBehaviour
	{
		public delegate void OnChangedDelegate(string bindingPath);

		public CurrentGamepadType currentGamepad;

		public InputKeyBindingImageDatas bindingImageData;

		public Func<string, string> PathToDisplayNameFunc;

		public InputBindingForInputSystem InputBinding;

		public UnityEvent<string> OnChangedEvent;

		public OnChangedDelegate OnChanged;

		public Button Button;

		public GameObject Normal;

		public GameObject Active;

		public TextMeshProUGUI TextTf;

		public TextMeshProUGUI DisplayNameTf;

		public Image DisplayImage;

		public TextMeshProUGUI ActiveTextTf;

		public List<GameObject> settingsInputObj;

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

		public virtual string DisplayName
		{
			get
			{
				if (DisplayNameTf == null)
				{
					return null;
				}
				return DisplayNameTf.text;
			}
			set
			{
				if (!(value == DisplayName))
				{
					DisplayNameTf.text = value;
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

		public virtual void SetActive(bool active)
		{
			bool num = IsActive != active && active;
			bool flag = IsActive != active && !active;
			if (num && InputBinding != null)
			{
				InputBinding.AddOnCompleteCallback(onBindingComplete);
				InputBinding.AddOnCanceledCallback(onBindingCanceled);
				InputBinding.StartListening();
			}
			if (flag && EventSystem.current != null)
			{
				SelectionUtils.SetSelected(Button.gameObject);
			}
			Active.SetActive(active);
			Button.interactable = !active;
			StartCoroutine(CheckSettingsInputObj(active));
		}

		public IEnumerator CheckSettingsInputObj(bool active)
		{
			yield return null;
			if (active)
			{
				foreach (GameObject item in settingsInputObj)
				{
					item.SetActive(value: false);
				}
				yield break;
			}
			foreach (GameObject item2 in settingsInputObj)
			{
				item2.SetActive(value: true);
			}
		}

		protected void onBindingComplete()
		{
			InputBinding.RemoveOnCompleteCallback(onBindingComplete);
			InputBinding.RemoveOnCanceledCallback(onBindingCanceled);
			UpdateDisplayName();
			SetActive(active: false);
			OnChanged?.Invoke(InputBinding.GetBindingPath());
			OnChangedEvent?.Invoke(InputBinding.GetBindingPath());
		}

		protected virtual void onBindingCanceled()
		{
			InputBinding.RemoveOnCompleteCallback(onBindingComplete);
			InputBinding.RemoveOnCanceledCallback(onBindingCanceled);
			SetActive(active: false);
		}

		public virtual void UpdateDisplayName()
		{
			if (InputBinding != null)
			{
				if (PathToDisplayNameFunc != null)
				{
					DisplayImage.sprite = GetInputBindingImage(InputBinding.GetBindingPath());
					DisplayName = PathToDisplayNameFunc(InputBinding.GetBindingPath());
				}
				else
				{
					DisplayName = InputBinding.GetBindingPath();
				}
			}
		}

		public virtual bool IsCancelKeyPressed()
		{
			return InputUtils.CancelDown();
		}

		public void OnEnable()
		{
			Refresh();
			InputBinding.OnEnable();
		}

		public void OnDisable()
		{
			InputBinding.OnDisable();
			if (IsActive)
			{
				SetActive(active: false);
			}
		}

		public virtual void Refresh()
		{
			UpdateDisplayName();
		}

		public Sprite GetInputBindingImage(string bindingPath)
		{
			if (bindingPath.Contains("Gamepad"))
			{
				Gamepad current = Gamepad.current;
				if (current != null)
				{
					if (!(current is DualShockGamepad))
					{
						if (!(current is XInputController))
						{
							if (current is SwitchProControllerHID)
							{
								currentGamepad = CurrentGamepadType.Xbox;
							}
							else
							{
								currentGamepad = CurrentGamepadType.Xbox;
							}
						}
						else
						{
							currentGamepad = CurrentGamepadType.Xbox;
						}
					}
					else
					{
						currentGamepad = CurrentGamepadType.Playstation;
					}
				}
				else
				{
					currentGamepad = CurrentGamepadType.Xbox;
				}
				if (PlayerPrefs.GetInt("ControllerOverlayImageType") == 1)
				{
					currentGamepad = CurrentGamepadType.Xbox;
				}
				else if (PlayerPrefs.GetInt("ControllerOverlayImageType") == 2)
				{
					currentGamepad = CurrentGamepadType.Playstation;
				}
				if (currentGamepad == CurrentGamepadType.Playstation)
				{
					foreach (InputKeyBindingImageDatas.GamepadBindingData gamepad in bindingImageData.gamepadList)
					{
						if (gamepad.gamepadString == bindingPath && gamepad.playStationSprite != null)
						{
							return gamepad.playStationSprite;
						}
					}
					return bindingImageData.unknownSprite;
				}
				foreach (InputKeyBindingImageDatas.GamepadBindingData gamepad2 in bindingImageData.gamepadList)
				{
					if (gamepad2.gamepadString == bindingPath && gamepad2.xboxSprite != null)
					{
						return gamepad2.xboxSprite;
					}
				}
				return bindingImageData.unknownSprite;
			}
			foreach (InputKeyBindingImageDatas.KeyboardBindingData keyboard in bindingImageData.keyboardList)
			{
				if (keyboard.keyboardString == bindingPath && keyboard.keyboardSprite != null)
				{
					return keyboard.keyboardSprite;
				}
			}
			foreach (InputKeyBindingImageDatas.MouseBindingData mouse in bindingImageData.mouseList)
			{
				if (mouse.mouseString == bindingPath && mouse.mouseSprite != null)
				{
					return mouse.mouseSprite;
				}
			}
			return bindingImageData.unknownSprite;
		}
	}
}
