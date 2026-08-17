using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Energy1_WeaponCounter : TP_Energy1_Weapon
{
	public override float PlayerFacing => -1f;

	public override bool IsPrimaryWeapon => false;

	public TP_Energy1_WeaponCounter()
	{
		_counterWeaponType = WeaponType.TP_ENERGY1_COUNTER;
		((Weapon)this)._002Ector();
	}
}
