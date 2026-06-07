using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Valmanway2_Projectile : Projectile
	{
		private const float Radius = 36f;

		private const float Speed = 4f;

		private PhaserSprite _slashSprite;

		private PhaserSprite _ghostSprite1;

		private PhaserSprite _ghostSprite2;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _spriteScaleTween;

		private MultiTargetTween _alphaTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitSprites()
		{
		}

		private void InitBounce()
		{
		}

		private void InitAiming()
		{
		}

		private void PlaySfx()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateRotation()
		{
		}

		public override void Despawn()
		{
		}

		private void Bounce(Body body, bool up, bool down, bool left, bool right)
		{
		}
	}
}
