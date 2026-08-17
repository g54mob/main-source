using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Soleil_Character : TP_Character
{
	private Weapon whip1;

	private Weapon whip2;

	private Weapon whip3;

	private Weapon hWhip1;

	private Weapon hWhip2;

	private Weapon hWhip3;

	private bool _canRetaliate = true;

	private float RetaliationDelay = 4000f;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_LEMURIA1, searchHidden: true);
		hWhip1 = weaponByType;
		Weapon weaponByType2 = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_MARTIALWHIP1, searchHidden: true);
		hWhip2 = weaponByType2;
		Weapon weaponByType3 = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_HOLYWHIP1, searchHidden: true);
		hWhip3 = weaponByType3;
	}

	public override bool GetDamaged(float damageAmount)
	{
		//IL_019c: Invalid comparison between F4 and I
		//IL_007c: Expected F4, but got I
		if (_canRetaliate)
		{
			_canRetaliate = false;
			if ((object)hWhip1 != null)
			{
				hWhip1.Fire();
			}
			if ((object)hWhip2 != null)
			{
				hWhip2.Fire();
			}
			if ((object)hWhip3 != null)
			{
				hWhip3.Fire();
			}
			float num = base.PSpeed();
			float num2 = default(float);
			bool flag = !(1f < num2);
			float num3 = 1f;
			if (!flag)
			{
				num3 = num2;
			}
			float num4 = RetaliationDelay / num3;
			float num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10FB4]");
			if (num5 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10FB4]");
				num4 = 0f;
			}
			Action onComplete = delegate
			{
				_canRetaliate = true;
			};
			float duration = num4 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
		return base.GetDamaged(damageAmount);
	}

	public override void LevelUp()
	{
		base.LevelUp();
		Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_LEMURIA1);
		whip1 = weaponByType;
		Weapon weaponByType2 = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_MARTIALWHIP1);
		whip2 = weaponByType2;
		Weapon weaponByType3 = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_HOLYWHIP1);
		whip3 = weaponByType3;
		Weapon weaponByType4 = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_LEMURIA1, searchHidden: true);
		hWhip1 = weaponByType4;
		Weapon weaponByType5 = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_MARTIALWHIP1, searchHidden: true);
		hWhip2 = weaponByType5;
		Weapon weaponByType6 = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_HOLYWHIP1, searchHidden: true);
		hWhip3 = weaponByType6;
		Weapon weapon = hWhip1;
		weapon._skipAddingEvolution = true;
		Weapon weapon2 = hWhip2;
		weapon2._skipAddingEvolution = true;
		Weapon weapon3 = hWhip3;
		weapon3._skipAddingEvolution = true;
		Weapon weapon4 = whip1;
		if ((object)whip1 != null && ((UnityEngine.Object)weapon4).m_CachedPtr != (IntPtr)0)
		{
			Weapon weapon5 = whip1;
			while (true)
			{
				Weapon weapon6 = hWhip1;
				if (((Equipment)weapon5)._003CLevel_003Ek__BackingField <= ((Equipment)weapon6)._003CLevel_003Ek__BackingField)
				{
					break;
				}
				bool flag = hWhip1.LevelUp(skipFire: true);
				weapon5 = whip1;
				if ((object)whip1 != null)
				{
					continue;
				}
				goto IL_0376;
			}
		}
		Weapon weapon7 = whip2;
		if ((object)whip2 != null && ((UnityEngine.Object)weapon7).m_CachedPtr != (IntPtr)0)
		{
			Weapon weapon8 = whip2;
			while (true)
			{
				Weapon weapon9 = hWhip2;
				if (((Equipment)weapon8)._003CLevel_003Ek__BackingField <= ((Equipment)weapon9)._003CLevel_003Ek__BackingField)
				{
					break;
				}
				bool flag2 = hWhip2.LevelUp(skipFire: true);
				weapon8 = whip2;
				if ((object)whip2 != null)
				{
					continue;
				}
				goto IL_0376;
			}
		}
		Weapon weapon10 = whip3;
		if ((object)whip3 == null || ((UnityEngine.Object)weapon10).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Weapon weapon11 = whip3;
		while (true)
		{
			Weapon weapon12 = hWhip3;
			if (((Equipment)weapon11)._003CLevel_003Ek__BackingField > ((Equipment)weapon12)._003CLevel_003Ek__BackingField)
			{
				bool flag3 = hWhip3.LevelUp(skipFire: true);
				weapon11 = whip3;
				continue;
			}
			break;
		}
		return;
		IL_0376:
		throw new NullReferenceException();
	}

	private void _003CGetDamaged_003Eb__9_0()
	{
		_canRetaliate = true;
	}
}
