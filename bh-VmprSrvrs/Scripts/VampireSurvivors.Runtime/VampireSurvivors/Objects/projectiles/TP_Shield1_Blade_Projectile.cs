using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Shield1_Blade_Projectile : Projectile
	{
		private MultiTargetTween _posTween;

		private SpriteAnimation _anim;

		private Timer _durationTimer;

		private PhaserSprite _animatedSprite;

		private MultiTargetTween _scaleTween;

		private float radius;

		private float _accelMul;

		private float maxDist;

		private Vector2 initialVelocity;

		private Tween accelTween;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private bool _isDespawning;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetAngleVelocity(float angle)
		{
		}

		private void StartDespawn()
		{
		}

		private void LateUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
