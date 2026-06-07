using System;
using Unity.Mathematics;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_PlaneProjectile : Projectile
	{
		[NonSerialized]
		public Timer timerEvent;

		[NonSerialized]
		public float angleOffset;

		private float _targetAngle;

		public float _dist;

		public float _width;

		public float2 drift;

		public Timer driftTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
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
