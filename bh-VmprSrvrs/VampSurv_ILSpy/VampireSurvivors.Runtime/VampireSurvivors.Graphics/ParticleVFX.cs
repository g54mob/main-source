using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Graphics;

public class ParticleVFX : GameMonoBehaviour
{
	private ParticleSystem Particles;

	public void AddSprite(string frameName, string textureName)
	{
		//IL_00ad: Expected O, but got I
		//IL_0057: Expected O, but got I
		Sprite sprite = SpriteManager.GetSprite(frameName, textureName);
		bool flag = (object)sprite == null;
		Sprite sprite2 = sprite;
		if (!flag)
		{
			sprite2 = (Sprite)(nint)((UnityEngine.Object)sprite).m_CachedPtr;
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
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v272 @ rax_v13 (should have been resolved before IL gen)");
	}

	public void SetSpeed(float speed)
	{
	}

	public unsafe void EmissionQuantity(int quantity)
	{
		//IL_0035: Expected O, but got Ref
		float constant = (float)quantity * 30f;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
		ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
		object obj = default(object);
		emissionModule.rateOverTime = (ParticleSystem.MinMaxCurve)(&obj);
	}

	public ParticleVFX()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
