using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class NightSwordProjectile : Projectile
	{
		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private NightSwordWeapon _trueWeapon;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter;

		private bool _initialisedParticles;

		private bool _isFinisher;

		protected override void Awake()
		{
		}

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
