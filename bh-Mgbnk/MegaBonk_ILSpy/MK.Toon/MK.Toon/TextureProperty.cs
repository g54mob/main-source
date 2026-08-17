using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class TextureProperty : Property<Texture>
{
	public TextureProperty(Uniform uniform, string keyword)
		: base(uniform, new string[1] { keyword })
	{
	}

	public TextureProperty(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public override Texture GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.TextureProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.TextureProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
			return material.GetTexture(0);
		}
		return (Texture)(object)new NullReferenceException();
	}

	public override void SetValue(Material material, Texture texture)
	{
		//IL_0051: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.TextureProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdx_v1+18]");
		material.SetTextureImpl(0, texture);
		bool flag = texture != null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1808D9510");
	}
}
