using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_RapidFireProjectile : Projectile
	{
		private Timer _timerEvent;

		private MultiTargetTween _hideTween;

		private float _save_vel_x;

		private float _save_vel_y;

		private Vector2 _aimVector;

		private float _bulletDeceleration;

		private TweenerCore<float, float, FloatOptions> _speedTween;

		protected Sprite cachedSprite;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected virtual Vector2 calDirection()
		{
			return default(Vector2);
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
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
