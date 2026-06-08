using UnityEngine;
using UnityEngine.InputSystem;

namespace Dorfromantik.Utility.Localization
{
	public class LocalizedTextGamepad : LocalizedText
	{
		[SerializeField]
		internal InputActionReference inputAction;

		[SerializeField]
		private string fallbackBindingString;

		[SerializeField]
		private int firstBindingIndex = -1;

		[SerializeField]
		private int displayedBindingsCount = -1;

		[SerializeField]
		private bool shouldInsertAtBeginning = true;

		[SerializeField]
		private bool shouldInsertAtEnd;

		[SerializeField]
		private bool shouldUpdateTextOnInputDeviceChange = true;

		protected override void Start()
		{
			base.Start();
			if (shouldUpdateTextOnInputDeviceChange)
			{
				Singleton<InputManager>.Instance.OnInputDeviceChanged += UpdateGamepadLabelText;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if ((bool)Singleton<InputManager>.Instance && shouldUpdateTextOnInputDeviceChange)
			{
				Singleton<InputManager>.Instance.OnInputDeviceChanged -= UpdateGamepadLabelText;
			}
		}

		private void UpdateGamepadLabelText(InputDevice inputDevice)
		{
			UpdateText();
		}

		protected override void UpdateText()
		{
			base.UpdateText();
			string currentControlScheme = Singleton<InputManager>.Instance.CurrentControlScheme;
			string text = KeyBindingUtility.GetRichTextAttributeForBinding(KeyBindingUtility.GetBindingString(inputAction, InputBinding.MaskByGroup(currentControlScheme)), showSymbolForEmptyBinding: false, fallbackBindingString, firstBindingIndex, displayedBindingsCount);
			if (LocalizationManager.Instance.IsCurrentLanguageRightToLeft)
			{
				text = StringUtility.Reverse(text);
			}
			string targetText = "";
			if (shouldInsertAtBeginning && shouldInsertAtEnd)
			{
				Debug.LogWarning("The gamepad label tries to be placed at the beginning and the end of the string. Only one is possible (default = at the beginning)");
			}
			if (shouldInsertAtBeginning)
			{
				if ((bool)textMesh)
				{
					targetText = text + " " + textMesh.text;
				}
				if ((bool)textMeshUi)
				{
					targetText = text + " " + textMeshUi.text;
				}
			}
			else if (shouldInsertAtEnd)
			{
				if ((bool)textMesh)
				{
					targetText = textMesh.text + " " + text;
				}
				if ((bool)textMeshUi)
				{
					targetText = textMeshUi.text + " " + text;
				}
			}
			else
			{
				Debug.LogWarning("Missing settings! SelectshouldInsertAtBeginning or shouldInsertAtEnd.");
				if ((bool)textMesh)
				{
					targetText = textMesh.text;
				}
				if ((bool)textMesh)
				{
					targetText = textMeshUi.text;
				}
			}
			if ((bool)textMeshUi)
			{
				UpdateTextMesh(textMeshUi, targetText);
			}
			if ((bool)textMesh)
			{
				UpdateTextMesh(textMesh, targetText);
			}
		}

		private void AddGamepadLabelToExistingText(bool shouldCleanupExistingString = true)
		{
			string currentControlScheme = Singleton<InputManager>.Instance.CurrentControlScheme;
			string richTextAttributeForBinding = KeyBindingUtility.GetRichTextAttributeForBinding(KeyBindingUtility.GetBindingString(inputAction, InputBinding.MaskByGroup(currentControlScheme)), showSymbolForEmptyBinding: false, fallbackBindingString, firstBindingIndex, displayedBindingsCount);
			string targetText = "";
			if (shouldInsertAtBeginning && shouldInsertAtEnd)
			{
				Debug.LogWarning("The gamepad label tries to be placed at the beginning and the end of the string. Only one is possible (default = at the beginning)");
			}
			if (shouldInsertAtBeginning)
			{
				if ((bool)textMesh)
				{
					targetText = richTextAttributeForBinding + " " + textMesh.text;
				}
				if ((bool)textMeshUi)
				{
					targetText = richTextAttributeForBinding + " " + textMeshUi.text;
				}
			}
			else if (shouldInsertAtEnd)
			{
				if ((bool)textMesh)
				{
					targetText = textMesh.text + " " + richTextAttributeForBinding;
				}
				if ((bool)textMeshUi)
				{
					targetText = textMeshUi.text + " " + richTextAttributeForBinding;
				}
			}
			else
			{
				Debug.LogWarning("Missing settings! SelectshouldInsertAtBeginning or shouldInsertAtEnd.");
				if ((bool)textMesh)
				{
					targetText = textMesh.text;
				}
				if ((bool)textMesh)
				{
					targetText = textMeshUi.text;
				}
			}
			if ((bool)textMeshUi)
			{
				UpdateTextMesh(textMeshUi, targetText);
			}
			if ((bool)textMesh)
			{
				UpdateTextMesh(textMesh, targetText);
			}
		}

		private void ResetStringToNonGamepad()
		{
			base.UpdateText();
		}
	}
}
