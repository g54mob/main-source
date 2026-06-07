using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BattiliaProjectile : Projectile
	{
		protected float fixedDuration;

		protected uint shadowTint;

		private float _currentDirectionX;

		private float _currentDirectionY;

		private Timer _expireTimer;

		protected PhaserSprite _batSprite;

		protected PhaserSprite _shadowSprite;

		private float2 previousPosition;

		private BattiliaWeapon trueWeapon;

		private bool isInitialised;

		private bool isFirstUpdate;

		public float TrueSpeed => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected virtual void SetAnims()
		{
		}

		protected virtual void SetColors()
		{
		}

		public override void ApplyInitialVelocity(Transform target, Transform playerTransform, bool rotate = true, Vector3? customFromPosition = null)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public void RestoreVelocity()
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
