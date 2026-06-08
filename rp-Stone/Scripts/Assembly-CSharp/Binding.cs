using System;
using System.Collections.Generic;
using UnityEngine;

public class Binding
{
	public enum Action
	{
		None = 0,
		Pause = 1,
		Leave = 2,
		Inventory = 3,
		Mindstone = 4,
		Potion = 5,
		ItemLeft = 6,
		ItemRight = 7,
		Up = 8,
		Down = 9,
		Left = 10,
		Right = 11,
		Primary = 12,
		Back = 13,
		Ability1 = 14,
		Ability2 = 15,
		BumpL = 16,
		BumpR = 17,
		Dynamic1 = 18,
		Dynamic2 = 19,
		Dynamic3 = 20,
		Dynamic4 = 21,
		Dynamic5 = 22
	}

	public List<KeyCode> boundKeyCodes = new List<KeyCode>();

	private Dictionary<Action, List<KeyCode>> actionsToCodes = new Dictionary<Action, List<KeyCode>>();

	private Dictionary<KeyCode, Action> codesToActions = new Dictionary<KeyCode, Action>();

	private static Binding _singleton;

	public static Binding singleton
	{
		get
		{
			if (_singleton == null)
			{
				_singleton = new Binding();
			}
			return _singleton;
		}
	}

	private void SetDefaultBindings()
	{
		Set(Action.Pause, KeyCode.Space, KeyCode.P);
		Set(Action.Leave, KeyCode.L);
		Set(Action.Inventory, KeyCode.I);
		Set(Action.Mindstone, KeyCode.M);
		Set(Action.Potion, KeyCode.Q);
		Set(Action.ItemLeft, KeyCode.E);
		Set(Action.ItemRight, KeyCode.R);
		Set(Action.Up, KeyCode.W, KeyCode.UpArrow);
		Set(Action.Down, KeyCode.S, KeyCode.DownArrow);
		Set(Action.Left, KeyCode.A, KeyCode.LeftArrow);
		Set(Action.Right, KeyCode.D, KeyCode.RightArrow);
		Set(Action.Primary, KeyCode.Return, KeyCode.KeypadEnter);
		Set(Action.Back, KeyCode.X);
		Set(Action.Ability1, KeyCode.LeftShift, KeyCode.RightShift);
		Set(Action.Ability2, KeyCode.LeftControl, KeyCode.RightControl);
		Set(Action.BumpL, KeyCode.Z);
		Set(Action.BumpR, KeyCode.C);
		Set(Action.Dynamic1, KeyCode.F);
		Set(Action.Dynamic2, KeyCode.T);
		Set(Action.Dynamic3, KeyCode.G);
		Set(Action.Dynamic4, KeyCode.V);
		Set(Action.Dynamic5, KeyCode.B);
	}

	public void ResetToDefault()
	{
		boundKeyCodes.Clear();
		actionsToCodes.Clear();
		codesToActions.Clear();
		SetDefaultBindings();
	}

	public bool IsPressed(Action action)
	{
		if (action == Action.None)
		{
			return false;
		}
		return IsPressed(GetCodeForAction(action), GetCodeForAction(action, 1));
	}

	public bool IsDown(Action action)
	{
		if (action == Action.None)
		{
			return false;
		}
		return IsDown(GetCodeForAction(action), GetCodeForAction(action, 1));
	}

	public bool IsUp(Action action)
	{
		if (action == Action.None)
		{
			return false;
		}
		return IsUp(GetCodeForAction(action), GetCodeForAction(action, 1));
	}

	private bool IsPressed(KeyCode code1, KeyCode code2)
	{
		if (!Input.GetKey(code1))
		{
			return Input.GetKey(code2);
		}
		return true;
	}

	private bool IsDown(KeyCode code1, KeyCode code2)
	{
		if (!Input.GetKeyDown(code1))
		{
			return Input.GetKeyDown(code2);
		}
		return true;
	}

