using System;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Connections;
using Doozy.Engine.Nody.Models;
using UnityEngine;

namespace Doozy.Engine.UI.Connections;

[Serializable]
public class WeightedConnection : PassthroughConnection
{
	private const int DEFAULT_WEIGHT = 100;

	public int Weight = 100;

	public static WeightedConnection GetValue(Socket socket)
	{
		//IL_003b: Expected I, but got O
		//IL_0068: Expected I, but got O
		//IL_0078: Expected O, but got I
		//IL_00b4: Expected O, but got I
		WeightedConnection weightedConnection;
		if (socket != null)
		{
			Type valueType = socket.ValueType;
			weightedConnection = (WeightedConnection)JsonUtility.FromJson(socket.m_value, valueType);
			nint num = (nint)typeof(WeightedConnection);
			if (weightedConnection == null)
			{
				goto IL_005b;
			}
			nint num2 = (nint)weightedConnection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v3 (Il2CppClass<Doozy.Engine.UI.Connections.WeightedConnection>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v2 (Il2CppClass<Doozy.Engine.UI.Connections.WeightedConnection>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v3 (Il2CppClass<Doozy.Engine.UI.Connections.WeightedConnection>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v2 (Il2CppClass<Doozy.Engine.UI.Connections.WeightedConnection>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7+FFFFFFF8+v74 @ rcx_v6*8]");
				if (0 == (nint)typeof(WeightedConnection))
				{
					goto IL_005b;
				}
			}
		}
		else
		{
			NullReferenceException ex = new NullReferenceException();
		}
		return (WeightedConnection)(object)new InvalidCastException();
		IL_005b:
		return weightedConnection;
	}

	public static void SetValue(Socket socket, WeightedConnection value)
	{
		string value2 = JsonUtility.ToJson(value);
		socket.m_value = value2;
	}
}
