using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TriaceProjectile : Projectile
	{
		private ParticleEmitterManager _PfxEmitter;

		private PhaserSprite _GroundFx;

		private MultiTargetTween _ScaleTween;

		private MultiTargetTween _AlphaTween;

		private float _radius;

		private uint _myColor;

		private ParticleSystem _projEmitter;

		private float _timeToReach;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}

		public override void SetTarget(Transform target)
		{
		}
	}
}
