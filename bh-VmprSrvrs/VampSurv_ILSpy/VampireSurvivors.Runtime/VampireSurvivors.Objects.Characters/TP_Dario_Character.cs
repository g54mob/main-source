using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Dario_Character : TP_Character
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
	}

	public unsafe override void LevelUp()
	{
		//IL_00cb: Expected O, but got I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		base.LevelUp();
		object obj = 0;
		while (true)
		{
			WeaponType[] fireDamageTypes = EnemyController.FireDamageTypes;
			if ((nint)obj >= fireDamageTypes.Length)
			{
				break;
			}
			WeaponType[] fireDamageTypes2 = EnemyController.FireDamageTypes;
			Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType((WeaponType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref fireDamageTypes2[obj]));
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				WeaponData currentWeaponData = weaponByType._currentWeaponData;
				float num = currentWeaponData._003Cpower_003Ek__BackingField + 0.05f;
				currentWeaponData._003Cpower_003Ek__BackingField = num;
			}
			obj++;
		}
	}
}
