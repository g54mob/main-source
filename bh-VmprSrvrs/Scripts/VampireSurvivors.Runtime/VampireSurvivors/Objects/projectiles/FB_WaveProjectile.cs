using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_WaveProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _SpriteRenderer;

		[SerializeField]
		private SpriteTrail _Trail;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _fadeTween;

		private PhaserSprite _sonicSprite;

		private SpriteAnimation _spriteAnim;

		private bool _isFadingOut;

		public bool IsCharged;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void MakeBasicProjectile()
		{
		}

		public void MakeChargedProjectile()
		{
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

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void FadeOut()
		{
		}
	}
}
