using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Fire1_WeaponCounter : TP_Fire1_Weapon
{
	public override bool IsPrimaryWeapon => false;

	public TP_Fire1_WeaponCounter()
	{
		base._003CCanFireNormally_003Ek__BackingField = true;
		base.GroundRadiusX = 0.32f;
		base.GroundRadiusY = 0.08f;
		_counterWeaponType = WeaponType.TP_FIRE1_COUNTER;
		((Weapon)this)._002Ector();
	}
}
