using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_WineGlass2_Weapon : Weapon
	{
		private BulletPool _invisibleProjectilePool;

		private BulletPool _explosionProjectilePool;

		[SerializeField]
		private Projectile _invisibleProjectilePrefab;

		[SerializeField]
		private Projectile _explosionProjectilePrefab;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override float PPower()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public void FireProjectiles(Vector2 position)
		{
		}

		public void FireExplosion(Vector2 position)
		{
		}

		public override void Cleanup()
		{
		}

		protected virtual bool OnFoodOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
