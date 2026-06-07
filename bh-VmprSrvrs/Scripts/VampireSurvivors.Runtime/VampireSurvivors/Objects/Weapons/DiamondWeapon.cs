using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class DiamondWeapon : Weapon
	{
		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
