using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Chauve2_Beam_Projectile : Projectile
	{
		private SpriteRenderer _muzzleFlash;

		private SpriteRenderer _muzzleFlash2;

		private SpriteRenderer _line9Slice;

		private Timer _destructionTimer;

		private float _firingCountdown;

		private float2 _startPosition;

		private float _collisionTween;

		private float2 _lastOwnerPosition;

		private float _MaxAlpha;

		private float _AlphaDiff;

		private float2 _playerTipOffset;

		private TP_Chauve2_Weapon _trueWeapon;

		private float _area;

		private const float Radius = 12f;

		public override float ProjectileSpeed => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void ManualInitProjectile(float2 playerTipOffset, float2 angleVector)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void ActuallyRemove()
		{
		}
	}
}
