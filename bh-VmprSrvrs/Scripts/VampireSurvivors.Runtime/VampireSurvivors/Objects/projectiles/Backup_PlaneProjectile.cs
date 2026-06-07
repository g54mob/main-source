using System;
using Unity.Mathematics;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Backup_PlaneProjectile : Projectile
	{
		private float2 _targetPosition;

		private float _timeSinceChangedTarget;

		private Timer _timerEvent;

		public BulletPool bulletPool;

		[NonSerialized]
		public float planeAngleOffset;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void RefreshTarget()
		{
		}

		private void fireBullet()
		{
		}

		public override void Despawn()
		{
		}
	}
}
