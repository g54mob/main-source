using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Ice1_WeaponCounter : TP_Ice1_Weapon
{
	public override float PlayerFacing => -1f;

	public override bool IsPrimaryWeapon => false;

	public TP_Ice1_WeaponCounter()
	{
		base._003CCanFireNormally_003Ek__BackingField = true;
		_counterWeaponType = WeaponType.TP_ICE1_COUNTER;
		((Weapon)this)._002Ector();
	}
}
