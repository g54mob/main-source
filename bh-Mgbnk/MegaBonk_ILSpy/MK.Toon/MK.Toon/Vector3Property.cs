using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class Vector3Property : Property<Vector3>
{
	public Vector3Property(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public unsafe override Vector3 GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		//IL_0069: Expected F4, but got O
		//IL_0064: Expected native int or pointer, but got O
		//IL_007e: Expected F4, but got I
		//IL_0079: Expected native int or pointer, but got O
		//IL_0093: Expected F4, but got I
		//IL_008e: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (MK.Toon.Vector3Property)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (MK.Toon.Vector3Property)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182279760");
			Vector3 vector = default(Vector3);
			object obj2 = default(object);
			((Vector3*)(nint)vector)->x = (float)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3+8]");
			((Vector3*)(nint)vector)->z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3+4]");
			((Vector3*)(nint)vector)->y = 0f;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe override void SetValue(Material material, Vector3 value)
	{
		//IL_0010: Expected O, but got I
		//IL_002f: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.Vector3Property)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
		float num = default(float);
		material.SetVector(0, (Vector4)(&num));
	}
}
