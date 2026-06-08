using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dorfromantik.UI.Gamepad
{
	public class GamepadInputLabel : MonoBehaviour
	{
		internal enum GamepadLabelPosition
		{
			TopLeft = 0,
			TopRight = 1,
			Custom = 99
		}

		[SerializeField]
		private TextMeshProUGUI gamepadInputLabel;

		[SerializeField]
		internal InputActionReference inputAction;

		[SerializeField]
		private int firstBindingIndex = -1;

		[SerializeField]
		private int displayedBindingsCount = -1;

		[SerializeField]
		private string fallbackBindingString;

		[SerializeField]
		private bool setGameObjectActiveInsteadOfInputLabel;

		[SerializeField]
		private GamepadLabelPosition gamepadLabelPosition = GamepadLabelPosition.Custom;

		[SerializeField]
		private RectTransform gamepadInputLabelContainer;

		[SerializeField]
		internal GamepadLabelPosition currentGamepadLabelPosition;

		private Vector2 defaultAnchoredPosition;

		private readonly Vector2 anchorMinTopLeft = new Vector2(0f, 1f);

		private readonly Vector2 anchorMaxTopLeft = new Vector2(0f, 1f);

		private readonly Vector2 anchorMinTopRight = new Vector2(1f, 1f);

		private readonly Vector2 anchorMaxTopRight = new Vector2(1f, 1f);

		private void Start()
		{
			TryInitializing();
			Singleton<InputManager>.Instance.OnInputDeviceChanged += UpdateLabel;
			UpdateLabel(Singleton<InputManager>.Instance.CurrentInputDevice);
			UpdateLabelLayout();
		}

		private void OnValidate()
		{
			if (base.gameObject.activeSelf && currentGamepadLabelPosition != gamepadLabelPosition && TryInitializing())
			{
				UpdateLabelLayout();
			}
		}

		private bool TryInitializing()
		{
			if (gamepadInputLabelContainer == null)
			{
				return false;
			}
			defaultAnchoredPosition = gamepadInputLabelContainer.anchoredPosition;
			return true;
		}

		private void UpdateLabel(InputDevice obj)
		{
			string currentControlScheme = Singleton<InputManager>.Instance.CurrentControlScheme;
			string richTextAttributeForBinding = KeyBindingUtility.GetRichTextAttributeForBinding(KeyBindingUtility.GetBindingString(inputAction, InputBinding.MaskByGroup(currentControlScheme)), showSymbolForEmptyBinding: false, fallbackBindingString, firstBindingIndex, displayedBindingsCount);
			gamepadInputLabel.text = richTextAttributeForBinding;
			if (setGameObjectActiveInsteadOfInputLabel)
			{
				base.gameObject.SetActive(!string.IsNullOrWhiteSpace(richTextAttributeForBinding));
			}
			else
			{
				gamepadInputLabel.gameObject.SetActive(!string.IsNullOrWhiteSpace(richTextAttributeForBinding));
			}
		}

		internal void UpdateLabelLayout()
		{
			switch (gamepadLabelPosition)
			{
			case GamepadLabelPosition.TopLeft:
				gamepadInputLabelContainer.anchorMin = anchorMinTopLeft;
				gamepadInputLabelContainer.anchorMax = anchorMaxTopLeft;
				gamepadInputLabelContainer.anchoredPosition = defaultAnchoredPosition;
				break;
			case GamepadLabelPosition.TopRight:
				gamepadInputLabelContainer.anchorMin = anchorMinTopRight;
				gamepadInputLabelContainer.anchorMax = anchorMaxTopRight;
				gamepadInputLabelContainer.anchoredPosition = defaultAnchoredPosition;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case GamepadLabelPosition.Custom:
				break;
			}
			currentGamepadLabelPosition = gamepadLabelPosition;
		}

		private void OnDestroy()
		{
			if ((bool)Singleton<InputManager>.Instance)
			{
				Singleton<InputManager>.Instance.OnInputDeviceChanged -= UpdateLabel;
			}
		}
	}
}
