using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MechProjectile_BallisticMissile : Projectile
	{
		[SerializeField]
		private ParticleSystem _MissileVFX;

		[SerializeField]
		private TrailRenderer _Trail;

		private const float VFXScale = 0.75f;

		private const float TrailDuration = 800f;

		protected Timer _movementTimer;

		protected Timer _expireTimer;

		private bool _cachedFlipX;

		private float _cachedWeaponSpeed;

		private float _cachedProjSpeed;

		private float _currentSpeed;

		private float _currentAngle;

		protected float _scaledTurnSpeed;

		protected float _scaledTurnDuration;

		protected float _scaledTurnDelay;

		private bool _isDecelerating;

		private bool _isTurning;

		private bool _isAccelerating;

		private bool _isDespawning;

		protected virtual float Radius => 0f;

		protected virtual float2 SpawnOffset => default(float2);

		protected virtual List<float> SpawnAngles => null;

		protected virtual float TurnSpeed => 0f;

		protected virtual float TurnDuration => 0f;

		protected virtual float TurnDelay => 0f;

		protected virtual float DecelRate => 0f;

		protected virtual float AccelRate => 0f;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void CheckHittingScreenEdges()
		{
		}

		protected virtual void OnHitScreenEdgeTop()
		{
		}

		protected virtual void OnHitScreenEdgeBottom()
		{
		}

		protected virtual void OnHitScreenEdgeRight()
		{
		}

		protected virtual void OnHitScreenEdgeLeft()
		{
		}

		protected virtual void SetMovementPattern()
		{
		}

		protected void UpdateVelocity()
		{
		}

		protected void StartDecelerating()
		{
		}

		protected void EnableTurning(bool enable)
		{
		}

		protected void StartAccelerating()
		{
		}

		protected void ResetMovementSpeed()
		{
		}

		protected void EnableTrail(bool enable)
		{
		}

		private void SetupTrail()
		{
		}

		private void PlaySfx()
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
