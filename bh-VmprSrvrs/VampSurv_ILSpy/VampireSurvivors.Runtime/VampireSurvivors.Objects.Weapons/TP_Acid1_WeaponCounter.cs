using System;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Acid1_WeaponCounter : TP_Acid1_Weapon
{
	public override bool IsPrimaryWeapon => false;

	public TP_Acid1_WeaponCounter()
	{
		base._003CCanFireNormally_003Ek__BackingField = true;
		base._angleUnit = 0.0174533f;
		base._targetAngle = (float)Math.PI / 2f;
		base._mul = 333.33334f;
		_counterWeaponType = WeaponType.TP_ACID1_COUNTER;
		((Weapon)this)._002Ector();
	}
}
