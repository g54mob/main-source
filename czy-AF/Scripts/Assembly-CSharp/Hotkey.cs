using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hotkey : MonoBehaviour
{
	public static Dictionary<string, Key> keys = new Dictionary<string, Key>();

	private void Awake()
	{
		keys.Add("File/Save", new Key(KeyCode.S, KeyCode.None, _modifierControl: true));
		keys.Add("File/Save As", new Key(KeyCode.S, KeyCode.None, _modifierControl: true, _modifierShift: true));
		keys.Add("File/Open", new Key(KeyCode.O, KeyCode.None, _modifierControl: true));
		keys.Add("Edit/Cut", new Key(KeyCode.X, KeyCode.None, _modifierControl: true));
		keys.Add("Edit/Copy", new Key(KeyCode.C, KeyCode.None, _modifierControl: true));
		keys.Add("Edit/Paste", new Key(KeyCode.V, KeyCode.None, _modifierControl: true));
		keys.Add("Edit/Clone", new Key(KeyCode.D, KeyCode.None, _modifierControl: true));
		keys.Add("Edit/Delete", new Key(KeyCode.Delete, KeyCode.Backspace));
		keys.Add("Edit/Undo", new Key(KeyCode.Z, KeyCode.None, _modifierControl: true));
		keys.Add("Edit/Redo", new Key(KeyCode.Y, KeyCode.None, _modifierControl: true));
		keys.Add("Edit/Group", new Key(KeyCode.G));
		keys.Add("Edit/Ungroup", new Key(KeyCode.G, KeyCode.None, _modifierControl: true));
		keys.Add("Edit/Hide", new Key(KeyCode.H));
		keys.Add("Edit/Unhide", new Key(KeyCode.H, KeyCode.None, _modifierControl: true));
		keys.Add("Edit/Lock", new Key(KeyCode.L));
		keys.Add("Edit/Unlock", new Key(KeyCode.L, KeyCode.None, _modifierControl: true));
		keys.Add("Edit/Vertex Snap", new Key(KeyCode.V));
		keys.Add("Edit/Greeble", new Key(KeyCode.G));
		keys.Add("Edit/Rotate", new Key(KeyCode.U, KeyCode.Space));
		keys.Add("Edit/Mirror", new Key(KeyCode.M));
		keys.Add("Edit/Cancel", new Key(KeyCode.Escape));
		keys.Add("Selection/Select all", new Key(KeyCode.A, KeyCode.None, _modifierControl: true));
		keys.Add("Selection/Select none", new Key(KeyCode.Escape));
		keys.Add("Selection/Focus", new Key(KeyCode.F));
		keys.Add("Script/Repeat", new Key(KeyCode.F5));
		keys.Add("Gizmo/Rotate", new Key(KeyCode.Q));
		keys.Add("Grid/Up", new Key(KeyCode.PageUp));
		keys.Add("Grid/Down", new Key(KeyCode.PageDown));
		keys.Add("Grid/Axis", new Key(KeyCode.I));
		keys.Add("Camera/Perspective", new Key(KeyCode.O));
		keys.Add("Camera/Zoom in", new Key(KeyCode.Plus, KeyCode.KeypadPlus));
		keys.Add("Camera/Zoom out", new Key(KeyCode.Minus, KeyCode.KeypadMinus));
		keys.Add("Camera/Forward", new Key(KeyCode.W, KeyCode.UpArrow));
		keys.Add("Camera/Left", new Key(KeyCode.A, KeyCode.LeftArrow));
		keys.Add("Camera/Back", new Key(KeyCode.S, KeyCode.DownArrow));
		keys.Add("Camera/Right", new Key(KeyCode.D, KeyCode.RightArrow));
		keys.Add("Camera/Rotate up", new Key(KeyCode.Keypad8));
		keys.Add("Camera/Rotate left", new Key(KeyCode.Keypad4));
		keys.Add("Camera/Rotate down", new Key(KeyCode.Keypad2));
		keys.Add("Camera/Rotate right", new Key(KeyCode.Keypad6));
		keys.Add("Camera/Up", new Key(KeyCode.RightBracket));
		keys.Add("Camera/Down", new Key(KeyCode.LeftBracket));
		keys.Add("Camera/Screenshot without UI", new Key(KeyCode.F11));
		keys.Add("Camera/Screenshot", new Key(KeyCode.F12));
		keys.Add("Modifier/Control", new Key(KeyCode.None, KeyCode.None, _modifierControl: true));
		keys.Add("Modifier/Shift", new Key(KeyCode.None, KeyCode.None, _modifierControl: false, _modifierShift: true));
		keys.Add("Modifier/Alt", new Key(KeyCode.None, KeyCode.None, _modifierControl: false, _modifierShift: false, _modifierAlt: true));
	}

	public static bool GetKey(string k, bool keyDown = false)
	{
		try
		{
			EventSystem.current.currentSelectedGameObject.GetComponent<InputField>();
			return false;
		}
		catch
		{
		}
		if (!keys.ContainsKey(k))
		{
			return false;
		}
		if (keys[k].key != KeyCode.None && keys[k].keyAlternative != KeyCode.None)
		{
			if (keyDown)
			{
				if (!Input.GetKeyDown(keys[k].key) && !Input.GetKeyDown(keys[k].keyAlternative))
				{
					return false;
				}
			}
			else if (!Input.GetKey(keys[k].key) && !Input.GetKey(keys[k].keyAlternative))
			{
				return false;
			}
		}
		if (keys[k].modifierControl)
		{
			bool num = !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl);
			bool flag = !Input.GetKey(KeyCode.LeftMeta) && !Input.GetKey(KeyCode.RightMeta);
			if (num && flag)
			{
				return false;
			}
		}
		if (keys[k].modifierShift && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
		{
			return false;
		}
		if (keys[k].modifierAlt && !Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt))
		{
			return false;
		}
		return true;
	}

	public static bool GetKeyDown(string key)
	{
		return GetKey(key, keyDown: true);
	}

	public static void ExportKeys()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Key> key in keys)
		{
			string text = "";
			if (key.Value.modifierControl)
			{
				text += "CTRL + ";
			}
			if (key.Value.modifierShift)
			{
				text += "SHIFT + ";
			}
			if (key.Value.modifierAlt)
			{
				text += "ALT + ";
			}
			text += key.Value.key;
			list.Add($"- `{key.Key}` **{text}**");
		}
		list.Sort();
		string text2 = "";
		foreach (string item in list)
		{
			text2 = text2 + item + "\n";
		}
		Debug.Log("Keys exported to file!");
		File.WriteAllText("hotkeys.txt", text2);
	}
}
