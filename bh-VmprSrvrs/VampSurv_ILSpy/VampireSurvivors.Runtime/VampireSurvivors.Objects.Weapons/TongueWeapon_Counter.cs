using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class TongueWeapon_Counter : TongueWeapon
{
	protected override WeaponType _counterWeaponType => WeaponType.VOID;

	public override float forwardFacing => -1f;

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
	}
}
