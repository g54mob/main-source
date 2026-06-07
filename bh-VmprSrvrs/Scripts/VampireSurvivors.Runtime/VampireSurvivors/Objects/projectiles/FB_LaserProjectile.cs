using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_LaserProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _trail;

		private SpriteRenderer _muzzleFlash;

		private SpriteRenderer _muzzleFlash2;

		private Timer _destructionTimer;

		private float _firingCountdown;

		private float2 _startPosition;

		private float _collisionTween;

		private float2 _lastOwnerPosition;

		private float _MaxAlpha;

		private float _AlphaDiff;

		private Vector2 TrailTextureScale => default(Vector2);

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void AdjustLine(float2 amount)
		{
		}

		public override void Despawn()
		{
		}

		private void ActuallyRemove()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
