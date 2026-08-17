using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerGyoruntin : CharacterController
{
	private CarnageWeapon NoFutureWeapon;

	public override bool ShouldCollideWithWalls()
	{
		return false;
	}

	protected override void OnStop()
	{
	}

	public unsafe void SetMechaDamageEmitter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0353: Expected O, but got Ref
		//IL_0374: Expected native int or pointer, but got O
		//IL_0387: Expected O, but got Ref
		//IL_0395: Expected O, but got Ref
		//IL_03ca: Expected O, but got Ref
		//IL_03e4: Expected native int or pointer, but got O
		//IL_0027: Expected O, but got Ref
		//IL_0035: Expected O, but got Ref
		//IL_01ca: Expected O, but got Ref
		//IL_01e4: Expected native int or pointer, but got O
		//IL_01fc: Expected O, but got Ref
		//IL_0255: Expected O, but got Ref
		//IL_026f: Expected native int or pointer, but got O
		//IL_0282: Expected O, but got Ref
		//IL_02f0: Expected O, but got I
		//IL_0305: Expected O, but got I
		//IL_031a: Expected O, but got I
		//IL_0335: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = _damageVfx;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = _damageVfx;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0.5f, 1f));
		ParticleSystem.MinMaxCurve startLifetime = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startLifetime = startLifetime;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		ParticleSystem.MinMaxCurve startRotation = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule2)->startRotation = startRotation;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxLine");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int cycleCount = default(int);
		RenderingExtensions.SetFrames(_damageVfx, list, null, clearExistingFrames: false, cycleCount);
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
		_ = 0;
		ParticleSystem particleSystem = RenderingExtensions.SetAngle(_damageVfx, minMaxCurve4);
		ParticleSystem particleSystem2 = RenderingExtensions.SetTint(_damageVfx, 16777215u);
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(4f, 2f));
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+27]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+37]");
		_ = 0;
		RenderingExtensions.SetScale(_damageVfx, minMaxCurve6);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		_ = 1;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		particleSystemConfig._collideLeft = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		particleSystemConfig._collideTop = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		particleSystemConfig._collideBottom = (bool?)(object)0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		particleSystemConfig._collideRight = (bool?)(object)0;
		RenderingExtensions.SetCollisionBounds(_damageVfx, particleSystemConfig);
	}

	public override void AfterFullInitialization()
	{
		//IL_004b: Expected I, but got O
		//IL_0059: Expected I, but got O
		//IL_0069: Expected O, but got I
		//IL_00e9: Expected O, but got I4
		//IL_00a5: Expected O, but got I
		//IL_00db: Expected O, but got I4
		base.AfterFullInitialization();
		Weapon weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.ROCHER);
		bool flag = (object)weaponByType == null;
		Weapon noFutureWeapon = weaponByType;
		if (flag)
		{
			goto IL_017a;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(CarnageWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.CarnageWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.CarnageWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v30+FFFFFFF8+v114 @ rax_v25*8]");
			if (0 == (nint)typeof(CarnageWeapon))
			{
				obj3 = 1;
				goto IL_0189;
			}
		}
		obj3 = 0;
		goto IL_0189;
		IL_017a:
		NoFutureWeapon = (CarnageWeapon)noFutureWeapon;
		CarnageWeapon noFutureWeapon2 = NoFutureWeapon;
		if ((object)NoFutureWeapon != null && ((UnityEngine.Object)noFutureWeapon2).m_CachedPtr != (IntPtr)0)
		{
			CarnageWeapon noFutureWeapon3 = NoFutureWeapon;
			WeaponData currentWeaponData = ((Weapon)noFutureWeapon3)._currentWeaponData;
			currentWeaponData._003Cpower_003Ek__BackingField = 0.5f;
		}
		SetMechaDamageEmitter();
		return;
		IL_0189:
		bool flag2 = obj3 == null;
		noFutureWeapon = null;
		if (!flag2)
		{
			noFutureWeapon = weaponByType;
		}
		goto IL_017a;
	}

	public override void LevelUp()
	{
		base.LevelUp();
		CarnageWeapon noFutureWeapon = NoFutureWeapon;
		if ((object)NoFutureWeapon == null || ((UnityEngine.Object)noFutureWeapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		CarnageWeapon noFutureWeapon2 = NoFutureWeapon;
		float num = (float)base._level * 0.1f;
		float num2 = num + 0.5f;
		LimitBreakData accumulatedLimitBreaks = noFutureWeapon2.accumulatedLimitBreaks;
		if ((object)accumulatedLimitBreaks._003Cpower_003Ek__BackingField != null)
		{
			CarnageWeapon noFutureWeapon3 = NoFutureWeapon;
			LimitBreakData accumulatedLimitBreaks2 = noFutureWeapon3.accumulatedLimitBreaks;
			if ((object)accumulatedLimitBreaks2._003Cpower_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			object obj = default(object);
			num2 += (float)obj;
		}
		CarnageWeapon noFutureWeapon4 = NoFutureWeapon;
		WeaponData currentWeaponData = ((Weapon)noFutureWeapon4)._currentWeaponData;
		currentWeaponData._003Cpower_003Ek__BackingField = num2;
	}
}
