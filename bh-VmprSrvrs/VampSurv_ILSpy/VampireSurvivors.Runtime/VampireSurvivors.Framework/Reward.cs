using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.Framework;

public class Reward
{
	public WeaponData Data;

	public WeaponType Weapon;

	public bool IsFood;

	public bool IsCoins;

	public int Value;

	public Reward(WeaponData data, WeaponType weapon, bool isFood = false, bool isCoins = false, int value = 0)
	{
		Data = data;
		bool isCoins2 = default(bool);
		IsCoins = isCoins2;
		int value2 = default(int);
		Value = value2;
		Weapon = weapon;
		IsFood = isFood;
	}
}
