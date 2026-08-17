using System;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Internal;

namespace Doozy.Engine.UI.Input;

public class KeyToGameEvent : MonoBehaviour
{
	public bool DebugMode;

	public InputData InputData;

	public string GameEvent;

	public bool HasGameEvent
	{
		get
		{
			//IL_008f: Expected I4, but got O
			if (GameEvent != null)
			{
				string text = GameEvent.TrimWhiteSpaceHelper(string.TrimType.Both);
				if (text != null && text._stringLength > 0)
				{
					return true;
				}
				return false;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0063: Expected I4, but got O
			if (DebugMode)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugKeyToGameEvent;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private void Awake()
	{
		if (InputData == null)
		{
			base.enabled = false;
		}
	}

	private unsafe void Update()
	{
		//IL_041b: Expected O, but got I4
		//IL_0209: Expected I, but got O
		//IL_047a: Expected O, but got Ref
		//IL_013f: Expected I, but got O
		InputData inputData = InputData;
		if (inputData.InputMode == InputMode.None)
		{
			return;
		}
		string text;
		string text2;
		string text3;
		if (inputData.InputMode != InputMode.KeyCode)
		{
			if (inputData.InputMode != InputMode.VirtualButton)
			{
				return;
			}
			if (!UnityEngine.Internal.InputUnsafeUtility.GetButtonDown(inputData.VirtualButtonName))
			{
				InputData inputData2 = InputData;
				if (!inputData2.EnableAlternateInputs || !UnityEngine.Internal.InputUnsafeUtility.GetButtonDown(inputData2.VirtualButtonNameAlt) || !HasGameEvent)
				{
					return;
				}
				if (!DebugMode)
				{
					DoozySettings instance = DoozySettings.Instance;
					if (!instance.DebugKeyToGameEvent)
					{
						goto IL_03db;
					}
				}
				InputData inputData3 = InputData;
				text = inputData3.VirtualButtonNameAlt;
			}
			else
			{
				if (!HasGameEvent)
				{
					return;
				}
				if (!DebugMode)
				{
					DoozySettings instance2 = DoozySettings.Instance;
					if (!instance2.DebugKeyToGameEvent)
					{
						goto IL_03db;
					}
				}
				InputData inputData4 = InputData;
				text = inputData4.VirtualButtonName;
			}
			text2 = GameEvent;
			text3 = "' via Virtual Button: ";
		}
		else
		{
			object obj = UnityEngine.Input.GetKeyDownInt(inputData.KeyCode);
			string gameEvent;
			nint num;
			if (obj == null)
			{
				InputData inputData5 = InputData;
				if (!inputData5.EnableAlternateInputs || !UnityEngine.Input.GetKeyDownInt(inputData5.KeyCodeAlt) || !HasGameEvent)
				{
					return;
				}
				if (!DebugMode)
				{
					DoozySettings instance3 = DoozySettings.Instance;
					if (!instance3.DebugKeyToGameEvent)
					{
						goto IL_03db;
					}
				}
				gameEvent = GameEvent;
				num = (nint)typeof(KeyCode);
			}
			else
			{
				string text4 = GameEvent.TrimWhiteSpaceHelper(string.TrimType.Both);
				if (text4 == null || text4._stringLength <= 0)
				{
					return;
				}
				if (!DebugMode)
				{
					DoozySettings instance4 = DoozySettings.Instance;
					if (!instance4.DebugKeyToGameEvent)
					{
						goto IL_03db;
					}
				}
				gameEvent = GameEvent;
				num = (nint)typeof(KeyCode);
			}
			string text5 = ((Enum)(&num)).ToString();
			text = text5;
			text3 = "' via KeyCode: ";
			text2 = gameEvent;
		}
		string message = "Sent '" + text2 + text3 + text;
		GameObject context = base.gameObject;
		DDebug.Log(message, context);
		goto IL_03db;
		IL_03db:
		GameObject source = base.gameObject;
		GameEventMessage.SendEvent(GameEvent, source);
	}

	public void Execute()
	{
		GameObject source = base.gameObject;
		GameEventMessage.SendEvent(GameEvent, source);
	}

	private static KeyToGameEvent AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<KeyToGameEvent>("Key To Game Event", isSingleton: false, selectGameObjectAfterCreation);
	}

	public KeyToGameEvent()
	{
		InputData inputData = new InputData();
		InputData = inputData;
	}
}
