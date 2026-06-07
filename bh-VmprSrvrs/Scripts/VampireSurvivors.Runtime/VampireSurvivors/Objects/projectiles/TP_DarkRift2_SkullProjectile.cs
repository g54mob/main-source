using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_DarkRift2_SkullProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail;

		private const float Radius = 32f;

		private const float Percentage = 0.125f;

		private const float SpeedModifier = 35f;

		private float _deltaTime;

		private float _outwardSpeed;

		private TP_DarkRift2_Weapon _trueWeapon;

		private float _cachedScale;

		private Timer _expireTimer;

		private Timer _trailTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void InitTrail()
		{
		}

		public void InitMovement()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateMovement()
		{
		}

		private void UpdateTrail()
		{
		}

		public override void Despawn()
		{
		}
	}
}
