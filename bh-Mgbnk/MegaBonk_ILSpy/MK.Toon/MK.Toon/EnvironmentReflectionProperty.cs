using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class EnvironmentReflectionProperty : Property<EnvironmentReflection>
{
	public EnvironmentReflectionProperty(Uniform uniform, string[] keywords)
		: base(uniform, keywords)
	{
	}

	public override EnvironmentReflection GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		//IL_007e: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.EnvironmentReflectionProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.EnvironmentReflectionProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
			return (EnvironmentReflection)material.GetInt(0);
		}
		NullReferenceException ex = new NullReferenceException();
		return (EnvironmentReflection)ex;
	}

	public override void SetValue(Material material, EnvironmentReflection environmentReflection)
	{
		//IL_011e: Expected O, but got I
		//IL_006a: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		Shader shader = material.shader;
		string name = shader.name;
		bool flag = name.Contains(Properties.shaderVariantSimpleName);
		bool flag2 = !flag;
		bool flag3 = (byte)environmentReflection != 0;
		if (!flag2)
		{
			object obj = environmentReflection - 1;
			object obj2 = environmentReflection ^ EnvironmentReflection.Ambient;
			object obj3 = environmentReflection ^ obj;
			object obj4 = obj2 & obj3;
			bool flag4 = (nint)obj4 < 0;
			bool flag5 = (nint)obj < 0;
			bool flag6 = flag5 == flag4;
			flag3 = flag6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.EnvironmentReflectionProperty)+18]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v8+18]");
		material.SetInt(0, flag3 ? 1 : 0);
		bool flag7 = !flag3;
		bool flag8 = !flag7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1808D9510");
	}
}
