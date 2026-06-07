using Unity.Mathematics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Unused_TP_WindWhip1_Weapon : TP_WhipCore1_Weapon
	{
		protected BulletPool _firePool;

		protected BulletPool _explosionPool;

		protected override void Awake()
		{
		}

		public Projectile CreateFireProjectile(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
		{
			return null;
		}

		public Projectile SpawnWhipExplosionAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
