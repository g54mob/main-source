using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class StencilModeProperty : Property<Stencil>
{
	public StencilModeProperty(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public override Stencil GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		//IL_007e: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.StencilModeProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.StencilModeProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
			return (Stencil)material.GetInt(0);
		}
		NullReferenceException ex = new NullReferenceException();
		return (Stencil)ex;
	}

	public override void SetValue(Material material, Stencil stencil)
	{
		//IL_00f0: Expected O, but got I
		//IL_0065: Expected O, but got I4
		if (stencil == Stencil.Builtin)
		{
			Properties.stencilRef.SetValue(material, 0);
			Properties.stencilReadMask.SetValue(material, 255);
			Properties.stencilWriteMask.SetValue(material, 255);
			((EnumProperty<>)(object)Properties.stencilComp).SetValue(material, (T)8);
			((EnumProperty<>)(object)Properties.stencilPass).SetValue(material, (T)null);
			((EnumProperty<>)(object)Properties.stencilFail).SetValue(material, (T)null);
			((EnumProperty<>)(object)Properties.stencilZFail).SetValue(material, (T)null);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.StencilModeProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v2+18]");
		material.SetInt(0, (int)stencil);
	}
}
