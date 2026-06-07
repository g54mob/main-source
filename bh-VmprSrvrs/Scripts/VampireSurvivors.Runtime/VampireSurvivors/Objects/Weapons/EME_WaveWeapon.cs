using UnityEngine;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_WaveWeapon : Weapon
	{
		[SerializeField]
		private ParticleSystem _pfxEmitter;

		[SerializeField]
		private ParticleSystem _pfxEmitter2;

		[SerializeField]
		protected Projectile _LinePrefab;

		protected BulletPool _linePool;

		public virtual bool IsEvolved => false;

		protected override int ProjectilePoolSize => 0;

		protected override void OnStart()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemyWave(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public void Rapture(EnemyController enemy)
		{
		}

		public void RaptureDamage(EnemyController enemy, bool risky = true)
		{
		}
	}
}
