using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class VersionNumber : MonoBehaviour
{
	public TextMeshProUGUI t_version;

	private void Start()
	{
		//IL_01de: Expected I, but got O
		//IL_01e7: Expected O, but got I
		Action b = Refresh;
		Delegate obj = Delegate.Combine(SteamManager.A_Initialized, b);
		Delegate obj2;
		Delegate obj3;
		NullReferenceException typeFromHandle;
		Delegate obj5;
		if ((object)obj == null)
		{
			SteamManager.A_Initialized = null;
			obj2 = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj3 = obj;
				goto IL_0189;
			}
			SteamManager.A_Initialized = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj4 = null;
			if (!flag2)
			{
				obj4 = obj;
			}
			bool flag3 = (object)obj4 == null;
			obj5 = obj2;
			obj3 = obj;
			typeFromHandle = (NullReferenceException)(object)typeof(Action);
			if (flag3)
			{
				goto IL_01c8;
			}
		}
		string version = Application.version;
		string text = "version " + version;
		bool flag4 = (object)t_version == null;
		obj3 = null;
		if (!flag4)
		{
			t_version.text = text;
			return;
		}
		goto IL_0189;
		IL_01c8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		nint num = (nint)obj3;
		((IDisposable)num).Dispose();
		return;
		IL_0189:
		typeFromHandle = new NullReferenceException();
		obj5 = obj2;
		goto IL_01c8;
	}

	private void OnDestroy()
	{
		//IL_0101: Expected I, but got O
		Action value = Refresh;
		Delegate obj = Delegate.Remove(SteamManager.A_Initialized, value);
		if ((object)obj == null)
		{
			SteamManager.A_Initialized = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			SteamManager.A_Initialized = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Refresh()
	{
		string version = Application.version;
		string text = "version " + version;
		t_version.text = text;
	}
}
