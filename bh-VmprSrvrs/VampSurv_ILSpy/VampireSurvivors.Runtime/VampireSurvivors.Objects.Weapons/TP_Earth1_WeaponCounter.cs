using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Earth1_WeaponCounter : TP_Earth1_Weapon
{
	public override float PlayerFacing => -1f;

	public override bool IsPrimaryWeapon => false;

	public TP_Earth1_WeaponCounter()
	{
		base._003CCanFireNormally_003Ek__BackingField = true;
		base._topBarHeight = 0.2f;
		_counterWeaponType = WeaponType.TP_EARTH1_COUNTER;
		((Weapon)this)._002Ector();
	}
}
