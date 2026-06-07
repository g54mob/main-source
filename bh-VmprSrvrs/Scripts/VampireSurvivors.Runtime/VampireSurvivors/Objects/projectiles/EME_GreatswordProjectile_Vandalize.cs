using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_GreatswordProjectile_Vandalize : Projectile
	{
		[SerializeField]
		private SpriteRenderer _SwordSprite;

		[SerializeField]
		private ParticleSystem GroundHitFX;

		[SerializeField]
		private SpriteTrail _SpriteTrail;

		private const float ScaleModifier = 2f;

		private const float MaxAreaLimit = 2.5f;

		private int _smashCounter;

		private int _maxSmashes;

		private Tween _fadeTween;

		private MultiTargetTween _angleTween;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _screenShakeTween;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void TweenIn()
		{
		}

		private void DoSmash()
		{
		}

		private void UpdatePosition()
		{
		}

		private void PlaySfx()
		{
		}

		private void UpdateBody()
		{
		}

		private void PlaySmashVfx()
		{
		}

		private void DoScreenShake()
		{
		}

		protected void EnableTrail(bool enable)
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
