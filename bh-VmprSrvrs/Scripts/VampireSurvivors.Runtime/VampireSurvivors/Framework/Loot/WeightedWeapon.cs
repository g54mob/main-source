using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loot
{
	public class WeightedWeapon
	{
		private WeaponType _weaponType;

		private int _weight;

		public WeaponType WeaponType => default(WeaponType);

		public int Weight => 0;

		public WeightedWeapon(WeaponType weaponType, int weight)
		{
		}
	}
}
