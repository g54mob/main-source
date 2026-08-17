using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class Vector4Property : Property<Vector4>
{
	public Vector4Property(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public unsafe override Vector4 GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		//IL_0069: Expected F4, but got O
		//IL_0064: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (MK.Toon.Vector4Property)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (MK.Toon.Vector4Property)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182279760");
			Vector4 vector = default(Vector4);
			object obj2 = default(object);
			((Vector4*)(nint)vector)->x = (float)obj2;
			return vector;
		}
		return (Vector4)new NullReferenceException();
	}

	public unsafe override void SetValue(Material material, Vector4 value)
	{
		//IL_0010: Expected O, but got I
		//IL_002e: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.Vector4Property)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
		object obj2 = default(object);
		material.SetVector(0, (Vector4)(&obj2));
	}
}
