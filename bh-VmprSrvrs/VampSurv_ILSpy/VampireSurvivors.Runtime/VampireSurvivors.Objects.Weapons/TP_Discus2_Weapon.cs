using System;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Discus2_Weapon : TP_Discus1_Weapon
{
	public override float PPower()
	{
		CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((characterController._isInvul || characterController._receivingDamage) ? 2f : 1f);
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
				float num3 = currentWeaponData._003Cpower_003Ek__BackingField * num2;
				float num4 = num3 * num;
				return num2 + num4;
			}
		}
		throw new NullReferenceException();
	}
}
