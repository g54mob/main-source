using System;
using Cpp2ILInjected;
using UnityEngine;

public static class Utils
{
	public static bool IndexIsValid(int index)
	{
		int num = index >> 31;
		return (byte)(num ^ 1) != 0;
	}

	public static bool IsPowerOf2(int iValueToCheck)
	{
		//IL_000e: Expected O, but got I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected I4, but got Unknown
		object obj = iValueToCheck - 1;
		int num = iValueToCheck & obj;
		return num == 0;
	}

	public unsafe static int RoundNumberUpToPowerOf2Boundary(int iNumberToRound, int iPowerOf2ToRoundUpTo)
	{
		//IL_008b: Expected O, but got I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected I4, but got Unknown
		//IL_00b2: Expected O, but got I4
		//IL_0066: Expected O, but got Ref
		//IL_0013: Expected O, but got I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected I4, but got Unknown
		object obj = iPowerOf2ToRoundUpTo - 1;
		int num = iPowerOf2ToRoundUpTo & obj;
		bool flag = num == 0;
		object obj2 = !flag;
		if (obj2 == null)
		{
			object obj3 = iPowerOf2ToRoundUpTo - 1;
			int num2 = -iPowerOf2ToRoundUpTo;
			object obj4 = obj3 + iNumberToRound;
			return obj4 & num2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj5 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "value passed as iPowerOf2ToRoundUpTo [{0}] is NOT a power of 2", (System.ParamsArray)(&obj5));
		Debug.LogError(message);
		return iNumberToRound;
	}

	public static bool IsPowerOf2(uint iValueToCheck)
	{
		//IL_000e: Expected O, but got I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected I4, but got Unknown
		object obj = iValueToCheck - 1;
		int num = (int)(iValueToCheck & obj);
		return num == 0;
	}

	public unsafe static uint RoundNumberUpToPowerOf2Boundary(uint iNumberToRound, uint iPowerOf2ToRoundUpTo)
	{
		//IL_008b: Expected O, but got I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected I4, but got Unknown
		//IL_00b2: Expected O, but got I4
		//IL_0066: Expected O, but got Ref
		//IL_0013: Expected O, but got I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected I4, but got Unknown
		object obj = iPowerOf2ToRoundUpTo - 1;
		int num = (int)(iPowerOf2ToRoundUpTo & obj);
		bool flag = num == 0;
		object obj2 = !flag;
		if (obj2 == null)
		{
			object obj3 = iPowerOf2ToRoundUpTo - 1;
			int num2 = (int)(0 - iPowerOf2ToRoundUpTo);
			object obj4 = obj3 + iNumberToRound;
			return (uint)(obj4 & num2);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj5 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "value passed as iPowerOf2ToRoundUpTo [{0}] is NOT a power of 2", (System.ParamsArray)(&obj5));
		Debug.LogError(message);
		return iNumberToRound;
	}

	public static bool IsPowerOf2(ulong iValueToCheck)
	{
		//IL_000e: Expected O, but got I8
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected I8, but got Unknown
		object obj = iValueToCheck - 1;
		long num = (long)(iValueToCheck & obj);
		return num == 0;
	}

	public unsafe static ulong RoundNumberUpToPowerOf2Boundary(ulong iNumberToRound, ulong iPowerOf2ToRoundUpTo)
	{
		//IL_008b: Expected O, but got I8
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected I8, but got Unknown
		//IL_00b2: Expected O, but got I4
		//IL_0066: Expected O, but got Ref
		//IL_0013: Expected O, but got I8
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected I8, but got Unknown
		object obj = iPowerOf2ToRoundUpTo - 1;
		long num = (long)(iPowerOf2ToRoundUpTo & obj);
		bool flag = num == 0;
		object obj2 = !flag;
		if (obj2 == null)
		{
			object obj3 = iPowerOf2ToRoundUpTo - 1;
			long num2 = (long)(0L - iPowerOf2ToRoundUpTo);
			object obj4 = obj3 + iNumberToRound;
			return (ulong)(obj4 & num2);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj5 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "value passed as iPowerOf2ToRoundUpTo [{0}] is NOT a power of 2", (System.ParamsArray)(&obj5));
		Debug.LogError(message);
		return iNumberToRound;
	}
}
