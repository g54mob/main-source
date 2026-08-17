using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class IntProperty : Property<int>
{
	private int _keywordDisabled;

	public IntProperty(Uniform uniform, string keyword, int keywordDisabled = 0)
		: base(uniform, new string[1] { keyword })
	{
	}

	public IntProperty(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public override int GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		//IL_007e: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.IntProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.IntProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
			return material.GetInt(0);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public override void SetValue(Material material, int value)
	{
		//IL_006f: Expected O, but got I
		//IL_002d: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.IntProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v1+18]");
		material.SetInt(0, value);
		object obj2 = value - _keywordDisabled;
		bool flag = obj2 == null;
		bool b = !flag;
		SetKeyword(material, b, value);
	}
}
