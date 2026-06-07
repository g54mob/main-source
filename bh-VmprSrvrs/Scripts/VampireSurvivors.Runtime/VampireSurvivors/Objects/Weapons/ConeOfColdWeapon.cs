using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons
{
	public class ConeOfColdWeapon : Weapon
	{
		private const WeaponType COUNTER_WEAPON_TYPE = WeaponType.CONEOFCOLD_COUNTER;

		private Weapon _counterWeapon;

		protected override void Awake()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
