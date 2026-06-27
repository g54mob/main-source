using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.Scripting;

namespace Restory.Data.GUIControllerElements
{
	[Preserve]
	[CreateAssetMenu(menuName = "Restory/Controllers/GUI/GuiKeyboardTemplate", fileName = "New GuiKeyboardTemplate")]
	public class GuiKeyboardTemplate : GuiControllerTemplate, IGuiKeyboardTemplate, IGuiControllerTemplate
	{
		[SerializeField]
		private ControllerId controllerId;

		[SerializeField]
		private Dictionary<KeyboardKeyCode, GuiControllerTemplateButtonElement> keys = new Dictionary<KeyboardKeyCode, GuiControllerTemplateButtonElement>();

		private List<IGuiControllerTemplateElement> elements;

		private static KeyboardKeyCode[] keycodes = (KeyboardKeyCode[])Enum.GetValues(typeof(KeyboardKeyCode));

		public override ControllerId ControllerId => controllerId;

		public override IReadOnlyList<IGuiControllerTemplateElement> Elements => elements ?? (elements = new List<IGuiControllerTemplateElement>(keys.Values));

		public IGuiControllerTemplateElement GetElement(KeyboardKeyCode keycode)
		{
			if (!keys.ContainsKey(keycode))
			{
				return null;
			}
			return keys[keycode];
		}

		public override bool TryGetElement(int elementId, out IGuiControllerTemplateElement element)
		{
			element = GetElement(elementId);
			return element != null;
		}

		public override IGuiControllerTemplateElement GetElement(int elementId)
		{
			return GetElement(GetkeyCode(elementId));
		}

		private static KeyboardKeyCode GetkeyCode(int elementId)
		{
			if (elementId >= 0 && elementId < keycodes.Length)
			{
				return keycodes[elementId];
			}
			return KeyboardKeyCode.None;
		}

		public void GenerateAllKeys()
		{
			KeyboardKeyCode[] array = keycodes;
			foreach (KeyboardKeyCode key in array)
			{
				if (!keys.ContainsKey(key))
				{
					keys[key] = new GuiControllerTemplateButtonElement(Keyboard.GetKeyName((KeyCode)key));
				}
			}
		}
	}
}
