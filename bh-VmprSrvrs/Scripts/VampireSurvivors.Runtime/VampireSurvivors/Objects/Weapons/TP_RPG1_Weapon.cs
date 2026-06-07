using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_RPG1_Weapon : Weapon
	{
		protected float exploRadius;

		private BulletPool _invisibleProjectilePool;

		[SerializeField]
		private Projectile _invisibleProjectilePrefab;

		protected override void Awake()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void SpawnExplosionClustersAt(float2 pos)
		{
		}

		public void SpawnExplosionWavesAt(Vector2 pos, Vector2 velocity)
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
