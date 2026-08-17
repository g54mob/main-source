using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class SurfaceProperty : Property<Surface, bool>
{
	public SurfaceProperty(Uniform uniform, string[] keywords)
		: base(uniform, keywords)
	{
	}

	public override Surface GetValue(Material material)
	{
		//IL_005e: Expected O, but got I
		//IL_004e: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.SurfaceProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.SurfaceProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1+18]");
			return (Surface)material.GetInt(0);
		}
		NullReferenceException ex = new NullReferenceException();
		return (Surface)ex;
	}

	public override void SetValue(Material material, Surface surface)
	{
		SetValue(material, surface, alphaClipping: false);
	}

	public override void SetValue(Material material, Surface surface, bool alphaClipping)
	{
		//IL_015f: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		//IL_0125: Expected O, but got I4
		//IL_0236: Expected O, but got I
		Shader shader = material.shader;
		string name = shader.name;
		bool flag = name.Contains(Properties.shaderComponentOutlineName);
		Surface surface2 = Surface.Opaque;
		if (!flag)
		{
			surface2 = surface;
		}
		Shader shader2 = material.shader;
		string name2 = shader2.name;
		if (name2.Contains(Properties.shaderComponentRefractionName))
		{
			surface2 = Surface.Transparent;
		}
		Blend value = Properties.blend.GetValue(material);
		bool enabled;
		if (surface2 == Surface.Transparent)
		{
			if (value != Blend.Custom)
			{
				((EnumProperty<>)(object)Properties.zWrite).SetValue(material, (T)null);
				((EnumProperty<>)(object)Properties.zTest).SetValue(material, (T)4);
			}
			material.SetOverrideTag("RenderType", "Transparent");
			material.SetOverrideTag("IgnoreProjector", "true");
			enabled = false;
		}
		else
		{
			if (value != Blend.Custom)
			{
				((EnumProperty<>)(object)Properties.zWrite).SetValue(material, (T)1);
				((EnumProperty<>)(object)Properties.zTest).SetValue(material, (T)4);
			}
			string val;
			if (!alphaClipping)
			{
				material.SetOverrideTag("RenderType", "Opaque");
				val = "false";
			}
			else
			{
				material.SetOverrideTag("RenderType", "TransparentCutout");
				val = "true";
			}
			material.SetOverrideTag("IgnoreProjector", val);
			enabled = true;
		}
		material.SetShaderPassEnabled("ShadowCaster", enabled);
		Blend value2 = Properties.blend.GetValue(material);
		Properties.blend.SetValue(material, value2);
		int value3 = Properties.renderPriority.GetValue(material);
		bool value4 = Properties.alphaClipping.GetValue(material);
		Properties.renderPriority.SetValue(material, value3, value4);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.SurfaceProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v25+18]");
		material.SetInt(0, (int)surface2);
		bool flag2 = surface2 == Surface.Opaque;
		bool flag3 = !flag2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1808D9510");
	}
}
