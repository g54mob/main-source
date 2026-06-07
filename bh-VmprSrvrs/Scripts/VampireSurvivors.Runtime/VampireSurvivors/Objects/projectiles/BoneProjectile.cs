using System;
using DG.Tweening;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BoneProjectile : Projectile
	{
		private Tween _angleTween;

		private Tween _scaleTween;

		private float _saveVelX;

		private float _saveVelY;

		private Timer _bounceTimer;

		private bool _canBounce;

		[NonSerialized]
		public float _physBounce;

		[NonSerialized]
		public bool _accelOnBounce;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void BounceMore()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		private void Bounce(Body bdy, bool up, bool down, bool left, bool right)
		{
		}

		public override void Despawn()
		{
		}
	}
}
