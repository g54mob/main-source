using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class ColorProperty : Property<Color>
{
	public ColorProperty(Uniform uniform, string keyword)
		: base(uniform, new string[1] { keyword })
	{
	}

	public ColorProperty(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public unsafe override Color GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		//IL_0069: Expected F4, but got O
		//IL_0064: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (MK.Toon.ColorProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (MK.Toon.ColorProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182279760");
			Color color = default(Color);
			object obj2 = default(object);
			((Color*)(nint)color)->r = (float)obj2;
			return color;
		}
		return (Color)new NullReferenceException();
	}

	public unsafe override void SetValue(Material material, Color color)
	{
		//IL_0010: Expected O, but got I
		//IL_002e: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.ColorProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
		object obj2 = default(object);
		material.SetColor(0, (Color)(&obj2));
	}
}
