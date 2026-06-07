using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Lapiste2_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _InvisibleProjectilePrefab;

		[SerializeField]
		private Projectile _BigFistProjectilePrefab;

		private BulletPool _invisibleProjectilePool;

		private BulletPool _bigFistProjectilePool;

		private const int BigFistFireInterval = 14;

		private const float BigFistDamageMultiplier = 5f;

		private int _fireCounter;

		public BulletPool InvisibleProjectilePool => null;

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void ParadoxFire()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void GetTargetTransform()
		{
		}

		private void CheckForBigFist()
		{
		}

		private void FireBigFists()
		{
		}

		private bool OnBulletOverlapsEnemy_BigFist(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}
	}
}
