using System;
using System.Globalization;
using System.IO;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Utils;

public static class AssetUtils
{
	public static T GetScriptableObject<T>(string fileName, string resourcesPath, bool saveAssetDatabase, bool refreshAssetDatabase) where T : ScriptableObject
	{
		//IL_0100: Expected O, but got I
		//IL_04b2: Expected O, but got I
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0209: Expected O, but got I4
		//IL_036d: Expected O, but got I
		//IL_0383: Expected O, but got I
		//IL_03ad: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ stack_28+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		string text;
		T val;
		int num;
		if (resourcesPath != null && resourcesPath._stringLength > 0 && fileName != null && fileName._stringLength > 0)
		{
			text = CleanPath(resourcesPath);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ stack_28+38]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rbx_v3+8]");
			Type systemTypeInstance = default(Type);
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj3 = default(object);
				object obj2 = obj3 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			}
			else
			{
				systemTypeInstance = null;
			}
			UnityEngine.Object obj4 = Resources.Load(fileName, systemTypeInstance);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ stack_28+38]");
			object obj5 = 0;
			if ((object)obj4 == null)
			{
				val = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				T val2 = default(T);
				bool flag = (object)val2 == null;
				val = val2;
				if (flag)
				{
					return (T)(object)new InvalidCastException();
				}
			}
			if ((object)val != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v621 @ rbx_v7 (T)+10]");
				if ((nint)0 != 0)
				{
					goto IL_03eb;
				}
			}
			string text2 = "Resources";
			num = text._stringLength - 1;
			if ("Resources" != null)
			{
				if (text._stringLength == 0)
				{
					object obj6 = num + 1;
					if ((nint)obj6 <= 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb ebx,ebx\"");
						goto IL_0531;
					}
				}
				if (num >= 0)
				{
					bool flag2 = num < text._stringLength;
					if (num <= text._stringLength)
					{
						if (num == text._stringLength)
						{
							num--;
						}
						if (!flag2)
						{
							if (text2._stringLength != 0)
							{
								int count = default(int);
								bool ignoreCase = default(bool);
								int num2 = CompareInfo.Invariant.LastIndexOfOrdinal(text, "Resources", num, count, ignoreCase);
								num = num2;
							}
							goto IL_0531;
						}
						ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("count", "Count must be positive and count must refer to a location within the string/array/collection.");
						ex._002Ector("count", "Count must be positive and count must refer to a location within the string/array/collection.");
						throw ex;
					}
				}
				ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException("startIndex", "Index was out of range. Must be non-negative and less than the size of the collection.");
				ex2._002Ector("startIndex", "Index was out of range. Must be non-negative and less than the size of the collection.");
				throw ex2;
			}
			ArgumentNullException ex3 = new ArgumentNullException("value");
			ex3._002Ector("value");
			throw ex3;
		}
		return null;
		IL_0531:
		string oldValue = text.Substring(0, num);
		string text3 = text.Replace(oldValue, "");
		string text4 = text3.Replace("Resources", "");
		string path = text4.Remove(0, 1);
		string path2 = Path.Combine(path, fileName);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ stack_28+38]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ rbx_v19+8]");
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		UnityEngine.Object obj8 = Resources.Load(path2, typeFromHandle);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ stack_28+38]");
		object obj9 = 0;
		if ((object)obj8 == null)
		{
			val = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			T val3 = default(T);
			bool flag3 = (object)val3 == null;
			val = val3;
			if (flag3)
			{
				throw new InvalidCastException();
			}
		}
		goto IL_03eb;
		IL_03eb:
		return val;
	}

	public static T GetResource<T>(string resourcesPath, string fileName) where T : ScriptableObject
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		if (resourcesPath != null && resourcesPath._stringLength > 0 && fileName != null && fileName._stringLength > 0)
		{
			string text = CleanPath(resourcesPath);
			string path = text + fileName;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type systemTypeInstance = default(Type);
			UnityEngine.Object obj3 = Resources.Load(path, systemTypeInstance);
			bool flag = (object)obj3 == null;
			T result = null;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				T val = default(T);
				bool flag2 = (object)val == null;
				result = val;
				if (flag2)
				{
					return (T)(object)new InvalidCastException();
				}
			}
			return result;
		}
		return null;
	}

	public static string CleanPath(string path)
	{
		//IL_0053: Expected O, but got I4
		//IL_0087: Expected O, but got I
		//IL_00ce: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899805F4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int stringLength = path._stringLength;
		object obj = path._stringLength - 1;
		string newValue;
		string text3;
		if ((nint)obj < path._stringLength)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
			object obj2 = 0;
			string text = "\\";
			if ("\\" != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
				bool flag = text != null;
				string text2 = null;
				if (!flag)
				{
					text2 = "\\";
				}
				if (text2 != null)
				{
					nint num = (nint)text;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v14 (Il2CppClass<System.String>)+40]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v6+40]");
					if (num2 != 0)
					{
						throw new InvalidCastException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [path @ rcx (System.String)+12+v47 @ rdx_v4 (System.Int32)*2]");
					bool flag2 = (nint)0 == text._stringLength;
					newValue = "\\";
					text3 = path;
					if (flag2)
					{
						goto IL_01da;
					}
				}
			}
			string text4 = path + "\\";
			newValue = "\\";
			text3 = text4;
			goto IL_01da;
		}
		System.ThrowHelper.ThrowIndexOutOfRangeException();
		string result = default(string);
		return result;
		IL_01da:
		string text5 = text3.Replace("\\\\", newValue);
		return text5.Replace("\\", "/");
	}
}
