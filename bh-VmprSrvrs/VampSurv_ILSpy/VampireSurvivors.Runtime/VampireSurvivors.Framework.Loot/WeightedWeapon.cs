using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loot;

public class WeightedWeapon
{
	private WeaponType _weaponType;

	private int _weight;

	public WeaponType WeaponType => _weaponType;

	public int Weight => _weight;

	public WeightedWeapon(WeaponType weaponType, int weight)
	{
		_weaponType = weaponType;
		_weight = weight;
	}
}
