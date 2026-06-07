using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SpiritTornado2_SpiritGemProjectile : Projectile
	{
		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfxEmitter;

		private Pickup _objectToFollow;

		public bool SpawnExplosion { get; set; }

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void Follow(Pickup objectToFollow)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}
