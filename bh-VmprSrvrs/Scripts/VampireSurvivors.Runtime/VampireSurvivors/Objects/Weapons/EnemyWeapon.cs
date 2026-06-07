using Unity.Mathematics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EnemyWeapon
	{
		public EnemyProjectile _projectilePrefab;

		private EnemyBulletPool _projectilePool;

		public EnemyWeapon(EnemyProjectile projectilePrefab)
		{
		}

		public void Fire(float2 position)
		{
		}

		private bool OnPlayerOverlapsEnemyBullet(CallbackContext context, ArcadeColliderType first, ArcadeColliderType second)
		{
			return false;
		}

		protected virtual bool OnBulletOverlapsWall(CallbackContext context, ArcadeColliderType bullet, ArcadeColliderType tile)
		{
			return false;
		}
	}
}
