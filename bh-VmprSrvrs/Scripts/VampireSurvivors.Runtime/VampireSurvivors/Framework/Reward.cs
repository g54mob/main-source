using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.Framework
{
	public class Reward
	{
		public WeaponData Data;

		public WeaponType Weapon;

		public bool IsFood;

		public bool IsCoins;

		public int Value;

		public Reward(WeaponData data, WeaponType weapon, bool isFood = false, bool isCoins = false, int value = 0)
		{
		}
	}
}
