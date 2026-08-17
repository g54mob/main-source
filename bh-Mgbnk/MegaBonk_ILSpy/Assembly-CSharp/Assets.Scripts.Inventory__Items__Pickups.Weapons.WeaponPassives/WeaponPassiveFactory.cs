using System;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponPassives;

public class WeaponPassiveFactory
{
	public static WeaponPassive GetWeaponPassive(WeaponBase weaponBase)
	{
		if (weaponBase != null)
		{
			WeaponData weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null)
			{
				WeaponPassiveDice weaponPassiveDice;
				if (weaponData.eWeapon == EWeapon.BloodMagic)
				{
					WeaponPassiveBloodMagic weaponPassiveBloodMagic = null;
					weaponPassiveBloodMagic.stackChance = 0.05f;
					float rollCooldown = WeaponPassiveBloodMagic.maxRollsUpgradesPerMinute / 60f;
					weaponPassiveBloodMagic.rollCooldown = rollCooldown;
					weaponPassiveDice = (WeaponPassiveDice)(object)weaponPassiveBloodMagic;
				}
				else
				{
					if (weaponData.eWeapon != EWeapon.Dice)
					{
						return null;
					}
					WeaponPassiveDice weaponPassiveDice2 = null;
					weaponPassiveDice2.critPer6 = 0.005f;
					weaponPassiveDice2.movingStatName = "DiceCritChance";
					float rollCooldown2 = WeaponPassiveDice.maxRollsUpgradesPerMinute / 60f;
					weaponPassiveDice2.rollCooldown = rollCooldown2;
					weaponPassiveDice = weaponPassiveDice2;
				}
				((WeaponPassive)weaponPassiveDice)._002Ector(weaponBase);
				return weaponPassiveDice;
			}
		}
		return (WeaponPassive)(object)new NullReferenceException();
	}
}
