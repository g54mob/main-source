using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_RapierProjectile_Mega : Projectile
	{
		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter;

		private bool _initialisedParticles;

		private EME_RapierWeapon _trueWeapon;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void SetNullTarget()
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
