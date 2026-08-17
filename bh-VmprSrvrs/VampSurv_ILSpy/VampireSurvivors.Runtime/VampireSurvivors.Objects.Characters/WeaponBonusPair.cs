using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

internal class WeaponBonusPair(WeaponType wtype, float v)
{
	public WeaponType weaponType = wtype;

	public float bonusValue = v;
}
