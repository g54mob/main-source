using System;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Mace1_Weapon : Weapon
	{
		private float maxCooldownOffset;

		private float cooldownOffset;

		private BulletPool _lingerPool;

		[NonSerialized]
		public int ExtraBodyAmount;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override void OnUpdate()
		{
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override void Cleanup()
		{
		}

		protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public Projectile CreateLingerProjectile(int index)
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
