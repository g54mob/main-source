using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using Doozy.Engine.Soundy;
using Doozy.Engine.UI.Base;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Internal;

namespace Doozy.Engine.UI.Input;

public class KeyToAction : MonoBehaviour
{
	public UIAction Actions;

	public bool DebugMode;

	public InputData InputData;

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
				return instance.DebugKeyToAction;
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
		//IL_05bb: Expected O, but got I4
		//IL_01b0: Expected I, but got O
		//IL_0611: Expected O, but got Ref
		//IL_012c: Expected I, but got O
		//IL_0459: Expected O, but got I4
		//IL_048c: Expected O, but got I4
		//IL_04b1: Expected O, but got I4
		InputData inputData = InputData;
		if (inputData.InputMode == InputMode.None)
		{
			return;
		}
		string text;
		string text2;
		if (inputData.InputMode != InputMode.KeyCode)
		{
			if (inputData.InputMode != InputMode.VirtualButton)
			{
				return;
			}
			if (!UnityEngine.Internal.InputUnsafeUtility.GetButtonDown(inputData.VirtualButtonName))
			{
				InputData inputData2 = InputData;
				if (!inputData2.EnableAlternateInputs || !UnityEngine.Internal.InputUnsafeUtility.GetButtonDown(inputData2.VirtualButtonNameAlt) || Actions == null)
				{
					return;
				}
				if (!DebugMode)
				{
					DoozySettings instance = DoozySettings.Instance;
					if (!instance.DebugKeyToAction)
					{
						goto IL_037a;
					}
				}
				InputData inputData3 = InputData;
				text = inputData3.VirtualButtonNameAlt;
			}
			else
			{
				if (Actions == null)
				{
					return;
				}
				if (!DebugMode)
				{
					DoozySettings instance2 = DoozySettings.Instance;
					if (!instance2.DebugKeyToAction)
					{
						goto IL_037a;
					}
				}
				InputData inputData4 = InputData;
				text = inputData4.VirtualButtonName;
			}
			text2 = "Executed UIAction via Virtual Button: ";
		}
		else
		{
			object obj = UnityEngine.Input.GetKeyDownInt(inputData.KeyCode);
			nint num;
			if (obj == null)
			{
				InputData inputData5 = InputData;
				if (!inputData5.EnableAlternateInputs || !UnityEngine.Input.GetKeyDownInt(inputData5.KeyCodeAlt) || Actions == null)
				{
					return;
				}
				if (!DebugMode)
				{
					DoozySettings instance3 = DoozySettings.Instance;
					if (!instance3.DebugKeyToAction)
					{
						goto IL_037a;
					}
				}
				num = (nint)typeof(KeyCode);
			}
			else
			{
				if (Actions == null)
				{
					return;
				}
				if (!DebugMode)
				{
					DoozySettings instance4 = DoozySettings.Instance;
					if (!instance4.DebugKeyToAction)
					{
						goto IL_037a;
					}
				}
				num = (nint)typeof(KeyCode);
			}
			string text3 = ((Enum)(&num)).ToString();
			text = text3;
			text2 = "Executed UIAction via KeyCode: ";
		}
		string message = text2 + text;
		GameObject context = base.gameObject;
		DDebug.Log(message, context);
		goto IL_037a;
		IL_037a:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980865]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (Actions != null)
		{
			UIAction actions = Actions;
			GameObject source = base.gameObject;
			if (Actions.HasSound)
			{
				SoundyController soundyController = SoundyManager.Play(actions.SoundData);
			}
			Canvas canvas = Actions.GetCanvas(source);
			Actions.ExecuteEffect(canvas);
			Actions.InvokeAnimatorEvents();
			bool flag = actions.GameEvents == null;
			object obj2 = 0;
			if (!flag)
			{
				List<string> gameEvents = actions.GameEvents;
				bool flag2 = gameEvents._size <= 0;
				obj2 = 0;
				if (!flag2)
				{
					GameEventMessage.SendEvents(gameEvents, source);
					obj2 = 0;
				}
			}
			if (actions.Event != null)
			{
				actions.Event.Invoke();
			}
			if (actions.Action != null)
			{
				Action<GameObject> action = actions.Action;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v908 @ rax_v27 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			return;
		}
		if (!DebugMode)
		{
			DoozySettings instance5 = DoozySettings.Instance;
			if (!instance5.DebugKeyToAction)
			{
				return;
			}
		}
		GameObject context2 = base.gameObject;
		DDebug.Log("UIAction is null!", context2);
	}

	public void Execute()
	{
		//IL_00df: Expected O, but got I4
		//IL_0112: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980865]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (Actions != null)
		{
			UIAction actions = Actions;
			GameObject source = base.gameObject;
			if (Actions.HasSound)
			{
				SoundyController soundyController = SoundyManager.Play(actions.SoundData);
			}
			Canvas canvas = Actions.GetCanvas(source);
			Actions.ExecuteEffect(canvas);
			Actions.InvokeAnimatorEvents();
			bool flag = actions.GameEvents == null;
			object obj = 0;
			if (!flag)
			{
				List<string> gameEvents = actions.GameEvents;
				bool flag2 = gameEvents._size <= 0;
				obj = 0;
				if (!flag2)
				{
					GameEventMessage.SendEvents(gameEvents, source);
					obj = 0;
				}
			}
			if (actions.Event != null)
			{
				actions.Event.Invoke();
			}
			if (actions.Action != null)
			{
				Action<GameObject> action = actions.Action;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v304 @ rax_v17 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			return;
		}
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugKeyToAction)
			{
				return;
			}
		}
		GameObject context = base.gameObject;
		DDebug.Log("UIAction is null!", context);
	}

	private static KeyToAction AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<KeyToAction>("Key To Action", isSingleton: false, selectGameObjectAfterCreation);
	}

	public KeyToAction()
	{
		UIAction actions = new UIAction();
		Actions = actions;
		InputData inputData = new InputData();
		InputData = inputData;
	}
}
