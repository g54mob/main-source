using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class RenderPriorityProperty : Property<int, bool>
{
	public RenderPriorityProperty(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public override int GetValue(Material material)
	{
		//IL_005e: Expected O, but got I
		//IL_004e: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.RenderPriorityProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.RenderPriorityProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1+18]");
			return material.GetInt(0);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public override void SetValue(Material material, int priority)
	{
		SetValue(material, priority, alphaClipping: false);
	}

	public override void SetValue(Material material, int priority, bool alphaClipping)
	{
		//IL_00ee: Expected O, but got I
		Surface value = Properties.surface.GetValue(material);
		int renderQueue;
		if (value == Surface.Transparent)
		{
			renderQueue = 3000;
		}
		else
		{
			renderQueue = 2450;
			if (!alphaClipping)
			{
				renderQueue = 2000;
			}
		}
		material.renderQueue = renderQueue;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.RenderPriorityProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v4+18]");
		material.SetInt(0, priority);
		int renderQueue2 = material.renderQueue;
		int value2 = Properties.renderPriority.GetValue(material);
		int renderQueue3 = renderQueue2 - value2;
		material.renderQueue = renderQueue3;
	}
}
