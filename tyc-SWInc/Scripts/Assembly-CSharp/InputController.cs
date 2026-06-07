using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class InputController
{
	public class KeyBinding
	{
		public string Name;

		public KeyCode MainBinding = KeyCode.Escape;

		public KeyCode AltBinding = KeyCode.Escape;

		public Modifiers MainModifier;

		public Modifiers AltModifier;

		public bool CanBeModifier;

		public KeyBinding(string name)
		{
			Name = name;
		}

		public KeyBinding(string name, KeyCode k1, Modifiers m1, KeyCode k2, Modifiers m2)
		{
			Name = name;
			MainBinding = k1;
			AltBinding = k2;
			MainModifier = m1;
			AltModifier = m2;
		}

		public KeyBinding(string name, KeyCode k1, KeyCode k2)
		{
			Name = name;
			MainBinding = k1;
			AltBinding = k2;
		}

		public KeyBinding(string name, KeyCode k1, Modifiers m1)
		{
			Name = name;
			MainBinding = k1;
			MainModifier = m1;
		}

		public KeyBinding(string name, KeyCode k1)
		{
			Name = name;
			MainBinding = k1;
		}

		public KeyBinding(KeyBinding other)
		{
			Name = other.Name;
			MainBinding = other.MainBinding;
			AltBinding = other.AltBinding;
			MainModifier = other.MainModifier;
			AltModifier = other.AltModifier;
		}

		public void Set(KeyBinding other)
		{
			MainBinding = other.MainBinding;
			AltBinding = other.AltBinding;
			MainModifier = other.MainModifier;
			AltModifier = other.AltModifier;
		}

		public void Set(KeyBinding other, bool alt, bool otherAlt)
		{
			if (alt)
			{
				AltBinding = (otherAlt ? other.AltBinding : other.MainBinding);
				AltModifier = (otherAlt ? other.AltModifier : other.MainModifier);
			}
			else
			{
				MainBinding = (otherAlt ? other.AltBinding : other.MainBinding);
				MainModifier = (otherAlt ? other.AltModifier : other.MainModifier);
			}
		}

		public void Set(KeyCode c, Modifiers m, bool alt)
		{
			if (alt)
			{
				AltBinding = c;
				AltModifier = m;
			}
			else
			{
				MainBinding = c;
				MainModifier = m;
			}
		}

		public bool Compare(KeyCode c, Modifiers m, bool alt)
		{
			if (alt)
			{
				if (AltBinding == c)
				{
					return AltModifier == m;
				}
				return false;
			}
			if (MainBinding == c)
			{
				return MainModifier == m;
			}
			return false;
		}

		public KeyCode GetKey(bool alt)
		{
			if (!alt)
			{
				return MainBinding;
			}
			return AltBinding;
		}

		public Modifiers GetModifier(bool alt)
		{
			if (!alt)
			{
				return MainModifier;
			}
			return AltModifier;
		}
	}

	[Flags]
	public enum Modifiers
	{
		NONE = 0,
		CTRL = 1,
		ALT = 2,
		SHIFT = 4,
		CMD = 8
	}

	public enum Keys
	{
		NormalSelection = 29,
		MultipleSelect = 30,
		SweepSelect = 32,
		RotateCamera = 28,
		DragCamera = 33,
		ContextMenu = 27,
		MoveUp = 2,
		MoveDown = 3,
		MoveLeft = 4,
		MoveRight = 5,
		TurnUp = 6,
		TurnDown = 7,
		TurnLeft = 8,
		TurnRight = 9,
		AlignNearest = 43,
		ZoomIn = 10,
		ZoomOut = 11,
		FloorUp = 12,
		FloorDown = 13,
		TopDown = 31,
		Pause = 14,
		Speed1 = 15,
		Speed2 = 16,
		Speed3 = 17,
		SkipDay = 18,
		SaveGame = 37,
		Undo = 42,
		Destroy = 22,
		ToggleBuildMode = 23,
		AnchorGrid = 35,
		ResetGrid = 36,
		ShiftGrid = 51,
		DisableGrid = 54,
		FurnitureClock = 25,
		FurnitureAntiClock = 26,
		FurnitureRandomRot = 46,
		FurnitureMove = 49,
		MirrorRoomHor = 38,
		MirrorRoomVert = 39,
		DuplicateFurniture = 47,
		AutoPlaceFurniture = 56,
		ShowFurnitureInfluence = 53,
		AutoCompleteRoom = 50,
		GlobalSearch = 55,
		CloseActiveWindow = 41,
		CloseAllWindows = 24,
		ToggleLights = 0,
		ToggleWalls = 1,
		ToggleAudioOverlay = 40,
		ToggleTeamLabels = 44,
		ToggleWireMode = 45,
		ToggleDataOverlay = 48,
		GotoEmp = 21,
		ToggleCamera = 19,
		HideHUD = 20,
		ReportScreen = 52,
		NewConsole = 34
	}

	private static List<KeyCode> _lockedKeys;

	private static KeyBinding[] OrgKeys;

	private static KeyBinding[] KeyBindings;

	public static bool InputEnabled;

	public static int KeyCount
	{
		get
		{
			return KeyBindings.Length;
		}
	}

	static InputController()
	{
		_lockedKeys = new List<KeyCode>();
		KeyBindings = new KeyBinding[57]
		{
			new KeyBinding("Toggle ceiling fixture", KeyCode.L),
			new KeyBinding("Toggle walls", KeyCode.T),
			new KeyBinding("Move camera forward", KeyCode.W),
			new KeyBinding("Move camera backward", KeyCode.S),
			new KeyBinding("Move camera left", KeyCode.A),
			new KeyBinding("Move camera right", KeyCode.D),
			new KeyBinding("Rotate camera up", KeyCode.UpArrow),
			new KeyBinding("Rotate camera down", KeyCode.DownArrow),
			new KeyBinding("Rotate camera left", KeyCode.LeftArrow),
			new KeyBinding("Rotate camera right", KeyCode.RightArrow),
			new KeyBinding("Zoom in", KeyCode.KeypadPlus),
			new KeyBinding("Zoom out", KeyCode.KeypadMinus),
			new KeyBinding("Move up one floor", KeyCode.E),
			new KeyBinding("Move down one floor", KeyCode.Q),
			new KeyBinding("Pause game", KeyCode.Keypad0, KeyCode.Alpha0),
			new KeyBinding("Normal game speed", KeyCode.Keypad1, KeyCode.Alpha1),
			new KeyBinding("Faster game speed", KeyCode.Keypad2, KeyCode.Alpha2),
			new KeyBinding("Fastest game speed", KeyCode.Keypad3, KeyCode.Alpha3),
			new KeyBinding("Skip day", KeyCode.Keypad5),
			new KeyBinding("Toggle camera mode", KeyCode.C),
			new KeyBinding("Hide HUD", KeyCode.H),
			new KeyBinding("Focus on object", KeyCode.Space),
			new KeyBinding("Destroy selected", KeyCode.Delete, KeyCode.Backspace),
			new KeyBinding("Toggle Build Mode", KeyCode.Tab),
			new KeyBinding("Close all windows", KeyCode.X, Modifiers.SHIFT),
			new KeyBinding("Turn furniture clockwise", KeyCode.Period),
			new KeyBinding("Turn furniture counter clockwise", KeyCode.Comma),
			new KeyBinding("Context menu", KeyCode.Mouse1),
			new KeyBinding("Rotate camera", KeyCode.Mouse2),
			new KeyBinding("Selection", KeyCode.Mouse0),
			new KeyBinding("Select multiple", KeyCode.Mouse0, Modifiers.SHIFT),
			new KeyBinding("Topdown view", KeyCode.Z),
			new KeyBinding("Sweep selection", KeyCode.Mouse0, Modifiers.CTRL),
			new KeyBinding("Drag camera", KeyCode.Mouse1),
			new KeyBinding("Open console"),
			new KeyBinding("Anchor grid", KeyCode.G),
			new KeyBinding("ResetGrid", KeyCode.G, Modifiers.CTRL),
			new KeyBinding("Save game", KeyCode.S, Modifiers.CTRL),
			new KeyBinding("Mirror room horizontally", KeyCode.Period, Modifiers.CTRL),
			new KeyBinding("Mirror room vertically", KeyCode.Comma, Modifiers.CTRL),
			new KeyBinding("Toggle audio overlay", KeyCode.U),
			new KeyBinding("Close active window", KeyCode.X),
			new KeyBinding("Undo", KeyCode.Z, Modifiers.CTRL),
			new KeyBinding("Align to nearest wall", KeyCode.F),
			new KeyBinding("RoomLabels", KeyCode.Y),
			new KeyBinding("WireMode", KeyCode.I),
			new KeyBinding("Rotate furniture randomly", KeyCode.R),
			new KeyBinding("Duplicate selected furniture", KeyCode.C, Modifiers.CTRL),
			new KeyBinding("Dataoverlay", KeyCode.O),
			new KeyBinding("ActionMove", KeyCode.M),
			new KeyBinding("AutoCompleteRoom", KeyCode.B),
			new KeyBinding("ShiftGrid", KeyCode.V),
			new KeyBinding("ScreenshotDev", KeyCode.P),
			new KeyBinding("ToggleFurnitureInfluence", KeyCode.K),
			new KeyBinding("DisableGrid", KeyCode.LeftAlt)
			{
				CanBeModifier = true
			},
			new KeyBinding("GlobalSearch", KeyCode.T, Modifiers.CTRL),
			new KeyBinding("AutoPlaceFurniture", KeyCode.J)
		};
		InputEnabled = true;
		OrgKeys = KeyBindings.SelectInPlace((KeyBinding x) => new KeyBinding(x));
	}

	public static void Reset()
	{
		for (int i = 0; i < KeyBindings.Length; i++)
		{
			KeyBindings[i].Set(OrgKeys[i]);
		}
	}

	public static string GetPrettyKeyName(KeyCode code)
	{
		switch (code)
		{
		case KeyCode.RightShift:
		case KeyCode.LeftShift:
			return "Shift";
		case KeyCode.RightAlt:
		case KeyCode.LeftAlt:
			return "Alt";
		case KeyCode.AltGr:
			return "AltGr";
		case KeyCode.RightControl:
		case KeyCode.LeftControl:
			return "Ctrl";
		case KeyCode.RightCommand:
		case KeyCode.LeftCommand:
			return "CMD";
		default:
		{
			int num = (int)code;
			if (num >= 48 && num <= 57)
			{
				return (num - 48).ToString();
			}
			string text = code.ToString();
			bool flag = false;
			if (text.StartsWith("Keypad"))
			{
				text = text.Substring(6);
				flag = true;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (char.IsUpper(c) && i > 0)
				{
					stringBuilder.Append(" " + char.ToLower(c));
				}
				else if (i > 0 && char.IsNumber(c) && !char.IsNumber(text[i - 1]))
				{
					stringBuilder.Append(" " + c);
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			string text2 = stringBuilder.ToString();
			if (text2 == "I")
			{
				text2 = "i";
			}
			if (text2.Length > 1)
			{
				text2 = ("KeyCode" + text).LocDef(text2);
			}
			if (flag)
			{
				text2 = Utilities.RobustStringFormat("KeyCodeKeypad".LocDef("Keypad {0}"), false, false, text2);
			}
			return text2;
		}
		}
	}

	public static void BindKey(Keys key, KeyCode keyCode, bool alter, bool GUI, bool ctrl, bool alt, bool shift, bool cmd)
	{
		BindKey(key, keyCode, alter, GUI, ModifierFromBool(ctrl, alt, shift, cmd));
	}

	public static bool CanBeModifier(Keys key)
	{
		return KeyBindings[(int)key].CanBeModifier;
	}

	public static void BindKey(Keys key, KeyCode keyCode, bool alter, bool GUI, Modifiers mod)
	{
		if (keyCode == KeyCode.Escape)
		{
			KeyBindings[(int)key].Set(keyCode, Modifiers.NONE, alter);
		}
		else
		{
			if ((!KeyBindings[(int)key].CanBeModifier && (keyCode == KeyCode.LeftControl || keyCode == KeyCode.RightControl || keyCode == KeyCode.LeftShift || keyCode == KeyCode.RightShift || keyCode == KeyCode.LeftAlt || keyCode == KeyCode.RightAlt || keyCode == KeyCode.LeftCommand || keyCode == KeyCode.RightCommand)) || KeyBindings[(int)key].Compare(keyCode, mod, alter))
			{
				return;
			}
			if (!AllowDoubleBind(key))
			{
				for (int i = 0; i < KeyBindings.Length; i++)
				{
					if (AllowDoubleBind((Keys)i))
					{
						continue;
					}
					if (KeyBindings[i].Compare(keyCode, mod, false))
					{
						if (GUI && i != (int)key)
						{
							DoRebind(i, false, (int)key, alter, keyCode, mod);
							return;
						}
						KeyBindings[i].Set(KeyBindings[(int)key], false, alter);
					}
					if (KeyBindings[i].Compare(keyCode, mod, true))
					{
						if (GUI && i != (int)key)
						{
							DoRebind(i, true, (int)key, alter, keyCode, mod);
							return;
						}
						KeyBindings[i].Set(KeyBindings[(int)key], true, alter);
					}
				}
			}
			KeyBindings[(int)key].Set(keyCode, mod, alter);
		}
	}

	public static Modifiers ModifierFromBool(bool ctrl, bool alt, bool shift, bool cmd)
	{
		Modifiers modifiers = Modifiers.NONE;
		if (ctrl)
		{
			modifiers |= Modifiers.CTRL;
		}
		if (alt)
		{
			modifiers |= Modifiers.ALT;
		}
		if (shift)
		{
			modifiers |= Modifiers.SHIFT;
		}
		if (cmd)
		{
			modifiers |= Modifiers.CMD;
		}
		return modifiers;
	}

	public static void DoRebind(int orgBind, bool orgAlt, int newBind, bool newAlt, KeyCode code, Modifiers mod)
	{
		DialogWindow diag = WindowManager.SpawnDialog();
		diag.Show(string.Format("KeyBindingWarning".Loc(), code.ToString(), GetLocKey(orgBind)), false, DialogWindow.DialogType.Warning, new KeyValuePair<string, Action>("Yes", delegate
		{
			KeyBindings[orgBind].Set(KeyBindings[newBind], orgAlt, newAlt);
			KeyBindings[newBind].Set(code, mod, newAlt);
			diag.Window.Close();
			Options.SaveToFile();
			foreach (InputButton inputButton in OptionsWindow.Instance.InputButtons)
			{
				inputButton.UpdateText();
			}
		}), new KeyValuePair<string, Action>("No", delegate
		{
			diag.Window.Close();
		}));
	}

	public static string GetLocKey(int key)
	{
		return KeyBindings[key].Name.Loc();
	}

	public static Keys GetKeyNum(string name)
	{
		return name.ToEnum(Keys.NewConsole);
	}

	public static string GetKeyBindString(Keys key, bool alt)
	{
		KeyCode binding = GetBinding(key, alt);
		if (binding != KeyCode.Escape)
		{
			return GetPrettyKeyName(binding);
		}
		return "None".Loc();
	}

	private static List<T> AddOrCreate<T>(List<T> l, T item)
	{
		if (l == null)
		{
			l = new List<T>();
		}
		l.Add(item);
		return l;
	}

	public static string GetFullKeyBindString(Keys key, bool alt, bool returnNull = false)
	{
		KeyCode key2 = KeyBindings[(int)key].GetKey(alt);
		if (key2 == KeyCode.Escape)
		{
			if (!returnNull)
			{
				return "None".Loc();
			}
			return null;
		}
		Modifiers modifier = KeyBindings[(int)key].GetModifier(alt);
		List<string> list = null;
		if ((modifier & Modifiers.CTRL) > Modifiers.NONE)
		{
			list = AddOrCreate(null, "Ctrl");
		}
		if ((modifier & Modifiers.SHIFT) > Modifiers.NONE)
		{
			list = AddOrCreate(list, "Shift");
		}
		if ((modifier & Modifiers.ALT) > Modifiers.NONE)
		{
			list = AddOrCreate(list, "Alt");
		}
		if ((modifier & Modifiers.CMD) > Modifiers.NONE)
		{
			list = AddOrCreate(list, "Cmd");
		}
		if (list == null)
		{
			return GetPrettyKeyName(key2);
		}
		list.Add(GetPrettyKeyName(key2));
		return string.Join("+", list.ToArray());
	}

	public static bool[] GetMods(Keys key, bool alt)
	{
		Modifiers modifier = KeyBindings[(int)key].GetModifier(alt);
		return new bool[4]
		{
			(modifier & Modifiers.CTRL) != 0,
			(modifier & Modifiers.ALT) != 0,
			(modifier & Modifiers.SHIFT) != 0,
			(modifier & Modifiers.CMD) != 0
		};
	}

	public static KeyCode GetBinding(Keys key, bool alt)
	{
		return KeyBindings[(int)key].GetKey(alt);
	}

	public static bool GetKeyDown(Keys key, bool force = false, bool ignoreModifers = false)
	{
		ignoreModifers |= CanBeModifier(key);
		bool ctrl = ignoreModifers || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
		bool alt = ignoreModifers || Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
		bool shift = ignoreModifers || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		bool cmd = ignoreModifers || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand);
		KeyCode binding = GetBinding(key, false);
		KeyCode binding2 = GetBinding(key, true);
		if (InputEnabled || force)
		{
			if (binding == KeyCode.Escape || !GetKey(binding, false, true) || (!ignoreModifers && !CheckModifier(key, false, ctrl, alt, shift, cmd)))
			{
				if (binding2 != KeyCode.Escape && GetKey(binding2, false, true))
				{
					if (!ignoreModifers)
					{
						return CheckModifier(key, true, ctrl, alt, shift, cmd);
					}
					return true;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool EventKey(Keys key, Event e, bool force = false)
	{
		bool ctrl = (e.modifiers & EventModifiers.Control) != 0;
		bool alt = (e.modifiers & EventModifiers.Alt) != 0;
		bool shift = (e.modifiers & EventModifiers.Shift) != 0;
		bool cmd = (e.modifiers & EventModifiers.Command) != 0;
		KeyCode binding = GetBinding(key, false);
		KeyCode binding2 = GetBinding(key, true);
		if (InputEnabled || force)
		{
			if (binding == KeyCode.Escape || binding != e.keyCode || !CheckModifier(key, false, ctrl, alt, shift, cmd))
			{
				if (binding2 != KeyCode.Escape && binding2 == e.keyCode)
				{
					return CheckModifier(key, true, ctrl, alt, shift, cmd);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool IsBound(Keys key)
	{
		KeyCode binding = GetBinding(key, false);
		KeyCode binding2 = GetBinding(key, true);
		if (binding == KeyCode.Escape)
		{
			return binding2 != KeyCode.Escape;
		}
		return true;
	}

	public static bool CheckModifier(Keys key, bool alter)
	{
		bool flag = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
		bool flag2 = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
		bool flag3 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		bool flag4 = Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand);
		Modifiers modifier = KeyBindings[(int)key].GetModifier(alter);
		if ((modifier & Modifiers.CTRL) != 0 == flag && (modifier & Modifiers.ALT) != 0 == flag2 && (modifier & Modifiers.SHIFT) != 0 == flag3)
		{
			return (modifier & Modifiers.CMD) != 0 == flag4;
		}
		return false;
	}

	private static bool CheckModifier(Keys key, bool alter, bool ctrl, bool alt, bool shift, bool cmd)
	{
		Modifiers modifier = KeyBindings[(int)key].GetModifier(alter);
		if ((modifier & Modifiers.CTRL) != 0 == ctrl && (modifier & Modifiers.ALT) != 0 == alt && (modifier & Modifiers.SHIFT) != 0 == shift)
		{
			return (modifier & Modifiers.CMD) != 0 == cmd;
		}
		return false;
	}

	public static bool GetKey(Keys key, bool ignoreModifers = false)
	{
		ignoreModifers |= CanBeModifier(key);
		bool ctrl = ignoreModifers || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
		bool alt = ignoreModifers || Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
		bool shift = ignoreModifers || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		bool cmd = ignoreModifers || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand);
		KeyCode binding = GetBinding(key, false);
		KeyCode binding2 = GetBinding(key, true);
		if (InputEnabled)
		{
			if (binding == KeyCode.Escape || !GetKey(binding, true, true) || (!ignoreModifers && !CheckModifier(key, false, ctrl, alt, shift, cmd)))
			{
				if (binding2 != KeyCode.Escape && GetKey(binding2, true, true))
				{
					if (!ignoreModifers)
					{
						return CheckModifier(key, true, ctrl, alt, shift, cmd);
					}
					return true;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool GetKeyUp(Keys key, bool ignoreModifers = false)
	{
		ignoreModifers |= CanBeModifier(key);
		bool ctrl = ignoreModifers || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
		bool alt = ignoreModifers || Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
		bool shift = ignoreModifers || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		bool cmd = ignoreModifers || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand);
		KeyCode binding = GetBinding(key, false);
		KeyCode binding2 = GetBinding(key, true);
		if (InputEnabled)
		{
			if (binding == KeyCode.Escape || !GetKey(binding, true, false) || (!ignoreModifers && !CheckModifier(key, false, ctrl, alt, shift, cmd)))
			{
				if (binding2 != KeyCode.Escape && GetKey(binding2, true, false))
				{
					if (!ignoreModifers)
					{
						return CheckModifier(key, true, ctrl, alt, shift, cmd);
					}
					return true;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static List<string> ToConfig(bool alt)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < KeyBindings.Length; i++)
		{
			KeyBinding keyBinding = KeyBindings[i];
			string[] array = new string[5];
			Keys keys = (Keys)i;
			array[0] = keys.ToString();
			array[1] = "=";
			array[2] = keyBinding.GetKey(alt).ToString();
			array[3] = ",";
			array[4] = ((int)keyBinding.GetModifier(alt)).ToString();
			list.Add(string.Concat(array));
		}
		return list;
	}

	public static bool AllowDoubleBind(Keys key)
	{
		return key == Keys.DragCamera;
	}

	private static bool CheckModifierKey(KeyCode key, bool up, bool down)
	{
		if (key >= KeyCode.RightShift && key <= KeyCode.LeftCommand)
		{
			KeyCode key2 = (((int)key % 2 != 0) ? (key + 1) : (key - 1));
			return GetKey(key2, up, down, false);
		}
		return false;
	}

	private static bool GetKey(KeyCode key, bool up, bool down, bool checkOtherModifier = true)
	{
		if (_lockedKeys.Count > 0 && _lockedKeys.Contains(key))
		{
			return false;
		}
		if (up && down)
		{
			if (!Input.GetKey(key))
			{
				if (checkOtherModifier)
				{
					return CheckModifierKey(key, up, down);
				}
				return false;
			}
			return true;
		}
		if (up)
		{
			if (!Input.GetKeyUp(key))
			{
				if (checkOtherModifier)
				{
					return CheckModifierKey(key, up, down);
				}
				return false;
			}
			return true;
		}
		if (!Input.GetKeyDown(key))
		{
			if (checkOtherModifier)
			{
				return CheckModifierKey(key, up, down);
			}
			return false;
		}
		return true;
	}

	public static void LoadConfig(List<string> config, List<string> altConfig)
	{
		if (config != null)
		{
			foreach (string item in config)
			{
				try
				{
					string[] array = item.Split('=');
					if (array[1].Contains(","))
					{
						string[] array2 = array[1].Split(',');
						Keys key = array[0].ToEnum<Keys>();
						KeyCode keyCode = array2[0].ToEnum<KeyCode>();
						int mod = Convert.ToInt32(array2[1]);
						BindKey(key, keyCode, false, false, (Modifiers)mod);
					}
					else
					{
						Keys key2 = array[0].ToEnum<Keys>();
						KeyCode keyCode2 = array[1].ToEnum<KeyCode>();
						BindKey(key2, keyCode2, false, false, Modifiers.NONE);
					}
				}
				catch (Exception)
				{
					Debug.Log("Couldn't bind key for " + item);
				}
			}
		}
		if (altConfig == null)
		{
			return;
		}
		foreach (string item2 in altConfig)
		{
			try
			{
				string[] array3 = item2.Split('=');
				if (array3[1].Contains(","))
				{
					string[] array4 = array3[1].Split(',');
					Keys key3 = array3[0].ToEnum<Keys>();
					KeyCode keyCode3 = array4[0].ToEnum<KeyCode>();
					int mod2 = Convert.ToInt32(array4[1]);
					BindKey(key3, keyCode3, true, false, (Modifiers)mod2);
				}
				else
				{
					Keys key4 = array3[0].ToEnum<Keys>();
					KeyCode keyCode4 = array3[1].ToEnum<KeyCode>();
					BindKey(key4, keyCode4, true, false, Modifiers.NONE);
				}
			}
			catch (Exception)
			{
				Debug.Log("Couldn't bind alt key for " + item2);
			}
		}
	}

	public static void UpdateKeyLocks()
	{
		for (int i = 0; i < _lockedKeys.Count; i++)
		{
			if (Input.GetKeyUp(_lockedKeys[i]))
			{
				_lockedKeys.RemoveAt(i);
				i--;
			}
		}
	}

	public static void LockKey(KeyCode key)
	{
		if (!_lockedKeys.Contains(key))
		{
			_lockedKeys.Add(key);
		}
	}

	public static Vector2 GetJoystickAxis(int id)
	{
		return Vector2.zero;
	}
}
