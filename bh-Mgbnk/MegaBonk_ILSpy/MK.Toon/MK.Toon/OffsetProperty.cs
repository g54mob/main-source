using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class OffsetProperty : Property<Vector2>
{
	public OffsetProperty(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public override Vector2 GetValue(Material material)
	{
		//IL_005e: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.OffsetProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.OffsetProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1+18]");
			return material.GetTextureOffset(0);
		}
		return (Vector2)new NullReferenceException();
	}

	public override void SetValue(Material material, Vector2 value)
	{
		//IL_002f: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.OffsetProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v1+18]");
		material.SetTextureOffset(0, value);
	}
}
