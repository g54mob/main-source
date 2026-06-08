using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dorfromantik
{
	public class KeyBindingUtility : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<string, bool> _003C_003E9__3_0;

			internal bool _003CGetRichTextAttributeForBinding_003Eb__3_0(string x)
			{
				if (x != "|")
				{
					return x != "/";
				}
				return false;
			}
		}

		private static Dictionary<InputDevice, string> spriteAssetByInputDevice = new Dictionary<InputDevice, string>
		{
			{
				InputDevice.Gamepad,
				"Gamepad_Buttons"
			},
			{
				InputDevice.NintendoSwitch,
				"NintendoSwitch_Buttons"
			}
		};

		private static Dictionary<string, string> bindingStringRerouting = new Dictionary<string, string>
		{
			{ "Right Stick Press", "RS Press" },
			{ "Left Stick Press", "LS Press" },
			{ "R3", "RS Press" },
			{ "L3", "LS Press" }
		};

		private static Dictionary<string, int> spriteIndexByBindingString = new Dictionary<string, int>
		{
			{ "A", 0 },
			{ "B", 0 },
			{ "X", 0 },
			{ "Y", 0 },
			{ "Triangle", 0 },
			{ "Cross", 0 },
			{ "Square", 0 },
			{ "Circle", 0 },
			{ "D-Pad", 0 },
			{ "D-Pad Y", 0 },
			{ "D-Pad X", 0 },
			{ "D-Pad Left", 0 },
			{ "D-Pad Right", 0 },
			{ "D-Pad Up", 0 },
			{ "D-Pad Down", 0 },
			{ "LS", 59 },
			{ "LS Left", 0 },
			{ "LS Right", 0 },
			{ "LS Up", 0 },
			{ "LS Down", 0 },
			{ "LS Press", 0 },
			{ "RS", 59 },
			{ "RS Left", 0 },
			{ "RS Right", 0 },
			{ "RS Up", 0 },
			{ "RS Down", 0 },
			{ "RS Press", 0 },
			{ "RT", 0 },
			{ "RB", 0 },
			{ "LT", 0 },
			{ "LB", 0 },
			{ "R1", 0 },
			{ "R2", 0 },
			{ "L1", 0 },
			{ "L2", 0 },
			{ "L", 0 },
			{ "ZL", 0 },
			{ "R", 0 },
			{ "ZR", 0 },
			{ "Start", 59 },
			{ "Options", 59 },
			{ "Minus", 0 },
			{ "Plus", 0 },
			{ "View", 0 },
			{ "Share", 0 },
			{ "Select", 0 }
		};

		public static string GetRichTextAttributeForBinding(string bindingString, bool showSymbolForEmptyBinding = false, string fallbackBindingString = "", int firstBindingIndex = -1, int bindingDisplayCount = -1, InputDevice device = InputDevice.Undefined)
		{
			if (device == InputDevice.Undefined)
			{
				device = Singleton<InputManager>.Instance.CurrentInputDevice;
			}
			if (!spriteAssetByInputDevice.ContainsKey(device))
			{
				if (bindingString.Contains("Empty"))
				{
					return bindingString.Replace("Empty", showSymbolForEmptyBinding ? "<sprite=\"Gamepad_Buttons\" name=\"Empty\" tint=1> " : " ");
				}
				return "";
			}
			List<string> list = Enumerable.ToList(bindingString.Split('|'));
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = list[i].TrimStart().TrimEnd();
			}
			list = Enumerable.ToList(Enumerable.Where(list, (string x) => x != "|" && x != "/"));
			if (firstBindingIndex > -1 && bindingDisplayCount > 0)
			{
				list = list.GetRange(firstBindingIndex, bindingDisplayCount);
			}
			string[] array = fallbackBindingString.Split('|');
			string text = "";
			for (int num = 0; num < list.Count; num++)
			{
				string text2 = spriteAssetByInputDevice[device];
				if (num > 0 && list.Count > 1)
				{
					text += "/ ";
				}
				string text3 = list[num];
				if (bindingStringRerouting.ContainsKey(text3))
				{
					text3 = bindingStringRerouting[text3];
				}
				if (!spriteIndexByBindingString.ContainsKey(text3))
				{
					if (!(text3 != "Empty") || array.Length <= num || string.IsNullOrWhiteSpace(array[num]) || !spriteIndexByBindingString.ContainsKey(array[num]))
					{
						text += text3;
						continue;
					}
					text3 = fallbackBindingString;
				}
				text = text + "<sprite=\"" + text2 + "\" name=\"" + text3 + "\" tint=1> ";
			}
			return text.Replace("Empty", showSymbolForEmptyBinding ? "<sprite=\"Gamepad_Buttons\" name=\"Empty\" tint=1> " : "");
		}

		public static string GetBindingString(InputAction inputAction, InputBinding bindingMask, InputBinding.DisplayStringOptions options = (InputBinding.DisplayStringOptions)0)
		{
			string text = "";
			if (inputAction == null)
			{
				Debug.LogError("no inputAction given when trying to get binding string");
				return text;
			}
			for (int i = 0; i < inputAction.bindings.Count; i++)
			{
				if (bindingMask.Matches(inputAction.bindings[i]))
				{
					string bindingDisplayString = InputActionRebindingExtensions.GetBindingDisplayString(inputAction, i, options);
					if (string.IsNullOrWhiteSpace(bindingDisplayString))
					{
						Debug.Log("binding text is empty! name: " + inputAction.bindings[i].name + ", path: " + inputAction.bindings[i].path + ", display string: " + inputAction.bindings[i].ToDisplayString() + ", string: " + inputAction.bindings[i].ToString() + ", " + $"id: {inputAction.bindings[i].id}");
					}
					text = ((!(text != "")) ? bindingDisplayString : (text + " | " + bindingDisplayString));
					if ((bool)LocalizationManager.Instance && LocalizationManager.Instance.Language == Language.ChineseSimplified && bindingMask.groups.Contains("Mouse & Keyboard"))
					{
						text += " 键";
					}
				}
			}
			return text.Replace("/", " ");
		}
	}
}
