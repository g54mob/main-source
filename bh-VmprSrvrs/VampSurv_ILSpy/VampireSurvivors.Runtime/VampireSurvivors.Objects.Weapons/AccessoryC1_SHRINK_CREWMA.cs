using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.Objects.Weapons;

public class AccessoryC1_SHRINK_CREWMA : ActiveAccessory
{
	public override void AfterWeaponAdded()
	{
		Weapon hiddenWeaponLinked = HiddenWeaponLinked;
		WeaponData currentWeaponData = hiddenWeaponLinked._currentWeaponData;
		currentWeaponData._003Cinterval_003Ek__BackingField = 2000f;
	}
}
