using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MechProjectile_CosmicRave : Projectile
	{
		[SerializeField]
		private SpriteRenderer _CloneSprite;

		[SerializeField]
		private SpriteRenderer _BackgroundSprite;

		[SerializeField]
		private TrailRenderer _Trail;

		private const float Radius = 16f;

		private const float DecelRate = 2f;

		private const float AccelRate = 5f;

		private const float TrailWidth = 0.05f;

		private float _cachedWeaponSpeed;

		private float _currentSpeed;

		private float _turnSpeed;

		private float _scaledTurnSpeed;

		private float _currentAngle;

		private bool _isDecelerating;

		private bool _isTurning;

		private bool _isAccelerating;

		private Timer _movementTimer;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private SpriteAnimation _cloneAnim;

		private EME_Mech1Weapon _trueWeapon;

		private MaterialPropertyBlock _propBlock;

		private MultiTargetTween _tintTween;

		private MultiTargetTween _scaleTween;

		private List<uint> _tints;

		private Timer _vfxTimer;

		private bool _canVFX;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void ApplyVelocityTowardsScreenCentre()
		{
		}

		private void SetMovementPattern()
		{
		}

		private void UpdateVelocity()
		{
		}

		private void StartHitboxTimer()
		{
		}

		private void StopHitboxTimer()
		{
		}

		private void SetupCloneSprite()
		{
		}

		private void UpdateCloneSprite()
		{
		}

		private void SetupTrail()
		{
		}

		private void UpdateTrail()
		{
		}

		private void SetCloneTintFill()
		{
		}

		private void DoBackgroundTintTween()
		{
		}

		private void DoScaleInTween(float duration)
		{
		}

		private void DoScaleOutTween()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
