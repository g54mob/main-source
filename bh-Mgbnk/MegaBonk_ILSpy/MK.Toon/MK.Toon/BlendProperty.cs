using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class BlendProperty : Property<Blend>
{
	public BlendProperty(Uniform uniform, string[] keywords)
		: base(uniform, keywords)
	{
	}

	public override Blend GetValue(Material material)
	{
		//IL_005e: Expected O, but got I
		//IL_004e: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.BlendProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.BlendProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1+18]");
			return (Blend)material.GetInt(0);
		}
		NullReferenceException ex = new NullReferenceException();
		return (Blend)ex;
	}

	public override void SetValue(Material material, Blend blend)
	{
		//IL_019a: Expected O, but got I
		//IL_004c: Expected O, but got I4
		//IL_017b: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_010e: Expected O, but got I4
		//IL_0168: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		//IL_0155: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		Blend value = Properties.blend.GetValue(material);
		EnumProperty<BlendFactor> blendSrc;
		_00210 value2;
		EnumProperty<BlendFactor> blendDst;
		_00210 value3;
		EnumProperty<BlendFactor> blendSrc2;
		_00210 value4;
		if (value != Blend.Custom)
		{
			((EnumProperty<>)(object)Properties.zTest).SetValue(material, (T)4);
			if (Properties.surface.GetValue(material) != Surface.Opaque)
			{
				bool flag = blend == Blend.Alpha;
				if (!flag)
				{
					object obj = blend - 1;
					if (flag)
					{
						blendSrc = Properties.blendSrc;
						value2 = (_00210)1;
						goto IL_024b;
					}
					object obj2 = obj - 1;
					if (flag)
					{
						((EnumProperty<>)(object)Properties.blendSrc).SetValue(material, (T)1);
						blendDst = Properties.blendDst;
						value3 = (_00210)1;
						goto IL_01fa;
					}
					if ((nint)obj2 == 1)
					{
						blendSrc2 = Properties.blendSrc;
						value4 = (_00210)2;
						goto IL_021e;
					}
				}
				blendSrc = Properties.blendSrc;
				value2 = (_00210)5;
				goto IL_024b;
			}
			blendSrc2 = Properties.blendSrc;
			value4 = (_00210)1;
			goto IL_021e;
		}
		goto IL_0278;
		IL_024b:
		((EnumProperty<>)(object)blendSrc).SetValue(material, (T)value2);
		blendDst = Properties.blendDst;
		value3 = (_00210)10;
		goto IL_01fa;
		IL_01fa:
		((EnumProperty<>)(object)blendDst).SetValue(material, (T)value3);
		goto IL_0278;
		IL_021e:
		((EnumProperty<>)(object)blendSrc2).SetValue(material, (T)value4);
		blendDst = Properties.blendDst;
		value3 = (_00210)null;
		goto IL_01fa;
		IL_0278:
		BlendProperty blend2 = Properties.blend;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v7 (MK.Toon.BlendProperty)+18]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v4+18]");
		material.SetInt(0, (int)blend);
		bool flag2 = blend == Blend.Alpha;
		bool flag3 = !flag2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1808D9510");
	}
}
