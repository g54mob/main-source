using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Cart2Projectile : Projectile
	{
		private ParticleSystem _pfxEmitter;

		private SpriteAnimation _spriteAnimator;

		private float _defaultSpeed;

		private bool _makeSparks;

		private bool _enterTweenCompleted;

		private bool _isGoingRight;

		private float _save_vel_x;

		private float _save_vel_y;

		private Tween _enterTween;

		private Sequence _fadeOutTween;

		private Tween _scaleTween;

		private Tween _xTween;

		private bool _isFadingOut;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		protected void Bounce(Body body, bool up, bool down, bool left, bool right)
		{
		}

		private void FadeOut()
		{
		}

		private void OnBounce()
		{
		}

		private void GenerateAnims()
		{
		}

		private void SetDepths()
		{
		}

		private void GeneratePfx()
		{
		}
	}
}
