using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dorfromantik
{
	public class ExitToolHint : MonoBehaviour
	{
		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private TextMeshProUGUI label;

		private RectTransform rectTransform;

		[SerializeField]
		private InputActionReference exitToolAction;

		private Dictionary<ToolId, string> toolLocalizationKey = new Dictionary<ToolId, string>
		{
			{
				ToolId.Pipette,
				"creativeMode_eyedropper"
			},
			{
				ToolId.MatchingTile,
				"creativeMode_matchingTile"
			},
			{
				ToolId.TileDeletion,
				"settings_controls_action_destroyTile"
			}
		};

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
			inputRouter.OnToolEnabled += ShowExitToolHint;
			Show(show: false, animate: false);
			exitToolAction.action.started += ExitTool;
			Singleton<InputManager>.Instance.OnInputDeviceChanged += InputDeviceChanged;
		}

		private void InputDeviceChanged(InputDevice newInputDevice)
		{
			ShowExitToolHint(inputRouter.ActiveTool);
		}

		private void ExitTool(InputAction.CallbackContext obj)
		{
			inputRouter.SwitchToTool(ToolId.None);
		}

		private void ShowExitToolHint(ToolId tool, bool enableTool = true)
		{
			if (Singleton<InputManager>.Instance.CurrentInputDevice == InputDevice.MouseKeyboard)
			{
				Show(show: false);
			}
			else if (enableTool)
			{
				if (tool == ToolId.None)
				{
					Show(show: false);
					return;
				}
				UpdateLabel(tool);
				Show(show: true);
			}
		}

		private void UpdateLabel(ToolId tool)
		{
			string currentControlScheme = Singleton<InputManager>.Instance.CurrentControlScheme;
			string text = LocalizationManager.Instance.GetLocalizedValue(toolLocalizationKey[tool], useFallbackText: true) + " - " + LocalizationManager.Instance.GetLocalizedValue("creativeMode_exitTool", useFallbackText: true);
			string text2 = KeyBindingUtility.GetRichTextAttributeForBinding(KeyBindingUtility.GetBindingString(exitToolAction.action, InputBinding.MaskByGroup(currentControlScheme)));
			if (LocalizationManager.Instance.IsCurrentLanguageRightToLeft)
			{
				text2 = StringUtility.Reverse(text2);
			}
			if (LocalizationManager.Instance.IsCurrentLanguageRightToLeft)
			{
				text2 = StringUtility.Reverse(text2);
			}
			text = text.Replace("[input]", text2);
			LocalizationManager.Instance.UpdateTextMesh(label, LocalizedFontStyle.H2, text);
		}

		private void Show(bool show, bool animate = true)
		{
			ShortcutExtensions.DOScale(rectTransform, show ? 1 : 0, 0.3f);
		}

		private void OnDestroy()
		{
			inputRouter.OnToolEnabled -= ShowExitToolHint;
			exitToolAction.action.started -= ExitTool;
			if ((bool)Singleton<InputManager>.Instance)
			{
				Singleton<InputManager>.Instance.OnInputDeviceChanged -= InputDeviceChanged;
			}
		}
	}
}
