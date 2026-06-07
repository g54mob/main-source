using UnityEngine;

namespace Motorways.Views
{
	public readonly struct HotkeyDescription
	{
		public readonly KeyCode keyCode;

		public readonly KeyCode modifierKeyCode;

		public readonly string description;

		public string KeyCodeDisplayName => GetHotkeyCharacter(modifierKeyCode) + GetHotkeyCharacter(keyCode);

		public HotkeyDescription(KeyCode keyCode, KeyCode modifierKeyCode, string description)
		{
			this.keyCode = keyCode;
			this.modifierKeyCode = modifierKeyCode;
			this.description = description;
		}

		public HotkeyDescription(KeyCode keyCode, string description)
		{
			this.keyCode = keyCode;
			modifierKeyCode = KeyCode.None;
			this.description = description;
		}

		public static string GetHotkeyCharacter(KeyCode keyCode)
		{
			switch (keyCode)
			{
			case KeyCode.None:
				return "";
			case KeyCode.Period:
				return ".";
			case KeyCode.Equals:
				return "=";
			case KeyCode.Escape:
				return "Esc";
			case KeyCode.Backslash:
				return "\\";
			case KeyCode.Comma:
				return ",";
			case KeyCode.Quote:
				return "'";
			case KeyCode.Slash:
				return "/";
			case KeyCode.Semicolon:
				return ";";
			case KeyCode.RightShift:
			case KeyCode.LeftShift:
				return "⇧";
			case KeyCode.RightControl:
			case KeyCode.LeftControl:
				return "^";
			default:
				return keyCode.ToString();
			}
		}
	}
}
