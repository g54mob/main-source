using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class LEM_Banana1_Weapon : LEM_BaseWeapon
	{
		[SerializeField]
		private Projectile _CritExplosionPrefab;

		private BulletPool _critExplosionPool;

		public virtual bool DespawnOnExplode => false;

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void FireOneBananaProjectile(Vector2 pos, int index, Vector2 playerDir)
		{
		}

		public bool IsCritProjectile()
		{
			return false;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private void DealProjectileDamage(IDamageable other, LEM_Banana1_Projectile projectile)
		{
		}

		protected override float CalcCritMul()
		{
			return 0f;
		}

		private void SpawnExplosionOnCrit(EnemyController target, LEM_Banana1_Projectile projectile)
		{
		}

		private bool OnExplosionOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}
	}
}
