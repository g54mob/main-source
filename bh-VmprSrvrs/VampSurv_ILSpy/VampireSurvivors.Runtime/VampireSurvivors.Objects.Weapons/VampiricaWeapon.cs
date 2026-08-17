using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class VampiricaWeapon : Weapon
{
	private Timer _healTimer;

	private bool _canHeal = true;

	private float _healDelay = 1000f;

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ae: Expected O, but got I4
		//IL_0068: Expected O, but got I
		//IL_009f: Expected O, but got I4
		//IL_03aa: Expected O, but got F4
		//IL_0118: Invalid comparison between F4 and O
		//IL_044b: Expected I4, but got O
		//IL_0229: Expected I, but got O
		//IL_0231: Expected I, but got O
		//IL_0241: Expected O, but got I
		//IL_016a: Expected I4, but got O
		//IL_027d: Expected O, but got I
		//IL_02ba: Expected O, but got I
		//IL_02fe: Expected O, but got I4
		//IL_02f0: Expected O, but got I4
		//IL_0407: Expected I, but got O
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		VampiricaWeapon vampiricaWeapon = (VampiricaWeapon)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v3 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj2;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v3 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v45+FFFFFFF8+v61 @ rax_v7 (VampireSurvivors.Objects.Weapons.VampiricaWeapon)*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj2 = 1;
				goto IL_0379;
			}
		}
		obj2 = 0;
		goto IL_0379;
		IL_0379:
		bool flag = obj2 == null;
		ArcadeColliderType arcadeColliderType = null;
		if (!flag)
		{
			arcadeColliderType = first;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rsi_v4 (ArcadeColliderType)+260]");
		if ((nint)0 == 0)
		{
			object obj3 = UnityEngine.Random.value;
			WeaponData currentWeaponData = _currentWeaponData;
			float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			object obj4 = default(object);
			float num5 = (float)obj4 * currentWeaponData._003CcritChance_003Ek__BackingField;
			float num6;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				WeaponData currentWeaponData2 = _currentWeaponData;
				num6 = currentWeaponData2._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
			}
			else
			{
				num6 = 1f;
			}
			bool flag2 = !(num6 > 1f);
			bool flag3 = (byte)(int)first != 0;
			if (!flag2)
			{
				bool flag4 = !_canHeal;
				flag3 = (byte)(int)first != 0;
				if (!flag4)
				{
					_canHeal = false;
					((Equipment)this)._003COwner_003Ek__BackingField.RecoverHp(8f, showRecovery: true);
					Action onComplete = delegate
					{
						_canHeal = true;
					};
					float num7 = _healDelay * 0.001f;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer healTimer = Timers.Register(num7, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_healTimer = healTimer;
					flag3 = false;
					num5 = num7;
				}
			}
			nint num8 = (nint)typeof(Projectile);
			nint num9 = (nint)second;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			if (num10 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v20+FFFFFFF8+v126 @ rax_v19*8]");
				if (0 == (nint)typeof(Projectile))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v20+FFFFFFF8+v597 @ rcx_v13*8]");
					object obj8 = ((0 != (nint)typeof(Projectile)) ? ((object)0) : ((object)1));
					bool flag5 = obj8 == null;
					ArcadeColliderType arcadeColliderType2 = null;
					if (!flag5)
					{
						arcadeColliderType2 = second;
					}
					if (!((Projectile)arcadeColliderType2).HasAlreadyHitObject((IDamageable)arcadeColliderType))
					{
						float num11 = base.PPower();
						WeaponData currentWeaponData3 = _currentWeaponData;
						float num12 = num5 * num6;
						if (_currentWeaponData != null)
						{
							HitVfxType hitVfxType = currentWeaponData3._003ChitVFX_003Ek__BackingField;
						}
						else
						{
							HitVfxType hitVfxType = HitVfxType.Default;
						}
						float knockback = base.Knockback;
						nint num13 = (nint)arcadeColliderType;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v387 @ rdx_v14 (Il2CppClass<ArcadeColliderType>)+3E8] (should have been resolved before IL gen)");
						float num14 = num12 + base._003CStatsInflictedDamage_003Ek__BackingField;
						base._003CStatsInflictedDamage_003Ek__BackingField = num14;
					}
					goto IL_039b;
				}
			}
			throw new NullReferenceException();
		}
		goto IL_039b;
		IL_039b:
		return false;
	}

	private void _003COnBulletOverlapsEnemy_003Eb__4_0()
	{
		_canHeal = true;
	}
}
