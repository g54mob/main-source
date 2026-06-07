using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Hydrostorm2_BoraProjectile : Projectile
	{
		private const float BodyRadius = 16f;

		private const float GroundFxAlpha = 0.2f;

		private const float BaseGroundSpeed = 25f;

		private bool _isBroken;

		private Vector3 _targetPos;

		private Vector2 _currentDirection;

		private float _groundArea;

		private PhaserSprite _bottleSprite;

		private PhaserSprite _groundFx;

		private ParticleEmitterManager _pfxEmitterExplosionManager;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter1;

		private ParticleSystem _pfxEmitter2;

		private MultiTargetTween _angleTween;

		private Tween _bottlePositionTween;

		private Tween _groundScaleInTween;

		private Tween _groundGrowTween;

		private Tween _groundFadeOutTween;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private Timer _despawnTimer;

		private Timer _groundHomingTimer;

		private float PfxRadius => 0f;

		private float BaseGroundArea => 0f;

		private float GroundDuration => 0f;

		private float BonusGroundSpeed => 0f;

		private Vector2 GroundVelocity => default(Vector2);

		private TP_Hydrostorm2_Weapon TrueWeapon => null;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitVfx()
		{
		}

		private void StartRotation()
		{
		}

		private void SetTargetPosition()
		{
		}

		private Vector2 GetRandomPointOnScreen()
		{
			return default(Vector2);
		}

		private void MoveToTargetPosition()
		{
		}

		private void Break()
		{
		}

		private void GrowGroundSize()
		{
		}

		public void SeekNearestEnemyToOwner()
		{
		}

		private void PlaySfx()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateGroundPfx()
		{
		}

		private void UpdateGroundDepth()
		{
		}

		private void UpdateGroundVelocity()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void KillTweens()
		{
		}

		private void KillTimers()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
