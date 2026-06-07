using System;
using System.Linq;
using UnityEngine;

public struct KeyCombination
{
	public KeyCode key;

	public bool alt;

	public bool ctrl;

	public bool shift;

	public KeyCombination(KeyCode key, bool alt, bool ctrl, bool shift)
	{
		this.key = key;
		this.alt = alt;
		this.ctrl = ctrl;
		this.shift = shift;
	}

	public override string ToString()
	{
		string text = (ctrl ? "Ctrl " : "");
		text = (alt ? (text + "Alt ") : text);
		text = (shift ? (text + "Shift ") : text);
		return (key != KeyCode.None) ? (text + key) : text;
	}

	public bool IsKeyPressed(bool pressedRightThisFrame)
	{
		if (pressedRightThisFrame)
		{
			if (!Input.GetKeyDown(key))
			{
				return false;
			}
		}
		else if (!Input.GetKey(key))
		{
			return false;
		}
		if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) != shift)
		{
			return false;
		}
		if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) != alt)
		{
			return false;
		}
		if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) != ctrl)
		{
			return false;
		}
		return true;
	}

	public static bool TryParse(string s, out KeyCombination k)
	{
		string[] array = s.Split(" ");
		if (Enum.TryParse<KeyCode>(array[^1], ignoreCase: true, out var result))
		{
			k = new KeyCombination(result, array.Contains("Alt"), array.Contains("Ctrl"), array.Contains("Shift"));
			return true;
		}
		k = new KeyCombination(KeyCode.None, alt: false, ctrl: false, shift: false);
		return false;
	}
}
