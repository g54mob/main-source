using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Evil1_WeaponCounter : TP_Evil1_Weapon
{
	public override bool IsPrimaryWeapon => false;

	public TP_Evil1_WeaponCounter()
	{
		base._003CCanFireNormally_003Ek__BackingField = true;
		_counterWeaponType = WeaponType.TP_EVIL1_COUNTER;
		((Weapon)this)._002Ector();
	}
}
