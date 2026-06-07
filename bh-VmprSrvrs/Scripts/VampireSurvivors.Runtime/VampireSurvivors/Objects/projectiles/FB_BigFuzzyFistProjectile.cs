using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_BigFuzzyFistProjectile : Projectile
	{
		private PhaserSprite _explosion;

		private PhaserSprite _crack;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void GenerateParticleSystem()
		{
		}

		public override void Despawn()
		{
		}

		private void SetupVisuals()
		{
		}

		private void OnAnimationComplete()
		{
		}
	}
}
