using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerPeppino : CharacterController
{
	protected override void OnStop()
	{
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}

	protected unsafe override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_011e: Expected O, but got I4
		//IL_0165: Expected O, but got Ref
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_01bc: Expected native int or pointer, but got O
		//IL_01d6: Expected O, but got I
		//IL_01f6: Expected O, but got Ref
		//IL_0210: Expected native int or pointer, but got O
		//IL_022a: Expected O, but got I
		//IL_0258: Expected O, but got I4
		//IL_0271: Expected O, but got Ref
		//IL_028b: Expected native int or pointer, but got O
		//IL_03af: Expected O, but got I4
		//IL_02a3: Expected O, but got Ref
		//IL_02bd: Expected native int or pointer, but got O
		//IL_03cc: Expected O, but got I4
		//IL_0308: Expected O, but got I
		//IL_0406: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.MakeLevelOne();
		Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
		if (currentSkinData != null && currentSkinData.skinType == SkinType.XMAS)
		{
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			list.Add("snowb0000");
			list.Add("snowb0001");
			list.Add("snowb0006");
			particleSystemConfig._frame = list;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num = renderer.height * 0.5f;
			float constant = num + 0.16f;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			float width = renderer2.width;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj3 = width ^ 0;
			float min = (float)obj3 * 0.25f;
			float max = renderer3.width * 1.5f;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(min, max));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(4000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
			particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
			_ = 0;
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
			_ = 0;
			_ = 0;
			_ = 4;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
			particleSystemConfig._quantity = (int?)(object)0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0.5f);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			_ = 0;
			Transform parent = base.transform;
			ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
			RenderingExtensions.Start(pfx);
		}
	}
}
