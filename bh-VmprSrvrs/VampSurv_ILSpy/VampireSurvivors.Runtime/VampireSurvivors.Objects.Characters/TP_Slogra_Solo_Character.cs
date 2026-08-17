using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Slogra_Solo_Character : TP_Character
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_CHAUVE1);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			WeaponData currentWeaponData = weaponByType._currentWeaponData;
			weaponByType.IsAdept = true;
			float num = currentWeaponData._003Cinterval_003Ek__BackingField * 0.5f;
			currentWeaponData._003Cinterval_003Ek__BackingField = num;
		}
	}
}
