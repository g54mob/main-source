using System;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("1Enwer/Input/_KeyBoard")]
public class _InputKeyBoard : MonoBehaviour
{
	public enum PressType
	{
		GetKey = 0,
		GetKeyDown = 1,
		GetKeyUp = 2
	}

	[Serializable]
	public class KeyCodeEvent
	{
		public KeyCode keyCode;

		public UnityEvent function;
	}

	public PressType pressType = PressType.GetKeyDown;

	public KeyCodeEvent[] keyBoardGetKey;

	private void Update()
	{
		for (int i = 0; i < keyBoardGetKey.Length; i++)
		{
			if (KeyBoardIsPressed(pressType, keyBoardGetKey[i].keyCode))
			{
				keyBoardGetKey[i].function.Invoke();
			}
		}
	}

	public bool KeyBoardIsPressed(PressType _pressType, KeyCode keycode)
	{
		return _pressType switch
		{
			PressType.GetKey => Input.GetKey(keycode), 
			PressType.GetKeyDown => Input.GetKeyDown(keycode), 
			PressType.GetKeyUp => Input.GetKeyUp(keycode), 
			_ => false, 
		};
	}
}
