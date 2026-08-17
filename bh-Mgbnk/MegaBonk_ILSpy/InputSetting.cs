using System;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Cpp2ILInjected;
using UnityEngine;

public class InputSetting : BetterSetting
{
	public KeyDisplay[] keyDisplays;

	private int listenSlot;

	private new void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		base.Awake();
		Action<EControllerType> b = OnControllerChange;
		Delegate obj = Delegate.Combine(CurrentSettings.A_ControllerTypeChanged, b);
		if ((object)obj == null)
		{
			CurrentSettings.A_ControllerTypeChanged = (Action<EControllerType>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EControllerType> action = default(Action<EControllerType>);
		if (action != null)
		{
			CurrentSettings.A_ControllerTypeChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<EControllerType>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<EControllerType>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<EControllerType> action = OnControllerChange;
		Delegate obj = Delegate.Remove(CurrentSettings.A_ControllerTypeChanged, action);
		if ((object)obj == null)
		{
			CurrentSettings.A_ControllerTypeChanged = (Action<EControllerType>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EControllerType> action2 = default(Action<EControllerType>);
		if (action2 != null)
		{
			CurrentSettings.A_ControllerTypeChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<EControllerType>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<EControllerType>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnControllerChange(EControllerType controllerType)
	{
		ShowValue();
	}

	public override void ControllerInputDir(int dir, float multiplier)
	{
	}

	protected override void ShowValue()
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00a0: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj = default(object);
		if (obj != null)
		{
			object obj2 = null;
			object obj3 = null;
			while (true)
			{
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v4+18]");
				if ((nint)obj4 < 0)
				{
					KeyDisplay[] array = keyDisplays;
					if ((nint)obj2 < array.Length)
					{
						KeyDisplay keyDisplay = array[obj2];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v4+20+v52 @ rbx_v3 (System.Object)*4]");
						keyDisplay.SetKey(KeyCode.None);
						obj2++;
						object obj5 = 0;
						obj3 = obj2;
						continue;
					}
					break;
				}
				break;
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		throw new NullReferenceException();
	}

	public void StartListening(int slot)
	{
		listenSlot = slot;
	}

	public void SetKey(int keyCode)
	{
		//IL_0036: Expected I, but got O
		//IL_0075: Expected I, but got O
		//IL_00ac: Expected I, but got O
		//IL_00e8: Expected I, but got O
		if (_settingValue != null)
		{
			int num = listenSlot;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj = default(object);
			bool flag = obj == null;
			nint num2 = (nint)typeof(int[]);
			object settingValue = _settingValue;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj2 = default(object);
				bool flag2 = obj2 == null;
				num2 = (nint)typeof(int[]);
				if (!flag2)
				{
					int num3 = listenSlot;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v11+18]");
					bool flag3 = (nint)num3 >= (nint)0;
					nint num4 = (nint)typeof(int[]);
					if (!flag3)
					{
						Action<string, object, CFSettings> action = base.saveAction;
						bool flag4 = base.saveAction == null;
						num4 = (nint)typeof(int[]);
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v53 @ r10_v5 (System.Action`3<System.String, System.Object, Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+18] (should have been resolved before IL gen)");
							ShowValue();
							return;
						}
						goto IL_0107;
					}
					throw new IndexOutOfRangeException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				settingValue = _settingValue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			return;
		}
		goto IL_0107;
		IL_0107:
		throw new NullReferenceException();
	}
}
