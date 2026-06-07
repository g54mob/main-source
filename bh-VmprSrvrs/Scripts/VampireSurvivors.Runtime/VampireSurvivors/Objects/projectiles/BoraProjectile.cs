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
	public class BoraProjectile : Projectile
	{
		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter1;

		private ParticleSystem _pfxEmitter2;

		private MultiTargetTween _angleTween;

		private MultiTargetTween _positionTween;

		[SerializeField]
		private PhaserSprite _GroundFx;

		private ParticleEmitterManager _pfxEmitterExplosionManager;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private Timer _despawnTimer;

		private float _radius;

		private float _exploRadius;

		private bool _isBroken;

		private float _groundFxAlpha;

		private Vector2 _currentDirection;

		private Circle _explosionCircle;

		private MultiTargetTween _fadeOutTween;

		private MultiTargetTween _scaleGroundTween;

		private MultiTargetTween _growTween;

		private Timer _chooseTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void GoTowardsNearestEnemyToOwner()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void Break()
		{
		}

		private void StartDespawn()
		{
		}

		private void KillTweens()
		{
		}
	}
}
