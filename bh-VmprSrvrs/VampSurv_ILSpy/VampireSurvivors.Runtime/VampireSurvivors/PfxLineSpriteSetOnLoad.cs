using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class PfxLineSpriteSetOnLoad : MonoBehaviour
{
	public bool _line1;

	private void Awake()
	{
		//IL_0161: Expected O, but got I
		string spriteName;
		string textureName;
		if (!_line1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FA1A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			spriteName = "PfxLine2";
			nint num = 0;
			textureName = "vfx";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FA19]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			spriteName = "PfxLine";
			nint num = 0;
			textureName = "vfx";
		}
		Sprite sprite = SpriteManager.GetSprite(spriteName, textureName);
		ParticleSystem component = GetComponent<ParticleSystem>();
		if ((object)sprite != null)
		{
			nint num = ((UnityEngine.Object)sprite).m_CachedPtr;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v747 @ rax_v18 (should have been resolved before IL gen)");
	}

	public PfxLineSpriteSetOnLoad()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
