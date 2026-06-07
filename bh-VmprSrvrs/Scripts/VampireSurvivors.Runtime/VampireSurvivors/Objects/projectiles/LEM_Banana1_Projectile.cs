using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LEM_Banana1_Projectile : Projectile
	{
		[SerializeField]
		private SpriteTrail _SpriteTrail;

		[SerializeField]
		private SpriteRenderer _SpriteTrailSprite;

		protected readonly float2 RotationDegRange;

		protected LEM_Banana1_Weapon _trueWeapon;

		protected PhaserSprite _bananaSprite;

		protected float _rotationDeg;

		protected int _flipSign;

		protected Timer _expireTimer;

		protected virtual float Radius => 0f;

		protected virtual SpriteTextureData BananaSprite => default(SpriteTextureData);

		protected virtual SpriteTextureData TrailSprite => default(SpriteTextureData);

		protected virtual float BananaSpriteScale => 0f;

		protected virtual float LaunchAngleOffset => 0f;

		protected float CurveAnglePerSec => 0f;

		protected float RotationDegPerSec => 0f;

		public bool IsCrit { get; private set; }

		public bool HasExploded { get; set; }

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void CheckForCrit()
		{
		}

		private void InitPositionAndRotation()
		{
		}

		private void ResetExpireTimer()
		{
		}

		public void SetBehaviour(Vector2 playerDir)
		{
		}

		protected void SetFlipFromPlayerDirection(Vector2 playerDir)
		{
		}

		protected virtual void AimInDirection(Vector2 playerDir)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateVelocity()
		{
		}

		private void UpdateRotation()
		{
		}

		protected virtual void PlayThrowSfx()
		{
		}

		private void PlayBounceSfx()
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

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
		{
		}
	}
}
