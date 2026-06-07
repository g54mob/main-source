using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_GreatswordProjectile : Projectile
	{
		[SerializeField]
		protected SpriteRenderer _SwordSprite;

		[SerializeField]
		private ParticleSystem GroundHitFX;

		[SerializeField]
		private SpriteTrail _SpriteTrail;

		protected const float Radius = 28f;

		protected const float ScaleModifier = 0.75f;

		protected const float Gravity = 6.25f;

		protected Sprite _swordSpriteFull;

		protected Sprite _swordSpriteGround;

		protected Vector2 _velocity;

		protected bool _hasLanded;

		protected float _timeToLand;

		protected Timer _landingTimer;

		protected bool _isFlipped;

		protected int _flipSwitch;

		protected Tween _angleTween;

		protected Tween _scaleTween;

		protected Tween _fadeTween;

		protected MultiTargetTween _screenShakeTween;

		protected virtual float MinTimeToLand => 0f;

		protected virtual float MaxTimeToLand => 0f;

		public bool HasLanded => false;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupSwordSprites()
		{
		}

		public override void InternalUpdate()
		{
		}

		protected virtual void InitVelocity()
		{
		}

		protected void UpdateVelocity()
		{
		}

		protected void StartSpinning()
		{
		}

		protected void Land()
		{
		}

		protected virtual void DoGlimmerAttack()
		{
		}

		protected void PlayLandingVfx()
		{
		}

		protected void DoScreenShake()
		{
		}

		protected void EnableTrail(bool enable)
		{
		}

		private void PlayThrowSfx()
		{
		}

		private void PlayLandingSfx()
		{
		}

		public void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
