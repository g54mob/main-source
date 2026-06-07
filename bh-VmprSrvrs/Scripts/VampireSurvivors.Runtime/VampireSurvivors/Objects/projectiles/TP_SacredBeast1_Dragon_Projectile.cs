using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SacredBeast1_Dragon_Projectile : Projectile
	{
		private Timer _expireTimer;

		private float _offset;

		private Vector2 _direction;

		private float2 _centralPos;

		private float _offsetDist;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public float2 PickPosition()
		{
			return default(float2);
		}

		public override void Despawn()
		{
		}
	}
}
