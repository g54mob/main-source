using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class EnumProperty<T> : Property<T> where T : Enum
{
	public EnumProperty(Uniform uniform, string[] keywords)
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1808D96F0");
	}

	public override T GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		//IL_0090: Expected O, but got I
		//IL_0096: Expected O, but got I
		//IL_00af: Expected I, but got O
		//IL_00c5: Expected I, but got O
		//IL_00f0: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v1 (MK.Toon.EnumProperty`1<T>)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v1 (MK.Toon.EnumProperty`1<T>)+18]");
		NullReferenceException ex;
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rdx_v1+18]");
			int num = material.GetInt(0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v7 (Il2CppRgctx<MK.Toon.EnumProperty`1>)+18]");
			ex = (NullReferenceException)0;
			EnumProperty<T> enumProperty = (EnumProperty<T>)0;
			EnumProperty<T> enumProperty2 = default(EnumProperty<T>);
			bool flag = enumProperty2 == null;
			nint num3 = unchecked((nint)null);
			if (!flag)
			{
				nint num4 = (nint)enumProperty2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v8 (Il2CppClass<MK.Toon.EnumProperty`1<T>>)+40]");
				bool flag2 = 0 != (nint)((Exception)ex)._stackTraceString;
				enumProperty = enumProperty2;
				num3 = unchecked((nint)null);
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					object result = default(object);
					return (T)result;
				}
				goto IL_011c;
			}
		}
		ex = new NullReferenceException();
		goto IL_011c;
		IL_011c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		T result2 = default(T);
		return result2;
	}

	public override void SetValue(Material material, T value)
	{
		//IL_0010: Expected O, but got I
		//IL_0050: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_0106: Expected I4, but got O
		//IL_0131: Expected O, but got I
		//IL_0154: Expected I, but got O
		//IL_017a: Expected O, but got I
		//IL_0182: Expected I, but got O
		//IL_01a8: Expected I, but got O
		//IL_01d4: Expected I, but got O
		//IL_01fa: Expected O, but got I
		//IL_0202: Expected I, but got O
		//IL_0228: Expected I, but got O
		//IL_0289: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.EnumProperty`1<T>)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.EnumProperty`1<T>)+18]");
		bool flag = (nint)0 == 0;
		EnumProperty<T> enumProperty = this;
		if (!flag)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v6 (Il2CppRgctx<MK.Toon.EnumProperty`1>)+18]");
			enumProperty = (EnumProperty<T>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			EnumProperty<T> enumProperty2 = default(EnumProperty<T>);
			if ((object)material != null && enumProperty2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
				T val = (T)0;
				T val2 = (T)enumProperty2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v3 (T)+40]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v5 (T)+40]");
				bool flag2 = num2 != 0;
				EnumProperty<T> enumProperty3 = enumProperty2;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v1+18]");
					object obj2 = default(object);
					material.SetInt(0, (int)obj2);
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rcx_v14 (Il2CppRgctx<MK.Toon.EnumProperty`1>)+18]");
					enumProperty = (EnumProperty<T>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					EnumProperty<T> enumProperty4 = default(EnumProperty<T>);
					bool flag3 = enumProperty4 == null;
					nint num5 = unchecked((nint)null);
					val2 = (T)obj2;
					if (flag3)
					{
						goto IL_0299;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
					val2 = (T)0;
					nint num6 = (nint)enumProperty4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rdx_v12 (Il2CppClass<MK.Toon.EnumProperty`1<T>>)+40]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v3 (T)+40]");
					bool flag4 = num7 != 0;
					num5 = unchecked((nint)null);
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						EnumProperty<T> enumProperty5 = default(EnumProperty<T>);
						bool flag5 = enumProperty5 == null;
						num5 = unchecked((nint)null);
						enumProperty = enumProperty4;
						if (flag5)
						{
							goto IL_0299;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
						val2 = (T)0;
						nint num8 = (nint)enumProperty5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v14 (Il2CppClass<MK.Toon.EnumProperty`1<T>>)+40]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v3 (T)+40]");
						bool flag6 = num9 != 0;
						num5 = unchecked((nint)null);
						enumProperty = enumProperty5;
						if (!flag6)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							object obj3 = default(object);
							bool flag7 = (nint)obj3 < 0;
							bool flag8 = obj3 == null;
							bool flag9 = !flag7;
							bool flag10 = !flag8;
							object obj4 = flag10 & flag9;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1808D9510");
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					enumProperty3 = enumProperty4;
					val = val2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
		}
		goto IL_0299;
		IL_0299:
		throw new NullReferenceException();
	}
}
