using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Characters;

public class TP_StoneSkull_Character : TP_Character
{
	private float cachedSize;

	public override bool HasThorns => true;

	public override bool DrainWeaponsImmunity => true;

	public override bool ShouldCollideWithWalls()
	{
		return false;
	}

	public unsafe override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		SetMechaDamageEmitter();
		object cachedTransform = ((CharacterController)this)._cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbx_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbx_v1 (System.Object)+10]");
		float ret;
		Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)(&ret));
		cachedSize = ret;
	}

	protected override Vector2 ProcessMovementVector(Vector2 v)
	{
		//IL_0070: Expected O, but got F4
		object obj = default(object);
		bool flag = obj == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875F3923h\"");
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			if ((nint)obj < 0)
			{
			}
		}
		float num = (float)v * 0.25f;
		return (Vector2)num;
	}

	public override float GetThornDamage(EnemyController enemy)
	{
		PlayerModifierStats playerStats = _playerStats;
		float num = base.PArmor();
		float attackPower = enemy.AttackPower;
		float num2 = (float)((CharacterController)this)._level * 0.1f;
		object obj = default(object);
		float num3 = num2 * (float)obj;
		if (!(1f > num3))
		{
			if (num3 > attackPower)
			{
				num3 = attackPower;
			}
		}
		else
		{
			num3 = 1f;
		}
		float num4 = num3 + ArcanaManager.ThornsValue;
		return num4 + playerStats._003CThorns_003Ek__BackingField;
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
			((List<object>)(object)list).AddWithResize((object)"PfxRed");
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
		ParticleSystem particleSystem2 = RenderingExtensions.SetTint(_damageVfx, 16777096u);
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
}
