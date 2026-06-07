using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_PrismCutlassWeapon : Weapon
	{
		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		private bool _fireCounterSet;

		private bool _hasCounterSet;

		private FB_PrismCutlassWeapon _counterSet;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
