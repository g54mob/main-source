using System;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using UnityEngine;

namespace Doozy.Engine.UI.Connections;

[Serializable]
public class UIConnection
{
	public const float DEFAULT_TIME_DELAY = 3f;

	public string ButtonCategory;

	public string ButtonName;

	public string GameEvent;

	public float TimeDelay;

	public UIConnectionTrigger Trigger;

	private void Reset()
	{
		//IL_006a: Expected O, but got I
		//IL_007a: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998086B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Trigger = UIConnectionTrigger.ButtonClick;
		ButtonCategory = "General";
		ButtonName = "Unnamed";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v6+B8]");
		object gameEvent = 0;
		GameEvent = (string)gameEvent;
		TimeDelay = 3f;
	}

	public static UIConnection GetValue(Socket socket)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_00fc: Expected I, but got O
		//IL_004d: Expected I, but got O
		//IL_005d: Expected O, but got I
		//IL_0099: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		object obj3 = JsonUtility.FromJson(socket.m_value, type);
		nint num = (nint)typeof(UIConnection);
		bool flag = obj3 == null;
		UIConnection result = null;
		if (!flag)
		{
			nint num2 = (nint)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v4 (Il2CppClass<Doozy.Engine.UI.Connections.UIConnection>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r9_v3 (Il2CppClass<System.Object>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v4 (Il2CppClass<Doozy.Engine.UI.Connections.UIConnection>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r9_v3 (Il2CppClass<System.Object>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v11+FFFFFFF8+v103 @ rax_v10*8]");
				if (0 == (nint)typeof(UIConnection))
				{
					result = (UIConnection)obj3;
					goto IL_011e;
				}
			}
			return (UIConnection)(object)new InvalidCastException();
		}
		goto IL_011e;
		IL_011e:
		return result;
	}

	public static void SetValue(Socket socket, UIConnection value)
	{
		string value2 = JsonUtility.ToJson(value);
		socket.m_value = value2;
	}

	public UIConnection()
	{
		//IL_005f: Expected O, but got I
		//IL_006f: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998086D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ButtonCategory = "General";
		ButtonName = "Unnamed";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v6+B8]");
		object gameEvent = 0;
		GameEvent = (string)gameEvent;
		TimeDelay = 3f;
	}
}
