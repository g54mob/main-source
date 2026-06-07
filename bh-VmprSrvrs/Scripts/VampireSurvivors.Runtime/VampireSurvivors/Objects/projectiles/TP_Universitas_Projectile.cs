using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Universitas_Projectile : Projectile
	{
		private TP_Universitas_Weapon trueWeapon;

		private PhaserSprite _sprite1;

		private PhaserSprite _sprite2;

		private PhaserSprite _spriteCircle;

		private PhaserSprite _faderImage;

		private MultiTargetTween _circleTween;

		private MultiTargetTween _faderTween;

		private MultiTargetTween _explosionTween;

		private MultiTargetTween _explosionLoopTween;

		private MultiTargetTween _explosionLoop2Tween;

		private MultiTargetTween _fadeOutTween;

		private MultiTargetTween _fadeOut2Tween;

		private float wHeight;

		private float wWidth;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void DisplayDarkness()
		{
		}

		private void Explode()
		{
		}

		private void ExplosionLoop()
		{
		}

		private void Disappear()
		{
		}

		public override void Despawn()
		{
		}
	}
}
