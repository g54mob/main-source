using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class FireballWeapon : Weapon
	{
		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
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
