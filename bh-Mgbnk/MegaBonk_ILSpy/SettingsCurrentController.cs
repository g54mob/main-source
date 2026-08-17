using System;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using Rewired;
using TMPro;
using UnityEngine;

public class SettingsCurrentController : MonoBehaviour
{
	public TextMeshProUGUI t_controller;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Controller> b = OnControllerChange;
		Delegate obj = Delegate.Combine(MyInputManager.A_SetCurrentController, b);
		if ((object)obj == null)
		{
			MyInputManager.A_SetCurrentController = (Action<Controller>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Controller> action = default(Action<Controller>);
		if (action != null)
		{
			MyInputManager.A_SetCurrentController = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Controller>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Controller>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Controller> value = OnControllerChange;
		Delegate obj = Delegate.Remove(MyInputManager.A_SetCurrentController, value);
		if ((object)obj == null)
		{
			MyInputManager.A_SetCurrentController = (Action<Controller>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Controller> action = default(Action<Controller>);
		if (action != null)
		{
			MyInputManager.A_SetCurrentController = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Controller>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Controller>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnControllerChange(Controller c)
	{
		Refresh();
	}

	private void OnEnable()
	{
		Refresh();
	}

	private void Refresh()
	{
		string text = ((MyInputManager._003CcurrentController_003Ek__BackingField == null) ? LocalizationUtility.GetLocalizedString("MainMenuOther", "NONE") : MyInputManager._003CcurrentController_003Ek__BackingField.name);
		t_controller.text = text;
	}
}
