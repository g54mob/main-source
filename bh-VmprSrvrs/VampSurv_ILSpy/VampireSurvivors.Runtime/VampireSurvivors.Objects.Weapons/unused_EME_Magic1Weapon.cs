using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class unused_EME_Magic1Weapon : Weapon
{
	private float FireInterval
	{
		get
		{
			float num = base.PDuration();
			float num2 = base.PInterval();
			object obj = default(object);
			return (float)obj + (float)obj;
		}
	}

	public override bool LevelUp(bool skipFire)
	{
		return base.LevelUp(true);
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_01a1: Expected O, but got I
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01d0: Invalid comparison between O and F4
		//IL_0041: Expected O, but got I
		//IL_0078: Expected I, but got O
		//IL_0086: Expected I, but got O
		//IL_0096: Expected O, but got I
		//IL_0116: Expected O, but got I4
		//IL_00d2: Expected O, but got I
		//IL_0108: Expected O, but got I4
		//IL_0163: Expected I, but got O
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = true;
		bool flag2 = true;
		nint num = default(nint);
		while ((flag2 ? 1 : 0) <= currentWeaponData._003Camount_003Ek__BackingField)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Projectile projectile = base.FireOneProjectile((Vector2)num, 0, _targetTransform);
			Projectile projectile2;
			if ((object)projectile == null)
			{
				projectile2 = null;
				goto IL_025b;
			}
			nint num2 = (nint)projectile;
			nint num3 = (nint)typeof(EME_Magic1Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_Magic1Projectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_Magic1Projectile>)+130]");
			object obj3;
			if (num4 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rax_v41+FFFFFFF8+v304 @ rax_v37*8]");
				if (0 == (nint)typeof(EME_Magic1Projectile))
				{
					obj3 = 1;
					goto IL_0233;
				}
			}
			obj3 = 0;
			goto IL_0233;
			IL_025b:
			if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
			{
				nint num5 = (nint)projectile2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v496 @ rax_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+448] (should have been resolved before IL gen)");
			}
			currentWeaponData = _currentWeaponData;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			flag2 = flag;
			continue;
			IL_0233:
			bool flag3 = obj3 == null;
			projectile2 = null;
			if (!flag3)
			{
				projectile2 = projectile;
			}
			goto IL_025b;
		}
		float num6 = base.PDuration();
		float num7 = base.PInterval();
		object obj4 = num + num;
		float num8 = _lastFiringInterval - (float)obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj5 = num8 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num9 = base.PDuration();
			float num10 = base.PInterval();
			float lastFiringInterval = (float)obj4 + (float)obj4;
			_lastFiringInterval = lastFiringInterval;
			ResetFiringTimer();
		}
	}

	public override void ResetFiringTimer()
	{
		//IL_0051: Expected I, but got O
		//IL_0090: Expected I4, but got O
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		float num = base.PDuration();
		float num2 = base.PInterval();
		object obj2 = default(object);
		object obj = obj2 + obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.unused_EME_Magic1Weapon>)+4C0]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num3 = (nint)this;
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer firingTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, (byte)(int)this != 0);
		_firingTimer = firingTimer;
	}

	protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0255: Expected I4, but got O
		//IL_00b3: Expected I, but got O
		//IL_00bb: Expected I, but got O
		//IL_00cb: Expected O, but got I
		//IL_014b: Expected O, but got I4
		//IL_0107: Expected O, but got I
		//IL_013d: Expected O, but got I4
		EnemyController component;
		Projectile projectile;
		object obj3;
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0239;
					}
					if (second == null)
					{
						projectile = null;
						goto IL_029e;
					}
					nint num = (nint)typeof(Projectile);
					nint num2 = (nint)second;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ r8_v8 (Il2CppClass<ArcadeColliderType>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ r8_v8 (Il2CppClass<ArcadeColliderType>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v33+FFFFFFF8+v256 @ rax_v29*8]");
						if (0 == (nint)typeof(Projectile))
						{
							obj3 = 1;
							goto IL_0277;
						}
					}
					obj3 = 0;
					goto IL_0277;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0239:
		return false;
		IL_0277:
		bool flag = obj3 == null;
		projectile = null;
		if (!flag)
		{
			projectile = (Projectile)second;
		}
		goto IL_029e;
		IL_029e:
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0 && !projectile.HasAlreadyHitObject(component))
		{
			float num4 = base.PPower();
			float num5 = base.PAmount();
			WeaponData currentWeaponData = _currentWeaponData;
			object obj4 = default(object);
			float num6 = (float)obj4 / 10f;
			float num7 = num6 + 1f;
			float num8 = num7 * (float)obj4;
			HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
			float knockback = base.Knockback;
			component.GetDamaged(num8, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
			float num9 = num8 + base._003CStatsInflictedDamage_003Ek__BackingField;
			base._003CStatsInflictedDamage_003Ek__BackingField = num9;
			return false;
		}
		goto IL_0239;
	}
}
