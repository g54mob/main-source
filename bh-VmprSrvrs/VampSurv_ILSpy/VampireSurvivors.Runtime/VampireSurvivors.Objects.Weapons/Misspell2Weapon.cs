using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Misspell2Weapon : Weapon
{
	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_explosionType = WeaponType.FIREEXPLOSION;
		base.InitWeapon(characterController, weaponType);
	}

	public override void ParadoxFire()
	{
		base.Fire(skipTriggers: true);
		Action onComplete = delegate
		{
			base.Fire(skipTriggers: true);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.05f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			base.Fire(skipTriggers: true);
		};
		Timer timer2 = Timers.Register(0.1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override float PPower()
	{
		GameManager core = GM.Core;
		float num2;
		float num3;
		float num4;
		float num5;
		VampireSurvivors.Objects.Characters.CharacterController characterController2;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				float num = (float)config._003CRunEnemies_003Ek__BackingField / 5000f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				num2 = num * 0.1f;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					if (characterController._sineMight == null)
					{
						CharacterData currentCharacterData = characterController._currentCharacterData;
						if (characterController._currentCharacterData != null)
						{
							num = (float)currentCharacterData._003Cpower_003Ek__BackingField + characterController._003CSilentMight_003Ek__BackingField;
							bool flag = !(10f > num);
							num3 = 10f;
							if (!flag)
							{
								num3 = num;
							}
							WeaponData currentWeaponData = _currentWeaponData;
							if (_currentWeaponData != null)
							{
								num4 = currentWeaponData._003Cpower_003Ek__BackingField;
								num5 = num;
								characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
								goto IL_02fb;
							}
						}
					}
					else
					{
						CharacterData currentCharacterData2 = characterController._currentCharacterData;
						if (characterController._currentCharacterData != null && characterController._sineMight != null)
						{
							float value = characterController._sineMight.Value;
							float num6 = (float)currentCharacterData2._003Cpower_003Ek__BackingField + characterController._003CSilentMight_003Ek__BackingField;
							num = value * num6;
							bool flag2 = !(10f > num);
							num3 = 10f;
							if (!flag2)
							{
								num3 = num;
							}
							WeaponData currentWeaponData2 = _currentWeaponData;
							if (_currentWeaponData != null)
							{
								characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
								num4 = currentWeaponData2._003Cpower_003Ek__BackingField;
								bool flag3 = (object)((Equipment)this)._003COwner_003Ek__BackingField != null;
								num5 = num;
								if (flag3)
								{
									goto IL_02fb;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_02fb:
		float bloodlineDamage = characterController2.BloodlineDamage;
		float num7 = num4 + num2;
		float num8 = num7 * num3;
		return num5 + num8;
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0017: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_010b: Expected I, but got O
		//IL_0119: Expected I, but got O
		//IL_0129: Expected O, but got I
		//IL_01a9: Expected O, but got I4
		//IL_0165: Expected O, but got I
		//IL_019b: Expected O, but got I4
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		Projectile projectile2;
		if ((object)projectile == null)
		{
			projectile2 = null;
			goto IL_027a;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(Misspell2Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Misspell2Projectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Misspell2Projectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v40+FFFFFFF8+v74 @ rax_v36*8]");
			if (0 == (nint)typeof(Misspell2Projectile))
			{
				obj3 = 1;
				goto IL_0253;
			}
		}
		obj3 = 0;
		goto IL_0253;
		IL_02d8:
		object obj4;
		bool flag = obj4 == null;
		Projectile projectile3 = null;
		Projectile projectile4;
		if (!flag)
		{
			projectile3 = projectile4;
		}
		goto IL_02ff;
		IL_027a:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
			_ = 1;
		}
		projectile4 = base.FireOneProjectile(pos, index, target, pool2);
		bool flag2 = (object)projectile4 == null;
		projectile3 = null;
		if (!flag2)
		{
			nint num4 = (nint)projectile4;
			nint num5 = (nint)typeof(Misspell2Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Misspell2Projectile>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Misspell2Projectile>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v28+FFFFFFF8+v285 @ rax_v24*8]");
				if (0 == (nint)typeof(Misspell2Projectile))
				{
					obj4 = 1;
					goto IL_02d8;
				}
			}
			obj4 = 0;
			goto IL_02d8;
		}
		goto IL_02ff;
		IL_0253:
		bool flag3 = obj3 == null;
		projectile2 = null;
		if (!flag3)
		{
			projectile2 = projectile;
		}
		goto IL_027a;
		IL_02ff:
		Projectile result;
		if ((object)projectile3 != null)
		{
			bool flag4 = ((UnityEngine.Object)projectile3).m_CachedPtr == (IntPtr)0;
			result = projectile3;
			if (!flag4)
			{
				_ = 0;
				result = projectile3;
			}
		}
		else
		{
			result = projectile3;
		}
		return result;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan3._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	private void _003CParadoxFire_003Eb__1_0()
	{
		base.Fire(skipTriggers: true);
	}

	private void _003CParadoxFire_003Eb__1_1()
	{
		base.Fire(skipTriggers: true);
	}
}
