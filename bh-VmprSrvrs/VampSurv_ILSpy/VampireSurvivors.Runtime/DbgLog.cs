using System;
using Cpp2ILInjected;
using UnityEngine;

public static class DbgLog
{
	public static void PL_User(string logMessage)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F167]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string message = "<color=\"green\">" + logMessage + "</color>";
		Debug.Log(message);
	}

	public static void PL_UserVerbose(string logMessage)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F168]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string message = "<color=\"blue\">" + logMessage + "</color>";
		Debug.Log(message);
	}

	public unsafe static void PL_UserData(string logMessage)
	{
		//IL_0057: Expected O, but got I4
		//IL_0081: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F169]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = Time.frameCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg, logMessage);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "[{0}] <color=\"magenta\">{1}</color>", (System.ParamsArray)(&obj2));
		Debug.Log(message);
	}

	public unsafe static void PL_UserDataVerbose(string logMessage)
	{
		//IL_0057: Expected O, but got I4
		//IL_0081: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F16A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = Time.frameCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg, logMessage);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "[{0}] <color=\"orange\">{1}</color>", (System.ParamsArray)(&obj2));
		Debug.Log(message);
	}

	public static void PL_UserDataOtherThread(string logMessage)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F16B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string message = "<color=\"orange\">" + logMessage + "</color>";
		Debug.Log(message);
	}

	private static void InternalLog(string logMsg)
	{
		Debug.Log(logMsg);
	}
}
