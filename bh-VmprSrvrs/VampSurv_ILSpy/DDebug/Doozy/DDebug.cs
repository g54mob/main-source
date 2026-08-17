using System;
using System.Diagnostics;
using System.Reflection;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy;

public static class DDebug
{
	private const string TAG = "Doozy";

	private const string SPACE = " ";

	public static string CurrentClass
	{
		get
		{
			//IL_00d0: Expected I, but got O
			//IL_00e0: Expected O, but got I
			//IL_00f0: Expected O, but got I
			StackTrace stackTrace = new StackTrace();
			if (stackTrace != null)
			{
				int frameCount = stackTrace.FrameCount;
				int num = frameCount - 1;
				if (num < 2)
				{
					if (num < 0)
					{
						return "{NoClass}";
					}
				}
				else
				{
					num = 2;
				}
				StackFrame frame = stackTrace.GetFrame(num);
				if (frame != null)
				{
					MethodBase method = frame.GetMethod();
					if ((object)method != null)
					{
						Type declaringType = method.DeclaringType;
						if ((object)declaringType != null)
						{
							nint num2 = (nint)declaringType;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v11 (Il2CppClass<System.Type>)+1B8]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v11 (Il2CppClass<System.Type>)+1C0]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v151 @ r8_v7 (should have been resolved before IL gen)");
						}
					}
				}
			}
			return (string)(object)new NullReferenceException();
		}
	}

	private static string GetTypeNamePretty(Type type, bool addExtraSpace = true)
	{
		string[] array = new string[5];
		bool flag = !addExtraSpace;
		object obj = "";
		if (!flag)
		{
			obj = " ";
		}
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)type != null)
			{
				string name = type.Name;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				bool flag2 = !addExtraSpace;
				object obj2 = "";
				if (!flag2)
				{
					obj2 = " ";
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				return string.Concat(array);
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe static void Log(object message)
	{
		//IL_0062: Expected O, but got I4
		//IL_003d: Expected O, but got Ref
		object obj = Debug.isDebugBuild;
		if (obj != null)
		{
			string currentClass = CurrentClass;
			System.ParamsArray paramsArray = new System.ParamsArray("Doozy", currentClass, message);
			object obj2 = default(object);
			string message2 = string.FormatHelper((IFormatProvider)null, "{0} : {1} : {2}", (System.ParamsArray)(&obj2));
			Debug.Log(message2);
		}
	}

	public unsafe static void Log(object message, UnityEngine.Object context)
	{
		//IL_0066: Expected O, but got I4
		//IL_003d: Expected O, but got Ref
		object obj = Debug.isDebugBuild;
		if (obj != null)
		{
			string currentClass = CurrentClass;
			System.ParamsArray paramsArray = new System.ParamsArray("Doozy", currentClass, message);
			object obj2 = default(object);
			string message2 = string.FormatHelper((IFormatProvider)null, "{0} : {1} : {2}", (System.ParamsArray)(&obj2));
			Debug.Log(message2, context);
		}
	}

	public unsafe static void LogWarning(object message)
	{
		//IL_0042: Expected O, but got Ref
		string currentClass = CurrentClass;
		System.ParamsArray paramsArray = new System.ParamsArray("Doozy", currentClass, message);
		object obj = default(object);
		string message2 = string.FormatHelper((IFormatProvider)null, " {0} : {1} : {2}", (System.ParamsArray)(&obj));
		Debug.LogWarning(message2);
	}

	public unsafe static void LogWarning(object message, UnityEngine.Object context)
	{
		//IL_0046: Expected O, but got Ref
		string currentClass = CurrentClass;
		System.ParamsArray paramsArray = new System.ParamsArray("Doozy", currentClass, message);
		object obj = default(object);
		string message2 = string.FormatHelper((IFormatProvider)null, "{0} : {1} : {2}", (System.ParamsArray)(&obj));
		Debug.LogWarning(message2, context);
	}

	public unsafe static void LogError(object message)
	{
		//IL_0042: Expected O, but got Ref
		string currentClass = CurrentClass;
		System.ParamsArray paramsArray = new System.ParamsArray("Doozy", currentClass, message);
		object obj = default(object);
		string message2 = string.FormatHelper((IFormatProvider)null, "{0} : {1} : {2}", (System.ParamsArray)(&obj));
		Debug.LogError(message2);
	}

	public unsafe static void LogError(object message, UnityEngine.Object context)
	{
		//IL_0046: Expected O, but got Ref
		string currentClass = CurrentClass;
		System.ParamsArray paramsArray = new System.ParamsArray("Doozy", currentClass, message);
		object obj = default(object);
		string message2 = string.FormatHelper((IFormatProvider)null, "{0} : {1} : {2}", (System.ParamsArray)(&obj));
		Debug.LogError(message2, context);
	}
}
