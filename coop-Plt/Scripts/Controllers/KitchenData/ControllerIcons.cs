using System;
using System.Collections.Generic;
using Platforms;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using WebSocketSharp;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Controller Icons", menuName = "Kitchen/Controller Icons")]
	public class ControllerIcons : SerializedScriptableObject
	{
		public ControllerIcon Default;

		public ControllerPathMap DefaultPathMap;

		public Dictionary<ControllerButton, ControllerIcon> Icons;

		public Dictionary<ControllerType, Dictionary<string, ControllerIcon>> IconsByController;

		public Dictionary<ControllerType, List<ControllerPathMap>> PathMapsByController;

		private Dictionary<string, string> FixedRemappings = new Dictionary<string, string>
		{
			{ "escape", "Esc" },
			{ "backquote", "GraveAccent" },
			{ "quote", "SingleQuotation" },
			{ "period", "Punctuation" },
			{ "leftBracket", "Parenthesis-Left" },
			{ "rightBracket", "Parenthesis-Right" },
			{ "upArrow", "ArrowUp" },
			{ "downArrow", "ArrowDown" },
			{ "rightArrow", "ArrowRight" },
			{ "leftArrow", "ArrowLeft" },
			{ "leftShift", "Shift" },
			{ "rightShift", "Shift" },
			{ "leftAlt", "Alt" },
			{ "rightAlt", "Alt" },
			{ "leftCtrl", "Ctrl" },
			{ "rightCtrl", "Ctrl" },
			{ "Divide", "Slash" },
			{ "Multiply", "Asterisk" },
			{ "Period", "Punctuation" }
		};

		private Dictionary<string, (string, string)> MouseMappings = new Dictionary<string, (string, string)>
		{
			{
				"leftButton",
				("LMB", "LeftClick")
			},
			{
				"rightButton",
				("RMB", "RightClick")
			},
			{
				"middleButton",
				("MMB", "MiddleClick")
			}
		};

		private string AttemptFuzzyMatch(InputControlLayout.ControlItem control, Func<string, bool> match_function)
		{
			if (FixedRemappings.TryGetValue(control.name, out var value))
			{
				return value;
			}
			if (match_function(control.name))
			{
				return control.name;
			}
			string text = control.name.ToString();
			string text2 = text[0].ToString().ToUpper() + text.Substring(1);
			if (match_function(text2))
			{
				return text2;
			}
			if (!control.displayName.IsNullOrEmpty() && match_function(control.displayName))
			{
				return control.displayName;
			}
			if (text.StartsWith("numpad"))
			{
				string text3 = text.Substring("numpad".Length);
				if (match_function(text3))
				{
					return text3;
				}
				if (FixedRemappings.TryGetValue(text3, out var value2))
				{
					return value2;
				}
			}
			return "";
		}

		public void RemoveInvalidControllerMappings()
		{
			if (Application.isEditor)
			{
				return;
			}
			List<ControllerType> list = new List<ControllerType>();
			switch (Application.platform)
			{
			case RuntimePlatform.PS4:
			case RuntimePlatform.PS5:
				list.Add(ControllerType.Playstation);
				break;
			case RuntimePlatform.Switch:
				list.Add(ControllerType.SwitchJoyConL);
				list.Add(ControllerType.SwitchJoyConR);
				list.Add(ControllerType.SwitchFull);
				break;
			case RuntimePlatform.GameCoreXboxSeries:
			case RuntimePlatform.GameCoreXboxOne:
				list.Add(ControllerType.Xbox);
				break;
			default:
				return;
			}
			List<ControllerType> list2 = new List<ControllerType>();
			foreach (KeyValuePair<ControllerType, Dictionary<string, ControllerIcon>> item in IconsByController)
			{
				if (!list.Contains(item.Key))
				{
					list2.Add(item.Key);
				}
			}
			foreach (KeyValuePair<ControllerType, List<ControllerPathMap>> item2 in PathMapsByController)
			{
				if (!list.Contains(item2.Key) && !list2.Contains(item2.Key))
				{
					list2.Add(item2.Key);
				}
			}
			foreach (ControllerType item3 in list2)
			{
				if (IconsByController.ContainsKey(item3))
				{
					IconsByController.Remove(item3);
				}
				if (PathMapsByController.ContainsKey(item3))
				{
					PathMapsByController.Remove(item3);
				}
			}
			GC.Collect();
		}

		public string GetTMPIcon(ControllerType controller, string path)
		{
			ControllerPathMap mapByControl = GetMapByControl(controller, path);
			if (MouseMappings.ContainsKey(mapByControl.Control))
			{
				return "<sprite=\"Mouse-Filled\" name=\"" + mapByControl.Button + "\">";
			}
			switch (controller)
			{
			case ControllerType.Playstation:
				return "<sprite=\"DualSense-Filled\" name=\"" + mapByControl.Button + "\">";
			case ControllerType.Keyboard:
				return "<sprite=\"Keyboard-Filled\" name=\"" + mapByControl.Button + "\">";
			case ControllerType.SwitchJoyConL:
			case ControllerType.SwitchJoyConR:
			case ControllerType.SwitchFull:
				return "<sprite=\"Joy-Con-Filled\" name=\"" + mapByControl.Button + "\">";
			default:
				return "<sprite=\"Xbox-Filled\" name=\"" + mapByControl.Button + "\">";
			}
		}

		private bool HasIcon(ControllerType type, string name)
		{
			if (IconsByController.TryGetValue(type, out var value) && value.TryGetValue(name, out var _))
			{
				return true;
			}
			return false;
		}

		private bool HasSprite(TMP_SpriteAsset sprites, string name)
		{
			foreach (TMP_SpriteCharacter item in sprites.spriteCharacterTable)
			{
				if (item.name == name)
				{
					return true;
				}
			}
			return false;
		}

		public ControllerIcon GetIconByName(ControllerType type, string name)
		{
			if (IconsByController.TryGetValue(type, out var value) && value.TryGetValue(name, out var value2))
			{
				return value2;
			}
			return Default;
		}

		public ControllerPathMap GetMapByControl(ControllerType type, string control)
		{
			string text = control.ToLower();
			if (PathMapsByController.TryGetValue(type, out var value))
			{
				foreach (ControllerPathMap item in value)
				{
					if (item.Control == control || item.Control == text)
					{
						return item;
					}
				}
			}
			return DefaultPathMap;
		}

		public ControllerIcon GetIconByControl(ControllerType type, string control)
		{
			return GetIconByName(type, GetMapByControl(type, control).Button);
		}
	}
}
