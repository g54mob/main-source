using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	[DefaultExecutionOrder(861)]
	public class TP_Rapidus_Projectile : Projectile
	{
		protected Timer _expireTimer;

		protected MultiTargetTween _tween2;

		protected bool isDespawning;

		protected float currentBarrierScale;

		protected const float Radius = 16f;

		public SpriteAnimation _spriteAnimation;

		private Timer _hitboxTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public virtual void OnRecycle()
		{
		}

		public virtual void OnDespawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
