using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class VentWeapon : Weapon
	{
		private int _ventLimit;

		protected override void Awake()
		{
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override bool OnBulletOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override bool OnBulletOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
