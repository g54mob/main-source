using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class MillionaireProjectile : Projectile
	{
		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter1;

		private ParticleSystem _pfxEmitter2;

		private MultiTargetTween _angleTween;

		private MultiTargetTween _positionTween;

		private PhaserSprite _groundFx;

		private ParticleEmitterManager _pfxEmitterExplosionManager;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private float _radius;

		private float _exploRadius;

		private bool _isBroken;

		private Vector2 _currentDirection;

		private Circle _explosionCircle;

		private Vector2 _target;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetDisplayDirection(bool left)
		{
		}

		private void Break()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
