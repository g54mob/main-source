using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

[CreateAssetMenu(menuName = "Pug/UI/ControllerButtonToCharTable", order = 3)]
public class ControllerButtonToCharTable : ScriptableObject
{
	[Serializable]
	public class ControllerButtonAndChar
	{
		public string controllerButton;

		[SerializeField]
		private ControllerChar character;

		public string Character => character.value;
	}

	[Serializable]
	public class ControllerChar
	{
		public string value;
	}

	public List<ControllerButtonAndChar> controllerButtonToCharMouse;

	public List<ControllerButtonAndChar> controllerButtonToCharKeyboard;

	public List<ControllerButtonAndChar> controllerButtonToCharXbox;

	public List<ControllerButtonAndChar> controllerButtonToCharPS4;

	public List<ControllerButtonAndChar> controllerButtonToCharPS5;

	public List<ControllerButtonAndChar> controllerButtonToCharSwitch;

	private const string BUTTON = " Button";

	public string GetControllerButtonCharacter(ControllerType controllerType, string controllerName, string controllerButton, bool fallbackToControllerButton = true)
	{
		List<ControllerButtonAndChar> list = null;
		switch (controllerType)
		{
		case ControllerType.Keyboard:
			list = controllerButtonToCharKeyboard;
			break;
		case ControllerType.Mouse:
			list = controllerButtonToCharMouse;
			break;
		case ControllerType.Joystick:
			list = ((!controllerName.StartsWith(InputManager.SonyDualShockPrefix)) ? ((!controllerName.StartsWith(InputManager.SonyDualSensePrefix)) ? ((!controllerName.StartsWith(InputManager.NintendoPrefix)) ? ((!controllerName.StartsWith(InputManager.XboxPrefix)) ? controllerButtonToCharXbox : controllerButtonToCharXbox) : controllerButtonToCharSwitch) : controllerButtonToCharPS5) : controllerButtonToCharPS4);
			break;
		}
		ReadOnlySpan<char> span = StripButtonFromEnd(controllerButton);
		if (list != null)
		{
			foreach (ControllerButtonAndChar item in list)
			{
				if (span.Equals(StripButtonFromEnd(item.controllerButton), StringComparison.OrdinalIgnoreCase))
				{
					return item.Character;
				}
			}
		}
		if (!fallbackToControllerButton)
		{
			return null;
		}
		return controllerButton;
	}

	private static ReadOnlySpan<char> StripButtonFromEnd(string s)
	{
		if (!s.EndsWith(" Button", StringComparison.OrdinalIgnoreCase))
		{
			return s.AsSpan();
		}
		return s.AsSpan(0, s.Length - 7);
	}
}
