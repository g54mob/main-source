using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MechProjectile : Projectile
	{
		[SerializeField]
		private ParticleSystem _MissileVFX;

		[SerializeField]
		private TrailRenderer _Trail;

		private const float Radius = 12f;

		private const float DecelRate = 2f;

		private const float AccelRate = 5f;

		private const float ArmingDuration = 500f;

		private const float VFXScale = 1f;

		private Vector2 _velocity;

		private Vector2 _cachedVelocity;

		private float _cachedWeaponSpeed;

		private bool _isDecelerating;

		private bool _isAccelerating;

		private bool _canExplode;

		private bool _explosionIsOnCooldown;

		private const float ExplosionCooldownDuration = 100f;

		private Timer _movementTimer;

		private Timer _explosionCooldownTimer;

		private EME_Mech1Weapon _trueWeapon;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected virtual void SetupMovementPattern()
		{
		}

		private void CaluclateInitialVelocity()
		{
		}

		public void InvertVelocity()
		{
		}

		public void MultiplyVelocity(float multiplier)
		{
		}

		protected void UpdateVelocity()
		{
		}

		protected void SetupTrail()
		{
		}

		protected void EnableTrail(bool enable)
		{
		}

		private void PlaySfx()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
		{
		}

		public override void Despawn()
		{
		}
	}
}
