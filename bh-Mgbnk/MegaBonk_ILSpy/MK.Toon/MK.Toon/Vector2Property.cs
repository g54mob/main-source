using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class Vector2Property : Property<Vector2>
{
	public Vector2Property(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public override Vector2 GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.Vector2Property)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.Vector2Property)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182279760");
			Vector2 result = default(Vector2);
			return result;
		}
		return (Vector2)new NullReferenceException();
	}

	public unsafe override void SetValue(Material material, Vector2 value)
	{
		//IL_0010: Expected O, but got I
		//IL_002e: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.Vector2Property)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v1+18]");
		Vector2 vector = default(Vector2);
		material.SetVector(0, (Vector4)(&vector));
	}
}
