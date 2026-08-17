using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_CannonProjectile_UNUSED_BombardingFire_Setup : EME_MechProjectile_BallisticMissile
{
	protected override float Radius => 12f;

	protected override float2 SpawnOffset
	{
		get
		{
			float2 result = default(float2);
			return result;
		}
	}

	protected override List<float> SpawnAngles
	{
		get
		{
			//IL_0028: Expected O, but got I
			//IL_0082: Expected O, but got I
			List<float> list = new List<float>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v4+18]");
			if (num >= 0)
			{
				list.AddWithResize(90f);
				return list;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v4+18]");
			if (num2 < 0)
			{
				_ = 1119092736;
				return list;
			}
			return (List<float>)(object)new IndexOutOfRangeException();
		}
	}

	protected override float TurnSpeed
	{
		get
		{
			//IL_0006: Expected F4, but got I4
			return 0f;
		}
	}

	protected override float TurnDuration
	{
		get
		{
			//IL_0006: Expected F4, but got I4
			return 0f;
		}
	}

	protected override float TurnDelay => 500f;

	protected override float AccelRate => 5f;

	protected override float DecelRate => 5f;

	protected override void OnHasHitAnObject(IDamageable other)
	{
	}

	public override void Despawn()
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		Weapon weapon = _weapon;
		object obj3;
		if ((object)_weapon != null)
		{
			nint num = (nint)typeof(EME_Cannon2Weapon);
			nint num2 = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon2Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon2Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v29+FFFFFFF8+v45 @ rax_v24*8]");
				if (0 == (nint)typeof(EME_Cannon2Weapon))
				{
					obj3 = 1;
					goto IL_01a6;
				}
			}
			obj3 = 0;
			goto IL_01a6;
		}
		goto IL_01c8;
		IL_01c8:
		ParticleSystem missileVFX = base._MissileVFX;
		if ((object)base._MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
		{
			base._MissileVFX.Clear(withChildren: true);
		}
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		((Projectile)this).Despawn();
		return;
		IL_01a6:
		bool flag = obj3 == null;
		EME_Cannon2Weapon eME_Cannon2Weapon = null;
		if (!flag)
		{
			eME_Cannon2Weapon = (EME_Cannon2Weapon)_weapon;
		}
		eME_Cannon2Weapon?.FireBombardment();
		goto IL_01c8;
	}
}