	private bool IsUp(KeyCode code1, KeyCode code2)
	{
		if (!Input.GetKeyUp(code1))
		{
			return Input.GetKeyUp(code2);
		}
		return true;
	}

	public void Set(Action action, KeyCode firstKeyCode, KeyCode secondKeyCode = KeyCode.None)
	{
		Remove(firstKeyCode);
		Remove(secondKeyCode);
		List<KeyCode> list;
		if (actionsToCodes.ContainsKey(action))
		{
			list = actionsToCodes[action];
			for (int i = 0; i < list.Count; i++)
			{
				KeyCode item = list[i];
				boundKeyCodes.Remove(item);
			}
			list.Clear();
		}
		else
		{
			list = new List<KeyCode>();
			actionsToCodes.Add(action, list);
		}
		list.Add(firstKeyCode);
		boundKeyCodes.Add(firstKeyCode);
		codesToActions[firstKeyCode] = action;
		if (secondKeyCode != KeyCode.None)
		{
			list.Add(secondKeyCode);
			boundKeyCodes.Add(secondKeyCode);
			codesToActions[secondKeyCode] = action;
		}
	}

	public void Set(string actionStr, string keyCodeStr)
	{
		Action action = (Action)Enum.Parse(typeof(Action), actionStr, ignoreCase: true);
		KeyCode firstKeyCode = (KeyCode)Enum.Parse(typeof(KeyCode), keyCodeStr, ignoreCase: true);
		Set(action, firstKeyCode);
	}

	public void Set(string actionStr, string firstKeyCodeStr, string secondKeyCodeStr)
	{
		Action action = (Action)Enum.Parse(typeof(Action), actionStr, ignoreCase: true);
		KeyCode firstKeyCode = (KeyCode)Enum.Parse(typeof(KeyCode), firstKeyCodeStr, ignoreCase: true);
		KeyCode secondKeyCode = (KeyCode)Enum.Parse(typeof(KeyCode), secondKeyCodeStr, ignoreCase: true);
		Set(action, firstKeyCode, secondKeyCode);
	}

	public KeyCode GetCodeForAction(Action action, int codeIndex = 0)
	{
		if (actionsToCodes.ContainsKey(action))
		{
			List<KeyCode> list = actionsToCodes[action];
			if (list.Count >= codeIndex + 1)
			{
				return list[codeIndex];
			}
		}
		return KeyCode.None;
	}

	public string GetFirstCodeForAction(string actionStr)
	{
		Action action = (Action)Enum.Parse(typeof(Action), actionStr, ignoreCase: true);
		return GetCodeForAction(action).ToString();
	}

	public string GetSecondCodeForAction(string actionStr)
	{
		Action action = (Action)Enum.Parse(typeof(Action), actionStr, ignoreCase: true);
		return GetCodeForAction(action, 1).ToString();
	}

	public Action GetActionForCode(KeyCode keyCode)
	{
		if (codesToActions.ContainsKey(keyCode))
		{
			return codesToActions[keyCode];
		}
		return Action.None;
	}

	public string GetActionForCode(string keyCodeStr)
	{
		KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), keyCodeStr, ignoreCase: true);
		return GetActionForCode(keyCode).ToString();
	}

	public void Remove(KeyCode keyCode)
	{
		if (!boundKeyCodes.Contains(keyCode))
		{
			return;
		}
		boundKeyCodes.Remove(keyCode);
		if (codesToActions.ContainsKey(keyCode))
		{
			Action key = codesToActions[keyCode];
			if (actionsToCodes.ContainsKey(key))
			{
				actionsToCodes[key].Remove(keyCode);
			}
		}
	}

	public void Remove(string keyCodeStr)
	{
		KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), keyCodeStr, ignoreCase: true);
		Remove(keyCode);
	}

	public void ClearOverrides()
	{
	}

	public string Serialize()
	{
		return null;
	}

	public void Parse(string sjson)
	{
	}

	private Binding()
	{
		SetDefaultBindings();
	}
}
