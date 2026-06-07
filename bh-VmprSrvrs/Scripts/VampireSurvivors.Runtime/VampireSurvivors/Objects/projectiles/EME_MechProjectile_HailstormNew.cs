using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MechProjectile_HailstormNew : Projectile
	{
		[SerializeField]
		private ParticleSystem _MissileVFX;

		[SerializeField]
		private TrailRenderer _Trail;

		private const float VFXScale = 0.75f;

		private const float TrailDuration = 800f;

		private const float AccelRate = 1.5f;

		private const float BaseTurnSpeed = 425f;

		private const float TurnSpeedModifier = 15f;

		private const float InitialAngleModifier = 5f;

		private const float MinTimeToExplode = 150f;

		private const float MaxTimeToExplode = 250f;

		private bool _isTurning;

		private float _currentTurnSpeed;

		private float _currentSpeed;

		private float _currentAngle;

		private float _scaledTurnSpeed;

		private float _cachedWeaponSpeed;

		private Timer _movementTimer;

		private Timer _expireTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateVelocity()
		{
		}

		private void SetMovementPattern()
		{
		}

		private void SetupTrail()
		{
		}

		private void Explode()
		{
		}

		private void PlaySfx()
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
