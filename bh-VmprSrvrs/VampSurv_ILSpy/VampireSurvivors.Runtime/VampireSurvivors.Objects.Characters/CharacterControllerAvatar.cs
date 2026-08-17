using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerAvatar : CharacterController
{
	public override bool NeedsCart => false;

	protected unsafe override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0447: Expected O, but got Ref
		//IL_0461: Expected native int or pointer, but got O
		//IL_001b: Expected O, but got Ref
		//IL_005b: Expected O, but got Ref
		//IL_0075: Expected native int or pointer, but got O
		//IL_0479: Expected O, but got Ref
		//IL_0494: Expected O, but got Ref
		//IL_0173: Expected O, but got I
		//IL_0188: Expected O, but got I
		//IL_019d: Expected O, but got I
		//IL_01b8: Expected O, but got I
		//IL_021c: Expected O, but got I
		//IL_0276: Expected O, but got I
		//IL_03be: Expected O, but got I
		//IL_0419: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.MakeLevelOne();
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
		_ = 0;
		ParticleSystem particleSystem = RenderingExtensions.SetAngle(_damageVfx, minMaxCurve2);
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
		object obj3 = default(object);
		if ((nint)0 == 0)
		{
			float num = (float)obj3 * 0.001f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
			if ((nint)0 == 3)
			{
				float num2 = (float)obj3 * 0.001f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-1D]");
				float num3 = 0f * 0.001f;
			}
		}
		_ = _damageVfx;
		ParticleSystem.MinMaxCurve gravityModifier = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 55));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
		_ = 0;
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		_ = _damageVfx;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->gravityModifier = gravityModifier;
		ParticleSystem particleSystem2 = RenderingExtensions.SetTint(_damageVfx, 16777147u, 16711680u);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		particleSystemConfig._002Ector("vfx");
		_ = 1;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		particleSystemConfig._collideLeft = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		particleSystemConfig._collideTop = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		particleSystemConfig._collideBottom = (bool?)(object)0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		particleSystemConfig._collideRight = (bool?)(object)0;
		RenderingExtensions.SetCollisionBounds(_damageVfx, particleSystemConfig);
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r8_v12+18]");
		if (num4 >= 0)
		{
			list.AddWithResize((System.Int32Enum)19);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj5 = (nint)0 + (nint)1;
			_ = 19;
		}
		GameManager core2 = GM.Core;
		core2._arcanaManager.TriggerArcana(ArcanaType.T19_FIRE);
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager2 = core3._arcanaManager;
		int num5 = arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField + 1;
		arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField = num5;
		GameManager core4 = GM.Core;
		PlayerOptionsData config = core4._playerOptions.Config;
		List<WeaponType> list2 = config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			if ((nint)obj6 != -1)
			{
				return;
			}
		}
		GameManager core5 = GM.Core;
		PlayerOptionsData config2 = core5._playerOptions.Config;
		List<System.Int32Enum> list3 = (List<System.Int32Enum>)(object)config2._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ r9_v13+18]");
		if (num6 >= 0)
		{
			list3.AddWithResize((System.Int32Enum)109);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj8 = (nint)0 + (nint)1;
		_ = 109;
	}

	protected override void OnStop()
	{
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}
}
