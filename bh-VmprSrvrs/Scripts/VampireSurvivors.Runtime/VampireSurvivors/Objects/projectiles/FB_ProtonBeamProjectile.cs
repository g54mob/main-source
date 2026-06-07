using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_ProtonBeamProjectile : Projectile
	{
		private SpriteRenderer _muzzleFlash;

		private SpriteRenderer _muzzleFlash2;

		private SpriteRenderer _line9Slice;

		private Timer _destructionTimer;

		private Timer _canSplitTimer;

		private float _firingCountdown;

		private float2 _startPosition;

		private float _collisionTween;

		private bool _hasSplit;

		private bool _canSplit;

		private float2 _lastOwnerPosition;

		private IDamageable _ignoreHitObject;

		private float _MaxAlpha;

		private float _AlphaDiff;

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
