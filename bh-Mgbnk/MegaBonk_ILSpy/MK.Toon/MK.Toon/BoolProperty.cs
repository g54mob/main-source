using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class BoolProperty : Property<bool>
{
	public BoolProperty(Uniform uniform, string keyword)
		: base(uniform, new string[1] { keyword })
	{
	}

	public BoolProperty(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public override bool GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		//IL_00eb: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.BoolProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.BoolProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
			int num = material.GetInt(0);
			int num2 = num ^ num;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = num < 0;
			bool flag3 = num == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override void SetValue(Material material, bool value)
	{
		//IL_0047: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.BoolProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v1+18]");
		material.SetInt(0, value ? 1 : 0);
		SetKeyword(material, value, 0);
	}
}
