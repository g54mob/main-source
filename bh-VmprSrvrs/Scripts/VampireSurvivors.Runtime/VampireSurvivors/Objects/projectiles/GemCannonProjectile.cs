using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class GemCannonProjectile : Projectile
	{
		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfxEmitter;

		private void Start()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}
