using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class VictoryProjectile : Projectile
	{
		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private VictoryWeapon _trueWeapon;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter;

		private bool _initialisedParticles;

		private bool _isFinisher;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		public override void SetNullTarget()
		{
		}

		public override void SetTarget(Transform target)
		{
		}
	}
}
