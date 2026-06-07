using System.Collections.Generic;
using UnityEngine;

public class KeyboardChipModule : Module, IInputChip
{
	public enum Commands
	{

	}

	public class Keyboard_EventData : EventData
	{
		public bool ButtonDown;

		public bool ButtonUp;

		public InputName InputName;

		public Keyboard_EventData()
		{
		}

		public Keyboard_EventData(bool buttonDown, bool buttonUp, InputName inputName)
		{
		}
	}

	private static Dictionary<string, KeyCode> inputBindingsDictionary;

	private static Dictionary<KeyCode, string> keyCodes;

	private HashSet<KeyCode> buttonDowns;

	public static ICollection<string> inputBindings => null;

	private static string GetInputNameFromKeyCode(KeyCode keyCode)
	{
		return null;
	}

	public ICollection<string> GetInputBindings()
	{
		return null;
	}

	public InputBinding.Type GetInputBindingType(string name)
	{
		return default(InputBinding.Type);
	}

	public bool IsInputBindingValid(string name)
	{
		return false;
	}

	public float GetAxis(InputBinding inputBinding)
	{
		return 0f;
	}

	public bool GetButtonState(InputBinding inputBinding)
	{
		return false;
	}

	public bool GetButtonDown(InputBinding inputBinding)
	{
		return false;
	}

	public bool GetButtonUp(InputBinding inputBinding)
	{
		return false;
	}

	private void OnGUI()
	{
	}

	public override void OnTurnOn()
	{
	}

	public override void OnTurnOff()
	{
	}

	public InputSource Script_GetButtonInputSource(InputName name)
	{
		return default(InputSource);
	}

	public InputSource Script_GetButtonAxisInputSource(InputName negativeName, InputName positiveName)
	{
		return default(InputSource);
	}
}
